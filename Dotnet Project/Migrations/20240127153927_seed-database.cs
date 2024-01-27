using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotnetProject.Migrations
{
    /// <inheritdoc />
    public partial class seeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, 1, new DateTime(2024, 1, 27, 18, 9, 27, 353, DateTimeKind.Local).AddTicks(3049), true, new DateTime(2024, 1, 27, 16, 39, 27, 353, DateTimeKind.Local).AddTicks(2992) },
                    { 2, 2, new DateTime(2024, 1, 27, 18, 9, 27, 353, DateTimeKind.Local).AddTicks(3059), false, new DateTime(2024, 1, 27, 16, 39, 27, 353, DateTimeKind.Local).AddTicks(3057) },
                    { 3, 3, new DateTime(2024, 1, 27, 18, 9, 27, 353, DateTimeKind.Local).AddTicks(3063), false, new DateTime(2024, 1, 27, 16, 39, 27, 353, DateTimeKind.Local).AddTicks(3062) },
                    { 4, 1, new DateTime(2024, 1, 27, 20, 9, 27, 353, DateTimeKind.Local).AddTicks(3068), false, new DateTime(2024, 1, 27, 18, 39, 27, 353, DateTimeKind.Local).AddTicks(3066) },
                    { 5, 2, new DateTime(2024, 1, 27, 20, 9, 27, 353, DateTimeKind.Local).AddTicks(3072), false, new DateTime(2024, 1, 27, 18, 39, 27, 353, DateTimeKind.Local).AddTicks(3071) },
                    { 6, 3, new DateTime(2024, 1, 27, 20, 9, 27, 353, DateTimeKind.Local).AddTicks(3077), false, new DateTime(2024, 1, 27, 18, 39, 27, 353, DateTimeKind.Local).AddTicks(3075) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StadeOwners",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StadeOwners",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
