using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ITeacher : IEntityService<TeacherDto, TeacherDto,TeacherAddDto>
    { 
    }
}
