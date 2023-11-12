using Blogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Persistance.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(comment => comment.Blog).WithMany(blog => blog.Comments)
            .HasForeignKey(comment => comment.BlogId);
        
        builder.HasOne(comment => comment.User).WithMany(user => user.Comments)
            .HasForeignKey(comment => comment.UserId);
    }
}