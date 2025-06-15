using csharp_chat_api.Features;
using csharp_chat_api.Features.Users;
using Riok.Mapperly.Abstractions;

namespace csharp_chat_api.Common.Mapping;

[Mapper]
public static partial class MappingProfile
{
    public static partial LoginResponseDto ToLoginResponseDto(User user);

    public static partial User ToUser(RegisterDto registerDto);
}