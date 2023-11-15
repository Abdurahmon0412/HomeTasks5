using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validatiors.SmsValidators;

public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator(IValidator<NotificationHistory> validator)
    {
        Include(validator);
        RuleFor(template => template.Type)
            .Equal(NotificationType.Sms);
    }
}