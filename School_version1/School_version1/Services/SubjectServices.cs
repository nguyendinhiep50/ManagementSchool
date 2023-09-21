using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.Linq;

namespace School_version1.Services
{
    public class SubjectServices : BaseEntityService<Subject, SubjectDto, SubjectAddDto>, ISubject
    {
        private readonly ILoginAccountRepository accountRepo;

        public SubjectServices(DbContextSchool db, IMapper mapper, ILoginAccountRepository repo) : base(db, mapper)
        {
            accountRepo = repo;
        }

        // tách học kì ra rồi có thể phát triển lấy học kì ở đây 
        // đây là lấy All 
        // tao them mot cai ham xu ly lay ra nhung môn da dang ky
        // xử lý hoc ki sẽ dựa trên ngày hiện tại
        public async Task<List<SubjectDto>> GetSubjectStudentFaucltyAll(string nameStudent)
        {
            // check xem mo lop hay chua
            var InfoAccount = await accountRepo.FindNameAccountID(nameStudent);
            var Result = await _db.AcademicPrograms
                                .Where(x => x.FacultyId ==
                                            _db.Students.Find(InfoAccount.Student.Id).FacultyId
                                       && x.AcademicProgramTimeEnd > DateTime.Now
                                       && _db.ClassLearns.Any(y => y.AcademicProgramId == x.Id))
                                .Select(x => x.SubjectId)
                                .ToListAsync();
            var subjectsList = await _db.Subjects
                            .Where(s => Result.Contains(s.Id))
                            .ToListAsync(); // Lấy danh sách đối tượng Subject tương ứng từ danh sách SubjectId

            return _mapper.Map<List<SubjectDto>>(subjectsList);
        }
        public async Task<List<SubjectDto>> GetSubjectStudentFaucltyNoRegister(string nameStudent)
        {
            var InfoAccount = await accountRepo.FindNameAccountID(nameStudent);
            var result = await GetSubjectStudentFaucltyAll(InfoAccount.UserName);
            var result2 = await GetSubjectStudentFaucltyRegister(InfoAccount.UserName);
            result.RemoveAll(subject => result2.Any(subjectToRemove => subjectToRemove.SubjectId == subject.SubjectId));
            return result;
        }
        public async Task<List<SubjectDto>> GetSubjectStudentFaucltyRegister(string nameStudent)
        {
            var InfoAccount = await accountRepo.FindNameAccountID(nameStudent);
            var Info = await _db.Students.FindAsync(InfoAccount.Student.Id);

            var SubjectList2 = await _db.ListStudentClassLearns
                        .Where(x => x.StudentId == InfoAccount.Student.Id)
                         .Join(_db.ClassLearns, l => l.ClassLearnId, c => c.Id, (l, c) => c)
                         .Join(_db.AcademicPrograms, c => c.AcademicProgramId, ap => ap.Id, (c, ap) => ap)
                         .Join(_db.Subjects, ap => ap.SubjectId, s => s.Id, (ap, s) => s)
                         .ToListAsync();



            var result2 = _mapper.Map<List<SubjectDto>>(SubjectList2);

            return result2;
        }

    }

}
