using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Notifications.Models;

public class EmailMessage : NotificationMessage
{
    public string SendEmailAddress { get; set; } = default!;
    
    public string ReceiveEmailAddress {get; set; } = default!;

    public EmailTemplate Template { get; set; } = default!;
    
    public string Subject { get; set; } = default!;

    public string Body { get; set; } = default!;
}