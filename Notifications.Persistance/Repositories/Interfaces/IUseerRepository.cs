using System.Linq.Expressions;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.Repositories.Interfaces;

public interface IUserRepository
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> usersId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    
    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);
}