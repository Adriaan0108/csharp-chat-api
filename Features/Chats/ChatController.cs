using csharp_chat_api.Features.Messages;
using Microsoft.AspNetCore.Mvc;

namespace csharp_chat_api.Features.Chats;

[Route("/chats")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IMessageService _messageService;

    public ChatController(IChatService chatService, IMessageService messageService)
    {
        _chatService = chatService;
        _messageService = messageService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatDto createChatDto)
    {
        await _chatService.CreateChat(createChatDto);

        return Ok(new { message = "Chat created successfully." });
    }

    [HttpPost("{chatId}/messages")]
    public async Task<IActionResult> CreateMessage(long chatId, [FromBody] CreateMessageDto createMessageDto)
    {
        await _messageService.CreateMessage(chatId, createMessageDto);

        return Ok(new { message = "Message created successfully." });
    }

    [HttpGet]
    public async Task<IActionResult> GetChatMessages()
    {
        var chats = await _chatService.GetUserChats();

        return Ok(chats);
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
        var users = await _messageService.GetChatMessages(chatId);

        return Ok(users);
    }
}