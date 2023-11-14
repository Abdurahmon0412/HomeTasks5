using Notifications.Application.Commoon.Notifications.Brokers;
using Notifications.Application.Commoon.Notifications.Services;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsSenderService : ISmsSenderService
{
    private readonly IEnumerable<ISmsSenderBroker> _smsSenderBrokers;

    public SmsSenderService(IEnumerable<ISmsSenderBroker> smsSenderBrokers) => 
        _smsSenderBrokers = smsSenderBrokers;

    public async ValueTask<bool> SendAsync(string senderPhoneNumber, 
        string receiverPhoneNumber, string message,
        CancellationToken cancellationToken)
    {
        var result = false;

        foreach(var smsSenderBroker  in _smsSenderBrokers)
        {
            try
            {
                result = await smsSenderBroker.SendAsync(
                    senderPhoneNumber,
                    receiverPhoneNumber,
                    message,
                    cancellationToken);
                if (result) return result;
            }
            catch (Exception ex)
            {
                // bu yerda logni o'tsak yozaman
            }
        }

        return result;
    }
}
