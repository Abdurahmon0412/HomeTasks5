using Blogs.Application.Foundations;
using Blogs.Application.Identity.Services;
using Blogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IUserService _userService;

    public AccountService(IUserService userService) => _userService = userService;

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _userService.CreateAsync(user, cancellationToken: cancellationToken);

        return true;
    }

    public async ValueTask<User?> GetUserByEmailAddress(string emailAddress)
        => await _userService.Get(self => true, asNoTracking: true)
            .Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.EmailAddress == emailAddress);
}