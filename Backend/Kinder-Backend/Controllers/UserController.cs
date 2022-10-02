using System.Threading.Tasks;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<LoginResponse> Login( LoginRequest request)
    {
        var accountInfo = await _userService.GetAccountInfo(request);
        //TODO: should have login success token
        return new LoginResponse()
        {
            Success = true,
            UserId =accountInfo.Id 
        };
    }
}

public class LoginResponse
{
    public bool Success { get; set; }
    public string UserId { get; set; }
}

public class LoginRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
}