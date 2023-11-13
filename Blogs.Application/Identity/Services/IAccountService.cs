using Blogs.Domain.Entities;

namespace Blogs.Application.Identity.Services;

public interface IAccountService
{
    ValueTask<User?> GetUserByEmailAddress(string emailAddress);

    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}