using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailHistoryService : IEmailHistoryService
{
    public ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
