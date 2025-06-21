using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Chats;

public interface IChatService
{
    Task<IEnumerable<UserDto>> GetChatUsers(long chatId);

    Task<IEnumerable<MessageDto>> GetChatMessages(long chatId);

    Task<Chat> CreateChat(CreateChatDto createChatDto);
}