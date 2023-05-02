using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using Graveyard_Backend.Models;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
public class AccountController : ControllerBase
{
    private readonly contextModel _contextModel;
    private readonly ILogger _log;
    private readonly HttpClient _httpClient;
    private readonly JwtAuth _jwtAuth;
    private readonly UserRepository _userRepository;
    public AccountController(contextModel contextModel, ILogger log, HttpClient httpClient, JwtAuth jwtAuth)
    {
        _contextModel = contextModel;
        _log = log;
        _httpClient = httpClient;
        _jwtAuth = jwtAuth;
        _userRepository = new UserRepository(_contextModel);
    }

    [AllowAnonymous]
    [HttpPost("/api/account/register")]
    public async Task<IActionResult> register([FromBody] RegisterDTO registerForm)
    {
        var customer = new Customer(registerForm.FirstName, registerForm.LastName, registerForm.email,
            registerForm.password);
        var testEmail = await _userRepository.getByEmail(registerForm.email);
        if (testEmail != null)
        {
            _log.Warning("Tried to register on taken email: " + testEmail.Email + " from ip" +
                         HttpContext.Request.Host);
            return BadRequest("Email taken");
        }
        {
           await _userRepository.add(customer);
            var x = _jwtAuth.GenerateToken(customer);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            _log.Information("Created new user on email: " + customer.Email + " from ip" + HttpContext.Request.Host);
            return Ok(x);
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/account/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginForm)
    {
        loginForm.hashPassword();
        var account = await _userRepository.getByEmailAndPassword(loginForm.email, loginForm.password);
        if (account == null)
        {
            _log.Warning("Tried to login on address: " + HttpContext.Request.Host);
            return NotFound();
        }

        {
            var x = _jwtAuth.GenerateToken(account);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            _log.Information("Succesfully loged on email as: " + loginForm.email + " from ip:" +HttpContext.Request.Host);
            return Ok(x);
        }
    }

    [HttpDelete("/api/account/delete/self")]
    public async Task<IActionResult> removeAccount()
    {
        var id = int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var acc = await _userRepository.deleteByID(id);
        _log.Information("Account with id: " + id + " deleted from: " + HttpContext.Request.Host);
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
        if(value==false)
            return NotFound();
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("/api/account/edit/{id}")]
    public async Task<IActionResult> editAccount(int id, [FromBody] EditDTO customer)
    {
        customer.hashPassword();
        await _userRepository.updateByID(id, customer);
        return Ok(_userRepository.getByID(id));
    }

}