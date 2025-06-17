using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.UserChats;
using csharp_chat_api.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace csharp_chat_api.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Chat> Chats { get; set; }

    public DbSet<Message> Messages { get; set; }
    public DbSet<UserChat> UserChats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // // Configure composite primary key for join table
        // modelBuilder.Entity<UserChat>()
        //     .HasKey(uc => new { uc.UserId, uc.ChatId });

        // User ↔ UserChat relationship (One-to-Many)
        modelBuilder.Entity<UserChat>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserChats)
            .HasForeignKey(uc => uc.UserId);

        // Chat ↔ UserChat relationship (One-to-Many)
        modelBuilder.Entity<UserChat>()
            .HasOne(uc => uc.Chat)
            .WithMany(c => c.UserChats)
            .HasForeignKey(uc => uc.ChatId);

        // Chat ↔ Message relationship (One-to-Many)
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId);

        // User ↔ Message relationship (One-to-Many) - for sender
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId);
    }
}