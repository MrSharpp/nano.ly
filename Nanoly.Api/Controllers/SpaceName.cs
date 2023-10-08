using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Nanoly.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SpaceNameController : ControllerBase
{
    [HttpGet]
    public IActionResult protectedRoute()
    {
        return Ok("You have access to protected route");
    }
}