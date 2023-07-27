using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Semester : EntityBase
    {
        [Required]
        public string NameSemester { get; set; }
        [Required]
        public DateTime DayBeginSemester { get; set; }
        [Required]
        public DateTime DayEndSemester { get; set; }
        [Required]
        public bool StatusSemester { get; set; }
    }
}
