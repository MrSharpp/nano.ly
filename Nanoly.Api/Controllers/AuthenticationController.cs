using Microsoft.AspNetCore.Mvc;
using Nanoly.Dto;
using Nanoly.Entities;
using Nanoly.Services;
using Nanoly.Utilities;

namespace Nanoly.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly TokenService _tokenService;
    private readonly AuthenticationHelper _authenticationHelper;

    public AuthController(UserService userService, TokenService tokenService, AuthenticationHelper authenticationHelper)
    {
        _userService = userService;
        _tokenService = tokenService;
        _authenticationHelper = authenticationHelper;
    }


    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO body)
    {
        var user = await _userService.GetUserByEmail(body.Email);

        if (user == null) return BadRequest("User doesnt exists");

        var token = _tokenService.GenerateToken(user);

        return Ok(token);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] RegisterRequestDTO body)
    {
        var exsist = await _userService.GetUserByEmail(body.Email);

        if (exsist != null) return BadRequest("User with this email already exsists");

        var user = new User() { email = body.Email, password = _authenticationHelper.HashPassword(body.Password) };

        var token = _tokenService.GenerateToken(user);

        return Ok(token);
    }

}