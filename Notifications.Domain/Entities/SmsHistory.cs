using Type = Notifications.Domain.Enums.NotificationType;

namespace Notifications.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        NotificationType = Type.Sms;
    }
}