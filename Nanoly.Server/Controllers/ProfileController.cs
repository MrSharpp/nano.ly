using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nanoly.Services;
using Shared.Web.MvcExtensions;

namespace Nanoly.Controllers;

[Authorize]
[Route("api/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly UserService _userService;
    public ProfileController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetLoggedInUser()
    {
        var user = await _userService.GetUserById(User.GetUserId());
        return Ok(new
        {
            user.Id,
            user.email,
        });
    }
}