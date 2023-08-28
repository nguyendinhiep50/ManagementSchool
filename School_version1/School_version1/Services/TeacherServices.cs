using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class TeacherServices : BaseEntityService<Teacher, TeacherDto, TeacherAddDto>, ITeacher
    {
        private readonly ILoginAccountRepository accountRepo;
        public TeacherServices(DbContextSchool db, IMapper mapper, ILoginAccountRepository repo) : base(db, mapper)
        {
            accountRepo = repo;
            db = base._db;
            mapper = base._mapper;
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
                        // Add Role "Student"
                        var Roles = new string[] { "Teacher", "Student" };
                        try
                        {
                            foreach (var item in Roles)
                                await accountRepo.AddUserRole(new AddRoleAccount
                                {
                                    EmailAccountUser = user.Email,
                                    RoleAccountRole = item,
                                    NameAccountUser = user.UserName
                                });
                            return true;
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
