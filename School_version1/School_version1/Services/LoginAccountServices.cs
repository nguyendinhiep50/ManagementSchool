using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApiNetCore6.Repositories
{
    public class LoginAccountServices : ILoginAccountRepository
    {
        private readonly UserManager<CustomIdentityUser> userManager;
        private readonly SignInManager<CustomIdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IConfiguration configuration;

        public LoginAccountServices(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return roles;
        }

        // CREATE PASSWORD
        public async Task<Boolean> ResetPassword(SupportLogin ResetPassword)
        {
            try
            {
                var result = await userManager.FindByEmailAsync(ResetPassword.LoginName);
                if (await userManager.CheckPasswordAsync(result, ResetPassword.PassWord))
                {
                    string resetToken = await userManager.GeneratePasswordResetTokenAsync(result);
                    IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(result, resetToken, ResetPassword.PassWordNew);
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
        public async Task<string> SignInAsync(LoginAddDto model)
        {
            var result = await userManager.FindByNameAsync(model.NameLogin);
            JwtSecurityToken token = null;

            // reset PassWord
            //string resetToken = await userManager.GeneratePasswordResetTokenAsync(result);
            //IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(result, resetToken, "123");

            if (result != null && await userManager.CheckPasswordAsync(result, model.PassWord))
            {
                var signInResult = await signInManager.PasswordSignInAsync(result, model.PassWord, true, false);
                if (signInResult != null)
                {
                    var roles = await userManager.GetRolesAsync(result);
                    var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.NameLogin),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

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
                        expires: DateTime.Now.AddMinutes(20),
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

        // create column in table asp User. No have Infomation Account 

        public async Task<IdentityResult> RegisterdAccount(RegisteredAccount model)
        {
            var user = new CustomIdentityUser
            {
                Email = model.EmailAccount,
                PasswordHash = model.PasswordAccount,
                PhoneNumber = model.PhoneAccount,
                UserName = model.NameAccount

            };

            return await userManager.CreateAsync(user, model.PasswordAccount);
        }
        // Add column in table User

        public async Task<bool> UpdateUser(SupportLogin model)
        {
            var user = await userManager.FindByNameAsync(model.LoginName);
            if (user != null)
            {
                var changePasswordResult = await userManager.ChangePasswordAsync(user, model.PassWord, model.PassWordNew);
                if (changePasswordResult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        // add role
        public async Task<bool> AddUserRole(string User, string role)
        {
            var resultUser = await userManager.FindByEmailAsync(User);
            var resultRole = await roleManager.FindByNameAsync(role);
            if (resultRole != null && resultUser != null)
            {
                var userRoleResult = await userManager.AddToRoleAsync(resultUser, resultRole.Id);
                if (userRoleResult.Succeeded)
                {
                    return true;
                }

            }
            return false;
        }

        public async Task<IdentityResult> AddInfomationAccount(RegisteredAccount model)
        {
            return null;
        }

        public async Task<List<CustomIdentityUser>> CheckAccount()
        {
            var bien = await userManager.Users.ToListAsync();
            foreach (var item in bien)
            {
                var passwordHasher = new PasswordHasher<CustomIdentityUser>(); // Thay thế CustomIdentityUser bằng lớp người dùng của bạn
                var verificationResult = passwordHasher.VerifyHashedPassword(item, item.PasswordHash, "enteredPassword");
            }
            return bien;
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

        public async Task<Object> TakeInfoAccount(string Token)
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
    }
}
