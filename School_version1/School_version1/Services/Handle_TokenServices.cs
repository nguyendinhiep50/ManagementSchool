using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_version1.Services
{
    public class Handle_TokenServices : ControllerBase, ISupportToken
    {
        private ClaimsPrincipal _currentUser;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handle_TokenServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Truy cập thông tin xác thực từ HttpContext.Items
            if (_httpContextAccessor.HttpContext.Items.ContainsKey("Username"))
            {
                string username = _httpContextAccessor.HttpContext.Items["Username"].ToString();
                // Sử dụng thông tin xác thực ở đây
            }
        }
        public async Task<string> GetSubjectInStudent(string tokenStudent)
        { 
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                token = authorizationHeader.Substring("Bearer ".Length);
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                // Các thiết lập khác
            }, out validatedToken); 
            var usernameClaim = principal.FindFirst(ClaimTypes.Name);
            if (usernameClaim != null)
            {
                return usernameClaim.Value; 
            }
        
            return null;
        }

        public void SetCurrentUser(ClaimsPrincipal currentUser)
        {
            _currentUser = currentUser;
        }
    }
}
