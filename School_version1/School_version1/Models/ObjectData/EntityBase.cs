using System.ComponentModel.DataAnnotations;

namespace School_version1.Models.ObjectData
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
