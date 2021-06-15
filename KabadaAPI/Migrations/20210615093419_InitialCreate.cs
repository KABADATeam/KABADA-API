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
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Img = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Completed = table.Column<int>(type: "int", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsSwotCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsResourcesCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    AttrVal = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("420230d1-0749-4533-8ece-4135bae3ebda"), "AT", "Austria" },
                    { new Guid("180ee9cd-8c49-42a3-add1-441c39c57584"), "LU", "Luxembourg" },
                    { new Guid("17c9038d-8e7e-483f-be0e-644ed916ad39"), "MT", "Malta" },
                    { new Guid("a9efbed3-0805-44e0-bf85-43046d907b1a"), "NL", "Netherlands" },
                    { new Guid("0ef44bfb-4696-42a3-b597-6e2783e623ce"), "MK", "North Macedonia" },
                    { new Guid("ec258459-44fa-4903-a0c7-767323843a00"), "NO", "Norway" },
                    { new Guid("68707b72-def8-41ad-9694-ab4ab073cbe0"), "PL", "Poland" },
                    { new Guid("422a978a-8acf-463b-92f3-b3df15b5bdd1"), "PT", "Portugal" },
                    { new Guid("5fc79f6f-35de-4ad3-8b69-cbaafefc317d"), "RO", "Romania" },
                    { new Guid("5e32fe0d-fb6a-4417-9807-89b10682e041"), "RS", "Serbia" },
                    { new Guid("13c2e120-e200-40eb-b9b3-749d8a45b2d5"), "SK", "Slovakia" },
                    { new Guid("bd33ce5e-04d8-48a4-81cb-375136506b75"), "SI", "Slovenia" },
                    { new Guid("37d0511d-6d35-4270-93b0-0f6c98080c1a"), "ES", "Spain" },
                    { new Guid("f8309568-62d8-43a8-bf99-512f9cb21307"), "CH", "Switzerland" },
                    { new Guid("fc9fb381-6d4e-45c1-987b-88448e4f413b"), "TR", "Turkey" },
                    { new Guid("f948901a-4d49-433a-a2aa-89f9caf7ffc6"), "UK", "United Kingdom" },
                    { new Guid("b2828cb1-e324-405b-b4e4-46721820b1a7"), "LT", "Lithuania" },
                    { new Guid("07c054a2-7d9b-439a-b54a-e0a1c7d3b10e"), "LI", "Liechtenstein" },
                    { new Guid("7f288f77-f005-40a1-9bf0-2bcd0f62d4dd"), "SE", "Sweden" },
                    { new Guid("64d404c4-9d91-47de-8414-53f07fbab775"), "IT", "Italy" },
                    { new Guid("6763e3db-481b-4877-b9d2-752d78fa260b"), "LV", "Latvia" },
                    { new Guid("cd6eba4c-5672-4dcb-ac52-767aec958e23"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("b3b27d47-9742-417f-b0de-d85a128c2d8e"), "BE", "Belgium" },
                    { new Guid("3be02dd1-d859-49d4-95d2-f008e58dbd5d"), "HR", "Croatia" },
                    { new Guid("232c51e6-6ac6-4696-8d95-676ff0541011"), "CY", "Cyprus" },
                    { new Guid("260f1d83-260c-44a8-82d7-7086f87bbed5"), "CZ", "Czechia" },
                    { new Guid("7418a8da-05cf-494d-bb75-b66c3f3f9a8d"), "DK", "Denmark" },
                    { new Guid("6d9915ca-9644-4242-8a1d-b3d2f05b6539"), "BG", "Bulgaria" },
                    { new Guid("e65f5554-98f7-4630-9ebd-5c7a3c1136a8"), "FI", "Finland" },
                    { new Guid("5796198a-a13e-4951-9168-3981eb935517"), "FR", "France" },
                    { new Guid("ed8d9290-6a03-4c78-91a9-ded88049eb7f"), "DE", "Germany" },
                    { new Guid("8c5a7461-111b-478c-8acd-79246bfeab2a"), "EL", "Greece" },
                    { new Guid("7c893ea6-8cdb-427d-847a-68bd1612b5f0"), "HU", "Hungary" },
                    { new Guid("939a630c-84d5-4261-a2bc-fe3d94c30669"), "IS", "Iceland" },
                    { new Guid("a12fe0ab-f001-4b3d-94a4-67d5ed6c7934"), "EE", "Estonia" },
                    { new Guid("eb714e01-7c1d-416d-898e-73e79f91f82e"), "IE", "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("4c207d8f-b9d6-4f23-b1b2-d9ea4bbea561"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("d9c8d061-49e5-4b16-bbef-cc1d8e29ac57"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)2, "Frequency" },
                    { new Guid("91695e3a-7066-4660-af9e-6e26fa458432"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false}]", new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)1, "Ownership type" },
                    { new Guid("5a08b013-d3ef-4757-95ba-1b5c2069db43"), (short)6, null, new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)5, "Other" },
                    { new Guid("2f422b71-51fd-4e8d-950f-0d46afe073fe"), (short)6, null, new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)4, "Resources" },
                    { new Guid("cfaae7b0-bc34-4fbc-bb8a-7ddbbe7afe66"), (short)7, null, new Guid("9acd91c1-be41-4d7c-b1ee-87a97c041706"), (short)5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("107b2af6-74fe-4d5b-b37c-c09c89e28864"), (short)6, null, new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)2, "Production machinery" },
                    { new Guid("a3cbef62-52a0-48a8-9e86-b432033e46b5"), (short)7, null, new Guid("9acd91c1-be41-4d7c-b1ee-87a97c041706"), (short)4, "Sales Buildings (Shop)" },
                    { new Guid("1f07bdfb-1e3d-4e6e-8156-6096ff282668"), (short)7, null, new Guid("9acd91c1-be41-4d7c-b1ee-87a97c041706"), (short)3, "Inventory Buildings" },
                    { new Guid("c5213ec4-0eb9-493d-8214-087cf0f2f011"), (short)6, null, new Guid("4c207d8f-b9d6-4f23-b1b2-d9ea4bbea561"), (short)1, "Brands" },
                    { new Guid("06058194-90e9-4cc6-95ad-c8ce968d5987"), (short)7, null, new Guid("9acd91c1-be41-4d7c-b1ee-87a97c041706"), (short)2, "Manufacturing Buildings" },
                    { new Guid("c6a0110e-5a65-4ab4-a6c8-4203aab66a67"), (short)6, null, new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)3, "Transport" },
                    { new Guid("0ddfb52d-c33f-493d-be89-e9273aea2119"), (short)6, null, new Guid("4c207d8f-b9d6-4f23-b1b2-d9ea4bbea561"), (short)2, "Licenses" },
                    { new Guid("049ddeff-4ae5-433a-aa92-2dfccbb426e0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)2, "Frequency" },
                    { new Guid("2dfe03a4-9eed-48cc-93a7-37568e6f6225"), (short)6, null, new Guid("4c207d8f-b9d6-4f23-b1b2-d9ea4bbea561"), (short)4, "Other" },
                    { new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("c60e5310-4c56-4cba-b217-25e1558ccff3"), (short)6, null, new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)1, "Know-how" },
                    { new Guid("4676586b-820d-46ee-93cf-61a634566377"), (short)6, null, new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)2, "Office" },
                    { new Guid("473403a2-023e-4aa1-8986-968d20a9c1f4"), (short)6, null, new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)3, "Factory/service" },
                    { new Guid("984c2e97-5ebe-45cc-8cab-5cd7295a6ced"), (short)6, null, new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)4, "Other" },
                    { new Guid("aad92c20-5da9-4d4d-90f5-2feb61085d24"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("bdc1c905-c4e7-41be-9315-2f112b5bf249"), (short)1, "Ownership type" },
                    { new Guid("4e9200d3-380b-4781-918f-13f03d61ea36"), (short)5, "The financial resource includes cash, lines of credit and the ability to have stock option plans for employees. All businesses have key resources in finance, but some will have stronger financial resources than other, such as banks that are based entirely on the availability of this key resource.", null, (short)4, "Financial resources" },
                    { new Guid("30bd9a06-5ed6-4b7d-a034-fc6057e4e2a8"), (short)6, null, new Guid("4e9200d3-380b-4781-918f-13f03d61ea36"), (short)1, "For start-up" },
                    { new Guid("b92b2ad0-9bb2-4a48-8ac6-faa3f697a928"), (short)6, null, new Guid("4e9200d3-380b-4781-918f-13f03d61ea36"), (short)2, "Operational" },
                    { new Guid("7098477b-31ea-4e90-9db3-656f6ac50015"), (short)8, "[{\"title\":\"Yes\",\"selected\":false},{\"title\":\"No\",\"selected\":false}]", new Guid("4e9200d3-380b-4781-918f-13f03d61ea36"), (short)1, "Is available?" },
                    { new Guid("c8bba288-51a8-4a51-abca-1c8666a12a0c"), (short)5, "", null, (short)5, "Other" },
                    { new Guid("d2db4aeb-b5d0-4812-b449-c44e38e7dfa4"), (short)7, null, new Guid("9acd91c1-be41-4d7c-b1ee-87a97c041706"), (short)1, "Office" },
                    { new Guid("f4b8108c-ece8-4cd4-860b-02ce86253660"), (short)6, null, new Guid("4c207d8f-b9d6-4f23-b1b2-d9ea4bbea561"), (short)3, "Software" },
                    { new Guid("9acd91c1-be41-4d7c-b1ee-87a97c041706"), (short)6, null, new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)1, "Buildings" },
                    { new Guid("950c3e5b-c1d7-401c-8769-1929808c602a"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("5641268d-1cf9-4e58-b79d-7257c65d5540"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("3d18b9f0-1bc4-4ccb-b02a-361d2926d18a"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("908848e8-c31e-4ac2-83ca-76225f7f1cdd"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("68fb9a25-75d5-4e2d-8668-323b00917d97"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("3db1db93-bcf5-4491-9640-8831043b94bc"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("a2c02476-2691-4203-be48-354deb445d0c"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("882e7bd3-9fc4-40c4-a3a1-33329b0f7693"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("4d4b6c93-d5f4-43d1-8a67-1c9b6642d850"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("cfe9ad59-1d0d-49d3-8416-28df2d05e88c"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("28a524b6-2569-408a-9430-6ac2fb4b1621"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("397f6b31-f86c-46f5-83f7-b8853e0ca393"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("275d4cb4-74f1-4fcd-8ede-2e117de91b1d"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("17f3df6c-0bdd-4846-9a19-e155e38d31a3"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("1cba3fbe-5af2-4845-b2cd-9d5f66cbd13f"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("98669c70-b9b5-4901-a262-9ddef513e61f"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("060dd9f2-965d-42ce-a62a-c84c73d3521a"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("8aca00fa-bf1f-46d5-844f-8fb38177fdd4"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("41d3f5d3-47df-4fb2-b27c-4ef98dfecb06"), (short)1, "a", null, (short)18, "Return of goods" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("ccff4586-a8b2-4563-9e35-d820aedd9b0c"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("cf476f67-0ad3-4c08-a516-a11b34324310"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("4b9af6da-e3ec-4ffe-85a0-efdd535ba081"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("d57c7c0e-10c9-439f-a95e-c839ea8971e0"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("4f7ff17f-3994-4df9-bcfa-d055397ee8a1"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("d26ca7c0-f903-4afe-b3a1-ea7557cd7935"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("1d626ff4-fcf1-4d11-a027-3512d6d0c0ef"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("18ee5bec-ce85-48fd-bfcf-e977b59fa2ea"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("f09fead5-f828-48c9-8fb4-1ed0d562bde7"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("9100165a-5447-4c65-8dc4-4dde0162d2c8"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("0a57b538-971a-4433-b018-46ca87440886"), (short)1, "a", null, (short)15, "Packaging and labeling" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 100, "Simple" }
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
