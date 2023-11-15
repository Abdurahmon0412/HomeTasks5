using Notifications.Application.Commoon.Notifications.Models;

namespace Notifications.Application.Commoon.Notifications.Services.EmailServices;

public interface IEmailRenderService
{
    ValueTask<string> RenderAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}