using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistance.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);

        builder.HasData(new User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Smith",
            Age = 39,
            EmailAddress = "Nimada@example.com",
            PasswordHash = "asldjfqjewoqwa",
            IsEmailAddressVerified = true,
            RoleId = Guid.Parse("94E5B7AA-45AD-4267-9A5E-236670A15F82")
        });
    }
}