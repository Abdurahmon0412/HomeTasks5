using System.Linq.Expressions;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.Repositories.Interfaces;

public interface IEmailHistoryRopository
{
    IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}