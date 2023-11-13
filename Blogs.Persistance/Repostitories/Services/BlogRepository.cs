using Blogs.Domain.Entities;
using Blogs.Persistance.DataContext;
using Blogs.Persistance.Repostitories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Persistance.Repostitories.Services;

public class BlogRepository : EntityRepositoryBase<Blog, BlogsDbContext>, IBlogRepostitory
{
    public BlogRepository(BlogsDbContext dbContext) : base(dbContext)
    {
    }
}