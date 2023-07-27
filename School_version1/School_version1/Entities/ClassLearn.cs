using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School_version1.Entities
{
    public class ClassLearn : EntityBase
    {
        public string NameClassLearn { get; set; }
        [Required]
        public int EnrollmentClass { get; set; }  // sỉ số
        [ForeignKey("AcademicProgram")]
        public Guid IdAcademicProgram { get; set; }
        [JsonIgnore]
        public virtual AcademicProgram? AcademicProgram { get; set; }
        [ForeignKey("Teacher")]
        public Guid IdTeacher { get; set; }
        [JsonIgnore]
        public virtual Teacher? Teacher { get; set; }

        // lấy khóa  của AcacdemicProgram để hiển thị chương trình học kì đó
        // chứa cô giáo để dạy có thể để cho cô giáo chọn môn dạy có thể null

        // tạo ra buổi dạy thứ mấy và mấy giờ

        // chưa học sinh và có thể tự thêm vào 

        // có thuộc tính khóa lại sau thời gian kết thúc đăng ký

        // Teacher :1
        // student many
        // Semester :1
    }
}
