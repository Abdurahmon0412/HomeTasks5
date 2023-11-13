using Blogs.Domain.Entities;
using System.Linq.Expressions;

namespace Blogs.Persistance.Repostitories.Interfaces;

public interface IRoleRepostitory
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<Role>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Role?> GetByIdAsync(Guid Id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

}