using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.Shared;

namespace csharp_chat_api.Features.Chats;

public class ChatDto : BaseDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsDirectChat { get; set; }

    public Message LastMessage { get; set; }
}