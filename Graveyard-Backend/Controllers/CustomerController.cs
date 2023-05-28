using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
[Route("/api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly HttpClient _httpClient;

    public CustomerController(ContextModel contextModel, HttpClient httpClient)
    {
        _httpClient = httpClient;
        var customerRepository = new CustomerRepository(contextModel);
        _customerService = new CustomerService(customerRepository);
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
        var x =await _customerService.LoginUser(loginForm, _httpClient);
        if (x == string.Empty)
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
    [HttpPut("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] Edit customer)
    {
        return Ok(_customerService.UpdateUser(id,customer));
    }
}