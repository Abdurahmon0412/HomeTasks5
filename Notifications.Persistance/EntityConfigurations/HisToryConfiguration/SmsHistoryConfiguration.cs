using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.EntityConfigurations.HisToryConfiguration;

public class SmsHistoryConfiguration : IEntityTypeConfiguration<SmsHistory>
{
    public void Configure(EntityTypeBuilder<SmsHistory> builder)
    {
        builder.Property(template => template.SenderPhoneNumber).IsRequired().HasMaxLength(32);
        builder.Property(template => template.ReceiverPhoneNumber).IsRequired().HasMaxLength(32);
    }
}