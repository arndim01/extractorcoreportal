using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_LibCommodities_SysCarriers_CarrierRefId",
                table: "LibCommodities");

            migrationBuilder.DropIndex(
                name: "IX_LibCommodities_CarrierRefId",
                table: "LibCommodities");

            migrationBuilder.DropColumn(
                name: "CarrierRefId",
                table: "LibCommodities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CarrierRefId",
                table: "LibCommodities",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_LibCommodities_CarrierRefId",
                table: "LibCommodities",
                column: "CarrierRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibCommodities_SysCarriers_CarrierRefId",
                table: "LibCommodities",
                column: "CarrierRefId",
                principalTable: "SysCarriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
