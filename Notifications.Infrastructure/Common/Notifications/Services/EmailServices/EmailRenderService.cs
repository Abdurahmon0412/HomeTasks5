using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services.EmailServices;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailRenderService : IEmailRenderService
{
    public ValueTask<string> RenderAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
