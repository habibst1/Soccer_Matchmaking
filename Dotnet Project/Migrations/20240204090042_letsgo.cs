using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnet_Project.Migrations
{
    /// <inheritdoc />
    public partial class letsgo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "adminId",
                table: "Lobbies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_adminId",
                table: "Lobbies",
                column: "adminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lobbies_AspNetUsers_adminId",
                table: "Lobbies",
                column: "adminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lobbies_AspNetUsers_adminId",
                table: "Lobbies");

            migrationBuilder.DropIndex(
                name: "IX_Lobbies_adminId",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "adminId",
                table: "Lobbies");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }
    }
}
