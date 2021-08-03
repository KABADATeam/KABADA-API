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
                    Id = table.Column<int>(type: "int", nullable: false),
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
                    IsCostCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRevenueCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsChannelsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerSegmentsCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("aaf950f5-7ace-48b7-a4e6-aeded19ab948"), "AT", "Austria" },
                    { new Guid("ab77ecb5-74b8-4088-91e5-2d2a41a413a0"), "LU", "Luxembourg" },
                    { new Guid("ea52ec60-a194-4f79-ab49-dd869ecf07cc"), "MT", "Malta" },
                    { new Guid("b54d4fa0-14b3-4e52-8285-ca94819ec68b"), "MK", "North Macedonia" },
                    { new Guid("f0337927-2e41-4307-af11-b8bdd08ca973"), "NO", "Norway" },
                    { new Guid("22867841-360f-406c-97fc-b6a547ae0033"), "PL", "Poland" },
                    { new Guid("63b2d4f7-a165-4dd7-bff0-295b117fcece"), "PT", "Portugal" },
                    { new Guid("7b24c5bb-0042-428a-8ca4-a45b90d3f7c5"), "RO", "Romania" },
                    { new Guid("860679ac-885b-4eef-99e7-c62cc1339153"), "RS", "Serbia" },
                    { new Guid("83eb0cdb-dfd7-45ef-b017-59fe1863f4e5"), "SK", "Slovakia" },
                    { new Guid("90f42ff3-9a1d-4163-9eae-8977fc8d49be"), "SI", "Slovenia" },
                    { new Guid("cbe1f193-ef74-49b8-a91b-3a6e785a5724"), "ES", "Spain" },
                    { new Guid("d9828a0a-bec4-444f-aad4-e196a5ee468e"), "SE", "Sweden" },
                    { new Guid("dd776dfb-accc-408b-acf6-2e915b5cc47a"), "CH", "Switzerland" },
                    { new Guid("7e526e7a-d8a9-4ed1-a832-c73df537801c"), "TR", "Turkey" },
                    { new Guid("1b2314bf-32f8-44a0-9f47-c21724fd603a"), "UK", "United Kingdom" },
                    { new Guid("21280142-ede7-4cb4-a80b-5da4c0b966f2"), "LT", "Lithuania" },
                    { new Guid("62e8a7ee-4494-44c3-9f8e-b0ada2968591"), "LI", "Liechtenstein" },
                    { new Guid("25940970-ca76-41fb-8d56-c552f991dc37"), "NL", "Netherlands" },
                    { new Guid("c5f6abbb-84e0-43fa-922c-b2388432d95a"), "IT", "Italy" },
                    { new Guid("42125f42-b5f5-4075-928a-2ec13be15351"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("c5882ec5-86a0-4a68-a27a-a72ecf14fe27"), "BE", "Belgium" },
                    { new Guid("94ae4a7d-7a01-41fb-9090-9d5b8cd3a0ca"), "BG", "Bulgaria" },
                    { new Guid("029243d5-20e0-4c15-a715-3f03650e67fa"), "LV", "Latvia" },
                    { new Guid("17f2e78f-177f-4e45-847e-5ac9a5401c18"), "CY", "Cyprus" },
                    { new Guid("363f1a88-971c-42a1-8523-822dc47ddc45"), "CZ", "Czechia" },
                    { new Guid("398bdd85-6661-40b3-b4b8-dbe75bf7f006"), "DK", "Denmark" },
                    { new Guid("1e464858-1c70-4208-9867-db6ad6466f59"), "EE", "Estonia" },
                    { new Guid("3e6009e3-9864-4da1-a516-a48fe1ef02a0"), "HR", "Croatia" },
                    { new Guid("7e5edb07-8176-4e4d-a78a-fdb54860cb97"), "FR", "France" },
                    { new Guid("88be7b61-b54b-400c-af64-aa088b4eba84"), "DE", "Germany" },
                    { new Guid("b74df096-8d61-4113-8381-c745b345ec24"), "EL", "Greece" },
                    { new Guid("79a78b65-ac2d-4d07-bf0a-dfcf0a35b4ec"), "HU", "Hungary" },
                    { new Guid("62ab22c9-326c-4462-95ab-ba2b777e4a00"), "IS", "Iceland" },
                    { new Guid("67654f76-2150-49e4-a87b-0e69d0641045"), "IE", "Ireland" },
                    { new Guid("58781f10-caf6-4f7e-9b1f-bab13e7cd5ad"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "P", "EN", "Education" },
                    { new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("07fdd34d-52f1-44bb-a87c-e15ca4240ab9"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "L", "EN", "Real estate activities" },
                    { new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "H", "EN", "Transporting and storage" },
                    { new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "J", "EN", "Information and communication" },
                    { new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "F", "EN", "Construction" },
                    { new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "C", "EN", "Manufacturing" },
                    { new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "B", "EN", "Mining and quarrying" },
                    { new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("4d83b344-d568-4b07-ae1f-4be8dc0ad4ea"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("79818a1e-ec61-43f0-9e1c-3e13ff2d9265"), (short)23, null, new Guid("b70c517c-d977-467f-881a-dd41f930abb3"), (short)1, "Accountant" },
                    { new Guid("b70c517c-d977-467f-881a-dd41f930abb3"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("33a039d6-dfed-40ae-bf08-3362bf94f192"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)7, "Other" },
                    { new Guid("ae8fa5fb-753d-410c-a8f8-0ea36cbfa816"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)6, "Communication" },
                    { new Guid("ba61db71-b4a9-449c-a173-1f995d12f83d"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)5, "Maintenance" },
                    { new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("40d17277-903b-45fa-b1d3-062b6efae2a0"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)3, "Gas" },
                    { new Guid("e4affb1f-7eb7-492b-8db9-e50e84e914c2"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)2, "Water" },
                    { new Guid("13e47ab0-ff83-4551-ba10-dcae0c2ea1c9"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)1, "Electricity" },
                    { new Guid("2022d3f5-afef-47ec-9fac-7b6bff413805"), (short)23, null, new Guid("b70c517c-d977-467f-881a-dd41f930abb3"), (short)2, "IT support" },
                    { new Guid("a5307f50-3a48-4e3c-901b-42c6ec86e373"), (short)23, null, new Guid("ba7be635-cc17-4234-9ba8-7f7e0b5e3b1b"), (short)4, "Other" },
                    { new Guid("2eb7ce77-1de9-4302-afce-638ec1a85ae3"), (short)23, null, new Guid("5d634558-1b61-4bbe-ae16-4755d19351f9"), (short)4, "Heat" },
                    { new Guid("7dfb844b-609e-4964-a173-2981dd8a72dc"), (short)23, null, new Guid("b70c517c-d977-467f-881a-dd41f930abb3"), (short)3, "Other" },
                    { new Guid("eca7d9a4-e1e3-48be-91be-b4366330e3ce"), (short)23, null, new Guid("ddedd6f3-275c-4e91-95df-069cf1864cbc"), (short)3, "Finance management" },
                    { new Guid("a470719d-f0db-4010-8fb9-f59fa3a979b9"), (short)23, null, new Guid("7a3d5658-d973-4624-9303-ab2ae2399409"), (short)1, "Other" },
                    { new Guid("ddedd6f3-275c-4e91-95df-069cf1864cbc"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("46c3a4ba-9e0f-4398-aae0-516dc61baee1"), (short)23, null, new Guid("ddedd6f3-275c-4e91-95df-069cf1864cbc"), (short)1, "Management" },
                    { new Guid("dfc591b3-bd33-4cdb-b381-01d1f27efca6"), (short)23, null, new Guid("ddedd6f3-275c-4e91-95df-069cf1864cbc"), (short)2, "Factory workers / service" },
                    { new Guid("f7d74976-052d-4d17-bb23-d1940d59316d"), (short)23, null, new Guid("ddedd6f3-275c-4e91-95df-069cf1864cbc"), (short)4, "Marketing" },
                    { new Guid("208c0c48-9f3f-42fe-ba6e-23bf37faf356"), (short)23, null, new Guid("ddedd6f3-275c-4e91-95df-069cf1864cbc"), (short)5, "Other" },
                    { new Guid("2fd4acc9-2df8-4e9f-9d31-c3b954f4b709"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("80185eda-3eb0-4696-aea1-7a3ab399d18b"), (short)23, null, new Guid("2fd4acc9-2df8-4e9f-9d31-c3b954f4b709"), (short)1, "Other" },
                    { new Guid("1c552317-50e4-4254-bac6-57f2c30a2b0c"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("08510268-ffce-4209-a3f5-5fa36e8eb25b"), (short)23, null, new Guid("1c552317-50e4-4254-bac6-57f2c30a2b0c"), (short)1, "Other" },
                    { new Guid("8ac9f2e6-91a4-4e49-a41d-65067a7eda0c"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("138108e9-5ecc-43e2-9692-1bb084d07fa6"), (short)23, null, new Guid("8ac9f2e6-91a4-4e49-a41d-65067a7eda0c"), (short)1, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("660d6d16-7e91-43f1-ae10-5307f6fc6fdc"), (short)23, null, new Guid("ba7be635-cc17-4234-9ba8-7f7e0b5e3b1b"), (short)3, "Transport" },
                    { new Guid("7a3d5658-d973-4624-9303-ab2ae2399409"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("190d4910-b1c3-42a9-913d-b5db28109778"), (short)23, null, new Guid("ba7be635-cc17-4234-9ba8-7f7e0b5e3b1b"), (short)2, "Production equipment and machinery" },
                    { new Guid("8fe120e8-8ef4-4854-ab5d-122f23455f2f"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("ba7be635-cc17-4234-9ba8-7f7e0b5e3b1b"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("3a3ccfe6-67f7-495b-bb9e-96af3341e087"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("e8c05294-fae1-4aba-b87a-66cf82cb7ff5"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("93d18b3a-0990-4653-9b35-5e44e816badc"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("f86ff145-0bcf-4696-a000-f080e3d0c2ef"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("f7c3da1a-aa7b-478f-a3ce-c9934248bd60"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("6c6c1b6c-f342-4fea-9515-b1595f87da2d"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("81d2f126-3a15-4893-a191-7264830cc827"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("d99af9be-80bc-43a7-bc8d-a8ac20cacb2a"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("337f1e18-5113-40c7-8f04-459574c15e3f"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("82153f15-707d-4b06-b670-06181208c738"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("40e67e40-97cf-4ab0-ab72-ecb973d07960"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("2f6bea67-035f-41e2-a93c-e3aba6c6a281"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("1c83da5a-9879-41d0-b6f9-651fb5d10c92"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("dd8b4045-afaf-49ad-96e7-e58eb42c1ffc"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("f2db7cb4-6bf9-4367-90a7-1e9a13402a64"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("9499cc7a-47dd-43f6-a35c-f7636f2da329"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("0b04d7f6-45f3-4569-b44a-53893e74cb8c"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("9fadf95c-1a22-403d-9108-ea6616caf8c9"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("ab049aac-7d46-4ded-a841-15f144901160"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("43f658c2-f972-4160-a7ad-c02758ad1660"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("56b23b14-cb08-4a85-9580-5fc2035d6f57"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("8b467599-8833-420a-83bb-2dd92aa3c2cc"), (short)23, null, new Guid("56b23b14-cb08-4a85-9580-5fc2035d6f57"), (short)1, "Other" },
                    { new Guid("c932d07d-9139-4393-86c5-b49a0fe65bf9"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("69128588-1ee5-4e62-81da-1ea1693df678"), (short)23, null, new Guid("c932d07d-9139-4393-86c5-b49a0fe65bf9"), (short)1, "Manufacturing buildings" },
                    { new Guid("69ffde56-c484-475c-85a4-1f33d9138fa5"), (short)23, null, new Guid("c932d07d-9139-4393-86c5-b49a0fe65bf9"), (short)2, "Inventory buildings" },
                    { new Guid("5e8e11f6-7973-4170-a61e-a34d600a5448"), (short)23, null, new Guid("c932d07d-9139-4393-86c5-b49a0fe65bf9"), (short)3, "Sales buildings (shops)" },
                    { new Guid("995d5de0-88e0-4644-9f56-343945355d30"), (short)23, null, new Guid("c932d07d-9139-4393-86c5-b49a0fe65bf9"), (short)4, "Other" },
                    { new Guid("f6aabcbe-dbd7-468f-8144-6a2b0da93e10"), (short)23, null, new Guid("ba7be635-cc17-4234-9ba8-7f7e0b5e3b1b"), (short)1, "IT (office) equipment" },
                    { new Guid("4b2544bb-8cbd-4edd-9d70-22b22ac94cbb"), (short)23, null, new Guid("3a3ccfe6-67f7-495b-bb9e-96af3341e087"), (short)1, "Other" },
                    { new Guid("d3820b33-a853-4e83-9196-7518e4566a67"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("6524153f-a6b5-4918-9c54-44e61ae6526b"), (short)23, null, new Guid("943625e5-f672-4acb-82bb-595d4f84f5f7"), (short)1, "Manufacturing building" },
                    { new Guid("58edbac8-4e76-4d42-94ef-29e0478393a2"), (short)26, null, new Guid("1dd3bf6f-37a9-4040-97aa-40b6785119f6"), (short)3, "Volume dependent" },
                    { new Guid("7b3d86a6-2c61-48be-b190-eece68026fd6"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("ed74d964-297a-4edb-9bb0-59dedb07b58e"), (short)26, null, new Guid("7b3d86a6-2c61-48be-b190-eece68026fd6"), (short)1, "Negotiation" },
                    { new Guid("213a811c-957e-43af-9db0-923214cb03c3"), (short)26, null, new Guid("7b3d86a6-2c61-48be-b190-eece68026fd6"), (short)2, "Yield management" },
                    { new Guid("afd491f1-5e34-41a2-89f4-595e2f37e603"), (short)26, null, new Guid("7b3d86a6-2c61-48be-b190-eece68026fd6"), (short)3, "Real time market" },
                    { new Guid("903f2fed-721e-4988-8eff-83692e243edf"), (short)26, null, new Guid("7b3d86a6-2c61-48be-b190-eece68026fd6"), (short)4, "Auctions" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("eba03ad0-4a9c-4bb4-8c5a-de1148d6e3c8"), (short)27, null, null, (short)1, "Direct sales" },
                    { new Guid("fae2867c-c922-4500-a20d-01e757ec9d36"), (short)28, null, new Guid("eba03ad0-4a9c-4bb4-8c5a-de1148d6e3c8"), (short)1, "Own shop" },
                    { new Guid("37c09fc4-5ba8-4aec-a727-c460a5b4ff40"), (short)29, null, new Guid("fae2867c-c922-4500-a20d-01e757ec9d36"), (short)1, "Physical" },
                    { new Guid("ce82a304-ed65-45cc-90d3-91dc7ea9e3ab"), (short)30, null, new Guid("37c09fc4-5ba8-4aec-a727-c460a5b4ff40"), (short)1, "Fixed location" },
                    { new Guid("073e627e-923d-4ce8-8fc3-1582d7a43e37"), (short)30, null, new Guid("37c09fc4-5ba8-4aec-a727-c460a5b4ff40"), (short)2, "Mobile" },
                    { new Guid("5e509119-4908-448e-9c97-f69e100ed4df"), (short)31, null, new Guid("37c09fc4-5ba8-4aec-a727-c460a5b4ff40"), (short)1, "Self pickup" },
                    { new Guid("78b6763c-7d22-4c98-9a4e-eb554ed8748a"), (short)31, null, new Guid("37c09fc4-5ba8-4aec-a727-c460a5b4ff40"), (short)2, "Delivery to home" },
                    { new Guid("837d97ed-2068-4515-a71d-203af3e562a2"), (short)31, null, new Guid("37c09fc4-5ba8-4aec-a727-c460a5b4ff40"), (short)3, "Courier service" },
                    { new Guid("17cfae03-5361-4f5e-b7b9-5577a70bc007"), (short)29, null, new Guid("fae2867c-c922-4500-a20d-01e757ec9d36"), (short)2, "Online" },
                    { new Guid("cc0e9f22-9c5c-4a49-8de6-798fa53a20dc"), (short)30, null, new Guid("17cfae03-5361-4f5e-b7b9-5577a70bc007"), (short)1, "Own website" },
                    { new Guid("d5dcc834-e16d-4528-9015-05d955317dc7"), (short)30, null, new Guid("17cfae03-5361-4f5e-b7b9-5577a70bc007"), (short)2, "Platform" },
                    { new Guid("09a7a0a1-1579-46d7-a060-f50cfefbb20c"), (short)31, null, new Guid("17cfae03-5361-4f5e-b7b9-5577a70bc007"), (short)1, "Own delivery" },
                    { new Guid("45fce602-ec1e-49a2-9afe-0f72b5894bf3"), (short)31, null, new Guid("17cfae03-5361-4f5e-b7b9-5577a70bc007"), (short)2, "Courier service" },
                    { new Guid("5ed296df-0863-4aba-b6ac-e6c07c6298a7"), (short)31, null, new Guid("17cfae03-5361-4f5e-b7b9-5577a70bc007"), (short)3, "To the email" },
                    { new Guid("e799a44e-51f8-48d1-aaad-eb84c7400e98"), (short)28, null, new Guid("eba03ad0-4a9c-4bb4-8c5a-de1148d6e3c8"), (short)2, "Market/Fairs" },
                    { new Guid("cb04121b-0b2f-4953-9a9f-9a8847d694d0"), (short)28, null, new Guid("eba03ad0-4a9c-4bb4-8c5a-de1148d6e3c8"), (short)3, "Direct visit" },
                    { new Guid("fa18f6e4-940e-488f-be2c-2f26e487b27c"), (short)28, null, new Guid("eba03ad0-4a9c-4bb4-8c5a-de1148d6e3c8"), (short)4, "" },
                    { new Guid("8df44519-2ae8-4d17-9337-08a7ec264cb9"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("425754e0-accc-4cd6-8185-b1ec7de297fc"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("bf9063b1-5d26-43ae-b46f-0781256ca94d"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("e879a9f5-eb4e-4bfc-977e-8c24630780a7"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("59e8ee90-290d-401e-9b22-ebe724cefb3f"), (short)26, null, new Guid("1dd3bf6f-37a9-4040-97aa-40b6785119f6"), (short)2, "Product feature dependent" },
                    { new Guid("943625e5-f672-4acb-82bb-595d4f84f5f7"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("c0efd4b3-4645-4e69-942d-20652f95675e"), (short)26, null, new Guid("1dd3bf6f-37a9-4040-97aa-40b6785119f6"), (short)1, "List price" },
                    { new Guid("fd386c4c-454f-4998-9899-f2d46c0b9bf1"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("b000b1a7-3790-4245-a1aa-2230dcc879c6"), (short)23, null, new Guid("943625e5-f672-4acb-82bb-595d4f84f5f7"), (short)2, "Office" },
                    { new Guid("2f0d0789-c3a8-4053-972a-cea4947a1be7"), (short)23, null, new Guid("943625e5-f672-4acb-82bb-595d4f84f5f7"), (short)3, "Equipment" },
                    { new Guid("a84fa872-c005-4af1-be63-94afed37e78b"), (short)23, null, new Guid("943625e5-f672-4acb-82bb-595d4f84f5f7"), (short)4, "Other" },
                    { new Guid("18cb1847-18e1-4ca6-8823-a7dadb21af37"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("abb2e2de-d1db-473b-b4af-7ca830442694"), (short)23, null, new Guid("18cb1847-18e1-4ca6-8823-a7dadb21af37"), (short)1, "Other" },
                    { new Guid("ea107688-85bc-41e2-b400-d2713cb02fea"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("0b0de69f-c03d-4974-bbfd-2deb9f89088b"), (short)23, null, new Guid("ea107688-85bc-41e2-b400-d2713cb02fea"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("e1e3bc97-a33d-48c2-a563-cbbf87d03bff"), (short)23, null, new Guid("ea107688-85bc-41e2-b400-d2713cb02fea"), (short)2, "Other" },
                    { new Guid("a176b314-343b-4634-b77e-9fe703fd4caf"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("d5abc9cd-b03f-4ac3-868d-ae3608c35acd"), (short)23, null, new Guid("a176b314-343b-4634-b77e-9fe703fd4caf"), (short)1, "Other" },
                    { new Guid("41109f99-9f4f-4f2e-9901-cf13622539d2"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("b95423ab-ae4f-4fb2-964b-b13696614ad4"), (short)23, null, new Guid("41109f99-9f4f-4f2e-9901-cf13622539d2"), (short)1, "Other" },
                    { new Guid("ff61f335-d31c-4c68-af3b-5837afb8e0bb"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("4ef4952f-4ca6-4a68-9a9b-7f0828facd31"), (short)23, null, new Guid("ff61f335-d31c-4c68-af3b-5837afb8e0bb"), (short)1, "Other" },
                    { new Guid("93dffc32-3c6f-4bb3-b1cb-fed7284704e9"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("7a3d8aa1-f040-43b7-adc2-ee4f4f111bdd"), (short)23, null, new Guid("93dffc32-3c6f-4bb3-b1cb-fed7284704e9"), (short)1, "Transport" },
                    { new Guid("764fe2af-1c23-4994-ab13-d9902c417267"), (short)23, null, new Guid("93dffc32-3c6f-4bb3-b1cb-fed7284704e9"), (short)2, "Cost of warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b09af0bb-fc1d-465c-9932-04a9c5357e93"), (short)23, null, new Guid("93dffc32-3c6f-4bb3-b1cb-fed7284704e9"), (short)3, "Fees to distributors" },
                    { new Guid("5af7dd83-6b9b-467e-ae4f-9d99de889c71"), (short)23, null, new Guid("93dffc32-3c6f-4bb3-b1cb-fed7284704e9"), (short)4, "Other" },
                    { new Guid("0cd94568-c2c9-423a-92a8-99e3a62f70a8"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("da0d2432-dfca-4a40-8106-612f12a6ee62"), (short)23, null, new Guid("0cd94568-c2c9-423a-92a8-99e3a62f70a8"), (short)1, "Other" },
                    { new Guid("c44a3762-e04c-4a0b-9c43-418a0216ec95"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("a7fc600c-764b-4697-ab53-ea8a0932d760"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("67ada133-5584-4839-b19e-30ed88c81b55"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("26948d9f-1049-41b3-b8b1-d914410687f7"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("c48a1c2f-271c-4a42-a9f9-8894bc875ab3"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("8983d680-6747-439f-a48e-793599ee7463"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("1dd3bf6f-37a9-4040-97aa-40b6785119f6"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("b09e9ac5-3fae-4618-a514-fde7ff1a8560"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("f0f3eca6-9d94-44bc-920f-f179c49ed4f0"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("7ed8bd97-e11e-42c3-9080-a72787a6d2f9"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("19a85b5e-22b5-4613-9796-72b6836d6e47"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("824fa1b5-70ff-4fbd-a88c-b90d077de9eb"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("04435985-e37c-4f24-b5aa-368e5f2445b5"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("69840d40-8626-4809-aa4c-9f224b5ae0a2"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("7e02ffba-1243-4587-83ce-ac865628ad78"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("59e1122e-a8ed-4533-98e2-4693ea340d45"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("c030a7ae-1443-4222-8fbd-4dc52bb8dae5"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("f322e17f-705c-4779-aae3-6a5b709e9c9f"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("02cff5bf-767c-4544-b0f0-5b44daf0c03a"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("0a58877b-eaa6-4dbd-9d9b-8475dd246627"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("27f1a8a6-d323-450a-b833-74defe4e44f5"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("c8241626-768b-4e5d-8f6a-8030f6880f3b"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("345d3f4e-2225-48ba-b579-137ed40a5f8b"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("ae23c065-35e9-4e2c-8b25-187054abd154"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("ceffe7fe-7d15-4807-a3bc-f0c00b17e646"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("1c073ad0-c1ca-486e-9414-81e0a0e225f4"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("3353b935-ff7c-444b-9af4-1a05d84646d9"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("fcfa9ab6-8642-4ee5-8d45-416d28b23a5e"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("fe19f875-288a-4d41-aacd-d3eccc52a34c"), (short)6, null, new Guid("fcfa9ab6-8642-4ee5-8d45-416d28b23a5e"), (short)1, "Buildings" },
                    { new Guid("07bcc20e-ff22-465b-844c-7e7efa6b340b"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("fe19f875-288a-4d41-aacd-d3eccc52a34c"), (short)1, "Ownership type" },
                    { new Guid("5e58340e-05ac-4d66-aa91-bf072888994a"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fe19f875-288a-4d41-aacd-d3eccc52a34c"), (short)2, "Frequency" },
                    { new Guid("355e1b4f-3a52-4763-a6f0-da7b294691dc"), (short)6, null, new Guid("fcfa9ab6-8642-4ee5-8d45-416d28b23a5e"), (short)2, "Equipment" },
                    { new Guid("758cd411-3982-45cb-a809-170d1354cc73"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("355e1b4f-3a52-4763-a6f0-da7b294691dc"), (short)1, "Ownership type" },
                    { new Guid("20d4d7f8-6d1f-4350-9347-5b28a1d125c9"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("355e1b4f-3a52-4763-a6f0-da7b294691dc"), (short)2, "Frequency" },
                    { new Guid("d2541450-fc79-401e-b67d-e7c4a1eec26b"), (short)6, null, new Guid("fcfa9ab6-8642-4ee5-8d45-416d28b23a5e"), (short)3, "Transport" },
                    { new Guid("8cb0879a-5f97-4f8e-943b-88595884aad3"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("d2541450-fc79-401e-b67d-e7c4a1eec26b"), (short)1, "Ownership type" },
                    { new Guid("32255366-8b46-4668-be7c-02b4ada0f940"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d2541450-fc79-401e-b67d-e7c4a1eec26b"), (short)2, "Frequency" },
                    { new Guid("ba606565-93d0-48d7-9c16-25f1dc56bf0b"), (short)3, null, null, (short)8, "Accessibility of human resources" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("5445ff68-fbf5-4ea8-adee-fd0d44a73d72"), (short)6, null, new Guid("fcfa9ab6-8642-4ee5-8d45-416d28b23a5e"), (short)4, "Raw materials" },
                    { new Guid("2822fc72-4352-4fed-8547-ab27dea05421"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("bdb27c50-5904-4a06-b9d1-3e6d384eade7"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("27369e3b-a659-4de5-81cc-de2a9776b1bf"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("ac29dddd-e3c6-4752-862c-e21cf5dc99e5"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("8ef23596-413c-4068-9514-98b73fa2b604"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("48317b06-92cb-477f-aa66-48d716696f0c"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("08f36ec2-af65-4e5c-a267-80d6293889f3"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("3d24e618-5e31-4a12-a786-69fa36fe5d2c"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("23567387-c539-4ac6-95b0-bbaa7f99561b"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("917eaa54-beaa-4213-93c9-cc593e864eba"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("55a5122e-a936-4499-a30c-85b599ef5548"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("2465228f-fc29-4bb5-87c0-3ac15034a57c"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("b4479382-93e5-44a0-87f7-ce2d08bfd762"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("2d6cca98-0a41-49c9-a425-5941f076fc31"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("330c9a51-9de2-4aa9-ac08-edee1607bf9a"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("de0bba24-26c1-42c0-b13e-05a24f69d0cc"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("4b860381-d14d-4845-893c-bed1d94f7439"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("50d4f789-37ba-44be-8e4a-527eb45c74ae"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("7f3e2d40-2832-4f59-8ee2-d173178985c5"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("bc2dcffe-5da4-417b-ac38-0a710e3e3f75"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("53a83e11-eaea-45e2-a205-5586614f3c39"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("1b36b83a-2690-4680-975a-b34410699374"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("5458949e-5886-40eb-853a-25d796af5ba1"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("b53dab2e-fefc-4e7b-8528-85d899579b89"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("ff602698-c541-40a8-80d0-ed0e22d16e28"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("3f6019b6-a20f-41f4-8d4f-ddc4a555ca77"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("7507f8d4-eb4b-44c5-8356-7d588ff6c006"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("0de6bd5a-83f8-47d1-9bb0-ad593333a8a4"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("27697115-4bfe-426f-a008-4b3d40c9ea12"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("05f205f5-32b0-4970-a9c7-266380f92666"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("6771aee4-bf4b-4c22-9d97-9d9802e6c75c"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("9707d260-85a6-4680-b630-c7fd7f0ec915"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("5445ff68-fbf5-4ea8-adee-fd0d44a73d72"), (short)1, "Ownership type" },
                    { new Guid("08917fb2-1dbf-4d92-8842-b8800f2fc744"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9e5e001e-50cf-4de5-9c3d-279b51c047f0"), (short)1, "Ownership type" },
                    { new Guid("a4ebfab9-0ef7-40df-80bd-0821935f11b1"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("3a633f38-e6bf-4db0-a506-acc08a007840"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("31f1f2e8-7504-4e05-9a17-c6d214a6464c"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("b3b0fc9f-d2b4-4720-8ed5-a746b81c1652"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("53cbb2b0-1994-499c-8514-97822bfff8d9"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("3a91d2ab-e4af-4e6e-a698-069ca67ee378"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("e351ba75-3a83-476c-9a95-58f44f92b8f2"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("fea6f63b-3b4e-48e5-9260-513b3c10eafd"), (short)15, null, null, (short)3, "No improvements or innovations" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7cb5bbcd-887f-41d2-b9a7-701db13b5210"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("8883bccf-217f-4c19-a48f-df227b8666af"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("18068846-9481-497d-b23f-79b330cc0806"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("90e39342-964c-41d4-b533-280c199d1045"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("5e8499e9-e099-4cc6-9f49-16ad2461e9cf"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("f5bb0fc3-d76a-4faf-84b1-1fa6326b0b07"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("634d01be-0857-4477-9920-40afb481ca40"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("60c08791-cf73-4a1a-b3fc-8fde24e7d0b7"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("ebefc3c1-5019-4f55-a2c8-60df84625b30"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("434cb959-9345-4029-b266-212f932a139c"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("b5125788-d1d1-4a3b-8b55-6ae796f8d80d"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("4166cb46-e398-4c4d-946e-24df3f3dedd2"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("126be5c0-3f45-4c8d-b310-2ee1e7389130"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("03251d5a-2a7c-411d-9ec2-9b8ab50c0f5d"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("db24c1bb-3c54-4cd1-8fe0-c6805024d483"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("85eb8053-b6a1-4c30-9200-dc4fd7e982d7"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("45aa6083-854d-4a47-b167-687195060e38"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("96400565-0952-4038-8ce8-228c860c697e"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("eae892dc-6011-4155-9909-d1dfd9c7929f"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("9e5e001e-50cf-4de5-9c3d-279b51c047f0"), (short)6, null, new Guid("fcfa9ab6-8642-4ee5-8d45-416d28b23a5e"), (short)5, "Other" },
                    { new Guid("c9d397cd-f93d-49e8-877c-7f1148b00e3c"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("c8c6db4b-a9e1-48b7-9483-a1e66e7fb99c"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("771b3f4f-f5f7-47fe-9f9a-2acee80792cc"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9e5e001e-50cf-4de5-9c3d-279b51c047f0"), (short)2, "Frequency" },
                    { new Guid("90b87458-8283-43bb-b46a-71d68e35babf"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("16e4d240-71ee-413a-9a63-31abc3d331bc"), (short)6, null, new Guid("90b87458-8283-43bb-b46a-71d68e35babf"), (short)1, "Brands" },
                    { new Guid("0840d09c-59e7-426a-8385-e08b6954f06a"), (short)6, null, new Guid("90b87458-8283-43bb-b46a-71d68e35babf"), (short)2, "Licenses" },
                    { new Guid("50eb6f96-1c0c-42ce-b4bc-4129ad7d5521"), (short)6, null, new Guid("90b87458-8283-43bb-b46a-71d68e35babf"), (short)3, "Software" },
                    { new Guid("892ff94a-bdee-46cd-a7f8-0b3d9247055b"), (short)6, null, new Guid("90b87458-8283-43bb-b46a-71d68e35babf"), (short)4, "Other" },
                    { new Guid("fde07cf1-3183-4bf5-b289-06871da5dda2"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("ca1598d5-9211-4388-830b-ef0b3096279a"), (short)6, null, new Guid("fde07cf1-3183-4bf5-b289-06871da5dda2"), (short)1, "Specialists & Know-how" },
                    { new Guid("dedef4d3-e499-497f-b2a9-5724a6c79a7d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("ca1598d5-9211-4388-830b-ef0b3096279a"), (short)1, "Ownership type" },
                    { new Guid("a47ef53e-503e-4de1-8be0-b5863841a07d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ca1598d5-9211-4388-830b-ef0b3096279a"), (short)2, "Frequency" },
                    { new Guid("0e97d692-ee01-4f80-bb99-8f6308c400f3"), (short)6, null, new Guid("fde07cf1-3183-4bf5-b289-06871da5dda2"), (short)2, "Administrative" },
                    { new Guid("e055f8bc-0e7e-4fce-9fcd-590dbbb850bf"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("0e97d692-ee01-4f80-bb99-8f6308c400f3"), (short)1, "Ownership type" },
                    { new Guid("34522761-7a59-439e-8d6f-8043d04b6ec1"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0e97d692-ee01-4f80-bb99-8f6308c400f3"), (short)2, "Frequency" },
                    { new Guid("7f82fff6-b6b6-4ffd-9328-9d11c40c714e"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("b7cd2a3b-e2f5-4829-9dc0-1fa01ba60775"), (short)6, null, new Guid("fde07cf1-3183-4bf5-b289-06871da5dda2"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("c8783ddf-6a89-4a3f-9d47-84d004db8c80"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b7cd2a3b-e2f5-4829-9dc0-1fa01ba60775"), (short)2, "Frequency" },
                    { new Guid("237f8ec5-4179-4b8d-9a51-1bffa9dea8e4"), (short)6, null, new Guid("fde07cf1-3183-4bf5-b289-06871da5dda2"), (short)4, "Other" },
                    { new Guid("2a3fa65f-8147-4eea-8477-46b0d40e90a1"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("237f8ec5-4179-4b8d-9a51-1bffa9dea8e4"), (short)1, "Ownership type" },
                    { new Guid("f194080e-0029-44fe-89a2-326f82e69753"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("237f8ec5-4179-4b8d-9a51-1bffa9dea8e4"), (short)2, "Frequency" },
                    { new Guid("efaba5f9-09fb-4f42-9bfd-c36db18a8243"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("9ed0b42d-b079-4d7f-809c-3b26ebaa8418"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("a040bf4e-7cf3-4f66-9599-c010821f64a8"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("41e9c1f8-dc87-46e8-858a-9b381dc91b19"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("9c14fbe4-f910-4b59-ad05-04d6ffc5e3c5"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("aba24945-c2ab-4569-926e-0d6ada7b82c3"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("d1fde09c-da17-4ed2-b599-22746fd323c7"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("a2e8221e-8198-4fa0-a6fe-52bea6c5e27a"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("004336f4-c794-472e-89ba-713b2674ae3d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("b7cd2a3b-e2f5-4829-9dc0-1fa01ba60775"), (short)1, "Ownership type" }
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
                    { new Guid("17358260-f4f0-4423-aab8-f2d813342bd3"), "A.01", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("2dd55350-1a5b-4438-a73b-29b1321e8e03"), "H.51.22", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Space transport" },
                    { new Guid("619aafae-6616-4cb8-b1cb-30b3cc1afeb5"), "H.52", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Warehousing and support activities for transportation" },
                    { new Guid("ca920a39-fea6-4225-bf6d-d8dfb6890c9a"), "H.52.1", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Warehousing and storage" },
                    { new Guid("7611e462-0420-427f-a196-04e4d8b74165"), "H.52.10", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Warehousing and storage" },
                    { new Guid("fd8b9061-2ef5-4423-8a8f-a0c500e231b3"), "H.52.2", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Support activities for transportation" },
                    { new Guid("894ac7dc-cf22-492e-8bcf-c0a317eb0c58"), "H.52.21", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Service activities incidental to land transportation" },
                    { new Guid("6e5ccaa6-02b5-4709-b443-53b4e86fd58d"), "H.52.22", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Service activities incidental to water transportation" },
                    { new Guid("5995647a-5151-4ba9-9600-3a0808b554e6"), "H.52.23", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Service activities incidental to air transportation" },
                    { new Guid("9502b2ff-d222-43fe-9738-e254c715ae93"), "H.52.24", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Cargo handling" },
                    { new Guid("9657aa39-82f5-491f-b8d1-1559320a4eb0"), "H.52.29", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Other transportation support activities" },
                    { new Guid("158d487e-2f64-4734-91d6-f9493c4f9a48"), "H.53", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Postal and courier activities" },
                    { new Guid("95e69ea2-ec82-49dd-a15f-6f423e37c9b2"), "H.53.1", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Postal activities under universal service obligation" },
                    { new Guid("d471ee99-674a-4255-9942-b941b437cd9e"), "H.51.21", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Freight air transport" },
                    { new Guid("d416d40b-85d9-4177-b54a-178edd075e6d"), "H.53.10", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Postal activities under universal service obligation" },
                    { new Guid("e1479ba9-0d1f-4bdd-a135-4734485c9d95"), "H.53.20", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Other postal and courier activities" },
                    { new Guid("9b876599-9752-4a73-b03d-1d6084fe7d6a"), "I.55", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Accommodation" },
                    { new Guid("f51d3124-11c8-4a9e-a622-5d5df8bfe6db"), "I.55.1", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Hotels and similar accommodation" },
                    { new Guid("0e4acf45-0832-4ac3-8173-ffa58a60be7f"), "I.55.10", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Hotels and similar accommodation" },
                    { new Guid("faf55279-fc12-4719-906e-785f9a4e380b"), "I.55.2", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Holiday and other short-stay accommodation" },
                    { new Guid("d6b96df2-a94e-4611-9457-554cb0ea7ae7"), "I.55.20", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Holiday and other short-stay accommodation" },
                    { new Guid("d258db14-0b9a-43e3-bb93-f3ea89800ab5"), "I.55.3", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("b8c393f3-9bb1-4d56-b387-a0ea5c1cff83"), "I.55.30", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("b3d439f9-763c-49bb-948b-f24abc7297c2"), "I.55.9", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Other accommodation" },
                    { new Guid("59eac756-aa0f-4cf0-8b00-e0336b49f914"), "I.55.90", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Other accommodation" },
                    { new Guid("e93bf9ca-85e3-4643-8d44-42ffdc4984dd"), "I.56", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Food and beverage service activities" },
                    { new Guid("0c2105e9-60e0-44a8-868a-ef2395e5ef15"), "I.56.1", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Restaurants and mobile food service activities" },
                    { new Guid("2ee4eda7-5e55-4fc8-a1cd-e2b3277386bb"), "H.53.2", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Other postal and courier activities" },
                    { new Guid("bf9b146b-7c5e-4dd6-8169-8062ca60e936"), "H.51.2", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Freight air transport and space transport" },
                    { new Guid("6e19b435-7877-447e-8f50-73b427c667ee"), "H.51.10", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Passenger air transport" },
                    { new Guid("9a84fbe1-52e6-4e95-a786-b67243c301b0"), "H.51.1", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Passenger air transport" },
                    { new Guid("0cff1d27-7d45-4b2a-b173-e9a22ed6592f"), "G.47.9", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("5a6d5ca2-7d43-4f1d-abcf-323e614ab6a6"), "G.47.91", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("fd7850b6-6f02-44cb-b0d6-c53e9fb83133"), "G.47.99", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("38fef992-527a-4214-837e-dad3f9f86fc1"), "H.49", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Land transport and transport via pipelines" },
                    { new Guid("f733bed3-0d24-4068-94b7-a9e9fedf45ea"), "H.49.1", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Passenger rail transport, interurban" },
                    { new Guid("e3f938ff-c1d5-4f55-a87c-dba0286f1755"), "H.49.10", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Passenger rail transport, interurban" },
                    { new Guid("46f8974a-203c-4691-a3aa-1a092a87ab8e"), "H.49.2", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Freight rail transport" },
                    { new Guid("ea748f02-0ca3-4abb-9327-34a1dc1f0f5c"), "H.49.20", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Freight rail transport" },
                    { new Guid("350a1f8b-57a4-4c33-be6c-a4a88832d19b"), "H.49.3", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Other passenger land transport" },
                    { new Guid("0bc42efd-8ae3-4ea2-af30-0bfcb39104d7"), "H.49.31", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Urban and suburban passenger land transport" },
                    { new Guid("4f9d503e-5117-42cb-aa06-fddd52116e73"), "H.49.32", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2bae932c-3d2a-4e67-a56a-537be26e7c6a"), "H.49.39", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Other passenger land transport n.e.c." },
                    { new Guid("8f054e59-edd3-45f6-b57c-8d4ce0600604"), "H.49.4", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Freight transport by road and removal services" },
                    { new Guid("c93ac0c7-9900-4c37-a8ef-309931d966f0"), "H.49.41", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Freight transport by road" },
                    { new Guid("4cb70c5b-79f7-487d-88a3-fdf9463344e9"), "H.49.42", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Removal services" },
                    { new Guid("5352da27-8b6c-4c0c-a060-9160a10d0d88"), "H.49.5", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Transport via pipeline" },
                    { new Guid("325d8d9c-0fee-45e0-9410-3785d49442c9"), "H.49.50", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Transport via pipeline" },
                    { new Guid("707597af-fe13-44b4-8bfc-a04339b7aa37"), "H.50", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Water transport" },
                    { new Guid("9926b7d9-c6ae-49ec-a68a-ec18dd08723d"), "H.50.1", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Sea and coastal passenger water transport" },
                    { new Guid("c525eea5-63f8-47c9-a3f2-1446dbcd136a"), "H.50.10", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Sea and coastal passenger water transport" },
                    { new Guid("3f2b3859-6060-4b27-a793-c414436df692"), "H.50.2", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Sea and coastal freight water transport" },
                    { new Guid("4a3d02c2-7d59-49dc-a247-588d463cb6f5"), "H.50.20", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Sea and coastal freight water transport" },
                    { new Guid("98d1b1d3-2a9f-453b-a4a7-146696993b2c"), "H.50.3", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Inland passenger water transport" },
                    { new Guid("3a5b7512-5f06-47a3-bce8-11c6be67c0bf"), "H.50.30", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Inland passenger water transport" },
                    { new Guid("3ab4517d-9126-44f7-b93a-ae4a814fc1c6"), "H.50.4", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Inland freight water transport" },
                    { new Guid("6ab39edb-dc4a-4867-a0ec-8636d37bc8e0"), "H.50.40", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Inland freight water transport" },
                    { new Guid("75611eeb-aa99-41e4-bd12-580efbb2ac86"), "H.51", new Guid("4e676437-c8d6-4a1a-acd1-32cf894c21ac"), "Air transport" },
                    { new Guid("33fcbb56-0298-4a89-b4b6-264f21e68267"), "I.56.10", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Restaurants and mobile food service activities" },
                    { new Guid("780938ad-c173-4e77-8f70-7f433ae5ad91"), "G.47.89", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("bf98ee07-6a26-42fa-9dff-c62d38768c40"), "I.56.2", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Event catering and other food service activities" },
                    { new Guid("5dee5030-7e3c-4283-9af4-0a5b074317c2"), "I.56.29", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Other food service activities" },
                    { new Guid("93c5e4ca-9dfd-4ad3-b719-1674b2d583ff"), "J.61.30", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Satellite telecommunications activities" },
                    { new Guid("cc065bf6-4500-4ced-83c3-dc99fd120d51"), "J.61.9", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other telecommunications activities" },
                    { new Guid("f731db72-9f8c-4fb4-856c-f78a71c609d9"), "J.61.90", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other telecommunications activities" },
                    { new Guid("9fab6af0-fd97-4226-b645-d438ec0931f6"), "J.62", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Computer programming, consultancy and related activities" },
                    { new Guid("6fe79ddf-dbaa-454d-9e1a-b4f35929f32c"), "J.62.0", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Computer programming, consultancy and related activities" },
                    { new Guid("49afba24-8de4-47b5-951f-f7108ebc9c3c"), "J.62.01", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Computer programming activities" },
                    { new Guid("30bbfceb-0e34-47ec-a782-63af5f6b08a1"), "J.62.02", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Computer consultancy activities" },
                    { new Guid("33134da6-8b99-4697-9b45-e58801f3a42a"), "J.62.03", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Computer facilities management activities" },
                    { new Guid("95a191b1-14b8-47e0-987d-a81b42dc8219"), "J.62.09", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other information technology and computer service activities" },
                    { new Guid("1c8dbc30-a635-4663-87c6-be6665f7c5be"), "J.63", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Information service activities" },
                    { new Guid("07f7feb6-4734-4dec-842d-2f0582c8fb03"), "J.63.1", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("96d2740f-f0a5-4d73-b20b-e37de5ee87df"), "J.63.11", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Data processing, hosting and related activities" },
                    { new Guid("0f8974ef-e4db-437d-a30e-9f2d901229a7"), "J.61.3", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Satellite telecommunications activities" },
                    { new Guid("96e4428e-cdbd-443b-893b-3b623b7c96e0"), "J.63.12", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Web portals" },
                    { new Guid("8330e50f-c6cd-4bf0-a225-cac5b11256e9"), "J.63.91", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "News agency activities" },
                    { new Guid("d4e7b38e-0cb7-4c3b-a862-8cde353d9d55"), "J.63.99", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other information service activities n.e.c." },
                    { new Guid("4b253c6f-cf09-4315-a9af-f8cb4f6d71c8"), "K.64", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("95ef3364-cc6b-4b01-a641-126fc8317a8b"), "K.64.1", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Monetary intermediation" },
                    { new Guid("156157d6-a78d-4599-83f8-5c4d5daa5924"), "K.64.11", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Central banking" },
                    { new Guid("d9857144-a85c-470e-9170-96c41a934bf6"), "K.64.19", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Other monetary intermediation" },
                    { new Guid("f7272406-0197-47c9-8d08-d5b619bf7be4"), "K.64.2", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Activities of holding companies" },
                    { new Guid("aa5a0065-dd51-48b2-80b2-8f55cc26ac5c"), "K.64.20", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("16af6ea5-52d4-43ff-b27a-7c33203cd670"), "K.64.3", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Trusts, funds and similar financial entities" },
                    { new Guid("4b1a0fae-b7b2-471b-93bc-1eeee2d462ba"), "K.64.30", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Trusts, funds and similar financial entities" },
                    { new Guid("7b1d4e33-017e-43b2-958c-430de5b0289c"), "K.64.9", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("f94c17d5-b62c-4931-9a5a-1c78f8f91fe1"), "K.64.91", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Financial leasing" },
                    { new Guid("ba6291a0-3546-436c-b36e-ef13faeebe63"), "J.63.9", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other information service activities" },
                    { new Guid("b270b51d-da82-42ee-956f-79b33a1d2080"), "J.61.20", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Wireless telecommunications activities" },
                    { new Guid("95f9d6ef-ce85-40aa-954d-5cdcc6062536"), "J.61.2", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Wireless telecommunications activities" },
                    { new Guid("664f588c-2480-48bc-a99d-b2b05d993a34"), "J.61.10", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Wired telecommunications activities" },
                    { new Guid("db9cb13e-4ee3-4058-9a50-5bb238c48312"), "I.56.3", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Beverage serving activities" },
                    { new Guid("3377af3c-88ed-4246-844c-5bca4e89a204"), "I.56.30", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Beverage serving activities" },
                    { new Guid("5a00d036-fb8d-4791-897f-4967444ad7dc"), "J.58", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Publishing activities" },
                    { new Guid("27cda2ce-c2ef-429b-bff2-a5dd0df753f3"), "J.58.1", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("1c84725a-eb9d-43a2-8ebc-1ac69fe0d25d"), "J.58.11", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Book publishing" },
                    { new Guid("f00b14bf-d2d6-492b-8e3e-b235cad4db91"), "J.58.12", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Publishing of directories and mailing lists" },
                    { new Guid("6b3b939b-df6a-4c68-8223-f24a11c15964"), "J.58.13", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Publishing of newspapers" },
                    { new Guid("6b7a6669-7746-40fa-80c4-58bcbc05e186"), "J.58.14", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Publishing of journals and periodicals" },
                    { new Guid("ba6f89ff-2b91-49aa-86b8-57bcebf4c805"), "J.58.19", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other publishing activities" },
                    { new Guid("7002c34c-8a6e-4a74-94f3-3f453f19e180"), "J.58.2", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Software publishing" },
                    { new Guid("1afab747-d34c-49e3-ac5e-37da12eaf535"), "J.58.21", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Publishing of computer games" },
                    { new Guid("145ad996-5299-4d3a-a805-fe83389324cc"), "J.58.29", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Other software publishing" },
                    { new Guid("a49896f0-3d1e-49e5-9105-4615a2dbfb5d"), "J.59", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("3338715c-a254-4b74-91e2-8f6ff40c9301"), "J.59.1", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Motion picture, video and television programme activities" },
                    { new Guid("21aa412a-9147-434a-ac19-a66b6e290697"), "J.59.11", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Motion picture, video and television programme production activities" },
                    { new Guid("1b54b9e0-2101-4bea-bb02-86d841cfbead"), "J.59.12", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("11454797-a840-494b-b3e8-00cb92509cdc"), "J.59.13", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("30e4bd6a-fe90-42aa-8018-0dc17fbfda99"), "J.59.14", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Motion picture projection activities" },
                    { new Guid("515fb95f-68b0-4d88-9917-9cb9e1c7ea80"), "J.59.2", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Sound recording and music publishing activities" },
                    { new Guid("d50d12c3-b379-4ae0-aa03-aff7cbcff5d2"), "J.59.20", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Sound recording and music publishing activities" },
                    { new Guid("d0fe5d5c-dc69-4bc0-ae5e-9c7f259c969f"), "J.60", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Programming and broadcasting activities" },
                    { new Guid("95604d81-bbf1-4c01-885c-6950ab67be61"), "J.60.1", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Radio broadcasting" },
                    { new Guid("570cf920-16d2-43d3-8e78-b51e422cf4a9"), "J.60.10", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Radio broadcasting" },
                    { new Guid("70986ec1-972d-47c1-b7fd-289906e16804"), "J.60.2", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Television programming and broadcasting activities" },
                    { new Guid("529ea6ad-1a1d-41d4-afd4-164eb2d2d848"), "J.60.20", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Television programming and broadcasting activities" },
                    { new Guid("07263ab6-2b1b-40ed-a006-6319fb4cb90d"), "J.61", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Telecommunications" },
                    { new Guid("28f64403-b6c3-4d88-b6ab-67bf1a4c2631"), "J.61.1", new Guid("ddf84dfe-47dd-4ad8-89a2-bd9b3f7e5231"), "Wired telecommunications activities" },
                    { new Guid("843781e9-b21a-4c84-8ca6-b23586339b92"), "I.56.21", new Guid("1986a0ab-b9b0-4d66-9b76-b839a30c00f5"), "Event catering activities" },
                    { new Guid("a0a457b1-03b1-40f2-b9c8-7130791c064e"), "K.64.92", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Other credit granting" },
                    { new Guid("ecd02392-0e28-4c33-b92a-4e6e9fbc09cf"), "G.47.82", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("791b7197-75c6-45d0-88b8-24d164d235a3"), "G.47.8", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale via stalls and markets" },
                    { new Guid("c2eff513-c56b-4558-b5e7-6b0bbb346aac"), "G.46.19", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("8126837e-5014-4616-8e21-eb7c93618d58"), "G.46.2", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("747452de-f74f-4cd8-90ea-4c8d97acc3b5"), "G.46.21", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4005439b-38cb-41c2-bb09-bd8e9c8b6f77"), "G.46.22", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of flowers and plants" },
                    { new Guid("8b0d9df0-4a6e-468d-85a7-3b030cea29aa"), "G.46.23", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of live animals" },
                    { new Guid("87b0c4b9-d73c-4add-81a5-06aaf19b0858"), "G.46.24", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of hides, skins and leather" },
                    { new Guid("caf7807f-e771-42c0-8e2d-f3d6cdfe225a"), "G.46.3", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("7de4d7cb-b1cb-440d-8021-b5ceacd0f939"), "G.46.31", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of fruit and vegetables" },
                    { new Guid("a96d6bd3-4870-43ba-9d94-01849ecb6f6d"), "G.46.32", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of meat and meat products" },
                    { new Guid("98440787-bb24-4ac8-8279-f6cba343faf7"), "G.46.33", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("a5df690d-c32b-46f5-b8ad-ae1240781978"), "G.46.34", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of beverages" },
                    { new Guid("d4075635-1869-406a-a54c-e415985c2a24"), "G.46.35", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of tobacco products" },
                    { new Guid("60bbdcaf-0dfc-46a7-9abf-4577209115c3"), "G.46.18", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents specialised in the sale of other particular products" },
                    { new Guid("e58095ef-4d6e-408f-b1b6-a9042ebe88c0"), "G.46.36", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("f62570a9-cf81-4adc-ba57-1515636275d7"), "G.46.38", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("d0791088-f2b1-4445-9d0f-c087b266ba3b"), "G.46.39", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("3960e65c-62c3-46ce-94b8-055386970a1a"), "G.46.4", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of household goods" },
                    { new Guid("b4438fcb-9cf8-49c7-b899-1342cc0be843"), "G.46.41", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of textiles" },
                    { new Guid("ae2ee383-0158-46f6-bb79-d759cc54051e"), "G.46.42", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of clothing and footwear" },
                    { new Guid("5113a2cf-41b0-4182-9b25-d3c765cb3f6c"), "G.46.43", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of electrical household appliances" },
                    { new Guid("80727740-b0dd-4e0d-bbe9-ec3aa62eb4ff"), "G.46.44", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("6841d235-0fa9-45e7-9a4b-f61362e965cb"), "G.46.45", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of perfume and cosmetics" },
                    { new Guid("d0dd20f6-476e-4671-96df-04746d386175"), "G.46.46", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of pharmaceutical goods" },
                    { new Guid("5524f4a9-3535-487c-bffe-a5576cffd981"), "G.46.47", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("683d4ed2-c5a2-4966-8584-8488c8fc2aef"), "G.46.48", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of watches and jewellery" },
                    { new Guid("3f1902d0-f8bc-473e-b0a2-afed2b0d6ff1"), "G.46.49", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of other household goods" },
                    { new Guid("3d2384d2-3788-4119-8323-eff95a3daf33"), "G.46.37", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("07686774-4a51-481b-bae6-e760b9711d30"), "G.46.17", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("6373509c-affe-4314-bedc-fbd28d02252e"), "G.46.16", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("6d434898-dac7-4ed2-aa1a-6fc61dfed4bd"), "G.46.15", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("e67853cc-66ad-4dc6-8103-07eda10b241c"), "F.43.29", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Other construction installation" },
                    { new Guid("39dd0dd1-6b37-4cd2-84e0-b160f4bcb227"), "F.43.3", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Building completion and finishing" },
                    { new Guid("85a07fb0-64b6-4fc8-a88d-fac1b7643c31"), "F.43.31", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Plastering" },
                    { new Guid("3b8e9c52-896f-4355-b113-a0a3685bde6f"), "F.43.32", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Joinery installation" },
                    { new Guid("c1768ba1-2339-469a-831f-ad5a3496aebd"), "F.43.33", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Floor and wall covering" },
                    { new Guid("380bfc5a-790b-42e9-bbfc-66d42583e393"), "F.43.34", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Painting and glazing" },
                    { new Guid("b2769f7f-da76-4286-a11e-26df58873028"), "F.43.39", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Other building completion and finishing" },
                    { new Guid("867c8e0b-6c97-4acc-b10a-30b4db4ccfc4"), "F.43.9", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Other specialised construction activities" },
                    { new Guid("fdad027e-b1e0-4f9d-8a56-214de32497b7"), "F.43.91", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Roofing activities" },
                    { new Guid("fd930176-e335-47dc-ab2a-e34f0d32d472"), "F.43.99", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Other specialised construction activities n.e.c." },
                    { new Guid("7d7292dd-6f95-4fe6-a656-c8bfa0db2d12"), "G.45", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("60043631-7ed2-4d49-bc86-44ce2af8b1e8"), "G.45.1", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Sale of motor vehicles" },
                    { new Guid("4aa3bcc2-3c32-4318-b9d5-d96c78c144b7"), "G.45.11", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Sale of cars and light motor vehicles" },
                    { new Guid("f890bc22-6190-4ee3-a38d-7ee424fdd9e1"), "G.45.19", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Sale of other motor vehicles" },
                    { new Guid("8ed10296-1734-492c-80aa-24d4b7affa4e"), "G.45.2", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0cfc6032-6d48-419b-9bc6-2b6f0e7ee60d"), "G.45.20", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Maintenance and repair of motor vehicles" },
                    { new Guid("a07d3e4b-0a9d-4e09-b196-035d7c266388"), "G.45.3", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("a220aad1-1c85-4347-8674-6605fe746c79"), "G.45.31", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("47256874-953a-4f8f-a48d-5a64c9991706"), "G.45.32", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("77204f7c-0e42-4560-af05-c9d24a85d18b"), "G.45.4", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("d7e9d8f2-4762-488f-b210-b069a5ddcfd4"), "G.45.40", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("823422f3-5152-42f0-8b29-aa115cc5e7f2"), "G.46", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("058e9b31-ab4b-4a49-a3f0-54e1ace70937"), "G.46.1", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale on a fee or contract basis" },
                    { new Guid("12ad22a4-91b3-47b7-afb9-9eff63491e91"), "G.46.11", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("86ace364-d068-41db-bc2c-a82ac365d167"), "G.46.12", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("c4650f7f-4ec7-423d-923f-a4e51aa1e39e"), "G.46.13", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("30e7bf8a-47ac-4a60-b542-66811c891816"), "G.46.14", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("e497f169-4440-4d09-83ee-d1f87eeef633"), "G.46.5", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of information and communication equipment" },
                    { new Guid("0950995a-8d41-4e7e-b418-eb3e54d2533b"), "G.47.81", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("0d984386-4326-4a42-8e2f-d5b3e657890f"), "G.46.51", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("7df4fce8-c675-42fb-bc14-4be182cdff2e"), "G.46.6", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("0a1f5f79-bf63-4fdd-9cde-409d0b7ff8e2"), "G.47.4", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("4f72467d-6a01-4058-bc2b-9544cd8d4d64"), "G.47.41", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("ad1c3d65-a6fc-4d20-bf82-d9455b0c7ab1"), "G.47.42", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("d50419e3-af24-4884-aac4-cae576cb792b"), "G.47.43", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("a230fb28-6462-4455-af60-25b7efe4d488"), "G.47.5", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("593b04ee-a435-47f1-90f3-459065f5eb36"), "G.47.51", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of textiles in specialised stores" },
                    { new Guid("a86e4a4f-eb3c-48f6-914a-173cc8d032b7"), "G.47.52", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("632c6e71-bd4a-4b7e-b327-3c0ac1277cbd"), "G.47.53", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("d0cbd2c8-5976-49c0-8d82-89dc18b43d62"), "G.47.54", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("904d6634-de5c-479c-99b8-bb6fd12c876d"), "G.47.59", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("e7c0c6eb-905c-49cf-b40c-737b2839dc8c"), "G.47.6", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("2c9878c0-6c5e-494e-9a21-1f16205684cd"), "G.47.61", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of books in specialised stores" },
                    { new Guid("c9b1ff0c-da66-4030-9707-d8146c7babc6"), "G.47.30", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("a5719afa-96f3-4a3b-8405-9b5308934a60"), "G.47.62", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("318513d6-27bb-4dba-9fd0-177adf8ed89e"), "G.47.64", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("a37c1fb8-c397-4b5b-9ea0-69f160a8b4d6"), "G.47.65", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("6c82c24b-5d24-472d-b235-09ac77970f91"), "G.47.7", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of other goods in specialised stores" },
                    { new Guid("b23799cd-b33b-4e35-a6a6-be72e7b54f59"), "G.47.71", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of clothing in specialised stores" },
                    { new Guid("4c904f65-b417-4c71-a39c-7b03da7cfb74"), "G.47.72", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("519765f3-a807-4e5d-be6a-ba26e23a5351"), "G.47.73", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Dispensing chemist in specialised stores" },
                    { new Guid("79c28ebf-34a7-414d-8497-a3d2ea52d4b5"), "G.47.74", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("081f9cd8-da0e-4ac5-b0b0-1ca412c31ad3"), "G.47.75", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("48bacbe1-88c9-413c-8636-20e4d9c1fe9f"), "G.47.76", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("6b186eb8-f9c9-44f5-891d-e5b101ee5052"), "G.47.77", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("b7156726-d6f1-4605-8334-5835eade581b"), "G.47.78", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("374841e0-c5ca-4777-ab87-a2df4a988904"), "G.47.79", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("20bfcaa0-21a6-4f43-bcb6-27a22d1a378b"), "G.47.63", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("3aa0081e-c5ce-4e24-bd35-5f39f76431d3"), "G.47.3", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("a7ed7a73-bf37-42ff-8e14-026e009199bb"), "G.47.29", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Other retail sale of food in specialised stores" },
                    { new Guid("43c2adce-1998-4f72-b69e-d3f59336f385"), "G.47.26", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("3f3be6d0-f68e-40a5-8f8c-de7b91c19f81"), "G.46.61", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("505fa75a-7e25-46ae-9a21-7203adeb03d5"), "G.46.62", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of machine tools" },
                    { new Guid("67fba0d4-467f-48d4-831b-03254a21e957"), "G.46.63", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("7b5d7814-be70-4b0e-9f33-52070768261e"), "G.46.64", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("3d01456d-49c7-49c1-ae2e-f7140e7c4759"), "G.46.65", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of office furniture" },
                    { new Guid("ec83bacf-d3b5-4c84-a8ce-2465ce7064b0"), "G.46.66", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of other office machinery and equipment" },
                    { new Guid("e77d4222-d9e8-42fb-b60f-28b34fef5f22"), "G.46.69", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of other machinery and equipment" },
                    { new Guid("78699f7e-bced-417c-92ae-03b6bd2e1ebc"), "G.46.7", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Other specialised wholesale" },
                    { new Guid("8d8f23ab-a468-4316-89db-f553352d2bc7"), "G.46.71", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("bf1138df-540b-49b1-aec2-ddd43c544e19"), "G.46.72", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of metals and metal ores" },
                    { new Guid("8e7431ef-6e83-44c6-b1c7-d7d4812ce7d7"), "G.46.73", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("1475c89a-43f9-484d-b6a3-e46ff1dfafc1"), "G.46.74", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("0fa0763d-83aa-4b0a-a058-dcd8c5080dff"), "G.46.75", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of chemical products" },
                    { new Guid("a5e21869-f6a0-4db7-923a-baf1f343084e"), "G.46.76", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of other intermediate products" },
                    { new Guid("b51f959e-94fb-4cfa-9f29-7102e9897760"), "G.46.77", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of waste and scrap" },
                    { new Guid("d95bdb2b-5b80-4574-b63a-e1e4f0361258"), "G.46.9", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Non-specialised wholesale trade" },
                    { new Guid("c8ab3127-5844-42e0-8a9c-39e07a55e221"), "G.46.90", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Non-specialised wholesale trade" },
                    { new Guid("05f3771a-c0e3-4748-a5d0-00f151932788"), "G.47", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("bbb8037c-cf5f-4db5-ba57-5f9e7f5131bc"), "G.47.1", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale in non-specialised stores" },
                    { new Guid("6946b73a-6d24-4ae7-9600-c75a0188820b"), "G.47.11", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("aac915d5-548b-46de-92ac-5e72f5cf32fe"), "G.47.19", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Other retail sale in non-specialised stores" },
                    { new Guid("98c282ad-fa53-48a6-83f4-59fdaf2649d1"), "G.47.2", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("68a932bc-55b4-4a6e-8d07-8014e548af7a"), "G.47.21", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("fc3c7f5c-5aba-4c71-9163-7c560aa89211"), "G.47.22", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("963d8f9c-a803-4dee-8186-47fb149461c3"), "G.47.23", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("ea7219ce-746d-4023-adda-8e422ec7c4b2"), "G.47.24", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("1afe128c-3680-4181-be79-099dad9a6c05"), "G.47.25", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Retail sale of beverages in specialised stores" },
                    { new Guid("4dda8f11-e2e7-4fdc-b259-e0e9197b4301"), "G.46.52", new Guid("9be4bc06-13a8-432c-830e-849e78f4a928"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("ff04c70e-d5ad-442a-bf71-ff566cfbb3c5"), "F.43.22", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("51b90cfa-9df6-41b7-b912-0756b263d465"), "K.64.99", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("5247da5d-934f-49eb-87d2-c66567cf9035"), "K.65.1", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Insurance" },
                    { new Guid("cb0dd94c-2365-4045-ab27-19bd3c927659"), "P.85.6", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Educational support activities" },
                    { new Guid("9d6e998b-83e3-49d3-8732-65d800b3e885"), "P.85.60", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Educational support activities" },
                    { new Guid("7be73dd5-fc3d-4c30-84aa-3f18531da5fe"), "Q.86", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Human health activities" },
                    { new Guid("1cfc5e9b-c035-42d8-b5b0-b89b715df228"), "Q.86.1", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Hospital activities" },
                    { new Guid("66bd1074-5caa-4a6d-a574-9133b7eee156"), "Q.86.10", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Hospital activities" },
                    { new Guid("a4965639-3524-4b6b-bf02-ded1d8fc3538"), "Q.86.2", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Medical and dental practice activities" },
                    { new Guid("d45c72fd-ef7f-406d-a069-8f4b4a6bf1c7"), "Q.86.21", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ee6f8f37-0861-4248-a98c-19196aa74558"), "Q.86.22", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Specialist medical practice activities" },
                    { new Guid("c06b4052-d9aa-4ea6-8fad-77ed68fb0e83"), "Q.86.23", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Dental practice activities" },
                    { new Guid("ae25be8a-ddd3-4ed9-99ff-7daf62c2db41"), "Q.86.9", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Other human health activities" },
                    { new Guid("50e9338a-ce36-4d09-9d43-e251d12e71d5"), "Q.86.90", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Other human health activities" },
                    { new Guid("faddea35-092d-4b1b-ae8c-3d541387ae89"), "Q.87", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential care activities" },
                    { new Guid("3869d4e8-4023-41ee-a277-7db5b7471945"), "P.85.59", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Other education n.e.c." },
                    { new Guid("3f5561e7-c675-45fd-8516-253358e24a4c"), "Q.87.1", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential nursing care activities" },
                    { new Guid("b21bda3f-306c-47cf-8877-d1ac5379d553"), "Q.87.2", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("9219a161-2968-4770-b983-a53360ca5d08"), "Q.87.20", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("585683e0-f73f-4f43-bb5e-010961d9a828"), "Q.87.3", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential care activities for the elderly and disabled" },
                    { new Guid("211635f8-ecb4-447a-9a63-07d68b7aee7e"), "Q.87.30", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential care activities for the elderly and disabled" },
                    { new Guid("cafcff3a-61dc-452f-921b-48e04c0daf95"), "Q.87.9", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Other residential care activities" },
                    { new Guid("84d8744d-012b-42a5-9656-503929426499"), "Q.87.90", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Other residential care activities" },
                    { new Guid("445c68d1-5098-42f3-9c54-b966ad2d9129"), "Q.88", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Social work activities without accommodation" },
                    { new Guid("45c6a119-df8b-4c30-9355-d2e643c6c706"), "Q.88.1", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("024d01c8-9092-412a-9d63-163b5195ec66"), "Q.88.10", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("2c238654-66bc-44f3-830b-c50571c8b70d"), "Q.88.9", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Other social work activities without accommodation" },
                    { new Guid("ffad4b43-78ee-4ee9-b484-d08e9d81526c"), "Q.88.91", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Child day-care activities" },
                    { new Guid("86293ab6-ed6f-4b97-a8b6-6187d3a8a449"), "Q.88.99", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("2c38ef76-3ba4-47a8-a39b-7815edd26ce4"), "Q.87.10", new Guid("b0b51b1d-d5a4-4fa1-8098-26d6cb0d057f"), "Residential nursing care activities" },
                    { new Guid("10f53b67-7267-48a1-9083-68a62b4553ab"), "P.85.53", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Driving school activities" },
                    { new Guid("2e4a3eb8-c1ad-4a7c-9b4e-fd4a0edc5c93"), "P.85.52", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Cultural education" },
                    { new Guid("ac3f0504-3e59-478c-940e-d742d61e4c42"), "P.85.51", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Sports and recreation education" },
                    { new Guid("c4b355b6-03ab-43b0-8bbf-e954ff20af1e"), "N.82.91", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Packaging activities" },
                    { new Guid("dfb1138f-5d60-4d0b-9c2e-1dac64ebc8b1"), "N.82.99", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other business support service activities n.e.c." },
                    { new Guid("cf9ce842-98da-4e9b-ab85-a57bfd5be0a3"), "O.84", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Public administration and defence; compulsory social security" },
                    { new Guid("6aafd136-d0f4-4f26-8e7f-a04dd639a140"), "O.84.1", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("b945c465-0607-4111-8f68-872545365a33"), "O.84.11", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "General public administration activities" },
                    { new Guid("916c591c-ad1d-404c-9fe5-49909a8896da"), "O.84.12", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("9e93a892-563c-4a28-b92c-0abde2872b93"), "O.84.13", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("86c042b6-090a-4fa2-977b-76dcf840ca89"), "O.84.2", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Provision of services to the community as a whole" },
                    { new Guid("717e85b7-9659-419a-9556-be399b841396"), "O.84.21", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Foreign affairs" },
                    { new Guid("e0e3f47a-86b9-4f40-a4d9-2d8bbf5a5845"), "O.84.22", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Defence activities" },
                    { new Guid("ea5524e1-aa26-4981-97bb-47fc47026f9a"), "O.84.23", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Justice and judicial activities" },
                    { new Guid("6afd462b-4c04-4d5c-8c0e-f37041836e23"), "O.84.24", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Public order and safety activities" },
                    { new Guid("55dad54d-0b95-4766-b0f5-571216107b1b"), "O.84.25", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Fire service activities" },
                    { new Guid("a02d8f87-6ab4-4b24-8d4e-a32d1cd5e29a"), "O.84.3", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Compulsory social security activities" },
                    { new Guid("e324cb07-d86e-4af7-ac9a-0ebeb4cdc422"), "O.84.30", new Guid("75c6aaf3-1575-4e7c-8e95-3a392c1e0bac"), "Compulsory social security activities" },
                    { new Guid("93ff568f-c739-4fc3-872e-4419b4065d4a"), "P.85", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Education" },
                    { new Guid("4d10cd81-3b35-4c87-91d2-ebcefa5a1f79"), "P.85.1", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Pre-primary education" },
                    { new Guid("46fc765a-cb1a-4dca-a5f4-d8ffe7af767b"), "P.85.10", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Pre-primary education" },
                    { new Guid("722ea4ba-3913-4a58-83c5-78eb1ce60b8b"), "P.85.2", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e62aa61b-c074-406b-86f8-79299c8a5db1"), "P.85.20", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Primary education" },
                    { new Guid("b863c4a6-e943-4617-9a4e-13e24e9a0175"), "P.85.3", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Secondary education" },
                    { new Guid("16d49935-018e-4c17-a1e0-fc29a51240a7"), "P.85.31", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "General secondary education" },
                    { new Guid("071006b8-657e-46c5-82d1-63e5d1cca671"), "P.85.32", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Technical and vocational secondary education" },
                    { new Guid("bd3d9f04-556b-4a0d-a3b9-f643e7258ec0"), "P.85.4", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Higher education" },
                    { new Guid("2ccf35d7-9560-4e8d-9952-c8d52ffdf9a0"), "P.85.41", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Post-secondary non-tertiary education" },
                    { new Guid("6649a3a2-aafb-4d0b-a05a-f3f0eec06c76"), "P.85.42", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Tertiary education" },
                    { new Guid("73d1fd68-7979-4448-bab3-8553ee5db208"), "P.85.5", new Guid("929cc3df-9f1c-42d3-9a00-be4f3e1f5f6c"), "Other education" },
                    { new Guid("1b28407f-0688-4aed-b7c2-9f1b55e7137c"), "R.90", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Creative, arts and entertainment activities" },
                    { new Guid("680b9144-dcbe-40eb-80b6-94cb33434164"), "N.82.92", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("a5e2cec6-5ca6-4700-ad0b-3253949d3fff"), "R.90.0", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Creative, arts and entertainment activities" },
                    { new Guid("5de08b4f-7cd0-4c1e-a23d-2bd48eb3591b"), "R.90.02", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Support activities to performing arts" },
                    { new Guid("2ac72c0e-e1c5-40ec-a78c-db6ab3fa4f89"), "S.95.1", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of computers and communication equipment" },
                    { new Guid("c2f5f000-903a-49b4-b7c0-fee702514526"), "S.95.11", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of computers and peripheral equipment" },
                    { new Guid("80517ee0-05e7-431e-90b8-366c05eba735"), "S.95.12", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of communication equipment" },
                    { new Guid("0eafd534-9f3a-4c76-831d-14de3b8cb852"), "S.95.2", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of personal and household goods" },
                    { new Guid("9176cf17-e02a-488c-9008-a575e3da0e0f"), "S.95.21", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of consumer electronics" },
                    { new Guid("39dc4c87-c96c-46d4-a671-68b36793424b"), "S.95.22", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("9efe11da-7ef2-41ec-91d7-1aebc369ecf3"), "S.95.23", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of footwear and leather goods" },
                    { new Guid("50f56fa4-ba54-404b-b1c6-e3ece58c8ea3"), "S.95.24", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of furniture and home furnishings" },
                    { new Guid("76575cb0-d5c5-4453-a281-194246ac8fda"), "S.95.25", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of watches, clocks and jewellery" },
                    { new Guid("147b5360-e5ba-4d73-9281-c91b3ce31fb9"), "S.95.29", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of other personal and household goods" },
                    { new Guid("ddc3c9bc-4206-4fa9-ba83-e6f4bf00499b"), "S.96", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Other personal service activities" },
                    { new Guid("4ffafb86-7308-4e00-aafb-6c7168601b2d"), "S.96.0", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Other personal service activities" },
                    { new Guid("08e023b9-47e7-4b19-a5c2-535cfe20994f"), "S.95", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Repair of computers and personal and household goods" },
                    { new Guid("196ab9ac-c93a-4c5f-83c0-262d56e62a79"), "S.96.01", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("8dd304db-826c-43dd-b681-451270928e9d"), "S.96.03", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Funeral and related activities" },
                    { new Guid("dd53dad0-1163-4fe9-9175-b9f0db754b98"), "S.96.04", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Physical well-being activities" },
                    { new Guid("00bd5340-d5d6-4b9a-8478-7332309c0d52"), "S.96.09", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Other personal service activities n.e.c." },
                    { new Guid("ac06b789-a71c-4ab1-abaf-76535c0f28cf"), "T.97", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Activities of households as employers of domestic personnel" },
                    { new Guid("007122cb-2186-4121-b092-76f5f03f516b"), "T.97.0", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Activities of households as employers of domestic personnel" },
                    { new Guid("bb936109-7092-4a86-b121-d4dbe0b22636"), "T.97.00", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Activities of households as employers of domestic personnel" },
                    { new Guid("a1699ed5-23f9-4f5b-9f74-9660596d2d8b"), "T.98", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("b69045c1-7baa-435a-b550-ea18547397a6"), "T.98.1", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("2cc4098f-eb0d-44b1-811a-d0405995a0d7"), "T.98.10", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("7885102e-72ed-4638-8b74-d1ef1344bf2b"), "T.98.2", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("7ecf4cf2-787a-4a35-b198-ab1f6d131941"), "T.98.20", new Guid("d05e7055-19b5-4cc2-86c8-231be70303ba"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("83977351-7516-4667-9c56-c83e1414cd96"), "U.99", new Guid("07fdd34d-52f1-44bb-a87c-e15ca4240ab9"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("46587e86-e89e-4265-91e3-1a3494544253"), "S.96.02", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Hairdressing and other beauty treatment" },
                    { new Guid("64733cb2-55c9-4848-980d-9a433109bcf8"), "S.94.99", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of other membership organisations n.e.c." },
                    { new Guid("12f608d9-fd16-425b-964d-ca70c242778b"), "S.94.92", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of political organisations" },
                    { new Guid("19edabf0-a0e4-4a21-aeeb-396ebd1fcbef"), "S.94.91", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("32ed83c9-7877-49eb-8130-a1b08aec0b87"), "R.90.03", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Artistic creation" },
                    { new Guid("01b07552-d2f4-4eae-9ee8-e8479c662aa6"), "R.90.04", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Operation of arts facilities" },
                    { new Guid("4e7ed4f9-dd4b-40be-b323-3aa9a5b8847e"), "R.91", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("4ac86db8-e661-4d1f-89f0-7f30e115f6a2"), "R.91.0", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("6d3f9ab3-7750-48a4-a290-03306e4a6813"), "R.91.01", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Library and archives activities" },
                    { new Guid("cda09a56-331b-4ddb-bf2f-1ff08a19823a"), "R.91.02", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Museums activities" },
                    { new Guid("031608ec-60dd-440e-b43e-b5dab40de9bf"), "R.91.03", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("7e5dd1d0-2589-4e2f-ac62-062982704a1d"), "R.91.04", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("2a99df82-261f-48f4-bb5f-934f72e6250c"), "R.92", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Gambling and betting activities" },
                    { new Guid("58c259fb-d421-4c00-ae13-c4a0e468a841"), "R.92.0", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Gambling and betting activities" },
                    { new Guid("4cfacbf4-8149-48d5-9463-7b59cacd174d"), "R.92.00", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Gambling and betting activities" },
                    { new Guid("da4488ad-7a86-4e6f-9e39-45b4745a4a89"), "R.93", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Sports activities and amusement and recreation activities" },
                    { new Guid("b896744e-cb32-40c5-9e24-8a77b7f20a46"), "R.93.1", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Sports activities" },
                    { new Guid("5841554a-adb2-4f07-b641-ff6d29e405d1"), "R.93.11", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Operation of sports facilities" },
                    { new Guid("6d925a4a-fadc-40d7-92d9-21cec8f9d90a"), "R.93.12", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Activities of sport clubs" },
                    { new Guid("1a5c7019-dc80-4ac4-b5ba-73e389df9782"), "R.93.13", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Fitness facilities" },
                    { new Guid("e0ad4f13-6057-4b5d-9bae-5d0a9b4a6a5c"), "R.93.19", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Other sports activities" },
                    { new Guid("7c6a5509-e147-4c8f-9c46-c0222ec0862d"), "R.93.2", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Amusement and recreation activities" },
                    { new Guid("861f4124-ba35-422c-8c2a-e855c182e5b8"), "R.93.21", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Activities of amusement parks and theme parks" },
                    { new Guid("f05f842b-11e5-4395-bc57-b475b60dfd46"), "R.93.29", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Other amusement and recreation activities" },
                    { new Guid("8e7542e2-5916-437a-8016-87dd608bceba"), "S.94", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of membership organisations" },
                    { new Guid("0e6cb1be-ab5d-4df8-bc3e-cc3d89f03d76"), "S.94.1", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("cb8c902f-f125-4ea1-9ce2-6d4cc0f9d907"), "S.94.11", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of business and employers membership organisations" },
                    { new Guid("6937cf09-6e01-47b6-b8d0-717ede69d33a"), "S.94.12", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of professional membership organisations" },
                    { new Guid("a580ea05-856b-4cf1-a006-ec7749217944"), "S.94.2", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of trade unions" },
                    { new Guid("ece3f04d-fa3d-4c3b-939c-49688628bab4"), "S.94.20", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of trade unions" },
                    { new Guid("b4c0aef6-474f-4ff6-bd25-e9d010ca50d2"), "S.94.9", new Guid("96e82805-0b18-4a3a-b973-bcb58797c47c"), "Activities of other membership organisations" },
                    { new Guid("941a8b47-f8c0-4009-8502-e056d75d64cc"), "R.90.01", new Guid("85f427d1-1cd8-4082-a9d2-fdd8881fe213"), "Performing arts" },
                    { new Guid("3f4dbab1-2f42-447e-bb5c-3e6853af8724"), "K.65", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("ff6157f7-5e77-47ae-ae91-9ccbb3af0f67"), "N.82.9", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Business support service activities n.e.c." },
                    { new Guid("60d2f94d-e621-447a-9f13-8fabb7fc5718"), "N.82.3", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Organisation of conventions and trade shows" },
                    { new Guid("f5a61b45-4636-4648-b022-da55108390b3"), "M.70.1", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Activities of head offices" },
                    { new Guid("8331f12d-4631-41a7-b994-9583b4fc9901"), "M.70.10", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Activities of head offices" },
                    { new Guid("8079bcaa-9c6d-4115-8148-fdf77076d1ef"), "M.70.2", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Management consultancy activities" },
                    { new Guid("53bb3668-b36e-46c5-ae9d-6512f3d9e8a2"), "M.70.21", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Public relations and communication activities" },
                    { new Guid("e9bc506e-90ed-4d00-836f-817941208247"), "M.70.22", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Business and other management consultancy activities" },
                    { new Guid("8c409c23-a700-4c17-9a6f-bb8a32b187a2"), "M.71", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("46b93413-23cc-47ec-9826-169f3e35d15f"), "M.71.1", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("732bfb6d-0bf1-4ab9-95fa-7dd252384bce"), "M.71.11", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Architectural activities" },
                    { new Guid("1591601b-836d-4abe-8a36-3e60abbe0fcb"), "M.71.12", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Engineering activities and related technical consultancy" },
                    { new Guid("559c5984-14a8-42e4-99b0-d8c08f8f500a"), "M.71.2", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Technical testing and analysis" },
                    { new Guid("067665d4-dc0e-4fe9-bf69-86bb68845e4a"), "M.71.20", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("312f8c93-e5d2-480b-b54e-7c95b4023320"), "M.72", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Scientific research and development" },
                    { new Guid("4719ccbf-f837-4754-84cd-4d700746c827"), "M.70", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Activities of head offices; management consultancy activities" },
                    { new Guid("f0aa3d91-9fab-4333-8655-f37612bd5cd9"), "M.72.1", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("9a3f6f23-d9a5-4bc8-8962-b20066e4eef5"), "M.72.19", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("a04744fe-3eb6-4688-824c-9f5302302914"), "M.72.2", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("eee7884c-9a1c-4780-839c-fc541af1266f"), "M.72.20", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("95aa04af-cfe9-4321-9c3a-25f754dded40"), "M.73", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Advertising and market research" },
                    { new Guid("639e12b7-fcce-4591-914e-f29280a37c2d"), "M.73.1", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Advertising" },
                    { new Guid("5581fe8f-0a2a-43a7-be33-aa3ded98397c"), "M.73.11", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Advertising agencies" },
                    { new Guid("f78c91ee-e3c3-48f1-9fe2-bc18572198fb"), "M.73.12", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Media representation" },
                    { new Guid("17c51246-9424-4d5a-b87c-24f5ea185c6d"), "M.73.2", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Market research and public opinion polling" },
                    { new Guid("73c23544-d51d-4de0-8964-0238e5eec866"), "M.73.20", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Market research and public opinion polling" },
                    { new Guid("b933cca5-bd9d-48a2-a0d0-c74a9ab3665e"), "M.74", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Other professional, scientific and technical activities" },
                    { new Guid("5695f486-c414-4356-ae49-9d800407c210"), "M.74.1", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Specialised design activities" },
                    { new Guid("93cd8280-ea76-4209-9619-42c91d3e197d"), "M.74.10", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Specialised design activities" },
                    { new Guid("77a8c389-f700-4cee-90fa-ffc5dcfebe21"), "M.72.11", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Research and experimental development on biotechnology" },
                    { new Guid("48902851-3ed4-4d41-96ea-95295c95652d"), "M.69.20", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("43c4c638-dabf-4247-938d-47fd82056ed9"), "M.69.2", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("57a1b917-ea50-4030-b68d-ab1212bd52a5"), "M.69.10", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Legal activities" },
                    { new Guid("abbb33ec-3628-4b84-9de9-e011b176226e"), "K.65.11", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Life insurance" },
                    { new Guid("443600ed-ca71-432f-b4ea-3d05a98ad978"), "K.65.12", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Non-life insurance" },
                    { new Guid("feb3924f-9ede-4405-914a-ba224663df73"), "K.65.2", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Reinsurance" },
                    { new Guid("885f9da0-1702-4212-9ef3-669bcdfb307f"), "K.65.20", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Reinsurance" },
                    { new Guid("cc0dc955-c9f7-4069-b327-96947d49e681"), "K.65.3", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Pension funding" },
                    { new Guid("ff751ab7-7a7b-4863-a9d1-c9bde2b65e0c"), "K.65.30", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Pension funding" },
                    { new Guid("6e8a6c4c-dfdc-48a9-b2aa-80a094cf7d58"), "K.66", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("43f15f29-13ca-44ef-8c0d-9bac2affc98f"), "K.66.1", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("477862a7-550c-432e-9143-161300f4bc8c"), "K.66.11", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Administration of financial markets" },
                    { new Guid("e6b48d7b-0be1-4120-bea5-02afc1ab15e4"), "K.66.12", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Security and commodity contracts brokerage" },
                    { new Guid("a2d0a342-abad-43b4-a2f4-e66b75d3fdad"), "K.66.19", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("96b90c0a-160d-4d68-af03-f10988397804"), "K.66.2", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("42a0141b-966c-4852-ba72-9d1242175d10"), "K.66.21", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Risk and damage evaluation" },
                    { new Guid("9644b3a2-4634-4bad-b8b6-7c795f703bf3"), "K.66.22", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Activities of insurance agents and brokers" },
                    { new Guid("81bc932a-4d4f-4b1f-8fe1-c35948b25380"), "K.66.29", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("6267bb72-b1d1-4627-96d9-3dc7090025b6"), "K.66.3", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Fund management activities" },
                    { new Guid("1ccbc557-5d02-4ef5-8fd9-c92890037e70"), "K.66.30", new Guid("d4b16e98-1259-4c5e-bd62-0213b593c1db"), "Fund management activities" },
                    { new Guid("5f3f18ae-564a-4465-b67b-633c84b036c5"), "L.68", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Real estate activities" },
                    { new Guid("95f1e1df-b0d1-4e9a-aba7-3b65f644044e"), "L.68.1", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Buying and selling of own real estate" },
                    { new Guid("dae99e67-64bc-46ac-972c-2d14da743516"), "L.68.10", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Buying and selling of own real estate" },
                    { new Guid("1e1e01d3-1b43-410b-906f-c32df4db56f0"), "L.68.2", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Renting and operating of own or leased real estate" },
                    { new Guid("ac388ce8-ac9f-476d-87e7-cb36d346f81f"), "L.68.20", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Renting and operating of own or leased real estate" },
                    { new Guid("a08e603b-0c37-4f3b-a06e-589114eb92f1"), "L.68.3", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a2678ffe-351a-411f-b797-02f915378386"), "L.68.31", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Real estate agencies" },
                    { new Guid("951a9db9-46d6-498d-9fb0-fbcee615334a"), "L.68.32", new Guid("aaa46201-fb46-446f-82d5-11454a8abc53"), "Management of real estate on a fee or contract basis" },
                    { new Guid("6b64ab10-b78f-4713-a8d7-7e27922fdd67"), "M.69", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Legal and accounting activities" },
                    { new Guid("6b27db7f-ed0b-4035-bee9-2f0cabc61d54"), "M.69.1", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Legal activities" },
                    { new Guid("52de29cf-5323-4fc1-afc4-ee1d1cb0ca9b"), "M.74.2", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Photographic activities" },
                    { new Guid("99ba9114-47e3-43d5-8dc1-f966cb14f26f"), "N.82.30", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Organisation of conventions and trade shows" },
                    { new Guid("a2e90023-6884-4945-bffe-02daebcf9275"), "M.74.20", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Photographic activities" },
                    { new Guid("314198da-22be-4c23-85df-347cefaa14d6"), "M.74.30", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Translation and interpretation activities" },
                    { new Guid("d494d7ce-856e-493b-8d77-aab4f5ed5014"), "N.79.11", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Travel agency activities" },
                    { new Guid("54b6a28d-1560-4bfb-b19b-5a6f9a8add61"), "N.79.12", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Tour operator activities" },
                    { new Guid("65eaa559-ef6b-48dc-aa08-60cfedc3e013"), "N.79.9", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other reservation service and related activities" },
                    { new Guid("72276685-208c-4c24-9444-4d719ec072bd"), "N.79.90", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other reservation service and related activities" },
                    { new Guid("74933535-3ee3-45bb-93bb-8d12681347a9"), "N.80", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Security and investigation activities" },
                    { new Guid("beee955e-fde9-4974-9ede-f4aaa7afe30a"), "N.80.1", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Private security activities" },
                    { new Guid("5ecd424a-858e-4525-b756-ad8c8857966d"), "N.80.10", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Private security activities" },
                    { new Guid("b56a32dd-5bc7-4519-bedb-c881542a21ef"), "N.80.2", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Security systems service activities" },
                    { new Guid("e5ce5c50-ae08-4a5b-a2b0-ed24716f1080"), "N.80.20", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Security systems service activities" },
                    { new Guid("a7791ba9-fa62-49c3-8cee-704836bd9704"), "N.80.3", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Investigation activities" },
                    { new Guid("ef4fa02c-9adf-4b47-aaf1-02b179efd46d"), "N.80.30", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Investigation activities" },
                    { new Guid("2d93eefd-040d-4d39-b57c-3664a75fa2fa"), "N.81", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Services to buildings and landscape activities" },
                    { new Guid("48995d8d-19bd-40fd-9ab7-ff2b31bbd79f"), "N.79.1", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Travel agency and tour operator activities" },
                    { new Guid("a1cacdbb-f804-4cf1-88e2-0fa91cdea8fb"), "N.81.1", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Combined facilities support activities" },
                    { new Guid("20428514-238b-47cc-b255-a990037a1057"), "N.81.2", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Cleaning activities" },
                    { new Guid("819c85e9-4923-456d-8d78-d8cf3f66b182"), "N.81.21", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "General cleaning of buildings" },
                    { new Guid("b527f477-902e-48ac-9a39-0b1afe5f06fb"), "N.81.22", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other building and industrial cleaning activities" },
                    { new Guid("dab5ccca-1a53-494e-b9d8-fbbc4061e025"), "N.81.29", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other cleaning activities" },
                    { new Guid("b5c9cbaf-ce1c-4e2a-8208-81da1193f7ce"), "N.81.3", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Landscape service activities" },
                    { new Guid("679c7834-ec6a-41d0-a156-56e89bab0cd8"), "N.81.30", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Landscape service activities" },
                    { new Guid("8e07a029-fc2d-422a-8b7a-fdc4affbdba3"), "N.82", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Office administrative, office support and other business support activities" },
                    { new Guid("965d8d90-8a4d-4214-9516-3b95fbd81692"), "N.82.1", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Office administrative and support activities" },
                    { new Guid("f65cfaec-4021-4beb-96aa-c5de6d5fd5fb"), "N.82.11", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Combined office administrative service activities" },
                    { new Guid("13bbb996-81c7-4746-8c35-51ed678e8046"), "N.82.19", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("07812e1b-b250-4ed1-99dc-437ad2444a51"), "N.82.2", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Activities of call centres" },
                    { new Guid("b8aa2ba3-af12-476f-b4c5-7c97b6c7de01"), "N.82.20", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Activities of call centres" },
                    { new Guid("0aff228f-54bc-4ea7-b197-5f47bcbbdc48"), "N.81.10", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Combined facilities support activities" },
                    { new Guid("db812bb1-85de-4048-9706-ca40b81b04b2"), "N.79", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("e02c57c7-b46b-466f-b60c-e46e90fe15b5"), "N.78.30", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other human resources provision" },
                    { new Guid("767a67ca-30da-4c16-931c-9b76de9a6061"), "N.78.3", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Other human resources provision" },
                    { new Guid("7b626357-13f9-44d6-b8c5-346063a92cbd"), "M.74.9", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("9db5d916-4d79-4f87-a3f4-d709b1ef8a8b"), "M.74.90", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("5b1f051e-a315-4c6a-bc5e-772539a3331b"), "M.75", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Veterinary activities" },
                    { new Guid("da23c53b-da42-4063-a230-69f89876bdec"), "M.75.0", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a34d414a-d20e-4ef1-99c0-c3fe0205192c"), "M.75.00", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Veterinary activities" },
                    { new Guid("397e226b-5587-4ec9-8125-6310ff3aca7b"), "N.77", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Rental and leasing activities" },
                    { new Guid("34ac78d2-8294-4f54-93ef-8e8650cdcc1e"), "N.77.1", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of motor vehicles" },
                    { new Guid("d34c1090-f282-40e8-bb04-0c0eac55acdc"), "N.77.11", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("0ab5cfe6-7ed8-4d38-877e-c5d8c41f825e"), "N.77.12", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of trucks" },
                    { new Guid("47330a02-1f61-4861-aec1-9406719b60ab"), "N.77.2", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of personal and household goods" },
                    { new Guid("9088f202-8418-46a5-8928-1d48fb427aed"), "N.77.21", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("57cac04b-d905-4373-bc49-665383534488"), "N.77.22", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting of video tapes and disks" },
                    { new Guid("aab46528-1711-47f1-9ea6-04c64c8827cf"), "N.77.29", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of other personal and household goods" },
                    { new Guid("0286d526-c174-416b-8208-dbc3bb0aa3a6"), "N.77.3", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("b670f62e-5eff-4810-9486-cc0203381a8d"), "N.77.31", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("680da3d3-8172-49ba-bbe0-3b4e09513db7"), "N.77.32", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("9d3983e6-f2cb-4127-bfd4-bf8883935789"), "N.77.33", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("1cddf26c-6c80-4390-ba06-04e2cbf62862"), "N.77.34", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of water transport equipment" },
                    { new Guid("a122a106-7def-4e88-b7f1-eeaae3993c3b"), "N.77.35", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of air transport equipment" },
                    { new Guid("f14599c6-f292-430f-9d20-9c993982df7a"), "N.77.39", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("148322f8-6a9b-4470-9eb6-5f6721c9f066"), "N.77.4", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("42a5af44-8e67-4d7b-a216-70aeaf22fa03"), "N.77.40", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("e34b05ec-3fad-4dca-a61f-7f7ece16b95c"), "N.78", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Employment activities" },
                    { new Guid("16f8cd75-6ad4-43ab-bf22-416fb96e3003"), "N.78.1", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Activities of employment placement agencies" },
                    { new Guid("f456cbbe-49ec-40df-993a-fc8312b41999"), "N.78.10", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Activities of employment placement agencies" },
                    { new Guid("4add45fd-87ad-4a1c-aaf5-122faa1327fd"), "N.78.2", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Temporary employment agency activities" },
                    { new Guid("9f85587c-4601-46fb-83d8-e502580259c7"), "N.78.20", new Guid("6c58aa0e-b69e-4ed1-8dc1-00e53c112a92"), "Temporary employment agency activities" },
                    { new Guid("c38a60a7-1e42-48d1-9b86-c6aaf9237003"), "M.74.3", new Guid("1e05788e-2bac-4f73-a960-6c6658b751e8"), "Translation and interpretation activities" },
                    { new Guid("76b1ee2c-eb36-4384-83ba-6c73667915ca"), "U.99.0", new Guid("07fdd34d-52f1-44bb-a87c-e15ca4240ab9"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("86c7ecb1-46cd-4142-af37-b4d57c3e362c"), "F.43.21", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Electrical installation" },
                    { new Guid("0cd30f15-4e27-41e5-90b1-1b1c0c2a438a"), "F.43.13", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Test drilling and boring" },
                    { new Guid("c5c39d35-6c2f-49ba-a413-039d354b7a27"), "C.14.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of articles of fur" },
                    { new Guid("3a7673cd-062f-4866-b66a-77b1dac84720"), "C.14.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of articles of fur" },
                    { new Guid("62784a76-ef34-4685-bada-00a7247f795e"), "C.14.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("06aee9aa-d060-4356-825d-e246a8af33bb"), "C.14.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("22ab828c-6468-43f6-bfb3-73e795ae77df"), "C.14.39", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("af824bc2-5c1b-4db4-9a06-e5ff2e599e1c"), "C.15", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of leather and related products" },
                    { new Guid("b66f5cf2-3ff9-47a4-b46b-13fb2067c5a2"), "C.15.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("3663b71a-15c1-40b0-bb27-e3c34e4b360f"), "C.15.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("d271183d-410d-446a-9ab4-c614f55bf984"), "C.15.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("3aad4f9f-f0bd-4b89-82ef-da07c02c454e"), "C.15.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of footwear" },
                    { new Guid("efcae712-fb1c-4029-bbb5-ed20f3374905"), "C.15.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of footwear" },
                    { new Guid("a9f89204-7a79-4258-905c-0ff8a4f58490"), "C.16", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("53ea6c10-ae5a-4388-8692-f47e19a9fe72"), "C.14.19", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("6657645d-de8e-428a-a53f-c63ba9047481"), "C.16.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Sawmilling and planing of wood" },
                    { new Guid("c99897bb-1471-4eff-90f3-ee1672dd5913"), "C.16.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4714d2f8-0f61-40bb-a6b7-5ae1ccd69003"), "C.16.21", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("a16fcb00-85ab-4524-a45c-2bcb94e797bd"), "C.16.22", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of assembled parquet floors" },
                    { new Guid("31517c9b-458d-438a-8f54-74f3f985ea64"), "C.16.23", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("30c93fc9-c25c-4e95-8e6c-bad35b793558"), "C.16.24", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wooden containers" },
                    { new Guid("9307177e-1924-4ae6-aa35-777c0ec57782"), "C.16.29", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("368de710-5a32-4e25-bad7-b22f63cc48e3"), "C.17", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of paper and paper products" },
                    { new Guid("b6d397d1-9b66-4daf-8a75-edd68182b330"), "C.17.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("89052ac4-f963-42c5-876c-8414d59fe43d"), "C.17.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of pulp" },
                    { new Guid("546abeed-d6aa-4bfb-9950-ae742449184b"), "C.17.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of paper and paperboard" },
                    { new Guid("2a40972d-5945-4a81-bacb-b27069b91214"), "C.17.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("226e8f8e-3446-4c49-b01c-1084a0044d4c"), "C.17.21", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("dcf179e4-a554-462a-944c-4646630956f3"), "C.16.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Sawmilling and planing of wood" },
                    { new Guid("8785bde8-9804-46cf-9bc2-d6960d2c6146"), "C.14.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of underwear" },
                    { new Guid("a2123746-a91b-4977-96b4-07bec0eb5c4b"), "C.14.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other outerwear" },
                    { new Guid("05299ba2-8992-4ff7-8b2a-2e5a2a1591fa"), "C.14.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of workwear" },
                    { new Guid("86c867e9-0163-4f2d-9de8-c98fd5103f4f"), "C.11.02", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wine from grape" },
                    { new Guid("0d289fab-5dde-4d42-ae9a-f2cd3e7feac3"), "C.11.03", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cider and other fruit wines" },
                    { new Guid("f6326de1-f934-4e98-925a-253df8ff0b67"), "C.11.04", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("a4880dd0-c07f-41d1-a37d-fdb4a597a6a2"), "C.11.05", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of beer" },
                    { new Guid("7b54b1d4-addc-4622-a6b3-1ed48e3705da"), "C.11.06", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of malt" },
                    { new Guid("5ca69f78-1089-4178-b1c2-f51825c1e9d0"), "C.11.07", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("88da91e3-b546-4f0a-936f-b8cf78bf27e5"), "C.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tobacco products" },
                    { new Guid("f884c456-ffcf-4a19-83dc-529976d5d55c"), "C.12.0", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tobacco products" },
                    { new Guid("b0204518-8598-4d48-b1dc-23b62bf1d3f6"), "C.12.00", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tobacco products" },
                    { new Guid("ca38b197-afa4-49c3-8f43-501f12894458"), "C.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of textiles" },
                    { new Guid("1cdbccf3-6339-43e2-bad5-7004c38ecfcd"), "C.13.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Preparation and spinning of textile fibres" },
                    { new Guid("938b9895-aab8-483b-9ee6-f13b8e34ae5c"), "C.13.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Preparation and spinning of textile fibres" },
                    { new Guid("f996c106-05e2-4709-9219-ae63ccca0613"), "C.13.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Weaving of textiles" },
                    { new Guid("d820ed20-60c2-4350-afd7-ba44a72a9922"), "C.13.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Weaving of textiles" },
                    { new Guid("69bbb49d-747e-4d56-ad1b-1db3ac08bc03"), "C.13.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Finishing of textiles" },
                    { new Guid("0ba91537-df87-484b-8e58-7de40d6dc504"), "C.13.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Finishing of textiles" },
                    { new Guid("d60536f8-bffb-4bb8-990e-369137f9fdec"), "C.13.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other textiles" },
                    { new Guid("e3663228-7efc-4e65-a30e-28b0724e87c0"), "C.13.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("bc9cf184-829c-4e34-ab7c-e5ecb2da14fe"), "C.13.92", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("08c2b3be-a0ac-48f5-880e-a89c45798142"), "C.13.93", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of carpets and rugs" },
                    { new Guid("e7fe56fc-d731-4f5e-9145-3f1dbd00bdce"), "C.13.94", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("033c8b5d-9585-4d75-94a5-b4d29e46ae60"), "C.13.95", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("439df491-c021-46b6-8c8d-17ee8f6ef6a4"), "C.13.96", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("302275ad-77d8-49ba-93df-bd080b67db1f"), "C.13.99", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other textiles n.e.c." },
                    { new Guid("dbd12203-900b-42a6-b302-0391749bff42"), "C.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wearing apparel" },
                    { new Guid("0a7397b4-1c8c-4766-8ca0-9675acc0557a"), "C.14.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("dbb68e01-e90c-4142-8734-ae34daa47d89"), "C.14.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5331d2c8-d792-4ecf-b01e-80b597c15c43"), "C.17.22", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("d496bc1c-674e-46a9-80e4-82063cbf7190"), "C.11.01", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("c078ec2d-2850-4c26-9865-2e6bd5cef815"), "C.17.23", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of paper stationery" },
                    { new Guid("8fcf3e8b-7934-4355-a2eb-5bc6e75e93e6"), "C.17.29", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("5300e8ee-797b-4745-a02e-7b1b33ff9f9f"), "C.20.52", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of glues" },
                    { new Guid("222089e3-9b9b-41f6-b0e2-ba8935589331"), "C.20.53", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of essential oils" },
                    { new Guid("39c1b1e8-af9d-4a1d-8e7f-1cbc905f6e26"), "C.20.59", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("d8c1a7e1-953a-4638-bea3-220e336ebf07"), "C.20.6", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of man-made fibres" },
                    { new Guid("32dcecac-c14f-4b8b-926d-a407e2702710"), "C.20.60", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of man-made fibres" },
                    { new Guid("4f7a2b0c-2680-4d2c-a2fe-cb331f0c044b"), "C.21", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("68633c94-f2e5-4440-b1e2-48b8c56e021d"), "C.21.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("887f7088-6c93-4f79-8354-df799e485c47"), "C.21.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("84f24078-9b99-41d1-a4f7-9f7b5987ded2"), "C.21.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("6bc2ae41-ea19-4830-9498-18d4b5a9d85c"), "C.21.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("858b99cf-ce7c-404a-96aa-a22a3bbdfeb2"), "C.22", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of rubber and plastic products" },
                    { new Guid("5301a585-02a6-4ca2-8155-81b750d79f0a"), "C.22.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of rubber products" },
                    { new Guid("397a4ef2-6c90-4a2e-bbe7-cfd73e7822c8"), "C.20.51", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of explosives" },
                    { new Guid("187b1b9d-fea8-4daf-9bb2-6cf62844dfc7"), "C.22.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("67c52881-0ffe-4228-81b7-05a89921f520"), "C.22.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of plastics products" },
                    { new Guid("61ceb79e-f7a5-4760-bf90-eae5f2512c2d"), "C.22.21", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("64275f0d-8500-40ec-aaea-606b311a04d1"), "C.22.22", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of plastic packing goods" },
                    { new Guid("cb163389-9a0d-4654-b4e9-2870ba839843"), "C.22.23", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("f8ada4c6-d4b0-444f-8e27-4bba25316236"), "C.22.29", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other plastic products" },
                    { new Guid("215658f1-0a8f-4c20-b904-f75b475eeda8"), "C.23", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("a816cb71-b5c7-4a81-b2fe-2fd70600d74f"), "C.23.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of glass and glass products" },
                    { new Guid("eb2975e8-45e7-4336-a444-d924e63b2375"), "C.23.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of flat glass" },
                    { new Guid("ffa561fc-faae-493e-947d-247b02541fbe"), "C.23.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Shaping and processing of flat glass" },
                    { new Guid("06962bc2-a8a7-4bbe-98f6-dd6ae71b7141"), "C.23.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of hollow glass" },
                    { new Guid("75ea4e26-8c90-424c-8527-6da742e49bb1"), "C.23.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of glass fibres" },
                    { new Guid("f8c4fe6d-6a13-403c-98f4-8103b5d5b5a9"), "C.23.19", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("abc05159-5ba9-4de4-985e-9e137c75f023"), "C.22.19", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other rubber products" },
                    { new Guid("3e5f64d6-8ddb-408a-8e45-dcfb54d8bb29"), "C.20.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other chemical products" },
                    { new Guid("baf6c0b7-ff9f-4b68-9c65-8544e4986764"), "C.20.42", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("a98bdbf2-7990-4b0b-bdd3-bc9c04fbc810"), "C.20.41", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("e84b24db-17a8-4179-a3ca-b7f76625a60c"), "C.18", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Printing and reproduction of recorded media" },
                    { new Guid("5f054f0c-5a4e-4195-b4ce-90a6b9215cc5"), "C.18.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Printing and service activities related to printing" },
                    { new Guid("67436adb-53b9-4f16-8895-6d418429c7c3"), "C.18.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Printing of newspapers" },
                    { new Guid("5ffb15f0-9bcd-4940-9367-1dac6316bd05"), "C.18.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Other printing" },
                    { new Guid("b6ba2120-727e-4624-a31c-e27b9bc0088a"), "C.18.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Pre-press and pre-media services" },
                    { new Guid("5a113eec-a28c-4466-ade6-40f3c2d35880"), "C.18.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Binding and related services" },
                    { new Guid("162c422f-41e7-4720-a69c-bab0f8d90efc"), "C.18.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Reproduction of recorded media" },
                    { new Guid("e14a84d4-6732-44b5-b1cb-acb9fad5e4b7"), "C.18.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6c5d913c-bd12-418f-bdae-f21240ddfc6f"), "C.19", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("5755c684-379c-47b6-b3e4-b136c2a38231"), "C.19.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of coke oven products" },
                    { new Guid("3f44cc6e-008e-4e84-9355-7f4f8bb3ccea"), "C.19.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of coke oven products" },
                    { new Guid("00a3af29-df43-409f-9946-c8b0fa7b1947"), "C.19.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of refined petroleum products" },
                    { new Guid("7fffb78d-1303-4474-8aa4-b24eb08b1d02"), "C.19.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of refined petroleum products" },
                    { new Guid("34e53d0b-fb3d-4816-b5e5-7157f75c120d"), "C.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of chemicals and chemical products" },
                    { new Guid("49f31402-48ce-4333-8db1-2b0bffe57c24"), "C.20.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("eb1669d8-3702-4bf8-ac1e-91636b127a1c"), "C.20.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of industrial gases" },
                    { new Guid("0006542b-b84d-4184-b48d-1959ca31e81f"), "C.20.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of dyes and pigments" },
                    { new Guid("9eb46207-be83-4871-bb3c-12ad3b478fdd"), "C.20.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("b3d6f795-d38e-4ec0-9495-5dc99f20767b"), "C.20.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other organic basic chemicals" },
                    { new Guid("a940fbe1-0f82-4a53-8109-e58f44fc2611"), "C.20.15", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("13514141-7f7d-4d5c-a95d-de3bc297b353"), "C.20.16", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of plastics in primary forms" },
                    { new Guid("be11cbe9-eb83-4d92-a12b-9c6a3add71fe"), "C.20.17", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("f5ce5011-1f48-4284-9a45-e0394161c7e9"), "C.20.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("fbe48d84-66e0-4cd8-a081-c07ab5dee03d"), "C.20.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("aeb0d403-7f75-4f3b-84cc-2bc1d7976830"), "C.20.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("da86c230-945f-4160-89f6-a667489f58a5"), "C.20.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("1bc166a3-0778-493a-b4c4-0797c3d3a8e2"), "C.20.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("086b53c2-6e09-4b1a-8350-d25fccaa914d"), "C.17.24", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wallpaper" },
                    { new Guid("3b57c9c1-f110-47c1-92ed-2ed50e109c2c"), "C.23.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of refractory products" },
                    { new Guid("b0498b2f-5ad8-48a8-9126-fbd9e86bc0af"), "C.11.0", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of beverages" },
                    { new Guid("689590e7-c290-449c-9e31-44cfa8abef5b"), "C.10.92", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of prepared pet foods" },
                    { new Guid("7a26ae9c-de63-483e-bfdd-7ac5f89321fe"), "A.01.6", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("13a67a48-b117-4b53-ab6b-1dba88301774"), "A.01.61", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Support activities for crop production" },
                    { new Guid("072d9f7b-c06c-4a10-9e5c-f67e09842f21"), "A.01.62", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Support activities for animal production" },
                    { new Guid("2e2222b2-59a7-4641-8dec-3da24bf8d350"), "A.01.63", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Post-harvest crop activities" },
                    { new Guid("e9f83f1e-c141-48ff-b129-feb7ebf11927"), "A.01.64", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Seed processing for propagation" },
                    { new Guid("09ed6249-b0e9-45f2-9485-e4274b36726c"), "A.01.7", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Hunting, trapping and related service activities" },
                    { new Guid("0a602f56-cb30-448e-97d8-343f0b7f11c7"), "A.01.70", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Hunting, trapping and related service activities" },
                    { new Guid("4f34c90d-157b-434f-a8e5-7fa9c8f16200"), "A.02", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Forestry and logging" },
                    { new Guid("2c153f30-a553-431c-b028-114bbbfe4d24"), "A.02.1", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Silviculture and other forestry activities" },
                    { new Guid("6384700a-88e2-4ceb-b824-492bab1e6b3a"), "A.02.10", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Silviculture and other forestry activities" },
                    { new Guid("9ff83811-cc00-4d98-a3bc-cd17aee67dfd"), "A.02.2", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Logging" },
                    { new Guid("e2220b18-08e8-43cd-8b86-3294b8e486b3"), "A.02.20", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Logging" },
                    { new Guid("6d3d7c81-bca0-46ca-ad43-b6bdbb505d8f"), "A.01.50", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Mixed farming" },
                    { new Guid("967a2be0-792d-48aa-8d6b-43a82c1db263"), "A.02.3", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Gathering of wild growing non-wood products" },
                    { new Guid("b406bac8-e4e1-489f-a2b0-55e178b8a7d4"), "A.02.4", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Support services to forestry" },
                    { new Guid("7677ec5b-8bee-4f36-874c-4c141a695e38"), "A.02.40", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Support services to forestry" },
                    { new Guid("8d3cc32a-649d-43ff-8493-5d9e07b9926f"), "A.03", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Fishing and aquaculture" },
                    { new Guid("8ee62c3a-5be3-49e9-92dd-8fe2757e9a49"), "A.03.1", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Fishing" },
                    { new Guid("3f89ecab-b7b3-4818-9017-7bbf662610b6"), "A.03.11", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fd0ab249-ac49-4d36-987a-7753b57ec093"), "A.03.12", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Freshwater fishing" },
                    { new Guid("a9f09c25-7672-41a6-b07e-624105c85896"), "A.03.2", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Aquaculture" },
                    { new Guid("b6ce73a9-11a8-457a-87f9-222aaf460cff"), "A.03.21", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Marine aquaculture" },
                    { new Guid("053a5b61-9abd-40d7-9572-1a959e9ca865"), "A.03.22", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Freshwater aquaculture" },
                    { new Guid("ad5600f3-6c99-437e-8bae-b5ac965a53dd"), "B.05", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of coal and lignite" },
                    { new Guid("ac7f6f78-d746-4738-b854-9e86285f59b7"), "B.05.1", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of hard coal" },
                    { new Guid("18cac3d6-a744-411d-a1c6-059b138ebc44"), "B.05.10", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of hard coal" },
                    { new Guid("5a9f180e-ef8b-4cea-94e3-9910ff2df483"), "A.02.30", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Gathering of wild growing non-wood products" },
                    { new Guid("97d7202c-de37-494a-b9cd-83343ea448a0"), "A.01.5", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Mixed farming" },
                    { new Guid("d4bc0d07-1e6b-41a9-b3c9-20858ea8ed82"), "A.01.49", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of other animals" },
                    { new Guid("5d7e18e9-3722-4a63-b384-1bd85ce5f185"), "A.01.47", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of poultry" },
                    { new Guid("ae83b95b-281a-4074-8b13-36740670319c"), "A.01.1", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of non-perennial crops" },
                    { new Guid("2da42e28-0129-4f86-9c59-f82d7e4493d7"), "A.01.11", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("0cbfa1b8-1f8a-4c44-9fdf-7541523158a7"), "A.01.12", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of rice" },
                    { new Guid("a8bd438e-cbdf-4922-ac9d-c40a44c33619"), "A.01.13", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("ddd2b0fa-feb4-4d3d-b608-93e163c4c57e"), "A.01.14", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of sugar cane" },
                    { new Guid("58911ead-56c9-48fc-af00-ca0a9cfa8489"), "A.01.15", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of tobacco" },
                    { new Guid("05122e02-ae1d-42e8-907b-5dbe50640959"), "A.01.16", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of fibre crops" },
                    { new Guid("e669a3d2-185c-49d0-a1b0-65c219a7b725"), "A.01.19", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of other non-perennial crops" },
                    { new Guid("38c3eed1-46ac-4c5d-ac3c-6f4f70c4c381"), "A.01.2", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of perennial crops" },
                    { new Guid("a2f9a55e-d797-4830-bedf-0c400fafc887"), "A.01.21", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of grapes" },
                    { new Guid("7abc1d1b-7e26-4ae2-ad4f-2d3a0b603f4a"), "A.01.22", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of tropical and subtropical fruits" },
                    { new Guid("591dc2dd-2c4d-4507-b703-5dd070cba9f7"), "A.01.23", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of citrus fruits" },
                    { new Guid("cc49b7fd-704f-472c-be95-51237c31ead1"), "A.01.24", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of pome fruits and stone fruits" },
                    { new Guid("45fd04ea-e9be-43a3-84b6-e96a3700665c"), "A.01.25", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("124a4abe-7b2c-4b04-bca1-3212eb05795b"), "A.01.26", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of oleaginous fruits" },
                    { new Guid("eb9afd8b-024e-43e0-ba20-75926b6d2c91"), "A.01.27", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of beverage crops" },
                    { new Guid("32e6b96d-5248-4ca7-bb75-2e866463a6ee"), "A.01.28", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("c286ce95-5850-4fba-b185-5979d07d8de8"), "A.01.29", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Growing of other perennial crops" },
                    { new Guid("bc45a579-2a7f-423f-a567-28dffd5d9da3"), "A.01.3", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Plant propagation" },
                    { new Guid("82f4a5de-af86-4c1f-8b71-e210ed0e0d96"), "A.01.30", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Plant propagation" },
                    { new Guid("dc79bf47-1c84-4f4c-9896-3463cdf35bc5"), "A.01.4", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Animal production" },
                    { new Guid("9e307f99-05b6-4876-8059-e316aa787009"), "A.01.41", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of dairy cattle" },
                    { new Guid("6750a513-a08f-4dbd-8278-8ad1c99eef72"), "A.01.42", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of other cattle and buffaloes" },
                    { new Guid("d507d8d8-06be-47df-aece-3d9c0902d79f"), "A.01.43", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of horses and other equines" },
                    { new Guid("41fe1ee4-6588-4191-910e-e1ab228ff451"), "A.01.44", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of camels and camelids" },
                    { new Guid("ff64997e-5c68-4a22-9b9c-6e09c4117fe2"), "A.01.45", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of sheep and goats" },
                    { new Guid("8d7bf726-340e-4352-b79b-b626d2b53e1a"), "A.01.46", new Guid("10366b80-cee1-43b7-a8a6-3c10ccddca8e"), "Raising of swine/pigs" },
                    { new Guid("9d30c188-5c82-43f1-8f11-b9152ba349f6"), "B.05.2", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of lignite" },
                    { new Guid("dd7eb192-d403-4c7c-8414-78a6273cabe5"), "C.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of beverages" },
                    { new Guid("bcac29a8-aba4-4cc0-9992-121626dfa581"), "B.05.20", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of lignite" },
                    { new Guid("07845460-fc12-4e3a-8966-9a5a8fb247dd"), "B.06.1", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("10197f95-461e-4df9-9782-18343ccf2be6"), "C.10.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of potatoes" },
                    { new Guid("7bfe4b72-3e83-4c17-8903-5f35a2fce9e5"), "C.10.32", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("f89db33e-4bbd-47ba-96f5-a735b7f03492"), "C.10.39", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("9ed43fef-1f79-4694-8ad1-30036465623e"), "C.10.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("684bd421-acf8-4341-937c-7e69508f35f9"), "C.10.41", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of oils and fats" },
                    { new Guid("183addc5-6ddc-41b8-9418-66d36e3e519d"), "C.10.42", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("3bd145f6-9311-4c3a-acb8-1c5a7b5e98a1"), "C.10.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of dairy products" },
                    { new Guid("4f3df5f0-4fc4-43c1-a77b-924826c949f1"), "C.10.51", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Operation of dairies and cheese making" },
                    { new Guid("21663554-f49c-4c7e-baec-0c9398390552"), "C.10.52", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ice cream" },
                    { new Guid("955c0d92-1647-47b1-9248-529f5a708145"), "C.10.6", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("cb838cdc-e605-4d69-ab19-8644b51f254d"), "C.10.61", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of grain mill products" },
                    { new Guid("910e6569-0871-4164-8036-0122f1317f5e"), "C.10.62", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of starches and starch products" },
                    { new Guid("249e23b1-d05f-47cb-86ce-a9020d16ccb2"), "C.10.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("7e6fd841-251e-4816-9a3c-a6ea3c1b5307"), "C.10.7", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("8cbcd439-c76f-4495-abe1-4c5703b42387"), "C.10.72", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("5e5a454c-790c-4b95-897a-1979c8fbfc74"), "C.10.73", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("67ef321f-55d8-424d-8861-52c27fb058cb"), "C.10.8", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other food products" },
                    { new Guid("a86ecc47-3d70-4528-8481-cdd785acb693"), "C.10.81", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of sugar" },
                    { new Guid("b3ecd85c-4fec-4179-99ad-47fa76a0246f"), "C.10.82", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("4d5a12fe-9f7c-49da-a955-03260394f75c"), "C.10.83", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing of tea and coffee" },
                    { new Guid("7ce1c331-9d0b-4e17-ace2-2de816cc23eb"), "C.10.84", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of condiments and seasonings" },
                    { new Guid("cc2cef82-68dc-4925-8c25-8b8d93ad39c2"), "C.10.85", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of prepared meals and dishes" },
                    { new Guid("cd8e8376-ae0b-437f-8304-879da89f0819"), "C.10.86", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("b1eaa02d-a470-492c-84c5-7e581d350764"), "C.10.89", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other food products n.e.c." },
                    { new Guid("59055fb9-6cce-45b8-90b4-dc4d5c2de0ed"), "C.10.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of prepared animal feeds" },
                    { new Guid("6ee58e32-d58b-44b4-912e-a0dff865e574"), "C.10.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("123f453e-fbe2-4f0f-879f-3d75c2db47a7"), "C.10.71", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("05a65138-5fe8-4d56-80c1-3acd6ce4ee47"), "C.10.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("1777de30-4eaa-4e34-8937-b07a39809875"), "C.10.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("22302bf0-07e0-433c-8ede-0f24b8b1e846"), "C.10.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Production of meat and poultry meat products" },
                    { new Guid("0c30ad57-df67-4c22-b380-b8588030604f"), "B.06.10", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of crude petroleum" },
                    { new Guid("a18c2d96-88c5-4131-bff3-6f1ac43c80ae"), "B.06.2", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of natural gas" },
                    { new Guid("a33c457f-ff6a-4ae6-a28d-a3784c539976"), "B.06.20", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of natural gas" },
                    { new Guid("72f71191-7f3b-4cce-9b5d-eac7c8783a1b"), "B.07", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of metal ores" },
                    { new Guid("e32e87e4-6a7d-4c0e-8b64-6624e83a8cca"), "B.07.1", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of iron ores" },
                    { new Guid("b2321d07-bf47-4a72-828c-a19f378bfac2"), "B.07.10", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of iron ores" },
                    { new Guid("0c870242-1d14-4c01-8120-df852137e391"), "B.07.2", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of non-ferrous metal ores" },
                    { new Guid("176e94e6-feaf-48c0-a9a6-3d1c3db0a0da"), "B.07.21", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of uranium and thorium ores" },
                    { new Guid("87e025d3-df09-444c-a591-03b2e4f846bd"), "B.07.29", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of other non-ferrous metal ores" },
                    { new Guid("04da88ca-b438-4d87-a2e8-a9f52af21a23"), "B.08", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Other mining and quarrying" },
                    { new Guid("3066daa0-b2f1-4eb5-a1fa-c4c0a923b8ad"), "B.08.1", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Quarrying of stone, sand and clay" },
                    { new Guid("26a62cfd-f7bb-41b7-8e29-05efaca1e1f4"), "B.08.11", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3ca7732b-bd9a-496b-9846-14af6cacd9a5"), "B.08.12", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("ebdeeabd-a536-45e2-9365-e96a2c83f094"), "B.08.9", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining and quarrying n.e.c." },
                    { new Guid("ca3045f6-1049-4147-be3c-a57a55082df8"), "B.08.91", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("bd93ae90-e081-4573-9772-c20d5f505f35"), "B.08.92", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of peat" },
                    { new Guid("264eee44-ad49-47d6-85f6-f2268af115ae"), "B.08.93", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of salt" },
                    { new Guid("a3186b0a-e685-4f07-8348-9acefbf68147"), "B.08.99", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Other mining and quarrying n.e.c." },
                    { new Guid("70bdb706-384a-4918-bb47-dfc2a13d61e3"), "B.09", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Mining support service activities" },
                    { new Guid("56b73d47-f041-490c-905d-bf30f4599bde"), "B.09.1", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("4b108ae4-0cce-498a-ad51-87156d419138"), "B.09.10", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("0da6dcf3-6dfb-4d3c-91d6-b202eec1f61d"), "B.09.9", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Support activities for other mining and quarrying" },
                    { new Guid("9bd819b6-b059-4be7-93cf-e24228f860ad"), "B.09.90", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Support activities for other mining and quarrying" },
                    { new Guid("0a2c92fa-aee3-468a-8771-27b20d1317b0"), "C.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of food products" },
                    { new Guid("603ce9ea-f51e-443f-ac5d-6085ed4ef06a"), "C.10.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("1f93b9bc-2648-4d58-8781-2a925df5a4c0"), "C.10.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of meat" },
                    { new Guid("983c32ab-559a-4965-95c6-76750542175e"), "C.10.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing and preserving of poultry meat" },
                    { new Guid("ad013e3e-c6e2-4113-aee1-fce618d2ed34"), "B.06", new Guid("19380a69-4d57-4d8b-8788-8eff66b28828"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("3cce3eb3-6be8-44d2-875b-8851422cdc23"), "F.43.2", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("e3a12753-097f-428b-8c94-2c28881f92f9"), "C.23.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of refractory products" },
                    { new Guid("3754e5cc-28b8-4a76-b91a-e1e6e42381bf"), "C.23.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("8114c001-9b5d-481d-8348-cd24a1c70d53"), "C.30.92", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("33c8a058-5158-44ea-85c6-ba61a8623e80"), "C.30.99", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("2f8fde39-85e5-45f2-8089-8d32f8fd0085"), "C.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of furniture" },
                    { new Guid("84240a39-ea5b-48b2-bf99-ef13a1dc5664"), "C.31.0", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of furniture" },
                    { new Guid("a5410876-f98d-4f65-b279-9e9f2e98ec7f"), "C.31.01", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of office and shop furniture" },
                    { new Guid("b5202748-6810-4b35-a4d5-1283d9968778"), "C.31.02", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of kitchen furniture" },
                    { new Guid("3bc1b1ff-8a1e-4501-b0e6-81d7623b935c"), "C.31.03", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of mattresses" },
                    { new Guid("57776db1-4208-4a83-9126-815a34261362"), "C.31.09", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other furniture" },
                    { new Guid("5d21fc4d-2c54-4301-ba2e-f9e05662b52e"), "C.32", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Other manufacturing" },
                    { new Guid("fd20a271-a6a7-4d6e-9cd0-9a9a421fd3e4"), "C.32.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("26e1bb86-28c2-424a-a06a-23b7a8c87444"), "C.32.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Striking of coins" },
                    { new Guid("3c47ae5b-becb-4ba6-a122-75f0fe7d18f8"), "C.32.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of jewellery and related articles" },
                    { new Guid("f4b0e365-c7fc-44eb-a24a-d41d5688d35f"), "C.30.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of motorcycles" },
                    { new Guid("99c1ebcb-e08a-4116-a793-ed5df7f61f88"), "C.32.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("7307acf5-6f21-46d0-93ed-5c57199d2de4"), "C.32.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of musical instruments" },
                    { new Guid("0977bc6e-9c35-40ca-83a4-d4e73829fb19"), "C.32.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of sports goods" },
                    { new Guid("c333a262-ce8a-4ccf-969f-b41a4d1d81d3"), "C.32.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of sports goods" },
                    { new Guid("a00f3714-a153-4ac7-af30-36ca146f61d9"), "C.32.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of games and toys" },
                    { new Guid("5a2b331a-e50f-4726-bd35-412e63197fa9"), "C.32.40", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of games and toys" },
                    { new Guid("4aed7f96-2d13-4cbc-989d-4ce09c35479b"), "C.32.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("b3de11bd-db98-45b1-8cfc-59a338b84b50"), "C.32.50", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("2ac8cec0-f5e1-4d43-a73b-77b98b9cd585"), "C.32.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacturing n.e.c." },
                    { new Guid("368c6251-fc5a-4c9b-bee4-a05429ef1190"), "C.32.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("825a5e30-8ef9-49b4-8b40-3454414db0f9"), "C.32.99", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Other manufacturing n.e.c." },
                    { new Guid("0e7f09c8-4e6d-4e23-a0b9-a2a852353e07"), "C.33", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair and installation of machinery and equipment" },
                    { new Guid("cdc47175-d7c8-49ba-9e43-746d3119c29f"), "C.33.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("b08dc241-3967-4c3d-8df2-e81ed0cd8719"), "C.32.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of musical instruments" },
                    { new Guid("aaa9f1d6-0306-491d-9815-233ab80d8565"), "C.30.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("e49922e2-b813-4e2a-88ca-45477768beb7"), "C.30.40", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of military fighting vehicles" },
                    { new Guid("a721bca0-4179-4be8-bcfa-c9a1da9edf6e"), "C.30.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of military fighting vehicles" },
                    { new Guid("2cb782ea-1244-46e7-9c6c-66cb226c0093"), "C.28.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("e0dbaddf-9d7d-45e8-8629-340d0ba9b93b"), "C.28.41", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of metal forming machinery" },
                    { new Guid("ec0dcd8b-7f5e-4872-b11c-6cee08b4c0b3"), "C.28.49", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other machine tools" },
                    { new Guid("980d407a-46c8-4c23-a1f2-aae3a48f0c83"), "C.28.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other special-purpose machinery" },
                    { new Guid("949512ce-31ba-4362-879b-50db550928d6"), "C.28.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of machinery for metallurgy" },
                    { new Guid("f6e04531-6354-4c3c-9c7a-4924d2dc7065"), "C.28.92", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("0cea959b-5cf5-4eb6-b086-74e672141ece"), "C.28.93", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("4493e681-da0b-419f-970d-b2fb5c00e390"), "C.28.94", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("d99db4d8-6afd-421f-808d-7de1f02f2eaf"), "C.28.95", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("9dc78b4b-9634-45a3-8a93-7b67d62089be"), "C.28.96", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("d621d53c-58d6-426c-8486-4cb944ccfe5f"), "C.28.99", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("1ff37af5-5dd6-4f2d-8608-b3cc75ebbb06"), "C.29", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("f9585cb5-1e91-43c7-be16-ff2c0e934513"), "C.29.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of motor vehicles" },
                    { new Guid("1cc21476-95ca-4abf-a985-9f0daa32fb10"), "C.29.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of motor vehicles" },
                    { new Guid("1609d491-3cf7-4686-b25c-b9d8305a1402"), "C.29.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("a3ec3ed8-dd82-4199-a4da-011fb4af6c59"), "C.29.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("a79cb238-3412-43ef-9bad-e71bb351d4ed"), "C.29.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("6285c640-4116-4fc8-be93-ebf78d0e6f9d"), "C.29.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("711df561-c670-4a78-8bea-7a48aa1ef0cc"), "C.29.32", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("f5c48565-cb37-4298-87a3-46ac8791f8df"), "C.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other transport equipment" },
                    { new Guid("643b4084-4b2c-4534-8e65-1792d3bc9c00"), "C.30.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Building of ships and boats" },
                    { new Guid("5e4abf54-5a6a-477f-b97e-4cbff2b746bb"), "C.30.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Building of ships and floating structures" },
                    { new Guid("fc5f8156-ab5d-4b84-84a6-ab2fc2490626"), "C.30.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Building of pleasure and sporting boats" },
                    { new Guid("8cc3b1b8-4abf-4b12-a110-853b92a7261f"), "C.30.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("e2055588-261d-4957-a6c5-95d91d34b5d0"), "C.30.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("6f94e30f-f038-4d56-8b56-14a80a5c9f3d"), "C.30.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("8772f52f-6b78-40e3-8870-616b366747b7"), "C.30.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("7b28b51d-8c77-4e30-b74a-30b6459f6b94"), "C.33.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair of fabricated metal products" },
                    { new Guid("b05b18ce-ce7b-4332-a28c-adcec45d760e"), "C.28.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("2cd06fbf-8d73-4934-92f3-6ce49a189f51"), "C.33.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair of machinery" },
                    { new Guid("ea476116-681e-443b-aa36-1e3750a84b42"), "C.33.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair of electrical equipment" },
                    { new Guid("fcb52eba-5c9f-4102-8339-6d6c16134b5b"), "E.38.3", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Materials recovery" },
                    { new Guid("2c6374fe-2a8e-4ba6-9ac4-18890fcb00cb"), "E.38.31", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Dismantling of wrecks" },
                    { new Guid("9bbc237a-864b-4a6e-809e-81a08919e7f0"), "E.38.32", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Recovery of sorted materials" },
                    { new Guid("5c45aefa-6698-4035-a3cd-7e8d4ab38749"), "E.39", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a6fa8620-53aa-4e06-9180-60be54cd4f43"), "E.39.0", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Remediation activities and other waste management services" },
                    { new Guid("b41fee59-12d6-4947-900d-f00d3aff590d"), "E.39.00", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Remediation activities and other waste management services" },
                    { new Guid("625be086-c6f0-44c5-81e8-eac2f5c00cf5"), "F.41", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of buildings" },
                    { new Guid("f8919248-b0c1-4b1c-a2de-9745a80f474c"), "F.41.1", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Development of building projects" },
                    { new Guid("55391f31-70e4-4174-9258-dd1f54b9eb84"), "F.41.10", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Development of building projects" },
                    { new Guid("1cabe975-7f3b-444c-88ee-0d9e31e3c6a5"), "F.41.2", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of residential and non-residential buildings" },
                    { new Guid("fad74be1-5326-405c-b994-bffd08bcb4de"), "F.41.20", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of residential and non-residential buildings" },
                    { new Guid("6f80a63f-211a-41f3-afe8-302bfe4b4910"), "F.42", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Civil engineering" },
                    { new Guid("6017cdde-69f3-472e-854e-66337c172314"), "E.38.22", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Treatment and disposal of hazardous waste" },
                    { new Guid("b829bb69-8c63-4a95-b553-c7ddd32c814d"), "F.42.1", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of roads and railways" },
                    { new Guid("b84bcfd1-b03a-4ad9-a082-7e2d7558cd66"), "F.42.12", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of railways and underground railways" },
                    { new Guid("b40d0549-c45c-47f3-be2b-986c327f66b5"), "F.42.13", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of bridges and tunnels" },
                    { new Guid("5cbfb565-547d-4f08-ade5-a38b7e36b26f"), "F.42.2", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of utility projects" },
                    { new Guid("816042cb-9e46-48d3-845d-3c9040788d87"), "F.42.21", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of utility projects for fluids" },
                    { new Guid("3662aafa-d4ca-4185-8e4d-e4ca9527f4af"), "F.42.22", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("bc1dee65-de27-4d5a-807b-b28430801027"), "F.42.9", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of other civil engineering projects" },
                    { new Guid("ed133ae4-e553-4ad8-9722-55936c428436"), "F.42.91", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of water projects" },
                    { new Guid("ecd24bb4-b60d-41aa-a373-d9148e66cb79"), "F.42.99", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("99fdad63-1935-4cf7-953e-9e02fba1dbd7"), "F.43", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Specialised construction activities" },
                    { new Guid("826d62ab-8d30-4747-9d04-ec81186e0853"), "F.43.1", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Demolition and site preparation" },
                    { new Guid("17e5c304-132d-49e0-88ec-b5aa0af0b7da"), "F.43.11", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Demolition" },
                    { new Guid("3c9e951c-eb6f-4692-8ebe-e63017dd760a"), "F.43.12", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Site preparation" },
                    { new Guid("a8f39757-c5e2-4a68-9adc-b01e3d3e1e32"), "F.42.11", new Guid("718e866e-ff3a-48ea-ade5-9420e042ee84"), "Construction of roads and motorways" },
                    { new Guid("61897b44-286b-4875-b164-46ba9a526db8"), "E.38.21", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("411ddeda-3b96-4fab-b445-1f47af2c017c"), "E.38.2", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Waste treatment and disposal" },
                    { new Guid("ed35288f-87a2-445d-a9fb-10fc8bb761ff"), "E.38.12", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Collection of hazardous waste" },
                    { new Guid("4756af73-9b75-451f-9675-63d0bba957b1"), "C.33.15", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair and maintenance of ships and boats" },
                    { new Guid("c2c26a38-97ab-4665-9d14-008ccd435c91"), "C.33.16", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("3b682276-83c9-4eff-a926-29dbacb5b5c6"), "C.33.17", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair and maintenance of other transport equipment" },
                    { new Guid("f29a292a-08f3-48f0-9c4d-dddd8938a402"), "C.33.19", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair of other equipment" },
                    { new Guid("528e87af-8014-41a3-b7b5-96d9097777d9"), "C.33.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Installation of industrial machinery and equipment" },
                    { new Guid("229f0854-b10c-48b4-863b-6a195d62c63c"), "C.33.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Installation of industrial machinery and equipment" },
                    { new Guid("4decb1ac-1684-45e7-ad89-5449e5011264"), "D.35", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("266f73b1-84d7-4a7d-a07e-600c5eca0991"), "D.35.1", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Electric power generation, transmission and distribution" },
                    { new Guid("45146ea4-dc86-4b7a-8fd2-e197a1497011"), "D.35.11", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Production of electricity" },
                    { new Guid("2f48bb0d-224e-4d5f-9fb1-bdc7b8d17928"), "D.35.12", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Transmission of electricity" },
                    { new Guid("a2cce54d-37b7-4715-b5ae-6766e782dcdf"), "D.35.13", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Distribution of electricity" },
                    { new Guid("3d70a372-f358-497e-8fa2-5b21b97ab231"), "D.35.14", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Trade of electricity" },
                    { new Guid("15a0965c-a944-45b8-9570-333e5c224354"), "D.35.2", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("b40098a8-69a6-4d40-97b6-0d5fb15c3e1a"), "D.35.21", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Manufacture of gas" },
                    { new Guid("8886b7fe-5623-4eda-b37c-65792245dc35"), "D.35.22", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Distribution of gaseous fuels through mains" },
                    { new Guid("14ac3c5c-54a6-4047-9c41-6da8bfbf61b5"), "D.35.23", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("51927daf-567f-4a5f-9b95-3f8286770135"), "D.35.3", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Steam and air conditioning supply" },
                    { new Guid("010f0439-13c3-4ca8-aac5-3d3e37f753c4"), "D.35.30", new Guid("6a63259a-6069-4810-9a88-7dd6a5b11b21"), "Steam and air conditioning supply" },
                    { new Guid("5a286c41-90e8-4598-898b-1265338cb38a"), "E.36", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Water collection, treatment and supply" },
                    { new Guid("e577024c-0a98-43bf-af65-da4a26546bd4"), "E.36.0", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Water collection, treatment and supply" },
                    { new Guid("85e30582-c2be-4cb2-92f3-21d7ccedd34c"), "E.36.00", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Water collection, treatment and supply" },
                    { new Guid("59de6103-65fd-4df4-a35e-5a3517a73b3f"), "E.37", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Sewerage" },
                    { new Guid("58b32704-beb4-4524-a2f7-a3cfecad1e9d"), "E.37.0", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Sewerage" },
                    { new Guid("5629e0b1-8b1a-40ca-89d0-199e191d628f"), "E.37.00", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Sewerage" },
                    { new Guid("24da2882-5d78-47c8-b5c5-cee76625ed49"), "E.38", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("318d1604-6032-4020-999f-50479f7e0e17"), "E.38.1", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Waste collection" },
                    { new Guid("3c0763c4-9d7b-4e1c-a7d4-3910fb054a87"), "E.38.11", new Guid("48cfbca2-fb45-4720-b6b5-010f9f7e55b5"), "Collection of non-hazardous waste" },
                    { new Guid("68e192bd-fbc0-4ff5-bb41-bee58c463e9b"), "C.33.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Repair of electronic and optical equipment" },
                    { new Guid("22148134-7e3c-4c9b-9d26-cb1ea73ca6d5"), "C.23.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of clay building materials" },
                    { new Guid("3eb9d829-9c93-4802-81e9-006fab41d681"), "C.28.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("af68078c-f620-4b12-91ab-89d79c2c742b"), "C.28.25", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("738fc5f6-5d64-4ac1-978e-6af5070c2fb9"), "C.24.34", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Cold drawing of wire" },
                    { new Guid("229dcddd-8bf8-46ee-850f-499c9e39c4bd"), "C.24.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("03bb47e0-5099-4a58-97b2-e0fe99365ac9"), "C.24.41", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Precious metals production" },
                    { new Guid("b1a22482-3b97-4a27-b9c1-0b6430af037b"), "C.24.42", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Aluminium production" },
                    { new Guid("f745173c-4c2e-4bd5-bfa4-e585817d0bbf"), "C.24.43", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Lead, zinc and tin production" },
                    { new Guid("f23a1056-c6f6-49ef-bf37-3930fdd2f146"), "C.24.44", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Copper production" },
                    { new Guid("72b6f5c7-2ce5-4be3-98a7-59031ada6636"), "C.24.45", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Other non-ferrous metal production" },
                    { new Guid("f9c5105b-4a9a-4e1b-b4e9-ea62307e4b15"), "C.24.46", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Processing of nuclear fuel" },
                    { new Guid("bb8eee1e-ebe1-49af-b34d-5b070634fbfb"), "C.24.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Casting of metals" },
                    { new Guid("ddc8efc9-1eac-4230-b628-373a30c971e0"), "C.24.51", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Casting of iron" },
                    { new Guid("4c9c3433-36bc-46da-8d0b-61acb68e9c6b"), "C.24.52", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Casting of steel" },
                    { new Guid("b5ae1652-5fd4-4aaa-b8e2-f4971609387a"), "C.24.53", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Casting of light metals" },
                    { new Guid("5d6ef6ba-b241-4f36-a35d-9651445eb477"), "C.24.33", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Cold forming or folding" },
                    { new Guid("19b43a96-999e-4ea7-8b54-35adc62da62d"), "C.24.54", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Casting of other non-ferrous metals" },
                    { new Guid("4c6e9c4f-3c45-4fcd-a6ce-bfddf7d9e4cc"), "C.25.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of structural metal products" },
                    { new Guid("07e8ba50-87e0-44b5-9a4f-d11265e014b1"), "C.25.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("21715592-4922-46cb-905b-61d28f5dcb8e"), "C.25.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of doors and windows of metal" },
                    { new Guid("f8698008-61e2-485b-a68f-2269c90b9c8c"), "C.25.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("8d4eac3c-8a66-46db-aefb-ce90dc5c19be"), "C.25.21", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("d90386dc-ecb0-4dd8-921e-1e42e0c21f84"), "C.25.29", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("6e42e7e3-9d6d-4ef7-8042-d33232aef20f"), "C.25.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("854a5670-6f8e-48eb-a68f-ad67f28e5790"), "C.25.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("c16f9803-6f2b-4577-a785-daa84aac3b2f"), "C.25.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of weapons and ammunition" },
                    { new Guid("efdbb6d8-6db4-45de-ad12-447a0fe0b692"), "C.25.40", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of weapons and ammunition" },
                    { new Guid("2a35e9cb-0d09-451b-9b75-53f8156257c9"), "C.25.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("3fb7b284-89a2-4161-bac1-86d7014826c9"), "C.25.50", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("0d226b9d-48f0-48ae-9452-7baac16f7c80"), "C.25", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("8c4888f1-7c88-418e-bebb-763efb15e129"), "C.24.32", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Cold rolling of narrow strip" },
                    { new Guid("7a52c737-1ae3-4bf9-9247-a0fd737120c5"), "C.24.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Cold drawing of bars" },
                    { new Guid("e8699ed1-ef90-4335-b781-579615b92bcc"), "C.24.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other products of first processing of steel" },
                    { new Guid("22e4db4b-e4d9-4f05-8cc7-9adadce85ec0"), "C.23.32", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("d9978d71-47ab-4443-8246-42b34b802ae9"), "C.23.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("6e226659-f41e-4463-8e98-009250e848a7"), "C.23.41", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("805e998b-aecd-4d75-b505-b977500fe28f"), "C.23.42", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("a539a513-ac44-48f4-afd2-c59941650d9d"), "C.23.43", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("12629691-a4eb-4aa5-b306-4c52e7f4454f"), "C.23.44", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other technical ceramic products" },
                    { new Guid("9a79b50f-ede6-4517-b892-9dc330709ddc"), "C.23.49", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other ceramic products" },
                    { new Guid("c00397f5-3374-464d-8304-cd978bea8ce8"), "C.23.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cement, lime and plaster" },
                    { new Guid("2320b98e-fbe6-40b1-aabe-d91f875f3656"), "C.23.51", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cement" },
                    { new Guid("9986fd27-40df-4d4f-a850-84f61c096411"), "C.23.52", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of lime and plaster" },
                    { new Guid("59433ec5-84df-4535-b080-ff46612b1dea"), "C.23.6", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("09c2caf4-34c3-49e3-ba32-69c7ece77ebc"), "C.23.61", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("e3a90381-1463-46e5-a863-e550d9b66f96"), "C.23.62", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("ee3c417d-0ce0-4071-810e-3e3e2841e94c"), "C.23.63", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ready-mixed concrete" },
                    { new Guid("755edfc4-59c7-487d-ad3a-7d0f8348f8e3"), "C.23.64", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of mortars" },
                    { new Guid("093fae08-67ad-4638-b926-2a48575f5e01"), "C.23.65", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fibre cement" },
                    { new Guid("004854f3-027b-4ab1-a163-56cb13da4e94"), "C.23.69", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("8264d4a0-9246-4b4a-af70-ead630f7f0ea"), "C.23.7", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Cutting, shaping and finishing of stone" },
                    { new Guid("1a51f95b-f176-4827-be4b-1a1c0c08b65e"), "C.23.70", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Cutting, shaping and finishing of stone" },
                    { new Guid("f04fb110-462e-435d-8017-2665a14b8907"), "C.23.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("6ce9a0c2-06f7-41e7-875c-1e4720666903"), "C.23.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Production of abrasive products" },
                    { new Guid("4dca1dd8-417a-4073-8fb0-666af5d316d1"), "C.23.99", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("d0b35925-0b13-4cb0-96ed-350e725404da"), "C.24", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic metals" },
                    { new Guid("de1268a0-1a48-4daf-a96e-3151629c1647"), "C.24.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("3b6c123f-1263-4f69-bd9b-75f4470cca6b"), "C.24.10", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("b711426d-a1d8-4edf-a1f5-e4f4bcdb661f"), "C.24.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("de7f9ba6-cfcf-493b-bb97-b98754491265"), "C.24.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("a424c48c-7508-497b-98a4-dc71eaccf157"), "C.25.6", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Treatment and coating of metals; machining" },
                    { new Guid("e745b64a-6d36-4d77-b56a-24f2b135cb51"), "C.28.29", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("161afabe-7d35-47b3-a6bf-9274d1383300"), "C.25.61", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Treatment and coating of metals" },
                    { new Guid("346efdaa-542a-4392-8b18-335bf5063852"), "C.25.7", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("a9cb8775-dce0-4b53-9700-4b18fc861749"), "C.27.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("79748c60-0fec-49f0-90a7-25ef38f27a72"), "C.27.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of batteries and accumulators" },
                    { new Guid("e1914e17-5e03-45d9-9d68-2a2428766e36"), "C.27.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of batteries and accumulators" },
                    { new Guid("e9b73b41-93cd-479c-8899-23bdbc81fa92"), "C.27.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wiring and wiring devices" },
                    { new Guid("ddbae2d5-c6b9-497d-a275-4ec9948083f5"), "C.27.31", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fibre optic cables" },
                    { new Guid("98385a66-ad01-4703-804c-07adf6ad05ae"), "C.27.32", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("ef19c515-e2ea-4f34-bad0-5a2d3b52ea81"), "C.27.33", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wiring devices" },
                    { new Guid("72511e2a-4f1e-43cc-ad41-2c7a5174f2f8"), "C.27.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2c7b6e04-4e99-4e82-beda-661ad9f3e2e4"), "C.27.40", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electric lighting equipment" },
                    { new Guid("6350033a-82d6-485e-ab58-e66f69f2bb4f"), "C.27.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of domestic appliances" },
                    { new Guid("b19bcb30-db4d-43dd-aa6b-7687046fc387"), "C.27.51", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electric domestic appliances" },
                    { new Guid("182f7951-b2a1-463d-af26-7128a27c004b"), "C.27.52", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("267413fa-e39c-4c2b-957f-735e7ad0eb4a"), "C.27.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("fd6e0b5b-fc84-4cdf-83f7-47870545a0ad"), "C.27.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other electrical equipment" },
                    { new Guid("bfc21ae2-a127-4c5f-ad67-640ab5a2cb3f"), "C.28", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("b8fa17a6-048d-4888-a858-2358c9d5a4a6"), "C.28.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of general-purpose machinery" },
                    { new Guid("1d5c21cc-5d95-41a6-9f01-4d5af62cd278"), "C.28.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("57756c00-b487-47f3-8fc6-4d695967188b"), "C.28.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fluid power equipment" },
                    { new Guid("49054d77-d5ee-4fb3-927e-c8ca73c29523"), "C.28.13", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other pumps and compressors" },
                    { new Guid("161db7d3-ae54-4564-a0ca-a9874ad38d03"), "C.28.14", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other taps and valves" },
                    { new Guid("7d8863e6-199f-488b-bd98-cf8d23ad4277"), "C.28.15", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("d3e0ca61-316d-4a9d-acb6-83a8a75e0c76"), "C.28.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other general-purpose machinery" },
                    { new Guid("4ffca4ac-1815-46fa-b1db-ffd0a226f569"), "C.28.21", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("4ae8bf2a-af59-471e-b4a8-5107b350251b"), "C.28.22", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of lifting and handling equipment" },
                    { new Guid("bc19e526-eff5-4235-8d92-be3c11c61608"), "C.28.23", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("5cdf361f-76a2-4686-a8c4-5f59b444b890"), "C.28.24", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of power-driven hand tools" },
                    { new Guid("2b5c1bca-cef3-4ca0-bbfa-6243afaf1c94"), "C.27.90", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other electrical equipment" },
                    { new Guid("60c7c0cb-f0e6-4310-97be-1572b2ccd2ea"), "C.27.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("ca6a4b5b-eb45-4552-a4fb-9766ce8959d4"), "C.27", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electrical equipment" },
                    { new Guid("16394d15-b71b-4b91-9ffb-194a81763082"), "C.26.80", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of magnetic and optical media" },
                    { new Guid("62d7e384-674e-4122-94d4-64cef84e3385"), "C.25.71", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of cutlery" },
                    { new Guid("633b831b-7f18-4f5e-bbc5-74842ed2602d"), "C.25.72", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of locks and hinges" },
                    { new Guid("9135557d-86b9-49a7-9ec3-e4c36661c59a"), "C.25.73", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of tools" },
                    { new Guid("b328946c-2470-49b9-9234-040a546381d6"), "C.25.9", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other fabricated metal products" },
                    { new Guid("5a426204-498a-4e8b-9c2d-d68d0907abf2"), "C.25.91", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of steel drums and similar containers" },
                    { new Guid("24bdfc83-defe-4f28-8409-a9a434ef14ed"), "C.25.92", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of light metal packaging" },
                    { new Guid("0ac0ebc6-d640-4cf4-8bc7-cd4520cce8d7"), "C.25.93", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of wire products, chain and springs" },
                    { new Guid("6ce14882-a29f-46a4-a3f8-73223c9e945b"), "C.25.94", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("378503b5-4bfb-4795-825d-9ebde5389a5a"), "C.25.99", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("70d56c90-4414-46f9-b2a5-4ad4db882fba"), "C.26", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("fb0494bb-bbf5-4e61-ad23-db8708e20379"), "C.26.1", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electronic components and boards" },
                    { new Guid("17ad590e-4b2f-4472-a0a5-c7a09c9d4e5f"), "C.26.11", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of electronic components" },
                    { new Guid("0a12af69-31a1-4716-a314-3ea1e6d8de22"), "C.26.12", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of loaded electronic boards" },
                    { new Guid("ae80c34e-36b8-4580-916b-82091ff91788"), "C.26.2", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("e7beff0c-fb9a-443b-a54e-a79365e4b5dc"), "C.26.20", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("7ecb27ed-588f-4088-8111-9a30108591e2"), "C.26.3", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of communication equipment" },
                    { new Guid("90987283-6edb-418f-a08a-b1398189b055"), "C.26.30", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of communication equipment" },
                    { new Guid("572dccf6-0128-4e4b-9ec3-13c6ce8f3c8d"), "C.26.4", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of consumer electronics" },
                    { new Guid("19ceaf66-7b26-4992-9311-216b9712aadf"), "C.26.40", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of consumer electronics" },
                    { new Guid("750b3607-27ae-4c47-aac6-f7a88c551bbb"), "C.26.5", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c9acd3ca-75cb-48a1-97a1-18f3315b4c1f"), "C.26.51", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("c70b653b-4e4a-438a-be5e-00e61064180c"), "C.26.52", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of watches and clocks" },
                    { new Guid("012c4fc4-46d1-49ba-94be-644010fb19a5"), "C.26.6", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("bbf2ab9c-bfef-43f1-a609-99045320d543"), "C.26.60", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("ac6925ab-8704-486a-ad94-b0624fcd5fe9"), "C.26.7", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("316894f5-f725-4e24-864a-3ef9ce624fd0"), "C.26.70", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("0876ba0e-4b84-4603-bb8c-c3dfc46dd274"), "C.26.8", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Manufacture of magnetic and optical media" },
                    { new Guid("d28f68be-5d58-4de7-b2cd-6f751d5c3eaa"), "C.25.62", new Guid("17facfb2-42cc-4faf-9c54-9e960d545f24"), "Machining" },
                    { new Guid("66aa3553-0009-4f3a-bcaf-ebe57b865150"), "U.99.00", new Guid("07fdd34d-52f1-44bb-a87c-e15ca4240ab9"), "Activities of extraterritorial organisations and bodies" }
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
