using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restful_API.Logging;
using Restful_API.Models.DTO.StudentDTOs;
using Restful_API.Models.Entities;
using Restful_API.Repository.IRepository;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(ILogging logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentListDto>>> GetStudent()
        {
            IEnumerable<Student> studentList = await _unitOfWork.Student.GetAllAsync();
            return Ok(_mapper.Map<List<StudentListDto>>(studentList));
        }

        [HttpGet("{id:int}",Name ="GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetStudent(int id)
        {
            if (id == 0)
            {
                _logger.Log("Get student error with id "+ id,"error");
                return BadRequest();
            }
            var studentDetails = await _unitOfWork.Student.GetFirstOrDefaultAsync(u => u.Id == id);

            if (studentDetails == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDetailsDTO>(studentDetails));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateStudentDto>> CreateStudent([FromBody] CreateStudentDto createStudentDto)
        {

            if (!ModelState.IsValid || createStudentDto == null)
            {
                return BadRequest(createStudentDto);
            }

            var student = _mapper.Map<Student>(createStudentDto);
            await _unitOfWork.Student.AddAsync(student);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetStudent", new { id = student.Id }, createStudentDto); 
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
            var student = _unitOfWork.Student.GetFirstOrDefaultAsync(u => u.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            _unitOfWork.Student.RemoveAsync(student.Result);
            return NoContent();
        }

        //[HttpPut()]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdateStudent([FromBody] CreateStudentDto createStudentDto)
        //{
        //    if(createStudentDto.Id ==0)
        //    {
        //        return BadRequest();
        //    }
        //    //var student = _db.Student.FirstOrDefault(u => u.Id == objStudentDto.StudentId);
        //    //if(student !=null)
        //    //    student.StudentName = objStudentDto.StudentName;
        //    var student = _mapper.Map<Student>(createStudentDto);
        //    await _unitOfWork.Student.AddAsync(student);
        //    await _unitOfWork.Save();

        //    return NoContent();
        //}

        //[HttpPatch()]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdateStudentPartial(int id, JsonPatchDocument<StudentDto> patchDto)
        //{
        //    if(id==0 || patchDto == null)
        //    {
        //        return BadRequest();
        //    }
        //    var student = _unitOfWork.Student.GetFirstOrDefaultAsync(u => u.Id == id);
        //    StudentDto studentdto = new()
        //    {
        //        StudentId = student.Id,
        //        FullName = student.
        //    };

        //    if (student == null)
        //    {
        //        return BadRequest();
        //    }

        //    patchDto.ApplyTo(studentdto, ModelState);
        //    Student model = new()
        //    {
        //        Id = studentdto.StudentId,
        //        FullName = studentdto.FullName
        //    };

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _unitOfWork.Student.Update(student);
        //    _unitOfWork.Save();

        //    return NoContent();
        //}

    }
}
