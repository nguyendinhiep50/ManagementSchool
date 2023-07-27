﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School_version1.Context;

#nullable disable

namespace School_version1.Migrations
{
    [DbContext(typeof(DbContextSchool))]
    [Migration("20230727030503_init03")]
    partial class init03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("School_version1.Entities.AcademicProgram", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IdCourese")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSemester")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSubject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeEndAcademicProgram")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdCourese");

                    b.HasIndex("IdSemester");

                    b.HasIndex("IdSubject");

                    b.ToTable("AcademicPrograms");
                });

            modelBuilder.Entity("School_version1.Entities.ClassLearn", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("EnrollmentClass")
                        .HasColumnType("int");

                    b.Property<Guid>("IdAcademicProgram")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTeacher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameClassLearn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAcademicProgram");

                    b.HasIndex("IdTeacher");

                    b.ToTable("ClassLearns");
                });

            modelBuilder.Entity("School_version1.Entities.Course", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("NameCourse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("School_version1.Entities.ListStudentClassLearn", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IdClassLearn")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdListStudentClassLearn")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdStudent")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdClassLearn");

                    b.HasIndex("IdStudent");

                    b.ToTable("ListStudentClassLearns");
                });

            modelBuilder.Entity("School_version1.Entities.Semester", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("DayBeginSemester")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DayEndSemester")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSemester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusSemester")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("School_version1.Entities.Student", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AdressStudent")
                        .IsRequired()
                        .HasColumnType("Nvarchar(200)");

                    b.Property<DateTime>("BirthDateStudent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateComeShoool")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailStudent")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("ImageStudent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameStudent")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("PasswordStudent")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("PhoneStudent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("int");

                    b.Property<bool>("StatusStudent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School_version1.Entities.Subject", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("CreditSubject")
                        .HasColumnType("int");

                    b.Property<bool>("MandatorySubject")
                        .HasColumnType("bit");

                    b.Property<string>("NameSubject")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("School_version1.Entities.Teacher", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AdressTeacher")
                        .IsRequired()
                        .HasColumnType("Nvarchar(200)");

                    b.Property<DateTime>("BirthDateTeacher")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailTeacher")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("ImageTeacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameTeacher")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("PasswordTeacher")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("PhoneTeacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusTeacher")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("School_version1.Entities.AcademicProgram", b =>
                {
                    b.HasOne("School_version1.Entities.Course", "Courese")
                        .WithMany()
                        .HasForeignKey("IdCourese")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("IdSemester")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courese");

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School_version1.Entities.ClassLearn", b =>
                {
                    b.HasOne("School_version1.Entities.AcademicProgram", "AcademicProgram")
                        .WithMany()
                        .HasForeignKey("IdAcademicProgram")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicProgram");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_version1.Entities.ListStudentClassLearn", b =>
                {
                    b.HasOne("School_version1.Entities.ClassLearn", "ClassLearn")
                        .WithMany()
                        .HasForeignKey("IdClassLearn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassLearn");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
