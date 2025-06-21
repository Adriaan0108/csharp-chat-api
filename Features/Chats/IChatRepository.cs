namespace csharp_chat_api.Features.Chats;

public interface IChatRepository
{
    Task<Chat> CreateChat(Chat chat);
}