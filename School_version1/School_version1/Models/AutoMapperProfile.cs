using AutoMapper;
using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //AcademicProgram

            CreateMap<AcademicProgramDto, AcademicProgram>();
            CreateMap<AcademicProgram, AcademicProgramSPDto>()
                .ForMember(x => x.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(x => x.SubjectId, opt => opt.MapFrom(src => src.Subject.Id))
                .ForMember(x => x.SubjectCredit, opt => opt.MapFrom(src => src.Subject.SubjectCredit))
                .ForMember(x => x.SubjectMandatory, opt => opt.MapFrom(src => src.Subject.SubjectMandatory))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
            // Get AcademicProgram
            CreateMap<AcademicProgram, AcademicProgramDto>()
                .ForMember(x => x.AcademicProgramId, opt => opt.MapFrom(src => src.Id));
            // Post AcademicProgram
            CreateMap<AcademicProgramAddDto, AcademicProgram>();

            //Faculty
            CreateMap<FacultyAddDto, Faculty>();
            CreateMap<FacultyDto, Faculty>();
            CreateMap<Faculty, FacultyDto>()
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.Id));

            //ClassLearn
            CreateMap<ClassLearn, ClassLearnsDto>()
                .ForMember(x => x.ClassLearnsId, opt => opt.MapFrom(src => src.Id));
            CreateMap<ClassLearnsDto, ClassLearn>();
            // convert ClassLearnsAddDto => ClassLearn
            CreateMap<ClassLearn, ClassLearnsAddDto>();
            CreateMap<ClassLearnsAddDto, ClassLearn>();


            // student
            CreateMap<Student, StudentDto>()
                .ForMember(x => x.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.FacultyId))
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.Faculty.Id))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));
            CreateMap<StudentAddDto, Student>()
                 .ForMember(x => x.StudentImage, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.StudentAdress, opt => opt.MapFrom(src => string.Empty))
                 .ForMember(x => x.SchoolYear, opt => opt.MapFrom(src => 1)) 
                 .ForMember(x => x.StudentDateCome, opt => opt.MapFrom(src => DateTime.Now));
            // convert from Student to studentDto
            CreateMap<StudentDto, Student>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.StudentId));
            CreateMap<Student, StudentInfo>()
                .ForMember(x => x.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.FacultyId))
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.Faculty.Id))
                .ForMember(x => x.PhoneStudent, opt => opt.MapFrom(src => src.CustomIdentityUser.PhoneNumber))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName));


            // teacher
            CreateMap<Teacher, TeacherDto>()
                .ForMember(x => x.TeacherId, opt => opt.MapFrom(src => src.Id));


            CreateMap<TeacherAddDto, Teacher>()
                .ForMember(x => x.TeacherStatus, opt => opt.MapFrom(src => true))
                .ForMember(x => x.CustomIdentityUserID, opt => opt.MapFrom(src => src.CustomIdentityUserID));
            CreateMap<Teacher, TeacherAddDto>()
                .ForMember(x => x.TeacherEmail, opt => opt.MapFrom(src => src.CustomIdentityUser.Email))
                .ForMember(x => x.TeacherPhone, opt => opt.MapFrom(src => src.CustomIdentityUser.PhoneNumber));

            CreateMap<TeacherDto, Teacher>()
                .ForMember(x => x.TeacherStatus, opt => opt.MapFrom(src => true))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.TeacherId));


            //subject
            CreateMap<Subject, SubjectDto>()
                 .ForMember(x => x.SubjectId, opt => opt.MapFrom(src => src.Id));
            CreateMap<SubjectDto, Subject>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.SubjectId));
            CreateMap<SubjectAddDto, Subject>();



            //ListStudentClassLearn
            CreateMap<ListStudentClassLearnDto, ListStudentClassLearn>();
            CreateMap<ListStudentClassLearnAddDto, ListStudentClassLearn>();
            CreateMap<AcademicProgram, AcademicProgramListName>()
                .ForMember(x => x.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName))
                .ForMember(x => x.FacultyName, opt => opt.MapFrom(src => src.Faculty.FacultyName))
                .ForMember(x => x.SemesterName, opt => opt.MapFrom(src => src.Semester.SemesterName))
                .ForMember(x => x.AcademicProgramId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.AcademicProgramName, opt => opt.MapFrom(src => src.AcademicProgramName))
                .ForMember(x => x.AcademicProgramTimeEnd, opt => opt.MapFrom(src => src.AcademicProgramTimeEnd));
            CreateMap<AcademicProgram, AcademicProgramDto>()
                .ForMember(x => x.AcademicProgramId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FacultyId, opt => opt.MapFrom(src => src.FacultyId))
                .ForMember(x => x.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(x => x.SemesterId, opt => opt.MapFrom(src => src.SemesterId))
                .ForMember(x => x.AcademicProgramName, opt => opt.MapFrom(src => src.AcademicProgramName))
                .ForMember(x => x.AcademicProgramTimeEnd, opt => opt.MapFrom(src => src.AcademicProgramTimeEnd));


            //Semester
            CreateMap<SemesterAddDto, Semester>();
            CreateMap<SemesterDto, Semester>();
            CreateMap<Semester, SemesterDto>()
                .ForMember(x => x.SemesterId, opt => opt.MapFrom(src => src.Id));


            CreateMap<ListStudentClassLearn, ListStudentClassLearnDto>()
                .ForMember(x => x.ListStudentClassLearnId, opt => opt.MapFrom(src => src.Id));


            //Management
            CreateMap<ManagementDto, Management>();
            CreateMap<Management, ManagementDto>()
                .ForMember(x => x.ManagementId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Management, ManagementInfo>()
                .ForMember(x => x.NameManagement, opt => opt.MapFrom(src => src.ManagementName))
                .ForMember(x => x.EmailManagement, opt => opt.MapFrom(src => src.CustomIdentityUser.Email))
                .ForMember(x => x.PhoneManagement, opt => opt.MapFrom(src => src.CustomIdentityUser.PhoneNumber));

          

        }
    }
}
