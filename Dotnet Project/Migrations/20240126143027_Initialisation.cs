using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotnetProject.Migrations
{
    /// <inheritdoc />
    public partial class Initialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StadeOwners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StadeId = table.Column<int>(type: "int", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mdp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadeOwners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StadeOwners_Stadiums_StadeId",
                        column: x => x.StadeId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    occupancy = table.Column<bool>(type: "bit", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    starttime = table.Column<DateTime>(name: "start_time", type: "datetime2", nullable: false),
                    endtime = table.Column<DateTime>(name: "end_time", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFull = table.Column<bool>(type: "bit", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lobbies_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mdp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberwins = table.Column<int>(name: "number_wins", type: "int", nullable: false),
                    numberlosses = table.Column<int>(name: "number_losses", type: "int", nullable: false),
                    numberdraws = table.Column<int>(name: "number_draws", type: "int", nullable: false),
                    LinkedLobbyId = table.Column<int>(type: "int", nullable: true),
                    TeamNumber = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    LobbyId = table.Column<int>(type: "int", nullable: true),
                    LobbyId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Lobbies_LinkedLobbyId",
                        column: x => x.LinkedLobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Lobbies_LobbyId1",
                        column: x => x.LobbyId1,
                        principalTable: "Lobbies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "EMail", "IsAdmin", "LinkedLobbyId", "LobbyId", "LobbyId1", "Name", "PhotoPath", "Surname", "TeamNumber", "mdp", "number_draws", "number_losses", "number_wins" },
                values: new object[,]
                {
                    { 1, "player1@example.com", false, null, null, null, "Ala", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 2, "player2@example.com", false, null, null, null, "Taher", "path2", "Doe", 0, "password2", 0, 0, 0 },
                    { 3, "player3@example.com", false, null, null, null, "Habib", "path2", "Doe", 0, "password3", 0, 0, 0 },
                    { 4, "player4@example.com", false, null, null, null, "Fedy", "path2", "Doe", 0, "password4", 0, 0, 0 },
                    { 5, "player5@example.com", false, null, null, null, "Najar", "path2", "Doe", 0, "password5", 0, 0, 0 },
                    { 6, "player6@example.com", false, null, null, null, "Reb3i", "path2", "Doe", 0, "password5", 0, 0, 0 },
                    { 7, "player7@example.com", false, null, null, null, "Ghazi", "path2", "Doe", 0, "password5", 0, 0, 0 },
                    { 8, "player8@example.com", false, null, null, null, "Kamel", "path2", "Doe", 0, "password5", 0, 0, 0 },
                    { 9, "player9@example.com", false, null, null, null, "Karim", "path2", "Doe", 0, "password5", 0, 0, 0 },
                    { 10, "play10@example.com", false, null, null, null, "Samir", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 11, "play11@example.com", false, null, null, null, "Kais", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 12, "play12@example.com", false, null, null, null, "Aziz", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 13, "play13@example.com", false, null, null, null, "Youssef", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 14, "play14@example.com", false, null, null, null, "Hamza", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 15, "play15@example.com", false, null, null, null, "Ali", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 16, "play16@example.com", false, null, null, null, "Mustafa", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 17, "play16@example.com", false, null, null, null, "Elyess", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 18, "play16@example.com", false, null, null, null, "Omar", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 19, "play16@example.com", false, null, null, null, "Ismail", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 20, "play16@example.com", false, null, null, null, "Amine", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 21, "play16@example.com", false, null, null, null, "Talel", "path1", "Doe", 0, "password1", 0, 0, 0 },
                    { 22, "play16@example.com", false, null, null, null, "Chehata", "path1", "Doe", 0, "password1", 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "StadeOwners",
                columns: new[] { "ID", "EMail", "Name", "StadeId", "Surname", "mdp" },
                values: new object[,]
                {
                    { 1, "owner1@example.com", "Owner1", null, "Owner1Surname", "password1" },
                    { 2, "owner2@example.com", "Owner2", null, "Owner2Surname", "password2" }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Description", "Localisation", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "Description1", "Location1", "Stadium1", "path1" },
                    { 2, "Description2", "Location2", "Stadium2", "path2" },
                    { 3, "Description3", "Location3", "Stadium3", "path2" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "StadiumId", "end_time", "occupancy", "start_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 26, 17, 0, 27, 679, DateTimeKind.Local).AddTicks(2288), true, new DateTime(2024, 1, 26, 15, 30, 27, 679, DateTimeKind.Local).AddTicks(2280) },
                    { 2, 2, new DateTime(2024, 1, 26, 17, 0, 27, 679, DateTimeKind.Local).AddTicks(2296), false, new DateTime(2024, 1, 26, 15, 30, 27, 679, DateTimeKind.Local).AddTicks(2295) },
                    { 3, 3, new DateTime(2024, 1, 26, 17, 0, 27, 679, DateTimeKind.Local).AddTicks(2297), false, new DateTime(2024, 1, 26, 15, 30, 27, 679, DateTimeKind.Local).AddTicks(2297) },
                    { 4, 1, new DateTime(2024, 1, 26, 19, 0, 27, 679, DateTimeKind.Local).AddTicks(2299), false, new DateTime(2024, 1, 26, 17, 30, 27, 679, DateTimeKind.Local).AddTicks(2299) },
                    { 5, 2, new DateTime(2024, 1, 26, 19, 0, 27, 679, DateTimeKind.Local).AddTicks(2301), false, new DateTime(2024, 1, 26, 17, 30, 27, 679, DateTimeKind.Local).AddTicks(2301) },
                    { 6, 3, new DateTime(2024, 1, 26, 19, 0, 27, 679, DateTimeKind.Local).AddTicks(2303), false, new DateTime(2024, 1, 26, 17, 30, 27, 679, DateTimeKind.Local).AddTicks(2303) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_TimeSlotId",
                table: "Lobbies",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LinkedLobbyId",
                table: "Players",
                column: "LinkedLobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LobbyId",
                table: "Players",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LobbyId1",
                table: "Players",
                column: "LobbyId1");

            migrationBuilder.CreateIndex(
                name: "IX_StadeOwners_StadeId",
                table: "StadeOwners",
                column: "StadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_StadiumId",
                table: "TimeSlots",
                column: "StadiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "StadeOwners");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
