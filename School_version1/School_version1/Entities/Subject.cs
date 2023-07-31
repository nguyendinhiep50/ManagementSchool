using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Subject : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string SubjectName { get; set; }
        [Required]
        public int SubjectCredit { get; set; }
        [Required]
        public bool SubjectMandatory { get; set; }
    }
}
