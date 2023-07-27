using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class init05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Management",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    NameManagement = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    EmailManagement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordManagement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Management");
        }
    }
}
