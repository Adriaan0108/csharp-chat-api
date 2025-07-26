namespace csharp_chat_api.Features.Users;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserById(long id);
    Task<User> CreateUser(User user);
    Task UpdateUser(User user);
    Task<IList<User>> GetOtherUsers(long userId);
}