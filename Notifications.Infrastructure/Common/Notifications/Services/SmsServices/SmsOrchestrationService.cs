using AutoMapper;
using Notifications.Application.Commoon.Identity;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Notifications.Services.SmsServices;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Domain.Extensions;
using Notifications.Persistance.DataContexts;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsRenderService _smsRenderService;
    private readonly ISmsHistoryService _smsHistoryService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly NotificationDbContext _notificationDbContext;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public SmsOrchestrationService(
        IMapper mapper,
        IUserService userService,
        NotificationDbContext notificationDbContext,
        ISmsTemplateService smsTemplateService,
        ISmsSenderService smsSenderService,
        ISmsRenderService smsRenderService,
        ISmsHistoryService smsHistoryService)
    {
        _userService = userService;
        _mapper = mapper;
        _notificationDbContext = notificationDbContext;
        _smsSenderService = smsSenderService;
        _smsRenderService = smsRenderService;
        _smsHistoryService = smsHistoryService;
        _smsTemplateService = smsTemplateService;
    }


    public async ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest smsNotificationRequest,
        // string  senderPhoneNumber,
        // string receiverPhoneNumber, NotificationTemplateType templateType, 
        // Dictionary<string, string> variables, 
        CancellationToken cancellationToken = default)
    {
        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<SmsMessage>(smsNotificationRequest);

            // get users
            // set receiver phone number and sender phone number
            var senderUser =
                (await _userService.GetByIdAsync(smsNotificationRequest.SenderUserId!.Value, cancellationToken: cancellationToken))!;

            var receiverUser =
                (await _userService.GetByIdAsync(smsNotificationRequest.ReceiverUserId, cancellationToken: cancellationToken))!;

            message.SenderPhoneNumber = senderUser.PhoneNumber;
            message.ReceiverPhoneNumber = receiverUser.PhoneNumber;

            // get template
            message.Template =
                await _smsTemplateService.GetByTypeAsync(smsNotificationRequest.TemplateType, true, cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {NotificationType.Sms} notification");

            // blogs.Comments.Add(new Comment { Title = "My comment" });

            // render template
            await _smsRenderService.RenderAsync(message, cancellationToken);

            // send message
            await _smsSenderService.SendAsync(message, cancellationToken);

            // save history

            var history = _mapper.Map<SmsHistory>(message);
            var test = _notificationDbContext.Entry(history.Template).State;

            await _smsHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsync();
    }
}