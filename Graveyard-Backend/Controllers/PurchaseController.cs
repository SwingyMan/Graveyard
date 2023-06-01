using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[ApiController]
[Authorize(Roles = "User,Administrator")]
[Route("api/[controller]/[action]")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseHistoryService _purchaseHistoryService;

    public PurchaseController(IPurchaseHistoryService purchaseHistoryService)
    {
        _purchaseHistoryService = purchaseHistoryService;
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
    [HttpPatch("{PurchaseId}")]
    public async Task<IActionResult> changeState(int PurchaseId)
    {
        return Ok(await _purchaseHistoryService.changeState(PurchaseId));
    }
}