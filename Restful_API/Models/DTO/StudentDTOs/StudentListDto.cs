﻿using Restful_API.Models.Entities.Master;
using System.ComponentModel.DataAnnotations;

namespace Restful_API.Models.DTO.StudentDTOs
{
    public class StudentListDto
    {
        public string Id { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
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

        public int StudyStatusId { get; set; }
        public int AdmissionInClassId { get; set; }
        public int AdmissionInSectionId { get; set; }
        public int CurrentClassId { get; set; }
        public int CurrentSectionId { get; set; }
    }
}
