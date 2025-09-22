using StudentRegistrationSystem.Models.Domain;

namespace StudentRegistrationSystem.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<Student> DeleteStudentAsync(int id);
        Task<bool> AssignStudentToClassRoomAsync(int studentId, int classRoomId);
    }
}
