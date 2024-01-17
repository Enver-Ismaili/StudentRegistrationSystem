using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models.DTO
{
    public class AddStudentRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Your input is invalid")]
        public decimal? AverageGrade { get; set; }
    }
}
