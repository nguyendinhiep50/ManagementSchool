namespace School_version1.Models.DTOs
{
    public class AcademicProgramAddDto
    {
        public string AcademicProgramName { get; set; }
        public DateTime AcademicProgramTimeEnd { get; set; }
        public Guid SemesterId { get; set; }
        public Guid FacultyId { get; set; }
        public Guid SubjectId { get; set; }

    }
}
