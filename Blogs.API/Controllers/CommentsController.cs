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
[Authorize(Roles = "Reader, Writer, Admin")]
public class CommentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBlogManagementService _blogManagementService;
    private readonly ICommentService _commentService;

    public CommentsController(IMapper mapper, IBlogManagementService blogManagementService, ICommentService commentService)
    {
        _blogManagementService = blogManagementService;
        _mapper = mapper;
        _commentService = commentService;
    }

    [HttpGet("{blogId}")]
    public async ValueTask<IActionResult> GetCommentsByBlogIdAsync([FromRoute] Guid blogId, CancellationToken cancellationToken)
    {
        var comments = await _blogManagementService.GetCommentsByBlogsIdAsync(blogId, cancellationToken);

        var result = comments.Select(_mapper.Map<CommentDto>);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateCommentAsync([FromBody] CommentDto commentDto, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        comment.UserId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _blogManagementService.CreateCommentAsync(comment, cancellationToken));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateCommentAsync([FromBody] CommentDto commentDto, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        comment.UserId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _commentService.UpdateAsync(comment, cancellationToken: cancellationToken));
    }

    [HttpDelete("{commentId}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid commentId, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value);

        return Ok(await _commentService.DeleteByIdAsync(commentId, authorId, cancellationToken: cancellationToken));
    }
}