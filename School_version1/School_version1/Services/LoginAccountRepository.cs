using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApiNetCore6.Repositories
{
    public class LoginAccountRepository : ILoginAccountRepository
    {
        private readonly UserManager<CustomIdentityUser> userManager;
        private readonly SignInManager<CustomIdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IConfiguration configuration;

        public LoginAccountRepository(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
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

        // create token
        public async Task<string> SignInAsync(LoginAddDto model)
        {
            var result = await userManager.FindByNameAsync(model.NameLogin);
            JwtSecurityToken token = null;
            if (result != null)
            {
                var signInResult = await signInManager.PasswordSignInAsync(result, model.PassWorld, true, false);
                if (signInResult != null)
                { 
                    var roles = await userManager.GetRolesAsync(result);
                    var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.NameLogin),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                            
                        };
                    // add role token
                    if(roles != null)
                    {
                        foreach (var role in roles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, role));
                        }

                    }

                    var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                    var a = configuration["Jwt:Issuer"];

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
            var user = await userManager.FindByEmailAsync(model.LoginEmail);
            if (user != null)
            {
                var changePasswordResult = await userManager.ChangePasswordAsync(user, model.PassWorld, model.PassWorldNew);
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

 
    }
}
