namespace Notifications.Application.Commoon.Notifications.Services.SmsServices;

public interface ISmsRenderService
{
    string RenderMessage(string template, Dictionary<string, string> variables);
}