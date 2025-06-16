using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Chats;

public interface IChatService
{
    Task<List<UserDto>> GetChatUsers(long chatId);
}