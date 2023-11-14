using Type = Notifications.Domain.Enums.NotificationType;


namespace Notifications.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        NotificationType = Type.Email;
    }
}