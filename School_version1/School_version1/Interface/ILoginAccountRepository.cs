using Microsoft.AspNetCore.Identity;
using School_version1.Entities;
using School_version1.Models.DTOs;
using System.Collections;
using System.Security.Claims;

namespace School_version1.Interface
{
    public interface ILoginAccountRepository
    {
        //create add
        public Task<IdentityResult> RegisterdAccount(AccountRegisterDto model);
        public Task<IdentityResult> AddInfomationAccount(AccountRegisterDto model);
        public Task<string> SignInAsync(AccountLoginDto model);
        // take roles
        public Task<int> GetRoleCount();
        public Task<Boolean> DeleteUser(string id);
        public Task<Boolean> UpdateUser(AccountResetPassword model);

        // add roleUser
        public Task<Boolean> AddUserRole(AddRoleAccount addRoleAccount);
        // list roleUser
        public Task<List<UserAccountWithRole>> ListRoleUser(int page,int size);
        public Task<List<string>> CheckRoleUserID(string IdUser);

        // take Info from Token
        public Task<CustomIdentityUser> TakeInfoAccount(string Token);

        // resetPassword
        public Task<Boolean> ResetPassword(AccountResetPassword ResetPassword);
        // Find ACcount ID
        public Task<CustomIdentityUser> FindNameAccountID(string id);
        public Task<Boolean> UpdateUserRole(UserAccountWithRole roles);

    }
}
