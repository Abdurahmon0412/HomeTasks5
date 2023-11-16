using Notifications.Domain.Common.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class UserSettings : IEntity
{
    /// <summary>
    /// Gets or set the user Id
    /// </summary>
    public Guid Id { get; set; }
    
    public NotificationType? PreferredNotificationType { get; set; }
}