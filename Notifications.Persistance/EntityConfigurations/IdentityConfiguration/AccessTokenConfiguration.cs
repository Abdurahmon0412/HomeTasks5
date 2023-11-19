using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.EntityConfigurations.IdentityConfiguration;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder.HasOne<User>().WithOne().HasForeignKey<AccessToken>(token => token.UserId);
    }
}