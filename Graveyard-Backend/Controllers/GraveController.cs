﻿using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
public class GraveController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly GraveRepository _graveRepository;
    private readonly ToBeBuriedRepository _toBeBuriedRepository;

    public GraveController(contextModel contextModel)
    {
        _contextModel = contextModel;
        _graveRepository = new GraveRepository(contextModel);
        _toBeBuriedRepository = new ToBeBuriedRepository(contextModel);
    }

    [HttpGet("/api/grave/list/{id}")]
    public IActionResult listGraves(int id)
    {
        return Ok(_graveRepository.ListAll(id));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost("/api/grave/add")]
    public async Task<IActionResult> addGrave([FromBody] DTOs.Grave graveDto)
    {
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
        _graveRepository.deleteByID(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("/api/grave/edit/{id}")]
    public IActionResult editGrave(int id, [FromBody] DTOs.Grave graveDto)
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
    [HttpGet("/api/grave/get/{id}")]
    public IActionResult getGrave(int id)
    {
        return Ok(_graveRepository.getByID(id));
    }

    [HttpGet("/api/grave/buy/{id}")]
    public IActionResult extendGrave(int id)
    {
        return Ok(_graveRepository.ExtendDate(id));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost("/api/burried/tobeburried/add")]
    public IActionResult addToBeBurried([FromBody] DTOs.Burial burialDto)
    {
        var burried = new Burried(burialDto.name, burialDto.lastname, burialDto.date_of_birth,
            burialDto.date_of_death);
        var toBeBurried = new ToBeBurried(burried, burialDto.burial_date);
        return Ok(_toBeBuriedRepository.add(toBeBurried));
    }

    [AllowAnonymous]
    [HttpGet("/api/burried/tobeburried/list")]
    public IActionResult listToBeBurried(int id)
    {
        return Ok(_toBeBuriedRepository.ListAll(id));
    }

    [HttpPatch("/api/burried/tobeburried/edit")]
    public IActionResult editToBeBurried(int id, [FromBody] DTOs.Burial burialDto)
    {
        var burried = new Burried(burialDto.name, burialDto.lastname, burialDto.date_of_birth, burialDto.date_of_death);
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