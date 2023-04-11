using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class ShopController : ControllerBase
    {
        private readonly contextModel _contextModel;
        private readonly ILogger _log;
        public ShopController(contextModel contextModel, ILogger log)
        {
            _contextModel = contextModel;
            _log = log;
        }
        [AllowAnonymous]
        [HttpGet("/api/shop")]
        public IActionResult listItems()
        {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);
            return Ok(_contextModel.shop.ToList());
        }
        [HttpPost("/api/shop/buy/{id}")]
        public IActionResult buyItem(int id)
        {
            _log.Information("Item " + id +" added by: " + HttpContext.Request.Host);
            int customerid = int.Parse(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var customer = _contextModel.customer.FirstOrDefault(x=> x.CustomerID == customerid);
            var item = _contextModel.shop.FirstOrDefault(x=> x.ItemID==id);
            Cart cart = new Cart(customer,item);
            return Ok(cart); }
        [HttpGet("/api/shop/cart")]
        public IActionResult showCart() {
            _log.Information("Cart requested by: " + HttpContext.Request.Host);

            throw new NotImplementedException(); }
        [HttpPost("/api/shop/add")]
        [Authorize(Roles = "Administrator")]
        public IActionResult addItem([FromBody]Item item) {
            _log.Information("Item added by: " + HttpContext.Request.Host);
            _contextModel.Add(item);
            _contextModel.SaveChanges();
            return Ok();
        }
        [HttpPut("/api/shop/edit/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult editItem(int id,[FromBody]Item item) {
            _log.Information("Item eddited by: " + HttpContext.Request.Host);
            var original = _contextModel.shop.FirstOrDefault(x => x.ItemID == id);
            original.kind = item.kind;
            original.price = item.price;
            original.quantity = item.quantity;
            _contextModel.SaveChanges();
            return Ok();
        }
        [HttpDelete("/api/shop/delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult deleteItem(int id) {
            _log.Information("Item deleted by: " + HttpContext.Request.Host);
            var x = _contextModel.shop.FirstOrDefault(x => x.ItemID == id);
            _contextModel.Remove(x);
            _contextModel.SaveChanges();
            return Ok();
        }
    }
}
