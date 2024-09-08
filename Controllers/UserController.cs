using LunaEdgeTask.Models;
using LunaEdgeTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace LunaEdgeTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        await _userService.RegisterUser(user);
        return Ok(new { message = "User registered successfully" });
    }
}