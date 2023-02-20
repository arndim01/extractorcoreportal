using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRateBullets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmendmentRefId = table.Column<long>(nullable: false),
                    BulletValue = table.Column<string>(maxLength: 100, nullable: false),
                    GroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateBullets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateBullets_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRateBullets_AmendmentRefId",
                table: "TRateBullets",
                column: "AmendmentRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRateBullets");
        }
    }
}
