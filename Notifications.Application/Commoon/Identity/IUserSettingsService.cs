using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Identity;

public interface IUserSettingsService
{
    ValueTask<UserSettings?> GetByIdAsync(
        Guid userSettingsId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}