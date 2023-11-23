using Interceptor.Domain.Common;
using Interceptor.Domain.Enums;

namespace Interceptor.Domain.Entities;

public class VerificationCode : Entity
{
    public VerificationCodeType CodeType { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }

    public bool IsActive { get; set; }

    public string Code { get; set; } = default!;

    public string VerificationLink { get; set; } = default!;
}