using Graveyard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly contextModel _contextModel;

    public CartController(contextModel contextModel)
    {
        _contextModel = contextModel;
    }
    [HttpGet]
    public IActionResult showCart()
    {
        var customerid = int.Parse(User.Claims.First(i =>
            i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
        if (cart == null)
            return NotFound();
        return Ok(cart);
    }

    [HttpDelete]
    public IActionResult delete(int id)
    {
        var customerid = int.Parse(User.Claims.First(i =>
            i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        var cart = _contextModel.carts.FirstOrDefault(x => x.Customer.CustomerID == customerid);
        cart.Items.Where(x => x.ItemID == id);
        _contextModel.SaveChanges();
        return Ok(cart);
    }
    [HttpGet]
    public Task<IActionResult> submit()
    {
        throw new NotImplementedException();
    }
}