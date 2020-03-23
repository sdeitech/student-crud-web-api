using AutoMapper;
using DTO;
using Models;

namespace StudentCoreApp.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
