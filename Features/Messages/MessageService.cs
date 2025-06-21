using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Infrastructure.Security;

namespace csharp_chat_api.Features.Messages;

public class MessageService : IMessageService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository, ICurrentUserService currentUserService)
    {
        _messageRepository = messageRepository;
        _currentUserService = currentUserService;
    }

    public async Task<IEnumerable<MessageDto>> GetChatMessages(long chatId)
    {
        var messages = await _messageRepository.GetChatMessages(chatId);

        var messageDtos = MappingProfile.ToMessageDto(messages);

        return messageDtos;
    }

    public async Task<Message> CreateMessage(long chatId, CreateMessageDto createMessageDto)
    {
        var message = MappingProfile.ToMessage(createMessageDto);

        message.ChatId = chatId;
        message.SenderId = _currentUserService.GetCurrentUserId();

        return await _messageRepository.CreateMessage(message);
    }
}