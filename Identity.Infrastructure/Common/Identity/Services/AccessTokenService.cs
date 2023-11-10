using Identity.Application.Common.Identity.Services;
using Identity.Domain.Entities;
using Identity.Persistance.Repositories.Interfaces;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AccessTokenService : IAccessTokenService
{
    private  readonly IAccessTokenRepository _accessTokenRepository;

    public AccessTokenService(IAccessTokenRepository accessTokenRepository) => 
        _accessTokenRepository = accessTokenRepository;

    public ValueTask<AccessToken> CreateAsync(
        AccessToken accessToken,
        bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);
    }

    public async ValueTask<AccessToken> CreateAsync(Guid userId, string value, bool saveChanges = true,
        CancellationToken cancellation = default)
    {
        var accessToken = new AccessToken
        {
            UserId = userId,
            Value = value,
            CreatedTime = DateTime.UtcNow
        };

        await _accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellation);

        return accessToken;
    }
}