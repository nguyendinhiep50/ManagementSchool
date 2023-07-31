using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class ListStudentClassLearn : EntityBase
    {
        public Guid StudentId { get; set; }
        [JsonIgnore]

        public virtual Student Student { get; set; }

        [ForeignKey("ClassLearn")]
        public Guid ClassLearnId { get; set; }
        [JsonIgnore]
        public virtual ClassLearn ClassLearn { get; set; }
    }
}
