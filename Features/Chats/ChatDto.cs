namespace csharp_chat_api.Features.Chats;

public class ChatDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}