using System.ComponentModel.DataAnnotations;

namespace csharp_chat_api.Features.Chats;

public class CreateChatDto
{
    [Required] public string Title { get; set; }

    [Required] public string Description { get; set; }

    [Required] public bool IsDirectChat { get; set; }

    public IList<int> UserIds { get; set; }
}