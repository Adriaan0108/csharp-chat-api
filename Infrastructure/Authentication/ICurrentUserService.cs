namespace csharp_chat_api.Infrastructure.Security;

public interface ICurrentUserService
{
    long GetCurrentUserId();

    string GetCurrentUserEmail();

    bool IsAuthenticated();
}