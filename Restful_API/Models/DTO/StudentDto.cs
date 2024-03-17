using System.ComponentModel.DataAnnotations;

namespace Restful_API.Models.DTO
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Student name is required ")]
        [MaxLength(100)]
        public string StudentName { get; set; }

    }
}
