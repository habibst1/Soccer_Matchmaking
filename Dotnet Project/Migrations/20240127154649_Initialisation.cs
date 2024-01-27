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
                    { 6, "player6@example.com", false, null, null, null, "Reb3i", "path2", "Doe", 0, "password6", 0, 0, 0 },
                    { 7, "player7@example.com", false, null, null, null, "Ghazi", "path2", "Doe", 0, "password7", 0, 0, 0 },
                    { 8, "player8@example.com", false, null, null, null, "Kamel", "path2", "Doe", 0, "password8", 0, 0, 0 },
                    { 9, "player9@example.com", false, null, null, null, "Karim", "path2", "Doe", 0, "password9", 0, 0, 0 },
                    { 10, "play10@example.com", false, null, null, null, "Samir", "path1", "Doe", 0, "password10", 0, 0, 0 },
                    { 11, "play11@example.com", false, null, null, null, "Kais", "path1", "Doe", 0, "password11", 0, 0, 0 },
                    { 12, "play12@example.com", false, null, null, null, "Aziz", "path1", "Doe", 0, "password12", 0, 0, 0 },
                    { 13, "play13@example.com", false, null, null, null, "Youssef", "path1", "Doe", 0, "password13", 0, 0, 0 },
                    { 14, "play14@example.com", false, null, null, null, "Hamza", "path1", "Doe", 0, "password14", 0, 0, 0 },
                    { 15, "play15@example.com", false, null, null, null, "Ali", "path1", "Doe", 0, "password15", 0, 0, 0 },
                    { 16, "play16@example.com", false, null, null, null, "Mustafa", "path1", "Doe", 0, "password16", 0, 0, 0 },
                    { 17, "play17@example.com", false, null, null, null, "Elyess", "path1", "Doe", 0, "password17", 0, 0, 0 },
                    { 18, "play18@example.com", false, null, null, null, "Omar", "path1", "Doe", 0, "password18", 0, 0, 0 },
                    { 19, "play19@example.com", false, null, null, null, "Ismail", "path1", "Doe", 0, "password19", 0, 0, 0 },
                    { 20, "play20@example.com", false, null, null, null, "Amine", "path1", "Doe", 0, "password20", 0, 0, 0 },
                    { 21, "play21@example.com", false, null, null, null, "Talel", "path1", "Doe", 0, "passwor21", 0, 0, 0 },
                    { 22, "play22@example.com", false, null, null, null, "Yahya", "path1", "Doe", 0, "password22", 0, 0, 0 },
                    { 23, "play23@example.com", false, null, null, null, "Skander", "path1", "Doe", 0, "password23", 0, 0, 0 },
                    { 24, "play24@example.com", false, null, null, null, "Omar", "path1", "Doe", 0, "password24", 0, 0, 0 },
                    { 25, "play25@example.com", false, null, null, null, "Zahran", "path1", "Doe", 0, "password25", 0, 0, 0 },
                    { 26, "play26@example.com", false, null, null, null, "Mohamed", "path1", "Doe", 0, "password26", 0, 0, 0 },
                    { 27, "play27@example.com", false, null, null, null, "Fethi", "path1", "Doe", 0, "password27", 0, 0, 0 },
                    { 28, "play28@example.com", false, null, null, null, "Adem", "path1", "Doe", 0, "password28", 0, 0, 0 },
                    { 29, "play29@example.com", false, null, null, null, "Ahmed", "path1", "Doe", 0, "password29", 0, 0, 0 },
                    { 30, "play30@example.com", false, null, null, null, "Ayhem", "path1", "Doe", 0, "password30", 0, 0, 0 },
                    { 31, "play31@example.com", false, null, null, null, "Abderrahmen", "path1", "Doe", 0, "password31", 0, 0, 0 },
                    { 32, "play32@example.com", false, null, null, null, "Hamdi", "path1", "Doe", 0, "password32", 0, 0, 0 },
                    { 33, "play33@example.com", false, null, null, null, "Majd", "path1", "Doe", 0, "password33", 0, 0, 0 },
                    { 34, "play34@example.com", false, null, null, null, "Bachar", "path1", "Doe", 0, "password34", 0, 0, 0 },
                    { 35, "play35@example.com", false, null, null, null, "Oussama", "path1", "Doe", 0, "password35", 0, 0, 0 }
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
                    { 1, "CHOUF 3CHIRI A9WA STADE F TUNIS KAMLA W YOUFA LA7DITH", "Monastir", "May Land", "Images/StadeMay.png" },
                    { 2, "A9WA STADE FEL 3ASSMA", "Route Géant", "Five Stars", "Images/StadeFive.png" },
                    { 3, "A5YEB STADE F TUNIS KAMLA", "Charguia", "Stade Charguia", "Images/StadeCharguia.png" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "StadiumId", "end_time", "occupancy", "start_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 27, 18, 16, 49, 61, DateTimeKind.Local).AddTicks(9874), true, new DateTime(2024, 1, 27, 16, 46, 49, 61, DateTimeKind.Local).AddTicks(9864) },
                    { 2, 2, new DateTime(2024, 1, 27, 18, 16, 49, 61, DateTimeKind.Local).AddTicks(9883), false, new DateTime(2024, 1, 27, 16, 46, 49, 61, DateTimeKind.Local).AddTicks(9883) },
                    { 3, 3, new DateTime(2024, 1, 27, 18, 16, 49, 61, DateTimeKind.Local).AddTicks(9885), false, new DateTime(2024, 1, 27, 16, 46, 49, 61, DateTimeKind.Local).AddTicks(9885) },
                    { 4, 1, new DateTime(2024, 1, 27, 20, 16, 49, 61, DateTimeKind.Local).AddTicks(9888), false, new DateTime(2024, 1, 27, 18, 46, 49, 61, DateTimeKind.Local).AddTicks(9886) },
                    { 5, 2, new DateTime(2024, 1, 27, 20, 16, 49, 61, DateTimeKind.Local).AddTicks(9889), false, new DateTime(2024, 1, 27, 18, 46, 49, 61, DateTimeKind.Local).AddTicks(9889) },
                    { 6, 3, new DateTime(2024, 1, 27, 20, 16, 49, 61, DateTimeKind.Local).AddTicks(9891), false, new DateTime(2024, 1, 27, 18, 46, 49, 61, DateTimeKind.Local).AddTicks(9891) }
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
