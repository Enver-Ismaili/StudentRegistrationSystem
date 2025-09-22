
using AutoMapper;
using StudentRegistrationSystem.Models.Domain;
using StudentRegistrationSystem.Models.DTO;

namespace StudentRegistrationSystem.Mappings
{
    public class ClasRoomMapper : Profile
    {
        public ClasRoomMapper()
        {
            CreateMap<ClassRoom, ClassRoomDto>().ReverseMap();
            CreateMap<AddClassRoomDto, ClassRoom>().ReverseMap();
            CreateMap<UpdateClassRoomDto, ClassRoom>().ReverseMap();
        }
    }
}
