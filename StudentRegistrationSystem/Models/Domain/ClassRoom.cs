namespace StudentRegistrationSystem.Models.Domain
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Capacity{ get; set; }
        public string TeacherName { get; set; }


        public ICollection<Student> Students{ get; set; }
    }
}
