using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
[Route("/api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly HttpClient _httpClient;

    public CustomerController(ICustomerService customerService, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _customerService = customerService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> register([FromBody] Register registerForm)
    {
        var token = await _customerService.CreateUser(registerForm, _httpClient);
        if (token == null)
            return BadRequest("Email Taken");
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> login([FromBody] Login loginForm)
    {
        var x = await _customerService.LoginUser(loginForm, _httpClient);
        if (x == null)
            return NotFound();
        return Ok(x);
    }

    [HttpDelete]
    public async Task<IActionResult> deleteSelf()
    {
        await _customerService.DeleteUser(int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value));
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
        return Ok(await _customerService.GetAll(page));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getById(int id)
    {
        return Ok(await _customerService.GetUser(id));
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        await _customerService.DeleteUser(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPatch("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] Edit customer)
    {
        return Ok(_customerService.UpdateUser(id, customer));
    }
}