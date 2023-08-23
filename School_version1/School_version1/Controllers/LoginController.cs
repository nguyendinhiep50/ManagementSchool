using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAccountRepository accountRepo;

        public LoginController(ILoginAccountRepository repo)
        {
            accountRepo = repo;
        }
        // add user
        // admin
        [HttpPost("RegisteredAccount")]
        public async Task<IActionResult> RegisteredAccount(RegisteredAccount LoginAdd)
        {
            var result = await accountRepo.RegisterdAccount(LoginAdd);
            if (result.Succeeded)
            {
                // add Infomation Account

                return Ok(result.Succeeded);
            }
            
            return Unauthorized();
        }
        //admin
        // get roles
        [HttpPost("getRoles")]
        public async Task<IActionResult> getRoles()
        {
            var result = await accountRepo.GetRoles();
            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }
        // admin
        // delete user
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await accountRepo.DeleteUser(id);
            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }
        // admin
        // update user
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(SupportLogin model)
        {
            var result = await accountRepo.UpdateUser(model);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }
        // admin
        // add role 
        [HttpPost("AddRoleUser")]
        public async Task<IActionResult> AddRoleUser(string Email,string NameRole)
        {
            var result = await accountRepo.AddUserRole(Email, NameRole);
            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }
        // login 
        // token
        [AllowAnonymous]
        [HttpPost("LoginAccount")]
        public async Task<IActionResult> LoginAccount(LoginAddDto LoginUser)
        {
            var result = await accountRepo.SignInAsync(LoginUser);
            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }
        // check info password        // có thể xóa
        [HttpGet("check")]
        public async Task<List<string>> check(string UserID)
        {
            var result = await accountRepo.CheckRoleUserID(UserID);
            if (result != null)
            {
                return result;
            }

            return null;
        }
        // Check Info Account

    }
}
