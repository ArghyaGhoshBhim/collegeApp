using collegeApp.Data;
using collegeApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private readonly ILogger<StudentController> _logger;
        private readonly CollegeNewDBContext _dbContext;

        public  StudentController(ILogger<StudentController>logger, CollegeNewDBContext dBContext)
        {
            _logger=logger;
            _dbContext=dBContext;
        }


        [HttpGet]
        [Route("All", Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            _logger.LogInformation("GetStudents method started");
            var students = _dbContext.students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Email = s.Email,
                Address = s.Address,
            }).ToList();
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
                _logger.LogError("Bad request");
                return BadRequest();
            }
            var student = _dbContext.students.Where(student => id == student.Id).FirstOrDefault();
            if (student == null)
            {
                _logger.LogError("Student not found with this id");
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
            var student = _dbContext.students.Where(student => name == student.StudentName).FirstOrDefault();
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
            var student = _dbContext.students.FirstOrDefault(s => s.Id == id); ;
            if (student == null)
            {
                return NotFound();
            }
            _dbContext.students.Remove(student);
            _dbContext.SaveChanges();
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
            var student = new Student()
            {
                StudentName = model.StudentName,
                Email = model.Email,
                Address = model.Address,
            };
            model.Id = student.Id;
            _dbContext.students.Add(student);
            _dbContext.SaveChanges();
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

            var existingStudent = _dbContext.students.AsNoTracking().Where(s => s.Id == model.Id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }

            var newRecord = new Student()
            {
                Id = existingStudent.Id,
                StudentName = existingStudent.StudentName,
                Address = existingStudent.Address,
            };
            _dbContext.students.Update(newRecord);
            /*existingStudent.StudentName = model.StudentName;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;*/
            _dbContext.SaveChanges();

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

            var existingStudent = _dbContext.students.Where(s => s.Id == id).FirstOrDefault();
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
            _dbContext.SaveChanges();

            return NoContent();

        }


    }
}
