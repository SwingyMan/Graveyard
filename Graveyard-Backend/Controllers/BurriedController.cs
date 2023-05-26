using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[Authorize(Roles = "Administrator")]
[ApiController]
public class BurriedController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly BurriedRepository _burriedRepository;
    private readonly BurriedService _burriedService;
    public BurriedController(contextModel contextModel)
    {
        _contextModel = contextModel;
        _burriedRepository = new BurriedRepository(_contextModel);
        _burriedService = new BurriedService(_burriedRepository);
    }

    [HttpPost]
    public async Task<IActionResult> addBurried([FromBody]DTOs.Burried burried)
    {
        return Ok(await _burriedService.addBurried(burried));
    }
    [HttpPut("{BurriedId}")]
    public async Task<IActionResult> editBurried(int BurriedId, [FromBody] DTOs.Burried burried)
    {
        return Ok(await _burriedService.editById(BurriedId, burried));
    }

    [AllowAnonymous]
    [HttpGet("{page}")]
    public async Task<IActionResult> getAll(int page)
    {
        return Ok(await _burriedService.getAll(page));
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> getById(int id)
    {
        return Ok(await _burriedService.getById(id));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteById(int id)
    {
        await _burriedService.deleteBurried(id);
        return Ok();
    }
}