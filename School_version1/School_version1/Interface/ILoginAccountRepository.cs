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
        public Task<IdentityResult> RegisterdAccount(RegisteredAccount model);
        public Task<IdentityResult> AddInfomationAccount(RegisteredAccount model);
        public Task<string> SignInAsync(LoginAddDto model);
        // take roles
        public Task<List<IdentityRole>> GetRoles();
        public Task<Boolean> DeleteUser(string id);
        public Task<Boolean> UpdateUser(SupportLogin model);

        // add roleUser
        public Task<Boolean> AddUserRole(string User,string role);
        public Task<List<CustomIdentityUser>> CheckAccount();
        public Task<List<string>> CheckRoleUserID(string IdUser);

        // take Info from Token
        public Task<Object> TakeInfoAccount(string Token);

        // resetPassword
        public Task<Boolean> ResetPassword(SupportLogin ResetPassword);

    }
}
