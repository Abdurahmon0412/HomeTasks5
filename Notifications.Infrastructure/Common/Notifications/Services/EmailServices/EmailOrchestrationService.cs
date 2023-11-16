using AutoMapper;
using Notifications.Application.Commoon.Identity;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Notifications.Services.EmailServices;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Domain.Extensions;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly IEmailTemplateService _emailtemplateService;
    private readonly IEmailHistoryService _emailHistoryService;
    private readonly IUserService _userService;
    private IEmailRenderService _emailRenderService;
    private IEmailSenderService _emailSenderService;

    public EmailOrchestrationService(
        IMapper mapper, 
        IEmailTemplateService emailTemplateService,
        IEmailHistoryService emailHistoryService,
        IEmailSenderService emailSenderService,
        IEmailRenderService emailRenderService,
        IUserService userService)
    {
        _mapper = mapper;
        _emailtemplateService = emailTemplateService;
        _userService = userService;
        _emailHistoryService = emailHistoryService;
        _emailRenderService = emailRenderService;
        _emailSenderService = emailSenderService;
    }
    public async ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest emailNotificationRequest,
        CancellationToken cancellationToken = default)
    {
        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<EmailMessage>(emailNotificationRequest);

            var senderUser = (await _userService.GetByIdAsync(emailNotificationRequest.SenderUserId!.Value,
                cancellationToken: cancellationToken))!;

            var receiverUser = (await _userService.GetByIdAsync(emailNotificationRequest.ReceiverUserId,
                cancellationToken: cancellationToken));

            message.SendEmailAddress = senderUser.EmailAddress;
            message.ReceiveEmailAddress = receiverUser.EmailAddress;

            // get Template
            message.Template =
                await _emailtemplateService.GetByTypeAsync(emailNotificationRequest.TemplateType, true,
                    cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {NotificationType.Sms} notification");

            // render Template
            await _emailRenderService.RenderAsync(message, cancellationToken);

            // send Message

            await _emailSenderService.SendAsync(message, cancellationToken);

            // save history 
            var history = _mapper.Map<EmailHistory>(message);
            await _emailHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsync();
    }
}