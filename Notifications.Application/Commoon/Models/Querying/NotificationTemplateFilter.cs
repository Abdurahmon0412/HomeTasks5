using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Models.Querying;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}