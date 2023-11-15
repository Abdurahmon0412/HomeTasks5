using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Models;

public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest() => Type = NotificationType.Email;
}