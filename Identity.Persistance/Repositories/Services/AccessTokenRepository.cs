using Identity.Domain.Entities;
using Identity.Persistance.DataContext;
using Identity.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistance.Repositories.Services;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, IdentityDbContext>, IAccessTokenRepository  
{
    public AccessTokenRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public new ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return  base.CreateAsync(accessToken, saveChanges, cancellationToken);
    }
}