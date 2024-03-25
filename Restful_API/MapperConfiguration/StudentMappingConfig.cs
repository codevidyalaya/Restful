using AutoMapper;
using Restful_API.Models.DTO;
using Restful_API.Models.Entities;

namespace Restful_API.MapperConfiguration
{
    public class StudentMappingConfig:Profile
    {
        public StudentMappingConfig()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
