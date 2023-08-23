using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class identityLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUser",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUser",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUser",
                table: "Management",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CustomIdentityUser",
                table: "Teachers",
                column: "CustomIdentityUser",
                unique: true,
                filter: "[CustomIdentityUser] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CustomIdentityUser",
                table: "Students",
                column: "CustomIdentityUser",
                unique: true,
                filter: "[CustomIdentityUser] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Management_CustomIdentityUser",
                table: "Management",
                column: "CustomIdentityUser",
                unique: true,
                filter: "[CustomIdentityUser] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Management_AspNetUsers_CustomIdentityUser",
                table: "Management",
                column: "CustomIdentityUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_CustomIdentityUser",
                table: "Students",
                column: "CustomIdentityUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_CustomIdentityUser",
                table: "Teachers",
                column: "CustomIdentityUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Management_AspNetUsers_CustomIdentityUser",
                table: "Management");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_CustomIdentityUser",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_CustomIdentityUser",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CustomIdentityUser",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_CustomIdentityUser",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Management_CustomIdentityUser",
                table: "Management");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUser",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUser",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUser",
                table: "Management");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "AspNetUsers");
        }
    }
}
