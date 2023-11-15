using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest smsNotificationRequest,
        CancellationToken cancellationToken = default);
}