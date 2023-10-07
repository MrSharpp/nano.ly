using Microsoft.AspNetCore.Mvc;
using Nanoly.Dto;
using Nanoly.Entities;
using Nanoly.Services;

namespace Nanoly.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthenticationService _authService;

    public AuthController(AuthenticationService authenticationService)
    {
        _authService = authenticationService;
    }


    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO body)
    {
        var user = await _authService.Login(body);

        if (user == null) return BadRequest("Email doesnt exists");

        return Ok(user);
    }

    [HttpPost("signup")]
    public async Task<User> Signup([FromBody] RegisterRequestDTO body)
    {
        return await _authService.Register(body);
    }

}