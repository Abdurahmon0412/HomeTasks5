namespace Interceptor.Domain.Common;

public class AuditableEntity : SoftDeletedEntity, IAuditableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }
}