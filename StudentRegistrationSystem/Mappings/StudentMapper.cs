using AutoMapper;
using StudentRegistrationSystem.Models.Domain;
using StudentRegistrationSystem.Models.DTO;

namespace StudentRegistrationSystem.Mappings
{
    public class StudentMapper : Profile
    {
        public StudentMapper() 
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<AddStudentRequestDto, Student>().ReverseMap();
            CreateMap<UpdateStudentDto, Student>().ReverseMap();
        }
    }
}
