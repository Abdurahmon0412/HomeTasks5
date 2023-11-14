using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Persistance.EntityConfigurations.HisToryConfiguration;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.Property(template => template.Content);

        builder.HasDiscriminator(template => template.NotificationType)
            .HasValue<SmsHistory>(NotificationType.Sms)
            .HasValue<EmailHistory>(NotificationType.Email);
    }
}