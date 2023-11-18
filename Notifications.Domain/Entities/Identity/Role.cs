using Notifications.Domain.Common.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }
    
    public RoleType Type { get; set; }

    public bool IsDisabled { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime ModifiedTime { get; set; }
}