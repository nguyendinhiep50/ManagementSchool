using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Teacher : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string NameTeacher { get; set; }
        public string ImageTeacher { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string EmailTeacher { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string PasswordTeacher { get; set; }
        [Required]
        public DateTime BirthDateTeacher { get; set; }
        public string PhoneTeacher { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(200)")]
        public string AdressTeacher { get; set; }
        [Required]
        public bool StatusTeacher { get; set; }
    }
}
