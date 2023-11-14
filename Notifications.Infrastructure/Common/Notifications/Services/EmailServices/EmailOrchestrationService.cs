using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Common.Extensions;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    public ValueTask<FuncResult<bool>> SendAsync(string senderEmailAddress, string receiverEmailAddress, NotificationTemplateType templateType, Dictionary<string, string> variables, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
