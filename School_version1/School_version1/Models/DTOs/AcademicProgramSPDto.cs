namespace School_version1.Models.DTOs
{
    public class AcademicProgramSPDto
    {
        public Guid SubjectId { get; set; }
        public string FacultyName { get; set; }
        public string SubjectName { get; set; }
        public int SubjectCredit { get; set; }
        public bool SubjectMandatory { get; set; }
    }
}
