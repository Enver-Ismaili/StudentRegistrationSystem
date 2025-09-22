using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Database;
using StudentRegistrationSystem.Models.Domain;

namespace StudentRegistrationSystem.Repository
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly StudentDbContext _context;

        public ClassRoomRepository(StudentDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task<List<ClassRoom>> GetAllClassRoomAsync()
        {
            return await _context.ClassRooms.ToListAsync();

        }

        public async Task<ClassRoom> GetClassRoomByIdAsync(int id)
        {
            return await _context.ClassRooms.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<ClassRoom> CreateClassRoomAsync(ClassRoom classRoom)
        {
            await _context.ClassRooms.AddAsync(classRoom);
            await _context.SaveChangesAsync();
            return classRoom;

        }
        public async Task<ClassRoom> UpdateClassRoomAsync(int id, ClassRoom classRoom)
        {
            var existingClassRoom = await _context.ClassRooms.FirstOrDefaultAsync(x => x.Id == id);

            if (existingClassRoom == null)
            {
                return null;
            }

            existingClassRoom.Name = classRoom.Name;
            existingClassRoom.Capacity = classRoom.Capacity;
            existingClassRoom.TeacherName = classRoom.TeacherName;

            await _context.SaveChangesAsync();
            return existingClassRoom;

        }
        public async Task<ClassRoom> DeleteClassRoomAsync(int id)
        {
            var existingClassRoom = await _context.ClassRooms.FirstOrDefaultAsync(x => x.Id == id);
            if (existingClassRoom == null)
            {
                return null;
            }

            _context.ClassRooms.Remove(existingClassRoom);
            await _context.SaveChangesAsync();
            return existingClassRoom;

        }
    }
}
