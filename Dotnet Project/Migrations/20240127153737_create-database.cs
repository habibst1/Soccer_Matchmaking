using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetProject.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
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
