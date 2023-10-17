using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Nanoly.Services;

namespace Nanoly.Controllers;

[Route("/")]
[ApiController]
public class RouterController : ControllerBase
{
    private readonly SpaceNameService _spaceNameService;
    public RouterController(SpaceNameService spaceNameService)
    {
        _spaceNameService = spaceNameService;
    }

    [HttpGet("{spaceName}")]
    public async Task<IActionResult> SpaceNameRedirection([FromRoute] string spaceName)
    {
        var SpaceName = await _spaceNameService.getSpaceName(spaceName);

        if (SpaceName == null) return BadRequest("Space name not found with this name");

        HttpContext.Response.Headers.Add("Location", "http://www.google.com");

        return new StatusCodeResult(303);
    }
}