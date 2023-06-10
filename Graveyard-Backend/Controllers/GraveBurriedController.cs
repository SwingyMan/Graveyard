using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
[Authorize(Roles = "Administrator")]
public class GraveBurriedController : ControllerBase
{
    private readonly IGraveBurriedService _graveBurriedService;

    public GraveBurriedController(IGraveBurriedService graveBurriedService)
    {
        _graveBurriedService = graveBurriedService;
    }

    [HttpGet("{GraveId}/{burriedId}/{gravediggerId}")]
    public async Task<IActionResult> addBurriedToGrave(int burriedId, int GraveId, int gravediggerId,
        DateTime burialDate)
    {
        return Ok(await _graveBurriedService.addBurriedToGrave(burriedId, GraveId, gravediggerId, burialDate));
    }

    [HttpDelete("{GraveId}/{burriedId}")]
    public async Task<IActionResult> removeBurriedFromGrave(int burriedId, int GraveId)
    {
        await _graveBurriedService.removeBurriedFromGrave(burriedId, GraveId);
        return Ok();
    }
    [AllowAnonymous]
    [HttpGet("{graveId}")]
    public async Task<IActionResult> getBurriedFromGrave(int graveId)
    {
        return Ok( _graveBurriedService.getBurriedFromGrave(graveId));
    }
}