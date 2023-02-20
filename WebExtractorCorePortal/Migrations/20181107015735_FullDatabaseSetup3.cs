using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibCityDetails");

            migrationBuilder.CreateTable(
                name: "LibCityDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityDetailRefId = table.Column<long>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: false),
                    UnlocRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCityDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibCityDetails_LibCities_CityDetailRefId",
                        column: x => x.CityDetailRefId,
                        principalTable: "LibCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibCityDetails_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCityDetails_SysUnlocs_UnlocRefId",
                        column: x => x.UnlocRefId,
                        principalTable: "SysUnlocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibCityDetails_CityDetailRefId",
                table: "LibCityDetails",
                column: "CityDetailRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityDetails_CreatorRefId",
                table: "LibCityDetails",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityDetails_UnlocRefId",
                table: "LibCityDetails",
                column: "UnlocRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibCityDetails");

            migrationBuilder.CreateTable(
                name: "LibCityLibDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<bool>(nullable: false),
                    CityDetailRefId = table.Column<long>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: false),
                    UnlocRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCityLibDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibCityLibDetails_LibCities_CityDetailRefId",
                        column: x => x.CityDetailRefId,
                        principalTable: "LibCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibCityLibDetails_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCityLibDetails_SysUnlocs_UnlocRefId",
                        column: x => x.UnlocRefId,
                        principalTable: "SysUnlocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibCityLibDetails_CityDetailRefId",
                table: "LibCityLibDetails",
                column: "CityDetailRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityLibDetails_CreatorRefId",
                table: "LibCityLibDetails",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityLibDetails_UnlocRefId",
                table: "LibCityLibDetails",
                column: "UnlocRefId");
        }
    }
}
