using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Database;
using StudentRegistrationSystem.Models.Domain;

namespace StudentRegistrationSystem.Repository
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly StudentDbContext dbContext;

        public SQLStudentRepository(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            //return await dbContext.Students.Where(x => x.AverageGrade >= 9).ToListAsync();
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.Name = student.Name;
            existingStudent.LastName = student.LastName;
            existingStudent.AverageGrade = student.AverageGrade;

            await dbContext.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent == null)
            {
                return null;
            }

            dbContext.Students.Remove(existingStudent);
            await dbContext.SaveChangesAsync();
            return existingStudent;
        }
    }
}
