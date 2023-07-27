using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
