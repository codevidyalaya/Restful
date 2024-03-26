using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Restful_API.Logging;
using Restful_API.Models;
using Restful_API.Models.DTO.StudentDTOs;
using Restful_API.Models.Entities;
using Restful_API.Repository.IRepository;
using System.Net;
using System.Text.Json;

namespace Restful_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(ILogging logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Default10")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetStudent([FromQuery(Name ="filterStudyStatus")]int? studyStatus, int pageSize = 0, int pageNumer = 1)
        {
            try
            {
                IEnumerable<Student> studentList;
                if (studyStatus > 0)
                {
                    studentList = await _unitOfWork.Student.GetAllAsync(u=>u.StudyStatusId==studyStatus,null,pageSize,pageNumer);
                }
                else
                {
                    studentList = await _unitOfWork.Student.GetAllAsync(null,pageSize,pageNumer);
                }
                Pagination pagination = new() { PageNumber = pageNumer, PageSize = pageSize };
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<List<StudentListDto>>(studentList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [Authorize]
        [HttpGet("{id:int}", Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get student error with id " + id, "error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var studentDetails = await _unitOfWork.Student.GetFirstOrDefaultAsync(u => u.Id == id, "StudyStatus");

                if (studentDetails == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<StudentDetailsDTO>(studentDetails);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> CreateStudent([FromBody] CreateStudentDto createStudentDto)
        {
            try
            {
                if (!ModelState.IsValid || createStudentDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var student = _mapper.Map<Student>(createStudentDto);
                await _unitOfWork.Student.AddAsync(student);
                await _unitOfWork.Save();

                _response.Result = _mapper.Map<StudentDetailsDTO>(student);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetStudent", new { id = student.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> DeleteStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var student = await _unitOfWork.Student.GetFirstOrDefaultAsync(u => u.Id == id);
                if (student == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _unitOfWork.Student.RemoveAsync(student);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateStudent([FromBody] UpdateStudentDto updateStudentDto)
        {
            try
            {
                if (updateStudentDto.Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var student = _mapper.Map<Student>(updateStudentDto);

                await _unitOfWork.Student.Update(student);
                await _unitOfWork.Save();

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdateStudentPartial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateStudentPartial(int id, JsonPatchDocument<UpdateStudentDto> patchDto)
        {
            try
            {
                if (id == 0 || patchDto == null)
                {
                    return BadRequest();
                }
                var findRecord = await _unitOfWork.Student.GetFirstOrDefaultAsync(u => u.Id == id);
                UpdateStudentDto updateStudentDto = _mapper.Map<UpdateStudentDto>(findRecord);
                if (findRecord == null)
                {
                    return BadRequest();
                }
                patchDto.ApplyTo(updateStudentDto, ModelState);

                Student student = _mapper.Map<Student>(updateStudentDto);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _unitOfWork.Student.Update(student);
                await _unitOfWork.Save();

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
