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

    public ShopController(contextModel contextModel)
    {
        _contextModel = contextModel;
        _cartRepository = new CartRepository(_contextModel);
        _itemRepository = new ItemRepository(_contextModel);
    }

    [AllowAnonymous]
    [HttpGet("/api/shop/{id}")]
    public async Task<IActionResult> listItems(int id)
    {
        return Ok(await _itemRepository.ListAll(id));
    }

    [HttpPost("/api/shop/buy/{id}")]
    public IActionResult buyItem(int id)
    {
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
        cart.Items.Where(x => x.ItemID == id);
        _contextModel.SaveChanges();
        return Ok(cart);
    }

    [HttpPost("/api/shop/add")]
    [Authorize(Roles = "Administrator")]
    public IActionResult addItem([FromBody] Item itemDto)
    {
        var item = new Item(itemDto.kind, itemDto.price, itemDto.quantity);
        _itemRepository.add(item);
        return Ok();
    }

    [HttpPut("/api/shop/edit/{id}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult editItem(int id, [FromBody] Item itemDto)
    {
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
        _itemRepository.deleteByID(id);
        return Ok();
    }
}