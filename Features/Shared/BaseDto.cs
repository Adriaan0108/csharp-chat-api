namespace csharp_chat_api.Features.Shared;

public class BaseDto
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}