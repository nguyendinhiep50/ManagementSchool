using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class ListStudentClassLearn : EntityBase
    {
        [Key]
        public Guid IdListStudentClassLearn { get; set; }
        [ForeignKey("Student")]
        public Guid IdStudent { get; set; }
        [JsonIgnore]

        public virtual Student? Student { get; set; }

        [ForeignKey("ClassLearn")]
        public Guid IdClassLearn { get; set; }
        [JsonIgnore]
        public virtual ClassLearn? ClassLearn { get; set; }
    }
}
