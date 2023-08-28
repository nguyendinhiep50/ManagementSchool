using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class Management : EntityBase
    {
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string ManagementName { get; set; }
        [ForeignKey("CustomIdentityUser")]
        public string CustomIdentityUserID { get; set; }
        [JsonIgnore]
        public virtual CustomIdentityUser CustomIdentityUser { get; set; }
    }
}
