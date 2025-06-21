using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.UserChats;

public interface IUserChatRepository
{
    Task<IList<User>> GetChatUsers(long chatId);

    Task<IList<Chat>> GetUserChats(long userId);

    Task<UserChat> CreateUserChat(UserChat userChat);
}