using Blogs.Domain.Common;

namespace Blogs.Domain.Entities;

public class Blog : IEntity
{
    public Guid Id {get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Content {get; set; } = string.Empty;
    
    public DateTime PublishDate {get; set; } 
    
    public DateTime ModifiedDate {get; set; }
    
    public Guid UserId {get; set;}

    public virtual User User { get; set; } = default!;
    
    public virtual ICollection<Comment> Comments { get; set; } = default!;
}