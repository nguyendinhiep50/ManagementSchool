using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Course: EntityBase
    {
        [Required]
        public string NameCourse { get; set; }
    }
}
