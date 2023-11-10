using System.Linq.Expressions;
using Identity.Domain.Entities;
using Identity.Persistance.DataContext;
using Identity.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistance.Repositories.Services;

public class RoleRepository : EntityRepositoryBase<Role, IdentityDbContext>, IRoleRepository
{
    public RoleRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public new IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }
}