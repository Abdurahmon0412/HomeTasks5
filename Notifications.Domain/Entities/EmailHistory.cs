using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory()
    {
        Type = NotificationType.Email;
    }

    public string Subject { get; set; } = default!;
    
    public string SenderEmailAddress { get; set; } = default!;
    
    public string ReceiverEmailAddress { get; set; } = default!;
}