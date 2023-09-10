namespace School_version1.Models.DTOs
{
    public class AcademicProgramListName
    {
        public Guid AcademicProgramId { get; set; }
        public string AcademicProgramName { get; set; }
        public DateTime AcademicProgramTimeEnd { get; set; }
        public string FacultyName { get; set; }
        public string SubjectName { get; set; }
        public string SemesterName { get; set; }

    }
}
