using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dotnet_Project.Migrations
{
    /// <inheritdoc />
    public partial class mydatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exactLocalisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    occupancy = table.Column<bool>(type: "bit", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    team1_score = table.Column<int>(type: "int", nullable: true),
                    team2_score = table.Column<int>(type: "int", nullable: true),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number_wins = table.Column<int>(type: "int", nullable: true),
                    number_losses = table.Column<int>(type: "int", nullable: true),
                    number_draws = table.Column<int>(type: "int", nullable: true),
                    LinkedLobbyId = table.Column<int>(type: "int", nullable: true),
                    TeamNumber = table.Column<int>(type: "int", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
                    StadeId = table.Column<int>(type: "int", nullable: true),
                    LobbyId = table.Column<int>(type: "int", nullable: true),
                    LobbyId1 = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Lobbies_LinkedLobbyId",
                        column: x => x.LinkedLobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Lobbies_LobbyId1",
                        column: x => x.LobbyId1,
                        principalTable: "Lobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Stadiums_StadeId",
                        column: x => x.StadeId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LinkedLobbyId",
                table: "AspNetUsers",
                column: "LinkedLobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LobbyId",
                table: "AspNetUsers",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LobbyId1",
                table: "AspNetUsers",
                column: "LobbyId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StadeId",
                table: "AspNetUsers",
                column: "StadeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_TimeSlotId",
                table: "Lobbies",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_StadiumId",
                table: "TimeSlots",
                column: "StadiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
