using System.Linq.Expressions;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface ISmsHistoryService
{
    IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<SmsHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}