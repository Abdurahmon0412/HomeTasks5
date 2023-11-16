using Notifications.Application.Commoon.Notifications.Brokers;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Infrastructure.Common.Settings;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Notifications.Infrastructure.Common.Notifications.Brokers;

public class TwilioSmsSenderBroker : ISmsSenderBroker
{
    private readonly TwilioSmsSenderSettings _twilioSmsSenderSettings;

    public TwilioSmsSenderBroker(TwilioSmsSenderSettings twilioSmsSenderSettings)
    {
        _twilioSmsSenderSettings = twilioSmsSenderSettings;
    }
    public ValueTask<bool> SendAsync(
        SmsMessage smsMessage,
        CancellationToken cancellationToken = default)
    {
        var test = "ACe09f7247dfbdf25dbe2ef0acdf2279f9";
        var test2 = "e1fdedded3a1a2ddf74da5336dd7687d";

        TwilioClient.Init(test, test2);

        var messageContent = MessageResource.Create(
            body: smsMessage.Message,
            from: new Twilio.Types.PhoneNumber(_twilioSmsSenderSettings.SenderPhoneNumber),
            to: new Twilio.Types.PhoneNumber(smsMessage.ReceiverPhoneNumber));

        return new ValueTask<bool>(true);
    }
}