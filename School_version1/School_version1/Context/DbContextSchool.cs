using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_version1.Entities;

namespace School_version1.Context
{
    public class DbContextSchool : IdentityDbContext<CustomIdentityUser>
    {
        public DbContextSchool() { }
        public DbContextSchool(DbContextOptions<DbContextSchool> options) : base(options)
        {
        }
        public DbSet<AcademicProgram> AcademicPrograms { get; set; }
        public DbSet<ClassLearn> ClassLearns { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<ListStudentClassLearn> ListStudentClassLearns { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<SubjectGrades> SubjectGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
            .HasOne(s => s.Faculty)
            .WithMany(f => f.Student)
            .HasForeignKey(s => s.FacultyId);
            // Config chitietHD
            //modelBuilder.Entity<SanPham>()
            //    .HasMany(e => e.MaSP)
            //    .WithMany(e => e.MaHD)
            //    .UsingEntity<ChiTietHD>();
            modelBuilder.Entity<Student>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SubjectGrades>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<AcademicProgram>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ClassLearn>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Faculty>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ListStudentClassLearn>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Semester>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Subject>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Teacher>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Management>()
            .Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ListStudentClassLearn>()
           .HasKey(pt => new { pt.Id });

            modelBuilder.Entity<ListStudentClassLearn>()
                        .HasOne(x => x.Student)
                        .WithMany(x => x.ListStudentClassLearns)
                        .HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Restrict);
            //// Cấu hình quan hệ giữa AspNetUsers và Management
            //modelBuilder.Entity<CustomIdentityUser>()
            //    .HasOne(u => u.Management)
            //    .WithOne()
            //    .HasForeignKey<Management>(m => m.AppLogin.Id );

            //// Cấu hình quan hệ giữa AspNetUsers và Teacher
            //modelBuilder.Entity<CustomIdentityUser>()
            //    .HasOne(u => u.Teacher)
            //    .WithOne()
            //    .HasForeignKey<Teacher>(t => t.AppLogin.Id);
            //// Cấu hình quan hệ giữa AspNetUsers và Student
            //modelBuilder.Entity<CustomIdentityUser>()
            //    .HasOne(u => u.Student)
            //    .WithOne()
            //    .HasForeignKey<Student>(t => t.AppLogin.Id);
        }
        public DbSet<Management>? Management { get; set; }

    }
}
