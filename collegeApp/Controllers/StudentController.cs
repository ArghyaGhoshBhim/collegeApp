using collegeApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/studentController")]
    [ApiController]
    public class StudentController : Controller
    {
        
        [HttpGet]
       public IEnumerable<Student> GetStudents()
        {
            return CollegeRepository.Students;
        }

        [HttpGet("{id:int}")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.Students.Where(student=>id==student.Id).FirstOrDefault();
        }


    }
}
