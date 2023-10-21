using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Nanoly.Services;

namespace Nanoly.Controllers;

[Route("/r")]
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

        return await FindAndRedirect(spaceName);
    }

    [HttpGet("{spaceName}/{subDirective}")]
    public async Task<IActionResult> SpaceNameRedirection([FromRoute] string spaceName, [FromRoute] string subDirective)
    {

        return await FindAndRedirect(spaceName, subDirective);
    }

    private async Task<IActionResult> FindAndRedirect(string spaceName, string subDirective = "/")
    {
        var link = await _spaceNameService.getSpaceName(spaceName, subDirective);

        if (link == null) return BadRequest("Space name not found with this name");

        HttpContext.Response.Headers.Add("Location", link.link);

        return new StatusCodeResult(303);
    }


}