using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;
using Notifications.Persistance.DataContexts;

namespace Notifications.API.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedDataAsync(this IServiceProvider serviceProvider,
        IWebHostEnvironment webHostEnvironment) 
    {
        var notificationsDbContext = serviceProvider.GetRequiredService<NotificationDbContext>();

        if (!await notificationsDbContext.EmailTemplates.AnyAsync())
            await notificationsDbContext.SeedEmailTemplatesAsync(webHostEnvironment);
        if (!await notificationsDbContext.SmsTemplates.AnyAsync())
            await notificationsDbContext.SeedSmsTemplatesAsync();
        if (!await notificationsDbContext.Users.AnyAsync())
            await notificationsDbContext.SeedUsersAsync();
        if (!await notificationsDbContext.Users.AnyAsync())
            await notificationsDbContext.SeedUserSettingsAsync();

        if (notificationsDbContext.ChangeTracker.HasChanges())
            await notificationsDbContext.SaveChangesAsync();
    }

    public static async ValueTask SeedEmailTemplatesAsync(this NotificationDbContext notificationDbContext,
        IWebHostEnvironment webHostEnvironment)
    {
        var emailTemplateTypes = new List<NotificationTemplateType>
        {
            NotificationTemplateType.ReferralNotification,
            NotificationTemplateType.EmailVerificationNotification,
            NotificationTemplateType.SystemWelcomeNotification
        };
        
        var emailTemplateContents = await Task.WhenAll(emailTemplateTypes.Select(async templateType =>
        {
            
            var filePaht = Path.Combine(webHostEnvironment.ContentRootPath, 
                "Data" , 
                "EmailTemplates", 
                Path.ChangeExtension(templateType.ToString(), "html"));

            return (TemplateType: templateType, TemplateContent: await File.ReadAllTextAsync(filePaht));
        }));

        var emailTemplates = emailTemplateContents.Select(templateContent => templateContent.TemplateType switch
        {
            NotificationTemplateType.SystemWelcomeNotification => new EmailTemplate
            {
                TemplateType = templateContent.TemplateType,
                Subject = "Welcome to our service!",
                Content = templateContent.TemplateContent,
            },
            NotificationTemplateType.EmailVerificationNotification => new EmailTemplate
            {
                TemplateType = templateContent.TemplateType,
                Subject = "Confirm your email address",
                Content = templateContent.TemplateContent,
            },
            NotificationTemplateType.ReferralNotification => new EmailTemplate
            {
                TemplateType = templateContent.TemplateType,
                Subject = "You have been referred!",
                Content = templateContent.TemplateContent
            },
            _ => throw new NotSupportedException("Template type not supported.")
        });
        await notificationDbContext.EmailTemplates.AddRangeAsync(emailTemplates);
    }
    
    private static async ValueTask SeedSmsTemplatesAsync(this NotificationDbContext notificationDbContext)
    {
        await notificationDbContext.SmsTemplates.AddRangeAsync(new SmsTemplate
            {
                TemplateType = NotificationTemplateType.SystemWelcomeNotification,
                Content =
                    "Welcome {{UserName}}! We're thrilled to have you on board. Get ready to explore and enjoy our services"
            },
            new SmsTemplate
            {
                TemplateType = NotificationTemplateType.PhoneNumberVerificationNotification,
                Content =
                    "Hey {{UserName}}. To secure your account, please verify your phone number using this link: {{PhoneNumberVerificationLink}}"
            },
            new SmsTemplate
            {
                TemplateType = NotificationTemplateType.ReferralNotification,
                Content =
                    "You've been invited to join by a friend {{SenderName}}! Sign up today and enjoy exclusive benefits. Use referral code"
            });
    }
    
    private static async ValueTask SeedUsersAsync(this NotificationDbContext notificationDbContext)
    {
        await notificationDbContext.Users.AddRangeAsync(new User
            {
                UserName = "System",
                PhoneNumber = "+12132931337",
                EmailAddress = "sultonbek.rakhimov.recovery@gmail.com",
                Role = RoleType.System
            },
            new User
            {
                Id = Guid.Parse("6c0021b5-818c-4f4c-b622-97f73fab473e"),
                UserName = "John",
                PhoneNumber = "+998999663258",
                EmailAddress = "sultonbek.rakhimov@gmail.com",
            },
            new User
            {
                Id = Guid.Parse("12c7e7df-4484-4181-bf96-d340e229c16b"),
                UserName = "Jane",
                PhoneNumber = "+12132931338",
                EmailAddress = "jane.doe@gmail.com",
            });
    }
    
    private static async ValueTask SeedUserSettingsAsync(this NotificationDbContext notificationDbContext)
    {
        await notificationDbContext.UsersSettings.AddRangeAsync(new UserSettings
            {
                Id = Guid.Parse("6c0021b5-818c-4f4c-b622-97f73fab473e"),
                PreferredNotificationType = NotificationType.Sms
            },
            new UserSettings
            {
                Id = Guid.Parse("12c7e7df-4484-4181-bf96-d340e229c16b"),
                PreferredNotificationType = NotificationType.Email
            });
    }
}