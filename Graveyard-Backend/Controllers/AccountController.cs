using Graveyard.Models;
using Graveyard_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize(Roles = "Administrator,User")]
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
            Customer customer = new Customer(registerForm.FirstName, registerForm.LastName, registerForm.email, registerForm.password);
            var testEmail = _contextModel.customer.FirstOrDefault(x => x.Email == registerForm.email);
            if (testEmail != null)
            {
                _log.Warning("Tried to register on taken email: " + testEmail.Email + " from ip" + HttpContext.Request.Host);
                return BadRequest("Email taken");
            }
            else
            {
                _contextModel.customer.Add(customer);
                _contextModel.SaveChanges();
                JwtAuth jwtAuth = new JwtAuth();
                var x = jwtAuth.GenerateToken(customer);
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",x);
                _log.Information("Created new user on email: " + customer.Email + " from ip" + HttpContext.Request.Host);
                return Ok(x);
            }
        }
        [AllowAnonymous]
        [HttpPost("/api/account/login")]
        public IActionResult Login([FromBody] LoginDTO loginForm)
        {
            loginForm.hashPassword();
            var account = _contextModel.customer.FirstOrDefault(x => x.Email == loginForm.email && x.Password == loginForm.password);
            if (account == null)
            {
                _log.Warning("Tried to login on address: " + HttpContext.Request.Host);
                return NotFound();
            }
            else
            {
                JwtAuth jwtAuth = new JwtAuth();
                var x = jwtAuth.GenerateToken(account);
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
                _log.Information("Succesfully loged on email as: " + loginForm.email + " from ip:" + HttpContext.Request.Host);
                return Ok(x);
            }
        }
        [HttpDelete("/api/account/delete/self")]
        public IActionResult removeAccount() { 
        int id = int.Parse(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var acc=   _contextModel.customer.FirstOrDefault(x => x.CustomerID == id);
           _contextModel.customer.Attach(acc);
            _contextModel.customer.Remove(acc);
            _contextModel.SaveChanges();
            _log.Information("Account with id: " + id + " deleted from: " + HttpContext.Request.Host);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("/api/account/list")]
        public IActionResult listAccount()
        {
            var list = _contextModel.customer.ToList();
            return Ok(list);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("/api/account/delete/{id}")]
        public IActionResult deleteAccount(int id)
        {
            Customer customer = new Customer() { CustomerID = id };
            _contextModel.customer.Attach(customer);
            _contextModel.Remove(customer);
            _contextModel.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("/api/account/edit/{id}")]
        public IActionResult editAccount(int id, [FromBody] EditDTO customer)
        {
            var account = _contextModel.customer.FirstOrDefault(x => x.CustomerID == id);
            customer.hashPassword();
            account.Name = customer.FirstName;
            account.LastName = customer.LastName;
            account.Owned_role = customer.Owned_role;
            account.Email = customer.email;
            account.Password = customer.password;
            _contextModel.SaveChanges();
            return Ok(account);
        }

    }
}
