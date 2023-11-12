using Blogs.Domain.Common;

namespace Blogs.Domain.Entities;

public class Comment : IEntity
{
    public Guid Id { get; set; }
    
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreatedTime { get; set; }
    
    public DateTime ModifiedTime { get; set; } 
    
    public Guid UserId { get; set; }

    public virtual User User { get; set; } = default!;
    
    public Guid BlogId { get; set; }

    public virtual Blog Blog { get; set; } = default!;
}