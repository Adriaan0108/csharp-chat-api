using csharp_chat_api.Common.Exceptions;
using csharp_chat_api.Features.Users;
using csharp_chat_api.Infrastructure.Security;

namespace csharp_chat_api.Features;

public class AuthService : IAuthService
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<LoginResponseDto> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByEmail(loginDto.Email);

        if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtTokenService.GenerateToken(user);

        return new LoginResponseDto
        {
            Token = token,
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            ExpiresAt = DateTime.UtcNow.AddHours(24)
        };
    }

    public async Task<LoginResponseDto> Register(RegisterDto registerDto)
    {
        var user = await _userRepository.GetUserByEmail(registerDto.Email);

        if (user != null) throw new ConflictException("Email already exists");

        var hashedPassword = _passwordHasher.HashPassword(registerDto.Password);

        var newUser = new User
        {
            Email = registerDto.Email,
            Password = hashedPassword,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName
        };

        var createdUser = await _userRepository.CreateUser(newUser);

        var token = _jwtTokenService.GenerateToken(createdUser);

        return new LoginResponseDto
        {
            Token = token,
            Id = createdUser.Id,
            Email = createdUser.Email,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            ExpiresAt = DateTime.UtcNow.AddHours(24)
        };
    }
}