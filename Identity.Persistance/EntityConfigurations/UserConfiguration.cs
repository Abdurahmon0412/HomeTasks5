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
            EmailAddress = "Nimadada@example.com",
            PasswordHash = "asldjfqjewoqwa",
            IsEmailAddressVerified = true,
            RoleId = Guid.Parse("7d07ea1f-9be7-48f0-ad91-5b83a5806baf")
        });
    }
}