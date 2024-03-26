using Restful_API.Models.Entities.LocalUsers;

namespace Restful_API.Models.DTO.LocalUserDtos
{
    public class LoginResponseDto
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
