using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Validatiors;

public class EmailHistoryValidator : AbstractValidator<EmailHistory>
{
    public EmailHistoryValidator(IValidator<NotificationHistory> validator)
    {
        Include(validator);
        
        RuleFor(template => template.NotificationType)
            .Equal(NotificationType.Email)
            .WithMessage("Sms template notification type must be Sms");

        RuleFor(template => template.Subject)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(1000);
    }
}