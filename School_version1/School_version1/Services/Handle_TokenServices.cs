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
        public Handle_TokenServices()
        {

        }
        public async Task<string> GetSubjectInStudent(string tokenStudent)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(tokenStudent, new TokenValidationParameters
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
