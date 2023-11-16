using Notifications.Application.Commoon.Notifications.Models;

namespace Notifications.Application.Commoon.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(
        SmsMessage smsMessage,
        CancellationToken cancellationToken = default);
}