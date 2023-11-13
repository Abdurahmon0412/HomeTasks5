namespace Blogs.Application.Dtos;

public class CommentDto
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid BlogId { get; set; }

    public DateTimeOffset Date { get; set; }
}