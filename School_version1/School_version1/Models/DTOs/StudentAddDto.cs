namespace School_version1.Models.DTOs
{
    public class StudentAddDto
    { 
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public Guid FacultyId { get; set; }
        public Guid CustomIdentityUserID { get; set; }
    }
}
