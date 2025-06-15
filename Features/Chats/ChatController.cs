using csharp_chat_api.Features.UserChats;
using Microsoft.AspNetCore.Mvc;

namespace csharp_chat_api.Features.Chats;

[Route("/chats")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IUserChatService _userChatService;

    public ChatController(IUserChatService userChatService)
    {
        _userChatService = userChatService;
    }

    [HttpGet("{chatId}/users")]
    public async Task<IActionResult> GetChatUsers(long chatId)
    {
        var users = await _userChatService.GetChatUsers(chatId);

        return Ok(users);
    }
}