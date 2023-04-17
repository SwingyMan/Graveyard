using Graveyard_Backend.Models;
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
        [HttpGet("/api/grave/list")]
        public IActionResult listGraves()
        {
            _log.Information("Listed grave for: " + HttpContext.Request.Host);
            var list = _contextModel.grave.ToList();
            return Ok(list);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost("/api/grave/add")]
        public IActionResult addGrave([FromBody]GraveDTO graveDto)
        {
            _log.Information("Grave added by: " + HttpContext.Request.Host);
            Burried burried = new Burried(graveDto.name, graveDto.lastname, graveDto.date_of_birth,
                graveDto.date_of_death);
            Grave grave = new Grave(graveDto.x, graveDto.y, graveDto.status,burried, graveDto.valid_until);
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
        public IActionResult editGrave(int id, [FromBody] GraveDTO graveDto)
        {
            _log.Information("Grave edited by: " + HttpContext.Request.Host);
            var _grave = _contextModel.grave.FirstOrDefault(x => x.GraveID ==id);
            _grave.x = graveDto.x;
            _grave.y = graveDto.y;
            _grave.status = graveDto.status;
            _grave.validUntil = graveDto.valid_until;
            Burried burried = new Burried(graveDto.name, graveDto.lastname, graveDto.date_of_birth,
                graveDto.date_of_death);
            _grave.burried = burried;
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
        [HttpGet("/api/grave/buy/{id}")]
        public IActionResult extendGrave(int id)
        {
            var grave = _contextModel.grave.FirstOrDefault(x=> x.GraveID ==  id);
            grave.validUntil.AddYears(5);
            _contextModel.SaveChanges();
            _log.Information("Extended grave " + grave.GraveID + " by ip: " + HttpContext.Request.Host);
            return Ok(grave);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost("/api/burried/tobeburried/add")]
        public IActionResult addToBeBurried()
        {
            throw new NotImplementedException();
        }
        [AllowAnonymous]
        [HttpGet("/api/burried/tobeburried/list")]
        public IActionResult listToBeBurried()
        {
            throw new NotImplementedException();
        }
        [HttpPatch("/api/burried/tobeburried/edit")]
        public IActionResult editToBeBurried()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("/api/burried/tobeburried/delete")]
        public IActionResult deleteToBeBurried()
        {
            throw new NotImplementedException();
        }
    }
}
