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
                    { new Guid("ec4ad87d-ac1f-44b7-8fa8-7f74d400332d"), "AT", "Austria" },
                    { new Guid("abe45e92-6c76-4eb6-92eb-5adec1c8eea3"), "LU", "Luxembourg" },
                    { new Guid("deeb1a61-f9f4-4abf-817f-ef0a59aafa5e"), "MT", "Malta" },
                    { new Guid("ba1eb416-471b-4bcd-9af1-420b22597780"), "MK", "North Macedonia" },
                    { new Guid("c8898a94-4ac6-4dc5-8072-b9340a758c53"), "NO", "Norway" },
                    { new Guid("c48297b0-aaaf-482e-a54c-ee68b1d6583b"), "PL", "Poland" },
                    { new Guid("cfbda472-6dd6-4f48-8df6-8b9721dbdb62"), "PT", "Portugal" },
                    { new Guid("36f6a3bf-151f-423f-8197-0a9833924a7d"), "RO", "Romania" },
                    { new Guid("e89f5290-b327-4ee8-ae01-66e2b785666b"), "RS", "Serbia" },
                    { new Guid("5949e6e8-0886-4ebb-9c5c-c4f9a8ff37af"), "SK", "Slovakia" },
                    { new Guid("12121950-beb7-45ba-8b5a-c40a1855e39c"), "SI", "Slovenia" },
                    { new Guid("8594ed09-db14-402a-9bf3-37e8aba91aac"), "ES", "Spain" },
                    { new Guid("045fef02-0d9a-4745-b38f-cff3ec73d64d"), "SE", "Sweden" },
                    { new Guid("db35c8bd-8bae-4112-8b1f-efcf0b0b403a"), "CH", "Switzerland" },
                    { new Guid("00162db5-f3fc-468f-a2b8-b3ddaed7dd04"), "TR", "Turkey" },
                    { new Guid("3fd06c8f-b526-467a-893d-cb45a9b260c9"), "UK", "United Kingdom" },
                    { new Guid("f88f2db1-0ab5-4ea9-a0bb-1902f6dd7bd9"), "LT", "Lithuania" },
                    { new Guid("db956652-4e1f-4a65-9d1d-3e37a73894dd"), "LI", "Liechtenstein" },
                    { new Guid("f89f7b66-0dd9-4f68-acc1-791beb2c2923"), "NL", "Netherlands" },
                    { new Guid("48c45ae4-80b3-4c30-a96a-3e5e699ccb2c"), "IT", "Italy" },
                    { new Guid("e9ac95a2-424d-44d3-98d4-ec751b93a8e9"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("58cb0b4b-cb59-44a2-a9c9-0f66bf4f1a21"), "BE", "Belgium" },
                    { new Guid("643d216a-46a1-4215-b8a3-5a25fcb604dd"), "BG", "Bulgaria" },
                    { new Guid("81afc244-c343-4f06-b035-f441e07c92b0"), "LV", "Latvia" },
                    { new Guid("42fb9318-532b-4a95-be16-88afe38aaa94"), "CY", "Cyprus" },
                    { new Guid("55c396d9-5e65-4623-9aa3-2b90d6f3d317"), "CZ", "Czechia" },
                    { new Guid("70ca0c11-f681-4374-9491-a9cfb80dce90"), "DK", "Denmark" },
                    { new Guid("14a68564-cdba-44fd-9bb3-a3b93968c80d"), "EE", "Estonia" },
                    { new Guid("2287a1f1-b2d6-4e96-9a37-da31231fcdd5"), "HR", "Croatia" },
                    { new Guid("bde4ff1b-bf38-4936-a9ab-9e1c7788d006"), "FR", "France" },
                    { new Guid("dae90083-d040-4680-b807-01ecc12da538"), "DE", "Germany" },
                    { new Guid("f2ffb1dc-fc6e-44c8-8ec4-babd01df4ab2"), "EL", "Greece" },
                    { new Guid("b55a97f4-f633-4032-94fe-3e832ac4babd"), "HU", "Hungary" },
                    { new Guid("73e982ea-5056-4c02-be87-b7151b25e5c0"), "IS", "Iceland" },
                    { new Guid("c2b5aab0-2f28-4b2f-ac0a-c627a0a76585"), "IE", "Ireland" },
                    { new Guid("6d4ab6da-3163-45c6-8391-bc352200183c"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "P", "EN", "Education" },
                    { new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("087a323a-af69-4a81-8966-4689327a8cd5"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "L", "EN", "Real estate activities" },
                    { new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "H", "EN", "Transporting and storage" },
                    { new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "F", "EN", "Construction" },
                    { new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "J", "EN", "Information and communication" },
                    { new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "C", "EN", "Manufacturing" },
                    { new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "B", "EN", "Mining and quarrying" },
                    { new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "A", "EN", "Agriculture, forestry and fishing" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("1e47ecf0-9999-480f-afec-2010b802f6de"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("f73b216e-7b08-494b-9074-c0e486a4bc0d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("04f3d4fc-ac20-4a97-84eb-519d47b00c60"), (short)1, "Ownership type" },
                    { new Guid("18c3f9ff-2ec2-4670-b027-d7d032a72a66"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("04f3d4fc-ac20-4a97-84eb-519d47b00c60"), (short)2, "Frequency" },
                    { new Guid("04f3d4fc-ac20-4a97-84eb-519d47b00c60"), (short)6, null, new Guid("be20d5e1-cb4d-4437-946f-a4dae66a6a32"), (short)1, "Specialists & Know-how" },
                    { new Guid("be20d5e1-cb4d-4437-946f-a4dae66a6a32"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("fa76a2fa-1829-429b-9584-9809b572f6e9"), (short)6, null, new Guid("071a7ca4-d074-4cee-906c-d682debf11cc"), (short)4, "Other" },
                    { new Guid("17f63aef-3272-456f-a128-a5ef35a8b856"), (short)6, null, new Guid("071a7ca4-d074-4cee-906c-d682debf11cc"), (short)3, "Software" },
                    { new Guid("e76fc71f-b646-4ed8-b541-de2c57843ebc"), (short)6, null, new Guid("071a7ca4-d074-4cee-906c-d682debf11cc"), (short)2, "Licenses" },
                    { new Guid("3bd78c0a-1992-49a7-9710-ca59483be48f"), (short)6, null, new Guid("071a7ca4-d074-4cee-906c-d682debf11cc"), (short)1, "Brands" },
                    { new Guid("071a7ca4-d074-4cee-906c-d682debf11cc"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("9a114702-df8d-4147-aaa2-06aa2913cb4c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("2b0389e9-c960-45aa-b3e2-c39b8133ae0c"), (short)2, "Frequency" },
                    { new Guid("f8932540-1357-4323-acbc-026066bbb1c4"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b890efd7-9b32-41aa-a5bc-8efe4784c8c7"), (short)2, "Frequency" },
                    { new Guid("2b0389e9-c960-45aa-b3e2-c39b8133ae0c"), (short)6, null, new Guid("12853b51-a12e-4444-b6be-dbcb7645c404"), (short)5, "Other" },
                    { new Guid("ce713d9e-eeb7-4cfe-ad49-00ccdeb3bd62"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ae553690-d1fe-4768-bd6e-8d2a683934e4"), (short)1, "Ownership type" },
                    { new Guid("ae553690-d1fe-4768-bd6e-8d2a683934e4"), (short)6, null, new Guid("12853b51-a12e-4444-b6be-dbcb7645c404"), (short)4, "Raw materials" },
                    { new Guid("6d82023a-2313-4610-a6cd-f62fe5e44bad"), (short)6, null, new Guid("be20d5e1-cb4d-4437-946f-a4dae66a6a32"), (short)2, "Administrative" },
                    { new Guid("4efae045-aa30-45ef-9571-4ffdc25d7038"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("b890efd7-9b32-41aa-a5bc-8efe4784c8c7"), (short)1, "Ownership type" },
                    { new Guid("b890efd7-9b32-41aa-a5bc-8efe4784c8c7"), (short)6, null, new Guid("12853b51-a12e-4444-b6be-dbcb7645c404"), (short)3, "Transport" },
                    { new Guid("04cfc996-2fc1-4c23-b854-f7f6bc595101"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0b132f81-a6a9-48f4-95e0-b73354bcebbe"), (short)2, "Frequency" },
                    { new Guid("6ff2971c-5005-4423-80fe-f3bd76e7affc"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("0b132f81-a6a9-48f4-95e0-b73354bcebbe"), (short)1, "Ownership type" },
                    { new Guid("0b132f81-a6a9-48f4-95e0-b73354bcebbe"), (short)6, null, new Guid("12853b51-a12e-4444-b6be-dbcb7645c404"), (short)2, "Equipment" },
                    { new Guid("42433fa5-93a0-48d1-ac83-c082efb9f246"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("8550becd-7a56-449f-a8be-3d8540733984"), (short)2, "Frequency" },
                    { new Guid("7d2b65a7-f5a6-4820-a44c-887437095451"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("2b0389e9-c960-45aa-b3e2-c39b8133ae0c"), (short)1, "Ownership type" },
                    { new Guid("fce62dd4-86c1-4efe-9f8b-4132ae0c46a2"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("6d82023a-2313-4610-a6cd-f62fe5e44bad"), (short)1, "Ownership type" },
                    { new Guid("08cb3535-b2d1-48d8-8cfc-22b9719d55fe"), (short)6, null, new Guid("be20d5e1-cb4d-4437-946f-a4dae66a6a32"), (short)4, "Other" },
                    { new Guid("b60ff3fc-87fb-4843-9f93-6ddb4c397182"), (short)6, null, new Guid("be20d5e1-cb4d-4437-946f-a4dae66a6a32"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("e4b0bb4c-cf4f-4b7c-b23d-286644c8b229"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("8550becd-7a56-449f-a8be-3d8540733984"), (short)1, "Ownership type" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("5078be6c-6c8f-4ca1-9246-bb3430f1b81f"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("844afc3d-6cbc-4386-b50f-d7914e8815a6"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("c46c27f8-1685-467f-822d-e463d3d2d46c"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("2d521fc0-c7de-4bd9-857c-ceac200b68e8"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("e995d0f7-235a-4201-bd8a-78eba4f80634"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("202ca465-2937-468c-8015-0725de0466fe"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("98d5b09e-8b82-4805-9e3d-1f2ad270e90b"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("8a9a24b1-d64d-420a-be76-796112826402"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("8355da0f-4685-41e9-9a0b-78bacbcd898a"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("575bed1e-3fce-4d07-96b6-de34492603a0"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("400da156-093f-43b4-91cf-71a149299c25"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("63153c1c-edf2-4598-8cae-74c9a761a6a4"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("b864b8f3-1974-4178-97d3-fb502bf3fc68"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("ad86ab8b-bc63-42fd-a915-5ced45bcbcf4"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("ff85a912-1068-43e9-a30d-c17ee2c2e40c"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("3b9700d3-0f7c-477f-8568-fe0789bbb63d"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("f248c73a-b978-468d-87fa-52f00b63ce6a"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("08cb3535-b2d1-48d8-8cfc-22b9719d55fe"), (short)2, "Frequency" },
                    { new Guid("73648e97-7375-4759-82db-0d84a2a4ab88"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("08cb3535-b2d1-48d8-8cfc-22b9719d55fe"), (short)1, "Ownership type" },
                    { new Guid("0a942555-a287-422c-b43d-6ebcc68e88bf"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b60ff3fc-87fb-4843-9f93-6ddb4c397182"), (short)2, "Frequency" },
                    { new Guid("119b5b28-f5eb-4a80-92b9-cde4648c4644"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("b60ff3fc-87fb-4843-9f93-6ddb4c397182"), (short)1, "Ownership type" },
                    { new Guid("3668cd42-0300-404a-b189-7f24f8c62c7c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("6d82023a-2313-4610-a6cd-f62fe5e44bad"), (short)2, "Frequency" },
                    { new Guid("8550becd-7a56-449f-a8be-3d8540733984"), (short)6, null, new Guid("12853b51-a12e-4444-b6be-dbcb7645c404"), (short)1, "Buildings" },
                    { new Guid("f6941c09-b39f-4a5a-8012-998f677f9714"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("167d7f6d-f22c-4758-ad20-d16a3f3d9d8b"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("56676b84-5227-49fe-86e2-cddb885c26ad"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("c746278b-ad7f-4fb1-852e-de5abc4b3528"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("730a46ae-646a-462f-a349-9c4b14067167"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("c5471770-2cc6-4142-a18b-44bf11bd7e01"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("ec593a61-4f4e-4110-a904-e8c33dc59c48"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("cde05811-9fac-446b-a117-c1968b3705a9"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("3b73200a-f2a0-451f-8ea4-65582325fd83"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("625f305f-6c43-4f19-8624-c7a6a0e6d3a1"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("e9e0e81d-5a10-46c1-92b4-3c81293c3abd"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("b51d7fd1-cfd6-45ae-abe6-d8a57ede490f"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("55f93abf-6fd7-43c6-959b-93231fbd3e9b"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("b88551ba-9ac3-41c8-8268-fbef3019daee"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("768f8106-c9f2-48f6-9fb0-5108ca8c795d"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("f5a285c6-6117-4b0a-a515-92271d4b9e65"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("b960c549-939a-4e91-a62a-e3eec26d60c3"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("19d79190-283c-4219-bd6d-ca74bcac99dc"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("a54bd55d-8091-4cc8-af78-230948f5b303"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("6d27c0cb-9535-4650-a1dd-a5c014e1c8d0"), (short)1, "a", null, (short)4, "Inventory" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("d95c9f27-74fa-4f59-857d-4e6575d28546"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("020e4ae6-9d12-4dd2-aef4-7faa40f9b371"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("c3dcb1ef-4df8-4f36-829d-4b9e2ec93912"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("02c20ec6-fd2e-4b99-a674-30c5d9a625ea"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("12853b51-a12e-4444-b6be-dbcb7645c404"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("60b5d3ee-1065-42c7-a68e-64aca25e73c7"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("6097f395-fa20-47c7-9219-7575a5be3521"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("9b0570e6-9651-4e2c-b965-8e95762ffdf8"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("4bda215f-c11e-43fc-9094-a6bfc6a8ed14"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("d46e8888-4f06-40dd-bebb-2dccdb9926d1"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("e6dbb214-96a9-42a7-8b32-e3841bb4a127"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("d28cf8f2-4ddc-41fb-a62b-62fa99d1de86"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("dd3f53a7-c0b9-4f66-9170-fff59268cd47"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("fe20b823-dfb7-4778-b643-2c7869726b1f"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("db075993-97f2-4a74-b272-7179a16159ec"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("c5e3e18b-71dc-434a-bb1f-08645eb5843c"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("3a53fbb0-c9cd-45c2-82a5-048dd8ded633"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("6a4eab40-330a-4736-8955-664196138fec"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("94d05503-043c-4887-817a-22721aad1ef5"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("db156b0d-ff87-4b27-a8b6-f20a58db79fc"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("00f48527-4694-4184-8693-8410afc7ec20"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("2d9bdec5-9849-4850-a1a2-715ab3cdf4b2"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("4faa7dff-f08f-4016-a9a9-258b288ac02d"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("f45ad176-a01f-4b11-b0be-4bf51befe9fb"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("93ee9c1a-9667-44d1-870a-522be7bb480b"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("3c7e400c-c9a8-4e2d-ace4-47e73da300c1"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("33719f73-ff1e-47e9-a73d-3378e3d5cabb"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("6bfa973b-d4ee-4db6-8b35-8358b6f7a33d"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("71856f9f-9e83-45c4-a666-7af1b249f271"), (short)3, null, null, (short)13, "Infrastructure" }
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
                    { new Guid("c299c78d-dd95-4731-ab7f-620a65eb5d58"), "A.01", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("ba9cd34d-d499-418a-ba9b-fc7cffa8ac96"), "H.51.22", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Space transport" },
                    { new Guid("8f88d7c6-5c7b-48de-966a-5bffdfffdf82"), "H.52", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Warehousing and support activities for transportation" },
                    { new Guid("a276dca2-eb95-4319-ac97-b1f5bcd3f4e8"), "H.52.1", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Warehousing and storage" },
                    { new Guid("de291805-d85f-44ac-88a7-e548849bcc60"), "H.52.10", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Warehousing and storage" },
                    { new Guid("8b3e9156-c16e-4765-860d-04f30b67415f"), "H.52.2", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Support activities for transportation" },
                    { new Guid("5ea263f5-d1a9-485f-a87c-71e248530a8d"), "H.52.21", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Service activities incidental to land transportation" },
                    { new Guid("ffd47084-7008-4d1c-b26f-c8c5c6a1b449"), "H.52.22", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Service activities incidental to water transportation" },
                    { new Guid("cf87fa2d-00b5-49a3-b819-6e14390027b8"), "H.52.23", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Service activities incidental to air transportation" },
                    { new Guid("251bcd1d-7ee2-4509-8b5b-bd5cbdb1db12"), "H.52.24", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Cargo handling" },
                    { new Guid("df0c96f8-ad72-4a68-b18f-a0a2e0fe56a7"), "H.52.29", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Other transportation support activities" },
                    { new Guid("1cc8daaf-0527-40a8-bd6a-17317c5be847"), "H.53", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Postal and courier activities" },
                    { new Guid("5207b092-6079-4b93-9c05-53e76a712d97"), "H.53.1", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Postal activities under universal service obligation" },
                    { new Guid("27963f27-26ef-446f-a2eb-c7588ca2db3c"), "H.51.21", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Freight air transport" },
                    { new Guid("f798f3e7-e2af-4c94-b775-a344d0b8687f"), "H.53.10", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Postal activities under universal service obligation" },
                    { new Guid("499e8c19-9f98-4ee4-a2e7-f462046302d2"), "H.53.20", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Other postal and courier activities" },
                    { new Guid("79b34eab-d9f4-45fc-b654-e69b471ba799"), "I.55", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Accommodation" },
                    { new Guid("a7e7aecb-f1c2-445c-b613-a2981a9bce9e"), "I.55.1", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Hotels and similar accommodation" },
                    { new Guid("defad9d8-e57b-4ffd-94ee-82b164bc8def"), "I.55.10", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Hotels and similar accommodation" },
                    { new Guid("1f60eff4-80b2-4061-87c1-aced5b031189"), "I.55.2", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Holiday and other short-stay accommodation" },
                    { new Guid("7f9722af-a4f7-4019-9622-45b434640e2a"), "I.55.20", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Holiday and other short-stay accommodation" },
                    { new Guid("fb798c26-3eeb-405e-b17d-d2deee7a95d5"), "I.55.3", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("aad55364-49fe-476b-b040-b8c7f84062b7"), "I.55.30", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("80cc19b4-a911-4d59-bb4e-6f958a269204"), "I.55.9", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Other accommodation" },
                    { new Guid("9584253b-b205-41ab-85c6-bc99b18519c3"), "I.55.90", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Other accommodation" },
                    { new Guid("18ebb0b8-4349-443a-b79a-17b84b75912d"), "I.56", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Food and beverage service activities" },
                    { new Guid("bf25cb28-9179-4fc6-98a4-d481c0874482"), "I.56.1", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Restaurants and mobile food service activities" },
                    { new Guid("29deceee-246e-4938-9201-2232074e89fd"), "H.53.2", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Other postal and courier activities" },
                    { new Guid("89ad8edb-697e-4438-80c3-7e8e465f83e0"), "H.51.2", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Freight air transport and space transport" },
                    { new Guid("61e712dd-59ca-4186-a87e-74bf04c00ec0"), "H.51.10", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Passenger air transport" },
                    { new Guid("3a6b7737-b886-48e0-8f5b-9819c623e560"), "H.51.1", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Passenger air transport" },
                    { new Guid("c3434547-d6a7-4dd5-a280-b820cf6501a7"), "G.47.9", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("04c012d8-68a7-4cf0-98db-ab4972b28f48"), "G.47.91", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("2eb95d2c-319e-4981-a6b4-147dfabf58f0"), "G.47.99", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("da35c5bd-2101-483f-8248-78fb2ccd1efb"), "H.49", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Land transport and transport via pipelines" },
                    { new Guid("bc7113bb-8912-4ba0-aef0-46cfdf3352e7"), "H.49.1", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Passenger rail transport, interurban" },
                    { new Guid("85552aa0-3625-4bd8-9557-4542036327de"), "H.49.10", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Passenger rail transport, interurban" },
                    { new Guid("d6e66997-f187-4d6d-a962-3e74118c916a"), "H.49.2", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Freight rail transport" },
                    { new Guid("ccf26ecf-9f07-467d-a535-6fe630fddcc2"), "H.49.20", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Freight rail transport" },
                    { new Guid("8d0b3540-1f64-40ff-a648-c4ee8f7db228"), "H.49.3", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Other passenger land transport" },
                    { new Guid("dfdf5ead-2d7e-480d-af68-3291f53653ca"), "H.49.31", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Urban and suburban passenger land transport" },
                    { new Guid("1842bccb-f666-4eab-8992-272f58f907b8"), "H.49.32", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3d3c870f-2c71-45dd-ba35-c7b322b8aad6"), "H.49.39", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Other passenger land transport n.e.c." },
                    { new Guid("3168530e-61f4-4d2f-900c-aaedc6597683"), "H.49.4", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Freight transport by road and removal services" },
                    { new Guid("e768b530-eef7-4f78-a414-6a1c90f75666"), "H.49.41", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Freight transport by road" },
                    { new Guid("16513e86-fdc8-4064-bf59-644df1e626f7"), "H.49.42", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Removal services" },
                    { new Guid("9f987df8-8a22-487a-a61d-5f7819e8b0b1"), "H.49.5", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Transport via pipeline" },
                    { new Guid("695c7f0c-ae6b-43b6-ab82-3cb077618db0"), "H.49.50", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Transport via pipeline" },
                    { new Guid("e2a7f293-ab38-4041-ab88-a9fb1b55912e"), "H.50", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Water transport" },
                    { new Guid("bb026092-202d-41c6-8461-8bd09c6663c4"), "H.50.1", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Sea and coastal passenger water transport" },
                    { new Guid("bb109109-2e1f-47a8-8a12-e67fca581376"), "H.50.10", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Sea and coastal passenger water transport" },
                    { new Guid("efa63058-a6af-495e-8dab-adb53c4cbcff"), "H.50.2", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Sea and coastal freight water transport" },
                    { new Guid("4e01c652-77b4-45de-b025-42a80fa54abc"), "H.50.20", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Sea and coastal freight water transport" },
                    { new Guid("de0e8ac5-7231-4646-8b4f-e891a80d5371"), "H.50.3", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Inland passenger water transport" },
                    { new Guid("5158f8c3-115c-4f98-b295-ce8630490fbc"), "H.50.30", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Inland passenger water transport" },
                    { new Guid("f96755a1-c808-477f-85e0-8f8f45d45e8d"), "H.50.4", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Inland freight water transport" },
                    { new Guid("8473309f-1539-48ff-9022-20449a9ca000"), "H.50.40", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Inland freight water transport" },
                    { new Guid("727f3574-8f9e-4e03-8613-a0e4bf111020"), "H.51", new Guid("723f984e-9e46-45cd-8bf4-73d76d6ac597"), "Air transport" },
                    { new Guid("1cea1751-2f00-46a8-82c5-90186bb97e12"), "I.56.10", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Restaurants and mobile food service activities" },
                    { new Guid("98e44b73-39f0-44a0-b602-1eeafbfc4175"), "G.47.89", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("de53d188-f42d-4de1-82dd-400ad5abc366"), "I.56.2", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Event catering and other food service activities" },
                    { new Guid("2819c4cd-052c-4267-bab6-e10a14a490df"), "I.56.29", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Other food service activities" },
                    { new Guid("8deb4748-d12d-42cb-8100-c3ab2c0ab3dd"), "J.61.30", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Satellite telecommunications activities" },
                    { new Guid("71a331b6-d63c-406d-9853-d5ecad082363"), "J.61.9", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other telecommunications activities" },
                    { new Guid("1db38738-48e3-4501-accb-cd0a023107f7"), "J.61.90", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other telecommunications activities" },
                    { new Guid("ebeeb8fc-68d1-46e3-93a8-19d3d1489d18"), "J.62", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Computer programming, consultancy and related activities" },
                    { new Guid("cf6d3ff4-47a8-4001-88f5-bca7428c2f4d"), "J.62.0", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Computer programming, consultancy and related activities" },
                    { new Guid("79a006a4-e94c-4fa7-9ae8-c0607e3d3395"), "J.62.01", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Computer programming activities" },
                    { new Guid("b0224139-7c04-464f-a733-dfb1d0c09829"), "J.62.02", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Computer consultancy activities" },
                    { new Guid("4c0abfdb-964f-4a33-84ee-b0a187372315"), "J.62.03", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Computer facilities management activities" },
                    { new Guid("a8b714d2-2da8-49e5-9f1c-9af99991dced"), "J.62.09", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other information technology and computer service activities" },
                    { new Guid("50c51946-7b2b-4dfa-9149-a9d32e72dddd"), "J.63", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Information service activities" },
                    { new Guid("667f33d8-0aa5-432f-b965-3ffb0b20c6e9"), "J.63.1", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("f180399c-7953-4acd-8b8c-8050d6c1b83a"), "J.63.11", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Data processing, hosting and related activities" },
                    { new Guid("ca580de8-efd2-4c78-8cf1-83235d1ec2df"), "J.61.3", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Satellite telecommunications activities" },
                    { new Guid("b2ddf3ea-2aba-4afd-b941-8a32f16f01ce"), "J.63.12", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Web portals" },
                    { new Guid("eaa6ba71-b7bb-447d-98e8-495af6338f46"), "J.63.91", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "News agency activities" },
                    { new Guid("2ddad8dc-cc7f-4a34-aca4-52d52ff34451"), "J.63.99", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other information service activities n.e.c." },
                    { new Guid("fe429e00-3fb8-483f-9ce1-86c3a4d40865"), "K.64", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("a46973c8-17fd-494d-b517-66e5aeb68bbd"), "K.64.1", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Monetary intermediation" },
                    { new Guid("80c421e8-2385-480f-b45e-0b26ad3f4c87"), "K.64.11", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Central banking" },
                    { new Guid("e8a283e6-579f-4e1b-89c0-65fa44a7761b"), "K.64.19", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Other monetary intermediation" },
                    { new Guid("70e5e141-b687-4df7-9596-7ab3b322dafa"), "K.64.2", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Activities of holding companies" },
                    { new Guid("8b07218e-a3dd-4610-9b34-f6bb1fa47e48"), "K.64.20", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7e2b5869-4271-45b4-b227-7fec0e852d00"), "K.64.3", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Trusts, funds and similar financial entities" },
                    { new Guid("d9045638-e8f2-45b6-8337-66791c749a52"), "K.64.30", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Trusts, funds and similar financial entities" },
                    { new Guid("02007b3a-6238-4d2d-bd33-a141675ad033"), "K.64.9", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("059757e8-acf3-4491-ab9e-59ea36691688"), "K.64.91", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Financial leasing" },
                    { new Guid("c7ab035a-70c7-46a2-981a-1bae42a44627"), "J.63.9", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other information service activities" },
                    { new Guid("e3666df1-4f57-4ead-848c-79a4f219a5ce"), "J.61.20", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Wireless telecommunications activities" },
                    { new Guid("e3ddf1f9-2fc8-49e5-abfa-123a640e5c7b"), "J.61.2", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Wireless telecommunications activities" },
                    { new Guid("90f7b385-e904-4c73-a4bc-0c96e1572dae"), "J.61.10", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Wired telecommunications activities" },
                    { new Guid("eaaa2c37-e963-4b51-827d-7318aabee589"), "I.56.3", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Beverage serving activities" },
                    { new Guid("38eac363-dffa-4b23-80df-784ef856961f"), "I.56.30", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Beverage serving activities" },
                    { new Guid("7b0c7f8b-ea2e-4820-82bf-dd0e361c06f8"), "J.58", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Publishing activities" },
                    { new Guid("c973cb57-f03f-4e1d-95e3-6c621372ab87"), "J.58.1", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("239f8f4a-42b8-4356-98bf-524f849940f8"), "J.58.11", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Book publishing" },
                    { new Guid("8585fe95-ed51-4df8-8898-02f08d3d903f"), "J.58.12", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Publishing of directories and mailing lists" },
                    { new Guid("b1bc8df9-6c8d-43b1-a93b-1061104832d3"), "J.58.13", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Publishing of newspapers" },
                    { new Guid("13e45f84-e4c2-4ca5-972a-a5d2a46db406"), "J.58.14", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Publishing of journals and periodicals" },
                    { new Guid("db24e00e-c9a2-4759-b96c-2ffdd8884494"), "J.58.19", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other publishing activities" },
                    { new Guid("b6920728-ff47-4b8b-b18d-cb69a4c640c4"), "J.58.2", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Software publishing" },
                    { new Guid("60f5973c-e3d4-42d0-841f-5ec64e32baff"), "J.58.21", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Publishing of computer games" },
                    { new Guid("326eb360-77c4-4102-aff0-7ecdfb233efd"), "J.58.29", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Other software publishing" },
                    { new Guid("78f6baa6-ca7e-47bf-951f-6f42a25394fc"), "J.59", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("e66cc018-9a86-4dee-927a-00b13c1cb7f7"), "J.59.1", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Motion picture, video and television programme activities" },
                    { new Guid("f567cc57-7146-4398-86bc-2e02d605edea"), "J.59.11", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Motion picture, video and television programme production activities" },
                    { new Guid("81f3d73f-7921-47ec-8fa6-c1658454480d"), "J.59.12", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("fcdc6cd8-7cd0-482f-bc87-2a87e9ad984c"), "J.59.13", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("3a3ebfc6-4448-411c-98fb-d237c3036212"), "J.59.14", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Motion picture projection activities" },
                    { new Guid("26f0ccf6-f777-492f-bbbc-a9e202dc9fac"), "J.59.2", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Sound recording and music publishing activities" },
                    { new Guid("faabf9c4-8bb4-40bf-9d15-f1a55ed3c060"), "J.59.20", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Sound recording and music publishing activities" },
                    { new Guid("2bc7fb3b-cfea-4141-95f3-e43e0eca1598"), "J.60", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Programming and broadcasting activities" },
                    { new Guid("3adbb489-7895-4cf4-83d0-833c2148cde5"), "J.60.1", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Radio broadcasting" },
                    { new Guid("c2cd3883-b2b0-4cef-9cb0-d6329d8d5691"), "J.60.10", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Radio broadcasting" },
                    { new Guid("f01ee00f-00ae-4b47-a7e4-ae682d0e761d"), "J.60.2", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Television programming and broadcasting activities" },
                    { new Guid("36dfa679-f262-4270-9e8b-d5df54698ad2"), "J.60.20", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Television programming and broadcasting activities" },
                    { new Guid("58473c0a-3771-41da-88a8-eba5b2fe655a"), "J.61", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Telecommunications" },
                    { new Guid("d74fb997-34a2-4c38-b71e-d0fa95ab64ee"), "J.61.1", new Guid("1a877449-0997-49ed-b855-28f5c4ac64f2"), "Wired telecommunications activities" },
                    { new Guid("35e8c8d6-55bf-430f-8522-5196462d0409"), "I.56.21", new Guid("792c5023-7658-4f65-a1ec-dc9513fd1667"), "Event catering activities" },
                    { new Guid("6b7732a3-e37a-4efa-98a0-8c4bc43f1669"), "K.64.92", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Other credit granting" },
                    { new Guid("dbde4521-1ac9-4227-b9a2-ad789cd83124"), "G.47.82", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("9c09e445-40a9-41a9-8a70-ec226d759ea9"), "G.47.8", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale via stalls and markets" },
                    { new Guid("06ed1760-31f4-4ec4-acda-d3d35dea6d6f"), "G.46.19", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("b4cc44ad-f163-4fc5-9841-755424379afd"), "G.46.2", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("2b4eac4b-9560-4b7a-a4a5-a98645cf02a7"), "G.46.21", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ffc358f9-47d8-485c-9b56-eefedbe5558d"), "G.46.22", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of flowers and plants" },
                    { new Guid("4b0b3bc2-20c0-47a8-8e3b-87ea6fa4177d"), "G.46.23", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of live animals" },
                    { new Guid("b48140b3-c4c8-4fc4-b279-d24350e87b46"), "G.46.24", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of hides, skins and leather" },
                    { new Guid("07dd8502-38a1-49a4-a093-1a61070ee0c0"), "G.46.3", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("8a97685f-4286-448e-8c87-7ab0bad2907e"), "G.46.31", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of fruit and vegetables" },
                    { new Guid("1d95027a-085b-447f-96dd-3de8bb3291aa"), "G.46.32", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of meat and meat products" },
                    { new Guid("538d84a5-8e88-40f3-8ae1-077136a7093f"), "G.46.33", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("249485c4-767e-4150-b294-7b72cfaaa26d"), "G.46.34", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of beverages" },
                    { new Guid("39ebad0f-7d51-477f-b02a-bcc4da630fd8"), "G.46.35", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of tobacco products" },
                    { new Guid("59b7d9b0-4034-4c24-9e90-493d3289ba81"), "G.46.18", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents specialised in the sale of other particular products" },
                    { new Guid("ac5067cb-f45c-4745-934e-54ec8950476e"), "G.46.36", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("10904f3e-857d-49fc-a440-c89777689dfa"), "G.46.38", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("9e50a727-7692-4c65-af46-934aadeb9bfb"), "G.46.39", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("28001f80-7934-4610-95d2-756c8ebe3364"), "G.46.4", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of household goods" },
                    { new Guid("7ee84500-8a62-4530-a7d9-0f59375b039d"), "G.46.41", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of textiles" },
                    { new Guid("0925a332-b72c-4f44-805c-947b505d36e3"), "G.46.42", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of clothing and footwear" },
                    { new Guid("9290225e-0677-4cae-a28a-f551b8945da5"), "G.46.43", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of electrical household appliances" },
                    { new Guid("8f538f21-cf75-4163-aa42-1bbe7b61bfe6"), "G.46.44", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("3056d27e-b864-4037-ae66-277221891b68"), "G.46.45", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of perfume and cosmetics" },
                    { new Guid("63133cea-ceb0-4253-98b6-de2385eabe2a"), "G.46.46", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of pharmaceutical goods" },
                    { new Guid("29f433dd-3d5f-4744-8bcd-f288e475b6f8"), "G.46.47", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("ee100422-c8d3-4995-84b1-4382bd7bc458"), "G.46.48", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of watches and jewellery" },
                    { new Guid("1a2ff93b-9095-48aa-b973-59509a970daf"), "G.46.49", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of other household goods" },
                    { new Guid("16bfce9b-781e-431b-ba18-182781483b93"), "G.46.37", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("ea128220-5e47-49cb-baf7-3537d6f455a9"), "G.46.17", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("073b850f-2393-420f-a25d-a7eb5a3c6f0e"), "G.46.16", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("bbaea21e-50de-43f8-a065-e085a8a08b90"), "G.46.15", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("3e0f6479-38c0-4d53-9546-741814d2fb84"), "F.43.29", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Other construction installation" },
                    { new Guid("c80efa51-bac0-410c-b378-0c58473509ba"), "F.43.3", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Building completion and finishing" },
                    { new Guid("6ca48f6a-9c86-4ae5-85e1-6e8a0607f441"), "F.43.31", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Plastering" },
                    { new Guid("af817fcf-8346-4e6a-a95e-85fddfdb4c1d"), "F.43.32", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Joinery installation" },
                    { new Guid("c503086c-042e-4deb-b144-1cb5c80519a7"), "F.43.33", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Floor and wall covering" },
                    { new Guid("5bdac1f9-7f46-46bf-b0ca-46dc984bc73d"), "F.43.34", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Painting and glazing" },
                    { new Guid("d7a587f7-e293-46e8-91f0-e143d7a6069e"), "F.43.39", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Other building completion and finishing" },
                    { new Guid("ffb200b1-84da-4064-a740-c1de625a7a6d"), "F.43.9", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Other specialised construction activities" },
                    { new Guid("df59b78b-cc61-45e4-a5ba-458105a4004c"), "F.43.91", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Roofing activities" },
                    { new Guid("b7f9a1f6-4926-4777-81f2-ceab81dba412"), "F.43.99", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Other specialised construction activities n.e.c." },
                    { new Guid("c2c330ad-6394-4d0b-b15b-371dd342e4dd"), "G.45", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("816d7f84-38e5-4d1f-a742-2758a3ec526d"), "G.45.1", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Sale of motor vehicles" },
                    { new Guid("811ae5b3-8d52-4976-8050-b76f2c11dc50"), "G.45.11", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Sale of cars and light motor vehicles" },
                    { new Guid("53883d53-73aa-4e3e-bb9c-e3377f4e175f"), "G.45.19", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Sale of other motor vehicles" },
                    { new Guid("654209ad-d9fd-45fe-998c-d29c24b95b15"), "G.45.2", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7235db9a-40c0-42f9-a099-01eadc62e08a"), "G.45.20", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Maintenance and repair of motor vehicles" },
                    { new Guid("81650c83-7bc0-42c7-9754-881edee9ef52"), "G.45.3", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("83e8d692-541f-4877-a42c-2085efdeac84"), "G.45.31", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("bb9e3e12-b493-45dc-be69-e60e9a39900b"), "G.45.32", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("3d12cfe4-1557-42c2-b9c1-219fa5904c93"), "G.45.4", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("a4987e5d-25d2-4568-8670-b1c9452be85b"), "G.45.40", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("fe39598c-db5d-43f5-a050-471df26fc7e5"), "G.46", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("b5b3013b-0c74-4fea-b93c-9c4066a691f5"), "G.46.1", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale on a fee or contract basis" },
                    { new Guid("563e3085-7fd5-4a48-98fe-9048e94060d4"), "G.46.11", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("d51f07e9-186f-429b-8c05-6d832ac84c2f"), "G.46.12", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("9404c50c-f791-4212-ac0e-4b5ef7866078"), "G.46.13", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("56077753-6bc6-476a-b02a-9ee9b5464b15"), "G.46.14", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("5229e5d4-be21-4ece-be7f-39c242470c23"), "G.46.5", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of information and communication equipment" },
                    { new Guid("28ef8e6b-24d0-498f-a56f-6caad2d5dac9"), "G.47.81", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("9b05a817-7a31-4614-be21-017bc6274e6c"), "G.46.51", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("cf9541c9-f63c-48b0-b40c-65b2e5105ce6"), "G.46.6", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("85109126-8ee0-460b-96cd-5f22c8cef285"), "G.47.4", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("f4715528-2c96-492f-9bfe-71334ea3d71a"), "G.47.41", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("69ca70ef-3c8d-4772-acc4-33849604fb06"), "G.47.42", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("30e0bf45-2137-45e6-b4eb-6c4369814fbc"), "G.47.43", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("f0e42e19-1d8f-4273-9499-0819eabe83fe"), "G.47.5", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("114c3c1b-6ccb-443a-8026-ee8399656970"), "G.47.51", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of textiles in specialised stores" },
                    { new Guid("fa09dbfe-e614-4188-a6d8-ea01bef79d4a"), "G.47.52", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("c05cb06a-e15c-4a56-ac3c-c8945192d093"), "G.47.53", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("bd97f9cc-37f4-479b-a872-c5dab0aa0b5e"), "G.47.54", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("f3a53506-2cd1-4150-827b-b2af3170b743"), "G.47.59", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("e9450a72-d0b3-46e5-8a4e-f940c6bc5a59"), "G.47.6", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("271a90cf-d668-4f85-adec-e75c9b60e71d"), "G.47.61", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of books in specialised stores" },
                    { new Guid("e20d46f7-1042-4858-bfe1-dfa217ab33ab"), "G.47.30", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("eac88cee-5019-47e9-8fad-e56832771d75"), "G.47.62", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("f08dde91-ce30-468b-b06e-802deb087849"), "G.47.64", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("1af65694-508b-4af7-804b-74c8d47e1758"), "G.47.65", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("a9304d3d-dd19-4b62-8509-14dc2905e280"), "G.47.7", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of other goods in specialised stores" },
                    { new Guid("8b3489e0-77b8-4e0c-83bd-9292938fd4fe"), "G.47.71", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of clothing in specialised stores" },
                    { new Guid("ab7303e5-9309-4053-aeb7-d4f25f5b4a29"), "G.47.72", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("c74b267a-ca6b-4f52-9010-15554da94cf2"), "G.47.73", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Dispensing chemist in specialised stores" },
                    { new Guid("93b91085-65b2-40b2-af1c-6398a6873f40"), "G.47.74", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("a64cd09e-fa21-41ae-8699-30f7c3b19f16"), "G.47.75", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("5aa6593b-3559-496c-9866-f709c994669f"), "G.47.76", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("5f740362-85d4-4474-8f05-e58d11f1e2bd"), "G.47.77", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("376ccb1b-76e6-42f0-916d-d086390d08ee"), "G.47.78", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("bf275731-5f0e-4cbe-82ed-87044d892e77"), "G.47.79", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f2f253da-2d18-4c12-9230-05e652f6cc8c"), "G.47.63", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("c7519c3b-9278-4add-900d-339485db8c01"), "G.47.3", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("bc1e7910-71b8-409a-926c-c5c7a487324b"), "G.47.29", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Other retail sale of food in specialised stores" },
                    { new Guid("315b075a-ca00-4489-9943-a95000bd640e"), "G.47.26", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("70b52dd0-6b49-4f20-88d7-9a0ce44b1674"), "G.46.61", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("340e9f79-65ee-47a7-8c4a-49186b6cc90f"), "G.46.62", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of machine tools" },
                    { new Guid("7c318621-e537-46c7-ae64-a0c02e9978da"), "G.46.63", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("d6fc981d-3369-4479-819e-a844e6a62003"), "G.46.64", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("e7e280ab-4749-4034-a7bf-379c7308c122"), "G.46.65", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of office furniture" },
                    { new Guid("3e46dbe5-14c8-43c7-958f-1e35ee9abd8a"), "G.46.66", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of other office machinery and equipment" },
                    { new Guid("0242c7e4-d014-4daf-ae2b-07cb10752434"), "G.46.69", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of other machinery and equipment" },
                    { new Guid("7b303f91-633b-40ad-964c-b4cbb1b5b048"), "G.46.7", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Other specialised wholesale" },
                    { new Guid("f1213374-29b4-48c0-905a-19d1fee16780"), "G.46.71", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("7c521a91-af5c-40ed-80fb-efb2566eb62b"), "G.46.72", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of metals and metal ores" },
                    { new Guid("db309920-598f-4dd2-8c20-a580ed52f5f7"), "G.46.73", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("e93ffff9-3f95-4b7a-b136-1554a9a964e9"), "G.46.74", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("f24ad5df-d341-47d9-bcf5-b88281eb1cbc"), "G.46.75", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of chemical products" },
                    { new Guid("9ab9b602-b150-47d9-bd5c-c1323a08a2ed"), "G.46.76", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of other intermediate products" },
                    { new Guid("edb57737-cc32-4ed7-9f90-ec67db8f1be0"), "G.46.77", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of waste and scrap" },
                    { new Guid("e8ebaa1a-372b-47b9-9264-c435fbd75d40"), "G.46.9", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Non-specialised wholesale trade" },
                    { new Guid("1804cc8c-7d67-42dd-8672-07e72322e116"), "G.46.90", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Non-specialised wholesale trade" },
                    { new Guid("67bcebcd-42a2-40ac-bebf-e8aa383f77ad"), "G.47", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("9255c87d-6a13-4c53-a99a-20b7faad511d"), "G.47.1", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale in non-specialised stores" },
                    { new Guid("fc438418-e5a9-4e06-b536-57ca6f325918"), "G.47.11", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("8cb7118f-33c4-42fe-847e-e712dd2ce461"), "G.47.19", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Other retail sale in non-specialised stores" },
                    { new Guid("bf4d9982-fac9-4249-aead-286929e41d98"), "G.47.2", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("2738b5aa-5d20-4773-90c8-985f379481ae"), "G.47.21", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("2c20f36d-be50-438b-b364-06c8d8ef1bb7"), "G.47.22", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("ce30bead-98c5-41b5-9b8c-217773b1ccd4"), "G.47.23", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("ccbe1d3a-0b4d-4114-b2b1-a19c8e245a5d"), "G.47.24", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("7684e663-c9d2-4aa3-93b9-2ea41e9b5b1b"), "G.47.25", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Retail sale of beverages in specialised stores" },
                    { new Guid("628fd067-6c48-45d4-bd95-3ee60544b01a"), "G.46.52", new Guid("a454338d-0515-423a-871f-9384c465c5e2"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("a9116036-9f43-4197-b832-ad3db8d97c0f"), "F.43.22", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("f4f4d5d8-5d95-4b4e-b6ad-7973d4aedf4f"), "K.64.99", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("96a51a89-7992-492b-b7ff-058ec4686b3d"), "K.65.1", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Insurance" },
                    { new Guid("7f438dfe-0897-4e77-88e2-e397036583af"), "P.85.6", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Educational support activities" },
                    { new Guid("a44fdb43-cf66-432e-ad8b-68188a934d28"), "P.85.60", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Educational support activities" },
                    { new Guid("16ad4e8b-dc7d-4ebe-9ab1-2db3be2e98e5"), "Q.86", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Human health activities" },
                    { new Guid("9cee34ab-24db-45e0-aaf6-777edc6012af"), "Q.86.1", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Hospital activities" },
                    { new Guid("34ba38aa-32d9-4bee-b1f9-00767fcd3bb9"), "Q.86.10", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Hospital activities" },
                    { new Guid("bfb0c500-252b-4ac7-8624-86b048073798"), "Q.86.2", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Medical and dental practice activities" },
                    { new Guid("27ce7d7a-6da7-4c37-84c2-5755d86ae6bc"), "Q.86.21", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2a12b7ae-0195-4407-a059-38de21fecfd4"), "Q.86.22", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Specialist medical practice activities" },
                    { new Guid("c76efbfb-36dd-4476-801f-e2bce66995a7"), "Q.86.23", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Dental practice activities" },
                    { new Guid("55d5b407-b933-4ed4-9e95-1bcde2d7d122"), "Q.86.9", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Other human health activities" },
                    { new Guid("9a215545-10ea-43d1-8fb0-72744bb09d18"), "Q.86.90", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Other human health activities" },
                    { new Guid("db183415-25fa-4385-ad9f-888ec7173c28"), "Q.87", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential care activities" },
                    { new Guid("78699ba3-b18a-43bc-9dce-f93cda0524a3"), "P.85.59", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Other education n.e.c." },
                    { new Guid("24af6149-ce5f-47ff-b6d9-d9ab01a69d12"), "Q.87.1", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential nursing care activities" },
                    { new Guid("d4d2492f-f8de-4f64-bb20-54a1237ab315"), "Q.87.2", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("88d545ac-f95d-462f-a27b-ea3dfefa9dc9"), "Q.87.20", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("e394e85d-d267-4014-9474-8d23fd8fc6c9"), "Q.87.3", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential care activities for the elderly and disabled" },
                    { new Guid("4a43728d-519f-402b-a67e-a968cf1afafe"), "Q.87.30", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential care activities for the elderly and disabled" },
                    { new Guid("9232989c-9ab7-4e52-8023-2682aea2fec0"), "Q.87.9", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Other residential care activities" },
                    { new Guid("7caae474-0c69-451d-9477-33b9b7da4ee7"), "Q.87.90", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Other residential care activities" },
                    { new Guid("906568d3-c6a3-42e2-8785-9f9b2b86c8f4"), "Q.88", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Social work activities without accommodation" },
                    { new Guid("bb180d03-ea27-46a7-a680-b1d9ff241eb1"), "Q.88.1", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("3bd7182a-775a-41c4-b8ab-1e3d99ba6b85"), "Q.88.10", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("f0e7bb6d-a91c-4d9e-a30a-1bc39f8a1f57"), "Q.88.9", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Other social work activities without accommodation" },
                    { new Guid("d38b3760-5f33-48f3-b24d-de126ef2d323"), "Q.88.91", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Child day-care activities" },
                    { new Guid("6c04a415-2478-463f-97c3-084b1e89e76a"), "Q.88.99", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("724e2d3d-b91e-4feb-8339-0cba6e02d0e8"), "Q.87.10", new Guid("0c3282e8-2116-4d97-8047-fb0425915f4b"), "Residential nursing care activities" },
                    { new Guid("aba87edd-8e5e-482b-b462-82d857ea8086"), "P.85.53", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Driving school activities" },
                    { new Guid("60efee88-ac11-429c-aade-8b17a0aab832"), "P.85.52", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Cultural education" },
                    { new Guid("6aecbee3-847c-42db-b90e-f07124b55389"), "P.85.51", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Sports and recreation education" },
                    { new Guid("92762102-4c9f-4e10-bb3a-6920cf196e5f"), "N.82.91", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Packaging activities" },
                    { new Guid("9313eaf4-b39e-4c1a-83e6-24390732f6da"), "N.82.99", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other business support service activities n.e.c." },
                    { new Guid("d015f3c2-07f6-4464-879f-68a4c882dee6"), "O.84", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Public administration and defence; compulsory social security" },
                    { new Guid("d9143529-36bb-4c9a-ab82-ee6c98106994"), "O.84.1", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("36d21938-dbd5-423f-a547-bfe407a352ac"), "O.84.11", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "General public administration activities" },
                    { new Guid("75c37307-9fbb-44d3-88c7-e848e6ff043a"), "O.84.12", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("b4dd03b1-1ee8-4e8b-b04c-d12d053a0631"), "O.84.13", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("ce9cb300-8ee2-4330-bff7-8a23073eca0b"), "O.84.2", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Provision of services to the community as a whole" },
                    { new Guid("e31921c4-5d02-47dd-9be4-358a46b4209b"), "O.84.21", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Foreign affairs" },
                    { new Guid("840cf5e5-3eab-492a-93fe-d8524a7997ac"), "O.84.22", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Defence activities" },
                    { new Guid("a32a1729-cc70-40c3-85f4-dd5924809647"), "O.84.23", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Justice and judicial activities" },
                    { new Guid("bb324554-67e8-417b-9e4c-d327c4ac0f7e"), "O.84.24", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Public order and safety activities" },
                    { new Guid("49b3b7ef-daa6-428c-8fe6-76843cc7742c"), "O.84.25", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Fire service activities" },
                    { new Guid("53de3378-4a39-4f92-b831-d435c14313cc"), "O.84.3", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Compulsory social security activities" },
                    { new Guid("677bddb3-474d-4472-ab40-44243640cc35"), "O.84.30", new Guid("f2c78620-65bc-4470-9df7-ca0469c58213"), "Compulsory social security activities" },
                    { new Guid("3657a5c3-5af2-4db5-a109-ec2495b673aa"), "P.85", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Education" },
                    { new Guid("b2fad8ff-b6da-4d2e-b75d-9af7f68700c1"), "P.85.1", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Pre-primary education" },
                    { new Guid("9fa20db4-6051-4dc6-a616-80d537dbf2b9"), "P.85.10", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Pre-primary education" },
                    { new Guid("00236a6a-c20b-436c-98fe-8c236a9ab6c3"), "P.85.2", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4c648fd5-0ddd-43cc-96d0-d2735f806ba9"), "P.85.20", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Primary education" },
                    { new Guid("3a5db752-dd5b-44a5-bd6a-5b45aa1bdcd0"), "P.85.3", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Secondary education" },
                    { new Guid("0fa19ba5-375e-416a-a3c8-2379fb2d96a6"), "P.85.31", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "General secondary education" },
                    { new Guid("9a378760-d268-42b6-a01a-fbbc59dfe4d1"), "P.85.32", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Technical and vocational secondary education" },
                    { new Guid("ec761817-200b-465c-82e9-f98f84ee7588"), "P.85.4", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Higher education" },
                    { new Guid("4ebd7df1-56d7-442c-8a82-fa23d288d4df"), "P.85.41", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Post-secondary non-tertiary education" },
                    { new Guid("322f901d-d4c4-4b91-ae8c-56eaf3360bf7"), "P.85.42", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Tertiary education" },
                    { new Guid("48d1330a-2731-4ff5-8338-1dfe349909af"), "P.85.5", new Guid("04ae1f36-62fb-4fa6-9b78-28f0740eb042"), "Other education" },
                    { new Guid("dc1cacd4-5120-42b5-b830-83a92dffd313"), "R.90", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Creative, arts and entertainment activities" },
                    { new Guid("a774e233-0c09-41b8-8ae8-7d0dc4ffc9a9"), "N.82.92", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("2c7a1835-1b03-4f28-97cf-cd69d825f7d0"), "R.90.0", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Creative, arts and entertainment activities" },
                    { new Guid("007376fe-3d7a-4ca4-8ffd-730ab3af4744"), "R.90.02", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Support activities to performing arts" },
                    { new Guid("d82bed17-f24b-4a69-a680-78ba94290124"), "S.95.1", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of computers and communication equipment" },
                    { new Guid("8da95bca-40c6-43ff-bece-52629be0eff7"), "S.95.11", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of computers and peripheral equipment" },
                    { new Guid("022885f3-732a-4f9d-adf6-7f2b51c546fd"), "S.95.12", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of communication equipment" },
                    { new Guid("04f523c3-eeff-48d0-aea5-ab5a372d6f40"), "S.95.2", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of personal and household goods" },
                    { new Guid("31d2cbbb-cc9f-4c83-9557-16f6ef4543f4"), "S.95.21", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of consumer electronics" },
                    { new Guid("ccc018f4-016a-4174-a9dd-6f05e9c011af"), "S.95.22", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("08e85de5-da0d-4044-921f-1080af5fe5d9"), "S.95.23", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of footwear and leather goods" },
                    { new Guid("7f629e5b-b18b-4de6-8ff3-07e48aa02aa3"), "S.95.24", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of furniture and home furnishings" },
                    { new Guid("618ad5c3-6c67-4ede-b9f5-75b5390d1269"), "S.95.25", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of watches, clocks and jewellery" },
                    { new Guid("7809aacd-8410-4b04-84bb-efb3dc5a6c63"), "S.95.29", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of other personal and household goods" },
                    { new Guid("dd00c9b1-f071-4c26-b8ca-87f647d6839e"), "S.96", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Other personal service activities" },
                    { new Guid("05c92a8a-49cc-4a9e-b495-321eaa0cab7a"), "S.96.0", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Other personal service activities" },
                    { new Guid("8ad62c2f-3752-4fe7-8270-369da83ecd1f"), "S.95", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Repair of computers and personal and household goods" },
                    { new Guid("46ec0b6e-e96b-4a28-82ce-9de9276c35d4"), "S.96.01", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("34fc5de9-b927-4a3f-8775-e0e597361385"), "S.96.03", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Funeral and related activities" },
                    { new Guid("1c315c16-6167-4dd0-a437-0c7a09f1cf1b"), "S.96.04", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Physical well-being activities" },
                    { new Guid("acbcb65d-a73a-40cd-b561-39cf6e18b6e6"), "S.96.09", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Other personal service activities n.e.c." },
                    { new Guid("d6d76a87-81d1-46b9-b706-9aa9f873df7d"), "T.97", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Activities of households as employers of domestic personnel" },
                    { new Guid("313a8505-19a4-4d78-90a9-f8161d323f55"), "T.97.0", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Activities of households as employers of domestic personnel" },
                    { new Guid("09bcec0c-9e35-4d96-ab9b-71b9064b69a8"), "T.97.00", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Activities of households as employers of domestic personnel" },
                    { new Guid("11248e90-fd01-41ef-86bb-4b35a4e509f6"), "T.98", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("4e16fc61-2d7c-446b-a154-a436976e61bb"), "T.98.1", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("2b48918e-8d26-4679-a2a6-9f41ecb3fb85"), "T.98.10", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("ea1745d1-d6af-4a3a-81c2-7b88f37334d7"), "T.98.2", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("170c43ec-ba6f-42d9-a6ff-35ba32a73594"), "T.98.20", new Guid("21f741e7-ad4d-4f2f-96a5-0e6d457e9e4e"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("7c8055ca-302f-4022-ae0a-b553b8fe4b7b"), "U.99", new Guid("087a323a-af69-4a81-8966-4689327a8cd5"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("aba93058-eaa8-4f53-bf53-8a42ab05562e"), "S.96.02", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Hairdressing and other beauty treatment" },
                    { new Guid("25fc3ac4-ef74-47a0-9f03-a6ae819e89dc"), "S.94.99", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of other membership organisations n.e.c." },
                    { new Guid("83f3b45d-6048-4bd9-8583-5c2b2708870b"), "S.94.92", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of political organisations" },
                    { new Guid("271c03b4-596b-4261-911b-9d486f67dd96"), "S.94.91", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5a126606-e57f-4bc2-9129-634b782cbe80"), "R.90.03", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Artistic creation" },
                    { new Guid("e593531c-d55c-4561-ba82-2d00a0401b7b"), "R.90.04", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Operation of arts facilities" },
                    { new Guid("c37a7704-cf60-4821-839e-27cd919ad2e8"), "R.91", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("ec17dcb8-3d3b-4f53-9e3e-bf4ae1187c99"), "R.91.0", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("3f7c0ff7-6dd1-4ff6-88ba-0acc7bc3acfb"), "R.91.01", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Library and archives activities" },
                    { new Guid("b6faa3ff-070b-401f-a562-bbafd43e113c"), "R.91.02", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Museums activities" },
                    { new Guid("596bd7a5-82f1-416e-8d39-cd4cf3df68f6"), "R.91.03", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("45ee4b6c-1ec7-42a4-92ad-b206df221832"), "R.91.04", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("cce1beaa-533e-42f4-afce-d5cc5b6f4a2d"), "R.92", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Gambling and betting activities" },
                    { new Guid("dc9b5cb9-7e49-494c-bf3a-6b8d2a6d25f3"), "R.92.0", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Gambling and betting activities" },
                    { new Guid("fee15fcb-df58-4165-a66e-ab3a5f3f79e2"), "R.92.00", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Gambling and betting activities" },
                    { new Guid("5d090b57-2ba0-4bbc-9431-bec8354523b0"), "R.93", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Sports activities and amusement and recreation activities" },
                    { new Guid("74b6598b-c58e-4eb7-95da-847bc0a8f886"), "R.93.1", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Sports activities" },
                    { new Guid("de79812c-fbb9-4761-ad74-8aaf2e746734"), "R.93.11", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Operation of sports facilities" },
                    { new Guid("0be40d37-0a26-40aa-a8f6-6bd66d1cafb4"), "R.93.12", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Activities of sport clubs" },
                    { new Guid("33c8bec9-6275-4387-a2a7-df9556aa972a"), "R.93.13", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Fitness facilities" },
                    { new Guid("a7d5655b-88aa-447e-a298-77bf1e9449dc"), "R.93.19", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Other sports activities" },
                    { new Guid("e0925b27-cf2a-4080-b8f5-b7c372e0065a"), "R.93.2", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Amusement and recreation activities" },
                    { new Guid("a6c44a2d-f661-4637-9568-e46ca22bd4ad"), "R.93.21", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Activities of amusement parks and theme parks" },
                    { new Guid("d496a256-938f-4ed2-b006-a3ed913da511"), "R.93.29", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Other amusement and recreation activities" },
                    { new Guid("8817fc26-29d2-4836-89af-41240d7d5ab1"), "S.94", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of membership organisations" },
                    { new Guid("f15c298c-da79-4dc6-933a-a374ac3b78f5"), "S.94.1", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("535f6dc6-935f-45aa-bea2-5e0f9a31de97"), "S.94.11", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of business and employers membership organisations" },
                    { new Guid("94acf8ea-d04c-4c9d-aaca-76d4e67f0d47"), "S.94.12", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of professional membership organisations" },
                    { new Guid("a6783a68-218e-44d9-922f-c14cb27c397e"), "S.94.2", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of trade unions" },
                    { new Guid("f877e8c1-a54d-40fd-87c1-e840d70ef487"), "S.94.20", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of trade unions" },
                    { new Guid("09093305-79aa-4b73-953b-a4b5ad70dc7c"), "S.94.9", new Guid("d1757e05-4a50-4fa5-b008-ca2fae98ecff"), "Activities of other membership organisations" },
                    { new Guid("c663d412-1230-4a09-b621-097964195bf1"), "R.90.01", new Guid("0c4568f3-997f-4677-af82-a69c1058e1e7"), "Performing arts" },
                    { new Guid("b627e005-d8b6-4deb-939a-552526f4bdd1"), "K.65", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("d1d15a5b-6ed0-4d69-8644-599fddbbd081"), "N.82.9", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Business support service activities n.e.c." },
                    { new Guid("1fa5ef6d-9002-4bc8-845a-05371e1a938e"), "N.82.3", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Organisation of conventions and trade shows" },
                    { new Guid("71081126-4bf0-4891-b71d-b19e1ce2c91c"), "M.70.1", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Activities of head offices" },
                    { new Guid("3ea23e63-3f94-4f37-92f2-9f47ab8a421c"), "M.70.10", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Activities of head offices" },
                    { new Guid("c1efc62e-e8a0-4967-a950-788d470f1f85"), "M.70.2", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Management consultancy activities" },
                    { new Guid("18fa736f-828c-4b61-8fff-301179823131"), "M.70.21", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Public relations and communication activities" },
                    { new Guid("48dfb2ea-c464-418a-abcb-17ab8a97f31c"), "M.70.22", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Business and other management consultancy activities" },
                    { new Guid("6c09bcaa-cbdb-4590-8e16-1b1ef8fe17ca"), "M.71", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("599999b9-4d71-4cb0-8621-19b01fe9ba02"), "M.71.1", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("9a5f3f57-d771-4818-af7c-f0bf30b209fe"), "M.71.11", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Architectural activities" },
                    { new Guid("0ed7d4fe-edd2-4d04-b3bb-1ebbc1269d07"), "M.71.12", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Engineering activities and related technical consultancy" },
                    { new Guid("11d14159-8895-4f2f-a04b-e0e35a335c3f"), "M.71.2", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Technical testing and analysis" },
                    { new Guid("7119a202-28da-4fa3-8010-6cbe53532866"), "M.71.20", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("03e54c3b-cfe7-4098-ad78-0b65b386341c"), "M.72", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Scientific research and development" },
                    { new Guid("d2527dfd-fd38-46c1-b3d6-2d64617051dd"), "M.70", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Activities of head offices; management consultancy activities" },
                    { new Guid("17f60328-1aec-4a5d-a974-e456d6371d83"), "M.72.1", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("2daa03c9-23df-4fef-b3a7-6044b4ea832e"), "M.72.19", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("8d67f21e-6e32-4667-bfd3-317fc512574c"), "M.72.2", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("d70299d2-ed07-461b-8430-af82e1e85a9d"), "M.72.20", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("dcda2265-b31b-4bcd-b7c6-bc887054cbd4"), "M.73", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Advertising and market research" },
                    { new Guid("c80c4e78-3f59-4946-a793-f373027e275b"), "M.73.1", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Advertising" },
                    { new Guid("4ea592df-9ca0-4bef-8cb0-a2490b6b82d3"), "M.73.11", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Advertising agencies" },
                    { new Guid("5ea30838-746c-4a48-831c-81b52018271c"), "M.73.12", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Media representation" },
                    { new Guid("74d50e27-0291-42c5-9b40-50b0503acfc2"), "M.73.2", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Market research and public opinion polling" },
                    { new Guid("ce0ef4fc-4b2b-46c9-a936-805197349ba7"), "M.73.20", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Market research and public opinion polling" },
                    { new Guid("c0979ec6-a30a-4b89-9ddd-2deb77f83878"), "M.74", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Other professional, scientific and technical activities" },
                    { new Guid("f49fa6ec-3489-4b50-8b39-6e83bc2b1b86"), "M.74.1", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Specialised design activities" },
                    { new Guid("48f5a30b-4c49-41f6-b875-7c33d61c36ac"), "M.74.10", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Specialised design activities" },
                    { new Guid("ca11624e-7994-42cd-86e7-b1a31453f77e"), "M.72.11", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Research and experimental development on biotechnology" },
                    { new Guid("df1fd522-940e-49db-9504-f8502a36ce25"), "M.69.20", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("cb68ee13-4261-43b1-905d-07f4aaba4eb6"), "M.69.2", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("87083207-8930-4e93-9a7d-a9ebe78e6267"), "M.69.10", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Legal activities" },
                    { new Guid("42c299af-21bf-4b03-8460-b8b47aad593c"), "K.65.11", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Life insurance" },
                    { new Guid("4b2e9754-a4a1-4e1c-a761-78607bf3cd54"), "K.65.12", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Non-life insurance" },
                    { new Guid("31e91a65-35e9-4227-997d-11c4dfd8fe1c"), "K.65.2", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Reinsurance" },
                    { new Guid("5413f1a1-ccc6-4abb-8b04-1a9800c9395e"), "K.65.20", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Reinsurance" },
                    { new Guid("91dd30c5-1ee3-4dd9-8707-1e75c49db8d4"), "K.65.3", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Pension funding" },
                    { new Guid("273ae248-f0f4-4177-95dd-3d83d9945925"), "K.65.30", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Pension funding" },
                    { new Guid("d5aabe72-6289-407a-8b9f-2703c3c56da5"), "K.66", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("930a69df-62ce-4f14-bc9e-3f35268b49fc"), "K.66.1", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("84101c3b-c5eb-44a6-813a-7b94af9628b2"), "K.66.11", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Administration of financial markets" },
                    { new Guid("00803dd6-8f42-473e-b55e-5b1370e8e8f0"), "K.66.12", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Security and commodity contracts brokerage" },
                    { new Guid("3755c0b7-e661-43fe-92eb-dd5a9c3a63b4"), "K.66.19", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("83136ace-fa11-45f3-b845-c41149ab3d9b"), "K.66.2", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("d1e90839-1b8b-432d-8a90-6a5870280cd5"), "K.66.21", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Risk and damage evaluation" },
                    { new Guid("383c1929-a4d3-4aac-9312-cb2abf3047e4"), "K.66.22", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Activities of insurance agents and brokers" },
                    { new Guid("c6a1d73f-f7d1-4ea2-9cbf-cdc204a58e42"), "K.66.29", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("3493d354-7984-4850-84f0-38c435cc85e9"), "K.66.3", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Fund management activities" },
                    { new Guid("b86509f9-a651-4bb0-bd23-44cd9ab7f0a7"), "K.66.30", new Guid("b1630a59-7a93-4531-8df9-4f42c1bc9970"), "Fund management activities" },
                    { new Guid("77acc525-c418-4ed2-b421-2bbe235aee4e"), "L.68", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Real estate activities" },
                    { new Guid("e79a7174-74b9-454e-a50f-024f10bbea8b"), "L.68.1", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Buying and selling of own real estate" },
                    { new Guid("d384a9fc-e10d-47a3-be79-3b7205860ca5"), "L.68.10", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Buying and selling of own real estate" },
                    { new Guid("7b8bcb94-5bad-416d-9687-5850644b3c9e"), "L.68.2", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Renting and operating of own or leased real estate" },
                    { new Guid("768a70f0-4cc2-48f8-95ef-86490f06a3d7"), "L.68.20", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Renting and operating of own or leased real estate" },
                    { new Guid("0d192ef5-9000-421e-a73f-ea4c89f89584"), "L.68.3", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f876bf92-b7b4-4942-9924-2a30d2315ed4"), "L.68.31", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Real estate agencies" },
                    { new Guid("4f6cd5ab-7625-44cc-b6c0-fb6e14c95d89"), "L.68.32", new Guid("cb18c817-d618-4807-9686-add81de4abaa"), "Management of real estate on a fee or contract basis" },
                    { new Guid("2415a2fa-25bb-4bfd-9ad4-2386f3edadfd"), "M.69", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Legal and accounting activities" },
                    { new Guid("6b324ea2-b269-4e57-815d-ff3b2f55b18b"), "M.69.1", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Legal activities" },
                    { new Guid("3487189c-dbf3-42c8-8e48-3fba5b1ab779"), "M.74.2", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Photographic activities" },
                    { new Guid("9d47e81a-0615-4454-a2b1-45d95430d455"), "N.82.30", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Organisation of conventions and trade shows" },
                    { new Guid("03d6bab4-e94e-4d93-90bb-8bb8d5392e68"), "M.74.20", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Photographic activities" },
                    { new Guid("61125793-f573-4ba6-b4cc-545e05292bc3"), "M.74.30", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Translation and interpretation activities" },
                    { new Guid("67c457e6-7138-4bb4-9188-ef81441ed039"), "N.79.11", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Travel agency activities" },
                    { new Guid("ae54e3a7-bbfa-4a5e-8ad4-4d5517b07ebd"), "N.79.12", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Tour operator activities" },
                    { new Guid("20f92442-3686-409d-a756-ebefc8cc824d"), "N.79.9", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other reservation service and related activities" },
                    { new Guid("56b78dd8-c06d-4199-8f22-a54ae7324f93"), "N.79.90", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other reservation service and related activities" },
                    { new Guid("579bcffb-a980-4cf7-b488-edfbf5884b91"), "N.80", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Security and investigation activities" },
                    { new Guid("61b3aa84-0128-4ca7-aca0-8f191cec0b5a"), "N.80.1", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Private security activities" },
                    { new Guid("427fac6e-4159-40c0-a7f6-4781d5656a36"), "N.80.10", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Private security activities" },
                    { new Guid("69ba404f-6f7f-448b-87d0-a403de8dd11d"), "N.80.2", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Security systems service activities" },
                    { new Guid("255ae4af-ce79-4b67-8e38-d585cb2940c7"), "N.80.20", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Security systems service activities" },
                    { new Guid("8bb1330f-44c0-47fc-99fd-bf3937c7539f"), "N.80.3", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Investigation activities" },
                    { new Guid("c1eddc92-f655-441b-8c6c-f13ba38aa338"), "N.80.30", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Investigation activities" },
                    { new Guid("f4d30c4a-2ec3-4166-b22c-37a147db3dbb"), "N.81", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Services to buildings and landscape activities" },
                    { new Guid("f7d2094a-fc7d-4909-8e1b-885433f5106d"), "N.79.1", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Travel agency and tour operator activities" },
                    { new Guid("3ed0ef83-2a81-4beb-8bc0-b6f447d28dd2"), "N.81.1", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Combined facilities support activities" },
                    { new Guid("bb0833ac-a118-4c2f-a965-b91f46fc1a8c"), "N.81.2", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Cleaning activities" },
                    { new Guid("ae244591-376d-430b-b1d6-ede59b4f4bbb"), "N.81.21", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "General cleaning of buildings" },
                    { new Guid("d91e1fdc-65f4-4a28-8453-ac47501ea3f8"), "N.81.22", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other building and industrial cleaning activities" },
                    { new Guid("389620ca-d09d-4cf9-beaf-d946eb307034"), "N.81.29", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other cleaning activities" },
                    { new Guid("ddc8b842-c1b1-409f-81dd-273e5f2b2d29"), "N.81.3", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Landscape service activities" },
                    { new Guid("4e5f9047-cc9a-486e-a39a-28fefe50c491"), "N.81.30", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Landscape service activities" },
                    { new Guid("d9c56934-121f-40a7-a184-094976711a0a"), "N.82", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Office administrative, office support and other business support activities" },
                    { new Guid("2851aab1-009f-4c7d-97c1-0e22611a2e69"), "N.82.1", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Office administrative and support activities" },
                    { new Guid("fb0130fd-561d-4f9f-a6ee-62f7b5e9ad97"), "N.82.11", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Combined office administrative service activities" },
                    { new Guid("2c7fde0d-6ae2-4b62-ac67-0a3a1fe89efb"), "N.82.19", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("046880b1-af2e-4e49-a576-612852929240"), "N.82.2", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Activities of call centres" },
                    { new Guid("821910a0-0b96-4761-bbb2-09d6e27d76b3"), "N.82.20", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Activities of call centres" },
                    { new Guid("49362f79-72b0-4ee1-a3ec-725f9716d65f"), "N.81.10", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Combined facilities support activities" },
                    { new Guid("c218cfc8-5c5e-4ec7-ae1e-1815ad74f794"), "N.79", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("6eb21edd-57e7-4e70-8d3b-3c3c1a58a624"), "N.78.30", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other human resources provision" },
                    { new Guid("474a2391-246f-4ea1-867a-62ec49cc47dd"), "N.78.3", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Other human resources provision" },
                    { new Guid("b0869b0a-1b21-4ca6-8f51-f4ee4a89a6b3"), "M.74.9", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("e7ecc654-12da-4cd5-a643-16b5088c7ee5"), "M.74.90", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("f463124e-4678-42c1-a02a-d4ba2c9c523d"), "M.75", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Veterinary activities" },
                    { new Guid("57039974-c869-4483-b22e-94ddac19866c"), "M.75.0", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1ba8d152-eaf2-4a6d-baac-8e67743cf5e1"), "M.75.00", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Veterinary activities" },
                    { new Guid("7bde26a2-130d-4ca4-833a-323e500e2deb"), "N.77", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Rental and leasing activities" },
                    { new Guid("b27f40b1-2286-4cff-91f2-651c48818c2d"), "N.77.1", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of motor vehicles" },
                    { new Guid("ed62b440-be97-4faa-b4b9-462c26bf7dee"), "N.77.11", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("4624807a-533d-4328-afb4-6421010f64bb"), "N.77.12", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of trucks" },
                    { new Guid("2e18b206-2f6c-468e-a1e7-90745cea6d8c"), "N.77.2", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of personal and household goods" },
                    { new Guid("23c12fa8-f7a4-45bd-92bf-14d787ed8138"), "N.77.21", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("a92efbac-ef04-4176-85f9-fde8850250df"), "N.77.22", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting of video tapes and disks" },
                    { new Guid("c9119932-ffd5-4baf-8502-031f0ef581fe"), "N.77.29", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of other personal and household goods" },
                    { new Guid("c8c9b8ef-f447-44e6-947b-e227984ac3f0"), "N.77.3", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("7c046907-606a-4b5f-a493-37aeb529d86d"), "N.77.31", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("4512be74-1ace-4cea-b3d6-cd006824e1d1"), "N.77.32", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("9d6b11fa-a723-48eb-9444-74e32c8352a0"), "N.77.33", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("3d662ec0-a57f-46d8-a1db-abffebd58801"), "N.77.34", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of water transport equipment" },
                    { new Guid("962a1004-7b76-4c63-9d67-11489aec2e0e"), "N.77.35", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of air transport equipment" },
                    { new Guid("c67029ec-b5f9-47cb-be3b-5f8513cc0961"), "N.77.39", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("b0d359ed-0fc3-4218-8ae8-d080e78c5661"), "N.77.4", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("7594b3b9-f540-4411-a837-cda546aa12f5"), "N.77.40", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("27de7fd5-c8d0-4278-8ac1-04d0a71bf22e"), "N.78", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Employment activities" },
                    { new Guid("7b3ab07e-fdd7-4899-b720-3986a20f53d8"), "N.78.1", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Activities of employment placement agencies" },
                    { new Guid("934c2f57-56c4-4d33-bc21-e0e044fdedef"), "N.78.10", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Activities of employment placement agencies" },
                    { new Guid("7c434f02-b13f-4703-930d-11f30b4d32ac"), "N.78.2", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Temporary employment agency activities" },
                    { new Guid("f3294ba0-3865-4bf9-85d8-68aebdf507ec"), "N.78.20", new Guid("b4b9fa94-9fa2-49f4-8950-442aa82424ea"), "Temporary employment agency activities" },
                    { new Guid("d37c03a9-7427-40e4-b6b4-4acfc89d4c32"), "M.74.3", new Guid("dd830316-2c68-4842-b332-bbde008f64b3"), "Translation and interpretation activities" },
                    { new Guid("338c884c-b9f0-4386-9359-879d835cc042"), "U.99.0", new Guid("087a323a-af69-4a81-8966-4689327a8cd5"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("0e27a4f0-2375-4081-be84-c6218ca9da2e"), "F.43.21", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Electrical installation" },
                    { new Guid("a1078beb-452f-4063-bd67-dc8b9649a866"), "F.43.13", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Test drilling and boring" },
                    { new Guid("ea428116-b3cc-4981-a844-1ba50648484f"), "C.14.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of articles of fur" },
                    { new Guid("be2e3384-5dd7-4d78-a7a8-97ab62b9fbcd"), "C.14.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of articles of fur" },
                    { new Guid("d001d1ab-0171-44aa-9907-9cc3cf5f9850"), "C.14.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("4d526722-8bf6-4a61-b411-5a9a4abdf2d1"), "C.14.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("f9a9dbb1-41dd-4d9d-be7c-4ac00ce884a2"), "C.14.39", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("f25006a8-3f4b-4260-bd97-84ac6c209cc4"), "C.15", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of leather and related products" },
                    { new Guid("90bd4ca6-7b56-4eda-800d-2ecf091b5078"), "C.15.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("63e879e1-8a09-42cb-af33-bf29fa7b557f"), "C.15.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("3e060917-9e28-4209-b66f-f84c658c4a3c"), "C.15.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("4b7383fb-c5c5-47c4-940f-f331419276a6"), "C.15.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of footwear" },
                    { new Guid("2b00ff53-a1f8-4638-b3ef-7ae2f1adcfdf"), "C.15.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of footwear" },
                    { new Guid("3b00be56-ff3b-482e-9583-b836da504cd0"), "C.16", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("220c8465-391e-4319-8600-afbfdafcc0d7"), "C.14.19", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("76bfc321-ed92-4c81-a652-642eba7c25d6"), "C.16.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Sawmilling and planing of wood" },
                    { new Guid("c24c111b-85bc-4a67-8f14-9a296ab77723"), "C.16.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3e905144-9460-4cad-81b4-1857777e510d"), "C.16.21", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("f3fbdbb9-9277-4bf1-b90b-fd526be234b6"), "C.16.22", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of assembled parquet floors" },
                    { new Guid("6b7df093-7f0d-47b4-a0ba-00b74b9d1de6"), "C.16.23", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("6112cf0e-7b42-4bce-a721-4afe28ef79ed"), "C.16.24", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wooden containers" },
                    { new Guid("593c7f64-c848-46a7-acae-7bbf4791186a"), "C.16.29", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("5c84c71f-6c04-4430-b8ce-c697d89ec3c0"), "C.17", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of paper and paper products" },
                    { new Guid("cb5f00da-35e0-4f95-ab05-ee141371d7bd"), "C.17.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("f35aee54-2581-4513-8faf-615f3808e2c6"), "C.17.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of pulp" },
                    { new Guid("e778fb12-1fee-4d68-add7-140e65fa1528"), "C.17.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of paper and paperboard" },
                    { new Guid("676d325a-f597-4986-97cf-f034b404834d"), "C.17.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("cfa625a4-bc05-4124-b5ad-d50f4d8ce623"), "C.17.21", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("bac60230-2706-4526-9cbc-ae0a62dc7ef2"), "C.16.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Sawmilling and planing of wood" },
                    { new Guid("6383fc38-8c6d-4979-a442-757ba1463009"), "C.14.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of underwear" },
                    { new Guid("2f41f972-295a-47cf-990a-ed4ff0bec187"), "C.14.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other outerwear" },
                    { new Guid("8fba5075-aa96-41f4-b4b1-a0d2c7e208f7"), "C.14.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of workwear" },
                    { new Guid("50149d8d-9d93-4310-8038-0e5950292fa9"), "C.11.02", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wine from grape" },
                    { new Guid("ce645168-10ac-4040-ada2-7bc1cba732f0"), "C.11.03", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cider and other fruit wines" },
                    { new Guid("4eee822c-3dfc-4311-9104-952d60ea7953"), "C.11.04", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("7bb699e8-74c5-4fbe-903a-7032dd7a2ed8"), "C.11.05", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of beer" },
                    { new Guid("61fd762c-c4eb-4e18-b6e0-eb100440a3af"), "C.11.06", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of malt" },
                    { new Guid("5f412c7f-7b9f-4c51-af64-35d9b4aa0ae8"), "C.11.07", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("2bde658b-325d-4f9e-8d24-412ee227dcef"), "C.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tobacco products" },
                    { new Guid("06ff630b-d9c1-4be7-a31f-a7a6f7e382f8"), "C.12.0", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tobacco products" },
                    { new Guid("146331b7-ae77-4af1-942d-f810242b065b"), "C.12.00", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tobacco products" },
                    { new Guid("b827701b-21d3-487e-ad09-c019247893f7"), "C.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of textiles" },
                    { new Guid("c5c87fca-0fd1-4450-ae17-041348a884ec"), "C.13.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Preparation and spinning of textile fibres" },
                    { new Guid("bd17d557-0904-4d8e-9fc2-912bea36f8c5"), "C.13.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Preparation and spinning of textile fibres" },
                    { new Guid("bf01bff8-6a17-41e9-a6f5-99a53f1d05e8"), "C.13.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Weaving of textiles" },
                    { new Guid("81e2a2e4-df6f-4f03-ab66-a2f0aed89342"), "C.13.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Weaving of textiles" },
                    { new Guid("76580912-e04d-49b2-9825-30de5cb19641"), "C.13.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Finishing of textiles" },
                    { new Guid("c70c84d8-b0c2-4c5e-8f07-4c5745ab8daa"), "C.13.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Finishing of textiles" },
                    { new Guid("1474c6b1-e816-4d94-89f2-4e75b91a0013"), "C.13.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other textiles" },
                    { new Guid("4d99985b-9e9e-421e-aedf-bc6874f2289f"), "C.13.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("4e89dfad-2787-47d3-95ab-1c76318f511d"), "C.13.92", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("6336e4c9-2888-4546-9392-6f8b39a63955"), "C.13.93", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of carpets and rugs" },
                    { new Guid("a202a015-243d-4bd7-b8ea-b8dabb9d90f4"), "C.13.94", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("87e42e02-a5a3-420d-a04a-ad1991b75f16"), "C.13.95", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("73567907-03bc-4302-99a7-db0ad50ff357"), "C.13.96", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("7fcd85b1-1fbd-4c70-8637-5804dbc618b1"), "C.13.99", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other textiles n.e.c." },
                    { new Guid("445f98ea-041b-4891-882c-517d45ae339f"), "C.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wearing apparel" },
                    { new Guid("6188df9b-d389-4ebc-bed3-889af714dcb4"), "C.14.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("00b618d9-fcf3-438f-9ed9-3057e2578f73"), "C.14.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("69503b56-4189-443a-aec1-f7018129d758"), "C.17.22", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("7b853ee3-200b-46ce-b701-785750d9a224"), "C.11.01", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("bf7aa69d-8d27-4d37-b281-93dce3fe9b40"), "C.17.23", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of paper stationery" },
                    { new Guid("fde42f3b-9085-4798-bed6-7e80b63f6f0c"), "C.17.29", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("e7b01e8a-9ef0-4a7b-ac25-c06424d6d7f2"), "C.20.52", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of glues" },
                    { new Guid("ad285f28-d34b-41be-8116-fc4d890f2185"), "C.20.53", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of essential oils" },
                    { new Guid("38631746-3510-4bac-8742-2b04eb5e38a3"), "C.20.59", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("c497df35-e701-459c-b8b5-8a1c970c7244"), "C.20.6", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of man-made fibres" },
                    { new Guid("3ba7a183-8e8e-417d-a0ab-75db8327becc"), "C.20.60", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of man-made fibres" },
                    { new Guid("3bedb598-47cd-4ac0-ae6a-5347c24eb3b3"), "C.21", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("b9bbd745-c2f3-4cbe-a0c1-748601feec39"), "C.21.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("f46d232f-6810-48d2-a04e-f9445dbb390b"), "C.21.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("917b4637-8b0c-4a9b-b123-f6ab3221e4bc"), "C.21.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("012b489f-c434-450e-9e9a-7d4cf8169544"), "C.21.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("e2524b03-bb9b-4194-8473-77c1a0066a10"), "C.22", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of rubber and plastic products" },
                    { new Guid("bbe5ebc1-702a-4ec4-89c4-670571f5d8d8"), "C.22.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of rubber products" },
                    { new Guid("a4eddb10-fcb5-4472-9945-6da5ee913e93"), "C.20.51", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of explosives" },
                    { new Guid("7cc0ca87-93c1-4b6e-bc3d-aeb4af3f47ab"), "C.22.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("a75fac70-d093-49ac-b8f6-6f3ee3e5dd54"), "C.22.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of plastics products" },
                    { new Guid("f86805a5-d5ee-44e6-a925-91c492be9749"), "C.22.21", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("c00d37d9-e99d-49bc-8d6d-8e0d57792984"), "C.22.22", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of plastic packing goods" },
                    { new Guid("48a83eda-b7ef-4da4-bbb3-28dee868636a"), "C.22.23", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("f88913af-acef-449b-8c53-ad82e70f3000"), "C.22.29", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other plastic products" },
                    { new Guid("2c60d486-4fe4-4cb6-a170-2c6ed6b3938a"), "C.23", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("d451bfbc-6448-4903-9c0a-42b206c5467a"), "C.23.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of glass and glass products" },
                    { new Guid("0689bfc5-bb33-45af-9caa-1003d1460f45"), "C.23.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of flat glass" },
                    { new Guid("5ab42077-0adc-47d5-9c8f-0405869ed78b"), "C.23.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Shaping and processing of flat glass" },
                    { new Guid("5f96b740-78d4-482c-853e-bf47db1fba55"), "C.23.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of hollow glass" },
                    { new Guid("833c963d-6ee9-4abb-ab74-8b8e2519ee7e"), "C.23.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of glass fibres" },
                    { new Guid("c6f3fc00-a6f0-4864-bf0d-410e04014a10"), "C.23.19", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("eafac447-1cf9-4ff2-a1be-de7ebeda82b9"), "C.22.19", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other rubber products" },
                    { new Guid("9f684ca0-fa6b-472d-a613-f3c6ac39dc27"), "C.20.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other chemical products" },
                    { new Guid("4971a47f-916f-4b14-8e3e-42cbac8badc6"), "C.20.42", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("7bf4ca53-2050-4042-b334-52b35939479a"), "C.20.41", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("a92112eb-8232-4cdc-a14c-4937c434253a"), "C.18", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Printing and reproduction of recorded media" },
                    { new Guid("286dd419-daa7-492e-9bec-5c92299082da"), "C.18.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Printing and service activities related to printing" },
                    { new Guid("af826a2c-755b-4dbe-a134-145fa6b41c5a"), "C.18.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Printing of newspapers" },
                    { new Guid("0930c5ee-0f8e-4ab9-b730-a4897592b7fa"), "C.18.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Other printing" },
                    { new Guid("d8753b25-bc98-4739-a351-63ac1490551b"), "C.18.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Pre-press and pre-media services" },
                    { new Guid("e2bc5ad4-634c-461e-ae23-086314aa150c"), "C.18.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Binding and related services" },
                    { new Guid("03666477-25e8-4d4a-ac19-55dbed3df414"), "C.18.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Reproduction of recorded media" },
                    { new Guid("bb3a58bb-f654-4634-a5ed-ecab1e703134"), "C.18.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6b1f5874-e7df-4af8-bcc9-7481c7633535"), "C.19", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("e35e1e5c-a84a-483c-9002-c10f6893b266"), "C.19.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of coke oven products" },
                    { new Guid("6efd4cae-8dbc-447b-bec7-f944f9a361f9"), "C.19.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of coke oven products" },
                    { new Guid("90d2f6ed-864a-40a8-9e37-4152a033503e"), "C.19.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of refined petroleum products" },
                    { new Guid("70bea4da-ed0e-426c-826a-aff0ad42adea"), "C.19.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of refined petroleum products" },
                    { new Guid("13fb1cee-e9a6-4c95-8fae-266cca67c668"), "C.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of chemicals and chemical products" },
                    { new Guid("be0eebfa-d9e8-48e4-865b-bb2a9863019d"), "C.20.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("dafafbfb-ea0a-4b77-8c1f-3b591b6ef44d"), "C.20.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of industrial gases" },
                    { new Guid("5b2adcb1-bf72-42cd-a981-ba593405d25e"), "C.20.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of dyes and pigments" },
                    { new Guid("2b33eadb-5a11-46a5-a80e-13e9cfc7aa82"), "C.20.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("9bf1ef69-36de-4deb-bf33-49514941f192"), "C.20.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other organic basic chemicals" },
                    { new Guid("a73f0865-a17e-4536-b466-510efd7f16cf"), "C.20.15", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("d95cff85-b30a-4bab-94e9-e018a55199f3"), "C.20.16", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of plastics in primary forms" },
                    { new Guid("3ad37c09-d364-4849-9e89-bd695c10b3b5"), "C.20.17", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("f7febd94-88db-43ac-9dde-a94515eca028"), "C.20.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("b2a6e5ea-7853-4f7a-9a74-bb043caf619e"), "C.20.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("4435d382-bf89-4685-af9f-8965b3d5177d"), "C.20.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("2cf2d499-df32-4057-8c2e-6c42ea77a17b"), "C.20.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("8611c0fb-009d-4017-abd2-5f5eed410d76"), "C.20.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("bd939985-a333-4e78-a781-2dd43bf5b740"), "C.17.24", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wallpaper" },
                    { new Guid("159f1d8e-bec1-41e9-b1ab-39541fd195fb"), "C.23.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of refractory products" },
                    { new Guid("02396ac1-bf64-4992-8738-076cb9b44185"), "C.11.0", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of beverages" },
                    { new Guid("c495fe08-7f56-4671-b767-a59a0f368d34"), "C.10.92", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of prepared pet foods" },
                    { new Guid("8e02d0bd-92c8-4663-860d-8d2ae5c397e6"), "A.01.6", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("13af9e4a-465a-40f9-903d-0397419028d8"), "A.01.61", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Support activities for crop production" },
                    { new Guid("ed7c9e46-2664-45e7-bd0c-f4ac4e69558d"), "A.01.62", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Support activities for animal production" },
                    { new Guid("5a126dbc-e7e2-4464-ba57-e93aea037128"), "A.01.63", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Post-harvest crop activities" },
                    { new Guid("93faca9b-1d8d-4fc2-9e55-896ff146c143"), "A.01.64", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Seed processing for propagation" },
                    { new Guid("2c32e12f-43a4-4c1e-b5cb-6d5aa386a437"), "A.01.7", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Hunting, trapping and related service activities" },
                    { new Guid("5b9c5493-4fba-4c0e-b2ee-b3c0d0d2e694"), "A.01.70", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Hunting, trapping and related service activities" },
                    { new Guid("363e903c-7a04-4f1f-b2a0-b7d694f158c8"), "A.02", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Forestry and logging" },
                    { new Guid("a33b9930-cbc4-4f10-bae2-1c6813ee197a"), "A.02.1", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Silviculture and other forestry activities" },
                    { new Guid("7f9beda0-d274-415e-b2ec-3d85e61c779c"), "A.02.10", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Silviculture and other forestry activities" },
                    { new Guid("86c33e89-9e13-4aaa-befe-322864febca7"), "A.02.2", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Logging" },
                    { new Guid("21d7e3d7-6fda-4501-be9f-e1a651e18350"), "A.02.20", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Logging" },
                    { new Guid("f696cd2b-532f-4e00-b98a-600918b29104"), "A.01.50", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Mixed farming" },
                    { new Guid("cb5237f9-bed7-4336-9329-d75803eab703"), "A.02.3", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Gathering of wild growing non-wood products" },
                    { new Guid("b777824a-6e16-43eb-9558-21998dbb221a"), "A.02.4", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Support services to forestry" },
                    { new Guid("eaac7dc7-5e12-427d-9b8b-822bf9ff8647"), "A.02.40", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Support services to forestry" },
                    { new Guid("45f763ca-b4f0-4bb6-825a-e81578facb08"), "A.03", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Fishing and aquaculture" },
                    { new Guid("dd05dc9f-b314-436e-b707-1905d68c5412"), "A.03.1", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Fishing" },
                    { new Guid("18854ba8-58bf-4e6d-8ef7-9d9f734be883"), "A.03.11", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5086f181-fa5f-4976-8530-a2907222b297"), "A.03.12", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Freshwater fishing" },
                    { new Guid("59f6b531-641b-4700-94ad-3f29d1230552"), "A.03.2", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Aquaculture" },
                    { new Guid("d5bce5ba-cd60-4119-8b73-2234dfae9eac"), "A.03.21", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Marine aquaculture" },
                    { new Guid("8041b3ac-e1ad-4c5d-a08e-b12795790c15"), "A.03.22", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Freshwater aquaculture" },
                    { new Guid("bed82183-d64c-4884-8980-0a96a238c2de"), "B.05", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of coal and lignite" },
                    { new Guid("e3700145-3c2f-4da1-89cb-d29050af40fd"), "B.05.1", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of hard coal" },
                    { new Guid("70439658-e0f8-4182-a871-d8386c742980"), "B.05.10", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of hard coal" },
                    { new Guid("d1e5201b-3bed-4691-9d60-b50aaf2767f9"), "A.02.30", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Gathering of wild growing non-wood products" },
                    { new Guid("2859abac-16e7-4870-a754-92cf55cbf716"), "A.01.5", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Mixed farming" },
                    { new Guid("74daf8d2-1cd6-403d-b611-c6fcb941e105"), "A.01.49", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of other animals" },
                    { new Guid("f711cd30-d3cc-4df4-9823-dbfe297dfa9d"), "A.01.47", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of poultry" },
                    { new Guid("a4f9cc53-97e9-45d4-92e4-a18d4e5cb184"), "A.01.1", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of non-perennial crops" },
                    { new Guid("699a574b-9444-43f4-859d-68495ca7445f"), "A.01.11", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("77099a6b-b6bd-42b4-95ef-6d38dcc0ebe7"), "A.01.12", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of rice" },
                    { new Guid("6d09d7af-4b82-4631-8a63-55ab83063cca"), "A.01.13", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("ae3f941a-0097-4b92-b9b5-2c72c2e30e4e"), "A.01.14", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of sugar cane" },
                    { new Guid("d999bc47-21da-4b76-bca9-f65305ccd81a"), "A.01.15", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of tobacco" },
                    { new Guid("5a74ff68-b8d6-4d93-894e-3bbeab5c6a14"), "A.01.16", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of fibre crops" },
                    { new Guid("48c61541-87f6-4640-8f82-3da3fedfda54"), "A.01.19", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of other non-perennial crops" },
                    { new Guid("f2966ab9-e50a-4d74-9ce1-18ff5e224026"), "A.01.2", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of perennial crops" },
                    { new Guid("9fb54078-217f-4e23-873c-b7b682cf4321"), "A.01.21", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of grapes" },
                    { new Guid("295a2171-d165-45e1-a657-ef9320780411"), "A.01.22", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of tropical and subtropical fruits" },
                    { new Guid("47710643-a628-4396-85e9-b6907f41968b"), "A.01.23", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of citrus fruits" },
                    { new Guid("b4a330d9-f8b8-498f-9283-966203f0fa4a"), "A.01.24", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of pome fruits and stone fruits" },
                    { new Guid("b0e23c78-e1b2-40cd-9d2c-b13950a90105"), "A.01.25", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("206151db-2433-4ebc-8d23-082b22a86acd"), "A.01.26", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of oleaginous fruits" },
                    { new Guid("b8a26270-a684-4353-ae41-4d99c97dbf33"), "A.01.27", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of beverage crops" },
                    { new Guid("f3e6fd06-d518-4143-9d7d-d6a822e9bf6b"), "A.01.28", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("3e1545cb-eff8-4b59-b347-808453d8302e"), "A.01.29", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Growing of other perennial crops" },
                    { new Guid("0ce8998f-c8c8-49ff-bc99-8a2ed756ede7"), "A.01.3", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Plant propagation" },
                    { new Guid("1813db32-1154-41cb-b9bc-f0a717a3f8db"), "A.01.30", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Plant propagation" },
                    { new Guid("f2ba641d-6987-4b42-85a9-65e5d1dece96"), "A.01.4", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Animal production" },
                    { new Guid("586e7061-5056-457f-b23d-7b73572cc216"), "A.01.41", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of dairy cattle" },
                    { new Guid("65402e45-862a-4eaa-867b-241394875f0a"), "A.01.42", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of other cattle and buffaloes" },
                    { new Guid("d90e2e07-8fa9-464a-87d7-84ff59234a4b"), "A.01.43", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of horses and other equines" },
                    { new Guid("f2138bae-d9f1-407a-9917-c46a2dc04f65"), "A.01.44", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of camels and camelids" },
                    { new Guid("fb29af33-2509-41d8-89bb-1b44009bf68f"), "A.01.45", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of sheep and goats" },
                    { new Guid("25cfcec2-1aa7-474d-9308-4d94020f886c"), "A.01.46", new Guid("b7059fbc-45b4-4d46-b18b-695c05c42bac"), "Raising of swine/pigs" },
                    { new Guid("65cc453a-a6af-4170-ba44-b16246156f59"), "B.05.2", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of lignite" },
                    { new Guid("d011606d-316e-452c-bbde-dce3cbd87d85"), "C.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of beverages" },
                    { new Guid("359c1223-1376-4805-ba7f-7329419dade3"), "B.05.20", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of lignite" },
                    { new Guid("eb9d29e7-b1de-421f-b0a6-6e3abf6f9a28"), "B.06.1", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("02eadbfa-bb38-419b-8984-5b62184fabd4"), "C.10.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of potatoes" },
                    { new Guid("9c07462f-5f71-4875-96b4-dc6f0a0f6b97"), "C.10.32", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("f313f4d7-423d-4bdc-82f4-e978b31d8adb"), "C.10.39", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("a00ad2bd-fedd-4fa0-9c59-1b97024da220"), "C.10.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("556c5678-ba44-4027-b06a-2e4cd2496ced"), "C.10.41", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of oils and fats" },
                    { new Guid("23cc06bb-f335-4090-ac34-a3190c82bd4c"), "C.10.42", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("1d3a5d43-c9ce-43bb-8d14-2f14a4e97314"), "C.10.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of dairy products" },
                    { new Guid("546546e5-08f9-41c0-b057-f59804b3db33"), "C.10.51", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Operation of dairies and cheese making" },
                    { new Guid("c7330ed9-9835-46ab-b99e-0f51b7f9c929"), "C.10.52", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ice cream" },
                    { new Guid("62e8bbe0-c3a1-4990-971b-478b505bea54"), "C.10.6", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("1791e3e4-02d1-42d2-a325-ed7ea9a56dc9"), "C.10.61", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of grain mill products" },
                    { new Guid("9d171270-b89d-4bbb-95b0-2d30c1b22bef"), "C.10.62", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of starches and starch products" },
                    { new Guid("6be32958-d875-412c-b1ae-fb9cf163461c"), "C.10.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("41c844fa-23b1-4857-bec1-2459dc26f941"), "C.10.7", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("f108bbf7-bbe3-49f7-9f16-d0613132bd2e"), "C.10.72", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("be65c647-8e08-473f-883b-d4f462503723"), "C.10.73", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("9c3ad886-2d65-4d29-8bd6-dfac3299a565"), "C.10.8", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other food products" },
                    { new Guid("3e41eca7-9780-40a7-8236-b24f5b7a8c85"), "C.10.81", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of sugar" },
                    { new Guid("6b4c824f-3a55-436a-ad16-5ffd67a7c97e"), "C.10.82", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("2cdd7989-d3a9-410f-92a6-a0ed8961a876"), "C.10.83", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing of tea and coffee" },
                    { new Guid("c0eb1e0b-ca44-42eb-8810-4a30582d5981"), "C.10.84", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of condiments and seasonings" },
                    { new Guid("5ebee11d-1612-4879-b31b-86e70281934c"), "C.10.85", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of prepared meals and dishes" },
                    { new Guid("eb20f401-c80d-4efb-a805-9636315a2a38"), "C.10.86", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("9b51822c-2ec2-4ae5-b477-0aef8feb0696"), "C.10.89", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other food products n.e.c." },
                    { new Guid("5b6123b9-d786-4ecc-afa8-9b78f3cc71b4"), "C.10.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of prepared animal feeds" },
                    { new Guid("802a74fa-b34b-4ca2-b33f-3ca310d08b62"), "C.10.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("24b07559-1bb0-4345-827e-3e31031245f9"), "C.10.71", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("0a957aca-ca72-4cb5-97d7-17e3fddd6fc1"), "C.10.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("797116f0-0955-404a-9989-7ffd383a656e"), "C.10.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("d4118679-0f1b-4eca-9a2d-79601eb9648d"), "C.10.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Production of meat and poultry meat products" },
                    { new Guid("d669c301-2512-49f4-abec-2ff627a5f9b7"), "B.06.10", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of crude petroleum" },
                    { new Guid("633778c1-2a86-4b67-b414-b3a68aa23273"), "B.06.2", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of natural gas" },
                    { new Guid("5ba95e6b-bd11-47f9-9c85-adba22439550"), "B.06.20", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of natural gas" },
                    { new Guid("8704f747-2385-425b-8afd-7361985100b7"), "B.07", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of metal ores" },
                    { new Guid("dc48ff51-d982-4a38-a4da-7ccd65c84797"), "B.07.1", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of iron ores" },
                    { new Guid("66b67348-9e90-485c-b8e4-0b034364aee5"), "B.07.10", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of iron ores" },
                    { new Guid("dbd251e3-525d-4bf8-9f82-bdfc0b3e6cac"), "B.07.2", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of non-ferrous metal ores" },
                    { new Guid("48da38ec-bee7-4a87-a9b4-f96febfa99a7"), "B.07.21", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of uranium and thorium ores" },
                    { new Guid("56816285-5ebf-413b-9e06-347e1de2f9c8"), "B.07.29", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of other non-ferrous metal ores" },
                    { new Guid("80ffcdc0-9ccf-4e56-84a9-e12763cb7071"), "B.08", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Other mining and quarrying" },
                    { new Guid("caa365a2-2307-4e5e-bde3-66abc817e6af"), "B.08.1", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Quarrying of stone, sand and clay" },
                    { new Guid("60901dad-6d8f-4b5a-8fd0-f1a5b40d8392"), "B.08.11", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9cad56db-6418-4d6b-b6a0-3a86ad569048"), "B.08.12", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("850a9c40-031b-4065-aead-5293876b5670"), "B.08.9", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining and quarrying n.e.c." },
                    { new Guid("e9e63fbf-9512-4ebe-9613-30bfb54bc74b"), "B.08.91", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("0a4cc9ba-0c81-468e-a315-62f6229a7ba0"), "B.08.92", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of peat" },
                    { new Guid("aeb3998f-1453-40d9-81cf-bdb9d39baf80"), "B.08.93", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of salt" },
                    { new Guid("5af4e899-8dc4-4efd-ae2e-419b94b14004"), "B.08.99", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Other mining and quarrying n.e.c." },
                    { new Guid("7ea71bc6-972a-4794-af68-1a4d62b10a8a"), "B.09", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Mining support service activities" },
                    { new Guid("6b9c8797-81ba-4321-9953-677b3e440faf"), "B.09.1", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("5c56912c-f750-4eee-801c-1d345533c99b"), "B.09.10", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("9af10e4c-49b4-4ab5-9d0c-5a72f5672eb8"), "B.09.9", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Support activities for other mining and quarrying" },
                    { new Guid("9d85a0a5-5ec7-4901-8df7-e62abd036911"), "B.09.90", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Support activities for other mining and quarrying" },
                    { new Guid("85ff75e6-8ec1-44cf-8554-6c97607d23ef"), "C.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of food products" },
                    { new Guid("4f71fe36-40de-4fb1-a821-e4e97c5e083a"), "C.10.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("9d982be8-66e7-4ff9-aaeb-5c7ac717f02b"), "C.10.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of meat" },
                    { new Guid("7e72cf6d-1d1b-443f-9f2d-21ad75d58adb"), "C.10.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing and preserving of poultry meat" },
                    { new Guid("e009d4ac-3ef4-4929-b7c5-4ad02168225e"), "B.06", new Guid("d0bfef26-f24d-43ff-be0c-88bfc213104c"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("0fc7b2c5-99bf-4536-96e8-1a9a79115eae"), "F.43.2", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("fbb452f1-3991-4f91-9ca7-cdb4af88dc3d"), "C.23.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of refractory products" },
                    { new Guid("c6983e1a-abe2-4dce-8687-28920c8790de"), "C.23.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("654ae749-05e6-4c8d-be53-de4c2f814160"), "C.30.92", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("333cbb53-ca7e-4520-a9f3-b4749f9716f4"), "C.30.99", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("9c1772f0-be2b-4ba0-9ddf-2614e31317b8"), "C.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of furniture" },
                    { new Guid("156ccb8e-04ed-4415-99e6-55eca8c4cf67"), "C.31.0", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of furniture" },
                    { new Guid("55ed4c89-42ca-413a-b0b9-96f64ec3afe8"), "C.31.01", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of office and shop furniture" },
                    { new Guid("d000e0ae-af76-4e98-adeb-a399430de716"), "C.31.02", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of kitchen furniture" },
                    { new Guid("b5beb34f-b766-4259-b4d6-8d9e1a011a17"), "C.31.03", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of mattresses" },
                    { new Guid("4cefa059-5a4e-41ae-ba44-ac4445fe00a9"), "C.31.09", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other furniture" },
                    { new Guid("c5c50e8f-2264-46a1-9e45-616742a55b8c"), "C.32", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Other manufacturing" },
                    { new Guid("eed049cd-803e-4f0c-8448-032bae3debe1"), "C.32.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("c42accaa-f148-43c0-b0d9-50dda74642d4"), "C.32.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Striking of coins" },
                    { new Guid("8fa6dbc5-765d-456b-9a20-c7e1d7398947"), "C.32.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of jewellery and related articles" },
                    { new Guid("fcd5a666-2743-4a10-9c60-1cee5e16ba20"), "C.30.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of motorcycles" },
                    { new Guid("895f24d2-419a-4306-be58-7f62fdfa7422"), "C.32.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("cac83a05-0670-4633-b4e2-29676e5ee4ea"), "C.32.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of musical instruments" },
                    { new Guid("b642ed64-3037-421e-9fa2-ed7f6562e7ed"), "C.32.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of sports goods" },
                    { new Guid("71a7b7d8-d8d2-42ba-9ca4-8fc0a4de17a8"), "C.32.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of sports goods" },
                    { new Guid("6c049d4d-2a4e-4973-a793-e5702be10ea3"), "C.32.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of games and toys" },
                    { new Guid("fb023506-8815-4ce0-a2f3-3038d8c03710"), "C.32.40", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of games and toys" },
                    { new Guid("26cda3b7-51d7-41a6-8dc6-e39f38df6b8e"), "C.32.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("d4926d8f-2195-4127-adf5-730c1c1c1e55"), "C.32.50", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("e274042f-7077-41e8-8279-cadc0fc55b37"), "C.32.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacturing n.e.c." },
                    { new Guid("0c0b4031-07f7-4410-b139-2c1c2f275fa2"), "C.32.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("184bd5d0-a88f-4c15-9e7c-d32c21436ffd"), "C.32.99", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Other manufacturing n.e.c." },
                    { new Guid("8ab71983-7487-4fb0-aeef-6c0563c3820f"), "C.33", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair and installation of machinery and equipment" },
                    { new Guid("63828bb8-1bfb-4d01-8c23-21eb6b171867"), "C.33.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("5cab68ab-21e1-4a98-a6de-78044c2c5a7b"), "C.32.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of musical instruments" },
                    { new Guid("95e16567-3aa2-48d7-a858-b484a0257506"), "C.30.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("b21b0415-b4eb-4251-bf78-12194b6dae76"), "C.30.40", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of military fighting vehicles" },
                    { new Guid("10425adb-eb3a-4423-a1ea-3651c4dec783"), "C.30.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of military fighting vehicles" },
                    { new Guid("7675787c-cff3-44ec-b11b-761d12eaf0b7"), "C.28.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("eb0c1f59-6449-4530-b51b-d9f3af48f851"), "C.28.41", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of metal forming machinery" },
                    { new Guid("22eaeefa-ef8f-4363-a6a9-f19da7386f31"), "C.28.49", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other machine tools" },
                    { new Guid("3a1d14de-035c-4623-9715-44931b219375"), "C.28.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other special-purpose machinery" },
                    { new Guid("eaa69504-5a9c-4c10-ac56-360003836a03"), "C.28.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of machinery for metallurgy" },
                    { new Guid("05c96ea0-18ab-4a50-bbec-715ad26f2331"), "C.28.92", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("d150fe45-d0c3-4c96-b24d-2c3f70be0ac4"), "C.28.93", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("f0a0756b-2a7f-43d0-8295-6dad50462947"), "C.28.94", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("64ca0f9b-2e5c-4088-8ed9-b8e1f71f222a"), "C.28.95", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("ede95988-162c-4ba2-9afc-2355af5d19b7"), "C.28.96", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("36181f3f-aed2-4dfd-a788-6a218224b50c"), "C.28.99", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("eeb761df-8c92-49d3-a719-4537df4ba448"), "C.29", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("9871e73a-f734-45ca-b2f3-4aa7d6692134"), "C.29.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of motor vehicles" },
                    { new Guid("e7ede9b3-e488-4a15-8c5a-490ec2b753e0"), "C.29.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of motor vehicles" },
                    { new Guid("08754755-2345-4ac0-b2ec-a476e52b59b0"), "C.29.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("50fe4671-0e03-4bed-91c1-2c13631c10fb"), "C.29.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("8da00ed7-f97e-47cb-956b-697af2695d69"), "C.29.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("d0faecbd-0d9c-43cc-8d49-00763d90c71c"), "C.29.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("650e7327-e9da-4c15-b6ab-2f1a7453ad2d"), "C.29.32", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("cb9719a9-5c9e-41cd-b611-66cd6df5822b"), "C.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other transport equipment" },
                    { new Guid("b13ff8c7-7ec2-46d5-a1f4-441633c6ca82"), "C.30.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Building of ships and boats" },
                    { new Guid("1bc8278f-8182-4b62-be3d-e03b4c2f3e5d"), "C.30.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Building of ships and floating structures" },
                    { new Guid("e389ff6a-fb87-407a-8317-4c284094eb37"), "C.30.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Building of pleasure and sporting boats" },
                    { new Guid("9a9770b2-4dba-498e-873c-82e1012e2c5e"), "C.30.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("aa402355-69af-430c-b2dd-d1e4ab711f9e"), "C.30.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("d5a0cc9e-e136-4d4c-bc98-90f3286c0a8b"), "C.30.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("296a5013-bed1-48bc-bafd-8a7f7a6104ed"), "C.30.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("d1edfb4c-2e73-48f3-b7a7-8303c0ce26b3"), "C.33.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair of fabricated metal products" },
                    { new Guid("037b65ec-a786-42a6-b164-de8424c51b05"), "C.28.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("3561a078-d188-473c-920f-7d9a915b5bb3"), "C.33.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair of machinery" },
                    { new Guid("c131bb22-8966-447f-a411-fc775b2404ec"), "C.33.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair of electrical equipment" },
                    { new Guid("e4ba991c-7828-4be7-b160-625055599152"), "E.38.3", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Materials recovery" },
                    { new Guid("0cefd6b0-2164-40fd-96e9-5e4cc41b0b8c"), "E.38.31", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Dismantling of wrecks" },
                    { new Guid("adea0713-ce56-4a81-aae2-cb18f7f05e40"), "E.38.32", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Recovery of sorted materials" },
                    { new Guid("2b44bc0a-b74d-4cea-97a6-fb86aa3d585f"), "E.39", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a23b560e-67ea-4c8f-a77d-f34e4ceb041d"), "E.39.0", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Remediation activities and other waste management services" },
                    { new Guid("c3a0cc76-fa5e-43bf-9b11-6059ac1b37fe"), "E.39.00", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Remediation activities and other waste management services" },
                    { new Guid("ecb58c03-c84a-4e54-af66-969a48cc8e03"), "F.41", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of buildings" },
                    { new Guid("b8c4c917-3316-41aa-a067-3ff3145b3564"), "F.41.1", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Development of building projects" },
                    { new Guid("fa0883a2-e96a-4384-8ff7-89258c9dbdab"), "F.41.10", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Development of building projects" },
                    { new Guid("4ef23162-2f8c-4486-b855-d55791880372"), "F.41.2", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of residential and non-residential buildings" },
                    { new Guid("5d1677b0-9680-4dfe-a96d-d5621dfd39ef"), "F.41.20", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of residential and non-residential buildings" },
                    { new Guid("4d2255bd-e489-4230-9144-dfeda3e28419"), "F.42", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Civil engineering" },
                    { new Guid("f3a5a81b-f846-4516-9fe5-8dc08240f8fb"), "E.38.22", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Treatment and disposal of hazardous waste" },
                    { new Guid("97886d3e-928e-4003-96fa-6ab4e72ccbf8"), "F.42.1", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of roads and railways" },
                    { new Guid("2e4dff0f-0e2f-4b50-a0c1-65aa27e539c4"), "F.42.12", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of railways and underground railways" },
                    { new Guid("1f9104c4-3da2-4d2d-a228-94d24673041c"), "F.42.13", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of bridges and tunnels" },
                    { new Guid("18ceac0c-dbab-45ea-9e21-8140b1afd41b"), "F.42.2", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of utility projects" },
                    { new Guid("dbab9062-57fc-4b73-a281-232b0b9a8d81"), "F.42.21", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of utility projects for fluids" },
                    { new Guid("f74c1712-110c-437d-a44f-ddabedc66c30"), "F.42.22", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("b87e975c-03b4-4696-afe5-e1e136bcc6ec"), "F.42.9", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of other civil engineering projects" },
                    { new Guid("5b49c99b-484b-4d31-8b2a-5b78b433e5ae"), "F.42.91", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of water projects" },
                    { new Guid("6f3d5437-181e-4b72-a56b-7e5f8715aa81"), "F.42.99", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("6868bc3f-4f8e-4968-825d-15aa1ef9e5eb"), "F.43", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Specialised construction activities" },
                    { new Guid("4673e406-bcd7-483c-b562-c40ae6f4f172"), "F.43.1", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Demolition and site preparation" },
                    { new Guid("6b4ad04d-3530-4e06-9008-7180426c6206"), "F.43.11", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Demolition" },
                    { new Guid("0e6c8094-126f-41cb-95da-d594c85885c5"), "F.43.12", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Site preparation" },
                    { new Guid("543b1f7a-4527-4c04-8cc3-63ea8deb7b3f"), "F.42.11", new Guid("0f504253-cd28-485c-a39a-703d7cc6fd51"), "Construction of roads and motorways" },
                    { new Guid("0b9682f4-ae13-4b5e-b7bc-74dd752ce82d"), "E.38.21", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("ed72b02f-6472-4073-b391-65fc321c3392"), "E.38.2", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Waste treatment and disposal" },
                    { new Guid("1933282e-f187-4b12-9e4c-19c34b9dbb56"), "E.38.12", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Collection of hazardous waste" },
                    { new Guid("e706c237-07eb-4505-a040-a793d4ab5663"), "C.33.15", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair and maintenance of ships and boats" },
                    { new Guid("69ab0821-87c9-4b30-87a1-264d320b4e9c"), "C.33.16", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("8bbabf2f-9806-4d16-bdd6-0505cda0751c"), "C.33.17", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair and maintenance of other transport equipment" },
                    { new Guid("db2eff46-eae2-4251-a1d3-18f21fd889b4"), "C.33.19", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair of other equipment" },
                    { new Guid("da5d1e62-b2d5-4070-b1a3-48e4d953d2fd"), "C.33.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Installation of industrial machinery and equipment" },
                    { new Guid("0059ea0c-9e79-4115-8110-1fb20e5a77df"), "C.33.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Installation of industrial machinery and equipment" },
                    { new Guid("84158dcb-54ed-4b7a-a741-f1318538b71e"), "D.35", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("dbfeba18-95fc-4058-963d-be91a1117c91"), "D.35.1", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Electric power generation, transmission and distribution" },
                    { new Guid("a2558f38-2d0b-4253-8ae8-4d3c06dc1662"), "D.35.11", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Production of electricity" },
                    { new Guid("d3da9a25-34af-40e0-aadd-79be559d24d6"), "D.35.12", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Transmission of electricity" },
                    { new Guid("e1081208-fd09-458f-bfdc-23fe33a7f956"), "D.35.13", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Distribution of electricity" },
                    { new Guid("587d0e62-0c2b-4151-93bc-78c6ad9befb3"), "D.35.14", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Trade of electricity" },
                    { new Guid("858a7913-2a16-4b72-b469-d26e36843db2"), "D.35.2", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("21464e07-24d6-4332-95b0-071a66a9a3b3"), "D.35.21", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Manufacture of gas" },
                    { new Guid("be78b738-62b0-40d7-8b4e-ca6653029f1c"), "D.35.22", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Distribution of gaseous fuels through mains" },
                    { new Guid("b5ce8ce9-26af-4c94-a81e-230ef75a2d70"), "D.35.23", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0e828784-3c81-4ca9-a451-47289ae394ae"), "D.35.3", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Steam and air conditioning supply" },
                    { new Guid("13c2101e-1ff9-42db-88cd-ca992bc76cde"), "D.35.30", new Guid("b12c5d5a-1d3a-4a8c-b526-12fb48d8c725"), "Steam and air conditioning supply" },
                    { new Guid("64087012-f9bb-43b9-a931-20f34d991db5"), "E.36", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Water collection, treatment and supply" },
                    { new Guid("59259396-6ac7-4398-8193-e8a1c5897142"), "E.36.0", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Water collection, treatment and supply" },
                    { new Guid("2c640502-51de-4e41-8fb2-6cc6fba9e6ce"), "E.36.00", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Water collection, treatment and supply" },
                    { new Guid("db339c94-196c-4136-9286-b990fea95440"), "E.37", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Sewerage" },
                    { new Guid("0fbaef15-9f47-4903-b8e5-923803c557ad"), "E.37.0", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Sewerage" },
                    { new Guid("e05ed1ad-1564-40a8-868f-aebe0c9bb455"), "E.37.00", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Sewerage" },
                    { new Guid("c962fb54-676a-4a71-806d-42f2323584ae"), "E.38", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("9f5e2931-0392-4965-8136-dd3e10e084aa"), "E.38.1", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Waste collection" },
                    { new Guid("1085f233-8e02-4f2a-8c5a-7d6d3c5a4dbf"), "E.38.11", new Guid("90ebccaa-84a6-4127-9b4e-0736a61fa904"), "Collection of non-hazardous waste" },
                    { new Guid("6de0fcfe-625e-464a-a59a-cf006f843701"), "C.33.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Repair of electronic and optical equipment" },
                    { new Guid("ab4ec4cc-ce40-4638-861b-27d750ce5ce5"), "C.23.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of clay building materials" },
                    { new Guid("0eccf205-b40b-4957-ab1e-8ab1aa386862"), "C.28.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("e35f782d-b630-4aa8-bc49-90f3ceb36e3b"), "C.28.25", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("0f007569-5b54-482c-a9c4-2dad1cfdc753"), "C.24.34", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Cold drawing of wire" },
                    { new Guid("23751553-551b-4d2c-99d5-fd827cc9d60d"), "C.24.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("f181f645-72fe-44fd-aa93-1f912b0938ec"), "C.24.41", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Precious metals production" },
                    { new Guid("3c878c48-9347-4347-bab3-c3c85c5e2a16"), "C.24.42", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Aluminium production" },
                    { new Guid("27621b32-4c96-42aa-a0ed-7bfd4967e67b"), "C.24.43", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Lead, zinc and tin production" },
                    { new Guid("592df208-9538-41b8-8a45-40f076c108f5"), "C.24.44", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Copper production" },
                    { new Guid("9be649ba-e669-4ed3-b0a5-e1ccff4a0d43"), "C.24.45", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Other non-ferrous metal production" },
                    { new Guid("4035b498-7077-4abb-bb6b-a5c5d74afe23"), "C.24.46", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Processing of nuclear fuel" },
                    { new Guid("122b319c-6f8f-481b-8d0d-a84c7a3ccd63"), "C.24.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Casting of metals" },
                    { new Guid("6739c902-ee13-4d26-9465-15465c5d48b4"), "C.24.51", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Casting of iron" },
                    { new Guid("c5b6cba5-4a82-4665-ae2d-2949f145f5dd"), "C.24.52", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Casting of steel" },
                    { new Guid("13927750-bab9-4819-908f-52736033e793"), "C.24.53", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Casting of light metals" },
                    { new Guid("7128d87a-6309-4276-acbd-ca1f44c4b7c4"), "C.24.33", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Cold forming or folding" },
                    { new Guid("74fc2161-fffa-4aa8-a467-e4086cafb2cd"), "C.24.54", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Casting of other non-ferrous metals" },
                    { new Guid("57ece757-0e66-49f0-82ac-ed468390b845"), "C.25.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of structural metal products" },
                    { new Guid("b3312026-a591-4181-935c-31f00ad54fd6"), "C.25.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("406b30ec-7772-4191-abbc-b5d8bc5c3c56"), "C.25.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of doors and windows of metal" },
                    { new Guid("53e1b7fb-d6bb-4a48-8604-7bf6780fe9bb"), "C.25.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("0f006d2f-163d-42c3-9c64-0078ef2ffb16"), "C.25.21", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("01138386-9079-4be2-9e31-4efb613d2f9b"), "C.25.29", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("a910c5f8-4c7c-419b-90f9-b7da63f03a8d"), "C.25.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("910e5e69-bb24-4a57-bea7-c5816775a7f6"), "C.25.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("24f1b3c3-2504-4074-af6e-93746ca4aa10"), "C.25.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of weapons and ammunition" },
                    { new Guid("06a3513d-4acc-463a-aaf2-2ac14c10736d"), "C.25.40", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of weapons and ammunition" },
                    { new Guid("9c1242d3-9e19-43a0-8ff3-8b44217174d6"), "C.25.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("1a07d3e7-b2d7-4aa4-9b1a-9fbaba233e21"), "C.25.50", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("bf4bdec7-47ce-4eb3-b96a-5a80f8e5b00b"), "C.25", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f7d57808-0c92-40cc-ab1c-aee4f5748a0b"), "C.24.32", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Cold rolling of narrow strip" },
                    { new Guid("82b04f78-4284-4b96-8e6c-34a3391efba3"), "C.24.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Cold drawing of bars" },
                    { new Guid("5b6f9124-0d74-4954-96d9-44398d2eaf6c"), "C.24.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other products of first processing of steel" },
                    { new Guid("603ba748-0da6-4bfc-845a-d426cb3d8a6c"), "C.23.32", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("6b5129ca-deb8-4658-b3e8-1c8b6bdac7ec"), "C.23.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("3d078753-6ca3-4218-bec0-51d06fb5dd2a"), "C.23.41", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("4031e29e-d574-4264-89b0-c84cdf71db1b"), "C.23.42", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("4921baf6-aa01-4f4e-97b3-904193035944"), "C.23.43", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("8950d5a6-919c-4d87-9f3a-4df336e15951"), "C.23.44", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other technical ceramic products" },
                    { new Guid("ccdb3059-1eca-4e63-8887-7efe4b79c053"), "C.23.49", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other ceramic products" },
                    { new Guid("41a5c45f-bc14-4069-8b31-b8229205a3ef"), "C.23.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cement, lime and plaster" },
                    { new Guid("2bbb1fcd-e2d3-4f10-a544-3f4743a04541"), "C.23.51", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cement" },
                    { new Guid("2af274ec-e944-4129-a28f-708fba9c7e67"), "C.23.52", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of lime and plaster" },
                    { new Guid("4681f6c9-ec02-48b9-9412-f85db599c868"), "C.23.6", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("10e2f278-2680-4de1-bf48-9469b1c5d4e9"), "C.23.61", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("dd914982-3054-4610-80f1-9cd5d66b649a"), "C.23.62", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("a3bf64d7-7016-4254-8e35-7a6f227cc5d9"), "C.23.63", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ready-mixed concrete" },
                    { new Guid("1334e558-017c-423a-b629-3693610cd7d6"), "C.23.64", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of mortars" },
                    { new Guid("a102ca67-7951-4a94-8da5-c2a63f11172f"), "C.23.65", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fibre cement" },
                    { new Guid("98d4aa90-9da8-4fe7-a849-365e1ad12756"), "C.23.69", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("dbaccbd1-aed8-4a4d-9a97-e3641159fc28"), "C.23.7", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Cutting, shaping and finishing of stone" },
                    { new Guid("41659702-51fe-4205-83ae-896770fb0ecc"), "C.23.70", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Cutting, shaping and finishing of stone" },
                    { new Guid("0ca170fd-b97b-4cd1-89c8-be5822925fa6"), "C.23.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("b385de65-1ccb-437a-a1a3-cd0531d524a4"), "C.23.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Production of abrasive products" },
                    { new Guid("03363404-602b-443d-90e4-e81593a621ad"), "C.23.99", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("1488694f-8c50-41b3-ae3c-c62f7194742e"), "C.24", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic metals" },
                    { new Guid("87cc0b4a-0dc2-46c9-b69d-e4d78ffa1010"), "C.24.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("916c881c-9683-41e3-84a8-02ef1cacf2cf"), "C.24.10", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("fd0d98c4-552b-444d-bca9-365ec5192402"), "C.24.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("ddb3bb99-82aa-4dd8-8b85-1ab7d4311c2e"), "C.24.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("e586e222-35e1-4b6c-8d20-2c1be1824e7f"), "C.25.6", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Treatment and coating of metals; machining" },
                    { new Guid("b14d9f2d-b181-4651-a13f-374f4b46a38e"), "C.28.29", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("dd551af8-813d-42b9-9c8c-8439b6768c81"), "C.25.61", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Treatment and coating of metals" },
                    { new Guid("c78bd22b-287d-461d-b75c-1ca65d33cf19"), "C.25.7", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("4db02fc1-3acc-4c0d-85c5-f75a310be20e"), "C.27.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("7ba55fcf-b019-4deb-8e1a-052a948abfbf"), "C.27.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of batteries and accumulators" },
                    { new Guid("a933c8c0-580b-4c96-9f09-52956ef17707"), "C.27.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of batteries and accumulators" },
                    { new Guid("34ef861b-7972-4431-92ab-c93afac1df3b"), "C.27.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wiring and wiring devices" },
                    { new Guid("9d51ee15-67cc-4bd3-a71d-22c1f266ac75"), "C.27.31", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fibre optic cables" },
                    { new Guid("5a5bc97e-38b7-43f9-879d-45112f9f2100"), "C.27.32", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("4d0f2d91-37de-4c0d-96a8-c0cbd87755a5"), "C.27.33", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wiring devices" },
                    { new Guid("08fbe273-29f0-4c23-b4aa-1537c2a379c9"), "C.27.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0fa6e7d5-f438-4210-b896-ad67215feee2"), "C.27.40", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electric lighting equipment" },
                    { new Guid("62ab89a0-8890-4364-b359-9233f3bc3eb8"), "C.27.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of domestic appliances" },
                    { new Guid("e6e076bc-54d0-4a43-bc79-9b53101db30d"), "C.27.51", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electric domestic appliances" },
                    { new Guid("8a43e45d-d8c4-421c-aeb2-509d5809985e"), "C.27.52", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("7870d4ae-220f-43d4-8f5e-c5748e74420f"), "C.27.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("6ca94657-394f-4012-b29b-4a39058e93ee"), "C.27.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other electrical equipment" },
                    { new Guid("481bd98c-d000-4a85-9079-1fea5d6e9a55"), "C.28", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("9afbf5fd-fc2f-418e-a81a-9398f835b0c2"), "C.28.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of general-purpose machinery" },
                    { new Guid("77a2c6a0-7495-487e-9a8f-5818e52e8198"), "C.28.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("480b3244-5cc4-4751-9823-67e61314bc3d"), "C.28.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fluid power equipment" },
                    { new Guid("ff1fd299-9a29-4c12-8803-9f615c4549f0"), "C.28.13", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other pumps and compressors" },
                    { new Guid("a923b964-0f85-411e-b60b-8416206d819e"), "C.28.14", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other taps and valves" },
                    { new Guid("0be47a06-a0db-45ee-815b-29c31a60a681"), "C.28.15", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("68b6c92c-72d1-46ed-8ebf-577806c2927d"), "C.28.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other general-purpose machinery" },
                    { new Guid("60a87657-edd7-4915-85d5-160782ac7899"), "C.28.21", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("4dc61756-20bf-468c-90b0-1393f43ca4a8"), "C.28.22", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of lifting and handling equipment" },
                    { new Guid("f9e013f1-f404-4910-9d37-bb347ae06d23"), "C.28.23", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("d0c560c7-1871-4730-b8d9-7a085e77c814"), "C.28.24", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of power-driven hand tools" },
                    { new Guid("51533a83-1eb8-4aef-a4bc-0b0ceb0d9792"), "C.27.90", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other electrical equipment" },
                    { new Guid("9764208e-35d3-439f-8140-79774c1d7692"), "C.27.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("ec32dd0b-c6f5-41cd-90f3-ed9e1f733c67"), "C.27", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electrical equipment" },
                    { new Guid("9cc60cef-e8a0-4626-a1e4-b3d8e9ba89de"), "C.26.80", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of magnetic and optical media" },
                    { new Guid("82b18242-94e6-474f-bd82-7f3c006fbbcb"), "C.25.71", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of cutlery" },
                    { new Guid("59e4c0be-ba1f-4c01-ada4-66c7cce208e2"), "C.25.72", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of locks and hinges" },
                    { new Guid("1d1d45d8-faf3-4802-9bec-ccc8b8c7b75f"), "C.25.73", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of tools" },
                    { new Guid("ed361590-1945-418d-aea0-1145e781c5e3"), "C.25.9", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other fabricated metal products" },
                    { new Guid("ab6a5b9a-91e1-43ca-a070-b087413fdc34"), "C.25.91", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of steel drums and similar containers" },
                    { new Guid("c321bda2-90df-4612-9e13-854a93f6bd46"), "C.25.92", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of light metal packaging" },
                    { new Guid("643f008a-88bc-4b26-b28a-237b245d0cf8"), "C.25.93", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of wire products, chain and springs" },
                    { new Guid("72032e19-2ef8-47f1-b543-7dfd60c39160"), "C.25.94", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("514dbb2b-91cf-41aa-8ea5-6b3d374b4cde"), "C.25.99", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("9db91fe9-7837-470d-b2c1-f3241d25c395"), "C.26", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("5bca6861-6a75-458c-9810-84107eb5f054"), "C.26.1", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electronic components and boards" },
                    { new Guid("5a061d23-0a47-4a78-abd5-ead886bb9b25"), "C.26.11", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of electronic components" },
                    { new Guid("0c87b52c-8a18-412e-9069-6f68441c7b70"), "C.26.12", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of loaded electronic boards" },
                    { new Guid("b81a64e4-ce7d-4bb0-8236-862bf6465636"), "C.26.2", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("43914ff2-9e48-44ca-a7b4-0a77f10d2e83"), "C.26.20", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("c0855944-1077-48d6-9f40-b84badb2218a"), "C.26.3", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of communication equipment" },
                    { new Guid("79727305-edc5-4d2f-aa3a-cc4ea8e2bcda"), "C.26.30", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of communication equipment" },
                    { new Guid("6554246c-1f24-4962-ac5e-ad3bc487dc73"), "C.26.4", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of consumer electronics" },
                    { new Guid("3853f926-43cf-493b-84f1-9ee3960dad18"), "C.26.40", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of consumer electronics" },
                    { new Guid("47009068-f94e-4c45-b987-1969c8404568"), "C.26.5", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("71fe411e-cc50-4afc-b763-f3fe8dd9ff72"), "C.26.51", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("12a9550e-f180-4a0f-b6f8-ab187e57b2d4"), "C.26.52", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of watches and clocks" },
                    { new Guid("91d7ba0f-1092-4d79-89f1-b7fe4a2b45e5"), "C.26.6", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("7cc15436-c971-4948-9588-59b46e97dae1"), "C.26.60", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("dc1a06e9-1960-41d1-ac0f-10c9a946ecf3"), "C.26.7", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("28d41b4b-263c-408f-8f03-1deb05e16b1d"), "C.26.70", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("d9133bf8-27bc-4ec0-9761-e9246d2ba881"), "C.26.8", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Manufacture of magnetic and optical media" },
                    { new Guid("217683c4-361e-4ad8-8041-372f74ba0621"), "C.25.62", new Guid("050ef450-c4fa-4047-a604-9451b284b5e4"), "Machining" },
                    { new Guid("a96c1f99-66b1-4551-b6c5-9bf9e3588855"), "U.99.00", new Guid("087a323a-af69-4a81-8966-4689327a8cd5"), "Activities of extraterritorial organisations and bodies" }
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
