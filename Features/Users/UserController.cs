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

    [HttpGet("other-users")]
    public async Task<IActionResult> GetOtherUsers()
    {
        var users = await _userService.GetOtherUsers();

        return Ok(users);
    }
}