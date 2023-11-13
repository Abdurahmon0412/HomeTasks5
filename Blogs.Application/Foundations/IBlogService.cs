using System.Linq.Expressions;
using Blogs.Domain.Entities;

namespace Blogs.Application.Foundations;

public interface IBlogService
{
    IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate, bool asNoTracking = false);

    ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteByIdAsync(Guid id, Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default);
}