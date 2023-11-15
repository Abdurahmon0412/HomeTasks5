using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Notifications.Services.SmsServices;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Domain.Extensions;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsRenderService _smsRenderService;
    private readonly ISmsHistoryService _smsHistoryService;

    public SmsOrchestrationService(
        ISmsSenderService smsSenderService, 
        ISmsRenderService smsRenderService,
        ISmsHistoryService smsHistoryService)
    {
        _smsSenderService = smsSenderService;
        _smsRenderService = smsRenderService;
        _smsHistoryService = smsHistoryService;
    }


    public async ValueTask<FuncResult<bool>> SendAsync(
        string  senderPhoneNumber,
        string receiverPhoneNumber, NotificationTemplateType templateType, 
        Dictionary<string, string> variables, 
        CancellationToken cancellationToken = default)
    {
        // validate

        var test = async () =>
        {
            var template = GetTemplate(templateType);

            var message = _smsRenderService.RenderMessage(template, variables);

            await _smsSenderService.SendAsync(senderPhoneNumber, receiverPhoneNumber, message, cancellationToken);

            var smsHistory = new SmsHistory
            {
                SenderPhoneNumber = senderPhoneNumber,
                ReceiverPhoneNumber = receiverPhoneNumber,
                Content = message,
                Type = NotificationType.Sms,
            };

            await _smsHistoryService.CreateAsync(smsHistory, true, cancellationToken);

            return true;
        };

        return await test.GetValueAsync();
    }

    public static string GetTemplate(NotificationTemplateType templateType)
    {
        var template = templateType switch
        {
            NotificationTemplateType.SystemWelcomeNotification => "Welcome to the system, {{UserName}}",
            NotificationTemplateType.EmailVerificationNotification => "Verify your email by clicking the link, {{VerificationLink}}",
            _ => throw new ArgumentOutOfRangeException(nameof(templateType), "")
        };

        return template;
    }
}