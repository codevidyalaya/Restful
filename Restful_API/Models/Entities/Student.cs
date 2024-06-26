﻿using Restful_API.Models.Entities.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restful_API.Models.Entities
{
    public class Student : BaseEntity
    {
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

        [ForeignKey("StudyStatusId")]
        public int StudyStatusId { get; set; }
        public StudyStatus StudyStatus { get; set; }


        [ForeignKey("AdmissionInClassId")]
        public int AdmissionInClassId { get; set; }
        public Class AdmissionInClass { get; set; }


        [ForeignKey("AdmissionInSectionId")]
        public int AdmissionInSectionId { get; set; }
        public Section AdmissionInSection { get; set; }


        [ForeignKey("CurrentClassId")]
        public int CurrentClassId { get; set; }
        public Class CurrentClass { get; set; }


        [ForeignKey("CurrentSectionId")]
        public int CurrentSectionId { get; set; }
        public Section CurrentSection { get; set; }

        public Religion Religion { get; set; }
        public Category Category { get; set; }
    }
}
