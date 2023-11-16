using Notifications.Application.Commoon.Notifications.Models;

namespace Notifications.Application.Commoon.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default);
}