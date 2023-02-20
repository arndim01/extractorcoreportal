using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AmendmentRefId",
                table: "TRateNoteIndexeds",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "TabType",
                table: "TRateNoteIndexeds",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TRateNoteIndexeds_AmendmentRefId",
                table: "TRateNoteIndexeds",
                column: "AmendmentRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_TRateNoteIndexeds_TAmendments_AmendmentRefId",
                table: "TRateNoteIndexeds",
                column: "AmendmentRefId",
                principalTable: "TAmendments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRateNoteIndexeds_TAmendments_AmendmentRefId",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropIndex(
                name: "IX_TRateNoteIndexeds_AmendmentRefId",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "AmendmentRefId",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "TabType",
                table: "TRateNoteIndexeds");
        }
    }
}
