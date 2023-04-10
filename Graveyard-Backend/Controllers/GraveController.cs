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
        [HttpGet("/api/grave/get/{id}")]
        public IActionResult getGrave(int id)
        {
            _log.Information("Grave accesed by: " + HttpContext.Request.Host);
            var x = _contextModel.grave.FirstOrDefault(y => y.GraveID == id);
            return Ok(x);
        }
    }
}
