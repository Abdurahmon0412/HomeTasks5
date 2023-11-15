using Notifications.Domain.Enums;

namespace Notifications.Application.Commoon.Notifications.Models;

public class SmsNotificationRequest : NotificationRequest
{
    public SmsNotificationRequest() => Type = NotificationType.Sms;
}