using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class addSubjectGrades3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListStudentClassLearns_SubjectGrades_SubjectGradesId",
                table: "ListStudentClassLearns");

            migrationBuilder.DropIndex(
                name: "IX_ListStudentClassLearns_SubjectGradesId",
                table: "ListStudentClassLearns");

            migrationBuilder.DropColumn(
                name: "SubjectGradesId",
                table: "ListStudentClassLearns");

            migrationBuilder.AddColumn<Guid>(
                name: "ListStudentClassLearnId",
                table: "SubjectGrades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGrades_ListStudentClassLearnId",
                table: "SubjectGrades",
                column: "ListStudentClassLearnId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_ListStudentClassLearns_ListStudentClassLearnId",
                table: "SubjectGrades",
                column: "ListStudentClassLearnId",
                principalTable: "ListStudentClassLearns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_ListStudentClassLearns_ListStudentClassLearnId",
                table: "SubjectGrades");

            migrationBuilder.DropIndex(
                name: "IX_SubjectGrades_ListStudentClassLearnId",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "ListStudentClassLearnId",
                table: "SubjectGrades");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectGradesId",
                table: "ListStudentClassLearns",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
