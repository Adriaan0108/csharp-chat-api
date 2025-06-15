namespace csharp_chat_api.Features;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginDto loginDto);

    Task<LoginResponseDto> Register(RegisterDto registerDto);
}