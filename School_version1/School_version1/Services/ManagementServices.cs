using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace School_version1.Services
{
    public class ManagementServices : BaseRepositories<Management, ManagementDto, ManagementAddDto>, IBaseRepositories<Management, ManagementDto,ManagementAddDto>
    {
        private readonly ILoginAccountRepository accountRepo;
        public ManagementServices(DbContextSchool db, IMapper mapper, ILoginAccountRepository repo) : base(db, mapper)
        {
            accountRepo = repo;
            db = base._db;
            mapper = base._mapper;
        }
        public override async Task<Boolean> Post(ManagementAddDto dto)
        {
            // add User Account
            AccountRegisterDto addAccountLogin = new AccountRegisterDto()
            {
                AccountEmail = dto.ManagementEmail,
                AccountName = dto.ManagementName,
                AccountPassword = "123",
                AccountPhone = string.Empty,

            };
            var result = await accountRepo.RegisterdAccount(addAccountLogin);
            if (result.Succeeded)
            {
                // Add InfoAccount
                var user = await accountRepo.FindNameAccountID(dto.ManagementName);
                if (user != null)
                {
                    //dto.cus = Guid.Parse(user.Id);
                    //if (await base.Post(dto))
                    //{
                    //    // Add Role "Student"
                    //    var addRole = await accountRepo.AddUserRole(new AddRoleAccount
                    //    {
                    //        EmailAccountUser = user.Email,
                    //        RoleAccountRole = "Student",
                    //        NameAccountUser = user.UserName
                    //    });
                    //    if (result != null)
                    //        return true;

                    //}
                }
            }
            return false;
        }
    }
}
