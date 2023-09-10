using System.ComponentModel.DataAnnotations.Schema;

namespace School_version1.Entities
{
    public class SubjectGrades :EntityBase
    {
        public double GPARank1  { get; set; }
        public double GPARank2 { get; set; }
        public double GPARank3 { get; set; }
        public double GPARank4 { get; set; }
        public Boolean PassSubject { get; set; }
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        //[JsonIgnore]
        public virtual Subject Subject { get; set; }
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        //[JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
