using Notifications.Application.Commoon.Notifications.Services;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailSenderService : IEmailSenderService
{
    public ValueTask<bool> SendAsync(string senderPhoneNumber, string receiverPhoneNumber, string message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
