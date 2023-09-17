using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_version1.Entities
{
    public class SubjectGrades :EntityBase
    {
        [Range(0, 10, ErrorMessage = "GPARank1 must be between 0 and 10.")]
        [DefaultValue(0)]
        public double GPARank1  { get; set; }
        [Range(0, 10, ErrorMessage = "GPARank2 must be between 0 and 10.")]
        [DefaultValue(0)]
        public double GPARank2 { get; set; }
        [Range(0, 10, ErrorMessage = "GPARank3 must be between 0 and 10.")]
        [DefaultValue(0)]
        public double GPARank3 { get; set; }
        [Range(0, 10, ErrorMessage = "GPARank4 must be between 0 and 10.")]
        [DefaultValue(0)]
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
