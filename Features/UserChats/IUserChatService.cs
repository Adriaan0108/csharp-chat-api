using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.UserChats;

public interface IUserChatService
{
    Task<List<User>> GetChatUsers(long chatId);

    Task<List<Chat>> GetUserChats(long userId);
}