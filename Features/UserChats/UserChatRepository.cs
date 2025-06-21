using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Users;
using csharp_chat_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace csharp_chat_api.Features.UserChats;

public class UserChatRepository : IUserChatRepository
{
    private readonly DataContext _context;

    public UserChatRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IList<User>> GetChatUsers(long chatId)
    {
        return await _context.UserChats
            .Where(uc => uc.ChatId == chatId)
            .Include(uc => uc.User)
            .Select(uc => uc.User)
            .ToListAsync();
    }

    public async Task<IList<Chat>> GetUserChats(long userId)
    {
        return await _context.UserChats
            .Where(uc => uc.UserId == userId)
            .Include(uc => uc.Chat)
            .Select(uc => uc.Chat)
            .ToListAsync();
    }

    public async Task<UserChat> CreateUserChat(UserChat userChat)
    {
        await _context.UserChats.AddAsync(userChat);
        await _context.SaveChangesAsync();

        return userChat;
    }
}