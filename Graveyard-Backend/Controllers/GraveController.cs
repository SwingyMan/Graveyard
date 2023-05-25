using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Grave = Graveyard_Backend.DTOs.Grave;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
[Route("/api/[controller]/[action]")]
public class GraveController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly GraveRepository _graveRepository;

    public GraveController(contextModel contextModel)
    {
        _contextModel = contextModel;
        _graveRepository = new GraveRepository(contextModel);
    }

    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
		throw new NotImplementedException();

	}

	[Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> add([FromBody] Grave graveDto)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        await _graveRepository.deleteByID(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("{id}")]
    public IActionResult edit(int id, [FromBody] Grave graveDto)
    {
		throw new NotImplementedException();

	}

	[Authorize(Roles = "Administrator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> get(int id)
    {
		throw new NotImplementedException();

	}

	[HttpGet("{id}")]
    public async Task<IActionResult> extend(int id)
    {
		throw new NotImplementedException();

	}
}