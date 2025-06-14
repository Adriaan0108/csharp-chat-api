using System.ComponentModel.DataAnnotations.Schema;
using csharp_chat_api.Features.Shared;

namespace csharp_chat_api.Features.Users;

[Table("users")]
public class User : BaseModel
{
    [Column("email")] public string Email { get; set; }

    [Column("password")] public string Password { get; set; }

    [Column("first_name")] public string FirstName { get; set; }

    [Column("last_name")] public string LastName { get; set; }
}