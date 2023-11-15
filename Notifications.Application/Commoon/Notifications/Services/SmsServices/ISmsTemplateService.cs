using System.Linq.Expressions;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Services;

public interface ISmsTemplateService
{
    ValueTask<SmsTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
    
    ValueTask<IList<SmsTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}