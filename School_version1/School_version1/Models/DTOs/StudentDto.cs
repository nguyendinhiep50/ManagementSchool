namespace School_version1.Models.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public string StudentImage { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string FacultyName { get; set; }

    }
}
