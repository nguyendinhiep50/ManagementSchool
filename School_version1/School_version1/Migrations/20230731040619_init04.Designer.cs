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
    [Migration("20230731040619_init04")]
    partial class init04
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SemesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeEndAcademicProgram")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("AcademicPrograms");
                });

            modelBuilder.Entity("School_version1.Entities.ClassLearn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AcademicProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassLearnEnrollment")
                        .HasColumnType("int");

                    b.Property<string>("ClassLearnName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AcademicProgramId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassLearns");
                });

            modelBuilder.Entity("School_version1.Entities.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("School_version1.Entities.ListStudentClassLearn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ClassLearnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassLearnId");

                    b.HasIndex("StudentId");

                    b.ToTable("ListStudentClassLearns");
                });

            modelBuilder.Entity("School_version1.Entities.Management", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ManagementEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagementName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("ManagementPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Management");
                });

            modelBuilder.Entity("School_version1.Entities.Semester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("SemesterDayBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SemesterDayEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SemesterStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("School_version1.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("int");

                    b.Property<string>("StudentAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StudentBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StudentDateCome")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("StudentImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("StudentPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("StudentStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School_version1.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("SubjectCredit")
                        .HasColumnType("int");

                    b.Property<bool>("SubjectMandatory")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("School_version1.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("TeacherAdress")
                        .IsRequired()
                        .HasColumnType("Nvarchar(200)");

                    b.Property<DateTime>("TeacherBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherEmail")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("TeacherImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("TeacherPassword")
                        .HasColumnType("Nvarchar(100)");

                    b.Property<string>("TeacherPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TeacherStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("School_version1.Entities.AcademicProgram", b =>
                {
                    b.HasOne("School_version1.Entities.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School_version1.Entities.ClassLearn", b =>
                {
                    b.HasOne("School_version1.Entities.AcademicProgram", "AcademicProgram")
                        .WithMany()
                        .HasForeignKey("AcademicProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicProgram");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_version1.Entities.ListStudentClassLearn", b =>
                {
                    b.HasOne("School_version1.Entities.ClassLearn", "ClassLearn")
                        .WithMany()
                        .HasForeignKey("ClassLearnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_version1.Entities.Student", "Student")
                        .WithMany("ListStudentClassLearns")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClassLearn");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("School_version1.Entities.Student", b =>
                {
                    b.HasOne("School_version1.Entities.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("School_version1.Entities.Student", b =>
                {
                    b.Navigation("ListStudentClassLearns");
                });
#pragma warning restore 612, 618
        }
    }
}
