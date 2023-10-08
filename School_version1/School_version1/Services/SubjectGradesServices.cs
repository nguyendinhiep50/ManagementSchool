using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class SubjectGradesServices : BaseEntityService<SubjectGrades, SubjectGradesDto, SubjectGradesAddDto>, ISubjectGrades
    {
        public SubjectGradesServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<List<SubjectGradesDto>> GetSubjectGradesAllClassLearn(string IdClassLearn)
        {
            Guid RefreshClassLearnId = new Guid(IdClassLearn);
            var result = await _db.ListStudentClassLearns
                .Where(x => x.ClassLearnId == RefreshClassLearnId)
                .Include(x => x.SubjectGrades)
                    .ThenInclude(y => y.Subject)
                .Include(o => o.Student)
                .ToListAsync();

            List<SubjectGradesDto> ListSubjectAllClassLearn = new List<SubjectGradesDto>();

            foreach (var x in result)
            {
                SubjectGradesDto subjectGradesAddDto = new SubjectGradesDto()
                {
                    GPARank1 = x.SubjectGrades.GPARank1,
                    GPARank2 = x.SubjectGrades.GPARank2,
                    GPARank3 = x.SubjectGrades.GPARank3,
                    GPARank4 = x.SubjectGrades.GPARank4,
                    PassSubject = x.SubjectGrades.PassSubject,
                    SubjectName = x.SubjectGrades.Subject.SubjectName,
                    StudentName = x.Student.StudentName,
                    SubjectGradesId = x.SubjectGrades.Id
                };

                ListSubjectAllClassLearn.Add(subjectGradesAddDto);
            }

            return ListSubjectAllClassLearn;
        }


        public async Task<SubjectGradesDto> GetSubjectGradesStudentSubject(string IdStudent)
        {
            Guid RefreshStudentId = new Guid(IdStudent);
            Student InfoStudent = await _db.Students.Include(x => x.CustomIdentityUser)
                .Where(x => x.CustomIdentityUserID == RefreshStudentId).FirstOrDefaultAsync();
            List<SubjectGrades> result = await _db.SubjectGrades
                            .Include(x => x.Student)
                            .Include(x => x.Subject)
                            .Where(x => x.StudentId == InfoStudent.Id)
                            .ToListAsync();

            return _mapper.Map<SubjectGradesDto>(result);
        }

        public async Task<SubjectGradesAddDto> UpdateSubjectGradesStudent(SubjectGradesAddDto SubjectGradesAddDtos)
        {
            var result = await _db.SubjectGrades.FindAsync(SubjectGradesAddDtos.SubjectGradesId);
            if (result == null)
            {
                // Create a new record if it doesn't exist
                result = new SubjectGrades(); // Replace SubjectGrades with your entity type
                _db.SubjectGrades.Add(result);
            }

            result.GPARank1 = SubjectGradesAddDtos.GPARank1;
            result.GPARank2 = SubjectGradesAddDtos.GPARank2;
            result.GPARank3 = SubjectGradesAddDtos.GPARank3;
            result.GPARank4 = SubjectGradesAddDtos.GPARank4;

            _db.Entry(result).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle database update errors
                // Log or throw an appropriate exception
            }

            return SubjectGradesAddDtos;
        }
        private async Task<Boolean> CheckPassSubject(SubjectGradesDto SubjectGradesDtos)
        {
            if(SubjectGradesDtos != null)
            {
                double TongAll = ((SubjectGradesDtos.GPARank1 + SubjectGradesDtos.GPARank2 *2
                                + SubjectGradesDtos.GPARank3*3)/3 + SubjectGradesDtos.GPARank4)/2;
                if (TongAll >= 5)
                    SubjectGradesDtos.PassSubject = true;
                else
                    SubjectGradesDtos.PassSubject = false;
            }
            return false;
        }

    }
}
