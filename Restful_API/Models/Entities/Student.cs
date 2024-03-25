using Restful_API.Models.Entities.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restful_API.Models.Entities
{
    public class Student : BaseEntity
    {
        public string AdmissionNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string StudentCode { get; set; }
        public int Status { get; set; }
        [ForeignKey("ClassId")]
        public int AdmissionInClass { get; set; }
        [ForeignKey("SectionId")]
        public int AdmissionInSection { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("ClassId")]
        public int CurrentClass { get; set; }
        [ForeignKey("SectionId")]
        public int CurrentSection { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string BloodGroup { get; set; }
        public int Gender { get; set; }
        public string AadharNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ReligionId { get; set; }
        public int CategoryId { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string ProfileImage { get; set; }

       
    }
}
