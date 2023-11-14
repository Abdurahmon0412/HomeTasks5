using Notifications.Domain.Common.Entities;

namespace Notifications.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    
    public string UserName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string EmailAddress { get; set; }
}