using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class SubjectServices : BaseEntityService<Subject, SubjectDto,SubjectAddDto> ,ISubject
    {
        public SubjectServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<List<SubjectDto>> GetSubjectStudentFauclty(Guid student)
        {
            var Result = await _db.AcademicPrograms.Where(x => x.FacultyId == _db.Students.Find(student).FacultyId)
                                             .Select(x=>x.SubjectId)
                                             .ToListAsync();
            var subjectsList = await _db.Subjects
                            .Where(s => Result.Contains(s.Id))
                            .ToListAsync(); // Lấy danh sách đối tượng Subject tương ứng từ danh sách SubjectId

            return _mapper.Map<List<SubjectDto>>(subjectsList);

        }
    }
    
}
