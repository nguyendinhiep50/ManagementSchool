using AutoMapper;
using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();

            // use check value in object student and studentDto
            //.ForAllMembers(x => x.Condition((src, dest, value)=>dest.FacultyName !=null));
            CreateMap<StudentAddDto, Student>()
                 .ForMember(x => x.StudentImage, opt => opt.MapFrom(src => string.Empty)) 
                 .ForMember(x => x.StudentAdress, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.SchoolYear, opt => opt.MapFrom(src => 1))
                 .ForMember(x => x.StudentDateCome, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherAddDto, Teacher>() 
                .ForMember(x => x.TeacherStatus, opt => opt.MapFrom(src => true));

            CreateMap<TeacherDto, Teacher>() 
                 .ForMember(x => x.TeacherStatus, opt => opt.MapFrom(src => true));

            CreateMap<AcademicProgramDto, AcademicProgram>();
            CreateMap<AcademicProgram, AcademicProgramSPDto>()
                .ForMember(x => x.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(x => x.SubjectId, opt => opt.MapFrom(src => src.Subject.Id))
                .ForMember(x => x.SubjectCredit, opt => opt.MapFrom(src => src.Subject.SubjectCredit))
                .ForMember(x => x.SubjectMandatory, opt => opt.MapFrom(src => src.Subject.SubjectMandatory))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
            CreateMap<ManagementDto, Management>();

            // change list
            CreateMap<AcademicProgram, AcademicProgramDto>()
                .ForMember(x => x.AcademicProgramId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Faculty, FacultyDto>()
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.Id));


            CreateMap<ClassLearn, ClassLearnsDto>()
                .ForMember(x => x.ClassLearnsId, opt => opt.MapFrom(src => src.Id));
            CreateMap<ClassLearnsDto, ClassLearn>();
            // convert ClassLearnsAddDto => ClassLearn
            CreateMap<ClassLearn, ClassLearnsAddDto>();
            CreateMap<ClassLearnsAddDto, ClassLearn>();

            CreateMap<ListStudentClassLearn, ListStudentClassLearnDto>()
                .ForMember(x => x.ListStudentClassLearnId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Management, ManagementDto>()
                .ForMember(x => x.ManagementId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Semester, SemesterDto>()
                .ForMember(x => x.SemesterId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Student, StudentDto>()
                .ForMember(x => x.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
            CreateMap<StudentAddDto, Student>();
            CreateMap<Subject, SubjectDto>()
                .ForMember(x => x.SubjectId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Teacher, TeacherDto>()
                .ForMember(x => x.TeacherId, opt => opt.MapFrom(src => src.Id));
            CreateMap<SubjectDto, Subject>()
                .ForMember(x=>x.Id ,opt => opt.MapFrom(src=>src.SubjectId));

            // convert from StudentDto to Student
            CreateMap<StudentDto, Student>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<SubjectAddDto, Subject>();
            CreateMap<FacultyAddDto, Faculty>();
            CreateMap<SemesterAddDto, Semester>(); 
            CreateMap<FacultyDto, Faculty>();


            CreateMap<ListStudentClassLearnDto, ListStudentClassLearn>();
            CreateMap<SemesterDto, Semester>();



        }
    }
}
