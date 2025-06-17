using csharp_chat_api.Features.Chats;

namespace csharp_chat_api.Features.Users;

public interface IUserService
{
    Task<IEnumerable<ChatDto>> GetUserChats(long userId);
}