using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace School_version1.Models.ObjectData
{
    public class Teacher : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string TeacherName { get; set; }
        public string TeacherImage { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string TeacherEmail { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        [DefaultValue("12345")]
        public string TeacherPassword { get; set; }
        [Required]
        public DateTime TeacherBirthDate { get; set; }
        public string TeacherPhone { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(200)")]
        public string TeacherAdress { get; set; }
        [DefaultValue(true)]
        public bool TeacherStatus { get; set; }
    }
}
