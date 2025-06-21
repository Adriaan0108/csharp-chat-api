using csharp_chat_api.Features.UserChats;

namespace csharp_chat_api.Features.Users;

public class UserService : IUserService
{
    private readonly IUserChatRepository _userChatRepository;

    public UserService(IUserChatRepository userChatRepository)
    {
        _userChatRepository = userChatRepository;
    }
}