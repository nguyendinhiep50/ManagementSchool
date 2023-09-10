using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class addSubjectGrades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubjectGradesId",
                table: "ListStudentClassLearns",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubjectGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Point1 = table.Column<double>(type: "float", nullable: false),
                    Point2 = table.Column<double>(type: "float", nullable: false),
                    Point3 = table.Column<double>(type: "float", nullable: false),
                    TestScores = table.Column<double>(type: "float", nullable: false),
                    PassSubject = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGrades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListStudentClassLearns_SubjectGradesId",
                table: "ListStudentClassLearns",
                column: "SubjectGradesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListStudentClassLearns_SubjectGrades_SubjectGradesId",
                table: "ListStudentClassLearns",
                column: "SubjectGradesId",
                principalTable: "SubjectGrades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListStudentClassLearns_SubjectGrades_SubjectGradesId",
                table: "ListStudentClassLearns");

            migrationBuilder.DropTable(
                name: "SubjectGrades");

            migrationBuilder.DropIndex(
                name: "IX_ListStudentClassLearns_SubjectGradesId",
                table: "ListStudentClassLearns");

            migrationBuilder.DropColumn(
                name: "SubjectGradesId",
                table: "ListStudentClassLearns");
        }
    }
}
