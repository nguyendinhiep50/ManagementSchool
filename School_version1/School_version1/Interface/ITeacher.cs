using School_version1.Entities;

namespace School_version1.Interface
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetAllTeacher();
        Task<Teacher> GetTeacher(Guid id);
        Task<Boolean> DeleteTeacher(Guid id);
        Task<Boolean> PostTeacher(Teacher teacher);
        Task<Teacher> PutTeacher(Guid id, Teacher teacher);
    }
}
