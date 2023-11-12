using Blogs.Domain.Common;
using Blogs.Domain.Enums;

namespace Blogs.Domain.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }

    public RoleType Type { get; set; }

    public bool IsDesabled { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set;}
}