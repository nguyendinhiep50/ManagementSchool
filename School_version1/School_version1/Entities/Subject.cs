using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Subject : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string NameSubject { get; set; }
        [Required]
        public int CreditSubject { get; set; }
        [Required]
        public bool MandatorySubject { get; set; }
    }
}
