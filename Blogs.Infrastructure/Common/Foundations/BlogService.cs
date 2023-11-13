using Blogs.Application.Foundations;
using Blogs.Domain.Entities;
using Blogs.Persistance.Repostitories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Authentication;

namespace Blogs.Infrastructure.Common.Foundations;

public class BlogService : IBlogService
{
    private readonly IBlogRepostitory _blogRepository;

    public BlogService(IBlogRepostitory blogRepostitory) => _blogRepository = blogRepostitory;

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate, bool asNoTracking = false)
        => _blogRepository.Get(predicate, asNoTracking);

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => _blogRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public async ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidBlog(blog))
            throw new ValidationException("Invalid blog!");

        blog.PublishDate = DateTime.UtcNow;

        return await _blogRepository.CreateAsync(blog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidBlog(blog))
            throw new ValidationException("Invalid blag!");

        var foundBlog = await _blogRepository.GetByIdAsync(blog.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        if (foundBlog.UserId != blog.UserId)
            throw new AuthenticationException("Forbidden action!");

        foundBlog.Content = blog.Content;
        foundBlog.Title = blog.Title;
        foundBlog.ModifiedDate = DateTime.UtcNow;

        return await _blogRepository.UpdateAsync(foundBlog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBlog = await GetByIdAsync(blog.Id, true, cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        if (foundBlog.UserId != blog.UserId)
            throw new AuthenticationException("Forbidden action!");

        return await _blogRepository.DeleteAsync(blog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> DeleteByIdAsync(Guid id, Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {

        var foundBlog = await GetByIdAsync(id, true, cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        if (foundBlog.UserId != userId)
            throw new AuthenticationException("Forbidden action!");

        return await _blogRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    private static bool IsValidBlog(Blog blog) =>
        !(string.IsNullOrWhiteSpace(blog.Title)
        || string.IsNullOrWhiteSpace(blog.Content));
}
