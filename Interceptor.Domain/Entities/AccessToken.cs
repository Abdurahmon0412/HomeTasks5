using Interceptor.Domain.Common;

namespace Interceptor.Domain.Entities;

public class AccessToken : AuditableEntity, ICreationAuditableEntity
{
    public Guid CreatedByUserId { get; set; }
}