using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validatiors.SmsValidators;

public class SmsTemplateValidator : AbstractValidator<SmsTemplate>
{
    public SmsTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .WithMessage("Sms template content is required")
            .MinimumLength(10)
            .WithMessage("Sms template content must be at least 10 characters long")
            .MaximumLength(256)
            .WithMessage("Sms template content must be at most 256 characters long");

        RuleFor(template => template.Type)
            .Equal(NotificationType.Sms);
    }
}