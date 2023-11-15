﻿namespace Notifications.Application.Commoon.Notifications.Models;

public abstract class NotificationMessage
{
    public Guid SenderUserId { get; set; }

    public Guid ReceiverUserId { get; set; }

    public Guid TemplateId { get; set; }

    public Dictionary<string, string> Variables { get; set; }

    public bool IsSuccessful { get; set; }

    public string? ErrorMessage { get; set; }
}