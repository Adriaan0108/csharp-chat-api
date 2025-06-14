namespace csharp_chat_api.Infrastructure.Configuration;

public class JwtSettings
{
    public string Key { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }
}