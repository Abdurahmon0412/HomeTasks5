﻿using FluentValidation;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Validatiors;

public class NotificationHistoryValidator : AbstractValidator<NotificationHistory>
{
    public NotificationHistoryValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(1000);

        RuleFor(template => template.SenderId)
            .NotEmpty();
        
        RuleFor(template => template.ReceiverId)
            .NotEmpty();
    }
}