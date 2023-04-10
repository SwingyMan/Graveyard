using Graveyard.Models;
using Graveyard_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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
        public IActionResult register([FromBody] RegisterDTO registerForm)
        {
            Customer customer = new Customer(registerForm.FirstName,registerForm.LastName,registerForm.email,registerForm.password);
            var testEmail = _contextModel.customer.FirstOrDefault(x => x.Email == registerForm.email);
            if (testEmail != null) {
                _log.Warning("Tried to register on taken email: " + testEmail.Email+" from ip" + HttpContext.Request.Host);
                return BadRequest("Email taken");
            }
            else
            {
                _contextModel.customer.Add(customer);
                _contextModel.SaveChanges();
                JwtAuth jwtAuth = new JwtAuth();
                var x = jwtAuth.GenerateToken(customer);
                _log.Information("Created new user on email: "+customer.Email+ " from ip" + HttpContext.Request.Host);
                return Ok(x);
            }
        }
        [AllowAnonymous]
        [HttpPost("/api/account/login")]
        public IActionResult Login([FromBody] LoginDTO loginForm) 
        {
            loginForm.hashPassword();
            var account = _contextModel.customer.FirstOrDefault(x => x.Email ==loginForm.email && x.Password == loginForm.password);
            if (account == null) {
                _log.Warning("Tried to login on address: " + HttpContext.Request.Host);
                return NotFound(); }
            else {
                JwtAuth jwtAuth = new JwtAuth();
                _log.Information("Succesfully loged on email as: " + loginForm.email + " from ip:" + HttpContext.Request.Host);
                return Ok(jwtAuth.GenerateToken(account)); }
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
        public IActionResult deleteAccount(int id) {
            Customer customer = new Customer () { CustomerID  = id};
            _contextModel.customer.Attach(customer);
            _contextModel.Remove(customer);
            _contextModel.SaveChanges();
            return Ok();
             }
        [HttpPut("/api/account/edit/{id}")]
        public IActionResult editAccount(int id,Customer customer) { throw new NotImplementedException(); }
        [HttpGet("/api/account/grant/{id1}/{id2}")]
        public IActionResult grantGrave(int id1,int id2) { throw new NotImplementedException(); }
    }
}
