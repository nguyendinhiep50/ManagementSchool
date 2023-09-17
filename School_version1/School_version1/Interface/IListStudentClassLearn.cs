using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{ 
    public interface IListStudentClassLearn : IEntityService<ListStudentClassLearn, ListStudentClassLearnDto,ListStudentClassLearnAddDto>
    {
        Task<AcademicProgramDto> GetAcademicProgramDtos(Guid idSubject);
        Task<Boolean> AddStudentClassLearn(Guid idAcademicProgram, Guid SubjectId, Guid StudentId);
        Task<StudentDto> GetStudentId(Guid IdAccount);
    }
}
