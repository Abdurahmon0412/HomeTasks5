using Notifications.Application.Commoon.Notifications.Services.SmsServices;
using System.Text.RegularExpressions;
using System.Text;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsRenderService : ISmsRenderService
{
    public string RenderMessage(string template, Dictionary<string, string> variables)
    {
        var messageBuilder = new StringBuilder(template);

        var pattern = @"\{\{([^\{\}]+)\}\}";
        var matchValuePattern = "{{(.*?)}}";
        var matches = Regex.Matches(template, pattern)
            .Select(match =>
            {
                var placeholder = match.Value;
                var placeholderValue = Regex.Match(placeholder, matchValuePattern).Groups[1].Value;
                var valid = variables.TryGetValue(placeholderValue, out var value);

                return new
                {
                    Placeholder = placeholder,
                    Value = value,
                    IsValid = valid
                };
            });

        foreach (var match in matches)
            messageBuilder.Replace(match.Placeholder, match.Value);

        var message = messageBuilder.ToString();
        return message;
    }
}