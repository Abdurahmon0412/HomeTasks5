using System.Linq.Expressions;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface IEmailHistoryService
{
    ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}