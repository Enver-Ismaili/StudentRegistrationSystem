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
    public class ClassRoomController : ControllerBase
    {
            private readonly StudentDbContext dbContext;
            private readonly IClassRoomRepository classRoomRepository;
            private readonly IMapper mapper;

            public ClassRoomController(StudentDbContext dbContext, IClassRoomRepository classRoomRepository, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.classRoomRepository = classRoomRepository;
                this.mapper = mapper;
            }


        [HttpGet]
        public async Task<IActionResult> GetAllClassRooms()
        {
            var studentsDomain = await classRoomRepository.GetAllClassRoomAsync();

            return Ok(mapper.Map<List<ClassRoomDto>>(studentsDomain));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var classRoom = await classRoomRepository.GetClassRoomByIdAsync(id);


            if (classRoom == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ClassRoomDto>(classRoom));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassRoom([FromBody] AddClassRoomDto addClassRoomDto)
        {                                                                         
            var classRoom = mapper.Map<ClassRoom>(addClassRoomDto);

            var classRoomDto = await classRoomRepository.CreateClassRoomAsync(classRoom);

            return CreatedAtAction(nameof(GetById), new { classRoomDto.Id }, classRoomDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateClassRoom([FromRoute] int id, UpdateClassRoomDto updateClassRoomDto)
        {
            var classRoom = mapper.Map<ClassRoom>(updateClassRoomDto);

            classRoom = await classRoomRepository.UpdateClassRoomAsync(id, classRoom);
            if (classRoom == null)
            {
                return NotFound();
            }

            var classRoomDto = mapper.Map<ClassRoomDto>(classRoom);

            return Ok(classRoomDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteClassRoom([FromRoute] int id)
        {
            var classRoom = await classRoomRepository.DeleteClassRoomAsync(id);


            if (classRoom == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ClassRoomDto>(classRoom));
        }
    }
}
