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
                name: "Plan_SpecificAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    AttrVal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderValue = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_SpecificAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_SpecificAttributes_BusinessPlans_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlans",
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
                    { new Guid("f4082366-511e-4d8b-8f77-d64c1728a979"), "AT", "Austria" },
                    { new Guid("ddaa634c-0c0f-4c03-a0c5-895435955ce5"), "LU", "Luxembourg" },
                    { new Guid("91122cca-d3f2-400d-8197-6dfa80a7e240"), "MT", "Malta" },
                    { new Guid("e5fb4c03-36ef-441a-bcaa-86f90f674575"), "MK", "North Macedonia" },
                    { new Guid("d643e587-a143-4859-81b2-d2cb35354c52"), "NO", "Norway" },
                    { new Guid("3999cb83-8d9b-4e8b-aad1-3d3db2264472"), "PL", "Poland" },
                    { new Guid("6177a542-5a54-4099-a9cd-5f2fb2c1cb45"), "PT", "Portugal" },
                    { new Guid("b918b558-5128-449d-ab30-4245b9f605ff"), "RO", "Romania" },
                    { new Guid("4bd7c7d4-bab6-423e-89fa-00c4021ae893"), "RS", "Serbia" },
                    { new Guid("2b3d4d1d-014d-4655-b51e-ebc747945c8b"), "SK", "Slovakia" },
                    { new Guid("f9c19056-aaea-458e-b250-e1c0e5641de5"), "SI", "Slovenia" },
                    { new Guid("3ef65468-2f24-4680-8a72-ebe0ae8ce0b4"), "ES", "Spain" },
                    { new Guid("f92aa342-cb89-4de6-a69f-8bae78128906"), "SE", "Sweden" },
                    { new Guid("f3a8b434-3971-492f-97c8-2ec85f83b7e9"), "CH", "Switzerland" },
                    { new Guid("4c8e85ba-f9d4-41b9-896e-969054c85f48"), "TR", "Turkey" },
                    { new Guid("0f61c83d-3e0e-4846-979a-194be3a24c2b"), "UK", "United Kingdom" },
                    { new Guid("a5a91e58-6da6-4baa-ac0e-46f5ff0d5bdd"), "LT", "Lithuania" },
                    { new Guid("aa4c1039-4f32-4101-b572-df1da81b99c2"), "LI", "Liechtenstein" },
                    { new Guid("3d593ae2-ace2-4b57-8ae2-cceb792a4929"), "NL", "Netherlands" },
                    { new Guid("1b36521b-5b9a-40a2-b3e5-525d9af80faf"), "IT", "Italy" },
                    { new Guid("5f138750-a556-4ca9-98e0-794d4d40c3a0"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("a197f2d2-f930-4468-9a5e-01fd1ca23ca7"), "BE", "Belgium" },
                    { new Guid("e87187bb-860e-48c4-bf6b-40a22b475802"), "BG", "Bulgaria" },
                    { new Guid("d10459e6-900f-4583-afe6-9186aec6f5d8"), "LV", "Latvia" },
                    { new Guid("992dad00-ca8f-4413-b14b-45f819229278"), "CY", "Cyprus" },
                    { new Guid("db9590e0-9f5d-4beb-aae7-23e02b9dc699"), "CZ", "Czechia" },
                    { new Guid("ec4a0e91-08b3-40d1-a362-2d777e27b171"), "DK", "Denmark" },
                    { new Guid("1ebad670-521c-4c77-bb88-73e8b2104f1c"), "EE", "Estonia" },
                    { new Guid("149cd0d4-0a8b-43f3-9b5c-e4f0f5274c2d"), "HR", "Croatia" },
                    { new Guid("d289c4a4-2a9c-430c-8430-b032b946e13a"), "FR", "France" },
                    { new Guid("63c4e678-c73e-4ecb-839c-978d121ba52e"), "DE", "Germany" },
                    { new Guid("3ed2e5e5-de7b-470c-93c8-085ef7d97154"), "EL", "Greece" },
                    { new Guid("808f9c88-a185-4f50-ba73-94085d21c77f"), "HU", "Hungary" },
                    { new Guid("bbedfcec-e1e6-40f5-a4c3-033185f8d671"), "IS", "Iceland" },
                    { new Guid("24097ab0-f552-47c8-8820-714659345ee2"), "IE", "Ireland" },
                    { new Guid("bd18c693-81a0-4002-8bb4-a73ec3ae2f8a"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "P", "EN", "Education" },
                    { new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("7a4af031-9636-4228-8ad9-d1a49a7c9e17"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "L", "EN", "Real estate activities" },
                    { new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "J", "EN", "Information and communication" },
                    { new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "B", "EN", "Mining and quarrying" },
                    { new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "H", "EN", "Transporting and storage" },
                    { new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "F", "EN", "Construction" },
                    { new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "C", "EN", "Manufacturing" },
                    { new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("8d65ff55-0cee-4186-95ae-619cf432f7d8"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("6b71323d-dcee-432c-8c5d-8cd2b795424b"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("6263adcf-2be3-4a10-9f07-5a3bfc8ca998"), (short)23, null, new Guid("6b71323d-dcee-432c-8c5d-8cd2b795424b"), (short)1, "Manufacturing building" },
                    { new Guid("7e606932-684f-49ee-b5b4-37c754e23b8c"), (short)23, null, new Guid("d07c0ee9-38f6-4bdd-b4f2-d807342c9c4d"), (short)4, "Marketing" },
                    { new Guid("4896eedb-e333-4b7b-98b4-044deb78283a"), (short)23, null, new Guid("6b71323d-dcee-432c-8c5d-8cd2b795424b"), (short)3, "Equipment" },
                    { new Guid("f6062788-bccc-4360-ab86-316cfc43b80a"), (short)23, null, new Guid("8f877272-fd3e-4458-b1ea-8fe63533b151"), (short)1, "Other" },
                    { new Guid("517abc82-0045-492e-ad28-21fae34d8add"), (short)23, null, new Guid("6b71323d-dcee-432c-8c5d-8cd2b795424b"), (short)2, "Office" },
                    { new Guid("8f877272-fd3e-4458-b1ea-8fe63533b151"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("10785842-a75e-435f-ad7f-b5ff7cfa7552"), (short)23, null, new Guid("6fd5ba2b-beca-4e65-866e-7b3b424687ce"), (short)1, "Other" },
                    { new Guid("3083a4d0-df52-4919-99b9-0dc500eea76f"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("356deb46-f539-4348-9bb7-02b9840dedb0"), (short)23, null, new Guid("2765cd69-5cee-4fc3-afef-666482398529"), (short)1, "Other" },
                    { new Guid("2765cd69-5cee-4fc3-afef-666482398529"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("e2dc034d-7e4f-458e-ab25-13e06444fb76"), (short)23, null, new Guid("6b71323d-dcee-432c-8c5d-8cd2b795424b"), (short)4, "Other" },
                    { new Guid("6fd5ba2b-beca-4e65-866e-7b3b424687ce"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("c4d84ffc-d0bd-44c2-890f-832e960efe55"), (short)23, null, new Guid("d07c0ee9-38f6-4bdd-b4f2-d807342c9c4d"), (short)5, "Other" },
                    { new Guid("bece2e07-0c5b-4ff9-9b76-7e251bb5cab9"), (short)23, null, new Guid("3083a4d0-df52-4919-99b9-0dc500eea76f"), (short)1, "Other" },
                    { new Guid("2ad869d1-2a33-43f5-862d-c65a74945b19"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("133c22d8-19a1-48ab-8743-87bb8e79acf8"), (short)23, null, new Guid("e316863a-d0a7-4b17-8ac4-e31eba61f011"), (short)1, "Other" },
                    { new Guid("3eb0d640-dfe1-4b07-9fb9-86dcba759a6f"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("dd9235d4-beb2-48c5-82ba-0b8fe9860695"), (short)23, null, new Guid("3eb0d640-dfe1-4b07-9fb9-86dcba759a6f"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("5c7ae176-7639-4544-9bde-8378b67fbc76"), (short)23, null, new Guid("3eb0d640-dfe1-4b07-9fb9-86dcba759a6f"), (short)2, "Other" },
                    { new Guid("e316863a-d0a7-4b17-8ac4-e31eba61f011"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("73ca9bc2-9576-4751-91d5-3b06f3008a27"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("b15ff45a-c663-4b3a-a2fa-e313066d569f"), (short)23, null, new Guid("73ca9bc2-9576-4751-91d5-3b06f3008a27"), (short)1, "Other" },
                    { new Guid("62def069-77bc-4c0b-bd65-6eb8b51de277"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("21982075-24d9-4a28-9688-1a3203d8eca8"), (short)23, null, new Guid("62def069-77bc-4c0b-bd65-6eb8b51de277"), (short)1, "Other" },
                    { new Guid("6ecefe73-d147-4af4-aa50-1f662e14e720"), (short)22, null, null, (short)8, "Distribution" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("4f537655-acd4-464a-97f7-4ec947ce8a80"), (short)23, null, new Guid("6ecefe73-d147-4af4-aa50-1f662e14e720"), (short)1, "Transport" },
                    { new Guid("de606359-a71e-4edf-af9d-def557f612b9"), (short)23, null, new Guid("6ecefe73-d147-4af4-aa50-1f662e14e720"), (short)2, "Cost of warehouse" },
                    { new Guid("d6b6c587-1fad-4bc4-97cb-2f57fb729671"), (short)23, null, new Guid("6ecefe73-d147-4af4-aa50-1f662e14e720"), (short)3, "Fees to distributors" },
                    { new Guid("c44c0f16-c482-487d-867c-8c1a713b837d"), (short)23, null, new Guid("6ecefe73-d147-4af4-aa50-1f662e14e720"), (short)4, "Other" },
                    { new Guid("3fe1a98d-d67a-47eb-97b3-5431de6fd0b6"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("ac2ee626-234a-44ae-a021-1ca749d5e445"), (short)23, null, new Guid("2ad869d1-2a33-43f5-862d-c65a74945b19"), (short)1, "Other" },
                    { new Guid("06026cc3-a32d-4203-9c95-1bfece1aa464"), (short)23, null, new Guid("d07c0ee9-38f6-4bdd-b4f2-d807342c9c4d"), (short)3, "Finance management" },
                    { new Guid("dacfacf0-ffe1-4cac-909e-c5188ca13e3e"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("7c80c156-c8b2-4b3c-afe6-1d145d9c6adf"), (short)23, null, new Guid("d07c0ee9-38f6-4bdd-b4f2-d807342c9c4d"), (short)1, "Management" },
                    { new Guid("944edc67-d65e-48e5-86a8-978be8900f32"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("5dfc7aad-3353-4398-a6ca-95de50726911"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("0bc074de-78e7-4b6f-bfc5-f51d2c41e2f1"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("b6bd9170-e9f3-476e-ad89-a9facfb713c7"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("468b55a1-ba1f-4846-97f9-54296743368d"), (short)23, null, new Guid("3fe1a98d-d67a-47eb-97b3-5431de6fd0b6"), (short)1, "Other" },
                    { new Guid("02e2d406-ccc8-47f7-ae4e-357e7bef2774"), (short)23, null, new Guid("dacfacf0-ffe1-4cac-909e-c5188ca13e3e"), (short)1, "Other" },
                    { new Guid("c6d9de69-73fb-4a92-ac54-93ec3bc70a74"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("9d5bcbde-bfe9-478c-8910-4e7a02e412a8"), (short)23, null, new Guid("c6d9de69-73fb-4a92-ac54-93ec3bc70a74"), (short)1, "Manufacturing buildings" },
                    { new Guid("868ad344-a883-4892-87d7-102007336c04"), (short)23, null, new Guid("c6d9de69-73fb-4a92-ac54-93ec3bc70a74"), (short)2, "Inventory buildings" },
                    { new Guid("36700d4a-82af-45be-b4db-5f766936cdec"), (short)23, null, new Guid("c6d9de69-73fb-4a92-ac54-93ec3bc70a74"), (short)3, "Sales buildings (shops)" },
                    { new Guid("9d0fb89e-763c-4cb9-baad-c26d496cfda1"), (short)23, null, new Guid("c6d9de69-73fb-4a92-ac54-93ec3bc70a74"), (short)4, "Other" },
                    { new Guid("197aeb2f-6e3f-40aa-8b1f-af43efe05c35"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("af544e71-19a1-4507-816b-62689c919b10"), (short)23, null, new Guid("197aeb2f-6e3f-40aa-8b1f-af43efe05c35"), (short)1, "IT (office) equipment" },
                    { new Guid("52c69363-b8a1-435a-b7ff-859a5ebc1a37"), (short)23, null, new Guid("197aeb2f-6e3f-40aa-8b1f-af43efe05c35"), (short)2, "Production equipment and machinery" },
                    { new Guid("3d3a0317-95a8-46ce-ba64-7fa72a91bc86"), (short)23, null, new Guid("197aeb2f-6e3f-40aa-8b1f-af43efe05c35"), (short)3, "Transport" },
                    { new Guid("d460758b-d187-4100-bf60-92726804ba9f"), (short)23, null, new Guid("197aeb2f-6e3f-40aa-8b1f-af43efe05c35"), (short)4, "Other" },
                    { new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("d07c0ee9-38f6-4bdd-b4f2-d807342c9c4d"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("4d406ed2-f1ab-4b17-9e92-3d202bdfca39"), (short)23, null, new Guid("cd93bb05-c33a-4966-8d5b-192484f14026"), (short)1, "Other" },
                    { new Guid("cd93bb05-c33a-4966-8d5b-192484f14026"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("e5262023-a1c7-43f5-963b-6d44ce99f7ca"), (short)23, null, new Guid("7f0baf15-c4c9-4112-8e7d-8501d84b8fb7"), (short)3, "Other" },
                    { new Guid("426c2dab-6d42-4cc4-abc1-bd6898a08ba4"), (short)23, null, new Guid("7f0baf15-c4c9-4112-8e7d-8501d84b8fb7"), (short)2, "IT support" },
                    { new Guid("76f4220d-edb9-4187-8206-46e42002b06a"), (short)23, null, new Guid("7f0baf15-c4c9-4112-8e7d-8501d84b8fb7"), (short)1, "Accountant" },
                    { new Guid("441fe823-d05e-4478-bd11-5f2b3a09b83c"), (short)23, null, new Guid("d07c0ee9-38f6-4bdd-b4f2-d807342c9c4d"), (short)2, "Factory workers / service" },
                    { new Guid("7f0baf15-c4c9-4112-8e7d-8501d84b8fb7"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("f596963c-17ad-45d2-8d72-08b611477058"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)6, "Communication" },
                    { new Guid("a985bcfb-6603-4469-8dd4-17a27c274c37"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)5, "Maintenance" },
                    { new Guid("5c7ad94b-739c-4a06-8edb-16149778d0ba"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)4, "Heat" },
                    { new Guid("a4b01780-6a22-4ba5-94ea-18e6b7d822e7"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)3, "Gas" },
                    { new Guid("582a4f01-0b04-4909-af54-0dcfd1ca19f8"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)2, "Water" },
                    { new Guid("d731d70a-9bfe-451d-a685-dece10c673b9"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)1, "Electricity" },
                    { new Guid("fc77f1e1-fe69-43be-931d-09ca381cc217"), (short)23, null, new Guid("ffb824aa-7dc5-43a3-8c68-734d4397f0d6"), (short)7, "Other" },
                    { new Guid("4cb70ec3-e223-4872-8030-e24a56949041"), (short)24, null, null, (short)1, "Asset sale" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("66f2fa0c-9d53-44f3-9709-d56adb119897"), (short)31, null, new Guid("6540609e-975e-4d0a-a306-a520dc0c6120"), (short)3, "To the email" },
                    { new Guid("0c408a2e-3fc1-4ed1-864b-ef3626845833"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("2920932a-901f-47ae-906d-51487ae7b02e"), (short)32, null, null, (short)2, "12 - 17" },
                    { new Guid("ce54f31f-80d1-4b5e-9445-78616aa5aff3"), (short)32, null, null, (short)3, "18 - 24" },
                    { new Guid("9977da91-713c-4fe9-8083-9462c7a3bd5c"), (short)32, null, null, (short)4, "25 - 34" },
                    { new Guid("d08fdf5c-48bc-4417-b7bb-e1c862bcb0cb"), (short)32, null, null, (short)5, "35 - 64" },
                    { new Guid("8e6a2712-ade4-4fc1-835c-d890626bc6bf"), (short)32, null, null, (short)6, "65 - 74" },
                    { new Guid("fe3a0eb2-e769-411a-9bf5-88a7d2f041ea"), (short)32, null, null, (short)7, "75 years or older" },
                    { new Guid("fbafaa43-7089-4d71-bf25-14f4ccc43008"), (short)32, null, null, (short)8, "All age groups" },
                    { new Guid("48d606e2-2b1d-46ba-9221-8ed64f8bc7df"), (short)33, null, null, (short)1, "Low" },
                    { new Guid("778f9828-1a7a-4b04-bbf3-3ab468a0befd"), (short)33, null, null, (short)2, "Medium" },
                    { new Guid("2e18dd31-6938-4e33-8e82-7790cf75bf07"), (short)33, null, null, (short)3, "High" },
                    { new Guid("74d276a8-c02c-41d6-ad0e-7b797e3a2dec"), (short)34, null, null, (short)1, "Primary" },
                    { new Guid("0ae03870-5e4d-42c5-9409-65a7f1d561f5"), (short)34, null, null, (short)2, "Secondary" },
                    { new Guid("b972d47e-192f-4e2e-9e44-1b246382bbfa"), (short)34, null, null, (short)3, "Higher education" },
                    { new Guid("028c25e3-ddf0-4bd0-bd37-559f590436ca"), (short)35, null, null, (short)1, "Domestic" },
                    { new Guid("bb3de36e-b39e-4f7c-a1cd-12d9a7426370"), (short)35, null, null, (short)2, "Domestic Urban" },
                    { new Guid("1d8442cb-e2ed-474b-a7c1-fcc438983df6"), (short)35, null, null, (short)3, "Domestic Rural" },
                    { new Guid("54e37dec-7d58-4266-beb9-3c1d62563612"), (short)35, null, null, (short)4, "Foreign" },
                    { new Guid("f411e4ca-6102-4ff4-8a91-87de1a823c80"), (short)39, null, null, (short)2, "female" },
                    { new Guid("43a61721-7e25-4b3c-b4ee-6054263827d8"), (short)39, null, null, (short)1, "male" },
                    { new Guid("c9e2f1a5-0e12-4856-9280-18c1de8dcd8e"), (short)38, null, null, (short)4, "Non-Government organisations" },
                    { new Guid("68ac1f15-a56a-4f77-9181-6f05237aec63"), (short)38, null, null, (short)3, "Muncipality" },
                    { new Guid("1e3b8423-8326-49b9-a6d5-dd1d1f4e5564"), (short)38, null, null, (short)2, "National Government" },
                    { new Guid("43d25630-bbf1-4f18-a847-118b5625ad82"), (short)38, null, null, (short)1, "International Organisations" },
                    { new Guid("b504ebdc-33b4-41ca-9020-9633ecaf10cd"), (short)32, null, null, (short)1, "Under 12" },
                    { new Guid("14269ad7-03a0-43f1-9483-f8852dc32fce"), (short)37, null, null, (short)2, "Services" },
                    { new Guid("c688dc3f-f103-4587-a8fe-fbb4f101416a"), (short)36, null, null, (short)3, "Large" },
                    { new Guid("274a5014-37e3-4583-8599-edda48f2d848"), (short)36, null, null, (short)2, "Medium" },
                    { new Guid("9ab70d57-a394-421b-8b2f-cb0e0e5da9aa"), (short)36, null, null, (short)1, "Small" },
                    { new Guid("60471b4f-922c-4e17-a5c6-ccf36767602e"), (short)35, null, null, (short)7, "Transnational" },
                    { new Guid("23f363cb-88c1-40c3-9974-0173623381e3"), (short)35, null, null, (short)6, "Foreign Rural" },
                    { new Guid("355a9b16-f362-4b4e-8bc3-24ea792436c0"), (short)35, null, null, (short)5, "Foreign Urban" },
                    { new Guid("ff44357a-4d66-41d7-8de9-e4fce227070b"), (short)37, null, null, (short)1, "Goods" },
                    { new Guid("63c5c3f1-8944-408c-8529-7629f9a28c05"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("31a326e3-2521-4080-a7c8-2300e20f8179"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("3c29158a-467a-4438-8269-c5ae37762b94"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("7cbd938d-1512-4896-9946-28ecaaaf4747"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("7d3bcc87-c96b-4bf7-9d99-cc299197d48b"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("cd45d79b-67d2-4889-94dd-77cdbddd68e9"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("f3f3943a-8539-411f-87cc-32a176924053"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("73c5a941-2fbf-445e-a399-c60ca809ed0c"), (short)25, null, null, (short)1, "Fixed pricing" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("ffdf8e85-acf7-4de4-99fa-40e0e3560f40"), (short)26, null, new Guid("73c5a941-2fbf-445e-a399-c60ca809ed0c"), (short)1, "List price" },
                    { new Guid("1fec5a71-f272-4f10-8fd2-613848311fc4"), (short)26, null, new Guid("73c5a941-2fbf-445e-a399-c60ca809ed0c"), (short)2, "Product feature dependent" },
                    { new Guid("13348cfc-72ed-42a1-a3d6-782b28080b1d"), (short)26, null, new Guid("73c5a941-2fbf-445e-a399-c60ca809ed0c"), (short)3, "Volume dependent" },
                    { new Guid("219478a0-9926-47f0-b780-e40f4f4316a1"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("a694124c-77bc-4405-929e-d9895b0b0de3"), (short)26, null, new Guid("219478a0-9926-47f0-b780-e40f4f4316a1"), (short)1, "Negotiation" },
                    { new Guid("313b127f-2d92-4ef3-85d7-5b6f8aaf080e"), (short)26, null, new Guid("219478a0-9926-47f0-b780-e40f4f4316a1"), (short)2, "Yield management" },
                    { new Guid("42d20ab3-b198-4a80-a38a-16165164ad70"), (short)26, null, new Guid("219478a0-9926-47f0-b780-e40f4f4316a1"), (short)3, "Real time market" },
                    { new Guid("b03c70a3-090f-4229-993b-a079b6950e51"), (short)26, null, new Guid("219478a0-9926-47f0-b780-e40f4f4316a1"), (short)4, "Auctions" },
                    { new Guid("60ff9c13-7cfb-4100-89cb-90d15c540670"), (short)27, null, null, (short)1, "Direct sales" },
                    { new Guid("3ad6ff86-4f3e-4d5e-ae79-4f00fe8a9e3b"), (short)28, null, new Guid("60ff9c13-7cfb-4100-89cb-90d15c540670"), (short)1, "Own shop" },
                    { new Guid("ea777a5a-afbc-4691-8e5b-02e962b24c16"), (short)29, null, new Guid("3ad6ff86-4f3e-4d5e-ae79-4f00fe8a9e3b"), (short)1, "Physical" },
                    { new Guid("afe05778-1bb2-4715-8b9a-681fe8aea06a"), (short)30, null, new Guid("ea777a5a-afbc-4691-8e5b-02e962b24c16"), (short)1, "Fixed location" },
                    { new Guid("878a94ca-a0a8-4f6c-a939-a81e571028b1"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("303a831b-8abd-41f0-90a5-cd93e87e87fb"), (short)28, null, new Guid("60ff9c13-7cfb-4100-89cb-90d15c540670"), (short)4, "" },
                    { new Guid("febd3659-f4c5-4aae-91e7-6aad052e8493"), (short)28, null, new Guid("60ff9c13-7cfb-4100-89cb-90d15c540670"), (short)3, "Direct visit" },
                    { new Guid("4f7d6dbd-822f-454a-9671-364ca050b597"), (short)28, null, new Guid("60ff9c13-7cfb-4100-89cb-90d15c540670"), (short)2, "Market/Fairs" },
                    { new Guid("ba9c8f23-7312-4ae2-89bf-1b8ecc3b5906"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("1899cc66-9e2e-4762-8a9e-f9a3fc79b43a"), (short)31, null, new Guid("6540609e-975e-4d0a-a306-a520dc0c6120"), (short)2, "Courier service" },
                    { new Guid("95e99c3f-a8d2-4d41-9472-4f7141d2ef47"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("725d9235-a3c9-4204-9add-a27d3cce5b85"), (short)31, null, new Guid("6540609e-975e-4d0a-a306-a520dc0c6120"), (short)1, "Own delivery" },
                    { new Guid("cf8a9278-0600-4b5b-9166-0784bcbb1847"), (short)30, null, new Guid("6540609e-975e-4d0a-a306-a520dc0c6120"), (short)1, "Own website" },
                    { new Guid("6540609e-975e-4d0a-a306-a520dc0c6120"), (short)29, null, new Guid("3ad6ff86-4f3e-4d5e-ae79-4f00fe8a9e3b"), (short)2, "Online" },
                    { new Guid("a0d19368-d5d5-4ee0-84a3-960ece7a6070"), (short)31, null, new Guid("ea777a5a-afbc-4691-8e5b-02e962b24c16"), (short)3, "Courier service" },
                    { new Guid("7510ffec-63e0-4842-ad09-ced40778ff2f"), (short)31, null, new Guid("ea777a5a-afbc-4691-8e5b-02e962b24c16"), (short)2, "Delivery to home" },
                    { new Guid("4a3b005a-ca6b-4b8c-993b-94a9271ac2ca"), (short)31, null, new Guid("ea777a5a-afbc-4691-8e5b-02e962b24c16"), (short)1, "Self pickup" },
                    { new Guid("ddc01ae4-5376-40bd-a558-59c5098b517d"), (short)30, null, new Guid("ea777a5a-afbc-4691-8e5b-02e962b24c16"), (short)2, "Mobile" },
                    { new Guid("a6462e11-d10b-42d8-af77-3b3896b892b9"), (short)30, null, new Guid("6540609e-975e-4d0a-a306-a520dc0c6120"), (short)2, "Platform" },
                    { new Guid("54606a62-3fea-45f5-b798-860a80daf52c"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("792a16b1-0e12-45f5-8802-5bf6efee0bb3"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("3752e3b0-e662-453a-9dc8-924f67282fd0"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("fce0f3c8-0d05-4c56-a7cf-ee7893998030"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("31721b20-f008-4ded-b2c1-66953df929d0"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("c3947a43-c29b-4d48-925b-4f79563289ae"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("991c12ba-404c-49f4-9f1a-cab03530595d"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("51036854-4d15-4371-aec4-ad55c7aaf7e5"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("12b84ab0-d02c-460c-bbc2-97b6198dfd53"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("ddc1b67d-274d-4799-886c-1b2d9096ba31"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("38884dbd-848b-44c7-876b-688f4b351cfe"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("195c804d-6bd6-4f41-81c5-89f2d90da420"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("cb9bb1cb-7a6c-45a8-b5cb-f9a49b119d48"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("6d2ebe23-5243-40ed-96d4-3719ac5cd182"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("e24de983-b4ea-4a7b-a399-09dde01fe06b"), (short)3, null, null, (short)24, "Potential/future competition" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("a7cb1abd-e500-4b87-8281-217e87833f24"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("ec5de24c-349d-4c26-9b46-9d108acd47bd"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("18690a82-21af-4293-b0fc-55058686be6f"), (short)6, null, new Guid("ec5de24c-349d-4c26-9b46-9d108acd47bd"), (short)1, "Buildings" },
                    { new Guid("2e8a5783-0101-41b5-9987-b3f23ec53e15"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("18690a82-21af-4293-b0fc-55058686be6f"), (short)1, "Ownership type" },
                    { new Guid("8ce99396-0ffd-432e-95dd-83816f74b9b7"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("18690a82-21af-4293-b0fc-55058686be6f"), (short)2, "Frequency" },
                    { new Guid("ff223698-77f4-4f6b-91ee-a0e2dc4dafac"), (short)6, null, new Guid("dae0f97e-112b-40b0-88f1-3d270de66762"), (short)2, "Licenses" },
                    { new Guid("c6537378-9107-4ae5-b5c2-1d205e65601f"), (short)6, null, new Guid("dae0f97e-112b-40b0-88f1-3d270de66762"), (short)1, "Brands" },
                    { new Guid("dae0f97e-112b-40b0-88f1-3d270de66762"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("ddb53537-b2b3-4449-b6ba-6197fefba7e4"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3d0ae89c-fbcb-48ba-84ba-779d1d1689f3"), (short)2, "Frequency" },
                    { new Guid("788092bb-74dd-442b-ac64-3dee0bdc90d2"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3d0ae89c-fbcb-48ba-84ba-779d1d1689f3"), (short)1, "Ownership type" },
                    { new Guid("3d0ae89c-fbcb-48ba-84ba-779d1d1689f3"), (short)6, null, new Guid("ec5de24c-349d-4c26-9b46-9d108acd47bd"), (short)5, "Other" },
                    { new Guid("693a75de-88fb-47ef-9b64-184ab881113d"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("d1b993fe-30ee-401e-bae3-c9a78e31be01"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3b477b53-87f9-4075-9370-40fa4954e158"), (short)1, "Ownership type" },
                    { new Guid("f22a4d71-58e0-4581-9db6-f1b729ee7963"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("741a0a48-af82-4162-b720-8e7bf7fdbb43"), (short)2, "Frequency" },
                    { new Guid("e313d5c9-0fe9-4b8b-b4d3-6c835fe84970"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("741a0a48-af82-4162-b720-8e7bf7fdbb43"), (short)1, "Ownership type" },
                    { new Guid("741a0a48-af82-4162-b720-8e7bf7fdbb43"), (short)6, null, new Guid("ec5de24c-349d-4c26-9b46-9d108acd47bd"), (short)3, "Transport" },
                    { new Guid("bf8d5cc6-44a6-4096-bac9-5b79c39acd5c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("6f8e2697-c5b8-4d49-bb24-78e2a1d66a51"), (short)2, "Frequency" },
                    { new Guid("ff64e6ee-a0ba-4988-b594-99661f8f57b5"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("6f8e2697-c5b8-4d49-bb24-78e2a1d66a51"), (short)1, "Ownership type" },
                    { new Guid("6f8e2697-c5b8-4d49-bb24-78e2a1d66a51"), (short)6, null, new Guid("ec5de24c-349d-4c26-9b46-9d108acd47bd"), (short)2, "Equipment" },
                    { new Guid("3b477b53-87f9-4075-9370-40fa4954e158"), (short)6, null, new Guid("ec5de24c-349d-4c26-9b46-9d108acd47bd"), (short)4, "Raw materials" },
                    { new Guid("3c52185d-eee6-4aca-8aa5-7d2f454aeae3"), (short)6, null, new Guid("dae0f97e-112b-40b0-88f1-3d270de66762"), (short)3, "Software" },
                    { new Guid("7434ccaa-2133-423e-a6cb-63f798b9e5f8"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("be2c7042-38ba-410a-84c7-ba9c24be14de"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("6504e869-a964-4cea-8b5f-325b8952d9f6"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("77dd201c-b2e9-4964-b0cf-555ce949ec51"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("c0b4f07b-1910-4d1f-ab73-9218e95cbf48"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("b6eedb55-6ef5-4a28-81e3-4d472a2c07cc"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("aa1f2f76-fb3e-4f01-a8de-025406b39a70"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("e4666a40-18b3-410c-853f-62bf22d7fb7a"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("35de3255-11c4-4aa0-8e55-e48130d4b355"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("df69c9e4-fef5-4d6f-956d-bea57f431622"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("2d817051-37e3-4b36-9950-7f16449e0640"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("c8b0b679-3463-4070-8ef9-ae083516cf7f"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("300a724e-a776-428e-9911-29c6917f2f6a"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("bc2b2c1e-1817-4e8b-aa02-d407ea3d8a4b"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("b9bbb53a-29b1-468d-b2fe-18d91272dd10"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("10eece96-31c5-49e9-9ed9-4105ece1951c"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("1839e391-68d2-48ac-92c6-c93ce0cf7041"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("da188dc5-d0f8-4ac6-bd03-8a005a08425e"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("800800f6-c20f-4381-995d-8367d871a891"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("705bb32c-93ed-4316-acff-d0259ec9d16e"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("e1b6b12d-479b-41ec-a77b-412ec33fd74f"), (short)3, null, null, (short)7, "Interest rate" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("455179ac-32c0-409f-8309-6410f408a65e"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("0f3c9262-0c4a-4bff-a58a-02d0db4cf496"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("bf11ca83-5e63-44e1-a3d3-23e1fd01715c"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("96860eb9-0397-4d31-8497-c4a218dcc0b3"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("d92ebe6d-3b7f-4425-966c-7e5bb5351bb1"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("85628ff2-be0a-431a-a9e2-9a18edd48cd0"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("f587bd1d-7046-463d-9e33-cb08a7447609"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("969a61d3-ddf2-4d8f-9732-b7ab3aebc309"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("720ecc18-cf56-426d-99dd-172f64600783"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("13a1c1a4-1916-43c5-b89e-07d05aafb38a"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("c895ae49-62e5-4b91-9764-6ac4556d2e81"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("8e61b2cb-6a8c-4e51-9d9e-50a81c7e9e25"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("c2223931-ae31-420d-bb7d-d56638d30c22"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("691c7b75-8711-4eef-b7c1-ad46562bc71c"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("dee0987b-0aaf-430a-9c20-3e211dcf945e"), (short)6, null, new Guid("dae0f97e-112b-40b0-88f1-3d270de66762"), (short)4, "Other" },
                    { new Guid("fe744df8-139f-428f-81ab-1fec87e0fa1c"), (short)6, null, new Guid("6c611d1e-af88-4374-a6db-d0324f0ceac5"), (short)1, "Specialists & Know-how" },
                    { new Guid("f62bf261-631b-48d1-a6d8-9dca7780a362"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("845581fa-52b8-4792-9fd3-f8d975913e5a"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("0c2c68bd-eb97-4852-9c53-8d58446606ea"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("d353ebba-8e1c-445e-989f-963ab4dbcf8b"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("2469ba3e-8939-4165-a3c4-99d77a9c2826"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("cb54feaa-eb6c-47d5-8725-6fb9dc83284a"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("e0353fc0-c786-49ed-92b3-8b457ca32395"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("a8c04867-56a1-488f-9f17-41bb4952c881"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("4efdf295-6a2e-44b2-8122-9da68f830039"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("3547c581-83f6-43ce-b6e8-01522ba186e4"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("25a9f65c-b986-4dce-83d0-576739b1ad3c"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("5c4f7cee-7529-4d6c-955c-3feab5ff747b"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("a7144011-995f-4bc8-83c4-fd323329fe19"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("217650ec-c037-424f-b696-7058b26003f4"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("66474d87-4375-4ad3-8cee-25749b3cc14e"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("3a2ef5ed-8754-4239-91d8-29f46c7ec437"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("02e38f35-1f83-4d99-877f-e8dba1a25afd"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("3c2ff7dc-7bc1-469e-9355-59cb038864f6"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("99b76e53-f04a-40ad-9419-82c302253ce4"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("ca2d7789-7610-4ce0-8dd8-ff66523bbdf8"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("7c7d7773-62f4-4f8e-8771-79f5604a253e"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("81d8619d-570a-4ed6-889f-1772947e1095"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("777cbaa6-a98d-4df7-939f-f49b9818d94c"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("d3116cd5-0b2a-4a38-a2d9-a465c126a3e8"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("894a6619-e8c0-4978-8cbf-1643b47ad855"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("1ba8a579-52a1-4e20-95f1-6ae42441a46f"), (short)17, null, null, (short)1, "Free" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("0a5232d9-df16-4466-b3bb-34dc07d847b5"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("076c24cc-9bcb-44a1-8719-7deed1f68bce"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("82806116-42db-4108-9748-3102ca11586a"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("0f7ee2ea-5bad-4c61-9360-e86e7ab14a80"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("00b444c3-25dc-4aaf-ae74-3cbea959f206"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("6c611d1e-af88-4374-a6db-d0324f0ceac5"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("cd398e14-44ee-4a53-8a5f-e672ada5c411"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("aa12a3be-8c06-49ef-9830-542d2c40ad36"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("27348ea3-db10-4bcf-8222-3da03b5d8790"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("476e1536-4765-4563-8fa5-e6452d4e1944"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("049328b6-34ad-4c97-8fd1-983e1ea9b868"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("8a92a9f3-8e6f-4bea-9cf9-b55b6722dcae"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("180d6a4b-e466-4d23-8ffa-9516bc3647ae"), (short)2, "Frequency" },
                    { new Guid("41767213-bf0a-490e-9bc5-dafa9231a5e4"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("180d6a4b-e466-4d23-8ffa-9516bc3647ae"), (short)1, "Ownership type" },
                    { new Guid("180d6a4b-e466-4d23-8ffa-9516bc3647ae"), (short)6, null, new Guid("6c611d1e-af88-4374-a6db-d0324f0ceac5"), (short)4, "Other" },
                    { new Guid("69144a01-4901-455f-9159-17bacd4ec3a6"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("0895fceb-6b49-4958-8b4e-e8e57c40147e"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("c8cf8d74-1623-4357-91d4-ad808fc144e0"), (short)2, "Frequency" },
                    { new Guid("c8cf8d74-1623-4357-91d4-ad808fc144e0"), (short)6, null, new Guid("6c611d1e-af88-4374-a6db-d0324f0ceac5"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("4dfe8082-9e1e-4f53-a7fd-abcfc0c5860b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("712bf688-d87c-4b84-9344-4fe21874653a"), (short)2, "Frequency" },
                    { new Guid("330c16d3-1e38-4804-a524-ea900c840498"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("712bf688-d87c-4b84-9344-4fe21874653a"), (short)1, "Ownership type" },
                    { new Guid("712bf688-d87c-4b84-9344-4fe21874653a"), (short)6, null, new Guid("6c611d1e-af88-4374-a6db-d0324f0ceac5"), (short)2, "Administrative" },
                    { new Guid("5f9c6770-e1a2-44bb-aa35-ec4c39666dc0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fe744df8-139f-428f-81ab-1fec87e0fa1c"), (short)2, "Frequency" },
                    { new Guid("7c3e79cd-6332-411c-941f-b6d708e10c9b"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("fe744df8-139f-428f-81ab-1fec87e0fa1c"), (short)1, "Ownership type" },
                    { new Guid("70dd892c-d93d-4f36-abeb-55df96d98e30"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("c8cf8d74-1623-4357-91d4-ad808fc144e0"), (short)1, "Ownership type" },
                    { new Guid("4f515162-1088-46a2-9e42-4e5c19b4f933"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("a36cbab1-1934-4e43-94a4-ed01311bec80"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("9df2ba8a-c868-428b-a0ad-c0ec518e05c6"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("d06809be-ba6d-4797-b31c-10b1518cdb6f"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("c31c0395-7f66-495e-a473-730fcd3d4489"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("fb5f25f7-1903-4aaa-bf1e-5a85b54f108d"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("bd54dd52-484f-4fe1-9399-f6a037ba00ae"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("660acdc2-a1c7-44ed-8985-42021ceab41b"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("c6ea729d-baf4-473b-bd1e-b49f06cf5d07"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("9aae4b3e-991c-4006-9409-3bac274e3bca"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("44905a0c-0cfa-453d-88d1-846e1bbc260d"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("6f6a8b81-efff-4b51-84d5-5a13d620dd2b"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("3519119b-f502-4231-bca3-253bf856f2ad"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("5168b467-d30b-4351-aad0-17311cc91858"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("50110364-83f4-4112-88ba-58587dbdda2e"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("ac2eec5c-27ff-4f5b-ab0a-6043d690f132"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("8ac17509-c043-477c-8cc9-f35d126a968f"), (short)13, null, null, (short)1, "Non-governmental institutions" }
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
                    { new Guid("a43209cd-9cf2-4f38-9e81-37efdce084bd"), "A.01", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("8db04452-709b-480d-a883-c2201d0c755f"), "H.51.22", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Space transport" },
                    { new Guid("b5477419-6dd6-4735-952e-cf6cf0bd395b"), "H.52", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Warehousing and support activities for transportation" },
                    { new Guid("0a2de676-2bad-4527-8bfd-30cc4a274069"), "H.52.1", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Warehousing and storage" },
                    { new Guid("7c41b8fb-c0e2-4c7f-a478-7f4ffbaca932"), "H.52.10", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Warehousing and storage" },
                    { new Guid("13427bdd-7bdf-421e-82c3-7724d731ddc0"), "H.52.2", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Support activities for transportation" },
                    { new Guid("e3187671-d835-4811-aae0-3e1744e5b19e"), "H.52.21", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Service activities incidental to land transportation" },
                    { new Guid("d1b6efaf-96c0-480a-9599-fba378ea9a43"), "H.52.22", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Service activities incidental to water transportation" },
                    { new Guid("e4f45fc7-2679-49b7-ad36-f25998d6e1d2"), "H.52.23", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Service activities incidental to air transportation" },
                    { new Guid("93ea0309-c09a-4294-8bfb-e82b49a7509a"), "H.52.24", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Cargo handling" },
                    { new Guid("183459b2-9d85-4685-8728-b6e66fd224a5"), "H.52.29", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Other transportation support activities" },
                    { new Guid("5e2f602c-b7bd-4cbb-9277-6302d48cc987"), "H.53", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Postal and courier activities" },
                    { new Guid("029ba7ba-6650-4eff-87ed-78616ea03743"), "H.53.1", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Postal activities under universal service obligation" },
                    { new Guid("f74c23db-fa8c-4690-82fc-77da41a7aa20"), "H.51.21", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Freight air transport" },
                    { new Guid("60294960-5051-4603-ab9f-ea195ba044c0"), "H.53.10", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Postal activities under universal service obligation" },
                    { new Guid("d6a5ad5d-766f-4e8b-b076-5cbec9148875"), "H.53.20", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Other postal and courier activities" },
                    { new Guid("331fa3c7-08e5-42fa-bae2-fc7d9bd1ea3c"), "I.55", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Accommodation" },
                    { new Guid("a6f83b54-c300-43ed-8b07-3168550e6d9b"), "I.55.1", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Hotels and similar accommodation" },
                    { new Guid("2bd46f2c-69b0-4b09-8fbf-4af5f911d74d"), "I.55.10", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Hotels and similar accommodation" },
                    { new Guid("be76a767-254c-42d1-b6a1-ba17219668ac"), "I.55.2", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Holiday and other short-stay accommodation" },
                    { new Guid("f54a49b5-8813-43fc-9c18-65bb00ae892a"), "I.55.20", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Holiday and other short-stay accommodation" },
                    { new Guid("07f748d1-7e27-4b5f-b0b5-30e1cb225cfa"), "I.55.3", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("440efe59-2054-4e66-896a-6770a84fda48"), "I.55.30", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("35cebd25-7b84-46fa-8315-baa8a162e3bd"), "I.55.9", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Other accommodation" },
                    { new Guid("da712e5b-1091-4941-bb36-1aa786009645"), "I.55.90", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Other accommodation" },
                    { new Guid("fec22be3-fa9a-4455-9016-e4b900f9d32a"), "I.56", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Food and beverage service activities" },
                    { new Guid("5abcf046-f3e7-43ff-9d53-669531fc8b92"), "I.56.1", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Restaurants and mobile food service activities" },
                    { new Guid("eeaffdcd-896f-42cd-a380-210f0a5ebc1a"), "H.53.2", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Other postal and courier activities" },
                    { new Guid("4c53d99d-8137-4e70-acae-72524a8bb938"), "H.51.2", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Freight air transport and space transport" },
                    { new Guid("a665a012-ca3e-492e-af4e-b1b514d76a5c"), "H.51.10", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Passenger air transport" },
                    { new Guid("efa49c48-b72c-4e81-be17-56715667f104"), "H.51.1", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Passenger air transport" },
                    { new Guid("4e5aea16-0314-464b-8977-5529a1ad74d0"), "G.47.9", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("610aa3d0-0c2e-4c36-9705-5cbff90ad737"), "G.47.91", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("ce8e9d60-379f-45c0-8d90-477c19f7f91f"), "G.47.99", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("307ea5f8-10d9-4387-a6cd-0c0693f1bae8"), "H.49", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Land transport and transport via pipelines" },
                    { new Guid("1229082f-eeab-42f6-92c9-217842041efc"), "H.49.1", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Passenger rail transport, interurban" },
                    { new Guid("69fb39be-e84d-45ad-a910-dce3b73b951c"), "H.49.10", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Passenger rail transport, interurban" },
                    { new Guid("6c7593eb-f62d-48f2-8e48-315a8aa490ac"), "H.49.2", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Freight rail transport" },
                    { new Guid("d3cc75a6-78db-402b-9bc1-20f088114c3c"), "H.49.20", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Freight rail transport" },
                    { new Guid("b5053f39-8668-451c-8ba0-34f6b4e60592"), "H.49.3", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Other passenger land transport" },
                    { new Guid("182f10d4-7663-4570-92c3-f0e8d47ab8f6"), "H.49.31", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Urban and suburban passenger land transport" },
                    { new Guid("95d075e9-dd04-437c-9340-d3c6a50eb526"), "H.49.32", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4d4bd5ad-de8b-41db-a3ff-3b605c4acb76"), "H.49.39", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Other passenger land transport n.e.c." },
                    { new Guid("88cb79ee-ec30-44db-972a-b83e79590226"), "H.49.4", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Freight transport by road and removal services" },
                    { new Guid("3888637d-7051-4a8b-975e-5f69499c4e33"), "H.49.41", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Freight transport by road" },
                    { new Guid("b753a574-2f58-4224-9cd7-1c1104c8babb"), "H.49.42", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Removal services" },
                    { new Guid("276bbdc4-7947-432e-a075-cf5b74b8e243"), "H.49.5", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Transport via pipeline" },
                    { new Guid("c39ba263-66d9-4c11-b800-3ddedb0ea507"), "H.49.50", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Transport via pipeline" },
                    { new Guid("fe4c8eb3-cd31-4042-b42c-9890bd17e390"), "H.50", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Water transport" },
                    { new Guid("0497cbd7-9e01-49b2-9508-5701a3af22f0"), "H.50.1", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Sea and coastal passenger water transport" },
                    { new Guid("022ca699-49bc-48a6-b6ef-c8d408a07457"), "H.50.10", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Sea and coastal passenger water transport" },
                    { new Guid("601a88db-1715-405b-ba83-fb27f7b08264"), "H.50.2", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Sea and coastal freight water transport" },
                    { new Guid("929fc67d-55d1-4a34-b2f1-43d4595404a7"), "H.50.20", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Sea and coastal freight water transport" },
                    { new Guid("04c30ff1-060c-45f0-9ff9-6672312e61d1"), "H.50.3", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Inland passenger water transport" },
                    { new Guid("93129ea1-303a-4229-8f12-5229ed2c42cd"), "H.50.30", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Inland passenger water transport" },
                    { new Guid("b2561db9-dab5-4bff-b5b9-1b2c99f72362"), "H.50.4", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Inland freight water transport" },
                    { new Guid("ef4ab70f-9db4-48a8-b371-252be09d120d"), "H.50.40", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Inland freight water transport" },
                    { new Guid("c4e8505a-a4fa-41d2-9fc5-e26ec9179e47"), "H.51", new Guid("5f2049a8-79dd-44d7-a35b-9f273b930669"), "Air transport" },
                    { new Guid("c1fbfd1d-8127-4372-8d4a-daf6e445c2e5"), "I.56.10", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Restaurants and mobile food service activities" },
                    { new Guid("777aa0b5-dc7c-412e-b19b-d4ff9de711da"), "G.47.89", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("4889486d-e3d2-4ffb-995a-408709695b39"), "I.56.2", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Event catering and other food service activities" },
                    { new Guid("9173d363-1ed5-4936-a42a-7764dbb48a59"), "I.56.29", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Other food service activities" },
                    { new Guid("61164d66-6416-4e18-81db-c2760c542f8d"), "J.61.30", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Satellite telecommunications activities" },
                    { new Guid("35d77bf4-3684-43bd-aa2e-5380d1ae68c8"), "J.61.9", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other telecommunications activities" },
                    { new Guid("b5bdf0af-0655-44f6-bea5-2a9b24087a1d"), "J.61.90", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other telecommunications activities" },
                    { new Guid("66a84328-2bfd-41e6-a966-e7861adde37a"), "J.62", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Computer programming, consultancy and related activities" },
                    { new Guid("a856e741-419f-482b-b964-f38e65cfe935"), "J.62.0", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Computer programming, consultancy and related activities" },
                    { new Guid("1d819255-afb9-4a22-b212-b34011ec1722"), "J.62.01", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Computer programming activities" },
                    { new Guid("ea6789e6-659f-403b-b34b-9188677ffd91"), "J.62.02", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Computer consultancy activities" },
                    { new Guid("954f6bed-77a2-463e-bafc-39de2b6895f8"), "J.62.03", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Computer facilities management activities" },
                    { new Guid("d9e6ba13-5732-4e1c-a8ba-7b42a99032eb"), "J.62.09", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other information technology and computer service activities" },
                    { new Guid("9e935db8-a40a-425c-8b41-ac465e77c976"), "J.63", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Information service activities" },
                    { new Guid("92de8249-0a7e-4b22-8b99-4f2c2ec06531"), "J.63.1", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("135abf08-63bc-4706-8be2-942f9dd2b907"), "J.63.11", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Data processing, hosting and related activities" },
                    { new Guid("8f5155f1-bd5c-4a4b-afac-65443d895bb7"), "J.61.3", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Satellite telecommunications activities" },
                    { new Guid("fc48be2d-1592-4c17-8827-aae9b5046a5f"), "J.63.12", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Web portals" },
                    { new Guid("ab476c8b-2f56-4945-aa7b-0610ef6d7f49"), "J.63.91", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "News agency activities" },
                    { new Guid("f23f77a8-d934-4e44-9d27-d3d945cae52b"), "J.63.99", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other information service activities n.e.c." },
                    { new Guid("4c3e157d-8b14-4786-a08d-3465c4353960"), "K.64", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("5bd3758d-f547-4fc1-95be-861178189703"), "K.64.1", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Monetary intermediation" },
                    { new Guid("ec7dca49-ad1c-4619-a8ac-c89e918dd292"), "K.64.11", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Central banking" },
                    { new Guid("0ec45b3a-8449-446f-9fec-5f282083a892"), "K.64.19", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Other monetary intermediation" },
                    { new Guid("5e4e41f9-2d1d-4c1f-b8ab-ded20ef2eb6c"), "K.64.2", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Activities of holding companies" },
                    { new Guid("dcaef0f3-5094-40af-bf9e-4349dc90e7d8"), "K.64.20", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1f2b5e2c-74fe-4fb2-8d4e-61ab46e8066f"), "K.64.3", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Trusts, funds and similar financial entities" },
                    { new Guid("e6b0e7be-924f-4651-a4ce-71661a8ef6e2"), "K.64.30", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Trusts, funds and similar financial entities" },
                    { new Guid("fc3d493a-5212-4903-9df9-c17ae6140aa4"), "K.64.9", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("60be5c67-8d09-453f-9417-50998e836df1"), "K.64.91", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Financial leasing" },
                    { new Guid("73908c03-54b0-4a47-89d8-d5e1da417879"), "J.63.9", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other information service activities" },
                    { new Guid("4db9c49f-652c-464b-b1d8-93f314466d11"), "J.61.20", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Wireless telecommunications activities" },
                    { new Guid("0785709f-f85a-4dc0-91ff-8e922c1ed106"), "J.61.2", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Wireless telecommunications activities" },
                    { new Guid("4aa32120-4583-4948-b8c6-486f6a43c117"), "J.61.10", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Wired telecommunications activities" },
                    { new Guid("b553f752-70dc-4349-acda-ebab9c51d350"), "I.56.3", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Beverage serving activities" },
                    { new Guid("c1a1cb09-2ce9-4505-93fd-18e0eb195a8b"), "I.56.30", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Beverage serving activities" },
                    { new Guid("c3c9b1b5-1680-457e-ad4f-a36d42b0f16b"), "J.58", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Publishing activities" },
                    { new Guid("ece358b0-597c-4309-a8dd-2ca902bdb622"), "J.58.1", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("b12a7eac-cd9e-438f-b0ee-c70a7bac3a4d"), "J.58.11", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Book publishing" },
                    { new Guid("fc914036-82d2-4a57-bce7-a9e9df3dc9ef"), "J.58.12", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Publishing of directories and mailing lists" },
                    { new Guid("7e39c4c7-7f28-4962-aa17-c1c3e956ba3f"), "J.58.13", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Publishing of newspapers" },
                    { new Guid("3f9dc4bc-566a-457e-a953-ca77ad8696e4"), "J.58.14", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Publishing of journals and periodicals" },
                    { new Guid("e35dd4f2-db05-4fb1-a941-d49abdc78af4"), "J.58.19", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other publishing activities" },
                    { new Guid("a08ad923-3301-4ac7-b5a6-19136e8717a2"), "J.58.2", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Software publishing" },
                    { new Guid("ae3ecc8e-c142-4cb0-b761-c43699daf3fd"), "J.58.21", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Publishing of computer games" },
                    { new Guid("3cbbd988-6cd5-427f-97c8-a924cbb5b030"), "J.58.29", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Other software publishing" },
                    { new Guid("4b96fc2d-3198-473a-88bd-a2b1df969409"), "J.59", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("6675914e-46c9-4fea-956c-a4f615adaea4"), "J.59.1", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Motion picture, video and television programme activities" },
                    { new Guid("dfff0e07-838f-4270-afec-2ef200bd6171"), "J.59.11", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Motion picture, video and television programme production activities" },
                    { new Guid("f7cd6abc-5a19-4dc0-8fa6-fa7081a09804"), "J.59.12", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("2cda6483-f7fa-4d94-bfb2-2fdbed557988"), "J.59.13", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("dbca9c83-9743-4197-aa6c-4657ba9a6760"), "J.59.14", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Motion picture projection activities" },
                    { new Guid("7179f032-8ba3-4ada-916b-c1d923c2f034"), "J.59.2", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Sound recording and music publishing activities" },
                    { new Guid("0d107b62-6283-41f5-b833-69b4e0b5e80a"), "J.59.20", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Sound recording and music publishing activities" },
                    { new Guid("774434b6-5e59-442f-a34c-870e6ccccecd"), "J.60", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Programming and broadcasting activities" },
                    { new Guid("5086f386-a41c-4419-bea9-ac9583210a65"), "J.60.1", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Radio broadcasting" },
                    { new Guid("8cf0282c-2f1c-45ca-8aba-09c85fd909ca"), "J.60.10", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Radio broadcasting" },
                    { new Guid("ce7034ea-2186-41f2-bcab-584d5ed56568"), "J.60.2", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Television programming and broadcasting activities" },
                    { new Guid("d4a3acc2-5c62-4e13-a3c2-35be20ec2180"), "J.60.20", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Television programming and broadcasting activities" },
                    { new Guid("41f856ea-ccd6-42ea-9d06-7491ec006a3a"), "J.61", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Telecommunications" },
                    { new Guid("ceeff60d-b3fe-45cd-b52a-d0d60f60b4c7"), "J.61.1", new Guid("e7c3da0e-6c40-437f-b562-4c2a559747a9"), "Wired telecommunications activities" },
                    { new Guid("8bae8ffd-0075-4023-b646-721defb16fc7"), "I.56.21", new Guid("86de33a2-28bc-4ccd-97ba-f6e993a0afed"), "Event catering activities" },
                    { new Guid("3863a2a2-a14e-445e-9dcb-a532271362c3"), "K.64.92", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Other credit granting" },
                    { new Guid("27f7d61f-85be-4437-a008-14b14edcdb15"), "G.47.82", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("11be3373-6f8a-410f-8b82-28254ed3e424"), "G.47.8", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale via stalls and markets" },
                    { new Guid("7987e82c-f80a-41de-a3c0-5c0a1185a4ac"), "G.46.19", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("cd3e5956-ffe8-4138-816b-cfefb254b550"), "G.46.2", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("a69c8642-dad7-4aa8-8458-99cd0fca1eb2"), "G.46.21", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7af49562-56b4-4632-a353-00e80b9321a3"), "G.46.22", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of flowers and plants" },
                    { new Guid("215b26a3-03db-45d5-bf0e-54d63cd58cfe"), "G.46.23", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of live animals" },
                    { new Guid("b8f35cb4-1552-4229-a517-ba8f0ce22ec7"), "G.46.24", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of hides, skins and leather" },
                    { new Guid("43069d63-4fc1-47dd-8162-8ffce93f2cf9"), "G.46.3", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("19e207f8-3538-4630-a963-30842bcc9cb7"), "G.46.31", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of fruit and vegetables" },
                    { new Guid("5a6f442a-e18a-4d01-a19d-9cab12d66836"), "G.46.32", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of meat and meat products" },
                    { new Guid("91f61cb7-4101-4a41-ad26-e20830204469"), "G.46.33", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("da6be520-06be-4c6f-9af1-92b8e7568cfa"), "G.46.34", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of beverages" },
                    { new Guid("4261a2b0-2942-479e-baf9-2d23e960b289"), "G.46.35", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of tobacco products" },
                    { new Guid("55703071-e888-434e-9580-ba1d57547aff"), "G.46.18", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents specialised in the sale of other particular products" },
                    { new Guid("f449978e-13aa-44be-be5c-7a337b7cfc6a"), "G.46.36", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("fbcabafa-da72-456a-98a9-74d3753292e2"), "G.46.38", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("9adbaa0a-4ffd-4a02-8bfd-60abea42a822"), "G.46.39", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("ce84a46c-a12f-4f50-8930-2a24f1720f81"), "G.46.4", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of household goods" },
                    { new Guid("090f55eb-270c-4f25-8ee2-0123dd0860a7"), "G.46.41", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of textiles" },
                    { new Guid("21821ad6-50d6-42f8-825e-125594599af4"), "G.46.42", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of clothing and footwear" },
                    { new Guid("0043bf33-3c4b-407c-9ad4-1f97a6798330"), "G.46.43", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of electrical household appliances" },
                    { new Guid("4305a8f9-2276-4753-a6ea-7536de1a658b"), "G.46.44", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("4be54303-0454-4dc0-aeb2-a090307c453c"), "G.46.45", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of perfume and cosmetics" },
                    { new Guid("8967498e-30aa-4656-a93f-27c9b2d224f5"), "G.46.46", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of pharmaceutical goods" },
                    { new Guid("62bbc972-a223-4fcb-abe1-59e7894517bc"), "G.46.47", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("27796d9d-7100-4251-85c2-8df227388678"), "G.46.48", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of watches and jewellery" },
                    { new Guid("ed61b76b-235e-419c-ab2e-7a0d96d1ec99"), "G.46.49", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of other household goods" },
                    { new Guid("ae3d65b3-188f-4d1b-b615-59e3bf6f1c38"), "G.46.37", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("b0258243-fd92-4714-9f5b-b160ab7195d6"), "G.46.17", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("97d483db-09f2-4cab-af88-fe772f2973a4"), "G.46.16", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("49356cff-57e2-4a2f-9721-6ebb9c38d321"), "G.46.15", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("30cb1bbd-e7af-4865-87d6-6385d76985d5"), "F.43.29", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Other construction installation" },
                    { new Guid("6053539b-b1fe-4296-a45a-5de532fa9e4d"), "F.43.3", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Building completion and finishing" },
                    { new Guid("f13319da-899c-4fcf-8db9-a7b3e708fadf"), "F.43.31", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Plastering" },
                    { new Guid("992d12a9-7005-4cac-a0ca-8168d36eb0d8"), "F.43.32", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Joinery installation" },
                    { new Guid("e233f05b-e153-476a-9d06-a1ad85e44582"), "F.43.33", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Floor and wall covering" },
                    { new Guid("da7d1173-264a-4256-ac35-94f4839236f1"), "F.43.34", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Painting and glazing" },
                    { new Guid("a3046b7f-514c-48fb-b4f4-b01232366358"), "F.43.39", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Other building completion and finishing" },
                    { new Guid("d1cb8e6e-12e9-4a27-aefc-427883c58fd8"), "F.43.9", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Other specialised construction activities" },
                    { new Guid("ef822520-1278-4ab6-b1f6-2f2081dff730"), "F.43.91", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Roofing activities" },
                    { new Guid("9ee7310c-107b-475f-9947-ef5fafd3dcd0"), "F.43.99", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Other specialised construction activities n.e.c." },
                    { new Guid("b7760aa9-5733-4c0c-baf3-d5457aebc02d"), "G.45", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("16d35305-c395-43f5-a4e3-3c87c4269ea7"), "G.45.1", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Sale of motor vehicles" },
                    { new Guid("cc583cb1-fd9b-44fd-a43d-1589534ab8aa"), "G.45.11", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Sale of cars and light motor vehicles" },
                    { new Guid("05caaa40-6156-45c3-a302-7e1204c3427e"), "G.45.19", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Sale of other motor vehicles" },
                    { new Guid("2ac11e23-53f7-42c5-8a23-499d201096b8"), "G.45.2", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("8749be64-51d9-4303-9e98-c4f47fe19ca1"), "G.45.20", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Maintenance and repair of motor vehicles" },
                    { new Guid("edc473aa-a6a6-4d80-ba41-b2fc41b66c1d"), "G.45.3", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("5141bca3-b818-4cbc-8743-2e3a08f9d87c"), "G.45.31", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("4f2baec0-f575-417b-81a8-e7e798a5a7ad"), "G.45.32", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("d78995ca-9831-4976-8383-c2f945d0ec31"), "G.45.4", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("94e5967b-001c-4eab-9486-b1b48afa10b2"), "G.45.40", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("f80a8b34-7d75-450d-b3c8-a5726cf6ce6f"), "G.46", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("e976e20f-d849-4295-9ffa-2d5a52285210"), "G.46.1", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale on a fee or contract basis" },
                    { new Guid("642d3cfe-1520-45fb-8956-222f4b777a2a"), "G.46.11", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("9b26c080-7bf8-49db-a11e-d1a17d3ce6c4"), "G.46.12", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("182e520a-7d3c-47d6-b887-8f8d35386a43"), "G.46.13", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("7ff5e642-739e-43f6-98c9-1000ff911305"), "G.46.14", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("7e848a37-2b59-4de5-888c-f33139b06251"), "G.46.5", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of information and communication equipment" },
                    { new Guid("fd5c8591-2e47-4f3c-a7a7-f0b56f3af271"), "G.47.81", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("95811f26-f529-4605-b2f6-e3748ff900c4"), "G.46.51", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("31847d9f-3601-4843-a4c4-2f6b8ca7b5ab"), "G.46.6", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("ecf93540-9f91-478d-8cdb-46be6b7c3e3b"), "G.47.4", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("62d1625f-f4ec-4cf8-ab7a-b0e277d9f0f6"), "G.47.41", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("a95b1a77-ead2-4924-adab-6f102d1e0b1e"), "G.47.42", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("60496d92-13c3-4ad7-a557-376d6fd49640"), "G.47.43", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("4ca65dfd-d411-4df8-b321-0af9d0d8b780"), "G.47.5", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("85692a85-1ae2-4ee8-9f5c-ef4d34ae825a"), "G.47.51", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of textiles in specialised stores" },
                    { new Guid("47ffbcad-6f77-43e0-9848-7145b72fb0d0"), "G.47.52", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("dac86ffb-26fe-47b8-acc1-e3769e58fc18"), "G.47.53", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("53c5bc41-8c33-4028-a3c6-414db3696ebb"), "G.47.54", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("d7ab0bb7-23d7-4e1c-bead-6d28557e5933"), "G.47.59", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("e86f5f7a-18ad-47d3-8782-4122554e6b0a"), "G.47.6", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("9efa3d0c-2fde-46ca-baf0-e45b677b6053"), "G.47.61", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of books in specialised stores" },
                    { new Guid("4763c27c-0b8f-4caf-8d36-7514dcdc51db"), "G.47.30", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("edcd6cbf-88ef-47c4-a355-9cd5238ba2e8"), "G.47.62", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("cfae9f41-7360-482c-ab01-23d47fe08af7"), "G.47.64", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("5d8fed00-b4b3-4396-9568-a74f3d3e3e3a"), "G.47.65", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("2e2603bc-cbfb-44aa-8537-e2f6b65bd16b"), "G.47.7", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of other goods in specialised stores" },
                    { new Guid("118a864c-0e6c-425c-8ccb-1a1251e5ecf1"), "G.47.71", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of clothing in specialised stores" },
                    { new Guid("53df7dfa-cb1f-4809-93fa-6a97c1e261cb"), "G.47.72", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("4509a4ca-3eb7-4867-a195-7c5efbd3105e"), "G.47.73", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Dispensing chemist in specialised stores" },
                    { new Guid("0235937d-e06f-457f-b87d-cea2be3345a7"), "G.47.74", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("f9df80df-15a0-4841-a969-a2b5c9e42354"), "G.47.75", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("17bb72d1-05a0-4712-965c-19e48a27b2aa"), "G.47.76", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("e5105250-62bf-4d50-aa94-571908e776c9"), "G.47.77", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("80bb6062-1abe-4304-8003-d981df90c7ef"), "G.47.78", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("f5e446ed-1eaf-4f79-b17f-e07ec72440af"), "G.47.79", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("851cb61c-1660-4a30-aca5-9f3145f49fdc"), "G.47.63", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("9fd4935c-7243-4d0b-a9f1-56a54a987ca6"), "G.47.3", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("51e582df-b3bd-4732-aabf-b1adbd838de7"), "G.47.29", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Other retail sale of food in specialised stores" },
                    { new Guid("df94e87e-bad1-4448-b41a-a40c5588cb36"), "G.47.26", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("4d41311f-2dfd-4318-8189-bde7cee104a6"), "G.46.61", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("536d6df4-165f-47be-84ac-1a1271d7cef5"), "G.46.62", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of machine tools" },
                    { new Guid("9e1862ae-cd15-4818-91cb-d5567fd39271"), "G.46.63", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("76992001-8cdb-479d-87a5-114dbbf9881b"), "G.46.64", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("4ae6c06e-2c8c-43cb-ba3b-320020e29d8b"), "G.46.65", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of office furniture" },
                    { new Guid("cd5f9f7a-5dc1-407b-bd19-d5db3d6dc650"), "G.46.66", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of other office machinery and equipment" },
                    { new Guid("3c15dcb1-c88d-480f-b0c6-bf8173b2a1b2"), "G.46.69", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of other machinery and equipment" },
                    { new Guid("e7a6da66-7178-4430-ac34-5b5e25506b95"), "G.46.7", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Other specialised wholesale" },
                    { new Guid("41eb5167-672f-4e23-8c66-a23e7d36b984"), "G.46.71", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("2ac724d2-3dcb-49ca-b6a1-f5389818c92c"), "G.46.72", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of metals and metal ores" },
                    { new Guid("a1ce34f7-d154-4b29-9c60-72f46c1e8f9e"), "G.46.73", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("35a7bcbf-a53d-49ed-8880-957c82c7eec2"), "G.46.74", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("1e6de08d-3911-4dc2-b754-903b3074ad28"), "G.46.75", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of chemical products" },
                    { new Guid("4eb3c9cf-bf18-4106-8798-266897ef8a96"), "G.46.76", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of other intermediate products" },
                    { new Guid("3dbf1a41-3478-4322-86a6-2be6156d453d"), "G.46.77", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of waste and scrap" },
                    { new Guid("f2425c7a-319c-4d6c-8c1d-645b8b17c847"), "G.46.9", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Non-specialised wholesale trade" },
                    { new Guid("6f23f3dc-4e1a-408b-8681-d3baaad49b3b"), "G.46.90", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Non-specialised wholesale trade" },
                    { new Guid("9f7959e1-3f7e-433e-924a-f77c187eab81"), "G.47", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("dd8e2f3e-4d3b-45fa-a9fa-e42efe31efa4"), "G.47.1", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale in non-specialised stores" },
                    { new Guid("2f6608c2-8937-4abd-a71a-6662a7e69730"), "G.47.11", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("c872c442-e26b-4f8e-bd0c-614fc0b2b186"), "G.47.19", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Other retail sale in non-specialised stores" },
                    { new Guid("c54dde30-0875-4694-8de0-09d4a7b43e84"), "G.47.2", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("27529213-be4a-4214-a77e-09c3060b6887"), "G.47.21", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("618f43b0-db86-4ffb-bf10-ee546787e32c"), "G.47.22", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("0d8ded01-5606-4521-bc7c-60861aa42993"), "G.47.23", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("ac6a9c8a-33a6-481b-856e-65bd335a490e"), "G.47.24", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("db7e3265-f614-4ff9-b133-01d4a7014e88"), "G.47.25", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Retail sale of beverages in specialised stores" },
                    { new Guid("47f63b19-10c9-43c5-9b64-856c76ba0c98"), "G.46.52", new Guid("3fc4b9c8-f0c9-40fc-86dc-e8615d9e79e3"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("91e01069-8fb1-4ced-af38-0452f6afcd41"), "F.43.22", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("ff1bfb66-67ca-4fba-9a3f-fbede6bc310b"), "K.64.99", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("8e4c30be-e632-4d9d-8db2-36749eff007c"), "K.65.1", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Insurance" },
                    { new Guid("6cbeba23-f8b6-47a1-a512-43b663fc216b"), "P.85.6", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Educational support activities" },
                    { new Guid("7a471ddb-e718-4c27-8ef4-da405582b2a0"), "P.85.60", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Educational support activities" },
                    { new Guid("2be7220b-d64d-4ac9-9a83-374044d663be"), "Q.86", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Human health activities" },
                    { new Guid("3e30604e-92e5-4e62-b741-df2942639b19"), "Q.86.1", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Hospital activities" },
                    { new Guid("ac42f7a8-f1c9-42f1-8c59-b13a06b526aa"), "Q.86.10", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Hospital activities" },
                    { new Guid("033f33b7-40c2-4f50-a2e9-b94808ad976b"), "Q.86.2", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Medical and dental practice activities" },
                    { new Guid("a981e076-041c-4d5d-a0ac-409abafb2820"), "Q.86.21", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("adbf54f5-b59c-467d-9e6e-8f3e39e4f6ff"), "Q.86.22", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Specialist medical practice activities" },
                    { new Guid("bac4a3c1-f815-4658-aa03-f95bae031701"), "Q.86.23", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Dental practice activities" },
                    { new Guid("62ce4082-0a7e-4bff-b86c-039f74c05229"), "Q.86.9", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Other human health activities" },
                    { new Guid("f7a55d05-2c0d-4401-a984-5fc1a0a3147c"), "Q.86.90", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Other human health activities" },
                    { new Guid("5bf790b6-8bc2-43e6-8703-a9231c656450"), "Q.87", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential care activities" },
                    { new Guid("f069c984-bdfc-4849-b59e-12e10475e6ca"), "P.85.59", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Other education n.e.c." },
                    { new Guid("6009a11d-c34d-4ec1-8b27-cb57a47b08a8"), "Q.87.1", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential nursing care activities" },
                    { new Guid("3f471585-ed60-4eec-97af-685f09d06c44"), "Q.87.2", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("0a634b96-979b-4a55-a72a-e6455b712ffa"), "Q.87.20", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("58fa1990-4b95-46e8-8a7c-ceccb874158c"), "Q.87.3", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential care activities for the elderly and disabled" },
                    { new Guid("c5d3a35f-69b7-423c-be1c-946cc57ac1d9"), "Q.87.30", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential care activities for the elderly and disabled" },
                    { new Guid("e5ed061d-8eb6-4084-b35b-f94dc4b92aad"), "Q.87.9", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Other residential care activities" },
                    { new Guid("20a1898e-f420-4e55-9d5c-a4a19845e6e4"), "Q.87.90", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Other residential care activities" },
                    { new Guid("6c353a1f-2bd8-44a5-aea0-d97854b92f00"), "Q.88", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Social work activities without accommodation" },
                    { new Guid("b4e65efa-a42e-41d9-ac31-de960b556c2d"), "Q.88.1", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("c666528d-7c56-45ae-b8ed-3bf8e3fecabd"), "Q.88.10", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("6674adb7-feba-42f9-b2ed-d360bf74e615"), "Q.88.9", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Other social work activities without accommodation" },
                    { new Guid("aa605bcd-303b-424f-8b5b-a01d1ba057cc"), "Q.88.91", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Child day-care activities" },
                    { new Guid("ecd1d88d-077d-4eb1-936e-3d3db65a7d89"), "Q.88.99", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("31492bd0-48ad-4757-a118-c3bb49d813d8"), "Q.87.10", new Guid("f2466e80-e7ac-4eff-a4da-815e827f6f5d"), "Residential nursing care activities" },
                    { new Guid("c239e3ad-73d8-45f7-acf2-8c8376888180"), "P.85.53", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Driving school activities" },
                    { new Guid("50ad612d-c2fb-4463-9ef3-f8b7b2a370e6"), "P.85.52", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Cultural education" },
                    { new Guid("015720eb-611e-4319-a78e-8e1d39d78dfb"), "P.85.51", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Sports and recreation education" },
                    { new Guid("5f6aba7e-901e-4fbc-9abb-d0bf6d3caa45"), "N.82.91", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Packaging activities" },
                    { new Guid("6d1ee3b8-1050-4b0c-8dd9-80bba66e3006"), "N.82.99", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other business support service activities n.e.c." },
                    { new Guid("0a5f13e0-716b-447d-87c5-5c3a1080b702"), "O.84", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Public administration and defence; compulsory social security" },
                    { new Guid("491c34f3-3f06-4606-b9cc-857003b5d64b"), "O.84.1", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("47ac7bf0-2035-4cec-94b1-314e1b423d7b"), "O.84.11", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "General public administration activities" },
                    { new Guid("a621fe9a-71a3-46a8-9fca-013c4154e8d3"), "O.84.12", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("00277e12-a646-452c-b9fc-7e5ac72aa3ca"), "O.84.13", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("0ebe53d7-0516-4c59-baac-081f4a34225c"), "O.84.2", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Provision of services to the community as a whole" },
                    { new Guid("908ebf50-3a51-4b70-a4ff-2787071450ef"), "O.84.21", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Foreign affairs" },
                    { new Guid("2f4e0314-058a-4fdb-b6d2-64986b996ddd"), "O.84.22", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Defence activities" },
                    { new Guid("ee1a874e-e87a-44d3-a0b9-66c6385f9102"), "O.84.23", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Justice and judicial activities" },
                    { new Guid("d105d75d-2761-4ae3-b746-793902aa7581"), "O.84.24", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Public order and safety activities" },
                    { new Guid("f9714e56-7c90-44d4-95b1-d3c8bae572cc"), "O.84.25", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Fire service activities" },
                    { new Guid("c91e484a-b152-44f6-9863-b565471cf840"), "O.84.3", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Compulsory social security activities" },
                    { new Guid("520a7657-9caf-4ad8-b31d-25a661d6d69c"), "O.84.30", new Guid("0c036429-272e-46d6-91f0-41d11b7e1458"), "Compulsory social security activities" },
                    { new Guid("d1fe6b70-6626-410b-b85d-c1e0cef3bc05"), "P.85", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Education" },
                    { new Guid("4c9a1f8b-c019-4d4a-81ec-b382696aa4d5"), "P.85.1", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Pre-primary education" },
                    { new Guid("884aaf2f-9f54-4981-9835-c6b8a4e43386"), "P.85.10", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Pre-primary education" },
                    { new Guid("4bfdb86a-480f-4787-97fc-babf95bb5b1a"), "P.85.2", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6c09565b-44ae-4097-8ca1-bcbce8077193"), "P.85.20", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Primary education" },
                    { new Guid("38b998e3-5b66-4a9b-bf8e-82bd3c6093ce"), "P.85.3", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Secondary education" },
                    { new Guid("86e47293-43eb-485e-9eda-c297277ee217"), "P.85.31", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "General secondary education" },
                    { new Guid("88db9319-0851-42f9-ad1d-36b10680f716"), "P.85.32", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Technical and vocational secondary education" },
                    { new Guid("4149fa4f-1779-48f6-976a-b3f0ac914656"), "P.85.4", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Higher education" },
                    { new Guid("31e78bb1-b67a-4e31-8426-246fa63986ad"), "P.85.41", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Post-secondary non-tertiary education" },
                    { new Guid("9d42ab94-c9fd-496b-a4d8-673f507e7152"), "P.85.42", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Tertiary education" },
                    { new Guid("7044d339-d559-4e27-b3c6-eb43a73b5d3a"), "P.85.5", new Guid("8e3ca402-a041-4258-aefa-3e4fef3b119e"), "Other education" },
                    { new Guid("47f0f529-36b6-49c1-8223-b3ebebb27840"), "R.90", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Creative, arts and entertainment activities" },
                    { new Guid("4d00cc66-5de6-4188-9c80-095a8a428e06"), "N.82.92", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("a848957c-250f-4df6-befe-43e5d42090f8"), "R.90.0", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Creative, arts and entertainment activities" },
                    { new Guid("9b90f57f-52ed-4992-89fb-26a1a20ac21f"), "R.90.02", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Support activities to performing arts" },
                    { new Guid("8b635091-2720-4e59-be0a-309fa8b1565d"), "S.95.1", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of computers and communication equipment" },
                    { new Guid("9bab6b5d-e7a2-4e2c-9d6e-eeae7f09be56"), "S.95.11", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of computers and peripheral equipment" },
                    { new Guid("92026674-7bef-47d4-a017-81f1f4e52f99"), "S.95.12", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of communication equipment" },
                    { new Guid("a4e01ff4-6cf5-42e3-944d-0138ff377bce"), "S.95.2", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of personal and household goods" },
                    { new Guid("884b6fed-3497-4b22-85c0-2bb964aa8266"), "S.95.21", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of consumer electronics" },
                    { new Guid("7c7a4cfe-706a-4cd3-91a9-a0779a7dd03a"), "S.95.22", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("04403eb2-b369-45fb-86a5-78418ee3ef04"), "S.95.23", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of footwear and leather goods" },
                    { new Guid("5fef7bac-aecc-4d26-8ea0-85b850284b23"), "S.95.24", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of furniture and home furnishings" },
                    { new Guid("9cda7736-23ce-49bf-8af1-5daacd840cd7"), "S.95.25", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of watches, clocks and jewellery" },
                    { new Guid("fd71d16c-4a16-4104-a555-72a5f246a4ae"), "S.95.29", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of other personal and household goods" },
                    { new Guid("f6a46a83-36d0-4c08-9240-3fa3895e5343"), "S.96", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Other personal service activities" },
                    { new Guid("8a15085b-c4e8-488c-bfc2-82e58f415292"), "S.96.0", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Other personal service activities" },
                    { new Guid("bf164740-b645-478e-844a-58db7db67243"), "S.95", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Repair of computers and personal and household goods" },
                    { new Guid("bcb2d263-58db-469b-a4bf-1ce4f6ef03a9"), "S.96.01", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("497007d6-dc8f-44ce-ab71-00b42a7c033a"), "S.96.03", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Funeral and related activities" },
                    { new Guid("c24d1981-317c-4de9-87cc-8d0ef8f45da5"), "S.96.04", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Physical well-being activities" },
                    { new Guid("6736b5b0-7bae-4015-a7d0-612bbaaa6ced"), "S.96.09", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Other personal service activities n.e.c." },
                    { new Guid("b26592ea-0c1e-4f4d-84af-22efacda9995"), "T.97", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Activities of households as employers of domestic personnel" },
                    { new Guid("9506de60-bb6c-4aa3-b14f-410fa161e0cd"), "T.97.0", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Activities of households as employers of domestic personnel" },
                    { new Guid("fd5e78c7-fe73-4403-b175-0ff6d1e3a5dc"), "T.97.00", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Activities of households as employers of domestic personnel" },
                    { new Guid("f04ce225-a8b2-4120-b4ff-15fba191cdb0"), "T.98", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("0919b362-361e-479a-97ef-0eb37b8c6d98"), "T.98.1", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("ba196077-6558-422d-82cc-575351d347ae"), "T.98.10", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("05ac33be-66ca-4e69-a935-9f1f652e58b3"), "T.98.2", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("2bb143ca-4536-437b-b76a-32de24cb9eb1"), "T.98.20", new Guid("c3110f80-40ff-4e8b-b86c-06007b35eeba"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("585fa95f-9b21-42c0-a4db-0e8d526360c5"), "U.99", new Guid("7a4af031-9636-4228-8ad9-d1a49a7c9e17"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("a9403ae2-598e-48c1-b2a4-fb69af772ec6"), "S.96.02", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Hairdressing and other beauty treatment" },
                    { new Guid("9b224def-9405-4480-b21a-1ffefdbe8e26"), "S.94.99", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of other membership organisations n.e.c." },
                    { new Guid("e8ff7962-a09b-4029-a12f-16d81ece8c43"), "S.94.92", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of political organisations" },
                    { new Guid("5a36c5e8-3768-44b5-99e0-1216377d27ed"), "S.94.91", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7f87d3ad-9dfc-4b38-8150-04eb6705ec9a"), "R.90.03", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Artistic creation" },
                    { new Guid("6a67e919-e85c-40cf-b897-d5f8fc42a4e3"), "R.90.04", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Operation of arts facilities" },
                    { new Guid("4ae7d2a1-aa23-40ac-9bff-85ceeedc550c"), "R.91", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("bc49e05f-7e44-4a9e-93d0-ed162ceac4d3"), "R.91.0", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("79aa9013-11fb-4010-bf8c-bf6b65a62d21"), "R.91.01", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Library and archives activities" },
                    { new Guid("d21e664c-a0c8-4e06-88a9-ea1ecc4b5654"), "R.91.02", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Museums activities" },
                    { new Guid("570e0f4d-10e8-4845-8a1d-8a8c2bc526ee"), "R.91.03", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("caac6a40-2599-4786-b504-86c23cb68f2b"), "R.91.04", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("330c57ec-2057-4329-8686-b90d781ea26f"), "R.92", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Gambling and betting activities" },
                    { new Guid("1bd7c358-2777-4cdd-a7c8-36e367473ebe"), "R.92.0", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Gambling and betting activities" },
                    { new Guid("9fd28f88-4cd4-49e1-8131-5bb8fe81bbc0"), "R.92.00", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Gambling and betting activities" },
                    { new Guid("74b15c2b-e1cc-4777-a31e-8d0be1690912"), "R.93", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Sports activities and amusement and recreation activities" },
                    { new Guid("f3e83d94-f491-4dce-a191-51e11ed7eeba"), "R.93.1", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Sports activities" },
                    { new Guid("14e39d6e-3779-4d68-9548-0935f5aa5682"), "R.93.11", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Operation of sports facilities" },
                    { new Guid("45b7f701-cdeb-435b-abcf-238d6181c08a"), "R.93.12", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Activities of sport clubs" },
                    { new Guid("9e20d692-be28-438c-bd22-a5b4e56200ee"), "R.93.13", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Fitness facilities" },
                    { new Guid("a429b6fe-7177-441c-8c88-fd97ce0020ba"), "R.93.19", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Other sports activities" },
                    { new Guid("31920333-45f6-4fd1-b4b1-61ac33487402"), "R.93.2", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Amusement and recreation activities" },
                    { new Guid("0dd51f6c-855f-4855-882f-ba7ee3bf5fe6"), "R.93.21", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Activities of amusement parks and theme parks" },
                    { new Guid("43ad1194-5bba-4f45-92f5-71edf81f42cb"), "R.93.29", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Other amusement and recreation activities" },
                    { new Guid("f1a76b31-b66c-43c7-93b6-b57cfdd6701b"), "S.94", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of membership organisations" },
                    { new Guid("19e15d9d-da74-4b46-8125-fa066b50733f"), "S.94.1", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("5d23cc20-3cba-4e91-a871-740940e0eeb8"), "S.94.11", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of business and employers membership organisations" },
                    { new Guid("7e8d3c00-ee19-4798-afab-70c503af4ee2"), "S.94.12", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of professional membership organisations" },
                    { new Guid("b48cec72-8703-43c5-8f8e-d9c1fbea5f24"), "S.94.2", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of trade unions" },
                    { new Guid("a8a4ed15-d565-4cc0-a86a-b34c5b0db198"), "S.94.20", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of trade unions" },
                    { new Guid("d318000c-da5f-4593-9c4b-dd0b89b8cfec"), "S.94.9", new Guid("e4e92ee0-f210-4781-a250-0af68b091e3e"), "Activities of other membership organisations" },
                    { new Guid("c2e22481-ce51-4acc-84a4-9e5dfa140047"), "R.90.01", new Guid("acf28872-a875-45f2-a0b4-b700b0ae5050"), "Performing arts" },
                    { new Guid("cb8087c9-0691-4a00-afb1-fad874f0daf7"), "K.65", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("6f496574-e248-4304-9e0b-e0ec54686410"), "N.82.9", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Business support service activities n.e.c." },
                    { new Guid("6ebed98d-00e7-4ce7-952d-0eb6aa8d89de"), "N.82.3", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Organisation of conventions and trade shows" },
                    { new Guid("1827087f-65a5-4ffb-933a-940391a1b738"), "M.70.1", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Activities of head offices" },
                    { new Guid("6e8d43f7-3e98-4db6-863e-611bf888baf7"), "M.70.10", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Activities of head offices" },
                    { new Guid("b3ebdb34-d2fb-4fd9-a306-d755929371a7"), "M.70.2", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Management consultancy activities" },
                    { new Guid("b6145e87-f9d7-4e08-9ac9-02e180cbd840"), "M.70.21", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Public relations and communication activities" },
                    { new Guid("bf03984b-5d47-4d24-9f3b-71dce4a9538a"), "M.70.22", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Business and other management consultancy activities" },
                    { new Guid("59ad73c7-7cdd-46ec-9009-50abb31d57b7"), "M.71", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("045de04d-b5ca-4047-924b-cdc682d88c34"), "M.71.1", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("322f6699-3973-4cd2-b5b3-9885ec346845"), "M.71.11", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Architectural activities" },
                    { new Guid("f190b9ae-418a-4bb5-a09b-834441f026bc"), "M.71.12", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Engineering activities and related technical consultancy" },
                    { new Guid("634109e4-5f17-4695-8de9-d370563cb70b"), "M.71.2", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Technical testing and analysis" },
                    { new Guid("e40096d9-d208-4c3a-8841-325aea24c2b7"), "M.71.20", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bfbca4fd-36dc-4790-8d00-cae1342046da"), "M.72", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Scientific research and development" },
                    { new Guid("6108658c-13de-49e8-993f-3e4c4f932f65"), "M.70", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Activities of head offices; management consultancy activities" },
                    { new Guid("2744e878-aa1f-4e52-ad3f-75e9b4dfa5c5"), "M.72.1", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("d7aaa36f-882d-4590-a00c-93aad592bca9"), "M.72.19", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("bbb20bdb-a527-4548-a2ca-d9690e1d3be8"), "M.72.2", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("09a6288f-0220-4bb0-96f9-e7a53bd76b6e"), "M.72.20", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("e6bbcf56-72aa-4f57-91f1-ef88d5b47dac"), "M.73", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Advertising and market research" },
                    { new Guid("3f48cdfc-409a-4de5-9c94-e134c5bd570f"), "M.73.1", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Advertising" },
                    { new Guid("99dce383-569b-4756-9109-24f535aaab6c"), "M.73.11", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Advertising agencies" },
                    { new Guid("8ecd2301-3731-4cb6-b791-4ff6f55cf17d"), "M.73.12", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Media representation" },
                    { new Guid("309b8850-b9b9-4ba6-a0bf-ff31d59a7b87"), "M.73.2", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Market research and public opinion polling" },
                    { new Guid("2d94e6bf-b6df-4f79-9ae6-330c6e71977b"), "M.73.20", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Market research and public opinion polling" },
                    { new Guid("3711fdeb-2c87-48ce-849a-fa3f94973e0a"), "M.74", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Other professional, scientific and technical activities" },
                    { new Guid("b40a984f-393f-4b98-99a5-32e1a0e87a21"), "M.74.1", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Specialised design activities" },
                    { new Guid("6d31286b-455e-4a13-8525-74926a4bf068"), "M.74.10", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Specialised design activities" },
                    { new Guid("83ecf78c-636d-438c-9b3d-b8022dc15a3b"), "M.72.11", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Research and experimental development on biotechnology" },
                    { new Guid("afb55665-79b3-4f5f-bb93-d823b3c1c6ce"), "M.69.20", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("3854618e-6fd2-42ec-bc47-eb36762d948f"), "M.69.2", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("dbdb975f-4257-4c32-b527-34139d99c509"), "M.69.10", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Legal activities" },
                    { new Guid("a9c7944f-604a-4315-930f-dc48c75a9aae"), "K.65.11", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Life insurance" },
                    { new Guid("09577801-c6e4-4ba0-a2a8-0654f0d4bdd5"), "K.65.12", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Non-life insurance" },
                    { new Guid("9a2e0564-255e-4bfa-85ce-f9ce43a755b7"), "K.65.2", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Reinsurance" },
                    { new Guid("88f4e09e-5a6e-43e8-9982-68c1e1193da6"), "K.65.20", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Reinsurance" },
                    { new Guid("74e275ec-2e21-44fd-92cf-e6845c7e57e8"), "K.65.3", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Pension funding" },
                    { new Guid("1add7653-40ea-4e77-b31b-f588443df1c0"), "K.65.30", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Pension funding" },
                    { new Guid("133f1556-1868-44ad-9763-36bfa9a68572"), "K.66", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("8007715e-69a6-452f-9511-a98e6f7da903"), "K.66.1", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("f8c22a9d-ce48-49e8-a86e-798dbb6ec61e"), "K.66.11", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Administration of financial markets" },
                    { new Guid("6d66acf6-e2a0-4d31-9259-03ac2cb7d096"), "K.66.12", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Security and commodity contracts brokerage" },
                    { new Guid("0a357463-493a-44ba-bcef-8ced4eafc88a"), "K.66.19", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("e3bf6959-1c7c-4ef4-befa-6c4f859906d0"), "K.66.2", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("9b483203-bbdb-4d6a-ba01-f546a1f1707a"), "K.66.21", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Risk and damage evaluation" },
                    { new Guid("7308a857-3ce4-479d-bc29-86878ee2cbb3"), "K.66.22", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Activities of insurance agents and brokers" },
                    { new Guid("dd3172cf-7686-4b5d-bde7-799d329f052f"), "K.66.29", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("277fe32f-256a-4ee4-a439-75521753bc61"), "K.66.3", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Fund management activities" },
                    { new Guid("9067e6e2-8b90-4c5b-8092-e06bf0d2415b"), "K.66.30", new Guid("966a83bc-35db-46d9-9c1c-a41328024a87"), "Fund management activities" },
                    { new Guid("9e0e9d4d-3b6f-41d8-a6b3-9b70e0d4b4dc"), "L.68", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Real estate activities" },
                    { new Guid("92b1ce6c-6dd8-4f93-99be-7566a858cf59"), "L.68.1", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Buying and selling of own real estate" },
                    { new Guid("ca1c6a55-c315-4a74-97f5-da842d6b9ff2"), "L.68.10", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Buying and selling of own real estate" },
                    { new Guid("7cc79414-c4c6-4903-becf-9a3acaac0248"), "L.68.2", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Renting and operating of own or leased real estate" },
                    { new Guid("0021406f-87f3-4398-86ae-1df87c2dcf87"), "L.68.20", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Renting and operating of own or leased real estate" },
                    { new Guid("edc8dce0-579d-48f0-b47a-acce07485f63"), "L.68.3", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5507def9-06e4-4c09-a6bd-9539a9b30d5a"), "L.68.31", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Real estate agencies" },
                    { new Guid("e6d37fd2-16bc-4142-be75-60a9a01cb3f4"), "L.68.32", new Guid("6312da2a-5cb2-42a2-a16c-2c16cdacd11e"), "Management of real estate on a fee or contract basis" },
                    { new Guid("d7c1cd37-f3c7-4910-9a4a-e31d661261b1"), "M.69", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Legal and accounting activities" },
                    { new Guid("60722829-ffb1-4a2e-8ed1-9e1fc4f0bce1"), "M.69.1", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Legal activities" },
                    { new Guid("1c78f2c4-a2cd-4db3-bea1-e2ba42c3acc8"), "M.74.2", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Photographic activities" },
                    { new Guid("6f551f5e-0479-4896-b51f-3f0e8624ab83"), "N.82.30", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Organisation of conventions and trade shows" },
                    { new Guid("636fb614-a8da-43e5-9527-027148eb22da"), "M.74.20", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Photographic activities" },
                    { new Guid("bc2370f6-b9e5-4c73-8950-a0ec113f6074"), "M.74.30", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Translation and interpretation activities" },
                    { new Guid("743f94b0-a2a2-4301-92e5-a509123e4d63"), "N.79.11", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Travel agency activities" },
                    { new Guid("2414f2c2-edf1-4c7f-9962-dddcd7da5e6a"), "N.79.12", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Tour operator activities" },
                    { new Guid("6783c70c-d158-47f3-801a-c8d649149397"), "N.79.9", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other reservation service and related activities" },
                    { new Guid("189f7779-1947-4020-9223-743a05a02b85"), "N.79.90", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other reservation service and related activities" },
                    { new Guid("eb4fc517-5220-4d49-bda1-d37e3d1c89ed"), "N.80", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Security and investigation activities" },
                    { new Guid("4a4c14bc-b3dc-4f6a-97de-0c1826d5eb1d"), "N.80.1", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Private security activities" },
                    { new Guid("72672772-5444-4253-a54c-e13b4e18c123"), "N.80.10", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Private security activities" },
                    { new Guid("a30ab294-2fb8-4e4d-b0b6-5eb5e1deefa4"), "N.80.2", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Security systems service activities" },
                    { new Guid("694f5342-fb61-407c-ac34-91f62bbe6788"), "N.80.20", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Security systems service activities" },
                    { new Guid("06255fe3-01ff-4dd2-9f84-f781ce25f450"), "N.80.3", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Investigation activities" },
                    { new Guid("005cfc76-afcb-4e07-b3c7-5931f1c45e84"), "N.80.30", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Investigation activities" },
                    { new Guid("8eadf58a-0487-46a5-bed3-40894f20248d"), "N.81", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Services to buildings and landscape activities" },
                    { new Guid("ea8953f4-32b0-40f2-a2b5-9fc9fa789f1e"), "N.79.1", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Travel agency and tour operator activities" },
                    { new Guid("782718e7-3570-4d4a-95c7-159167b337e9"), "N.81.1", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Combined facilities support activities" },
                    { new Guid("6b1297f7-d805-4708-94f6-5503f36cc386"), "N.81.2", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Cleaning activities" },
                    { new Guid("959237e7-45a1-4a4d-ad01-4f5e1ca4e2e8"), "N.81.21", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "General cleaning of buildings" },
                    { new Guid("8cc5316f-fb39-42b9-aee2-35a048e7387d"), "N.81.22", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other building and industrial cleaning activities" },
                    { new Guid("58e2546f-289c-482a-a9c9-90482b51249e"), "N.81.29", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other cleaning activities" },
                    { new Guid("45310ea8-1184-4000-b1d0-6fa782bcff7c"), "N.81.3", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Landscape service activities" },
                    { new Guid("823d3fa2-d883-4610-a706-3e2896a227bb"), "N.81.30", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Landscape service activities" },
                    { new Guid("3825094c-7340-4612-9279-86bf22798c63"), "N.82", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Office administrative, office support and other business support activities" },
                    { new Guid("367b0412-8c1a-4bd5-9b70-1e7c30332b8f"), "N.82.1", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Office administrative and support activities" },
                    { new Guid("8d4e3931-8076-4b4e-a45a-853c8f5875a1"), "N.82.11", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Combined office administrative service activities" },
                    { new Guid("ee5acfcb-c480-44cf-8454-f634c91536e9"), "N.82.19", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("2b4a2673-efe4-4444-a163-7e02bc131f7e"), "N.82.2", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Activities of call centres" },
                    { new Guid("e5c6c1d4-b787-45fd-a698-1131926b6e58"), "N.82.20", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Activities of call centres" },
                    { new Guid("63556928-b95b-472c-81e8-f23e42b7e740"), "N.81.10", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Combined facilities support activities" },
                    { new Guid("c32ff32c-05b5-46b0-8620-ac8859f41715"), "N.79", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("44db55b7-9a76-4ffd-a898-6091bcc5c3bf"), "N.78.30", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other human resources provision" },
                    { new Guid("73bae355-ee94-440f-8e98-b7589593939a"), "N.78.3", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Other human resources provision" },
                    { new Guid("d5159ab3-a127-451d-9f48-d1c2ababadbe"), "M.74.9", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("1002e5ed-3eb3-4a77-9395-b50507a513ad"), "M.74.90", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("f1292347-647c-4bcb-afc7-dc05f019e6a3"), "M.75", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Veterinary activities" },
                    { new Guid("3a7c29af-f25f-436f-b26d-48a79179d25e"), "M.75.0", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fcb8ecac-ad37-43f1-9c86-dd39b63c145a"), "M.75.00", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Veterinary activities" },
                    { new Guid("3b34ae93-b9c3-4a25-af6e-add1a3f98d2d"), "N.77", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Rental and leasing activities" },
                    { new Guid("9cf5912b-b284-4df3-9f37-7e99ecbe6d70"), "N.77.1", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of motor vehicles" },
                    { new Guid("2cb444d9-5135-4f5d-9056-fd38b7a4f4d8"), "N.77.11", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("753bf024-95ca-4010-bb1c-09096933e9f5"), "N.77.12", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of trucks" },
                    { new Guid("db176d63-e804-4916-934f-a64a895e7725"), "N.77.2", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of personal and household goods" },
                    { new Guid("74f2a35f-71e0-4136-a2bf-2634b1f44b8a"), "N.77.21", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("5b18ad0e-5f0f-431c-9364-022a8396a4ee"), "N.77.22", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting of video tapes and disks" },
                    { new Guid("a09f27c0-bf42-482e-9d01-924335be59ad"), "N.77.29", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of other personal and household goods" },
                    { new Guid("772bc44a-7861-4ec2-8612-869834b6dc00"), "N.77.3", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("542adb50-539a-4185-ab1a-655d263e294e"), "N.77.31", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("bb8932a1-7176-42c7-9e00-9d8ae1a62dc8"), "N.77.32", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("13b12eb9-419c-4949-9a83-763e33f3a9cd"), "N.77.33", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("272380f1-f1fe-4ced-b862-8e52cd0fc74a"), "N.77.34", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of water transport equipment" },
                    { new Guid("b73c8099-fe9f-457e-8fe6-9cd7a835e31e"), "N.77.35", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of air transport equipment" },
                    { new Guid("77fa7d56-61f2-46c7-895d-1b16ab7b0d36"), "N.77.39", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("ce37a450-b5bc-458e-aaab-eef69906c524"), "N.77.4", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("4b3f2c2b-c16b-49df-ab6a-ec714330c811"), "N.77.40", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("ace07346-cfc3-409f-91f2-df5b0d900777"), "N.78", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Employment activities" },
                    { new Guid("89c07e8d-2335-41b2-90d6-910e02c02724"), "N.78.1", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Activities of employment placement agencies" },
                    { new Guid("6c1870af-b1ee-4e13-a381-3ea80265998a"), "N.78.10", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Activities of employment placement agencies" },
                    { new Guid("23ca13e9-2d6c-438d-a2e6-5e39679a914f"), "N.78.2", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Temporary employment agency activities" },
                    { new Guid("c7e316a8-4346-45f2-8f0d-7fd8a0164bd7"), "N.78.20", new Guid("461c6852-4f2e-4fab-a5ce-bb2cbc175906"), "Temporary employment agency activities" },
                    { new Guid("a65a6aa5-2b82-4d31-83e7-b4b34ccca883"), "M.74.3", new Guid("0c3388dd-fb2c-4925-ab38-427567f88a46"), "Translation and interpretation activities" },
                    { new Guid("2988fecc-7573-45e6-b19f-aca13bb4a334"), "U.99.0", new Guid("7a4af031-9636-4228-8ad9-d1a49a7c9e17"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("c92a0602-95a2-40b3-ba3e-f96f28a91358"), "F.43.21", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Electrical installation" },
                    { new Guid("edc6f787-8ca2-4513-b170-99b5c1c0b306"), "F.43.13", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Test drilling and boring" },
                    { new Guid("6698ee09-6610-41a5-a8ad-e2d3e2374435"), "C.14.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of articles of fur" },
                    { new Guid("2aa2caa0-8ae3-4614-bf91-ed998afe5712"), "C.14.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of articles of fur" },
                    { new Guid("1e0839b2-eb54-47ba-be89-560ec8a85393"), "C.14.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("19706a68-847f-4e8c-9f34-bdebb6397554"), "C.14.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("3de4c104-c48a-48a0-b499-747d40047e80"), "C.14.39", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("f9772083-4cad-4eed-9137-c5a707a40dd8"), "C.15", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of leather and related products" },
                    { new Guid("1e774366-e2ae-45d0-9cf1-8f462e27424f"), "C.15.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("07f509bc-eceb-43ec-94cc-a52833c477af"), "C.15.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("d94a29e3-64ac-4f52-ae3d-75b3781b8790"), "C.15.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("969b4f3a-0f82-4e71-bec6-cb41906b8519"), "C.15.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of footwear" },
                    { new Guid("2140659f-e785-41f1-9a1c-16818cc8dc51"), "C.15.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of footwear" },
                    { new Guid("41263eff-ef27-4b15-8a96-690ca743d7ab"), "C.16", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("d84215df-9042-47ac-a314-b1a70289599a"), "C.14.19", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("8923749d-4822-4211-880c-bd8d56ad289b"), "C.16.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Sawmilling and planing of wood" },
                    { new Guid("d0be815e-f86e-48ff-be76-e4db555cccb8"), "C.16.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("59ac3c2f-db43-4f9c-b6d2-86ab8c03c856"), "C.16.21", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("2a14ff93-b5e5-4b13-8ec0-f61d3c855b17"), "C.16.22", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of assembled parquet floors" },
                    { new Guid("1f31ca3f-9e77-40eb-811d-7f7c246168ff"), "C.16.23", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("9afa31cb-9645-46f7-b7a4-5847eec98549"), "C.16.24", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wooden containers" },
                    { new Guid("c86ae1f0-a25e-450d-a112-a5b8447d70b7"), "C.16.29", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("8b8b3a36-f4ab-4284-89bd-7443700b03c3"), "C.17", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of paper and paper products" },
                    { new Guid("3e9fe766-e538-40b5-bd0d-11e4654313bd"), "C.17.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("b06625ac-318d-4746-bdd2-f6d30f6ab0dd"), "C.17.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of pulp" },
                    { new Guid("b1824026-b6f5-4932-85e9-b0ccbe6680cb"), "C.17.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of paper and paperboard" },
                    { new Guid("23a1faab-1f69-465e-b3c4-2f6dfc9a6640"), "C.17.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("99c25c9c-e6fa-447d-a906-394e30452ad0"), "C.17.21", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("cf8524fb-223c-4565-8c4c-e719ae29d206"), "C.16.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Sawmilling and planing of wood" },
                    { new Guid("03e049b7-f687-48b0-82c7-b6cae12a21b9"), "C.14.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of underwear" },
                    { new Guid("76bb1282-2471-4e8c-a546-c99ca6720902"), "C.14.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other outerwear" },
                    { new Guid("f5f9af43-3f90-4c1a-8dbe-a3150a04d074"), "C.14.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of workwear" },
                    { new Guid("1f85b9bd-237f-4322-8082-286a3c37bff1"), "C.11.02", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wine from grape" },
                    { new Guid("dc252449-1a02-4018-908b-bbe00a1ef9ae"), "C.11.03", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cider and other fruit wines" },
                    { new Guid("31600c73-5819-4fd9-9148-1b886ece6029"), "C.11.04", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("cc7154ee-b885-44dc-95de-ca047ced4968"), "C.11.05", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of beer" },
                    { new Guid("c551b8ee-8e3e-427d-bf39-aab5e1016348"), "C.11.06", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of malt" },
                    { new Guid("be001664-59da-46bd-9c33-4500c7988161"), "C.11.07", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("27c94299-6eb8-4f83-b89b-2816b4a820c7"), "C.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tobacco products" },
                    { new Guid("8f5c2af1-1d78-46e1-b977-e5acf5c9e2c1"), "C.12.0", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tobacco products" },
                    { new Guid("83a841fb-9dcb-455a-a3e7-7661ae54b8a7"), "C.12.00", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tobacco products" },
                    { new Guid("fa6db0d1-7b3d-4089-a6dd-5360d5b1c882"), "C.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of textiles" },
                    { new Guid("b126a58e-27f1-4b31-8f42-241461284d42"), "C.13.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Preparation and spinning of textile fibres" },
                    { new Guid("f7b58e91-3533-4459-ad32-a81d384e3dca"), "C.13.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Preparation and spinning of textile fibres" },
                    { new Guid("b26dc928-b8f6-488b-a747-7b2811b1d263"), "C.13.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Weaving of textiles" },
                    { new Guid("4aabe03f-d773-45f3-ac70-31805ba87a92"), "C.13.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Weaving of textiles" },
                    { new Guid("c5c1332e-7446-4fe9-aed6-2e5aeef03af9"), "C.13.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Finishing of textiles" },
                    { new Guid("00597ac5-dd9a-462c-b105-198f5dc9ba6a"), "C.13.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Finishing of textiles" },
                    { new Guid("ced4f08d-e007-4413-bbd5-7e1669ae1a11"), "C.13.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other textiles" },
                    { new Guid("93f3b1b3-841d-48cb-a3b6-d19f842a8215"), "C.13.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("c6599274-b35e-4a38-8176-f2948dca922c"), "C.13.92", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("542e46e5-2662-4e63-bb74-9da0eb666244"), "C.13.93", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of carpets and rugs" },
                    { new Guid("cf650c26-8453-424a-8d87-477110cf19ff"), "C.13.94", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("cd53813a-45ed-4c58-a180-be884de77fa2"), "C.13.95", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("cf8ae8c4-8cf0-42dd-a3eb-bd92641650f3"), "C.13.96", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("029f1d0c-23c8-4114-afc9-de92b2f21c0b"), "C.13.99", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other textiles n.e.c." },
                    { new Guid("26877a71-29c7-434c-9c2f-1110a68a540a"), "C.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wearing apparel" },
                    { new Guid("ab27e3ff-d393-4e40-8cad-d510ed22dffb"), "C.14.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("a62f1170-498b-465d-96e4-aac013dea0ec"), "C.14.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("85729d16-67f2-480f-8f46-b548ededbc4f"), "C.17.22", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("c805acd8-3f09-4803-9e06-84259ddfc0c9"), "C.11.01", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("0049a96e-d7c4-48ea-86de-e3f1b1003a49"), "C.17.23", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of paper stationery" },
                    { new Guid("0624add3-9ef6-47af-a0f1-613f8076b961"), "C.17.29", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("f4225377-cc78-412d-ac7b-42ca464ef8f4"), "C.20.52", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of glues" },
                    { new Guid("65d5ebad-e9fe-4892-b92c-0cffb21eac2f"), "C.20.53", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of essential oils" },
                    { new Guid("73a1501a-af97-48a7-80c5-4178af82381d"), "C.20.59", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("42c718e2-1a51-4057-86ca-e5e34edbc557"), "C.20.6", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of man-made fibres" },
                    { new Guid("5887b29a-1aa8-4008-94db-d6198d62ffdf"), "C.20.60", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of man-made fibres" },
                    { new Guid("4fe3422e-c259-40b0-b5eb-68785a5605f2"), "C.21", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("969b8acb-3d29-4187-9243-afdb35749c6f"), "C.21.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("6dc0ef58-43db-4151-b776-780177d0142f"), "C.21.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("ca8ef10d-4b00-4eaa-9123-c0f178f0a4d4"), "C.21.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("55f651ff-ccbe-4c67-8792-b37cbfc85d3f"), "C.21.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("696ee2bc-d0d4-449a-b471-a08ab36d8198"), "C.22", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of rubber and plastic products" },
                    { new Guid("7d869073-321f-4997-8061-853884c3f3c0"), "C.22.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of rubber products" },
                    { new Guid("1c10ad70-9916-477f-88fa-cc26cabce70c"), "C.20.51", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of explosives" },
                    { new Guid("da9f6fa3-52b2-4fb6-89a1-ae3944418568"), "C.22.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("dba5c84e-c01c-4a78-8398-f5605864c4ed"), "C.22.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of plastics products" },
                    { new Guid("0255dc32-8a53-4d92-b570-c0b4db26687c"), "C.22.21", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("1f331c67-f40e-4878-86ed-eef80afd1b2a"), "C.22.22", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of plastic packing goods" },
                    { new Guid("67b20e3c-2018-4a57-984e-a683c15fbaaa"), "C.22.23", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("76b48597-3f73-41d3-a6f8-c4e17d170860"), "C.22.29", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other plastic products" },
                    { new Guid("6574dbac-c271-41fd-91cf-9cc8e917bfae"), "C.23", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("ee1fa9ae-bc2c-4761-a2d0-b4e2ed4eaeeb"), "C.23.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of glass and glass products" },
                    { new Guid("353bb6b6-256f-4d52-99a7-523882fe63f4"), "C.23.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of flat glass" },
                    { new Guid("aa1bb006-552a-4b33-9491-549ed40de017"), "C.23.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Shaping and processing of flat glass" },
                    { new Guid("33002392-aada-4da4-b2b7-61ae7b9313b6"), "C.23.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of hollow glass" },
                    { new Guid("5a2671fc-2cf6-4411-a9a7-ef02d5ba812c"), "C.23.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of glass fibres" },
                    { new Guid("e4030416-a433-48b9-9af3-98abe924f1b1"), "C.23.19", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("40bf0ef5-1a57-4305-abf6-34179b8f6094"), "C.22.19", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other rubber products" },
                    { new Guid("c4481b62-dd7f-4840-a62f-1670689c426e"), "C.20.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other chemical products" },
                    { new Guid("17e52953-bac4-4b65-ae8f-f4f1b3d4a749"), "C.20.42", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("bdb47670-da38-497e-8b7e-b52a3e8fdbda"), "C.20.41", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("3a0eef7b-2658-4837-b6c9-f08b52dcf7eb"), "C.18", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Printing and reproduction of recorded media" },
                    { new Guid("782a9c52-32a8-4fdb-ab8d-78e8aa0a9e78"), "C.18.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Printing and service activities related to printing" },
                    { new Guid("90ccfe84-cdb1-4183-bd50-cbda46090723"), "C.18.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Printing of newspapers" },
                    { new Guid("0c3bc0eb-91a4-463d-965e-83de2e4b07e4"), "C.18.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Other printing" },
                    { new Guid("307037f5-8165-4df3-81ec-87cd632be411"), "C.18.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Pre-press and pre-media services" },
                    { new Guid("f0c53b4c-5f3c-4d52-9daa-bd21771b9feb"), "C.18.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Binding and related services" },
                    { new Guid("0bb547b6-87d6-4bd4-98f2-20124af6dda7"), "C.18.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Reproduction of recorded media" },
                    { new Guid("8c876691-8fba-419d-847e-cedaacd183d1"), "C.18.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("63b2f3c4-9173-48e9-aac7-1d9d6c913d3c"), "C.19", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("072f3147-82cd-491f-bc8d-f28dca90b10c"), "C.19.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of coke oven products" },
                    { new Guid("5009ec59-4416-4bdb-8410-a94098c8474e"), "C.19.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of coke oven products" },
                    { new Guid("8542b2e8-81ef-4c62-a204-157377392d8b"), "C.19.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of refined petroleum products" },
                    { new Guid("69fa35ad-d7db-464e-a1a0-5efa10be7fd5"), "C.19.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of refined petroleum products" },
                    { new Guid("1c3c0eb3-7b2f-48d2-bca6-cba0052ef5c2"), "C.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of chemicals and chemical products" },
                    { new Guid("1d590f0e-8ee5-471d-900c-e483582380cd"), "C.20.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("05541149-7ebf-488a-8a3a-9110abd67dfa"), "C.20.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of industrial gases" },
                    { new Guid("b01c82ca-f233-4342-bf6a-0f962ed1e6d6"), "C.20.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of dyes and pigments" },
                    { new Guid("3b5214e1-4899-4259-9cfd-1f007daf6e3e"), "C.20.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("f11b995a-ea9e-4e98-8b64-44b756f9e11a"), "C.20.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other organic basic chemicals" },
                    { new Guid("b8235947-5b02-484a-a9d9-aff067db24d4"), "C.20.15", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("fa3cacba-9e31-4ae1-bbed-65e707442a14"), "C.20.16", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of plastics in primary forms" },
                    { new Guid("8e301a15-6fe3-4faf-b179-b066fa353dbd"), "C.20.17", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("ca590c8f-fd93-4a0c-8290-27cd5f094d58"), "C.20.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("2c507773-a731-4d65-a5dc-834e32aa7a45"), "C.20.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("566ab8cf-e75b-4f31-a780-bdf38b824dd3"), "C.20.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("5e154c45-2c9f-4ab8-8c2b-7e0094cfba49"), "C.20.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("da6493c4-e900-4703-ac14-aab88c1581b3"), "C.20.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("f27805a1-468e-4602-ad4f-70856d794fc7"), "C.17.24", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wallpaper" },
                    { new Guid("2a3168b1-b82d-48a0-b2b9-8cad7c2c69ca"), "C.23.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of refractory products" },
                    { new Guid("9f3779bb-25cf-4cc9-8376-9eebc14a02e6"), "C.11.0", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of beverages" },
                    { new Guid("12e29865-6593-4e9d-9d58-3ae022dba483"), "C.10.92", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of prepared pet foods" },
                    { new Guid("05a64922-c000-4d49-a26f-656a950203e7"), "A.01.6", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("40868dae-70ca-4bef-bb7e-dcc1c7923360"), "A.01.61", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Support activities for crop production" },
                    { new Guid("579a70ba-4eeb-4eb7-b405-8559e07034d4"), "A.01.62", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Support activities for animal production" },
                    { new Guid("14d1ad84-e2bb-47b9-82e1-c48e00b15149"), "A.01.63", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Post-harvest crop activities" },
                    { new Guid("4b7fc34c-3fdc-4460-acaa-79c7d97274fc"), "A.01.64", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Seed processing for propagation" },
                    { new Guid("fb4772f9-39f5-42e8-b59c-e740cb25ed2e"), "A.01.7", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Hunting, trapping and related service activities" },
                    { new Guid("0915fbf3-28b4-48de-8db9-5298f1c38824"), "A.01.70", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Hunting, trapping and related service activities" },
                    { new Guid("a8da206b-6749-4d95-a379-71aa2fbfdcdc"), "A.02", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Forestry and logging" },
                    { new Guid("5e4489e2-e184-4a3f-abdb-195fa266f64b"), "A.02.1", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Silviculture and other forestry activities" },
                    { new Guid("a9b41acb-47b5-4534-9fef-d0c33bca1197"), "A.02.10", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Silviculture and other forestry activities" },
                    { new Guid("79c66a80-8998-4033-8154-063634493fef"), "A.02.2", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Logging" },
                    { new Guid("06b7c2a6-6fb3-4570-b2be-55d00df35d5b"), "A.02.20", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Logging" },
                    { new Guid("09536b17-1441-46e9-9b44-f3699f916be1"), "A.01.50", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Mixed farming" },
                    { new Guid("98ee4c28-0fe6-4aee-a1d5-f0f9b0ab15ba"), "A.02.3", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Gathering of wild growing non-wood products" },
                    { new Guid("3f246ff9-821f-4dc8-bb68-3006c3a1b714"), "A.02.4", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Support services to forestry" },
                    { new Guid("72ff0a74-7c06-4219-96c2-a80fbc67b0d3"), "A.02.40", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Support services to forestry" },
                    { new Guid("34ca291c-7d6d-41e6-b100-9c886a007a91"), "A.03", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Fishing and aquaculture" },
                    { new Guid("462de6be-6d35-4f8a-aabe-e44b45b2bb69"), "A.03.1", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Fishing" },
                    { new Guid("e8d4da83-97f3-49d7-bd5f-7f43364d165e"), "A.03.11", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f0676d74-bad2-4d06-9344-0386dfc7d1a6"), "A.03.12", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Freshwater fishing" },
                    { new Guid("0c6eb5f4-0c84-45f9-89bb-eaeb1cb55298"), "A.03.2", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Aquaculture" },
                    { new Guid("dbf59e64-35ed-4a91-ae38-e029dba8de3b"), "A.03.21", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Marine aquaculture" },
                    { new Guid("b2bd05d4-2ce4-47e7-b055-72722fb40f68"), "A.03.22", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Freshwater aquaculture" },
                    { new Guid("f7889a8f-3c10-4a8d-bfc1-e0b82c583a86"), "B.05", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of coal and lignite" },
                    { new Guid("34ac52ee-c8bd-44bd-beab-b8f9ed9f72a7"), "B.05.1", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of hard coal" },
                    { new Guid("18dc8fdc-bd18-43dc-994e-c6cb39a73005"), "B.05.10", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of hard coal" },
                    { new Guid("29a0df90-0f78-482c-be88-9cf5c3aae33b"), "A.02.30", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Gathering of wild growing non-wood products" },
                    { new Guid("e98555c3-d3c0-432b-a00a-4cc2103c9117"), "A.01.5", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Mixed farming" },
                    { new Guid("bd801e3e-c61f-4d84-aa27-3ec7073c09df"), "A.01.49", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of other animals" },
                    { new Guid("5f3805ea-fe94-4e75-a904-586bb4241a15"), "A.01.47", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of poultry" },
                    { new Guid("65e40b93-a91f-43e5-87b7-5a129c82cbee"), "A.01.1", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of non-perennial crops" },
                    { new Guid("e8d0e611-75a4-4f22-a81e-a32ed0a14d4a"), "A.01.11", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("f6ebb8db-5a06-47fe-a1db-549bc844b794"), "A.01.12", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of rice" },
                    { new Guid("9efff93d-a3f8-414d-92df-0ef5f9454198"), "A.01.13", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("3c10d3ec-22ba-404e-ae78-768dc018b45c"), "A.01.14", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of sugar cane" },
                    { new Guid("700ea9f0-50eb-43fa-ae63-77fec1a41765"), "A.01.15", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of tobacco" },
                    { new Guid("c02ce32d-a314-4da9-accd-33461e1a7acc"), "A.01.16", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of fibre crops" },
                    { new Guid("5a6f07b3-48ae-44bb-abcb-ed12f48096fb"), "A.01.19", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of other non-perennial crops" },
                    { new Guid("12211a1c-8d91-40e7-9f15-f9e393f3bc05"), "A.01.2", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of perennial crops" },
                    { new Guid("39e01c39-b21d-41d9-83d7-dd210fe18eef"), "A.01.21", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of grapes" },
                    { new Guid("dbefeec2-b06c-4619-9302-aba97a183e00"), "A.01.22", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of tropical and subtropical fruits" },
                    { new Guid("7ff7c610-e189-4f4a-b205-390c12347147"), "A.01.23", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of citrus fruits" },
                    { new Guid("8a38ce29-75ff-4a6a-9c7d-d0593211acf0"), "A.01.24", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of pome fruits and stone fruits" },
                    { new Guid("53aa2b2d-568d-49e8-a201-185555fffdfe"), "A.01.25", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("91279cdd-5043-4543-82f1-fa7c6d8d92d4"), "A.01.26", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of oleaginous fruits" },
                    { new Guid("53c2a57f-33df-4fbe-bbf7-200faef1f76e"), "A.01.27", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of beverage crops" },
                    { new Guid("02ff6a94-de37-4b80-9f4a-5c772a4a6092"), "A.01.28", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("4d60478a-3c6a-4ee9-96ca-5016fe00d9ce"), "A.01.29", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Growing of other perennial crops" },
                    { new Guid("c5bd05ea-11ed-452b-9ab5-786caf3be5b0"), "A.01.3", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Plant propagation" },
                    { new Guid("9c3f9a63-1285-4b16-bd0f-42b3188cf17a"), "A.01.30", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Plant propagation" },
                    { new Guid("a35301a9-d167-4e1d-8811-0865b177a2ef"), "A.01.4", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Animal production" },
                    { new Guid("d0f63860-91e8-41f4-a085-8c27cb8f6a42"), "A.01.41", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of dairy cattle" },
                    { new Guid("42c8de76-7b1d-47ef-b181-22d503b61023"), "A.01.42", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of other cattle and buffaloes" },
                    { new Guid("6cd0501d-c2a2-41f7-8190-c26332879564"), "A.01.43", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of horses and other equines" },
                    { new Guid("4f1a6fec-31dd-4bcf-a5e3-0d51b67515a1"), "A.01.44", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of camels and camelids" },
                    { new Guid("c8149b38-c1bc-4318-a35e-4a78fa5e7133"), "A.01.45", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of sheep and goats" },
                    { new Guid("b76599bf-5e60-49e0-b632-35d82da18504"), "A.01.46", new Guid("9a3ceb9f-51cc-427c-a23e-9c5fd892d13e"), "Raising of swine/pigs" },
                    { new Guid("cc60d26b-9998-4d39-99d0-13436d5e1dc7"), "B.05.2", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of lignite" },
                    { new Guid("be16893a-37ea-48c8-ae87-22cb2db7f765"), "C.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of beverages" },
                    { new Guid("066f6a86-0ec9-4c5c-9550-e2bdc3e97abe"), "B.05.20", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of lignite" },
                    { new Guid("d700b625-dbce-4644-9f47-e863821da6b7"), "B.06.1", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fcd2f4f4-70e8-4291-a555-96741ce07d47"), "C.10.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of potatoes" },
                    { new Guid("498d97e1-7520-42b9-8e8d-b6a27e585865"), "C.10.32", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("94759103-889f-4d6a-b378-1908e6f096b3"), "C.10.39", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("7c1b84b0-d5c4-4906-9eab-22c7d1810e04"), "C.10.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("a71d0d48-c965-412b-8cac-f2f7b1725151"), "C.10.41", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of oils and fats" },
                    { new Guid("87960433-db13-4bf7-9f17-db2b4ca13253"), "C.10.42", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("634aab99-3486-43d3-8e85-63a1a3aea27c"), "C.10.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of dairy products" },
                    { new Guid("d687c753-28b7-462c-92d3-bbe81e29c515"), "C.10.51", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Operation of dairies and cheese making" },
                    { new Guid("32853da1-cdd7-458e-a7ff-da4384314a56"), "C.10.52", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ice cream" },
                    { new Guid("ab61b4df-88f3-4895-b4dd-daf5e60ff837"), "C.10.6", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("871503d5-238b-4d2b-9bb1-a551ef51c1a8"), "C.10.61", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of grain mill products" },
                    { new Guid("61a2d61e-273c-4265-b213-2106ba524160"), "C.10.62", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of starches and starch products" },
                    { new Guid("de4d4bd4-e174-43f2-bcb7-4fb84b245820"), "C.10.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("5ed9777d-a6f5-44cf-9385-81800a1d797e"), "C.10.7", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("d95f0635-c8c6-43bf-84a7-fed992bbbd29"), "C.10.72", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("2ac2519c-f2f9-4738-a579-c1f37879831c"), "C.10.73", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("52af93c2-82b1-4df8-948a-08a355cb5ac0"), "C.10.8", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other food products" },
                    { new Guid("f33dd35a-d088-4307-956b-f240b5b19c8d"), "C.10.81", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of sugar" },
                    { new Guid("2f07851a-56a2-436b-bd46-c8de86fd942a"), "C.10.82", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("8ed7505a-0a8a-4e8e-a14b-2dcedc381ef9"), "C.10.83", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing of tea and coffee" },
                    { new Guid("44b9e4b1-b615-4997-87aa-1c010dfd54d1"), "C.10.84", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of condiments and seasonings" },
                    { new Guid("79bf7587-dde0-492b-a068-cfb201ce55bb"), "C.10.85", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of prepared meals and dishes" },
                    { new Guid("ae9435cf-366e-4e24-bf70-e3ff794d414a"), "C.10.86", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("4c50bce1-ac1e-4f9c-a73e-53dd1f682ea8"), "C.10.89", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other food products n.e.c." },
                    { new Guid("4b000bdc-2566-4501-a753-544f9340654b"), "C.10.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of prepared animal feeds" },
                    { new Guid("620b4a20-7476-426f-a46a-c5cb83b75427"), "C.10.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("ccb3a047-0556-440f-a25d-e309f08ac9a4"), "C.10.71", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("506fb52f-363a-483a-b152-4db74b412dc2"), "C.10.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("afcc395a-41d9-47a8-8711-269620b2b4c7"), "C.10.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("d56c0863-55f3-47dc-a24b-e9382930bc5c"), "C.10.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Production of meat and poultry meat products" },
                    { new Guid("9a2dc559-29a6-48b9-8140-073ad7919b27"), "B.06.10", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of crude petroleum" },
                    { new Guid("6b9cf30f-287b-4db1-8dd1-16c57b724b54"), "B.06.2", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of natural gas" },
                    { new Guid("307fb281-2c07-4920-a604-72411bdcc703"), "B.06.20", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of natural gas" },
                    { new Guid("74f0a6c0-0707-422a-9659-702b01a2adb1"), "B.07", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of metal ores" },
                    { new Guid("6903641d-f036-401b-bf08-ba19df506efc"), "B.07.1", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of iron ores" },
                    { new Guid("7eb870f7-3b47-43c2-8208-0ed3ea578adb"), "B.07.10", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of iron ores" },
                    { new Guid("0149241b-b396-4847-88b9-525e15e1f7c2"), "B.07.2", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of non-ferrous metal ores" },
                    { new Guid("0a68adf6-7d54-48e2-84fe-5e7311363f3e"), "B.07.21", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of uranium and thorium ores" },
                    { new Guid("c03f461b-93e7-41d7-8b9f-4c370136942f"), "B.07.29", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of other non-ferrous metal ores" },
                    { new Guid("f76b49e8-92ba-478a-8e75-c82cf39b6d4f"), "B.08", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Other mining and quarrying" },
                    { new Guid("dee15e9f-b39f-4839-9b5f-5288613545ec"), "B.08.1", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Quarrying of stone, sand and clay" },
                    { new Guid("ce626bbc-e551-4ba8-9a92-75780d51e700"), "B.08.11", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("61cea7eb-e945-4524-a79b-41d4cf87e3f1"), "B.08.12", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("cb600251-ead4-46c4-956f-7f2907af094a"), "B.08.9", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining and quarrying n.e.c." },
                    { new Guid("63bb28fb-554e-4a29-8ebd-b7cf0d582256"), "B.08.91", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("e7e523c3-1ef5-4d42-8bc8-8d672e24a993"), "B.08.92", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of peat" },
                    { new Guid("0159e1ff-8cac-4491-9caa-e47b3dfed050"), "B.08.93", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of salt" },
                    { new Guid("c60a5d79-d74e-4ab7-bc1c-63357464a041"), "B.08.99", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Other mining and quarrying n.e.c." },
                    { new Guid("2b8430b3-ce25-40de-b67b-681c39612f85"), "B.09", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Mining support service activities" },
                    { new Guid("7fe63c6e-61a6-42ae-885d-9e4e230e5432"), "B.09.1", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("8fd41daa-81bc-46e4-a1ad-2eeed71d6357"), "B.09.10", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("bf60ed7b-9749-4e42-a322-718dd9a03124"), "B.09.9", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Support activities for other mining and quarrying" },
                    { new Guid("19fd6974-04a6-4b4e-8ff6-c00fe9240ba6"), "B.09.90", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Support activities for other mining and quarrying" },
                    { new Guid("20f1e08b-5172-46c9-a997-ffa75909170b"), "C.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of food products" },
                    { new Guid("c0cd2535-a7bb-4932-9a59-43ab3768ac42"), "C.10.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("919cf42a-2528-447f-b50d-4e98aaea6761"), "C.10.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of meat" },
                    { new Guid("71202299-4dc5-4fe7-9c50-2cd903363fef"), "C.10.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing and preserving of poultry meat" },
                    { new Guid("d289a3b7-4437-4afd-9b98-1416753e57fc"), "B.06", new Guid("a163713d-a864-4c47-8ffe-fd38011f0ad1"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("be41278f-e0ad-4272-9dc0-fc4fe65adf4f"), "F.43.2", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("1ee737a6-838b-4621-89ae-0f4305ffc88a"), "C.23.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of refractory products" },
                    { new Guid("940b257f-fd79-47e9-856d-0dac8eb98476"), "C.23.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("77e47b27-dfb1-4214-9104-e2a79904eb11"), "C.30.92", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("ca61747d-7cc0-49a8-a264-c631d0754897"), "C.30.99", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("5e8623ed-2e45-4e16-b61d-4e0c67aaae3c"), "C.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of furniture" },
                    { new Guid("f2529e54-b70a-4c92-8b34-383bebdce4da"), "C.31.0", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of furniture" },
                    { new Guid("a2c3beec-c97d-4e1f-b0d0-3c175295d778"), "C.31.01", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of office and shop furniture" },
                    { new Guid("8238776b-d095-4165-a338-85fc0f62e6df"), "C.31.02", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of kitchen furniture" },
                    { new Guid("9e66a6f4-9d1d-4733-9aa5-fe048504dd1b"), "C.31.03", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of mattresses" },
                    { new Guid("b9f2ad10-7fa5-4307-af34-0707b1d775f0"), "C.31.09", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other furniture" },
                    { new Guid("303d7d6b-bfed-433c-87ce-36dc8487c6c7"), "C.32", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Other manufacturing" },
                    { new Guid("db534591-9afd-4ddb-a95d-59d363a5785f"), "C.32.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("226ec82c-831d-43b2-a50e-bf081b70c37d"), "C.32.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Striking of coins" },
                    { new Guid("d5f9d1a7-a039-45eb-bcdf-09c9b41d0b87"), "C.32.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of jewellery and related articles" },
                    { new Guid("4ce9e598-fb2f-403e-b9c6-7a8f2a9d6319"), "C.30.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of motorcycles" },
                    { new Guid("1b4844ba-3497-48b5-808d-f466cff14421"), "C.32.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("4106c78b-95fd-47bb-a7a8-0c20fe4dcd22"), "C.32.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of musical instruments" },
                    { new Guid("925e187c-9404-4c1d-a64e-353c92dd5498"), "C.32.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of sports goods" },
                    { new Guid("d0682a83-6461-455c-a36b-2f80138f7f7f"), "C.32.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of sports goods" },
                    { new Guid("9aec3cdf-c316-4763-8904-4a8e78552406"), "C.32.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of games and toys" },
                    { new Guid("8860f11f-8a28-48c7-bc7d-414c554c38c9"), "C.32.40", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of games and toys" },
                    { new Guid("1d465475-f2c4-4248-a669-dfbbc9e40dbe"), "C.32.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("65f1136a-fb5c-4f31-81ed-e57818fbb8f3"), "C.32.50", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("f7ff2fbd-8c53-48f1-ad30-e7ef6c168af6"), "C.32.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacturing n.e.c." },
                    { new Guid("fef21eaa-c8f7-4f67-b1d9-37c877268019"), "C.32.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("763c9cc2-fcdd-415b-9e72-879120b2dd97"), "C.32.99", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Other manufacturing n.e.c." },
                    { new Guid("d9cb5310-3deb-42b1-869b-f8633aa9e81c"), "C.33", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair and installation of machinery and equipment" },
                    { new Guid("321a9b9e-c47f-4acf-becc-84849eb03631"), "C.33.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("d0d9a6cc-db02-4723-89a3-bc847b4d5524"), "C.32.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of musical instruments" },
                    { new Guid("074f8eef-833f-40d9-bcf6-ad2cb3ba4edc"), "C.30.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("0727e9f2-6e02-4264-b429-543424e29f4a"), "C.30.40", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of military fighting vehicles" },
                    { new Guid("e6ecc961-3b73-4983-8092-3991aa00cee8"), "C.30.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of military fighting vehicles" },
                    { new Guid("55dc9eb5-4c45-45e1-9205-9883b436d37c"), "C.28.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("a83dd1bc-9d8f-4411-8eee-9f99cfc5bf96"), "C.28.41", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of metal forming machinery" },
                    { new Guid("16473367-0cf3-4f35-9d32-3faeb22b3be1"), "C.28.49", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other machine tools" },
                    { new Guid("f928a3d9-434a-4c0d-bd49-ced4fc9d2cdb"), "C.28.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other special-purpose machinery" },
                    { new Guid("2314161d-15b6-4852-9b9b-719fcfac7c7f"), "C.28.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of machinery for metallurgy" },
                    { new Guid("fd4fcc8b-8459-4c66-b73d-c6476a1b6ec3"), "C.28.92", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("7856f8eb-1047-49fd-aebe-5e6c9f75b83d"), "C.28.93", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("7fc06bab-fb73-40fb-a777-fa2da6ca8221"), "C.28.94", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("20b7ba1a-375f-4ab1-9e9c-178738bce3f1"), "C.28.95", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("2fc2122b-d12f-4648-b653-16bcf1fac51c"), "C.28.96", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("64de607b-c8ba-4249-a3ef-a10adce701a5"), "C.28.99", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("d050831b-9129-49f5-b017-fc9f87da534a"), "C.29", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("cc7f4ddd-1e98-4e78-8eac-f1126e0fe592"), "C.29.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of motor vehicles" },
                    { new Guid("7c2787e0-853f-43ff-ace0-8c49ccc19a70"), "C.29.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of motor vehicles" },
                    { new Guid("feb2116b-6a80-4884-b3a3-0d550377ccf6"), "C.29.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("071a2aa2-4cc7-4324-8ba3-583a04df0bc2"), "C.29.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("e238ae71-5c2d-4b0a-a31a-4e5d50a821a2"), "C.29.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("be79eab9-60fb-4972-b209-42bf5eaaaca0"), "C.29.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("087e89f0-f29c-4769-8dff-a69aee5299cc"), "C.29.32", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("8313e29a-51bb-4c25-857f-8635d38e4a09"), "C.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other transport equipment" },
                    { new Guid("be3b7e60-aa89-479b-b150-7a9c3d0ae42d"), "C.30.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Building of ships and boats" },
                    { new Guid("2a94002f-f4c4-4f57-8880-7d3152ad08bd"), "C.30.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Building of ships and floating structures" },
                    { new Guid("8161411b-7609-45b8-b111-b24c5ebb0fa0"), "C.30.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Building of pleasure and sporting boats" },
                    { new Guid("2292fe9e-372b-43fd-8896-1a92690ca1f3"), "C.30.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("3c298323-6fef-4d13-b001-0a479e90db33"), "C.30.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("57402f77-7d1f-41af-afac-b4f6926b9f7e"), "C.30.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("7443f332-b3c7-4a19-acbd-25d2333a8087"), "C.30.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("197e054c-e26e-463a-94a8-9603215c938c"), "C.33.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair of fabricated metal products" },
                    { new Guid("dea8a02e-0715-4c2c-a7c5-a30bf3d2b21f"), "C.28.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("447a55f8-e1ee-4501-a8f2-c3fc28b709cf"), "C.33.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair of machinery" },
                    { new Guid("0e0dff78-128e-4f2f-a626-375842a071fb"), "C.33.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair of electrical equipment" },
                    { new Guid("ca7caf9a-53bc-4e57-806b-aa1f32c11149"), "E.38.3", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Materials recovery" },
                    { new Guid("b879a9b1-cee0-4109-8376-9afff00fb23d"), "E.38.31", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Dismantling of wrecks" },
                    { new Guid("c95c9cb2-ef6a-4003-a9e1-285403eab8d7"), "E.38.32", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Recovery of sorted materials" },
                    { new Guid("7c372c38-23b9-4cc4-ba62-d8a4aa657896"), "E.39", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b45c417e-6b29-412d-915a-87a9548702e1"), "E.39.0", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Remediation activities and other waste management services" },
                    { new Guid("70a8bf34-3fac-4ea1-a72d-f1033e2c385a"), "E.39.00", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Remediation activities and other waste management services" },
                    { new Guid("35c53fcf-b0bf-4d93-be80-8ad292113ed8"), "F.41", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of buildings" },
                    { new Guid("9350f18c-e4d0-4c7d-8dc4-ed41f88867b6"), "F.41.1", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Development of building projects" },
                    { new Guid("05ba0a22-c8ad-4ef9-ba8a-8a54ea7ba926"), "F.41.10", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Development of building projects" },
                    { new Guid("299038c4-b469-4b82-9793-6115dec32e84"), "F.41.2", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of residential and non-residential buildings" },
                    { new Guid("501de1b8-3d7e-460e-aeb8-286c7c47b9c5"), "F.41.20", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of residential and non-residential buildings" },
                    { new Guid("03515d43-9d20-4e7b-8b30-da505550566e"), "F.42", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Civil engineering" },
                    { new Guid("01a7e761-266f-4cd6-8ad6-6fdf274b0b34"), "E.38.22", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Treatment and disposal of hazardous waste" },
                    { new Guid("b8a6cb54-0df5-4175-bb0c-90d54edc2ee5"), "F.42.1", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of roads and railways" },
                    { new Guid("da7d073b-3109-4ce8-888d-ecf3e108a3dc"), "F.42.12", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of railways and underground railways" },
                    { new Guid("1fbcc1dd-982c-4840-9551-d5abb3d020e8"), "F.42.13", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of bridges and tunnels" },
                    { new Guid("08d2d1a8-be4f-4a1c-adc2-d7cd0dd7edb5"), "F.42.2", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of utility projects" },
                    { new Guid("0d102bb0-e07c-4b6d-a416-2941d0581968"), "F.42.21", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of utility projects for fluids" },
                    { new Guid("c29c4f77-8633-4527-a770-98e32754a466"), "F.42.22", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("131d8fd1-37b2-4a49-8e94-3832bea2c3ad"), "F.42.9", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of other civil engineering projects" },
                    { new Guid("a4255145-f4df-48e7-9c11-2798f2ea0191"), "F.42.91", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of water projects" },
                    { new Guid("e6b9711c-1f8b-4f66-9289-ca729d22254a"), "F.42.99", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("db416fb2-6c38-431a-af89-bc661a2c3b33"), "F.43", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Specialised construction activities" },
                    { new Guid("42dcddc8-078f-4a9c-90c7-6a70b23e20ee"), "F.43.1", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Demolition and site preparation" },
                    { new Guid("2eca0c3a-4e98-4c51-93e1-2137ffd06454"), "F.43.11", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Demolition" },
                    { new Guid("1b124c97-1aac-471d-8082-f296f0dbc05b"), "F.43.12", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Site preparation" },
                    { new Guid("de36e3fa-431a-48fc-8160-5ff77fafd533"), "F.42.11", new Guid("b6b8e0e4-d980-42eb-b112-8339aeabbe50"), "Construction of roads and motorways" },
                    { new Guid("d14ac9e9-13de-480b-b72e-eed9a8ede251"), "E.38.21", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("3a978d87-c105-4586-8e5f-a2a694f91530"), "E.38.2", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Waste treatment and disposal" },
                    { new Guid("c0b4ba40-88e2-4bdd-8df3-7fbbecf3f1cd"), "E.38.12", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Collection of hazardous waste" },
                    { new Guid("d05e0b77-4070-4248-bcfc-93e91d7a966f"), "C.33.15", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair and maintenance of ships and boats" },
                    { new Guid("b9113500-c4cf-4e04-b0bb-3902a8100afe"), "C.33.16", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("27637b54-68b1-46d3-af59-41741da6b6b9"), "C.33.17", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair and maintenance of other transport equipment" },
                    { new Guid("e6fee5fb-accf-4b88-8ced-723a90151652"), "C.33.19", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair of other equipment" },
                    { new Guid("97aa5364-4079-4f3e-b41f-e6eb6eae4c44"), "C.33.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Installation of industrial machinery and equipment" },
                    { new Guid("f569da7e-e99d-4458-91c9-78eb558a5b1a"), "C.33.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Installation of industrial machinery and equipment" },
                    { new Guid("f424381f-636a-4eac-8375-f332825085b7"), "D.35", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("09d9ed50-ba6d-4aba-a57e-fbe031cc6948"), "D.35.1", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Electric power generation, transmission and distribution" },
                    { new Guid("b0c41e41-4a58-435e-a52e-99601c953673"), "D.35.11", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Production of electricity" },
                    { new Guid("7654a4ae-394b-4d3a-98ac-580d79801378"), "D.35.12", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Transmission of electricity" },
                    { new Guid("fb9dc34c-9755-4a1e-982d-b0191713d07f"), "D.35.13", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Distribution of electricity" },
                    { new Guid("ced03abc-8a00-442f-9fe8-d3660efd25c4"), "D.35.14", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Trade of electricity" },
                    { new Guid("851f921c-7b1a-4b3c-b641-029d85d6bdad"), "D.35.2", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("c5ef53af-a43a-48fc-aab5-15b9e4d2c31a"), "D.35.21", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Manufacture of gas" },
                    { new Guid("3f8213d2-8fb3-484f-9b95-e8fe751e145c"), "D.35.22", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Distribution of gaseous fuels through mains" },
                    { new Guid("bfb23a62-601f-44ff-b18a-8d204b56ab60"), "D.35.23", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("efd1659f-437b-4788-a1f5-25f4428f20c7"), "D.35.3", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Steam and air conditioning supply" },
                    { new Guid("1fbe8416-07c2-4639-a657-988f4a0d55e8"), "D.35.30", new Guid("b81cd0e6-2adf-4de2-8655-1ae4bddb8bdb"), "Steam and air conditioning supply" },
                    { new Guid("d2d01646-4dd4-463c-8146-8654b3fe76d9"), "E.36", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Water collection, treatment and supply" },
                    { new Guid("0b6ad198-e9ce-47de-b0df-07b31d196922"), "E.36.0", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Water collection, treatment and supply" },
                    { new Guid("d5060471-cc1b-463e-8ac7-2fae18142ba2"), "E.36.00", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Water collection, treatment and supply" },
                    { new Guid("80b3b545-3829-4a05-a493-eee73e242e0f"), "E.37", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Sewerage" },
                    { new Guid("e5012d3e-11ae-444e-9e82-61ee392347c2"), "E.37.0", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Sewerage" },
                    { new Guid("8f34d6ad-fcd6-4b86-b28c-4b849ee6b650"), "E.37.00", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Sewerage" },
                    { new Guid("90fde28a-40e7-4966-8d8f-d1920eed2110"), "E.38", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("81ca3b21-f45b-408b-ab7a-4ad8f5d8d695"), "E.38.1", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Waste collection" },
                    { new Guid("8be8775a-cf41-4cc5-8c84-40ffa47b911a"), "E.38.11", new Guid("ab7571ac-c712-4acb-b9f0-f181c54fca67"), "Collection of non-hazardous waste" },
                    { new Guid("5b9e579a-c556-4cdc-bcdd-4bff0d7d0964"), "C.33.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Repair of electronic and optical equipment" },
                    { new Guid("27c31944-0a61-4063-b15a-a3186e1d4274"), "C.23.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of clay building materials" },
                    { new Guid("cdc35f70-a049-45fe-8006-43d9aeebd753"), "C.28.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("675d7559-f235-4ea5-ac61-182ddec67948"), "C.28.25", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("95677931-46d9-4ab2-9a9f-4e7453aed91c"), "C.24.34", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Cold drawing of wire" },
                    { new Guid("73f68463-ecbe-41bb-becb-35387f81beda"), "C.24.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("7924b1dd-54ae-4597-9caa-7bc97b18c4ae"), "C.24.41", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Precious metals production" },
                    { new Guid("1cfb5da7-465a-40e6-9454-e3a01ed9d978"), "C.24.42", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Aluminium production" },
                    { new Guid("827c33b7-4d37-42fc-addf-6fb8fe496e64"), "C.24.43", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Lead, zinc and tin production" },
                    { new Guid("ff0cf448-43c6-4936-93d5-32b0b3e07ccc"), "C.24.44", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Copper production" },
                    { new Guid("048fb65a-8f9e-4887-8b14-8d01ace8bcb4"), "C.24.45", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Other non-ferrous metal production" },
                    { new Guid("8f862a19-16f8-4616-a099-b925cac5978c"), "C.24.46", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Processing of nuclear fuel" },
                    { new Guid("67cfbd84-fba6-4d32-b53b-5c597b0e1b41"), "C.24.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Casting of metals" },
                    { new Guid("390ea4e2-19b1-409f-8b4c-159703b7478c"), "C.24.51", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Casting of iron" },
                    { new Guid("6a5afeef-2014-47f8-b23d-1020e95f49c6"), "C.24.52", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Casting of steel" },
                    { new Guid("9ae338b5-50e1-4a5b-bf90-d14520b14bde"), "C.24.53", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Casting of light metals" },
                    { new Guid("d7a92818-7d62-49fd-b04b-404e8db4740e"), "C.24.33", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Cold forming or folding" },
                    { new Guid("05336ae2-2f41-495e-b6a0-2260878a50a4"), "C.24.54", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Casting of other non-ferrous metals" },
                    { new Guid("980e49d0-a311-42e4-bf1d-7377470362b1"), "C.25.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of structural metal products" },
                    { new Guid("ebee39a6-91a3-4139-8af9-7931a164ed73"), "C.25.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("1edf1d54-c6d0-4940-bbfa-8aa5ab4cc3ef"), "C.25.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of doors and windows of metal" },
                    { new Guid("a1ee442a-2184-44ec-bff1-514b72bfb85b"), "C.25.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("9964ad9c-0a45-427c-b7c5-9c917368c354"), "C.25.21", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("108f33d2-dcc6-4e10-8934-165990685ca1"), "C.25.29", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("f624e900-6414-4d81-b129-a73d165ed17c"), "C.25.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("e3f9cea1-b039-47bb-a0e2-792aaae9df44"), "C.25.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("571a0eda-4783-47d4-98c8-e3b67f3095c1"), "C.25.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of weapons and ammunition" },
                    { new Guid("6c4d8007-3a70-48ca-8358-a98040e5c068"), "C.25.40", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of weapons and ammunition" },
                    { new Guid("c5deca80-4766-40a4-86d4-3cb09aafa583"), "C.25.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("ef41c463-6810-4a6b-80e8-e45bc8ae8ab0"), "C.25.50", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("3339aacf-08e7-4f1f-a2d7-fd1dac166a2c"), "C.25", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d8834a5d-ea1a-4c08-a89d-1f615c419949"), "C.24.32", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Cold rolling of narrow strip" },
                    { new Guid("fdb50901-e3a8-428e-aa53-602534d833d0"), "C.24.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Cold drawing of bars" },
                    { new Guid("909ccdd0-262d-4350-86f6-a65256c4a75f"), "C.24.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other products of first processing of steel" },
                    { new Guid("ede1550b-1f32-45f8-a966-21bca92c6780"), "C.23.32", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("371a7202-1a4f-4c43-8013-7974f468ee85"), "C.23.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("19482c30-2448-4368-8fd7-a4107772a895"), "C.23.41", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("f81bdb2e-51ce-4e90-90bf-bcec1c7ebe15"), "C.23.42", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("c9c04a47-6e84-429a-97e5-1f03e436728f"), "C.23.43", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("ae0769ec-bc25-4023-8b50-ca12b5246623"), "C.23.44", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other technical ceramic products" },
                    { new Guid("da062aa5-1291-4a52-95fa-194227417b7c"), "C.23.49", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other ceramic products" },
                    { new Guid("c0af976e-fb9b-45e0-8e7f-18e485040a33"), "C.23.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cement, lime and plaster" },
                    { new Guid("1fa31148-2251-44f7-8b10-773178574175"), "C.23.51", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cement" },
                    { new Guid("732ffe69-6719-4ea4-8029-7433f49675a2"), "C.23.52", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of lime and plaster" },
                    { new Guid("a94acc3e-9a14-40b5-af0e-b815ca6473e2"), "C.23.6", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("3400b7c4-6993-457d-bbb8-6d70c7077bcb"), "C.23.61", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("14a723c1-13ed-4119-b47c-8a7a2af9f12a"), "C.23.62", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("5cd53a7a-2304-44c3-b985-3ac2961ada6b"), "C.23.63", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ready-mixed concrete" },
                    { new Guid("f9ee3e00-6916-48c9-8eda-0bd876b40a26"), "C.23.64", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of mortars" },
                    { new Guid("eed4732b-ed69-4b6c-8f69-0d0ab06acc5e"), "C.23.65", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fibre cement" },
                    { new Guid("76629d59-b521-4ff3-8720-1428ee6da2d7"), "C.23.69", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("e055c1a8-8e6d-40cb-809b-6524cc736965"), "C.23.7", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Cutting, shaping and finishing of stone" },
                    { new Guid("50e34d73-c5a1-4cae-817b-977da4fc041c"), "C.23.70", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Cutting, shaping and finishing of stone" },
                    { new Guid("3c23b5eb-65b4-4647-9a9b-f29177ffa95c"), "C.23.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("11b23b7c-aa86-414c-b5bd-b39c42f0acce"), "C.23.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Production of abrasive products" },
                    { new Guid("42d38e65-389a-488f-9f3a-26e8fa5304e9"), "C.23.99", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("7834d522-ae58-46ad-a0f3-34912bf50021"), "C.24", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic metals" },
                    { new Guid("2384a9ef-2846-4352-8e8c-6a0c934df726"), "C.24.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("27041fac-1c0b-4ea2-870a-53bbf4e5bd17"), "C.24.10", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("f36c720f-eeac-405f-8404-26bdc4ba8139"), "C.24.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("ce0cd4a3-60f7-457a-948f-f06adaaf6cfa"), "C.24.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("c1f6747b-8fc7-4942-9578-99ef58c15b05"), "C.25.6", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Treatment and coating of metals; machining" },
                    { new Guid("9f5446ca-9131-40cc-b23c-90588bd47a05"), "C.28.29", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("b4edb204-78c2-44c1-acd1-261cf68f3acf"), "C.25.61", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Treatment and coating of metals" },
                    { new Guid("054bb2e3-7b85-47b4-990f-74ccf3a0b862"), "C.25.7", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("324d9331-3fc8-4c6d-b2e5-808aa07289dd"), "C.27.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("38a8de89-a2fd-4a17-a10f-a3ffa61035f4"), "C.27.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of batteries and accumulators" },
                    { new Guid("0989a44a-0193-4f54-b0f6-d3779355dcc6"), "C.27.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of batteries and accumulators" },
                    { new Guid("83575158-491c-4f69-8758-2aa7da6ca1ca"), "C.27.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wiring and wiring devices" },
                    { new Guid("a6c787fa-8c82-446e-b5db-81aa41e10216"), "C.27.31", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fibre optic cables" },
                    { new Guid("760a2e64-a496-4786-b1fa-de81f6ce24bb"), "C.27.32", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("3e6ab8a2-2adf-4535-9549-e6e449da877e"), "C.27.33", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wiring devices" },
                    { new Guid("f0efc727-dbcc-4257-a134-9c262fd446a2"), "C.27.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("82588301-9107-4c28-bad1-04276a5a3ce2"), "C.27.40", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electric lighting equipment" },
                    { new Guid("c9896383-2e48-4444-b2ac-3faa8146d0dd"), "C.27.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of domestic appliances" },
                    { new Guid("e9d4ba49-a026-4a39-8a10-42b42623a624"), "C.27.51", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electric domestic appliances" },
                    { new Guid("55d13214-fa28-4fd7-9714-88b1089094d1"), "C.27.52", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("a57c26b3-8529-4004-a3d0-e68957b720b8"), "C.27.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("38af4b8a-b9be-49f8-a190-3014aca8931a"), "C.27.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other electrical equipment" },
                    { new Guid("868cc40f-5733-4368-a5c4-83cd6d359d91"), "C.28", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("44a86fcc-71fd-488b-a327-e10e04c12345"), "C.28.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of general-purpose machinery" },
                    { new Guid("1e0004fe-37f2-4a88-8f6b-be8e0536f2b5"), "C.28.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("0d28e57d-aed7-4832-8029-fdcedacfb3de"), "C.28.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fluid power equipment" },
                    { new Guid("892423ca-203f-4036-86e6-8ae451f8a801"), "C.28.13", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other pumps and compressors" },
                    { new Guid("c00fc91c-d4fe-49cc-a051-91a284efafac"), "C.28.14", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other taps and valves" },
                    { new Guid("6d0dcce6-6ce2-4c1e-b7f1-ab778cdec012"), "C.28.15", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("0ac91b5d-257b-4435-82e1-98fdb324f345"), "C.28.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other general-purpose machinery" },
                    { new Guid("75a35917-e727-470c-9c4a-8a98c0001f96"), "C.28.21", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("045902b0-22e7-41fe-a94a-d5d14c6732b2"), "C.28.22", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of lifting and handling equipment" },
                    { new Guid("39d950a6-efe4-4f65-b996-50df82003136"), "C.28.23", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("b5434364-0967-4761-a799-feefd901d1e7"), "C.28.24", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of power-driven hand tools" },
                    { new Guid("fe934b73-24c4-4df5-9e8c-644489a73948"), "C.27.90", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other electrical equipment" },
                    { new Guid("b80de974-d35e-439e-a49d-47e7e75cec14"), "C.27.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("eb2b7b29-e8dc-4cda-b828-64119a352da3"), "C.27", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electrical equipment" },
                    { new Guid("03fc90dc-2c09-417c-81af-7afbbff4fc7c"), "C.26.80", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of magnetic and optical media" },
                    { new Guid("1fc8d8be-055f-446e-b48c-536c8fde0a3e"), "C.25.71", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of cutlery" },
                    { new Guid("42de41aa-0b2d-4632-b4e4-b2fda95aaea7"), "C.25.72", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of locks and hinges" },
                    { new Guid("f9524f78-1744-46e7-9239-29c5769f3bd2"), "C.25.73", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of tools" },
                    { new Guid("79106c47-2237-4c0c-af2c-d27b915c85aa"), "C.25.9", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other fabricated metal products" },
                    { new Guid("3da90a3d-37f8-4404-9b97-301b9b72160d"), "C.25.91", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of steel drums and similar containers" },
                    { new Guid("6892e51a-db64-4f12-ba90-4d4040cd96bf"), "C.25.92", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of light metal packaging" },
                    { new Guid("053e6027-1980-45d8-a83f-a6a29804e038"), "C.25.93", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of wire products, chain and springs" },
                    { new Guid("ccf4b66b-d393-4e3d-8912-f4778c98fed1"), "C.25.94", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("4a63bb61-5434-4204-866e-e7522ed920d7"), "C.25.99", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("a4cf81c8-819c-4073-b408-7f0d50a8481f"), "C.26", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("1f6f1e2a-b9ac-4fab-b140-94bf2a03a5fa"), "C.26.1", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electronic components and boards" },
                    { new Guid("51d07199-e807-414b-9f5a-2e980cb883d4"), "C.26.11", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of electronic components" },
                    { new Guid("8ff30433-f46a-4eb5-802a-82de91c9c49c"), "C.26.12", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of loaded electronic boards" },
                    { new Guid("a494ccde-5849-4f57-83c4-0cf8e64ef617"), "C.26.2", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("cf7386eb-aa1a-4271-b131-12d0a53192bb"), "C.26.20", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("1b347945-ba8f-4870-a62b-8dd8b39451b0"), "C.26.3", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of communication equipment" },
                    { new Guid("593f9b8a-f4f4-4912-aec6-4383fbfb3c52"), "C.26.30", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of communication equipment" },
                    { new Guid("674f49fb-4795-481e-a467-784e92cec630"), "C.26.4", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of consumer electronics" },
                    { new Guid("659d654d-866d-4eea-880e-664846ef5636"), "C.26.40", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of consumer electronics" },
                    { new Guid("a000f923-55bf-43ab-bd2c-23966077e4f6"), "C.26.5", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("05934b10-6757-4350-b34d-d967dc351f6d"), "C.26.51", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("19b8712c-9af6-4f0b-b2f9-12178a1b0582"), "C.26.52", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of watches and clocks" },
                    { new Guid("58095794-be71-4496-84e9-7b848ea884fe"), "C.26.6", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("ff0542b8-5a3d-4d00-a05b-ba1debeadfd0"), "C.26.60", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("53b3c097-8ca2-483c-ab6d-72b4acceb2ac"), "C.26.7", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("7bd4a1d0-e12b-46c6-a54a-175e2c0f5772"), "C.26.70", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("62b79e62-1210-479b-adb0-39d559524f65"), "C.26.8", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Manufacture of magnetic and optical media" },
                    { new Guid("e93d58a1-2ec1-4256-ad09-a33b15a09ed0"), "C.25.62", new Guid("9ac4ef5b-a13e-40f7-a731-4d1e0a0246ba"), "Machining" },
                    { new Guid("c67c2054-3060-419c-bc4f-cf5655e574e5"), "U.99.00", new Guid("7a4af031-9636-4228-8ad9-d1a49a7c9e17"), "Activities of extraterritorial organisations and bodies" }
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
                name: "IX_Plan_SpecificAttributes_BusinessPlanId",
                table: "Plan_SpecificAttributes",
                column: "BusinessPlanId");

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
                name: "Plan_SpecificAttributes");

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
