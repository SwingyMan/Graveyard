using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
[Route("api/[controller]/[action]")]
[ApiController]
public class ToBeBurriedController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly ToBeBuriedRepository _toBeBuriedRepository;

    public ToBeBurriedController(contextModel contextModel)
    {
        _contextModel = contextModel;
        _toBeBuriedRepository = new ToBeBuriedRepository(_contextModel);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> add([FromBody] Burial burialDto)
	{
		throw new NotImplementedException();

	}

	[AllowAnonymous]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
	{
		throw new NotImplementedException();

	}

	[HttpPatch("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] Burial burialDto)
    {
		throw new NotImplementedException();

	}

	[HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
		throw new NotImplementedException();

	}
}