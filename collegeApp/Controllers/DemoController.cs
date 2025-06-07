using collegeApp.MyLogger;
using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        private readonly IMyLogger _logger;
        public DemoController(IMyLogger myLogger)
        {
            //_logger = new LogToFile();
            //_logger = new LogToServerMemory();
            //_logger = new LogToDB();
            _logger = myLogger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _logger.Log("Index Method started");
            return Ok();
        }
    }
}
