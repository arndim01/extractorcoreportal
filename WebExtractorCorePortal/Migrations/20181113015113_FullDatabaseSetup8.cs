using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainValue",
                table: "TRateNoteIndexeds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainValue",
                table: "TRateNoteIndexeds");
        }
    }
}
