namespace Interceptor.Domain.Common;

public interface IAuditableEntity : IEntity 
{
    DateTimeOffset CreatedTime { get; set; }

    DateTimeOffset? ModifiedTime { get; set; }
}