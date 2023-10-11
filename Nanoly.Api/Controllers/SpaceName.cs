using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nanoly.Services;
using Shared.Web.MvcExtensions;


namespace Nanoly.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SpaceNameController : ControllerBase
{
    private readonly SpaceNameService _spaceNameServic;
    public SpaceNameController(SpaceNameService spaceNameService)
    {
        _spaceNameServic = spaceNameService;
    }


    [HttpGet("all")]
    public async Task<IActionResult> getAllSpaceNamesRelatedToUser()
    {

        var spaceNames = await _spaceNameServic.getAllSpaceNames();
        return Ok(spaceNames);
    }
}