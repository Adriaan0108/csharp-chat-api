namespace csharp_chat_api.Features.Messages;

public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetChatMessages(long chatId);
}