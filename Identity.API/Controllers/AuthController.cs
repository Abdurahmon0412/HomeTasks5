using Identity.Application.Common.Constants;
using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) =>
        _authService = authService;

    [AllowAnonymous]
    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromBody] RegistrationDetails registrationDetails,
        CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(registrationDetails,cancellationToken);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails,
        CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(loginDetails, cancellationToken);

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [HttpPut("users/{userId:guid}/roles/{roleType}")]
    public async ValueTask<IActionResult> GrandRole([FromRoute] Guid userId, [FromRoute] string roleType,
        CancellationToken cancellationToken)
    {
        var actionUserId = Guid.Parse(User.Claims.First(claim => claim.Type.Equals(ClaimConstants.UserId)).Value);
        var result = await _authService.GrandRoleAsync(userId, roleType, actionUserId, cancellationToken);
        
        return  result ? Ok() : BadRequest();
    }
}