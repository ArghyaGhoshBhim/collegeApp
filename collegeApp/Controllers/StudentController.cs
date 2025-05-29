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
       public IEnumerable<Student> GetStudents()
        {
            return CollegeRepository.Students;
        }

        [HttpGet]
        [Route("{id}", Name = "GetStudentById")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.Students.Where(student=>id==student.Id).FirstOrDefault();
        }

        [HttpGet("{name}", Name = "GeStudentByName")]
        public Student GeStudentByName(string name)
        {
            return CollegeRepository.Students.Where(student => name == student.StudentName).FirstOrDefault();
        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]
        public bool DeleteStudentById(int id)
        {
            var student=CollegeRepository.Students.FirstOrDefault(s => s.Id == id); ;
            CollegeRepository.Students.Remove(student);
            return true;
        }


    }
}
