using Blogs.Domain.Entities;
using System.Linq.Expressions;

namespace Blogs.Persistance.Repostitories.Interfaces;

public interface ICommentRepository
{
    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate, bool asNoTracking = false);

    public ValueTask<IList<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChnges = true, CancellationToken cancellationToken = default);

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChnges = true, CancellationToken cancellationToken = default);

    public ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default);

    public ValueTask<Comment> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken= default);
}