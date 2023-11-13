using Blogs.Domain.Entities;
using Blogs.Persistance.DataContext;
using Blogs.Persistance.Repostitories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Persistance.Repostitories.Services;

public class UserRopository : EntityRepositoryBase<User, BlogsDbContext>, IUserRepository
{
    public UserRopository(BlogsDbContext dbContext) : base(dbContext)
    {
    }
}