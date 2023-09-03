using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class ClassLearnsServices : BaseEntityService<ClassLearn, ClassLearnsDto,ClassLearnsAddDto> ,IClassLearn
    {
        public ClassLearnsServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<List<string>> GetAllStudentInClassLearn(Guid id,int pages,int size)
        {
            var pageSkip = (pages - 1) * size;
            var ListStudentInClass = _db.ListStudentClassLearns.Include(x => x.Student)
                                       .Where(x => x.ClassLearnId == id )
                                       .Select(x=>x.Student.StudentName)
                                       .Skip(pageSkip)
                                       .Take(size)
                                       .ToListAsync();
            return await ListStudentInClass;
        }
    }
}
