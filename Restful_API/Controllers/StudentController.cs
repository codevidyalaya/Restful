using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.Logging;
using Restful_API.Models.DTO;
using Restful_API.Models.Entities;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public StudentController(ILogging logger,ApplicationDbContext db,IMapper mapper)
        {
            _logger = logger;
            this._db = db;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudent()
        {
            IEnumerable<Student> studentList = await _db.Student.ToListAsync();
            return Ok(_mapper.Map<List<StudentDto>>(studentList));

            //_logger.Log("Fetch all student record");
            //return Ok(_db.Student.ToList()) ;
        }

        [HttpGet("{id:int}",Name ="GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetStudent(int id)
        {
            if (id == 0)
            {
                _logger.Log("Get student error with id "+ id,"error");
                return BadRequest();
            }

            if (_db.Student.FirstOrDefault(u => u.Id == id) == null)
            {
                return NotFound();
            }

            return Ok(_db.Student.FirstOrDefault(u => u.Id == id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDto> CreateStudent([FromBody]StudentDto studentDto)
        {

            if(_db.Student.FirstOrDefault(u => u.FullName.ToLower() == studentDto.FullName.ToLower()) !=null)
            {
                ModelState.AddModelError("CustomeErrorMessage", "Student already exists!");
                return BadRequest(ModelState);
            }
         
            if(!ModelState.IsValid)
            {
                return BadRequest(studentDto);
            }

            if(studentDto == null)
            {
                return BadRequest(studentDto);
            }

            if(studentDto.StudentId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            // studentDto.StudentId = StudentData.studentList.OrderByDescending(u => u.StudentId).FirstOrDefault().StudentId + 1;

            Student student = new()
            {
                Id =studentDto.StudentId,  
                FullName = studentDto.FullName
            };
            _db.Student.Add(student);
            _db.SaveChanges();

            return CreatedAtRoute("GetStudent", new { id = studentDto.StudentId }, studentDto); //Ok(studentDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteStudent(int id)
        {
            if(id ==0)
            {
                return BadRequest();
            }
            var student = _db.Student.FirstOrDefault(u => u.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            _db.Student.Remove(student);
            return NoContent();
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateStudent([FromBody]StudentDto objStudentDto)
        {
            if(objStudentDto.StudentId ==0)
            {
                return BadRequest();
            }
            //var student = _db.Student.FirstOrDefault(u => u.Id == objStudentDto.StudentId);
            //if(student !=null)
            //    student.StudentName = objStudentDto.StudentName;
            Student student = new()
            {
                Id = objStudentDto.StudentId,
                FullName = objStudentDto.FullName
            };
            _db.Student.Update(student);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateStudentPartial(int id, JsonPatchDocument<StudentDto> patchDto)
        {
            if(id==0 || patchDto == null)
            {
                return BadRequest();
            }
            var student = _db.Student.FirstOrDefault(u => u.Id == id);
            StudentDto studentdto = new()
            {
                StudentId = student.Id,
                FullName = student.FullName
            };

            if (student == null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(studentdto, ModelState);
            Student model = new()
            {
                Id = studentdto.StudentId,
                FullName = studentdto.FullName
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Student.Update(student);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
