using csharp_chat_api.Features.Shared;
using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Features.Messages;

public class MessageDto : BaseDto
{
    public string Text { get; set; }

    public long ChatId { get; set; }

    public UserDto Sender { get; set; }
}