using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRateCityDirects_TRates_CityId",
                table: "TRateCityDirects");

            migrationBuilder.DropForeignKey(
                name: "FK_TRates_SysTradelanes_DestinationTradelane",
                table: "TRates");

            migrationBuilder.DropForeignKey(
                name: "FK_TRates_SysTradelanes_OriginTradelane",
                table: "TRates");

            migrationBuilder.DropIndex(
                name: "IX_TRates_DestinationTradelane",
                table: "TRates");

            migrationBuilder.DropIndex(
                name: "IX_TRates_OriginTradelane",
                table: "TRates");

            migrationBuilder.DropIndex(
                name: "IX_TRateCityDirects_CityId",
                table: "TRateCityDirects");

            migrationBuilder.DropColumn(
                name: "DestinationTradelane",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "OriginTradelane",
                table: "TRates");

            migrationBuilder.AddColumn<string>(
                name: "DestinationValue",
                table: "TRates",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationViaValue",
                table: "TRates",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginValue",
                table: "TRates",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginViaValue",
                table: "TRates",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationValue",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "DestinationViaValue",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "OriginValue",
                table: "TRates");

            migrationBuilder.DropColumn(
                name: "OriginViaValue",
                table: "TRates");

            migrationBuilder.AddColumn<long>(
                name: "DestinationTradelane",
                table: "TRates",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OriginTradelane",
                table: "TRates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRates_DestinationTradelane",
                table: "TRates",
                column: "DestinationTradelane");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_OriginTradelane",
                table: "TRates",
                column: "OriginTradelane");

            migrationBuilder.CreateIndex(
                name: "IX_TRateCityDirects_CityId",
                table: "TRateCityDirects",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TRateCityDirects_TRates_CityId",
                table: "TRateCityDirects",
                column: "CityId",
                principalTable: "TRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TRates_SysTradelanes_DestinationTradelane",
                table: "TRates",
                column: "DestinationTradelane",
                principalTable: "SysTradelanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TRates_SysTradelanes_OriginTradelane",
                table: "TRates",
                column: "OriginTradelane",
                principalTable: "SysTradelanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
