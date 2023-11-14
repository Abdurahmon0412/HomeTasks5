using System.Linq.Expressions;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.Repositories.Interfaces;

public interface ISmsTemplateRepository
{
    IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}