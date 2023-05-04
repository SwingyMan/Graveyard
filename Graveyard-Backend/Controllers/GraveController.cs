using Graveyard_Backend.Models;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
public class GraveController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly ILogger _log;
    private readonly GraveRepository _graveRepository;
    private readonly ToBeBuriedRepository _toBeBuriedRepository;
    public GraveController(contextModel contextModel, ILogger log)
    {
        _contextModel = contextModel;
        _log = log;
        _graveRepository = new GraveRepository(contextModel);
        _toBeBuriedRepository = new ToBeBuriedRepository(contextModel);
    }

    [HttpGet("/api/grave/list/{id}")]
    public IActionResult listGraves(int id)
    {
        _log.Information("Listed grave for: " + HttpContext.Request.Host);
        return Ok(_graveRepository.ListAll(id));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost("/api/grave/add")]
    public async Task<IActionResult> addGrave([FromBody] GraveDTO graveDto)
    {
        
        _log.Information("Grave added by: " + HttpContext.Request.Host);
        var burried = new Burried(graveDto.name, graveDto.lastname, graveDto.date_of_birth,
            graveDto.date_of_death);
        var grave = new Grave(graveDto.x, graveDto.y, graveDto.status, burried);
       await _graveRepository.add(grave);
        return Ok(grave);
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("/api/grave/delete/{id}")]
    public IActionResult deleteGrave(int id)
    {
        _log.Information("Grave deleted by: " + HttpContext.Request.Host);
        _graveRepository.deleteByID(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("/api/grave/edit/{id}")]
    public IActionResult editGrave(int id, [FromBody] GraveDTO graveDto)
    {
        _log.Information("Grave edited by: " + HttpContext.Request.Host);
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
    [HttpGet("/api/grave/get/{id}")]
    public IActionResult getGrave(int id)
    {
        _log.Information("Grave accesed by: " + HttpContext.Request.Host);
        return Ok(_graveRepository.getByID(id));
    }

    [HttpGet("/api/grave/buy/{id}")]
    public IActionResult extendGrave(int id)
    {
        _log.Information("Extended grave by ip: " + HttpContext.Request.Host);
        return Ok(_graveRepository.ExtendDate(id));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost("/api/burried/tobeburried/add")]
    public IActionResult addToBeBurried([FromBody] BurialDTO burialDto)
    {
        Burried burried = new Burried(burialDto.name, burialDto.lastname, burialDto.date_of_birth,
            burialDto.date_of_death);
        ToBeBurried toBeBurried = new ToBeBurried(burried, burialDto.burial_date);
        return Ok(_toBeBuriedRepository.add(toBeBurried));
    }

    [AllowAnonymous]
    [HttpGet("/api/burried/tobeburried/list")]
    public IActionResult listToBeBurried(int id)
    {
        return Ok(_toBeBuriedRepository.ListAll(id));
    }

    [HttpPatch("/api/burried/tobeburried/edit")]
    public IActionResult editToBeBurried(int id,[FromBody]BurialDTO burialDto)
    {        
        Burried burried = new Burried(burialDto.name, burialDto.lastname, burialDto.date_of_birth,burialDto.date_of_death);
        var toBeBurried = _contextModel.burials.FirstOrDefault(x => x.ToBeBurriedID == id);
        toBeBurried.burried = burried;
        toBeBurried.burial_date = burialDto.burial_date;
        _contextModel.SaveChanges();
        return Ok(toBeBurried);
    }

    [HttpDelete("/api/burried/tobeburried/delete/{id}")]
    public async Task<IActionResult> deleteToBeBurried(int id)
    {
        await _toBeBuriedRepository.deleteByID(id);
        return Ok();
    }
}