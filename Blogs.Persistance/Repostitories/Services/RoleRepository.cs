using Blogs.Domain.Entities;
using Blogs.Persistance.DataContext;
using Blogs.Persistance.Repostitories.Interfaces;

namespace Blogs.Persistance.Repostitories.Services;

public class RoleRepository : EntityRepositoryBase<Role, BlogsDbContext>, IRoleRepostitory
{
    public RoleRepository(BlogsDbContext dbContext) : base(dbContext)
    {
    }
}