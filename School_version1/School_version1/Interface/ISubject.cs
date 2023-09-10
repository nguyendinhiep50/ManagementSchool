using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ISubject : IEntityService<Subject, SubjectDto,SubjectAddDto>
    {
        Task<List<SubjectDto>> GetSubjectStudentFaucltyAll(string nameStudent);
        Task<List<SubjectDto>> GetSubjectStudentFaucltyNoRegister(string nameStudent);
        Task<List<SubjectDto>> GetSubjectStudentFaucltyRegister(string nameStudent);
    }
}
