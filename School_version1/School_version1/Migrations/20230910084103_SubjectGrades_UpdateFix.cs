using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class SubjectGrades_UpdateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestScores",
                table: "SubjectGrades",
                newName: "GPARank4");

            migrationBuilder.RenameColumn(
                name: "Point3",
                table: "SubjectGrades",
                newName: "GPARank3");

            migrationBuilder.RenameColumn(
                name: "Point2",
                table: "SubjectGrades",
                newName: "GPARank2");

            migrationBuilder.RenameColumn(
                name: "Point1",
                table: "SubjectGrades",
                newName: "GPARank1");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "SubjectGrades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGrades_StudentId",
                table: "SubjectGrades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Students_StudentId",
                table: "SubjectGrades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Students_StudentId",
                table: "SubjectGrades");

            migrationBuilder.DropIndex(
                name: "IX_SubjectGrades_StudentId",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SubjectGrades");

            migrationBuilder.RenameColumn(
                name: "GPARank4",
                table: "SubjectGrades",
                newName: "TestScores");

            migrationBuilder.RenameColumn(
                name: "GPARank3",
                table: "SubjectGrades",
                newName: "Point3");

            migrationBuilder.RenameColumn(
                name: "GPARank2",
                table: "SubjectGrades",
                newName: "Point2");

            migrationBuilder.RenameColumn(
                name: "GPARank1",
                table: "SubjectGrades",
                newName: "Point1");
        }
    }
}
