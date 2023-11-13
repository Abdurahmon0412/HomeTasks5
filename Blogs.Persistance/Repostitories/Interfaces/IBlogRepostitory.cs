using Blogs.Domain.Entities;
using System.Linq.Expressions;

namespace Blogs.Persistance.Repostitories.Interfaces;

public interface IBlogRepostitory
{
    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = default, bool asNoTracking = false);

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    public ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    public ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    public ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancelToken = default);

    public ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    public ValueTask<Blog> DeleteByIdAsync(Guid id, bool saveChnges = true, CancellationToken cancellation = default);
}