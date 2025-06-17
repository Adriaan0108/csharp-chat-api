using System.ComponentModel.DataAnnotations.Schema;
using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.Shared;
using csharp_chat_api.Features.UserChats;

namespace csharp_chat_api.Features.Chats;

[Table("chats")]
public class Chat : BaseModel
{
    [Column("title")] public string Title { get; set; }

    [Column("description")] public string Description { get; set; }

    public ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}