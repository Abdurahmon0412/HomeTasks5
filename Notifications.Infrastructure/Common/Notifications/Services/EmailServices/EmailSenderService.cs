using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailSenderService : IEmailSenderService
{
    public ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
