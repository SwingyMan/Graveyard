using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers
{

    [Authorize]
    public class ShopController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("list")]
        public IActionResult listItems()
        {
            throw new NotImplementedException();
        }
        public IActionResult buyItem()
        { throw new NotImplementedException(); }
        public IActionResult addItem() { throw new NotImplementedException(); }
        public IActionResult deleteItem() {  throw new NotImplementedException(); }
        public IActionResult editItem() {  throw new NotImplementedException(); }  
        public IActionResult deleteItem(int id) {  throw new NotImplementedException(); }
    }
}
