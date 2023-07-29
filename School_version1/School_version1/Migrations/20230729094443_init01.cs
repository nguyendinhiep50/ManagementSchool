using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Management",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ManagementName = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    ManagementEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagementPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemesterDayBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemesterDayEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemesterStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    StudentDateCome = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentStatus = table.Column<bool>(type: "bit", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    SubjectName = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    SubjectCredit = table.Column<int>(type: "int", nullable: false),
                    SubjectMandatory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TeacherName = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    TeacherImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherEmail = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    TeacherPassword = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    TeacherBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAdress = table.Column<string>(type: "Nvarchar(200)", nullable: false),
                    TeacherStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    StudentName = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    StudentImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEmail = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    StudentPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    StudentDateCome = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentStatus = table.Column<bool>(type: "bit", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TimeEndAcademicProgram = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassLearns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ClassLearnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassLearnEnrollment = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLearns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassLearns_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassLearns_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListStudentClassLearns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassLearnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListStudentClassLearns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListStudentClassLearns_ClassLearns_ClassLearnId",
                        column: x => x.ClassLearnId,
                        principalTable: "ClassLearns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListStudentClassLearns_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_FacultyId",
                table: "AcademicPrograms",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_SemesterId",
                table: "AcademicPrograms",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_SubjectId",
                table: "AcademicPrograms",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLearns_AcademicProgramId",
                table: "ClassLearns",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLearns_TeacherId",
                table: "ClassLearns",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ListStudentClassLearns_ClassLearnId",
                table: "ListStudentClassLearns",
                column: "ClassLearnId");

            migrationBuilder.CreateIndex(
                name: "IX_ListStudentClassLearns_StudentId",
                table: "ListStudentClassLearns",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListStudentClassLearns");

            migrationBuilder.DropTable(
                name: "Management");

            migrationBuilder.DropTable(
                name: "StudentViews");

            migrationBuilder.DropTable(
                name: "ClassLearns");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
