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
    public async Task<User> Login(LoginRequestDTO body)
    {
        return await _authService.Login(body);
    }

}