using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Validatiors;

public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator(IValidator<NotificationHistory> validator)
    {
        Include(validator);
        RuleFor(template => template.NotificationType)
            .Equal(NotificationType.Sms);
    }
}