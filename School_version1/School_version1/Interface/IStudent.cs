using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface IStudent : IEntityService<Student, StudentAddDto>
    {
        Task<List<StudentDto>> GetAllStudentFaculty();
        Task<StudentDto> GetStudentFaculty(Guid id);
        Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id);
    }
}
