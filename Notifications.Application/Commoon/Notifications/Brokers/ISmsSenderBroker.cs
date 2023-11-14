namespace Notifications.Application.Commoon.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(
        string senderPhoneNumber,
        string receiverPhoneNumber,
        string message,
        CancellationToken cancellationToken = default);
}