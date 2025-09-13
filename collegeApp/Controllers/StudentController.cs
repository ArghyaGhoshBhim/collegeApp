using AutoMapper;
using collegeApp.Data;
using collegeApp.Data.Repository;
using collegeApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace collegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "LocalSchemes", Roles = "Superadmin, Admin")]
    public class StudentController : Controller
    {

        private readonly ILogger<StudentController> _logger;
        private readonly CollegeNewDBContext _dbContext;
        private readonly IMapper _mapper;
        //private readonly IStudentRepository _studentRepository;
        private readonly IStudentRepository _studentRepository;
        private APIResponse _response;

        public  StudentController(ILogger<StudentController>logger, CollegeNewDBContext dBContext, IMapper mapper,IStudentRepository studentRepository)
        {
            _logger=logger;
            _dbContext=dBContext;
            _mapper=mapper;
            _studentRepository=studentRepository;
            _response=new APIResponse();
        }


        [HttpGet]
        [Route("All", Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse>> GetStudents()
        {
            try
            {
                _logger.LogInformation("GetStudents method started");
                var students = await _studentRepository.GetALL();
                var studentDto = _mapper
                    .Map<List<StudentDTO>>(students);
                _response.Data = studentDto;
                _response.Status = true;
                _response.StatusCode=HttpStatusCode.OK;

                return _response;
            }catch (Exception ex)
            {
                _response.Status = false;
                _response.Errors.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return _response;
            }
            
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStudentById(int id)
        {
            try
            {
                if (id < 0)
                {
                    _logger.LogError("Bad request");
                    return BadRequest();
                }
                var student = await _studentRepository.GetById(student => student.Id == id);
                if (student == null)
                {
                    _logger.LogError("Student not found with this id");
                    return NotFound();
                }
                var studentDTO = _mapper.Map<StudentDTO>(student);
                _response.Data=studentDTO;
                _response.Status = true;
                _response.StatusCode=HttpStatusCode.OK;

                return _response;
            }catch (Exception ex)
            {
                _response.Status = false;
                _response.Errors.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;

                return _response;
            }
        }

        [HttpGet("{name:alpha}", Name = "GeStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GeStudentByName(string name)
        {
            try
            {
                var student = await _studentRepository.GetByName(student => student.StudentName.ToLower().Contains(name.ToLower()));
                if (student == null)
                {
                    return NotFound();
                }
                var studentDTO = _mapper.Map<StudentDTO>(student);

                _response.Data= studentDTO;
                _response.Status = true;
                _response.StatusCode = HttpStatusCode.OK;

                return _response;
            }catch (Exception ex)
            {
                _response.Status = false;
                _response.Errors.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;

                return _response;
            }
        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteStudentById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest();
                }
                var student = await _studentRepository.GetById(student => student.Id == id);
                var isDeleted = await _studentRepository.Delete(student);
                _response.Data= isDeleted;
                _response.Status = true;
                _response.StatusCode = HttpStatusCode.OK;

                return _response;

            }catch (Exception ex)
            {
                _response.Status = false;
                _response.Errors.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;

                return _response;
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> CreateStudentAsync([FromBody] StudentDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var student = _mapper.Map<Student>(model);
                model.Id = student.Id;
                var StudentCreatedId = await _studentRepository.Create(student);
                _response.Data = CreatedAtRoute("GetStudentById", new { Id = StudentCreatedId.Id }, model);
                _response.Status = true;
                _response.StatusCode = HttpStatusCode.OK;

                return _response;
            }catch(Exception ex)
            {
                _response.Status = false;
                _response.Errors.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;

                return _response;
            }
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

            var existingStudent =await _studentRepository.GetById(studen=>studen.Id==model.Id, true);
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
            var existingStudent = await _studentRepository.GetById(studen => studen.Id ==id, true);
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
