using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ISubject : IEntityService<Subject, SubjectDto,SubjectAddDto>
    {
        Task<List<SubjectDto>> GetSubjectStudentFauclty(string nameStudent);
    }
}
