using Identity.Application.Common.Identity.Services;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository) => 
        _roleRepository = roleRepository;

    public async ValueTask<Role?> GetByTypeAsync(
        RoleType roleType, bool asNoTracking, CancellationToken cancellationToken = default)
    {
        return await _roleRepository.Get(asNoTracking: asNoTracking)
            .SingleOrDefaultAsync(role => role.Type == roleType, cancellationToken);
    }
}