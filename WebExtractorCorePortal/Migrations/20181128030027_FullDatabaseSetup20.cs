using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommodityHash",
                table: "TRates",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenId",
                table: "TRates",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarkedType",
                table: "TRates",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenId",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "MarkedType",
                table: "TRates");

            migrationBuilder.AlterColumn<string>(
                name: "CommodityHash",
                table: "TRates",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
