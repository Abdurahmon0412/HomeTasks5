using Notifications.Application.Commoon.Notifications.Brokers;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Extensions;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsSenderService : ISmsSenderService
{
    private readonly IEnumerable<ISmsSenderBroker> _smsSenderBrokers;

    public SmsSenderService(IEnumerable<ISmsSenderBroker> smsSenderBrokers)
    {
        _smsSenderBrokers = smsSenderBrokers;
    }

    public async ValueTask<bool> SendAsync(SmsMessage smsMessage,
        CancellationToken cancellationToken)
    {
        foreach (var sms in _smsSenderBrokers)
        {
            var sendNotificationTask = () => sms.SendAsync(smsMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsync();

            smsMessage.IsSuccessful = result.IsSuccess;
            smsMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}
