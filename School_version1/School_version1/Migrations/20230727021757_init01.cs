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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSemester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayBeginSemester = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayEndSemester = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSemester = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameStudent = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    ImageStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailStudent = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    PasswordStudent = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    BirthDateStudent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressStudent = table.Column<string>(type: "Nvarchar(200)", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    DateComeShoool = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusStudent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSubject = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    CreditSubject = table.Column<int>(type: "int", nullable: false),
                    MandatorySubject = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameTeacher = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    ImageTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailTeacher = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    PasswordTeacher = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    BirthDateTeacher = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressTeacher = table.Column<string>(type: "Nvarchar(200)", nullable: false),
                    StatusTeacher = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeEndAcademicProgram = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSemester = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCourese = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Courses_IdCourese",
                        column: x => x.IdCourese,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Semesters_IdSemester",
                        column: x => x.IdSemester,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassLearns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameClassLearn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentClass = table.Column<int>(type: "int", nullable: false),
                    IdAcademicProgram = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTeacher = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLearns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassLearns_AcademicPrograms_IdAcademicProgram",
                        column: x => x.IdAcademicProgram,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassLearns_Teachers_IdTeacher",
                        column: x => x.IdTeacher,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListStudentClassLearns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdListStudentClassLearn = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClassLearn = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListStudentClassLearns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListStudentClassLearns_ClassLearns_IdClassLearn",
                        column: x => x.IdClassLearn,
                        principalTable: "ClassLearns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListStudentClassLearns_Students_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_IdCourese",
                table: "AcademicPrograms",
                column: "IdCourese");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_IdSemester",
                table: "AcademicPrograms",
                column: "IdSemester");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_IdSubject",
                table: "AcademicPrograms",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLearns_IdAcademicProgram",
                table: "ClassLearns",
                column: "IdAcademicProgram");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLearns_IdTeacher",
                table: "ClassLearns",
                column: "IdTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_ListStudentClassLearns_IdClassLearn",
                table: "ListStudentClassLearns",
                column: "IdClassLearn");

            migrationBuilder.CreateIndex(
                name: "IX_ListStudentClassLearns_IdStudent",
                table: "ListStudentClassLearns",
                column: "IdStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListStudentClassLearns");

            migrationBuilder.DropTable(
                name: "ClassLearns");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
