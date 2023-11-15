using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        Type = NotificationType.Sms;
    }

    public string SenderPhoneNumber { get; set; } = default!;
    
    public  string ReceiverPhoneNumber { get; set; } = default!;
}