using System.Linq.Expressions;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface IEmailtemplateService
{
    ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
    
    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}