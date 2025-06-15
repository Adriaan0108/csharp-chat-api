using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.UserChats;

public class UserChatService : IUserChatService
{
    private readonly IUserChatRepository _userChatRepository;

    public UserChatService(IUserChatRepository userChatRepository)
    {
        _userChatRepository = userChatRepository;
    }

    public async Task<List<User>> GetChatUsers(long chatId)
    {
        var users = await _userChatRepository.GetChatUsers(chatId);

        return users;
    }

    public async Task<List<Chat>> GetUserChats(long userId)
    {
        var chats = await _userChatRepository.GetUserChats(userId);

        return chats;
    }
}