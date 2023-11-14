using System.Linq.Expressions;
using Notifications.Domain.Entities;

namespace Notifications.Persistance.Repositories.Interfaces;

public interface IEmailTemplateRepository
{
    IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}