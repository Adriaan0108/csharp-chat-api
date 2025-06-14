using csharp_chat_api.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace csharp_chat_api.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}