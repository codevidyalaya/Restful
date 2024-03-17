using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Restful_API.Data;
using Restful_API.Logging;
using Restful_API.Models.DTO;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogging _logger;
        public StudentController(ILogging logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<StudentDto>> GetStudent()
        {
            _logger.Log("Fetch all student record");
            return Ok(StudentData.studentList) ;
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

            if (StudentData.studentList.FirstOrDefault(u => u.StudentId == id) == null)
            {
                return NotFound();
            }

            return Ok(StudentData.studentList.FirstOrDefault(u => u.StudentId == id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDto> CreateStudent([FromBody]StudentDto studentDto)
        {

            if(StudentData.studentList.FirstOrDefault(u => u.StudentName.ToLower() == studentDto.StudentName.ToLower()) !=null)
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

            studentDto.StudentId = StudentData.studentList.OrderByDescending(u => u.StudentId).FirstOrDefault().StudentId +1;
            StudentData.studentList.Add(studentDto);

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
            var student = StudentData.studentList.FirstOrDefault(u => u.StudentId == id);
            if(student == null)
            {
                return NotFound();
            }
            StudentData.studentList.Remove(student);
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
            var student = StudentData.studentList.FirstOrDefault(u => u.StudentId == objStudentDto.StudentId);
            if(student !=null)
                student.StudentName = objStudentDto.StudentName;

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
            var student = StudentData.studentList.FirstOrDefault(u => u.StudentId == id);
            if(student == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(student, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

    }
}
