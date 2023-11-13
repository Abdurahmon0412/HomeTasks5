namespace Blogs.Application.Dtos;

public class BlogDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content {  get; set; } = string.Empty;    

    public DateTime PublishDate { get; set; }
}