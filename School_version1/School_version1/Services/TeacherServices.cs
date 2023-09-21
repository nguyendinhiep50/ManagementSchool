using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.Drawing;

namespace School_version1.Services
{
    public class TeacherServices : BaseEntityService<Teacher, TeacherDto, TeacherAddDto>, ITeacher
    {
        private readonly ILoginAccountRepository accountRepo;
        public TeacherServices(DbContextSchool db, IMapper mapper, ILoginAccountRepository repo) : base(db, mapper)
        {
            accountRepo = repo;
        }
        public async Task<List<ClassLearnsDto>> GetClassLearnForTeacher(string nameTeacher)
        {
            var entity = await _db.ClassLearns
                            .Where(x => x.TeacherId == (_db.Teachers
                                                        .Where(x => x.TeacherName == nameTeacher)
                                                        .Select(x => x.Id).FirstOrDefault()
                                                        )).ToListAsync();
            return _mapper.Map<List<ClassLearnsDto>>(entity).ToList();
        }

        public async Task<TeacherAddDto> GetInfoAccount(string token)
        { 
            var result =await accountRepo.TakeInfoAccount(token);
            if (result != null)
            {
                var AccountTeacher = await _db.Teachers
                                        .Where(x => x.CustomIdentityUserID == (result.Id))
                                        .Include(x=>x.CustomIdentityUser)
                                        .FirstOrDefaultAsync(); 
                return _mapper.Map<TeacherAddDto>(AccountTeacher);
            }
            return null;
        }

        public async Task<TeacherDto> GetInfomationAccount(string nameTeacher)
        {
            var entity = await _db.ClassLearns
                            .Where(x => x.TeacherId == (_db.Teachers
                                                        .Where(x => x.TeacherName == nameTeacher)
                                                        .Select(x => x.Id).FirstOrDefault()
                                                        )).ToListAsync();
            return null;
        }
        public async Task<List<StudentDto>> GetListStudents(Guid ClassLearnId)
        {
            var Students = await _db.ListStudentClassLearns
                                .Where(x => x.ClassLearnId == ClassLearnId)
                                .Include(x => x.Student)
                                .Select(x=> new StudentDto
                                {
                                    StudentId = x.StudentId,
                                    FacultyId = x.Student.FacultyId,
                                    FacultyName = string.Empty,
                                    StudentName = x.Student.StudentName,
                                    StudentBirthDate = x.Student.StudentBirthDate,
                                    StudentImage = x.Student.StudentImage
                                })
                                .ToListAsync();
            return Students;
        }
        public override async Task<bool> Post(TeacherAddDto dto)
        {
            // add User Account
            AccountRegisterDto addAccountLogin = new AccountRegisterDto()
            {
                AccountEmail = dto.TeacherEmail,
                AccountName = dto.TeacherName,
                AccountPassword = "123",
                AccountPhone = dto.TeacherPhone,

            };
            var result = await accountRepo.RegisterdAccount(addAccountLogin);
            if (result.Succeeded)
            {
                // Add InfoAccount
                var user = await accountRepo.FindNameAccountID(dto.TeacherName);
                if (user != null)
                {
                    dto.CustomIdentityUserID =(user.Id);
                    if (await base.Post(dto))
                    { 
                        try
                        {
                            var resultEnd = await accountRepo.AddUserRole(new AddRoleAccount
                            {
                                EmailAccountUser = user.Email,
                                RoleAccountRole = "Teacher",
                                NameAccountUser = user.UserName
                            });
                            return resultEnd;
                        }
                        catch (Exception)
                        {
                            return false;
                            throw;
                        }
                    }
                }
            }
            return false;
        }
    }
}
