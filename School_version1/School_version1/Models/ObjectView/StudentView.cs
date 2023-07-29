namespace School_version1.Models.ObjectView
{
    public class StudentView
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public string StudentImage { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPassword { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAdress { get; set; }
        public int SchoolYear { get; set; }
        public DateTime? StudentDateCome { get; set; }
        public bool? StudentStatus { get; set; }
        public Guid FacultyId { get; set; }
    }
}
