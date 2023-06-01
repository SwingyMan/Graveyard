using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "Administrator,User")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> showCart()
    {
        return Ok(await _cartService.showCart(int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value)));
    }

    [HttpDelete("{ItemId}/{GraveId}")]
    public async Task<IActionResult> delete(int ItemId,int GraveId)
    {
        await _cartService.removeItemFromCart(int.Parse(User.Claims
                .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value),
            ItemId, GraveId);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> deleteAll()
    {
        await _cartService.removeAllItemsFromCart(int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value));
        return Ok();
    }
    [HttpGet("{ItemId}/{GraveId}")]
    public async Task<IActionResult> addItemToCart(int ItemId,int GraveId,int quantity)
    {
        return Ok(await _cartService.addItemToCart(int.Parse(User.Claims
                .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value),
            ItemId,
            GraveId, quantity));
    }
}