using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSystem.Database;
using StudentRegistrationSystem.Models.Domain;
using StudentRegistrationSystem.Models.DTO;
using StudentRegistrationSystem.Repository;

namespace StudentRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext dbContext;
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly Student student;

        public StudentController(StudentDbContext dbContext, IStudentRepository studentRepository, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsDomain = await studentRepository.GetAllStudentsAsync();

            return Ok(mapper.Map<List<StudentDto>>(studentsDomain));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var studentDomain = await studentRepository.GetStudentByIdAsync(id);

            
            if (studentDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StudentDto>(studentDomain));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentRequestDto addStudentRequestDto)
        {
            var studentDomain = mapper.Map<Student>(addStudentRequestDto);

            var studentDto = await studentRepository.CreateStudentAsync(studentDomain);

            return CreatedAtAction(nameof(GetById), new {studentDto.Id}, studentDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, UpdateStudentDto updateStudentDto)
        {
            var studentDomainModel = mapper.Map<Student>(updateStudentDto);

            studentDomainModel = await studentRepository.UpdateStudentAsync(id, studentDomainModel);
            if (studentDomainModel == null)
            {
                return NotFound();
            }

            var studentDto = mapper.Map<StudentDto>(studentDomainModel);

            return Ok(studentDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var studentDomainModel = await studentRepository.DeleteStudentAsync(id);


            if (studentDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StudentDto>(studentDomainModel));
        }
    } 
}
