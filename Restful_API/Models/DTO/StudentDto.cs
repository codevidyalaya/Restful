using Restful_API.Models.Entities.Master;
using System.ComponentModel.DataAnnotations;

namespace Restful_API.Models.DTO
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }


        //Navigation Properties
        //public Category Categories { get; set; }
        //public Religion Religions { get; set; }
        //public Class Classes { get; set; }
        //public Section Sections { get; set; }
        //public Gender Genders { get; set; }
        //public StudyStatus StudyStatus { get; set; }
    }
}
