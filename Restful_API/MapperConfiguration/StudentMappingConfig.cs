using AutoMapper;
using Restful_API.Models.DTO.StudentDTOs;
using Restful_API.Models.Entities;

namespace Restful_API.MapperConfiguration
{
    public class StudentMappingConfig:Profile
    {
        public StudentMappingConfig()
        {
            CreateMap<Student, StudentListDto>().ReverseMap();
            CreateMap<Student, StudentDetailsDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
        }
    }
    
}
