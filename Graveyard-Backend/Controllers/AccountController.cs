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
[Route("/api/[controller]/[action]")]
public class AccountController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly HttpClient _httpClient;
    private readonly ILogger _log;
    private readonly UserRepository _userRepository;
    private readonly AccountService _accountService;
    public AccountController(contextModel contextModel, ILogger log, HttpClient httpClient)
    {
        _contextModel = contextModel;
        _log = log;
        _httpClient = httpClient;
        _userRepository = new UserRepository(_contextModel);
        _accountService = new AccountService(_contextModel);
    }

    [AllowAnonymous]
    [HttpPost]
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
    [HttpPost]
    public async Task<IActionResult> login([FromBody] Login loginForm)
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

    [HttpDelete]
    public async Task<IActionResult> deleteSelf()
    {
        var id = int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        await _userRepository.deleteByID(id);
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("{page}")]
    public async Task<IActionResult> list(int page)
    {
        return Ok(await _userRepository.ListAll(page));
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var value = await _userRepository.deleteByID(id);
        if (value == false)
            return NotFound();
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("{id}")]
    public async Task<IActionResult> edit(int id, [FromBody] Edit customer)
    {
        customer.hashPassword();
        await _userRepository.updateByID(id, customer);
        return Ok(_userRepository.getByID(id));
    }
}