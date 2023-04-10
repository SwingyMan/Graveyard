using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class ShopController : ControllerBase
    {
        private readonly contextModel _contextModel;
        private readonly ILogger _log;
        public ShopController(contextModel contextModel, ILogger log)
        {
            _contextModel = contextModel;
            _log = log;
        }
        [AllowAnonymous]
        [HttpGet("/api/shop")]
        public IActionResult listItems()
        {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);
            return Ok(_contextModel.shopList.ToList());
        }
        [HttpPost("/api/shop/buy/{id}")]
        public IActionResult buyItem(int id)
        {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);
            throw new NotImplementedException(); }
        [HttpGet("/api/shop/cart")]
        public IActionResult showCart() {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);

            throw new NotImplementedException(); }
        [HttpPost("/api/shop/add/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult addItem() {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);

            throw new NotImplementedException(); }
        [HttpPut("/api/shop/edit/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult editItem(int id) {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);

            throw new NotImplementedException(); }
        [HttpDelete("/api/shop/delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult deleteItem(int id) {
            _log.Information("Shop listed by: " + HttpContext.Request.Host);    
            throw new NotImplementedException(); }
    }
}
