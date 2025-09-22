using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models.Domain;

namespace StudentRegistrationSystem.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);

                entity.Property(e => e.AverageGrade).HasColumnType("decimal(18,2)").IsRequired();
            });
            modelBuilder.Entity<Student>()
            .HasOne(s => s.ClassRoom)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassRoomId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ClassRoom>(entity =>
            {
                // 👇 If your DB has "ClassRoom" (singular)
                entity.ToTable("ClassRoom");

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd()
                      .IsRequired();

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Capacity);

                entity.Property(e => e.TeacherName)
                      .HasMaxLength(100);
            });
        }
    }
}
