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
                    { new Guid("29806c4b-d85f-4e06-8a49-972ff0de14d5"), "AT", "Austria" },
                    { new Guid("ab397403-d0da-43df-9c92-dfe80a649967"), "LU", "Luxembourg" },
                    { new Guid("eb92910a-1bcb-4187-b507-236096fcb0dd"), "MT", "Malta" },
                    { new Guid("17fd8da6-e68e-4ca2-8476-f5c1dd3755a4"), "NL", "Netherlands" },
                    { new Guid("900b90e0-6e41-466f-b271-360d27c84aa9"), "MK", "North Macedonia" },
                    { new Guid("9f3f79cd-ec1a-494d-81ed-3cd200719c82"), "NO", "Norway" },
                    { new Guid("58f7e746-85ca-4aec-8b2e-39ec7e856dd5"), "PL", "Poland" },
                    { new Guid("25a513ad-4718-4688-9ade-2e411905fad4"), "RO", "Romania" },
                    { new Guid("a4a2cc9f-656a-48cd-88f9-50e7a540f384"), "RS", "Serbia" },
                    { new Guid("edf6dbfa-4995-4ce7-ab44-c5ae0df48154"), "SK", "Slovakia" },
                    { new Guid("11d89805-e111-4c16-adf4-c2b758fd39c1"), "SI", "Slovenia" },
                    { new Guid("1ab6ce2e-a51a-44dc-9cb8-f25f80db24a2"), "ES", "Spain" },
                    { new Guid("e8677a3a-c5eb-4f26-a084-3b0ddb5c1603"), "SE", "Sweden" },
                    { new Guid("9fc1cfc7-6ae1-4602-adb9-049ad16e59f5"), "CH", "Switzerland" },
                    { new Guid("3d85e579-9181-4dee-b8e3-dbb5f3e1ba9c"), "TR", "Turkey" },
                    { new Guid("a50ad36b-5c41-4c96-83db-f5044ede77d3"), "UK", "United Kingdom" },
                    { new Guid("8fcf6f85-10ba-441e-95ad-fcdcb7804d18"), "LT", "Lithuania" },
                    { new Guid("b794433d-413f-4c14-8c77-970497b8d817"), "LI", "Liechtenstein" },
                    { new Guid("43682bc1-0d02-4f9b-9068-8b8c6dd494d8"), "PT", "Portugal" },
                    { new Guid("e3f3ca2f-8045-4b10-97e7-52cbe98367f3"), "IT", "Italy" },
                    { new Guid("6c14ed17-892a-4d92-8672-c723bc619ce7"), "LV", "Latvia" },
                    { new Guid("4ae789fd-ebb1-4074-8fa8-704e96a85583"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("a7a082e3-bdc6-4e40-9472-560b1c3780ad"), "BE", "Belgium" },
                    { new Guid("793c8ade-8656-460c-bb65-ffc30a421cfd"), "BG", "Bulgaria" },
                    { new Guid("bde293c4-1a13-421b-9d54-8dc719f71064"), "HR", "Croatia" },
                    { new Guid("d2ca55a7-4bf5-495f-bba9-f26908729d97"), "CZ", "Czechia" },
                    { new Guid("485d0d4e-2ebc-425b-ab97-e6405b16a200"), "DK", "Denmark" },
                    { new Guid("b58e8ea5-ee30-46fc-8415-ea85148a7047"), "EE", "Estonia" },
                    { new Guid("9491f7f9-cf78-48cb-9dbc-4049ad5ccb89"), "CY", "Cyprus" },
                    { new Guid("f94d6c77-407d-4249-9221-82789368e916"), "FR", "France" },
                    { new Guid("f19c804f-35d1-466c-b608-8f0fe2332050"), "DE", "Germany" },
                    { new Guid("fa746db5-c5e5-4597-835d-bc3a843f10a7"), "EL", "Greece" },
                    { new Guid("3a9b9553-ca89-4951-b77b-766b6b0d4374"), "HU", "Hungary" },
                    { new Guid("25ae8878-213c-4275-867c-793d36ada33f"), "IS", "Iceland" },
                    { new Guid("e0adce69-addd-4389-b1a3-e06fb0bcb679"), "IE", "Ireland" },
                    { new Guid("40062cdd-9235-47f3-9614-0661fa709e86"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("54d9a32d-994e-4e06-8b24-50a558bf0c34"), (short)6, null, new Guid("e9639458-9779-4c24-9cd4-1b593b92ccd9"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("7bb79880-d79b-453d-9c0d-940b2705aa56"), (short)6, null, new Guid("e9639458-9779-4c24-9cd4-1b593b92ccd9"), (short)1, "Specialists & Know-how" },
                    { new Guid("63ab951d-5dfe-4330-8160-daebede1bedb"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("722d42a6-511c-4dc9-bbdf-c94848f54444"), (short)2, "Frequency" },
                    { new Guid("3d37c769-a806-4b7e-969c-c32ea6e88e62"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("722d42a6-511c-4dc9-bbdf-c94848f54444"), (short)1, "Ownership type" },
                    { new Guid("722d42a6-511c-4dc9-bbdf-c94848f54444"), (short)6, null, new Guid("e9639458-9779-4c24-9cd4-1b593b92ccd9"), (short)2, "Administrative" },
                    { new Guid("718b21ac-f828-4c8a-967b-9b33b5d1fce4"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("7bb79880-d79b-453d-9c0d-940b2705aa56"), (short)2, "Frequency" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("9a16c837-eafb-4eb6-ad51-94362acd2487"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("7bb79880-d79b-453d-9c0d-940b2705aa56"), (short)1, "Ownership type" },
                    { new Guid("e9639458-9779-4c24-9cd4-1b593b92ccd9"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("f7fa041e-350c-45a2-a639-2721d728d9c1"), (short)6, null, new Guid("acf21675-8b93-48b9-b2f5-ed2359163b9f"), (short)5, "Other" },
                    { new Guid("d20445fd-edd6-45b3-9617-69d5dc410a38"), (short)6, null, new Guid("4337ab6d-c76a-4b16-bf24-9c31a546eb5c"), (short)3, "Software" },
                    { new Guid("0b77606d-09f9-4396-ac80-ea4e7159cff3"), (short)6, null, new Guid("4337ab6d-c76a-4b16-bf24-9c31a546eb5c"), (short)2, "Licenses" },
                    { new Guid("a17f4c09-ac0e-4525-8315-b2b45f4525f8"), (short)6, null, new Guid("4337ab6d-c76a-4b16-bf24-9c31a546eb5c"), (short)1, "Brands" },
                    { new Guid("4337ab6d-c76a-4b16-bf24-9c31a546eb5c"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("b30d1712-41bc-49b0-90f3-1be698ee32da"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f7fa041e-350c-45a2-a639-2721d728d9c1"), (short)2, "Frequency" },
                    { new Guid("690278b8-2d0a-4913-8200-43af5ea35475"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f7fa041e-350c-45a2-a639-2721d728d9c1"), (short)1, "Ownership type" },
                    { new Guid("02ce0e28-2f87-4406-b61c-079056156451"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("54d9a32d-994e-4e06-8b24-50a558bf0c34"), (short)1, "Ownership type" },
                    { new Guid("54d29d29-f32c-4fd7-9f84-248a8fac0441"), (short)6, null, new Guid("4337ab6d-c76a-4b16-bf24-9c31a546eb5c"), (short)4, "Other" },
                    { new Guid("add942d6-7fea-402d-9f12-c833680e9b6d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("54d9a32d-994e-4e06-8b24-50a558bf0c34"), (short)2, "Frequency" },
                    { new Guid("b7241727-8a24-4cc2-95d6-fdfa34248c62"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("78f73dc2-e573-40e2-9e51-b436a827ad41"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("fe3e7dac-bfbb-46f1-b074-ea41fa7ed8d6"), (short)1, "Ownership type" },
                    { new Guid("f07bca18-1b81-4490-aca4-2fc235cf5078"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("b5d76c6d-03cb-42d4-882c-5b51ed84f2e9"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("e5513499-a7e6-4c6c-bd88-fb6d00abd0f8"), (short)1, "Ownership type" },
                    { new Guid("2d156aca-4ae9-4668-958f-ede0fcb5e86d"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("ffcd6ea8-6aac-439d-95b9-76115e1873b1"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("3da21b93-5391-4460-8886-f85a7d179036"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("32c16ddf-4eb1-4f85-a471-d8b101224633"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("c1563709-3630-4347-98b0-b1f63d74c3b7"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("9b450966-cdbf-40ee-be3f-03ee3ddfcbe2"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("e6f85231-90ea-4b9d-b72c-48533b4f0e4a"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("66c213c9-ea86-433d-9be0-195dc00c5fbe"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("beb8488e-80b8-4ef8-a5b1-e3c88cdc27c5"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("e2c25987-1ed5-4835-93eb-ae71bc3157f5"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("a24f62b9-9b39-46ab-9010-7b0a27357b86"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("fa16364c-977f-4409-b27a-9c5f5429642d"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("62c0a2ae-d09b-49e2-bb75-6b3713cd1a68"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("320bc7e7-c21c-4329-bae3-f42e2ad10b06"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("ab1d1762-e6e5-4b53-bcf9-271629638b80"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fe3e7dac-bfbb-46f1-b074-ea41fa7ed8d6"), (short)2, "Frequency" },
                    { new Guid("fe3e7dac-bfbb-46f1-b074-ea41fa7ed8d6"), (short)6, null, new Guid("e9639458-9779-4c24-9cd4-1b593b92ccd9"), (short)4, "Other" },
                    { new Guid("e5513499-a7e6-4c6c-bd88-fb6d00abd0f8"), (short)6, null, new Guid("acf21675-8b93-48b9-b2f5-ed2359163b9f"), (short)4, "Raw materials" },
                    { new Guid("1913a85f-a83c-4e11-84ac-034acfef1335"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("f56a75ab-3d24-4378-a9f3-195db5a10415"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ee211d86-4e49-458b-9730-8d4b7bae3ba5"), (short)1, "Ownership type" },
                    { new Guid("5b5fb932-6747-4e55-9aae-b7261532e42f"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("0a6eec93-63fa-4488-acb2-1db6bd2e8197"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("97b6bda3-15c3-4824-9f1d-c743ecabac2e"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("be441a81-83ae-4ecc-b236-8558ae0e4c82"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("11b7aada-bbd9-472b-a74d-fcbc6f95ea58"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("7b85f3a7-8342-44cb-9607-2affeed260b1"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("c1e9b860-4449-4dc7-a2db-b5067f72ba0a"), (short)1, "a", null, (short)10, "Operational processes" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e6d43157-6b17-4379-9f90-e9ab9fb30bce"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("b7f5aa0a-3969-4fb7-b5a3-efe609dbc739"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("e3e3f9d7-536e-44ab-ad52-2fa92087a75e"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("1718c5af-97e0-4efb-8c94-7a01af4280f8"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("87f2e937-5c58-4694-9438-132549ba2c42"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("b78c3603-fe20-492e-bf8b-780fc9f29743"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("89fc96e9-bd8b-4d44-94c7-6f5dfe7d7b70"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("5a521f07-d2bc-4490-887f-a82861d88edc"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("fa0e4a99-1f1a-4b54-bedd-9bec0c1b5041"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("8a4797de-bd18-4be8-a915-7aa63d295709"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("dab0f45e-01d3-4c6e-b999-82631f27c1f9"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("199d34cc-04f3-4ef0-a205-18a92ef4f337"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("513d529f-c751-43a6-adb1-99a3230b3bcb"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("ee211d86-4e49-458b-9730-8d4b7bae3ba5"), (short)6, null, new Guid("acf21675-8b93-48b9-b2f5-ed2359163b9f"), (short)3, "Transport" },
                    { new Guid("7118eb1c-a9ad-4cac-8d74-bcd8b55c6dd4"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("6419bc24-0fe8-4709-be7b-efc05dab6bc2"), (short)2, "Frequency" },
                    { new Guid("73fc0c8d-89fd-49b8-8ec4-8825d50b3dee"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("6419bc24-0fe8-4709-be7b-efc05dab6bc2"), (short)1, "Ownership type" },
                    { new Guid("6419bc24-0fe8-4709-be7b-efc05dab6bc2"), (short)6, null, new Guid("acf21675-8b93-48b9-b2f5-ed2359163b9f"), (short)2, "Equipment" },
                    { new Guid("c7a958b2-94a9-486f-aea4-0018ced60706"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("337bcfe6-d7f7-4049-927b-17dccf2a0223"), (short)2, "Frequency" },
                    { new Guid("9204347d-ff82-4ed2-8c6d-6dfc91c3c0f7"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("337bcfe6-d7f7-4049-927b-17dccf2a0223"), (short)1, "Ownership type" },
                    { new Guid("337bcfe6-d7f7-4049-927b-17dccf2a0223"), (short)6, null, new Guid("acf21675-8b93-48b9-b2f5-ed2359163b9f"), (short)1, "Buildings" },
                    { new Guid("acf21675-8b93-48b9-b2f5-ed2359163b9f"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("8116aeeb-bd23-40e0-9e3c-69364a1f8b0f"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("5a72cac5-dc05-4dec-b9a5-4253db9c697b"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("90cc8e16-b58b-45f4-bc9c-4c5ac0837baf"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("6d0a32d8-86e9-4ab4-b09f-0445312550e4"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("08ff0984-c781-4e85-8a79-cde60782b27c"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("1b630500-61ad-441c-9612-730936b8f1a3"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("7345490c-2e26-4201-9171-21c053fdb8f0"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("7526235c-1443-47c1-8e08-34d38cc8faf1"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("b2d46133-1b0f-48e5-9d05-a22791049191"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ee211d86-4e49-458b-9730-8d4b7bae3ba5"), (short)2, "Frequency" }
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
