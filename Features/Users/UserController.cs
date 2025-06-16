using Microsoft.AspNetCore.Mvc;

namespace csharp_chat_api.Features.Users;

[Route("/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}/chats")]
    public async Task<IActionResult> GetUserChats(long userId)
    {
        var chats = await _userService.GetUserChats(userId);

        return Ok(chats);
    }
}