using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
[Authorize(Roles = "Administrator")]
public class GraveBurriedController : ControllerBase
{
    private readonly GraveBurriedService _graveBurriedService;

    public GraveBurriedController(ContextModel contextModel)
    {
        _graveBurriedService = new GraveBurriedService(new GraveBurriedRepository(contextModel));
    }

    [HttpGet("{GraveId}/{burriedId}")]
    public async Task<IActionResult> addBurriedToGrave(int burriedId, int GraveId, DateTime burialDate)
    {
        return Ok(await _graveBurriedService.addBurriedToGrave(burriedId, GraveId, burialDate));
    }

    [HttpDelete("{GraveId}/{burriedId}")]
    public async Task<IActionResult> removeBurriedFromGrave(int burriedId, int GraveId)
    {
        await _graveBurriedService.removeBurriedFromGrave(burriedId, GraveId);
        return Ok();
    }
}