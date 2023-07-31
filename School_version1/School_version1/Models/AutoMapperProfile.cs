using School_version1.Models.DTOs;
using AutoMapper;
using School_version1.Entities;

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

                    // use check value in object student and studentDto
                 //.ForAllMembers(x => x.Condition((src, dest, value)=>dest.FacultyName !=null));
            CreateMap<StudentAddDto, Student>()
                 .ForMember(x => x.StudentName, opt => opt.MapFrom(src => src.StudentName))
                 .ForMember(x => x.StudentEmail, opt => opt.MapFrom(src => src.StudentEmail))
                 .ForMember(x => x.StudentBirthDate, opt => opt.MapFrom(src => src.StudentBirthDate))
                 .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.FacultyId))
                 .ForMember(x => x.StudentImage, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.StudentPassword, opt => opt.MapFrom(src =>"123"))
                 .ForMember(x => x.StudentPhone, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.StudentAdress, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.SchoolYear, opt => opt.MapFrom(src => 1))
                 .ForMember(x => x.StudentDateCome, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Teacher, TeacherDto>()
                 .ForMember(x => x.TeacherName, opt => opt.MapFrom(src => src.TeacherName))
                 .ForMember(x => x.TeacherImage, opt => opt.MapFrom(src => src.TeacherImage))
                 .ForMember(x => x.TeacherEmail, opt => opt.MapFrom(src => src.TeacherEmail))
                 .ForMember(x => x.TeacherBirthDate, opt => opt.MapFrom(src => src.TeacherBirthDate))
                 .ForMember(x => x.TeacherPhone, opt => opt.MapFrom(src => src.TeacherPhone))
                 .ForMember(x => x.TeacherAdress, opt => opt.MapFrom(src => src.TeacherAdress));
            CreateMap<TeacherDto, Teacher>()
                 .ForMember(x => x.TeacherName, opt => opt.MapFrom(src => src.TeacherName))
                 .ForMember(x => x.TeacherImage, opt => opt.MapFrom(src => src.TeacherImage))
                 .ForMember(x => x.TeacherEmail, opt => opt.MapFrom(src => src.TeacherEmail))
                 .ForMember(x => x.TeacherBirthDate, opt => opt.MapFrom(src => src.TeacherBirthDate))
                 .ForMember(x => x.TeacherPhone, opt => opt.MapFrom(src => src.TeacherPhone))
                 .ForMember(x => x.TeacherAdress, opt => opt.MapFrom(src => src.TeacherAdress))
                 .ForMember(x => x.TeacherPassword, opt => opt.MapFrom(src => "12345"))
                 .ForMember(x => x.TeacherStatus, opt => opt.MapFrom(src => true));
            CreateMap<Subject, SubjectDto>()
                 .ForMember(x => x.SubjectName, opt => opt.MapFrom(src => src.SubjectName))
                 .ForMember(x => x.SubjectCredit, opt => opt.MapFrom(src => src.SubjectCredit))
                 .ForMember(x => x.SubjectMandatory, opt => opt.MapFrom(src => src.SubjectMandatory));
            CreateMap<SemesterDto, Semester>()
                 .ForMember(x => x.SemesterName, opt => opt.MapFrom(src => src.SemesterName))
                 .ForMember(x => x.SemesterDayBegin, opt => opt.MapFrom(src => src.SemesterDayBegin))
                 .ForMember(x => x.SemesterDayEnd, opt => opt.MapFrom(src => src.SemesterDayEnd));


        }
    }
}
