using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using NotificationTemplate = Notifications.Domain.Entities.NotificationTemplate;

namespace Notifications.Persistance.EntityConfigurations;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.Property(template => template.Content).HasMaxLength(256);
        
        builder
            .HasDiscriminator(template => template.NotificationType)
            .HasValue<SmsTemplate>(NotificationType.Sms)
            .HasValue<EmailTemplate>(NotificationType.Email);
    }
}