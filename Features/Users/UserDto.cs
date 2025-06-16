namespace csharp_chat_api.Features.Users;

public class UserDto
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}