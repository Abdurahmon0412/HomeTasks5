namespace Interceptor.Domain.Entities;

public class User
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public bool IsEmailAddressVerified { get; set; }

    public Guid? DeletedByUserId { get; set; }

    public Guid? ModifiedByUserId { get; set; }

    public Guid RoleId { get; set; }

    public Role? Role { get; set; }
}