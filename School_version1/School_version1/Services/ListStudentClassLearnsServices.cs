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

        public async Task<Boolean> AddStudentClassLearn(Guid idAcademicProgram,Guid StudentId)
        {
            var result = _db.ClassLearns
               .Where(x => x.AcademicProgramId == idAcademicProgram)
               .ToList();

            // check full class
            foreach (var item in result)
            {
                int countStudent =await _db.ListStudentClassLearns.Where(x => x.ClassLearnId == item.Id).CountAsync();
                if (countStudent < item.ClassLearnEnrollment)
                {
                    ListStudentClassLearnAddDto AddStudent = new ListStudentClassLearnAddDto()
                    {
                        ClassLearnId = item.Id,
                        StudentId = StudentId
                    };
                    try
                    {
                        _db.ListStudentClassLearns.Add(_mapper.Map<ListStudentClassLearn>(AddStudent));
                        _db.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                        throw;
                    }

                }
            }
            return false;
        }

        public async Task<StudentDto> GetStudentId(Guid IdAccount)
        {
            var result = await _db.Students.Where(x => x.CustomIdentityUserID == IdAccount.ToString()).FirstOrDefaultAsync();
            return _mapper.Map<StudentDto>(result);
        }
    }
}
