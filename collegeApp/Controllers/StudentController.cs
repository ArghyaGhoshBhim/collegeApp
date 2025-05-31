using collegeApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        
        [HttpGet]
        [Route("All", Name = "GetStudents")]
       public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            return Ok(CollegeRepository.Students.Where(student=>id==student.Id).FirstOrDefault());
        }

        [HttpGet("{name:alpha}", Name = "GeStudentByName")]
        public ActionResult<Student> GeStudentByName(string name)
        {
            return Ok(CollegeRepository.Students.Where(student => name == student.StudentName).FirstOrDefault());
        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]
        public ActionResult<bool> DeleteStudentById(int id)
        {
            if (id<0)
            {
                return BadRequest();
            }
            var student=CollegeRepository.Students.FirstOrDefault(s => s.Id == id); ;
            if (student == null)
            {
                return NotFound();
            }
            CollegeRepository.Students.Remove(student);
            return Ok(true);
        }


    }
}
