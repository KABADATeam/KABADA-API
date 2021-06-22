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
                    IsPartnersCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("f33c9cf7-fbe4-42ea-864a-dc787f54be1c"), "AT", "Austria" },
                    { new Guid("231bf77b-94fe-4441-a93d-852e04460fbe"), "LU", "Luxembourg" },
                    { new Guid("d762db47-16e0-4da6-81ee-17cb5c828203"), "MT", "Malta" },
                    { new Guid("3530dd06-2c14-4ed7-9728-ba2b8e2f563c"), "MK", "North Macedonia" },
                    { new Guid("9891d09a-c794-4f31-8af6-772932bbc1bd"), "NO", "Norway" },
                    { new Guid("f56ee4b8-a8a7-4e41-8dd5-461c14422a84"), "PL", "Poland" },
                    { new Guid("b2c1c0fc-f079-4510-8d28-ac0a5e7a28df"), "PT", "Portugal" },
                    { new Guid("4772a26b-941f-42a3-819b-ee4db186b4ff"), "RO", "Romania" },
                    { new Guid("10a1d8c6-e8cf-4f30-8b4a-f25c8564c4ed"), "RS", "Serbia" },
                    { new Guid("18c12ca5-54f5-4d48-8f9e-bfb1b4fd6884"), "SK", "Slovakia" },
                    { new Guid("4ec9d189-6a3b-4141-b4e4-0360105a3986"), "SI", "Slovenia" },
                    { new Guid("5709aa53-1d04-449c-ba5e-0b2f13fa35e8"), "ES", "Spain" },
                    { new Guid("dd4eb0a7-64e1-41ca-92a6-c9d8402c2bc1"), "SE", "Sweden" },
                    { new Guid("d345d460-ae98-4873-8fad-d2367ec95a70"), "CH", "Switzerland" },
                    { new Guid("0128c7db-a4c4-44ad-bda0-1f775fc81d2f"), "TR", "Turkey" },
                    { new Guid("1cdde9b8-f0ba-4843-bc0e-1f51749dfbcc"), "UK", "United Kingdom" },
                    { new Guid("dbcc71b2-f4b8-4b52-838e-006fcec8c838"), "LT", "Lithuania" },
                    { new Guid("c811ba06-f49b-4b05-bcd6-38264ecd5a3c"), "LI", "Liechtenstein" },
                    { new Guid("4112fe37-8243-44ef-acb8-acbc5ffc3d68"), "NL", "Netherlands" },
                    { new Guid("91955988-4e08-464b-91c0-17c10a50dc8b"), "IT", "Italy" },
                    { new Guid("5e8d7c77-a092-4cb8-a230-d8b63eea2daa"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("a1eabfc7-3d48-4a7e-b5a5-0143b7e27448"), "BE", "Belgium" },
                    { new Guid("6736fd95-b1a4-4334-ae80-791f47c87325"), "BG", "Bulgaria" },
                    { new Guid("3332e187-9f54-4384-aa60-3b907f1107fa"), "LV", "Latvia" },
                    { new Guid("bf5f2b06-a094-47df-abac-d418c9098679"), "CY", "Cyprus" },
                    { new Guid("dbc7d213-eedd-41dc-a82f-efcde230872b"), "CZ", "Czechia" },
                    { new Guid("72ea16ed-f1e2-4dcc-b1a6-8d8661190285"), "DK", "Denmark" },
                    { new Guid("1249fa96-43b3-4c56-ab8b-06efcd3331bc"), "EE", "Estonia" },
                    { new Guid("30952c8c-f1cb-4b62-8603-f51105014e74"), "HR", "Croatia" },
                    { new Guid("1d2dde51-4c96-4116-9059-e9cb7a23875b"), "FR", "France" },
                    { new Guid("d20ad1ec-266d-4696-bfd9-37f2203d9615"), "DE", "Germany" },
                    { new Guid("a8555f9b-2e41-4512-9e68-3073caaab7e8"), "EL", "Greece" },
                    { new Guid("f767d508-8d61-4f6e-99f8-49013058b73f"), "HU", "Hungary" },
                    { new Guid("493e43a5-bc46-4085-9adf-68388823c2f1"), "IS", "Iceland" },
                    { new Guid("ab235aec-0cd6-49e2-a744-b8ccb775a606"), "IE", "Ireland" },
                    { new Guid("d0d5389e-0b1e-4519-af06-852e021f5299"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "P", "EN", "Education" },
                    { new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("74d43747-70c9-41e3-b67a-9e1e7eebbaf1"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "L", "EN", "Real estate activities" },
                    { new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "H", "EN", "Transporting and storage" },
                    { new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "F", "EN", "Construction" },
                    { new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "J", "EN", "Information and communication" },
                    { new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "C", "EN", "Manufacturing" },
                    { new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "B", "EN", "Mining and quarrying" },
                    { new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "A", "EN", "Agriculture, forestry and fishing" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("335108b4-2667-4a32-9d70-c73c32dcbc0f"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("825c3af2-b8fc-4b51-89df-2c5ec8d2c893"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4650c2ca-74e3-432d-80cd-4168d80a73a8"), (short)2, "Frequency" },
                    { new Guid("62a7b829-43ab-4f78-8ec2-da145f8e5d11"), (short)6, null, new Guid("b3edf4ee-f7e0-42d0-8527-80732c837c1d"), (short)2, "Administrative" },
                    { new Guid("7cba09d2-cb23-441d-a3a5-1580cc694845"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("4650c2ca-74e3-432d-80cd-4168d80a73a8"), (short)1, "Ownership type" },
                    { new Guid("4650c2ca-74e3-432d-80cd-4168d80a73a8"), (short)6, null, new Guid("b3edf4ee-f7e0-42d0-8527-80732c837c1d"), (short)1, "Specialists & Know-how" },
                    { new Guid("b3edf4ee-f7e0-42d0-8527-80732c837c1d"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("fb4aa7db-76f2-47fe-9682-3a77918d84de"), (short)6, null, new Guid("f507fb2a-887a-4153-8c94-963961e676d2"), (short)4, "Other" },
                    { new Guid("483606a5-86da-4e5f-9b91-f941116bccce"), (short)6, null, new Guid("f507fb2a-887a-4153-8c94-963961e676d2"), (short)3, "Software" },
                    { new Guid("80adcee9-750c-4a1d-8412-1cecb82d67d4"), (short)6, null, new Guid("f507fb2a-887a-4153-8c94-963961e676d2"), (short)2, "Licenses" },
                    { new Guid("f7571148-fdcd-451a-91f9-b717054c785c"), (short)6, null, new Guid("f507fb2a-887a-4153-8c94-963961e676d2"), (short)1, "Brands" },
                    { new Guid("f507fb2a-887a-4153-8c94-963961e676d2"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("7eda062b-5414-424d-ab5e-97b5db2292ff"), (short)6, null, new Guid("739c85a3-aed0-448e-9f48-ec936d8b05c6"), (short)4, "Raw materials" },
                    { new Guid("ffe8af54-fd92-4940-a4eb-7fea23f2a817"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("74a939fe-73b8-4476-9453-d039474d3d7a"), (short)1, "Ownership type" },
                    { new Guid("74a939fe-73b8-4476-9453-d039474d3d7a"), (short)6, null, new Guid("739c85a3-aed0-448e-9f48-ec936d8b05c6"), (short)5, "Other" },
                    { new Guid("4042b640-c3b5-45dc-aeeb-215ebf4bb74f"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("7eda062b-5414-424d-ab5e-97b5db2292ff"), (short)1, "Ownership type" },
                    { new Guid("c196c4d7-dbc3-4521-93ac-bf2e61c1635d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("62a7b829-43ab-4f78-8ec2-da145f8e5d11"), (short)1, "Ownership type" },
                    { new Guid("31da3b40-717a-4248-ab1e-e33fa06b6589"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("50352502-c7e3-4c5a-942d-85b676b11cb6"), (short)2, "Frequency" },
                    { new Guid("e5c4bfa5-e5ac-4a5a-8ab4-753c6d5eef81"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("50352502-c7e3-4c5a-942d-85b676b11cb6"), (short)1, "Ownership type" },
                    { new Guid("50352502-c7e3-4c5a-942d-85b676b11cb6"), (short)6, null, new Guid("739c85a3-aed0-448e-9f48-ec936d8b05c6"), (short)3, "Transport" },
                    { new Guid("5ca0517b-1db4-497d-bf2e-4d4e190e0c16"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4149957c-dc47-483e-835e-aaca51b432ad"), (short)2, "Frequency" },
                    { new Guid("7ede417e-be97-474b-89b2-68d522ac2638"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("4149957c-dc47-483e-835e-aaca51b432ad"), (short)1, "Ownership type" },
                    { new Guid("4149957c-dc47-483e-835e-aaca51b432ad"), (short)6, null, new Guid("739c85a3-aed0-448e-9f48-ec936d8b05c6"), (short)2, "Equipment" },
                    { new Guid("97befb65-05c9-4c7e-a314-d10499135aac"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("74a939fe-73b8-4476-9453-d039474d3d7a"), (short)2, "Frequency" },
                    { new Guid("453b1a31-e37e-4126-b286-241e01e40095"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("62a7b829-43ab-4f78-8ec2-da145f8e5d11"), (short)2, "Frequency" },
                    { new Guid("5c825d7e-95eb-4161-a99f-64e90d087fb9"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d79d1ed7-c521-49c7-8ee0-c72c7c23bbf2"), (short)2, "Frequency" },
                    { new Guid("63a9d789-82bb-4e2a-a6bf-b72b8219bf4c"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("7f507b2a-81ac-445b-94e7-b29fde70dce6"), (short)1, "Ownership type" },
                    { new Guid("f5a8e082-11e5-4471-854d-e8be8d720d3a"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ded087f8-5966-4c48-8248-540136d47c90"), (short)2, "Frequency" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("01f37933-80c0-4a09-a4d6-c9f416b4d7c7"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("69de0b2d-f644-427a-a924-8bd897440604"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("d12fc4c1-bdb2-4f73-b898-e0820763217b"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("36135758-0b3f-4783-b64b-dde487fdb782"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("37e12daf-554b-45ca-9dc6-2ca5043aef1d"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("74f3c2e5-ceaf-4623-9445-e486bd926369"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("ef805d95-5d63-4cbb-8a71-99d15b79e1e0"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("1c9db011-d588-4fd6-98a1-da6313a3f634"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("995966a8-f77f-4e48-874f-f15b856c6441"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("7f507b2a-81ac-445b-94e7-b29fde70dce6"), (short)6, null, new Guid("b3edf4ee-f7e0-42d0-8527-80732c837c1d"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("cbf6631f-b33f-493b-9e9f-0f2b334228a9"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("e4690958-e87f-4deb-8f8a-60a63264714c"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("ef0509e0-e114-4b36-aa0d-749e7c4e8fca"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("21e18aad-a737-4598-b7de-ccf3a4d03e9b"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("c9fe26c3-108c-44b9-ab1c-af1890a8b81d"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("1f3e5788-8cc4-4ff0-b24e-47ffd8ff7439"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("2953e767-e889-4a28-80d5-dc3f2ad2c108"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("094dfc5d-b289-4c6b-853b-ea1e2df16540"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("e15d5e5d-9c86-4f17-9442-03b5d4a7dd76"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("d79d1ed7-c521-49c7-8ee0-c72c7c23bbf2"), (short)1, "Ownership type" },
                    { new Guid("d79d1ed7-c521-49c7-8ee0-c72c7c23bbf2"), (short)6, null, new Guid("b3edf4ee-f7e0-42d0-8527-80732c837c1d"), (short)4, "Other" },
                    { new Guid("9b9e6a28-4419-4a40-b86c-f117f6fa09f0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("7f507b2a-81ac-445b-94e7-b29fde70dce6"), (short)2, "Frequency" },
                    { new Guid("822a264c-a372-419b-aa09-409d2c9f426f"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("419cde40-f020-4c0f-a1de-41ec023dcb7b"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ded087f8-5966-4c48-8248-540136d47c90"), (short)1, "Ownership type" },
                    { new Guid("b4523f2e-7846-449a-abc5-5b1f55722e1f"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("739c85a3-aed0-448e-9f48-ec936d8b05c6"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("6842e580-5063-42bf-b182-4bdc9b1143c5"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("5f125c5a-b4df-45f4-9677-9e18b63fc633"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("2ea9fdb4-7641-4cb8-b2bf-2afe359ecc9e"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("bba60a3b-879d-412c-96d6-a2f5e44887cc"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("aceed3e0-f382-458c-9ea6-24866c9f65b7"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("687961a3-4c4b-40a5-a261-283b4ae3858b"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("57f3e1db-4ed8-475f-b2b3-781f45555cd8"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("16c16d5f-a155-4b54-a5aa-0c5bd56ac886"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("9aa0fcaf-432c-409b-80ab-06b75c3b6cc8"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("be60dfef-8bbb-4006-a1fd-eecc84cee383"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("3d6863a8-81f5-4110-9c7a-630aebcb367e"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("c043d16c-8219-4211-83db-85662b417127"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("b16244d0-17dd-4fb3-bb36-af9b7ae2c9de"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("ef9acdb4-5ee2-49c6-b140-dbc7e442dbfb"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("2bc9ba5b-2ee1-4967-ae4b-4200315ab1be"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("29c0c44c-3dc7-4271-9bf1-94107bb031fb"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("5f6558c3-9287-4bb0-882b-d33ca823fbfe"), (short)1, "a", null, (short)5, "Skills and experience of employees" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("fc22bced-3cfe-473a-8e7d-eab2fb3dc9b8"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("b22068da-803a-4c22-8277-dd594ba1e426"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("a9aaa206-9cee-485b-abf1-5ef08d1925cb"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("ca441913-8ffd-409e-897b-037206165b72"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("425a355c-6067-49ad-b3d6-7d97b21ecb5a"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("ded087f8-5966-4c48-8248-540136d47c90"), (short)6, null, new Guid("739c85a3-aed0-448e-9f48-ec936d8b05c6"), (short)1, "Buildings" },
                    { new Guid("d12658ff-3bdb-42fd-8977-ad062eff0b6a"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("234bf3df-b5d7-4bd7-84d0-0c618e246f5f"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("3c315ad5-e9ac-4cc4-a831-61e7bbfa4c02"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("39943b45-0ff3-4df4-8418-1ed5bb6fa618"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("4dfa4286-ea9c-4566-bef9-6392ab9f4837"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("7ea7efb0-c36b-47b3-9603-11532dc92cd2"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("787ce3b2-104c-41e4-bc58-7b4ce0b4809a"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("84fdd4da-dc32-418d-9ac4-0f814b00db6a"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("79f890c6-000b-475b-aab1-cc52ef7aaf5a"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("2308c3b8-cad3-47d5-9b32-a7f79a8f06ea"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("d4dbbb3b-7337-4f52-ae43-5a681107b362"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("8f4affe8-5c45-48aa-bac6-5c8b8310894a"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("01468001-2d69-432a-b3d8-3b465a6dc0e4"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("9e080616-edde-4668-911d-49dbe9af6b89"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("2c37da3a-4955-4987-be84-c636873592dc"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("19fa365f-bb06-4021-9ae3-ce93f0b16c40"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("88a72d6b-e2e1-42ef-b3d9-c72012ce368c"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("e1269d9e-b807-42d6-a5f5-0e4f03623eac"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("ecfd4d51-70d1-4287-8eb6-454f5e7ff5c8"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("7b341f4d-01bd-4ad7-a586-97cb18700ede"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("4ebd7d00-ba80-43f1-8e7c-80d25c77de3e"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("e8be017e-a331-4782-93f5-00a7be04ff32"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("969c6e5f-c632-4416-90f4-aa7766c70461"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("091d86ed-6b7a-4258-88ba-b0ff2408e258"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("ce5153ac-4071-459b-8836-9db6126285cc"), (short)3, null, null, (short)2, "Government regulation" }
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
                    { new Guid("01b008ea-efa7-4924-b907-13709ecbacd6"), "A.01", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("31a61d64-4a12-4dc3-89df-04452409a9ed"), "H.51.22", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Space transport" },
                    { new Guid("debdbd09-0c9a-46bb-a0a5-5a7b56d98815"), "H.52", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Warehousing and support activities for transportation" },
                    { new Guid("f61ef6db-74ce-47de-b109-b73ac3459aec"), "H.52.1", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Warehousing and storage" },
                    { new Guid("86fc63a9-4c66-45c1-9ef0-b1d7887881a9"), "H.52.10", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Warehousing and storage" },
                    { new Guid("22ec50ad-f1ce-4292-afa5-b35638d5372c"), "H.52.2", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Support activities for transportation" },
                    { new Guid("2c394eff-dcbb-485d-bd35-04bbdc36c5f4"), "H.52.21", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Service activities incidental to land transportation" },
                    { new Guid("301ab597-9797-4cf8-a95b-3372e4318eb1"), "H.52.22", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Service activities incidental to water transportation" },
                    { new Guid("3ca2929e-c3fd-402d-ab31-3a684a667472"), "H.52.23", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Service activities incidental to air transportation" },
                    { new Guid("f1726ca5-683f-4585-9f1b-36f2b6dba481"), "H.52.24", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Cargo handling" },
                    { new Guid("84a6efd0-5e62-4177-bf0a-57820d46e0e9"), "H.52.29", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Other transportation support activities" },
                    { new Guid("c73b6d96-6282-4551-9097-e0d1a0fc1073"), "H.53", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Postal and courier activities" },
                    { new Guid("4828060e-a5df-47d7-b401-e88ff341b364"), "H.53.1", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Postal activities under universal service obligation" },
                    { new Guid("67fd624a-0457-4628-af50-dad89a801e21"), "H.51.21", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Freight air transport" },
                    { new Guid("23621aee-3be2-4593-8b00-1edbe2e630e4"), "H.53.10", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Postal activities under universal service obligation" },
                    { new Guid("f2127031-f313-4cc7-92f7-6dc40789fa45"), "H.53.20", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Other postal and courier activities" },
                    { new Guid("b70f3c76-1aee-477f-b411-e2372785b209"), "I.55", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Accommodation" },
                    { new Guid("221ee540-e10b-4ebd-a1e9-7fd68ace94fc"), "I.55.1", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Hotels and similar accommodation" },
                    { new Guid("fbb3e21b-9e86-41de-afbe-19b715f2454c"), "I.55.10", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Hotels and similar accommodation" },
                    { new Guid("4cf96277-78d6-43ef-b5b6-0b542e9c183a"), "I.55.2", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Holiday and other short-stay accommodation" },
                    { new Guid("18c68c46-1c03-4640-9dba-c914e809829e"), "I.55.20", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Holiday and other short-stay accommodation" },
                    { new Guid("d92bf45a-8799-45b7-9a2a-5c3e17880fdb"), "I.55.3", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("8fcbea25-52be-43e6-84f8-a9f0881ac27a"), "I.55.30", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("685149ce-aa1c-4fbf-a719-ce05dd2b2f63"), "I.55.9", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Other accommodation" },
                    { new Guid("bc582591-940b-4355-9efe-74c282ff64b1"), "I.55.90", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Other accommodation" },
                    { new Guid("0683c73c-5b74-4585-8ba0-18166221c534"), "I.56", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Food and beverage service activities" },
                    { new Guid("92cecf3b-57a3-46e1-a9b8-63385a11ca64"), "I.56.1", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Restaurants and mobile food service activities" },
                    { new Guid("f0962638-d294-4d67-a595-97003ac1d65b"), "H.53.2", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Other postal and courier activities" },
                    { new Guid("73fdffe5-d592-4ad7-991c-f5becba1dd7e"), "H.51.2", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Freight air transport and space transport" },
                    { new Guid("e73ba402-8de1-4aa4-aa8a-49361ea4a985"), "H.51.10", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Passenger air transport" },
                    { new Guid("5acd5c33-b9c9-41c3-b8b3-55889c7e47de"), "H.51.1", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Passenger air transport" },
                    { new Guid("05b33b90-ad64-45ba-a3d8-bf6be8e2a06b"), "G.47.9", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("9193e23a-23c6-4e90-b174-03eb9eea27a6"), "G.47.91", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("fb7ef708-a93b-480c-83e0-77b4d9e381db"), "G.47.99", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("de018e8f-6709-42a2-9977-192d577e73bb"), "H.49", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Land transport and transport via pipelines" },
                    { new Guid("4aaeaae6-60d4-4426-b89a-952eb4ac680a"), "H.49.1", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Passenger rail transport, interurban" },
                    { new Guid("64c20d99-7da4-4723-b4e3-f7c6ada4c00c"), "H.49.10", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Passenger rail transport, interurban" },
                    { new Guid("23ecef38-982c-46a4-83f0-3c27ac9dc776"), "H.49.2", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Freight rail transport" },
                    { new Guid("47fde157-b126-4afa-a79f-23e43c6443ec"), "H.49.20", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Freight rail transport" },
                    { new Guid("ff86ecc6-4869-41a4-8248-9fa9d63135cd"), "H.49.3", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Other passenger land transport" },
                    { new Guid("a5fc83a3-113a-492f-8ddd-3b0cde894ffb"), "H.49.31", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Urban and suburban passenger land transport" },
                    { new Guid("11407043-68ba-4464-b035-a2deeb970aec"), "H.49.32", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4806988c-9381-4611-ba74-b49ad79105d9"), "H.49.39", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Other passenger land transport n.e.c." },
                    { new Guid("9185ba94-7ef3-4670-be23-26b5192ed9a3"), "H.49.4", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Freight transport by road and removal services" },
                    { new Guid("e0163c50-ae66-4f55-8d53-07e4646ddf2e"), "H.49.41", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Freight transport by road" },
                    { new Guid("2138cf76-752b-453b-8e92-17bb27d5a678"), "H.49.42", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Removal services" },
                    { new Guid("33ee660f-1711-47f2-8111-a9daa1d14391"), "H.49.5", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Transport via pipeline" },
                    { new Guid("de1c82e3-a7ad-45cb-8002-52f3a9e84943"), "H.49.50", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Transport via pipeline" },
                    { new Guid("8aa53d6b-c9ba-4bf3-86c5-17526a3d3e7a"), "H.50", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Water transport" },
                    { new Guid("fef9b1e4-defc-4a2e-b66b-1ea6e058e9f7"), "H.50.1", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Sea and coastal passenger water transport" },
                    { new Guid("7816191a-fb52-4d7c-9735-69c9ea3beee6"), "H.50.10", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Sea and coastal passenger water transport" },
                    { new Guid("1ccaf995-9b00-415a-9b7b-84c61464c543"), "H.50.2", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Sea and coastal freight water transport" },
                    { new Guid("ed4bd5da-87ae-4743-8322-4c323a283b46"), "H.50.20", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Sea and coastal freight water transport" },
                    { new Guid("68b48001-5352-4443-abb5-5a6ca595402e"), "H.50.3", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Inland passenger water transport" },
                    { new Guid("c8c9cf30-e000-4cc0-b905-41bcf29ccf18"), "H.50.30", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Inland passenger water transport" },
                    { new Guid("6050098b-86ab-46b1-b429-4f6340631b40"), "H.50.4", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Inland freight water transport" },
                    { new Guid("ecf339cd-4501-4fbf-b1a6-ede99cb262c9"), "H.50.40", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Inland freight water transport" },
                    { new Guid("13824591-69c3-4fa6-9161-8685974f22e6"), "H.51", new Guid("c8a6dd7f-b020-4521-99b3-fea03b5308e0"), "Air transport" },
                    { new Guid("ac9d8c31-018f-4e2b-abf3-6eb59c4e7bea"), "I.56.10", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Restaurants and mobile food service activities" },
                    { new Guid("460bfc75-530c-4729-8bc3-5bb3f82821a5"), "G.47.89", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("cff0fc98-4b9e-4da5-933a-0da595535ef2"), "I.56.2", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Event catering and other food service activities" },
                    { new Guid("8b03639c-932e-4b0b-8f6c-b490341ae74b"), "I.56.29", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Other food service activities" },
                    { new Guid("3c3211ca-cad0-4345-89bc-728a7efe9888"), "J.61.30", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Satellite telecommunications activities" },
                    { new Guid("49c34c80-6565-4837-b2dc-9182bfb35dc5"), "J.61.9", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other telecommunications activities" },
                    { new Guid("f6bde611-adb3-4fe0-8a73-1c5160e64ed3"), "J.61.90", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other telecommunications activities" },
                    { new Guid("b2976ed0-a78e-42b2-8b3f-3cddfdb39c40"), "J.62", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Computer programming, consultancy and related activities" },
                    { new Guid("3e9dba12-e4f1-443b-9f73-6efdc409dca8"), "J.62.0", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Computer programming, consultancy and related activities" },
                    { new Guid("2314cb22-88c0-4a7b-8634-7b56465cf176"), "J.62.01", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Computer programming activities" },
                    { new Guid("6a73d24d-58e9-42c8-b65a-5d4c52cfc856"), "J.62.02", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Computer consultancy activities" },
                    { new Guid("81b253c0-29c3-4ddc-b7a9-dec3417d3ebc"), "J.62.03", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Computer facilities management activities" },
                    { new Guid("b833dcdb-4e2c-4c41-9c3a-e916eaee17ac"), "J.62.09", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other information technology and computer service activities" },
                    { new Guid("43bc3ab3-73d7-4a56-be29-1c98401767cd"), "J.63", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Information service activities" },
                    { new Guid("ee0272a5-9a5a-4192-8663-500943d1f09c"), "J.63.1", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("58fbb711-eaea-45a6-80d4-64dd00b0cde6"), "J.63.11", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Data processing, hosting and related activities" },
                    { new Guid("2b04f53c-0539-4e98-aa26-3f94b326afc1"), "J.61.3", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Satellite telecommunications activities" },
                    { new Guid("cdf2bb3e-9f31-4c0d-a239-8a86b6deca49"), "J.63.12", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Web portals" },
                    { new Guid("04c0acca-2b8e-4d65-bdf7-2b0856c50e76"), "J.63.91", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "News agency activities" },
                    { new Guid("a644da9b-220f-4f13-8453-cc8ea4e79449"), "J.63.99", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other information service activities n.e.c." },
                    { new Guid("8b9daeac-e954-4207-a09f-301b9215bf06"), "K.64", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("e6d18764-c3ba-4267-b413-0641fcaada37"), "K.64.1", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Monetary intermediation" },
                    { new Guid("5441d16e-95db-435a-85d7-1458dc585f0c"), "K.64.11", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Central banking" },
                    { new Guid("98777f54-94b8-4ff2-8608-3dc68708a7a0"), "K.64.19", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Other monetary intermediation" },
                    { new Guid("22844fb9-29df-4b8a-82f9-054a3fabd6f3"), "K.64.2", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Activities of holding companies" },
                    { new Guid("3bf9ff1a-8401-49c5-b49f-1a7f044247d1"), "K.64.20", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("437164b7-0dd6-48b6-985b-1381bfef8eb5"), "K.64.3", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Trusts, funds and similar financial entities" },
                    { new Guid("08650cdd-a7f2-4b1e-ad67-c72eec88eb9d"), "K.64.30", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Trusts, funds and similar financial entities" },
                    { new Guid("ee42113a-38f4-416b-868f-a0eddd47e371"), "K.64.9", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("e22b8b67-418a-467f-b832-4bfad68afe15"), "K.64.91", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Financial leasing" },
                    { new Guid("1c7dea89-39ac-41b0-b9bd-74ab1b7fbb2f"), "J.63.9", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other information service activities" },
                    { new Guid("56a8d038-529b-4089-bd71-42414f9475e0"), "J.61.20", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Wireless telecommunications activities" },
                    { new Guid("69c3d84d-9c44-4529-8a13-37d35b090f9f"), "J.61.2", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Wireless telecommunications activities" },
                    { new Guid("f488888c-02ed-41c4-9c31-bc150bc811d7"), "J.61.10", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Wired telecommunications activities" },
                    { new Guid("617da4d9-175f-43b2-82a1-667144336f38"), "I.56.3", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Beverage serving activities" },
                    { new Guid("53767db8-f1b6-4f0f-9a91-1b5211ed24b0"), "I.56.30", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Beverage serving activities" },
                    { new Guid("16a2045d-666e-45bc-acaa-d1bf98232402"), "J.58", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Publishing activities" },
                    { new Guid("718e5eac-b060-4016-b6cc-74f63f46d046"), "J.58.1", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("ac798869-a8fd-40a6-b855-e7070ce9f91a"), "J.58.11", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Book publishing" },
                    { new Guid("09726d89-b2b0-445a-98b7-43c4781c785a"), "J.58.12", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Publishing of directories and mailing lists" },
                    { new Guid("3caa6db5-6e72-423b-b997-ea4792b2438e"), "J.58.13", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Publishing of newspapers" },
                    { new Guid("ffa56adb-5f38-4293-9463-7628f2d687d4"), "J.58.14", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Publishing of journals and periodicals" },
                    { new Guid("332120ff-bd46-4c03-80be-5d4c5e546c81"), "J.58.19", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other publishing activities" },
                    { new Guid("5ad711f4-3bc9-4bf0-a44f-f49838acd654"), "J.58.2", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Software publishing" },
                    { new Guid("f9efee92-fbd4-41f2-9c80-82bf37ae3d4c"), "J.58.21", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Publishing of computer games" },
                    { new Guid("aacd7c62-e952-4e5d-a316-f2671e5b886b"), "J.58.29", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Other software publishing" },
                    { new Guid("e57081c4-5292-4a87-93be-ac7418ddf9a2"), "J.59", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("4e27f565-b295-49b0-a740-0a615bb54af0"), "J.59.1", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Motion picture, video and television programme activities" },
                    { new Guid("b277a4d0-9e57-4121-be7f-4a0c3b3224b7"), "J.59.11", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Motion picture, video and television programme production activities" },
                    { new Guid("1318b457-4a8a-4e81-8ca5-91260aa379d9"), "J.59.12", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("1510a640-57ea-4744-a5d3-cec0e0e26a5f"), "J.59.13", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("38a35fed-3d9a-4ebb-b6ac-381de7d293f1"), "J.59.14", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Motion picture projection activities" },
                    { new Guid("05c30835-dece-4710-922a-fec524479f14"), "J.59.2", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Sound recording and music publishing activities" },
                    { new Guid("6d52768e-8b28-4c9d-a349-564c49758752"), "J.59.20", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Sound recording and music publishing activities" },
                    { new Guid("4d2db6f6-ad40-4be2-bc68-715e19bc0c4b"), "J.60", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Programming and broadcasting activities" },
                    { new Guid("6963683f-e4e2-4417-ae0e-9ab412a80bc2"), "J.60.1", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Radio broadcasting" },
                    { new Guid("7e287a9c-a2ad-4932-9be6-b77d2b39acdc"), "J.60.10", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Radio broadcasting" },
                    { new Guid("40704759-ab5f-419d-8d7f-cc2e1152f1ce"), "J.60.2", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Television programming and broadcasting activities" },
                    { new Guid("6bb11143-08e6-46df-b6fa-59eb15557a6e"), "J.60.20", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Television programming and broadcasting activities" },
                    { new Guid("9a31d322-a540-4b83-9566-92cbe156ef53"), "J.61", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Telecommunications" },
                    { new Guid("67ea851f-c701-473a-907b-15286a770c74"), "J.61.1", new Guid("7a87ff71-c538-48a7-8b9f-70a06e330409"), "Wired telecommunications activities" },
                    { new Guid("cd0ea872-83cc-492f-a4a8-ad63b2eaf2a7"), "I.56.21", new Guid("4c379059-edad-47d4-ae59-ba9d1fe940f9"), "Event catering activities" },
                    { new Guid("356e45a3-b8f0-46ff-88cc-551b3f1e35c8"), "K.64.92", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Other credit granting" },
                    { new Guid("6a061b85-4f09-40ca-be56-7bab456df1c2"), "G.47.82", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("1414ffa6-8a54-45c8-a7c6-b9b7c44f6033"), "G.47.8", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale via stalls and markets" },
                    { new Guid("c5e584d3-f517-444a-bf07-b72b02609ef8"), "G.46.19", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("0f4965b4-068f-43f7-a9ef-671e2e5b33cc"), "G.46.2", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("1965f0d4-932f-4c82-b187-d88f64107da9"), "G.46.21", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1541155e-d96e-4330-8a29-f45c73defeb8"), "G.46.22", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of flowers and plants" },
                    { new Guid("1414adb1-d17c-41ee-bcd9-0886d18519d6"), "G.46.23", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of live animals" },
                    { new Guid("e9d63c46-3e0e-4fe8-a92f-8d9c6ba26939"), "G.46.24", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of hides, skins and leather" },
                    { new Guid("8d54b72d-062e-4ed9-ac39-60906c4617ed"), "G.46.3", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("796ae1eb-69dc-46b3-a9d2-fa979d09cbcf"), "G.46.31", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of fruit and vegetables" },
                    { new Guid("60821a61-943f-4bfa-aa59-7137625e1ef2"), "G.46.32", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of meat and meat products" },
                    { new Guid("42bcd5e9-be62-481b-a210-b7e35c1d47f8"), "G.46.33", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("c74e2d7b-7dcd-4f16-b78c-ca92a36d28cc"), "G.46.34", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of beverages" },
                    { new Guid("c6e1a261-2d6c-474c-b85b-5c23c53c364a"), "G.46.35", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of tobacco products" },
                    { new Guid("257e6df0-67ec-4b0a-93f4-fe716728f368"), "G.46.18", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents specialised in the sale of other particular products" },
                    { new Guid("3dd81e56-bfe6-4b1c-89e9-afc78f7f2e6b"), "G.46.36", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("0429b2bc-a482-4f2d-9ad0-360c2c5cbce5"), "G.46.38", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("1b5ebef0-d1f9-4454-a3f7-d67714cbcf40"), "G.46.39", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("938c8006-a25e-420c-b736-4b08c0cd32c1"), "G.46.4", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of household goods" },
                    { new Guid("1acd88de-85be-4f47-8d2c-fd7991d83e17"), "G.46.41", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of textiles" },
                    { new Guid("444bb10e-23da-4393-b043-e3beeb76d7a1"), "G.46.42", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of clothing and footwear" },
                    { new Guid("46bce86c-9a1f-44cf-a2e4-55c2218ad85a"), "G.46.43", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of electrical household appliances" },
                    { new Guid("fa4d3979-7540-4540-966b-1ddadb5b94e2"), "G.46.44", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("81670829-fe47-4c74-8fcd-2d7a375b1807"), "G.46.45", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of perfume and cosmetics" },
                    { new Guid("a77bcca4-b190-4a30-a30f-f0ffa455f125"), "G.46.46", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of pharmaceutical goods" },
                    { new Guid("fb167a48-e08f-4afe-860e-9cd6d1a603c6"), "G.46.47", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("8ca49c03-4ee5-4239-98aa-0590c13c76ca"), "G.46.48", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of watches and jewellery" },
                    { new Guid("d6c20ce8-5480-49a2-997b-f873847c69a0"), "G.46.49", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of other household goods" },
                    { new Guid("da050065-b55b-44b6-81d0-025d39d6df0c"), "G.46.37", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("36bbd2ff-9832-40ad-95a5-dfc0a58e83ed"), "G.46.17", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("393cc964-e443-410f-841b-f672b11765a0"), "G.46.16", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("bb3af373-8e53-4fd2-bd3b-fa6a0a4fd6fb"), "G.46.15", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("6d327d1f-96cc-40ac-bcc0-610854073c5e"), "F.43.29", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Other construction installation" },
                    { new Guid("10230802-5c06-4f40-be97-aee163ac67fd"), "F.43.3", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Building completion and finishing" },
                    { new Guid("30980dec-4b24-44b9-8319-3ec854512948"), "F.43.31", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Plastering" },
                    { new Guid("52c18bed-c319-42c7-bc3f-a895cf0dad52"), "F.43.32", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Joinery installation" },
                    { new Guid("effe559c-9630-49af-8758-99a34ec24eb9"), "F.43.33", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Floor and wall covering" },
                    { new Guid("f83c3592-53f6-4410-83b2-0af3e8727b4c"), "F.43.34", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Painting and glazing" },
                    { new Guid("92fa48f9-e792-46df-bbb7-e9244e9f483d"), "F.43.39", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Other building completion and finishing" },
                    { new Guid("00f7b7e5-b8a1-4618-b485-47a673be7449"), "F.43.9", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Other specialised construction activities" },
                    { new Guid("47c59545-e8f4-4988-9c98-7d9232fdcfe5"), "F.43.91", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Roofing activities" },
                    { new Guid("bdd89350-59be-4ac9-afec-3aab46c517b3"), "F.43.99", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Other specialised construction activities n.e.c." },
                    { new Guid("02babeae-bceb-40ac-9f07-8af75ab30b23"), "G.45", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("8c78099d-3055-45b9-b3a5-1ec90ba76968"), "G.45.1", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Sale of motor vehicles" },
                    { new Guid("fbcc83dc-a13a-44d1-9499-51542213bcd8"), "G.45.11", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Sale of cars and light motor vehicles" },
                    { new Guid("84959592-9033-498a-8b25-f34d418995cd"), "G.45.19", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Sale of other motor vehicles" },
                    { new Guid("41a41793-6e29-4ad7-a549-795e7ac3408c"), "G.45.2", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("dc3fe11e-a57a-4c31-86d2-0382a4a2b285"), "G.45.20", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Maintenance and repair of motor vehicles" },
                    { new Guid("bdc5cdc1-490c-4ac1-9efa-86e7b2c00d29"), "G.45.3", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("49d85a6e-078a-43f0-915b-ad6c0164a52b"), "G.45.31", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("04bbca88-477e-4196-889a-4058bbdd4601"), "G.45.32", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("c0cd34e8-edb6-4d0a-a96f-958daa7f36e4"), "G.45.4", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("e917b391-6c8f-4b40-bc02-973d0bd7db97"), "G.45.40", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("1117c934-e39f-4003-a5c7-656b929b08de"), "G.46", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("a04d4377-7e80-4d0e-85a4-d794c06c7893"), "G.46.1", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale on a fee or contract basis" },
                    { new Guid("e8ba12e5-03f5-4892-bbf9-570970d88e85"), "G.46.11", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("9fe09569-2a2d-4ddc-8950-87089c948efa"), "G.46.12", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("868c4f8c-96dd-4ae6-9e2b-a865a31fa760"), "G.46.13", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("ab7927d1-17ff-456a-b66d-2f2786deef03"), "G.46.14", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("dbae3427-b6cd-4b4c-87c5-39cb73283006"), "G.46.5", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of information and communication equipment" },
                    { new Guid("567f7ea5-4d3f-4e21-a67c-167b42e5a293"), "G.47.81", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("892eecae-2aa2-449f-8439-38c4621989f9"), "G.46.51", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("b89c0e66-fb54-40e8-a68c-f2f9afd28703"), "G.46.6", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("a10a7aa5-c4d7-432e-a4b4-7d37b598d5a4"), "G.47.4", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("dd2455ef-091a-446e-8973-efc29ad5ff07"), "G.47.41", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("9c60b40f-c29e-44a1-b1be-207cdf637f6e"), "G.47.42", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("817044e0-a6a4-4e3f-a491-37d039948300"), "G.47.43", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("3eeb31a6-2fb1-4341-bb20-03da02b7613d"), "G.47.5", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("19e15c7a-2025-4b92-b1e3-fa7eab3c2a8a"), "G.47.51", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of textiles in specialised stores" },
                    { new Guid("99aa5325-8a40-40da-bde4-39d53553e687"), "G.47.52", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("cb1642cc-a50d-40d1-840f-ee550613142e"), "G.47.53", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("5afd53e7-ed52-4166-a386-543ae6aa95be"), "G.47.54", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("9ecf865b-31d2-47ce-a365-574ed054eddf"), "G.47.59", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("35222e31-bdf3-4136-acf2-ca7cfe39df6f"), "G.47.6", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("64da9126-b89c-434d-ac78-93020d6fd89c"), "G.47.61", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of books in specialised stores" },
                    { new Guid("e23e035e-e1d6-46ee-8ecb-3d111ac65c1c"), "G.47.30", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("1b86576c-8e15-42e1-8263-105676327e92"), "G.47.62", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("e12300e4-7e47-4b97-8606-a9473ee788e3"), "G.47.64", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("7a6a95f6-bcb3-4ee7-96c2-32dba19ef2a7"), "G.47.65", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("70a1beb0-4226-43a8-8771-94acb859bd52"), "G.47.7", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of other goods in specialised stores" },
                    { new Guid("f59f1015-6cea-4d1f-8493-b8f215d44bcd"), "G.47.71", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of clothing in specialised stores" },
                    { new Guid("3b9c6ba9-1b29-4996-b846-e37311dc20ee"), "G.47.72", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("3e274391-e565-4ae5-a45d-71b5e9752afd"), "G.47.73", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Dispensing chemist in specialised stores" },
                    { new Guid("59e39f63-f313-4368-8de7-44c4e5811f7b"), "G.47.74", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("412d2dda-2e90-454b-a1ac-36a522a12452"), "G.47.75", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("478965a1-9c2b-41a2-9914-af2d1e917d43"), "G.47.76", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("645f6339-f110-4681-b993-2ebb0b497c8d"), "G.47.77", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("11577acd-f819-48e8-a126-1b29c683f4c5"), "G.47.78", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("03c5cd86-9733-4561-9b51-ef932a436701"), "G.47.79", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7c95151a-cf9f-4b8b-9549-90226fede6bf"), "G.47.63", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("7e5e4eae-a22a-4f55-8297-4803cff22d43"), "G.47.3", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("25122bc1-8aa6-4f20-a0a8-340710c25b23"), "G.47.29", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Other retail sale of food in specialised stores" },
                    { new Guid("2d00521f-9859-4925-91bc-e60315c8c929"), "G.47.26", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("cb4aa70c-a7db-4862-be5f-36a3697820f1"), "G.46.61", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("c37fcb52-809d-4f25-b278-724e46fa2c2e"), "G.46.62", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of machine tools" },
                    { new Guid("3d76b4ec-be0a-4cde-b643-fa45838d2983"), "G.46.63", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("58c80835-526c-4117-a3a3-d3b105eb06b5"), "G.46.64", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("6bf599ae-e07d-4cdf-aef3-1b6888d8cc06"), "G.46.65", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of office furniture" },
                    { new Guid("ffd23714-7461-4e2e-b77e-c0ae957e490b"), "G.46.66", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of other office machinery and equipment" },
                    { new Guid("49f35bf4-1d57-48d9-9c23-5112b420eed4"), "G.46.69", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of other machinery and equipment" },
                    { new Guid("3a523414-72e1-49e6-91c0-f648ddfa5ae5"), "G.46.7", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Other specialised wholesale" },
                    { new Guid("42bf7f47-3c66-479d-bb6f-316a4c61b23a"), "G.46.71", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("7cfad442-2d1d-4a0d-a824-5f89e5f43ca5"), "G.46.72", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of metals and metal ores" },
                    { new Guid("e2d3bdf4-f1d0-47da-8cf1-4d1d30bf48d2"), "G.46.73", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("341b8502-f7be-4455-be35-42365fefe2d7"), "G.46.74", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("3f64ee23-462b-438d-9381-436233e68bf5"), "G.46.75", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of chemical products" },
                    { new Guid("2cf6a7c9-d8d8-49b5-9d89-c3e60baa85e9"), "G.46.76", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of other intermediate products" },
                    { new Guid("4fe4f430-4ffb-4525-b317-341d7c97d3cd"), "G.46.77", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of waste and scrap" },
                    { new Guid("602c1c84-1320-496c-ab75-06e3525f34be"), "G.46.9", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Non-specialised wholesale trade" },
                    { new Guid("295beca8-7741-44f0-9345-75ab65e29876"), "G.46.90", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Non-specialised wholesale trade" },
                    { new Guid("adef755d-fc1f-4b89-95a4-608b2c3d6f82"), "G.47", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("ba12ffc9-1626-474d-b4dd-878a790102e5"), "G.47.1", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale in non-specialised stores" },
                    { new Guid("1772de20-0cb4-4b5d-aa69-bb2a853dc0a4"), "G.47.11", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("75b10be3-4d1b-4d65-bdbf-3fb5717ce83b"), "G.47.19", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Other retail sale in non-specialised stores" },
                    { new Guid("61214138-2212-469c-bdf8-c6057a0ad496"), "G.47.2", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("5b30184a-665c-4adf-bb01-58c4682bb5f1"), "G.47.21", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("0a0e3831-0b32-4425-a234-198d7448a489"), "G.47.22", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("62b35ad0-89ca-4207-9cac-dd3037433409"), "G.47.23", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("964757a8-6488-40fd-8c29-5783c745eb7b"), "G.47.24", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("1b03d938-27eb-4ef4-8d07-896a5b07324a"), "G.47.25", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Retail sale of beverages in specialised stores" },
                    { new Guid("5b2c8190-2b36-4168-ae17-87313be254a3"), "G.46.52", new Guid("03a9355a-42c4-4dc6-923a-740c4fe2ce22"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("fd852f21-d0d6-43d2-9dad-cd8efa73747b"), "F.43.22", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("ff33b20c-664f-481d-bbf0-95b88a5e8374"), "K.64.99", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("e47785a9-e4d4-47cf-ba1b-641a15890f22"), "K.65.1", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Insurance" },
                    { new Guid("3307111b-1e18-4fb1-8a75-84133cb90e58"), "P.85.6", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Educational support activities" },
                    { new Guid("8f66ce10-ccdf-4466-a6a2-1c8e60e626af"), "P.85.60", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Educational support activities" },
                    { new Guid("a9113c5b-3028-4031-b894-1882cd88b586"), "Q.86", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Human health activities" },
                    { new Guid("b91f57ff-dbc7-4e68-bc92-ac64032c2f54"), "Q.86.1", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Hospital activities" },
                    { new Guid("72a4dd56-503a-4cba-bf61-7d1ef6aeae73"), "Q.86.10", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Hospital activities" },
                    { new Guid("511434a7-cf41-4fea-9a8c-8daf422d6d67"), "Q.86.2", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Medical and dental practice activities" },
                    { new Guid("8f3d1524-ec45-41ad-98f2-bf63bd9f3f8f"), "Q.86.21", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("966b8d30-8d96-412c-a2a7-ce154c1f214d"), "Q.86.22", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Specialist medical practice activities" },
                    { new Guid("6c48a488-3137-41c9-a190-4e409ee9bfff"), "Q.86.23", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Dental practice activities" },
                    { new Guid("e9f0b6f3-08df-485d-88f7-4a320b214806"), "Q.86.9", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Other human health activities" },
                    { new Guid("3da5f85d-2a77-4e17-b781-68234ac4a69d"), "Q.86.90", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Other human health activities" },
                    { new Guid("f3b37cd0-a1e0-407c-abe2-d25b69128ea9"), "Q.87", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential care activities" },
                    { new Guid("2e799c28-0a71-477b-8692-f80c76949242"), "P.85.59", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Other education n.e.c." },
                    { new Guid("fb4664e4-ed45-432a-911e-68a0113c02dd"), "Q.87.1", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential nursing care activities" },
                    { new Guid("ec2b641a-444a-47c7-ac80-201871019a98"), "Q.87.2", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("d46236b2-900a-4269-8ea9-3bd5508ca5a3"), "Q.87.20", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("ba44a102-a070-4316-b54b-5cfff2faa6e3"), "Q.87.3", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential care activities for the elderly and disabled" },
                    { new Guid("a95aaefa-167b-49df-9d25-0bd8d7f637ea"), "Q.87.30", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential care activities for the elderly and disabled" },
                    { new Guid("53ec8281-dea5-408a-95f1-33b0897c9003"), "Q.87.9", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Other residential care activities" },
                    { new Guid("9ef5af50-049c-4391-81d6-e6e78d9de716"), "Q.87.90", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Other residential care activities" },
                    { new Guid("bdd6b4c9-2061-4176-9494-73f3c893857d"), "Q.88", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Social work activities without accommodation" },
                    { new Guid("4fda6785-30f6-4657-9839-5916bc286a66"), "Q.88.1", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("6f77f64f-41c4-43dc-baea-0d7f4bd13286"), "Q.88.10", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("39fb59b0-c37e-46f1-972d-2015245c785b"), "Q.88.9", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Other social work activities without accommodation" },
                    { new Guid("71b05dfc-0437-4b68-9be7-419f7e6e85c7"), "Q.88.91", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Child day-care activities" },
                    { new Guid("4ef862c5-af86-4b80-a6f3-f967dda1e0ed"), "Q.88.99", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("8fe4d831-313f-49f1-a1f7-4c353731c19d"), "Q.87.10", new Guid("19c75e0b-fba4-4409-b533-aad93c7b4b38"), "Residential nursing care activities" },
                    { new Guid("52df36a5-16c2-4dd3-9865-50b6b27a0ff1"), "P.85.53", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Driving school activities" },
                    { new Guid("6acab854-69f2-4da7-aa89-8f1f620e42ee"), "P.85.52", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Cultural education" },
                    { new Guid("cb15c9b2-4241-4b2f-9ced-dbc6c92d4373"), "P.85.51", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Sports and recreation education" },
                    { new Guid("54c16e0b-d24c-42f3-825b-d8aef5e1b163"), "N.82.91", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Packaging activities" },
                    { new Guid("ad566d36-33a0-4ad1-91a9-d4ad6a7896be"), "N.82.99", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other business support service activities n.e.c." },
                    { new Guid("f13d50a6-47cc-4a37-8ad0-3cf0c954332c"), "O.84", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Public administration and defence; compulsory social security" },
                    { new Guid("b9872971-cf09-4a04-83f0-8abbb95ee5db"), "O.84.1", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("949519c7-3963-44c9-aa77-4410bcef940e"), "O.84.11", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "General public administration activities" },
                    { new Guid("3af39fdb-0e19-42fb-a9a0-5343ea2cb000"), "O.84.12", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("eb00ce05-3481-4a7d-ba6c-6670543a095c"), "O.84.13", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("1b02844c-0e2f-4fbd-99d5-95afd7294c90"), "O.84.2", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Provision of services to the community as a whole" },
                    { new Guid("c9364ec6-902d-4a9a-b128-6ca05d215e95"), "O.84.21", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Foreign affairs" },
                    { new Guid("a7587a4e-075f-40eb-a226-8572fe24ec61"), "O.84.22", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Defence activities" },
                    { new Guid("a312ae0c-b138-4334-a701-845ef1487be0"), "O.84.23", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Justice and judicial activities" },
                    { new Guid("ec709c0f-459c-4cc8-8613-a30c5daa214c"), "O.84.24", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Public order and safety activities" },
                    { new Guid("2a2b46b7-92f4-4f3f-8243-f35be6583587"), "O.84.25", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Fire service activities" },
                    { new Guid("7abe559e-853a-4616-b5b7-0d2e89b58e59"), "O.84.3", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Compulsory social security activities" },
                    { new Guid("a156f218-8460-4bfb-aeea-a8516397097e"), "O.84.30", new Guid("801ccf1b-38c8-44f0-8c9a-69b1fba00c8c"), "Compulsory social security activities" },
                    { new Guid("bf5a1397-a8e4-456f-b303-72f847c62ffc"), "P.85", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Education" },
                    { new Guid("fafd7def-897c-4a18-a51a-231db6a0e18c"), "P.85.1", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Pre-primary education" },
                    { new Guid("7288adc0-7883-449d-95f1-0285ab5220bf"), "P.85.10", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Pre-primary education" },
                    { new Guid("07bc2527-911e-4d97-bc28-debf7d60fdcd"), "P.85.2", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("63370d33-a4ee-4831-a62f-f71d2a9b5867"), "P.85.20", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Primary education" },
                    { new Guid("248a9869-cb5a-48ad-8b88-4753f4d47e60"), "P.85.3", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Secondary education" },
                    { new Guid("9bd2affb-b014-4b31-bd54-498b7e70ba81"), "P.85.31", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "General secondary education" },
                    { new Guid("71c81288-0105-4f9f-b6c3-9832ff3d7749"), "P.85.32", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Technical and vocational secondary education" },
                    { new Guid("20d215ff-1948-4ef0-845c-2cdac1aeaa7c"), "P.85.4", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Higher education" },
                    { new Guid("5fd5c067-bc3a-4a82-8eac-fee4661c385d"), "P.85.41", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Post-secondary non-tertiary education" },
                    { new Guid("f6adfbfd-1f5d-4fca-8c56-346974f219fe"), "P.85.42", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Tertiary education" },
                    { new Guid("36835ddc-60b1-45bd-af09-4b4f38d6699c"), "P.85.5", new Guid("97149375-a9b3-4166-9896-c6edb49d4e9d"), "Other education" },
                    { new Guid("325433f9-aca2-4fba-b0bf-001eadc101ed"), "R.90", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Creative, arts and entertainment activities" },
                    { new Guid("48f2f369-a954-4634-ac52-d5072e4f6a0c"), "N.82.92", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("847f42f0-aa35-4a58-aeb3-089223ab2b28"), "R.90.0", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Creative, arts and entertainment activities" },
                    { new Guid("d4af0aaf-0909-41ba-9641-05f84fc8d153"), "R.90.02", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Support activities to performing arts" },
                    { new Guid("d4aadac1-1fd9-4c81-af49-0016b57abd8f"), "S.95.1", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of computers and communication equipment" },
                    { new Guid("4184174d-a0b5-4c10-bc7f-3b77ae152746"), "S.95.11", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of computers and peripheral equipment" },
                    { new Guid("7ab91fdb-d47d-4540-a26a-8c78acfed117"), "S.95.12", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of communication equipment" },
                    { new Guid("23a89bc8-4fde-4e62-a48f-0201e8f97b64"), "S.95.2", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of personal and household goods" },
                    { new Guid("73fa2e03-ed80-4da4-8d25-15e6d74e87a9"), "S.95.21", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of consumer electronics" },
                    { new Guid("df6cd6b0-3615-4875-a6c5-c34c0654fb23"), "S.95.22", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("3f67bdbe-5445-4b17-95b1-dbf8590e2ae5"), "S.95.23", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of footwear and leather goods" },
                    { new Guid("a0debd80-d8f4-48c0-a980-244c5a8c61ff"), "S.95.24", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of furniture and home furnishings" },
                    { new Guid("4c4b2cff-f7c4-4444-a9cd-e38eff534808"), "S.95.25", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of watches, clocks and jewellery" },
                    { new Guid("3a0dc056-7e1d-4715-a82a-58db88c45452"), "S.95.29", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of other personal and household goods" },
                    { new Guid("45b92eee-a419-40ce-95ce-721c658e202e"), "S.96", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Other personal service activities" },
                    { new Guid("4e0eb755-0306-479f-bef5-58022d3d21f7"), "S.96.0", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Other personal service activities" },
                    { new Guid("b889760b-8e89-4ec2-beeb-043e011da34f"), "S.95", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Repair of computers and personal and household goods" },
                    { new Guid("c18ed4a0-33c0-4057-939b-2fa15c4a9183"), "S.96.01", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("6a6e41fe-3305-407c-9e90-897c03d7ec8b"), "S.96.03", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Funeral and related activities" },
                    { new Guid("3673fd86-1169-4bdc-9153-b1488913da29"), "S.96.04", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Physical well-being activities" },
                    { new Guid("9fd758d3-8eb4-4ba0-b825-7a1786695ecd"), "S.96.09", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Other personal service activities n.e.c." },
                    { new Guid("8e9dfe8c-fb2e-4e83-9486-5f2a4dffa406"), "T.97", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Activities of households as employers of domestic personnel" },
                    { new Guid("1f29167a-e0ab-48b4-9c94-3f07326d2ce7"), "T.97.0", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Activities of households as employers of domestic personnel" },
                    { new Guid("e674deec-c91e-4722-9868-72ad8ac6db71"), "T.97.00", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Activities of households as employers of domestic personnel" },
                    { new Guid("e3ff001c-b4fa-4296-9a3f-3524e69b42cc"), "T.98", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("ec5106b2-9ec1-450e-9bc7-01b518738b63"), "T.98.1", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("88a76e03-e1d6-4449-916b-23ce756cb847"), "T.98.10", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("5849772d-fbeb-44b5-824e-034f68402736"), "T.98.2", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("c6f022e8-58c1-40d8-999b-8fa0754060da"), "T.98.20", new Guid("94119db1-2e99-462c-a387-2fc8b1222446"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("77a9d072-30d6-48ea-92ee-353e50a4e29b"), "U.99", new Guid("74d43747-70c9-41e3-b67a-9e1e7eebbaf1"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("04761a0c-81d5-430a-9448-ee510997967d"), "S.96.02", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Hairdressing and other beauty treatment" },
                    { new Guid("0ce14f45-0ea3-4479-a6bb-72a6ee1c8c7a"), "S.94.99", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of other membership organisations n.e.c." },
                    { new Guid("82a48798-f476-4fcb-b813-3f3c711e946e"), "S.94.92", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of political organisations" },
                    { new Guid("0fc717da-482f-4a2d-a9af-ff5ddf030272"), "S.94.91", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e7a9d6df-3782-4e9c-8cfd-7ea97682acd2"), "R.90.03", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Artistic creation" },
                    { new Guid("e1f7f634-fd7e-4ac1-b37b-6597095d04f9"), "R.90.04", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Operation of arts facilities" },
                    { new Guid("f23cbb32-6f8e-4b6f-a013-ccd64dc74e36"), "R.91", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("4e62fdae-6e29-4da6-8554-c417e3ca0791"), "R.91.0", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("b8b7330a-e1d3-47e2-ada4-019cee416f91"), "R.91.01", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Library and archives activities" },
                    { new Guid("be2fceaa-2651-4a26-ba44-1dd0152615ee"), "R.91.02", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Museums activities" },
                    { new Guid("447a35e0-7749-497b-baaf-6eeda50272d7"), "R.91.03", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("d0a89834-5c67-4cb6-b4b8-b4485d67b563"), "R.91.04", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("d2eb5ae9-7489-471b-91c2-f7a4c9c963b1"), "R.92", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Gambling and betting activities" },
                    { new Guid("28c0beee-1f9b-4d15-bb92-35b4ef0c8904"), "R.92.0", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Gambling and betting activities" },
                    { new Guid("d1049a37-1498-452d-ac62-c07802d73a9a"), "R.92.00", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Gambling and betting activities" },
                    { new Guid("fc11a16d-2d16-46a1-9041-89409a80491a"), "R.93", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Sports activities and amusement and recreation activities" },
                    { new Guid("cffcec6a-d57b-4b59-a6f4-4a8e7c9efa34"), "R.93.1", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Sports activities" },
                    { new Guid("d005ba43-c155-4aac-882f-c93f0696b3c7"), "R.93.11", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Operation of sports facilities" },
                    { new Guid("8574c7cb-f021-4f3c-b120-b6b10c7aaddd"), "R.93.12", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Activities of sport clubs" },
                    { new Guid("20e16db5-1feb-451d-bd4a-f40bd461b22c"), "R.93.13", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Fitness facilities" },
                    { new Guid("8e8d0f6b-e5d9-438a-9079-5f44e35e6936"), "R.93.19", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Other sports activities" },
                    { new Guid("fec0e3dd-e284-46f9-a193-38850e223272"), "R.93.2", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Amusement and recreation activities" },
                    { new Guid("169b8fda-c0ab-4133-b6b8-73a8108d3cd8"), "R.93.21", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Activities of amusement parks and theme parks" },
                    { new Guid("62ef15b3-68b0-468b-9c6c-69f6e73e88cd"), "R.93.29", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Other amusement and recreation activities" },
                    { new Guid("aa28538c-db1b-4a1e-bb71-96dc8ad88158"), "S.94", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of membership organisations" },
                    { new Guid("322d97ed-e95e-4fe9-ab0b-1461c0dba9d9"), "S.94.1", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("ccadf0ee-5483-405c-85ea-bbb17e5d5863"), "S.94.11", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of business and employers membership organisations" },
                    { new Guid("162685d6-7c62-4297-bf9a-b5e361a9480c"), "S.94.12", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of professional membership organisations" },
                    { new Guid("c7431cdd-fffb-45cc-98a1-1bf8c257e4f5"), "S.94.2", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of trade unions" },
                    { new Guid("dcc86fec-68a1-40c1-a459-54e6b6e139fc"), "S.94.20", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of trade unions" },
                    { new Guid("3f64fed8-6a2b-45d9-a617-dc003df1a17e"), "S.94.9", new Guid("c96e5dd5-5426-44a6-8daa-b79d77401746"), "Activities of other membership organisations" },
                    { new Guid("b6b2e61b-b46d-498e-93a7-bf48a88b3285"), "R.90.01", new Guid("063b360c-27f3-4af9-b0b2-8e3255c05ebc"), "Performing arts" },
                    { new Guid("4bf7c998-c0f0-45eb-8c28-91b016276bab"), "K.65", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("a01adec0-414f-47fe-b3fa-d90638a19239"), "N.82.9", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Business support service activities n.e.c." },
                    { new Guid("9c41f6b4-9b6a-41b3-ab06-eadeee5694b0"), "N.82.3", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Organisation of conventions and trade shows" },
                    { new Guid("13291e06-4c20-49b6-b3a8-7849a07cbcd7"), "M.70.1", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Activities of head offices" },
                    { new Guid("63301e17-9d01-48d9-8496-d1517d0b8b64"), "M.70.10", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Activities of head offices" },
                    { new Guid("774d3259-9dab-430f-90ba-0ab1e3a76a9e"), "M.70.2", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Management consultancy activities" },
                    { new Guid("f380b033-4ff1-4e48-8a80-6c14f9aeca1c"), "M.70.21", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Public relations and communication activities" },
                    { new Guid("034b81f8-27cd-4d75-8113-882b0ba4ddfd"), "M.70.22", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Business and other management consultancy activities" },
                    { new Guid("e13dabd4-d6b8-4e64-88fb-c20b27fd532c"), "M.71", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("27d65d1e-cbb7-4bd7-8cc2-bacbfb82a379"), "M.71.1", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("8235a94d-61f6-4599-b7f9-e5386ad723bc"), "M.71.11", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Architectural activities" },
                    { new Guid("d5973835-76ce-4e2d-a4d9-27b55d9f3fc9"), "M.71.12", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Engineering activities and related technical consultancy" },
                    { new Guid("c993159a-4ae8-404f-9d86-8258b891777b"), "M.71.2", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Technical testing and analysis" },
                    { new Guid("325a2234-0f8a-422a-bac7-0c5d1cdb9e03"), "M.71.20", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2f8855b9-34a2-4742-a7b0-081e2c05b089"), "M.72", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Scientific research and development" },
                    { new Guid("03d7df7c-462d-4f18-afe5-9825a9abfafb"), "M.70", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Activities of head offices; management consultancy activities" },
                    { new Guid("11cf8ef2-0979-4e83-959d-c613a82e68b2"), "M.72.1", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("38dcf2d2-4eff-4f70-b030-812297cf6cdc"), "M.72.19", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("b784d448-dbe2-4b55-b650-2ec190c6e109"), "M.72.2", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("67df21d7-46f3-4cc8-8952-19c6402ee678"), "M.72.20", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("9fdb27a2-44cc-4e7f-b470-ba48a6b63b2e"), "M.73", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Advertising and market research" },
                    { new Guid("fce2bd77-7b8f-4c5d-8057-95d976bc4c8f"), "M.73.1", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Advertising" },
                    { new Guid("c25a87d3-eba5-4bc7-90d5-c55efe4960f0"), "M.73.11", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Advertising agencies" },
                    { new Guid("63d45bbb-e6aa-431f-8d35-147858f9e26f"), "M.73.12", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Media representation" },
                    { new Guid("dd722f47-88c7-432e-91f9-04ab49b9e0de"), "M.73.2", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Market research and public opinion polling" },
                    { new Guid("f21e9a7f-6dbb-4d42-bd16-113784d4aa92"), "M.73.20", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Market research and public opinion polling" },
                    { new Guid("53719b79-5851-4f57-8001-c9e3799f9450"), "M.74", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Other professional, scientific and technical activities" },
                    { new Guid("1ac4ac59-90df-4c4c-96c3-65e38a1d40ac"), "M.74.1", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Specialised design activities" },
                    { new Guid("5721573b-a735-4807-a96e-5494beacfa9f"), "M.74.10", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Specialised design activities" },
                    { new Guid("2a1c1f41-79de-40a1-939d-44847d34247f"), "M.72.11", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Research and experimental development on biotechnology" },
                    { new Guid("2d39dede-6727-45a3-8af7-43f560da15e2"), "M.69.20", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("15245cc3-d890-4a60-9392-1c280b405f71"), "M.69.2", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("cbf92826-2317-4732-8e22-6740dbd41443"), "M.69.10", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Legal activities" },
                    { new Guid("6f23319e-8d95-4040-aee9-80aa99921346"), "K.65.11", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Life insurance" },
                    { new Guid("dc8ccfec-9225-4058-a979-1dd2f9c03a93"), "K.65.12", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Non-life insurance" },
                    { new Guid("e350fc66-22d6-4f9b-86ff-19f0371385db"), "K.65.2", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Reinsurance" },
                    { new Guid("5bf204d1-b33c-47e8-a90b-79fde449e3e4"), "K.65.20", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Reinsurance" },
                    { new Guid("adb62447-6437-4edc-a293-2a04370287a3"), "K.65.3", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Pension funding" },
                    { new Guid("96096c25-3f88-40c9-9c5a-9e6ee336a040"), "K.65.30", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Pension funding" },
                    { new Guid("d40bf098-9a2d-42bd-906c-e71cac55ecac"), "K.66", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("6021f83f-b0c8-4fa4-a7b5-de2ae4e7adf5"), "K.66.1", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("a6700ed5-c400-4951-ab56-0d4ec65e6b14"), "K.66.11", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Administration of financial markets" },
                    { new Guid("5a3cb867-2964-4700-a9bc-397bb9626350"), "K.66.12", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Security and commodity contracts brokerage" },
                    { new Guid("43ad29f7-f7ba-4683-9ee9-9596bd714332"), "K.66.19", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("d82d45b6-f1a1-4c6f-bd49-152199458770"), "K.66.2", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("03c0fbc0-bf22-4359-afbd-b7767ba86005"), "K.66.21", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Risk and damage evaluation" },
                    { new Guid("83fbbb9f-7fe3-416d-9c5d-b497c3bfd545"), "K.66.22", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Activities of insurance agents and brokers" },
                    { new Guid("80a1aea3-18ed-4f45-bf77-d01682015621"), "K.66.29", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("39255db5-66a9-4a91-8376-506b54ab6c7c"), "K.66.3", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Fund management activities" },
                    { new Guid("83be1191-183a-46d6-b118-15445996339b"), "K.66.30", new Guid("0d92eca7-7bf4-4e11-b012-159643d5f7ae"), "Fund management activities" },
                    { new Guid("3c9acccc-3052-49bf-8e17-4cb22845c39e"), "L.68", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Real estate activities" },
                    { new Guid("09b47be6-633e-4f6b-aa78-c599f5d66eee"), "L.68.1", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Buying and selling of own real estate" },
                    { new Guid("609cecbe-ad50-4f26-9b43-29249081841e"), "L.68.10", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Buying and selling of own real estate" },
                    { new Guid("7475418e-1bb6-4261-be48-cd920f69635b"), "L.68.2", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Renting and operating of own or leased real estate" },
                    { new Guid("a3ce18c4-de66-4e6f-b33f-ada9c8d0ccbf"), "L.68.20", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Renting and operating of own or leased real estate" },
                    { new Guid("9f657c81-b727-44bb-af80-106d17d5417c"), "L.68.3", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("08a18ae3-1927-4328-a9e2-3b6a6ddf1cd7"), "L.68.31", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Real estate agencies" },
                    { new Guid("030da9b2-8fff-46ff-afed-d8b0af92afcd"), "L.68.32", new Guid("51fed472-7a14-4e35-a948-727044f8cbac"), "Management of real estate on a fee or contract basis" },
                    { new Guid("6c0feeb6-346b-4eb9-a0e1-ffe3ab3b8a53"), "M.69", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Legal and accounting activities" },
                    { new Guid("af24333a-81c5-40e0-a91a-94f00e9a92cc"), "M.69.1", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Legal activities" },
                    { new Guid("60590e2f-19b7-4fcd-b2ff-afc31cbb6bd1"), "M.74.2", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Photographic activities" },
                    { new Guid("ed42fa7d-49b3-4e55-8fab-b5033596a4bb"), "N.82.30", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Organisation of conventions and trade shows" },
                    { new Guid("d915a3c3-8992-4ab9-ae25-03e36a54a058"), "M.74.20", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Photographic activities" },
                    { new Guid("fd9992a3-dd2a-49ec-a2e4-f14b1da4463f"), "M.74.30", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Translation and interpretation activities" },
                    { new Guid("bb170e27-7dac-4c9a-a4e8-742960e4952d"), "N.79.11", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Travel agency activities" },
                    { new Guid("4bcc71be-8c33-4ab6-94fe-a3bc21b36b0b"), "N.79.12", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Tour operator activities" },
                    { new Guid("ebd06259-b5bb-420f-b28b-1f7757ef0187"), "N.79.9", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other reservation service and related activities" },
                    { new Guid("04e93040-1658-4adc-b8d7-52716f535aa6"), "N.79.90", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other reservation service and related activities" },
                    { new Guid("8820915e-17ad-4d29-8acf-3aa5176cac3a"), "N.80", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Security and investigation activities" },
                    { new Guid("50ecbe07-2776-44eb-ad61-1b9d66241f70"), "N.80.1", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Private security activities" },
                    { new Guid("b61ab56b-26a0-4523-b363-00cbc082a101"), "N.80.10", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Private security activities" },
                    { new Guid("2c94a67b-be5e-487f-b161-35d4c330258e"), "N.80.2", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Security systems service activities" },
                    { new Guid("6aaf5911-3755-42bb-8d7d-ddb54f98c82c"), "N.80.20", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Security systems service activities" },
                    { new Guid("80168684-e03d-48ac-9c6a-a0f90f76bbdd"), "N.80.3", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Investigation activities" },
                    { new Guid("77242e27-b391-4d04-9205-95387bdda89a"), "N.80.30", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Investigation activities" },
                    { new Guid("01524192-d2b8-4674-8939-639cb3c7f3fa"), "N.81", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Services to buildings and landscape activities" },
                    { new Guid("f49923cc-7a43-4214-aa56-584c269b27e4"), "N.79.1", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Travel agency and tour operator activities" },
                    { new Guid("142250e4-6b1c-4f27-9b16-3cdc128c3660"), "N.81.1", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Combined facilities support activities" },
                    { new Guid("8e2fe419-665b-48c9-baba-a18a7e670b8c"), "N.81.2", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Cleaning activities" },
                    { new Guid("50762658-1ee4-46d9-8650-1bab482b3104"), "N.81.21", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "General cleaning of buildings" },
                    { new Guid("8ee20427-9393-4c9d-95a9-245a2b1710aa"), "N.81.22", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other building and industrial cleaning activities" },
                    { new Guid("f72bfb32-18fb-4a7c-8e5b-f913ae8f506d"), "N.81.29", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other cleaning activities" },
                    { new Guid("86e8b73e-37e1-4848-b720-895a9cb82726"), "N.81.3", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Landscape service activities" },
                    { new Guid("6ab93b96-3053-45b2-8089-d70433d6e698"), "N.81.30", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Landscape service activities" },
                    { new Guid("3c4d24c7-b787-4705-8715-a064f7365677"), "N.82", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Office administrative, office support and other business support activities" },
                    { new Guid("739625e9-c770-4049-a06f-f7a6f808a193"), "N.82.1", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Office administrative and support activities" },
                    { new Guid("5018d122-aaf5-4c63-9ffd-11b15b733371"), "N.82.11", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Combined office administrative service activities" },
                    { new Guid("3750877b-d95d-4875-9264-d669338e293c"), "N.82.19", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("ccced86d-02ca-4eea-885f-5b46f6db1cb2"), "N.82.2", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Activities of call centres" },
                    { new Guid("25175bc2-3b4b-4b15-b8a8-823e08f467a6"), "N.82.20", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Activities of call centres" },
                    { new Guid("5170e391-a871-4551-b5ad-5a397b2cca40"), "N.81.10", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Combined facilities support activities" },
                    { new Guid("4283ac5c-92a8-4b10-80db-6b4386282c11"), "N.79", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("bc1625e7-f2bf-45f6-bc4d-428b1dc1aee5"), "N.78.30", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other human resources provision" },
                    { new Guid("c541d21f-2845-4416-9540-2eb62976dbfa"), "N.78.3", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Other human resources provision" },
                    { new Guid("4cfd6a34-e2b1-4a76-9df0-4435c7940cc7"), "M.74.9", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("8525a905-bf1e-4792-baae-72d1580b437a"), "M.74.90", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("84d9ca29-a2e1-4a15-b4fe-21fa6c76fcb8"), "M.75", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Veterinary activities" },
                    { new Guid("6777b82e-acf5-4d90-8f2d-4e2451d0f7ff"), "M.75.0", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ec6f054c-61af-4eb9-be59-c77e1e7b0197"), "M.75.00", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Veterinary activities" },
                    { new Guid("a992e0c6-2a09-4fa8-b007-8e32faf09228"), "N.77", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Rental and leasing activities" },
                    { new Guid("409068a9-8a1c-4b6d-b1ad-ac40f35e8d41"), "N.77.1", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of motor vehicles" },
                    { new Guid("8703ae00-a3b9-4d2b-a1a1-a42f8b276f58"), "N.77.11", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("10bca7c7-1f2c-4e1a-82f7-c934f3b186c8"), "N.77.12", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of trucks" },
                    { new Guid("38baacf4-b5aa-4490-90ea-c3281ca94c56"), "N.77.2", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of personal and household goods" },
                    { new Guid("a9667cdc-30b6-46d4-a6f3-5ebad5567970"), "N.77.21", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("40289cca-5f51-4e88-9f1e-ecf365389be6"), "N.77.22", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting of video tapes and disks" },
                    { new Guid("c4dd845f-4f32-4c30-8760-a94a202e43b9"), "N.77.29", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of other personal and household goods" },
                    { new Guid("2e47bc9b-5327-4ac6-b162-3613b133dd32"), "N.77.3", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("7d342bac-a686-4a4e-a46f-5b5dfae76985"), "N.77.31", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("48f98148-0087-4fb6-83cd-8a95b94ce3fc"), "N.77.32", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("42fdca09-999e-4c2a-8616-b0332d097fb2"), "N.77.33", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("b08a843c-68eb-49e7-9725-48ae9d87d9e7"), "N.77.34", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of water transport equipment" },
                    { new Guid("319b7030-eef5-4eaf-ba10-4bf3ff07bd2f"), "N.77.35", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of air transport equipment" },
                    { new Guid("46fb026e-9d21-4548-aadb-ec19e8605dbb"), "N.77.39", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("e7e0d14d-6881-4cb9-9ec0-b0996f56db62"), "N.77.4", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("be929c9f-a124-4b2d-b608-653b23740885"), "N.77.40", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("7898be2d-f6ba-440c-89f6-3be469de9a78"), "N.78", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Employment activities" },
                    { new Guid("cf16f5fe-3a14-4abb-9a29-b74156c2e4d0"), "N.78.1", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Activities of employment placement agencies" },
                    { new Guid("fff75682-f85c-4dcc-89b4-24707ee28717"), "N.78.10", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Activities of employment placement agencies" },
                    { new Guid("9afbdb8a-6b70-4e2a-b1da-7698c2c0f5f4"), "N.78.2", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Temporary employment agency activities" },
                    { new Guid("714bacc7-fd75-4bb1-b0d3-0745ac5abb58"), "N.78.20", new Guid("cc0af668-7bd7-4b87-b3f7-d4dd5d162c52"), "Temporary employment agency activities" },
                    { new Guid("982d5433-ba1c-48dd-96ed-2117a6954499"), "M.74.3", new Guid("d29f383b-1cc5-4bd8-912f-f71bfae8d16d"), "Translation and interpretation activities" },
                    { new Guid("dde89926-a28e-4173-a13c-8e57783de0f5"), "U.99.0", new Guid("74d43747-70c9-41e3-b67a-9e1e7eebbaf1"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("db4902ef-93f1-4b9b-917e-459962f86cd1"), "F.43.21", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Electrical installation" },
                    { new Guid("5030545c-bbae-44fa-a453-8e8584348016"), "F.43.13", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Test drilling and boring" },
                    { new Guid("8d172f3d-8fac-4ace-9615-adccaee9aa3c"), "C.14.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of articles of fur" },
                    { new Guid("3186f6e6-3290-4f73-83bc-71dabbb5d4b5"), "C.14.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of articles of fur" },
                    { new Guid("91f28eef-fed1-4fd6-a4d0-d2523d2f290d"), "C.14.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("54b46fe1-b5c9-44b7-a98e-4f03668d1c36"), "C.14.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("c09325e6-2693-4540-a14a-08cefd4a13d1"), "C.14.39", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("357f664b-b4fa-4694-bc24-2febf458807c"), "C.15", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of leather and related products" },
                    { new Guid("aae66cc1-cff9-432f-8a29-a93c4c214a13"), "C.15.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("cc04454e-0e55-45fa-9b09-c69629d01a1e"), "C.15.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("d0ded3dd-82a3-4f1f-b2b8-49ed5b3eb235"), "C.15.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("cf25e31a-2b01-4aa9-91f7-ccc859caf9b7"), "C.15.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of footwear" },
                    { new Guid("a08c32ca-2704-49ad-8f0f-cd7926aa8c8d"), "C.15.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of footwear" },
                    { new Guid("de485a98-9c91-4d73-9986-cc16ecaf55c8"), "C.16", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("95028c00-df54-4ada-b20c-b0fed83a926e"), "C.14.19", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("2ba82b93-ed70-4926-8b22-70ccebeefff8"), "C.16.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Sawmilling and planing of wood" },
                    { new Guid("8c32d7a8-615a-47d9-9f14-1a4c59639682"), "C.16.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5b5fbf48-b294-4fd0-8f05-73cbead4e3fa"), "C.16.21", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("daf51668-f7f9-47ba-a6a3-cbdabd5f30f1"), "C.16.22", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of assembled parquet floors" },
                    { new Guid("789e5f2d-b290-4225-85c1-e9965e4085e5"), "C.16.23", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("942bf5ca-f178-4df6-b003-b3c86e39bc56"), "C.16.24", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wooden containers" },
                    { new Guid("2743acc9-bfaa-4338-96d0-3495ae187348"), "C.16.29", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("79dd78b1-8236-4bed-8f33-74304a7a650a"), "C.17", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of paper and paper products" },
                    { new Guid("f935e28f-d4b6-42d7-973e-938b9b16461c"), "C.17.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("b3b192a0-f290-465f-8d13-88ed38fe364d"), "C.17.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of pulp" },
                    { new Guid("be889c62-b7d7-468e-88e4-99f14f257b59"), "C.17.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of paper and paperboard" },
                    { new Guid("dd2afd03-5778-43ff-a4b4-dd83a79afbb3"), "C.17.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("91d61ff6-8449-4b38-af96-c3de43e15032"), "C.17.21", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("7e04dfe5-cc61-4e8a-9c98-657fa4dbdcfc"), "C.16.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Sawmilling and planing of wood" },
                    { new Guid("e7731e02-8403-41a7-8af2-64c92ed994b3"), "C.14.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of underwear" },
                    { new Guid("6136aaf9-6249-4ffd-a91e-9e91582bafde"), "C.14.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other outerwear" },
                    { new Guid("6058326b-6a20-4dce-b5da-d61d47fea548"), "C.14.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of workwear" },
                    { new Guid("027d6685-2bff-422c-8c93-c6b72ab27a27"), "C.11.02", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wine from grape" },
                    { new Guid("02206819-6a2b-4c00-a7c5-242bcc3e851d"), "C.11.03", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cider and other fruit wines" },
                    { new Guid("03c78c02-f63c-40c6-b910-2d42aeb4fa09"), "C.11.04", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("7f4f21dc-ba78-4568-91cc-911336768dfe"), "C.11.05", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of beer" },
                    { new Guid("1f9e0545-1dcd-47f9-86a3-63990e7dff63"), "C.11.06", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of malt" },
                    { new Guid("a0633b69-b71d-4665-a40c-fd6a0fe4bdb0"), "C.11.07", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("94e34827-8a71-442a-93da-dabd9f362727"), "C.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tobacco products" },
                    { new Guid("25a48510-7b12-4830-8540-cee0541e347a"), "C.12.0", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tobacco products" },
                    { new Guid("568a81b0-3e22-4313-8a71-a8ca50209955"), "C.12.00", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tobacco products" },
                    { new Guid("cffe76f2-e6a0-491e-b033-0375ffc06ece"), "C.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of textiles" },
                    { new Guid("1c6b3090-c8de-44c1-a6bc-7c8f7d182fea"), "C.13.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Preparation and spinning of textile fibres" },
                    { new Guid("95afa169-0997-4b8f-94d3-4ef0f1ba39a6"), "C.13.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Preparation and spinning of textile fibres" },
                    { new Guid("edb8e51a-96de-4ff4-9d70-86575a66b20d"), "C.13.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Weaving of textiles" },
                    { new Guid("ddce63e2-b674-494a-a174-13e0b975c65d"), "C.13.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Weaving of textiles" },
                    { new Guid("49d9031c-8419-4627-9f80-d2c9ab58645e"), "C.13.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Finishing of textiles" },
                    { new Guid("d82f9f2a-3678-44fa-80f0-6b095d2dd728"), "C.13.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Finishing of textiles" },
                    { new Guid("a36e7fe3-121b-41af-b28f-204d4c5e435c"), "C.13.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other textiles" },
                    { new Guid("47a10b64-d4b7-409b-99fa-45e27cc2bffd"), "C.13.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("2cd76ed6-f9b2-4c78-aa54-9335c1e18e2e"), "C.13.92", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("f09e8c25-7e46-4f31-8c8f-774b064bd58c"), "C.13.93", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of carpets and rugs" },
                    { new Guid("ed64629e-bfbe-459a-9713-3250a929de9f"), "C.13.94", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("bb74763b-3b53-4e5a-ab6f-958cd271046c"), "C.13.95", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("f00927ef-5a11-4f63-82da-97dcbf918ffa"), "C.13.96", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("dad1c9a8-9b64-461a-afd0-50b7eda0f001"), "C.13.99", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other textiles n.e.c." },
                    { new Guid("9b47222f-5de4-4563-a96b-314cf8b436e0"), "C.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wearing apparel" },
                    { new Guid("51705ee6-caf6-4a32-8e6b-8296a316f9a1"), "C.14.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("a9200b21-4070-4b48-b50d-49bc8c631481"), "C.14.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d4c2990c-25fa-4c32-8d45-87d43de1c585"), "C.17.22", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("4bc4fa7f-7260-42a6-b790-ae6f557f94da"), "C.11.01", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("eb08fdc2-7b9b-4b64-8f97-955a218e17a5"), "C.17.23", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of paper stationery" },
                    { new Guid("49fc4305-57c7-43fe-8a69-94dca56720ca"), "C.17.29", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("8bec936f-f928-41bc-9257-4c57f9c3f65f"), "C.20.52", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of glues" },
                    { new Guid("1223b490-33a5-492b-adb8-3085dd357494"), "C.20.53", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of essential oils" },
                    { new Guid("80f45b6f-49e4-49e0-b8a8-6214aa48bc71"), "C.20.59", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("593ffd31-f539-4ee5-b244-1a2f7107c6d6"), "C.20.6", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of man-made fibres" },
                    { new Guid("d8d18db5-fa34-4cf0-bba9-d562a9af4c11"), "C.20.60", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of man-made fibres" },
                    { new Guid("6ef3fbfa-5344-442e-b9a6-33fbcb7f4a91"), "C.21", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("55dfc05f-7003-4cba-b6ce-073799eb4205"), "C.21.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("4e58076a-9bb3-4130-bc5c-69839d8eb935"), "C.21.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("3df9e29c-564f-45b1-92e9-a240b0597842"), "C.21.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("c39dfe19-bff5-4fa6-8b25-0316aac997ae"), "C.21.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("7c036c96-416f-4454-9d5e-fbfe13eb319e"), "C.22", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of rubber and plastic products" },
                    { new Guid("f475c13b-3c75-4dab-9381-a8f6a7738702"), "C.22.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of rubber products" },
                    { new Guid("b190e4c9-bf76-4e56-b8e9-dd9a773b7f32"), "C.20.51", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of explosives" },
                    { new Guid("1fae8978-0e70-4354-9d03-ce796cb00207"), "C.22.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("8b315d62-8f50-4d05-b4a5-4a6b6748654e"), "C.22.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of plastics products" },
                    { new Guid("6ef65928-eff0-46ec-ac03-b802834ae1f6"), "C.22.21", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("a4c91b4c-971e-4994-807e-1ea4446519ea"), "C.22.22", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of plastic packing goods" },
                    { new Guid("a7922615-cf70-4627-877c-62e9f64648f7"), "C.22.23", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("a6ba8a1f-e24b-4536-9196-11a66693e17f"), "C.22.29", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other plastic products" },
                    { new Guid("3b6e63f8-438d-4984-b661-eb66faa4a098"), "C.23", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("c139a76c-8226-4883-94b8-7ec2831467f5"), "C.23.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of glass and glass products" },
                    { new Guid("1ef6b857-1e61-4ff4-b2e2-d135be153247"), "C.23.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of flat glass" },
                    { new Guid("27d2a8cf-fce6-473f-b7aa-2739d7301cd7"), "C.23.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Shaping and processing of flat glass" },
                    { new Guid("58d035a6-122c-4834-a913-70ae21e24870"), "C.23.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of hollow glass" },
                    { new Guid("5c23c1e9-58dc-4b42-8460-0499ad5dcb7e"), "C.23.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of glass fibres" },
                    { new Guid("1a7cf4c5-e960-44e9-86b8-7d347bb19c4c"), "C.23.19", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("b208d94c-41b4-4739-a70a-ee92bdb367f9"), "C.22.19", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other rubber products" },
                    { new Guid("445e9daf-86d3-4148-95e5-7acc12101af6"), "C.20.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other chemical products" },
                    { new Guid("f347f51f-b79e-4fb2-bb37-8af6773997e1"), "C.20.42", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("eb6c5d2e-7d0f-4bf2-b564-c087d994a600"), "C.20.41", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("0549f227-c75f-40b2-a71c-01a084602cc3"), "C.18", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Printing and reproduction of recorded media" },
                    { new Guid("56cfa840-cf17-4de4-bf26-31e17ed35019"), "C.18.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Printing and service activities related to printing" },
                    { new Guid("194b8771-504a-4b75-9d2b-a39f5d4644ba"), "C.18.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Printing of newspapers" },
                    { new Guid("b081f009-385a-42eb-9d83-351ca6bde514"), "C.18.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Other printing" },
                    { new Guid("0493e280-9ddc-47e6-89f2-ec64b01a6bde"), "C.18.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Pre-press and pre-media services" },
                    { new Guid("e9cf77db-e7d6-4d09-9859-ede60658ebb4"), "C.18.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Binding and related services" },
                    { new Guid("3a9b39ca-9b80-42a6-8381-eeb9fb73fe2a"), "C.18.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Reproduction of recorded media" },
                    { new Guid("79307ec4-3209-44cf-8db1-23ed75790f19"), "C.18.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("53924d80-a11b-4826-ba27-38efac29dd32"), "C.19", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("20391e99-1b1c-4964-bf46-b925f1959d1b"), "C.19.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of coke oven products" },
                    { new Guid("af1aa480-dc9c-440f-ae2d-bd119629c8bb"), "C.19.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of coke oven products" },
                    { new Guid("570ac0ce-5865-42f8-8b42-a1fb11623468"), "C.19.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of refined petroleum products" },
                    { new Guid("9eb8ac11-1db2-4f97-a810-84fd5f25c3bd"), "C.19.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of refined petroleum products" },
                    { new Guid("67d82a73-f363-4ecf-a6c4-4128b098bde3"), "C.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of chemicals and chemical products" },
                    { new Guid("0035978f-62be-4967-84f8-1ad1408bb19a"), "C.20.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("49ff3a2d-4007-4699-86ed-a27ef3a075a1"), "C.20.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of industrial gases" },
                    { new Guid("6bf0aca4-f8c8-4ff0-8972-429f71bd053c"), "C.20.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of dyes and pigments" },
                    { new Guid("b9fd82d2-add3-4042-ad2f-45ade2b36cf3"), "C.20.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("30ff27d9-fdbc-4918-b436-d626a0702431"), "C.20.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other organic basic chemicals" },
                    { new Guid("65cfaa2e-9faa-463e-85e0-81a8e9e23ead"), "C.20.15", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("e8bf0c91-f6a1-4913-afd6-23c288c1f9c8"), "C.20.16", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of plastics in primary forms" },
                    { new Guid("53c41fd5-e1fb-405e-b3da-dab713453aff"), "C.20.17", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("8382796d-6452-499e-b101-eca1bfa4834f"), "C.20.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("62592c25-170a-4280-8c50-57e35fbfe615"), "C.20.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("89c6b564-fc20-48a8-8fc9-a4ade7e202fe"), "C.20.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("8e12d6df-2a2e-4101-8389-17d86439a59d"), "C.20.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("c8a0bb5f-0aa7-4a0e-8ef5-cc31ebc6b6d2"), "C.20.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("390900f8-434a-4ad8-869e-721f3df70614"), "C.17.24", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wallpaper" },
                    { new Guid("d8170d5b-357b-4c37-8593-85f303631cec"), "C.23.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of refractory products" },
                    { new Guid("adc24af0-d2a3-416f-985e-1a65fb36b5d6"), "C.11.0", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of beverages" },
                    { new Guid("1f7da8ba-3ab2-4f8d-8308-f32d697083ae"), "C.10.92", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of prepared pet foods" },
                    { new Guid("baffed25-19ab-414d-8798-bf8fafc4ba33"), "A.01.6", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("24f6ff50-9f71-4b99-9711-e948cc7034c4"), "A.01.61", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Support activities for crop production" },
                    { new Guid("164cdfaf-5cb1-467b-960b-eeed3eb4c266"), "A.01.62", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Support activities for animal production" },
                    { new Guid("e5bcf522-93d7-40f6-b376-561fe9e70a7c"), "A.01.63", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Post-harvest crop activities" },
                    { new Guid("273f4b4a-e8da-40d9-a8a8-83b327370dee"), "A.01.64", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Seed processing for propagation" },
                    { new Guid("1e7a567a-72f5-48bd-b7a8-7185e59ac6d1"), "A.01.7", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Hunting, trapping and related service activities" },
                    { new Guid("d09251db-173c-4420-8138-c40e9dd8e9d3"), "A.01.70", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Hunting, trapping and related service activities" },
                    { new Guid("8216635f-10db-4c9d-9198-ccfca1d82189"), "A.02", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Forestry and logging" },
                    { new Guid("ebb9532c-f510-4157-8059-86bcf4593122"), "A.02.1", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Silviculture and other forestry activities" },
                    { new Guid("c3301ca6-a073-48a7-a609-0adf79babcdb"), "A.02.10", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Silviculture and other forestry activities" },
                    { new Guid("1449e705-09f8-445d-80b0-6d99091c3f29"), "A.02.2", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Logging" },
                    { new Guid("f8058612-f889-4cd7-98f4-4e5ba565af5e"), "A.02.20", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Logging" },
                    { new Guid("12567560-fddb-44a2-b697-4fce7ee0494a"), "A.01.50", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Mixed farming" },
                    { new Guid("46b9d83a-06a3-43ce-887a-aa547c338541"), "A.02.3", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Gathering of wild growing non-wood products" },
                    { new Guid("da25928e-77ad-405a-8e1e-ce390f4a1400"), "A.02.4", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Support services to forestry" },
                    { new Guid("17f47a5e-58a4-442b-ac8b-d93fd05ff18e"), "A.02.40", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Support services to forestry" },
                    { new Guid("5e308149-8388-4d0c-9107-288ca2bfc98f"), "A.03", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Fishing and aquaculture" },
                    { new Guid("0ba0eb0a-e09b-432c-8101-d1041e3c0ecb"), "A.03.1", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Fishing" },
                    { new Guid("afb8f4c7-d36d-4603-8a03-a082465c0fab"), "A.03.11", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ecddbaef-d6f6-4fb5-8e42-22022bcbc6f5"), "A.03.12", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Freshwater fishing" },
                    { new Guid("aeb8e99b-f7f2-49a8-a88a-69a06253083e"), "A.03.2", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Aquaculture" },
                    { new Guid("c76b7c66-c1eb-4446-ac8d-fca142b549db"), "A.03.21", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Marine aquaculture" },
                    { new Guid("dee328c0-f921-424b-851e-7e73f070e2d3"), "A.03.22", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Freshwater aquaculture" },
                    { new Guid("417262dd-1188-400e-bf85-08d0de7732d8"), "B.05", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of coal and lignite" },
                    { new Guid("04fcd5d0-de70-40df-9d62-27fecfa7ae85"), "B.05.1", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of hard coal" },
                    { new Guid("039acb91-e806-479e-b66f-6f397896d428"), "B.05.10", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of hard coal" },
                    { new Guid("d324d825-3c2f-4ce5-afb2-49c200e98814"), "A.02.30", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Gathering of wild growing non-wood products" },
                    { new Guid("fbb01727-0bf9-465e-8c41-891660c5972a"), "A.01.5", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Mixed farming" },
                    { new Guid("54f5ad41-a284-4a6d-846b-d8f245f18700"), "A.01.49", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of other animals" },
                    { new Guid("ab94d05b-c7d5-45d4-aa38-b87401818d59"), "A.01.47", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of poultry" },
                    { new Guid("ecdd6951-890a-413f-aa55-053e2455d137"), "A.01.1", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of non-perennial crops" },
                    { new Guid("2f1e620b-679b-47ef-84b2-c2fd9db8b3ab"), "A.01.11", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("a7a1c2ac-d09f-46b4-8919-1bbd7fb0625e"), "A.01.12", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of rice" },
                    { new Guid("c244747d-7642-40d3-ba13-83244a9a3133"), "A.01.13", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("e94ad09f-9d43-4155-9622-08b5d8502aee"), "A.01.14", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of sugar cane" },
                    { new Guid("61536097-3f7c-46a7-b04b-d02a75e2818a"), "A.01.15", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of tobacco" },
                    { new Guid("3c1eecc6-4404-432b-8f48-a4c863278ac4"), "A.01.16", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of fibre crops" },
                    { new Guid("bdf7f21a-eecc-43b5-b4c1-5c6b72a50410"), "A.01.19", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of other non-perennial crops" },
                    { new Guid("9472184c-c3e2-4243-b6e4-939ad826bff8"), "A.01.2", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of perennial crops" },
                    { new Guid("5c2cf585-8ece-4d44-a16d-ea0cdf44773d"), "A.01.21", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of grapes" },
                    { new Guid("9e5744f2-4db1-4e1f-8de6-788d26ee280b"), "A.01.22", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of tropical and subtropical fruits" },
                    { new Guid("9372d43b-016f-4085-bce4-40528568916f"), "A.01.23", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of citrus fruits" },
                    { new Guid("415dbd7e-bf63-4ad9-9ea4-6a949d373a4b"), "A.01.24", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of pome fruits and stone fruits" },
                    { new Guid("7eafb557-1819-4811-86eb-6ff7325719ce"), "A.01.25", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("79f77198-0bfb-4399-8630-3f57c88de1da"), "A.01.26", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of oleaginous fruits" },
                    { new Guid("74830e67-cd78-4c64-acba-5c323c8f9828"), "A.01.27", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of beverage crops" },
                    { new Guid("a5a659d3-b064-439f-b474-108f600ff784"), "A.01.28", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("798237b3-0c70-41c4-931f-a1e8defcc74f"), "A.01.29", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Growing of other perennial crops" },
                    { new Guid("c95589a0-2905-473e-aa8a-fcbbd2d4c40c"), "A.01.3", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Plant propagation" },
                    { new Guid("10507942-34be-4e40-b16c-b5a6f858fc24"), "A.01.30", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Plant propagation" },
                    { new Guid("c60633ee-756b-49d8-88c0-275a2dd853cc"), "A.01.4", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Animal production" },
                    { new Guid("cd3e0404-ed78-4ebc-b8a9-4e7ee17eb60d"), "A.01.41", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of dairy cattle" },
                    { new Guid("f83790b1-d50e-4104-8892-313a9da824cc"), "A.01.42", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of other cattle and buffaloes" },
                    { new Guid("698db47b-5f72-47dd-af83-3c389eae15c1"), "A.01.43", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of horses and other equines" },
                    { new Guid("6746e1f0-c93d-42eb-9c62-b26848b9e90f"), "A.01.44", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of camels and camelids" },
                    { new Guid("736a43a1-d99e-4231-9c27-173eb9f02b82"), "A.01.45", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of sheep and goats" },
                    { new Guid("daeb11b1-4d99-4f9f-b7e3-8ff2453ba1ad"), "A.01.46", new Guid("20541fed-b4b5-4364-b9ca-a7763b116830"), "Raising of swine/pigs" },
                    { new Guid("92916ffe-2a29-4d75-8ac7-a56964673dc6"), "B.05.2", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of lignite" },
                    { new Guid("bbca6520-6714-4479-b9e9-ec3c7f20fb0e"), "C.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of beverages" },
                    { new Guid("bcfd7d5f-5376-46c4-bebf-20e3a6033faa"), "B.05.20", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of lignite" },
                    { new Guid("9d308322-7fdd-4591-874f-afa5cc50f3bc"), "B.06.1", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ef70fee3-6f98-49f8-9536-15b897c08b2f"), "C.10.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of potatoes" },
                    { new Guid("c90fc92b-4a27-4e75-b2c3-a0ab17afe645"), "C.10.32", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("d40b92bf-02db-45d9-834d-9855a31c5718"), "C.10.39", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("a9040328-2237-4838-bb72-196895c04a04"), "C.10.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("9d933263-1bf8-4689-b5ab-05f07661860a"), "C.10.41", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of oils and fats" },
                    { new Guid("25418553-fa88-44ff-b2fa-c8358c419ddf"), "C.10.42", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("5cbff9e9-043e-404d-9ff1-4113d90ba56d"), "C.10.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of dairy products" },
                    { new Guid("2b900d12-4943-4faa-ad9b-0647f45e8c91"), "C.10.51", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Operation of dairies and cheese making" },
                    { new Guid("cd91f42f-e39c-4ff6-9712-e9d502086207"), "C.10.52", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ice cream" },
                    { new Guid("8823426d-9f3d-4de4-9368-8da13f40cd81"), "C.10.6", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("4ead3919-d2c3-490d-aee9-c1cc1ba9038f"), "C.10.61", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of grain mill products" },
                    { new Guid("2899d76e-6935-40d5-bc82-c51bc02beaa6"), "C.10.62", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of starches and starch products" },
                    { new Guid("c23311eb-37de-4ac1-92a6-a57cedca8361"), "C.10.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("834196a8-24ee-419e-afe3-3b37c6cd2658"), "C.10.7", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("356fde88-5d06-45bb-8489-487672d5f116"), "C.10.72", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("fdee885c-cb87-488c-ad12-59db5fd67faa"), "C.10.73", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("55aa6190-af24-4996-8c9e-1b7846b74acd"), "C.10.8", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other food products" },
                    { new Guid("a1702e0a-0034-46b9-9de3-ea9209b08844"), "C.10.81", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of sugar" },
                    { new Guid("eabb3214-1dc7-42a8-aee6-fc7797032f88"), "C.10.82", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("1ccf8d7c-f02f-49ff-abe5-7e6915b9129f"), "C.10.83", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing of tea and coffee" },
                    { new Guid("242d1f69-c813-415c-a39d-9b7567ffbaa2"), "C.10.84", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of condiments and seasonings" },
                    { new Guid("951ca0f8-55bc-470b-9b33-287d1df76a37"), "C.10.85", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of prepared meals and dishes" },
                    { new Guid("722ee485-a8f8-4928-a1b9-f4e6512dcec4"), "C.10.86", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("95d29980-48da-4eaa-a282-a74c95b40e91"), "C.10.89", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other food products n.e.c." },
                    { new Guid("fd4f0d3f-66cb-4c6d-bbca-7c54f2eb8906"), "C.10.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of prepared animal feeds" },
                    { new Guid("d3ac8113-e171-4572-bb5f-898f60a5d547"), "C.10.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("8514ff89-6c00-4686-b212-1b00a62ffaa9"), "C.10.71", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("d27a2417-4c48-44b4-9faf-455937b75f80"), "C.10.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("0debf319-0010-441b-99ca-9f4511dbf899"), "C.10.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("58987d71-a1c5-4148-a398-036e41ecc0f3"), "C.10.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Production of meat and poultry meat products" },
                    { new Guid("808b6ffc-a023-4bb0-ac04-44401c7e8528"), "B.06.10", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of crude petroleum" },
                    { new Guid("edb89590-3beb-4c17-95cc-25729c371910"), "B.06.2", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of natural gas" },
                    { new Guid("c7b1d338-6ba9-4148-a243-436f645eb751"), "B.06.20", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of natural gas" },
                    { new Guid("29f5511c-a508-4a10-8e38-95d70d64df49"), "B.07", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of metal ores" },
                    { new Guid("01f349ad-b7de-4e41-8cf7-c6c250f65888"), "B.07.1", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of iron ores" },
                    { new Guid("4c042fe0-df53-4319-9cdb-2ecf9baa2d9f"), "B.07.10", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of iron ores" },
                    { new Guid("f0ba583d-0a7a-4958-ab76-31e8ee62cc51"), "B.07.2", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of non-ferrous metal ores" },
                    { new Guid("03af9555-c289-415c-bd11-5bd26dc3146b"), "B.07.21", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of uranium and thorium ores" },
                    { new Guid("6a3a1586-2331-43bf-b06b-b90e4b575c68"), "B.07.29", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of other non-ferrous metal ores" },
                    { new Guid("478247a0-1034-45af-9e69-6d8aad4db18d"), "B.08", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Other mining and quarrying" },
                    { new Guid("d7d7119e-bb4a-436f-bccf-01dd02baca03"), "B.08.1", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Quarrying of stone, sand and clay" },
                    { new Guid("a3579e17-ec2a-43b4-a9e0-c67601db90a0"), "B.08.11", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c821da4c-f561-4bb6-9fc5-5efd1e05fd98"), "B.08.12", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("b1456a13-2644-410d-a84d-1e016e4b2ef9"), "B.08.9", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining and quarrying n.e.c." },
                    { new Guid("3e6287a9-bdbf-404f-8492-d93a1a26d0c2"), "B.08.91", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("522d2da6-8886-455c-b870-5986503771aa"), "B.08.92", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of peat" },
                    { new Guid("c34db6b4-4df9-4853-b8bb-b30cfb5faebf"), "B.08.93", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of salt" },
                    { new Guid("c0975bbb-e94b-49c4-917d-7f312a8caea5"), "B.08.99", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Other mining and quarrying n.e.c." },
                    { new Guid("846dfbca-4e2b-415b-b12a-586dba5b113b"), "B.09", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Mining support service activities" },
                    { new Guid("3d85026a-80af-44d1-8308-5e37df279db1"), "B.09.1", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("a859cb84-17d7-46ca-ac3c-597fc6382d79"), "B.09.10", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("1c745514-0e33-4f21-8628-54d0bfc2aae9"), "B.09.9", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Support activities for other mining and quarrying" },
                    { new Guid("e49e2898-8b19-46cb-815d-10dd223fb1e1"), "B.09.90", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Support activities for other mining and quarrying" },
                    { new Guid("e88f3236-186d-45a2-a150-86e8e9d862ed"), "C.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of food products" },
                    { new Guid("7a9c2996-a849-47d4-95c3-6dd9c62d7940"), "C.10.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("4f6c72fb-26b3-4af8-be00-5e0c7bb92cda"), "C.10.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of meat" },
                    { new Guid("b0a3fea1-d1ab-47ac-a3ff-2bce04b311b7"), "C.10.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing and preserving of poultry meat" },
                    { new Guid("724e808b-6689-4977-87d6-619c23c3f846"), "B.06", new Guid("2f1e59cf-ccae-432b-a8c4-083fd82a392d"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("96e2e6d0-983b-428f-ac7a-b47c802a9dcc"), "F.43.2", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("8e27095e-797a-4b7b-b371-eec630b73798"), "C.23.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of refractory products" },
                    { new Guid("c82acb0e-c26c-4649-bf0c-e54932a841c8"), "C.23.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("671c3e35-95ab-40f4-b0ec-52891020716c"), "C.30.92", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("23b52254-d969-44fe-86e6-b735550d02eb"), "C.30.99", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("23b1e614-51b1-4ace-aea9-e2dd890a8935"), "C.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of furniture" },
                    { new Guid("421eea9a-55b4-4acf-b96b-170048ee1ca1"), "C.31.0", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of furniture" },
                    { new Guid("3ed5c03c-88a8-4d59-bc77-7bc4b75b05cb"), "C.31.01", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of office and shop furniture" },
                    { new Guid("73a80957-4237-4612-ac4a-5caf87aaad97"), "C.31.02", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of kitchen furniture" },
                    { new Guid("269f8115-4757-4ad6-b797-9647bcc3018e"), "C.31.03", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of mattresses" },
                    { new Guid("43799e95-ec3b-490c-9d0a-fab655486eb2"), "C.31.09", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other furniture" },
                    { new Guid("6f899906-2bd1-4b69-86aa-c1d48f8d15a2"), "C.32", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Other manufacturing" },
                    { new Guid("930ed657-eb78-499a-8059-758c16cba088"), "C.32.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("c6166495-ef55-4596-83c6-e428f7d3ef34"), "C.32.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Striking of coins" },
                    { new Guid("deeab02d-5b06-4365-802b-289c4f8dbf38"), "C.32.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of jewellery and related articles" },
                    { new Guid("2481d166-6fcd-4c40-9597-21a4488341a5"), "C.30.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of motorcycles" },
                    { new Guid("a2e31629-eccf-47dd-985a-7114530e40d1"), "C.32.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("2c5b2fd5-b5c0-4aa5-9d1f-633567675adc"), "C.32.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of musical instruments" },
                    { new Guid("a5ff7c0b-527e-4023-a480-373346913211"), "C.32.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of sports goods" },
                    { new Guid("ae42b60d-50f6-4b59-acd6-85f35237551b"), "C.32.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of sports goods" },
                    { new Guid("9f0532ed-ccc6-4179-a613-c703c237f094"), "C.32.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of games and toys" },
                    { new Guid("d8d5bdd1-5bcc-4690-bbb2-1d04c3c44821"), "C.32.40", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of games and toys" },
                    { new Guid("a8da5f2d-bfba-402a-9b37-086b29703df0"), "C.32.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("6b88e794-ee0b-4d83-b1ff-7ccec669f95e"), "C.32.50", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("e2715163-87d6-42a1-8dbd-c743a05f6aa7"), "C.32.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacturing n.e.c." },
                    { new Guid("40ab73df-8ec0-4fe3-8b15-0c057e4e43f0"), "C.32.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f17ed674-d589-4e18-9afd-2c68d72abb7a"), "C.32.99", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Other manufacturing n.e.c." },
                    { new Guid("c8c54919-e6fa-4fe8-9577-5aff262cc649"), "C.33", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair and installation of machinery and equipment" },
                    { new Guid("f34fe883-ff38-40f3-877c-400a21cadd5c"), "C.33.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("2c71111f-fcf9-4ee9-8d32-e914a67b4f78"), "C.32.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of musical instruments" },
                    { new Guid("5d87460e-2285-40d2-8a54-7e76278b277b"), "C.30.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("9e86681f-a6d8-4943-8762-01864c1a9c49"), "C.30.40", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of military fighting vehicles" },
                    { new Guid("fbafabf1-7918-4a12-8ab6-dc2c5d4fac0f"), "C.30.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of military fighting vehicles" },
                    { new Guid("7ceaf207-a81c-4440-b1f8-3b1acd77a393"), "C.28.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("58569896-b591-4114-824c-d325aec79ed3"), "C.28.41", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of metal forming machinery" },
                    { new Guid("58bab602-3833-4851-a362-11bc49604980"), "C.28.49", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other machine tools" },
                    { new Guid("78575618-5e90-4034-9e2a-e8063068e7aa"), "C.28.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other special-purpose machinery" },
                    { new Guid("f81d6e87-4efd-4c26-a230-60c158e26bef"), "C.28.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of machinery for metallurgy" },
                    { new Guid("3aa75240-409c-4a7a-8ccc-f36e6c263257"), "C.28.92", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("6d04fcf8-cd08-4461-8aae-66c8616690b2"), "C.28.93", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("f3f412c3-c8c7-4167-91cb-69de7af3b18d"), "C.28.94", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("7363fbe3-bcc2-4349-bddf-023469448cda"), "C.28.95", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("4eadfaca-c0f2-4016-815d-2ec1788e30f3"), "C.28.96", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("7370e30b-2386-45f9-93c0-573167a078b9"), "C.28.99", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("3abd8b4c-e220-4eb9-b9e2-fe162441e4aa"), "C.29", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("3f31f5a3-0589-4e1c-996f-e783dee3f18e"), "C.29.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of motor vehicles" },
                    { new Guid("cdb114b4-7e21-49ac-9ec3-3ecc9a7c4f87"), "C.29.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of motor vehicles" },
                    { new Guid("2d9666e9-98ed-4c41-b941-2748a8f7d5f6"), "C.29.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("a42b9b75-6147-4857-a101-ae7759bde279"), "C.29.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("7986e4bc-4fe4-45c8-b18b-dc9b750d8a1e"), "C.29.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("f6392ef9-b534-40ae-9ef0-b4cec91d2398"), "C.29.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("6e2cad48-c05d-45cc-9e8c-79b26bd3cb67"), "C.29.32", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("0e8dd8c4-d4d1-47e9-afe1-3fe475171e54"), "C.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other transport equipment" },
                    { new Guid("7efbbf7b-25f5-4162-908b-83136063f934"), "C.30.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Building of ships and boats" },
                    { new Guid("e78bfccb-1108-4943-80b2-9c22d9e90f30"), "C.30.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Building of ships and floating structures" },
                    { new Guid("478a95f9-c47e-4278-917a-d307467f48c3"), "C.30.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Building of pleasure and sporting boats" },
                    { new Guid("dc30577d-b912-41a7-890a-1867003b1603"), "C.30.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("d7738eb7-8b39-4532-b1e9-1abe92f3ba10"), "C.30.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("ae8f796b-3111-4061-9699-9301ebe864d3"), "C.30.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("41d234e0-937d-4a3e-a984-105d5aad4ae4"), "C.30.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("101ad92d-2c99-48a9-930c-3feb52f01b48"), "C.33.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair of fabricated metal products" },
                    { new Guid("40832319-f793-43ec-b959-a7cc0c87e0d3"), "C.28.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("935a64ef-b5ba-448b-8678-e471454557e6"), "C.33.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair of machinery" },
                    { new Guid("097a45ea-59bc-45c5-b5da-0792fe22e3d5"), "C.33.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair of electrical equipment" },
                    { new Guid("51dd4714-f84c-4c77-a7e9-0fb7bda80aa2"), "E.38.3", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Materials recovery" },
                    { new Guid("b603839f-9eb0-4144-8701-3b8af3c34d2d"), "E.38.31", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Dismantling of wrecks" },
                    { new Guid("c8bf4ff6-f8ef-4e31-983e-999fa55a986d"), "E.38.32", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Recovery of sorted materials" },
                    { new Guid("ffaf5549-88ca-4785-b89f-58ef465bb243"), "E.39", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6f10182a-4f08-4ea2-9f0c-3ca97c61b0ad"), "E.39.0", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Remediation activities and other waste management services" },
                    { new Guid("aeeae3c3-6b15-431d-8be5-b4e4fb94257a"), "E.39.00", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Remediation activities and other waste management services" },
                    { new Guid("9e48c83c-4c13-405d-a039-e11056b2e911"), "F.41", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of buildings" },
                    { new Guid("80e8e280-a52a-4b9b-a50c-03c4cacd8983"), "F.41.1", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Development of building projects" },
                    { new Guid("f1682c37-0abe-41ea-b937-15959486bb96"), "F.41.10", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Development of building projects" },
                    { new Guid("448994a1-b1da-4f41-b55e-28bd0c8bb1f9"), "F.41.2", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of residential and non-residential buildings" },
                    { new Guid("b23e2039-c322-40be-b191-f62cd5fa2c43"), "F.41.20", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of residential and non-residential buildings" },
                    { new Guid("115fd7c3-c43c-40eb-ab96-9b285f3d0dad"), "F.42", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Civil engineering" },
                    { new Guid("0859dade-0bdc-4571-9283-6dc8c3405927"), "E.38.22", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Treatment and disposal of hazardous waste" },
                    { new Guid("2098e3fd-76ee-4cbd-81ae-8d7596b06fdf"), "F.42.1", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of roads and railways" },
                    { new Guid("91618d84-3cfe-4624-b4af-8bdd9666709d"), "F.42.12", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of railways and underground railways" },
                    { new Guid("d985402f-4b41-4603-9ea5-1cc4e4b2b06e"), "F.42.13", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of bridges and tunnels" },
                    { new Guid("a2443217-6d8b-4148-b48c-d13bbc23738e"), "F.42.2", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of utility projects" },
                    { new Guid("b4185ca8-8533-4918-a9e4-c2917648a173"), "F.42.21", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of utility projects for fluids" },
                    { new Guid("df77766a-13ae-4933-91fb-69e7ebf66708"), "F.42.22", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("c2f08c1b-68e9-49d5-bb94-8929791a3bce"), "F.42.9", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of other civil engineering projects" },
                    { new Guid("c1406292-0abc-403b-a9a3-17a94fa014c7"), "F.42.91", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of water projects" },
                    { new Guid("96a29317-5ccf-4be9-87e1-297132ea4722"), "F.42.99", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("2e03fef5-19d3-450e-af29-e57a3cbd25d3"), "F.43", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Specialised construction activities" },
                    { new Guid("456f22f8-4d18-4fb2-ad58-312540c29f42"), "F.43.1", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Demolition and site preparation" },
                    { new Guid("d06803f7-f07e-400a-a134-5973ec89a8cd"), "F.43.11", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Demolition" },
                    { new Guid("d5178c30-3259-4ca2-9a4d-4af2244bb0cb"), "F.43.12", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Site preparation" },
                    { new Guid("8aab0118-94b0-4d7b-a7e5-6fa97f8e2ccd"), "F.42.11", new Guid("eb0ddf78-aaae-4f67-82c3-7f8d15db3ee3"), "Construction of roads and motorways" },
                    { new Guid("86ec8c1d-90cc-4ede-89dd-ec9caadb8fc7"), "E.38.21", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("40a38eef-f32a-4d5e-8fbc-c153baec764e"), "E.38.2", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Waste treatment and disposal" },
                    { new Guid("f9474e74-6025-4f95-b3c5-ac9efa5e2bc5"), "E.38.12", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Collection of hazardous waste" },
                    { new Guid("e7bc7375-5f33-4d5b-aef3-7f4880416966"), "C.33.15", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair and maintenance of ships and boats" },
                    { new Guid("f10eb17f-6bd6-4648-99b1-fb04f817bf43"), "C.33.16", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("a888f0fa-7ab1-4f9c-a58b-b993dcc9ec4e"), "C.33.17", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair and maintenance of other transport equipment" },
                    { new Guid("17ab13d9-4b00-4f1a-b9bc-387505ccc1fa"), "C.33.19", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair of other equipment" },
                    { new Guid("ee011726-64fa-4867-a5e9-f30554fc8859"), "C.33.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Installation of industrial machinery and equipment" },
                    { new Guid("351c7711-27ae-4bc5-af4e-1e0bfa7ce7a7"), "C.33.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Installation of industrial machinery and equipment" },
                    { new Guid("072e24f1-ed44-4aac-982d-e0ba27057f2a"), "D.35", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("86c59943-cc0c-4dd3-8630-ad53c6f15132"), "D.35.1", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Electric power generation, transmission and distribution" },
                    { new Guid("14e70905-ff87-49d0-9055-ccdaa02b6ec7"), "D.35.11", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Production of electricity" },
                    { new Guid("fa8ff2ba-8a7f-492b-bd35-a0c2617ea032"), "D.35.12", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Transmission of electricity" },
                    { new Guid("2be42e2e-a7b3-4857-89a5-fdfbf6960a9b"), "D.35.13", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Distribution of electricity" },
                    { new Guid("9ba1d346-d3fd-41bc-a690-d7c98f531263"), "D.35.14", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Trade of electricity" },
                    { new Guid("3d7e7671-9317-4dcf-a818-bdd4dcca6c47"), "D.35.2", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("a09d3204-95c6-4abf-be8c-2b66e341a4b5"), "D.35.21", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Manufacture of gas" },
                    { new Guid("c8445775-23c8-45db-86ba-e9b778482a09"), "D.35.22", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Distribution of gaseous fuels through mains" },
                    { new Guid("d63cc20c-63e2-41df-8e04-35a36ad33e52"), "D.35.23", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("46b08496-fc08-4a7e-9497-625d240819ba"), "D.35.3", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Steam and air conditioning supply" },
                    { new Guid("ff13a5f8-9d79-44cd-b1eb-1d62cebb19eb"), "D.35.30", new Guid("b1e82175-6728-4312-bd24-1d0cdf8ff608"), "Steam and air conditioning supply" },
                    { new Guid("dca541c3-bcc8-4213-a90c-0577dcafe3cf"), "E.36", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Water collection, treatment and supply" },
                    { new Guid("37c71d25-064c-4514-af55-09bb2ad574d4"), "E.36.0", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Water collection, treatment and supply" },
                    { new Guid("176fb445-7935-4a83-8635-66e83edb535c"), "E.36.00", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Water collection, treatment and supply" },
                    { new Guid("08148ca7-79ad-470e-a537-febfa9c58641"), "E.37", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Sewerage" },
                    { new Guid("ae125d7d-851e-4236-96aa-2f37aa06d76b"), "E.37.0", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Sewerage" },
                    { new Guid("cc9d35c7-18dd-495c-bed8-0b6017da2725"), "E.37.00", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Sewerage" },
                    { new Guid("d364b9d2-32e3-4ec2-9cc2-09dffaa619f3"), "E.38", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("5e2bd7e1-7802-475a-b4d1-e9c69d13c358"), "E.38.1", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Waste collection" },
                    { new Guid("8548a8b5-a86b-4cba-9307-fb1a563a3e00"), "E.38.11", new Guid("94c9403f-9920-48f5-a743-5ec5c5ab32d2"), "Collection of non-hazardous waste" },
                    { new Guid("8a851001-ebbe-4cca-83b4-fe9a6f90616c"), "C.33.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Repair of electronic and optical equipment" },
                    { new Guid("f4fe61f6-c022-4d55-8030-b8ec23001f9a"), "C.23.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of clay building materials" },
                    { new Guid("360f638a-c336-4895-a0cc-c2e3b266231c"), "C.28.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("743c719b-cff3-4ec5-bf74-aa28af5ae281"), "C.28.25", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("058a2f9f-55fa-43c2-8314-91c7661d6195"), "C.24.34", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Cold drawing of wire" },
                    { new Guid("6a8b16b1-6150-4b60-a0dd-f814e27181ec"), "C.24.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("b2f99925-4257-4d15-9ca0-a48f181e99d7"), "C.24.41", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Precious metals production" },
                    { new Guid("a636c9cd-8e88-4867-8514-bd69f2328d74"), "C.24.42", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Aluminium production" },
                    { new Guid("3ecb9765-721e-4368-9104-e45abae4935a"), "C.24.43", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Lead, zinc and tin production" },
                    { new Guid("93fb6825-99fc-4737-8ecf-39462dc9606b"), "C.24.44", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Copper production" },
                    { new Guid("3789ad3e-176c-4cba-bddc-423cbf34ac3d"), "C.24.45", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Other non-ferrous metal production" },
                    { new Guid("ef4ee939-c52e-454a-9f34-1a0525d1441d"), "C.24.46", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Processing of nuclear fuel" },
                    { new Guid("1da91a78-5124-4550-a121-8497eedd8a20"), "C.24.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Casting of metals" },
                    { new Guid("5045f941-8071-419e-8458-9e220f53ac68"), "C.24.51", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Casting of iron" },
                    { new Guid("8f214704-4b0f-425b-9515-6494a8f5bc83"), "C.24.52", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Casting of steel" },
                    { new Guid("cc7856d6-5f01-45a8-8e05-8110d3a7ce7e"), "C.24.53", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Casting of light metals" },
                    { new Guid("55761996-3f34-429e-b43c-0534f077bff9"), "C.24.33", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Cold forming or folding" },
                    { new Guid("8694d4cb-a35b-41b7-8e84-d13ebe5b6e8f"), "C.24.54", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Casting of other non-ferrous metals" },
                    { new Guid("169a32e4-1407-4688-b544-52093974dd42"), "C.25.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of structural metal products" },
                    { new Guid("e114feb3-b9bf-42da-87ef-fd3b30b1c1f1"), "C.25.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("a9ec8ecc-c639-486b-97fe-79e7b03b8efe"), "C.25.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of doors and windows of metal" },
                    { new Guid("594676c5-f616-4767-9f22-5badb1a805db"), "C.25.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("21b56b87-0294-4955-9049-69dc749b1898"), "C.25.21", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("09bace07-5175-4640-a598-0eb31dc9eeb5"), "C.25.29", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("6daddf99-9361-4d67-bae7-43e486ee490e"), "C.25.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("387654b5-d89f-4df0-abff-dc42ba3aecde"), "C.25.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("b75a58fb-fa45-4c03-a6d2-1e89320fffed"), "C.25.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of weapons and ammunition" },
                    { new Guid("ba01ceea-343a-42a6-87c9-d213da4f0757"), "C.25.40", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of weapons and ammunition" },
                    { new Guid("7b3ab406-a24e-4d00-9a48-a89e3d564403"), "C.25.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("bf55fd58-061e-48b2-8e58-b3fc7f75af66"), "C.25.50", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("667387d5-4559-4ec9-b518-48c2ea7a9063"), "C.25", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4fe1496d-c679-4716-ad75-747c22a0275e"), "C.24.32", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Cold rolling of narrow strip" },
                    { new Guid("6812b482-e104-4298-87a2-620967adef9b"), "C.24.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Cold drawing of bars" },
                    { new Guid("6ead3255-7694-40e1-87a5-2aaefba93b50"), "C.24.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other products of first processing of steel" },
                    { new Guid("3a9a95d6-50d0-47cf-ac51-1b58a07eb89a"), "C.23.32", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("831efd05-c0de-4fff-8bb1-794d43eb5cef"), "C.23.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("34afc816-bb06-4d6b-9d04-dd1cb59577d5"), "C.23.41", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("2800b658-56a0-4899-b613-0b6eb122b4c0"), "C.23.42", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("ca92394d-74be-4dd0-b0d7-e2cb56bf6ec8"), "C.23.43", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("0add645c-8d80-442a-afda-ccc7236b1638"), "C.23.44", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other technical ceramic products" },
                    { new Guid("a14b0ee4-0bb3-4079-aebb-62a48b80b73a"), "C.23.49", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other ceramic products" },
                    { new Guid("51137e2d-5a0d-4cd7-b4b6-0c20cb325695"), "C.23.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cement, lime and plaster" },
                    { new Guid("5dfdf6d3-3d29-4c3c-b023-8830dffb16ac"), "C.23.51", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cement" },
                    { new Guid("02410628-7d2a-4b23-bf4a-c54cb08c6c70"), "C.23.52", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of lime and plaster" },
                    { new Guid("65a431c2-dad7-4303-ba97-37f9e5ad4985"), "C.23.6", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("fc2db3ab-ee4a-4747-ac6c-86bf02a4c66c"), "C.23.61", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("d738fb97-c88d-41fe-8d71-426ddbd5a942"), "C.23.62", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("301f0f37-d236-4be7-aa2e-23497a80f82d"), "C.23.63", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ready-mixed concrete" },
                    { new Guid("68869aa1-309e-4144-a738-1f0ff605d4bc"), "C.23.64", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of mortars" },
                    { new Guid("998f975f-69ec-4daa-b82b-abf9c22b55d5"), "C.23.65", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fibre cement" },
                    { new Guid("fe0fee0d-7fe5-4cdd-925d-e992d44102b1"), "C.23.69", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("ad8edc6d-40d8-4150-bcf7-180ef3e57833"), "C.23.7", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Cutting, shaping and finishing of stone" },
                    { new Guid("f32b41b8-71e5-4576-86ae-9ca00fa209a6"), "C.23.70", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Cutting, shaping and finishing of stone" },
                    { new Guid("11da23ae-b341-4d80-93b0-b4f4dd929bae"), "C.23.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("5c29a46f-01ab-4bb7-88dd-66b0f3af7ef5"), "C.23.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Production of abrasive products" },
                    { new Guid("836cb48c-2260-493f-b863-6fc33bdb0933"), "C.23.99", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("18a5ad3a-89d0-46ed-abab-c7046c8ffff6"), "C.24", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic metals" },
                    { new Guid("fe5f836a-3e05-4c14-85ae-645b9a37c23b"), "C.24.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("48a69ffe-ee7e-420e-b5f8-67a8dd0720c6"), "C.24.10", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("8fd22b2d-7c68-4f60-9a61-765fd3282815"), "C.24.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("921a17ec-a163-4ac0-a596-2ba4e358005d"), "C.24.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("a5c6182b-80ec-4bc7-be2c-0823b2cfd15c"), "C.25.6", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Treatment and coating of metals; machining" },
                    { new Guid("069bedb5-0594-434b-81e7-5a08e51bc632"), "C.28.29", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("b6d84e3a-7f81-4c8d-81f1-25faf3d02ce5"), "C.25.61", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Treatment and coating of metals" },
                    { new Guid("b56eb967-0664-4f46-a3e9-b2d9d588cacd"), "C.25.7", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("961944ac-2ef6-4305-a6cc-54213181aee1"), "C.27.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("d2362c1a-f0d5-44ed-a6d0-8c1b75f12659"), "C.27.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of batteries and accumulators" },
                    { new Guid("a4accc44-fd5a-4953-a1e8-e8c45b8fc204"), "C.27.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of batteries and accumulators" },
                    { new Guid("3d5a7156-e052-43f6-95f3-f0c3ce7622c1"), "C.27.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wiring and wiring devices" },
                    { new Guid("fe4bf17a-1699-44e1-937e-f053a771bb7e"), "C.27.31", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fibre optic cables" },
                    { new Guid("5e200e41-bb75-46df-ba69-93e40c0f1a74"), "C.27.32", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("2bcf729f-ccc7-4eae-85f5-83e12e801b43"), "C.27.33", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wiring devices" },
                    { new Guid("cf8d7ef0-5af9-4487-abe8-4f3da3cfa981"), "C.27.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("eba6329c-d764-49db-af68-8e4c51f5d9b1"), "C.27.40", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electric lighting equipment" },
                    { new Guid("84a04529-888b-4e92-b92d-274e9dd20e82"), "C.27.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of domestic appliances" },
                    { new Guid("5368c638-e98c-46a0-bfaa-33e4d675d08d"), "C.27.51", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electric domestic appliances" },
                    { new Guid("183be5c2-3fda-4ca0-8134-503d5f7baf7e"), "C.27.52", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("f7248843-731b-4602-aa08-e3c6f41d7d9d"), "C.27.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("3140effe-840b-4cfe-a6bc-368dd820d23c"), "C.27.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other electrical equipment" },
                    { new Guid("217d992b-115d-4471-b619-c4e95a4bf759"), "C.28", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("0517650c-78ca-459b-87f7-4c5aa702ec24"), "C.28.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of general-purpose machinery" },
                    { new Guid("c26839fa-68a8-4d49-b17d-05594e8f7918"), "C.28.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("bf136c23-3c7e-474e-95f0-da7272a8044d"), "C.28.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fluid power equipment" },
                    { new Guid("6534f628-acc7-4ff4-aaa4-483c109593d7"), "C.28.13", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other pumps and compressors" },
                    { new Guid("3f769b35-41ae-4b3e-9651-3147bf1d11e2"), "C.28.14", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other taps and valves" },
                    { new Guid("1cc7a699-7cf0-4a21-a664-ab6df19ed096"), "C.28.15", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("40f22e4b-59ae-4d46-95fe-5073a7079184"), "C.28.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other general-purpose machinery" },
                    { new Guid("0af98c68-210a-4f53-a96f-c2a16068f64e"), "C.28.21", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("f82a96c5-2715-4709-bf9f-6129b0bbf460"), "C.28.22", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of lifting and handling equipment" },
                    { new Guid("197e896a-97b7-4bc7-8976-22ccf28a6238"), "C.28.23", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("68db42db-a4b4-4cf6-b66d-50413f4ef64d"), "C.28.24", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of power-driven hand tools" },
                    { new Guid("b820d23e-36e0-43e0-9a92-0692f8514d5b"), "C.27.90", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other electrical equipment" },
                    { new Guid("8eb465ab-7243-43c1-837d-8905bd70a755"), "C.27.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("88d2abb4-4970-4274-8e37-b28046e46c9f"), "C.27", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electrical equipment" },
                    { new Guid("a6841f54-cca6-4190-b2cb-652fe6fc472b"), "C.26.80", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of magnetic and optical media" },
                    { new Guid("4d7b1e5d-8d28-4057-9316-7dc6a1538a17"), "C.25.71", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of cutlery" },
                    { new Guid("55ec8025-985d-4cab-b68d-8cc72ac05793"), "C.25.72", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of locks and hinges" },
                    { new Guid("99ff3abb-1bc2-4df8-b18b-6e9496b1559d"), "C.25.73", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of tools" },
                    { new Guid("d6991585-8762-4428-ac06-a016f24be319"), "C.25.9", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other fabricated metal products" },
                    { new Guid("703ebb69-562c-4179-be02-dc6e3ee68851"), "C.25.91", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of steel drums and similar containers" },
                    { new Guid("826f53d2-17ac-41db-bd1b-e5c87e76dd1c"), "C.25.92", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of light metal packaging" },
                    { new Guid("f2f55292-8825-4eb7-af89-7f62076cc48f"), "C.25.93", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of wire products, chain and springs" },
                    { new Guid("5819dedd-241b-46e7-b6fe-ed68e0ae1cb6"), "C.25.94", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("269ae44b-eac5-49de-bd80-c310f34455e9"), "C.25.99", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("cbe7559e-d7c5-43f0-8af8-c1befeba4ed3"), "C.26", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("63348e53-76a0-445f-a156-3dbddd74563a"), "C.26.1", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electronic components and boards" },
                    { new Guid("cd9cf913-af85-4a1e-b3d3-f43f682c384d"), "C.26.11", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of electronic components" },
                    { new Guid("6326b3e1-d5c4-4415-a834-0a923d10d7cc"), "C.26.12", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of loaded electronic boards" },
                    { new Guid("c38c0106-c79d-4f18-bcbb-7d61a56c6b7e"), "C.26.2", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("b283e400-e991-40af-bcde-edd71a24e087"), "C.26.20", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("71da812a-70b1-418d-9892-6ed991351854"), "C.26.3", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of communication equipment" },
                    { new Guid("e88b58fc-69f4-4085-9ce4-5e5e546715c7"), "C.26.30", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of communication equipment" },
                    { new Guid("07823268-35a9-4cda-99dc-6a7abd03205c"), "C.26.4", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of consumer electronics" },
                    { new Guid("3063fb04-3957-40d6-a017-53bdd23f57f3"), "C.26.40", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of consumer electronics" },
                    { new Guid("3f6d840d-a5d2-4ac4-becf-0902eb93fc00"), "C.26.5", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("86dac8f8-fed2-4b34-9f0c-9b5c65f0f02e"), "C.26.51", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("1f6a157e-c603-4869-a16a-0739eb56c976"), "C.26.52", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of watches and clocks" },
                    { new Guid("8f255afd-837e-4d0a-953b-2eca45aae833"), "C.26.6", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("27fc1a98-9aea-402d-a390-364ee5e4d84f"), "C.26.60", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("e067fa47-e600-4922-853e-dc7564c42d8a"), "C.26.7", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("4f3135bf-6105-4303-89ec-0e7bb4bcdf3b"), "C.26.70", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("cb6358c7-3217-4dc5-a3f3-2c081e9d59a8"), "C.26.8", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Manufacture of magnetic and optical media" },
                    { new Guid("c1b4df5d-999c-4b48-8b28-831ed8f7b5da"), "C.25.62", new Guid("635d2e8e-7a9b-4ccb-adbe-b00c9c4594bd"), "Machining" },
                    { new Guid("a4df138d-b6b5-4c98-866e-701cc558a9cb"), "U.99.00", new Guid("74d43747-70c9-41e3-b67a-9e1e7eebbaf1"), "Activities of extraterritorial organisations and bodies" }
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
