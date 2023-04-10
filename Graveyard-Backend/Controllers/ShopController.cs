using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Core;
using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class ShopController : ControllerBase
    {
        private readonly contextModel _contextModel;
        private readonly ILogger _log;
        public ShopController(contextModel contextModel, ILogger log) {
            _contextModel = contextModel;
            _log = log;
        }
        [AllowAnonymous]
        [HttpGet("/api/shop")]
        public IActionResult listItems()
        {
            _log.Information("Listed items");
            return Ok(_contextModel.shopList.ToList());
        }
        [Authorize(Roles = "User,Administrator")]
        [HttpPost("/api/shop/buy/{id}")]
        public IActionResult buyItem(int id)
        { throw new NotImplementedException(); }
        [Authorize(Roles = "User,Administrator")]
        [HttpGet("/api/shop/cart")]
        public IActionResult showCart() { throw new NotImplementedException(); }
        [HttpPost("/api/shop/add/{id}")]
        public IActionResult addItem() { throw new NotImplementedException(); }
        [HttpPut("/api/shop/edit/{id}")]
        public IActionResult editItem(int id) {  throw new NotImplementedException(); }
        [HttpDelete("/api/shop/delete/{id}")]  
        public IActionResult deleteItem(int id) {  throw new NotImplementedException(); }
    }
}
