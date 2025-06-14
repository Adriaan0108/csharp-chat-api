using System.ComponentModel.DataAnnotations;

namespace csharp_chat_api.Features;

public class LoginDto
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
}