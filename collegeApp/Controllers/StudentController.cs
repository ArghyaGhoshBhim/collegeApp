using collegeApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/studentController")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet]
       public IEnumerable<Student> GetStudent()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    StudentName = "TestName1",
                    Email="TestName1@gmail.com",
                    Address="Test Address1",
                },
                new Student()
                {
                    Id = 2,
                    StudentName = "TestName2",
                    Email="TestName2@gmail.com",
                    Address="Test Address2",
                }
            };
        }
    }
}
