using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Identity.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetClaims(User user);
}