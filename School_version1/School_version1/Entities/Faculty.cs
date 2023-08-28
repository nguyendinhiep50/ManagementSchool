using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Faculty : EntityBase
    {
        [Required]
        public string FacultyName { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
