using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ITeacher : IEntityService<Teacher, TeacherDto,TeacherAddDto>
    {
        Task<List<ClassLearnsDto>> GetClassLearnForTeacher(string token);
        Task<List<StudentDto>> GetListStudents(Guid IdClassLearn);
        Task<TeacherAddDto> GetInfoAccount(string token);


    }
}
