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

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatDto createChatDto)
    {
        await _chatService.CreateChat(createChatDto);

        return Ok(new { message = "Chat created successfully." });
    }

    [HttpGet("{chatId}/users")]
    public async Task<IActionResult> GetChatUsers(long chatId)
    {
        var users = await _chatService.GetChatUsers(chatId);

        return Ok(users);
    }

    [HttpGet("{chatId}/messages")]
    public async Task<IActionResult> GetChatMessages(long chatId)
    {
        var users = await _chatService.GetChatMessages(chatId);

        return Ok(users);
    }
}