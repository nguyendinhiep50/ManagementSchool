using School_version1.Models.DTOs;
using AutoMapper;
using School_version1.Entities;

namespace School_version1.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Student, StudentDto>(); 

                    // use check value in object student and studentDto
                 //.ForAllMembers(x => x.Condition((src, dest, value)=>dest.FacultyName !=null));
            CreateMap<StudentAddDto, Student>()  
                 .ForMember(x => x.StudentImage, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.StudentPassword, opt => opt.MapFrom(src =>"123"))
                 .ForMember(x => x.StudentPhone, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.StudentAdress, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.SchoolYear, opt => opt.MapFrom(src => 1))
                 .ForMember(x => x.StudentDateCome, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>() 
                 .ForMember(x => x.TeacherPassword, opt => opt.MapFrom(src => "12345"))
                 .ForMember(x => x.TeacherStatus, opt => opt.MapFrom(src => true));
            CreateMap<Subject, SubjectDto>();
            CreateMap<SemesterDto, Semester>();
            CreateMap<FacultyDto, Faculty>();
            CreateMap<AcademicProgramDto, AcademicProgram>();
            CreateMap<ClassLearnsDto, ClassLearn>();
            CreateMap<ListStudentClassLearnDto, ListStudentClassLearn>();

        }
    }
}
