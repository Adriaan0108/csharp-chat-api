namespace csharp_chat_api.Infrastructure.Security;

public interface IPasswordHasher
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string hashedPassword);
}