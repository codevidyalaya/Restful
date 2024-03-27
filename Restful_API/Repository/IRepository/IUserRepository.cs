using Restful_API.Models.DTO.LocalUserDtos;
using Restful_API.Models.Entities.LocalUsers;

namespace Restful_API.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
        bool IsUniqueUser(string userName);
    }
}
