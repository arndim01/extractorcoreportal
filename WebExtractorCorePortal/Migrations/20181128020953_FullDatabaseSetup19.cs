using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRates_TRateCommodities_CommodityRefId",
                table: "TRates");

            migrationBuilder.DropIndex(
                name: "IX_TRates_CommodityRefId",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "CommodityRefId",
                table: "TRates");

            migrationBuilder.AddColumn<string>(
                name: "CommodityHash",
                table: "TRates",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "TRates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TableId",
                table: "TRates",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommodityHash",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "TRates");

            migrationBuilder.AddColumn<long>(
                name: "CommodityRefId",
                table: "TRates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRates_CommodityRefId",
                table: "TRates",
                column: "CommodityRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_TRates_TRateCommodities_CommodityRefId",
                table: "TRates",
                column: "CommodityRefId",
                principalTable: "TRateCommodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
