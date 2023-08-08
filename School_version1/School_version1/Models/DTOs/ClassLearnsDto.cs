namespace School_version1.Models.DTOs
{
    public class ClassLearnsDto
    {
        public string ClassLearnName { get; set; }
        public int ClassLearnEnrollment { get; set; }
        public Guid AcademicProgramId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
