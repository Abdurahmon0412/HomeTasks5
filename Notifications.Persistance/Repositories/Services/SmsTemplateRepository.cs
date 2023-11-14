using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
}