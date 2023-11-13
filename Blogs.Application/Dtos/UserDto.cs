namespace Blogs.Application.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; }
    
    public Guid RoleId { get; set; }
}