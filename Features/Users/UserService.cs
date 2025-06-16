using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.UserChats;

namespace csharp_chat_api.Features.Users;

public class UserService : IUserService
{
    private readonly IUserChatRepository _userChatRepository;

    public UserService(IUserChatRepository userChatRepository)
    {
        _userChatRepository = userChatRepository;
    }

    public async Task<List<ChatDto>> GetUserChats(long userId)
    {
        var chats = await _userChatRepository.GetUserChats(userId);

        var chatDtos = MappingProfile.ToChatDto(chats);

        return chatDtos;
    }
}