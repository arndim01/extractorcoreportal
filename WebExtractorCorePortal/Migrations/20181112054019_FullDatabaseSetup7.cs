using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRateSurcharges_TRateNoteIndexeds_SurchargeRefId",
                table: "TRateSurcharges");

            migrationBuilder.DropColumn(
                name: "AdditionalCommodity",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "ArbsConstruction",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "Connector",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "TRateNoteIndexeds");

            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "TExceptionalNotes");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "TRateNoteIndexeds",
                newName: "NumberNotes");

            migrationBuilder.AddColumn<string>(
                name: "RateNoteType",
                table: "TRateNoteIndexeds",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateNoteType",
                table: "TRateNoteIndexeds");

            migrationBuilder.RenameColumn(
                name: "NumberNotes",
                table: "TRateNoteIndexeds",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalCommodity",
                table: "TRateNoteIndexeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArbsConstruction",
                table: "TRateNoteIndexeds",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connector",
                table: "TRateNoteIndexeds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EffectiveDate",
                table: "TRateNoteIndexeds",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationDate",
                table: "TRateNoteIndexeds",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteType",
                table: "TRateNoteIndexeds",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "TRateNoteIndexeds",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteType",
                table: "TExceptionalNotes",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TRateSurcharges_TRateNoteIndexeds_SurchargeRefId",
                table: "TRateSurcharges",
                column: "SurchargeRefId",
                principalTable: "TRateNoteIndexeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
