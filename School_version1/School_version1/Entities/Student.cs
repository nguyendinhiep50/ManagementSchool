using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace School_version1.Entities
{
    public class Student : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string StudentName { get; set; }
        public string StudentImage { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string StudentEmail { get; set; }
        [DefaultValue("12345")]
        public string StudentPassword { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAdress { get; set; }
        [JsonIgnore]
        [DefaultValue(0)]
        public int SchoolYear { get; set; }
        public DateTime? StudentDateCome { get; set; }
        [JsonIgnore]
        public bool? StudentStatus { get; set; }
        [ForeignKey("Faculty")]
        public Guid FacultyId { get; set; }
        [JsonIgnore]
        public virtual Faculty Faculty { get; set; }
        [JsonIgnore]
        public virtual ICollection<ListStudentClassLearn> ListStudentClassLearns { get; set; }
    }
}
