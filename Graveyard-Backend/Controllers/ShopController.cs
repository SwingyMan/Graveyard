using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Graveyard_Backend.Controllers;

[Authorize(Roles = "Administrator,User")]
public class ShopController : ControllerBase
{
    private readonly CartRepository _cartRepository;
    private readonly ContextModel _contextModel;
    private readonly ItemRepository _itemRepository;
    private readonly ILogger _log;

    public ShopController(ContextModel contextModel, ILogger log)
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
		throw new NotImplementedException();

	}

	[HttpPost("/api/shop/buy/{id}")]
    public IActionResult buyItem(int id)
    {
		throw new NotImplementedException();
	}


    [HttpPost("/api/shop/add")]
    [Authorize(Roles = "Administrator")]
    public IActionResult addItem([FromBody] Graveyard_Backend.DTOs.Item itemDto)
    {
       throw new NotImplementedException();
    }

    [HttpPut("/api/shop/edit/{id}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult editItem(int id, [FromBody] Graveyard_Backend.DTOs.Item itemDto)
    {
		throw new NotImplementedException();
	}

    [HttpDelete("/api/shop/delete/{id}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult deleteItem(int id)
    {
		throw new NotImplementedException();
	}
}