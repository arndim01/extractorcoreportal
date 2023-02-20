using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibCities_TAmendments_AmendmentRefId",
                table: "LibCities");

            migrationBuilder.DropForeignKey(
                name: "FK_LibCities_SysCarriers_CarrierRefId",
                table: "LibCities");

            migrationBuilder.AlterColumn<long>(
                name: "CarrierRefId",
                table: "LibCities",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "AmendmentRefId",
                table: "LibCities",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_LibCities_TAmendments_AmendmentRefId",
                table: "LibCities",
                column: "AmendmentRefId",
                principalTable: "TAmendments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCities_SysCarriers_CarrierRefId",
                table: "LibCities",
                column: "CarrierRefId",
                principalTable: "SysCarriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibCities_TAmendments_AmendmentRefId",
                table: "LibCities");

            migrationBuilder.DropForeignKey(
                name: "FK_LibCities_SysCarriers_CarrierRefId",
                table: "LibCities");

            migrationBuilder.AlterColumn<long>(
                name: "CarrierRefId",
                table: "LibCities",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AmendmentRefId",
                table: "LibCities",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCities_TAmendments_AmendmentRefId",
                table: "LibCities",
                column: "AmendmentRefId",
                principalTable: "TAmendments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibCities_SysCarriers_CarrierRefId",
                table: "LibCities",
                column: "CarrierRefId",
                principalTable: "SysCarriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
