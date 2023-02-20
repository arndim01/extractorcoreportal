using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRateFreetimeDirects_TRates_FreetimeId",
                table: "TRateFreetimeDirects");

            migrationBuilder.DropForeignKey(
                name: "FK_TRateGeneralNotes_TRates_RateGeneralNoteRefId",
                table: "TRateGeneralNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TRateHazGens_TRates_HazRef",
                table: "TRateHazGens");

            migrationBuilder.DropForeignKey(
                name: "FK_TRateLineNotes_TRates_RateLineNoteRefId",
                table: "TRateLineNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TRates_TRateScopes_RateTrade",
                table: "TRates");

            migrationBuilder.DropIndex(
                name: "IX_TRateLineNotes_RateLineNoteRefId",
                table: "TRateLineNotes");

            migrationBuilder.DropIndex(
                name: "IX_TRateHazGens_HazRef",
                table: "TRateHazGens");

            migrationBuilder.DropIndex(
                name: "IX_TRateGeneralNotes_RateGeneralNoteRefId",
                table: "TRateGeneralNotes");

            migrationBuilder.DropIndex(
                name: "IX_TRateFreetimeDirects_FreetimeId",
                table: "TRateFreetimeDirects");

            migrationBuilder.DropColumn(
                name: "TabType",
                table: "TRateNotes");

            migrationBuilder.AlterColumn<long>(
                name: "RateTrade",
                table: "TRates",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TRates_TRateScopes_RateTrade",
                table: "TRates",
                column: "RateTrade",
                principalTable: "TRateScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRates_TRateScopes_RateTrade",
                table: "TRates");

            migrationBuilder.AlterColumn<long>(
                name: "RateTrade",
                table: "TRates",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "TabType",
                table: "TRateNotes",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TRateLineNotes_RateLineNoteRefId",
                table: "TRateLineNotes",
                column: "RateLineNoteRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateHazGens_HazRef",
                table: "TRateHazGens",
                column: "HazRef");

            migrationBuilder.CreateIndex(
                name: "IX_TRateGeneralNotes_RateGeneralNoteRefId",
                table: "TRateGeneralNotes",
                column: "RateGeneralNoteRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateFreetimeDirects_FreetimeId",
                table: "TRateFreetimeDirects",
                column: "FreetimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TRateFreetimeDirects_TRates_FreetimeId",
                table: "TRateFreetimeDirects",
                column: "FreetimeId",
                principalTable: "TRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TRateGeneralNotes_TRates_RateGeneralNoteRefId",
                table: "TRateGeneralNotes",
                column: "RateGeneralNoteRefId",
                principalTable: "TRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TRateHazGens_TRates_HazRef",
                table: "TRateHazGens",
                column: "HazRef",
                principalTable: "TRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TRateLineNotes_TRates_RateLineNoteRefId",
                table: "TRateLineNotes",
                column: "RateLineNoteRefId",
                principalTable: "TRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TRates_TRateScopes_RateTrade",
                table: "TRates",
                column: "RateTrade",
                principalTable: "TRateScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
