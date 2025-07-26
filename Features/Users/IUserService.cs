namespace csharp_chat_api.Features.Users;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetOtherUsers();
}