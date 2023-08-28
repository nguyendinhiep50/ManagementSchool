namespace School_version1.Models.DTOs
{
    public class TeacherAddDto
    {
        public string TeacherName { get; set; }
        public string TeacherImage { get; set; }
        public string TeacherEmail { get; set; }
        public DateTime TeacherBirthDate { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherAdress { get; set; }
        public Guid CustomIdentityUserID { get; set; }
    }
}
