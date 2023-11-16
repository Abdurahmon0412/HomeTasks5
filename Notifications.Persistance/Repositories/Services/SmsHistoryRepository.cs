using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationDbContext>, ISmsHistoryRepository
{
    public SmsHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate = default,
        bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (smsHistory.SmsTemplate is not null)
            DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Unchanged;
        
        var createdHistory = base.CreateAsync(smsHistory, saveChanges, cancellationToken);

        if (smsHistory.SmsTemplate is not null)
            DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Detached;

        return createdHistory;
    }
}