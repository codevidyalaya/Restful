using Microsoft.IdentityModel.Tokens;
using Restful_API.Data;
using Restful_API.Models.DTO.LocalUserDtos;
using Restful_API.Models.Entities.LocalUsers;
using Restful_API.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restful_API.Repository
{
    public class LocalUserRepository : ILocalUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;

        public LocalUserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            this._db = db;
            this.secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string userName)
        {
            var user = _db.LocalUser.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.LocalUser.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower() &&
            u.Password == loginRequestDto.Password);

            if (user == null)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }

            //JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.LocalUserRoleId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDto;
        }

        public async Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registrationRequestDto.UserName,
                Password = registrationRequestDto.Password,
                Name = registrationRequestDto.Name,
                LocalUserRoleId = registrationRequestDto.LocalUserRoleId
            };
            _db.LocalUser.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
