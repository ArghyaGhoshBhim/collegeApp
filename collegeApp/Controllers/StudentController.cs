using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/studentController")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet]
       public string GetStudent()
        {
            return "student name 1";
        }
    }
}
