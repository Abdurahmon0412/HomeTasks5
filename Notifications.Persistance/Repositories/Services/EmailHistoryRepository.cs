using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRopository
{
    public EmailHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
}