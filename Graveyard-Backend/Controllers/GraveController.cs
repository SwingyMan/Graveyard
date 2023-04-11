using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class GraveController : ControllerBase
    {
        private readonly contextModel _contextModel;
        private readonly ILogger _log;
        public GraveController(contextModel contextModel, ILogger log)
        {
            _contextModel = contextModel;
            _log = log;
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet("/api/grave/list")]
        public IActionResult listGraves()
        {
            _log.Information("Listed grave for: " + HttpContext.Request.Host);
            var list = _contextModel.grave.ToList();
            return Ok(list);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost("/api/grave/add")]
        public IActionResult addGrave([FromBody]Grave grave)
        {
            _log.Information("Grave added by: " + HttpContext.Request.Host);
            _contextModel.grave.Add(grave);
            _contextModel.SaveChanges();
            return Ok(grave);
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete("/api/grave/delete/{id}")]
        public IActionResult deleteGrave(int id)
        {
            _log.Information("Grave deleted by: " + HttpContext.Request.Host);
            var x =_contextModel.grave.FirstOrDefault(x => x.GraveID ==id);
            _contextModel.grave.Remove(x);
            _contextModel.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut("/api/grave/edit/{id}")]
        public IActionResult editGrave(int id, [FromBody] Grave grave)
        {
            _log.Information("Grave edited by: " + HttpContext.Request.Host);
            var _grave = _contextModel.grave.FirstOrDefault(x => x.GraveID ==id);
            _grave.x = grave.x;
            _grave.y = grave.y;
            _grave.status = grave.status;
            _grave.validUntil = grave.validUntil;
            _grave.burried = grave.burried;
            _contextModel.SaveChanges();
            return Ok(_grave);
        }
        [Authorize (Roles="Administrator")]
        [HttpGet("/api/grave/get/{id}")]
        public IActionResult getGrave(int id)
        {
            _log.Information("Grave accesed by: " + HttpContext.Request.Host);
            var x = _contextModel.grave.FirstOrDefault(y => y.GraveID == id);
            return Ok(x);
        }

        [HttpGet("/api/grave/getowned")]
        public IActionResult getOwnedGrave()
        {
            int id = int.Parse(User.Claims.First(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var graves = _contextModel.graveOwner.FirstOrDefault(x => x.customer.CustomerID == id);
            _log.Information("Owned Grave accesed by: " + HttpContext.Request.Host);
            return Ok(graves.grave.ToList());
        }
        [HttpGet("/api/grave/buy/{id1}/{id2}")]
        public IActionResult buyGrave(int id1,int id2)
        {
            var customer = _contextModel.customer.FirstOrDefault(x=> x.CustomerID == id1);
            var grave = _contextModel.grave.FirstOrDefault(x=> x.GraveID ==  id2);
            GraveOwner ownedGrave = new GraveOwner(customer, grave);
            _contextModel.graveOwner.Add(ownedGrave);
            _contextModel.SaveChanges();
            _log.Information("New grave " + grave.GraveID +" owner "+customer.Email+ " from ip: " + HttpContext.Request.Host);
            return Ok(ownedGrave);
        }
    }
}
