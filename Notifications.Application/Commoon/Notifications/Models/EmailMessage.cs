using Notifications.Domain.Entities;

namespace Notifications.Application.Commoon.Notifications.Models;

public class EmailMessage : NotificationMessage
{
    public string SendEmailAddress { get; set; }
    
    public string ReceiveEmailAddress {get; set; }  
    
    public EmailTemplate Template {get; set; }
    
    public string Subject { get; set; } = default!;

    public string Body { get; set; } = default!;
}