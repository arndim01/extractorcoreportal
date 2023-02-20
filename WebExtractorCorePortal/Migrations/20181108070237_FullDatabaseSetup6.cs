using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRateNoteIndexeds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<long>(nullable: false),
                    TableId = table.Column<long>(nullable: false),
                    HashValue = table.Column<string>(nullable: true),
                    Connector = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: true),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: true),
                    ArbsConstruction = table.Column<string>(maxLength: 5, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Services = table.Column<string>(maxLength: 5, nullable: true),
                    AdditionalCommodity = table.Column<string>(nullable: true),
                    NoteType = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateNoteIndexeds", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TRateSurcharges_TRateNoteIndexeds_SurchargeRefId",
                table: "TRateSurcharges",
                column: "SurchargeRefId",
                principalTable: "TRateNoteIndexeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRateSurcharges_TRateNoteIndexeds_SurchargeRefId",
                table: "TRateSurcharges");

            migrationBuilder.DropTable(
                name: "TRateNoteIndexeds");
        }
    }
}
