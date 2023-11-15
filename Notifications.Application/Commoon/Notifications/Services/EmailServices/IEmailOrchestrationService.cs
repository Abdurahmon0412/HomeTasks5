using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest request,
        CancellationToken cancellationToken = default);
}