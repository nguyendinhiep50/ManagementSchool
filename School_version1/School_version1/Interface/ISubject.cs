using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ISubject
    {
        Task<List<Subject>> GetAllSubject();
        Task<Subject> GetSubject(Guid id);
        Task<Boolean> DeleteSubject(Guid id);
        Task<bool> PostSubject(Subject subject);
        Task<Subject> PutSubject(Guid id, Subject Subject);
    }
}
