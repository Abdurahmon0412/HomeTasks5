using Identity.Domain.Entities;
using Identity.Persistance.DataContext;
using Identity.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistance.Repositories.Services;

public class UserRepository : EntityRepositoryBase<User, IdentityDbContext>, IUserRepository
{
    public UserRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }
    
    public new ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, 
        CancellationToken cancellationToken = default) => 
            base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    
    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default) =>
            base.CreateAsync(user, saveChanges, cancellationToken);
    
    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, 
        CancellationToken cancellationToken = default) =>
            base.UpdateAsync(user, saveChanges, cancellationToken);
}