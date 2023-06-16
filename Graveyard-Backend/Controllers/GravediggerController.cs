using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator")]
[ApiController]
[Route("/api/[controller]/[action]")]
public class GravediggerController : ControllerBase
{
    private readonly IGravediggerService _gravediggerService;

    public GravediggerController(IGravediggerService gravediggerService)
    {
        _gravediggerService = gravediggerService;
    }

    [HttpPost]
    public async Task<IActionResult> addGravedigger([FromBody] Gravedigger gravedigger)
    {
        return Ok(await _gravediggerService.addGravedigger(gravedigger));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> editGravedigger(int id, Gravedigger gravedigger)
    {
        return Ok(await _gravediggerService.updateGravedigger(id, gravedigger));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> removeGravedigger(int id)
    {
        await _gravediggerService.removeGravedigger(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getGravedigger(int id)
    {
        return Ok(await _gravediggerService.getById(id));
    }

    [HttpGet("{page}")]
    public async Task<IActionResult> listGravediggers(int page)
    {
        return Ok(await _gravediggerService.getAll(page));
    }
}