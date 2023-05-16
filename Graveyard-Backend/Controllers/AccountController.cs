using System.Net.Http.Headers;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
public class AccountController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly HttpClient _httpClient;
    private readonly UserRepository _userRepository;
    private readonly AccountService _accountService;
    public AccountController(contextModel contextModel, HttpClient httpClient)
    {
        _contextModel = contextModel;
        _httpClient = httpClient;
        _userRepository = new UserRepository(_contextModel);
        _accountService = new AccountService(_contextModel);
    }

    [AllowAnonymous]
    [HttpPost("/api/account/register")]
    public async Task<IActionResult> register([FromBody] Register registerForm)
    {
        var token =await _accountService.CreateUser(registerForm, _httpClient);
        if (token == null)
            return NotFound("Email Taken");
        else
        {
            return Ok(token);
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/account/login")]
    public async Task<IActionResult> Login([FromBody] Login loginForm)
    {
        loginForm.hashPassword();
        var account = await _userRepository.getByEmailAndPassword(loginForm.email, loginForm.password);
        if (account == null)
        {
            return NotFound();
        }

        {
            var x = JwtAuth.GenerateToken(account);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            return Ok(x);
        }
    }

    [HttpDelete("/api/account/delete/self")]
    public async Task<IActionResult> removeAccount()
    {
        var id = int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var acc = await _userRepository.deleteByID(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("/api/account/list/{id}")]
    public async Task<IActionResult> listAccount(int id)
    {
        return Ok(await _userRepository.ListAll(id));
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("/api/account/delete/{id}")]
    public async Task<IActionResult> deleteAccount(int id)
    {
        var value = await _userRepository.deleteByID(id);
        if (value == false)
            return NotFound();
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("/api/account/edit/{id}")]
    public async Task<IActionResult> editAccount(int id, [FromBody] Edit customer)
    {
        customer.hashPassword();
        await _userRepository.updateByID(id, customer);
        return Ok(_userRepository.getByID(id));
    }
}