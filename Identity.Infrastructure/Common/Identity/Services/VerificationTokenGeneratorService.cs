using Identity.Application.Common.Enums;
using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _dataProtector;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationTokenGeneratorService(IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtectionProvider dataProtectionProvider)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtector =
            dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime =
                DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings
                    .IdentityVerificationExpirationDurationInMinutes)
        };

        return _dataProtector.Protect(JsonConvert.SerializeObject(verificationToken));
    }

    public (VerificationToken Token, bool IsValid) DecadeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token));

        var unProtectedToken = _dataProtector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unProtectedToken) ??
                                throw new ArgumentException("Invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }
}