using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Features.UserChats;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Chats;

public class ChatService : IChatService
{
    private readonly IUserChatRepository _userChatRepository;

    public ChatService(IUserChatRepository userChatRepository)
    {
        _userChatRepository = userChatRepository;
    }

    public async Task<List<UserDto>> GetChatUsers(long chatId)
    {
        var users = await _userChatRepository.GetChatUsers(chatId);

        var userDtos = MappingProfile.ToUserDto(users);

        return userDtos;
    }
}