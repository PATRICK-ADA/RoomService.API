using Microsoft.AspNetCore.Mvc;
using RoomService.Core.Abstraction;
using RoomService.Core.ApiResponse;
using RoomService.Domain.UserDto;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register-User")]
    public async Task<IActionResult> Register([FromBody] UsersDto model)
    {
            var result = await _userService.CreateUser(model);

        return result is SuccessApiResponse<UsersDto> ? Ok(result) : BadRequest(result);

    }

    [HttpPost("Login-User")]
    public async Task<IActionResult> LoginUser([FromBody] UsersDto model)
    {
        var result = await _userService.LoginUser(model);

        return result is SuccessApiResponse<UsersDto> ? Ok(result) : BadRequest(result);

    }
}