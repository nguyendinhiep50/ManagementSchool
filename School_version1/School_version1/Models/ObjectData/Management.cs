using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_version1.Models.ObjectData
{
    public class Management : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string ManagementName { get; set; }
        [Required]
        public string ManagementEmail { get; set; }
        [Required]
        public string ManagementPassword { get; set; }
    }
}
