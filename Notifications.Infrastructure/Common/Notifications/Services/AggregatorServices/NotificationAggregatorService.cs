using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Notifications.Services.AggregatorServices;

public class NotificationAggregatorService : INotificationAggregatorService
{
    public ValueTask<IList<NotificationTemplate>> GetTEmplatesByFilterAsync(NotificationTemplateFilter filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<FuncResult<bool>> SendAsync(NotificationRequest notificationRequest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
