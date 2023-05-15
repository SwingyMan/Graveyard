using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
public class ShopController : ControllerBase
{
    private readonly CartRepository _cartRepository;
    private readonly contextModel _contextModel;
    private readonly ItemRepository _itemRepository;
    private readonly ILogger _log;

    public ShopController(contextModel contextModel, ILogger log)
    {
        _contextModel = contextModel;
        _log = log;
        _cartRepository = new CartRepository(_contextModel);
        _itemRepository = new ItemRepository(_contextModel);
    }

    [AllowAnonymous]
    [HttpGet("/api/shop/{id}")]
    public async Task<IActionResult> listItems(int id)
    {
        _log.Information("Shop listed by: " + HttpContext.Request.Host);
        return Ok(await _itemRepository.ListAll(id));
    }

    [HttpPost("/api/shop/buy/{id}")]
    public IActionResult buyItem(int id)
    {
        _log.Information("Item " + id + " added by: " + HttpContext.Request.Host);
        var customerid = int.Parse(User.Claims.First(i =>
            i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
        if (cart == null)
        {
            var customer = _contextModel.customer.FirstOrDefault(x => x.CustomerID == customerid);
            var item = _contextModel.shop.FirstOrDefault(x => x.ItemID == id);
            var cart1 = new Cart(customer, item);
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
    public IActionResult showCart()
    {
        _log.Information("Cart requested by: " + HttpContext.Request.Host);
        var customerid = int.Parse(User.Claims.First(i =>
            i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
        if (cart == null)
            return NotFound();
        return Ok(cart);
    }

    [HttpDelete("/api/shop/cart/delete")]
    public IActionResult deleteItemFromCart(int id)
    {
        var customerid = int.Parse(User.Claims.First(i =>
            i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
        _log.Information("Cart item " + id + " deleted by: " + HttpContext.Request.Host);
        cart.Items.Where(x => x.ItemID == id);
        _contextModel.SaveChanges();
        return Ok(cart);
    }

    [HttpPost("/api/shop/add")]
    [Authorize(Roles = "Administrator")]
    public IActionResult addItem([FromBody] Item itemDto)
    {
        var item = new Item(itemDto.kind, itemDto.price, itemDto.quantity);
        _log.Information("Item added by: " + HttpContext.Request.Host);
        _itemRepository.add(item);
        return Ok();
    }

    [HttpPut("/api/shop/edit/{id}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult editItem(int id, [FromBody] Item itemDto)
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
    public IActionResult deleteItem(int id)
    {
        _log.Information("Item deleted by: " + HttpContext.Request.Host);
        _itemRepository.deleteByID(id);
        return Ok();
    }
}