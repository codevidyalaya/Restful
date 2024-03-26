using Restful_API.Models.DTO.LocalUserDtos;
using Restful_API.Models.Entities.LocalUsers;

namespace Restful_API.Repository.IRepository
{
    public interface ILocalUserRepository
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto);
        bool IsUniqueUser(string userName);
    }
}
