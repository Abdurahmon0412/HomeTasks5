namespace Notifications.Application.Commoon.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(
        string senderEmailAddress,
        string receiverEmailAddress,
        string message,
        CancellationToken cancellationToken = default);
}