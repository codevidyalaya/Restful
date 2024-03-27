using Restful_API.Models.Entities.LocalUsers;

namespace Restful_API.Models.DTO.LocalUserDtos
{
    public class LoginResponseDto
    {
        public LocalUser LocalUser { get; set; }
        public UserDto User { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
