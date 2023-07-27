using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string PasswordStudent { get; set; }
        [Required]
        public DateTime BirthDateStudent { get; set; }
        public string PhoneStudent { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(200)")]
        public string AdressStudent { get; set; }
        [Required]
        public int SchoolYear { get; set; }
        [Required]
        public DateTime DateComeShoool { get; set; }
        [Required]
        public bool StatusStudent { get; set; }

    }
}
