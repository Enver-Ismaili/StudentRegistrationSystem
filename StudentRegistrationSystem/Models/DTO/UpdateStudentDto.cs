using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models.DTO
{
    public class UpdateStudentDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage ="Your input is invalid")]
        public decimal AverageGrade { get; set; }
    }
}
