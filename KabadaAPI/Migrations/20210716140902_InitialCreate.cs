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
                    IsCostCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRevenueCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsChannelsCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("088c957b-8620-4f71-9066-82790c6eee73"), "AT", "Austria" },
                    { new Guid("8f113c78-4097-4465-90a1-7fc33909a66c"), "LU", "Luxembourg" },
                    { new Guid("49ac3e0b-646c-46ac-bf77-4f22c7be412f"), "MT", "Malta" },
                    { new Guid("7e94e707-74cf-4096-a86c-008eefcb1d72"), "MK", "North Macedonia" },
                    { new Guid("b75b7016-ef25-41de-9425-7ddc38f710c5"), "NO", "Norway" },
                    { new Guid("6355032b-1b62-48a4-9892-cf37a451206e"), "PL", "Poland" },
                    { new Guid("4725c3b8-2c9c-47d4-afcd-3ec6c6aa4c90"), "PT", "Portugal" },
                    { new Guid("5370ed66-b687-4251-93e1-185f471d4ec7"), "RO", "Romania" },
                    { new Guid("f6f01e71-9651-49c1-b45b-a947e9dc82f4"), "RS", "Serbia" },
                    { new Guid("e0392d52-f219-41f6-96e7-8e2e2995afe0"), "SK", "Slovakia" },
                    { new Guid("f55ced02-9f52-41e0-995f-f299dcf3b90f"), "SI", "Slovenia" },
                    { new Guid("214cd6e2-9cc9-4f21-8224-3161b425b716"), "ES", "Spain" },
                    { new Guid("a81b5410-84e2-457d-827d-bc6ef4cca65f"), "SE", "Sweden" },
                    { new Guid("b1643694-8953-4a9b-8bb2-340721f6d14d"), "CH", "Switzerland" },
                    { new Guid("3e809c95-f623-409c-812d-79cc4840330d"), "TR", "Turkey" },
                    { new Guid("3e386bad-668f-4ca3-b793-35e949731cf8"), "UK", "United Kingdom" },
                    { new Guid("5375a808-ba90-4919-975b-4b85a5ba661b"), "LT", "Lithuania" },
                    { new Guid("41204af2-09b8-4774-b063-ff53aacb006d"), "LI", "Liechtenstein" },
                    { new Guid("3ddd1ed0-ee45-4f93-a944-d9aeb7bd179d"), "NL", "Netherlands" },
                    { new Guid("afcc670a-8a95-4388-9767-6e266798b25a"), "IT", "Italy" },
                    { new Guid("645eb207-18f3-420c-a96c-01d0fc7ac27c"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("0d6805ee-6a75-4ee1-9b19-add1dfe8fbad"), "BE", "Belgium" },
                    { new Guid("2f395053-8a3e-4654-a8b1-daa5bdfe781e"), "BG", "Bulgaria" },
                    { new Guid("83893000-dbd2-4327-9708-1a95137ce704"), "LV", "Latvia" },
                    { new Guid("2ca5c24b-2815-41c7-955c-70517f112489"), "CY", "Cyprus" },
                    { new Guid("2d32d12e-9d16-4f97-b904-79405a88d267"), "CZ", "Czechia" },
                    { new Guid("4f913c37-03b8-4cc3-bc87-aa23d5a32d2b"), "DK", "Denmark" },
                    { new Guid("c6026b2c-805c-4f5a-b62b-c5122f65082a"), "EE", "Estonia" },
                    { new Guid("c437e61e-a26f-408e-86d5-eca600e276dd"), "HR", "Croatia" },
                    { new Guid("14348c49-d194-4fa0-8934-643113e7cf8e"), "FR", "France" },
                    { new Guid("47e1df04-9de0-409a-a958-421d823edf58"), "DE", "Germany" },
                    { new Guid("b6fe88ce-2a56-4321-8896-ab29a6e2bc92"), "EL", "Greece" },
                    { new Guid("6b1efc6e-9ee2-4272-8b78-1241181b2cf0"), "HU", "Hungary" },
                    { new Guid("8e4cc198-0473-4815-a5fa-d2fef6264f81"), "IS", "Iceland" },
                    { new Guid("aee41a0e-f377-4841-a6af-305cd9b2c33f"), "IE", "Ireland" },
                    { new Guid("3a0a71d3-6074-4f64-9162-8194e3b2eda9"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "P", "EN", "Education" },
                    { new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("c128e241-6aa3-4c82-b8ed-bb6932f96cf6"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "L", "EN", "Real estate activities" },
                    { new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "H", "EN", "Transporting and storage" },
                    { new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "J", "EN", "Information and communication" },
                    { new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "F", "EN", "Construction" },
                    { new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "C", "EN", "Manufacturing" },
                    { new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "B", "EN", "Mining and quarrying" },
                    { new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("c73cc23d-3660-4277-b215-2c1cda7c81be"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e2a64427-882d-4ced-b8fc-4d4e50c7748c"), (short)23, null, new Guid("e6e5935c-0d43-48f8-9dec-f2ed1ded8cf4"), (short)1, "Accountant" },
                    { new Guid("e6e5935c-0d43-48f8-9dec-f2ed1ded8cf4"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("1162a0d6-b0cc-465a-8998-b1159d6fca29"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)7, "Other" },
                    { new Guid("90b7b676-7477-458c-9faf-840c59eec588"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)6, "Communication" },
                    { new Guid("b602e996-d544-41c8-97d2-5b6101266921"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)5, "Maintenance" },
                    { new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("e92ce0ea-a1f2-4344-9584-d530bd190c5e"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)3, "Gas" },
                    { new Guid("62d4c398-18f5-4505-8565-ab09770cbc51"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)2, "Water" },
                    { new Guid("0348dba9-6e12-4e7d-b820-6cab500b4571"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)1, "Electricity" },
                    { new Guid("63efe98a-1404-460d-9e4f-179ba189d7f5"), (short)23, null, new Guid("e6e5935c-0d43-48f8-9dec-f2ed1ded8cf4"), (short)2, "IT support" },
                    { new Guid("766e5f4f-ab7e-41b0-bc06-87cf6e26b932"), (short)23, null, new Guid("4fda2ffe-a621-4111-8ca4-5e71f4f2b7c0"), (short)4, "Other" },
                    { new Guid("9dd27cb0-0c62-4ec8-a670-1f17f814e873"), (short)23, null, new Guid("318c572b-2cff-4d95-816b-d07296a643d4"), (short)4, "Heat" },
                    { new Guid("675add76-9009-4c88-84fd-d3f056e12545"), (short)23, null, new Guid("e6e5935c-0d43-48f8-9dec-f2ed1ded8cf4"), (short)3, "Other" },
                    { new Guid("5e87aad8-71ab-4836-a6c8-3b928a052a1c"), (short)23, null, new Guid("9b09d6e4-db23-46c8-a1ff-c3405450761f"), (short)3, "Finance management" },
                    { new Guid("e585ce3e-4434-4cf5-becb-699615748595"), (short)23, null, new Guid("c090b64e-c509-468b-bca1-ec40d4df9fe1"), (short)1, "Other" },
                    { new Guid("9b09d6e4-db23-46c8-a1ff-c3405450761f"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("16d7383e-c497-4be1-895c-311638240bb9"), (short)23, null, new Guid("9b09d6e4-db23-46c8-a1ff-c3405450761f"), (short)1, "Management" },
                    { new Guid("ec17302d-3c1e-4788-8dec-4696dd50ee31"), (short)23, null, new Guid("9b09d6e4-db23-46c8-a1ff-c3405450761f"), (short)2, "Factory workers / service" },
                    { new Guid("acd89fe3-ddb0-4213-afa6-d4b3d1ba3e2a"), (short)23, null, new Guid("9b09d6e4-db23-46c8-a1ff-c3405450761f"), (short)4, "Marketing" },
                    { new Guid("745115b2-f479-4cfa-b1f1-0a7e7c86dd4c"), (short)23, null, new Guid("9b09d6e4-db23-46c8-a1ff-c3405450761f"), (short)5, "Other" },
                    { new Guid("06a377e7-b1c9-41e9-b52e-cbe22f27fd21"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("a57a170d-0462-4324-b941-89ae32bd5924"), (short)23, null, new Guid("06a377e7-b1c9-41e9-b52e-cbe22f27fd21"), (short)1, "Other" },
                    { new Guid("d4f5acd2-1eaf-4cbb-b71f-425e10220da5"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("0d767ba2-2f14-4d95-902c-a66440ad9800"), (short)23, null, new Guid("d4f5acd2-1eaf-4cbb-b71f-425e10220da5"), (short)1, "Other" },
                    { new Guid("c401d7fd-2fb5-4358-b166-ea01725a5bfd"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("2ebe23a3-31e4-427c-8484-54aa789c5c55"), (short)23, null, new Guid("c401d7fd-2fb5-4358-b166-ea01725a5bfd"), (short)1, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("57b8014f-aa6d-423b-9755-618c6e792cef"), (short)23, null, new Guid("4fda2ffe-a621-4111-8ca4-5e71f4f2b7c0"), (short)3, "Transport" },
                    { new Guid("c090b64e-c509-468b-bca1-ec40d4df9fe1"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("875685d9-6a00-4592-af58-916800f77c90"), (short)23, null, new Guid("4fda2ffe-a621-4111-8ca4-5e71f4f2b7c0"), (short)2, "Production equipment and machinery" },
                    { new Guid("82f7c181-4d06-4bd3-adf9-4e955a34b60d"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("4fda2ffe-a621-4111-8ca4-5e71f4f2b7c0"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("def0d067-b4ee-40fa-b5a1-a86122125cad"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("70157b66-9cee-4153-9801-452783928afe"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("ba4ced9c-ae5c-43da-a8a8-7c4deb379439"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("98669725-2466-447a-ae41-63b027b0a33b"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("f02efb9c-5b32-486d-8899-5e50405af154"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("745fb8ad-b54c-4d52-9802-cf8bc283a5a3"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("f48f988f-84be-486f-9034-560aaf8eba70"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("d9f6c810-6911-4657-806a-484722534179"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("426a81fa-b0f8-4287-85ae-1a1dfe5bad75"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("a54af6f3-c7d2-4d3d-88d2-14778249336b"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("0d5e07ed-dd09-4d6e-bbe3-05ada6e743c7"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("6e578aa5-002d-442e-89e4-ffe1131e4ec9"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("5fbcfe95-8ede-44b7-b1a9-bfe7cbc6b548"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("7164cb32-9b75-4f79-827f-cd86b41c881b"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("552ea7c9-15f7-46d3-b830-c9eeef5a2550"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("fe94eb9c-4cf1-4aff-9929-f45d4022907d"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("aa5406fa-64c6-41fb-8d88-51584e829634"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("1b4dcd00-4a23-4384-bcfe-873c892d29ef"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("380cd43a-6cfb-4420-aa6a-5e0a0dca3323"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("3cbc4795-c142-4ec2-9809-11a2aae9cb95"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("e2d6d68d-073d-4082-bf4a-ee06cca7669f"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("532ca888-343a-40e2-99cc-bdea50102c0d"), (short)23, null, new Guid("e2d6d68d-073d-4082-bf4a-ee06cca7669f"), (short)1, "Other" },
                    { new Guid("2dbd2a21-1996-48f1-b412-f6677045ab3d"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("7f1a3071-ce19-4b8d-a9f0-21f0eb72d159"), (short)23, null, new Guid("2dbd2a21-1996-48f1-b412-f6677045ab3d"), (short)1, "Manufacturing buildings" },
                    { new Guid("84b95200-e5a1-4cf5-bcd2-2b79d43b67db"), (short)23, null, new Guid("2dbd2a21-1996-48f1-b412-f6677045ab3d"), (short)2, "Inventory buildings" },
                    { new Guid("95c52c50-bd5b-41eb-97bb-aced3c5ddec1"), (short)23, null, new Guid("2dbd2a21-1996-48f1-b412-f6677045ab3d"), (short)3, "Sales buildings (shops)" },
                    { new Guid("dc3d4df5-32a7-4959-90d6-7e8b1f4e7543"), (short)23, null, new Guid("2dbd2a21-1996-48f1-b412-f6677045ab3d"), (short)4, "Other" },
                    { new Guid("a8d9efb6-8b1d-4c48-80d7-13b59225c4ee"), (short)23, null, new Guid("4fda2ffe-a621-4111-8ca4-5e71f4f2b7c0"), (short)1, "IT (office) equipment" },
                    { new Guid("c37d4113-24c5-4cb4-8c6f-50fea99935a9"), (short)23, null, new Guid("def0d067-b4ee-40fa-b5a1-a86122125cad"), (short)1, "Other" },
                    { new Guid("1f69c56d-3f0f-4450-985e-2d705c781aab"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("968df735-25d8-4618-96f3-714c61b965ee"), (short)23, null, new Guid("72651c3e-6ef3-484c-8dc8-fc0fad470464"), (short)1, "Manufacturing building" },
                    { new Guid("b34efedb-b38e-43d5-b931-b87dc1fa5f84"), (short)26, null, new Guid("f3218993-4c63-4fb7-b94d-f37d725abc4c"), (short)3, "Volume dependent" },
                    { new Guid("faf98621-5135-435b-83b4-67d8e9cc7503"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("68efb8bf-31d0-4ad7-ab35-0b89c95d6e45"), (short)26, null, new Guid("faf98621-5135-435b-83b4-67d8e9cc7503"), (short)1, "Negotiation" },
                    { new Guid("c27ab7a2-32e1-454a-897f-cb73c2703332"), (short)26, null, new Guid("faf98621-5135-435b-83b4-67d8e9cc7503"), (short)2, "Yield management" },
                    { new Guid("5d869778-3139-4a9e-976f-56be273bb873"), (short)26, null, new Guid("faf98621-5135-435b-83b4-67d8e9cc7503"), (short)3, "Real time market" },
                    { new Guid("dc31a2ef-0625-4b22-8c37-a533e8cb33df"), (short)26, null, new Guid("faf98621-5135-435b-83b4-67d8e9cc7503"), (short)4, "Auctions" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("a3189d1e-a81e-476f-b873-74f4386ac9d3"), (short)27, null, null, (short)1, "Direct sales" },
                    { new Guid("b005ecd4-c9ff-4c54-bef5-7e044c206294"), (short)28, null, new Guid("a3189d1e-a81e-476f-b873-74f4386ac9d3"), (short)1, "Own shop" },
                    { new Guid("8aecf568-a6d5-46f6-8afd-7da838455d1d"), (short)29, null, new Guid("b005ecd4-c9ff-4c54-bef5-7e044c206294"), (short)1, "Physical" },
                    { new Guid("f1a1fdf9-4494-4239-9109-a062effeab27"), (short)30, null, new Guid("8aecf568-a6d5-46f6-8afd-7da838455d1d"), (short)1, "Fixed location" },
                    { new Guid("489022b3-23b0-411e-bd4b-62e19b10c0c8"), (short)30, null, new Guid("8aecf568-a6d5-46f6-8afd-7da838455d1d"), (short)2, "Mobile" },
                    { new Guid("67f29956-5a82-459f-ad8d-2990ede22b5a"), (short)31, null, new Guid("8aecf568-a6d5-46f6-8afd-7da838455d1d"), (short)1, "Self pickup" },
                    { new Guid("8224685d-e6ce-4854-80f7-65828e48b9f7"), (short)31, null, new Guid("8aecf568-a6d5-46f6-8afd-7da838455d1d"), (short)2, "Delivery to home" },
                    { new Guid("9306f049-85f6-4543-8d9a-ba729dbc781e"), (short)31, null, new Guid("8aecf568-a6d5-46f6-8afd-7da838455d1d"), (short)3, "Courier service" },
                    { new Guid("99bf317f-19ae-43b1-bb2a-8b74bccc55b6"), (short)29, null, new Guid("b005ecd4-c9ff-4c54-bef5-7e044c206294"), (short)2, "Online" },
                    { new Guid("0ef783d8-79fd-4b20-b986-c62cd1a5e673"), (short)30, null, new Guid("99bf317f-19ae-43b1-bb2a-8b74bccc55b6"), (short)1, "Own website" },
                    { new Guid("f59915b4-b9de-49c6-a490-629b773b9aee"), (short)30, null, new Guid("99bf317f-19ae-43b1-bb2a-8b74bccc55b6"), (short)2, "Platform" },
                    { new Guid("d95b19fd-97b2-441d-90ff-6d203752e357"), (short)31, null, new Guid("99bf317f-19ae-43b1-bb2a-8b74bccc55b6"), (short)1, "Own delivery" },
                    { new Guid("2dfa2cc3-3963-4769-bc9a-16a8f127f54d"), (short)31, null, new Guid("99bf317f-19ae-43b1-bb2a-8b74bccc55b6"), (short)2, "Courier service" },
                    { new Guid("1827c7f5-8c07-498f-82e7-8ab41141fe85"), (short)31, null, new Guid("99bf317f-19ae-43b1-bb2a-8b74bccc55b6"), (short)3, "To the email" },
                    { new Guid("aef195b6-6a97-4bfe-9f1d-7188fc6f3f30"), (short)28, null, new Guid("a3189d1e-a81e-476f-b873-74f4386ac9d3"), (short)2, "Market/Fairs" },
                    { new Guid("980a2227-ca5a-4107-a7da-c076484bbba7"), (short)28, null, new Guid("a3189d1e-a81e-476f-b873-74f4386ac9d3"), (short)3, "Direct visit" },
                    { new Guid("af06b829-34d9-4e89-bbdd-01f18cbeedfa"), (short)28, null, new Guid("a3189d1e-a81e-476f-b873-74f4386ac9d3"), (short)4, "" },
                    { new Guid("b3e4419c-12c1-4125-bfa0-12add4fa0e17"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("7f8cc39f-7121-4c6f-b63e-bbe8d3ab31bf"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("351f1251-158a-4627-99e1-165ce856fe91"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("9c4c598e-43a2-437c-b7f2-ddd1f10025ff"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("14b4862e-ee13-4f30-b2f5-955ea6c2f56c"), (short)26, null, new Guid("f3218993-4c63-4fb7-b94d-f37d725abc4c"), (short)2, "Product feature dependent" },
                    { new Guid("72651c3e-6ef3-484c-8dc8-fc0fad470464"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("76537ec0-07da-4dbf-a549-7bce51886a62"), (short)26, null, new Guid("f3218993-4c63-4fb7-b94d-f37d725abc4c"), (short)1, "List price" },
                    { new Guid("2fdb3754-4c1b-4925-b6e9-6ae8236a9654"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("a4458351-b992-4eb0-a7f6-e1ac1f645504"), (short)23, null, new Guid("72651c3e-6ef3-484c-8dc8-fc0fad470464"), (short)2, "Office" },
                    { new Guid("f5f68dea-1e2b-4cb2-86be-4877edef1c32"), (short)23, null, new Guid("72651c3e-6ef3-484c-8dc8-fc0fad470464"), (short)3, "Equipment" },
                    { new Guid("cf0b28af-fada-4915-8f32-32b6b95f2876"), (short)23, null, new Guid("72651c3e-6ef3-484c-8dc8-fc0fad470464"), (short)4, "Other" },
                    { new Guid("2ec77dfd-2839-47ff-81c1-dee817d96b1a"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("2a6f4cd7-2220-485a-9afc-5dde44bde63e"), (short)23, null, new Guid("2ec77dfd-2839-47ff-81c1-dee817d96b1a"), (short)1, "Other" },
                    { new Guid("78e93c8c-f564-424a-8c0e-124af5a0d87e"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("241c12d7-484a-4ae2-aa22-912dffe5e838"), (short)23, null, new Guid("78e93c8c-f564-424a-8c0e-124af5a0d87e"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("71547ad5-3789-4da5-be4b-9c479b3674c1"), (short)23, null, new Guid("78e93c8c-f564-424a-8c0e-124af5a0d87e"), (short)2, "Other" },
                    { new Guid("30b0177a-e481-4c59-adf0-2259f291b431"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("9a3da24d-35cd-49ca-b4f7-8ed3b6233d3b"), (short)23, null, new Guid("30b0177a-e481-4c59-adf0-2259f291b431"), (short)1, "Other" },
                    { new Guid("a6fc7307-f1a1-4c93-ba87-480fa2aa9427"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("9d9af525-9b81-4837-aebf-7330c2585273"), (short)23, null, new Guid("a6fc7307-f1a1-4c93-ba87-480fa2aa9427"), (short)1, "Other" },
                    { new Guid("50de85a2-c982-4702-bc2b-aa30fc4ff582"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("152e5f29-312f-4d9c-a3e5-17571064e230"), (short)23, null, new Guid("50de85a2-c982-4702-bc2b-aa30fc4ff582"), (short)1, "Other" },
                    { new Guid("3b39559b-b63b-4c8c-9f11-524b94e74751"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("d0d7b17a-3964-4704-8a7d-029397138acc"), (short)23, null, new Guid("3b39559b-b63b-4c8c-9f11-524b94e74751"), (short)1, "Transport" },
                    { new Guid("f7f4da35-7167-4ae0-80c7-fba438000815"), (short)23, null, new Guid("3b39559b-b63b-4c8c-9f11-524b94e74751"), (short)2, "Cost of warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("a00ef58a-01c9-4ef7-93d3-650da48e8de7"), (short)23, null, new Guid("3b39559b-b63b-4c8c-9f11-524b94e74751"), (short)3, "Fees to distributors" },
                    { new Guid("65776979-612b-49af-b8ca-8fd89e9b9420"), (short)23, null, new Guid("3b39559b-b63b-4c8c-9f11-524b94e74751"), (short)4, "Other" },
                    { new Guid("f7fdca81-c0d7-416e-a0a0-b5cda1faa45f"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("14aaeeeb-0037-4a4d-8e6a-01aad364515e"), (short)23, null, new Guid("f7fdca81-c0d7-416e-a0a0-b5cda1faa45f"), (short)1, "Other" },
                    { new Guid("77b46213-6ef8-465a-814a-3d636e6054a3"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("2f9d6a46-f216-4063-bc77-77eb076ddc32"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("092f1052-7edf-4026-bf25-66d575891438"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("72d52ddd-5913-4b84-ba95-71936ec5336d"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("6d8d55d0-4d50-4575-a683-7091ded70f43"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("a3106520-2a11-417a-8003-afc2b213162f"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("f3218993-4c63-4fb7-b94d-f37d725abc4c"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("5fbcd08f-2c29-4172-be54-998f6ff70d54"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("5992a1eb-d53f-4393-9442-ad007114c3be"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("e17c4ae8-adfb-4d55-b41a-5a4ed396a3dd"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("e39f03d2-0b8b-419b-b02f-1c78c72cbe36"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("291ae540-113e-4909-895a-d4fc760cd7d2"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("bb093a3f-5462-4396-a20a-389245ac3481"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("011ca433-bd1b-4c44-9849-2bdcbb57f8a0"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("f4a02cd2-67e2-4f52-8391-781dd6ff21a3"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("b5e472c8-4122-4141-9b7e-e8fdf2665671"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("eef368ba-2485-4ecb-87e1-c49508e756e0"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("0ac99ffe-4fa6-4289-a42d-572b1b53876b"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("17051b2d-85b6-47ca-b564-815da3848368"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("c507d971-df1c-4b9e-8dd1-fecfcbb74b28"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("a8b32b47-5de4-4dfd-b8cf-55e9e07c95f6"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("81bf7028-03e4-4832-9b67-a49549567960"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("ef0e2039-4dc7-4db5-89b8-3c4d543255f1"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("22504a8e-1618-4753-83fb-73aa93dc4bb8"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("4438a48d-66a0-4769-8207-dfaaff754575"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("5350858c-ee4e-40d4-acd1-20b0b978308a"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("0cb43ed8-3db1-42ee-a86c-28b92deac46a"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("d0a5e365-ac03-4e9e-b64a-3f7af22b7e02"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("d7e99294-9f96-4c32-870c-7205edef89e7"), (short)6, null, new Guid("d0a5e365-ac03-4e9e-b64a-3f7af22b7e02"), (short)1, "Buildings" },
                    { new Guid("5b6d9f62-ebb0-4df7-bd93-857d4fa2780d"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("d7e99294-9f96-4c32-870c-7205edef89e7"), (short)1, "Ownership type" },
                    { new Guid("99c235a2-b0d5-45f6-8289-bcdbe7a38ccd"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d7e99294-9f96-4c32-870c-7205edef89e7"), (short)2, "Frequency" },
                    { new Guid("40f124e9-6994-4755-8560-c70c56df9845"), (short)6, null, new Guid("d0a5e365-ac03-4e9e-b64a-3f7af22b7e02"), (short)2, "Equipment" },
                    { new Guid("407e16d7-94ed-420e-858d-00d2e926fdf9"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("40f124e9-6994-4755-8560-c70c56df9845"), (short)1, "Ownership type" },
                    { new Guid("59f62097-204a-4cbb-9e5c-5d65661ba37f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("40f124e9-6994-4755-8560-c70c56df9845"), (short)2, "Frequency" },
                    { new Guid("a0ddff6e-6af2-4152-a405-87522275312b"), (short)6, null, new Guid("d0a5e365-ac03-4e9e-b64a-3f7af22b7e02"), (short)3, "Transport" },
                    { new Guid("6ac186f7-0931-4d67-8778-7eca6a34cc81"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("a0ddff6e-6af2-4152-a405-87522275312b"), (short)1, "Ownership type" },
                    { new Guid("907242fe-58cd-489d-b5c7-db0fab159e22"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("a0ddff6e-6af2-4152-a405-87522275312b"), (short)2, "Frequency" },
                    { new Guid("ce828f9f-ee20-41f2-bef8-ac412e3bff83"), (short)3, null, null, (short)8, "Accessibility of human resources" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("8c7f57df-2f6c-41da-9df2-9cad63e88cc1"), (short)6, null, new Guid("d0a5e365-ac03-4e9e-b64a-3f7af22b7e02"), (short)4, "Raw materials" },
                    { new Guid("aa4bbefe-59da-47b1-bfb7-379dbe277a55"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("1a8890ab-4889-4414-965d-dbe8361b69e2"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("64ded3c6-ccf0-40b4-a0b9-a023d2a1594d"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("8bb24771-d54c-49c8-b0fd-a0cc5091fddb"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("48d6d83b-6b83-442b-b565-ffae21af64a5"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("b05344d4-4982-4382-93ab-ec6d25bc735f"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("06b75e87-f84b-46c0-a624-9bb671817789"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("d0ae3cb8-44cc-49b7-ac9f-4a0d8a44e9b9"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("bfa96232-b1f7-4f30-b3ce-8785849cef81"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("8d6a133d-6486-479b-b3b4-da2589cba968"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("930ab7f8-9d3f-401b-a0d1-6dcb33b873f8"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("03296f3f-62d8-4e6c-8f93-ebe15c890527"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("ea14e759-dcf0-4572-8545-6ce40979d58e"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("82987456-dff0-4750-aaad-1799b0f30fc6"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("2489a1e9-413c-4dd2-848d-692d97d19e1e"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("04b768d4-51b1-4a28-9c57-df2f0fd3dcbc"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("b8d297b3-3d40-4a7f-9e39-d9fb1ec1f907"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("e4f5bc62-35af-4bf7-92e4-a7fdcb918167"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("293c5260-1668-4183-a20a-34490b5e934b"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("96c05a60-8f56-46c8-8b63-5ca194ad648a"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("3c3027d2-be64-4737-a6c5-18b9ff6a825b"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("4a6e0b51-54fd-46bf-b33d-dc2874cbf86c"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("bdd58d4e-b6dc-4113-8a89-67ecc8a5b39e"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("c3fa6f34-d639-4b22-8e1b-653efcae1e0e"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("fc7c35b4-eafb-49e7-8380-1bff74413c99"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("59226202-f6ba-45c6-ad05-42bdb8d0f80b"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("e8d54b7e-4424-4121-bc6f-0e5b116b5bc5"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("47df6765-fbb3-4051-9c6b-c597d06354c7"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("077259e6-e0d9-4951-9608-9ddef6fb2bb1"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("6951fc00-e785-4d68-9e7b-3690ee83e712"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("84e896e6-0e4a-4237-9675-101c3f33e29c"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("bfdf3ce1-9d99-49b2-ae50-4a2bb1f9e5c1"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("8c7f57df-2f6c-41da-9df2-9cad63e88cc1"), (short)1, "Ownership type" },
                    { new Guid("21abb268-9294-45c1-a7a7-3ff66d1b5650"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3ce4e4d5-65b8-4ce1-b73c-eea54dda35e8"), (short)1, "Ownership type" },
                    { new Guid("b1dc8ef3-d600-42fa-bcd0-37b20373c69b"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("62ee18b2-cba1-4d9f-abf3-51b194d106ee"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("1a01a48a-c7c3-4b03-8639-1deb9df9c119"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("50e25461-b6ca-4254-ac25-65227f6aa1ac"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("9a8c5450-b1a2-4573-a9eb-4daf40c89113"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("3cad7d81-4b50-4029-939e-c5e4827b8923"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("375ca814-dfd7-4494-949c-623e4321ac98"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("47eae0f4-169b-47ec-8475-8e7a2d266fae"), (short)15, null, null, (short)3, "No improvements or innovations" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("f7c1e9a8-9514-4f70-8af9-e5e279a02e44"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("1ef3ce01-511b-46a0-bc50-a4e7eb517745"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("c4395d8e-90e1-4628-9ea1-bcdd367b403b"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("2a614859-ffd5-45b4-83c1-35caaa54971e"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("78df3835-04f6-48ec-95a7-d8b166843524"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("f6aac9d7-57d2-4a0a-b4b4-f1922827aabd"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("0edbca17-d8e6-4f85-bdc8-86c30efcb1f4"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("40a0911d-01a0-4df9-a29f-ed69d15cc94e"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("74e87da7-ee8b-4dee-99af-4be63e657b9c"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("1e7536d7-3a77-460f-8742-d93397f78454"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("9b8f1998-1b14-4426-832f-cce30ce03632"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("12923444-6555-4482-bb11-77b0df43a201"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("69f03964-93ab-4499-bd34-a4f92b9f594e"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("488c7c11-8420-4e21-82ef-e91ab4c4de19"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("bea2893d-89a9-4bbb-8be0-0da720d27324"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("f7e7ded1-4c6d-4d68-8a7a-336aa9450572"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("d69bb116-2f04-4bf4-9fa1-0aa2bc24e3ea"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("fe7126af-a682-4fd6-894b-2a5ff13329e4"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("b2fd38c4-9ad6-4b0c-9736-1e78ea3bdca9"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("3ce4e4d5-65b8-4ce1-b73c-eea54dda35e8"), (short)6, null, new Guid("d0a5e365-ac03-4e9e-b64a-3f7af22b7e02"), (short)5, "Other" },
                    { new Guid("f8fe0049-eb4f-469a-a845-c76104cceeb2"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("7af78cd2-97e2-4cd6-80dc-704161e0d3fd"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("cfab5224-d56f-43cf-947f-9b80c0f1eab8"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3ce4e4d5-65b8-4ce1-b73c-eea54dda35e8"), (short)2, "Frequency" },
                    { new Guid("4f999eec-d43c-41e4-9e24-3c0de77dcdf4"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("f3c5c15a-6460-43e9-81c9-ecf008272c1b"), (short)6, null, new Guid("4f999eec-d43c-41e4-9e24-3c0de77dcdf4"), (short)1, "Brands" },
                    { new Guid("7149caaf-e4c3-4d75-818a-48b5150248ce"), (short)6, null, new Guid("4f999eec-d43c-41e4-9e24-3c0de77dcdf4"), (short)2, "Licenses" },
                    { new Guid("be5244e9-39e7-4e5b-aa0f-7569318681ee"), (short)6, null, new Guid("4f999eec-d43c-41e4-9e24-3c0de77dcdf4"), (short)3, "Software" },
                    { new Guid("cd603552-e60e-4486-8ab8-13fb89a31446"), (short)6, null, new Guid("4f999eec-d43c-41e4-9e24-3c0de77dcdf4"), (short)4, "Other" },
                    { new Guid("a67a3961-0ae3-4e95-8844-0e2e1835516c"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("19c0e7eb-2759-48dc-a830-cb5871e77bff"), (short)6, null, new Guid("a67a3961-0ae3-4e95-8844-0e2e1835516c"), (short)1, "Specialists & Know-how" },
                    { new Guid("91c1863e-5a5f-4c9e-be8a-5b40671e6fcf"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("19c0e7eb-2759-48dc-a830-cb5871e77bff"), (short)1, "Ownership type" },
                    { new Guid("4cb5d892-3a56-4c8a-a265-802c3bf08e1b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("19c0e7eb-2759-48dc-a830-cb5871e77bff"), (short)2, "Frequency" },
                    { new Guid("4fb09968-06a3-417d-80fd-261e1be6d69f"), (short)6, null, new Guid("a67a3961-0ae3-4e95-8844-0e2e1835516c"), (short)2, "Administrative" },
                    { new Guid("8deb4db6-349e-425f-81ef-f1dd46fa3fcd"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("4fb09968-06a3-417d-80fd-261e1be6d69f"), (short)1, "Ownership type" },
                    { new Guid("431d4cff-8aae-449c-b869-15d5bc82032a"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4fb09968-06a3-417d-80fd-261e1be6d69f"), (short)2, "Frequency" },
                    { new Guid("f5ad17c2-c69b-4417-a2cf-33077a2c2c37"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("00ae6754-bf4f-40c7-9f16-0c647eda0ed7"), (short)6, null, new Guid("a67a3961-0ae3-4e95-8844-0e2e1835516c"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("b332bb53-95eb-462b-9d8c-830ce1bdd366"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("00ae6754-bf4f-40c7-9f16-0c647eda0ed7"), (short)2, "Frequency" },
                    { new Guid("8f0142ba-2fb5-4b4d-9f8b-bbdd70df681c"), (short)6, null, new Guid("a67a3961-0ae3-4e95-8844-0e2e1835516c"), (short)4, "Other" },
                    { new Guid("0aed0e1a-acc8-4e10-8f3e-5db40f57da59"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("8f0142ba-2fb5-4b4d-9f8b-bbdd70df681c"), (short)1, "Ownership type" },
                    { new Guid("bba20e9c-e4f1-4f88-b872-249269a74390"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("8f0142ba-2fb5-4b4d-9f8b-bbdd70df681c"), (short)2, "Frequency" },
                    { new Guid("96a15b8e-9cdc-4667-8a55-1dce9e17de33"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("8b27baed-d051-4190-abee-8257a2e2d543"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("9d79c2ae-22bb-452b-94f1-233a78c3021d"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("7993b0c4-b094-44d7-95ea-74f854c7ba4f"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("ef04fdff-ad4a-4c08-8a3f-7964221cb577"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("b55366e5-0525-467c-a2dc-2d045c724376"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("baa034ab-ff54-4ac9-b591-f5ff701223a2"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("e6c92792-3e45-46ea-a613-d04841104e3d"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("782d79d5-ad55-437c-b631-7e8aac780ae8"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("00ae6754-bf4f-40c7-9f16-0c647eda0ed7"), (short)1, "Ownership type" }
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
                    { new Guid("e1a6e678-5ca9-4856-a908-cf4a2fb1e1fa"), "A.01", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("40bba745-3a35-4aaa-a724-91d1357f9984"), "H.51.22", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Space transport" },
                    { new Guid("9fbc1d7f-798c-4459-911f-9c672f697e23"), "H.52", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Warehousing and support activities for transportation" },
                    { new Guid("6309604f-8002-4c91-86cd-ed3f13b9ed24"), "H.52.1", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Warehousing and storage" },
                    { new Guid("c97f8fb5-eefc-4110-a2e1-dae26938830f"), "H.52.10", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Warehousing and storage" },
                    { new Guid("08c24e27-ba52-473b-815a-f339468f74dc"), "H.52.2", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Support activities for transportation" },
                    { new Guid("c569e8bb-62c5-41b0-bb1c-715a4368fd52"), "H.52.21", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Service activities incidental to land transportation" },
                    { new Guid("da0c242e-64c5-4e7a-824f-63c406c4bc4b"), "H.52.22", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Service activities incidental to water transportation" },
                    { new Guid("ccb35311-2399-4dd8-bbc9-8a98ed58c3b8"), "H.52.23", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Service activities incidental to air transportation" },
                    { new Guid("d9d09bac-86f0-425d-a98b-2cc0a094c418"), "H.52.24", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Cargo handling" },
                    { new Guid("6e07aea7-ffca-4ef1-a2d1-02273fa5ff18"), "H.52.29", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Other transportation support activities" },
                    { new Guid("aeb25157-36f1-4b93-866b-2e8b63afcdd8"), "H.53", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Postal and courier activities" },
                    { new Guid("663da92e-0f8a-4fdf-8283-e8c7f8e6eb42"), "H.53.1", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Postal activities under universal service obligation" },
                    { new Guid("54bc1c36-f23e-4682-9771-f86e7631ee8a"), "H.51.21", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Freight air transport" },
                    { new Guid("1836b4b4-cdbd-4f26-89d0-ea22593bcf25"), "H.53.10", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Postal activities under universal service obligation" },
                    { new Guid("ed4d2010-db5d-46d3-8b0c-beef2f8ab996"), "H.53.20", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Other postal and courier activities" },
                    { new Guid("21d352a0-aee6-482b-a2eb-9514a6c850ba"), "I.55", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Accommodation" },
                    { new Guid("75c66631-958c-42a7-ac32-05d8ec75294b"), "I.55.1", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Hotels and similar accommodation" },
                    { new Guid("2d3d3465-55c5-4079-86e0-31b31e78fd94"), "I.55.10", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Hotels and similar accommodation" },
                    { new Guid("9e24244c-4cff-43ef-9431-83dd90b45090"), "I.55.2", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Holiday and other short-stay accommodation" },
                    { new Guid("4f9799cb-161f-40b8-bbd8-39b1e12692d6"), "I.55.20", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Holiday and other short-stay accommodation" },
                    { new Guid("b107af92-d973-403e-bbe9-d6f430a8ac67"), "I.55.3", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("236d3f6a-f5c8-42fd-9127-6440e3c077f2"), "I.55.30", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("3e7460e0-27f4-4334-8d55-bf9fbf5f8d16"), "I.55.9", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Other accommodation" },
                    { new Guid("6aa40574-8cbc-41d8-80cc-d0e00975176c"), "I.55.90", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Other accommodation" },
                    { new Guid("d1a7542a-af51-424f-9319-9fe942098d74"), "I.56", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Food and beverage service activities" },
                    { new Guid("a3626d7f-75f4-488f-b8f7-312405115149"), "I.56.1", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Restaurants and mobile food service activities" },
                    { new Guid("381c1c95-3e92-47e6-983f-55267e3ba367"), "H.53.2", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Other postal and courier activities" },
                    { new Guid("a3596608-b7a1-4116-b5e8-33ac289f07c9"), "H.51.2", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Freight air transport and space transport" },
                    { new Guid("f22fa918-3a4d-454c-b9d9-5a0739bf5782"), "H.51.10", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Passenger air transport" },
                    { new Guid("41c968ed-dd20-4a59-a8d2-1ad40ea73899"), "H.51.1", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Passenger air transport" },
                    { new Guid("335cb532-5270-4c7a-a2b6-2ab447cdd30f"), "G.47.9", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("89ebf4dd-9e9d-45cc-aa89-032812d52020"), "G.47.91", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("8856cbd6-3212-4789-9205-acacd8f579e9"), "G.47.99", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("7e71dfc1-2141-4fba-905d-c3e2a6a03f46"), "H.49", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Land transport and transport via pipelines" },
                    { new Guid("18763092-93fe-4b6d-816a-5e44088edf4f"), "H.49.1", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Passenger rail transport, interurban" },
                    { new Guid("c212d577-e62f-44d6-84cc-726f8e689b3e"), "H.49.10", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Passenger rail transport, interurban" },
                    { new Guid("63c610d4-70c7-4c51-9176-4f109185c5f8"), "H.49.2", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Freight rail transport" },
                    { new Guid("14fb4a19-9ba3-46d5-ab1c-146cd7747fc0"), "H.49.20", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Freight rail transport" },
                    { new Guid("0d91026b-0c38-4620-9ce2-ccea04b667d6"), "H.49.3", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Other passenger land transport" },
                    { new Guid("8eb4eb9c-2315-4cbd-b41e-38b301ba48d5"), "H.49.31", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Urban and suburban passenger land transport" },
                    { new Guid("bec85d57-f1c8-44e8-ac1c-f330f1000489"), "H.49.32", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("8cc2e1b6-983a-4210-8f17-edecef57bade"), "H.49.39", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Other passenger land transport n.e.c." },
                    { new Guid("4b543b79-88d0-47d5-8ac1-7d910138aa46"), "H.49.4", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Freight transport by road and removal services" },
                    { new Guid("a6c47d3e-fc3c-42e9-b307-177729021427"), "H.49.41", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Freight transport by road" },
                    { new Guid("7a503dc0-44b4-4440-9386-59d9ffcc2ede"), "H.49.42", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Removal services" },
                    { new Guid("9ab57c07-1ebf-4b96-aa24-a0e3ff58cc0b"), "H.49.5", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Transport via pipeline" },
                    { new Guid("82b028b6-e6a8-4eaf-92be-95b0694f926a"), "H.49.50", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Transport via pipeline" },
                    { new Guid("52373b3b-8d6d-4d3d-9145-20c7af0e74f1"), "H.50", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Water transport" },
                    { new Guid("124b0fac-53de-4d02-b8f1-f561a205222b"), "H.50.1", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Sea and coastal passenger water transport" },
                    { new Guid("ba4671e0-462d-4060-ae77-0e78fec6f777"), "H.50.10", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Sea and coastal passenger water transport" },
                    { new Guid("d84f3308-3e12-456f-876f-d42ee8595dc8"), "H.50.2", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Sea and coastal freight water transport" },
                    { new Guid("762ab80b-4b81-49d9-b838-eef6cd15e830"), "H.50.20", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Sea and coastal freight water transport" },
                    { new Guid("ec72f8dc-1001-4c40-8980-ab36fcf3e8b4"), "H.50.3", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Inland passenger water transport" },
                    { new Guid("ddd2e9ca-197e-4ddd-b364-b9f1ee467fdc"), "H.50.30", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Inland passenger water transport" },
                    { new Guid("a732ce63-4edd-4dd2-b416-c2c5db489ac3"), "H.50.4", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Inland freight water transport" },
                    { new Guid("ed4bd88a-977a-4977-9374-46569ed65e46"), "H.50.40", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Inland freight water transport" },
                    { new Guid("3b8db5c4-7c06-4ca3-a987-5e4b38c074e0"), "H.51", new Guid("853336d2-bf20-44e4-995e-acefbcf26837"), "Air transport" },
                    { new Guid("f1c5fcb1-b74b-4756-a8f4-8ed9558a3351"), "I.56.10", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Restaurants and mobile food service activities" },
                    { new Guid("1b7adf56-fd8b-4812-94d2-1d4b6ffb6ac0"), "G.47.89", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("9686dcc0-7bca-42bd-8b93-a4ecadfd27d9"), "I.56.2", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Event catering and other food service activities" },
                    { new Guid("0194ef92-27d8-4d81-9208-e7ab8a75f32d"), "I.56.29", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Other food service activities" },
                    { new Guid("e0d880ab-8490-4d63-bf87-d686da196909"), "J.61.30", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Satellite telecommunications activities" },
                    { new Guid("2282561e-b07b-4b1c-ae1d-bff0f00a0f86"), "J.61.9", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other telecommunications activities" },
                    { new Guid("58ab19ab-3c20-4b7e-afc1-a51d8a5a4982"), "J.61.90", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other telecommunications activities" },
                    { new Guid("25157d25-3627-4fbc-9549-539fc2417c82"), "J.62", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Computer programming, consultancy and related activities" },
                    { new Guid("30654ba5-a68c-4ee0-8328-f998897d09f0"), "J.62.0", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Computer programming, consultancy and related activities" },
                    { new Guid("ba97b708-42d1-467a-a0f5-4c9f56e625af"), "J.62.01", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Computer programming activities" },
                    { new Guid("7d113a5d-328c-4a4c-9432-34e6e4cfc337"), "J.62.02", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Computer consultancy activities" },
                    { new Guid("fe14975e-bd86-46e3-b630-8ba4fcb831d6"), "J.62.03", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Computer facilities management activities" },
                    { new Guid("9a701861-8540-49e6-891b-f965c253dada"), "J.62.09", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other information technology and computer service activities" },
                    { new Guid("5f02bf7e-8633-48ed-a08d-f25f1b067833"), "J.63", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Information service activities" },
                    { new Guid("dc62fdf8-064c-441b-b7fe-a8a482c4d18b"), "J.63.1", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("fe842928-0618-4895-8ce4-68d1395e99e8"), "J.63.11", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Data processing, hosting and related activities" },
                    { new Guid("68e50443-02d1-492e-a4f0-5ab7c2d7c44f"), "J.61.3", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Satellite telecommunications activities" },
                    { new Guid("37dbcb1a-d5a8-47d9-bdd1-9fea70819052"), "J.63.12", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Web portals" },
                    { new Guid("2302ca77-5ac3-496e-bb11-1b4381ffa490"), "J.63.91", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "News agency activities" },
                    { new Guid("291bd20a-4775-4998-949e-ed7bd64d0812"), "J.63.99", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other information service activities n.e.c." },
                    { new Guid("5899ccba-44c1-41fe-bfc0-bc81db24f04d"), "K.64", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("3c7c598c-6372-4196-b928-a182db6d6d23"), "K.64.1", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Monetary intermediation" },
                    { new Guid("5e43bcd4-e0f3-41f9-9871-03e4b4f03d99"), "K.64.11", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Central banking" },
                    { new Guid("c3912620-3dc1-4c48-b9a2-4e6cd1462106"), "K.64.19", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Other monetary intermediation" },
                    { new Guid("a1f34658-faec-4e1b-b789-7bd2bdcb64a6"), "K.64.2", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Activities of holding companies" },
                    { new Guid("7cefd468-cc90-4994-83dd-bd0836ce889b"), "K.64.20", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("316444d9-84a5-4c22-962d-3c90e7b05e5e"), "K.64.3", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Trusts, funds and similar financial entities" },
                    { new Guid("9bc0feb4-d43e-4964-8995-18d999a98dbf"), "K.64.30", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Trusts, funds and similar financial entities" },
                    { new Guid("a29de2b3-f2ee-4e0f-b725-10c898c67872"), "K.64.9", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("0791c2db-8936-4887-9ac1-389d91fcda0c"), "K.64.91", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Financial leasing" },
                    { new Guid("3c86ef91-1212-4b18-8169-68bba353b8b8"), "J.63.9", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other information service activities" },
                    { new Guid("632bb8fd-af3c-4742-ab02-152b372ea53f"), "J.61.20", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Wireless telecommunications activities" },
                    { new Guid("ceba35a4-13a6-4eb1-86e6-61bfa19a3126"), "J.61.2", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Wireless telecommunications activities" },
                    { new Guid("1a68e5a9-d444-4ff4-81aa-56929809eb4a"), "J.61.10", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Wired telecommunications activities" },
                    { new Guid("9ada360c-33c8-4eca-9449-19d2b6323857"), "I.56.3", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Beverage serving activities" },
                    { new Guid("3a494d35-7268-45a7-a4e9-b06b54811550"), "I.56.30", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Beverage serving activities" },
                    { new Guid("6888ab42-e3fe-4834-82fc-f5a6a5f30867"), "J.58", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Publishing activities" },
                    { new Guid("547d5554-f70d-49b8-a0ba-ac80cf2bee07"), "J.58.1", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("5125d71c-6b6a-41c7-9ad9-0937cf38fa01"), "J.58.11", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Book publishing" },
                    { new Guid("8b475cec-b30c-40bf-a712-b575da3fbfaf"), "J.58.12", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Publishing of directories and mailing lists" },
                    { new Guid("dad2b35e-142f-436d-ba64-9c51abfe325d"), "J.58.13", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Publishing of newspapers" },
                    { new Guid("6f3ae006-c911-4be5-a549-aea12f992fcc"), "J.58.14", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Publishing of journals and periodicals" },
                    { new Guid("f7b3ac60-9573-4447-afe8-81d1a2f494bf"), "J.58.19", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other publishing activities" },
                    { new Guid("cd49a1b7-ec0a-4497-a220-a1cd11a55fa1"), "J.58.2", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Software publishing" },
                    { new Guid("c6e974ce-10df-45a4-b3f8-2c609fb218be"), "J.58.21", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Publishing of computer games" },
                    { new Guid("338d4d4f-cab6-49e1-912d-bccb5c19a78a"), "J.58.29", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Other software publishing" },
                    { new Guid("196ca8b1-9181-46fc-8d9d-db27b985e087"), "J.59", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("68ab87ef-eef9-492e-baa6-d1df4c2c5a79"), "J.59.1", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Motion picture, video and television programme activities" },
                    { new Guid("77b9f07e-98c5-43b2-a60b-e4afe6738c1e"), "J.59.11", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Motion picture, video and television programme production activities" },
                    { new Guid("7074da6e-567e-43f9-a485-d341e2693706"), "J.59.12", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("457166c3-453c-495d-a350-fac419fc27c0"), "J.59.13", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("b6acdde1-5889-4ca7-803b-f3bad8913388"), "J.59.14", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Motion picture projection activities" },
                    { new Guid("d2ff4f39-9eaf-4fee-bbc6-b7e955a36584"), "J.59.2", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Sound recording and music publishing activities" },
                    { new Guid("1ac67146-e5f0-47b6-b5a5-c504eb298a7b"), "J.59.20", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Sound recording and music publishing activities" },
                    { new Guid("4d81ec29-1af4-4b05-bfac-1bedf5bee6f6"), "J.60", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Programming and broadcasting activities" },
                    { new Guid("c14c2aac-729c-4221-a2e4-20ab89e9360b"), "J.60.1", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Radio broadcasting" },
                    { new Guid("05c38c45-818f-4a65-8f09-df9f2877469f"), "J.60.10", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Radio broadcasting" },
                    { new Guid("71981439-b4f6-4893-b4da-37069e7b5310"), "J.60.2", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Television programming and broadcasting activities" },
                    { new Guid("15582e4e-3bb4-4fb3-86b1-367415538359"), "J.60.20", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Television programming and broadcasting activities" },
                    { new Guid("dd4195e6-7bc0-43db-944a-3c4877f462df"), "J.61", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Telecommunications" },
                    { new Guid("b724dd5d-c41e-4b99-a17e-480956126ca3"), "J.61.1", new Guid("1c400054-33bd-48a6-8dc0-39cdd8413b71"), "Wired telecommunications activities" },
                    { new Guid("5af74271-603b-47ef-bef1-5a35bef5b4df"), "I.56.21", new Guid("18e4a873-2da4-4acf-bb09-1c59357938ba"), "Event catering activities" },
                    { new Guid("0002defd-00cd-4177-a47a-116dfe84aa1d"), "K.64.92", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Other credit granting" },
                    { new Guid("9176c22b-1019-433e-9951-8e5c561b3620"), "G.47.82", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("2b96fd4c-b337-438f-add8-24f0af2645a8"), "G.47.8", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale via stalls and markets" },
                    { new Guid("09ade363-dd48-46e8-aac2-f993c0b02b0e"), "G.46.19", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("68076006-6e98-41a9-9157-d427cc52407e"), "G.46.2", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("13c16e27-45e2-457e-bbb4-13bcaa2628d8"), "G.46.21", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0c2963ee-7d28-45b2-9e35-9ecfc5259e27"), "G.46.22", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of flowers and plants" },
                    { new Guid("72b325a9-8fde-4e85-9213-8423acf05bc1"), "G.46.23", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of live animals" },
                    { new Guid("1b4cde5d-0071-4bb1-a975-7e2c127766f3"), "G.46.24", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of hides, skins and leather" },
                    { new Guid("d07bbf1c-8358-470f-8b67-b833891b34f1"), "G.46.3", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("be85d3ac-5c9e-416a-947b-ecba8948ff56"), "G.46.31", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of fruit and vegetables" },
                    { new Guid("aafa11d1-a968-4ad6-8a5b-775f9c636f92"), "G.46.32", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of meat and meat products" },
                    { new Guid("d87af1f9-30c6-4eea-956a-be2786a51a7b"), "G.46.33", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("a3901776-431d-4104-a4b5-2a98bfe73405"), "G.46.34", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of beverages" },
                    { new Guid("58bf3182-63b7-4b5d-8c0c-d7ba0c1c548f"), "G.46.35", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of tobacco products" },
                    { new Guid("ef3b2648-e52b-442e-8c5a-1c98495df743"), "G.46.18", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents specialised in the sale of other particular products" },
                    { new Guid("18203ca5-c128-4d4d-ba7a-59c8e6644d42"), "G.46.36", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("6be07ca8-5ad1-4747-b03e-3bac9efbb36a"), "G.46.38", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("1bc0cc98-9595-4196-b430-ad0ab7219402"), "G.46.39", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("26f8b7cf-2578-470f-bb3b-ecf752dc942f"), "G.46.4", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of household goods" },
                    { new Guid("378edb43-9314-495c-ab1a-db44dbe7100a"), "G.46.41", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of textiles" },
                    { new Guid("ef2fe725-3aa8-4ff1-8eae-9b1a8164352c"), "G.46.42", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of clothing and footwear" },
                    { new Guid("a1c7ce92-2d7c-40e9-a21f-b2aca71aad86"), "G.46.43", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of electrical household appliances" },
                    { new Guid("f19cffd0-abc5-47ca-9ffd-f1cb615cdabe"), "G.46.44", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("a7b24755-717e-449e-a745-20ddc0a7bc73"), "G.46.45", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of perfume and cosmetics" },
                    { new Guid("6d02b390-2e4c-4543-a8bc-707181c74f9e"), "G.46.46", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of pharmaceutical goods" },
                    { new Guid("b2a39965-0a5f-4474-b098-e572f6ea364a"), "G.46.47", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("b0eef0ff-b1f5-4da7-acf3-5935609f06e1"), "G.46.48", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of watches and jewellery" },
                    { new Guid("465799f3-f488-4dc3-a5b8-1f716d49d918"), "G.46.49", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of other household goods" },
                    { new Guid("ded23fe8-1b7d-4dcf-9828-68d4ba08944f"), "G.46.37", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("1d4a55f5-363e-4485-a8b5-d5e02d70b6a2"), "G.46.17", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("ef1adbd1-ef00-4ded-9bc0-d8ccaf1215f9"), "G.46.16", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("2dfa46f7-1589-47b8-a4ba-75159a21dca6"), "G.46.15", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("232faa35-e44b-468e-aff5-02167301b3dd"), "F.43.29", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Other construction installation" },
                    { new Guid("ac863440-d872-4076-962e-6cb7366b8d0e"), "F.43.3", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Building completion and finishing" },
                    { new Guid("ce41a6c7-2fc1-4acf-a0d8-80ef15c09423"), "F.43.31", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Plastering" },
                    { new Guid("af5b4b52-9de3-452a-8bf5-ad0028f48ddc"), "F.43.32", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Joinery installation" },
                    { new Guid("266603d6-3161-4cd9-bf4b-50087b2101af"), "F.43.33", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Floor and wall covering" },
                    { new Guid("d4bab611-13a4-44d8-afb2-a64ad22b04ee"), "F.43.34", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Painting and glazing" },
                    { new Guid("c1f01766-ffdb-452f-a690-60779d43103e"), "F.43.39", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Other building completion and finishing" },
                    { new Guid("0113fa7d-c168-4502-b383-94869b344051"), "F.43.9", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Other specialised construction activities" },
                    { new Guid("36e7f316-b354-44db-994f-afa94209866a"), "F.43.91", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Roofing activities" },
                    { new Guid("e4efaf0f-0b52-4853-841f-34028649891f"), "F.43.99", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Other specialised construction activities n.e.c." },
                    { new Guid("05be5f8c-fcc4-4466-a49b-6aeb44b67f3f"), "G.45", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("febaceab-2b5a-42db-8f8f-7d28e42ed139"), "G.45.1", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Sale of motor vehicles" },
                    { new Guid("a8332ac7-0f2d-4472-97a9-83da27923eeb"), "G.45.11", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Sale of cars and light motor vehicles" },
                    { new Guid("d9a116a9-17f1-46c8-9b45-0d5a6d71ab70"), "G.45.19", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Sale of other motor vehicles" },
                    { new Guid("cd38e34b-ec8e-4f66-b90e-d6628d88a671"), "G.45.2", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4afcf4e4-e663-46ba-ad72-799653d0415f"), "G.45.20", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Maintenance and repair of motor vehicles" },
                    { new Guid("ac9e665d-98e3-4320-abc7-38b2167c1530"), "G.45.3", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("b12400d6-89bc-4ee8-bd44-29f7c9adb6f6"), "G.45.31", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("9d8d1949-925f-4f2a-a6fd-1a76b70e84d9"), "G.45.32", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("1618507f-7e0f-453c-b13c-f16ade07f9d2"), "G.45.4", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("e1806601-b237-4942-bb99-e391a3702b92"), "G.45.40", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("5198fb4c-e914-4c32-a1ae-0ded6f1ad414"), "G.46", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("6dd28196-c21d-4de2-8a5c-e8f0df4efde8"), "G.46.1", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale on a fee or contract basis" },
                    { new Guid("5c54661f-8fbb-472b-bb1c-6dbd67d05c98"), "G.46.11", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("4426ac0f-0c29-4aac-a74c-32f0742fbbbf"), "G.46.12", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("a026411c-06df-4e88-b791-671de5113ece"), "G.46.13", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("977056f5-0e87-47e4-9b67-a53ef46eae2f"), "G.46.14", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("ae182449-b988-4dc9-8b2b-102f6f92f2d9"), "G.46.5", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of information and communication equipment" },
                    { new Guid("28f1a960-1944-4cde-9d17-6b8494fc7cb1"), "G.47.81", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("cb9eb8ef-6b3f-4b37-82e3-145125df9628"), "G.46.51", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("9cb18fac-934d-41e6-9765-c666ac51311c"), "G.46.6", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("a4715ff6-941b-42ff-9da9-ad85d645e5a4"), "G.47.4", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("5e698cc6-2680-4287-8fc2-52f3457e2d05"), "G.47.41", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("ef8cee6c-2c0c-4dc1-aa68-2a2642bb7dbb"), "G.47.42", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("7b40e65d-380d-4ba7-8d8e-e6cbb6abc84d"), "G.47.43", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("8dc14c39-9599-48d0-94e4-c520722e1468"), "G.47.5", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("a1f3220a-4800-4a08-961e-5f88cedf9029"), "G.47.51", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of textiles in specialised stores" },
                    { new Guid("a3f87e37-90cf-4d13-8497-dcfc2b64d7f8"), "G.47.52", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("bd96fbd4-ee90-4c1e-95ed-697a31376834"), "G.47.53", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("7950b919-0bc4-4b9d-a642-0a6b3c443cc2"), "G.47.54", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("3af37634-d9ae-4d38-9114-9cce3a3f4dea"), "G.47.59", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("31702f54-c068-4902-8089-3ddbbf0c61d5"), "G.47.6", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("923bee99-48ec-499d-8d62-60807a675815"), "G.47.61", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of books in specialised stores" },
                    { new Guid("4e969d02-a08b-4ba4-b36f-ce89330938ca"), "G.47.30", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("6955a989-7f7c-4f53-a2c5-e6966a85e22d"), "G.47.62", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("52976cd7-9360-4f8c-9cbb-202428659f3f"), "G.47.64", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("cce1c362-5110-4d81-b191-b7b1c765b76c"), "G.47.65", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("67607257-8b76-4228-aca1-86ee9af82d1b"), "G.47.7", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of other goods in specialised stores" },
                    { new Guid("c65831fa-088d-448f-a784-967b1839a7f2"), "G.47.71", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of clothing in specialised stores" },
                    { new Guid("d6d3a4a9-79aa-4b2b-ac3e-beddc4c30850"), "G.47.72", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("5172fbfc-3ec6-4b3d-82a7-59cecad67298"), "G.47.73", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Dispensing chemist in specialised stores" },
                    { new Guid("5c0245f7-1c32-4f73-beeb-9ea4f73cb2af"), "G.47.74", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("be105ce2-9280-483d-95f7-68a7655a1273"), "G.47.75", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("ad5820f4-cc8c-4e2e-bf92-65390d4420ce"), "G.47.76", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("470d1a61-274e-48f1-a5fa-d15a0af8810c"), "G.47.77", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("b7d75367-4402-4923-868b-bbe77d8d69f4"), "G.47.78", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("497ef29f-69bc-44fe-9e0e-efe14fa072e4"), "G.47.79", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("32838a9f-38bb-4621-bbb1-f5d1ef21eb63"), "G.47.63", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("a04d2e21-6294-4d50-9bee-87527def6652"), "G.47.3", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("b6f298a4-f673-47fc-919e-b24955e92a97"), "G.47.29", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Other retail sale of food in specialised stores" },
                    { new Guid("7e95cd8c-1bf5-4913-ad98-8bd4ea25eccd"), "G.47.26", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("0739038f-837a-4a98-962e-450ed013d882"), "G.46.61", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("0f2e5f8d-7919-418c-b684-e5cbd40ca293"), "G.46.62", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of machine tools" },
                    { new Guid("cf38ec7e-74da-4867-b1cf-e48d4142a33e"), "G.46.63", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("d0c5a8b7-5160-4e23-b12e-7d07cd353d6f"), "G.46.64", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("cb6dccea-4646-41ca-ab4b-d117a995a9d5"), "G.46.65", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of office furniture" },
                    { new Guid("9eacaa6a-c423-4cae-ab4a-9d6d35beaaf9"), "G.46.66", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of other office machinery and equipment" },
                    { new Guid("e633c6a3-f4dd-4273-83a9-91256b1b80fd"), "G.46.69", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of other machinery and equipment" },
                    { new Guid("9ff95a20-5b08-4fb7-a5e7-eb74035b3af6"), "G.46.7", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Other specialised wholesale" },
                    { new Guid("197b3144-a871-438d-a948-362ed74f38ac"), "G.46.71", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("f4e8aeba-b5da-471a-ae1b-ae27e54e0485"), "G.46.72", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of metals and metal ores" },
                    { new Guid("fbbb1f0c-45d9-4e54-99fe-85f75008e2a6"), "G.46.73", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("8759beb7-beed-4d0f-9d64-20683521915d"), "G.46.74", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("ee7cce0d-67b0-460e-84d7-3bc1493e3708"), "G.46.75", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of chemical products" },
                    { new Guid("57c63eec-a4c3-4d04-b0c9-2cc01e63d838"), "G.46.76", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of other intermediate products" },
                    { new Guid("27e49980-1d3b-4471-82a3-5b20130525ab"), "G.46.77", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of waste and scrap" },
                    { new Guid("f4ca50de-a944-4dd7-a457-9222ab442ace"), "G.46.9", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Non-specialised wholesale trade" },
                    { new Guid("c7d3f711-3ecb-420c-8765-bf57d45db719"), "G.46.90", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Non-specialised wholesale trade" },
                    { new Guid("e5219626-edb0-42d9-bbce-9ab81d01127a"), "G.47", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("732253c4-b054-4b38-9f86-943dda33adb3"), "G.47.1", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale in non-specialised stores" },
                    { new Guid("31ec6e57-997d-4752-8895-dfb1c3f6b71e"), "G.47.11", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("f04e17a2-a297-479a-9f7c-4b7715b32902"), "G.47.19", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Other retail sale in non-specialised stores" },
                    { new Guid("04f7c46b-edea-4c5b-8444-07b8baf100ab"), "G.47.2", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("90006b02-1399-41d3-aa67-809bef7b8fcf"), "G.47.21", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("4f50e0db-c495-4d69-8e5f-2bfac686f4bc"), "G.47.22", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("2cd895ad-b1c8-4721-a7e5-cdd6b8dfbb16"), "G.47.23", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("169a5175-31da-45c3-81c2-61434129f59d"), "G.47.24", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("e0470485-1396-43aa-9187-9837181d7509"), "G.47.25", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Retail sale of beverages in specialised stores" },
                    { new Guid("3c9b21c5-a752-4e4b-80eb-56af62d498e0"), "G.46.52", new Guid("9073e44e-88e7-4d0b-9917-75633ee720bd"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("eca79583-8238-4500-9b89-d8e480e40eba"), "F.43.22", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("3fa40317-6a20-4025-a1da-a875f89649fd"), "K.64.99", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("fdeea457-a1f1-44ec-842b-b42a561c9438"), "K.65.1", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Insurance" },
                    { new Guid("18364a18-f7e3-422c-a984-e366afac395a"), "P.85.6", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Educational support activities" },
                    { new Guid("188bf723-8c2e-4b0a-ae6b-ab3a1292ed7e"), "P.85.60", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Educational support activities" },
                    { new Guid("dcb0bd90-0c5c-4371-910a-a12764cc0d50"), "Q.86", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Human health activities" },
                    { new Guid("e226cd56-db03-401e-b7da-9c20ead2bea5"), "Q.86.1", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Hospital activities" },
                    { new Guid("c9909035-4e49-43ed-aa54-baaa25832b03"), "Q.86.10", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Hospital activities" },
                    { new Guid("e14dd9d1-9dc9-467b-9f2a-79b4210337e1"), "Q.86.2", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Medical and dental practice activities" },
                    { new Guid("14532b75-151c-4e80-a83e-dcaa287f3c9a"), "Q.86.21", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("796b1f46-e95c-4707-813c-4b73b90114a3"), "Q.86.22", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Specialist medical practice activities" },
                    { new Guid("b8ed2a2e-7157-4f6a-9c49-08981ec9c87f"), "Q.86.23", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Dental practice activities" },
                    { new Guid("999e28dc-d7e2-4bb4-a93e-7394ddc11b10"), "Q.86.9", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Other human health activities" },
                    { new Guid("7659b743-ae7e-407f-9b73-9152866464d8"), "Q.86.90", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Other human health activities" },
                    { new Guid("7af5b2a8-24f5-4d57-afc5-a3b9ee07c138"), "Q.87", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential care activities" },
                    { new Guid("28013f96-bc71-4865-aa3c-02f534af7c18"), "P.85.59", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Other education n.e.c." },
                    { new Guid("55b38e3d-47bf-4e22-b3ed-b49415a64c9b"), "Q.87.1", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential nursing care activities" },
                    { new Guid("be0a50eb-b739-44c8-8a40-a55527e35422"), "Q.87.2", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("2bf0f051-773f-4bdf-b9a4-7696bc528e35"), "Q.87.20", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("798b4d65-ec9b-4d94-baa7-76ecb32e6cc4"), "Q.87.3", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential care activities for the elderly and disabled" },
                    { new Guid("1d454a2c-d46d-4a6e-bacb-07dc2bd4b09a"), "Q.87.30", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential care activities for the elderly and disabled" },
                    { new Guid("23c237c5-3995-4879-817b-e952d4af1bd6"), "Q.87.9", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Other residential care activities" },
                    { new Guid("efc77c32-ec0d-4620-a334-4522c7884dfe"), "Q.87.90", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Other residential care activities" },
                    { new Guid("8bb55716-5216-4e5c-9f63-323a6e0ce4fc"), "Q.88", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Social work activities without accommodation" },
                    { new Guid("c5dae5c1-befd-42fc-ba6a-85efa1309708"), "Q.88.1", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("a31a7636-2742-4a70-9cc3-fde6d764b5e0"), "Q.88.10", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("336dd774-919b-485e-8fba-2e57530dbbfb"), "Q.88.9", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Other social work activities without accommodation" },
                    { new Guid("f91e1088-b7c1-454e-a773-41517ad465cf"), "Q.88.91", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Child day-care activities" },
                    { new Guid("3916c518-34bc-4706-ab41-7a5a21fc5e88"), "Q.88.99", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("53d0020b-0710-4f7d-8ca1-7693738cdbd9"), "Q.87.10", new Guid("6c29ece4-9ffc-4bf7-878e-e1c562886399"), "Residential nursing care activities" },
                    { new Guid("a3cfa62f-db5e-47d7-a99c-3895475550fe"), "P.85.53", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Driving school activities" },
                    { new Guid("ab2e056c-c8cf-488d-90e1-4a4a1e6bd4ac"), "P.85.52", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Cultural education" },
                    { new Guid("69e4b583-bc4b-451d-aad2-0955b0e6ef69"), "P.85.51", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Sports and recreation education" },
                    { new Guid("1f090f02-03b0-4d6f-b9f6-4f09009f9b89"), "N.82.91", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Packaging activities" },
                    { new Guid("7d9e623b-28c6-4610-8f09-5ac27e430ac8"), "N.82.99", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other business support service activities n.e.c." },
                    { new Guid("4f664bb0-a7e8-4f3c-aced-74792bb36b13"), "O.84", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Public administration and defence; compulsory social security" },
                    { new Guid("bb589826-35af-42bf-9021-db744279a16b"), "O.84.1", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("bfd3d169-5f37-4fdc-b71b-eeff3e7cdfe5"), "O.84.11", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "General public administration activities" },
                    { new Guid("a00679c5-6fd6-4723-b49b-275a13cefa42"), "O.84.12", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("2933f91a-f409-49f7-8a95-242ac3285f75"), "O.84.13", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("8a82a5b0-3348-4105-b617-783fa3dacc8b"), "O.84.2", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Provision of services to the community as a whole" },
                    { new Guid("02e9c18c-4a38-45f8-841e-7ac9a4a32b7f"), "O.84.21", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Foreign affairs" },
                    { new Guid("7c0d7dd4-d1c0-45e8-9ccf-0dd8da53b7c1"), "O.84.22", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Defence activities" },
                    { new Guid("be29befd-7b13-4df4-8293-6cc6765930b2"), "O.84.23", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Justice and judicial activities" },
                    { new Guid("a7dab6b1-e1df-4938-98e9-374c72847b91"), "O.84.24", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Public order and safety activities" },
                    { new Guid("c251dab6-134d-428f-832c-d249cc1d92d8"), "O.84.25", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Fire service activities" },
                    { new Guid("097624ba-99e0-470c-a2e2-bee5fe2fab64"), "O.84.3", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Compulsory social security activities" },
                    { new Guid("b429c18a-5a68-42a6-a295-5da997378f99"), "O.84.30", new Guid("c8458554-f0f3-4509-a1aa-46134335e907"), "Compulsory social security activities" },
                    { new Guid("8e2a40ac-6efe-417b-845e-4cb06966d8c8"), "P.85", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Education" },
                    { new Guid("9cd06ef7-3217-43bd-bb01-9a8bc5b2e917"), "P.85.1", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Pre-primary education" },
                    { new Guid("212c2103-f668-4480-a706-397f211eb1bb"), "P.85.10", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Pre-primary education" },
                    { new Guid("368a04ba-c8e6-41b5-be7f-26e24bbf1eb3"), "P.85.2", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("82035e2b-1cc1-45f5-9204-a458deaf9e12"), "P.85.20", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Primary education" },
                    { new Guid("c7e6c9c1-b493-4471-95cd-70084fc9e47b"), "P.85.3", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Secondary education" },
                    { new Guid("3c1677be-e322-4385-9fe8-ff30a6fe8796"), "P.85.31", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "General secondary education" },
                    { new Guid("588574e8-23bc-4a39-a4c4-28fba50b1a02"), "P.85.32", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Technical and vocational secondary education" },
                    { new Guid("7f6c0b2c-b1f9-46aa-9a65-ea86bb067caa"), "P.85.4", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Higher education" },
                    { new Guid("d73698ac-4ad8-48b2-857e-27bf5d3c4fed"), "P.85.41", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Post-secondary non-tertiary education" },
                    { new Guid("2eb45eb3-d847-437b-b49c-739f956f152b"), "P.85.42", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Tertiary education" },
                    { new Guid("ef4215d1-825e-4d8f-87fd-1052a63e68e2"), "P.85.5", new Guid("7788a9aa-24d9-4d5b-a5d5-a25d6ff2b9ed"), "Other education" },
                    { new Guid("953ff469-ce7b-4512-8090-ca3ba31f5c8f"), "R.90", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Creative, arts and entertainment activities" },
                    { new Guid("57902318-a3de-44eb-87b4-6a69edcceb17"), "N.82.92", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("2dfe825e-cbc1-49fa-8a12-d2e45224c491"), "R.90.0", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Creative, arts and entertainment activities" },
                    { new Guid("ced2f9ea-a92c-4264-8e8b-80c20e001d84"), "R.90.02", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Support activities to performing arts" },
                    { new Guid("216ab953-a3d1-41d8-a666-ab42cca2023f"), "S.95.1", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of computers and communication equipment" },
                    { new Guid("ec87ab4c-5b88-440b-9095-905b2f72ad1a"), "S.95.11", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of computers and peripheral equipment" },
                    { new Guid("8d3256e1-0e5b-4e31-bcbb-8ac2c35242b8"), "S.95.12", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of communication equipment" },
                    { new Guid("a8f7b1a3-357d-4800-942f-579d33f98b98"), "S.95.2", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of personal and household goods" },
                    { new Guid("d48b533e-b0d7-4902-86dc-51d312121119"), "S.95.21", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of consumer electronics" },
                    { new Guid("f62c1efc-8c26-4369-bfe9-8f2f4458d4d1"), "S.95.22", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("770f2b75-ea03-423a-83d6-4316db7f618f"), "S.95.23", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of footwear and leather goods" },
                    { new Guid("53d3b354-ccdf-4dc4-b2f0-1faac6754eda"), "S.95.24", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of furniture and home furnishings" },
                    { new Guid("7b4843ec-9e35-40d4-be81-1c57f68262ab"), "S.95.25", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of watches, clocks and jewellery" },
                    { new Guid("f3061782-21f8-4ded-936f-c999a50ab725"), "S.95.29", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of other personal and household goods" },
                    { new Guid("e361ffc6-c3ba-4405-b75b-d2bd4a119049"), "S.96", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Other personal service activities" },
                    { new Guid("cf62f3c7-5a6d-4bfa-a311-548f6cf7457a"), "S.96.0", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Other personal service activities" },
                    { new Guid("83fb6473-b1cd-4c93-8f95-c1ba0fa05111"), "S.95", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Repair of computers and personal and household goods" },
                    { new Guid("c89df749-3174-4344-b002-1e97b085ae18"), "S.96.01", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("59c094c3-7bbd-4429-98ee-03c25db796d9"), "S.96.03", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Funeral and related activities" },
                    { new Guid("1327186f-c2a6-4a53-9cfd-33ef1ae971e0"), "S.96.04", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Physical well-being activities" },
                    { new Guid("9a6bfe00-7f03-4ce0-bd01-151cad83d8bf"), "S.96.09", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Other personal service activities n.e.c." },
                    { new Guid("82547ff7-bae0-44fa-9345-55bf906924f1"), "T.97", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Activities of households as employers of domestic personnel" },
                    { new Guid("99cf35ee-b8ff-449e-accf-86bde4b237cb"), "T.97.0", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Activities of households as employers of domestic personnel" },
                    { new Guid("196355d0-7b6d-49de-8d7d-f5af08f6345c"), "T.97.00", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Activities of households as employers of domestic personnel" },
                    { new Guid("7aebcd1b-544c-4768-a735-22076b79e7ab"), "T.98", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("e4767ba7-fde8-4e43-8da2-9726204a3d87"), "T.98.1", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("77573aad-4ec7-445b-8613-0142f4d9ed01"), "T.98.10", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("9236861d-c344-4b07-b38a-1df40ae9426b"), "T.98.2", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("f7c9a121-8523-4a57-a6c4-9c60b8b768cf"), "T.98.20", new Guid("a3fa5683-9b41-478b-91db-2a874f161d17"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("67002252-1d22-4ca2-8bb9-bb96607701d6"), "U.99", new Guid("c128e241-6aa3-4c82-b8ed-bb6932f96cf6"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("b166cb85-5090-4e46-be15-19ce1431c327"), "S.96.02", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Hairdressing and other beauty treatment" },
                    { new Guid("8fafbbd2-c6ea-4b27-8d07-4751d05ebdd5"), "S.94.99", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of other membership organisations n.e.c." },
                    { new Guid("1dc03103-6843-4e44-a278-1c20d07a46cd"), "S.94.92", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of political organisations" },
                    { new Guid("a7072be5-d6c1-4b0d-8f5b-d01d439d9a78"), "S.94.91", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a95b70e2-78dc-4513-84c2-bc973ee47052"), "R.90.03", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Artistic creation" },
                    { new Guid("52a98d42-7d84-411f-ad4f-51b907108c92"), "R.90.04", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Operation of arts facilities" },
                    { new Guid("af2dc92f-2935-4c94-99be-9a9b8fa35cf1"), "R.91", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("33e7ad88-76a7-48df-8945-29521a6d4235"), "R.91.0", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("1c58dac9-9ff9-4919-a6bc-78534f31e92c"), "R.91.01", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Library and archives activities" },
                    { new Guid("ebfa668e-4a22-44c2-846e-9859bcfc6a17"), "R.91.02", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Museums activities" },
                    { new Guid("1cbae40b-edff-42c2-baef-502000910823"), "R.91.03", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("32af3bbe-7f72-4d24-a3e1-8fa8ccc9d6fe"), "R.91.04", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("cc5d8f84-ee3e-4385-8764-8cc9aa2c82ce"), "R.92", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Gambling and betting activities" },
                    { new Guid("8b272534-97f6-4bc7-b20b-bfb502d4c2da"), "R.92.0", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Gambling and betting activities" },
                    { new Guid("ada98cbd-f41f-4f3a-a11e-14f4a128a519"), "R.92.00", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Gambling and betting activities" },
                    { new Guid("85b36566-7e0f-4f21-b782-7c73f1d95924"), "R.93", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Sports activities and amusement and recreation activities" },
                    { new Guid("28713657-98a4-480a-b90d-017d80b7ef20"), "R.93.1", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Sports activities" },
                    { new Guid("cdc7eb40-ad25-4b24-9ea3-fa619a185d01"), "R.93.11", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Operation of sports facilities" },
                    { new Guid("18acf3af-f58b-462a-b4b3-090d084e6d28"), "R.93.12", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Activities of sport clubs" },
                    { new Guid("0e6712ea-ee9d-465b-9833-e8669f63dc8a"), "R.93.13", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Fitness facilities" },
                    { new Guid("88f298a2-58a2-471e-952c-1ebeb076b7c1"), "R.93.19", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Other sports activities" },
                    { new Guid("6d2e1d2c-185e-4738-952d-36b7cb16a93e"), "R.93.2", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Amusement and recreation activities" },
                    { new Guid("7428b9fe-32b5-48d1-bf93-7aaed0dbb336"), "R.93.21", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Activities of amusement parks and theme parks" },
                    { new Guid("4a45ec64-e2dc-42e0-85bd-2720fc62df10"), "R.93.29", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Other amusement and recreation activities" },
                    { new Guid("0bc2d446-6f46-4f59-89d7-9c6bd199d18b"), "S.94", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of membership organisations" },
                    { new Guid("f5179b3d-4fb7-4df3-b806-b88adcda3a29"), "S.94.1", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("8bb8f271-7dd5-446e-ba05-01582e48c307"), "S.94.11", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of business and employers membership organisations" },
                    { new Guid("821cf9ba-38de-4d62-a02c-0be3a1b8a15f"), "S.94.12", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of professional membership organisations" },
                    { new Guid("12de4fb2-d231-4036-a09d-0101bc102925"), "S.94.2", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of trade unions" },
                    { new Guid("e46b0f4c-4918-40e5-aa16-cca07fee9e49"), "S.94.20", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of trade unions" },
                    { new Guid("1167c4fc-3acf-48c0-bd9b-0c5c9e52aba7"), "S.94.9", new Guid("01138d29-1c80-4ec3-90fa-fb64c498a5f8"), "Activities of other membership organisations" },
                    { new Guid("e48ade6a-70cc-470c-8492-80eb364642ea"), "R.90.01", new Guid("6648878d-a226-4ab9-901b-15f801b7f051"), "Performing arts" },
                    { new Guid("11eaf91f-7887-4e68-aee9-bd28f82e17af"), "K.65", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("0e3faa88-43ca-426b-a616-d43cebfe99d8"), "N.82.9", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Business support service activities n.e.c." },
                    { new Guid("3f193dc0-3948-4bbf-92bc-05e9d8dcc6ed"), "N.82.3", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Organisation of conventions and trade shows" },
                    { new Guid("ec0da8c6-cbb2-4e39-adc9-497d0a77d202"), "M.70.1", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Activities of head offices" },
                    { new Guid("5f7a3336-79ab-46bc-8183-dfa07e53eab7"), "M.70.10", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Activities of head offices" },
                    { new Guid("ed52c77a-bed2-48f0-8880-f208b72495a1"), "M.70.2", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Management consultancy activities" },
                    { new Guid("360d55e6-98c7-4acd-92d4-ea4becefac21"), "M.70.21", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Public relations and communication activities" },
                    { new Guid("deaee0a1-5c07-4ebb-824c-74c5a6e5c8bd"), "M.70.22", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Business and other management consultancy activities" },
                    { new Guid("4114bbe6-a4c4-4fb1-8dd8-7035b23846c6"), "M.71", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("78e8d448-bd0a-4bc5-aca2-2c3eb019d1a1"), "M.71.1", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("2d88d886-0da2-4f18-bbc0-fea875049c4c"), "M.71.11", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Architectural activities" },
                    { new Guid("c68ad135-465a-45cb-bcde-39beeae48dca"), "M.71.12", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Engineering activities and related technical consultancy" },
                    { new Guid("a9b3c8ed-bad7-414a-aa78-09bc327dde51"), "M.71.2", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Technical testing and analysis" },
                    { new Guid("bea9a8b7-154b-474b-8c73-b21b97c01b4c"), "M.71.20", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("94e6c07f-6176-4349-b920-6203cce04efd"), "M.72", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Scientific research and development" },
                    { new Guid("e4b25c55-f177-4e45-9802-9274ae9850a1"), "M.70", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Activities of head offices; management consultancy activities" },
                    { new Guid("1a7040f4-3915-407e-9436-6523d2800b5e"), "M.72.1", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("d97c886b-31e9-40d8-b92f-9d29e63ae51d"), "M.72.19", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("d5f7649e-70d8-4c0a-be35-ef1a57eef23e"), "M.72.2", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("6ac1730a-0f4d-48e7-aded-7e2780c8fea3"), "M.72.20", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("417df9d2-1a5f-4d9d-b580-c47c83d52358"), "M.73", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Advertising and market research" },
                    { new Guid("2b335a95-7c26-4518-a057-8757bb5cfc1f"), "M.73.1", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Advertising" },
                    { new Guid("400a13f6-1f98-41b0-971e-7188ef1cb1f6"), "M.73.11", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Advertising agencies" },
                    { new Guid("c02893d2-9cd7-4a21-a470-192c6ed196f2"), "M.73.12", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Media representation" },
                    { new Guid("5f398200-465b-4d21-9893-6a3290914a35"), "M.73.2", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Market research and public opinion polling" },
                    { new Guid("0b6e4f09-f217-45c0-8bab-3f164346ef64"), "M.73.20", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Market research and public opinion polling" },
                    { new Guid("3f85af7c-ff52-4437-8f43-f99bc73c59a2"), "M.74", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Other professional, scientific and technical activities" },
                    { new Guid("3ce7e1e8-a856-4006-8fdf-a8040ec5496f"), "M.74.1", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Specialised design activities" },
                    { new Guid("5e5b39d1-78a2-4421-ba1d-f10c1d599664"), "M.74.10", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Specialised design activities" },
                    { new Guid("a8ca3bc7-eeb7-403e-81c4-f2f6a8193fe5"), "M.72.11", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Research and experimental development on biotechnology" },
                    { new Guid("fee7a436-7493-4bf4-93a8-88f59a6a213a"), "M.69.20", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("3d5d5043-bd5d-421a-8282-76ba3972584a"), "M.69.2", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("ef17a528-e8ae-4157-929b-dce9160cad9b"), "M.69.10", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Legal activities" },
                    { new Guid("c13b006d-ba1a-47b4-a360-126d60c23a47"), "K.65.11", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Life insurance" },
                    { new Guid("e1aff591-6ba8-46b8-8c7d-4252522bffc3"), "K.65.12", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Non-life insurance" },
                    { new Guid("eb73eda7-695e-4df1-bb03-485046e4238f"), "K.65.2", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Reinsurance" },
                    { new Guid("a79a4d26-e78a-420c-abf4-c8af85545178"), "K.65.20", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Reinsurance" },
                    { new Guid("95cb0ee9-8384-45a0-8876-5bc3a2f235ce"), "K.65.3", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Pension funding" },
                    { new Guid("9601f5fd-8cf2-410e-b8fd-517764f868b2"), "K.65.30", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Pension funding" },
                    { new Guid("9114b21a-94ec-46c2-a8e2-ce009f0c14bf"), "K.66", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("05a69015-cb65-419e-906c-e9f836a131e6"), "K.66.1", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("baf81546-e5ab-42be-8e8d-27e038968e32"), "K.66.11", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Administration of financial markets" },
                    { new Guid("efc27171-9d7b-4aec-a002-d5b7a65cc0e6"), "K.66.12", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Security and commodity contracts brokerage" },
                    { new Guid("ad338dc3-0ae0-46dd-9ea9-849c4716b527"), "K.66.19", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("315ab364-ffc5-4cfd-87cc-ea41391a6401"), "K.66.2", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("6f6a18ec-4dfa-4eb0-a9de-dbd11376a3b2"), "K.66.21", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Risk and damage evaluation" },
                    { new Guid("4a27d061-651b-40b2-be3a-d9879da041a2"), "K.66.22", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Activities of insurance agents and brokers" },
                    { new Guid("39292019-e4a1-42f0-ba93-a77fcdbc0fcf"), "K.66.29", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("477603bb-d8fa-47f1-bcac-a447314c2a25"), "K.66.3", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Fund management activities" },
                    { new Guid("127f0f4f-493e-4fd6-bd3e-df06ea5cf572"), "K.66.30", new Guid("ca05e0ac-5b42-480a-ac62-5f0a2485ee4b"), "Fund management activities" },
                    { new Guid("522a1f0c-0d51-4533-bb55-6924a6f46798"), "L.68", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Real estate activities" },
                    { new Guid("e5e45c80-88a0-4e2d-bbba-2b7231b01c72"), "L.68.1", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Buying and selling of own real estate" },
                    { new Guid("6284775f-cba5-4d1d-96d6-5f66e222797e"), "L.68.10", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Buying and selling of own real estate" },
                    { new Guid("844f0da1-95fb-4b4b-a6c6-5ef530753f81"), "L.68.2", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Renting and operating of own or leased real estate" },
                    { new Guid("81829118-a39b-4456-aad8-cb6725db63ad"), "L.68.20", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Renting and operating of own or leased real estate" },
                    { new Guid("fa0b1d37-aa4f-41ae-b16e-58828080d3b6"), "L.68.3", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d1049978-5995-4681-8299-cf5f7cf27a62"), "L.68.31", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Real estate agencies" },
                    { new Guid("5476f308-af09-4d15-ba7a-833bddf02474"), "L.68.32", new Guid("c200791e-d807-49f3-b954-31196fb1f931"), "Management of real estate on a fee or contract basis" },
                    { new Guid("d7e325ac-cd6a-49d2-a7f9-a3e3c9f069b7"), "M.69", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Legal and accounting activities" },
                    { new Guid("b0173dfd-9f5b-439e-b83f-497ac784a634"), "M.69.1", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Legal activities" },
                    { new Guid("e962f21f-44a6-4454-81d4-2ed4efe84b29"), "M.74.2", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Photographic activities" },
                    { new Guid("086869ac-57e9-461b-8696-57608d2d1037"), "N.82.30", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Organisation of conventions and trade shows" },
                    { new Guid("d06930df-3eae-4f5c-8d21-cd47da53f8e8"), "M.74.20", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Photographic activities" },
                    { new Guid("5dc00504-9a36-4999-ac87-537ba9836bb4"), "M.74.30", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Translation and interpretation activities" },
                    { new Guid("d0ddce98-0e04-459d-a197-a4c16425f49c"), "N.79.11", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Travel agency activities" },
                    { new Guid("95ded6b5-c739-48f5-8ec9-1d82246fc1fc"), "N.79.12", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Tour operator activities" },
                    { new Guid("0082b9e6-76eb-4b2c-8aeb-212a83b811de"), "N.79.9", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other reservation service and related activities" },
                    { new Guid("d9bc6b30-0c16-4119-a582-007aa2799126"), "N.79.90", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other reservation service and related activities" },
                    { new Guid("476e6376-086d-46ea-a8f0-13602fb9a540"), "N.80", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Security and investigation activities" },
                    { new Guid("1e36706b-8324-4c5c-921b-830262d62d26"), "N.80.1", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Private security activities" },
                    { new Guid("66d66a61-8ded-411a-93d0-deb952ad3323"), "N.80.10", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Private security activities" },
                    { new Guid("7f096a99-d13c-4de1-b0e1-09f07fdb1620"), "N.80.2", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Security systems service activities" },
                    { new Guid("5559eac4-077f-4f63-b184-80856176173a"), "N.80.20", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Security systems service activities" },
                    { new Guid("502ab42f-aa19-4b6f-aa25-10da37d47533"), "N.80.3", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Investigation activities" },
                    { new Guid("4242b888-0f80-46bb-8dc3-d001e25d9492"), "N.80.30", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Investigation activities" },
                    { new Guid("07eb8cf1-4ac6-4a97-a533-4fc580f4104a"), "N.81", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Services to buildings and landscape activities" },
                    { new Guid("77cd9e88-7a79-4683-8152-4b580a5e87f3"), "N.79.1", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Travel agency and tour operator activities" },
                    { new Guid("6ad1be80-cfc6-4153-ac5c-670f54e6b595"), "N.81.1", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Combined facilities support activities" },
                    { new Guid("380cdc42-cf17-43dc-a32a-b65c64b1d742"), "N.81.2", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Cleaning activities" },
                    { new Guid("7a032f83-907f-432e-8897-e85a9e1c43b6"), "N.81.21", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "General cleaning of buildings" },
                    { new Guid("24c85ea8-36db-4e27-80d9-9ff5e3f62612"), "N.81.22", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other building and industrial cleaning activities" },
                    { new Guid("41fb998c-55c4-4dd4-a284-ac31abfe8527"), "N.81.29", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other cleaning activities" },
                    { new Guid("c120a9ad-e123-424a-b25b-1ec34d1eb30a"), "N.81.3", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Landscape service activities" },
                    { new Guid("7bb94615-81aa-479a-9d81-6cfcda826df8"), "N.81.30", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Landscape service activities" },
                    { new Guid("0f1b4edf-d1d4-46d7-9ccd-9bd885bbb60c"), "N.82", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Office administrative, office support and other business support activities" },
                    { new Guid("d5a17621-e505-4c03-b13a-079e60a1cb38"), "N.82.1", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Office administrative and support activities" },
                    { new Guid("cd317a24-a4eb-4633-880d-681d3a9e3b94"), "N.82.11", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Combined office administrative service activities" },
                    { new Guid("885d754e-b725-485e-9c29-a923e0063dc6"), "N.82.19", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("f4737bf8-1735-452c-97d3-8dcca740a90c"), "N.82.2", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Activities of call centres" },
                    { new Guid("37ce880f-59d5-436a-8f4f-2a06d53f0f37"), "N.82.20", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Activities of call centres" },
                    { new Guid("874b1020-4cb3-447b-a25c-9ef465bd32ab"), "N.81.10", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Combined facilities support activities" },
                    { new Guid("c1f3983b-628c-43f5-ba1c-8938b1a5ca81"), "N.79", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("dc127cb9-9a4c-4619-b9d9-b841cd32b85e"), "N.78.30", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other human resources provision" },
                    { new Guid("a2760c33-dd74-4bda-a454-f9c87a8d7b43"), "N.78.3", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Other human resources provision" },
                    { new Guid("8e72f5b2-b331-4d2c-8c02-e2fadd3ba48e"), "M.74.9", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("fb2c1b1f-4b23-46dd-8dd9-8eee81ab4ff6"), "M.74.90", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("61a978e7-d9a5-4b54-a9c3-089801b488d6"), "M.75", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Veterinary activities" },
                    { new Guid("8c5dce62-ba38-4b5d-b17d-bfee1ccf3cc9"), "M.75.0", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1d260c5a-f676-43f1-a9a8-7753e9b95442"), "M.75.00", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Veterinary activities" },
                    { new Guid("67c235fd-664a-46ca-ab6e-3571c9c6da0c"), "N.77", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Rental and leasing activities" },
                    { new Guid("94d9c88b-d19e-4bd6-a1d1-fb3b2d890754"), "N.77.1", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of motor vehicles" },
                    { new Guid("97276ac9-c19c-4b36-b606-790ea46b6598"), "N.77.11", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("870e2519-c677-4490-9c56-c80a15709e25"), "N.77.12", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of trucks" },
                    { new Guid("22f43c30-29d6-421b-9677-0a56528353ef"), "N.77.2", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of personal and household goods" },
                    { new Guid("86a6de55-9739-4c82-9403-44bdad02d0c8"), "N.77.21", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("1e59ffb5-a80b-4bc9-b59d-868298e5680e"), "N.77.22", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting of video tapes and disks" },
                    { new Guid("23737117-2468-43f3-85c6-de67ef19c72f"), "N.77.29", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of other personal and household goods" },
                    { new Guid("2334e9c5-7ab1-4fbf-b2f3-85c7569ffef4"), "N.77.3", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("d83f9191-0dbd-4ef2-b90f-f9bb0ae1542a"), "N.77.31", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("68696fdc-2023-47f3-b906-4351d3b6e19d"), "N.77.32", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("7ac0a9e8-270d-47b9-9f8e-db10a564b0db"), "N.77.33", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("793584ea-75a1-4e8f-b8ab-97651a860103"), "N.77.34", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of water transport equipment" },
                    { new Guid("775ec514-f8c8-48c2-8a3f-754076acf795"), "N.77.35", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of air transport equipment" },
                    { new Guid("d0d86af9-3160-440d-9380-5e816644f793"), "N.77.39", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("f4f2f643-3fe7-409a-844a-cd87b89109dc"), "N.77.4", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("0babeaab-9430-4379-a4eb-b521989502da"), "N.77.40", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("d658ae9b-bb13-47f7-bd66-7944286b11e2"), "N.78", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Employment activities" },
                    { new Guid("5604594c-2471-4a66-92b8-c62d6c62d4d4"), "N.78.1", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Activities of employment placement agencies" },
                    { new Guid("3b1d63a1-a9f6-4e3c-8622-bb17dbbdd8ca"), "N.78.10", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Activities of employment placement agencies" },
                    { new Guid("8ed49051-b634-48fa-9b50-2acf114374f4"), "N.78.2", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Temporary employment agency activities" },
                    { new Guid("9c176630-6e85-40d6-b236-9252c4abcd55"), "N.78.20", new Guid("8e84a333-7a65-41ee-965d-01bb08f94bf8"), "Temporary employment agency activities" },
                    { new Guid("a3d6d61f-0458-40f6-8ece-902dcb3411d4"), "M.74.3", new Guid("566dfdee-39f5-40af-ada3-4ce4e88e6900"), "Translation and interpretation activities" },
                    { new Guid("8c363c7a-2ea6-46a1-bf50-fb87ef56da00"), "U.99.0", new Guid("c128e241-6aa3-4c82-b8ed-bb6932f96cf6"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("c1a97935-5b3b-4213-8fc9-8069cc19ba6a"), "F.43.21", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Electrical installation" },
                    { new Guid("1adbb880-e36e-4fd6-a09b-5124a82aa07c"), "F.43.13", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Test drilling and boring" },
                    { new Guid("24094a58-9291-44e1-b9a8-397f8d88ddb8"), "C.14.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of articles of fur" },
                    { new Guid("eac7d82f-d458-4932-a7e9-388f8ca58cb1"), "C.14.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of articles of fur" },
                    { new Guid("06c2b761-eab2-42ef-994f-1ff40da3cba3"), "C.14.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("d703d612-d76a-4bc6-a182-43e0ecc75d41"), "C.14.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("ce3b585c-0c0f-49d7-99d5-66bda369b236"), "C.14.39", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("84130032-fbba-4122-95de-f02720928042"), "C.15", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of leather and related products" },
                    { new Guid("7dea72e0-eafd-4e23-bbff-326e9e33544c"), "C.15.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("03c304a9-d9d3-4a74-817c-9a8a690694af"), "C.15.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("f861dd9b-a09d-4333-b6b0-fb86433af59c"), "C.15.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("c60e9371-55f4-425e-8095-60552011dd9f"), "C.15.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of footwear" },
                    { new Guid("c8756954-9d7c-4099-bdba-90d5ec2a2044"), "C.15.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of footwear" },
                    { new Guid("3f7e5291-0f98-43e1-b3af-d14c2696e72e"), "C.16", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("4c681bb0-960f-43b0-99b1-b01b0d03ba02"), "C.14.19", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("71ac38b6-ddc5-4d2c-b1f5-0860c29e667e"), "C.16.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Sawmilling and planing of wood" },
                    { new Guid("60fe7a2e-96eb-41cb-84a9-83b73164fa1d"), "C.16.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f77b9c66-f13e-40d0-8774-f65c424d8377"), "C.16.21", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("3e0bc6f3-dcd2-4871-b02f-8b5dad70e9a3"), "C.16.22", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of assembled parquet floors" },
                    { new Guid("0bd5b44c-cf6a-47fd-93fd-c87aa8a3d63b"), "C.16.23", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("1e2a6098-5f89-41a4-af55-be91246e660b"), "C.16.24", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wooden containers" },
                    { new Guid("98fd4269-9ea1-4475-a476-5b0e20443955"), "C.16.29", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("bd4cd834-9cfc-4d24-8fdc-a79625ea1696"), "C.17", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of paper and paper products" },
                    { new Guid("7a5db396-7a64-4d4f-80f3-dd59dc9c7fe1"), "C.17.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("6b28f176-c76d-4f20-94d8-247c4da7f65d"), "C.17.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of pulp" },
                    { new Guid("f66a4a95-d9ce-486e-b542-ed0fb26a3e65"), "C.17.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of paper and paperboard" },
                    { new Guid("65968f19-b376-41f6-a1fa-269432f22666"), "C.17.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("d5f1b304-c39c-4609-a504-fb77d92b1070"), "C.17.21", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("e52b16b1-059a-4d6c-a13c-c5262fee5e54"), "C.16.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Sawmilling and planing of wood" },
                    { new Guid("6db90be0-1c75-4d76-bfa5-f4d9800f9fb6"), "C.14.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of underwear" },
                    { new Guid("0bf33f7f-8e8b-4a11-9d8e-1626645ceb96"), "C.14.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other outerwear" },
                    { new Guid("ef56e5d9-192e-49da-b5f1-060190ff24a5"), "C.14.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of workwear" },
                    { new Guid("a6641753-d41c-4aac-97c7-98ae6c9c50f5"), "C.11.02", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wine from grape" },
                    { new Guid("fe62145e-4692-47f6-8e79-bbd1f7585511"), "C.11.03", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cider and other fruit wines" },
                    { new Guid("c487fffc-d6bb-4d35-b264-277d10e1638c"), "C.11.04", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("e0b321de-c8d1-4f05-ae4b-d8a04ee32425"), "C.11.05", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of beer" },
                    { new Guid("878de6c0-64b6-4144-bb4f-6edf7f960e27"), "C.11.06", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of malt" },
                    { new Guid("2aaad66c-07ee-42f4-a40e-3a22f10e3462"), "C.11.07", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("0889ba06-87cb-42dd-9f83-10fed79175e6"), "C.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tobacco products" },
                    { new Guid("e21d1b4b-1011-41f9-81cf-867858adab72"), "C.12.0", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tobacco products" },
                    { new Guid("3cacbad6-65c0-4998-8087-6d861a55d83a"), "C.12.00", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tobacco products" },
                    { new Guid("9b216be9-8ee7-4c8e-94d4-2b34adc36c7b"), "C.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of textiles" },
                    { new Guid("2def9460-a5dd-4d71-a20d-6b1f680dfe9b"), "C.13.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Preparation and spinning of textile fibres" },
                    { new Guid("03025ed6-8f81-48ec-8d18-b5b5b2876d05"), "C.13.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Preparation and spinning of textile fibres" },
                    { new Guid("d4234137-d4c5-440c-9506-9d3ef73adac6"), "C.13.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Weaving of textiles" },
                    { new Guid("cee0c740-1874-485d-9926-4ea14df312dc"), "C.13.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Weaving of textiles" },
                    { new Guid("29a84d1d-f412-4bd1-8cc4-8a012449c0b8"), "C.13.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Finishing of textiles" },
                    { new Guid("d87ac715-af21-4c78-9f49-b1033bc39494"), "C.13.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Finishing of textiles" },
                    { new Guid("485ae9c0-767b-4d12-9441-4ab22c92b34d"), "C.13.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other textiles" },
                    { new Guid("1c44bb13-6c18-4bd9-a7f3-ce839798a25e"), "C.13.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("00e5a703-0378-456f-be73-726c3d03b1b6"), "C.13.92", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("43dded8f-51e6-4f2e-a608-0b20f8e7077b"), "C.13.93", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of carpets and rugs" },
                    { new Guid("e4abbe5e-f5d8-463e-8c0d-f6c148f44a34"), "C.13.94", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("611a0831-a0c7-4a4e-b95b-a7427785548c"), "C.13.95", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("b242c64d-6563-4e9b-a90c-082fe58bf945"), "C.13.96", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("0f2ae982-ae0a-42a5-b378-315147ce290d"), "C.13.99", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other textiles n.e.c." },
                    { new Guid("dfbb2f60-525f-4577-9715-8ceab99b98fc"), "C.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wearing apparel" },
                    { new Guid("cb0736bc-a6af-4468-84b8-abdfaba737f8"), "C.14.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("98ffa6ba-f97e-4266-b408-a964012bfda2"), "C.14.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("752c1e6a-21ef-4075-9445-7d05755366d6"), "C.17.22", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("67ad5f50-899d-4a96-a303-a6e36faf5e3d"), "C.11.01", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("a0e46bc7-46e2-4663-860c-01170f48a415"), "C.17.23", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of paper stationery" },
                    { new Guid("fac7f998-b815-43eb-9233-d958815614d4"), "C.17.29", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("c7907aa4-30ec-4ca7-a100-e4f122e21879"), "C.20.52", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of glues" },
                    { new Guid("1b2ef209-9414-44ce-b568-c0735aff86ea"), "C.20.53", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of essential oils" },
                    { new Guid("c66ce3e6-25ff-4769-a8f8-7be804a0a39c"), "C.20.59", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("131fcdae-2403-42db-aa78-107c3626b380"), "C.20.6", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of man-made fibres" },
                    { new Guid("bf5d57e2-2cfa-4d43-aade-f7cbb93d0583"), "C.20.60", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of man-made fibres" },
                    { new Guid("7881d0fa-0261-4efa-ac2f-ce8832caa612"), "C.21", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("18f4ed96-4986-40b8-84c5-d81b94be271a"), "C.21.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("53fb6ee8-11cd-470b-8426-9ec753abd0ad"), "C.21.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("4788352f-7a36-4c3d-9f73-19f27c314183"), "C.21.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("a932342f-2331-4044-a248-7dbdf16be39a"), "C.21.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("5112006c-096e-43d9-91aa-5c8153026bb7"), "C.22", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of rubber and plastic products" },
                    { new Guid("00103b83-956c-44b0-9d38-994aa43c530d"), "C.22.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of rubber products" },
                    { new Guid("bccf0f6d-c0c5-444b-b9d9-b53bdfb9cf2d"), "C.20.51", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of explosives" },
                    { new Guid("66ae221a-6241-4e5a-a50c-bf508fbbc874"), "C.22.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("5b6bfcbd-849c-4162-9284-402f4be5bff8"), "C.22.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of plastics products" },
                    { new Guid("b9284aca-10fb-48a5-856e-098656ca302b"), "C.22.21", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("c0e6776d-a776-4f10-b98b-1bbc967cd9f0"), "C.22.22", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of plastic packing goods" },
                    { new Guid("7a170121-6daf-4e7f-b6aa-868610c7d93e"), "C.22.23", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("962eebf9-25d2-43be-a543-c9817a64312d"), "C.22.29", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other plastic products" },
                    { new Guid("53b582cd-d82e-4562-b811-92c0ce1a64e2"), "C.23", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("0da253f4-1168-43ca-847f-ea28e163ceef"), "C.23.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of glass and glass products" },
                    { new Guid("dfcc2115-042f-4757-99e5-555f047d1c5e"), "C.23.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of flat glass" },
                    { new Guid("e0c631c4-5222-4d01-9786-0e8c9d74b62c"), "C.23.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Shaping and processing of flat glass" },
                    { new Guid("4fcf777d-2908-4954-b9cd-ebed4c40bdd1"), "C.23.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of hollow glass" },
                    { new Guid("8e5b9475-c00c-4986-9cf6-9487fd40f6ab"), "C.23.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of glass fibres" },
                    { new Guid("aef68551-0aac-4671-ad18-b7e0650b32dd"), "C.23.19", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("9bffa53d-439c-4b6f-a2bc-fb6b632c0828"), "C.22.19", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other rubber products" },
                    { new Guid("cc6b4d54-6075-4c85-a80a-f5ffcb86815d"), "C.20.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other chemical products" },
                    { new Guid("316f8e9c-b391-4cf1-8719-f042c5133bce"), "C.20.42", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("e32c495e-e607-4550-adb1-4ebfb351b796"), "C.20.41", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("356b5bab-0d37-44b9-a708-0f996c10dea7"), "C.18", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Printing and reproduction of recorded media" },
                    { new Guid("da2b28df-3957-42c2-81a4-b906ef1ab181"), "C.18.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Printing and service activities related to printing" },
                    { new Guid("5b6854b3-ca78-44d7-a1ce-63426cf054c4"), "C.18.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Printing of newspapers" },
                    { new Guid("5e068677-42b2-4fae-97d8-ef8b192cda88"), "C.18.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Other printing" },
                    { new Guid("5e3b7e95-fbb4-46b3-8bbc-e74a587f3f83"), "C.18.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Pre-press and pre-media services" },
                    { new Guid("f577ec1b-0c8b-4dd7-9edb-0b2336e69018"), "C.18.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Binding and related services" },
                    { new Guid("31e3372b-9c0e-4381-aa07-08586e371d33"), "C.18.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Reproduction of recorded media" },
                    { new Guid("c12d937e-fedc-436d-9ad3-1bd620f91677"), "C.18.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("cdb30752-4d3d-4e06-9d8b-44dc1aa69528"), "C.19", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("ebb713b0-8c06-4b48-8686-09b372e30c8f"), "C.19.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of coke oven products" },
                    { new Guid("ac53d42d-e1e8-43ad-8472-12022888302a"), "C.19.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of coke oven products" },
                    { new Guid("42e82290-c087-4b80-b63a-72ba46d71417"), "C.19.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of refined petroleum products" },
                    { new Guid("670f5b03-735b-4e78-ac21-72459d9680c4"), "C.19.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of refined petroleum products" },
                    { new Guid("c3627cd5-cc98-4dd7-8d9f-b7608b110ee4"), "C.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of chemicals and chemical products" },
                    { new Guid("6457e262-24ff-48b8-a1d5-22693d3d4e06"), "C.20.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("b0812292-55f9-4599-8740-bf6f45f382f2"), "C.20.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of industrial gases" },
                    { new Guid("8a92c415-d92e-4535-a0a1-827c7362f984"), "C.20.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of dyes and pigments" },
                    { new Guid("6591b4be-4365-4e05-9706-4b9f823d6813"), "C.20.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("2c343205-df54-48ad-a702-e9386414545d"), "C.20.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other organic basic chemicals" },
                    { new Guid("e610fbca-fafd-4643-854d-0f744a507991"), "C.20.15", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("44f9e003-687e-47e3-936b-12fb9fd16167"), "C.20.16", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of plastics in primary forms" },
                    { new Guid("5466fa8a-fc13-4e89-98e5-67710732ab75"), "C.20.17", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("6a068bf0-60d0-4bf1-a6dc-83ead0742408"), "C.20.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("b3e84d84-85a7-4758-b062-7115b8d2aba4"), "C.20.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("4cb28273-df03-4b00-a889-4cf41cb64775"), "C.20.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("15d89270-a69b-43c4-9d73-b746e55a8b99"), "C.20.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("10010a5b-1327-4bd9-988d-df18edef59b2"), "C.20.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("4ef0e84d-4b5f-49fe-99f5-18358848a9fd"), "C.17.24", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wallpaper" },
                    { new Guid("73b1eb25-5d6d-4820-b88d-9b00b14a0762"), "C.23.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of refractory products" },
                    { new Guid("9509f181-d6ba-4f1f-9230-59d70bb2f512"), "C.11.0", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of beverages" },
                    { new Guid("ef1fe33d-f0b7-4d68-a89f-a57eb1a006fe"), "C.10.92", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of prepared pet foods" },
                    { new Guid("333a41c3-a0f1-453c-9ac7-19721d9a7eee"), "A.01.6", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("c76bfad1-e31a-4c46-bfc0-6122dbab0000"), "A.01.61", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Support activities for crop production" },
                    { new Guid("8e43c1eb-881b-4134-8110-f3f65067356f"), "A.01.62", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Support activities for animal production" },
                    { new Guid("4635bd8a-eed2-4107-9040-009ac2421356"), "A.01.63", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Post-harvest crop activities" },
                    { new Guid("b7525e2f-4087-43ff-bbed-0bdc0a64c5f1"), "A.01.64", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Seed processing for propagation" },
                    { new Guid("7c25c352-6f17-47d6-b942-1ae9030d40ba"), "A.01.7", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Hunting, trapping and related service activities" },
                    { new Guid("09cbfc73-ddbc-43ec-98c3-d2483e9787da"), "A.01.70", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Hunting, trapping and related service activities" },
                    { new Guid("572c1489-b0aa-4aa3-9e1b-4a2d50a698b3"), "A.02", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Forestry and logging" },
                    { new Guid("4f9b92d3-6296-445c-982b-79d26c4e78f6"), "A.02.1", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Silviculture and other forestry activities" },
                    { new Guid("47c61290-c2b4-4e9a-b52a-218e5e580a43"), "A.02.10", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Silviculture and other forestry activities" },
                    { new Guid("8812010b-a06a-49d8-bed2-02ef2cbf59bb"), "A.02.2", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Logging" },
                    { new Guid("91dd8e26-598b-411e-90d7-880098fe6c6a"), "A.02.20", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Logging" },
                    { new Guid("6a829921-db83-46f4-b7cd-9c1537546bb2"), "A.01.50", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Mixed farming" },
                    { new Guid("af6bee21-8857-45b4-ac32-90b6383a3a77"), "A.02.3", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Gathering of wild growing non-wood products" },
                    { new Guid("e81640eb-224e-4fab-8bdd-d66a97f362aa"), "A.02.4", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Support services to forestry" },
                    { new Guid("21afd4ee-52bb-4734-a870-36beb7ea29b1"), "A.02.40", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Support services to forestry" },
                    { new Guid("9abf35e1-c042-428e-b6ef-42d99ecf82b8"), "A.03", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Fishing and aquaculture" },
                    { new Guid("876fca29-b985-4e68-9fde-9b7ec399f301"), "A.03.1", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Fishing" },
                    { new Guid("5aa1b537-1005-42b9-a64c-2941efd6c907"), "A.03.11", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ff9fcfb3-e087-4b24-9f65-7ae916ba266f"), "A.03.12", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Freshwater fishing" },
                    { new Guid("309fdee0-80d6-447c-855b-32a57199e43e"), "A.03.2", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Aquaculture" },
                    { new Guid("488d79f5-4759-4d6c-8569-0c89598e059e"), "A.03.21", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Marine aquaculture" },
                    { new Guid("5231196f-94f7-455b-a29e-ac576add10bd"), "A.03.22", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Freshwater aquaculture" },
                    { new Guid("ee8e2031-6483-4a2a-a944-ffa99bd69514"), "B.05", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of coal and lignite" },
                    { new Guid("991d0b0a-707e-4167-adfc-865a6f7853e7"), "B.05.1", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of hard coal" },
                    { new Guid("458a5a30-fd42-44a6-8472-232b0fe056ce"), "B.05.10", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of hard coal" },
                    { new Guid("d1b27ebe-8f40-44f3-84bd-cc1c8e000e44"), "A.02.30", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Gathering of wild growing non-wood products" },
                    { new Guid("30921550-de59-42cc-97f9-ac36bf95ef55"), "A.01.5", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Mixed farming" },
                    { new Guid("0ad8f4be-1fb1-420e-a640-7a1d8d88d512"), "A.01.49", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of other animals" },
                    { new Guid("f168f811-3642-46c3-b83c-7ee0de6a35c8"), "A.01.47", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of poultry" },
                    { new Guid("e00ed5a5-a97e-4f2a-a86e-c4e01858045b"), "A.01.1", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of non-perennial crops" },
                    { new Guid("84944b2e-5cd8-4324-be0b-ac1684caf840"), "A.01.11", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("a84ed78a-1ef2-43c4-8d7e-8a707c8ffe39"), "A.01.12", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of rice" },
                    { new Guid("b56e69bc-4be5-45b1-9279-e65522d01860"), "A.01.13", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("c2906f06-94bc-43b0-ba34-5f875554a0b7"), "A.01.14", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of sugar cane" },
                    { new Guid("e5d8c6af-6cc5-435c-b3cc-dae233fb5b07"), "A.01.15", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of tobacco" },
                    { new Guid("dc1ef2f4-728b-49ac-b882-5e5202f8680b"), "A.01.16", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of fibre crops" },
                    { new Guid("9168943e-efc8-426a-adea-b975742b00aa"), "A.01.19", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of other non-perennial crops" },
                    { new Guid("39460219-2fe3-43b6-a3ef-b38ae10a66fc"), "A.01.2", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of perennial crops" },
                    { new Guid("dceb2e31-90c6-4f77-8eb0-964d1089b3f7"), "A.01.21", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of grapes" },
                    { new Guid("2e2b73d8-df5f-41b1-ab54-0a934d60efd1"), "A.01.22", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of tropical and subtropical fruits" },
                    { new Guid("fb1cd41f-c113-484b-9d33-4b3728932762"), "A.01.23", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of citrus fruits" },
                    { new Guid("9b7de819-7ebe-49c7-9918-f75ff7f60dac"), "A.01.24", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of pome fruits and stone fruits" },
                    { new Guid("bffec13c-ba8c-4a72-a7e3-a5a1bee41db0"), "A.01.25", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("b990612d-0eef-48c3-af8b-b0fbe63bfd0c"), "A.01.26", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of oleaginous fruits" },
                    { new Guid("80ec2931-a10e-4fc0-880d-4b36a2953649"), "A.01.27", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of beverage crops" },
                    { new Guid("8fd90dc5-f186-4250-9d33-7876da76036a"), "A.01.28", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("1007196f-93fd-479a-8dae-792a05d100e1"), "A.01.29", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Growing of other perennial crops" },
                    { new Guid("86d4c98a-a237-468c-a72c-bc2d6cf07cd0"), "A.01.3", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Plant propagation" },
                    { new Guid("1339c008-7bd6-4c43-826e-62dcbe1c2cac"), "A.01.30", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Plant propagation" },
                    { new Guid("1370569f-55ed-439c-9d2d-5eb97d647ff6"), "A.01.4", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Animal production" },
                    { new Guid("e6fe37a8-0690-4361-94f6-e534016db901"), "A.01.41", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of dairy cattle" },
                    { new Guid("530d5841-0cd9-45fa-89fa-f68b69be8391"), "A.01.42", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of other cattle and buffaloes" },
                    { new Guid("08119231-a8a3-4b08-9ab5-72284784619c"), "A.01.43", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of horses and other equines" },
                    { new Guid("991fa3c0-fe6f-4019-8bc8-77b9b3136ca0"), "A.01.44", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of camels and camelids" },
                    { new Guid("c3cb3d8f-76f9-43be-8dcb-17b47f17d4f3"), "A.01.45", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of sheep and goats" },
                    { new Guid("f7667a5c-9ee0-45d6-beba-a0d9d533b673"), "A.01.46", new Guid("72c67ffe-6129-4dc3-adf6-286cbd333dc6"), "Raising of swine/pigs" },
                    { new Guid("a6da0ae4-3a6b-4764-8717-3e43ed00775d"), "B.05.2", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of lignite" },
                    { new Guid("b74b88e7-44ab-4d63-942d-621034afaa5c"), "C.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of beverages" },
                    { new Guid("113a7b22-7de9-45a9-9cb3-a982a865c3ab"), "B.05.20", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of lignite" },
                    { new Guid("ed938c08-c071-4689-b248-a00b825e51aa"), "B.06.1", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ed45f398-a0b1-412c-91e9-a6a29da84742"), "C.10.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of potatoes" },
                    { new Guid("cafea931-2b54-4a6f-b8ff-5fde1c13bbe0"), "C.10.32", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("2869e480-5956-4f1f-99da-0b3a93116d80"), "C.10.39", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("b6863031-eab3-444c-ae99-f470576fce1c"), "C.10.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("14b7284b-4533-4ec0-9e56-b7a18f6943be"), "C.10.41", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of oils and fats" },
                    { new Guid("fc63d8a5-6740-4c0b-b3f5-f34ee5e682da"), "C.10.42", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("386949ce-9ef6-4ba8-8294-24a0f6b2b53d"), "C.10.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of dairy products" },
                    { new Guid("6ed287e4-6507-4338-8591-5a1d80c6ab77"), "C.10.51", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Operation of dairies and cheese making" },
                    { new Guid("338f2206-d76e-4269-99dd-d2e690259325"), "C.10.52", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ice cream" },
                    { new Guid("bf617330-5a42-42d1-a5c2-87455ffb6c8e"), "C.10.6", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("6d47289a-2cdb-48e7-8f57-8a64f2c86d02"), "C.10.61", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of grain mill products" },
                    { new Guid("78cc739a-470d-4674-891d-8473445d083f"), "C.10.62", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of starches and starch products" },
                    { new Guid("a7b2b09d-b75a-4372-9dc2-23064914d305"), "C.10.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("dfb1e488-9de0-4aa2-8e32-5d67404c8956"), "C.10.7", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("f0b2fd8a-d7ba-4b98-894d-78a3790e9844"), "C.10.72", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("f22f0241-62ab-40cb-9e8f-9d8f7dc997f5"), "C.10.73", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("cca36f94-d09e-400f-8e9a-87bbe28cf7d6"), "C.10.8", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other food products" },
                    { new Guid("f167b58b-6c09-47fd-b113-b31818d69f26"), "C.10.81", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of sugar" },
                    { new Guid("849eb17b-84ad-4edf-8e63-1413f1031dd7"), "C.10.82", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("438b9113-e3c4-4372-af04-3e1333e9e307"), "C.10.83", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing of tea and coffee" },
                    { new Guid("346593de-9ebd-49d7-b977-a5241c22d1b8"), "C.10.84", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of condiments and seasonings" },
                    { new Guid("f6c690d5-3457-4d62-94b9-d44935b5efbc"), "C.10.85", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of prepared meals and dishes" },
                    { new Guid("b358fb5d-367b-45d5-be69-43f84d4f2147"), "C.10.86", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("c077bcf4-ef32-4855-8e41-fab3f802b9b6"), "C.10.89", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other food products n.e.c." },
                    { new Guid("504c6032-3906-4488-bb9e-876e399701c0"), "C.10.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of prepared animal feeds" },
                    { new Guid("6c51451f-0ac5-4273-a368-b4fcd9f3fce4"), "C.10.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("fb173cdf-338e-4981-9a66-fa9514c53b14"), "C.10.71", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("b47d8a43-a62d-40b9-aba3-2295c6be2cef"), "C.10.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("0ff74801-8cd5-4967-af5b-f6055566ab57"), "C.10.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("f8959bdf-454a-4d17-8f26-dc2d17c8665a"), "C.10.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Production of meat and poultry meat products" },
                    { new Guid("b9cc9ca9-b45b-43bc-aa63-31c426d17241"), "B.06.10", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of crude petroleum" },
                    { new Guid("d9c8fb91-6fe9-4c3c-bdc9-ac598b780217"), "B.06.2", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of natural gas" },
                    { new Guid("d31cb275-f709-4ad3-8b86-99215b6f4995"), "B.06.20", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of natural gas" },
                    { new Guid("c40e41cf-aac9-42dd-ada1-bd2adbd009d8"), "B.07", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of metal ores" },
                    { new Guid("7d4d6939-c66b-4966-8896-f3b3ce67b6fc"), "B.07.1", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of iron ores" },
                    { new Guid("3288eb1a-b035-4201-b19a-3dff047e3417"), "B.07.10", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of iron ores" },
                    { new Guid("2e1eac71-13f2-4a8c-b2ff-343ed5f60433"), "B.07.2", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of non-ferrous metal ores" },
                    { new Guid("7f55676e-2bd4-4e5e-8d4c-261e2ba29d78"), "B.07.21", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of uranium and thorium ores" },
                    { new Guid("e0a2f515-e596-4187-8d51-64c0552c6e2b"), "B.07.29", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of other non-ferrous metal ores" },
                    { new Guid("3a9422dc-d9a9-42bf-ad66-407720c2b670"), "B.08", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Other mining and quarrying" },
                    { new Guid("c6af5f29-5457-4bf3-99d6-9787a07a7dc8"), "B.08.1", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Quarrying of stone, sand and clay" },
                    { new Guid("2425f9e8-ec5d-45f1-8d0a-87fe1cf04585"), "B.08.11", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("18a69dbd-e11e-4000-b55e-3035705914a6"), "B.08.12", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("1b068e29-3504-4ff5-9b18-34330d303151"), "B.08.9", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining and quarrying n.e.c." },
                    { new Guid("568df104-0aab-438b-893c-3ef2593f3e6e"), "B.08.91", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("ab67a29e-d962-48b0-88b3-16ae1fff3325"), "B.08.92", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of peat" },
                    { new Guid("cdb9cad7-158a-43e8-b4b1-0631b335e057"), "B.08.93", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of salt" },
                    { new Guid("ce3f1b06-a73f-4415-b5f5-dc8e118b8348"), "B.08.99", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Other mining and quarrying n.e.c." },
                    { new Guid("7e08117d-d2fc-40db-8f53-a35257dc3109"), "B.09", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Mining support service activities" },
                    { new Guid("d628f5fc-5d3a-4c9f-a78d-2875b261c80a"), "B.09.1", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("2c579c3d-3a33-4b04-b55c-18756f9d6432"), "B.09.10", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("65e2736b-38f4-45fd-93a0-90bbd2665c23"), "B.09.9", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Support activities for other mining and quarrying" },
                    { new Guid("0ca52487-45b8-4707-8133-837c09ebc82a"), "B.09.90", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Support activities for other mining and quarrying" },
                    { new Guid("3ba682ae-77ca-4119-961c-7e682c6032fa"), "C.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of food products" },
                    { new Guid("9a82b411-a2f3-4a6a-90c2-8eb2d9020c47"), "C.10.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("1e6df2c5-7c38-4ae8-a062-f8be317a30ce"), "C.10.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of meat" },
                    { new Guid("0d495e63-9113-4945-b3a1-a6b08c4d8d76"), "C.10.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing and preserving of poultry meat" },
                    { new Guid("fff9740e-335f-4721-9108-726ce9d57ea1"), "B.06", new Guid("830e89f6-b0ba-4cbc-b7cd-7ef43d9a4eeb"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("83212b84-3e64-40db-aece-52b0ea324e28"), "F.43.2", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("62684f91-abbc-44ae-b9b5-0f942022283e"), "C.23.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of refractory products" },
                    { new Guid("7143374b-73db-4726-97e0-55c11bd2e03f"), "C.23.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("00636c43-4b52-4d91-8c55-a5529d57f3e5"), "C.30.92", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("346cec42-d537-4e14-b9c2-8375f8bb5820"), "C.30.99", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("984e4cc8-ab02-4ca3-9c19-2ed78a39539d"), "C.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of furniture" },
                    { new Guid("f9c60356-613f-4c5e-8f6c-eb95df13320d"), "C.31.0", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of furniture" },
                    { new Guid("a9b65f00-227e-4b9b-b701-30d8c9d7af4b"), "C.31.01", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of office and shop furniture" },
                    { new Guid("94593e23-272e-4a50-a21c-b6d77fecf256"), "C.31.02", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of kitchen furniture" },
                    { new Guid("b49fff47-6a70-4a98-b632-c8e91f44a156"), "C.31.03", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of mattresses" },
                    { new Guid("edc8e8cd-d696-42d5-9ce4-2bc4a39f1600"), "C.31.09", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other furniture" },
                    { new Guid("f0a29848-d6b6-4437-9853-0999fe3f385d"), "C.32", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Other manufacturing" },
                    { new Guid("0c4d5afb-3429-4270-9a0b-575c55fcfbe4"), "C.32.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("eac7ab8a-dd2e-46c8-bc13-1c6ebfcc759b"), "C.32.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Striking of coins" },
                    { new Guid("97a20da6-6809-43d5-8230-f4d06517bddb"), "C.32.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of jewellery and related articles" },
                    { new Guid("57ca5a8d-0f91-4218-b927-ee791ee42a0a"), "C.30.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of motorcycles" },
                    { new Guid("0bd7f925-c283-4e10-87fc-0bc6aa7e6d32"), "C.32.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("e1145f17-d57d-4a98-a229-e83599f82088"), "C.32.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of musical instruments" },
                    { new Guid("781dedbb-d24c-4b41-8d08-9f37ff302c37"), "C.32.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of sports goods" },
                    { new Guid("e7b09731-d5d1-4a87-8c7c-e1bc522752bd"), "C.32.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of sports goods" },
                    { new Guid("7eab5f39-746d-47ce-9565-b6bec5ba133d"), "C.32.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of games and toys" },
                    { new Guid("a62ddb39-ff22-48af-980e-f69260351428"), "C.32.40", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of games and toys" },
                    { new Guid("c5ceb320-45e9-4b76-84c6-9e3f5a6fc4a1"), "C.32.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("df5dd493-fd8e-4fe9-8df5-01dea780dd77"), "C.32.50", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("3d36a39b-6a22-45ad-8862-30f3584f4b98"), "C.32.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacturing n.e.c." },
                    { new Guid("60a7af8c-4a43-4327-b5f6-ae6ff7fafaf4"), "C.32.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("eb14db6f-d116-4eab-acfb-58a5c8c3e3a5"), "C.32.99", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Other manufacturing n.e.c." },
                    { new Guid("c5557d9a-fe14-4da5-b450-8ac87ed9f64a"), "C.33", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair and installation of machinery and equipment" },
                    { new Guid("157e2ac9-6f42-4937-91ae-fcb4ad6968a5"), "C.33.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("6c70d0b2-9040-4c6a-8bc3-9a93ef9a8aa3"), "C.32.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of musical instruments" },
                    { new Guid("59b1bcea-d6bb-401d-8986-359ae117ac10"), "C.30.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("335c3de4-beec-44e0-916c-ee05217e2922"), "C.30.40", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of military fighting vehicles" },
                    { new Guid("064bbbcf-ac3e-460b-b510-e132bf29c2c7"), "C.30.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of military fighting vehicles" },
                    { new Guid("b76f0adc-bef6-4bab-9a8e-fc097fca37c0"), "C.28.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("63eb8b2c-5fba-4bd3-a23c-a5c91690e6de"), "C.28.41", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of metal forming machinery" },
                    { new Guid("088cdbd3-48db-477e-9988-f0d05ccd4759"), "C.28.49", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other machine tools" },
                    { new Guid("cb8223c7-6a3e-4428-89c2-72e748d9d5b6"), "C.28.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other special-purpose machinery" },
                    { new Guid("13edb5ea-cf2e-4b64-8b5d-a30ac01da6fd"), "C.28.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of machinery for metallurgy" },
                    { new Guid("7a867dd1-fcbc-4ed7-b2f4-a50f6f5fbf67"), "C.28.92", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("8f48724d-3940-4d45-89f4-3714c8f7b10d"), "C.28.93", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("c2112baa-f9e2-4186-8391-e245900896e9"), "C.28.94", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("9b2e8622-9405-40cb-8361-479aafc9544a"), "C.28.95", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("0e9ef0f6-5c6b-4af9-b8fa-a4ebcadf6716"), "C.28.96", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("6a2a4bae-5c12-4235-aedf-cee4868ab6d4"), "C.28.99", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("36a6488a-4719-4eac-aa88-bb2f30398660"), "C.29", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("1d287d5f-2629-463a-a1f2-44c870dc4603"), "C.29.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of motor vehicles" },
                    { new Guid("7fa9f559-d249-498a-a8e8-7592b6cb956a"), "C.29.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of motor vehicles" },
                    { new Guid("464f2019-0036-4332-b9d8-5dccd66a56b5"), "C.29.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("2ee1e2e3-bfb3-45fc-88a0-2d5b38968855"), "C.29.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("1ca510f5-77cb-4745-82b6-fe6764bc6e9d"), "C.29.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("99a6ac62-b892-49ad-a7a0-85c16d0eb74e"), "C.29.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("2212c844-dab6-46b8-9f5b-a1272839b97e"), "C.29.32", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("0ff93f1d-75b3-4de4-9804-fb886e7d10e9"), "C.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other transport equipment" },
                    { new Guid("07fcc6f5-8652-4e4b-8127-92ee56f98f3e"), "C.30.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Building of ships and boats" },
                    { new Guid("ea5bf83d-bcb4-4fb6-bc68-faea4be1f9df"), "C.30.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Building of ships and floating structures" },
                    { new Guid("59f4fbd3-b46d-4dde-b5f5-d9b547d57c92"), "C.30.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Building of pleasure and sporting boats" },
                    { new Guid("b43b823c-0610-4873-9a53-fa4a398189f5"), "C.30.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("b6ea8a23-b690-4a5c-b178-5ccd03658054"), "C.30.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("408dd3e3-f270-4b8a-8b31-af3100f5903a"), "C.30.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("a907b740-1e94-423c-927a-5aa409623811"), "C.30.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("7ca46d41-6534-40e5-be56-97706864314f"), "C.33.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair of fabricated metal products" },
                    { new Guid("8daf7ab5-c397-489d-9976-c8efa03bd602"), "C.28.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("22dc9111-db84-4c70-8ad0-2eeed133f3d9"), "C.33.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair of machinery" },
                    { new Guid("6e9fc4ff-2f36-40eb-96c7-dc6fe6ad8934"), "C.33.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair of electrical equipment" },
                    { new Guid("0f0d0ab9-a685-44a4-8990-f341daf1335a"), "E.38.3", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Materials recovery" },
                    { new Guid("78b8dbb8-b7ee-4af5-a251-45d1431dec5e"), "E.38.31", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Dismantling of wrecks" },
                    { new Guid("6db702b8-a996-42dd-90cd-cd353e9344aa"), "E.38.32", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Recovery of sorted materials" },
                    { new Guid("a9500fc1-25b1-49a6-8855-8e6c944e67cb"), "E.39", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1adf1eb3-9038-4a51-92e2-dd55c8f6a0ee"), "E.39.0", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Remediation activities and other waste management services" },
                    { new Guid("36b66ff0-3438-428b-89f2-4805280d90da"), "E.39.00", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Remediation activities and other waste management services" },
                    { new Guid("f87f2285-784e-4477-98fa-a2a489629bf9"), "F.41", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of buildings" },
                    { new Guid("d69e52b6-6262-4491-bde2-d8ae091bf431"), "F.41.1", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Development of building projects" },
                    { new Guid("c1cc397d-049a-459f-8502-48f3479d7ed7"), "F.41.10", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Development of building projects" },
                    { new Guid("de3e9d5c-a8d1-4f34-bec9-9540e3ea17e9"), "F.41.2", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of residential and non-residential buildings" },
                    { new Guid("078c18ed-0e6d-4f74-b212-d05e1a7637fd"), "F.41.20", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of residential and non-residential buildings" },
                    { new Guid("31f35006-bcd0-44bd-83fb-3d5f1a65f44a"), "F.42", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Civil engineering" },
                    { new Guid("1df53c8b-e15f-4957-82ac-c1281f702e49"), "E.38.22", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Treatment and disposal of hazardous waste" },
                    { new Guid("e86a8f70-df56-4cb8-a2b2-821b1ad8c6e6"), "F.42.1", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of roads and railways" },
                    { new Guid("cc4deca7-63de-4d5b-a6ce-96708d9b4d4d"), "F.42.12", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of railways and underground railways" },
                    { new Guid("6ad2ca69-9be8-49e7-a5ed-4f7ef6d5c1a8"), "F.42.13", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of bridges and tunnels" },
                    { new Guid("b0c861b7-5349-4819-8ac5-4eeaaca84d5d"), "F.42.2", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of utility projects" },
                    { new Guid("ab13221c-a0cb-4c38-9064-60524ab8ba94"), "F.42.21", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of utility projects for fluids" },
                    { new Guid("bf123c66-0d46-4e2f-9b7a-c8de268cc076"), "F.42.22", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("9ae21e9b-f4d9-40ba-96cf-5a7ccf474a02"), "F.42.9", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of other civil engineering projects" },
                    { new Guid("715bf9c2-ea0b-466d-abd7-39363ec639e3"), "F.42.91", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of water projects" },
                    { new Guid("e07406cf-7e50-4de4-ad7a-a10c966684cb"), "F.42.99", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("f2ad0d24-c5be-4486-a870-a76cae739e46"), "F.43", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Specialised construction activities" },
                    { new Guid("35144654-bfb9-48de-a67c-b5d41d22c922"), "F.43.1", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Demolition and site preparation" },
                    { new Guid("b38463d3-9220-44bf-a1af-a427d9ed2829"), "F.43.11", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Demolition" },
                    { new Guid("dc4a7209-e182-42c2-bf5f-4df0583ea59b"), "F.43.12", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Site preparation" },
                    { new Guid("e55a36f5-5315-4969-a67a-0ffc90736503"), "F.42.11", new Guid("3474aa89-653f-4f11-b1ff-401ab4907066"), "Construction of roads and motorways" },
                    { new Guid("03ae3181-8320-4ec4-860e-edebaf78570c"), "E.38.21", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("5194ed27-46a7-40d8-9a86-89c2429ee106"), "E.38.2", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Waste treatment and disposal" },
                    { new Guid("9c9481d6-f50a-4880-9d47-b5eee51262c9"), "E.38.12", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Collection of hazardous waste" },
                    { new Guid("73514c8d-20e2-4080-a7cd-1f692539d01e"), "C.33.15", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair and maintenance of ships and boats" },
                    { new Guid("150f73e8-5174-4907-b90e-2d6b8b5e81b2"), "C.33.16", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("079e0daf-e449-4008-87cb-9f243cd51310"), "C.33.17", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair and maintenance of other transport equipment" },
                    { new Guid("c31c9073-1659-4a37-894f-92516298b9e9"), "C.33.19", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair of other equipment" },
                    { new Guid("a4c5a737-3eee-4cbc-a5dd-29f1cc31034c"), "C.33.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Installation of industrial machinery and equipment" },
                    { new Guid("9ca55f93-c449-42fa-bde8-75a97f0c2493"), "C.33.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Installation of industrial machinery and equipment" },
                    { new Guid("b9df769e-2e14-4efd-a5fb-b00d120c6979"), "D.35", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("835dfe04-faa4-46ab-a04c-ed066cea2119"), "D.35.1", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Electric power generation, transmission and distribution" },
                    { new Guid("fb874b76-ce5b-4312-8f7a-59810136811b"), "D.35.11", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Production of electricity" },
                    { new Guid("b4634457-d9c4-4583-bbd9-0698ef97d17a"), "D.35.12", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Transmission of electricity" },
                    { new Guid("f001579d-bcfd-426e-9a23-b83ec734891a"), "D.35.13", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Distribution of electricity" },
                    { new Guid("d40c3d80-d46b-411f-ae04-14f2f0d37403"), "D.35.14", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Trade of electricity" },
                    { new Guid("2018c16d-0bd6-4eb3-9967-90dc6b70f7a5"), "D.35.2", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("b8dc5de0-df03-4c8d-a9a4-1ba70f733598"), "D.35.21", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Manufacture of gas" },
                    { new Guid("b7220b89-2d10-487b-a6bd-c73aeafbfbb2"), "D.35.22", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Distribution of gaseous fuels through mains" },
                    { new Guid("8cfef00d-d3b9-48ca-8706-cdb0b88c9cf4"), "D.35.23", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0cdf7ad6-a15b-434e-ae3d-478f7e2a65df"), "D.35.3", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Steam and air conditioning supply" },
                    { new Guid("34733c3f-41b9-45f7-82d5-4bf86b74c7e2"), "D.35.30", new Guid("3228e773-7866-4b77-aa78-f6b043086335"), "Steam and air conditioning supply" },
                    { new Guid("d295a369-1024-4e04-875b-387288e07f1c"), "E.36", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Water collection, treatment and supply" },
                    { new Guid("e888e93e-9825-496e-8d89-be02ffa504f6"), "E.36.0", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Water collection, treatment and supply" },
                    { new Guid("6a49a24a-7377-45b4-90ec-3495280a87d8"), "E.36.00", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Water collection, treatment and supply" },
                    { new Guid("fdb5c725-2644-446f-be81-9b02ff783def"), "E.37", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Sewerage" },
                    { new Guid("59bbd8e9-bb5d-4ee2-9487-c81632b90f94"), "E.37.0", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Sewerage" },
                    { new Guid("ca1a4a80-ae55-402b-8622-8afee96936a8"), "E.37.00", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Sewerage" },
                    { new Guid("558b0390-ff93-4473-943f-472926d24487"), "E.38", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("0126cc3b-bf17-4160-abc8-ccfc7302b58a"), "E.38.1", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Waste collection" },
                    { new Guid("a44b1c72-b379-494d-9703-e12a839ea94d"), "E.38.11", new Guid("06986339-d221-4ae6-84c9-bb2b03d7d703"), "Collection of non-hazardous waste" },
                    { new Guid("451eaf88-f6ce-4ebf-926e-612b9e8d292b"), "C.33.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Repair of electronic and optical equipment" },
                    { new Guid("223eeaa3-91e1-4603-a031-a459202a35bc"), "C.23.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of clay building materials" },
                    { new Guid("bc9badf3-86c3-4e5b-8251-4ce52bea5c2f"), "C.28.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("71f612b0-fc59-4f48-a044-8bf85511deef"), "C.28.25", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("87d0f2ad-b843-4f30-ac04-1b0d182993da"), "C.24.34", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Cold drawing of wire" },
                    { new Guid("0e2dbc06-aef7-4761-b3d7-a3af07d0ca4b"), "C.24.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("82f7bb80-712e-4c97-a987-0b9d4d9edde1"), "C.24.41", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Precious metals production" },
                    { new Guid("76040f97-caa5-40dc-8a59-4d689b369292"), "C.24.42", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Aluminium production" },
                    { new Guid("f31cd5a6-2dc7-4618-88d7-86ce81f21b18"), "C.24.43", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Lead, zinc and tin production" },
                    { new Guid("ffd07a63-eb6a-4f62-9f46-81a0d1c0b48b"), "C.24.44", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Copper production" },
                    { new Guid("b2f92003-b8d1-4c36-8bc9-9f2e9332cad3"), "C.24.45", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Other non-ferrous metal production" },
                    { new Guid("7adec774-0c9d-49d2-8293-a203c3434359"), "C.24.46", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Processing of nuclear fuel" },
                    { new Guid("24e9b066-aaaa-440b-aec8-a8b4953d992a"), "C.24.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Casting of metals" },
                    { new Guid("4f7cd836-38b2-4db5-8614-e878b114a484"), "C.24.51", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Casting of iron" },
                    { new Guid("2de0482f-350d-440e-9524-2e52da25ae8d"), "C.24.52", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Casting of steel" },
                    { new Guid("d1ddf5e2-dd03-480e-bfb1-c00efc74d27d"), "C.24.53", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Casting of light metals" },
                    { new Guid("d19e49e6-d58d-4b68-803b-e7b879a72f5a"), "C.24.33", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Cold forming or folding" },
                    { new Guid("19302ec7-e474-4f66-8c36-36d857453a6b"), "C.24.54", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Casting of other non-ferrous metals" },
                    { new Guid("8c70ee74-7e67-4259-b04a-df5b50e12011"), "C.25.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of structural metal products" },
                    { new Guid("a35094bb-dc9f-4f56-8ec6-b25bebce7fe8"), "C.25.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("1f5ca5c6-0c14-424c-8f20-e68b23b72774"), "C.25.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of doors and windows of metal" },
                    { new Guid("a9c01ab2-00b0-4aee-afdc-c3e5d1c0c7b3"), "C.25.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("400d8347-6f0b-4558-a9d7-a4c0b18e19ba"), "C.25.21", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("3db76307-5bdc-40e4-9736-125f42c4fa51"), "C.25.29", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("2256faaa-c218-4314-8ad7-834c279837f3"), "C.25.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("79b3f0fd-869a-4ffc-8c3d-0cba7b79598d"), "C.25.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("0964a94f-1be2-44ad-b46a-3f706a06df40"), "C.25.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of weapons and ammunition" },
                    { new Guid("a0471773-b15a-4887-b5e3-2a907f67023d"), "C.25.40", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of weapons and ammunition" },
                    { new Guid("5ad61a95-a54b-4750-b961-d9b43d970f30"), "C.25.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("a998be2b-fa7c-47d1-99ed-7d90dc578de4"), "C.25.50", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("d6c1003b-9495-4f92-b32c-55e06a1dc788"), "C.25", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4a610476-d8f6-450c-a095-bc20490a5ef3"), "C.24.32", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Cold rolling of narrow strip" },
                    { new Guid("97d07d61-c5b9-4145-bc4c-d7998f0619f8"), "C.24.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Cold drawing of bars" },
                    { new Guid("3c2c0242-1208-4096-a18b-a7a00471e57c"), "C.24.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other products of first processing of steel" },
                    { new Guid("0b582ff5-a274-47d3-bf20-7724db7149c6"), "C.23.32", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("6e852433-7a7a-460c-87e9-db3723bdadbf"), "C.23.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("7e61f286-62d7-4b53-89c5-bcdb19beacfa"), "C.23.41", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("d45bc4cb-b5a0-4129-b4f9-e8d18077030e"), "C.23.42", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("ec37f5eb-667d-4c3d-9623-39cafa491038"), "C.23.43", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("30cfef0d-0194-499f-bd65-39e67cfb53df"), "C.23.44", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other technical ceramic products" },
                    { new Guid("a48507ad-f4d2-4bff-bdda-da7f55c3807a"), "C.23.49", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other ceramic products" },
                    { new Guid("fe3324ec-3ef5-4045-953a-32b51c1acfa3"), "C.23.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cement, lime and plaster" },
                    { new Guid("3a50f6c0-eb5c-42ee-86e7-4f2dc5802da8"), "C.23.51", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cement" },
                    { new Guid("a0b916f1-47dd-40b0-9475-f98bb7b297a3"), "C.23.52", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of lime and plaster" },
                    { new Guid("1dcb394f-1a41-4ced-ab43-6084c529bc41"), "C.23.6", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("f37c7eec-c318-4b34-8200-861c07b3d0fc"), "C.23.61", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("cf9e3829-1737-49b2-8363-8c1f8cc39539"), "C.23.62", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("e4ef1a10-de79-4e67-8f5b-b1461b092d47"), "C.23.63", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ready-mixed concrete" },
                    { new Guid("c659c2d2-5fe4-4673-9333-02c48fe632e6"), "C.23.64", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of mortars" },
                    { new Guid("5ed70d28-6170-4781-a202-a854ec4a026f"), "C.23.65", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fibre cement" },
                    { new Guid("61e6143a-9b08-4e77-b245-9999f171d962"), "C.23.69", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("6163119a-23de-48f6-b118-5e232dd133de"), "C.23.7", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Cutting, shaping and finishing of stone" },
                    { new Guid("085c487b-301a-4c97-a4b2-47271431f247"), "C.23.70", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Cutting, shaping and finishing of stone" },
                    { new Guid("6ac130db-7509-48ee-9fd8-42518ee6dbed"), "C.23.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("df78fe69-07c3-4107-babb-0c59ab8516a9"), "C.23.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Production of abrasive products" },
                    { new Guid("f3e6d718-a017-47db-9f2c-1b2fe8dcc95e"), "C.23.99", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("1737a8c9-f215-4024-9fc0-b41458ba4cb7"), "C.24", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic metals" },
                    { new Guid("18e9cd53-6467-462a-a5fe-69b00fb3e07e"), "C.24.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("3b5cf102-cd94-45c2-ab28-36115e7b4b81"), "C.24.10", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("740dc432-abc4-4b08-b5ae-853a50008bda"), "C.24.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("a08f0412-2657-446a-a36c-0788f4daddf3"), "C.24.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("3b1d4433-f244-417a-ab0f-e1d8293199b8"), "C.25.6", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Treatment and coating of metals; machining" },
                    { new Guid("7c29dd66-e0bb-4266-a28e-cc6ce935694e"), "C.28.29", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("397b15a4-b567-4c58-a7e0-f10a08a5523e"), "C.25.61", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Treatment and coating of metals" },
                    { new Guid("6806fd10-140d-4e1f-8323-e16da8c99342"), "C.25.7", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("368e7a9a-f4df-449d-8c19-5c7f320b6a2f"), "C.27.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("072beb99-71fb-4199-847f-321e4c820222"), "C.27.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of batteries and accumulators" },
                    { new Guid("3aaca3cd-87ec-4556-acc5-0f48043ef213"), "C.27.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of batteries and accumulators" },
                    { new Guid("8cd50155-b48e-4ed3-9cae-466de54e2d44"), "C.27.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wiring and wiring devices" },
                    { new Guid("06a85ede-ef9a-423a-89b8-5913ea52b3d2"), "C.27.31", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fibre optic cables" },
                    { new Guid("dae327be-005c-487b-8a95-93d9a19199e2"), "C.27.32", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("5a07373b-c022-4bff-805e-fa6115e502f0"), "C.27.33", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wiring devices" },
                    { new Guid("0d35aade-b715-44d8-8981-67c8ce7d7cc4"), "C.27.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4c241ca8-e569-4891-8df1-89a2e18b0c34"), "C.27.40", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electric lighting equipment" },
                    { new Guid("15bda167-7a46-4fe8-9654-7a67e70ab5cb"), "C.27.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of domestic appliances" },
                    { new Guid("bf5ea57a-cb95-44c4-b28c-17d91c2cae67"), "C.27.51", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electric domestic appliances" },
                    { new Guid("cf9b4182-0bf0-4d84-a5d1-7f574599feb6"), "C.27.52", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("12e58e3b-d268-4f48-a5fb-65a61b122308"), "C.27.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("127771b5-b008-4bc3-a0a8-5f0eb8104a3b"), "C.27.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other electrical equipment" },
                    { new Guid("48125e7e-b1dd-40e3-9747-799dcac8b587"), "C.28", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("06b979e2-9b4d-42cb-8eed-5ec27481cd92"), "C.28.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of general-purpose machinery" },
                    { new Guid("461d5075-eff2-4797-88ae-8925af7dbbbe"), "C.28.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("e06e8c1c-e160-4013-81ba-badc6ba31ec4"), "C.28.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fluid power equipment" },
                    { new Guid("62143302-44bc-4666-9d8f-fc0f12f1787e"), "C.28.13", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other pumps and compressors" },
                    { new Guid("ba9b2129-d655-445a-92f2-98d585630808"), "C.28.14", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other taps and valves" },
                    { new Guid("f15102d7-8c08-4a2c-aa3b-a8e1c79edbfd"), "C.28.15", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("db4a9215-27a9-42bf-a942-969a35ece102"), "C.28.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other general-purpose machinery" },
                    { new Guid("f0a153a9-153b-41a3-b911-e997b69caba3"), "C.28.21", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("4885c715-130c-44cb-859d-4f8ab302c6d2"), "C.28.22", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of lifting and handling equipment" },
                    { new Guid("1455312b-0b49-4624-9f89-b584eb1d836a"), "C.28.23", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("7f8347c7-8284-445f-bcd4-f5b7d9488064"), "C.28.24", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of power-driven hand tools" },
                    { new Guid("fabd41c7-eb17-4305-8341-be3c1dac97fb"), "C.27.90", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other electrical equipment" },
                    { new Guid("0744545a-211a-4833-9006-1b4adfd44da0"), "C.27.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("055f552a-ca11-4391-85cd-c463fdec3d95"), "C.27", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electrical equipment" },
                    { new Guid("13b15911-269b-4c51-998e-c4c42c06df40"), "C.26.80", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of magnetic and optical media" },
                    { new Guid("3d358c79-a35f-45b3-bf7a-0e2f45bfaea0"), "C.25.71", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of cutlery" },
                    { new Guid("4bbc716f-dc0e-406a-819a-f7f875618292"), "C.25.72", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of locks and hinges" },
                    { new Guid("1933ef5a-3691-4e69-a120-29811404e526"), "C.25.73", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of tools" },
                    { new Guid("4a98a8d7-1cb0-470a-bdd3-fc669d4e5049"), "C.25.9", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other fabricated metal products" },
                    { new Guid("4c2cd02f-74d0-4e97-b948-90fb724eb282"), "C.25.91", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of steel drums and similar containers" },
                    { new Guid("7b77d3d5-1b81-48ab-a3ca-9b7c29a97076"), "C.25.92", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of light metal packaging" },
                    { new Guid("ddf3bbbf-0edc-4666-8a2e-21ee6349f096"), "C.25.93", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of wire products, chain and springs" },
                    { new Guid("e09425f3-7e05-413f-bf18-6be43b718819"), "C.25.94", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("a463ba06-92c4-4273-8f6e-35eddb875a33"), "C.25.99", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("e4bdb33c-8922-41bb-93fd-cff2ab061505"), "C.26", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("625b9f04-58d8-4034-a0cc-bcd2c1ab68c3"), "C.26.1", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electronic components and boards" },
                    { new Guid("d1b45828-a0f5-4771-b675-b741c596a586"), "C.26.11", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of electronic components" },
                    { new Guid("cf553f6e-de21-4c2f-939b-eb5a342246f0"), "C.26.12", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of loaded electronic boards" },
                    { new Guid("b595fbc1-625a-4abb-9ea0-91ec33a73efa"), "C.26.2", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("03894df7-2fce-46b9-8320-1b194cecc744"), "C.26.20", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("4d0b697f-533c-4819-b487-a6accdf1da63"), "C.26.3", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of communication equipment" },
                    { new Guid("153cc24b-da42-41e5-b679-7733736b7655"), "C.26.30", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of communication equipment" },
                    { new Guid("48d11ddd-1ac9-4c64-81cf-129a8680cc77"), "C.26.4", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of consumer electronics" },
                    { new Guid("f7d74f7f-2f32-46c2-ad46-fea9f8964864"), "C.26.40", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of consumer electronics" },
                    { new Guid("3d110d17-20b4-42c2-8640-40fdc5f5695d"), "C.26.5", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("78e57512-a129-4d7e-94bb-8ffa967fdc49"), "C.26.51", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("d955124a-4181-44c3-b6df-04173fd9c459"), "C.26.52", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of watches and clocks" },
                    { new Guid("042beef9-b3b1-4ce1-94fd-1c7cae44b19b"), "C.26.6", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("5e842634-6dee-4272-90ad-2672fef48380"), "C.26.60", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("c16190d0-930c-4474-8c68-6348d9524a6d"), "C.26.7", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("18472a6d-054c-4c7d-add6-2c7f99c4b863"), "C.26.70", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("35f89936-9e03-43bf-b09f-07003201a802"), "C.26.8", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Manufacture of magnetic and optical media" },
                    { new Guid("58ae76be-fe69-4b03-b94c-7bb9121ce02d"), "C.25.62", new Guid("c69cb50b-abd6-4244-a1b9-373a74cd5809"), "Machining" },
                    { new Guid("656478e0-d40b-4cd9-b47e-508b3a387524"), "U.99.00", new Guid("c128e241-6aa3-4c82-b8ed-bb6932f96cf6"), "Activities of extraterritorial organisations and bodies" }
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
