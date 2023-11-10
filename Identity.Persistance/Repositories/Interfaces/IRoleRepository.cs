using System.Linq.Expressions;
using Identity.Domain.Entities;

namespace Identity.Persistance.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);
}