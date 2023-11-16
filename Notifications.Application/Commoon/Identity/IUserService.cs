using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Identity;

public interface IUserService
{
    ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> userIds, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}