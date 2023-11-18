using Type = Notifications.Domain.Enums.NotificationType;

namespace Notifications.Domain.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate()
    {
        Type = Type.Sms;
    }
}