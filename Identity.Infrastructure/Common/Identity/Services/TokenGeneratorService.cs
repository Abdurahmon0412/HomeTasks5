using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.Application.Common.Constants;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _settings;

    public TokenGeneratorService(IOptions<JwtSettings> settings) => 
        _settings = settings.Value;

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var secyrityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(secyrityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken
            (
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddMinutes(_settings.ExpirationTimeInMinutes),
                signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimTypes.Role, user.Role.Type.ToString()),
            new(ClaimConstants.UserId, user.Id.ToString())
        };
    }
}