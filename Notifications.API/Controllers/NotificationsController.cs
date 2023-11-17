using Microsoft.AspNetCore.Mvc;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Entities;

namespace Notifications.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationAggregatorService _notificationAggregatorService;

    public NotificationsController(INotificationAggregatorService notificationAggregatorService)
    {
        _notificationAggregatorService = notificationAggregatorService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Send([FromBody] NotificationRequest request)
    {
        var result = await _notificationAggregatorService.SendAsync(request);

        return result.IsSuccess && (result?.Data ?? false) ? Ok() : BadRequest();
    }

    [HttpGet("templates")]
    public async ValueTask<IActionResult> GetTemplates([FromQuery] NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default)
    {
        var result = await _notificationAggregatorService.GetTEmplatesByFilterAsync(filter, cancellationToken);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpGet("templates/sms")]
    public async ValueTask<IActionResult> GetSmsTemplates(
        [FromQuery] FilterPagination filterPagination, [FromServices] ISmsTemplateService smsTemplateService,
        CancellationToken cancellationToken)
    {
        var result = await smsTemplateService.GetByFilterAsync(filterPagination, cancellationToken: cancellationToken);
        
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpGet("templates/email")]
    public async ValueTask<IActionResult> GetEmailTemplates(
        [FromQuery] FilterPagination filterPagination,
        [FromServices] IEmailTemplateService emailTemplateService, CancellationToken cancellationToken)
    {
        var result =
            await emailTemplateService.GetByFilterAsync(filterPagination, cancellationToken: cancellationToken);
        return  result.Any() ? Ok(result) : BadRequest();
    }
    
    [HttpPost("templates/sms")]
    public async ValueTask<IActionResult> CreateSmsTemplate(
        [FromBody] SmsTemplate template,
        [FromServices] ISmsTemplateService smsTemplateService,
        CancellationToken cancellationToken
    )
    {
        var result = await smsTemplateService.CreateAsync(template, cancellationToken: cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("templates/email")]
    public async ValueTask<IActionResult> CreateEmailTemplate(
        [FromBody] EmailTemplate template,
        [FromServices] IEmailTemplateService emailTemplateService,
        CancellationToken cancellationToken
    )
    {
        var result = await emailTemplateService.CreateAsync(template, cancellationToken: cancellationToken);
        return Ok(result);
    }
}