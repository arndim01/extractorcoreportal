using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmation",
                table: "TRateCities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GenId",
                table: "TRateCities",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "TRateCities");

            migrationBuilder.DropColumn(
                name: "GenId",
                table: "TRateCities");
            
        }
    }
}
