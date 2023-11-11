﻿using Identity.Application.Common.Identity.Services;
using Identity.Domain.Entities;
using Identity.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false,
        CancellationToken cancellationToken = default) =>
        _userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);

    public async ValueTask<User?> GetByEmailAddressAsync(string emailAddress, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository.Get(asNoTracking: asNoTracking)
            .Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken: cancellationToken);
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default) =>
        await _userRepository.CreateAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true,
        CancellationToken cancellationToken = default) =>
        _userRepository.UpdateAsync(user, saveChanges, cancellationToken);
}