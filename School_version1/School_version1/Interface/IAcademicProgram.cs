using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface IAcademicProgram : IEntityService<AcademicProgram, AcademicProgramDto,AcademicProgramAddDto>
    {
        Task<List<AcademicProgramSPDto>> GetProgramLearn();
        Task<List<AcademicProgramSPDto>> GetProgramLearnFaculty(Guid FacultyId);
    }
}
