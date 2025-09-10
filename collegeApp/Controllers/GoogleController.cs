using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "GoogleSchemes", Roles = "Superadmin, Admin")]
    public class GoogleController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetResult()
        {
            return Ok( new { message = "Hi I am from Google" });
        }
    }
}
