namespace csharp_chat_api.Features.Messages;

public interface IMessageRepository
{
    Task<IList<Message>> GetChatMessages(long chatId);
}