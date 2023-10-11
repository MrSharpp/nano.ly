using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Web.MvcExtensions;


namespace Nanoly.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SpaceNameController : ControllerBase
{
    [HttpGet]
    public IActionResult protectedRoute()
    {

        var userId = User.GetUserId();
        // if (claims == null) return Ok("it is null");
        Console.WriteLine(userId);
        return Ok("Ok");
    }
}