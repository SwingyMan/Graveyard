using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Grave = Graveyard_Backend.DTOs.Grave;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator")]
[Route("/api/[controller]/[action]")]
public class GraveController : ControllerBase
{
    private readonly ContextModel _contextModel;
    private readonly GraveRepository _graveRepository;
    private readonly GraveService _graveService;

    public GraveController(ContextModel contextModel)
    {
        _contextModel = contextModel;
        _graveRepository = new GraveRepository(_contextModel);
        _graveService = new GraveService(_graveRepository);
    }

    [AllowAnonymous]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
        return Ok(await _graveService.list(page));
    }

    [HttpPost]
    public async Task<IActionResult> add([FromBody] Grave graveDto)
    {
        return Ok(await _graveService.add(graveDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        await _graveService.delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] Grave graveDto)
    {
        return Ok(await _graveService.edit(id, graveDto));
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> get(int id)
    {
        return Ok(await _graveService.getById(id));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> extend(int id)
    {
        return Ok(await _graveService.extendGrave(id));
    }
}