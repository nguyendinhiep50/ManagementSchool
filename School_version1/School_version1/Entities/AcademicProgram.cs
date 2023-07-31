using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class AcademicProgram : EntityBase
    {
        // tạo key chính
        // chứa học kì
        // chứa môn học số nhiều
        // tạo thuộc tính khóa lại đăng ký học môn này khi kết thúc thời gian đăng ký
        // chứa lớp học 
        // dựa vào học kì và lớp học để lọc ra những gì cần học trong năm học đó

        [Required]
        public DateTime TimeEndAcademicProgram { get; set; }
        [ForeignKey("Semester")]
        public Guid SemesterId { get; set; }
        [JsonIgnore]
        public virtual Semester Semester { get; set; }
        [ForeignKey("Faculty")]
        public Guid FacultyId { get; set; }
        [JsonIgnore]
        public virtual Faculty Faculty { get; set; }
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        [JsonIgnore]
        public virtual Subject Subject { get; set; }

    }
}
