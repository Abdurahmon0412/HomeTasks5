using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(
        NotificationRequest notificationRequest,
        CancellationToken cancellationToken = default);

    ValueTask<IList<NotificationTemplate>> GetTEmplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default);
}