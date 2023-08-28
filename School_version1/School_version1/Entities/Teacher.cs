using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class Teacher : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string TeacherName { get; set; }
        public string TeacherImage { get; set; } 
        [Required]
        public DateTime TeacherBirthDate { get; set; } 
        [Required]
        [Column(TypeName = "Nvarchar(200)")]
        public string TeacherAdress { get; set; }
        [DefaultValue(true)]
        public bool TeacherStatus { get; set; }
        [ForeignKey("CustomIdentityUser")]
        public string CustomIdentityUserID { get; set; }
        [JsonIgnore]
        public virtual CustomIdentityUser CustomIdentityUser { get; set; }
    }
}
