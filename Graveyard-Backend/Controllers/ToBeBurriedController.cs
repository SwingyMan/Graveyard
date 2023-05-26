using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Burried = Graveyard_Backend.DTOs.Burried;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator")]
[Route("api/[controller]/[action]")]
[ApiController]
public class ToBeBurriedController : ControllerBase
{
    private readonly ToBeBurriedService _toBeBurriedService;

    public ToBeBurriedController(ContextModel contextModel)
    {
       var _contextModel = contextModel;
       var _toBeBuriedRepository = new ToBeBuriedRepository(_contextModel);
        _toBeBurriedService = new ToBeBurriedService(_toBeBuriedRepository);
    }
    [HttpPost]
    public async Task<IActionResult> add(int ToBeBurriedId,[FromBody] DateTime burial_date)
    {
	    return Ok(_toBeBurriedService.addBurried(ToBeBurriedId, burial_date));
    }

	[AllowAnonymous]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
	    return Ok(await _toBeBurriedService.listburried(page));

    }

	[HttpPatch("{toBeBurriedId}")]
    public async Task<IActionResult> editDate(int toBeBurriedId, [FromBody] DateTime burial_date)
    {
	    return Ok(await _toBeBurriedService.editBurried(toBeBurriedId, burial_date));

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
	    await _toBeBurriedService.removeToBeBurried(id);
	    return Ok();
    }
}