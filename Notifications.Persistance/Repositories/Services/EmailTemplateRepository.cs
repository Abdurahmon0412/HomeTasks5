using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
}