namespace School_version1.Models.DTOs
{
    public class UserAccountWithRole
    {
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public Boolean RoleManagement { get; set; }
        public Boolean RoleTeacher { get; set; }
        public Boolean RoleStudent { get; set; }
    }
}
