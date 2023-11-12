using System.Net;
using System.Net.Mail;
using Identity.Application.Common.Notifications.Services;
using Identity.Application.Common.Settings;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Common.Notifications.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailOrchestrationService(IOptions<EmailSenderSettings> emailSenderSettings) => 
        _emailSenderSettings = emailSenderSettings.Value;

    public ValueTask<bool> SendAsync(string emailAddress, string message)
    {
        var mail = new MailMessage(_emailSenderSettings.CredentialAddress, emailAddress);
        mail.Subject = "Siz muvaffaqiyatli ro'yhatdan o'tdingiz";
        mail.Body = message;

        var smtpClient = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port);
        smtpClient.Credentials =
            new NetworkCredential(_emailSenderSettings.CredentialAddress, _emailSenderSettings.Password);
        smtpClient.EnableSsl = true;
        
        smtpClient.Send(mail);

        return new(true);
    }
}