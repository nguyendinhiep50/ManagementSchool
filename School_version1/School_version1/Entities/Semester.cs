using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class Semester : EntityBase
    {
        [Required]
        public string SemesterName { get; set; }
        [Required]
        public DateTime SemesterDayBegin { get; set; }
        [Required]
        public DateTime SemesterDayEnd { get; set; }
        [Required]
        public bool SemesterStatus { get; set; }
    }
}
