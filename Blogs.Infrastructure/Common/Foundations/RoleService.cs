using Blogs.Application.Foundations;
using Blogs.Domain.Entities;
using Blogs.Domain.Enums;
using Blogs.Persistance.Repostitories.Interfaces;
using System.Linq.Expressions;

namespace Blogs.Infrastructure.Common.Foundations;

public class RoleService : IRoleService
{
    private readonly IRoleRepostitory _roleRepository;

    public RoleService(IRoleRepostitory roleRepository) => _roleRepository = roleRepository;

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
        => _roleRepository.Get(predicate, asNoTracking);
    
    public async ValueTask<IList<Role>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) 
        => await _roleRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public async ValueTask<Role?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default) => 
        await _roleRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default) 
        => new(_roleRepository.Get(asNoTracking: asNoTracking)
            .SingleOrDefault(role => role.Type == type)
            ?? throw new ArgumentNullException(nameof(Role)));
}