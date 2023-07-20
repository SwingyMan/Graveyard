using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[Authorize(Roles="Administrator")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost]
    public async Task<IActionResult> addItem(Item item)
    {
        return Ok(await _itemService.addItem(item));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getItem(int id)
    {
        return Ok(await _itemService.getItemById(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> removeItem(int id)
    {
        await _itemService.removeItem(id);
        return Ok();
    }

    [HttpPatch("{ItemId}/{quantity}")]
    public async Task<IActionResult> changeItemQuantity(int quantity, int ItemId)
    {
        return Ok(await _itemService.changeQuantity(ItemId, quantity));
    }

    [HttpPatch("{ItemId}")]
    public async Task<IActionResult> editItem(int ItemId, [FromBody] Item item)
    {
        return Ok(await _itemService.updateItem(ItemId, item));
    }
    [AllowAnonymous]
    [HttpGet("{page}")]
    public async Task<IActionResult> getItems(int page)
    {
        return Ok(await _itemService.getItems(page));
    }
}