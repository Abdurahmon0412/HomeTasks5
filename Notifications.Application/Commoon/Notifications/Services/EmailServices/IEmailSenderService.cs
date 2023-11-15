using Notifications.Application.Commoon.Notifications.Models;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken
    );
}