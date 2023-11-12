using Blogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Persistance.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);

        builder.HasData(new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Abdurahmon",
            LastName = "Sadriddinov",
            Age = 20,
            EmailAddress = "abdurahmonsadriddinov0412@gmail.com",
            PasswordHash = "Abdurahmon0440",
            IsEmailAddressVerified = true,
            RoleId = Guid.Parse("9E2B4BFF-A5EE-4F9F-9E1F-C11D62EE2DDF")
        });
    }
}