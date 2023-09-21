using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class ListStudentClassLearnsServices : BaseEntityService<ListStudentClassLearn, ListStudentClassLearnDto,ListStudentClassLearnAddDto>, IListStudentClassLearn
    {
        public ListStudentClassLearnsServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<AcademicProgramDto> GetAcademicProgramDtos(Guid idSubject)
        {
            //var result = await _db.AcademicPrograms
            //    .Where(x => x.SubjectId == idSubject && x.AcademicProgramTimeEnd > DateTime.Now)
            //    .FirstOrDefaultAsync();
            var result = await _db.AcademicPrograms
              .Where(x => x.SubjectId == idSubject)
              .FirstOrDefaultAsync();
            return _mapper.Map<AcademicProgramDto>(result);
        }

        public async Task<Boolean> AddStudentClassLearn(Guid idAcademicProgram,Guid SubjectId,Guid StudentId)
        {
            var result = await _db.ClassLearns
               .Where(x => x.AcademicProgramId == idAcademicProgram)
               .FirstOrDefaultAsync();

            // check full class 
                // check 
            var CheckExist = await _db.ListStudentClassLearns.Where(x => x.ClassLearnId == result.Id && x.StudentId == StudentId).ToArrayAsync();
            int countStudent =await _db.ListStudentClassLearns.Where(x => x.ClassLearnId == result.Id).CountAsync();
            if (countStudent < result.ClassLearnEnrollment && CheckExist.Count() ==0)
            {
                Guid IDClassLearn = Guid.NewGuid();
                SubjectGrades subjectGradesNew = new SubjectGrades()
                {
                    StudentId = StudentId,
                    SubjectId = SubjectId, 
                };
                ListStudentClassLearn AddStudent = new ListStudentClassLearn()
                {
                    ClassLearnId = result.Id,
                    StudentId = StudentId,
                    Id = IDClassLearn,
                    SubjectGrades = subjectGradesNew
                };
                try
                {
                    _db.ListStudentClassLearns.Add(AddStudent);
                    _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                } 
            } 
            return false;
        }
        public async Task<StudentDto> GetStudentId(Guid IdAccount)
        {
            var result = await _db.Students.Where(x => x.CustomIdentityUserID == IdAccount).FirstOrDefaultAsync();
            return _mapper.Map<StudentDto>(result);
        }
    }
}
