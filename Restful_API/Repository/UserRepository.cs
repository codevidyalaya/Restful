using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Restful_API.Data;
using Restful_API.Models;
using Restful_API.Models.DTO.LocalUserDtos;
using Restful_API.Models.Entities.LocalUsers;
using Restful_API.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restful_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration,UserManager<ApplicationUser> userManager
            ,IMapper mapper,RoleManager<IdentityRole> roleManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
            this.secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string userName)
        {
            var user = _db.ApplicationUser.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            var isvalidUser = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || !isvalidUser)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }

            //JWT
            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,roles.FirstOrDefault()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDto>(user),
                Role= roles.FirstOrDefault()
            };
            return loginResponseDto;
        }

        public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDto.UserName,
                Email = registrationRequestDto.UserName,
                NormalizedEmail = registrationRequestDto.UserName.ToUpper(),
                Name = registrationRequestDto.Name
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if(result.Succeeded)
                {
                    if(!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("teacher"));
                    }
                    
                    await _userManager.AddToRoleAsync(user, "admin");
                    var userToReturn = _db.ApplicationUser.FirstOrDefault(u => u.UserName == registrationRequestDto.UserName);
                    return _mapper.Map<UserDto>(userToReturn);
                }
            }
            catch (Exception ex)
            {
                return new UserDto();
            }
            return new UserDto();
        }
    }
}
