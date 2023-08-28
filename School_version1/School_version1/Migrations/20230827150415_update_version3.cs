using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class update_version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Management_AspNetUsers_CustomIdentityUser",
                table: "Management");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_CustomIdentityUser",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CustomIdentityUser",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Management_CustomIdentityUser",
                table: "Management");

            migrationBuilder.RenameColumn(
                name: "CustomIdentityUser",
                table: "Teachers",
                newName: "CustomIdentityUserID");

            migrationBuilder.RenameColumn(
                name: "CustomIdentityUser",
                table: "Management",
                newName: "CustomIdentityUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CustomIdentityUserID",
                table: "Teachers",
                column: "CustomIdentityUserID",
                unique: true,
                filter: "[CustomIdentityUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Management_CustomIdentityUserID",
                table: "Management",
                column: "CustomIdentityUserID",
                unique: true,
                filter: "[CustomIdentityUserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Management_AspNetUsers_CustomIdentityUserID",
                table: "Management",
                column: "CustomIdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_CustomIdentityUserID",
                table: "Teachers",
                column: "CustomIdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Management_AspNetUsers_CustomIdentityUserID",
                table: "Management");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_CustomIdentityUserID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CustomIdentityUserID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Management_CustomIdentityUserID",
                table: "Management");

            migrationBuilder.RenameColumn(
                name: "CustomIdentityUserID",
                table: "Teachers",
                newName: "CustomIdentityUser");

            migrationBuilder.RenameColumn(
                name: "CustomIdentityUserID",
                table: "Management",
                newName: "CustomIdentityUser");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CustomIdentityUser",
                table: "Teachers",
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
                name: "FK_Teachers_AspNetUsers_CustomIdentityUser",
                table: "Teachers",
                column: "CustomIdentityUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
