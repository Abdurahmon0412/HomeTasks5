using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.DataContexts;

public class NotificationDbContext : DbContext
{
    public DbSet<SmsTemplate> SmsTemplates => Set<SmsTemplate>();
    
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();
    
    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();
    
    public DbSet<SmsHistory> SmsHistories => Set<SmsHistory>();

    public DbSet<User> Users => Set<User>();
    
    public DbSet<UserSettings> UsersSettings => Set<UserSettings>();
    
    public DbSet<Role> Roles => Set<Role>();
    
    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();

    public NotificationDbContext(DbContextOptions<NotificationDbContext> options ) : base( options )
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
    }
}