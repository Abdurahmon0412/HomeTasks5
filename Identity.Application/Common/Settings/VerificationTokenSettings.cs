﻿namespace Identity.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string IdentityVerificationTokenPurpose { get; set; } = default!;

    public int IdentityVerificationExpirationDurationInMinutes { get; set; }
}