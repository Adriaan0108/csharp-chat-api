using System.ComponentModel.DataAnnotations.Schema;
using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Shared;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Messages;

[Table("messages")]
public class Message : BaseModel
{
    [Column("text")] public string Text { get; set; }

    [Column("chat_id")] public long ChatId { get; set; }

    [Column("sender_id")] public long SenderId { get; set; }

    public Chat Chat { get; set; }

    public User Sender { get; set; }
}