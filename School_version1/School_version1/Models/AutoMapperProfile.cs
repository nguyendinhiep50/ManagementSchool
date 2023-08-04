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
            CreateMap<SubjectDto, Subject>();
            CreateMap<SemesterDto, Semester>();
            CreateMap<FacultyDto, Faculty>();
            CreateMap<AcademicProgramDto, AcademicProgram>();
            CreateMap<AcademicProgram, AcademicProgramSPDto>()
                .ForMember(x => x.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(x => x.SubjectId, opt => opt.MapFrom(src => src.Subject.Id))
                .ForMember(x => x.SubjectCredit, opt => opt.MapFrom(src => src.Subject.SubjectCredit))
                .ForMember(x => x.SubjectMandatory, opt => opt.MapFrom(src => src.Subject.SubjectMandatory))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
            CreateMap<ClassLearnsDto, ClassLearn>();
            CreateMap<ListStudentClassLearnDto, ListStudentClassLearn>();
            CreateMap<ManagementDto, Management>();


        }
    }
}
