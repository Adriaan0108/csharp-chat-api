using csharp_chat_api.Common.Mapping;

namespace csharp_chat_api.Features.Messages;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<MessageDto>> GetChatMessages(long chatId)
    {
        var messages = await _messageRepository.GetChatMessages(chatId);

        var messageDtos = MappingProfile.ToMessageDto(messages);

        return messageDtos;
    }
}