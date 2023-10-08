using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApiNetCore6.Repositories
{
    public class LoginAccountServices : ILoginAccountRepository
    {
        private readonly UserManager<CustomIdentityUser> userManager;
        private readonly SignInManager<CustomIdentityUser> signInManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly DbContextSchool _dbContext; 

        private readonly IConfiguration configuration;

        public LoginAccountServices( UserManager<CustomIdentityUser> userManager, DbContextSchool dbContext, SignInManager<CustomIdentityUser> signInManager, RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration; 
            _dbContext = dbContext;
        }

        public async Task<int> GetRoleCount()
        {
            var groupedUserRoles = await _dbContext.Users.CountAsync();
            return groupedUserRoles;
        }


        // CREATE PASSWORD
        public async Task<Boolean> ResetPassword(AccountResetPassword ResetPassword)
        {
            try
            {
                var result = await userManager.FindByEmailAsync(ResetPassword.AccountEmail);
                if (await userManager.CheckPasswordAsync(result, ResetPassword.AccountPassword))
                {
                    string resetToken = await userManager.GeneratePasswordResetTokenAsync(result);
                    IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(result, resetToken, ResetPassword.AccountPasswordNew);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        // create token
        public async Task<string> SignInAsync(AccountLoginDto model)
        {
            var result = await userManager.FindByNameAsync(model.AccountName);
            JwtSecurityToken token = null;

            // reset PassWord
            //string resetToken = await userManager.GeneratePasswordResetTokenAsync(result);
            //IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(resul'
            //t, resetToken, "123");

            if (result != null && await userManager.CheckPasswordAsync(result, model.AccountPassword))
            {
                var signInResult = await signInManager.PasswordSignInAsync(result, model.AccountPassword, true, false);
                if (signInResult != null)
                {
                    var roles = await userManager.GetRolesAsync(result);
                    var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.AccountName),
                            new Claim(JwtRegisteredClaimNames.Jti, result.Id.ToString())

                        };
                    // add role token
                    if (roles != null)
                    {
                        foreach (var role in roles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, role));
                        }

                    }

                    var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));


                    token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddMonths(1),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                    );

                }
            }

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // Find Account Take Info

        public async Task<Boolean> DeleteUser(string id)
        {
            var deleteUser = await userManager.FindByEmailAsync(id);
            try
            {
                await userManager.DeleteAsync(deleteUser);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
        // Find Name Account 
        public async Task<CustomIdentityUser> FindNameAccountID(string NameAccount)
        {
            try
            {
                var FindAccountId = await userManager.FindByNameAsync(NameAccount);
                FindAccountId.Student = await _dbContext.Students.Where(x => x.CustomIdentityUserID ==  (FindAccountId.Id)).FirstOrDefaultAsync();
                return FindAccountId;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return null;
        }
        // create column in table asp User. No have Infomation Account 

        public async Task<IdentityResult> RegisterdAccount(AccountRegisterDto model)
        {
            var user = new CustomIdentityUser
            {
                Email = model.AccountEmail,
                PasswordHash = model.AccountPassword,
                PhoneNumber = model.AccountPhone,
                UserName = model.AccountName
            };

            return await userManager.CreateAsync(user, model.AccountPassword);
        }

        public async Task<bool> UpdateUser(AccountResetPassword model)
        {
            var user = await userManager.FindByNameAsync(model.AccountName);
            if (user != null)
            {
                var changePasswordResult = await userManager.ChangePasswordAsync(user, model.AccountPassword, model.AccountPasswordNew);
                if (changePasswordResult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        // add role
        public async Task<bool> AddUserRole(AddRoleAccount addRoleAccount)
        {
            var resultUser = await userManager.FindByNameAsync(addRoleAccount.NameAccountUser);
            var resultRole = await roleManager.FindByNameAsync(addRoleAccount.RoleAccountRole);
            var resultByEmail = await userManager.FindByEmailAsync(addRoleAccount.EmailAccountUser);

            if (resultRole != null && resultUser != null && resultByEmail != null)
            {
                try
                {
                    var userRoleResult = await userManager.AddToRoleAsync(resultUser, resultRole.Name);
                    if (userRoleResult.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi ngoại lệ ở đây, ví dụ: ghi log hoặc trả về thông báo lỗi.
                    //throw ex; // Nếu bạn muốn ném lỗi ra ngoài để xử lý ở lớp gọi hàm này.
                }
            }

            return false;

        }


        public async Task<IdentityResult> AddInfomationAccount(AccountRegisterDto model)
        {
            return null;
        }

        public async Task<List<string>> CheckRoleUserID(string IdUser)
        {
            // Tìm người dùng dựa trên ID
            var user = await userManager.FindByIdAsync(IdUser);
            if (user == null)
            {
                // Xử lý trường hợp không tìm thấy người dùng
                return null;
            }

            // Lấy danh sách vai trò của người dùng
            var roles = await userManager.GetRolesAsync(user);

            return roles.ToList();
        }

        public async Task<CustomIdentityUser> TakeInfoAccount(string Token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                // Giải mã token và trả về thông tin bên trong dưới dạng ClaimsPrincipal
                var claimsPrincipal = tokenHandler.ValidateToken(Token, tokenValidationParameters, out var validatedToken);
                var userIdClaim = claimsPrincipal.Identities.FirstOrDefault().Name;
                var InfoAccount = await userManager.FindByNameAsync(userIdClaim); 
                var roles = await userManager.GetRolesAsync(InfoAccount);
                string RoleTemp = "";
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        if(role =="Management")
                            RoleTemp = role;    
                        else if (role =="Teacher" && role == "Management")
                            RoleTemp = role;
                        else if (role == "Student" && role == "Management" && role == "Teacher")
                            RoleTemp = role;
                    }
                }
                switch (RoleTemp)
                {
                    case "Management":
                        return InfoAccount;
                    case "Teacher":
                        return InfoAccount;
                    case "Student":
                        return InfoAccount;
                    default:
                        break;
                }

                return InfoAccount;
            }
            catch (SecurityTokenException)
            {
                // Nếu giải mã token gặp lỗi, xử lý lỗi tại đây
                return null;
            }
        }
        [AllowAnonymous]

        public async Task<List<UserAccountWithRole>> ListRoleUser(int page, int size)
        {
            var groupedUserRoles = await (
                from user in _dbContext.Users
                let roles = (
                    from ur in _dbContext.UserRoles
                    join r in _dbContext.Roles on ur.RoleId equals r.Id
                    where ur.UserId == user.Id
                    select r.Name
                ).ToList()
                select new UserAccountWithRole
                {
                    NameUser = user.UserName,
                    EmailUser = user.Email,
                    RoleManagement = roles.Contains("Management"),
                    RoleTeacher = roles.Contains("Teacher"),
                    RoleStudent = roles.Contains("Student"),
                }
            )
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
            return groupedUserRoles; 
        }
        public async Task<bool> UpdateUserRole(UserAccountWithRole roles)
        {
            var resultUserName = await userManager.FindByNameAsync(roles.NameUser);
            var resultUserEmail = await userManager.FindByEmailAsync(roles.EmailUser);
            // xoa toan bo id cua no
            // them id role lại cho nó từ đầu
            // vòng for xoa role 
            if (resultUserEmail != null && resultUserName != null)
            {
                var listRoles = roleManager.Roles.ToList();
                foreach (var item in listRoles)
                {
                    var userRoleResult = await userManager.RemoveFromRoleAsync(resultUserName, item.Name);
                    if (!userRoleResult.Succeeded)
                    {
                        var erro = userRoleResult.Succeeded;
                    }
                }
                List<string> result = new List<string>();
                if (roles.RoleManagement)
                    result.Add("Management");
                if (roles.RoleTeacher)
                    result.Add("Teacher");
                if (roles.RoleStudent)
                    result.Add("Student");
                foreach (var item in result)
                {
                    var userRoleResult = await userManager.AddToRoleAsync(resultUserName, item);
                    if (!userRoleResult.Succeeded)
                    {
                        var erro = userRoleResult.Succeeded;
                    }
                }
            }
            else
                return false;

            return true;
        }
    }
}
