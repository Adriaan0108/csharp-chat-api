using Microsoft.AspNetCore.Mvc;

namespace csharp_chat_api.Features.Chats;

[Route("/chats")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("{chatId}/users")]
    public async Task<IActionResult> GetChatUsers(long chatId)
    {
        var users = await _chatService.GetChatUsers(chatId);

        return Ok(users);
    }
}