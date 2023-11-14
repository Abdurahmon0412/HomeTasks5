namespace Notifications.Application.Commoon.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(
        string senderPhoneNumber,
        string receiverPhoneNumber,
        string message,
        CancellationToken cancellationToken
    );
}