using csharp_chat_api.Infrastructure.Data;

namespace csharp_chat_api.Features.Chats;

public class ChatRepository : IChatRepository
{
    private readonly DataContext _context;

    public ChatRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Chat> CreateChat(Chat chat)
    {
        await _context.Chats.AddAsync(chat);
        await _context.SaveChangesAsync();

        return chat;
    }
}