using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;

using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class StudentServices : BaseEntityService<Student, StudentDto, StudentAddDto>, IStudent
    {
        private readonly ILoginAccountRepository accountRepo;
        public StudentServices(DbContextSchool db, IMapper mapper, ILoginAccountRepository repo) : base(db, mapper)
        {
            accountRepo = repo;
            db = base._db;
            mapper = base._mapper;
        }
        // ghi de phuong thuc Post Sinh vien de tao them tai khoan cho sinh vien trong identity
        public override async Task<bool> Post(StudentAddDto dto)
        {
            // add User Account
            AccountRegisterDto addAccountLogin = new AccountRegisterDto()
            {
                AccountEmail = dto.StudentEmail,
                AccountName = dto.StudentName,
                AccountPassword = "123",
                AccountPhone = string.Empty
            };
            var result = await accountRepo.RegisterdAccount(addAccountLogin);
            if (result.Succeeded)
            {
                // Add InfoAccount
                var user = await accountRepo.FindNameAccountID(dto.StudentName);
                if (user != null) {
                    dto.CustomIdentityUserID = Guid.Parse(user.Id);
                    if(await base.Post(dto))
                    {
                        // Add Role "Student"
                        var addRole = await accountRepo.AddUserRole(new AddRoleAccount {
                            EmailAccountUser = user.Email,
                            RoleAccountRole = "Student",
                            NameAccountUser = user.UserName
                        });
                        if (result != null)
                            return true;

                    }
                }
            }
            return false;
        }

        public async Task<List<StudentDto>> GetAllStudentFaculty(int page,int size)
        {
            page = page < 1 ? 1 : page;
            int PagesSkip = (page - 1) * size;
            // take all
            if (size < 1)
            {
                var entity2 = await _db.Set<Student>().Include(x => x.Faculty).ToListAsync();
                return _mapper.Map<List<StudentDto>>(entity2).ToList();
            }
            var entity = await _db.Set<Student>().Include(x => x.Faculty).Skip(PagesSkip).Take(size).ToListAsync();
            return _mapper.Map<List<StudentDto>>(entity).ToList();

        }

        public async Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id)
        {
            var students = await _db.Students.Include(s=>s.Faculty).Where(x => x.FacultyId == id).ToListAsync();

            return _mapper.Map<List<StudentDto>>(students).ToList();
        }

        public async Task<StudentDto> GetStudentFaculty(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            student.Faculty = await _db.Faculty.FindAsync(student.FacultyId);
            return _mapper.Map<StudentDto>(student);
        }

    }
}
