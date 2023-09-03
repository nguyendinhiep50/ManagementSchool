using School_version1.Entities;
using School_version1.Models.DTOs;
using System.Security.Claims;

namespace School_version1.Interface
{
    public interface ISupportToken
    {
        public Task<string> GetSubjectInStudent(string tokenStudent);
        void SetCurrentUser(ClaimsPrincipal currentUser);
    }
}
