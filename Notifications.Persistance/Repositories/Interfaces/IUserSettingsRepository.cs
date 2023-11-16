using Notifications.Domain.Entities;

namespace Notifications.Persistance.Repositories.Interfaces;

public interface IUserSettingsRepository
{
    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}