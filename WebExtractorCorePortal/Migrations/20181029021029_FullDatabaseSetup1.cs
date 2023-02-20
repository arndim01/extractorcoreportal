using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebExtractorCorePortal.Migrations
{
    public partial class FullDatabaseSetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysCarriers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierName = table.Column<string>(maxLength: 100, nullable: false),
                    CarrierDescription = table.Column<string>(maxLength: 500, nullable: false),
                    CarrierCode = table.Column<string>(maxLength: 10, nullable: false),
                    CarrierDirPath = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysCarriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysColorSchemeColoreds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HtmlColor = table.Column<string>(maxLength: 10, nullable: false),
                    ColorName = table.Column<string>(maxLength: 50, nullable: false),
                    IsKnown = table.Column<bool>(nullable: false),
                    Prio = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysColorSchemeColoreds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysColorSchemeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SysColorRefId = table.Column<long>(nullable: false),
                    DataType = table.Column<string>(nullable: true),
                    SysCarrierRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysColorSchemeDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysColorSchemeIndexedDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SysColorRefId = table.Column<long>(nullable: false),
                    DataType = table.Column<string>(nullable: true),
                    SysCarrierRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysColorSchemeIndexedDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysColorSchemeIndexeds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Indexed = table.Column<int>(nullable: false),
                    HtmlColor = table.Column<string>(maxLength: 10, nullable: false),
                    ColorName = table.Column<string>(maxLength: 50, nullable: false),
                    Prio = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysColorSchemeIndexeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysCurrencies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysCurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysSurchargeKeywords",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysSurchargeKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysTradelanes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TradelaneCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysTradelanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysUnlocs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iso = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    State_code = table.Column<string>(maxLength: 50, nullable: true),
                    Full_code = table.Column<string>(maxLength: 50, nullable: false),
                    Port = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUnlocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TExceptionalNotes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_TExceptionalNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRateNotes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TabType = table.Column<string>(maxLength: 5, nullable: false),
                    ExportService = table.Column<string>(maxLength: 20, nullable: true),
                    ImportService = table.Column<string>(maxLength: 20, nullable: true),
                    ExportMode = table.Column<string>(maxLength: 20, nullable: true),
                    ImportMode = table.Column<string>(maxLength: 20, nullable: true),
                    AnalystNotes = table.Column<string>(nullable: true),
                    ContractNotes = table.Column<string>(nullable: true),
                    DataEntryNotes = table.Column<string>(nullable: true),
                    RateType = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRateScopes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TradeName = table.Column<string>(nullable: false),
                    IsMarked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRateValidationLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatelineValidationRefId = table.Column<long>(nullable: true),
                    ValidationType = table.Column<string>(maxLength: 50, nullable: false),
                    ValidationMsg = table.Column<string>(nullable: false),
                    Resolve = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateValidationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CRoleClaim_CRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "CRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUserClaim_CUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUserDetails_CUser_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_CUserLogin_CUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_CUserRole_CRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "CRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CUserRole_CUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_CUserToken_CUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TSource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SourceName = table.Column<string>(maxLength: 250, nullable: false),
                    SourcePath = table.Column<string>(maxLength: 500, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    SourceType = table.Column<string>(maxLength: 20, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSource_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibContainers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContainerKeyword = table.Column<string>(maxLength: 100, nullable: false),
                    ContainerDirectKeyWord = table.Column<string>(maxLength: 100, nullable: true),
                    KeyWordMeaning = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<string>(maxLength: 10, nullable: false),
                    CarrierRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibContainers_SysCarriers_CarrierRefId",
                        column: x => x.CarrierRefId,
                        principalTable: "SysCarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DirectoryName = table.Column<string>(maxLength: 128, nullable: true),
                    WorkflowPath = table.Column<string>(maxLength: 250, nullable: true),
                    CreatorRefId = table.Column<string>(nullable: false),
                    CarrierRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TContracts_SysCarriers_CarrierRefId",
                        column: x => x.CarrierRefId,
                        principalTable: "SysCarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TContracts_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysHazTariffs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierRefId = table.Column<long>(nullable: false),
                    Scope = table.Column<string>(maxLength: 30, nullable: false),
                    Trade = table.Column<string>(maxLength: 30, nullable: false),
                    Mode = table.Column<string>(maxLength: 4, nullable: false),
                    ShipSize = table.Column<string>(maxLength: 5, nullable: false),
                    ShipType = table.Column<string>(maxLength: 5, nullable: false),
                    RateBasis = table.Column<string>(maxLength: 5, nullable: false),
                    Value = table.Column<string>(maxLength: 10, nullable: false),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    CurrencyRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysHazTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysHazTariffs_SysCarriers_CarrierRefId",
                        column: x => x.CarrierRefId,
                        principalTable: "SysCarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysHazTariffs_SysCurrencies_CurrencyRefId",
                        column: x => x.CurrencyRefId,
                        principalTable: "SysCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysSurchargeGRIs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierRefId = table.Column<long>(nullable: false),
                    ContainerSize = table.Column<string>(maxLength: 5, nullable: false),
                    ContainerType = table.Column<string>(maxLength: 5, nullable: false),
                    RateBasis = table.Column<string>(maxLength: 5, nullable: false),
                    CurrencyRefId = table.Column<long>(nullable: false),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    Value = table.Column<string>(maxLength: 10, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysSurchargeGRIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysSurchargeGRIs_SysCarriers_CarrierRefId",
                        column: x => x.CarrierRefId,
                        principalTable: "SysCarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysSurchargeGRIs_SysCurrencies_CurrencyRefId",
                        column: x => x.CurrencyRefId,
                        principalTable: "SysCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUnlocTrades",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Export_code = table.Column<string>(maxLength: 50, nullable: true),
                    Import_code = table.Column<string>(maxLength: 50, nullable: true),
                    UnlocRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUnlocTrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUnlocTrades_SysUnlocs_UnlocRefId",
                        column: x => x.UnlocRefId,
                        principalTable: "SysUnlocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRateSurcharges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurchargeRefId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    ContainerSize = table.Column<string>(maxLength: 5, nullable: false),
                    ContainerType = table.Column<string>(maxLength: 5, nullable: false),
                    RateBasis = table.Column<string>(maxLength: 5, nullable: false),
                    CurrencyRefId = table.Column<long>(nullable: false),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    Value = table.Column<string>(maxLength: 10, nullable: false),
                    Header = table.Column<string>(maxLength: 250, nullable: false),
                    CodeType = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateSurcharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateSurcharges_SysCurrencies_CurrencyRefId",
                        column: x => x.CurrencyRefId,
                        principalTable: "SysCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRateSurcharges_TExceptionalNotes_SurchargeRefId",
                        column: x => x.SurchargeRefId,
                        principalTable: "TExceptionalNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TAmendments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HashId = table.Column<string>(nullable: true),
                    SourceId = table.Column<long>(nullable: false),
                    AmendmentId = table.Column<string>(maxLength: 200, nullable: false),
                    WorkflowPath = table.Column<string>(maxLength: 250, nullable: true),
                    AmendmentType = table.Column<string>(nullable: false),
                    ContractEff = table.Column<string>(maxLength: 10, nullable: false),
                    ContractExp = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ContractRefId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAmendments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TAmendments_TContracts_ContractRefId",
                        column: x => x.ContractRefId,
                        principalTable: "TContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAmendments_TSource_SourceId",
                        column: x => x.SourceId,
                        principalTable: "TSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibCities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_hash = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: false),
                    AmendmentRefId = table.Column<long>(nullable: false),
                    CarrierRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibCities_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCities_SysCarriers_CarrierRefId",
                        column: x => x.CarrierRefId,
                        principalTable: "SysCarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCities_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibCommodities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Main_value = table.Column<string>(nullable: false),
                    Main_hash_value = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Exclusions = table.Column<string>(nullable: true),
                    Nac = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: false),
                    CarrierRefId = table.Column<long>(nullable: false),
                    AmendmentRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCommodities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibCommodities_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCommodities_SysCarriers_CarrierRefId",
                        column: x => x.CarrierRefId,
                        principalTable: "SysCarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCommodities_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAmendmentComparePointers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<long>(nullable: true),
                    ReferenceId = table.Column<long>(nullable: true),
                    CurrentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAmendmentComparePointers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TAmendmentComparePointers_TContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "TContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAmendmentComparePointers_TAmendments_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAmendmentComparePointers_TAmendments_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateCommodities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Main_value = table.Column<string>(nullable: false),
                    Main_value_hash = table.Column<string>(maxLength: 128, nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Brief_description = table.Column<string>(nullable: true),
                    Nac = table.Column<string>(nullable: true),
                    Exclusion = table.Column<string>(nullable: true),
                    AmendmentRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateCommodities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateCommodities_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRateFreetimes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FreeCode = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    MinDay = table.Column<int>(nullable: false),
                    MaxDay = table.Column<int>(nullable: false),
                    Price = table.Column<string>(maxLength: 10, nullable: false),
                    CurrencyRefId = table.Column<long>(nullable: false),
                    Unit = table.Column<string>(maxLength: 10, nullable: false),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    GVersion = table.Column<long>(nullable: false),
                    AmendmentRefId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateFreetimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateFreetimes_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRateFreetimes_SysCurrencies_CurrencyRefId",
                        column: x => x.CurrencyRefId,
                        principalTable: "SysCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TStartedWorkflows",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AmendmendId = table.Column<long>(nullable: false),
                    Activate = table.Column<bool>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TStartedWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TStartedWorkflows_TAmendments_AmendmendId",
                        column: x => x.AmendmendId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TStartedWorkflows_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibCityLibDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityDetailRefId = table.Column<long>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorRefId = table.Column<string>(nullable: false),
                    UnlocRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCityLibDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibCityLibDetails_LibCities_CityDetailRefId",
                        column: x => x.CityDetailRefId,
                        principalTable: "LibCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibCityLibDetails_CUser_CreatorRefId",
                        column: x => x.CreatorRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCityLibDetails_SysUnlocs_UnlocRefId",
                        column: x => x.UnlocRefId,
                        principalTable: "SysUnlocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRateCities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    HashName = table.Column<string>(maxLength: 128, nullable: false),
                    CityRefId = table.Column<long>(nullable: true),
                    AmendmentRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateCities_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRateCities_LibCities_CityRefId",
                        column: x => x.CityRefId,
                        principalTable: "LibCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    CommodityRefId = table.Column<long>(nullable: true),
                    TabType = table.Column<string>(maxLength: 10, nullable: false),
                    OriginTradelane = table.Column<long>(nullable: true),
                    DestinationTradelane = table.Column<long>(nullable: true),
                    ArbsConst = table.Column<string>(maxLength: 5, nullable: true),
                    RateNoteRefId = table.Column<long>(nullable: false),
                    RateTrade = table.Column<long>(nullable: true),
                    AmendmentRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRates_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRates_TRateCommodities_CommodityRefId",
                        column: x => x.CommodityRefId,
                        principalTable: "TRateCommodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRates_SysTradelanes_DestinationTradelane",
                        column: x => x.DestinationTradelane,
                        principalTable: "SysTradelanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRates_SysTradelanes_OriginTradelane",
                        column: x => x.OriginTradelane,
                        principalTable: "SysTradelanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRates_TRateNotes_RateNoteRefId",
                        column: x => x.RateNoteRefId,
                        principalTable: "TRateNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRates_TRateScopes_RateTrade",
                        column: x => x.RateTrade,
                        principalTable: "TRateScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SysConditions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConditionRefId = table.Column<long>(nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Apply = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysConditions_TRateFreetimes_ConditionRefId",
                        column: x => x.ConditionRefId,
                        principalTable: "TRateFreetimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SysConditions_SysHazTariffs_ConditionRefId",
                        column: x => x.ConditionRefId,
                        principalTable: "SysHazTariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SysConditions_SysSurchargeGRIs_ConditionRefId",
                        column: x => x.ConditionRefId,
                        principalTable: "SysSurchargeGRIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWorkflows",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimedDate = table.Column<DateTime>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: false),
                    UClaimedRefId = table.Column<string>(nullable: true),
                    UCompletedRefId = table.Column<string>(nullable: true),
                    SWorkflowRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TWorkflows_TStartedWorkflows_SWorkflowRefId",
                        column: x => x.SWorkflowRefId,
                        principalTable: "TStartedWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWorkflows_CUser_UClaimedRefId",
                        column: x => x.UClaimedRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWorkflows_CUser_UCompletedRefId",
                        column: x => x.UCompletedRefId,
                        principalTable: "CUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateBRs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BRRefId = table.Column<long>(nullable: true),
                    CodeType = table.Column<string>(maxLength: 5, nullable: false),
                    ContainerSize = table.Column<string>(maxLength: 5, nullable: false),
                    ContainerType = table.Column<string>(maxLength: 5, nullable: false),
                    Currency = table.Column<string>(maxLength: 5, nullable: false),
                    RateBasis = table.Column<string>(maxLength: 5, nullable: false),
                    Value = table.Column<string>(maxLength: 10, nullable: false),
                    Header = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateBRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateBRs_TRates_BRRefId",
                        column: x => x.BRRefId,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateCityDirects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityPoint = table.Column<string>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    CityRefId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateCityDirects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateCityDirects_TRates_CityId",
                        column: x => x.CityId,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRateCityDirects_TRateCities_CityRefId",
                        column: x => x.CityRefId,
                        principalTable: "TRateCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateFreetimeDirects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Point = table.Column<string>(nullable: true),
                    FreetimeId = table.Column<long>(nullable: false),
                    FreetimeRefId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateFreetimeDirects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateFreetimeDirects_TRates_FreetimeId",
                        column: x => x.FreetimeId,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRateFreetimeDirects_TRateFreetimes_FreetimeRefId",
                        column: x => x.FreetimeRefId,
                        principalTable: "TRateFreetimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateGeneralNotes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RateGeneralNoteRefId = table.Column<long>(nullable: false),
                    GeneralNoteType = table.Column<string>(maxLength: 128, nullable: false),
                    HashValue = table.Column<string>(nullable: true),
                    MainValue = table.Column<string>(nullable: true),
                    Exceptional = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateGeneralNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateGeneralNotes_TExceptionalNotes_Exceptional",
                        column: x => x.Exceptional,
                        principalTable: "TExceptionalNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRateGeneralNotes_TRates_RateGeneralNoteRefId",
                        column: x => x.RateGeneralNoteRefId,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRateHazGens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HazRef = table.Column<long>(nullable: true),
                    TabType = table.Column<string>(maxLength: 5, nullable: false),
                    HazCode = table.Column<string>(maxLength: 250, nullable: true),
                    HazDescription = table.Column<string>(nullable: true),
                    HazType = table.Column<byte>(nullable: false),
                    HazNote = table.Column<string>(maxLength: 20, nullable: true),
                    ShipSize = table.Column<string>(maxLength: 5, nullable: false),
                    ShipType = table.Column<string>(maxLength: 5, nullable: false),
                    RateBasis = table.Column<string>(maxLength: 5, nullable: false),
                    CurrencyRefId = table.Column<long>(nullable: true),
                    EffectiveDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    Mode = table.Column<string>(maxLength: 4, nullable: false),
                    Header = table.Column<string>(nullable: false),
                    Value = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateHazGens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateHazGens_SysCurrencies_CurrencyRefId",
                        column: x => x.CurrencyRefId,
                        principalTable: "SysCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRateHazGens_TRates_HazRef",
                        column: x => x.HazRef,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateIndexeds",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmendmentRefId = table.Column<long>(nullable: true),
                    RateRefId = table.Column<long>(nullable: true),
                    GroutId = table.Column<long>(nullable: false),
                    TableId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateIndexeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateIndexeds_TAmendments_AmendmentRefId",
                        column: x => x.AmendmentRefId,
                        principalTable: "TAmendments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRateIndexeds_TRates_RateRefId",
                        column: x => x.RateRefId,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRateLineNotes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RateLineNoteRefId = table.Column<long>(nullable: false),
                    HashValue = table.Column<string>(maxLength: 128, nullable: true),
                    MainValue = table.Column<string>(nullable: true),
                    SpecificValue = table.Column<string>(nullable: true),
                    Exceptional = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRateLineNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRateLineNotes_TExceptionalNotes_Exceptional",
                        column: x => x.Exceptional,
                        principalTable: "TExceptionalNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRateLineNotes_TRates_RateLineNoteRefId",
                        column: x => x.RateLineNoteRefId,
                        principalTable: "TRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "CRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CRoleClaim_RoleId",
                table: "CRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "CUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "CUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CUserClaim_UserId",
                table: "CUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CUserDetails_IdentityId",
                table: "CUserDetails",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_CUserLogin_UserId",
                table: "CUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CUserRole_RoleId",
                table: "CUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCities_AmendmentRefId",
                table: "LibCities",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCities_CarrierRefId",
                table: "LibCities",
                column: "CarrierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCities_CreatorRefId",
                table: "LibCities",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityLibDetails_CityDetailRefId",
                table: "LibCityLibDetails",
                column: "CityDetailRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityLibDetails_CreatorRefId",
                table: "LibCityLibDetails",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCityLibDetails_UnlocRefId",
                table: "LibCityLibDetails",
                column: "UnlocRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCommodities_AmendmentRefId",
                table: "LibCommodities",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCommodities_CarrierRefId",
                table: "LibCommodities",
                column: "CarrierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCommodities_CreatorRefId",
                table: "LibCommodities",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LibContainers_CarrierRefId",
                table: "LibContainers",
                column: "CarrierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SysConditions_ConditionRefId",
                table: "SysConditions",
                column: "ConditionRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SysHazTariffs_CarrierRefId",
                table: "SysHazTariffs",
                column: "CarrierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SysHazTariffs_CurrencyRefId",
                table: "SysHazTariffs",
                column: "CurrencyRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SysSurchargeGRIs_CarrierRefId",
                table: "SysSurchargeGRIs",
                column: "CarrierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SysSurchargeGRIs_CurrencyRefId",
                table: "SysSurchargeGRIs",
                column: "CurrencyRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUnlocTrades_UnlocRefId",
                table: "SysUnlocTrades",
                column: "UnlocRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TAmendmentComparePointers_ContractId",
                table: "TAmendmentComparePointers",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TAmendmentComparePointers_CurrentId",
                table: "TAmendmentComparePointers",
                column: "CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_TAmendmentComparePointers_ReferenceId",
                table: "TAmendmentComparePointers",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TAmendments_ContractRefId",
                table: "TAmendments",
                column: "ContractRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TAmendments_SourceId",
                table: "TAmendments",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TContracts_CarrierRefId",
                table: "TContracts",
                column: "CarrierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TContracts_CreatorRefId",
                table: "TContracts",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateBRs_BRRefId",
                table: "TRateBRs",
                column: "BRRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateCities_AmendmentRefId",
                table: "TRateCities",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateCities_CityRefId",
                table: "TRateCities",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateCityDirects_CityId",
                table: "TRateCityDirects",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateCityDirects_CityRefId",
                table: "TRateCityDirects",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateCommodities_AmendmentRefId",
                table: "TRateCommodities",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateFreetimeDirects_FreetimeId",
                table: "TRateFreetimeDirects",
                column: "FreetimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateFreetimeDirects_FreetimeRefId",
                table: "TRateFreetimeDirects",
                column: "FreetimeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateFreetimes_AmendmentRefId",
                table: "TRateFreetimes",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateFreetimes_CurrencyRefId",
                table: "TRateFreetimes",
                column: "CurrencyRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateGeneralNotes_Exceptional",
                table: "TRateGeneralNotes",
                column: "Exceptional");

            migrationBuilder.CreateIndex(
                name: "IX_TRateGeneralNotes_RateGeneralNoteRefId",
                table: "TRateGeneralNotes",
                column: "RateGeneralNoteRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateHazGens_CurrencyRefId",
                table: "TRateHazGens",
                column: "CurrencyRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateHazGens_HazRef",
                table: "TRateHazGens",
                column: "HazRef");

            migrationBuilder.CreateIndex(
                name: "IX_TRateIndexeds_AmendmentRefId",
                table: "TRateIndexeds",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateIndexeds_RateRefId",
                table: "TRateIndexeds",
                column: "RateRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateLineNotes_Exceptional",
                table: "TRateLineNotes",
                column: "Exceptional");

            migrationBuilder.CreateIndex(
                name: "IX_TRateLineNotes_RateLineNoteRefId",
                table: "TRateLineNotes",
                column: "RateLineNoteRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_AmendmentRefId",
                table: "TRates",
                column: "AmendmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_CommodityRefId",
                table: "TRates",
                column: "CommodityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_DestinationTradelane",
                table: "TRates",
                column: "DestinationTradelane");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_OriginTradelane",
                table: "TRates",
                column: "OriginTradelane");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_RateNoteRefId",
                table: "TRates",
                column: "RateNoteRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRates_RateTrade",
                table: "TRates",
                column: "RateTrade");

            migrationBuilder.CreateIndex(
                name: "IX_TRateSurcharges_CurrencyRefId",
                table: "TRateSurcharges",
                column: "CurrencyRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TRateSurcharges_SurchargeRefId",
                table: "TRateSurcharges",
                column: "SurchargeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TSource_CreatorRefId",
                table: "TSource",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TStartedWorkflows_AmendmendId",
                table: "TStartedWorkflows",
                column: "AmendmendId");

            migrationBuilder.CreateIndex(
                name: "IX_TStartedWorkflows_CreatorRefId",
                table: "TStartedWorkflows",
                column: "CreatorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TWorkflows_SWorkflowRefId",
                table: "TWorkflows",
                column: "SWorkflowRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TWorkflows_UClaimedRefId",
                table: "TWorkflows",
                column: "UClaimedRefId");

            migrationBuilder.CreateIndex(
                name: "IX_TWorkflows_UCompletedRefId",
                table: "TWorkflows",
                column: "UCompletedRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CRoleClaim");

            migrationBuilder.DropTable(
                name: "CUserClaim");

            migrationBuilder.DropTable(
                name: "CUserDetails");

            migrationBuilder.DropTable(
                name: "CUserLogin");

            migrationBuilder.DropTable(
                name: "CUserRole");

            migrationBuilder.DropTable(
                name: "CUserToken");

            migrationBuilder.DropTable(
                name: "LibCityLibDetails");

            migrationBuilder.DropTable(
                name: "LibCommodities");

            migrationBuilder.DropTable(
                name: "LibContainers");

            migrationBuilder.DropTable(
                name: "SysColorSchemeColoreds");

            migrationBuilder.DropTable(
                name: "SysColorSchemeDetails");

            migrationBuilder.DropTable(
                name: "SysColorSchemeIndexedDetails");

            migrationBuilder.DropTable(
                name: "SysColorSchemeIndexeds");

            migrationBuilder.DropTable(
                name: "SysConditions");

            migrationBuilder.DropTable(
                name: "SysSurchargeKeywords");

            migrationBuilder.DropTable(
                name: "SysUnlocTrades");

            migrationBuilder.DropTable(
                name: "TAmendmentComparePointers");

            migrationBuilder.DropTable(
                name: "TRateBRs");

            migrationBuilder.DropTable(
                name: "TRateCityDirects");

            migrationBuilder.DropTable(
                name: "TRateFreetimeDirects");

            migrationBuilder.DropTable(
                name: "TRateGeneralNotes");

            migrationBuilder.DropTable(
                name: "TRateHazGens");

            migrationBuilder.DropTable(
                name: "TRateIndexeds");

            migrationBuilder.DropTable(
                name: "TRateLineNotes");

            migrationBuilder.DropTable(
                name: "TRateSurcharges");

            migrationBuilder.DropTable(
                name: "TRateValidationLogs");

            migrationBuilder.DropTable(
                name: "TWorkflows");

            migrationBuilder.DropTable(
                name: "CRole");

            migrationBuilder.DropTable(
                name: "SysHazTariffs");

            migrationBuilder.DropTable(
                name: "SysSurchargeGRIs");

            migrationBuilder.DropTable(
                name: "SysUnlocs");

            migrationBuilder.DropTable(
                name: "TRateCities");

            migrationBuilder.DropTable(
                name: "TRateFreetimes");

            migrationBuilder.DropTable(
                name: "TRates");

            migrationBuilder.DropTable(
                name: "TExceptionalNotes");

            migrationBuilder.DropTable(
                name: "TStartedWorkflows");

            migrationBuilder.DropTable(
                name: "LibCities");

            migrationBuilder.DropTable(
                name: "SysCurrencies");

            migrationBuilder.DropTable(
                name: "TRateCommodities");

            migrationBuilder.DropTable(
                name: "SysTradelanes");

            migrationBuilder.DropTable(
                name: "TRateNotes");

            migrationBuilder.DropTable(
                name: "TRateScopes");

            migrationBuilder.DropTable(
                name: "TAmendments");

            migrationBuilder.DropTable(
                name: "TContracts");

            migrationBuilder.DropTable(
                name: "TSource");

            migrationBuilder.DropTable(
                name: "SysCarriers");

            migrationBuilder.DropTable(
                name: "CUser");
        }
    }
}
