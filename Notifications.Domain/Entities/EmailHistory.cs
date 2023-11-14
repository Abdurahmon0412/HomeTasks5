using Type = Notifications.Domain.Enums.NotificationType;

namespace Notifications.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory()
    {
        NotificationType = Type.Email;
    }

    public string Subject { get; set; } = default!;
}