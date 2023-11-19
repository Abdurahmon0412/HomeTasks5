using Notifications.Domain.Common.Entities;

namespace Notifications.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;
    
    public string FirstName { get; set; } = default!;
    
    public string LastName { get; set; } = default!;
    
    public int Age { get; set; }
    
    public string PasswordHash { get; set; } = default!;
    
    public bool IsEmailAddressVerified {get; set; }
    
    public string PhoneNumber { get; set; } = default!;
    
    public string EmailAddress { get; set; } = default!;
    
    public  Guid RoleId { get; set; } = default!;
    
    public virtual Role Role { get; set;} 
    
    public UserSettings UserSettings { get; set; }
}