﻿using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services.EmailServices;
using Notifications.Infrastructure.Common.Settings;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailRenderService : IEmailRenderService
{
    private readonly TemplateRenderingSettings _templateRenderingSettings;

    public EmailRenderService(IOptions<TemplateRenderingSettings> templateRenderingSettings)
    {
        _templateRenderingSettings = templateRenderingSettings.Value;
    }
    
    public ValueTask<string> RenderAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        var placeholderRegex = new Regex(_templateRenderingSettings.PlaceholderRegexPattern,
            RegexOptions.Compiled,
            TimeSpan.FromSeconds(_templateRenderingSettings.RegexMatchTimeoutInSeconds));

        var placeholderValueRegex = new Regex(_templateRenderingSettings.PlaceholderValueRegexPattern,
            RegexOptions.Compiled,
            TimeSpan.FromSeconds(_templateRenderingSettings.RegexMatchTimeoutInSeconds));


        var matches = placeholderRegex.Matches(emailMessage.Template.Content);

        if (matches.Any() && !emailMessage.Variables.Any())
            throw new InvalidOperationException("Variables are required for this template.");

        var templatePlaceholders = matches.Select(match =>
            {
                var placeholder = match.Value;
                var placeholderValue = placeholderValueRegex.Match(placeholder).Groups[1].Value;
                var valid = emailMessage.Variables.TryGetValue(placeholderValue, out var value);

                return new TemplatePlaceholder
                {
                    Placeholder = placeholder,
                    PlaceholderValue = placeholderValue,
                    Value = value,
                    IsValid = valid
                };
            })
            .ToList();

        ValidatePlaceholders(templatePlaceholders);

        var messageBuilder = new StringBuilder(emailMessage.Template.Content);
        templatePlaceholders.ForEach(placeholder => messageBuilder.Replace(placeholder.Placeholder, placeholder.Value));

        var message = messageBuilder.ToString();
        emailMessage.Body = message;
        emailMessage.Subject = emailMessage.Template.Subject;

        return ValueTask.FromResult(message);
    }

    private static void ValidatePlaceholders(IEnumerable<TemplatePlaceholder> templatePlaceholders)
    {
        var missingPlaceholders = templatePlaceholders.Where(placeholder => !placeholder.IsValid)
            .Select(placeholder => placeholder.PlaceholderValue)
            .ToList();
        
        if(!missingPlaceholders.Any()) return;

        var errorMessage = new StringBuilder();
        missingPlaceholders.ForEach(placeholderValue => errorMessage.Append(placeholderValue).Append(','));
        
        throw new InvalidOperationException(
            $"Variable for given placeholders is not found - {string.Join(',', missingPlaceholders)}");
    }
}
