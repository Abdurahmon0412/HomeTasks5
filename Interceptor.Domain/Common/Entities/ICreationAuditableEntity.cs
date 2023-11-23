namespace Interceptor.Domain.Common;

public interface ICreationAuditableEntity
{
    Guid CreatedByUserId { get; set; } 
}