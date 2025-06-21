using csharp_chat_api.Common.Exceptions;
using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.UserChats;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Chats;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IUserChatRepository _userChatRepository;

    public ChatService(IUserChatRepository userChatRepository, IMessageRepository messageRepository,
        IChatRepository chatRepository)
    {
        _userChatRepository = userChatRepository;
        _messageRepository = messageRepository;
        _chatRepository = chatRepository;
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

    public async Task<Chat> CreateChat(CreateChatDto createChatDto)
    {
        if (createChatDto.IsDirectChat && createChatDto.UserIds.Count > 2)
            throw new BadRequestException("Cannot create direct chat with more than 2 users");

        if (createChatDto.UserIds.Count < 2)
            throw new BadRequestException("Cannot create chat without at least 2 users");

        var chat = MappingProfile.ToChat(createChatDto);

        var createdChat = await _chatRepository.CreateChat(chat);

        foreach (var id in createChatDto.UserIds)
        {
            var createUserChatDto = new CreateUserChatDto
            {
                ChatId = createdChat.Id,
                UserId = id
            };

            var userChat = MappingProfile.ToUserChat(createUserChatDto);

            await _userChatRepository.CreateUserChat(userChat);
        }

        return createdChat;
    }
}