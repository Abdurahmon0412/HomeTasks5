using Blogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Persistance.DataContext;

public class BlogsDbContext : DbContext
{
    DbSet<User> Users => Set<User>();

    DbSet<Role> Roles => Set<Role>();
    
    DbSet<Blog> Blogs => Set<Blog>();
    
    DbSet<Comment> Comments => Set<Comment>();

    public BlogsDbContext(DbContextOptions<BlogsDbContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogsDbContext).Assembly);
    }
}