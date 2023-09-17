namespace School_version1.Models.DTOs
{
    public class SubjectGradesDto
    {
        public Guid SubjectGradesId { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public double GPARank1 { get; set; }
        public double GPARank2 { get; set; }
        public double GPARank3 { get; set; }
        public double GPARank4 { get; set; }
        public Boolean PassSubject { get; set; }
    }
}
