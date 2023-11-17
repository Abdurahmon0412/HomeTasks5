using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationHistoriesController : ControllerBase
{
    [HttpGet("sms")]
    public async ValueTask<IActionResult> Get([FromServices] IEmailHistoryRopository repo)
        => Ok(await repo.Get().ToListAsync());
    
    [HttpGet("email")]
    public async ValueTask<IActionResult> Get([FromServices] ISmsHistoryRepository repo) => 
        Ok(await repo.Get().ToListAsync());
}