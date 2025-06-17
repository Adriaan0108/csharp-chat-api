using csharp_chat_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace csharp_chat_api.Features.Messages;

public class MessageRepository : IMessageRepository
{
    private readonly DataContext _context;

    public MessageRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IList<Message>> GetChatMessages(long chatId)
    {
        return await _context.Messages
            .Include(m => m.Sender) // This loads the User data
            .Where(m => m.ChatId == chatId)
            .OrderBy(m => m.CreatedAt)
            .ToListAsync();
    }
}