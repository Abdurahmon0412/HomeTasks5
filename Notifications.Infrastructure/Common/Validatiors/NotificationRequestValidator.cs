using FluentValidation;
using Notifications.Application.Commoon.Identity;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validatiors;

public class NotificationRequestValidator : AbstractValidator<NotificationRequest>
{
    public NotificationRequestValidator(IUserService userService)
    {
        var templatesRequireSender = new List<NotificationTemplateType>
        {
            NotificationTemplateType.ReferralNotification
        };

        RuleFor(request => request.SenderUserId)
            .NotEqual(Guid.Empty)
            .NotNull()
            .When(request => templatesRequireSender.Contains(request.TemplateType))
            .CustomAsync(async (senderUserId, context, cancellationToken) =>
            {
                var user = await userService.GetByIdAsync(senderUserId!.Value, true, cancellationToken);

                if (user is null)
                    context.AddFailure("Sender user not found");
            });

        RuleFor(request => request.ReceiverUserId)
            .NotEqual(Guid.Empty)
            .CustomAsync(async (receiverUserId, context, cancellationToken) =>
            {
                var user = await userService.GetByIdAsync(receiverUserId, true, cancellationToken);
                if (user is null)
                    context.AddFailure("Sender user not found");
            });
    }
}