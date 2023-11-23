namespace Interceptor.Domain.Common;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId { get; set; }
}