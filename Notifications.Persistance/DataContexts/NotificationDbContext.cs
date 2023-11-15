using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.DataContexts;

public class NotificationDbContext : DbContext
{
    public DbSet<SmsTemplate> SmsTemplates => Set<SmsTemplate>();
    
    public DbSet<SmsHistory> SmsHistories => Set<SmsHistory>();
    
    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();
    
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();

    public DbSet<User> Users => Set<User>();

    public NotificationDbContext(DbContextOptions<NotificationDbContext> options ) : base( options )
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
    }
}