using Blogs.Application.Foundations;
using Blogs.Domain.Entities;
using Blogs.Persistance.Repostitories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Blogs.Infrastructure.Common.Foundations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => _userRepository = userRepository; 
    
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate, bool asNoTracking = false)
        => _userRepository.Get(predicate, asNoTracking);

    public async ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await _userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await _userRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);
    
    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if(!IsValidUser(user))
            throw new ValidationException(nameof(User));

        return await _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if(!IsValidUser(user))
            throw new ValidationException(nameof(User));

        var foundUser = await _userRepository.GetByIdAsync(user.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("User not found!");

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.IsEmailAddressVerified = user.IsEmailAddressVerified;
        foundUser.PasswordHash = user.PasswordHash;
        
        return await _userRepository.UpdateAsync(foundUser, saveChanges, cancellationToken);
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await _userRepository.DeleteAsync(user,saveChanges, cancellationToken);

    public async ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await _userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    private static bool IsValidUser(User user) =>
        !(string.IsNullOrWhiteSpace(user.FirstName)
        || string.IsNullOrWhiteSpace(user.LastName)
        || string.IsNullOrWhiteSpace(user.EmailAddress)
        || string.IsNullOrWhiteSpace(user.PasswordHash));
}