using Notifications.Application.Commoon.Notifications.Models;

namespace Notifications.Application.Commoon.Notifications.Services.SmsServices;

public interface ISmsRenderService
{
    ValueTask<string> RenderAsync(SmsMessage message, CancellationToken cancellationToken = default);
}