using System.Linq.Expressions;
using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
}