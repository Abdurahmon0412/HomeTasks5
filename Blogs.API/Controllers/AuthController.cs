using Blogs.Application.Identity.Constants;
using Blogs.Application.Identity.Models;
using Blogs.Application.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("signUp")]
    public async ValueTask<IActionResult> SignUpAsync([FromBody] SignUpDetails signUpDetails, CancellationToken cancellationToken) => 
        Ok(await _authService.SignUpAsync(signUpDetails, cancellationToken));

    [HttpPost("signIn")]
    public async ValueTask<IActionResult> SignInAsync([FromBody] SignInDetails signInDetails, CancellationToken cancellationToken) => 
        Ok(await _authService.SignInAsync(signInDetails, cancellationToken));

    [Authorize(Roles = "Admin")]
    [HttpPut("users/{userId}/roles/{roleType}")]
    public async ValueTask<IActionResult> GrantRoleAsync([FromRoute] Guid userId, [FromRoute] string roleType, CancellationToken cancellationToken)
    {
        var actionUserId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _authService.GrantRole(userId, roleType, actionUserId, cancellationToken));
    }
}
