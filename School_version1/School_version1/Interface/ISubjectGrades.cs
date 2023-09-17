using Microsoft.AspNetCore.Mvc;
using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ISubjectGrades : IEntityService<SubjectGrades, SubjectGradesDto, SubjectGradesAddDto>
    {
        //  list all (ClassLearnID)
        Task<List<SubjectGradesDto>> GetSubjectGradesAllClassLearn(string IdClassLearn);
        //  SubjectGrdes (ClassLearnID)

        //  Student take SubjectGrades
        Task<SubjectGradesDto> GetSubjectGradesStudentSubject(string IdStudent);
        //  update SubjectGrades
        Task<SubjectGradesAddDto> UpdateSubjectGradesStudent(SubjectGradesAddDto SubjectGradesAddDtos);

    }
}
