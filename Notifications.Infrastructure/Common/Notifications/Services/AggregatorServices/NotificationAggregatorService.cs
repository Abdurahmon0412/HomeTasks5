using AutoMapper;
using Microsoft.Extensions.Options;
using Notifications.Application.Commoon.Identity;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Domain.Extensions;
using Notifications.Infrastructure.Common.Settings;

namespace Notifications.Infrastructure.Common.Notifications.Services.AggregatorServices;

public class NotificationAggregatorService : INotificationAggregatorService
{
    private readonly IMapper _mapper;
    private readonly IOptions<NotificationSettigs> _notificationSettings;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly ISmsOrchestrationService _smsOrchestrationService;
    private IEmailOrchestrationService _emailOrchestrationService;
    private IUserSettingsService _userSettingsService;
    private IUserService _userService;

    public NotificationAggregatorService(
        IMapper mapper,
        IOptions<NotificationSettigs> notificationSettings,
        ISmsTemplateService smsTemplateService,
        IEmailTemplateService emailTemplateService,
        ISmsOrchestrationService smsOrchestrationService,
        IEmailOrchestrationService emailOrchestrationService,
        IUserSettingsService userSettingsService,
        IUserService userService)
    {
        _mapper = mapper;
        _notificationSettings = notificationSettings;
        _smsTemplateService = smsTemplateService;
        _emailTemplateService = emailTemplateService;
        _smsOrchestrationService = smsOrchestrationService;
        _emailOrchestrationService = emailOrchestrationService;
        _userSettingsService = userSettingsService;
        _userService = userService;
    }

    public async ValueTask<IList<NotificationTemplate>> GetTEmplatesByFilterAsync(NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default)
    {
        var templates = new List<NotificationTemplate>();
        if(filter.TemplateType.Contains(NotificationType.Sms))
            templates.AddRange(await  _smsTemplateService.GetByFilterAsync(filter, cancellationToken:cancellationToken));
        
        if(filter.TemplateType.Contains(NotificationType.Email))
            templates.AddRange(await _emailTemplateService.GetByFilterAsync(filter,cancellationToken:cancellationToken));

        return templates;
    }

    public async ValueTask<FuncResult<bool>> SendAsync(NotificationRequest notificationRequest,
        CancellationToken cancellationToken = default)
    {
        var sendNotificationTask = async () =>
        {
            // If sender is not specified, get system user
            var senderUser = notificationRequest.SenderUserId.HasValue
                ? await _userService.GetByIdAsync(notificationRequest.SenderUserId.Value,
                    cancellationToken: cancellationToken)
                : await _userService.GetSystemUserAsync(true, cancellationToken: cancellationToken);

            notificationRequest.SenderUserId = senderUser!.Id;

            var receiverUser = _userService.GetByIdAsync(notificationRequest.ReceiverUserId,
                cancellationToken: cancellationToken);
            
            // If notification provider type is not specified, get from receiver user settings
            // if (!notificationRequest.Type.HasValue && receiverUser!.UserSettings.PreferredNotificationType.HasValue)
            //     notificationRequest.Type = receiverUser!.UserSettings.PreferredNotificationType!.Value;

            // If user not specified preferred notification type get from settings
            if (!notificationRequest.Type.HasValue)
                notificationRequest.Type = _notificationSettings.Value.DefaultNotificationType;
            
            var sendNotificationTask = notificationRequest.Type switch
            {
                NotificationType.Sms => _smsOrchestrationService.SendAsync(
                    _mapper.Map<SmsNotificationRequest>(notificationRequest),
                    cancellationToken),
                NotificationType.Email => _emailOrchestrationService.SendAsync(
                    _mapper.Map<EmailNotificationRequest>(notificationRequest),
                    cancellationToken),
                _ => throw new NotImplementedException("This type of notification is not supported yet.")
            };

            var sendNotificationResult = await sendNotificationTask;
            return sendNotificationResult.Data;
        };

        return await sendNotificationTask.GetValueAsync();
    }
}