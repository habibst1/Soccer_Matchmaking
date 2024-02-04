using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dotnet_Project.Migrations
{
    /// <inheritdoc />
    public partial class Initialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 7);

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

            migrationBuilder.AddColumn<int>(
                name: "nbminutes",
                table: "Stadiums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "prix",
                table: "Stadiums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbminutes",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "prix",
                table: "Stadiums");

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Description", "Localisation", "Name", "PhotoPath", "PhotoPath2", "exactLocalisation" },
                values: new object[,]
                {
                    { 1, "CHOUF 3CHIRI A9WA STADE F TUNIS KAMLA W YOUFA LA7DITH", "Monastir", "May Land", "Images/StadeMay.png", "Images/StadeMay2.png", "https://maps.app.goo.gl/qfwmuN7oYvZAHxgo6" },
                    { 2, "A9WA STADE FEL 3ASSMA", "Route De Sidi Younes El Borj", "Five Stars", "Images/StadeFive.png", "/Images/StadeFive2.png", "https://maps.app.goo.gl/JuCkdWuti8xPFwsE9" },
                    { 3, "A5YEB STADE F TUNIS KAMLA", "Charguia", "Stade Charguia", "Images/StadeCharguia.png", "Images/StadeCharguia2.png", "https://maps.app.goo.gl/SYJ6qQaWXY9MkE7XA" },
                    { 4, "AWEL STADE F MAHDIA", "Mahdia", "MStadium", "Images/MStadium.png", "Images/MStadium2.png", "https://maps.app.goo.gl/k5BGdbc26YHUTnsy6" },
                    { 5, "A7SSEN STADE F MAHDIA", "Rejiche", "Parc Des Princes", "Images/PDP.png", "Images/PDP2.png", "https://maps.app.goo.gl/YqEoZrBDytUnh2Te9" },
                    { 6, "STADE F WOST 7OMMA T5AWEF ", "Monastir", "Al Kahna", "Images/Kahna.png", "Images/Kahna2.png", "https://maps.app.goo.gl/pHnjSerugXFYSRE39" },
                    { 7, "EKTICHAF JDID", "Monastir", "Stade Sahara Beach", "Images/Sahara.png", "Images/Sahara2.png", "https://maps.app.goo.gl/UGkynYQKBK7Mai9U6" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "StadiumId", "end_time", "occupancy", "start_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 3, 1, 59, 6, 352, DateTimeKind.Local).AddTicks(8173), true, new DateTime(2024, 2, 3, 0, 29, 6, 352, DateTimeKind.Local).AddTicks(8112) },
                    { 2, 2, new DateTime(2024, 2, 3, 1, 59, 6, 352, DateTimeKind.Local).AddTicks(8182), false, new DateTime(2024, 2, 3, 0, 29, 6, 352, DateTimeKind.Local).AddTicks(8180) },
                    { 3, 3, new DateTime(2024, 2, 3, 1, 59, 6, 352, DateTimeKind.Local).AddTicks(8186), false, new DateTime(2024, 2, 3, 0, 29, 6, 352, DateTimeKind.Local).AddTicks(8185) },
                    { 4, 1, new DateTime(2024, 2, 3, 3, 59, 6, 352, DateTimeKind.Local).AddTicks(8190), false, new DateTime(2024, 2, 3, 2, 29, 6, 352, DateTimeKind.Local).AddTicks(8188) },
                    { 5, 2, new DateTime(2024, 2, 3, 3, 59, 6, 352, DateTimeKind.Local).AddTicks(8194), false, new DateTime(2024, 2, 3, 2, 29, 6, 352, DateTimeKind.Local).AddTicks(8192) },
                    { 6, 3, new DateTime(2024, 2, 3, 3, 59, 6, 352, DateTimeKind.Local).AddTicks(8198), false, new DateTime(2024, 2, 3, 2, 29, 6, 352, DateTimeKind.Local).AddTicks(8196) }
                });
        }
    }
}
