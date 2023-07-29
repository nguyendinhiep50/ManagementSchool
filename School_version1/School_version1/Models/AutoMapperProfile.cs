using School_version1.Models.DTOs;
using School_version1.Models.ObjectData;
using AutoMapper;
namespace School_version1.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Student, StudentDto>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(x => x.StudentName, opt => opt.MapFrom(src => src.StudentName))
                 .ForMember(x => x.StudentImage, opt => opt.MapFrom(src => src.StudentImage)) 
                 .ForMember(x => x.StudentBirthDate, opt => opt.MapFrom(src => src.StudentBirthDate)) 
                 .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
        }
    }
}
