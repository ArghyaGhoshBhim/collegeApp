using collegeApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        [HttpGet]
        [Route("All", Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = CollegeRepository.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Email = s.Email,
                Address = s.Address,
            });
            return Ok(students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var student = CollegeRepository.Students.Where(student => id == student.Id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
            };
            return Ok(studentDTO);
        }

        [HttpGet("{name:alpha}", Name = "GeStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDTO> GeStudentByName(string name)
        {
            var student = CollegeRepository.Students.Where(student => name == student.StudentName).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
            };

            return Ok(studentDTO);
        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteStudentById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var student = CollegeRepository.Students.FirstOrDefault(s => s.Id == id); ;
            if (student == null)
            {
                return NotFound();
            }
            CollegeRepository.Students.Remove(student);
            return Ok(true);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.Id = CollegeRepository.Students.LastOrDefault().Id + 1;
            var student = new Student()
            {
                Id = model.Id,
                StudentName = model.StudentName,
                Email = model.Email,
                Address = model.Address,
            };

            CollegeRepository.Students.Add(student);
            return CreatedAtRoute("GetStudentById", new { Id = student.Id }, model);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateStudent([FromBody] StudentDTO model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }

            var existingStudent = CollegeRepository.Students.Where(s => s.Id == model.Id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.StudentName = model.StudentName;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;

            return NoContent();

        }

        [HttpPatch]
        [Route("{id}/updatePartially")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateStudentPartially(int id,[FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }

            var existingStudent = CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }

            var studentDto=new StudentDTO()
            {
                Id = id,
                StudentName=existingStudent.StudentName,
                Email=existingStudent.Email,
                Address=existingStudent.Address,
            };

            patchDocument.ApplyTo(studentDto, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            existingStudent.StudentName = studentDto.StudentName;
            existingStudent.Email = studentDto.Email;
            existingStudent.Address = studentDto.Address;

            return NoContent();

        }


    }
}
