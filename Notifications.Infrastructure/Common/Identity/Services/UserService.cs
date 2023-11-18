using Microsoft.EntityFrameworkCore;
using Notifications.Application.Commoon.Identity;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> userIds, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => _userRepository.GetByIdsAsync(userIds, asNoTracking, cancellationToken);

    public async ValueTask<User?> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        //bu yerham to'girlanadi
        return await _userRepository.Get(user => user.Role == new Role(), asNoTracking)
            .Include(user => user.UserSettings)
            .SingleOrDefaultAsync(cancellationToken);

    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellation = default)
        => _userRepository.GetByIdAsync(userId, asNoTracking, cancellation);
}