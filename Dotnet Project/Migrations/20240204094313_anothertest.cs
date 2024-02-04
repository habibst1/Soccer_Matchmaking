using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnet_Project.Migrations
{
    /// <inheritdoc />
    public partial class anothertest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lobbies_LinkedLobbyId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LobbyId2",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LobbyId2",
                table: "AspNetUsers",
                column: "LobbyId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lobbies_LinkedLobbyId",
                table: "AspNetUsers",
                column: "LinkedLobbyId",
                principalTable: "Lobbies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lobbies_LobbyId2",
                table: "AspNetUsers",
                column: "LobbyId2",
                principalTable: "Lobbies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lobbies_LinkedLobbyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lobbies_LobbyId2",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LobbyId2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LobbyId2",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lobbies_LinkedLobbyId",
                table: "AspNetUsers",
                column: "LinkedLobbyId",
                principalTable: "Lobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
