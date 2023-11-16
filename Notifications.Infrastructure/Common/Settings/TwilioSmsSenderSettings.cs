﻿namespace Notifications.Infrastructure.Common.Settings;

public class TwilioSmsSenderSettings
{
    public string AccoundSid { get; set; } = default!;
    
    public string AuthToken { get; set; } = default!;
    
    public string SenderPhoneNumber { get; set; } = default!;
}