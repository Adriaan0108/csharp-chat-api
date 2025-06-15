using System.ComponentModel.DataAnnotations.Schema;
using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Shared;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.UserChats;

[Table("user_chats")]
public class UserChat : BaseModel
{
    [Column("user_id")] public long UserId { get; set; }

    [Column("chat_id")] public long ChatId { get; set; }

    public User User { get; set; }

    public Chat Chat { get; set; }
}