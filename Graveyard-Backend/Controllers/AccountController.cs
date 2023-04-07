using Graveyard.Models;
using Graveyard_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AccountController : ControllerBase
    {
        private readonly contextModel _contextModel;
        private readonly ILogger _log;
        public AccountController(contextModel contextModel, ILogger log)
        {
            _contextModel = contextModel;
            _log = log;
        }
        [AllowAnonymous]
        [HttpPost("/api/account/register")]
        public IActionResult register(string email,string name,string lastname,string password)
        {
            Customer customer = new Customer(name,lastname,email,password);
            _contextModel.customer.Add(customer);
            _contextModel.SaveChanges();
            JwtAuth jwtAuth = new JwtAuth();
            var x =jwtAuth.GenerateToken(customer);
            return Ok(x);
        }
        [AllowAnonymous]
        [HttpGet("/api/account/login")]
        public IActionResult login()
        {
            throw new NotImplementedException();
        }
        [HttpGet("/api/account/logout")]
        public IActionResult logout()
        {
            throw new NotImplementedException();
        }
        [Authorize(Roles = "User,Administrator")]
        [HttpDelete("/api/account/delete")]
        public IActionResult removeAccount() { throw new NotImplementedException(); }
        [HttpDelete("/api/account/delete/{id}")]
        public IActionResult deleteAccount(int id) { throw new NotImplementedException(); }
        [HttpPut("/api/account/edit/{id}")]
        public IActionResult editAccount(int id,Customer customer) { throw new NotImplementedException(); }
        [HttpGet("/api/account/grant/{id1}/{id2}")]
        public IActionResult grantGrave(int id1,int id2) { throw new NotImplementedException(); }
    }
}
