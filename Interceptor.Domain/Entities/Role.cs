using Interceptor.Domain.Common;
using Interceptor.Domain.Enums;

namespace Interceptor.Domain.Entities;

public class Role : AuditableEntity
{
    public RoleType Type { get; set; }
    
    public bool IsActive { get; set; }
}