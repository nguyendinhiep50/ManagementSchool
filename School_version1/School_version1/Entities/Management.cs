using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_version1.Entities
{
    public class Management : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string NameManagement { get; set; }
        [Required]
        public string EmailManagement { get; set; }
        [Required]
        public string PasswordManagement { get; set; }
    }
}
