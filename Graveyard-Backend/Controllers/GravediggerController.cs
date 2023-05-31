using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Gravedigger = Graveyard_Backend.DTOs.Gravedigger;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator")]
[ApiController]
[Route("/api/[controller]/[action]")]
public class GravediggerController : ControllerBase
{
    private readonly GravediggerService _gravediggerService;

    public GravediggerController(ContextModel contextModel)
    {
        var repo = new GravediggerRepository(contextModel);
        _gravediggerService = new GravediggerService(repo);
    }

    [HttpPost]
    public async Task<IActionResult> addGravedigger([FromBody] Gravedigger gravedigger)
    {
        return Ok(await _gravediggerService.addGravedigger(gravedigger));
    }

    [HttpPost]
    public async Task<IActionResult> editGravedigger(int id, Gravedigger gravedigger)
    {
        return Ok(await _gravediggerService.updateGravedigger(id, gravedigger));
    }

    [HttpDelete]
    public async Task<IActionResult> removeGravedigger(int id)
    {
        await _gravediggerService.removeGravedigger(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> getGravedigger(int id)
    {
        return Ok(await _gravediggerService.getById(id));
    }

    [HttpGet]
    public async Task<IActionResult> listGravediggers(int page)
    {
        return Ok(await _gravediggerService.getAll(page));
    }
}