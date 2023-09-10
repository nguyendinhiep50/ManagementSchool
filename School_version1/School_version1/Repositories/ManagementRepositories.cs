using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Repositories
{
    public class ManagementRepositories : IManagementRepositories
    {
        protected DbContextSchool _db { get; private set; }  // can use when inherit
        protected IMapper _mapper;
        private readonly ILoginAccountRepository _accountRepo;

        public ManagementRepositories(DbContextSchool db, IMapper mapper , ILoginAccountRepository accountRepo)
        {
            _db = db;
            _mapper = mapper;
            _accountRepo = accountRepo;
        }

        public async Task<ManagementInfo> GetInfoAccount(string token)
        {
            var nameAccount = await _accountRepo.TakeInfoAccount(token);
            var result = await _db.Managements
                        .Include(x=>x.CustomIdentityUser)
                        .Where(x => x.CustomIdentityUser.Id == nameAccount.Id)
                        .FirstOrDefaultAsync();
            return _mapper.Map<ManagementInfo>(result); 
        }
    }
}
