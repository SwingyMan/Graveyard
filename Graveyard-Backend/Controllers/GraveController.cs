using Graveyard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ILogger = Serilog.ILogger;
namespace Graveyard_Backend.Controllers
{
    [Authorize (Roles = "Administrator")]
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
            throw new NotImplementedException();
        }
        [HttpPost("/api/grave/add")]
        public IActionResult addGrave()
        {
            throw new NotImplementedException();
        }
        [HttpDelete("/api/grave/delete/{id}")]
        public IActionResult deleteGrave()
        {
            throw new NotImplementedException();
        }
        [HttpPut("/api/grave/edit/{id}")]
        public IActionResult editGrave()
        { 
            throw new NotImplementedException(); 
        }
        [Authorize(Roles = "Administrator,User")]
        [HttpGet("/api/grave/get/{id}")]
        public IActionResult getGrave() {
            throw new NotImplementedException();
        }
    }
}
