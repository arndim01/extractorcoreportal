using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmation",
                table: "TRateCommodities",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "TRateCommodities");
        }
    }
}
