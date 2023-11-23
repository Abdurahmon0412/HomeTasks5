namespace Interceptor.Domain.Entities;

public class UserInfoVerificationCode : VerificationCode
{ 
    public Guid UserId { get; set; }
}