namespace Restful_API.Models.DTO.LocalUserDtos
{
    public class RegistrationRequestDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int LocalUserRoleId { get; set; }
    }
}
