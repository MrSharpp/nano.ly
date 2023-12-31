using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nanoly.Dto;
using Nanoly.Entities;
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

    [HttpGet("find/{spaceName}")]
    public async Task<IActionResult> findSpaceNames([FromRoute] string spaceName)
    {
        var spaceNames = await _spaceNameServic.findSpaceNames(spaceName);

        return Ok(spaceNames);
    }


    [HttpGet("all")]
    public async Task<IActionResult> getAllSpaceNamesRelatedToUser()
    {
        var userId = User.GetUserId();

        var spaceNames = await _spaceNameServic.getAllSpaceNames(userId);

        return Ok(spaceNames);
    }

    [HttpPost]
    public async Task<IActionResult> addSpaceName([FromBody] CreateSpaceNameRequestDTO body)
    {
        // check if space name is free to park
        var isTaken = await _spaceNameServic.isSpaceNameTaken(body.SpaceName);

        if (isTaken == true) return BadRequest("Space name is already taken parked");

        var spaceName = new SpaceName()
        {
            name = body.SpaceName,
            content = body.Content,
            UserId = User.GetUserId()
        };

        await _spaceNameServic.addSpaceName(spaceName);

        return Ok(spaceName);
    }

    [HttpPut("{spaceNameId}")]
    public async Task<IActionResult> updateSpaceName([FromRoute] string spaceNameId, [FromBody] UpdateSpaceNameRequest body)
    {
        var spaceName = await _spaceNameServic.findSpaceNameById(int.Parse(spaceNameId));

        if (spaceName == null) return BadRequest("Space Name with this id not found");

        if (body.SpaceName != null) spaceName.name = body.SpaceName;

        if (body.Content != null) spaceName.content = body.Content;

        await _spaceNameServic.updateSpaceName(spaceName);

        return Ok(spaceNameId);
    }

    [HttpDelete("{spaceNameId}")]
    public async Task<IActionResult> deleteSPaceName([FromRoute] int spaceNameId)
    {
        var spaceName = await _spaceNameServic.findSpaceNameById(spaceNameId);

        if (spaceName == null) return BadRequest("Space name with this id not found");

        await _spaceNameServic.deleteSpaceName(spaceName);

        return Ok();
    }
}