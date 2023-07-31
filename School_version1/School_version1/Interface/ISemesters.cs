using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ISemesters
    {
        Task<List<Semester>> GetAllSemester();
        Task<Semester> GetSemester(Guid id);
        Task<Boolean> DeleteSemester(Guid id);
        Task<bool> PostSemester(SemesterDto semesterDto);
        Task<Semester> PutSemester(Guid id, Semester semester);
    }
}
