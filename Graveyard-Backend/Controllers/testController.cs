using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers
{
    public class testController : Controller
    {
        [Authorize]
        [HttpGet("/test")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
