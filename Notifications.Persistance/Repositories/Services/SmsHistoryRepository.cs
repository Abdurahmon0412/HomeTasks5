using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationDbContext>, ISmsHistoryRepository
{
    public SmsHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
}