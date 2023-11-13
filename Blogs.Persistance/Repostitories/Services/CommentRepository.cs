using Blogs.Domain.Entities;
using Blogs.Persistance.DataContext;
using Blogs.Persistance.Repostitories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Persistance.Repostitories.Services;

public class CommentRepository : EntityRepositoryBase<Comment, BlogsDbContext>, ICommentRepository
{
    public CommentRepository(BlogsDbContext dbContext) : base(dbContext)
    {
    }
}