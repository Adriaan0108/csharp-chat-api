using System.ComponentModel.DataAnnotations;

namespace csharp_chat_api.Features;

public class RegisterDto
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }
}