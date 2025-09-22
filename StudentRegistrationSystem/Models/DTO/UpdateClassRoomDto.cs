using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models.DTO
{
    public class UpdateClassRoomDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string TeacherName { get; set; }
    }
}
