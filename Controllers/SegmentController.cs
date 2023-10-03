using Microsoft.AspNetCore.Mvc;
using Nanoly.Entities;
using Nanoly.Services;

namespace Nanoly.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SegmentController : ControllerBase
{
    private readonly SegmentService _segmentService;

    public SegmentController(SegmentService sService)
    {
        _segmentService = sService;
    }

    [HttpGet]
    public async Task<ActionResult<Segment>> getAllSegment()
    {
        return await _segmentService.getAllSegments();
    }
}