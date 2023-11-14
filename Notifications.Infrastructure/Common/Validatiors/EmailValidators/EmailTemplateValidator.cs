using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validatiors.EmailValidators;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);

        RuleFor(template => template.NotificationType)
            .Equal(NotificationType.Email)
            .WithMessage("Sms template notification type must be Sms");

        RuleFor(template => template.Subject)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(1000);

    }
}