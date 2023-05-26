using Graveyard_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graveyard_Backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ContextModel _contextModel;

    public CartController(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    [HttpGet]
    public IActionResult showCart()
    {
		throw new NotImplementedException();
	}

    [HttpDelete]
    public IActionResult delete(int id)
    {
		throw new NotImplementedException();
	}

    [HttpGet]
    public Task<IActionResult> submit()
    {
        throw new NotImplementedException();
    }
}