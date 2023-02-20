using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAmendmentLoadeds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmendmentRefId = table.Column<long>(nullable: false),
                    CommodityLoaded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAmendmentLoadeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TAmendmentLoadeds_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_TAmendmentLoadeds_AmendmentRefId",
                table: "TAmendmentLoadeds",
                column: "AmendmentRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAmendmentLoadeds");
        }
    }
}
