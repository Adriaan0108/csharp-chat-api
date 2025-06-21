using Microsoft.AspNetCore.Mvc;

namespace csharp_chat_api.Features.Users;

[Route("/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
}