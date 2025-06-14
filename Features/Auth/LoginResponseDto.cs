using csharp_chat_api.Features.Shared;

namespace csharp_chat_api.Features;

public class LoginResponseDto : BaseDto
{
    public string Token { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime ExpiresAt { get; set; }
}