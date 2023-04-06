using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers
{
    [Authorize]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        public IActionResult register()
        {
            throw new NotImplementedException();
        }
        [AllowAnonymous]
        public IActionResult login()
        {
            throw new NotImplementedException();
        }
        public IActionResult logout()
        {
            throw new NotImplementedException();
        }
        public IActionResult removeAccount() { throw new NotImplementedException(); }
        public IActionResult deleteAccount(int id) { throw new NotImplementedException(); }
        public IActionResult editAccount(int id,Customer customer) { throw new NotImplementedException(); }
        public IActionResult grantGrave() { throw new NotImplementedException(); }
    }
}
