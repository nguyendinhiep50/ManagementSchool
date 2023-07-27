using School_version1.Entities;

namespace School_version1.Interface
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudent(Guid id);
        Task<Boolean> DeleteStudent(Guid id);
        Task<Boolean> PostStudent(Student student);
        Task<Student> PutStudent(Guid id , Student student);
    }
}
