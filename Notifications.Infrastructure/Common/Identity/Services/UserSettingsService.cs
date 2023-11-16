using Notifications.Application.Commoon.Identity;
using Notifications.Domain.Entities;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Infrastructure.Common.Identity.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly IUserSettingsRepository _settingsRepository;

    public UserSettingsService(IUserSettingsRepository settingsRepository) => _settingsRepository = settingsRepository;

    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => _settingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
}