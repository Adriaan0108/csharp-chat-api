using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.UserChats;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Chats;

public class ChatService : IChatService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUserChatRepository _userChatRepository;

    public ChatService(IUserChatRepository userChatRepository, IMessageRepository messageRepository)
    {
        _userChatRepository = userChatRepository;
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<UserDto>> GetChatUsers(long chatId)
    {
        var users = await _userChatRepository.GetChatUsers(chatId);

        var userDtos = MappingProfile.ToUserDto(users);

        return userDtos;
    }

    public async Task<IEnumerable<MessageDto>> GetChatMessages(long chatId)
    {
        var messages = await _messageRepository.GetChatMessages(chatId);

        var messageDtos = MappingProfile.ToMessageDto(messages);

        return messageDtos;
    }
}