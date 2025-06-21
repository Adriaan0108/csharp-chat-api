using csharp_chat_api.Features;
using csharp_chat_api.Features.Chats;
using csharp_chat_api.Features.Messages;
using csharp_chat_api.Features.UserChats;
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

    public static partial IList<UserDto> ToUserDto(IEnumerable<User> users);

    // chats
    public static partial ChatDto ToChatDto(Chat chat);
    public static partial IList<ChatDto> ToChatDto(IEnumerable<Chat> chats);

    // user chats
    public static partial UserChat ToUserChat(CreateUserChatDto createUserChatDto);

    public static partial Chat ToChat(CreateChatDto createChatDto);

    // messages
    public static partial MessageDto ToMessageDto(Message message);

    public static partial IList<MessageDto> ToMessageDto(IEnumerable<Message> messages);
}