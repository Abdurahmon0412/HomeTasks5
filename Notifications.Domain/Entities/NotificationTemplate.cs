using Notifications.Domain.Common.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public abstract class NotificationTemplate : IEntity
{   
    public Guid Id { get; set; }
    
    public string Content { get; set; }
    
    public NotificationType NotificationType { get; set; }
}