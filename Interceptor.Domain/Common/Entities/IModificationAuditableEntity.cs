namespace Interceptor.Domain.Common;

public interface IModificationAuditableEntity
{
    Guid? ModifiedByUserId { get; set; }
}