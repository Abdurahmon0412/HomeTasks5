using AutoMapper;
using Blogs.Application.Dtos;
using Blogs.Application.Foundations;
using Blogs.Application.Identity.Constants;
using Blogs.Application.ManagementServices;
using Blogs.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;
    private readonly IMapper _mapper;
    private readonly IBlogManagementService _blogManagementService;

    public BlogsController(IMapper mapper, IBlogManagementService blogManagementService, IBlogService blogService)
    {
        _blogManagementService = blogManagementService;
        _mapper = mapper;
        _blogService = blogService;
    }

    [HttpGet("bloggers/popular")]
    public async ValueTask<IActionResult> GetPopularBloggers(CancellationToken cancellationToken)
    {
        var bloggers = await _blogManagementService.GetPapularBloggers(cancellationToken);

        var result = bloggers.Select(_mapper.Map<UserDto>);

        return result.Any() ? Ok(result) : NoContent();
    }

    [Authorize(Roles = "Admin,Author,Reader")]
    [HttpGet("{authorId}")]
    public async ValueTask<IActionResult> GetBlogsByAuthor([FromRoute] Guid authorId, CancellationToken cancellationToken)
    {
        var blogs = await _blogManagementService.GetBlogsByUserId(authorId, cancellationToken);

        var blogdtos = blogs.Select(_mapper.Map<BlogDto>);

        return blogdtos.Any() ? Ok(blogs) : NoContent();
    }

    [Authorize(Roles = "Reader")]
    [HttpPost()]
    public async ValueTask<IActionResult> CreateBlogAsync([FromBody] BlogDto blogDto, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        var blog = _mapper.Map<Blog>(blogDto);
        blog.UserId = authorId;

        return Ok(await _blogService.CreateAsync(blog,cancellationToken: cancellationToken));
    }

    [Authorize(Roles = "Author")]
    [HttpPut]
    public async ValueTask<IActionResult> UpdateBlogAsync([FromBody] BlogDto blogDto, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        var blog = _mapper.Map<Blog>(blogDto);
        blog.UserId = authorId;

        return Ok(await _blogService.UpdateAsync(blog, cancellationToken: cancellationToken));
    }

    [Authorize(Roles = "Author")]
    [HttpDelete("{blogId}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid blogId, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        await _blogService.DeleteByIdAsync(blogId, authorId, cancellationToken: cancellationToken);

        return NoContent();
    }
}