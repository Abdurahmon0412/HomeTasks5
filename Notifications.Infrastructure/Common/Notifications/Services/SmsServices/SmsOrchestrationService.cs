using AutoMapper;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Notifications.Services.SmsServices;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Extensions;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsRenderService _smsRenderService;
    private readonly ISmsHistoryService _smsHistoryService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly IMapper _mapper;

    public SmsOrchestrationService(
        IMapper mapper,
        ISmsTemplateService smsTemplateService,
        ISmsSenderService smsSenderService,
        ISmsRenderService smsRenderService,
        ISmsHistoryService smsHistoryService)
    {
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
        // validate

        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<SmsMessage>(smsNotificationRequest);

            message.Template =
                await _smsTemplateService
                    .GetByTypeAsync(
                        smsNotificationRequest.TemplateType, 
                        true, cancellationToken);

            await _smsRenderService.RenderAsync(message, cancellationToken);
            
            await _smsSenderService.SendAsync(message, cancellationToken);

            var history = _mapper.Map<SmsHistory>(message);
            
            await _smsHistoryService.CreateAsync(history, cancellationToken: cancellationToken);
            
            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsync();
    }
}