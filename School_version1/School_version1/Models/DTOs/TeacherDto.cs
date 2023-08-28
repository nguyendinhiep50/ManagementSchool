namespace School_version1.Models.DTOs
{
    public class TeacherDto
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherImage { get; set; }
        public DateTime TeacherBirthDate { get; set; }
        public string TeacherAdress { get; set; }
    }
}
