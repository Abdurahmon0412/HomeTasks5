using Notifications.Application.Commoon.Notifications.Models;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface ISmsSenderService
{
    ValueTask<bool> SendAsync(
        SmsMessage message,
        CancellationToken cancellationToken = default);
}