using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Texters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LongValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderValue = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    TwoFactorAuthEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Facebook = table.Column<bool>(type: "bit", nullable: false),
                    Google = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveEmail = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveNotification = table.Column<bool>(type: "bit", nullable: false),
                    UserPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TwoFactorString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorStringExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailConfirmationString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Img = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Completed = table.Column<int>(type: "int", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsSwotCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsResourcesCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPartnersCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPropositionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCostCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPlans_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessPlans_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessPlans_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan_Attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TexterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    AttrVal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderValue = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Attributes_BusinessPlans_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plan_Attributes_Texters_TexterId",
                        column: x => x.TexterId,
                        principalTable: "Texters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedPlans_BusinessPlans_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("93708740-9dd4-4fe7-b522-eb35449590fe"), "AT", "Austria" },
                    { new Guid("07ab3fdb-38f5-452f-8854-f1f84cc430f7"), "LU", "Luxembourg" },
                    { new Guid("75f0d275-65f0-4401-888a-7c612a0c76b2"), "MT", "Malta" },
                    { new Guid("337030a4-a3bf-46d4-b884-e4ae5574ab9f"), "MK", "North Macedonia" },
                    { new Guid("cfe81d12-7c3d-4de5-83b2-a1decb2fe470"), "NO", "Norway" },
                    { new Guid("d2da2af6-d188-4c87-8f97-57da22aaa696"), "PL", "Poland" },
                    { new Guid("c6018d9c-026d-463b-a517-27849ebf8b70"), "PT", "Portugal" },
                    { new Guid("f6601b75-84f6-4773-a2e5-732ddd53c4a3"), "RO", "Romania" },
                    { new Guid("2a31e97a-d06a-4e10-a1cb-40359cc55027"), "RS", "Serbia" },
                    { new Guid("ac5b981f-b2b0-4218-954a-d86a0177b63d"), "SK", "Slovakia" },
                    { new Guid("bfb9db75-a252-4dbb-8602-df429f630de0"), "SI", "Slovenia" },
                    { new Guid("74ef25a4-0145-4079-98f8-20d02dcdd5ad"), "ES", "Spain" },
                    { new Guid("17023167-e4c4-4061-b279-5bcaf328b563"), "SE", "Sweden" },
                    { new Guid("beacba0a-d8ba-41c4-bc75-ac4b3f2308ec"), "CH", "Switzerland" },
                    { new Guid("67d4855a-0775-4396-8c10-0adc67c4f19a"), "TR", "Turkey" },
                    { new Guid("61966ed4-4514-4e46-89a4-4e9f063ad581"), "UK", "United Kingdom" },
                    { new Guid("cae4a27b-9e6f-47f4-ab15-0899632899dd"), "LT", "Lithuania" },
                    { new Guid("625b4167-93a0-43fc-963e-87ef54a87b9b"), "LI", "Liechtenstein" },
                    { new Guid("e07acf64-5dd9-4307-89fb-bbb7809f83ed"), "NL", "Netherlands" },
                    { new Guid("ecff931f-3c4f-4c66-8aa7-0665c5ed2415"), "IT", "Italy" },
                    { new Guid("ab35a27c-d241-4d27-a5e9-1b30be1bc52a"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("eea20ec0-f5c6-414c-b573-2719459845e2"), "BE", "Belgium" },
                    { new Guid("65d14093-86f3-490b-9147-4277bf469f4d"), "BG", "Bulgaria" },
                    { new Guid("1fa167ab-a7f7-47c2-8c7b-6fd6ec2ec5f6"), "LV", "Latvia" },
                    { new Guid("a5389700-9353-41d0-807e-b2402a20446a"), "CY", "Cyprus" },
                    { new Guid("7a255a29-31f6-4630-b839-2268d53add6d"), "CZ", "Czechia" },
                    { new Guid("023c3b36-a18b-49e3-9851-d4f1ade4bd8a"), "DK", "Denmark" },
                    { new Guid("077f0160-6381-44d4-8f7d-2a4dd31c6aaf"), "EE", "Estonia" },
                    { new Guid("c5914b28-dda6-46b0-8cc0-113215245271"), "HR", "Croatia" },
                    { new Guid("01f819c3-7013-4036-a746-b1551c54b960"), "FR", "France" },
                    { new Guid("61b96a67-8a1c-4f55-b91f-56f225980acc"), "DE", "Germany" },
                    { new Guid("8a8f15bd-f582-4840-81eb-d0763dab2a0d"), "EL", "Greece" },
                    { new Guid("53ddacf9-85ca-4509-a8a4-09cdf1acc1e6"), "HU", "Hungary" },
                    { new Guid("fb2ecdc0-0a72-40b7-8b2f-bf5eeb76a479"), "IS", "Iceland" },
                    { new Guid("753b098d-81e1-46b9-a9ef-e7004c5069b7"), "IE", "Ireland" },
                    { new Guid("3013a687-28b8-490b-817a-7437af008484"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "P", "EN", "Education" },
                    { new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("3be2dff3-ef27-45ba-86ed-94012b8cb823"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "L", "EN", "Real estate activities" },
                    { new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "H", "EN", "Transporting and storage" },
                    { new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "F", "EN", "Construction" },
                    { new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "J", "EN", "Information and communication" },
                    { new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "C", "EN", "Manufacturing" },
                    { new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "B", "EN", "Mining and quarrying" },
                    { new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "A", "EN", "Agriculture, forestry and fishing" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("992b8693-8ddf-4ec9-b2a2-aa1db80d133b"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("56198005-8505-4083-af8f-09078aea07bd"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("ad560df6-7796-429c-a9eb-6c903861f54d"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("6594194c-9fbe-42ff-a974-3094194b6cf1"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("b8a0b207-7b09-4532-a5fa-7e84a9ad7940"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("bf867b15-a91b-4c2a-b167-fda7808e9a2b"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("2b2528e7-76b7-4926-9891-213b68d59e45"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("f0e9e267-db6c-4d20-81c3-0b66d7f7d83e"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("97c9dc1b-ad5e-492d-98d1-9fdb1ec2c3b0"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("f73e8a4b-890d-4ad1-95f9-cb408b4c3d0d"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("b153f0e8-4e08-414c-a259-12f6d8a042c1"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("504596a2-5a89-49d5-b5b3-f0ec6ae2ac4b"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("ebb1e33b-2408-4990-97de-d19547f7d365"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("1d4bb10d-ef37-4111-8d01-e23954454062"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("60ebf6fb-92e7-4f2c-9a1e-013ea7818f61"), (short)23, null, new Guid("1d4bb10d-ef37-4111-8d01-e23954454062"), (short)1, "Other" },
                    { new Guid("3b0fd524-491a-4d61-bc42-2485cd05f373"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("8fd10cea-b6ec-49e2-ad07-e972b3061a62"), (short)23, null, new Guid("504596a2-5a89-49d5-b5b3-f0ec6ae2ac4b"), (short)1, "Manufacturing buildings" },
                    { new Guid("e06f122e-bbcb-475a-a602-ca5826fc6780"), (short)23, null, new Guid("504596a2-5a89-49d5-b5b3-f0ec6ae2ac4b"), (short)2, "Inventory buildings" },
                    { new Guid("28841f37-f789-4642-80ba-18a3c3476978"), (short)23, null, new Guid("504596a2-5a89-49d5-b5b3-f0ec6ae2ac4b"), (short)3, "Sales buildings (shops)" },
                    { new Guid("7db2f010-70a9-46ae-94c4-b99af63995ed"), (short)23, null, new Guid("504596a2-5a89-49d5-b5b3-f0ec6ae2ac4b"), (short)4, "Other" },
                    { new Guid("4546d9d0-9a89-4a20-b8f2-0bf7d0e77dc5"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("2ddbe4ca-e1f6-41a4-bdd7-80076faae047"), (short)23, null, new Guid("4546d9d0-9a89-4a20-b8f2-0bf7d0e77dc5"), (short)1, "IT (office) equipment" },
                    { new Guid("d649749b-4e6f-419f-b0f0-142cc0e6cae7"), (short)23, null, new Guid("4546d9d0-9a89-4a20-b8f2-0bf7d0e77dc5"), (short)2, "Production equipment and machinery" },
                    { new Guid("f541b7f7-5965-4f1e-baf5-c20fb8fa0dd7"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("3dade90f-1c8f-49b0-b731-d14b8b95368a"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("f3ee26fa-4722-4430-a05a-2c7572d09b97"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("12a998db-14e2-4a35-bf95-d0840a576b1f"), (short)16, null, null, (short)5, "Different price for individuals" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("74e3641e-8871-4dc1-a899-08abb012b18b"), (short)23, null, new Guid("4546d9d0-9a89-4a20-b8f2-0bf7d0e77dc5"), (short)3, "Transport" },
                    { new Guid("626f25a0-9b16-4ee3-8040-21173c2324e3"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("36918f91-0875-4988-a3d4-fbe6c76a20d6"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("57fa3a07-4616-4b41-9b95-cd2c391a507d"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("0344e347-da82-40a1-9128-3656cac78548"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("c2d62588-f6a1-42b8-ab08-7874362b9873"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("8fd7fa4a-25fa-4eeb-b052-44ce4083ec28"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("c4f76dfd-bf4d-4b94-a6dd-3694f864c0d3"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("5d4b948a-fc0e-4260-aa0a-22628d8fa386"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("b9b07747-971c-47c0-b305-97a1298324df"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("43b788c0-67a7-4ca4-8c3f-5c15a44796a2"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("234ef20a-306c-404c-bd2c-bea4b4f70f2c"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("bdead1db-7430-4966-aa6c-55cc247118ed"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("95311435-ee07-4627-acee-fa269feeac7b"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("0f52373f-32ef-473c-84ea-075803685097"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("d3fcbfda-d53f-4d2a-8dcf-152cacd555af"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("19bb1b10-b898-4986-900f-d6d113eef33b"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("51f61a24-54a4-45d0-882a-c13d93410ce3"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("d7d3f487-7129-480c-9539-4955fa7c39e1"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("cfea90dd-f179-4cc0-b3fe-b074edb45d24"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("48d7a62a-d845-4177-bf27-d404d4d56923"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("f72f882b-811a-4776-ac4e-0943f3334c92"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("a647c6b4-e663-462a-971b-6fcb63d5fac6"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("9256e4f5-509c-49de-8052-1f6a357319df"), (short)23, null, new Guid("4546d9d0-9a89-4a20-b8f2-0bf7d0e77dc5"), (short)4, "Other" },
                    { new Guid("26c0cc4b-1433-40c2-a8af-1c6a121f6c9f"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("fcc85441-0c42-4b63-9728-4d94f8d70cf5"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)1, "Electricity" },
                    { new Guid("c1c4f52d-52a1-4d03-bb27-535ae32cc2d7"), (short)23, null, new Guid("26c0cc4b-1433-40c2-a8af-1c6a121f6c9f"), (short)1, "Manufacturing building" },
                    { new Guid("9c29345e-c763-4ed9-9d85-a7617e0328bc"), (short)23, null, new Guid("26c0cc4b-1433-40c2-a8af-1c6a121f6c9f"), (short)2, "Office" },
                    { new Guid("beacc5b2-5842-4833-b371-f56ffedcd973"), (short)23, null, new Guid("26c0cc4b-1433-40c2-a8af-1c6a121f6c9f"), (short)3, "Equipment" },
                    { new Guid("3727e165-dd1b-4058-8370-eb7a11842459"), (short)23, null, new Guid("26c0cc4b-1433-40c2-a8af-1c6a121f6c9f"), (short)4, "Other" },
                    { new Guid("2bedcb83-2b74-44a8-8423-37ae91491e44"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("fbd14005-c95b-4008-b56d-e5bfc0da0abc"), (short)23, null, new Guid("2bedcb83-2b74-44a8-8423-37ae91491e44"), (short)1, "Other" },
                    { new Guid("fe6f205d-4965-40a1-a8da-b391f0fdb683"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("c05057aa-910c-4748-9b1f-cb63296099ac"), (short)23, null, new Guid("fe6f205d-4965-40a1-a8da-b391f0fdb683"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("6c358c6f-85cd-4c95-9946-55cb29f4e450"), (short)23, null, new Guid("fe6f205d-4965-40a1-a8da-b391f0fdb683"), (short)2, "Other" },
                    { new Guid("e98177f7-8556-487f-b9c0-a56a608f9250"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("0f5fcda3-ef16-44a6-88d7-333fcf7e07fd"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("40980b22-0ca4-4693-b6d9-8d7b29882ecc"), (short)23, null, new Guid("e98177f7-8556-487f-b9c0-a56a608f9250"), (short)1, "Other" },
                    { new Guid("783a949b-bdaf-4832-b0bc-8f13fcc9f876"), (short)23, null, new Guid("c26800ed-bd4c-4dde-9f08-a2c81425e1f2"), (short)1, "Other" },
                    { new Guid("9e60e2b8-c9fe-444b-b986-4ba158faef45"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("dd31efd8-738c-49cd-bd32-6e83d421a3d9"), (short)23, null, new Guid("9e60e2b8-c9fe-444b-b986-4ba158faef45"), (short)1, "Other" },
                    { new Guid("dbf8831d-0ba1-4c35-af0a-a71bd19d67a0"), (short)22, null, null, (short)8, "Distribution" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("279f45e9-f3b6-40fa-8997-867d93a22b3f"), (short)23, null, new Guid("dbf8831d-0ba1-4c35-af0a-a71bd19d67a0"), (short)1, "Transport" },
                    { new Guid("5db862ea-21c7-48ed-96d5-c17f2b99aa53"), (short)23, null, new Guid("dbf8831d-0ba1-4c35-af0a-a71bd19d67a0"), (short)2, "Cost of warehouse" },
                    { new Guid("52590332-2c57-41a2-8233-4eb35e9019d0"), (short)23, null, new Guid("dbf8831d-0ba1-4c35-af0a-a71bd19d67a0"), (short)3, "Fees to distributors" },
                    { new Guid("08b644f7-cba2-4425-a05c-786e44621ea2"), (short)23, null, new Guid("dbf8831d-0ba1-4c35-af0a-a71bd19d67a0"), (short)4, "Other" },
                    { new Guid("cc9b3119-df68-42b8-8914-3c7c08bb5131"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("b540c2d7-587a-42c8-9ba8-bd09ee8f1ce9"), (short)23, null, new Guid("cc9b3119-df68-42b8-8914-3c7c08bb5131"), (short)1, "Other" },
                    { new Guid("c26800ed-bd4c-4dde-9f08-a2c81425e1f2"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("15142efa-9b0f-4fcc-ad1d-73364e63838f"), (short)23, null, new Guid("6c20c38a-165d-4daa-bfe7-1a5d954351ec"), (short)1, "Other" },
                    { new Guid("6c20c38a-165d-4daa-bfe7-1a5d954351ec"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("d6359529-283b-4072-8fae-902d1f2b6261"), (short)23, null, new Guid("66279505-3274-48ba-a7df-5494db5a5ed5"), (short)1, "Other" },
                    { new Guid("32fb2e07-a4f7-496f-b4fd-fe8f8795cf30"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)2, "Water" },
                    { new Guid("62c49883-1c4e-4563-8b3c-136448be3595"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)3, "Gas" },
                    { new Guid("e832875a-23c0-4577-a9b3-a57dcf8cffc6"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)4, "Heat" },
                    { new Guid("f5203f41-d9c7-47df-81e0-04c14813dcf1"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)5, "Maintenance" },
                    { new Guid("796476eb-3206-4cc2-9b1b-fe24f38cdb90"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)6, "Communication" },
                    { new Guid("3bc5e57e-d760-49e5-a6ae-5bb38c79974d"), (short)23, null, new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)7, "Other" },
                    { new Guid("d10ddccf-fc1c-4ad4-bb06-13c0fb83fb08"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("e890aa44-0ea7-42c0-985a-7c74df4a6170"), (short)23, null, new Guid("d10ddccf-fc1c-4ad4-bb06-13c0fb83fb08"), (short)1, "Accountant" },
                    { new Guid("9f590534-aba6-47df-9e17-398adb701a78"), (short)23, null, new Guid("d10ddccf-fc1c-4ad4-bb06-13c0fb83fb08"), (short)2, "IT support" },
                    { new Guid("6d3f35b4-fd70-482d-b193-0a7a39088603"), (short)23, null, new Guid("d10ddccf-fc1c-4ad4-bb06-13c0fb83fb08"), (short)3, "Other" },
                    { new Guid("9e5e332e-9808-47e9-9636-57fa4fc4046a"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("31bf5575-75dd-4d09-9695-0fe5ae47ae50"), (short)23, null, new Guid("9e5e332e-9808-47e9-9636-57fa4fc4046a"), (short)1, "Other" },
                    { new Guid("472aae2c-ae1e-425f-ad26-79d56352e00f"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("11980c18-5d11-4d01-b06c-a4186883129e"), (short)23, null, new Guid("472aae2c-ae1e-425f-ad26-79d56352e00f"), (short)1, "Management" },
                    { new Guid("5167118a-d674-4bf0-95de-786edb7b6f6e"), (short)23, null, new Guid("472aae2c-ae1e-425f-ad26-79d56352e00f"), (short)2, "Factory workers / service" },
                    { new Guid("50263788-db8b-4298-846e-98d2948f5c82"), (short)23, null, new Guid("472aae2c-ae1e-425f-ad26-79d56352e00f"), (short)3, "Finance management" },
                    { new Guid("b94ed079-a0bf-4dfe-9496-983b0b8083a9"), (short)23, null, new Guid("472aae2c-ae1e-425f-ad26-79d56352e00f"), (short)4, "Marketing" },
                    { new Guid("3ca0b88b-45e9-471c-a1b8-ed954f94efb6"), (short)23, null, new Guid("472aae2c-ae1e-425f-ad26-79d56352e00f"), (short)5, "Other" },
                    { new Guid("b146e696-4083-4473-a7da-0aa801c6b9e2"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("baab8afb-0ad7-44e6-b22d-73e104a3ad01"), (short)23, null, new Guid("b146e696-4083-4473-a7da-0aa801c6b9e2"), (short)1, "Other" },
                    { new Guid("a8997280-2ae5-47bf-9826-ef7a0c574ece"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("38eb3f8a-5dc1-4503-909c-5ef48097aa1d"), (short)23, null, new Guid("a8997280-2ae5-47bf-9826-ef7a0c574ece"), (short)1, "Other" },
                    { new Guid("66279505-3274-48ba-a7df-5494db5a5ed5"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("87e84a38-7d4c-479a-8280-37cedf2baeee"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("1f411140-3c05-4ff8-92df-4f8e366eb2a5"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("5ce94b5e-6d89-485e-8703-a7b34871eea4"), (short)6, null, new Guid("feaf5337-0cbc-415f-8f0a-61067f3c4539"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("98ddaab8-fe62-4e18-888d-ab4567ab472c"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("ad7955ac-eab5-4536-8158-e8ee7c3b1055"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("654efbf3-e1e6-4e2b-aeca-b4c5ac161a3d"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("bc984b92-1ce7-4404-88fe-40e1bbfc6e6e"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("edffb2b6-9d63-4add-aad7-bf02246faec7"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("75ee2d50-f52e-4feb-aede-e384340ef58a"), (short)3, null, null, (short)9, "Accessibility of tangible resources" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("50880ad3-ef97-4f5d-a16e-c5959880db59"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("c65fad13-a3dc-4666-ad81-9a49d042e219"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("447f3130-da32-4cd9-b52f-7b444e0df06c"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("32c94acd-116b-4211-b79c-c4a658c3a435"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("4ddd7a1b-5e91-4d6d-ba5d-73332ee49dce"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("b5762d9f-17a9-4571-bb63-4b3a8d9119db"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("eb7c86fc-92e6-45b0-93c0-9d80565a86d3"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("eeb81efe-7bb4-4125-8175-2029ada9d4ed"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("cce9b229-190b-44dd-99f8-ce87abaa8888"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("9c85530c-87b3-444b-9b41-d3819a5c5577"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("1793bdd1-3063-4b86-a89b-27fc06e6c970"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("ab09cfa9-b72b-4391-9afb-282509e17d47"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("550a76b9-3339-41a9-bbf7-ed589be1e21f"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("8a5b5cfe-bf83-450f-8b46-b26bc9c8743e"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("e3485db9-c14c-45a4-8490-e42451658fed"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("b3c14210-9ae2-41e5-87d1-ce73cdcbdefa"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("87a1152b-e644-440e-b97c-d57273567510"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("73fd4d59-56c2-47a4-bd10-9e662e3b792e"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("f6cec57a-a39d-43a8-96d6-2cc3688c39ba"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("4a8caa1d-76f9-4b82-b854-15857ec286c1"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("331ed134-23c2-4413-95a6-3c50fd8ba7a0"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("9671aaf8-de0d-4657-b689-6c3400a09de8"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("394a7b27-c1a5-4f92-b973-100e59962992"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("a5d5611a-c7bd-4d97-a867-a69a0898aaee"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("4e431744-82e0-482a-94c7-6c011e6a46e5"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("31cd7330-b2b0-4789-8d3d-935993b2993f"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("1d609403-dd61-463e-a7fe-1749f0352039"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("13979562-9f8c-4f64-9f32-aff842a239cd"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("5daacc4e-cf4a-4e66-8ed7-c6352dcefaee"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("f24cdebf-3b89-44b7-8046-0cd98fe382b2"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("31ecdf9c-2fbe-4578-a53c-f42d21b220ba"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("214c1ac2-684d-461d-bfce-4c385af1f425"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("d02d021c-25f1-4a56-a5ef-31fc972dce66"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("c2dbcd78-11d6-403e-8f32-c827e8576795"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("ac15b5c7-d212-4d01-ab43-e6b5ae9a2375"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("6d43684c-69ee-44d3-8fbd-135655d45426"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("ab24c273-f682-4dd7-a315-252447e48a8e"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("f87e63c9-102e-4920-af77-72dd1c2fc31b"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("b20226e0-e491-4a13-a14f-1e07e20f285a"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("9b2c5bef-0937-487c-8642-92dd08808b88"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("ebb8a61d-734a-4cb4-9dbb-ba1aa7905315"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("506ba0f8-0dd2-4973-a5e6-421ef6d290c5"), (short)1, "a", null, (short)21, "Payment terms" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("fd073fe4-acd5-4731-a654-7d887ee17627"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("502ef640-8e47-427d-888e-02be5a1fc5dc"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("cdb4c855-7171-4a91-9b49-4c9ccbb44beb"), (short)6, null, new Guid("87a1152b-e644-440e-b97c-d57273567510"), (short)1, "Buildings" },
                    { new Guid("cb1135c2-644f-455b-a1e7-123b1f5eaf0e"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("0c05e541-f59b-4fe9-b0d3-8b7d9e2c064f"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("cdb4c855-7171-4a91-9b49-4c9ccbb44beb"), (short)1, "Ownership type" },
                    { new Guid("fe1c9c46-464c-4133-a44e-573d21a24bc6"), (short)6, null, new Guid("87a1152b-e644-440e-b97c-d57273567510"), (short)2, "Equipment" },
                    { new Guid("f289e416-e50d-4c88-bfab-f9d9b2f9a204"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("e9574fc2-4ce3-4767-b718-b8168733ed01"), (short)2, "Frequency" },
                    { new Guid("71ec7ecc-6024-4772-9cb4-9e808ded32d6"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("79cb09d2-486d-466f-b4f8-0922e745db16"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("c78c2b6a-ab28-46ed-9b03-46dbea4df438"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("15bdceaf-7070-47ce-8645-4367fbf6a02d"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("91c85aa1-25ba-4430-b5f5-a46b57481a1f"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("f1344f70-9a91-4094-9df3-7fe522741f17"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("f361af50-34ad-4008-b366-694c582d0a0f"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("b30f267b-f670-4347-9f6a-1bf8adbe4d9b"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("0133a84f-3813-470d-9b38-c72b4fff63d7"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("a8266376-3377-4bc5-bfc0-850f9a5bcc7a"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("e9574fc2-4ce3-4767-b718-b8168733ed01"), (short)1, "Ownership type" },
                    { new Guid("48f628b8-9e1d-497b-82f3-a4c4009d6f14"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("a2ce1e53-ae96-4227-8de1-5cfc9d7267cd"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("7e5f2df2-9cf4-4b33-925d-3b2b836356ff"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("7b680c08-9084-457c-a853-70043a8a3805"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("4f94462d-9a2f-441b-a556-201ffdf66195"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("c044b7fc-c757-4901-ad8c-beb94c46e95f"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("ebc44bc8-57d1-445f-ad46-b2ba532aa7cf"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("a0319634-bed5-48b6-82ac-0aac532a938c"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("d844c5b9-6bdd-457a-8604-f9644814624b"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("df2a8046-3710-400e-b41b-a053aab17f53"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("e8faa737-84b9-40b0-8d3c-5f9ae81151ba"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("212496f7-3d0a-4039-b515-a5aa3ee80175"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("e9574fc2-4ce3-4767-b718-b8168733ed01"), (short)6, null, new Guid("feaf5337-0cbc-415f-8f0a-61067f3c4539"), (short)4, "Other" },
                    { new Guid("791e5bf4-f2e8-42ad-b00d-e5e48baf76a7"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("5ce94b5e-6d89-485e-8703-a7b34871eea4"), (short)2, "Frequency" },
                    { new Guid("ac753d2c-8505-4680-b308-c3e762c9c553"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("5ce94b5e-6d89-485e-8703-a7b34871eea4"), (short)1, "Ownership type" },
                    { new Guid("b4650d56-a559-47c5-99e4-60d7205f516d"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("fe1c9c46-464c-4133-a44e-573d21a24bc6"), (short)1, "Ownership type" },
                    { new Guid("55159712-5caa-469a-af89-92c060c68a4a"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fe1c9c46-464c-4133-a44e-573d21a24bc6"), (short)2, "Frequency" },
                    { new Guid("87ab42bc-7365-4e4d-ab88-7c88adcda61a"), (short)6, null, new Guid("87a1152b-e644-440e-b97c-d57273567510"), (short)3, "Transport" },
                    { new Guid("4fce532b-fb25-456a-ba7a-c664b44c83c1"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("87ab42bc-7365-4e4d-ab88-7c88adcda61a"), (short)1, "Ownership type" },
                    { new Guid("583ecf1c-76b4-43a7-9460-7bbfd458c296"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("87ab42bc-7365-4e4d-ab88-7c88adcda61a"), (short)2, "Frequency" },
                    { new Guid("c0e9b543-94e2-4cda-84da-f8c72991fc1a"), (short)6, null, new Guid("87a1152b-e644-440e-b97c-d57273567510"), (short)4, "Raw materials" },
                    { new Guid("5f3d19c6-6b78-4aa4-a2ba-0b687505402f"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("c0e9b543-94e2-4cda-84da-f8c72991fc1a"), (short)1, "Ownership type" },
                    { new Guid("19917a6a-290d-49be-ad59-980e917786c3"), (short)6, null, new Guid("87a1152b-e644-440e-b97c-d57273567510"), (short)5, "Other" },
                    { new Guid("0fed0f7c-1abd-41fc-b69a-42ebbcb679e2"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("19917a6a-290d-49be-ad59-980e917786c3"), (short)1, "Ownership type" },
                    { new Guid("e33cba01-1c8e-4927-86d5-a7576a3bce6d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("19917a6a-290d-49be-ad59-980e917786c3"), (short)2, "Frequency" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("1758bb72-e689-4302-82f2-3915752e1ed3"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("58bd7004-052f-4e61-ba9d-6cc5419233b5"), (short)6, null, new Guid("1758bb72-e689-4302-82f2-3915752e1ed3"), (short)1, "Brands" },
                    { new Guid("2ab61d85-7141-492c-9e8f-9dd1c26fb007"), (short)6, null, new Guid("1758bb72-e689-4302-82f2-3915752e1ed3"), (short)2, "Licenses" },
                    { new Guid("f838c30d-29a9-4cce-83ce-9c771e91fbfa"), (short)6, null, new Guid("1758bb72-e689-4302-82f2-3915752e1ed3"), (short)3, "Software" },
                    { new Guid("f45322fe-fdf2-4871-92fb-c9612ce6cb50"), (short)6, null, new Guid("1758bb72-e689-4302-82f2-3915752e1ed3"), (short)4, "Other" },
                    { new Guid("feaf5337-0cbc-415f-8f0a-61067f3c4539"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("d0490032-82da-440b-a2b9-608b79c33fea"), (short)6, null, new Guid("feaf5337-0cbc-415f-8f0a-61067f3c4539"), (short)1, "Specialists & Know-how" },
                    { new Guid("7a7b74df-e2fe-4363-9796-e53e654d7250"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("d0490032-82da-440b-a2b9-608b79c33fea"), (short)1, "Ownership type" },
                    { new Guid("5145ab5e-98a8-4bca-9613-de8a57983098"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d0490032-82da-440b-a2b9-608b79c33fea"), (short)2, "Frequency" },
                    { new Guid("e9f76220-fe3c-432d-a1de-5669222518a8"), (short)6, null, new Guid("feaf5337-0cbc-415f-8f0a-61067f3c4539"), (short)2, "Administrative" },
                    { new Guid("4509de04-50c3-4466-a314-25e0479daa64"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("e9f76220-fe3c-432d-a1de-5669222518a8"), (short)1, "Ownership type" },
                    { new Guid("e52205aa-5231-43d2-8a66-9a94e097f8e3"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("e9f76220-fe3c-432d-a1de-5669222518a8"), (short)2, "Frequency" },
                    { new Guid("01dcac55-082f-4d8a-93ee-81adf5e3c03f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("cdb4c855-7171-4a91-9b49-4c9ccbb44beb"), (short)2, "Frequency" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 100, "Simple" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ca79c492-7c7a-4cd6-9330-60a13ea700cc"), "A.01", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("eb265b5d-b82e-43ef-b3ff-911e82d2ab98"), "H.51.22", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Space transport" },
                    { new Guid("50be0522-99e6-479f-922b-659f3c8d1e5a"), "H.52", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Warehousing and support activities for transportation" },
                    { new Guid("d5acdbe7-253d-4503-8676-77ff032e2692"), "H.52.1", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Warehousing and storage" },
                    { new Guid("1cebf647-5f95-468c-8dff-ef8fef8bd9b0"), "H.52.10", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Warehousing and storage" },
                    { new Guid("e7d7d6de-b75f-4064-b7e1-48960ffc1571"), "H.52.2", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Support activities for transportation" },
                    { new Guid("f04603ca-6b63-4755-8b39-74025a62d013"), "H.52.21", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Service activities incidental to land transportation" },
                    { new Guid("57ea357b-8dec-49fc-b08a-3f4ecaa3a261"), "H.52.22", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Service activities incidental to water transportation" },
                    { new Guid("7d6004c7-6ca0-4b75-a0c1-b2f686da2c6d"), "H.52.23", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Service activities incidental to air transportation" },
                    { new Guid("d28e81b0-f87c-4b91-a7c3-5781c7f39af8"), "H.52.24", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Cargo handling" },
                    { new Guid("c2756114-6409-4596-86cb-ff4d8e60bbe3"), "H.52.29", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Other transportation support activities" },
                    { new Guid("8fb51c3d-6bde-4ba7-9be6-fdf7ba64d0df"), "H.53", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Postal and courier activities" },
                    { new Guid("5e723388-18f6-4df9-ae1c-3bde64aec6c4"), "H.53.1", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Postal activities under universal service obligation" },
                    { new Guid("49ab7075-8f9f-41c9-82e2-a9f6f9c202dd"), "H.51.21", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Freight air transport" },
                    { new Guid("f82c238c-e6f5-4792-a091-31c40d2afa42"), "H.53.10", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Postal activities under universal service obligation" },
                    { new Guid("a29196ce-c4be-402f-b297-80f42cc109b1"), "H.53.20", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Other postal and courier activities" },
                    { new Guid("62943c20-481c-4f76-85e2-7202710c1fa2"), "I.55", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Accommodation" },
                    { new Guid("1526c0c0-9dd1-4ed8-8c08-97627576f54e"), "I.55.1", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Hotels and similar accommodation" },
                    { new Guid("3b4fc857-ed4f-4968-849c-d5ca1592f357"), "I.55.10", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Hotels and similar accommodation" },
                    { new Guid("2bdcd814-80e2-4428-bb4e-c8f3106a22d8"), "I.55.2", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Holiday and other short-stay accommodation" },
                    { new Guid("5104f8da-a552-4bc5-b055-f8802d85056b"), "I.55.20", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Holiday and other short-stay accommodation" },
                    { new Guid("13d41fcd-1987-4ce5-9154-87e20c8cc25a"), "I.55.3", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("2cfc409a-7c10-41bb-ab25-f59eacead787"), "I.55.30", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("92762a7b-470f-4197-84eb-7b5037a5a749"), "I.55.9", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Other accommodation" },
                    { new Guid("ddac4b8f-9ac5-4510-9f47-4ce7bb84a5f7"), "I.55.90", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Other accommodation" },
                    { new Guid("0970236e-8483-453c-8da0-6f6ce0609bf4"), "I.56", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Food and beverage service activities" },
                    { new Guid("03ead85c-a10d-4e3d-bb54-6959bd4782d0"), "I.56.1", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Restaurants and mobile food service activities" },
                    { new Guid("e7871e05-700b-4b1e-8c41-b5c330fbfab6"), "H.53.2", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Other postal and courier activities" },
                    { new Guid("aeb1504f-4b54-4187-83c7-cdfc704dfe8d"), "H.51.2", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Freight air transport and space transport" },
                    { new Guid("364094ec-d73b-483c-b1ca-9c77352fdf40"), "H.51.10", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Passenger air transport" },
                    { new Guid("786c1c82-29e9-4c17-b55b-8aa82eb7601c"), "H.51.1", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Passenger air transport" },
                    { new Guid("53e254b1-769a-422f-ab4f-e2fbafee13d8"), "G.47.9", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("8b7a93fb-b24c-444c-9441-a417c96aa823"), "G.47.91", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("2bec07ed-6946-4666-b79c-d261e6b0fe33"), "G.47.99", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("dbd230ab-b83a-4a51-8dac-1d1cd47286f5"), "H.49", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Land transport and transport via pipelines" },
                    { new Guid("8ad7d1d3-a0e9-4596-bc3d-532745739ac6"), "H.49.1", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Passenger rail transport, interurban" },
                    { new Guid("544e9830-532c-4a4f-8cbb-0d94aeb4678b"), "H.49.10", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Passenger rail transport, interurban" },
                    { new Guid("d3212e42-dbf7-49d7-81fc-ccb2c9bce1ce"), "H.49.2", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Freight rail transport" },
                    { new Guid("4a0be5d3-2c80-455c-b51c-3ada41273696"), "H.49.20", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Freight rail transport" },
                    { new Guid("6c32be8e-dc5a-4a0e-8332-711a9eb0ecbf"), "H.49.3", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Other passenger land transport" },
                    { new Guid("317c64ef-a4ee-42f1-91af-361bf629513d"), "H.49.31", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Urban and suburban passenger land transport" },
                    { new Guid("8b69c2a7-f447-40dc-a4ce-fbd64300d275"), "H.49.32", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0251080c-799e-48f9-803c-f62c4cf28057"), "H.49.39", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Other passenger land transport n.e.c." },
                    { new Guid("6714fede-027c-463c-909e-d2b1535a5465"), "H.49.4", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Freight transport by road and removal services" },
                    { new Guid("b5697822-dfd8-4a20-b067-cdf15027644c"), "H.49.41", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Freight transport by road" },
                    { new Guid("5121f8cb-0a2c-4b09-94cd-d8c1fbd261d7"), "H.49.42", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Removal services" },
                    { new Guid("a3d68d73-ac8b-42c7-9b7a-41bdd0c10751"), "H.49.5", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Transport via pipeline" },
                    { new Guid("1beef53e-e84d-4cbf-9760-c3c51cb2dab7"), "H.49.50", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Transport via pipeline" },
                    { new Guid("16eed657-9d68-4716-9d73-1baaf0459b29"), "H.50", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Water transport" },
                    { new Guid("3fbc0718-edb3-469d-9aa5-cbfe697d2c70"), "H.50.1", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Sea and coastal passenger water transport" },
                    { new Guid("3661ff39-0172-4df5-9d82-9aa51707a40d"), "H.50.10", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Sea and coastal passenger water transport" },
                    { new Guid("0d17447a-162c-469e-a160-8e0f361f068f"), "H.50.2", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Sea and coastal freight water transport" },
                    { new Guid("4b64e457-db7f-4d28-bdec-b175f916a123"), "H.50.20", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Sea and coastal freight water transport" },
                    { new Guid("2b3e9b77-ff9d-4a82-844a-e891d538bfb0"), "H.50.3", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Inland passenger water transport" },
                    { new Guid("4d38fa8c-5db7-464e-89cf-ac711c3f2d34"), "H.50.30", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Inland passenger water transport" },
                    { new Guid("5e1ccef3-8c63-4826-bf5e-7650b1fe1631"), "H.50.4", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Inland freight water transport" },
                    { new Guid("16ac6e8a-0ce5-4f43-a9f1-62944bd28143"), "H.50.40", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Inland freight water transport" },
                    { new Guid("bb83290a-219e-4a43-81e7-491dc261902e"), "H.51", new Guid("9109f2dc-6ae0-426f-bbe8-7d9b4df82bd6"), "Air transport" },
                    { new Guid("0ea6a077-8088-4e52-b050-16ceb1fa124a"), "I.56.10", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Restaurants and mobile food service activities" },
                    { new Guid("c0d8240e-2125-4051-a1d5-8ced61edfc73"), "G.47.89", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("c957bb15-be99-4cc4-82a6-b73d48e02f5f"), "I.56.2", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Event catering and other food service activities" },
                    { new Guid("ad1f65cf-bc67-4230-9d01-f8a2560ad177"), "I.56.29", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Other food service activities" },
                    { new Guid("e5f40ced-6be3-460a-b168-aaaef4426dc2"), "J.61.30", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Satellite telecommunications activities" },
                    { new Guid("6a79a389-11ff-4fc0-adcf-2c90fecc258e"), "J.61.9", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other telecommunications activities" },
                    { new Guid("b96f4fbc-4af1-431f-8792-eb738aa92eef"), "J.61.90", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other telecommunications activities" },
                    { new Guid("7419680f-2e09-485a-9187-3c62ec63018f"), "J.62", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Computer programming, consultancy and related activities" },
                    { new Guid("8e2b9c83-9e3d-4849-85d9-2e5fcfd4aafd"), "J.62.0", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Computer programming, consultancy and related activities" },
                    { new Guid("bc3e5a33-e00b-420a-a550-35c223621e32"), "J.62.01", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Computer programming activities" },
                    { new Guid("f03271ef-662e-44c0-932f-30c49bb9cb8a"), "J.62.02", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Computer consultancy activities" },
                    { new Guid("94a38bf5-29d3-4ac5-9a2a-384b55be1ccd"), "J.62.03", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Computer facilities management activities" },
                    { new Guid("811ae1e2-b61d-488a-9de5-f934af726725"), "J.62.09", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other information technology and computer service activities" },
                    { new Guid("14272bfc-4eb5-43dc-ada9-674c3cbd34c6"), "J.63", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Information service activities" },
                    { new Guid("a95c084e-0412-4513-b661-f51ec742038b"), "J.63.1", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("aaa296ba-96ef-44f7-964c-31033e72f273"), "J.63.11", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Data processing, hosting and related activities" },
                    { new Guid("2898f9e1-07d0-414a-8f9e-7d4053b5a273"), "J.61.3", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Satellite telecommunications activities" },
                    { new Guid("8cf763a9-ace6-4638-b88c-6eb55709599a"), "J.63.12", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Web portals" },
                    { new Guid("2aa44f50-5cd6-4965-8c59-dc7fdfe6e262"), "J.63.91", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "News agency activities" },
                    { new Guid("4f7d019b-c708-4832-acf2-8fb123b0cddb"), "J.63.99", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other information service activities n.e.c." },
                    { new Guid("1ddfb23f-54c3-431d-ab87-0b943506a7ca"), "K.64", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("31502be5-6600-47d2-afcb-3e7c4d88e88b"), "K.64.1", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Monetary intermediation" },
                    { new Guid("3166f566-753c-4f45-bb02-d64d46dcd9ed"), "K.64.11", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Central banking" },
                    { new Guid("35d05ff7-592e-46e1-aa27-1e8512732b64"), "K.64.19", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Other monetary intermediation" },
                    { new Guid("50567d74-e2a7-43df-ba17-1c675fd40856"), "K.64.2", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Activities of holding companies" },
                    { new Guid("dd18adca-f125-4483-b93b-8d99ca71bb3f"), "K.64.20", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("13cdfef0-8e60-4a42-a685-e0200e1f1540"), "K.64.3", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Trusts, funds and similar financial entities" },
                    { new Guid("dc0de71c-82c2-43a1-9c35-d48b2531d71a"), "K.64.30", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Trusts, funds and similar financial entities" },
                    { new Guid("47a88f12-a197-40d5-8c9e-77cbcf480e23"), "K.64.9", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("52c607e3-db76-4806-a76b-14087fda958a"), "K.64.91", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Financial leasing" },
                    { new Guid("051435b9-44fe-4443-854c-2a9917199a8b"), "J.63.9", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other information service activities" },
                    { new Guid("c6ea3c70-9688-45e0-9e3e-65571bfad28d"), "J.61.20", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Wireless telecommunications activities" },
                    { new Guid("f2e0d62c-9187-4236-bc0c-2cfc4c099500"), "J.61.2", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Wireless telecommunications activities" },
                    { new Guid("64a08e5b-cf5a-4fc6-a7c0-21e46e8d0095"), "J.61.10", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Wired telecommunications activities" },
                    { new Guid("7291868b-580c-4f78-92ef-8bd772371fd8"), "I.56.3", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Beverage serving activities" },
                    { new Guid("b00d8ae7-9cf7-4683-8fe2-919f036d2285"), "I.56.30", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Beverage serving activities" },
                    { new Guid("422b1983-3189-4fb6-a047-64bfa86f029d"), "J.58", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Publishing activities" },
                    { new Guid("fa05abc8-3bb4-4201-b541-1f0408995ce4"), "J.58.1", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("f1cd0db0-c992-4fe5-bdd3-1e2b10dd1f51"), "J.58.11", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Book publishing" },
                    { new Guid("f965a63f-dc53-4fa4-a01b-f45d4b819a6a"), "J.58.12", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Publishing of directories and mailing lists" },
                    { new Guid("dec9708d-9c80-481a-ba8d-9fc226a393da"), "J.58.13", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Publishing of newspapers" },
                    { new Guid("2944c9d6-fa8f-4c49-93fa-3ac62eeb06a1"), "J.58.14", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Publishing of journals and periodicals" },
                    { new Guid("fbab5198-5313-4a0b-b570-5f679b26ff6e"), "J.58.19", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other publishing activities" },
                    { new Guid("1305e96f-4755-4d7d-84d5-edb2bbce47a8"), "J.58.2", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Software publishing" },
                    { new Guid("876712c2-730c-429c-83a8-3995511da24f"), "J.58.21", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Publishing of computer games" },
                    { new Guid("ecf1576e-649e-41f5-90c4-0c6d4d56aa99"), "J.58.29", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Other software publishing" },
                    { new Guid("97d6f8a0-f32d-4a55-b48f-f5e8318a39e5"), "J.59", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("6bd64afd-0872-41e4-8b5c-8a0b21a8f96f"), "J.59.1", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Motion picture, video and television programme activities" },
                    { new Guid("3bfecc15-266e-4f80-b98e-4e09285c6673"), "J.59.11", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Motion picture, video and television programme production activities" },
                    { new Guid("d13d32ff-3c1b-43a9-a681-b0f8646d629d"), "J.59.12", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("6d80b44f-9a2a-437a-9c32-b1067407d6e8"), "J.59.13", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("6d3be008-fdea-42e1-91a0-f51c02b7261f"), "J.59.14", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Motion picture projection activities" },
                    { new Guid("bc90097e-1efb-4e20-8724-3fbd9a57ad85"), "J.59.2", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Sound recording and music publishing activities" },
                    { new Guid("cd127553-92bb-42a4-b395-84948faaeee7"), "J.59.20", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Sound recording and music publishing activities" },
                    { new Guid("b0d27014-c9bc-47ec-8ec8-e8cfc92259fd"), "J.60", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Programming and broadcasting activities" },
                    { new Guid("32474ffb-928d-4dc3-bf6d-89965de93088"), "J.60.1", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Radio broadcasting" },
                    { new Guid("4e25ffb8-c9ed-4de2-9625-e4fad875ea89"), "J.60.10", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Radio broadcasting" },
                    { new Guid("045d873f-521c-4d13-8745-d2662f87856f"), "J.60.2", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Television programming and broadcasting activities" },
                    { new Guid("71b2f3f7-8856-4fa4-9353-ab2516d82fed"), "J.60.20", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Television programming and broadcasting activities" },
                    { new Guid("49ab8204-20f9-4a97-ad5b-73d35dc98f43"), "J.61", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Telecommunications" },
                    { new Guid("8b4f7665-9ccb-4ac7-b99b-e2732bbc82f2"), "J.61.1", new Guid("e05825a8-0098-472b-9115-dbd74fa30300"), "Wired telecommunications activities" },
                    { new Guid("b2cdebc2-32df-4139-9dda-114092a3a6d0"), "I.56.21", new Guid("53693494-1e10-4084-8c8e-6d6caef5b0c8"), "Event catering activities" },
                    { new Guid("d016f1a1-40ed-4abf-aded-7d54e4de7847"), "K.64.92", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Other credit granting" },
                    { new Guid("007f3a93-820c-4c9b-a99d-10cedc7c2a45"), "G.47.82", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("9b32b04e-12f2-415f-8673-48252c70c9c9"), "G.47.8", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale via stalls and markets" },
                    { new Guid("836807ed-8efa-4573-b3b5-375a543d06fa"), "G.46.19", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("18daa1ac-8057-4fdb-85db-1d0149a3bcfc"), "G.46.2", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("6652ed2a-d798-441a-9569-50c307e71b74"), "G.46.21", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("395d6d49-d2cb-4860-8137-5587e79bea1d"), "G.46.22", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of flowers and plants" },
                    { new Guid("b7b01aa6-6f1e-4e40-a99b-f62ca4baad01"), "G.46.23", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of live animals" },
                    { new Guid("1f9ad4c3-ab9b-44c7-8053-249641fbe733"), "G.46.24", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of hides, skins and leather" },
                    { new Guid("a5741169-0cec-4f24-9d6e-11151e0b47c4"), "G.46.3", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("af07027f-43d9-42cd-b8df-4acdcdd811fe"), "G.46.31", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of fruit and vegetables" },
                    { new Guid("de3bd989-e054-4b54-8d9a-eb624df3d53c"), "G.46.32", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of meat and meat products" },
                    { new Guid("38c92f93-9460-4307-990e-fd4fd28919fc"), "G.46.33", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("432bd461-f9e4-41a2-aa14-70e66891f11e"), "G.46.34", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of beverages" },
                    { new Guid("e31f6b3a-45b8-46aa-ad97-a311c8c6ef35"), "G.46.35", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of tobacco products" },
                    { new Guid("4b3126e4-df0f-440f-80eb-c95488d8a9ac"), "G.46.18", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents specialised in the sale of other particular products" },
                    { new Guid("dc81af5c-9021-47a9-a336-f89aa928395f"), "G.46.36", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("2a830765-7260-4ec1-af36-95a42f5be55f"), "G.46.38", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("caf74076-9d45-4557-bc2e-ea2879e05d64"), "G.46.39", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("a1f4f865-c022-42d0-9fbf-ad4c00151173"), "G.46.4", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of household goods" },
                    { new Guid("f4072202-6bb9-4b72-b74c-2d2b7dfd9c15"), "G.46.41", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of textiles" },
                    { new Guid("a350017e-7d43-48ee-82fa-c44620839104"), "G.46.42", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of clothing and footwear" },
                    { new Guid("e95a727b-3e10-4066-9425-4cc9b586c70c"), "G.46.43", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of electrical household appliances" },
                    { new Guid("24c55d26-47ec-417f-a8a1-7e5150af2f56"), "G.46.44", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("a26ee59b-83ad-4691-bdd6-605afc761a6a"), "G.46.45", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of perfume and cosmetics" },
                    { new Guid("163cf652-a042-4a6e-838f-62f4e37a0d9f"), "G.46.46", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of pharmaceutical goods" },
                    { new Guid("2358e030-6bd7-43c0-9188-b6e9c35b779e"), "G.46.47", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("a34479eb-481a-4f57-a8a5-b6eb5210df30"), "G.46.48", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of watches and jewellery" },
                    { new Guid("1437bfd5-5743-4c69-9f85-8f06e710ac5c"), "G.46.49", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of other household goods" },
                    { new Guid("c559f8df-76af-437d-bdbe-08642bff2a39"), "G.46.37", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("921d96df-437c-4552-b1c0-8a1273b2b79e"), "G.46.17", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("195ef183-393d-47f2-ad63-34dc7b104bcc"), "G.46.16", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("efd460a6-1496-4b34-a925-64a5ba9e7ddf"), "G.46.15", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("79c44589-f047-4d06-ae3e-15800f00fe05"), "F.43.29", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Other construction installation" },
                    { new Guid("bfa07e9e-122d-462b-b8ef-a5a7651d560a"), "F.43.3", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Building completion and finishing" },
                    { new Guid("f89a09c2-98f0-47c1-8b73-a4f357e8c430"), "F.43.31", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Plastering" },
                    { new Guid("8f58bf8f-bb7a-460e-8e21-317b98a56010"), "F.43.32", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Joinery installation" },
                    { new Guid("1373f4ae-0a1b-4a71-8236-bc06d8b15173"), "F.43.33", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Floor and wall covering" },
                    { new Guid("d79ede88-e0f0-4027-9ab6-daff916e36a0"), "F.43.34", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Painting and glazing" },
                    { new Guid("56af6f80-b3a1-443d-8c37-4a4b4b1e4b6f"), "F.43.39", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Other building completion and finishing" },
                    { new Guid("a534603a-b6fe-43f1-ac25-84641ca860c9"), "F.43.9", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Other specialised construction activities" },
                    { new Guid("9c39e12d-7454-4ed9-a078-420fb0c5b170"), "F.43.91", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Roofing activities" },
                    { new Guid("b6827137-2414-4f5a-a13d-63a27ac11655"), "F.43.99", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Other specialised construction activities n.e.c." },
                    { new Guid("8ccaf09e-1fae-45c6-ad31-0bf8f6ab6ccc"), "G.45", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("71f507fe-7329-4744-a6cf-eeaf9ee2c0d6"), "G.45.1", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Sale of motor vehicles" },
                    { new Guid("6b5a3ef2-a5f7-497d-a4da-d70cf50accf0"), "G.45.11", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Sale of cars and light motor vehicles" },
                    { new Guid("efbe4e03-34f9-4612-944e-2c8e016667e9"), "G.45.19", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Sale of other motor vehicles" },
                    { new Guid("42e789ad-467c-486a-b217-0b77d9f7cbf1"), "G.45.2", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("95cd62a6-9091-4d81-a14a-eb89b9bd47b1"), "G.45.20", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Maintenance and repair of motor vehicles" },
                    { new Guid("efa243db-d50c-4ed9-ac29-8df03727f087"), "G.45.3", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("80dc8b09-7760-4d1c-8cf1-68b8c865c12b"), "G.45.31", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("5d6e5eb3-0cd9-4c4e-af25-63f469b25ee3"), "G.45.32", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("266ba271-a258-4185-9b21-23ce9a5995dd"), "G.45.4", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("5d982759-a54e-49ab-b0bc-828dc2b1bbda"), "G.45.40", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("5ca96f56-d0be-486e-8019-258709dacedf"), "G.46", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("b80e4e1d-4a63-479d-b05f-498078bba3d3"), "G.46.1", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale on a fee or contract basis" },
                    { new Guid("4e8d38b3-82dd-4f69-bd48-ed57eb927efc"), "G.46.11", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("14044468-e41a-449e-b1d0-1166eaea24d7"), "G.46.12", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("52b2abdb-9407-42a8-8a51-4b1f7dca4a87"), "G.46.13", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("03e90467-b82c-4972-b019-b86fa29011a3"), "G.46.14", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("f171735f-9f54-44f2-a268-80aeb075b9f2"), "G.46.5", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of information and communication equipment" },
                    { new Guid("4ecafcc5-47f6-4143-9db1-a1788852733e"), "G.47.81", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("92c927e4-4dc6-4bf1-aaf8-80c2ab206355"), "G.46.51", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("8ec367a3-d03d-46ba-8b4c-d6b571748eab"), "G.46.6", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("71cfc110-9831-4ff3-9260-63f9f247a926"), "G.47.4", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("30c690f7-a472-4f48-af4c-7cfaebbd6012"), "G.47.41", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("3d7df980-59ac-472f-b927-b70973df8b68"), "G.47.42", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("3310c88a-afd9-4448-9820-29ca56ea5305"), "G.47.43", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("ba2b4f44-8546-4b61-9c17-f0dc0eda03e1"), "G.47.5", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("78cd0f07-074c-409a-9afe-75bd30cbb399"), "G.47.51", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of textiles in specialised stores" },
                    { new Guid("dc31d356-0f5d-41bb-9fc6-7548595f5320"), "G.47.52", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("f63cfdb5-4ac4-4f6c-994e-cd924966d682"), "G.47.53", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("84c17197-bcb9-4379-9d4a-10610fcb9a48"), "G.47.54", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("1cc31a3a-6e4d-48f1-8498-82ab600727a8"), "G.47.59", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("ad945e2f-e6c2-43dd-9f56-04a65fc17f48"), "G.47.6", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("eb87e01b-13b9-43b1-9eeb-566d5f819127"), "G.47.61", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of books in specialised stores" },
                    { new Guid("933ec2d9-380a-401f-a2dc-d8f8e5d094c9"), "G.47.30", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("27e9e060-5694-4d00-ae54-6dfcd60f78c3"), "G.47.62", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("a92ed7a4-3520-4105-aa76-11d1e745d7b8"), "G.47.64", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("6d8cd8f3-bcd3-4606-912f-ac881a2a5d31"), "G.47.65", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("0fcaf43e-e193-44da-8614-a6fe570a041b"), "G.47.7", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of other goods in specialised stores" },
                    { new Guid("e88e85c9-5081-43a2-9075-60dda8a2c934"), "G.47.71", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of clothing in specialised stores" },
                    { new Guid("b95de514-bb49-49a8-9d7a-fe4479d7850b"), "G.47.72", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("024e03d0-f2e0-4cb7-a901-60b8c2e365bc"), "G.47.73", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Dispensing chemist in specialised stores" },
                    { new Guid("229fcedb-e0e4-4cd0-be4e-7a8e1dda1085"), "G.47.74", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("98c6d881-b3ca-4abf-90ab-b95eb9028d21"), "G.47.75", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("d56007f2-1e1e-4039-b3d4-9a750edeb8cc"), "G.47.76", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("c7a780e1-705d-464b-8256-ae5f6cb6c19b"), "G.47.77", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("b85f12b3-cb15-489a-8e8e-3897e2ac7c88"), "G.47.78", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("7f478c93-84c0-49a3-9b58-cbdd52930f92"), "G.47.79", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("43fd61ab-531a-4ee6-a184-92efdf945c96"), "G.47.63", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("240a57e4-9e86-4a5f-bf96-3433abefc14e"), "G.47.3", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("da92f048-88e1-41c0-9c24-0b7d46787f7f"), "G.47.29", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Other retail sale of food in specialised stores" },
                    { new Guid("6c5f74f5-fc59-47ef-b838-ea0e83cfe38f"), "G.47.26", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("8b26f16b-bd02-47fc-a42b-dc48607473b5"), "G.46.61", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("bf40894f-cf50-4dbd-9c50-33f2142107a1"), "G.46.62", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of machine tools" },
                    { new Guid("56e1ee4f-4244-474c-ac88-a49a3a50d056"), "G.46.63", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("3a1f0193-71b3-4820-afea-8d47c6cf2db4"), "G.46.64", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("ea341a7c-9ec3-49eb-afad-5480a8a753b5"), "G.46.65", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of office furniture" },
                    { new Guid("0533a7ae-0dbf-4494-99dc-23085fa4281b"), "G.46.66", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of other office machinery and equipment" },
                    { new Guid("86897e43-33f9-4767-9c38-11753c0bc596"), "G.46.69", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of other machinery and equipment" },
                    { new Guid("1b9a05f1-2ca4-4a58-81f4-a1630aaf11ac"), "G.46.7", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Other specialised wholesale" },
                    { new Guid("359371ee-144e-423d-bc75-6767bd629d1b"), "G.46.71", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("e1e479e0-9a24-4427-89e2-6d5a2b34324b"), "G.46.72", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of metals and metal ores" },
                    { new Guid("5da0915d-bdf4-4dbc-bb24-f02894f35a4d"), "G.46.73", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("424751e9-a334-4e31-bbb9-d8092f374180"), "G.46.74", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("2a6a9e15-68fa-443e-ae16-f57630acc5c9"), "G.46.75", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of chemical products" },
                    { new Guid("f325b765-c931-44a5-ad95-ac58c21fa551"), "G.46.76", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of other intermediate products" },
                    { new Guid("d07de5f2-aeec-4d3c-b930-95562772095e"), "G.46.77", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of waste and scrap" },
                    { new Guid("baf716eb-df41-47f4-837b-3ba1a0ed6414"), "G.46.9", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Non-specialised wholesale trade" },
                    { new Guid("e834ca66-86f0-49c4-bcf7-c473e02cb55e"), "G.46.90", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Non-specialised wholesale trade" },
                    { new Guid("5e32cdea-1584-4897-9b22-dec85bee3059"), "G.47", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("458eda47-b785-4a41-9cc5-93f53d85dd58"), "G.47.1", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale in non-specialised stores" },
                    { new Guid("2c596bc5-d310-4060-ba4c-9acad6f7cc2b"), "G.47.11", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("123a3b82-21be-4315-b14d-5692eb8f0b60"), "G.47.19", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Other retail sale in non-specialised stores" },
                    { new Guid("ad2c5551-3577-431e-b979-56e6e1c5657d"), "G.47.2", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("8b6b067a-5274-46e4-80ea-ada2cd001fb3"), "G.47.21", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("55b87a92-5fea-4e9e-bada-2bc64237a5e7"), "G.47.22", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("9ee2fc82-e494-4dc9-aa56-3826fed6ea7e"), "G.47.23", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("907b5219-dae8-4bf4-80cc-c5437b17eabc"), "G.47.24", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("185e6641-9c9f-4f34-b43b-b5e7dbea5cde"), "G.47.25", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Retail sale of beverages in specialised stores" },
                    { new Guid("5ec110ac-c542-4f5c-a0d4-9a20deac3e65"), "G.46.52", new Guid("d55c918d-b9e5-441a-a299-136b205169af"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("89c83a49-5511-405c-8f5e-75ccf2797599"), "F.43.22", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("e61bca17-97f1-49d1-a52d-67d31790f135"), "K.64.99", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("681d0b14-c423-49c3-a7f5-6e8d7611fe49"), "K.65.1", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Insurance" },
                    { new Guid("724f6047-f90c-4238-aa82-1911ea8c40c9"), "P.85.6", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Educational support activities" },
                    { new Guid("aa9d4c48-85ce-412c-ad7e-95fd852f9c59"), "P.85.60", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Educational support activities" },
                    { new Guid("4849c172-9a0d-4986-b096-66604449e5b0"), "Q.86", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Human health activities" },
                    { new Guid("57f1c65d-9ce2-48c8-b45d-750f1d12e01f"), "Q.86.1", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Hospital activities" },
                    { new Guid("c3234529-7fd2-4bc6-98df-d7a648fbf66b"), "Q.86.10", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Hospital activities" },
                    { new Guid("69e623c3-aa3a-498a-b838-713e6ed0ed5e"), "Q.86.2", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Medical and dental practice activities" },
                    { new Guid("cdfd1401-199b-4055-b11e-bfa0594f189c"), "Q.86.21", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a4505e18-cded-4509-b6c6-beea65ba5f03"), "Q.86.22", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Specialist medical practice activities" },
                    { new Guid("b33d3ce6-be05-4a10-8d67-d4203e6b548e"), "Q.86.23", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Dental practice activities" },
                    { new Guid("6650ce51-07db-4baf-bcce-f69a98fd14a3"), "Q.86.9", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Other human health activities" },
                    { new Guid("ff011083-553b-4ae4-bdb9-ecb4868a0491"), "Q.86.90", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Other human health activities" },
                    { new Guid("d7a63ab9-dd4e-4e10-9b0f-e745bffffd3d"), "Q.87", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential care activities" },
                    { new Guid("d6050abc-f99b-474c-be5c-dc4ddb0b1cab"), "P.85.59", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Other education n.e.c." },
                    { new Guid("6d7b262e-8ee2-4df1-93b1-35b764983104"), "Q.87.1", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential nursing care activities" },
                    { new Guid("e2899e64-ab34-4149-a561-60d0eb9a69f6"), "Q.87.2", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("28afc77b-4b11-4d46-9ad1-a3eae34e9f6e"), "Q.87.20", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("100c806d-40b8-4396-a054-a0d860ead3cf"), "Q.87.3", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential care activities for the elderly and disabled" },
                    { new Guid("0586fe0f-cb34-4c26-bebd-13751322cb58"), "Q.87.30", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential care activities for the elderly and disabled" },
                    { new Guid("2cc45d54-cc2f-49ca-9060-c6e37b9b39e7"), "Q.87.9", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Other residential care activities" },
                    { new Guid("9be7331e-3274-41c9-81f4-ffbdbcd0108c"), "Q.87.90", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Other residential care activities" },
                    { new Guid("bd554efc-e0e3-4369-b69a-d9c406c0234e"), "Q.88", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Social work activities without accommodation" },
                    { new Guid("3a87d652-2d9c-4c86-b6c7-21c3a22da675"), "Q.88.1", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("2c89aebe-36f8-4eb4-8b26-4ac02fda3bc6"), "Q.88.10", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("c8670612-f6a8-42a6-b859-b383f5a71194"), "Q.88.9", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Other social work activities without accommodation" },
                    { new Guid("f8b047c9-1f64-436e-a598-1b7382155b92"), "Q.88.91", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Child day-care activities" },
                    { new Guid("f3cced04-45c7-4ec5-9640-0b7467d785c8"), "Q.88.99", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("781abb60-04c4-4942-95b0-e133d53f38bf"), "Q.87.10", new Guid("299579a6-7944-4117-b9bb-b60b90b5eab7"), "Residential nursing care activities" },
                    { new Guid("7c840b48-b242-4671-80d4-a35f67ece4df"), "P.85.53", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Driving school activities" },
                    { new Guid("69bfd808-3e4c-4a6e-9444-226128447d65"), "P.85.52", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Cultural education" },
                    { new Guid("683c7df0-7a8c-4eef-ba26-09d48aabcb50"), "P.85.51", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Sports and recreation education" },
                    { new Guid("00592498-03a3-417f-85d2-5fc73dc5897a"), "N.82.91", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Packaging activities" },
                    { new Guid("b252460c-c5d4-4738-b2cb-42e5371afcb5"), "N.82.99", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other business support service activities n.e.c." },
                    { new Guid("11e1d414-cd72-4848-b6e7-e8cc13fb8351"), "O.84", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Public administration and defence; compulsory social security" },
                    { new Guid("68c686e9-a706-40bf-9a4d-e8b2bdd16379"), "O.84.1", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("0fe1984b-fc6f-403c-ab06-2f048d29ad59"), "O.84.11", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "General public administration activities" },
                    { new Guid("adbafee9-6456-4182-835d-5db32ef951de"), "O.84.12", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("2d6dec87-937c-4dad-ade2-bf8112968708"), "O.84.13", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("01a63952-4dff-45af-b687-6c70e5481a30"), "O.84.2", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Provision of services to the community as a whole" },
                    { new Guid("115bab4a-ae06-4394-ad04-1d4cb9673f14"), "O.84.21", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Foreign affairs" },
                    { new Guid("5771ed72-fdca-433d-893b-046109c4282d"), "O.84.22", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Defence activities" },
                    { new Guid("f9b3d9e0-4f2d-494f-af9a-ba35bfe28eea"), "O.84.23", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Justice and judicial activities" },
                    { new Guid("b5ae3e86-5c1d-4062-a510-d174919dc87b"), "O.84.24", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Public order and safety activities" },
                    { new Guid("aa12cd8a-7d65-4935-8999-537307d901a4"), "O.84.25", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Fire service activities" },
                    { new Guid("3d9c2807-4002-44bd-9a02-b208ff3d5656"), "O.84.3", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Compulsory social security activities" },
                    { new Guid("f178fa22-754e-4415-a910-e855a2465bc8"), "O.84.30", new Guid("10f45ef6-e849-4f5c-948c-0c4c23764a44"), "Compulsory social security activities" },
                    { new Guid("fd3d8f51-a468-4ae4-85b1-42b42bae9af2"), "P.85", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Education" },
                    { new Guid("31f233ed-1398-465d-b5f8-d52c9d23f047"), "P.85.1", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Pre-primary education" },
                    { new Guid("ba112bd6-57de-4c37-8ee5-15afed6816f7"), "P.85.10", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Pre-primary education" },
                    { new Guid("fb302a43-ece1-44cf-9ab8-46fdf8c9cdb0"), "P.85.2", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1d601f34-58b7-457b-906f-c13426908938"), "P.85.20", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Primary education" },
                    { new Guid("a9a5f940-9083-433d-af98-f7a6393f40ee"), "P.85.3", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Secondary education" },
                    { new Guid("ad120d7c-4a53-4fd4-b4c9-fc525f5eae63"), "P.85.31", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "General secondary education" },
                    { new Guid("da921534-644e-4357-aa15-4e95c64ce037"), "P.85.32", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Technical and vocational secondary education" },
                    { new Guid("475c21c6-b386-43d6-a5a7-8cd29fca472c"), "P.85.4", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Higher education" },
                    { new Guid("80d206f8-fcfa-4be0-861c-137cab648d6d"), "P.85.41", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Post-secondary non-tertiary education" },
                    { new Guid("9a9b9de3-e2f0-4a24-8a94-5d4f46e7f62a"), "P.85.42", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Tertiary education" },
                    { new Guid("428561bc-c282-464c-8252-4ed65891f22d"), "P.85.5", new Guid("96eba7d2-2b65-4c68-8129-12a891c2feed"), "Other education" },
                    { new Guid("47ff38f0-438d-4041-964a-c2fc6802e13d"), "R.90", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Creative, arts and entertainment activities" },
                    { new Guid("e0d1b01c-0ded-4b60-851d-8a88b2af0af8"), "N.82.92", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("1dd343e0-c5a3-4037-a45b-b8fcded78f07"), "R.90.0", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Creative, arts and entertainment activities" },
                    { new Guid("0163a5c4-3dad-43b2-82bc-f7247c9f695e"), "R.90.02", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Support activities to performing arts" },
                    { new Guid("5cc314c5-20bd-447f-b311-0717bedfd667"), "S.95.1", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of computers and communication equipment" },
                    { new Guid("e806200e-b11e-4ab0-bbfc-bde3ab105456"), "S.95.11", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of computers and peripheral equipment" },
                    { new Guid("36b962c3-de22-424c-87ae-23f592611155"), "S.95.12", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of communication equipment" },
                    { new Guid("c256f7c8-1bcb-40f9-9683-8cc502b0d1b5"), "S.95.2", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of personal and household goods" },
                    { new Guid("ca41b08b-7dc9-410b-af59-fb1fe8570828"), "S.95.21", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of consumer electronics" },
                    { new Guid("734fbabf-1b19-46e1-b229-380339c51a2c"), "S.95.22", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("f469982c-50d6-41ac-9dac-0db0a5ea26fe"), "S.95.23", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of footwear and leather goods" },
                    { new Guid("4ec1870b-d5fe-4bbb-ab5f-bda0e137dbc6"), "S.95.24", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of furniture and home furnishings" },
                    { new Guid("8033f82b-e9c7-4be7-8958-4e184713025f"), "S.95.25", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of watches, clocks and jewellery" },
                    { new Guid("cbdda4a1-4566-4ffa-abc2-3bef84a36744"), "S.95.29", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of other personal and household goods" },
                    { new Guid("a1fad384-50ae-4086-ad8c-9c93ce63d556"), "S.96", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Other personal service activities" },
                    { new Guid("68205e51-af6b-4623-a81e-cd5b8d0bf40b"), "S.96.0", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Other personal service activities" },
                    { new Guid("0a8b1b12-7f67-4b41-a811-77b1cd3b31f7"), "S.95", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Repair of computers and personal and household goods" },
                    { new Guid("a5b8c66a-ccb9-462a-b99f-dcc8daf4bc28"), "S.96.01", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("4be49476-6447-478a-b886-2c63b948eb7d"), "S.96.03", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Funeral and related activities" },
                    { new Guid("09140b81-0d21-4c72-b0e7-3d4444d62821"), "S.96.04", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Physical well-being activities" },
                    { new Guid("8a6d7e12-6038-49a3-aaf4-faf7b6431171"), "S.96.09", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Other personal service activities n.e.c." },
                    { new Guid("918e8851-b26a-40ab-98d5-7be7a608792a"), "T.97", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("ec8c301f-3375-46a0-a74b-d5e4afaa30e8"), "T.97.0", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("d8d39279-5ac6-4838-bdfb-42b51e44691a"), "T.97.00", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("b44b11a5-600f-4bdf-a72c-5bdf86ee4127"), "T.98", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("244fdb64-c737-49b5-85a1-07d15ab1e13e"), "T.98.1", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("359f81e2-b8d6-4f10-bf8a-78e0cda3a2d1"), "T.98.10", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("cd60f623-71ee-44bd-8c32-74cd85e56d8a"), "T.98.2", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("55301d78-971f-43e6-a675-1c6b1e96d51f"), "T.98.20", new Guid("2461a048-e0e5-4fd4-9c2a-c8c9491b486b"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("366e3a33-6b37-40ea-ba2a-f77103f11204"), "U.99", new Guid("3be2dff3-ef27-45ba-86ed-94012b8cb823"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("046e2b25-31b6-4ecf-b6cd-d3a048ad2f0b"), "S.96.02", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Hairdressing and other beauty treatment" },
                    { new Guid("0cfd1475-1875-4c21-8677-e5dba82f91d7"), "S.94.99", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of other membership organisations n.e.c." },
                    { new Guid("487554a1-007d-4c0c-96df-7f976fe27de4"), "S.94.92", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of political organisations" },
                    { new Guid("c8a6237c-bbb6-4426-a174-ea60d98042f0"), "S.94.91", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("85822550-a75f-4bce-abfe-f52a4502e3f9"), "R.90.03", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Artistic creation" },
                    { new Guid("c799d099-f9b1-4aff-b6eb-f1104679f725"), "R.90.04", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Operation of arts facilities" },
                    { new Guid("966cb7fc-e2ae-4b58-9ff3-6c2e18e7ebda"), "R.91", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("a0b4eb9d-da1a-404f-8b4d-04b3078962a0"), "R.91.0", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("9fb65c91-4054-4235-ad81-eab0b0919016"), "R.91.01", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Library and archives activities" },
                    { new Guid("d22fa256-1233-4ab1-9273-fa1d143a80cf"), "R.91.02", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Museums activities" },
                    { new Guid("59b02d2f-e480-4274-aaeb-3d5af2dc4083"), "R.91.03", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("6f2152d3-d3ee-4090-b621-51cb1a9b4b8d"), "R.91.04", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("e6318de7-9497-44cf-bf1b-084b26664a44"), "R.92", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Gambling and betting activities" },
                    { new Guid("fb9f47d7-67b2-4009-91ac-470f010dc68f"), "R.92.0", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Gambling and betting activities" },
                    { new Guid("2ec7c7db-9e7b-498e-b0fd-bc9945f857e7"), "R.92.00", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Gambling and betting activities" },
                    { new Guid("7c449f24-374c-48ca-b30d-6a9898b20d22"), "R.93", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Sports activities and amusement and recreation activities" },
                    { new Guid("2af0f116-d86b-4d7c-8689-5f2d6be982be"), "R.93.1", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Sports activities" },
                    { new Guid("890f0500-0822-498c-912c-4b2486f78a01"), "R.93.11", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Operation of sports facilities" },
                    { new Guid("02f1d199-2dc1-40c3-966f-b4d4dd69237d"), "R.93.12", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Activities of sport clubs" },
                    { new Guid("a4443f96-a943-4276-8d45-ccff3dc0e671"), "R.93.13", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Fitness facilities" },
                    { new Guid("119c27c9-6279-44d6-ba25-667b0af09dfb"), "R.93.19", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Other sports activities" },
                    { new Guid("be0412ba-21e3-4df4-8dfc-509fe8bed7d2"), "R.93.2", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Amusement and recreation activities" },
                    { new Guid("29cc2187-7c1e-421a-8021-28561db16a64"), "R.93.21", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Activities of amusement parks and theme parks" },
                    { new Guid("4ae8c322-8e73-4878-b06b-323f8e875d34"), "R.93.29", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Other amusement and recreation activities" },
                    { new Guid("774599bc-ddf5-4f59-aa1e-b0c3fb30d229"), "S.94", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of membership organisations" },
                    { new Guid("a0e40d88-6f1a-4d0e-a590-d43ba665f698"), "S.94.1", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("6efb0cf0-e5b2-49be-97f1-b3712c0336fb"), "S.94.11", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of business and employers membership organisations" },
                    { new Guid("856b37b8-e705-4765-a1e3-a52bc97bb6a6"), "S.94.12", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of professional membership organisations" },
                    { new Guid("cede340f-c08c-4aae-81c1-390df1b93822"), "S.94.2", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of trade unions" },
                    { new Guid("f8f431d0-7517-4711-b3df-78264fe5707f"), "S.94.20", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of trade unions" },
                    { new Guid("7bcfae4a-1667-4ff7-964f-a31cd5bf0628"), "S.94.9", new Guid("60e87e24-7e94-4377-aedf-fb2d4647814b"), "Activities of other membership organisations" },
                    { new Guid("3887a8ae-2109-4244-b173-66a83b5aed77"), "R.90.01", new Guid("4534f470-8cc8-4fc7-94c2-c7f3cb9d06d5"), "Performing arts" },
                    { new Guid("404ba617-1e82-4522-84a1-1c4cbe609f39"), "K.65", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("01a26b58-6683-4719-b79c-eccae5dafdb6"), "N.82.9", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Business support service activities n.e.c." },
                    { new Guid("be62fe13-32e9-405c-8bda-47586761fad8"), "N.82.3", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Organisation of conventions and trade shows" },
                    { new Guid("8ad20b5f-419f-4ee4-987d-72f50515a2e9"), "M.70.1", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Activities of head offices" },
                    { new Guid("050ca325-b336-408b-99ca-e84b080f978b"), "M.70.10", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Activities of head offices" },
                    { new Guid("b5244418-0b0c-48fe-baf2-69a501256bc6"), "M.70.2", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Management consultancy activities" },
                    { new Guid("59276aeb-7daa-4cb6-bf20-76ad8e69013d"), "M.70.21", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Public relations and communication activities" },
                    { new Guid("10490a03-4557-4d67-a48e-e968ce35b5e1"), "M.70.22", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Business and other management consultancy activities" },
                    { new Guid("44168236-654a-45e9-8f0a-5e2b450d8c18"), "M.71", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("9a950405-df8e-4fe8-bf6d-8eafc5693363"), "M.71.1", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("729e430c-e03c-4dfd-8387-a8c3211b95e7"), "M.71.11", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Architectural activities" },
                    { new Guid("bdb9c4d5-81b7-4cf1-9329-04b614b2a6fc"), "M.71.12", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Engineering activities and related technical consultancy" },
                    { new Guid("be17afb0-952d-4707-85db-627cbcc6f3c5"), "M.71.2", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Technical testing and analysis" },
                    { new Guid("db213380-f693-48a4-8327-e7ea89fe8c35"), "M.71.20", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6c7a0d04-be0b-4048-81ed-025d3bd49690"), "M.72", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Scientific research and development" },
                    { new Guid("f17ce98c-6eea-41c8-bca1-7c03a3c15769"), "M.70", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Activities of head offices; management consultancy activities" },
                    { new Guid("48cc7777-e51b-4e63-b855-3664a487c1c1"), "M.72.1", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("4d86f0dc-7d4f-4f3c-a643-e3d26d9cccae"), "M.72.19", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("02e22c3e-56e7-4d6a-9ab7-61e40724b371"), "M.72.2", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("d5696e60-302f-4152-9a28-df0c5399bfe7"), "M.72.20", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("4bed3a13-11df-4861-8ca9-57e4c3ccc6ab"), "M.73", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Advertising and market research" },
                    { new Guid("7be0df2e-2735-4664-9c7d-daa2bd66d351"), "M.73.1", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Advertising" },
                    { new Guid("f3b7b3dd-5f99-4363-99f3-35b6feadd82f"), "M.73.11", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Advertising agencies" },
                    { new Guid("f437540b-a251-4873-9dda-a0e61e78322d"), "M.73.12", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Media representation" },
                    { new Guid("84b292ad-2b66-4411-9df8-e02168b498f5"), "M.73.2", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Market research and public opinion polling" },
                    { new Guid("c1c7d914-5875-41e1-81a1-919dcbb7c509"), "M.73.20", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Market research and public opinion polling" },
                    { new Guid("c1442108-b22a-4f5d-9bcb-96eaba580584"), "M.74", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Other professional, scientific and technical activities" },
                    { new Guid("daaadf7e-e8a5-479f-afb0-bbe2d0d87811"), "M.74.1", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Specialised design activities" },
                    { new Guid("72ed85de-034a-4831-a29d-2aae2eb09332"), "M.74.10", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Specialised design activities" },
                    { new Guid("5f00846b-7e15-4ab5-8c51-cd59c53673a2"), "M.72.11", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Research and experimental development on biotechnology" },
                    { new Guid("6bcb975c-e102-4061-9a56-dd711b420ad9"), "M.69.20", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("158a7a6e-c0e0-4e1b-a81f-c83a72810775"), "M.69.2", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("e093a5d6-c762-40d2-a551-f532b39cfd56"), "M.69.10", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Legal activities" },
                    { new Guid("18a2946b-9bad-4651-81c9-3e64ced1ee2a"), "K.65.11", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Life insurance" },
                    { new Guid("c1cfef7a-f4c8-4914-af3b-9f0d74d9a79c"), "K.65.12", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Non-life insurance" },
                    { new Guid("eb682eaf-0ba8-4d26-b6d7-73cb9684e8e2"), "K.65.2", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Reinsurance" },
                    { new Guid("beeaada9-6803-4b40-b7f7-9fcd6fa6772e"), "K.65.20", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Reinsurance" },
                    { new Guid("68d597a5-dc39-416d-8bc7-881431cd26ed"), "K.65.3", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Pension funding" },
                    { new Guid("31bc6db8-e03e-44f0-a652-cea4f509e3ff"), "K.65.30", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Pension funding" },
                    { new Guid("7a08ebce-e5ca-4fd1-af59-f4d0f496da45"), "K.66", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("af1e7107-7a14-449e-b6fc-5124ae25018f"), "K.66.1", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("5d6f9d65-648c-4ba4-a0c1-13627380899c"), "K.66.11", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Administration of financial markets" },
                    { new Guid("6132af3e-74ed-4f8e-8720-b8fd235b1a9e"), "K.66.12", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Security and commodity contracts brokerage" },
                    { new Guid("7cf5c46b-5213-4145-b77e-cf2b9560389d"), "K.66.19", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("cfae9fcf-3c9b-4230-b16f-428c7be43adb"), "K.66.2", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("f9a99dd7-4dc6-4588-b69e-755b2f126f6a"), "K.66.21", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Risk and damage evaluation" },
                    { new Guid("b24894b2-55f7-48f3-aba2-50f4111d9cd6"), "K.66.22", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Activities of insurance agents and brokers" },
                    { new Guid("a87afda8-3cfc-403b-9db8-48af39295464"), "K.66.29", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("68887f0a-b5af-4751-a0ec-458100a9b40c"), "K.66.3", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Fund management activities" },
                    { new Guid("16394eee-1edf-465c-9f65-392264d5b51d"), "K.66.30", new Guid("e05e7283-76bf-4acb-ba23-5038e662715e"), "Fund management activities" },
                    { new Guid("e6ffb5a8-ea4e-427d-9d08-0a09677404e5"), "L.68", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Real estate activities" },
                    { new Guid("aa7bdf39-dae3-4983-a9a8-23923e211a1e"), "L.68.1", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Buying and selling of own real estate" },
                    { new Guid("de792ed7-8b43-4717-9479-89b270552720"), "L.68.10", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Buying and selling of own real estate" },
                    { new Guid("50459caa-ba3c-4e8a-96cd-23e7101c8827"), "L.68.2", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Renting and operating of own or leased real estate" },
                    { new Guid("51fb2a62-fb5a-435a-b676-a781e3319ef2"), "L.68.20", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Renting and operating of own or leased real estate" },
                    { new Guid("20fe5a65-345a-4df0-a8d4-2e1c2fb5a43c"), "L.68.3", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("12afc2a4-bb8d-45da-b1dd-eeb2cf3297aa"), "L.68.31", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Real estate agencies" },
                    { new Guid("b4314634-dfb8-4001-a6f9-ea40001587b1"), "L.68.32", new Guid("9e824413-4637-4478-9bbc-0d5dde19161e"), "Management of real estate on a fee or contract basis" },
                    { new Guid("a9d7c6b1-c419-454b-99a5-5cc1bff6f40b"), "M.69", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Legal and accounting activities" },
                    { new Guid("fb1215ff-8f7b-4fd0-b6f4-d584605692cc"), "M.69.1", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Legal activities" },
                    { new Guid("ef53b247-2a9b-4071-a4ba-5d59fc5c7502"), "M.74.2", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Photographic activities" },
                    { new Guid("cd1e7bd3-aa2a-4997-b4af-0f43aa202cba"), "N.82.30", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Organisation of conventions and trade shows" },
                    { new Guid("eb53ddcf-f8d2-4368-8a10-987c0852c52f"), "M.74.20", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Photographic activities" },
                    { new Guid("db81842b-8a66-4d90-90c3-04f49769c2ec"), "M.74.30", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Translation and interpretation activities" },
                    { new Guid("ccde40af-df92-4453-b1f6-326ac54b0d37"), "N.79.11", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Travel agency activities" },
                    { new Guid("056f5468-3ec9-4347-acd1-b52c00609d9b"), "N.79.12", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Tour operator activities" },
                    { new Guid("e3188d8a-5732-4c4b-ab5d-1043f8fa904c"), "N.79.9", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other reservation service and related activities" },
                    { new Guid("0b6ac804-116a-4587-b446-773537bcfd3b"), "N.79.90", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other reservation service and related activities" },
                    { new Guid("d22d88c0-3355-40e3-964c-0674530975b3"), "N.80", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Security and investigation activities" },
                    { new Guid("3ae221ac-b24f-4a33-b430-73b49326bed7"), "N.80.1", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Private security activities" },
                    { new Guid("5df1500c-5974-498a-aaca-43fb79215098"), "N.80.10", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Private security activities" },
                    { new Guid("513bd59b-07d8-4c14-a322-ccc03b2de4b7"), "N.80.2", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Security systems service activities" },
                    { new Guid("775d23b7-63b2-4663-a513-11a68e409041"), "N.80.20", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Security systems service activities" },
                    { new Guid("f06c2da0-4f54-4fa3-b17d-f817840797fa"), "N.80.3", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Investigation activities" },
                    { new Guid("d381dde0-2a59-4338-b8be-fa29aeb409ff"), "N.80.30", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Investigation activities" },
                    { new Guid("c34f95fa-ed56-4f8d-81cc-0f862ffdabfa"), "N.81", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Services to buildings and landscape activities" },
                    { new Guid("628db897-2a29-4379-9560-8f1913d6e8a2"), "N.79.1", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Travel agency and tour operator activities" },
                    { new Guid("6aac401f-7ff7-4126-8ef8-2b89eb440a70"), "N.81.1", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Combined facilities support activities" },
                    { new Guid("e1eecf6c-cccf-4aec-80eb-8b6b9d5bf87c"), "N.81.2", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Cleaning activities" },
                    { new Guid("53ddd882-bdce-4021-87e5-0b0d74303fad"), "N.81.21", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "General cleaning of buildings" },
                    { new Guid("48a9c2fb-9b5e-4695-a26c-0108a5ed99d7"), "N.81.22", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other building and industrial cleaning activities" },
                    { new Guid("9843ff39-8a58-4a79-9f64-8cc45aa48828"), "N.81.29", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other cleaning activities" },
                    { new Guid("0413d39a-810a-41a5-9c8d-66516c9a06dd"), "N.81.3", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Landscape service activities" },
                    { new Guid("0d1690d9-d35c-459d-99c9-c9f61d7fe7b9"), "N.81.30", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Landscape service activities" },
                    { new Guid("fdd740d8-610e-426b-a209-ab65835c965d"), "N.82", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Office administrative, office support and other business support activities" },
                    { new Guid("3d141807-88ce-4c60-8fa9-09f67868e3c9"), "N.82.1", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Office administrative and support activities" },
                    { new Guid("6000537f-eea1-437f-903c-a184a60d44a1"), "N.82.11", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Combined office administrative service activities" },
                    { new Guid("e000b01f-8e6e-475c-85ae-08d38854ea07"), "N.82.19", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("b00ba138-2352-41ee-9230-76cb0fde27cf"), "N.82.2", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Activities of call centres" },
                    { new Guid("b2eb1f72-efbc-4c76-b429-f48c92748416"), "N.82.20", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Activities of call centres" },
                    { new Guid("b3475a30-6381-48c6-a56c-f1ee4053547b"), "N.81.10", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Combined facilities support activities" },
                    { new Guid("ba7f2b95-8c97-4b4f-930b-1368a8b284d4"), "N.79", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("e0ee2fd4-013d-4b67-bdb8-875aec746484"), "N.78.30", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other human resources provision" },
                    { new Guid("96b1ca3c-cb19-499d-9be2-e0bf1972b912"), "N.78.3", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Other human resources provision" },
                    { new Guid("34fe5e72-a430-4987-8319-b24e36574bd2"), "M.74.9", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("896493d8-9be2-4e43-bd57-68eec4d4ab04"), "M.74.90", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("f44a8180-d9c9-4d6d-a82b-bf958d859e5b"), "M.75", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Veterinary activities" },
                    { new Guid("0f2fb603-70f8-4894-852f-ccedb00ee263"), "M.75.0", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("90570743-ca06-4e22-96db-e01b907d87d9"), "M.75.00", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Veterinary activities" },
                    { new Guid("c30f2bf9-5912-4707-9107-691f5cf12dcb"), "N.77", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Rental and leasing activities" },
                    { new Guid("0d3749eb-bf8c-4d40-b401-edcec8147b7d"), "N.77.1", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of motor vehicles" },
                    { new Guid("2722a176-f7b9-474b-94f7-408bb69309a6"), "N.77.11", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("5e08a2d1-2ba7-448b-8798-0439bfa5542c"), "N.77.12", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of trucks" },
                    { new Guid("f92afdb4-aff8-450b-9fc9-6e970d3f7048"), "N.77.2", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of personal and household goods" },
                    { new Guid("c222106b-0c0d-499e-85a7-156071e17ea9"), "N.77.21", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("683af0df-1da3-4120-88e2-09078c494317"), "N.77.22", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting of video tapes and disks" },
                    { new Guid("b12d626e-a650-44b3-9ffe-bc116681dea5"), "N.77.29", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of other personal and household goods" },
                    { new Guid("57ef3236-8ad2-4871-94a1-e25f37db6957"), "N.77.3", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("79010de6-4faf-460a-b0da-ea42325085a7"), "N.77.31", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("d402cf74-5cd5-4704-8540-6bae91a89355"), "N.77.32", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("85d62b42-42fa-4443-af48-bd24d40c5afe"), "N.77.33", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("faec3bc8-fa83-47fa-9812-f29523d5d07c"), "N.77.34", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of water transport equipment" },
                    { new Guid("202f0061-a0de-4f52-83e7-b9f72c0f2af4"), "N.77.35", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of air transport equipment" },
                    { new Guid("b6515070-d065-4f67-9a52-42ea3852e060"), "N.77.39", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("f276e0fe-2d34-4b40-b541-5434088a9967"), "N.77.4", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("16b90373-8c1b-41a0-bae7-2fdec403107b"), "N.77.40", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("71a3fc1d-2a18-4fb9-ab02-740c0745b0af"), "N.78", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Employment activities" },
                    { new Guid("bf312160-dcde-4cde-a0e6-4afd3baca5aa"), "N.78.1", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Activities of employment placement agencies" },
                    { new Guid("16b16983-84ea-46fc-a206-1c31c9012495"), "N.78.10", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Activities of employment placement agencies" },
                    { new Guid("dca0d855-7efc-40cb-8f09-a99d827de286"), "N.78.2", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Temporary employment agency activities" },
                    { new Guid("0fac0262-d94e-414a-8be6-6467207ad993"), "N.78.20", new Guid("a6241a6e-3e46-4a7d-8ac9-7a3f76773595"), "Temporary employment agency activities" },
                    { new Guid("bc28f2bf-44f6-41e7-9ee6-4ac2524cd918"), "M.74.3", new Guid("388b6943-3ed9-4457-86f6-8b7c11cb6fcd"), "Translation and interpretation activities" },
                    { new Guid("a1326b6b-7a29-41e7-879d-5abd9178561f"), "U.99.0", new Guid("3be2dff3-ef27-45ba-86ed-94012b8cb823"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("6e259282-c6ac-4b78-be14-4a10d13f62c5"), "F.43.21", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Electrical installation" },
                    { new Guid("4fd5e53f-86e9-4bb7-a3ba-d4a140f31a3d"), "F.43.13", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Test drilling and boring" },
                    { new Guid("8fcac966-2b1f-450b-9f49-7ec2e5773b79"), "C.14.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of articles of fur" },
                    { new Guid("77777800-f34d-4d58-937d-106f6a37700a"), "C.14.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of articles of fur" },
                    { new Guid("97954a1e-0c5d-438b-a489-2c1d7eb3180a"), "C.14.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("097f36de-f1b6-4722-9cfd-2a482768d2d4"), "C.14.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("f267632f-c2ac-41d0-97a8-a7da4a848c2a"), "C.14.39", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("6cbc73a2-c5ff-4970-a52f-d32cfdcad6db"), "C.15", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of leather and related products" },
                    { new Guid("4ee62b57-e83e-40a5-9ea8-589d93ebb927"), "C.15.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("6804e46b-8802-4520-b944-db2a911603ba"), "C.15.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("e274e0ba-df49-414b-8024-8a157a1a00de"), "C.15.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("f9699217-e391-4a5c-a240-5ed26d5ce78e"), "C.15.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of footwear" },
                    { new Guid("402cc063-63f2-4fbf-a73b-d57137fd5f5e"), "C.15.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of footwear" },
                    { new Guid("747796d6-360a-4120-a313-32a02331fd46"), "C.16", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("2bd05d41-b519-4ea6-abc6-c2a0d786e7b2"), "C.14.19", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("d0175fbe-0fb5-4fd6-b2fd-a4ffafcafb87"), "C.16.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Sawmilling and planing of wood" },
                    { new Guid("1dac81b1-eeae-451e-b553-1813f21d0d30"), "C.16.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("aecfa628-5a96-4a75-a468-07538f8bd11d"), "C.16.21", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("6dd4c409-04a3-4a64-8f13-89cfc970a0e1"), "C.16.22", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of assembled parquet floors" },
                    { new Guid("8102ba1b-a3cc-4c3c-b1f7-46c5da9839a5"), "C.16.23", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("b51cd8ff-5e8f-47a8-a08c-d1a5a878bd3c"), "C.16.24", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wooden containers" },
                    { new Guid("23492115-88ce-473b-abb6-b7a3098ef88d"), "C.16.29", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("62059d56-d25e-4c0d-99ad-48e1bc2b8857"), "C.17", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of paper and paper products" },
                    { new Guid("32ad5e55-0ff0-47b6-af31-8c3d0b4ba3af"), "C.17.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("93b8a347-547e-4d86-af34-7755f458fee8"), "C.17.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of pulp" },
                    { new Guid("ab15b3f4-409a-4a9e-946e-437a4da1987d"), "C.17.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of paper and paperboard" },
                    { new Guid("b76a96d8-3124-4b14-803b-683777f551d2"), "C.17.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("e818961a-85f0-40d2-b336-a8ea31c1e6d0"), "C.17.21", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("8065f394-51eb-46b6-b94d-ee568a642498"), "C.16.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Sawmilling and planing of wood" },
                    { new Guid("ebc0b941-a1bb-4129-9438-62322b83c766"), "C.14.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of underwear" },
                    { new Guid("f93af9d8-898f-4065-af3c-f4edf840f153"), "C.14.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other outerwear" },
                    { new Guid("404d9dcc-c73d-4e7a-8a0e-dc3dbe887e79"), "C.14.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of workwear" },
                    { new Guid("38961c9f-d571-45f9-b60a-669c8efb8234"), "C.11.02", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wine from grape" },
                    { new Guid("d7652b82-04db-4fc6-b491-a9683e6fb523"), "C.11.03", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cider and other fruit wines" },
                    { new Guid("1a5b0446-a157-4ca1-97d8-e5ae36ff2dd9"), "C.11.04", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("d035c1a5-f44d-4c76-ba46-970274173eac"), "C.11.05", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of beer" },
                    { new Guid("95354281-ef45-49d6-9401-4e2b6539ebae"), "C.11.06", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of malt" },
                    { new Guid("a0413a63-3beb-40c1-ba43-42e45d13a194"), "C.11.07", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("6dfb0fd5-2f70-455a-8ff7-a85f71d2865a"), "C.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tobacco products" },
                    { new Guid("b5dad601-6ead-4298-bab1-64f7354a7a75"), "C.12.0", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tobacco products" },
                    { new Guid("47a8e6ab-1004-4431-9094-87c1b2d2e983"), "C.12.00", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tobacco products" },
                    { new Guid("22545da1-1cb7-4824-ba4e-e37721b3d938"), "C.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of textiles" },
                    { new Guid("97703de4-6895-4b22-8f54-db47417c844b"), "C.13.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Preparation and spinning of textile fibres" },
                    { new Guid("7d2d94f4-98b0-491f-8fea-17e2351dfc9d"), "C.13.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Preparation and spinning of textile fibres" },
                    { new Guid("cd6ab3a9-da49-42f4-88da-dd66eb0e29b5"), "C.13.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Weaving of textiles" },
                    { new Guid("121a4642-5aa9-4b5c-845b-cac43460a172"), "C.13.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Weaving of textiles" },
                    { new Guid("f1b8e1f3-4ca0-4a6f-85f0-cc81645db89f"), "C.13.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Finishing of textiles" },
                    { new Guid("f21ac4cd-d8d7-40b9-9bc1-927a8461a9ba"), "C.13.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Finishing of textiles" },
                    { new Guid("dcff8ec0-9726-4c87-9807-6a0a48972264"), "C.13.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other textiles" },
                    { new Guid("e5ccb24e-3158-4bd0-b518-5604207fd701"), "C.13.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("5faeea64-139b-4b78-9431-c8e80ff52319"), "C.13.92", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("90e46458-e614-40ff-afe0-8050732489d0"), "C.13.93", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of carpets and rugs" },
                    { new Guid("51003eb0-63be-463a-b1c2-e1bfeffb85d1"), "C.13.94", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("45e7a59a-07e9-4516-a470-a8ac52ca61e9"), "C.13.95", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("10a806a4-8a8c-415c-8dff-15c487e8ab93"), "C.13.96", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("f3ae6591-8923-49b4-aa4b-7420768cf992"), "C.13.99", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other textiles n.e.c." },
                    { new Guid("d733f38c-0b9d-48c4-88d1-23d8899182d8"), "C.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wearing apparel" },
                    { new Guid("819afaeb-9f4b-4cb1-ad86-84517d8dad5e"), "C.14.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("438a0175-1d66-49fd-b96e-33c3fbf879ca"), "C.14.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d908823e-7aa2-485f-a121-8d58b7a9a580"), "C.17.22", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("3556c55e-1014-4d7a-b893-474a51510250"), "C.11.01", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("5e5f601b-2a96-43a8-b541-9975cac69ee9"), "C.17.23", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of paper stationery" },
                    { new Guid("a9cdd374-611b-4e8e-a205-f0ca963be0b5"), "C.17.29", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("b8b286c8-cfd8-43ec-a735-c6d47e77ea9f"), "C.20.52", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of glues" },
                    { new Guid("b3e4f647-a302-4903-9b62-ac60c65fb440"), "C.20.53", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of essential oils" },
                    { new Guid("186a1f7f-b07c-4052-a0d6-53ea736ac1d4"), "C.20.59", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("df7df230-e95f-4af8-a1c0-c6abeefea27f"), "C.20.6", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of man-made fibres" },
                    { new Guid("6016b179-74d5-4c42-a3ed-c776f38c9280"), "C.20.60", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of man-made fibres" },
                    { new Guid("4b83fe83-f72e-4546-b509-8c56210f2e03"), "C.21", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("b09799bd-7882-480b-a228-d173dc26fa9f"), "C.21.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("f6df92d5-3156-4f0c-a4ab-880e82f2656b"), "C.21.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("342b5a61-2668-43b1-85d6-03e21c2a14b2"), "C.21.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("53bf2b10-a268-496f-bfb3-020e1a5161b8"), "C.21.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("ac927c59-781c-4cbf-9d6a-eb0a082ef937"), "C.22", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of rubber and plastic products" },
                    { new Guid("df069ad8-b7a0-44d1-b092-7712b103a117"), "C.22.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of rubber products" },
                    { new Guid("e3461285-f4ca-4985-bd7b-85ffcc8fbaa0"), "C.20.51", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of explosives" },
                    { new Guid("07ba2e0c-0502-416b-967a-600ef3f0bfa0"), "C.22.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("86ebf762-f7f1-4480-afbe-6bbaaa53e020"), "C.22.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of plastics products" },
                    { new Guid("3a68f5aa-994b-44eb-84a0-88bc396a0c4c"), "C.22.21", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("efc8a251-c0b9-4427-afa8-3872a50c14a7"), "C.22.22", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of plastic packing goods" },
                    { new Guid("4f8f3edf-d617-46c0-a9e5-61fe43ca9166"), "C.22.23", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("0201b686-90ad-41a0-8c73-aef1b7618a86"), "C.22.29", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other plastic products" },
                    { new Guid("8f1773c4-f189-44af-b0d7-f27eb73bb3f0"), "C.23", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("c7d349ff-1740-43b3-9f64-c3995b48f73f"), "C.23.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of glass and glass products" },
                    { new Guid("52505854-5e08-499f-859b-6a70ff7e9558"), "C.23.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of flat glass" },
                    { new Guid("46349601-4f4e-4500-9fae-96dedf8234b7"), "C.23.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Shaping and processing of flat glass" },
                    { new Guid("ec0598b1-f917-437d-9b02-86b1d74ef19e"), "C.23.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of hollow glass" },
                    { new Guid("6d105fcd-725d-46ca-8495-583ab25748e1"), "C.23.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of glass fibres" },
                    { new Guid("6b642e94-b1eb-4449-9b5d-edce2cfcb15d"), "C.23.19", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("bb8d04be-2142-4ff3-848b-8ea88c8b1578"), "C.22.19", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other rubber products" },
                    { new Guid("46545da3-bc8e-488a-8877-c6e98b73a789"), "C.20.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other chemical products" },
                    { new Guid("fbd64af2-d125-4e37-9783-2007f1b1e926"), "C.20.42", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("6d808eea-6f78-480e-b329-a489b02a41a7"), "C.20.41", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("0d459aee-10f9-4313-bc98-7bbd9eefeed9"), "C.18", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Printing and reproduction of recorded media" },
                    { new Guid("99e991f2-7a79-4bc3-b85d-7478b2b43044"), "C.18.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Printing and service activities related to printing" },
                    { new Guid("6ccecdfb-ab91-4f80-bbb7-9bd85adcd24d"), "C.18.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Printing of newspapers" },
                    { new Guid("681c934a-e465-429e-a62a-65ac3fc3d784"), "C.18.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Other printing" },
                    { new Guid("bc5d9b8d-e456-4be1-add6-884827ca2852"), "C.18.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Pre-press and pre-media services" },
                    { new Guid("71a11217-8fc8-499b-82f1-e7160a86f5f8"), "C.18.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Binding and related services" },
                    { new Guid("3bf28df9-ed00-48dd-8571-1c9614078c91"), "C.18.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Reproduction of recorded media" },
                    { new Guid("d42c1876-4374-4139-a3e8-cbdaa5c92167"), "C.18.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("093234bf-3d80-453d-adce-10df96fc1e99"), "C.19", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("39e8addc-fabd-4e0e-8dd8-1555942ad155"), "C.19.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of coke oven products" },
                    { new Guid("db4a02f6-be45-4e72-be8c-8333f92fbe4a"), "C.19.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of coke oven products" },
                    { new Guid("f49eda19-4f88-4804-922c-ccd0c4685a41"), "C.19.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of refined petroleum products" },
                    { new Guid("7555422c-19c8-42c2-82bc-cb5e58ed0f96"), "C.19.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of refined petroleum products" },
                    { new Guid("80a64486-bc12-44ca-b7f4-8d8fe65c74a6"), "C.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of chemicals and chemical products" },
                    { new Guid("c1011292-0b6d-459e-a15f-ecec7842efe4"), "C.20.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("d5997e50-89d8-4927-ab8f-6151c6fec567"), "C.20.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of industrial gases" },
                    { new Guid("d94953b5-0a63-466b-8503-ba275cc71ac6"), "C.20.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of dyes and pigments" },
                    { new Guid("09c1f14b-5656-4198-b275-04cf9ca5c456"), "C.20.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("9b129804-91dd-4374-9341-53671efa7f35"), "C.20.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other organic basic chemicals" },
                    { new Guid("4494d58f-0b3b-4dd6-bf8b-fdbf9b0f146e"), "C.20.15", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("746c2de9-b512-4112-a9f8-9a6307135ede"), "C.20.16", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of plastics in primary forms" },
                    { new Guid("9f7d95cd-3547-42ef-9785-0dfa60a25421"), "C.20.17", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("9f83df99-d37c-435e-b815-27b38dd01faa"), "C.20.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("ebb91e2e-5897-4772-a060-6f63d655a091"), "C.20.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("99ba9e9e-5c0f-45a2-a853-61fc4a577dd2"), "C.20.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("eec56209-3c7f-487f-b25d-ea669a444fff"), "C.20.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("246c8ef1-7f52-4cd7-8feb-a7b7e6b9a47a"), "C.20.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("170ceb70-dd11-4b06-b768-ca037faa5033"), "C.17.24", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wallpaper" },
                    { new Guid("2c43f94e-1961-43c5-8fd8-cee9e1595c2a"), "C.23.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of refractory products" },
                    { new Guid("d5328a4e-b7ed-4335-addf-a09de5edb9ac"), "C.11.0", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of beverages" },
                    { new Guid("2cacc9f6-ff96-49fe-8296-42f8b887307e"), "C.10.92", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of prepared pet foods" },
                    { new Guid("1dc12e68-ed31-44d9-9c92-a5516c47ae1e"), "A.01.6", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("a0abf5af-ab29-432f-a9b1-825691ef981c"), "A.01.61", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Support activities for crop production" },
                    { new Guid("c2bcd65e-0552-4084-8109-519cdd80935f"), "A.01.62", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Support activities for animal production" },
                    { new Guid("df77cfbf-7889-4c2c-af1b-cc5a6a81c2d5"), "A.01.63", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Post-harvest crop activities" },
                    { new Guid("675dea90-1566-41cc-9b6b-4ed66edc5ffc"), "A.01.64", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Seed processing for propagation" },
                    { new Guid("6d5b891f-456a-4fb0-bb4a-6719075796a5"), "A.01.7", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Hunting, trapping and related service activities" },
                    { new Guid("dbf29f61-61f0-486e-9f4b-1b35ce0c7420"), "A.01.70", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Hunting, trapping and related service activities" },
                    { new Guid("62cce76b-ee11-440a-89cc-dbfc8091fe1d"), "A.02", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Forestry and logging" },
                    { new Guid("b961c2f5-2d1f-4ec3-9a2b-922de4421070"), "A.02.1", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Silviculture and other forestry activities" },
                    { new Guid("b732203e-fad6-41c9-96cf-64dee874bc34"), "A.02.10", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Silviculture and other forestry activities" },
                    { new Guid("fcb54077-e3b6-4ab3-9f2e-53b8b3d2d8e5"), "A.02.2", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Logging" },
                    { new Guid("408606e1-609e-463d-a0de-12a1f9134467"), "A.02.20", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Logging" },
                    { new Guid("eb677bff-1a62-42d9-ae59-ac5220ef29a4"), "A.01.50", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Mixed farming" },
                    { new Guid("deea40a2-2887-4ab3-b15c-fa188b4081cb"), "A.02.3", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Gathering of wild growing non-wood products" },
                    { new Guid("25794169-dc72-497c-9efe-ca70ab0bcb11"), "A.02.4", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Support services to forestry" },
                    { new Guid("b9f308ba-bd86-4a7f-bd77-356f2705b62c"), "A.02.40", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Support services to forestry" },
                    { new Guid("c1603fd0-19c3-408a-a774-563ec2a65a4e"), "A.03", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Fishing and aquaculture" },
                    { new Guid("d4e7840d-1ab9-48af-989c-7805c9df2d47"), "A.03.1", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Fishing" },
                    { new Guid("2d1fa698-d451-4fdf-86ba-b6cd6228d0ce"), "A.03.11", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bb4ee41f-6a50-417c-85b9-abf11d1cfd5d"), "A.03.12", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Freshwater fishing" },
                    { new Guid("483be8f3-f335-4a99-8866-cd0863e33fea"), "A.03.2", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Aquaculture" },
                    { new Guid("8aa1febd-bef2-4406-b877-c0ddb6d85286"), "A.03.21", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Marine aquaculture" },
                    { new Guid("e782293f-095e-48c8-a187-8751c5d17ecf"), "A.03.22", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Freshwater aquaculture" },
                    { new Guid("f2c8a054-2300-4373-b575-92f552511348"), "B.05", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of coal and lignite" },
                    { new Guid("8b3f127f-681c-421a-ae82-36999b017371"), "B.05.1", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of hard coal" },
                    { new Guid("22936167-3688-4651-b81d-49a880c01cf5"), "B.05.10", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of hard coal" },
                    { new Guid("7a1ca61a-c007-43a3-8cec-6bbd51854c32"), "A.02.30", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Gathering of wild growing non-wood products" },
                    { new Guid("d88ab481-bed0-4a7b-9b8c-6fbed868c436"), "A.01.5", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Mixed farming" },
                    { new Guid("0fccdeed-c4ef-4c15-9c81-e4660fc391da"), "A.01.49", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of other animals" },
                    { new Guid("13bec7d1-9826-4ebb-b479-43dbfad4c6d4"), "A.01.47", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of poultry" },
                    { new Guid("960d3d2b-bdf0-4788-ab5d-9246066d0d87"), "A.01.1", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of non-perennial crops" },
                    { new Guid("1ee52ccd-e996-48b1-b0ef-32b883f319ab"), "A.01.11", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("ddbff370-e40f-42ac-862d-e0e0ca6af960"), "A.01.12", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of rice" },
                    { new Guid("322f4673-6138-4991-9c5f-9a1f0c649491"), "A.01.13", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("a7a8fdad-39ca-4e18-ae66-49be2702c92d"), "A.01.14", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of sugar cane" },
                    { new Guid("fbce186f-5228-4598-b46b-c3137bb37af2"), "A.01.15", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of tobacco" },
                    { new Guid("91a3d566-a610-4878-8b48-67b4285ca056"), "A.01.16", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of fibre crops" },
                    { new Guid("6560d159-b3f2-4f3c-a099-5cfa631e7811"), "A.01.19", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of other non-perennial crops" },
                    { new Guid("74289e8f-baa9-494f-8ade-b1cf10f454e6"), "A.01.2", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of perennial crops" },
                    { new Guid("dc9b8788-8ffe-452a-bb8c-8f04f4b89766"), "A.01.21", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of grapes" },
                    { new Guid("8b6ab9ae-b691-4f9f-a950-6b1f85692462"), "A.01.22", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of tropical and subtropical fruits" },
                    { new Guid("8ebec27f-79ac-4728-ab7d-cc1829b0f915"), "A.01.23", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of citrus fruits" },
                    { new Guid("eda17544-f32e-4b06-ae80-0532033270ca"), "A.01.24", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of pome fruits and stone fruits" },
                    { new Guid("0c388e51-9d98-4db9-abe2-6d285b3db24a"), "A.01.25", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("938c9222-608c-4538-a338-dc080d1ab4f4"), "A.01.26", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of oleaginous fruits" },
                    { new Guid("70cbe4af-8d83-412e-b31d-393132647a76"), "A.01.27", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of beverage crops" },
                    { new Guid("f129f353-f7d6-40ce-a835-e4500db000a2"), "A.01.28", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("375cfced-aef2-4838-907e-6e2f12b5f79b"), "A.01.29", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Growing of other perennial crops" },
                    { new Guid("e909696b-4e2a-4266-a359-98ce7c507461"), "A.01.3", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Plant propagation" },
                    { new Guid("e8180c69-399e-48ff-9b8d-b40ee3b70b55"), "A.01.30", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Plant propagation" },
                    { new Guid("78ce0c61-9384-4e98-a466-66482563cc6d"), "A.01.4", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Animal production" },
                    { new Guid("3d16d8f3-ea6e-430f-b47f-77a68b2ca554"), "A.01.41", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of dairy cattle" },
                    { new Guid("0c948ec8-48dc-480d-8054-e24eb20bed1d"), "A.01.42", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of other cattle and buffaloes" },
                    { new Guid("aa40495b-b31d-4a9e-aa48-21f5ca3ae978"), "A.01.43", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of horses and other equines" },
                    { new Guid("d5da1934-389b-4169-9350-34613b0215ff"), "A.01.44", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of camels and camelids" },
                    { new Guid("274988f0-6c0d-4675-bf8f-55b0d6cac09a"), "A.01.45", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of sheep and goats" },
                    { new Guid("d49a67b8-ce2b-47c2-b82f-8ec785f89e69"), "A.01.46", new Guid("48be067a-2b5d-4305-a4ce-3e794f60698b"), "Raising of swine/pigs" },
                    { new Guid("7108095b-3945-4387-8141-8537e28e8a83"), "B.05.2", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of lignite" },
                    { new Guid("cf4d3b29-de86-4710-8d0b-efd9f89c4bdd"), "C.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of beverages" },
                    { new Guid("90e5ee29-5b9f-4495-89f7-ea0c22b08e6f"), "B.05.20", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of lignite" },
                    { new Guid("db10b0a1-f384-4cf2-a3dc-dd8101d0f319"), "B.06.1", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f681a796-1b3d-4087-870c-bfca3bc08045"), "C.10.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of potatoes" },
                    { new Guid("71dce193-c39c-431c-a2b9-91825f8fad98"), "C.10.32", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("d8df1884-b9c4-43d8-83e5-74ce5546fb5c"), "C.10.39", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("f1f4b637-9068-48d7-8580-841359c2e6eb"), "C.10.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("bcac859b-05f2-4598-852f-2e5fe65ffc30"), "C.10.41", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of oils and fats" },
                    { new Guid("8e8a4d81-f4e1-4707-9337-96cc0ed66c17"), "C.10.42", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("39434222-a8a3-4dfb-bb17-a50b51e505ac"), "C.10.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of dairy products" },
                    { new Guid("2b788c2b-381e-4686-a6f6-dbacdfa07f23"), "C.10.51", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Operation of dairies and cheese making" },
                    { new Guid("07f3db83-0be9-4c7b-abd5-fa5b640fbfab"), "C.10.52", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ice cream" },
                    { new Guid("34ec2448-081f-4c37-b5a5-c3344b4ace6e"), "C.10.6", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("0cd83c04-08a5-471c-b9a7-26617d0e591d"), "C.10.61", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of grain mill products" },
                    { new Guid("c6b7870a-8026-4c6b-a14c-01867672dde7"), "C.10.62", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of starches and starch products" },
                    { new Guid("00e1873c-972d-4f5e-9e15-62d976239729"), "C.10.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("cb623939-8b1d-4f36-a234-5cf9c5e4e4bf"), "C.10.7", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("889561dc-71b0-47ea-ac76-26aa9d137f30"), "C.10.72", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("d9556ce7-726b-433b-b582-79eb1b35e1b2"), "C.10.73", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("df74e841-bad2-47bc-b73c-ad312719873e"), "C.10.8", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other food products" },
                    { new Guid("82fd4d03-07ba-49f6-ac81-a351619c95c7"), "C.10.81", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of sugar" },
                    { new Guid("02a4be8a-dc75-40dc-b9dc-9cfab94bef85"), "C.10.82", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("130f33e3-fd7e-4566-b375-ffd05c633235"), "C.10.83", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing of tea and coffee" },
                    { new Guid("5a4492ae-1686-47f2-8f11-6ce7b34a23a6"), "C.10.84", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of condiments and seasonings" },
                    { new Guid("d94b8b7e-2c87-456d-a897-e0031789ca35"), "C.10.85", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of prepared meals and dishes" },
                    { new Guid("70d2aafd-c91c-45bb-9fcd-961081fab070"), "C.10.86", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("4ba43c41-8383-43b2-b893-9e1182a63e1a"), "C.10.89", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other food products n.e.c." },
                    { new Guid("5c555721-8d75-47db-913f-30311c77578c"), "C.10.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of prepared animal feeds" },
                    { new Guid("75925c84-5b75-4729-bc1d-2749510f0ca6"), "C.10.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("d976e9e6-fa10-4142-84bb-8a8674382c11"), "C.10.71", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("3cb0fa28-a54a-4ea3-8631-3121736f5ef2"), "C.10.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("060bcc2b-fda5-411c-bace-4d6aec71bca7"), "C.10.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("48f5d213-6c8a-4b4a-9cd9-d71c4f43d00b"), "C.10.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Production of meat and poultry meat products" },
                    { new Guid("002b3010-c5c6-49bb-a281-ec9dca23ff1e"), "B.06.10", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of crude petroleum" },
                    { new Guid("e5eb9a98-642c-4c04-b9c3-d8662e66105c"), "B.06.2", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of natural gas" },
                    { new Guid("74a41cf9-adaf-4b48-b081-5b1f38894c09"), "B.06.20", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of natural gas" },
                    { new Guid("5436db9e-9026-4b0b-8323-ea359b44387a"), "B.07", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of metal ores" },
                    { new Guid("2f0e5d3b-28fc-4740-8d9d-1dbb8b2e8220"), "B.07.1", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of iron ores" },
                    { new Guid("f613e52c-22ef-4e49-9b50-e6d640fac5a4"), "B.07.10", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of iron ores" },
                    { new Guid("d6dfc3fe-6414-4d29-8b84-6ec6631f3f89"), "B.07.2", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of non-ferrous metal ores" },
                    { new Guid("8a5761e8-c4a7-465e-b942-d4147e374dd6"), "B.07.21", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of uranium and thorium ores" },
                    { new Guid("e574eb64-9cb7-43c0-955b-fc7fcd842a42"), "B.07.29", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of other non-ferrous metal ores" },
                    { new Guid("a12e834b-284d-43fa-bf1a-a4457b5ccd1e"), "B.08", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Other mining and quarrying" },
                    { new Guid("19b20043-9b52-4ecb-8bae-eca887e339f6"), "B.08.1", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Quarrying of stone, sand and clay" },
                    { new Guid("1c4eebae-0e57-4ba6-9d1a-d2516b814abb"), "B.08.11", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("28db65d8-a9a5-42b4-bdb9-d76acfc0444a"), "B.08.12", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("11ab87f5-6b88-466b-a0af-118ca5e73d88"), "B.08.9", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining and quarrying n.e.c." },
                    { new Guid("7c30e1ef-3ed3-4d4f-b658-9dceba518fe6"), "B.08.91", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("685492f3-8f90-4d68-8927-062744d931dc"), "B.08.92", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of peat" },
                    { new Guid("3549aeba-eb25-4132-89a3-53d34aa1358c"), "B.08.93", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of salt" },
                    { new Guid("a06ebf73-0d3e-44c6-a368-6a9fa1b8b620"), "B.08.99", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Other mining and quarrying n.e.c." },
                    { new Guid("2b1d6cbe-e049-4a93-9347-c3cda38c5856"), "B.09", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Mining support service activities" },
                    { new Guid("840edc5f-def1-40fe-a4bb-04303f4a33f8"), "B.09.1", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("8f2a5aca-e8d5-4091-86c8-c314aca0a908"), "B.09.10", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("dbe30bad-d6f9-4713-98ba-ab180831b98d"), "B.09.9", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Support activities for other mining and quarrying" },
                    { new Guid("a09a101b-4ad8-42e4-81ca-c0d5f94a695a"), "B.09.90", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Support activities for other mining and quarrying" },
                    { new Guid("9fe46b6c-b6f2-444c-9d84-9f2a2047be2d"), "C.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of food products" },
                    { new Guid("504fb564-cf7e-492d-9c28-3b071b4d1f3e"), "C.10.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("2a38445e-87b9-4155-92b7-61c21dc4e429"), "C.10.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of meat" },
                    { new Guid("8d64a60c-0984-4a5c-a075-344d71049ecd"), "C.10.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing and preserving of poultry meat" },
                    { new Guid("3a93470b-67c8-439c-905e-8e23aacfcafa"), "B.06", new Guid("955498af-ac3f-4d4e-a6fa-8d70b96f3b3d"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("4919052d-0fe1-4425-b499-6470b0026b62"), "F.43.2", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("62fcafe2-6f75-48d9-b6d3-4abe82f04fb2"), "C.23.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of refractory products" },
                    { new Guid("0a0160ac-3e39-4e6a-97ef-eefac053e77b"), "C.23.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("3e29cf1c-2ed5-4f32-b34a-1aff57cfff12"), "C.30.92", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("e527614d-6b51-4458-97c5-90db30add315"), "C.30.99", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("1f15dd67-d928-4904-8f44-b2cf147d1972"), "C.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of furniture" },
                    { new Guid("75765f65-cde5-4cb7-83ab-73d787aa63b3"), "C.31.0", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of furniture" },
                    { new Guid("2a59dbc5-fa67-45f1-8953-d9a1141d3330"), "C.31.01", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of office and shop furniture" },
                    { new Guid("5204abd7-09f3-4985-a457-8f27e8dccfb0"), "C.31.02", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of kitchen furniture" },
                    { new Guid("c1328472-100a-45bd-9cd9-9e39179db36f"), "C.31.03", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of mattresses" },
                    { new Guid("f6e89e96-e02b-4933-af4d-095cc8a8e0a5"), "C.31.09", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other furniture" },
                    { new Guid("644da0a6-1750-48d7-a0d6-28597e771bb6"), "C.32", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Other manufacturing" },
                    { new Guid("d30f3ff3-9edc-4c0d-a262-64a34e39a3b9"), "C.32.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("ac613629-bcc7-45c1-8c14-0ca5bd789a47"), "C.32.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Striking of coins" },
                    { new Guid("c8af61eb-4f78-42f7-89a6-78dc47284eee"), "C.32.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of jewellery and related articles" },
                    { new Guid("4732e284-06b2-4c9c-acd4-33fa70044209"), "C.30.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of motorcycles" },
                    { new Guid("b987fd9d-a296-4380-bf25-813913e453fa"), "C.32.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("529a33a1-cb54-4879-9a75-fef772d89abe"), "C.32.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of musical instruments" },
                    { new Guid("f8f5dc69-8ed1-4749-ad81-9718e8901e01"), "C.32.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of sports goods" },
                    { new Guid("382da501-0124-481e-9362-67a5e629d3e3"), "C.32.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of sports goods" },
                    { new Guid("86231fc3-1902-4e47-9ffe-ac4bd61dd56d"), "C.32.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of games and toys" },
                    { new Guid("2a49f32d-ae7b-4004-8ae3-ec239e7a6d92"), "C.32.40", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of games and toys" },
                    { new Guid("0c5c02da-66a4-4fa2-b3ea-ef201e9a21d8"), "C.32.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("b4766dfb-fe6c-477c-915f-fc4b5aa73484"), "C.32.50", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("da3acd10-b759-4d51-889f-99bff30fa21d"), "C.32.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacturing n.e.c." },
                    { new Guid("77f3a3e6-af14-4687-be6c-afbb45b321d8"), "C.32.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2f7ef9b7-ef6b-40ca-baf8-cc5b755c3d71"), "C.32.99", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Other manufacturing n.e.c." },
                    { new Guid("af685007-6fc5-4c9a-94d0-b5630b3e129b"), "C.33", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair and installation of machinery and equipment" },
                    { new Guid("47751355-e02d-43a9-a831-d707be7de73e"), "C.33.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("c48fbb12-414d-4e4b-860e-ddc71096f0f9"), "C.32.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of musical instruments" },
                    { new Guid("546511aa-63b2-4e17-a010-28c2de0695ed"), "C.30.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("bddaee6d-1420-4bf7-b6a9-0f8b520cd771"), "C.30.40", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of military fighting vehicles" },
                    { new Guid("8ca7a91f-0510-4d54-8c1f-a7c9246fac77"), "C.30.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of military fighting vehicles" },
                    { new Guid("00ee54a2-1825-417e-89e2-56b27d94b579"), "C.28.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("81034a59-444a-4294-894b-c6dd0fd8c237"), "C.28.41", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of metal forming machinery" },
                    { new Guid("40ea91bc-e11c-4e3b-aa4d-45e8c290cbbd"), "C.28.49", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other machine tools" },
                    { new Guid("478b0c19-907d-43c1-8967-2bdae5e5e964"), "C.28.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other special-purpose machinery" },
                    { new Guid("e4d3edc0-90e9-44be-8f94-0b7a96e05ae3"), "C.28.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of machinery for metallurgy" },
                    { new Guid("d7df8743-d025-4c39-abe6-ea6d6de10dae"), "C.28.92", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("6d50842a-ac79-4b63-b2d7-f4645f5e7ba2"), "C.28.93", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("829f1197-83f4-4b95-a5be-e169d917542c"), "C.28.94", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("98489754-a538-4578-8ab0-d0daf18d16ad"), "C.28.95", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("620e2e83-b347-489e-8398-d5d9922432d7"), "C.28.96", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("f864e64b-eade-45f5-8867-486bc829512f"), "C.28.99", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("72f6531b-8156-46dc-b8bc-ada9ae4dd414"), "C.29", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("cd413da6-308b-4511-8979-313c585e87cf"), "C.29.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of motor vehicles" },
                    { new Guid("ebda525f-4e07-4b98-b965-ec2da73e8e87"), "C.29.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of motor vehicles" },
                    { new Guid("4f0fe3ed-f67a-4b18-9cc6-e73f582c9a75"), "C.29.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("71d59837-b89d-45d6-bcc5-6aba9a7f20be"), "C.29.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("4275f475-62c3-4626-9f04-19d2d9f2a74f"), "C.29.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("656da337-3e7b-415a-bc1a-a3b92f9248f2"), "C.29.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("16348985-e3e5-4eee-b5c3-ee3f0d5772bb"), "C.29.32", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("c48a12be-9b3e-4119-98f3-552cde5da2d9"), "C.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other transport equipment" },
                    { new Guid("375f3d7a-9f79-42bb-b1ed-da33061a8057"), "C.30.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Building of ships and boats" },
                    { new Guid("08de91c8-0f16-4600-81bb-a1ec18a24213"), "C.30.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Building of ships and floating structures" },
                    { new Guid("c8997e53-8a95-4dcd-958a-23c07d361d77"), "C.30.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Building of pleasure and sporting boats" },
                    { new Guid("2533d0cc-3e3e-4285-9769-21b74c7b000e"), "C.30.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("0b7b43f2-786d-49f5-a504-fc95f812b53b"), "C.30.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("e7c9d934-99c7-4171-8c39-e5651edbf895"), "C.30.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("5bbb1bbb-0339-4647-9d4f-13ab2cbe4fe1"), "C.30.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("0fc35ca2-d5c4-4c09-9120-3f595391a91a"), "C.33.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair of fabricated metal products" },
                    { new Guid("0665c57a-9ed9-44e0-add9-d7eb42389cad"), "C.28.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("ce67084d-ab01-4feb-b610-17879d183206"), "C.33.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair of machinery" },
                    { new Guid("01f9902c-3385-4cee-bbf1-aa8c61e01930"), "C.33.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair of electrical equipment" },
                    { new Guid("db7ca49a-ecde-4dfd-b03d-c0acc402ba13"), "E.38.3", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Materials recovery" },
                    { new Guid("b5967a08-82e7-4137-ab21-75b7f69705cc"), "E.38.31", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Dismantling of wrecks" },
                    { new Guid("4d3b91f1-6139-474f-9558-8fb20611612a"), "E.38.32", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Recovery of sorted materials" },
                    { new Guid("9309bdd6-c3a6-4e78-8253-0bbef503ffa3"), "E.39", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bf980598-12ef-4010-84d5-4b944f0c956b"), "E.39.0", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Remediation activities and other waste management services" },
                    { new Guid("f0b248ed-7dec-4ca9-b1c1-2f10739f88a2"), "E.39.00", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Remediation activities and other waste management services" },
                    { new Guid("463243e2-9666-4d7a-8474-64b7f9e9f0d1"), "F.41", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of buildings" },
                    { new Guid("8ade6d8c-c7b0-47b2-9c77-ab5e8c8f7989"), "F.41.1", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Development of building projects" },
                    { new Guid("c2c43e1d-d998-4071-9fed-3616913603c2"), "F.41.10", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Development of building projects" },
                    { new Guid("d4342356-6577-4d47-995b-b773a09b24c0"), "F.41.2", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of residential and non-residential buildings" },
                    { new Guid("37b9da8d-1c8d-4315-bcd8-fcf183aaf1e4"), "F.41.20", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of residential and non-residential buildings" },
                    { new Guid("f50a3e6b-69c7-4b93-bc93-10d4bc6bb1a9"), "F.42", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Civil engineering" },
                    { new Guid("7c199de9-694c-4583-a007-7361b013e421"), "E.38.22", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Treatment and disposal of hazardous waste" },
                    { new Guid("1a5a8a8c-8477-402b-a666-9be42c66091f"), "F.42.1", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of roads and railways" },
                    { new Guid("6799821c-3cb6-4b94-88cb-1f30d94c48d2"), "F.42.12", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of railways and underground railways" },
                    { new Guid("1fbd128e-a8e8-4f30-a247-2d72182e2fdb"), "F.42.13", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of bridges and tunnels" },
                    { new Guid("d6490a14-18c3-4b34-abef-b8e83e94b3ea"), "F.42.2", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of utility projects" },
                    { new Guid("647db6ee-d799-4f87-99ab-684c7a51b5fc"), "F.42.21", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of utility projects for fluids" },
                    { new Guid("10688fdb-322f-4ab2-b21a-adb3657ca3fc"), "F.42.22", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("6d82bcd1-e636-4a46-b095-791cc9604867"), "F.42.9", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of other civil engineering projects" },
                    { new Guid("249b8f94-7382-45a6-8a67-b7f279685f24"), "F.42.91", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of water projects" },
                    { new Guid("8aae2810-07f7-4069-8fc4-018aa67f2286"), "F.42.99", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("8eb16ec6-e21e-42fc-adb9-0d1e2a57cb01"), "F.43", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Specialised construction activities" },
                    { new Guid("6e63fd9a-f6f6-4f91-9a18-8956d4eb2e23"), "F.43.1", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Demolition and site preparation" },
                    { new Guid("42e82c97-2131-4071-92f4-7b30826e63b5"), "F.43.11", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Demolition" },
                    { new Guid("f42229a2-0649-4dd9-bd43-64cd3aea5e68"), "F.43.12", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Site preparation" },
                    { new Guid("d99ae207-d524-4bcd-927a-fdf11804501e"), "F.42.11", new Guid("1dfd798f-ea93-42f6-9b38-4edf8393ba1a"), "Construction of roads and motorways" },
                    { new Guid("15e3a952-f47a-4359-9b80-d49b3a2796d8"), "E.38.21", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("29ff5b17-e8b0-4aee-8bbb-eb1fcdcdc606"), "E.38.2", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Waste treatment and disposal" },
                    { new Guid("ced3cea8-f32a-46a7-b35b-680622477a4d"), "E.38.12", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Collection of hazardous waste" },
                    { new Guid("b46f9e86-f0f8-4fcb-95f4-0cce181ef8b9"), "C.33.15", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair and maintenance of ships and boats" },
                    { new Guid("4de8f2b7-1ba4-4853-b244-b309460632c0"), "C.33.16", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("3111a037-e839-426d-ae15-ead892a1945a"), "C.33.17", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair and maintenance of other transport equipment" },
                    { new Guid("86a67fb6-cf46-4e2e-93b0-defc15fe54de"), "C.33.19", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair of other equipment" },
                    { new Guid("86bc5b7e-a74b-476a-8204-60d377459ca4"), "C.33.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Installation of industrial machinery and equipment" },
                    { new Guid("32c72728-38a9-42ed-ace3-6cb89b56e31b"), "C.33.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Installation of industrial machinery and equipment" },
                    { new Guid("2294305e-55cc-49ac-b171-04c4ffc81b58"), "D.35", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("d72e2deb-31fd-4015-ae1f-634e22149119"), "D.35.1", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Electric power generation, transmission and distribution" },
                    { new Guid("82e671e8-e4e6-416a-a68f-f1b2862239fb"), "D.35.11", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Production of electricity" },
                    { new Guid("516028d7-f59d-4c20-88d2-52522412c33c"), "D.35.12", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Transmission of electricity" },
                    { new Guid("20f5b094-20ee-4c90-b0bc-e85445d65996"), "D.35.13", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Distribution of electricity" },
                    { new Guid("f359ec70-30e6-4b67-85e2-365f3c8b9849"), "D.35.14", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Trade of electricity" },
                    { new Guid("93805005-1ba6-4d6a-95dd-e7cd8cdaf63a"), "D.35.2", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("dfc5523a-471d-450d-9ec2-ee1570b5720e"), "D.35.21", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Manufacture of gas" },
                    { new Guid("5c41d738-54ed-461c-bfed-1fb7cc94f9fc"), "D.35.22", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Distribution of gaseous fuels through mains" },
                    { new Guid("c343add4-9787-494b-89a2-917cbd1457f5"), "D.35.23", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("df2fe050-eafd-4dd2-9e01-d323685cb6eb"), "D.35.3", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Steam and air conditioning supply" },
                    { new Guid("994c40d9-555c-4a53-91d5-00cab7fc4b91"), "D.35.30", new Guid("b81f75ca-3aeb-4830-8e80-2246e673eac7"), "Steam and air conditioning supply" },
                    { new Guid("72cd21c7-7114-426f-a3aa-ea265ece8cbc"), "E.36", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Water collection, treatment and supply" },
                    { new Guid("3e15691c-93a8-4ccb-b1c6-868aeba8287d"), "E.36.0", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Water collection, treatment and supply" },
                    { new Guid("f419755d-9b98-4bdd-b221-6c20e561219b"), "E.36.00", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Water collection, treatment and supply" },
                    { new Guid("954dd4d7-2039-4e25-9205-a5745669eadf"), "E.37", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Sewerage" },
                    { new Guid("3e1ec52b-f41b-4e40-a629-958fd4781ed2"), "E.37.0", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Sewerage" },
                    { new Guid("8681d8db-a189-4243-9bfa-5eaad8749c7b"), "E.37.00", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Sewerage" },
                    { new Guid("9418423c-5a52-4aab-a3fc-f0a60bc21d4d"), "E.38", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("2f5f3fe0-f0e1-4cca-a62e-48bdb118f7a3"), "E.38.1", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Waste collection" },
                    { new Guid("62e4afad-df78-47b5-9b0b-a52fc28f2308"), "E.38.11", new Guid("8ac17cef-cea3-4239-a4d5-ecfe795cffde"), "Collection of non-hazardous waste" },
                    { new Guid("4144a006-dd71-4ec5-bffc-646c8daade9d"), "C.33.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Repair of electronic and optical equipment" },
                    { new Guid("8e76b578-5dcc-47ad-ac39-fd4b698a61f6"), "C.23.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of clay building materials" },
                    { new Guid("083a5a63-db4d-43c9-b7c8-7d7fb70fc94a"), "C.28.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("bdc35291-c5ea-4f0f-81d8-93311bff3612"), "C.28.25", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("50b9405d-1965-4d3c-a307-304599f18259"), "C.24.34", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Cold drawing of wire" },
                    { new Guid("dd8ea7ee-5a64-4169-ab8e-8a612a46e957"), "C.24.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("0a46e45b-3a10-472b-9849-abccecfa2344"), "C.24.41", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Precious metals production" },
                    { new Guid("26dbe1c9-b7cb-4eaf-b7c7-736c4cee0c33"), "C.24.42", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Aluminium production" },
                    { new Guid("1d26a5f5-a39c-4d04-8545-65fac3be3950"), "C.24.43", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Lead, zinc and tin production" },
                    { new Guid("3644255c-4b3e-4529-9192-f5cf93ea1a48"), "C.24.44", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Copper production" },
                    { new Guid("8aad2a3c-e733-47e1-9bef-fcf9ab4573be"), "C.24.45", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Other non-ferrous metal production" },
                    { new Guid("1b2d18ea-24cb-4c07-8c68-c892493a1342"), "C.24.46", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Processing of nuclear fuel" },
                    { new Guid("bceef7c3-6a93-477f-9480-54e6f7bdead0"), "C.24.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Casting of metals" },
                    { new Guid("21fd763d-449b-4435-badf-c5230ac0f9bf"), "C.24.51", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Casting of iron" },
                    { new Guid("bbbe71fe-9216-4dba-86f3-e7c26e59e1c7"), "C.24.52", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Casting of steel" },
                    { new Guid("7afe73c8-e1da-4f0f-8c77-19b4dae7c8f2"), "C.24.53", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Casting of light metals" },
                    { new Guid("1aa1f696-efe5-431b-8c83-4bd6bf48db11"), "C.24.33", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Cold forming or folding" },
                    { new Guid("1f22503d-24fc-4c3e-9b1c-13c1b815645f"), "C.24.54", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Casting of other non-ferrous metals" },
                    { new Guid("0ef27e5a-ae01-46f9-bbfb-7dbc91810c30"), "C.25.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of structural metal products" },
                    { new Guid("624b7991-2bb3-4e1c-8852-949293a8600e"), "C.25.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("4f4da9d4-41f6-49b7-acb2-a6061a9b7183"), "C.25.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of doors and windows of metal" },
                    { new Guid("4206e345-12ec-4435-9d5c-cf06e6328f0d"), "C.25.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("a6606b4d-4630-427a-9816-06dc0b25fb13"), "C.25.21", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("7af93ef0-aab4-44a9-bc6b-7e50f1398a34"), "C.25.29", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("10fdabca-f71c-4088-b964-0ae35438e140"), "C.25.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("f0bb90cc-7b2b-45bd-8dc9-2494c9a03423"), "C.25.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("dfb906a1-8fe7-41a7-96a3-0bed0ede6232"), "C.25.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of weapons and ammunition" },
                    { new Guid("c11f7a5b-71cc-4e1c-91a3-bc81205b02c1"), "C.25.40", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of weapons and ammunition" },
                    { new Guid("079e1ea7-0a1f-4e40-b8b4-8354e756a16e"), "C.25.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("469453e6-bed3-4c98-b355-e333c8b41373"), "C.25.50", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("f8a1489c-cfd4-405a-9fa6-f6d0e6b50642"), "C.25", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("210373ec-d32d-4938-8883-77263c9d8bd4"), "C.24.32", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Cold rolling of narrow strip" },
                    { new Guid("e4b83d92-681d-4b00-845b-58d2672882b9"), "C.24.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Cold drawing of bars" },
                    { new Guid("52f8b395-c312-4fde-a377-726e5be7b58a"), "C.24.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other products of first processing of steel" },
                    { new Guid("1a4f8cd2-c875-42f6-a8ab-f72ed6b4a7eb"), "C.23.32", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("3a83555b-557e-43c6-8131-6659d2e421cd"), "C.23.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("3f74f361-c279-4a24-b583-fdd6d7c636b3"), "C.23.41", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("a0496f82-cf3b-4271-8daf-cfa4a8f80766"), "C.23.42", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("2079b7f6-2c63-4751-b7c3-ccc93acd9a9f"), "C.23.43", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("73825518-dcb3-4734-94e6-02bf862c4e9f"), "C.23.44", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other technical ceramic products" },
                    { new Guid("6a8acbd7-d3c5-4a72-88fb-ebd9e798ba91"), "C.23.49", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other ceramic products" },
                    { new Guid("9b3a2b1d-ce82-4920-a8d9-133b5eef7ff3"), "C.23.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cement, lime and plaster" },
                    { new Guid("96bcce16-92f1-4a30-aa5e-a31bf441572c"), "C.23.51", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cement" },
                    { new Guid("eff55301-012f-4411-a9cb-29aad366270e"), "C.23.52", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of lime and plaster" },
                    { new Guid("3037c337-05ee-4722-87f3-a0e8046d1098"), "C.23.6", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("34db4d47-d512-4008-baca-89d4970f1e83"), "C.23.61", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("19fa38bc-a860-4b7e-8ce1-4f56394af8f5"), "C.23.62", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("a561ce00-300d-4e68-89c9-3537da0b7f31"), "C.23.63", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ready-mixed concrete" },
                    { new Guid("c400bd11-f258-49b8-9334-bdefa31937df"), "C.23.64", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of mortars" },
                    { new Guid("70af9229-8d69-4ad4-a15d-bcba63fa30dd"), "C.23.65", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fibre cement" },
                    { new Guid("c25284e8-254d-479c-a39e-b7029f35f724"), "C.23.69", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("f762448d-0528-4c60-bf1c-25ec9faffd73"), "C.23.7", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Cutting, shaping and finishing of stone" },
                    { new Guid("fcb3ef6a-0548-4976-8324-4b6cae7b8acd"), "C.23.70", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Cutting, shaping and finishing of stone" },
                    { new Guid("43c8f29c-eef1-4996-b423-9001e5a23c03"), "C.23.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("8f8adf51-2241-4fc9-89a8-a4702f1c7ac1"), "C.23.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Production of abrasive products" },
                    { new Guid("55f79ef9-8a8d-4eef-ad37-d8213d9d5249"), "C.23.99", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("5fbcc25d-9a37-4a08-b161-e4af575ae9d8"), "C.24", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic metals" },
                    { new Guid("cf78693b-ee2f-46c8-821b-77652a3576f7"), "C.24.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("cd4fe021-d6da-4641-819d-6d0fc5043fa0"), "C.24.10", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("9f76baf5-091b-43ef-8efe-e2e46b40d2d2"), "C.24.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("934c94d5-56c7-4973-9f9a-4dba45d116e2"), "C.24.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("655f8526-5bc7-4a1a-b373-4861e2c15ff6"), "C.25.6", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Treatment and coating of metals; machining" },
                    { new Guid("ec65db67-74c2-49bf-92c0-582879452328"), "C.28.29", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("b940b6b8-d0fd-4866-b3f1-251b0649c903"), "C.25.61", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Treatment and coating of metals" },
                    { new Guid("58f80277-fc61-475e-88cb-a338d2a527b9"), "C.25.7", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("520f7f20-3642-451b-87ca-369eee61f0c6"), "C.27.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("7089dd6a-a33f-4c7e-a6d4-14a848e5fb33"), "C.27.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of batteries and accumulators" },
                    { new Guid("3cdb23fd-1f72-4a81-b7d2-fcdab563a1b8"), "C.27.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of batteries and accumulators" },
                    { new Guid("b058242a-08b2-4b63-83bf-0d12eee1bba6"), "C.27.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wiring and wiring devices" },
                    { new Guid("f10d3cf2-f213-4731-83ad-1d873e64250c"), "C.27.31", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fibre optic cables" },
                    { new Guid("6c520f4e-662e-4642-9f3a-791d2452da11"), "C.27.32", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("9d07ed3b-d66b-4cff-b28b-d89f4f4d3534"), "C.27.33", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wiring devices" },
                    { new Guid("74d3c5bb-7d72-4dc6-ab7e-18f6637c73b3"), "C.27.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("02bd5898-df95-4057-95e3-a0aa1a6b76b8"), "C.27.40", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electric lighting equipment" },
                    { new Guid("857a2241-5273-41da-9232-b5d631ce1d61"), "C.27.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of domestic appliances" },
                    { new Guid("371deba2-dee0-46c1-b09a-fd093175f8d8"), "C.27.51", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electric domestic appliances" },
                    { new Guid("c7fad3ad-8690-4677-b089-3c0f8f2f33e9"), "C.27.52", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("aa4e0759-9338-4f5d-ac8c-8eb5f416caaf"), "C.27.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("2b634c58-a022-4b22-9b9b-3f23ea316315"), "C.27.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other electrical equipment" },
                    { new Guid("ac366190-079a-4ee4-ae1e-68eba127b86e"), "C.28", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("884e9618-0404-479a-bcf1-9b8db73db213"), "C.28.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of general-purpose machinery" },
                    { new Guid("50b31f61-2588-4ded-ae93-1719d53ffc28"), "C.28.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("b5364fe4-1350-445c-b474-e7a6b9d3fd31"), "C.28.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fluid power equipment" },
                    { new Guid("c106b544-521a-4ad4-af09-1f56f3ceb31a"), "C.28.13", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other pumps and compressors" },
                    { new Guid("eab8982b-b644-4478-a9dc-1a695b2cc361"), "C.28.14", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other taps and valves" },
                    { new Guid("e50e7a28-83ca-4ee1-80ef-b9cbc9c6e142"), "C.28.15", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("fab5265e-60bc-423c-8048-743eaf0ff064"), "C.28.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other general-purpose machinery" },
                    { new Guid("291e3261-b84b-431c-9571-0500a973a950"), "C.28.21", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("1fc4b12e-d58a-4ea4-b6f8-b039455a6376"), "C.28.22", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of lifting and handling equipment" },
                    { new Guid("fe1fc5c3-0fb2-400f-b5ae-e32269eb2f69"), "C.28.23", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("040804b3-b42b-4c12-bdaf-2a49963681f5"), "C.28.24", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of power-driven hand tools" },
                    { new Guid("b19eeab3-0f0a-45f4-ac22-99b51174c711"), "C.27.90", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other electrical equipment" },
                    { new Guid("a4ceccda-f220-4fde-a8fd-c78993df79e0"), "C.27.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("3b7eab15-b064-42dd-97bb-e9c22a9bc2c2"), "C.27", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electrical equipment" },
                    { new Guid("a0f01263-5dbd-43a3-89a2-dde2d5c33a2c"), "C.26.80", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of magnetic and optical media" },
                    { new Guid("8652ec3a-930e-46ed-a706-34782946a0d5"), "C.25.71", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of cutlery" },
                    { new Guid("8eb4b611-d336-4d7d-86c4-992abc406658"), "C.25.72", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of locks and hinges" },
                    { new Guid("98a6b48b-20b2-4c49-b31a-3ff2623583d4"), "C.25.73", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of tools" },
                    { new Guid("d6cab3ff-7b72-400c-a0b0-22b00793a118"), "C.25.9", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other fabricated metal products" },
                    { new Guid("2118fc8d-8ba4-4063-aa54-32506d67c709"), "C.25.91", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of steel drums and similar containers" },
                    { new Guid("91a9a5ad-e680-4882-8fe8-44fb620944f7"), "C.25.92", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of light metal packaging" },
                    { new Guid("d872afe6-5582-41e1-abc7-3bde2f092f1a"), "C.25.93", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of wire products, chain and springs" },
                    { new Guid("12d2b293-809e-4a2a-9ed8-2ac582be9851"), "C.25.94", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("549c4f7d-de8b-4786-b204-8d2d11ff6db9"), "C.25.99", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("78dd923b-2494-4aff-9b4d-f3e7f635ba96"), "C.26", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("cf9791f7-2a66-4bf7-a9e6-bf933e35e9f3"), "C.26.1", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electronic components and boards" },
                    { new Guid("d18f553e-110c-49aa-88d4-de0508623058"), "C.26.11", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of electronic components" },
                    { new Guid("c34e9224-1210-4b75-bcd9-1f94e518b5e3"), "C.26.12", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of loaded electronic boards" },
                    { new Guid("056c8971-1382-448a-8b2c-d3db5907888b"), "C.26.2", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("2caca919-1c83-4918-b5d9-ea2aeeeaaa32"), "C.26.20", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("b195afb2-2c81-4488-ac53-0112e6a6f78a"), "C.26.3", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of communication equipment" },
                    { new Guid("24eac652-d7ab-4d26-8e0e-ff008b666974"), "C.26.30", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of communication equipment" },
                    { new Guid("66c755dc-0d4b-4b59-b002-e34165170893"), "C.26.4", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of consumer electronics" },
                    { new Guid("92d441fb-027c-4402-b3eb-35420ec45288"), "C.26.40", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of consumer electronics" },
                    { new Guid("b1dae218-4b44-41c1-97f4-7d33a7e312ce"), "C.26.5", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4eab1ce0-28d7-421c-a71e-d3bf90d92f1d"), "C.26.51", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("2e5f9e9c-2376-4560-a964-1e938550bb11"), "C.26.52", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of watches and clocks" },
                    { new Guid("9daf0c8c-5ef3-42be-9ed4-428a25623115"), "C.26.6", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("763e593f-309d-4513-9928-aeb7cec6d3cc"), "C.26.60", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("79fd272a-de1e-473a-939b-0a6c896a427b"), "C.26.7", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("539d0e6b-dd1e-445c-9c85-c3792be56569"), "C.26.70", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("03ddf07f-c752-418e-9620-75c4be4d9ee5"), "C.26.8", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Manufacture of magnetic and optical media" },
                    { new Guid("6c032aad-63ec-4120-9591-c1f5446d78c6"), "C.25.62", new Guid("970ece46-1f47-47b7-8e34-b6d57e18c5f4"), "Machining" },
                    { new Guid("f2175664-74cd-4139-b969-e13a9a9656e8"), "U.99.00", new Guid("3be2dff3-ef27-45ba-86ed-94012b8cb823"), "Activities of extraterritorial organisations and bodies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_IndustryId",
                table: "Activities",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlans_ActivityId",
                table: "BusinessPlans",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlans_CountryId",
                table: "BusinessPlans",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlans_LanguageId",
                table: "BusinessPlans",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlans_UserId",
                table: "BusinessPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Attributes_BusinessPlanId",
                table: "Plan_Attributes",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Attributes_TexterId",
                table: "Plan_Attributes",
                column: "TexterId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedPlans_BusinessPlanId",
                table: "SharedPlans",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeId",
                table: "Users",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan_Attributes");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SharedPlans");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "Texters");

            migrationBuilder.DropTable(
                name: "BusinessPlans");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
