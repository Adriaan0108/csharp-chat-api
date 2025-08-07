using Microsoft.AspNetCore.SignalR;

namespace csharp_chat_api.Features.Messages;

public class MessageHub : Hub
{
    private readonly IMessageService _messageService;

    public MessageHub(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task JoinChat(long chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    public async Task SendMessage(long chatId, CreateMessageDto createMessageDto)
    {
        var message = await _messageService.CreateMessage(chatId, createMessageDto);

        // broadcast to all users in the chat that are currently online and listening for messages
        await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", message);
    }
}