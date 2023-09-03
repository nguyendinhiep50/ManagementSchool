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
        public async Task<TeacherDto> GetInfomationAccount(string nameTeacher)
        {
            var entity = await _db.ClassLearns
                            .Where(x => x.TeacherId == (_db.Teachers
                                                        .Where(x => x.TeacherName == nameTeacher)
                                                        .Select(x => x.Id).FirstOrDefault()
                                                        )).ToListAsync();
            return null;
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
                    dto.CustomIdentityUserID = Guid.Parse(user.Id);
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
