using collegeApp.MyLogger;
using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        private readonly ILogger<DemoController> _logger;
        public DemoController(ILogger<DemoController> myLogger)
        {
            //_logger = new LogToFile();
            //_logger = new LogToServerMemory();
            //_logger = new LogToDB();
            _logger = myLogger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _logger.LogTrace("Log message from trace");
            _logger.LogDebug("Log message from trace"); 
            _logger.LogInformation("Log message from trace");
            _logger.LogWarning("Log message from trace");
            _logger.LogError("Log message from trace");
            _logger.LogCritical("Log message from trace");
            return Ok();
        }
    }
}
