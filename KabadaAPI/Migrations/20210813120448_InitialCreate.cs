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
                name: "DbSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSettings", x => x.Id);
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
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lookup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
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
                    IsCustomerSegmentsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerRelationshipCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActivitiesCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("4fc44f33-6d0c-4b14-a3d6-086b8887439c"), "LT", "Lithuania" },
                    { new Guid("31bf0dc8-84bc-4fb4-be98-adc820e704f0"), "CH", "Switzerland" },
                    { new Guid("3ba00e48-567d-4ab2-8d69-b2513029450f"), "DE", "Germany" },
                    { new Guid("f80c19a8-cfbb-4a11-9fcf-b2bb6bb76209"), "PT", "Portugal" },
                    { new Guid("9adfa62a-dc9c-4eef-9117-c524d25bed02"), "LU", "Luxembourg" },
                    { new Guid("e77e44cb-424b-4e9e-af3a-d18d80af7af9"), "IS", "Iceland" },
                    { new Guid("2f5f58b0-9187-4880-989a-d1c0df55eadf"), "CY", "Cyprus" },
                    { new Guid("563ddee5-e623-497f-a156-dd017c9cdab8"), "BG", "Bulgaria" },
                    { new Guid("152b4a85-1cd8-4d6d-8943-e4fe8b54d650"), "NO", "Norway" },
                    { new Guid("e25fc6c5-ff87-45f6-91fe-e704644c2c72"), "LV", "Latvia" },
                    { new Guid("e518c516-6118-4b09-b58f-e856299682d4"), "SE", "Sweden" },
                    { new Guid("0d3a5193-d049-4578-a280-e90bde5f344a"), "HU", "Hungary" },
                    { new Guid("0440025f-72d4-40df-bd15-f235d391bcb7"), "ES", "Spain" },
                    { new Guid("67ed2cd2-1f1c-4dcc-b79c-f4484a33ce75"), "FI", "Finland" },
                    { new Guid("aff0b384-b033-4d50-a2a5-f88459196587"), "CZ", "Czechia" },
                    { new Guid("cece3c3c-ff40-428a-b6e0-fd4895e727e9"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("34656372-3fe8-40b4-b1a2-a8f3e7aadd71"), "MT", "Malta" },
                    { new Guid("42da7d0f-bc1e-4738-981d-a347f02e149b"), "EE", "Estonia" },
                    { new Guid("4cb2912a-653a-44fb-b7a7-bfc336e96452"), "DK", "Denmark" },
                    { new Guid("4cf29c73-9558-4ee6-9fe2-973e01a71365"), "RS", "Serbia" },
                    { new Guid("d480bd70-e883-4001-ba2b-10c941f2832f"), "TR", "Turkey" },
                    { new Guid("a25ad04d-d63a-4e6c-a16b-118f5922e175"), "MK", "North Macedonia" },
                    { new Guid("df4d5d75-8c3b-45b3-8ac0-17c7b5d0b0f9"), "IT", "Italy" },
                    { new Guid("050b9ee7-07ef-40c6-8f62-9a1e3b932074"), "SI", "Slovenia" },
                    { new Guid("febb11c0-ac67-43c6-8eba-1b9e4fcbe318"), "EL", "Greece" },
                    { new Guid("faf79adb-0ee3-4831-b3b9-45840415ac0d"), "BE", "Belgium" },
                    { new Guid("b166b440-11d7-4766-8926-45cc6f97430f"), "AT", "Austria" },
                    { new Guid("e90a042c-5236-49ad-989f-481f007f32aa"), "PL", "Poland" },
                    { new Guid("e876704f-b93c-4a46-ac45-19a45935aa34"), "HR", "Croatia" },
                    { new Guid("8d52d2a1-8459-488d-8315-4a7d2fd28204"), "SK", "Slovakia" },
                    { new Guid("520e1ff1-ba39-4dec-82f5-56e2868c2822"), "RO", "Romania" },
                    { new Guid("a0c1dd5e-8ae6-439a-9ac9-7638c8b72020"), "NL", "Netherlands" },
                    { new Guid("fb1fec9a-4d42-4248-9469-83a1b2ec6a77"), "UK", "United Kingdom" },
                    { new Guid("9ddbfacc-ef15-4bff-a4e3-8d57e90ca5c2"), "FR", "France" },
                    { new Guid("c66c593a-d743-4473-8202-955ac09d78cf"), "IE", "Ireland" },
                    { new Guid("8de06ef6-8966-4e52-a244-48422321ffaa"), "LI", "Liechtenstein" }
                });

            migrationBuilder.InsertData(
                table: "DbSettings",
                columns: new[] { "Id", "Value" },
                values: new object[] { "initialDataSetLevel", "2" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("b6f19c27-77f5-4b31-9303-c16a9654e3aa"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "N", "EN", "Administrative and support service activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "L", "EN", "Real estate activities" },
                    { new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "B", "EN", "Mining and quarrying" },
                    { new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "P", "EN", "Education" },
                    { new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "J", "EN", "Information and communication" },
                    { new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "H", "EN", "Transporting and storage" },
                    { new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "C", "EN", "Manufacturing" },
                    { new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "F", "EN", "Construction" },
                    { new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "S", "EN", "Other services activities" },
                    { new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "O", "EN", "Public administration and defence; compulsory social security" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("353afb7a-984f-4629-94bf-6f2aee3c9ea5"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("df0fa10f-05df-485a-9f90-aaae6cc11ebc"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)3, "Direct visit" },
                    { new Guid("7d1df83e-9bdd-47eb-8fad-ad7f7b1a8329"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("adb303c0-23af-4eca-948c-9f09142bf015"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("d050dc8f-aa16-47f8-ab35-ae6fc8d7a3ae"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("9ee57d37-6425-409e-b7fd-aa97f3010e9f"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("9f62a58d-00b7-43ee-8374-ae679f5d68af"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("41655b64-362b-4402-af8d-a777ed912c97"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("6a08ddad-1878-46da-a843-a1856a93dd91"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("3066446c-5e9b-4321-bdf6-a47f367f61c5"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)4, "Other" },
                    { new Guid("d57d1d34-e721-4d46-a5f4-a3f9e7d3a198"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("b2445fa0-fa0d-4f77-b545-a3d10f6da338"), (short)41, null, null, (short)0, "Production" },
                    { new Guid("49ac2e9c-ecbb-4a14-aa35-a35efb4ff919"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("1afacd96-1b6b-4958-bffd-af953759ee25"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("5087771d-cce4-4521-a3cb-a14b1891abba"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)2, "Office" },
                    { new Guid("cdc1a197-fb79-42b9-a7cb-9ff8fd0e1622"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("860adbf1-baf5-4cf2-8b55-a5baca045e60"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)2, "Factory workers / service" },
                    { new Guid("cf6361ec-886e-4b0a-b53b-af9a477f334b"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("121f0a92-8b35-4890-8384-b66f48db9ac5"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)29, null, new Guid("91d5edff-f361-47aa-8d3c-b420681dcd5e"), (short)1, "Physical" },
                    { new Guid("b4517dc0-8202-4cff-be3e-c11a1f78037c"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)2, "Administrative" },
                    { new Guid("fbaa6538-cedd-43f9-b739-bffcf4f00e96"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("f90efa9d-ff68-4fe7-b6b3-bf55850f7437"), (short)31, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)1, "Self pickup" },
                    { new Guid("335fcecd-5a78-4b23-a065-be7eaeae4f20"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ca5124ab-0c2f-4224-88b1-f579a01d2522"), (short)2, "Frequency" },
                    { new Guid("593cfcc0-bc1d-4189-b0af-bdd5f51b0b8d"), (short)37, null, null, (short)2, "Services" },
                    { new Guid("598ee84a-c772-4156-abf3-bc0d57c678a1"), (short)41, null, null, (short)0, "Platform/Network" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("0bff5c28-137c-4890-90df-ba7e0746431c"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("bf7c1d8a-7240-4c81-84e2-b96709e3c3ba"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("e682f874-c899-432d-a963-b82470f6bcf1"), (short)42, null, new Guid("b2445fa0-fa0d-4f77-b545-a3d10f6da338"), (short)0, "Logistics" },
                    { new Guid("22656f17-0f99-438f-a934-b71d64a7fbd6"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)1, "Buildings" },
                    { new Guid("86d1df12-6c1b-4211-a936-b5c2cad16a81"), (short)42, null, new Guid("53299dc3-8c18-486c-8be9-623d2152b9dd"), (short)0, "Knowledge management" },
                    { new Guid("91d5edff-f361-47aa-8d3c-b420681dcd5e"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)1, "Own shop" },
                    { new Guid("f5311b29-88a0-4500-8173-b2e16a3137ed"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("e2d723ce-1ea6-4d1e-a35e-5b47907d2d2a"), (short)1, "Ownership type" },
                    { new Guid("88579996-53e2-4699-a6f0-b97df2421276"), (short)32, null, null, (short)6, "65 - 74" },
                    { new Guid("329ecdc4-faeb-43fa-b53e-9efad8c7b4d3"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("a2254a01-9908-42e0-af0d-8a0b04875197"), (short)36, null, null, (short)1, "Small" },
                    { new Guid("7da1cdc9-d7e4-4234-b31b-9e0570e5e9c6"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("e436274e-cbea-42e0-be23-8dcf0804daf0"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("3861b60b-1598-4b1e-be5a-8d815e6674a7"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("e673e497-be75-4692-952c-8cdf3d5a9714"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)1, "IT (office) equipment" },
                    { new Guid("1245994e-b52c-4c9a-9060-8c4856742197"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("2bb3f65a-5c77-4482-9fa3-8b7c2ce555bd"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)4, "Heat" },
                    { new Guid("df741ccc-d2ef-4797-8c96-8b5be0344f88"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("92455eb0-dd6b-4c56-a883-8a39f2dafbae"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("a4e19cfd-e63d-4eaf-b45e-8a298a3be406"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)2, "Water" },
                    { new Guid("4c53b804-2392-4744-a1ce-c11d424d7aab"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("07d5452f-6ea6-4ae6-9395-89fd1d0eeab0"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("457f681a-f052-408d-a7f6-8979f6c47063"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("2483ee5b-da92-4400-aa64-88eb8a1ea152"), (short)26, null, new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)2, "Product feature dependent" },
                    { new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("e77f9a30-6e69-432d-9c8e-88380ba63de2"), (short)23, null, new Guid("09b845a4-df9c-4f53-b833-1f69ae6d1835"), (short)1, "Other" },
                    { new Guid("4b0ba05e-88c6-4c54-a313-880e3aee9905"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("36c027b7-849b-4466-bafa-8e3441a53fb9"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)3, "Gas" },
                    { new Guid("825d07dd-581b-4473-841c-9ec037746ae2"), (short)35, null, null, (short)7, "Transnational" },
                    { new Guid("d54aefa4-bd1c-4c73-b0f1-8e3c58eb29bc"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)6, "Communication" },
                    { new Guid("fb4a4c08-a17d-444c-9776-92c54acd6940"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)3, "Finance management" },
                    { new Guid("3bb18f50-91bf-4c73-ad1f-9cdd924127fb"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("2fc70a56-27b6-442b-938c-9c13fb36e316"), (short)40, null, null, (short)1, "Word of Mouth" },
                    { new Guid("a80edb58-5f37-4410-891f-9c0446982131"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("08871a1a-331b-44af-8395-9bdf2287ed8c"), (short)23, null, new Guid("c7b32094-6538-4e72-ad49-6ea1fda21562"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("d4ede701-8037-488b-9794-9b8632c1c3c0"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)4, "Other" },
                    { new Guid("97f2428a-982b-44a6-8b54-9b7f81c8958b"), (short)32, null, null, (short)7, "75 years or older" },
                    { new Guid("4820dc72-7756-4510-9d6a-9a062e2fc22e"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("57edccf6-bc5a-4679-8a9a-99f8c2f97a4e"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("6d1b4bb9-7de0-443d-a9f4-9880cb99fab0"), (short)32, null, null, (short)8, "All age groups" },
                    { new Guid("169b2610-f5eb-47c1-88d8-95831dae4a59"), (short)20, null, null, (short)1, "Not" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("cbf5fd0e-8a6e-420d-8fbb-94585c7558ba"), (short)42, null, new Guid("598ee84a-c772-4156-abf3-bc0d57c678a1"), (short)0, "Platform management" },
                    { new Guid("fee1bca2-317f-4b5d-9c8b-9414a16a4d0f"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("c804bad3-0387-44fb-9817-93085d14ccf9"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)1, "Management" },
                    { new Guid("4ae078f2-21a9-4f01-b11d-92eace60e38e"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("93916775-80bd-4355-bfda-907e8a737cbe"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("109af523-c8ae-409f-a5ab-c15d02ce5858"), (short)32, null, null, (short)3, "18 - 24" },
                    { new Guid("3f2faea5-f8f6-43b4-80f2-db55874a5c4b"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("2e4ee3fe-7f1b-4105-b37e-c1ee4d8d4d40"), (short)30, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)1, "Fixed location" },
                    { new Guid("f5e69507-6f10-49bd-a3aa-edd3b0845e67"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("eaee254e-e4c3-4ebd-86eb-ed38a54c238b"), (short)23, null, new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)1, "Accountant" },
                    { new Guid("b362e97b-b47d-4183-82b2-ecc6dbd9bc6f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3943c265-621b-4738-93c8-4470986c3af3"), (short)2, "Frequency" },
                    { new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("fc87ba60-6c43-4420-bdb0-eacc00ffbca5"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)4, "Raw materials" },
                    { new Guid("ed7c4844-5ab2-431f-b765-ea94db35952d"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("dfe881a2-cd69-4295-a16a-edfb2c8fc0bf"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("d8aaf777-bd2b-40e6-9eab-ea5e06f34c55"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("22656f17-0f99-438f-a934-b71d64a7fbd6"), (short)1, "Ownership type" },
                    { new Guid("67dc4bec-4276-44df-a573-e95b64864a7e"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("eea606be-c02d-41a6-a35e-e8701086869c"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("5eb6013b-0cca-4f89-b39d-e711477a972f"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("de834ef4-a990-4a17-9385-e6a6c226189c"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)4, "Other" },
                    { new Guid("197debde-3d72-4bae-89e5-e5d9010c8562"), (short)35, null, null, (short)4, "Foreign" },
                    { new Guid("7a4a57fd-79e7-4141-88b5-e57a22d7ef9a"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("f782da7f-d1e2-4cf8-9267-ea403651f58d"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("2d5348f7-f619-4de2-a186-ee0ad4fff927"), (short)35, null, null, (short)3, "Domestic Rural" },
                    { new Guid("327ca493-9191-4fb5-b1a8-eec264849f7d"), (short)42, null, new Guid("b2445fa0-fa0d-4f77-b545-a3d10f6da338"), (short)0, "R & D" },
                    { new Guid("5365d22f-9372-4471-baab-f1175d25ae0f"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("e0c84bf6-dbc3-450e-95ac-fe42299e05df"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("187d8314-5350-4f30-a68c-fde38021a178"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("cf1657e0-d4eb-430c-8185-fc80c20aa25c"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)7, "Other" },
                    { new Guid("7cb479d5-c8e5-40c3-909c-fbde2188b593"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("eed82f80-4e74-435d-9371-fba9683b33ad"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)3, "Equipment" },
                    { new Guid("10f4eb49-006c-4f56-89d4-fb1743313707"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("da790cb3-6e70-4f32-8e18-fab771727c07"), (short)38, null, null, (short)4, "Non-Government organisations" },
                    { new Guid("d4c9d2ba-44e3-4eff-98a5-f968bdc25952"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("4b0ba05e-88c6-4c54-a313-880e3aee9905"), (short)1, "Ownership type" },
                    { new Guid("db69b609-d71a-417a-9142-f8b5dbeb7cb3"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)2, "Production equipment and machinery" },
                    { new Guid("d7588518-4eae-4e60-ae17-f8abc90b3358"), (short)42, null, new Guid("b2445fa0-fa0d-4f77-b545-a3d10f6da338"), (short)0, "Marketing" },
                    { new Guid("fe928bb7-8ef0-4f01-b40b-f7da62c1c084"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("6e0f7f5e-1780-4218-a5c5-f6be04b49a12"), (short)32, null, null, (short)2, "12 - 17" },
                    { new Guid("e59e3f4e-077f-4d34-9214-f5b93134cf44"), (short)35, null, null, (short)6, "Foreign Rural" },
                    { new Guid("ca5124ab-0c2f-4224-88b1-f579a01d2522"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)2, "Equipment" },
                    { new Guid("be005f23-8f91-4776-835c-f4e231bdb1e5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("22656f17-0f99-438f-a934-b71d64a7fbd6"), (short)2, "Frequency" },
                    { new Guid("941b8d92-ecb7-4885-b95c-e57408d66213"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("e2d723ce-1ea6-4d1e-a35e-5b47907d2d2a"), (short)2, "Frequency" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("90e3590d-b9d4-4e07-87cf-e45659e486f0"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("fc510839-c0c3-4883-a917-e35a2b9ea22e"), (short)23, null, new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)2, "IT support" },
                    { new Guid("22ab4468-869c-4f8a-94c9-e2f5c3974718"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("c6a66809-c479-4563-95df-cb9396c37e35"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)4, "" },
                    { new Guid("c055ffa9-c8e4-4f77-859d-cae9785736f6"), (short)35, null, null, (short)1, "Domestic" },
                    { new Guid("b00a4df7-4b4e-41b6-a2ac-cabf1e75ce5d"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("2ad13e8d-672f-4eb7-87eb-ca33891eeffb"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("90a35599-3c47-4389-b571-c9d3c7957daf"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)4, "Other" },
                    { new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)29, null, new Guid("91d5edff-f361-47aa-8d3c-b420681dcd5e"), (short)2, "Online" },
                    { new Guid("a3935a3c-ad19-4395-8020-c7c73a9587f3"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("f61f60ab-7991-4dac-b40e-c742dcef878b"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("7baa945c-4bcb-46b9-8e95-c72fe5b49778"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("7a82656a-a993-4a54-b8e6-c69224642dd1"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("e33adb3f-4391-4631-ab67-c5ce6989dd38"), (short)42, null, new Guid("598ee84a-c772-4156-abf3-bc0d57c678a1"), (short)0, "Marketing" },
                    { new Guid("9c1015a6-00a0-4d86-a723-c56bb7da4df5"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("7322bf24-fee2-4a31-bcda-c4e7a762c162"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("44468654-bf65-4e70-ab92-c4bf5c399d03"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("50477479-4b86-4ce1-bcea-c3e7b075f5c8"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("e8daf129-e055-4683-b4aa-c1ebd5934e25"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("a571bc0b-8f30-4070-b16b-cd873a2deab7"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)4, "Other" },
                    { new Guid("003ba515-28f7-4141-af55-ce6a35b96e41"), (short)42, null, new Guid("b2445fa0-fa0d-4f77-b545-a3d10f6da338"), (short)0, "Services" },
                    { new Guid("0f3080b7-034f-4891-9d66-e1d6f0d8cd8c"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("3066446c-5e9b-4321-bdf6-a47f367f61c5"), (short)1, "Ownership type" },
                    { new Guid("5393af35-4b9f-49f4-a366-e1430860ee49"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("03af662c-036c-43d8-95c7-e07b9388495c"), (short)23, null, new Guid("ef60cdef-d5b1-421a-aa36-10463faf9f6e"), (short)1, "Other" },
                    { new Guid("0fe097a6-bd15-4272-885e-de82c1d08677"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("c06464ec-0248-4964-b09a-dd6fd7c6cc17"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)2, "Market/Fairs" },
                    { new Guid("6dad8d59-0786-43e5-98a6-dd6d4fdc7688"), (short)31, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)1, "Own delivery" },
                    { new Guid("80b218db-fd97-43a7-9945-dbe555990934"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("ae7c712d-f780-429f-aed6-87509c0bc43c"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("636b2c40-cfd3-4eb3-9003-dac709ff860b"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("3253125f-cc5c-4269-a6e2-d9e95f0d4c3a"), (short)23, null, new Guid("5a7a66cb-25f4-462b-b1f7-47b97735d7da"), (short)1, "Other" },
                    { new Guid("97070765-ae68-4bb1-9b50-d99761807ef4"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("0367b12d-3444-4c35-8045-d8ecc607cc00"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("9d608883-4f26-4303-9903-d8de46433f04"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("bc6e314f-5d86-40dc-a791-d63be99c22bd"), (short)34, null, null, (short)1, "Primary" },
                    { new Guid("f611bf2d-3089-4e53-b362-cf740f1f102a"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("b30ffa71-9656-4f10-be64-cd92bad378c0"), (short)33, null, null, (short)1, "Low" },
                    { new Guid("be31e251-6784-4472-a771-86c159b3f9fb"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)2, "Yield management" },
                    { new Guid("69646d5e-0e73-4056-9dac-70ff0d0a9ebe"), (short)23, null, new Guid("c7b32094-6538-4e72-ad49-6ea1fda21562"), (short)2, "Other" },
                    { new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("42c22ecb-1f79-467a-8b1f-2e709de5a5e2"), (short)1, "a", null, (short)17, "Guarantees and warranties" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("d39c0155-1419-4a48-962f-2e42d5aca11b"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("abdbd71b-4c23-4cc1-aacb-2dac249540f3"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("3fe4a8e4-daa1-4edb-a209-2d9f6f9ced35"), (short)30, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)2, "Platform" },
                    { new Guid("373f6176-6eef-4866-96ff-2c4efe5c4a76"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)4, "Other" },
                    { new Guid("c7cb2b43-fc30-40ec-b06b-2bdeadc6000f"), (short)39, null, null, (short)1, "male" },
                    { new Guid("75ccb567-91f3-4966-91f6-30565cb59ba0"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("e3773f81-fa98-4ad4-b235-2bab8369e22b"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("5bf44939-b777-454a-86c2-280eea5fc6dd"), (short)35, null, null, (short)5, "Foreign Urban" },
                    { new Guid("58eac7eb-b165-4056-8df3-27e3ab23d1e9"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4b0ba05e-88c6-4c54-a313-880e3aee9905"), (short)2, "Frequency" },
                    { new Guid("3c36a2c7-4cd3-43b1-98f5-270c8c98edd7"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)5, "Other" },
                    { new Guid("31ca9e3a-ff44-41db-8833-2661abddb353"), (short)23, null, new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)3, "Other" },
                    { new Guid("6d62227c-94dc-4ad8-a89c-240fe74f26d6"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("4a427807-de66-429c-8ae0-2185f71d2543"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3943c265-621b-4738-93c8-4470986c3af3"), (short)1, "Ownership type" },
                    { new Guid("ce619ee3-d636-497f-8238-2ac9c9e79b49"), (short)40, null, null, (short)2, "Ads and Commercials" },
                    { new Guid("fd203ec9-9519-4adb-8c98-314cab2b4689"), (short)40, null, null, (short)3, "Printed Promotional/informative materials" },
                    { new Guid("0addb638-0a86-4fc8-90fa-332a530655b8"), (short)42, null, new Guid("598ee84a-c772-4156-abf3-bc0d57c678a1"), (short)0, "R & D" },
                    { new Guid("e8f6e9d6-0e37-4182-9c47-33c9d119ac73"), (short)31, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)3, "To the email" },
                    { new Guid("37c1161f-aac3-4e5e-81df-3cce00e3b25c"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("f2424d76-d25a-430a-ab55-3c0480a1f56c"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("73fcb86d-53b1-4063-87b8-3aa42702c820"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b4517dc0-8202-4cff-be3e-c11a1f78037c"), (short)2, "Frequency" },
                    { new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("70fad897-dcb6-4818-a9b1-39b2b08dd93c"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("a4b8b286-4fc6-4021-ab42-3952154ffeba"), (short)23, null, new Guid("7ac334c8-cafd-4f64-8414-00c61aa80cb7"), (short)1, "Other" },
                    { new Guid("ac7a78ec-1dab-4de4-a42a-38af55118921"), (short)42, null, new Guid("598ee84a-c772-4156-abf3-bc0d57c678a1"), (short)0, "Service provisioning" },
                    { new Guid("229ee29a-cac8-488c-9a75-37fbdbff4a42"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3c36a2c7-4cd3-43b1-98f5-270c8c98edd7"), (short)1, "Ownership type" },
                    { new Guid("c7250794-8be0-4cdb-99e7-37337b2e8fc1"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)3, "Sales buildings (shops)" },
                    { new Guid("ab5ffc0e-da10-4ed8-a7fb-369785911381"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("ad8c7415-613b-4c04-b7ee-3643d949fd2a"), (short)42, null, new Guid("53299dc3-8c18-486c-8be9-623d2152b9dd"), (short)0, "Marketing" },
                    { new Guid("e1da4359-882f-4fd7-8eb0-360b5f859c9a"), (short)42, null, new Guid("53299dc3-8c18-486c-8be9-623d2152b9dd"), (short)0, "Recruitment" },
                    { new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("2897fd3b-afad-47e5-8407-3582fb0cdf07"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)1, "Negotiation" },
                    { new Guid("a82e9156-c03c-4815-80ca-35508e2371ad"), (short)30, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)2, "Mobile" },
                    { new Guid("bf6b3a07-2578-4ab2-8ca8-21209388c38e"), (short)40, null, null, (short)4, "Other" },
                    { new Guid("085df303-2e4d-4dd0-9e9f-204085352597"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("87ffbf10-1f99-4d0b-ae5a-202736ed5a4e"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("2d9ebc0f-7a82-4891-8dc6-1fa64b5fa22d"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)1, "Manufacturing buildings" },
                    { new Guid("3325759e-8add-4b30-a00c-10ce7fbbd330"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("ef60cdef-d5b1-421a-aa36-10463faf9f6e"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("fe7ff7a5-af48-4eb2-b60e-0d76c808a43f"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)5, "Other" },
                    { new Guid("e6aaacaf-9550-4937-bf13-0d1ff0b69874"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)1, "Electricity" },
                    { new Guid("c31ebd92-79bc-417c-bab4-0c3960778ef7"), (short)32, null, null, (short)5, "35 - 64" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("c48b255a-2451-42e2-a889-0a76e5b850e0"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("25feae02-736b-44c7-b6e7-06fa502f4c63"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)1, "Brands" },
                    { new Guid("6a09985e-01b1-4034-9a82-05945dce19a5"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("75c81e8e-aa76-4f81-895e-0465da7b6d7a"), (short)26, null, new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)1, "List price" },
                    { new Guid("e93d16a1-fc41-4443-b88b-023d051103bf"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("7c36e454-f5df-4cbf-9507-01a389bcb923"), (short)23, null, new Guid("4a3658fb-71ac-4feb-9104-7761fdd5cc9b"), (short)1, "Other" },
                    { new Guid("5cb61693-d73a-40fd-9664-01921eeba8cc"), (short)23, null, new Guid("abdbd71b-4c23-4cc1-aacb-2dac249540f3"), (short)1, "Other" },
                    { new Guid("7ac334c8-cafd-4f64-8414-00c61aa80cb7"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("bbe1a5d6-d7d1-4d70-a5cf-00589419ce8d"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)2, "Cost of warehouse" },
                    { new Guid("fef1c6f8-493c-4641-9f0c-1141cb762605"), (short)26, null, new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)3, "Volume dependent" },
                    { new Guid("e1d977e9-0c83-4f69-8bfe-3f2689b6cec2"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)3, "Real time market" },
                    { new Guid("aa2e4a07-25cf-454b-9505-118ee9077477"), (short)23, null, new Guid("4bf467d0-1c9d-469d-9dad-45b6bf4b7f47"), (short)1, "Other" },
                    { new Guid("2984418a-638e-4da9-be1d-12ba94d8ffaf"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("578b2d6c-608f-4bd7-9e38-1f888650e6b0"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("09b845a4-df9c-4f53-b833-1f69ae6d1835"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("8e07b533-f25e-4227-8fd8-1b2f19a7b4f3"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("bbab5ef4-bbd3-44aa-a879-1a792a5feada"), (short)34, null, null, (short)2, "Secondary" },
                    { new Guid("0ea957e0-d54e-4729-b7a7-1a4ac6b0b9fc"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("d2a35000-6520-47fb-921a-1968a38f6eb8"), (short)33, null, null, (short)2, "Medium" },
                    { new Guid("4261a424-6b58-467c-a5da-1844827950b5"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)27, null, null, (short)1, "Direct sales" },
                    { new Guid("a560bf73-2db4-46de-a121-17756a2cd4ad"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)1, "Manufacturing building" },
                    { new Guid("c109d793-c4af-4ade-b0c1-17157bc927de"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("e83d8ad7-c709-41b3-b1cd-15e1871fb374"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("c6e60be8-eef9-41fe-948b-133375a3c43b"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("404d16aa-f0f7-452a-88ce-13109e57724a"), (short)30, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)1, "Own website" },
                    { new Guid("ac1f0f22-1958-45fd-851b-130a155e86c3"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)4, "Marketing" },
                    { new Guid("bdb6d057-80b7-411a-a6b6-12aae71581c3"), (short)33, null, null, (short)3, "High" },
                    { new Guid("ab606dbd-08d6-49be-8bc6-844812d8b214"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("ef193985-9b48-495e-a40c-3f53f2b0b30a"), (short)32, null, null, (short)1, "Under 12" },
                    { new Guid("ab3c7d47-062b-437e-a164-4172444e276f"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("b4517dc0-8202-4cff-be3e-c11a1f78037c"), (short)1, "Ownership type" },
                    { new Guid("c267cba0-ef66-48d5-96bd-74d4efd1b52b"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)3, "Fees to distributors" },
                    { new Guid("8f4213e4-50ce-42f9-aee1-73e2d6efeaff"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("fc87ba60-6c43-4420-bdb0-eacc00ffbca5"), (short)1, "Ownership type" },
                    { new Guid("e31f5678-6604-47a6-ac67-724b8d0d54e8"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)1, "Transport" },
                    { new Guid("aa351db4-3b28-4cab-ad95-722bfcba23dc"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)2, "Licenses" },
                    { new Guid("1947e5da-01ea-4d22-8e37-72264d47d9b8"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("316e0636-3ce5-4ba0-b72f-7223698fb8fb"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("7146d46e-a7b5-429b-85ee-74f24e9b8894"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("2f2f8c7f-ac0c-4115-a3b8-714e0d6529d9"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("f4056ba5-de88-45b6-92a9-6f9707e4f494"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3066446c-5e9b-4321-bdf6-a47f367f61c5"), (short)2, "Frequency" },
                    { new Guid("c7b32094-6538-4e72-ad49-6ea1fda21562"), (short)22, null, null, (short)4, "Salaries" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("37634235-3b04-4aad-a647-6d79a2c88655"), (short)36, null, null, (short)2, "Medium" },
                    { new Guid("b2706a04-d62f-4103-ae40-6b5868029c73"), (short)31, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)2, "Courier service" },
                    { new Guid("4718bb8b-3018-4408-9ff1-68ab9c4f2b87"), (short)34, null, null, (short)3, "Higher education" },
                    { new Guid("5a78cb95-3eb4-432a-a0cc-68886ae692da"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("e221190c-00bc-404f-a540-708d0e673454"), (short)23, null, new Guid("df741ccc-d2ef-4797-8c96-8b5be0344f88"), (short)1, "Other" },
                    { new Guid("bbc364e1-2394-48c7-8aaf-774ba76942b6"), (short)36, null, null, (short)3, "Large" },
                    { new Guid("4a3658fb-71ac-4feb-9104-7761fdd5cc9b"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("67cdf9e6-acc0-404a-a189-78325e83f547"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("e04a476c-a409-472a-beb4-819b104d9731"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("acb3829b-c7e2-45eb-810d-80cd3d4f5f39"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("96f638ad-c41f-492f-982a-7f4018bcb3a6"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("d89128ed-072e-4f22-aea3-7f058c855888"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("a3a74886-85d0-4861-baa3-7d09bea0e583"), (short)38, null, null, (short)3, "Muncipality" },
                    { new Guid("e1915d59-a5a4-43bd-a5db-7c8ab320371a"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("aae57ccf-f33c-4a0e-925a-7a65d8ca171e"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("aa02701e-c0d0-4c27-a09d-7a4987629640"), (short)23, null, new Guid("0bff5c28-137c-4890-90df-ba7e0746431c"), (short)1, "Other" },
                    { new Guid("4cb290b2-7fbc-4846-be7b-79f9e3efbb46"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("c64ed84d-db99-4a25-95f1-79bb99fa6936"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("dd32e3d1-de98-436a-be89-79206cf5204b"), (short)35, null, null, (short)2, "Domestic Urban" },
                    { new Guid("7ace64a6-77c6-44de-a675-78ff13ca0859"), (short)31, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)2, "Delivery to home" },
                    { new Guid("08a43d2e-87da-433b-9656-787878f8c04d"), (short)42, null, new Guid("53299dc3-8c18-486c-8be9-623d2152b9dd"), (short)0, "Continous training" },
                    { new Guid("f71ce8b4-dbd8-4280-a216-66677e115f74"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("bdf69fe7-c3e3-44e1-a984-41041ea08e96"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("ee238326-5d11-4531-92b0-6565f42ae874"), (short)31, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)3, "Courier service" },
                    { new Guid("9454b766-1241-44ca-ae12-63e101fbae55"), (short)38, null, null, (short)2, "National Government" },
                    { new Guid("54afad44-3157-4521-90df-543d4686355a"), (short)23, null, new Guid("67dc4bec-4276-44df-a573-e95b64864a7e"), (short)1, "Other" },
                    { new Guid("a5a126b8-fb9a-413c-a5fa-53870b90df77"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("17063605-ce9b-4e92-9d41-52ea1cee6632"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("925f1189-56f9-4cc3-ae1e-50ddbab2a29d"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)4, "Auctions" },
                    { new Guid("22d688a4-1dae-42c2-98af-4e076de1ca73"), (short)32, null, null, (short)4, "25 - 34" },
                    { new Guid("a9677a24-bc3c-40aa-8265-4be52545113b"), (short)39, null, null, (short)2, "female" },
                    { new Guid("b0cb1000-5a92-47a0-a45b-499c5f580524"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("7d87bb63-1cd8-4ec0-a46d-487c77da365f"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)5, "Maintenance" },
                    { new Guid("5a7a66cb-25f4-462b-b1f7-47b97735d7da"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("d8cb55ce-d517-4912-8b07-46d41d4d4c4a"), (short)42, null, new Guid("b2445fa0-fa0d-4f77-b545-a3d10f6da338"), (short)0, "Operations" },
                    { new Guid("4bf467d0-1c9d-469d-9dad-45b6bf4b7f47"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("adcdc439-8170-4fab-a70d-457c1b98bc92"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("da250714-2420-4d57-8015-44fe1e1ff294"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("3943c265-621b-4738-93c8-4470986c3af3"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)3, "Transport" },
                    { new Guid("88fa173b-e9a8-44a7-be1a-43fab1989a02"), (short)11, null, null, (short)5, "Agents" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7851aaea-93c4-48e8-8817-563ef55cf61a"), (short)38, null, null, (short)1, "International Organisations" },
                    { new Guid("e1371329-8c9e-4ab3-95fe-654e7f64dfc4"), (short)23, null, new Guid("f61f60ab-7991-4dac-b40e-c742dcef878b"), (short)1, "Other" },
                    { new Guid("5d465e51-2608-4a01-af4f-566fcc5e7519"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3c36a2c7-4cd3-43b1-98f5-270c8c98edd7"), (short)2, "Frequency" },
                    { new Guid("cc3cddf7-c4fa-4679-8feb-58935864f5b2"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("7682545b-fbee-475e-ab30-5a1f694c81c6"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)3, "Software" },
                    { new Guid("e2d723ce-1ea6-4d1e-a35e-5b47907d2d2a"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)1, "Specialists & Know-how" },
                    { new Guid("8f79391b-d687-4515-9292-5b4958ef0589"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("0ff6b626-a1ff-4184-b1bb-5bf2992091bd"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("75bcee28-686d-47e6-82b2-5c2a32168377"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("1b776dfa-533e-4511-8185-5c576db8dcec"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)3, "Transport" },
                    { new Guid("58b41b4d-da41-4f9b-9cec-5da895a0b502"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("3a0ffc1e-bede-4f74-9cff-5735a0b600f9"), (short)37, null, null, (short)1, "Goods" },
                    { new Guid("f9862c29-9a20-4cbe-8fa2-5e1660f6b8da"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("95f441a5-2f4e-4c6e-93e7-5e18cbe26749"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("c5acf766-38a0-4cf2-8649-6074f10a6b9f"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)2, "Inventory buildings" },
                    { new Guid("62d8c572-b4b2-45e7-be6d-607de423b903"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("651a1fcd-0ad6-4311-9bb0-61cb8b210146"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("53299dc3-8c18-486c-8be9-623d2152b9dd"), (short)41, null, null, (short)0, "Problem solving" },
                    { new Guid("df75df99-8916-4eba-8ef1-636c8cc2478b"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ca5124ab-0c2f-4224-88b1-f579a01d2522"), (short)1, "Ownership type" }
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
                    { new Guid("c247e922-419e-4a00-bf22-045d0afc1c38"), "A.01.11", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("74701920-0309-4048-9e3d-ea2f411c8dea"), "J.62.02", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Computer consultancy activities" },
                    { new Guid("71965359-a5f8-4c95-a783-f39475490f3e"), "J.62.09", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other information technology and computer service activities" },
                    { new Guid("e58100ef-915e-4f7e-9b0b-fd3893b69672"), "J.58.19", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other publishing activities" },
                    { new Guid("49bc055a-521c-4959-9cf4-00073430aa80"), "O.84.24", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Public order and safety activities" },
                    { new Guid("0cdfb6c7-d3ab-491b-93a8-1901b0c5fee8"), "O.84.23", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Justice and judicial activities" },
                    { new Guid("dbb18c39-0d4d-4ddd-bdae-29c1a570dd06"), "O.84.3", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Compulsory social security activities" },
                    { new Guid("703510b6-2963-4785-8e95-2e7d10200c26"), "O.84.13", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("5be202e6-40f4-483d-8890-5267e7f4c70b"), "O.84.25", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Fire service activities" },
                    { new Guid("d99ecbf5-1d12-49a7-b01a-699288bb92f6"), "O.84.2", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Provision of services to the community as a whole" },
                    { new Guid("732a159a-23a8-4975-b8cf-782c0e11436f"), "O.84", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Public administration and defence; compulsory social security" },
                    { new Guid("9ace88d1-673c-429e-8e15-7e63685a987e"), "O.84.22", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Defence activities" },
                    { new Guid("45748ced-9467-4f93-87b8-7fb35863011a"), "O.84.1", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("d837d593-0852-4a59-9240-e7410382ee2a"), "J.58.12", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Publishing of directories and mailing lists" },
                    { new Guid("9842e673-7da5-476a-805d-80d1546422a8"), "O.84.21", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Foreign affairs" },
                    { new Guid("b25780fc-6941-4d1e-9a21-abf328e9514d"), "O.84.30", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Compulsory social security activities" },
                    { new Guid("968fbd0e-4680-4560-862a-c02dcb31e302"), "O.84.11", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "General public administration activities" },
                    { new Guid("b31f060f-cbf7-4ae6-8e0e-244cb92ace15"), "P.85.31", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "General secondary education" },
                    { new Guid("ecd22ba1-cf8d-4b4c-bf16-285234e106bc"), "P.85.2", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Primary education" },
                    { new Guid("f3bab5ee-e390-42c4-aadd-34f7190fab22"), "P.85.4", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Higher education" },
                    { new Guid("490185dd-dab0-4b21-b48f-3b4719dfc56c"), "P.85.60", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Educational support activities" },
                    { new Guid("babe5766-5042-48a0-8c68-516c3fe4ecdf"), "P.85.52", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Cultural education" },
                    { new Guid("94e003c9-f40a-4bef-8926-5ecb15445c86"), "P.85.51", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Sports and recreation education" },
                    { new Guid("ab1cb6b8-b2a5-430f-a1e5-6e08a3877e1d"), "P.85.41", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Post-secondary non-tertiary education" },
                    { new Guid("b1a3793c-ba21-4627-b9bb-7afebe1f65a9"), "P.85.1", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Pre-primary education" },
                    { new Guid("59be036b-0d99-48eb-b5de-80d26f6a528a"), "P.85.42", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Tertiary education" },
                    { new Guid("076f37f3-81ee-43c8-b0b5-9809d8915ea9"), "P.85.53", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Driving school activities" },
                    { new Guid("8cc79ccf-9326-481f-96e1-84cb86517e70"), "O.84.12", new Guid("92a890d6-1eb5-467f-8eb3-65a1eafba707"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("37bfae2f-8611-4fca-815f-e398481136c5"), "J.62.03", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Computer facilities management activities" },
                    { new Guid("3d2b113c-815a-4cff-902d-e0eabf8b9889"), "J.58.2", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Software publishing" },
                    { new Guid("7afcfd4c-5ad0-4918-bca5-dcf888007ac2"), "J.61", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Telecommunications" },
                    { new Guid("23ff4f21-6f23-436e-8de9-4bb4eec8b2e3"), "J.62.01", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Computer programming activities" },
                    { new Guid("1d089673-bd12-4493-ae01-4e463cfd4b42"), "J.58.13", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Publishing of newspapers" },
                    { new Guid("9f4f41f1-ae1a-4f55-98eb-5c3ca2793644"), "J.59.11", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Motion picture, video and television programme production activities" },
                    { new Guid("914b0bb4-1800-483c-bf15-600417f991eb"), "J.59.13", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("be369878-7539-4e61-9dff-616ac0e2135a"), "J.61.2", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Wireless telecommunications activities" },
                    { new Guid("fd221301-7118-4578-bede-735cd3bac4c0"), "J.60.1", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Radio broadcasting" },
                    { new Guid("187d6074-5f9b-4e7f-b26d-73ab622b23fc"), "J.58.1", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("35bffdd5-dcb5-4d86-ba90-74360f091e70"), "J.59.12", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("4575ebae-169a-4207-a4af-7f7e72debe20"), "J.60.20", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Television programming and broadcasting activities" },
                    { new Guid("3e63ee34-d2e7-487c-aa2b-8745e0c18f78"), "J.61.1", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Wired telecommunications activities" },
                    { new Guid("bdad184c-7cca-4394-9a94-87d419111579"), "J.61.10", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Wired telecommunications activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f1c44a80-a772-4116-8cbb-89f59b630e32"), "J.58.21", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Publishing of computer games" },
                    { new Guid("85978871-beb7-415d-834a-919b2572f715"), "J.62.0", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Computer programming, consultancy and related activities" },
                    { new Guid("51e1af2b-abb0-463e-9698-931df0fe8baf"), "J.62", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Computer programming, consultancy and related activities" },
                    { new Guid("d0317f5a-b948-4a21-b11c-967484111263"), "J.58.11", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Book publishing" },
                    { new Guid("fc38f0a2-952a-4cfd-8d71-97cf8caa020b"), "J.63.99", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other information service activities n.e.c." },
                    { new Guid("62d28c44-1734-449e-89f0-9d13acc495d6"), "J.61.3", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Satellite telecommunications activities" },
                    { new Guid("60817cdc-58ea-45fb-9dfc-9d33ad331a81"), "J.59.14", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Motion picture projection activities" },
                    { new Guid("59d8db6d-b27e-422d-8d90-a36c1b10ee19"), "J.61.90", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other telecommunications activities" },
                    { new Guid("b83a72dc-f459-41af-9f11-a6087f146b0a"), "J.60.10", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Radio broadcasting" },
                    { new Guid("28cbc141-52ae-43dc-b746-a7d8225ca651"), "J.58.29", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other software publishing" },
                    { new Guid("58cb352a-57c8-4076-8a2d-ac7b7c50bbb1"), "J.59.20", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Sound recording and music publishing activities" },
                    { new Guid("cba55115-913a-4d5f-b93d-adae0d80c9a0"), "J.63.1", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("e3439f23-d3ae-4938-8010-b53c5a0546c2"), "J.60", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Programming and broadcasting activities" },
                    { new Guid("caa0725a-3d6f-4ff2-9337-b957029f2a17"), "J.60.2", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Television programming and broadcasting activities" },
                    { new Guid("b8998d68-3e54-49a5-8d53-be56cfb63c24"), "J.59.1", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Motion picture, video and television programme activities" },
                    { new Guid("94f5a466-0bdd-44b5-b4e4-c2ec46806669"), "J.61.9", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other telecommunications activities" },
                    { new Guid("32c185fe-d326-479f-bfed-a469a050dee0"), "P.85.20", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Primary education" },
                    { new Guid("ff82ae36-7e88-437b-91c1-496fc61eaf98"), "J.59", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("288e94e7-17d1-4210-8e26-a9836337e963"), "P.85.32", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Technical and vocational secondary education" },
                    { new Guid("7cbdfbf7-9b11-407c-9d94-b63a8c634f0d"), "P.85.10", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Pre-primary education" },
                    { new Guid("a40931c2-9d8c-4150-9b58-53070d36d5e4"), "M.71.20", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Technical testing and analysis" },
                    { new Guid("971b7746-cc41-4cc7-856a-603dfb67fbcb"), "M.70.21", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Public relations and communication activities" },
                    { new Guid("a1f5d187-ad2d-4411-b466-780befb24b5c"), "M.74.30", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Translation and interpretation activities" },
                    { new Guid("f649b259-0dcb-42f2-8232-882cae929802"), "M.73.11", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Advertising agencies" },
                    { new Guid("d2ecbc76-8a64-47c5-86da-980c1a551274"), "M.73.2", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Market research and public opinion polling" },
                    { new Guid("3c9bfe63-abcc-4867-9feb-9c72d51cbec6"), "M.74.10", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Specialised design activities" },
                    { new Guid("ea113900-94ee-4787-8c87-a539cb7c52bb"), "M.69", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Legal and accounting activities" },
                    { new Guid("d94833c5-8765-4d7e-a22e-a8260096a2db"), "M.74.90", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("97616064-5eda-426c-9f04-a8869b7eb880"), "M.70", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Activities of head offices; management consultancy activities" },
                    { new Guid("ceb7b50c-ce44-48d4-991f-b4d39d2c216b"), "M.71.12", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Engineering activities and related technical consultancy" },
                    { new Guid("b453646c-2c4f-4b74-a3b8-bdecac7a5428"), "M.74", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Other professional, scientific and technical activities" },
                    { new Guid("aa9bd953-f31f-46a1-8652-be5a23b1361d"), "M.69.20", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("65c73322-4042-44f9-8422-5216dce61dbe"), "M.73.1", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Advertising" },
                    { new Guid("c51cbd8b-e955-4f61-ae22-c14cfe6e08bd"), "M.69.2", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("16176374-d74a-4f4c-a8ef-cbfb5e6f9ce2"), "M.73.20", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Market research and public opinion polling" },
                    { new Guid("f2a268ac-1cfe-461f-b7a7-ce914a3397cd"), "M.71", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("5eb53ad1-f386-4c04-b40b-ceae082d0ad2"), "M.69.10", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Legal activities" },
                    { new Guid("71760927-eb3f-4045-b06b-d12dcea7dab2"), "M.70.1", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Activities of head offices" },
                    { new Guid("837201ae-21ec-4388-b7ed-d28a1b75e749"), "M.74.3", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Translation and interpretation activities" },
                    { new Guid("a7be8a39-f20c-4cb9-b843-d45d2ed2ceb2"), "M.74.2", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Photographic activities" },
                    { new Guid("1976de7b-5cd7-4b6c-a888-dcd7b6562398"), "M.70.22", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Business and other management consultancy activities" },
                    { new Guid("89eef24c-bb3c-4169-96c8-e045b3124415"), "M.71.2", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("aebbdd83-80ee-44d2-934f-ed46cf05879d"), "M.72.2", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("a9c09934-52ce-40d7-86b2-eef3633dcddd"), "M.74.9", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("f41a095b-cf68-42f3-af04-f90a4135f5f1"), "M.74.20", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Photographic activities" },
                    { new Guid("7b65f37c-34c0-4ed2-964a-fec507e28dda"), "M.72.19", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("8bb4ebd7-7244-4a9d-9847-c32938b04064"), "M.73.12", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Media representation" },
                    { new Guid("ef07a654-345a-4342-86e8-4d444a432259"), "M.73", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Advertising and market research" },
                    { new Guid("30b22b01-2bda-46fc-9961-456cf213acc5"), "M.69.1", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Legal activities" },
                    { new Guid("60bf1650-6f84-48e4-8a2b-4028ee681b16"), "M.75.0", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Veterinary activities" },
                    { new Guid("99c5f09f-ea51-484a-8251-d577d51d1a7c"), "P.85.3", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Secondary education" },
                    { new Guid("b513fbd4-b32b-45b5-8618-d98258136d2f"), "P.85.6", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Educational support activities" },
                    { new Guid("49e3e000-64a4-4982-b88e-df68965296de"), "P.85", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Education" },
                    { new Guid("306496d4-2fef-4f08-9935-ed49bf887ec5"), "P.85.59", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Other education n.e.c." },
                    { new Guid("76075eb6-54e4-4b25-8b80-0027c6d821d1"), "D.35.23", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Trade of gas through mains" },
                    { new Guid("5698a85b-1aeb-4640-befa-147891735abd"), "D.35.22", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Distribution of gaseous fuels through mains" },
                    { new Guid("fe13d798-c96f-40fb-b928-16e16104032e"), "D.35.14", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Trade of electricity" },
                    { new Guid("09eb41de-3380-4f2f-a20d-19817ef44a60"), "D.35.12", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Transmission of electricity" },
                    { new Guid("f5f51619-a57c-4dce-a17e-27503336d6a5"), "D.35.3", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Steam and air conditioning supply" },
                    { new Guid("5a2abcc1-595d-4415-b56c-42fea43e2f69"), "D.35.30", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Steam and air conditioning supply" },
                    { new Guid("ee9191de-f58c-4a1b-b5b4-4ff99f84296e"), "D.35.13", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Distribution of electricity" },
                    { new Guid("b7eed11c-dcd7-4b0c-a521-539004ed951f"), "D.35.21", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Manufacture of gas" },
                    { new Guid("343fa7d1-87c8-4a0a-8e1c-7f70fb319ed8"), "D.35.1", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Electric power generation, transmission and distribution" },
                    { new Guid("a94ddc62-7118-4ca3-97af-7ffbf3f5d011"), "D.35.2", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("4f16dc30-eed5-425e-b517-c2873f62d4d7"), "D.35.11", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Production of electricity" },
                    { new Guid("e9327025-49c2-43cf-807c-db5c150b5e0a"), "D.35", new Guid("79dee4b7-94f0-4ee5-94f7-705d50ba3a20"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("eb7c8b42-4800-477a-a97d-0d8a87dfdcff"), "M.71.1", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("44a34d15-b9da-4b85-80ae-13b34f280b68"), "M.72.20", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("6597eb1e-36d0-4ab5-a942-185a73c64b01"), "M.74.1", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Specialised design activities" },
                    { new Guid("6fce9794-0259-4e09-9404-1c417a45e53f"), "M.75", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Veterinary activities" },
                    { new Guid("f57afccb-7cb3-4b9f-98f6-1dde25737758"), "M.72.11", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Research and experimental development on biotechnology" },
                    { new Guid("48c8b4a5-44c0-4696-b73b-1e9ef85a519d"), "M.72", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Scientific research and development" },
                    { new Guid("b10d800f-ae5e-4122-81a3-2908706549bb"), "M.70.10", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Activities of head offices" },
                    { new Guid("ea940650-c2b9-4523-886c-294ee6284c1d"), "M.71.11", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Architectural activities" },
                    { new Guid("7a0eaf2f-6489-4e9f-a52b-35dbd587f924"), "M.72.1", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("ce34ff2d-752a-4530-910a-3d1ab62982e0"), "M.75.00", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Veterinary activities" },
                    { new Guid("d0b0cd02-d337-4f67-b9ef-3d7b9599d62f"), "M.70.2", new Guid("852a62fa-0c08-4675-a58b-7fe1b8476aed"), "Management consultancy activities" },
                    { new Guid("b722d94a-ae14-4575-b211-b3714c86c10d"), "P.85.5", new Guid("e72f48a2-1aeb-416d-8282-65b96623a98c"), "Other education" },
                    { new Guid("6c44fab2-f431-4b78-9b8b-0067c005e4d8"), "G.47.22", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("ec8d4283-83af-42f4-ac47-488d26e78ae3"), "J.63.91", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "News agency activities" },
                    { new Guid("2cbd9966-9325-4999-bfcd-3fef15f5dd5d"), "J.63.11", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Data processing, hosting and related activities" },
                    { new Guid("a92ec71c-6fc5-43a7-89c0-f94a49d92c20"), "C.21", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("8001f838-6faf-42b4-b741-fbce265f7af3"), "C.24", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic metals" },
                    { new Guid("57b7d8f6-8493-46d9-9560-fce6e0b1ff4d"), "C.30.40", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of military fighting vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("370008ab-6b73-48fe-8372-fcf22cf11460"), "C.18.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Pre-press and pre-media services" },
                    { new Guid("656ddfc6-45a5-4c84-9a67-fe46c330729d"), "C.23.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("4aa94118-1804-481e-9103-feeb0e97973c"), "C.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of beverages" },
                    { new Guid("2aaed416-eb99-4d15-a03b-ff921e17cd5d"), "C.32.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of jewellery and related articles" },
                    { new Guid("c77d6527-8f9b-4cbb-ad36-ffcba1faaa3e"), "C.30.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Building of ships and boats" },
                    { new Guid("877fc485-a93e-4db6-9123-00bcb56fb1c0"), "K.64.19", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Other monetary intermediation" },
                    { new Guid("aa70949b-9a69-4bc3-a766-012f8883eb54"), "K.65.1", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Insurance" },
                    { new Guid("44d7fa9a-3399-402a-a588-01b962764242"), "K.64.30", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Trusts, funds and similar financial entities" },
                    { new Guid("94565981-9f50-435b-82b5-041cea6d1fef"), "K.64.3", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Trusts, funds and similar financial entities" },
                    { new Guid("1651dace-6c31-41e7-8e4b-f920143f79d6"), "C.30.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("ffd39030-b91d-4bd3-9d9c-0f0b2ac388ed"), "K.66.29", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("68557135-037d-4974-9592-1d6ca1298a85"), "K.66", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("6326aa4e-d5fe-4aec-934b-1da86e90355a"), "K.66.22", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Activities of insurance agents and brokers" },
                    { new Guid("a032cdb3-bbb8-42c6-a176-2d3ae366b251"), "K.65.2", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Reinsurance" },
                    { new Guid("122e4b2e-5a2c-4c7d-bc3c-2fa504c09bc0"), "K.64.11", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Central banking" },
                    { new Guid("56c7a761-746e-4b0d-bad6-323f28abcae5"), "K.64", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("a25fd63b-a5e6-41d9-8aca-33b0357eda91"), "K.65.20", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Reinsurance" },
                    { new Guid("f3cb5a60-1151-446a-83fe-3d132dc7e416"), "K.64.91", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Financial leasing" },
                    { new Guid("3db30ca4-2afb-4dcc-81b6-3e882b5544f1"), "K.66.30", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Fund management activities" },
                    { new Guid("c46859ff-e50e-4f9a-88c1-4320d692ad5f"), "K.66.2", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("960e4978-0c17-4e52-85e1-4566d473f01c"), "K.66.21", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Risk and damage evaluation" },
                    { new Guid("b59bf426-8d54-470b-a573-55d66e1bc2c6"), "K.65.11", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Life insurance" },
                    { new Guid("bb829910-fdb1-4d65-966e-7aa960a9ac9b"), "K.64.99", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("042fb915-bf48-495b-9a76-18b210f93012"), "K.64.2", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Activities of holding companies" },
                    { new Guid("91cb6735-ebb6-4f17-85eb-f7f57ba02c59"), "C.13.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other textiles" },
                    { new Guid("6d40870c-6c83-471f-ae76-f7e237234881"), "C.32.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("06a40781-4537-4c78-9219-f7b41b3f6e00"), "C.22.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of rubber products" },
                    { new Guid("c4fefc7e-ca17-4123-88a8-e59dff5ed727"), "C.26.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" },
                    { new Guid("e13017f7-72a9-4c5a-b83b-e5e882306379"), "C.17", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of paper and paper products" },
                    { new Guid("8b94c101-a8b1-40be-abdf-e6b38b001335"), "C.15.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("0bec6df6-5dc1-4ba5-b4f5-e6ff17b807c3"), "C.20.51", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of explosives" },
                    { new Guid("4a002f0b-3378-4682-88dd-e75fd3f7abad"), "C.25.93", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wire products, chain and springs" },
                    { new Guid("c7459be7-61ee-4076-8141-e83038421200"), "C.11.01", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("07e67150-d08c-4813-8937-e8819daf317b"), "C.20.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("6889ca98-a355-4389-b594-e97e0bff4aa1"), "C.26.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("dfcec0c9-e2bb-4ea1-a5b7-ea524bcefc83"), "C.16.23", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("a096b0c1-1161-49e0-867a-eb77f959d5d2"), "C.10.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of dairy products" },
                    { new Guid("2c5b0994-973f-417c-a165-ed6ff3c4209b"), "C.17.24", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wallpaper" },
                    { new Guid("80828417-e42a-4a4d-bb10-edf3bc60189c"), "C.25.21", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("d3a0e816-e109-49c1-aa75-eec2798f8cad"), "C.17.22", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("3fc3d2fd-179d-40da-acbf-efc37010304e"), "C.28.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other taps and valves" },
                    { new Guid("04912b51-3dae-4d3c-81a0-f05ffe535b62"), "C.10.8", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other food products" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1c48b987-afee-410d-b9d3-f06c7a16ddc9"), "C.28.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other general-purpose machinery" },
                    { new Guid("5fc9ee5a-1fdc-424b-91e5-f0700e0b85ab"), "C.20.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("5bd6387d-cd1f-40c8-8b16-f275be0f26c3"), "C.29.32", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("c95536e1-4cb9-4a8f-948e-f288b8330778"), "C.10.42", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("c6ad7d9b-b93c-4403-bd21-f2bb0f119bed"), "C.13.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Weaving of textiles" },
                    { new Guid("0a9ed60b-ea33-4ccd-b98d-f3029cfd4d03"), "C.25.94", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("c746df2b-5aae-4fab-a944-f3d941db93ea"), "C.24.42", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Aluminium production" },
                    { new Guid("aadeccd7-2d64-4bf1-a672-f4dfb0b46240"), "C.31.01", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of office and shop furniture" },
                    { new Guid("194ca9d3-32b7-4d72-9a30-f660f11499a9"), "C.10.7", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("1a4232db-dedc-4459-9cfa-f6b10c8e907f"), "C.10.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("040594ab-482f-4f22-88f8-f734df1f4998"), "C.20.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other organic basic chemicals" },
                    { new Guid("a1d20940-a13a-4cdd-b34e-f7acad2da8bc"), "C.16.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Sawmilling and planing of wood" },
                    { new Guid("16784e91-ff70-452c-aae1-804cd46825be"), "K.64.92", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Other credit granting" },
                    { new Guid("01c6ad85-e2b4-4f88-b253-447d304cbb95"), "J.59.2", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Sound recording and music publishing activities" },
                    { new Guid("10bdbe61-2536-40be-b09f-a8fc3b916982"), "K.66.3", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Fund management activities" },
                    { new Guid("b6ad6a05-db09-4e28-b769-c794793e5cc4"), "K.66.12", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Security and commodity contracts brokerage" },
                    { new Guid("6acd55bc-a348-4e3f-a7a8-3676ab10d9a7"), "R.90.02", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Support activities to performing arts" },
                    { new Guid("d8a63b3c-43a1-4961-bb6c-379e7f16d929"), "R.93.13", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Fitness facilities" },
                    { new Guid("223a956c-d96a-46f7-9fc8-39e17d179911"), "R.91.02", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Museums activities" },
                    { new Guid("a7a46eca-465e-4751-a22f-42383a05405e"), "R.90.01", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Performing arts" },
                    { new Guid("2daf2d4e-a8d3-4c79-9a54-501a39a9592e"), "R.92.00", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Gambling and betting activities" },
                    { new Guid("59e5c404-89ed-4847-8684-553968883e14"), "R.91.04", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("127dfd1d-49d0-4b02-bb9f-5aad71539357"), "R.91.0", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("d209e40f-0df0-4f1f-9599-5ac5f838a036"), "R.91.01", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Library and archives activities" },
                    { new Guid("42768fcd-bb0e-4dc6-bc0e-5afddcade4f4"), "R.93.12", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Activities of sport clubs" },
                    { new Guid("45e27e18-e9dc-426d-9e73-701212c42939"), "R.93.29", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Other amusement and recreation activities" },
                    { new Guid("482c5c42-6d71-41c4-bdcc-8e6fd20034e1"), "R.90", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Creative, arts and entertainment activities" },
                    { new Guid("2eaed180-2840-4139-a85d-9aef06b99cf9"), "R.93.2", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Amusement and recreation activities" },
                    { new Guid("f4677561-161c-463f-bd5b-303cb5c6faf6"), "R.90.03", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Artistic creation" },
                    { new Guid("e6be8104-d3b0-4039-a60d-a7932dd24a52"), "R.93.19", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Other sports activities" },
                    { new Guid("f9222bab-417f-4e43-a1e4-afc9c45dda59"), "R.92", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Gambling and betting activities" },
                    { new Guid("69bd726d-dd37-4e25-bff8-c37b4a2cd6a2"), "R.91.03", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("fbfc5be4-8426-498c-8b8a-dff1a7edc966"), "R.93.11", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Operation of sports facilities" },
                    { new Guid("220e54f3-8f07-4501-b82b-eb619f7c3797"), "R.90.04", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Operation of arts facilities" },
                    { new Guid("3eac1e01-3332-46f7-b7e5-f119bb5c63be"), "R.91", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("4a15de28-9f71-4052-8e3f-00665824c310"), "J.61.20", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Wireless telecommunications activities" },
                    { new Guid("2fce8270-4e21-46f1-84cf-00ee483d4625"), "J.63", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Information service activities" },
                    { new Guid("2c6ce424-20b6-4a83-bb9b-02deafdcba54"), "J.61.30", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Satellite telecommunications activities" },
                    { new Guid("bc7f20b1-70b8-496a-b30e-060883cc75ff"), "J.63.12", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Web portals" },
                    { new Guid("33396cdb-aefa-4291-a291-0cee53b70885"), "J.58.14", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Publishing of journals and periodicals" },
                    { new Guid("179f582f-47c6-442e-980b-1f6a3e916237"), "J.58", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Publishing activities" },
                    { new Guid("8f00785f-7f28-4bc8-ac7e-2976902a5cea"), "J.63.9", new Guid("744698bc-9ad1-40d2-a810-4e3d865e252c"), "Other information service activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1efbbd22-917a-4dc7-b918-ab236fe8de5b"), "R.90.0", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Creative, arts and entertainment activities" },
                    { new Guid("79bef387-8943-4c3f-bcbc-240993e6e8ea"), "R.93.21", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Activities of amusement parks and theme parks" },
                    { new Guid("5d47767e-fe56-4161-ad0b-1b7504f0098c"), "R.92.0", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Gambling and betting activities" },
                    { new Guid("bff43fc3-d5c5-4989-a270-0be8cb186881"), "R.93.1", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Sports activities" },
                    { new Guid("854bcc1d-e2fd-4e48-ac39-d508fb95b556"), "K.65.30", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Pension funding" },
                    { new Guid("f7c43efa-dfb4-461f-9ba8-e1e88bb4e4cd"), "K.66.11", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Administration of financial markets" },
                    { new Guid("0dc7c87c-e976-4668-94e8-e6e3bd167b48"), "K.66.1", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("70528eda-9baa-4db6-9e0f-eaeced78a735"), "K.66.19", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("b53d2449-9d20-444b-8f3a-ed7919102420"), "K.65", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("e3d738f8-119e-49c0-9858-fb8754440663"), "K.64.9", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("4acc6984-5571-4fa6-b7b7-fc0eac092434"), "K.64.1", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Monetary intermediation" },
                    { new Guid("94fe5393-7282-4f31-b253-fd0cfbb70787"), "K.65.3", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Pension funding" },
                    { new Guid("57583e6b-ea00-42da-8771-fd1c8b4e16ea"), "K.65.12", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Non-life insurance" },
                    { new Guid("1bec541c-4d47-41a6-997c-055d3e116e05"), "I.56.29", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Other food service activities" },
                    { new Guid("3b07a5a4-d867-4a8a-842c-1943702226bc"), "I.55.20", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Holiday and other short-stay accommodation" },
                    { new Guid("41e53540-07ae-4206-a59d-1fb30784226f"), "I.55.10", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Hotels and similar accommodation" },
                    { new Guid("1ee3b99b-f69e-4237-a488-2914c3eaf203"), "I.55.2", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Holiday and other short-stay accommodation" },
                    { new Guid("0764af31-050c-48d9-8f6b-30fad715bd00"), "I.56.21", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Event catering activities" },
                    { new Guid("f41e7d38-f464-4d66-8b00-3357399695c5"), "I.55.30", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("f40f1d79-5492-41b5-80e9-4f063f36a647"), "I.56.2", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Event catering and other food service activities" },
                    { new Guid("f65dde51-533c-4cc3-a5fc-5c04f944306b"), "I.55.9", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Other accommodation" },
                    { new Guid("f9ab05fd-173f-483a-a954-5f70a267c37d"), "I.56.10", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Restaurants and mobile food service activities" },
                    { new Guid("c088bd39-30b2-4a8f-a6ea-7362e4ccf44c"), "I.56.30", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Beverage serving activities" },
                    { new Guid("27fd47de-f9ef-46f7-9e69-9d24c8a4d601"), "I.55.3", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("1d8b2507-a377-4610-90f5-ac8ba288ed2c"), "I.55.90", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Other accommodation" },
                    { new Guid("68d93e70-8fb3-42f6-8ae2-b5f0d5a13f36"), "I.55.1", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Hotels and similar accommodation" },
                    { new Guid("bc964bb9-5b2b-4fae-8647-e1e5f764ae85"), "I.55", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Accommodation" },
                    { new Guid("b0a23edf-ac4b-4d71-99fa-e518fd76f3ef"), "I.56", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Food and beverage service activities" },
                    { new Guid("f4b7f797-8e9a-4484-aac5-ea308cdec16b"), "I.56.3", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Beverage serving activities" },
                    { new Guid("bdbcabc4-2ba0-443f-97b1-f819c84537c6"), "I.56.1", new Guid("2da38e16-d2a2-45af-99a3-43a3cba895ad"), "Restaurants and mobile food service activities" },
                    { new Guid("7b81a539-d5cc-472b-a5e1-08dcee4dba3f"), "R.93", new Guid("ca191390-10c5-4bff-9930-459cdaab7ce6"), "Sports activities and amusement and recreation activities" },
                    { new Guid("edd2e230-dacb-4737-8775-b93dc915205f"), "K.64.20", new Guid("badd804d-dda3-4f05-afdf-4167778dac70"), "Activities of holding companies" },
                    { new Guid("eabdf0ec-da5c-49e3-bfac-e4ee6c603a79"), "C.31.0", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of furniture" },
                    { new Guid("d7eb56c3-3c17-4584-97ab-01c03740b9d5"), "G.46.34", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of beverages" },
                    { new Guid("7049f396-897d-4a61-bb8f-0aee15356a05"), "G.45.32", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("4029b14c-02ad-4fda-b013-e6ee18baf00e"), "L.68.32", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Management of real estate on a fee or contract basis" },
                    { new Guid("ce79c0e6-6511-4b0e-93d6-077f6c627cfb"), "B.08", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Other mining and quarrying" },
                    { new Guid("38e99b85-750b-426d-8cbf-128814e14ac8"), "B.08.92", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of peat" },
                    { new Guid("6a66796a-3b8c-4ef2-82fb-2171472029ac"), "B.09.90", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Support activities for other mining and quarrying" },
                    { new Guid("496a5e09-90cd-494e-addf-27acd713726b"), "B.05.20", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of lignite" },
                    { new Guid("3c393826-7e78-4502-a7a2-301e73590ba7"), "B.07.10", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of iron ores" },
                    { new Guid("91531898-5bfb-4d2f-8236-350cfc6ca79a"), "B.05.2", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of lignite" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("03c38ba2-59f3-424c-9bf4-3d41314c5249"), "B.09.10", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("d0c36d0c-f850-4c92-9163-3d53043d8bd3"), "B.08.11", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" },
                    { new Guid("2d5af623-49cb-434b-acf9-40f804537c5b"), "B.06", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("1e9f580d-650a-41a7-9c9b-426df2e9f0fd"), "B.06.10", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of crude petroleum" },
                    { new Guid("6af4aa56-50d7-4193-a906-6d574cd82435"), "B.08.1", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Quarrying of stone, sand and clay" },
                    { new Guid("0c711ede-2b48-48af-ac6a-a51b132efcce"), "L.68.2", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Renting and operating of own or leased real estate" },
                    { new Guid("9e5fc93d-994b-40db-ac52-73b763de6156"), "B.05", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of coal and lignite" },
                    { new Guid("913a7c93-5a18-4bca-96d1-8084cccaebad"), "B.07", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of metal ores" },
                    { new Guid("0a6e139f-c3e0-4d61-aa77-80fe0c2313f7"), "B.08.99", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Other mining and quarrying n.e.c." },
                    { new Guid("0bef2266-25dd-4ff2-8e82-87a0ff8d5bbd"), "B.08.9", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining and quarrying n.e.c." },
                    { new Guid("d6e7b57a-2f46-4032-b206-94d3edce64a4"), "B.05.10", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of hard coal" },
                    { new Guid("b07481b3-a192-467c-ba5e-ae6f39b89bb6"), "B.09", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining support service activities" },
                    { new Guid("395f64b7-00ab-4d1e-80b4-b00b20d2382b"), "B.09.9", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Support activities for other mining and quarrying" },
                    { new Guid("d0c2a981-bee3-4b87-9109-b9a91b315301"), "B.07.2", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of non-ferrous metal ores" },
                    { new Guid("1195f55f-b815-4c34-93d2-bb17abd31609"), "B.07.21", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of uranium and thorium ores" },
                    { new Guid("5d331c5f-6329-4f80-8d4a-bea8500fdc49"), "B.06.2", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of natural gas" },
                    { new Guid("a81d961f-b306-4752-9ebd-bf0f223fb434"), "B.06.1", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of crude petroleum" },
                    { new Guid("55cc98f0-ae69-4884-903c-c0ef2e031a34"), "B.09.1", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("309ddd0c-e9e3-45f0-9727-d22272069a3c"), "B.07.29", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of other non-ferrous metal ores" },
                    { new Guid("4d2891b4-e541-4d04-b9e0-80339341c5f7"), "B.06.20", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of natural gas" },
                    { new Guid("cb9da36b-578f-4bf5-bc11-72ff20d25169"), "L.68.3", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Real estate activities on a fee or contract basis" },
                    { new Guid("8e170d02-5e8a-494c-a279-64ade5d7fa45"), "L.68", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Real estate activities" },
                    { new Guid("a8186b3f-47be-406f-945c-4e3ed9b697d0"), "L.68.1", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Buying and selling of own real estate" },
                    { new Guid("8bf6acfd-a430-4406-b0a8-73da513480a8"), "Q.87.30", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential care activities for the elderly and disabled" },
                    { new Guid("9e48e178-046c-492b-b9c8-9dfa1f108dd0"), "Q.86.10", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Hospital activities" },
                    { new Guid("4ba4fb9d-a5cc-481d-8d84-a8e038ac38d9"), "Q.88", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Social work activities without accommodation" },
                    { new Guid("78489b18-970e-421d-abcd-b65b4f66f493"), "Q.87.10", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential nursing care activities" },
                    { new Guid("15aa7aa9-3747-4cd5-a85b-b81d96ffcf4d"), "Q.88.9", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Other social work activities without accommodation" },
                    { new Guid("9ac7f1dc-00dd-4e32-8750-bb95f2313ba2"), "Q.87", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential care activities" },
                    { new Guid("13287be9-f847-4b74-84b0-be477973c0ca"), "Q.86.90", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Other human health activities" },
                    { new Guid("211e5e45-2132-4288-8172-d42aaedf2f04"), "Q.88.10", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("0cdcf48f-c365-4eab-8fd0-d52286bcb011"), "Q.86.2", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Medical and dental practice activities" },
                    { new Guid("4fbc6acd-3a67-4e23-b96a-d86435d5769c"), "Q.88.99", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("211bdcbd-2028-4664-8447-d86988ec141d"), "Q.86.9", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Other human health activities" },
                    { new Guid("768d280f-e7ad-47ef-921a-f53971e837e3"), "Q.86.1", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Hospital activities" },
                    { new Guid("976b42d3-6f22-4958-9534-fedb9d7e67ed"), "Q.88.91", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Child day-care activities" },
                    { new Guid("cff0294f-49fb-4bd2-8225-bdcaf80ca9a4"), "U.99.0", new Guid("b6f19c27-77f5-4b31-9303-c16a9654e3aa"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("99ad9f7c-27ff-447b-a013-d1abd02dd87b"), "U.99", new Guid("b6f19c27-77f5-4b31-9303-c16a9654e3aa"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("1f9ec4c2-42df-4964-8414-d51ffc09c5da"), "U.99.00", new Guid("b6f19c27-77f5-4b31-9303-c16a9654e3aa"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9ef5bad4-d427-4150-8e97-0d8f37592a2b"), "T.97.00", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Activities of households as employers of domestic personnel" },
                    { new Guid("a318f458-c551-4f0e-a75c-26c6df564f77"), "T.97.0", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Activities of households as employers of domestic personnel" },
                    { new Guid("2e9fe34b-736d-4762-b8db-47fbba0dfa47"), "T.97", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Activities of households as employers of domestic personnel" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fbfb4610-5917-4cb1-804e-548984d2eb76"), "T.98.1", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("42e6b6d1-987d-4ac8-a11b-7047f45ecb22"), "T.98.10", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("53a5dbd8-ddad-4fbb-a31c-7263e0709cbe"), "T.98.20", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("e14cb7cc-44d9-48f5-b264-bcda20a78fe1"), "T.98", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("9b53a43d-4b72-45ff-8b87-e3c78239acc4"), "T.98.2", new Guid("ce64a561-858c-43f9-90a2-d77a5cae5377"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("2361b7b8-967a-4572-b76e-266670ddc560"), "L.68.20", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Renting and operating of own or leased real estate" },
                    { new Guid("17c30153-2972-456a-beb5-41b24d0e7774"), "L.68.31", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Real estate agencies" },
                    { new Guid("93fe13b7-65d3-4218-a53e-4b3725a2a136"), "L.68.10", new Guid("7605dd2a-d935-461c-a1df-d89e9fba0a77"), "Buying and selling of own real estate" },
                    { new Guid("9b91f4c9-7432-4a16-8cac-dde7b1da6548"), "B.08.12", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("f7c1526d-1a48-4f47-a67e-6a3a1608765f"), "Q.87.9", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Other residential care activities" },
                    { new Guid("aae6828c-ea3e-4ea0-b84c-df1343f90619"), "B.08.91", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("4c528a5d-956d-4eb9-bac8-effed4bae913"), "B.05.1", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of hard coal" },
                    { new Guid("8572ac3d-5fdd-431e-a323-761e0d667340"), "N.81.1", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Combined facilities support activities" },
                    { new Guid("de26e1c2-a737-4be3-ba35-7c55721474d7"), "N.77.2", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of personal and household goods" },
                    { new Guid("458476c6-8ea2-4a48-9e9a-7d8b1ab82dbe"), "N.82.9", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Business support service activities n.e.c." },
                    { new Guid("acef5acd-d969-457d-98eb-7e5fb8a9c668"), "N.77.29", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of other personal and household goods" },
                    { new Guid("a1232e07-d3b2-4741-977f-8707a321f764"), "N.82.30", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Organisation of conventions and trade shows" },
                    { new Guid("88a52574-7a73-49bc-a015-92ddd35c3008"), "N.77.11", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("40313423-8ac3-4b2c-b337-951c5da23c08"), "N.81.3", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Landscape service activities" },
                    { new Guid("51373bef-6217-4640-85da-9d0554971c69"), "N.77.40", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("9f710fba-d989-4e35-8271-9de5bc511b5a"), "N.81.22", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other building and industrial cleaning activities" },
                    { new Guid("6e9a1c57-5722-48a1-bce5-a04ea0ba568e"), "N.82.11", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Combined office administrative service activities" },
                    { new Guid("fb71cbec-4be8-4a03-90b4-a2f414332ef3"), "N.77.31", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("53301142-5a5f-4809-9b4b-a52a2e9da841"), "N.81.29", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other cleaning activities" },
                    { new Guid("73df1e7a-7e77-4a81-a674-7378db6c327d"), "N.78.30", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other human resources provision" },
                    { new Guid("53f59fa2-44b0-4cc0-9c49-a70391aec877"), "N.82.99", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other business support service activities n.e.c." },
                    { new Guid("a37dfde5-5c85-4700-bf3a-adf0445ee568"), "N.81.2", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Cleaning activities" },
                    { new Guid("215e6b10-b8cd-4300-b780-b11ebbe46cdf"), "N.77.34", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of water transport equipment" },
                    { new Guid("0d94b98d-5bf6-443f-b18d-b21ea03de74b"), "N.82.91", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Packaging activities" },
                    { new Guid("c992ff73-ce2b-48df-99aa-bf8dacb0acb1"), "N.82.20", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Activities of call centres" },
                    { new Guid("9c5248ca-35fa-440b-b6ab-c714d99a124d"), "N.78.10", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Activities of employment placement agencies" },
                    { new Guid("f4e14001-c38d-44b7-9d1e-c8e59602c7e2"), "N.79.11", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Travel agency activities" },
                    { new Guid("d8d107a1-3c1e-46b2-8653-d0de9e011768"), "N.81", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Services to buildings and landscape activities" },
                    { new Guid("4d4d5af6-a07a-48b8-b89b-d335f8f600b2"), "N.77.32", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("1baa0b61-3eac-410d-a3b4-d973e5832c73"), "N.79.9", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other reservation service and related activities" },
                    { new Guid("0571748d-b7f2-4919-9ac4-dc3c6385f85c"), "N.77.39", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("48df4246-bae3-49f2-878e-e6c7700af5f7"), "N.78.20", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Temporary employment agency activities" },
                    { new Guid("28e5bb7b-fc1d-490a-8553-ea9441c48a89"), "N.79", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("a2a556fd-d143-4a57-9c14-a8e5e3807f07"), "N.80.2", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Security systems service activities" },
                    { new Guid("5d55f3d6-bba9-4e4b-8974-701d36c8ec61"), "N.82.92", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("3b06aac8-445f-426c-99a3-6b7858f8b8ea"), "N.78", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Employment activities" },
                    { new Guid("5f2063d5-7561-49dd-9bc5-6580fe2ab390"), "N.77.33", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of office machinery and equipment (including computers)" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3fab8669-a3df-4467-a18c-f5c6c5193239"), "B.07.1", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Mining of iron ores" },
                    { new Guid("860107c7-133a-4c39-ba0d-094781e9e7de"), "N.80.20", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Security systems service activities" },
                    { new Guid("3f9b5b43-92bd-43aa-8c8f-0b739170b35d"), "N.80.10", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Private security activities" },
                    { new Guid("19369160-b7dd-4f46-89ed-0ccebad7e655"), "N.82.19", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("6b23f635-c7b6-4c98-8258-0ce7ec034d68"), "N.77.21", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("974ae324-e7ce-4b2e-b77e-150c0676caa6"), "N.81.10", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Combined facilities support activities" },
                    { new Guid("0dd93052-4163-4cfb-9752-15d34ccea3ad"), "N.77", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Rental and leasing activities" },
                    { new Guid("4a1782f5-6fee-4121-8a3e-1985a650ad50"), "N.80.1", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Private security activities" },
                    { new Guid("f57e5021-2d78-4f3b-9f57-1f7be828b3f7"), "N.79.90", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other reservation service and related activities" },
                    { new Guid("f724648b-3ec0-46b1-84b9-23f9b8e99ac0"), "N.77.3", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("860dbbec-c2e1-4e07-8d2e-2a36c172df5e"), "N.82.2", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Activities of call centres" },
                    { new Guid("482e0bcf-8f4a-4198-9bd8-2fa34a76b22f"), "N.79.1", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Travel agency and tour operator activities" },
                    { new Guid("01795229-a323-44b1-800a-346ff996099b"), "N.77.22", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting of video tapes and disks" },
                    { new Guid("58a8a25e-2aab-4763-959f-362058dc9ac4"), "N.78.3", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Other human resources provision" },
                    { new Guid("0fe1062b-a9a7-48ef-9ff4-368b37316768"), "N.77.1", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of motor vehicles" },
                    { new Guid("58a48455-da8d-41f3-a8d9-3bfbeaa9e1c0"), "N.78.2", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Temporary employment agency activities" },
                    { new Guid("dd3e7058-8593-4c14-983f-4714f52b83af"), "N.77.12", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of trucks" },
                    { new Guid("c5e20f0e-c7d5-4189-a5be-492ef6ad1dc7"), "N.82", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Office administrative, office support and other business support activities" },
                    { new Guid("98e75f82-3e1a-4d08-9531-49fc7a5f2944"), "N.80.3", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Investigation activities" },
                    { new Guid("fca4c3a7-dec1-466b-92ab-5041e41dc0d7"), "N.79.12", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Tour operator activities" },
                    { new Guid("220173b1-ea7c-401a-84b3-5155d19c7111"), "N.77.4", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("e2f162d0-6de2-4757-b749-51ab2b0a7b1e"), "N.81.21", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "General cleaning of buildings" },
                    { new Guid("56003ecc-64d2-4eab-9370-5b7f0a485183"), "N.78.1", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Activities of employment placement agencies" },
                    { new Guid("c61d3a7c-23dc-4b32-ba95-5eb776718fc6"), "N.80", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Security and investigation activities" },
                    { new Guid("15d09969-7874-46e7-ad6a-60e263820b96"), "N.80.30", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Investigation activities" },
                    { new Guid("197d08a9-5c80-421f-9a6b-6129d6149ecd"), "N.77.35", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Renting and leasing of air transport equipment" },
                    { new Guid("4f5b0ff2-58cc-484d-a359-623568b9b4c2"), "N.82.3", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Organisation of conventions and trade shows" },
                    { new Guid("d1318ba2-998b-421c-acec-e8206356a722"), "B.08.93", new Guid("9e1f4f46-173f-402d-ade7-df8ddc6c563f"), "Extraction of salt" },
                    { new Guid("48d1482a-2a01-4142-ad9e-06ff450156fc"), "G.46.74", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("61f7d321-f6db-449c-8c3b-605506132f82"), "Q.86", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Human health activities" },
                    { new Guid("e2137197-0a9d-4f61-b9e1-4523c191bb38"), "Q.87.2", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("5f72239f-2762-4bb7-98f0-411980063c42"), "G.47.25", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of beverages in specialised stores" },
                    { new Guid("a6be7230-b806-4dd9-9e06-41f9c4d3de2a"), "G.46.69", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of other machinery and equipment" },
                    { new Guid("c0f49018-2a5f-4e36-9db0-4248ddc356c0"), "G.46.49", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of other household goods" },
                    { new Guid("12db7c1a-1c4d-4867-b3ca-42dbd5444ac9"), "G.47.26", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("f647e521-3204-440f-8a7e-4623f6ea8c6d"), "G.46.38", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("40c75f2b-3f76-4091-9ceb-47d49620c513"), "G.45.1", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Sale of motor vehicles" },
                    { new Guid("59a68677-6cd5-4b38-8d13-4947cf012698"), "G.45.31", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("e3af0cd3-7f6c-4545-97e8-5056b1c62ca6"), "G.47.77", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("71a1a803-33bf-430d-afd3-510570986025"), "G.47.73", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Dispensing chemist in specialised stores" },
                    { new Guid("e7daca7c-0bb0-49be-854c-51de8b10b192"), "G.45.11", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Sale of cars and light motor vehicles" },
                    { new Guid("b33e4092-cfc8-4db7-9ae5-5258a65ff0c2"), "G.46.48", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of watches and jewellery" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e9c7d607-ac95-4bc3-88e3-54b0340a1438"), "G.46.65", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of office furniture" },
                    { new Guid("fa8db586-b8f6-4cbf-9e49-40ea3339f240"), "G.46.66", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of other office machinery and equipment" },
                    { new Guid("2a213ecf-a478-4f41-aa73-58d3308b39bd"), "G.45.4", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("eb086b45-8dee-4d8d-ba9a-5d04fe4c199f"), "G.47.19", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Other retail sale in non-specialised stores" },
                    { new Guid("0a0d7706-7d52-4496-b193-5e2bab15c58b"), "G.46.12", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("9787a2f4-1769-4bae-a5a2-5f3f089bd1cc"), "G.46.6", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("c79ab671-7a3f-4c36-9726-617959e9907b"), "G.47.64", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("8a98138a-8f6d-48ba-9a3d-62f3db0a8b76"), "G.47.43", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("dc85faf3-0c14-4cc3-bad4-667a39bfd330"), "G.46.21", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" },
                    { new Guid("8cbf9987-eaa4-4126-9428-6f341f830ca3"), "G.46.37", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("0ecaea82-a076-4b48-987d-712a0ed3473a"), "G.47.71", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of clothing in specialised stores" },
                    { new Guid("38497a4a-287f-46ea-b2e3-72312d9968a9"), "G.46.43", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of electrical household appliances" },
                    { new Guid("6677060c-45f3-4eb7-9451-724d3d91d566"), "G.47.99", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("6fd5877e-666b-46fb-8a5f-759f30a512fb"), "G.46.17", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("14f9fc22-3b48-40df-a9f6-75e90ca4b870"), "G.47.81", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("0beba92e-0403-467b-9de4-593142143dca"), "G.46.36", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("63ee530c-1f5b-4dc3-ac8e-3bccf646ecbd"), "G.47.78", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("55bd166b-a8d9-4d10-919b-3ab3f6e9f337"), "G.46.22", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of flowers and plants" },
                    { new Guid("024cbb84-9043-4391-bbb8-393ccac4171b"), "G.46.18", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents specialised in the sale of other particular products" },
                    { new Guid("38691441-6477-4425-90c6-0c39d7885bb0"), "G.47.30", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("a06fe784-1ddc-4b36-b511-0d0f9cd074d6"), "G.47.29", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Other retail sale of food in specialised stores" },
                    { new Guid("44a1cb2d-0023-4f6c-a47e-0da5aaf32b37"), "G.46.41", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of textiles" },
                    { new Guid("9cb05a25-3b8d-4ae6-9432-0e01f2c3acc1"), "G.47.79", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of second-hand goods in stores" },
                    { new Guid("2510ade5-bbd8-4217-b5fa-0e16c54599b3"), "G.47.54", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("7cd589a1-cab9-4726-9f31-16c7f5d5dc84"), "G.47.52", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("0feef138-d001-40fa-9499-197dd9f3a2c9"), "G.46.1", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale on a fee or contract basis" },
                    { new Guid("54a0fc9e-4bb3-4f45-bf71-1aae7b3ebcf0"), "G.47.82", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("f38f84de-34fc-44e4-b706-1f8b08d978b1"), "G.47.5", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("91391ae6-7022-4413-944b-215d838a1e02"), "G.46.72", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of metals and metal ores" },
                    { new Guid("0e1b024e-7acc-4fe3-8d34-2170701740ca"), "G.46.44", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("9181298c-9f1b-4769-8f6a-223cc2e50025"), "G.47.74", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("53881262-f0cd-4fc8-b5fa-262f882ab4c4"), "G.47.21", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("1bc931d0-a67b-4d8f-adfd-2635da57affe"), "G.46.4", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of household goods" },
                    { new Guid("e35d78f6-c968-4cac-8dac-26f14650d616"), "G.47.53", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("406523ff-296f-4688-beb2-282e9cf61226"), "G.47.11", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("1fd4bbb3-fddd-42d3-a13a-2915c064e751"), "G.47.91", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("531920dd-8305-450d-9d36-2a9fcc81f7f1"), "G.46.16", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("7a4e4f22-9854-486d-8a94-2aecea62f4c9"), "G.47.61", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of books in specialised stores" },
                    { new Guid("3fd65854-e1eb-4ebe-b879-2ecf7b96b7ef"), "G.47.63", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("e5079afb-f8b7-463d-b6fd-2fc8be1cc90b"), "G.46.9", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Non-specialised wholesale trade" },
                    { new Guid("eee473d8-45e6-44aa-a3a9-3059c1b7184a"), "G.47.7", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of other goods in specialised stores" },
                    { new Guid("c0fb5557-e90e-41d6-b913-3073502b5215"), "G.46.2", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of agricultural raw materials and live animals" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b06750a1-fa43-436b-a859-3226c56728cb"), "G.47.2", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("35a9ba6f-4e43-46e6-b699-331a08a399c0"), "G.46.90", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Non-specialised wholesale trade" },
                    { new Guid("b4c97857-f375-4b39-8e7e-367e78b1b759"), "G.46.23", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of live animals" },
                    { new Guid("53b6da57-e033-4bbb-9d32-372e41c85e9a"), "G.46.15", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("0094c62d-38e1-4013-b86b-80ab6442dd7d"), "G.46.71", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("9eacdafb-833f-4f7f-9f7c-5f8102796fa2"), "Q.86.23", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Dental practice activities" },
                    { new Guid("9c031d95-c15c-430d-8960-81a9fb200329"), "G.46.64", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("4e1fad56-a48a-49aa-80b1-918f37cda7f7"), "G.46.32", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of meat and meat products" },
                    { new Guid("b3bf50d7-8598-430d-bf00-de0c7cdfe163"), "G.47", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("42f33a01-852b-47f4-ba72-de42f9e04091"), "G.46.61", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("e07e0777-8b2c-43ef-a60b-dfb4bbb15ce7"), "G.46.14", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("3e5b61c3-f568-45cc-917d-e08dded5fb02"), "G.46.3", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("1d54ea49-ffd6-477a-909f-e489faf245fd"), "G.46.52", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("dd5cb816-ab67-43f9-b6b0-e620769353a6"), "G.45.40", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("058181c6-c611-4064-a8e6-e664b4bdc65a"), "G.47.76", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("62d7c0ef-45bd-44b0-889a-e7ca28990947"), "G.47.65", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("b73a57a4-07e1-4043-9091-e8110c99a4f5"), "G.46.63", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("681c29fe-eff3-4d66-b1b6-e880ae0461b4"), "G.45", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("3c096b18-25ef-4ace-b22b-eb484d6722bf"), "G.45.3", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("41360936-38c4-4742-9610-ec6680d677ba"), "G.47.42", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("6d21d1d9-482a-4f4e-a484-d97f9c81b6f6"), "G.46.77", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of waste and scrap" },
                    { new Guid("fe11baa2-0098-4309-9d62-ef296f75a50b"), "G.47.62", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("269a8e55-b93f-42c1-8e77-f2cdf51e8c3f"), "G.46.31", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of fruit and vegetables" },
                    { new Guid("a769e869-b7db-4e94-b249-f44f6be45f93"), "G.46", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("b286ec5b-a2a9-4e17-86b2-f5ca9c4e5056"), "G.47.3", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("3f47d35f-5c40-4ec0-b8e4-fb6ca89f6263"), "G.47.24", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("c60ec3ce-947f-4fda-93f9-fe3f46f29590"), "G.46.39", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("931e4371-d62b-4fc4-8f2d-096ce39c9a4c"), "Q.87.20", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("1eac9eca-52c6-4049-83a8-0a91f83debae"), "Q.87.1", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential nursing care activities" },
                    { new Guid("28f0e335-3600-4be0-b0e3-0c9efbd6db57"), "Q.86.21", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "General medical practice activities" },
                    { new Guid("9bd646b3-09b6-4193-a1f4-2326f632d411"), "Q.87.3", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Residential care activities for the elderly and disabled" },
                    { new Guid("c9c1e66b-91bb-4ef3-bd78-2649bfb472d1"), "Q.87.90", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Other residential care activities" },
                    { new Guid("0042825d-077c-4677-8358-35a46e5d47d3"), "Q.88.1", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("b5d16bbe-6b82-414b-8303-42af64fff727"), "Q.86.22", new Guid("3dcae13b-1a77-477c-89c9-900e9ed0469c"), "Specialist medical practice activities" },
                    { new Guid("38a5d5ec-5f60-4226-ba3a-f10df271cf64"), "G.46.35", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of tobacco products" },
                    { new Guid("61dd1905-c86b-4164-9901-d91a0b7c0f6d"), "G.45.2", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Maintenance and repair of motor vehicles" },
                    { new Guid("5366435d-c130-4f4b-96b8-d4a568297934"), "G.47.1", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale in non-specialised stores" },
                    { new Guid("a025468c-003f-4ff0-b293-d2bb3cc6e2e3"), "G.47.8", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale via stalls and markets" },
                    { new Guid("1dc7ad1f-50b5-4075-a549-922d1897b7fe"), "G.45.20", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Maintenance and repair of motor vehicles" },
                    { new Guid("280551d7-c3bd-40f9-9263-9323e6b013c3"), "G.46.62", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of machine tools" },
                    { new Guid("8e8c51e8-fcdc-422d-8a16-94eba93dfeb0"), "G.47.4", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("1bd869ca-eca0-4207-8fd3-94ee5ea8bcf5"), "G.47.6", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of cultural and recreation goods in specialised stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("dfda75dd-5910-44b9-946d-9d11dd17ca71"), "G.46.47", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("75ef12f7-9678-4e4e-953e-9e4bfab1228a"), "G.46.45", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of perfume and cosmetics" },
                    { new Guid("2a4d7187-34aa-47f6-a4ca-aa36b493c86f"), "G.46.7", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Other specialised wholesale" },
                    { new Guid("03a1a2d2-12e8-47ef-8c12-ad0eea978693"), "G.46.11", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("b90b8adb-edb0-4de6-bc3e-ae8aa7f76d8c"), "G.46.73", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("400331fd-42d3-470b-9313-b01f17c81a6f"), "G.47.59", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("0b8f091f-7024-4326-b005-b55c12f8f24d"), "G.47.41", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("ab768299-52c5-4bd8-abaf-b57cf979909a"), "G.46.13", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("59312bd9-bc58-47b7-9c4e-b5b6fe7e1aff"), "G.46.76", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of other intermediate products" },
                    { new Guid("6b65512f-706c-4ea2-a6ab-b67b749cd0a5"), "G.46.33", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("2d9bb0ba-e7c9-4b32-903e-b80d47588ee3"), "G.47.9", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("23cb5fa6-72a8-420e-bafc-b8581b1d673e"), "G.45.19", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Sale of other motor vehicles" },
                    { new Guid("1ff70fa0-2c9f-4e0f-b610-b9368b0bce21"), "G.47.75", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("e1844f79-20c4-471e-8e4e-ba94c6f6711e"), "G.47.89", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("2037081d-5a99-4b4f-a8ca-bbf0de415283"), "G.46.75", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of chemical products" },
                    { new Guid("4f3ccdfa-2776-407a-9986-beafb8e34e32"), "G.46.5", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of information and communication equipment" },
                    { new Guid("011af312-01c1-4f95-ba11-c223abee7efe"), "G.47.72", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("a581b95e-0c34-423a-a4a9-cc207426ea1a"), "G.46.42", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of clothing and footwear" },
                    { new Guid("e782c37b-c16d-45c3-a606-cd1cee4130c4"), "G.46.51", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("88aa4c61-db91-4cbb-92e4-cd670d578fca"), "G.47.23", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("96cfbf8d-234b-42fa-be1d-d01a80a6b812"), "G.46.19", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("4d789121-0e9d-4784-aa34-d06e93fa4a8e"), "G.47.51", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Retail sale of textiles in specialised stores" },
                    { new Guid("65fcb5cd-a039-4a5b-ae73-d18c2efe640b"), "G.46.46", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of pharmaceutical goods" },
                    { new Guid("c1374e27-4922-444a-9cda-855e290fa543"), "G.46.24", new Guid("d42356d9-186d-408e-857c-8aec5011bae2"), "Wholesale of hides, skins and leather" },
                    { new Guid("fb6eeadc-1e38-491a-b09d-f3a64f9654dd"), "N.82.1", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Office administrative and support activities" },
                    { new Guid("b5af8dfd-83c6-4834-b77c-e2598d7d2d4c"), "C.32.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of musical instruments" },
                    { new Guid("2e831fc3-6646-4562-865b-dfa7a5a01188"), "C.27.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electric lighting equipment" },
                    { new Guid("c7ce2b24-bca4-48e6-a9a6-57598f0e7e4c"), "F.43.13", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Test drilling and boring" },
                    { new Guid("f0be24ca-2a9d-4d34-9d3b-5e5b2b02bb90"), "F.43.29", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Other construction installation" },
                    { new Guid("d67d2d10-eb07-45c7-99d4-607511e136af"), "F.43.9", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Other specialised construction activities" },
                    { new Guid("f943d075-d30e-437b-a151-6d89ce7ebba0"), "F.43.2", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("0dd09135-f53c-4aa0-8ae3-7192f194e89f"), "F.43.1", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Demolition and site preparation" },
                    { new Guid("cb1a25e7-97fc-4493-ba20-8ee4a547eac4"), "F.43.91", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Roofing activities" },
                    { new Guid("b161782e-0d3c-41ad-8d6e-936f17365abe"), "F.43.39", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Other building completion and finishing" },
                    { new Guid("10e8ef0d-37f0-4fb5-9156-9854547547dd"), "F.42.11", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of roads and motorways" },
                    { new Guid("72151d9d-3905-47e5-8277-9f4882f21980"), "F.42.91", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of water projects" },
                    { new Guid("b1144838-cb99-4f4f-9549-b2af836d667b"), "F.42.1", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of roads and railways" },
                    { new Guid("6ebd2ece-1c18-4f3f-bc2c-b57d18d53298"), "F.42.22", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("91d7890d-f2a1-45bd-b760-c1631a45a400"), "F.43.22", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("8a5785d6-e9a4-4867-a4f6-546536a1c545"), "F.43.31", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Plastering" },
                    { new Guid("c81abe0b-5bbd-42f0-8415-c57fa2999401"), "F.41.20", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of residential and non-residential buildings" },
                    { new Guid("15599ebe-64e1-420f-908c-ca42d5694a18"), "F.42.9", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of other civil engineering projects" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("46192f5d-16c6-453c-af3f-cb61d6fc7e67"), "F.43.33", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Floor and wall covering" },
                    { new Guid("7c46e588-95bb-4458-9494-cfeb8959f829"), "F.41.2", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of residential and non-residential buildings" },
                    { new Guid("598ac608-244a-44c6-baa8-d351e6d7e6c6"), "F.41", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of buildings" },
                    { new Guid("f7042eb4-3f76-48c7-aa60-d8a9823f1bcf"), "F.43.11", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Demolition" },
                    { new Guid("3a0c970f-9555-4d8e-b849-d93535a77005"), "F.43.32", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Joinery installation" },
                    { new Guid("81c015c8-442e-47c0-b76b-f13fae42e5da"), "F.43.21", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Electrical installation" },
                    { new Guid("9afa9b5b-fbc8-4faa-9792-f1c196c00a6b"), "F.43", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Specialised construction activities" },
                    { new Guid("42aa02ca-e837-4aa0-8ba7-f303bf2b309a"), "F.41.1", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Development of building projects" },
                    { new Guid("32641b06-16ce-40b9-9897-f4adb08575fa"), "F.42.99", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("0c2b6ad6-678d-4d79-a4c2-fbeb4989f758"), "F.41.10", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Development of building projects" },
                    { new Guid("e3855083-e027-477f-80ea-01b2d33c3ae7"), "C.20.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other chemical products" },
                    { new Guid("a20f5bd2-cee6-4f29-8920-c68353630f0c"), "F.43.3", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Building completion and finishing" },
                    { new Guid("f0e7fa6f-cd91-4ec0-b630-5029f98e70a3"), "F.42.21", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of utility projects for fluids" },
                    { new Guid("45c52131-55d8-43fa-8781-42e1fd017107"), "F.43.99", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Other specialised construction activities n.e.c." },
                    { new Guid("13e6627e-cd1a-44b2-930a-3529f86597e2"), "F.42.12", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of railways and underground railways" },
                    { new Guid("df0fcbfb-cbf9-43eb-8f1e-f82a7efd2048"), "S.94.99", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of other membership organisations n.e.c." },
                    { new Guid("aa930e05-5679-4b9c-8d50-faf7d4e71cd2"), "S.94.9", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of other membership organisations" },
                    { new Guid("ca1ee218-25ec-4a93-ad99-fb4c61e2230e"), "S.95.29", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of other personal and household goods" },
                    { new Guid("2add8567-686d-47eb-8e85-03b59741dd33"), "E.37.0", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Sewerage" },
                    { new Guid("eacb570c-6482-4363-9e90-2562c03c90b7"), "E.38.1", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Waste collection" },
                    { new Guid("97194cae-4bc3-414f-b085-2c39809590fb"), "E.38.2", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Waste treatment and disposal" },
                    { new Guid("573c9676-da31-432d-a6a9-384f1dc63ed9"), "E.38.32", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Recovery of sorted materials" },
                    { new Guid("70e4c806-1d01-444d-b4d6-3c8210f09e44"), "E.36.00", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Water collection, treatment and supply" },
                    { new Guid("0972af9c-29d1-4b89-9d70-501838c75cf4"), "E.39.00", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Remediation activities and other waste management services" },
                    { new Guid("962ddfbb-ac4a-43c8-b02f-5061b2fa679f"), "E.38.21", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("ef1dae25-21d0-4b29-b51d-50eccf8c0bf5"), "E.38", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("114f51f4-f68d-4293-9f7f-61b17f24b53d"), "E.36.0", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Water collection, treatment and supply" },
                    { new Guid("2468bdb9-c24e-4d3b-b22e-67fe489b5b04"), "E.38.12", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Collection of hazardous waste" },
                    { new Guid("4b236cad-25f2-4078-a09e-77dd8a4084d2"), "E.37", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Sewerage" },
                    { new Guid("8ab456b0-75a4-496a-bc30-8b53bb370c88"), "E.39", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Remediation activities and other waste management services" },
                    { new Guid("ccb3c9a7-4863-4ce9-803d-92e2489a028f"), "E.36", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Water collection, treatment and supply" },
                    { new Guid("9de11218-6b5a-4656-8ca7-99bc0fd655ab"), "E.38.22", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Treatment and disposal of hazardous waste" },
                    { new Guid("aa8463ed-de66-4fa2-8595-9f26accc669a"), "E.38.11", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Collection of non-hazardous waste" },
                    { new Guid("4a7a05c2-2113-4085-9343-a66c8c82c528"), "E.39.0", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Remediation activities and other waste management services" },
                    { new Guid("90140dec-c2f5-4aa7-8c96-c9bb3f52970d"), "E.37.00", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Sewerage" },
                    { new Guid("3fe226ea-07e8-4ea6-9621-d2154999c465"), "E.38.31", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Dismantling of wrecks" },
                    { new Guid("1954013c-7244-4c08-9230-dedf8bb9ca62"), "E.38.3", new Guid("59dc62c0-0e24-42b9-855a-172e72e4961d"), "Materials recovery" },
                    { new Guid("18579f2d-b021-422e-987c-08882cc9f94c"), "F.42.2", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of utility projects" },
                    { new Guid("6dca07da-482c-4630-89ab-0fe33e52ee8e"), "F.42.13", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Construction of bridges and tunnels" },
                    { new Guid("3bb0f654-f2be-4dd4-979f-2e4eb6342381"), "F.42", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Civil engineering" },
                    { new Guid("15157c90-d48b-4055-9616-2fc441f3eed3"), "F.43.12", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Site preparation" },
                    { new Guid("c0a1b169-dacf-4be2-ba3a-351d69929d1a"), "F.43.34", new Guid("8f0984c6-63fe-4282-8d58-37366d1a5b58"), "Painting and glazing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4fa2090f-8cc6-4f57-894b-01c20fd3a014"), "C.21.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("0a94e0b1-b670-4b4b-b02f-e3ba4c407f5b"), "S.95.11", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of computers and peripheral equipment" },
                    { new Guid("ed91e1b4-135c-4421-a6f8-01d3103d52f5"), "C.14.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of articles of fur" },
                    { new Guid("d837e8b1-c35a-4d56-91da-0266f6b4b38c"), "C.28.95", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("2044b655-02f9-4ce2-a4ff-166d4aac2f23"), "C.19.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of coke oven products" },
                    { new Guid("e5f262c0-d72d-4b5b-9ef4-172ea0251ae1"), "C.10.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("abcfad05-8e08-43da-83f9-1774a497ccd9"), "C.14.39", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("9992cf92-16f1-407a-ac85-1797d1af731b"), "C.26.80", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of magnetic and optical media" },
                    { new Guid("d4513a26-d183-4fdc-b172-18d944b404e5"), "C.24.41", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Precious metals production" },
                    { new Guid("1b621fcc-3dc3-49a8-affc-19769bd5c3af"), "C.22.22", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of plastic packing goods" },
                    { new Guid("a472aa47-4a20-4664-b35e-19980a1d6595"), "C.10.51", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Operation of dairies and cheese making" },
                    { new Guid("171a36c4-fc5f-468a-8521-1b0a7da4211c"), "C.23.6", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("44d01751-9b05-4db8-a9c1-1b639d47bc53"), "C.25.72", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of locks and hinges" },
                    { new Guid("40f79489-868e-4225-aabf-1b85c8d6c89f"), "C.32.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of sports goods" },
                    { new Guid("7f64b1e1-82ff-4844-82fc-2096b83fa56f"), "C.24.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("d9f1b02d-91a8-4fc2-aeaa-20dbcc2c5989"), "C.10.73", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("931f16b9-6bcf-4bff-9f23-16533bd159ec"), "C.26.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of communication equipment" },
                    { new Guid("02e8f36a-d648-444e-b17a-21913d84b64e"), "C.14.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("3aecd986-3973-4dca-af88-21cb1bc1c390"), "C.27.52", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("a45a6dc8-6775-4ae5-bcd3-23360247d30d"), "C.25.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other fabricated metal products" },
                    { new Guid("070a2073-232a-4900-8cd9-239e3a4ae4af"), "C.25.50", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("5464b06c-a428-40de-b289-245e4291f143"), "C.20.52", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of glues" },
                    { new Guid("4e83c8a9-d3ce-49f1-87bb-273459488a07"), "C.25.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of structural metal products" },
                    { new Guid("703e7724-646c-48a1-998b-27be4de0bc33"), "C.20.41", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("1096a8cf-2e20-4656-b24e-281a1297b72e"), "C.20.15", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("ae3d6ee8-ab83-44b0-8c33-2a525565f748"), "C.14.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("d2d1fa22-b009-4bf4-b549-2ad2424e9898"), "C.27.51", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electric domestic appliances" },
                    { new Guid("e4e0b16d-2fb9-4cc7-a17b-2ad7d73468a7"), "C.20.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of industrial gases" },
                    { new Guid("407f2374-03d8-4496-951b-2b86c8b2d98e"), "C.29.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("8e2b0f43-d4fb-415a-80b2-2bd74ab1015f"), "C.26.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electronic components" },
                    { new Guid("a904899b-efed-4b5f-bffd-21ad868ddd73"), "C.23.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of clay building materials" },
                    { new Guid("ab285c85-c8de-441a-91e7-1646970b4e58"), "C.27.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of batteries and accumulators" },
                    { new Guid("34f16a06-4082-49b0-8632-15a4e2c1b64a"), "C.22.29", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other plastic products" },
                    { new Guid("f8dc67e8-1682-49dd-aad0-1527a6b81b87"), "C.22.21", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("f390267f-c134-4dd3-8a63-0443f3b1522b"), "C.23.44", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other technical ceramic products" },
                    { new Guid("94e39b37-9406-4dbe-96a0-045c933e5994"), "C.10.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of prepared animal feeds" },
                    { new Guid("a44c204d-c889-4ef9-b50a-04c663b21cbc"), "C.11.0", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of beverages" },
                    { new Guid("64d38e61-2e2d-46ab-a0d6-04e9055f45ed"), "C.30.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of motorcycles" },
                    { new Guid("18a7a4fa-b024-4034-a342-071648672d1b"), "C.13.92", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("9cdf7c7f-1d94-4af0-8d16-0756bb8e978f"), "C.23.62", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("db476ca7-43d8-48a3-ab6b-07bb091041cd"), "C.23.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cement, lime and plaster" },
                    { new Guid("f32c9086-80eb-4d8e-b0f0-082412383a8f"), "C.24.54", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Casting of other non-ferrous metals" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d2a9c151-8675-40ab-9dd7-08e12f7961a7"), "C.23.43", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("ca466210-0941-4a1c-a01c-09c5684d94d1"), "C.26.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of consumer electronics" },
                    { new Guid("3ae0d095-b891-4abd-976d-09f777779268"), "C.26.52", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of watches and clocks" },
                    { new Guid("46be4e87-3718-4de0-bde4-0ae757f18529"), "C.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of textiles" },
                    { new Guid("af0332b0-7894-481e-8d25-0b71ea610c87"), "C.33.16", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("f74dab1e-c32e-4543-ad0e-0b86fab6ead2"), "C.33.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("66ffab68-9d61-4598-b3ce-0d1e72649332"), "C.23.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Shaping and processing of flat glass" },
                    { new Guid("7fb314db-0888-4577-8923-0e028154aa4f"), "C.11.04", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("7c00d472-ecf5-4473-8119-0e1117e77512"), "C.25.61", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Treatment and coating of metals" },
                    { new Guid("46de0770-03ab-4592-98b3-0f025a3367d2"), "C.19.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of coke oven products" },
                    { new Guid("5c219a0e-076b-48f3-a057-0fb1fc818825"), "C.23.61", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("acc29125-8121-4e35-9820-0ffa04e5c952"), "C.33.15", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair and maintenance of ships and boats" },
                    { new Guid("90f4fcac-db5b-4e76-a153-1042fb7b1e27"), "C.32.40", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of games and toys" },
                    { new Guid("1bb5eaf2-3517-43bf-bc01-10d95afca235"), "C.22.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of plastics products" },
                    { new Guid("c88818a0-e1a7-4ce2-90a0-10e3595630e8"), "C.24.45", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Other non-ferrous metal production" },
                    { new Guid("c2aa5d29-f7e8-4d03-826e-1323398d8ad5"), "C.25.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("acef7c8a-97fa-4575-b1f0-138535a63fa1"), "C.30.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("a89fa834-e832-46c0-86d0-145e3037ab24"), "C.15.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("7f41a950-4f0d-4802-8d64-14b1435e03e7"), "C.28.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("9cda916f-13af-4972-a196-023f0bfb5656"), "C.14.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of underwear" },
                    { new Guid("ddae4337-87da-4f7e-97ee-2c298dc6c35d"), "C.17.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("b82dc4e0-ab53-45e6-a838-e2d2e510002d"), "S.96", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Other personal service activities" },
                    { new Guid("8abc2916-a293-47de-986a-cae30ec67405"), "S.96.01", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("a74f5a64-421f-43d4-b598-a38e72c2f7dc"), "A.01.45", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of sheep and goats" },
                    { new Guid("79cf0589-1bb2-48bc-ad39-a5810567f2ef"), "A.02.4", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Support services to forestry" },
                    { new Guid("ec67e36d-fd3f-4722-9fa7-b3afe16ac041"), "A.01.42", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of other cattle and buffaloes" },
                    { new Guid("a77bd8b4-e0d6-42fb-8900-b9c68be3cb65"), "A.01.24", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of pome fruits and stone fruits" },
                    { new Guid("74c9f57f-514b-404e-a62c-b9e62d34c6a6"), "A.02.30", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Gathering of wild growing non-wood products" },
                    { new Guid("b34f5b8e-ee2d-4a6b-9e8e-bb34adf3ffeb"), "A.03", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Fishing and aquaculture" },
                    { new Guid("c78826dc-fa3c-445a-b5fc-bba39792f332"), "A.01.23", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of citrus fruits" },
                    { new Guid("e72141f2-f01f-4ca6-bb9b-bdc3c51ca179"), "A.01.70", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Hunting, trapping and related service activities" },
                    { new Guid("0e6e98b6-827d-498b-bb33-bf4071936eef"), "A.01.26", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of oleaginous fruits" },
                    { new Guid("75392d97-99a8-45d9-9c36-c506a0d17e0e"), "A.01.44", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of camels and camelids" },
                    { new Guid("87a85bdf-b5d6-4107-ab08-c50ec12b7c84"), "A.01.62", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Support activities for animal production" },
                    { new Guid("df940a82-2c68-405b-a9b2-c626df6dfae3"), "A.01.1", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of non-perennial crops" },
                    { new Guid("f83be9ce-f282-48fe-bad1-9258214cd2b8"), "A.01.12", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of rice" },
                    { new Guid("21a7f92c-005f-464c-a988-d97c6dbf1eca"), "A.01.27", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of beverage crops" },
                    { new Guid("ec066b7b-aa82-47bd-8201-e27b7e0dfc14"), "A.01.41", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of dairy cattle" },
                    { new Guid("8501fd14-f5fd-4244-a908-e70ce82197ef"), "A.01.50", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Mixed farming" },
                    { new Guid("b464ab5f-8291-4ee8-b584-e92d6ec90b02"), "A.01.3", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Plant propagation" },
                    { new Guid("4c6c4466-16d0-49da-8f4a-f238bfdcf57f"), "A.02.20", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Logging" },
                    { new Guid("5cfc845d-af7e-47c8-a403-f77d14901adb"), "A.01.30", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Plant propagation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("77b75506-16f6-436e-8c90-f9803cdc5dca"), "A.02.2", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Logging" },
                    { new Guid("cd76ed40-f9fa-4198-b074-fb4c01bee10a"), "A.02.3", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Gathering of wild growing non-wood products" },
                    { new Guid("7fe3b598-3883-4b82-999c-fdae88553a7f"), "A.01.7", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Hunting, trapping and related service activities" },
                    { new Guid("1ba6cdaa-7414-4126-9fd7-fe40f338cfb9"), "A.03.22", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Freshwater aquaculture" },
                    { new Guid("a81725ac-f42d-443a-aee7-0638c29561c0"), "H.51.2", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Freight air transport and space transport" },
                    { new Guid("872f2292-b87b-4170-8795-108625f00477"), "H.49.10", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Passenger rail transport, interurban" },
                    { new Guid("fb5c9c0c-697e-4202-be91-11cfb2476e00"), "H.49", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Land transport and transport via pipelines" },
                    { new Guid("4b19fbab-d997-4e5e-bffd-dc9b7485cc8d"), "A.03.12", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Freshwater fishing" },
                    { new Guid("32442681-5e8b-49da-9734-84746614f990"), "A.02.10", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Silviculture and other forestry activities" },
                    { new Guid("3a282485-5047-4f68-8420-7f4d59d216d7"), "A.01.22", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of tropical and subtropical fruits" },
                    { new Guid("073f180f-cec3-4139-a1b8-7d40105ab7e1"), "A.01.6", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("807b79eb-d594-45a1-98ab-062568281c8d"), "A.01.28", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("eca619db-cba3-442b-9316-0e51956c2258"), "A.03.2", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Aquaculture" },
                    { new Guid("a683fa7f-aa9b-428a-9209-14378ba2872e"), "A.01.19", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of other non-perennial crops" },
                    { new Guid("e48e0c60-7ef0-4f3e-a91a-18a72272c801"), "A.01.15", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of tobacco" },
                    { new Guid("29d55e9d-4c1b-4ad4-b24b-1c0e695c06a6"), "A.01.14", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of sugar cane" },
                    { new Guid("79d8ada0-c8d8-410e-a612-31ebd3a37717"), "A.03.21", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Marine aquaculture" },
                    { new Guid("73957347-0b0b-434d-a603-3421a7698a22"), "A.03.1", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Fishing" },
                    { new Guid("1421d6c0-6cad-4be1-a201-35885966aea3"), "A.01.4", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Animal production" },
                    { new Guid("036f79f1-baa4-4c27-abed-38b55f17d865"), "A.02.40", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Support services to forestry" },
                    { new Guid("92a81f91-2c43-4e3b-9108-3b31a985072e"), "A.01.46", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of swine/pigs" },
                    { new Guid("d6c56c1e-2429-49f0-a822-3c4bc0e56f57"), "A.01.13", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("1ff9a43e-e2f1-4c78-97c5-3ceda17a7a0a"), "A.01.2", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of perennial crops" },
                    { new Guid("71e85499-4d1a-4e4b-8c66-440bdcdc9360"), "A.01.49", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of other animals" },
                    { new Guid("e53c4016-8f9e-4445-991f-460816b4cfc0"), "A.01.63", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Post-harvest crop activities" },
                    { new Guid("92c3487e-3f1c-45fe-8cbc-4ea45625e91e"), "A.01.5", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Mixed farming" },
                    { new Guid("81ca6818-f7f0-4b1c-9ac8-4ff13f433d2d"), "A.01.64", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Seed processing for propagation" },
                    { new Guid("0c30ab94-620c-45f3-8d6c-5001adb35b17"), "A.01.47", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of poultry" },
                    { new Guid("a4d876cc-c870-487b-9a85-55cd450c4d03"), "A.01.21", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of grapes" },
                    { new Guid("ca4a8833-e1d2-4352-ad23-5a753fa6ad58"), "A.01.25", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("806a5794-a7d5-43bb-89e0-5d036cd624bd"), "A.02", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Forestry and logging" },
                    { new Guid("bb5da169-8359-4e1c-94d2-6192d4920faa"), "A.01.29", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of other perennial crops" },
                    { new Guid("3778e51b-035e-4aba-83ba-6b5fe9798bce"), "A.03.11", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Marine fishing" },
                    { new Guid("822fc759-05af-424c-9359-6e65383432c8"), "A.01.16", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Growing of fibre crops" },
                    { new Guid("92ccb36f-2750-479c-a878-708068b3275d"), "A.01.43", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Raising of horses and other equines" },
                    { new Guid("4fd7b982-39af-4cc1-a469-70e5daf0d68b"), "A.01", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("20b4ced5-2dea-48e3-b87a-71261b74bfe9"), "A.01.61", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Support activities for crop production" },
                    { new Guid("6d9e798e-9c1d-4944-9bc3-75b444482468"), "A.02.1", new Guid("b3f121d5-141d-44a5-bc83-04eefb43ea02"), "Silviculture and other forestry activities" },
                    { new Guid("339fe510-2837-455d-a6c0-1818232a2491"), "H.49.1", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Passenger rail transport, interurban" },
                    { new Guid("72ae4728-d111-41b5-b85f-da3087819718"), "S.96.0", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Other personal service activities" },
                    { new Guid("e686a89b-8373-45bf-919f-195b21803dc8"), "H.49.20", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Freight rail transport" },
                    { new Guid("badc8218-0724-4797-a5e6-1e6a078edec1"), "H.50", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Water transport" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e4e27080-fdbf-4488-af0e-bc851169111d"), "H.50.40", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Inland freight water transport" },
                    { new Guid("153166f4-6166-4485-88d4-d8bbbba7774f"), "H.51.21", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Freight air transport" },
                    { new Guid("d346b88a-7a60-4803-88b9-d9661484fb09"), "H.53", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Postal and courier activities" },
                    { new Guid("1b32c06e-0212-4e28-9e60-dfcafdaf04ec"), "H.52.21", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Service activities incidental to land transportation" },
                    { new Guid("c64f0b66-4c1d-4053-93dc-f009b5bcf2ac"), "H.50.20", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Sea and coastal freight water transport" },
                    { new Guid("931986a7-6a77-48d2-bc79-018e0bd0cefd"), "S.94.12", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of professional membership organisations" },
                    { new Guid("47fb90d6-3b61-4122-af02-1a14f3f6fc28"), "S.95.2", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of personal and household goods" },
                    { new Guid("ea3c0fd8-b390-49c7-af01-20f4898da35e"), "S.95.21", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of consumer electronics" },
                    { new Guid("28ca470f-040f-4989-a5fe-2940bc74343b"), "S.94.2", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of trade unions" },
                    { new Guid("8f1a34ff-54a7-4c23-86f8-2b47e1597ba5"), "S.95.12", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of communication equipment" },
                    { new Guid("98a497e1-5984-439a-9643-2ce3407d81f9"), "S.94.11", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of business and employers membership organisations" },
                    { new Guid("ce73263e-2868-4c63-823f-2ef50ef6ca4e"), "S.95.24", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of furniture and home furnishings" },
                    { new Guid("f5652893-6acb-4e36-af21-b8d45c020af2"), "H.50.1", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Sea and coastal passenger water transport" },
                    { new Guid("cb916345-e6aa-466d-ada7-3b75d7f84f7d"), "S.96.03", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Funeral and related activities" },
                    { new Guid("6ab03bd6-9270-4de7-8faf-68aa1e9e5fa8"), "S.95.1", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of computers and communication equipment" },
                    { new Guid("ba5fcb63-f02c-4d0b-9852-94132c4379c2"), "S.94.92", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of political organisations" },
                    { new Guid("8d322237-86dd-44c5-814f-9f31e78dcf53"), "S.94.91", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of religious organisations" },
                    { new Guid("3eadbdc5-5346-415b-a35a-a06fdb53ef3b"), "S.95.23", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of footwear and leather goods" },
                    { new Guid("25edd928-f6da-4b53-9c14-a55a0063dda3"), "S.96.09", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Other personal service activities n.e.c." },
                    { new Guid("4119054e-6f0a-430b-ad1b-ad6be9ac0215"), "S.96.02", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Hairdressing and other beauty treatment" },
                    { new Guid("91066f28-6809-451a-99a5-b3543d5e84d1"), "S.95.25", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of watches, clocks and jewellery" },
                    { new Guid("d969f009-ed15-4a41-9d6a-bc323404104e"), "S.94.20", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of trade unions" },
                    { new Guid("1f504734-2b74-4c6a-bf59-bdb8c4a554f2"), "S.94", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of membership organisations" },
                    { new Guid("1aef0d79-4c88-4a0e-b90e-c5005ecc390d"), "S.96.04", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Physical well-being activities" },
                    { new Guid("92362e2e-e8fe-48cb-aa3c-c57c1d223f35"), "S.94.1", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("a95863f8-7889-437c-863b-c868371381cc"), "S.95", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of computers and personal and household goods" },
                    { new Guid("457a7fe1-8bc3-4008-9152-4f9c84a6904b"), "S.95.22", new Guid("0204f73e-c29b-4728-90f8-14ef1db1db8f"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("34d6ec28-b2fa-435e-89fb-b252d10eb6b6"), "H.52.2", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Support activities for transportation" },
                    { new Guid("09956287-e130-4fdf-8ba0-b17aebbcfbbe"), "H.52.23", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Service activities incidental to air transportation" },
                    { new Guid("988a282d-4c3f-494d-805d-ae328d6abef3"), "H.50.10", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Sea and coastal passenger water transport" },
                    { new Guid("f7758faa-1329-41d6-a5ec-209af2b76846"), "H.53.10", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Postal activities under universal service obligation" },
                    { new Guid("244462cd-148a-4488-bd20-2480e442f83d"), "H.49.42", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Removal services" },
                    { new Guid("77d871ff-adb6-4b21-b9b1-2d28729ea4ec"), "H.51.1", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Passenger air transport" },
                    { new Guid("9830a55d-7ad6-48db-a350-2e77270a0db0"), "H.49.31", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Urban and suburban passenger land transport" },
                    { new Guid("e2af1499-950e-4008-aa21-3cbdf75183ef"), "H.52.22", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Service activities incidental to water transportation" },
                    { new Guid("9967004b-08f8-4e64-900a-3f8743ed019c"), "H.50.30", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Inland passenger water transport" },
                    { new Guid("6629e5d3-cae4-47d3-a460-43aa452bd675"), "H.49.5", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Transport via pipeline" },
                    { new Guid("5453b86a-2a97-4283-882e-4a5aa3f1e485"), "H.50.2", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Sea and coastal freight water transport" },
                    { new Guid("f90ef40e-d25d-45af-937e-5076c192e3fe"), "H.49.2", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Freight rail transport" },
                    { new Guid("df762a7c-d886-42b6-8ab6-5240b08c20c0"), "H.49.3", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Other passenger land transport" },
                    { new Guid("f0c400ec-e2db-4fc4-8362-55eb7e798efc"), "H.49.4", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Freight transport by road and removal services" },
                    { new Guid("c29e39c1-09a1-4faf-aef8-565cc5f3125e"), "H.49.50", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Transport via pipeline" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("eb09049f-8890-4785-a150-5a61a840db5c"), "H.49.32", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Taxi operation" },
                    { new Guid("d3343774-4d3f-4143-ba11-60b3d0f29a99"), "H.52.10", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Warehousing and storage" },
                    { new Guid("9d1d39bb-5fcf-43ee-bbbe-6412bb0abec2"), "H.51.10", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Passenger air transport" },
                    { new Guid("0eb1cc6a-78d0-4df5-b901-6af90f19fa1b"), "H.52.1", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Warehousing and storage" },
                    { new Guid("c67c5c18-20a7-4f48-b35c-7dc0971ff10f"), "H.49.41", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Freight transport by road" },
                    { new Guid("513477e7-8bd7-4d54-9268-85f2e070366e"), "H.52.24", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Cargo handling" },
                    { new Guid("3d7730e0-1803-45ef-bcc6-86a9ece30020"), "H.52.29", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Other transportation support activities" },
                    { new Guid("6bb86bc5-76cb-485a-a81a-8ea6c4a3890a"), "H.50.4", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Inland freight water transport" },
                    { new Guid("6f962d7c-e050-4e8d-8a7b-902a760918a1"), "H.50.3", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Inland passenger water transport" },
                    { new Guid("5af4bebe-5283-4aeb-b4da-932fdbfc2df4"), "H.53.20", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Other postal and courier activities" },
                    { new Guid("962bcfea-ba26-42c5-a4af-933ae018beb6"), "H.53.2", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Other postal and courier activities" },
                    { new Guid("fde0ae20-b99f-4aca-bf8d-9f68cb36ebc8"), "H.49.39", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Other passenger land transport n.e.c." },
                    { new Guid("4cf7f06e-2155-4cbe-8f71-a09718a0ec4e"), "H.52", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Warehousing and support activities for transportation" },
                    { new Guid("3315661c-38e2-478c-80e6-a4da877ebffb"), "H.53.1", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Postal activities under universal service obligation" },
                    { new Guid("27ec6a2a-002d-4d4f-a003-ac121a2a4d02"), "H.51.22", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Space transport" },
                    { new Guid("0c1becb1-d6cb-456d-80a0-1c8591b60081"), "H.51", new Guid("b736e378-91b1-4ac9-9fff-0f507898ec74"), "Air transport" },
                    { new Guid("67a7d14f-5900-4a69-877a-e00ddae6f052"), "C.24.51", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Casting of iron" },
                    { new Guid("e8bb6008-acb1-4c3d-a4c4-2df06dd627d9"), "C.27.90", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other electrical equipment" },
                    { new Guid("6ee0296e-84bc-43a5-8cc7-2ebd4a06a1f0"), "C.20.59", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("315d5116-33d5-4129-8d29-a9e23445379f"), "C.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tobacco products" },
                    { new Guid("da259cdd-d03a-4996-8824-a9e66e0a2683"), "C.27.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("e97b545e-0de2-4bbd-a593-aa7686465c11"), "C.18.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Reproduction of recorded media" },
                    { new Guid("01cf86ce-89ad-4454-9e0b-aa8ae93fbcee"), "C.10.92", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of prepared pet foods" },
                    { new Guid("326c1ea4-5a1e-4abe-a584-ab6187fbbe43"), "C.10.81", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of sugar" },
                    { new Guid("895f6de1-b40b-496d-914d-ac401d3ebf22"), "C.25.7", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("a67b994d-06cf-48f1-afcc-adb1b61d4308"), "C.23.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of refractory products" },
                    { new Guid("e1e41f1c-4ded-4383-a09c-adb2e8feea5a"), "C.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other transport equipment" },
                    { new Guid("e0eb58af-c88c-47d4-a0b4-af486fa955e8"), "C.28.49", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other machine tools" },
                    { new Guid("4c135474-af49-417b-a991-afa386c086fa"), "C.26", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("9f2334cc-884c-4b5d-bd3e-b078db171f7e"), "C.30.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("8f4f18f9-d366-4cf9-997d-b09fc985cc47"), "C.23.99", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("35170a2e-051b-49e7-988e-a9847c175885"), "C.16.24", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wooden containers" },
                    { new Guid("d3bb4802-dbdb-49ea-a61f-b136a4d46676"), "C.13.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Weaving of textiles" },
                    { new Guid("6247a1b5-167f-4dc6-9cc5-b1f75105c0a0"), "C.32", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Other manufacturing" },
                    { new Guid("0a7cbf1d-86ff-48ad-8eb3-b3599b04d50e"), "C.28", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("80306d69-0cbc-44b4-bee4-b38d593d803e"), "C.10.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Production of meat and poultry meat products" },
                    { new Guid("c0c5e1c4-69a7-46f1-a6dc-b3c038c7d270"), "C.30.92", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("7815617b-504d-4ff0-b6a7-b4c4c1796c1d"), "C.13.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("992d1e78-1a16-4a16-b058-b545b9661134"), "C.13.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Preparation and spinning of textile fibres" },
                    { new Guid("5a16ebcd-19b4-4c31-9bbc-b67d2e324e9a"), "C.26.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of communication equipment" },
                    { new Guid("0bf31a39-521f-442c-8f08-b68ce31b2cbb"), "C.11.03", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cider and other fruit wines" },
                    { new Guid("c9cf9353-3f30-4380-a464-b78cdec8af0f"), "C.14.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1ccf3d8c-3c43-4bdb-87a8-b7eb945e4b4e"), "C.14.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of articles of fur" },
                    { new Guid("b1e98c5d-e72d-4aca-a1f9-b89d3f80b3c9"), "C.32.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("5aa5dbf8-ab6e-4652-9466-b8c330e75ec6"), "C.27", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electrical equipment" },
                    { new Guid("1b197344-4567-4b30-92a3-b1759ada510a"), "C.27.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of domestic appliances" },
                    { new Guid("c5c448c9-f347-4ec5-97ca-a8adadb028b5"), "C.21.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("df9f099f-45cd-45b3-90ea-a888503f34ec"), "C.29", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("00c951b3-c09b-4e77-a23d-a794dfd6fb12"), "C.10.32", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("07eceb5c-4c64-4787-8bae-92da3fdca025"), "C.29.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("1d83ec94-63f4-4484-95ca-92eb2ff9ec98"), "C.26.51", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("63bf919a-225f-4d70-b011-9322b374d094"), "C.17.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of pulp" },
                    { new Guid("3c4ab387-4df6-4a0b-aef7-954cec13a4c0"), "C.10.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("e5f9d728-aca7-4887-8f18-95813abfe93f"), "C.33.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair of electronic and optical equipment" },
                    { new Guid("5dc2ff28-7983-437a-a9cf-95d91260878b"), "C.28.41", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of metal forming machinery" },
                    { new Guid("bc17b2c8-f5e5-47a7-82b7-9845116fd872"), "C.10.41", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of oils and fats" },
                    { new Guid("2ba15391-7fad-41d1-ae47-9855076f453d"), "C.13.94", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("732fc697-a490-4acd-b833-99a7ba933c7e"), "C.27.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of batteries and accumulators" },
                    { new Guid("080c583c-ab05-4712-a400-9a9346187b66"), "C.12.00", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tobacco products" },
                    { new Guid("695a4379-9dcf-40af-a91d-9b58f9053c6f"), "C.28.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fluid power equipment" },
                    { new Guid("369bd031-33be-47b8-b8bb-9bcffc460731"), "C.15.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of footwear" },
                    { new Guid("d73d0052-0471-4670-94bb-9d3e90c9f88b"), "C.16.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of products of wood, cork, straw and plaiting materials" },
                    { new Guid("1b59966e-fa78-4298-854d-9e0de9461239"), "C.10.86", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("f8725fbd-5322-41d2-8aca-9ebeaf0f007c"), "C.32.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacturing n.e.c." },
                    { new Guid("a12cdeb1-c03d-4aea-a982-9ef0ef613206"), "C.30.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Building of pleasure and sporting boats" },
                    { new Guid("b0909a3e-6597-47f7-a933-9f2fab0aacd6"), "C.24.34", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Cold drawing of wire" },
                    { new Guid("edf47a2b-6542-4313-b46e-9ffe30ca7bf8"), "C.23.52", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of lime and plaster" },
                    { new Guid("031421c0-289b-44ee-8858-a059cda7ff65"), "C.23.7", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Cutting, shaping and finishing of stone" },
                    { new Guid("a357f04f-86e5-4bc3-95b2-a0e37d28e3e1"), "C.10.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("0847dffc-3f90-4734-a2a3-a10a41b0fb26"), "C.23", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("483c0f8b-53a4-4723-86a6-a1431ba672ae"), "C.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of chemicals and chemical products" },
                    { new Guid("5849fccc-e885-418a-8381-a25c498003cb"), "C.27.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fibre optic cables" },
                    { new Guid("0b222e7d-055f-440c-971e-a40cb28a3231"), "C.27.40", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electric lighting equipment" },
                    { new Guid("abe1be08-d12c-495e-abac-a5de7f98c019"), "C.16", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("1be490f4-9d30-43c9-aa13-a63967429e3e"), "C.12.0", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tobacco products" },
                    { new Guid("d7962733-b43c-4944-b801-a68b84bc4f19"), "C.27.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other electrical equipment" },
                    { new Guid("e1fc543d-0e83-4318-a400-b93905a6e8bc"), "C.20.6", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of man-made fibres" },
                    { new Guid("79ba0bff-93e5-456b-b00b-927633d5fcb8"), "C.28.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("d975c6cd-64b4-4f78-86aa-b9e92a204555"), "C.10.61", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of grain mill products" },
                    { new Guid("ef9def87-4f5c-4d2e-a612-ba57ee1f1a47"), "C.24.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("808e5e1a-06f7-47a8-bfdb-cc27cfbf1941"), "C.23.65", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fibre cement" },
                    { new Guid("85c8c168-21bd-4bb1-82b3-cd0e52d80786"), "C.28.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of machinery for metallurgy" },
                    { new Guid("b6dac4cc-3f19-44ce-9e74-cf9b15754a44"), "C.25.71", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cutlery" },
                    { new Guid("a379b6ec-e87c-4b8d-b3a8-d036b296c774"), "C.24.43", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Lead, zinc and tin production" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("830efd03-ed13-4431-9315-d2674068592b"), "C.26.60", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("704ed4f3-200c-4a85-970b-d36a2601cce9"), "C.15.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("168e0ad7-7d3a-464f-ad91-d4741215522a"), "C.23.41", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("b3c94864-664c-49c4-b2b4-d4750cb02e12"), "C.24.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("d39e79ac-5ebe-42aa-a994-d6c0109e2d22"), "C.33.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair of fabricated metal products" },
                    { new Guid("d6e45c50-fb8a-4b86-b52a-d734ef56db71"), "C.20.60", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of man-made fibres" },
                    { new Guid("866419d9-7a7f-4931-a2d5-d739431b4623"), "C.33.19", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair of other equipment" },
                    { new Guid("6a651841-0d57-4025-ad91-d78497668d7f"), "C.28.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of general-purpose machinery" },
                    { new Guid("6c116185-2a61-4bb0-944a-cbee7dadc71d"), "C.28.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("e191ae0e-49a5-47b1-9fc4-d7ea3b5610c4"), "C.17.29", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("339aa805-e492-4b82-93f4-d843efa99593"), "C.25.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("7d08a9bd-a247-420b-9cb1-d89329232348"), "C.19.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of refined petroleum products" },
                    { new Guid("8a6d6147-3282-453f-88de-d8ce0ffcbde0"), "C.13.93", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of carpets and rugs" },
                    { new Guid("dbff7485-2d8e-4757-b0e2-d8e8a396f71b"), "C.10.6", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("c3fafc75-50f6-436b-bc5f-daf1a2a649be"), "C.30.99", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("67bcc5df-026e-4469-9db8-db0e079f7da6"), "C.24.46", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing of nuclear fuel" },
                    { new Guid("bf6f626d-fa33-4b26-a38c-dc12b8000af9"), "C.17.23", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of paper stationery" },
                    { new Guid("6bd34dd6-85c0-4284-af0b-dd0dd7a2bb98"), "C.32.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of games and toys" },
                    { new Guid("1d45f059-a515-4235-85cf-dd21f48ffe6b"), "C.15", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of leather and related products" },
                    { new Guid("878f8ca6-3950-4419-ae61-ddd529af262b"), "C.25.73", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tools" },
                    { new Guid("f009a1b1-1b0c-402b-9bcf-dea0be2cfbfa"), "C.33.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair of machinery" },
                    { new Guid("1cc74f6d-680a-49f3-9e07-df638c786dae"), "C.13.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Preparation and spinning of textile fibres" },
                    { new Guid("2679a0a1-4e4c-46d2-8cae-d83511ca8cda"), "C.28.96", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("65d33c3c-76f4-4ca5-9082-cbda940f585e"), "C.28.25", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("f6f5840e-958c-4c60-9e20-cac123933afd"), "C.31.09", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other furniture" },
                    { new Guid("52ec89ae-86f4-4457-bf45-ca7c3fd95c09"), "C.20.16", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of plastics in primary forms" },
                    { new Guid("1175ecad-e0fe-4e02-8034-baded6b8adc2"), "C.10.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of poultry meat" },
                    { new Guid("61511248-8c5d-43e7-b6dd-bbe61043d321"), "C.28.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other special-purpose machinery" },
                    { new Guid("474abdb3-68b2-463b-b5dd-bdf03777314f"), "C.24.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("6e55a05c-0d03-4dca-89d9-be33cb10933e"), "C.20.17", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("45eb5c12-9a80-4764-8670-be685834a9d9"), "C.25.6", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Treatment and coating of metals; machining" },
                    { new Guid("35fadc20-2670-4714-b624-bec2a158785c"), "C.18.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Reproduction of recorded media" },
                    { new Guid("90ec0b49-3357-485b-bea0-bee1d937225d"), "C.23.19", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("0b3f2620-05d3-4c86-9b7d-c00186102507"), "C.23.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Production of abrasive products" },
                    { new Guid("92a04596-94f7-4d89-9e9c-c08bb7ca91ac"), "C.25.99", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("e590993a-a43a-47d7-bb6e-c0bcfd512a75"), "C.13.99", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other textiles n.e.c." },
                    { new Guid("46d7a42f-6ca0-4dd0-8500-c0ec7b19bc92"), "C.30.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Building of ships and floating structures" },
                    { new Guid("6980d4c7-fa30-4f11-9099-c1a6848ddc3b"), "C.24.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("6ee30645-f7da-4879-ae4d-c2a0d3884bdb"), "C.25.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of doors and windows of metal" },
                    { new Guid("01c80637-01f2-4f00-a6d1-c2fab0cece25"), "C.10.62", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of starches and starch products" },
                    { new Guid("bc633ef0-1f85-43ba-9747-c3a0e981a162"), "C.33.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Installation of industrial machinery and equipment" },
                    { new Guid("ef189937-1430-43ef-b34b-c40341de3279"), "C.32.50", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of medical and dental instruments and supplies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d60d60d9-36ca-4571-bc6a-c55adedf2f89"), "C.10.39", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("7459562f-4ffe-468f-9a88-c579655ec251"), "C.24.32", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Cold rolling of narrow strip" },
                    { new Guid("1594743f-d486-4f17-99b5-c5acd6b2335f"), "C.10.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("7b8e669c-18a0-4596-b27c-c65e31781327"), "C.24.44", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Copper production" },
                    { new Guid("b4833b34-a3e1-46b3-9bf9-c7042d55b109"), "C.23.51", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cement" },
                    { new Guid("727cbf34-73ed-495d-90c6-c82728819e21"), "C.28.93", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("1b473ab5-0377-4c24-86de-c8af207a21f8"), "C.16.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Sawmilling and planing of wood" },
                    { new Guid("483f398b-ae0d-4a8a-b1d5-c8c8d7309fff"), "C.23.63", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ready-mixed concrete" },
                    { new Guid("d8ce4faa-fdf9-4336-85ad-c922c9eeaf63"), "C.32.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of brooms and brushes" },
                    { new Guid("53fd7fd5-e9f8-4b76-8415-c9a1695310f6"), "C.23.42", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("c1980f1f-9f61-48df-a67d-ca2128b8742f"), "C.32.99", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Other manufacturing n.e.c." },
                    { new Guid("ca6c6025-4c7f-4cd3-834a-b9fef4241621"), "C.16.29", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("40a3b64e-22a3-43d2-835f-2e3c98f62017"), "C.20.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of dyes and pigments" },
                    { new Guid("04bee32e-385b-4159-b2c9-8fe2e88ce0fc"), "C.10.71", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("976cff68-ec27-46a8-992e-8cb7c85322ab"), "C.26.6", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("ef45cc62-6fe6-48b8-9217-460765ed157e"), "C.17.21", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("ea36fbb6-64c2-41af-a732-462bcfe6e946"), "C.27.33", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wiring devices" },
                    { new Guid("f42af7b8-ad0b-4157-ad0a-46f493828bae"), "C.26.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("9bc34c39-c903-4669-803a-481deb0764c3"), "C.13.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Finishing of textiles" },
                    { new Guid("7e005897-b5e6-4fe4-9d08-48702044c0fb"), "C.25.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("23a2ee1f-9469-4392-ace4-4c39cf78a271"), "C.32.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of musical instruments" },
                    { new Guid("287b6280-86f0-4e07-a94d-4c63a84d8ec5"), "C.24.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Cold drawing of bars" },
                    { new Guid("fd2d1c06-9ea1-4ee6-8dff-4d41ad415a04"), "C.24.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other products of first processing of steel" },
                    { new Guid("1d7d0c2a-1729-4caf-b814-4d9c785e2e92"), "C.18.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Other printing" },
                    { new Guid("a68d0883-1aff-49b0-bc48-4f3002a463a7"), "C.23.9", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("425686ab-5ffe-4720-afe8-4f8d9263121f"), "C.13.95", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("7a07db8f-bd6c-44dd-8eb8-4feffbd4209d"), "C.28.92", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("f4d28a98-58ba-4af6-816d-43fd409ba2e8"), "C.10.83", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing of tea and coffee" },
                    { new Guid("2978ce4f-8072-4dd2-9283-51e323fa5226"), "C.14.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("410653b1-738a-4bc6-b4ae-5272531f93af"), "C.20.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("244cbb3a-4e16-46a1-ae8b-52b648c08caa"), "C.10.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of meat" },
                    { new Guid("63a1b67c-9edb-4f20-bdcb-55938ce574b4"), "C.28.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("2470a915-e8f2-485e-b4d1-55b3577ed988"), "C.23.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of refractory products" },
                    { new Guid("9a87e30d-2eaa-4664-ba77-56a00eef4dd8"), "C.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of food products" },
                    { new Guid("c179de73-c634-4cbd-897c-56fd2c83852b"), "C.11.07", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("104c2dd9-b7a4-472c-b1ac-57638d7026a9"), "C.20.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("ae219b3a-0a05-43da-94a6-5819cf4e0bf4"), "C.22", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of rubber and plastic products" },
                    { new Guid("55e3f063-ba68-49a7-92e9-583cef620f0a"), "C.30.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("d56579c5-f4fb-46d4-8482-58a4d01a2d75"), "C.10.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of potatoes" },
                    { new Guid("dad3961e-89b3-449f-8c59-5d6c6b6341fc"), "C.25.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("64663c05-900e-47d9-b096-5edf4aa50a0e"), "C.25.92", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of light metal packaging" },
                    { new Guid("fe92066a-2ea5-4081-ad72-51f6bfe2d5bf"), "C.23.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of flat glass" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("27398f47-e2cb-4d36-a724-43c793e9e604"), "C.33.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Installation of industrial machinery and equipment" },
                    { new Guid("df4c5dc6-8deb-4350-8498-43b2a54a04f9"), "C.22.19", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other rubber products" },
                    { new Guid("0cb959f3-f4c2-4242-9068-43a083f60e31"), "C.32.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Striking of coins" },
                    { new Guid("2b0866f5-e19c-4e94-bffe-30185ac9d48a"), "C.13.96", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("36f082f5-2620-4076-be80-31ba71a22122"), "C.14.19", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("0ac60aed-2eb9-4b98-9b45-31e7dd0fc90c"), "C.23.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("b2784414-c4f5-4700-8424-3343f5a9a45c"), "C.30.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("752656f6-543c-424c-ab0f-33933467b586"), "C.20.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("27563191-1ca7-4ec5-b4ec-3503d77dec08"), "C.25.29", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("2f540b35-580f-4dd1-b791-3582a4e16db4"), "C.17.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("2bcab5ce-e25e-40ab-a0f1-37825449aeed"), "C.21.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("a9753e39-b136-47e6-a419-3786b09c5d12"), "C.22.23", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("5df31687-c744-4f64-baa7-3850b47ff8dd"), "C.23.49", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other ceramic products" },
                    { new Guid("089a7114-730c-4698-a1ed-38821a36b556"), "C.28.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other pumps and compressors" },
                    { new Guid("a4803184-1d3c-46c7-bf76-39bbf7f6a715"), "C.23.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of glass and glass products" },
                    { new Guid("4ce29441-34ff-4f5f-863e-3ad941c4828f"), "C.28.22", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of lifting and handling equipment" },
                    { new Guid("1b62a843-e035-494e-a132-3b4fd6260134"), "C.24.5", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Casting of metals" },
                    { new Guid("daf1ff69-21ab-45c3-a6d7-3bddc62d2ac2"), "C.23.70", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Cutting, shaping and finishing of stone" },
                    { new Guid("81a58d68-baa3-4633-8b7c-3c76faab5e86"), "C.33", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair and installation of machinery and equipment" },
                    { new Guid("d61e9dcc-7491-4610-8044-3cfbb0ab381d"), "C.25.91", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of steel drums and similar containers" },
                    { new Guid("69291733-0241-4258-b8d4-3d2c571c6692"), "C.11.02", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wine from grape" },
                    { new Guid("959282ed-3948-412e-9e1c-3d67672a98d7"), "C.14.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of workwear" },
                    { new Guid("acffe5fa-a9fd-4799-8568-3e237a249a3c"), "C.25", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of fabricated metal products, except machinery and equipment" },
                    { new Guid("c86d7020-d0e2-4802-8ca8-3e52f3d685cb"), "C.26.8", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of magnetic and optical media" },
                    { new Guid("8a8791c2-3f84-4e27-bb04-3eeebd665017"), "C.26.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of loaded electronic boards" },
                    { new Guid("14867d46-d03f-4d41-90f4-3f893eb0ce09"), "C.15.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of footwear" },
                    { new Guid("440ae002-559c-43ab-8602-40d5b0ac9cb1"), "C.26.7", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("27588879-1f6d-4144-ab33-41268b237052"), "C.19.2", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of refined petroleum products" },
                    { new Guid("e7d1f2f1-2395-4da1-8536-4130f0a7770d"), "C.10.82", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("715f5f09-33a7-43d0-978d-437166e19a25"), "C.18", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Printing and reproduction of recorded media" },
                    { new Guid("cd302c07-c795-4a9c-9f35-5ee47642c1d6"), "C.23.32", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("51a6ed12-649a-4301-9777-8dd61732ee0a"), "C.11.06", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of malt" },
                    { new Guid("bb54164f-d550-488a-95b1-5fe7be5438a9"), "C.28.94", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("ce04f888-6329-4baa-8063-625de2564bb5"), "C.10.84", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of condiments and seasonings" },
                    { new Guid("d74e476a-d640-4f26-a566-7aee88ac3d36"), "C.27.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wiring and wiring devices" },
                    { new Guid("86178b7e-5cca-4675-ae35-7b80949a93c9"), "C.29.3", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("11b85ead-c09f-4a6f-a603-7c0249a0c78d"), "C.28.24", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of power-driven hand tools" },
                    { new Guid("9d1b3b13-ee1b-4714-a16e-7c120af5152b"), "C.20.53", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of essential oils" },
                    { new Guid("075637df-350d-4cfe-922e-7ca510c65c5c"), "C.25.62", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Machining" },
                    { new Guid("0ef43098-0f50-45cd-a0f8-7d868737ecfa"), "C.23.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of hollow glass" },
                    { new Guid("15b1a04c-c284-46c7-a319-7eb1f4a7d8f7"), "C.10.85", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of prepared meals and dishes" },
                    { new Guid("34800984-3e04-4efc-823b-82b678c03644"), "C.20.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a0bc0835-4042-4945-9245-832b822b400c"), "C.28.99", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("7c3a1794-d947-448a-9cc0-8372f54f4d02"), "C.25.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("a7c5297e-7dea-432f-9c45-844343ca7e06"), "C.23.64", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of mortars" },
                    { new Guid("6ae26897-3299-4938-89ce-8485874dc17d"), "C.10.72", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("069a462c-5b7e-4ce6-8a26-7aa92f3b7ca8"), "C.22.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("53dc0307-6c82-4da4-8931-84d8e333cbdf"), "C.31.03", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of mattresses" },
                    { new Guid("5139d393-f00c-4d93-85e3-86242cc8a605"), "C.17.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of paper and paperboard" },
                    { new Guid("9e6ccb52-ae39-4a17-9965-8661cc7117ec"), "C.33.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair of electrical equipment" },
                    { new Guid("705c93f2-b0f1-4f79-b81e-86e1aad5fdd5"), "C.23.69", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("1ea6b8a1-eccb-4d57-a506-8755922e46f3"), "C.31", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of furniture" },
                    { new Guid("f970ff64-c24d-4956-ba52-879cdd77b338"), "C.11.05", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of beer" },
                    { new Guid("50c3128b-00e7-441a-a320-87e039b12471"), "C.26.70", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("aa629e57-929c-40d2-9b23-8877d5ee9607"), "C.24.33", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Cold forming or folding" },
                    { new Guid("3ce94a79-d265-4504-b134-88e627543860"), "C.33.17", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Repair and maintenance of other transport equipment" },
                    { new Guid("7b673efa-9bfc-4be1-bd79-8bb8d8242f0b"), "C.27.32", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("8c96175e-3cbe-4d76-9d05-8c0dcda4f4e6"), "C.28.23", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("8fff8a03-bc42-4063-85f7-8c2fd710d82b"), "C.28.21", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("cfc29c78-6e51-4706-80de-8c629f184ad8"), "C.24.52", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Casting of steel" },
                    { new Guid("172debbf-b22c-4928-8714-85bd9e352007"), "C.27.12", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("7115f565-1281-44ca-8749-79efb18014e5"), "C.25.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of weapons and ammunition" },
                    { new Guid("1988fe7f-ab34-43c2-91a5-79dcd20048a5"), "C.10.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("8995b9c4-3128-47f3-b020-79b0beb3e56d"), "C.28.15", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("3955c681-6927-4113-aa69-627df6639001"), "C.18.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Binding and related services" },
                    { new Guid("2ee6e488-605e-4c60-8e30-629881c4a481"), "C.30.4", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of military fighting vehicles" },
                    { new Guid("64977174-5e78-4204-b9d5-62d7cc66378d"), "C.16.21", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("be7f2df7-2a2b-4f6f-b6e4-635b92e3d16f"), "C.19", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("79304328-94db-4b48-b871-641b4ac52bb6"), "C.21.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("308fb810-fb36-49fa-9999-6872372c80ff"), "C.27.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("5ae4a32a-2d75-41e0-9987-68fab72221f7"), "C.29.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("32ccbeee-3856-4a2e-981f-6a7467b42a31"), "C.20.20", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("b72239d8-bccb-4d42-be89-6bba75e277b7"), "C.29.10", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of motor vehicles" },
                    { new Guid("6f7508e5-07d8-41b6-9cfa-6bde7257b942"), "C.26.40", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of consumer electronics" },
                    { new Guid("ea777e81-fb30-403f-93ac-6c3a034af337"), "C.24.53", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Casting of light metals" },
                    { new Guid("8986f894-213a-489d-9e52-6c9113f0a50f"), "C.29.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of motor vehicles" },
                    { new Guid("dcac83f4-0c71-4e7e-9042-6c98a8698f6a"), "C.23.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of glass fibres" },
                    { new Guid("dd23b0cb-6c4c-46f5-8921-6d57112d9db1"), "C.14", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of wearing apparel" },
                    { new Guid("d732f8ea-4a21-4c21-858b-6f3aad06b22e"), "C.26.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of electronic components and boards" },
                    { new Guid("d402c489-b18b-4f34-9e59-6f42f26c8bff"), "C.25.40", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of weapons and ammunition" },
                    { new Guid("2c423d2e-0be6-421f-931c-6fcba0b7e004"), "C.10.52", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of ice cream" },
                    { new Guid("3a2ce221-2cec-4550-ac5e-708815a6adea"), "C.32.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("d69d74d4-7537-473a-ae77-70c195e0d812"), "C.10.89", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other food products n.e.c." },
                    { new Guid("369c01c2-9792-4e8c-8b5f-71aa81aa2b86"), "C.13.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Finishing of textiles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c5f1fbf9-c983-4b34-9ff3-71ef8b763bcd"), "C.32.30", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of sports goods" },
                    { new Guid("128e963d-c69f-4305-a7e7-72e4e644c89c"), "C.16.22", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of assembled parquet floors" },
                    { new Guid("1d2c70a7-dee7-4f5b-a0b0-733ea126727a"), "C.18.11", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Printing of newspapers" },
                    { new Guid("1eda7346-8f82-4115-99dc-73ecc7d8c9d5"), "C.18.1", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Printing and service activities related to printing" },
                    { new Guid("ce12e8ea-7ec7-415c-bbd2-7466eea710f1"), "C.28.29", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("da23baa4-09e9-4849-956e-76b85c7e4d60"), "C.14.13", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of other outerwear" },
                    { new Guid("89e4aae3-3f91-46bf-9965-782d889f948c"), "C.31.02", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of kitchen furniture" },
                    { new Guid("ef19a909-2908-44a5-8151-61b3a9754de7"), "C.20.42", new Guid("08e384e3-f59b-4b7a-b356-3ef8fa79ac13"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("9769cd69-0b8f-417c-931f-fbd1d93a5d3c"), "N.81.30", new Guid("550e86b3-c2d8-4952-9b94-f4f4b35f4f6f"), "Landscape service activities" }
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
                name: "DbSettings");

            migrationBuilder.DropTable(
                name: "Jobs");

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
