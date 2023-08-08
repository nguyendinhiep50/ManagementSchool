using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class init06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAcademicProgram",
                table: "AcademicPrograms",
                newName: "AcademicProgramName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcademicProgramName",
                table: "AcademicPrograms",
                newName: "NameAcademicProgram");
        }
    }
}
