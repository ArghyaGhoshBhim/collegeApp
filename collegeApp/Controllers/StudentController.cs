using AutoMapper;
using collegeApp.Data;
using collegeApp.Data.Repository;
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
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public  StudentController(ILogger<StudentController>logger, CollegeNewDBContext dBContext, IMapper mapper, IStudentRepository studentRepository)
        {
            _logger=logger;
            _dbContext=dBContext;
            _mapper=mapper;
            _studentRepository=studentRepository;
        }


        [HttpGet]
        [Route("All", Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            _logger.LogInformation("GetStudents method started");
            var students = await _studentRepository.GetALL();
            var studentDto=_mapper
                .Map<List<StudentDTO>>(students);
            return Ok(studentDto);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Bad request");
                return BadRequest();
            }
            var student = await _studentRepository.GetById(id);
            if (student == null)
            {
                _logger.LogError("Student not found with this id");
                return NotFound();
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        [HttpGet("{name:alpha}", Name = "GeStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GeStudentByName(string name)
        {
            var student = await _studentRepository.GetByName(name);
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);

            return Ok(studentDTO);
        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteStudentById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var isDeleted = await _studentRepository.Delete(id);
          
            return Ok(isDeleted);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<StudentDTO>> CreateStudentAsync([FromBody] StudentDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var student = _mapper.Map<Student>(model);
            model.Id = student.Id;
            var createdId=await _studentRepository.Create(student);
            return CreatedAtRoute("GetStudentById", new { Id = createdId }, model);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }

            var existingStudent =await _studentRepository.GetById(model.Id, true);
            if (existingStudent == null)
            {
                return NotFound();
            }

            var newRecord = new Student()
            {
                Id = model.Id,
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email,
                DOB = model.DOB,
            };
            await _studentRepository.Update(newRecord);
            /*existingStudent.StudentName = model.StudentName;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;*/
           // _dbContext.SaveChanges();

            return NoContent();

        }

        [HttpPatch]
        [Route("{id}/updatePartially")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateStudentPartially(int id,[FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }

            //var existingStudent = _dbContext.students.AsNoTracking().Where(s => s.Id == id).FirstOrDefault();
            var existingStudent = await _studentRepository.GetById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            var studentDto=_mapper.Map<StudentDTO>(existingStudent);

            patchDocument.ApplyTo(studentDto, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            existingStudent=_mapper.Map<Student>(studentDto);
            /*existingStudent.StudentName = studentDto.StudentName;
            existingStudent.Email = studentDto.Email;
            existingStudent.Address = studentDto.Address;*/

            await _studentRepository.Update(existingStudent);

            return NoContent();

        }


    }
}
