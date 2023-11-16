using Notifications.Application.Commoon.Notifications.Brokers;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Extensions;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailSenderService : IEmailSenderService
{
    private readonly IEnumerable<IEmailSenderBroker> _emailSenderBrokers;

    public EmailSenderService(IEnumerable<IEmailSenderBroker> emailSenderBrokers)
    {
        _emailSenderBrokers = emailSenderBrokers;
    }
    
    public async ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
    {
        foreach (var smsSenderBroker in _emailSenderBrokers)
        {
            var sendNotificationTask = () => smsSenderBroker.SendAsync(emailMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsync();

            emailMessage.IsSuccessful = result.IsSuccess;
            emailMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}
