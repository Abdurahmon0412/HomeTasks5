using Blogs.Domain.Entities;
using Blogs.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Persistance.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.Type).IsUnique();

        builder.HasData(new Role
        {
            Id = Guid.Parse("01051801-6828-4332-9620-4250F02820CC"),
            Type = RoleType.Reader,
            CreatedTime = DateTime.UtcNow,
        },
        new Role
        {
            Id = Guid.Parse("9E2B4BFF-A5EE-4F9F-9E1F-C11D62EE2DDF"),
            Type = RoleType.Writer,
            CreatedTime = DateTime.UtcNow,
        });
    }
}
