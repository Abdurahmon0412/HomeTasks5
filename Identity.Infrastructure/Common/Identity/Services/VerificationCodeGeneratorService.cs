﻿using System.Security.Cryptography;
using System.Text;

namespace Identity.Infrastructure.Common.Identity.Services;

public class VerificationCodeGeneratorService
{
    public static string GenerateOnlyDigitCode(int length)
    {
        var code = new StringBuilder();

        for (var i = 0; i < length; i++)
            code.Append(RandomNumberGenerator.GetInt32(0, 10));

        return code.ToString();
    }
}