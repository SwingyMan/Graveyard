using System.Net.Http.Headers;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
[Route("/api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly contextModel _contextModel;
    private readonly HttpClient _httpClient;
    private readonly ILogger _log;
    private readonly CustomerRepository _customerRepository;

    public CustomerController(contextModel contextModel, ILogger log, HttpClient httpClient)
    {
        _contextModel = contextModel;
        _log = log;
        _httpClient = httpClient;
        _customerRepository = new CustomerRepository(_contextModel);
        _customerService = new CustomerService(_contextModel);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> register([FromBody] Register registerForm)
    {
        var token = await _customerService.CreateUser(registerForm, _httpClient);
        if (token == null)
            return NotFound("Email Taken");
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> login([FromBody] Login loginForm)
    {
        loginForm.hashPassword();
        var account = await _customerRepository.getByEmailAndPassword(loginForm.email, loginForm.password);
        if (account == null) return NotFound();

        {
            var x = JwtAuth.GenerateToken(account);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            return Ok(x);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> deleteSelf()
    {
        var id = int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        await _customerRepository.deleteByID(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
        return Ok(await _customerRepository.ListAll(page));
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var value = await _customerRepository.deleteByID(id);
        if (value == false)
            return NotFound();
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] Edit customer)
    {
        customer.hashPassword();
        await _customerRepository.updateByID(id, customer);
        return Ok(_customerRepository.getByID(id));
    }
}