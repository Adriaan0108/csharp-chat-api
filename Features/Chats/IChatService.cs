using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Chats;

public interface IChatService
{
    Task<IEnumerable<UserDto>> GetChatUsers(long chatId);

    Task<IEnumerable<ChatDto>> GetUserChats();

    Task<Chat> CreateChat(CreateChatDto createChatDto);
}