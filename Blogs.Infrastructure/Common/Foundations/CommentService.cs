using Blogs.Application.Foundations;
using Blogs.Domain.Entities;
using Blogs.Persistance.Repostitories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Authentication;

namespace Blogs.Infrastructure.Common.Foundations;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository) => _commentRepository = commentRepository;

    public async ValueTask<IList<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await _commentRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate, bool asNoTracking = false)
        => _commentRepository.Get(predicate, asNoTracking);

    public async ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await _commentRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if(!IsValidComment(comment))
            throw new ValidationException(nameof(comment));

        comment.CreatedTime = DateTime.UtcNow;

        return await _commentRepository.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if(!IsValidComment(comment))
            throw new ValidationException(nameof(comment));

        var foundComment = await _commentRepository.GetByIdAsync(comment.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Comment not found!");

        if(foundComment.UserId != comment.UserId)
                throw new AuthenticationException("Forbidden action!");

        foundComment.Content = comment.Content;
        foundComment.ModifiedTime = DateTime.UtcNow;

        return await _commentRepository.UpdateAsync(foundComment, saveChanges, cancellationToken);
    }
    

    public async ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundComment = await GetByIdAsync(comment.Id, cancellationToken: cancellationToken)
          ?? throw new InvalidOperationException("Comment not found!");

        if (foundComment.UserId != comment.UserId)
            throw new AuthenticationException("Forbidden action!");

        return await _commentRepository.DeleteAsync(comment, saveChanges, cancellationToken);
    }

    public async ValueTask<Comment> DeleteByIdAsync(Guid id, Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundComment = await _commentRepository.GetByIdAsync(id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Comment not found");

        if (foundComment.UserId != userId)
            throw new AuthenticationException("Forbidden action");

        return await _commentRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    private static bool IsValidComment(Comment comment)
        => !string.IsNullOrWhiteSpace(comment.Content); 
}