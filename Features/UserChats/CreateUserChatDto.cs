using System.ComponentModel.DataAnnotations;

namespace csharp_chat_api.Features.UserChats;

public class CreateUserChatDto
{
    [Required] public long UserId { get; set; }

    [Required] public long ChatId { get; set; }
}