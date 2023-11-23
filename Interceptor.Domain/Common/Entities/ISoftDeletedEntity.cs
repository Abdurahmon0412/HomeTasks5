namespace Interceptor.Domain.Common;

public interface ISoftDeletedEntity : IEntity
{
    bool IsDeleted { get; set; }
    
    DateTimeOffset? DeletedTime { get; set; }
}