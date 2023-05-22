using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

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
        return Ok(await _graveRepository.ListAll(page));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> add([FromBody] DTOs.Grave graveDto)
    {
        var burried = new Burried(graveDto.name, graveDto.lastname, graveDto.date_of_birth,
            graveDto.date_of_death);
        var grave = new Grave(graveDto.x, graveDto.y, graveDto.status, burried);
        await _graveRepository.add(grave);
        return Ok(grave);
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
    public IActionResult edit(int id, [FromBody] DTOs.Grave graveDto)
    {
        var _grave = _contextModel.grave.FirstOrDefault(x => x.GraveID == id);
        _grave.x = graveDto.x;
        _grave.y = graveDto.y;
        _grave.status = graveDto.status;
        var burried = new Burried(graveDto.name, graveDto.lastname, graveDto.date_of_birth,
            graveDto.date_of_death);
        _grave.burried = burried;
        _contextModel.SaveChanges();
        return Ok(_grave);
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("{id}")]
    public async Task<IActionResult> get(int id)
    {
        return Ok( await _graveRepository.getByID(id));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> extend(int id)
    {
        return Ok(await _graveRepository.ExtendDate(id));
    }

   
}