using csharp_chat_api.Common.Exceptions;
using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Features.UserChats;
using csharp_chat_api.Features.Users;
using csharp_chat_api.Infrastructure.Security;

namespace csharp_chat_api.Features.Chats;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserChatRepository _userChatRepository;

    public ChatService(IUserChatRepository userChatRepository, ICurrentUserService currentUserService,
        IChatRepository chatRepository)
    {
        _userChatRepository = userChatRepository;
        _currentUserService = currentUserService;
        _chatRepository = chatRepository;
    }

    public async Task<IEnumerable<UserDto>> GetChatUsers(long chatId)
    {
        var users = await _userChatRepository.GetChatUsers(chatId);

        var userDtos = MappingProfile.ToUserDto(users);

        return userDtos;
    }

    public async Task<IEnumerable<ChatDto>> GetUserChats()
    {
        var userId = _currentUserService.GetCurrentUserId();

        var chats = await _userChatRepository.GetUserChats(userId);

        // var chatDtos = MappingProfile.ToChatDto(chats);

        var chatDtos = chats.Select(chat =>
        {
            var chatDto = MappingProfile.ToChatDto(chat);
            chatDto.LastMessage = chat.Messages
                ?.OrderByDescending(m => m.CreatedAt)
                ?.FirstOrDefault();
            return chatDto;
        });

        return chatDtos;
    }

    public async Task<Chat> CreateChat(CreateChatDto createChatDto)
    {
        if (createChatDto.UserIds.Count > 0)
        {
            var userId = _currentUserService.GetCurrentUserId();

            // Remove all existing current user IDs
            createChatDto.UserIds.RemoveAll(id => id == userId);

            // Add current user ID once
            createChatDto.UserIds.Add(userId);

            // Remove any other duplicates (if any)
            createChatDto.UserIds = createChatDto.UserIds.Distinct().ToList();
        }

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