namespace Blogs.Application.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; } = default!;

    public bool ValidateIssuer {  get; set; }

    public string ValidIssuer { get; set; } = default!;

    public bool ValidateAudience { get; set; }

    public string ValidAudience { get; set; } = default!;

    public bool ValidateLifetime { get; set; }

    public int ExpirationTimeInMinutes { get; set; }

    public bool ValidateIssuerSigningKey { get; set; }
}