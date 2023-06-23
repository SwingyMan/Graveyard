using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[Authorize(Roles = "Administrator")]
[ApiController]
public class BurriedController : ControllerBase
{
    private readonly IBurriedService _burriedService;

    public BurriedController(IBurriedService burriedService)
    {
        _burriedService = burriedService;
    }

    [HttpPost]
    public async Task<IActionResult> addBurried([FromBody] Burried burried)
    {
        return Ok(await _burriedService.addBurried(burried));
    }

    [HttpPatch("{BurriedId}")]
    public async Task<IActionResult> editBurried(int BurriedId, [FromBody] Burried burried)
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
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetNewBurried()
    {
        return Ok(await _burriedService.GetToBeBurried());
    }
}