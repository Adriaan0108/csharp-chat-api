using csharp_chat_api.Features.Users;

namespace csharp_chat_api.Infrastructure.Security;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}