namespace StudentRegistrationSystem.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public decimal AverageGrade { get; set; }
    }
}
