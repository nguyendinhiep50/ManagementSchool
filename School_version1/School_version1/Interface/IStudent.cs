using School_version1.Models.DTOs;
using School_version1.Models.ObjectData;

namespace School_version1.Interface
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudent();
        Task<List<StudentDto>> GetAllStudentFaculty();
        Task<Student> GetStudent(Guid id);
        Task<StudentDto> GetStudentFaculty(Guid id);
        Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id);
        Task<Boolean> DeleteStudent(Guid id);
        Task<Boolean> PostStudent(Student student);
        Task<Student> PutStudent(Guid id , Student student);
    }
}
