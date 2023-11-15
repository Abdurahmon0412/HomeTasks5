using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    public ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest emailNotificationRequest,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}