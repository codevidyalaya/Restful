using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        public StudentController(ILogging logger,ApplicationDbContext db)
        {
            _logger = logger;
            this._db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<StudentDto>> GetStudent()
        {
            _logger.Log("Fetch all student record");
            return Ok(_db.Student.ToList()) ;
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

            if(_db.Student.FirstOrDefault(u => u.StudentName.ToLower() == studentDto.StudentName.ToLower()) !=null)
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
                StudentName = studentDto.StudentName
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
                StudentName = objStudentDto.StudentName
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
                StudentName = student.StudentName
            };

            if (student == null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(studentdto, ModelState);
            Student model = new()
            {
                Id = studentdto.StudentId,
                StudentName = studentdto.StudentName
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
