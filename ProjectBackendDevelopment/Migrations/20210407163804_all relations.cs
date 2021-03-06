using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBackendDevelopment.Migrations
{
    public partial class allrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RugNummers",
                columns: table => new
                {
                    RugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RugNummerCijfer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RugNummers", x => x.RugId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    RugNummerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_RugNummers_RugNummerId",
                        column: x => x.RugNummerId,
                        principalTable: "RugNummers",
                        principalColumn: "RugId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    SponsorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.SponsorId);
                    table.ForeignKey(
                        name: "FK_Sponsors_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SponsorPlayers",
                columns: table => new
                {
                    SponsorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorPlayers", x => new { x.SponsorId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_SponsorPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SponsorPlayers_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "SponsorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RugNummers",
                columns: new[] { "RugId", "RugNummerCijfer" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 9 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Manchester", "England", "Manchester City" },
                    { 2, "Barcelona", "Spain", "Barcelona" },
                    { 3, "Munchen", "Germany", "Bayern" },
                    { 4, "Oudenaarde", "Belgium", "Mater" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Age", "FirstName", "LastName", "RugNummerId" },
                values: new object[,]
                {
                    { 1, 19, "Ewoud", "De Preester", 1 },
                    { 2, 19, "Robbe", "Raevens", 2 },
                    { 3, 13, "Jarno", "Vanden Haesevelde", 3 },
                    { 4, 19, "Lara", "Desmet", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_RugNummerId",
                table: "Players",
                column: "RugNummerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SponsorPlayers_PlayerId",
                table: "SponsorPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_TeamId",
                table: "Sponsors",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SponsorPlayers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "RugNummers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
