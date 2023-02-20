using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibCityDetails_CUser_CreatorRefId",
                table: "LibCityDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LibCityDetails_SysUnlocs_UnlocRefId",
                table: "LibCityDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LibCommodities_CUser_CreatorRefId",
                table: "LibCommodities");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorRefId",
                table: "LibCommodities",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "UnlocRefId",
                table: "LibCityDetails",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "CreatorRefId",
                table: "LibCityDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_LibCityDetails_CUser_CreatorRefId",
                table: "LibCityDetails",
                column: "CreatorRefId",
                principalTable: "CUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCityDetails_SysUnlocs_UnlocRefId",
                table: "LibCityDetails",
                column: "UnlocRefId",
                principalTable: "SysUnlocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCommodities_CUser_CreatorRefId",
                table: "LibCommodities",
                column: "CreatorRefId",
                principalTable: "CUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibCityDetails_CUser_CreatorRefId",
                table: "LibCityDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LibCityDetails_SysUnlocs_UnlocRefId",
                table: "LibCityDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LibCommodities_CUser_CreatorRefId",
                table: "LibCommodities");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorRefId",
                table: "LibCommodities",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UnlocRefId",
                table: "LibCityDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorRefId",
                table: "LibCityDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCityDetails_CUser_CreatorRefId",
                table: "LibCityDetails",
                column: "CreatorRefId",
                principalTable: "CUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCityDetails_SysUnlocs_UnlocRefId",
                table: "LibCityDetails",
                column: "UnlocRefId",
                principalTable: "SysUnlocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCommodities_CUser_CreatorRefId",
                table: "LibCommodities",
                column: "CreatorRefId",
                principalTable: "CUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
