using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[ApiController]
[Authorize(Roles = "User,Administrator")]
[Route("api/[controller]/[action]")]
public class PurchaseController : ControllerBase
{
    private readonly PurchaseHistoryService _purchaseHistoryService;

    public PurchaseController(ContextModel contextModel)
    {
        var purchase = new PurchaseHistoryRepository(contextModel);
        var cart = new CartRepository(contextModel);
        var item = new ItemRepository(contextModel);
        _purchaseHistoryService = new PurchaseHistoryService(purchase, cart, item);
    }

    [HttpGet]
    public async Task<IActionResult> submit()
    {
        return Ok(await _purchaseHistoryService.submitCart(int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value)));
    }

    [HttpGet]
    public async Task<IActionResult> get()
    {
        return Ok(await _purchaseHistoryService.getList(int.Parse(User.Claims
            .First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value)));
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut("{PurchaseId}")]
    public async Task<IActionResult> changeState(int PurchaseId)
    {
        return Ok(await _purchaseHistoryService.changeState(PurchaseId));
    }
}