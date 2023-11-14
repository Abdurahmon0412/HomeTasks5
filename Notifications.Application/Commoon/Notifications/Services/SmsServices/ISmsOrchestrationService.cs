using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        User senderUser,
        User receiverUser,
        NotificationTemplateType templateType,
        Dictionary<string, string> variables,
        CancellationToken cancellationToken = default);
}