using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Item = Graveyard_Backend.DTOs.Item;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[Authorize("Administrator")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ContextModel contextModel)
    {
        var itemrepository = new ItemRepository(contextModel);
        _itemService = new ItemService(itemrepository);
    }
    [HttpPost]
    public async Task<IActionResult> addItem(Item item)
    {
        return Ok(await _itemService.addItem(item));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> getItem(int id)
    {
        return Ok(await _itemService.getItems(id));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> removeItem(int id)
    {
        await _itemService.removeItem(id);
        return Ok();
    }
    [HttpPut("{ItemId}/{quantity}")]
    public async Task<IActionResult> changeItemQuantity(int quantity,int ItemId)
    {
        return Ok(await _itemService.changeQuantity(ItemId, quantity));
    }
    [HttpPatch("{ItemId}")]
    public async Task<IActionResult> editItem(int ItemId,[FromBody]DTOs.Item item)
    {
        return Ok(await _itemService.updateItem(ItemId, item));
    }
    [HttpGet("{page}")]
    public async Task<IActionResult> getItems(int page)
    {
        return Ok(await _itemService.getItems(page));
    }
    
}