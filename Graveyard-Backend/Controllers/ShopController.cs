using Graveyard_Backend.Models;
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
            _log.Information("Item " + id + " added by: " + HttpContext.Request.Host);
            int customerid = int.Parse(User.Claims.First(i =>
                i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
            if (cart == null)
            {
                var customer = _contextModel.customer.FirstOrDefault(x => x.CustomerID == customerid);
                var item = _contextModel.shop.FirstOrDefault(x => x.ItemID == id);
                Cart cart1 = new Cart(customer, item);
                return Ok(cart1);
            }
            else
            {
                var item = _contextModel.shop.FirstOrDefault(x => x.ItemID == id);
                cart.Items.Add(item);
                _contextModel.SaveChanges();
                return Ok(cart.Items.ToList());
            }
        }

        [HttpGet("/api/shop/cart")]
        public IActionResult showCart() {
            _log.Information("Cart requested by: " + HttpContext.Request.Host);
            int customerid = int.Parse(User.Claims.First(i =>
                i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
            if (cart == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cart);
            }
        }

        [HttpDelete("/api/shop/cart/delete")]
        public IActionResult deleteItemFromCart(int id)
        {
            int customerid = int.Parse(User.Claims.First(i =>
                i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
            _log.Information("Cart item "+ id+" deleted by: " + HttpContext.Request.Host);
            cart.Items.Where(x => x.ItemID == id);
            _contextModel.SaveChanges();
            return Ok(cart);
        }
        [HttpPost("/api/shop/add")]
        [Authorize(Roles = "Administrator")]
        public IActionResult addItem([FromBody]ItemDTO itemDto) {
            Item item = new Item(itemDto.kind, itemDto.price, itemDto.quantity);
            _log.Information("Item added by: " + HttpContext.Request.Host);
            _contextModel.Add(item);
            _contextModel.SaveChanges();
            return Ok();
        }
        [HttpPut("/api/shop/edit/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult editItem(int id,[FromBody]ItemDTO itemDto)
        {
            _log.Information("Item eddited by: " + HttpContext.Request.Host);
            var original = _contextModel.shop.FirstOrDefault(x => x.ItemID == id);
            original.kind = itemDto.kind;
            original.price = itemDto.price;
            original.quantity = itemDto.quantity;
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
