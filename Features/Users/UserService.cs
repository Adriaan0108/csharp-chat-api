using csharp_chat_api.Common.Mapping;
using csharp_chat_api.Infrastructure.Security;

namespace csharp_chat_api.Features.Users;

public class UserService : IUserService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public async Task<IEnumerable<UserDto>> GetOtherUsers()
    {
        var userId = _currentUserService.GetCurrentUserId();

        var users = await _userRepository.GetOtherUsers(userId);

        var userDtos = MappingProfile.ToUserDto(users);

        return userDtos;
    }
}