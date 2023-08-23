using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class changeTableUseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherEmail",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherPassword",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherPhone",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentPassword",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentPhone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ManagementEmail",
                table: "Management");

            migrationBuilder.DropColumn(
                name: "ManagementPassword",
                table: "Management");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherEmail",
                table: "Teachers",
                type: "Nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherPassword",
                table: "Teachers",
                type: "Nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherPhone",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "Students",
                type: "Nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentPassword",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentPhone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagementEmail",
                table: "Management",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagementPassword",
                table: "Management",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
