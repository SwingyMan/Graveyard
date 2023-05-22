using Graveyard_Backend.Repositories;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;
[Authorize(Roles = "Administrator,User")]

[Route("api/[controller]/[action]")]
[ApiController]
public class ToBeBurriedController : ControllerBase
{
    private readonly ToBeBuriedRepository _toBeBuriedRepository;
    private readonly contextModel _contextModel;

    public ToBeBurriedController(contextModel contextModel)
    {
        _contextModel = contextModel;
        _toBeBuriedRepository = new ToBeBuriedRepository(_contextModel);
    }
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> add([FromBody] DTOs.Burial burialDto)
    {
        var burried = new Burried(burialDto.name, burialDto.lastname, burialDto.date_of_birth,
            burialDto.date_of_death);
        var toBeBurried = new ToBeBurried(burried, burialDto.burial_date);
        return Ok(await _toBeBuriedRepository.add(toBeBurried));
    }

    [AllowAnonymous]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
        return Ok(await _toBeBuriedRepository.ListAll(page));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] DTOs.Burial burialDto)
    {
        var burried = new Burried(burialDto.name, burialDto.lastname, burialDto.date_of_birth, burialDto.date_of_death);
        var toBeBurried = _contextModel.burials.FirstOrDefault(x => x.ToBeBurriedID == id);
        toBeBurried.burried = burried;
        toBeBurried.burial_date = burialDto.burial_date;
        _contextModel.SaveChanges();
        return Ok(toBeBurried);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        await _toBeBuriedRepository.deleteByID(id);
        return Ok();
    }
}