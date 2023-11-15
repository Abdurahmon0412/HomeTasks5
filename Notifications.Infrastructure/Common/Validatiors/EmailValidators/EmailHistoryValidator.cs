using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validatiors.EmailValidators;

public class EmailHistoryValidator : AbstractValidator<EmailHistory>
{
    public EmailHistoryValidator(IValidator<NotificationHistory> validator)
    {
        Include(validator);

        RuleFor(template => template.Type)
            .Equal(NotificationType.Email)
            .WithMessage("Sms template notification type must be Sms");

        RuleFor(template => template.Subject)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(1000);
    }
}