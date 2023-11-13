using Blogs.Application.Identity.Models;

namespace Blogs.Application.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);

    ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default);

    ValueTask<bool> GrantRole(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default);
}