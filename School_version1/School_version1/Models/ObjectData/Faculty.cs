using System.ComponentModel.DataAnnotations;

namespace School_version1.Models.ObjectData
{
    public class Faculty : EntityBase
    {
        [Required]
        public string FacultyName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
