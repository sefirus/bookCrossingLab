using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;
    private readonly IVmMapper<UpdateCommentViewModel, Comment> _updateMapper;

    public CommentController(
        ICommentService commentService,
        IUserService userService,
        IVmMapper<UpdateCommentViewModel, Comment> updateMapper)
    {
        _commentService = commentService;
        _userService = userService;
        _updateMapper = updateMapper;
    }

    [HttpPut]
    public async Task UpdateComment([FromBody] UpdateCommentViewModel viewModel)
    {
        var comment = _updateMapper.Map(viewModel);
        var requestUser = await _userService.GetCurrentUserAsync(HttpContext);
        comment.AuthorId = requestUser.Id;
        await _commentService.UpdateCommentAsync(comment);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task DeleteComment([FromRoute]int id)
    {
        var requestUser = await _userService.GetCurrentUserAsync(HttpContext);
        await _commentService.DeleteCommentAsync(id, requestUser);
    }
}