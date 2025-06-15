using System.ComponentModel.DataAnnotations.Schema;
using csharp_chat_api.Features.Shared;
using csharp_chat_api.Features.UserChats;

namespace csharp_chat_api.Features.Chats;

[Table("chats")]
public class Chat : BaseModel
{
    [Column("name")] public string Name { get; set; }

    [Column("description")] public string Description { get; set; }

    public ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();
}