using AutoMapper;
using Blogs.Application.Foundations;
using Blogs.Application.Identity.Models;
using Blogs.Application.Identity.Services;
using Blogs.Domain.Entities;
using Blogs.Domain.Enums;

namespace Blogs.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IAccessTokenGeneratorService _accessTokenGeneratorService;
    private readonly IAccountService _accountService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public AuthService(
        IAccessTokenGeneratorService accessTokenGeneratorService,
        IAccountService accountService,
        IPasswordHasherService passwordHasherService,
        IMapper mapper,
        IRoleService roleService,
        IUserService userService)
    {
        _accessTokenGeneratorService = accessTokenGeneratorService;
        _accountService = accountService;
        _passwordHasherService = passwordHasherService;
        _mapper = mapper;
        _roleService = roleService;
        _userService = userService;
    }

    public async ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var user = _mapper.Map<User>(signUpDetails);
        user.PasswordHash = _passwordHasherService.HashPassword(signUpDetails.Password);

        var role = await _roleService.GetByTypeAsync(RoleType.Reader, true, cancellationToken)
            ?? throw new InvalidOperationException("This role type does not exists");

        user.Role = role;

        return await _accountService.CreateUserAsync(user);
    }

    public async ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default)
    {
        var foundUser = await _accountService.GetUserByEmailAddress(signInDetails.EmailAddress)
            ?? throw new InvalidOperationException(nameof(SignInDetails));

        if (!_passwordHasherService.VerifyPassword(signInDetails.Password, foundUser.PasswordHash))
            throw new InvalidOperationException();

        var token = _accessTokenGeneratorService.GetToken(foundUser);

        return token;
    }

    public async ValueTask<bool> GrantRole(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetByIdAsync(userId, cancellationToken: cancellationToken)
            ?? throw new ArgumentNullException(nameof(userId));

        _ = await _userService.GetByIdAsync(actionUserId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException();

        if (!Enum.TryParse(roleType, out RoleType type))
            throw new InvalidOperationException();

        var role = await _roleService.GetByTypeAsync(type, true, cancellationToken)
            ?? throw new InvalidOperationException();

        user.RoleId = role.Id;

        await _userService.UpdateAsync(user);

        return true;
    }
}