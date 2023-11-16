using System.Linq.Expressions;
using Notifications.Domain.Entities;
using Notifications.Persistance.DataContexts;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Persistance.Repositories.Services;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);
    
    public ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
}