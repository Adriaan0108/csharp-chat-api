using csharp_chat_api.Features.UserChats;
using Microsoft.AspNetCore.Mvc;

namespace csharp_chat_api.Features.Users;

[Route("/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserChatService _userChatService;

    public UserController(IUserChatService userChatService)
    {
        _userChatService = userChatService;
    }

    [HttpGet("{userId}/chats")]
    public async Task<IActionResult> GetUserChats(long userId)
    {
        var chats = await _userChatService.GetUserChats(userId);

        return Ok(chats);
    }
}