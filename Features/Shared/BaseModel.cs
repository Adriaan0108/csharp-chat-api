using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_chat_api.Features.Shared;

public class BaseModel
{
    public BaseModel()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    [Column("id")] [Key] public long Id { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}