using Graveyard.Models;
using Graveyard_Backend.Controllers;
using Graveyard_Backend.Models;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;
namespace BackendTest
{
    public class UnitTest1
    {
        private readonly testContext _testContext;
        private readonly ILogger _logger;
        private readonly JwtAuth _jwtAuth;
        private readonly HttpClient _httpClient;
        [Fact]
        public void Test1()
        {
            //setup
            AccountController accountController = new AccountController(_testContext,_logger,_httpClient, _jwtAuth);

            Assert.
        }
    }
}