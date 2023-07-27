using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class Student : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string NameStudent { get; set; }
        public string ImageStudent { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string EmailStudent { get; set; }
        public string PasswordStudent { get; set; }
        public DateTime BirthDateStudent { get; set; }
        public string PhoneStudent { get; set; }
        public string AdressStudent { get; set; }
        public int SchoolYear { get; set; }
        [Required]
        public DateTime DateComeShoool { get; set; }
        [Required]
        public bool StatusStudent { get; set; }
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        [JsonIgnore]
        public virtual Course? Course { get; set; }
        [JsonIgnore]
        public virtual ICollection<ListStudentClassLearn>? ListStudentClassLearns { get; set; }
    }
}
