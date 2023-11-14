using System.ComponentModel.Design;
using Notifications.Domain.Common.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public abstract class NotificationHistory : IEntity
{
    public Guid Id { get; set; }
    
    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }
    
    public  string Content { get; set; } = default!;
    public NotificationType NotificationType { get; set; }
}