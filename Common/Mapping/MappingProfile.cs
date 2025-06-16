using csharp_chat_api.Features;
using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Users;
using Riok.Mapperly.Abstractions;

namespace csharp_chat_api.Common.Mapping;

[Mapper]
public static partial class MappingProfile
{
    // auth
    public static partial LoginResponseDto ToLoginResponseDto(User user);

    // users
    public static partial User ToUser(RegisterDto registerDto);

    public static partial UserDto ToUserDto(User user);

    public static partial List<UserDto> ToUserDto(List<User> users);

    // chats
    public static partial ChatDto ToChatDto(Chat chat);
    public static partial List<ChatDto> ToChatDto(List<Chat> chats);
}