using Microsoft.AspNetCore.Mvc;
using Restful_API.Models;
using Restful_API.Models.DTO.LocalUserDtos;
using Restful_API.Repository.IRepository;
using System.Net;

namespace Restful_API.Controllers
{
    [Route("api/LocalUserAuth")]
    [ApiController]
    public class LocalUserController : Controller
    {
        private readonly ILocalUserRepository _localUserRepository;
        protected APIResponse _response;
        public LocalUserController(ILocalUserRepository localUserRepository)
        {
            this._localUserRepository = localUserRepository;
            this._response = new();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginResponse = await _localUserRepository.Login(loginRequestDto);
            if (loginResponse.User == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
        {
            bool isUserUnique = _localUserRepository.IsUniqueUser(registrationRequestDto.UserName);
            if(!isUserUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            var user = await _localUserRepository.Register(registrationRequestDto);
            if(user ==null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while register");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = user;
            return Ok(_response);
        }

    }
}
