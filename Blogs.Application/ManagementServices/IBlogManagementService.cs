using Blogs.Domain.Entities;

namespace Blogs.Application.ManagementServices;

public interface IBlogManagementService
{
    ValueTask<IList<Blog>> GetBlogsByUserId(Guid userId, CancellationToken cancellationToken = default);

    ValueTask<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken = default);

    ValueTask<IList<Comment>> GetCommentsByBlogsIdAsync(Guid blogId, CancellationToken cancellationToken = default);

    ValueTask<IList<User>> GetPapularBloggers(CancellationToken cancellationToken = default);
}
