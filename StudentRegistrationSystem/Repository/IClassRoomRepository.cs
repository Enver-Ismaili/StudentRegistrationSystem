using StudentRegistrationSystem.Models.Domain;

namespace StudentRegistrationSystem.Repository
{
    public interface IClassRoomRepository
    {
        Task<List<ClassRoom>> GetAllClassRoomAsync();
        Task<ClassRoom> GetClassRoomByIdAsync(int id);
        Task<ClassRoom> CreateClassRoomAsync(ClassRoom student);
        Task<ClassRoom> UpdateClassRoomAsync(int id, ClassRoom student);
        Task<ClassRoom> DeleteClassRoomAsync(int id);
    }
}
