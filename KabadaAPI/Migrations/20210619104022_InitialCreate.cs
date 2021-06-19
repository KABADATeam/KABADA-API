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
                    { new Guid("c7752011-6fb3-497b-91f7-1eadfe5bebf7"), "AT", "Austria" },
                    { new Guid("b88656f0-f873-4280-93fe-47fdd833b596"), "LU", "Luxembourg" },
                    { new Guid("6b0ae9ea-e7be-4349-869c-76379ad0bded"), "MT", "Malta" },
                    { new Guid("cbb3351a-136e-4913-b79f-968ef92f27ba"), "MK", "North Macedonia" },
                    { new Guid("6d614265-807e-4d9c-83b4-9d930caa4022"), "NO", "Norway" },
                    { new Guid("dafbff28-a1e5-4fb9-8ead-c77ba9aaa615"), "PL", "Poland" },
                    { new Guid("aab82f2d-80b4-43b5-bbfa-08e4563ada47"), "PT", "Portugal" },
                    { new Guid("972cb460-c6b6-4ef3-bf06-659799f9fe88"), "RO", "Romania" },
                    { new Guid("b81fe13f-6d28-44c0-90ed-81ffaa980435"), "RS", "Serbia" },
                    { new Guid("7c72d164-8a84-44ca-9783-95f67961a3b8"), "SK", "Slovakia" },
                    { new Guid("23ecaa89-9404-4496-84f3-5086ecb732d7"), "SI", "Slovenia" },
                    { new Guid("7e9ab38e-3fc6-4c18-b48f-b02a21b1f224"), "ES", "Spain" },
                    { new Guid("b727e1f7-1ff7-4355-be21-b2ca4dc1878c"), "SE", "Sweden" },
                    { new Guid("dce7ba95-91da-45fc-b563-73608917e376"), "CH", "Switzerland" },
                    { new Guid("1f78699a-f83f-4e80-91b1-8636490d776b"), "TR", "Turkey" },
                    { new Guid("455559e1-e902-4ef4-b520-206d5229b3c4"), "UK", "United Kingdom" },
                    { new Guid("80b13559-7ac0-4188-ac6f-bc8a3a4ac27d"), "LT", "Lithuania" },
                    { new Guid("b63ea517-ec1e-4197-9a4c-7608f021042a"), "LI", "Liechtenstein" },
                    { new Guid("1a266f20-f007-4a09-8f90-0ce6da7742be"), "NL", "Netherlands" },
                    { new Guid("8fce456d-91f6-40e7-8ea3-e0142e6a5008"), "IT", "Italy" },
                    { new Guid("2f6f0645-de0f-4b21-b0b7-7c45ccec1e84"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("7380949d-0f78-4125-81fc-fa3039e269d4"), "BE", "Belgium" },
                    { new Guid("c5128548-8a34-45a3-ad50-10964090fedf"), "BG", "Bulgaria" },
                    { new Guid("25bcfc22-b4f9-4f8f-a8bf-b4ce6868604b"), "LV", "Latvia" },
                    { new Guid("c1a79eee-196d-4353-a8cd-eaf9b9490f5c"), "CY", "Cyprus" },
                    { new Guid("0ee5c31e-eeb2-41b9-8c8b-047e809771bb"), "CZ", "Czechia" },
                    { new Guid("bf632c2d-9835-4639-affe-876fa48d0bef"), "DK", "Denmark" },
                    { new Guid("835bc5f5-220d-4f92-a9e7-b5ebf83ba4b3"), "EE", "Estonia" },
                    { new Guid("957c21e9-d74b-4e13-9826-202b3810cc02"), "HR", "Croatia" },
                    { new Guid("dee2d1ac-6a2c-4d4c-8110-013acd1885b2"), "FR", "France" },
                    { new Guid("f3df26de-336c-4b96-8bc3-e981b6ae5b06"), "DE", "Germany" },
                    { new Guid("645f1ca2-da90-4af8-8fee-a1f6d840d404"), "EL", "Greece" },
                    { new Guid("8f2587b0-90b9-43fe-874b-871755ba7aed"), "HU", "Hungary" },
                    { new Guid("757846ec-a71c-4546-a697-b58b67299a00"), "IS", "Iceland" },
                    { new Guid("387828dc-fc87-454e-99c2-2dcf5587eb6f"), "IE", "Ireland" },
                    { new Guid("13f30709-c2a8-4ba6-af9b-c5df438f466b"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "P", "EN", "Education" },
                    { new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("1fd26d14-c6e8-4720-8a95-8bbe268c7326"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "L", "EN", "Real estate activities" },
                    { new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "J", "EN", "Information and communication" },
                    { new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "C", "EN", "Manufacturing" },
                    { new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "B", "EN", "Mining and quarrying" },
                    { new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "F", "EN", "Construction" },
                    { new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "H", "EN", "Transporting and storage" },
                    { new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("b7a6db3b-303e-4541-8bb8-6694ff3e1493"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e60a5170-7852-4f14-8bdf-b8c0b7268029"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("965a37af-52f1-4bae-9c1d-55dbf2a0dd36"), (short)1, "Ownership type" },
                    { new Guid("637af3c8-a066-4d11-8946-1117da5677e4"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("7cd08900-bb76-4f35-87a4-d82d598bb313"), (short)2, "Frequency" },
                    { new Guid("1476d39d-e091-47ad-b952-1bde818a3e4e"), (short)6, null, new Guid("67b13e33-dd18-413b-a4db-ad33352b67c1"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("58b5a3d7-ed11-43bb-a904-070f0d797046"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("7cd08900-bb76-4f35-87a4-d82d598bb313"), (short)1, "Ownership type" },
                    { new Guid("7cd08900-bb76-4f35-87a4-d82d598bb313"), (short)6, null, new Guid("67b13e33-dd18-413b-a4db-ad33352b67c1"), (short)2, "Administrative" },
                    { new Guid("6caf890f-9c82-44a0-9b2a-a13d1b34ac03"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("965a37af-52f1-4bae-9c1d-55dbf2a0dd36"), (short)2, "Frequency" },
                    { new Guid("965a37af-52f1-4bae-9c1d-55dbf2a0dd36"), (short)6, null, new Guid("67b13e33-dd18-413b-a4db-ad33352b67c1"), (short)1, "Specialists & Know-how" },
                    { new Guid("b98fceba-5593-452b-808b-1c5946b48653"), (short)6, null, new Guid("5d3064d5-22a4-47fe-b8f4-ae7f92188595"), (short)1, "Brands" },
                    { new Guid("57249825-a5ca-46d5-8d9f-c58a1c2c0045"), (short)6, null, new Guid("5d3064d5-22a4-47fe-b8f4-ae7f92188595"), (short)4, "Other" },
                    { new Guid("1d61cd4c-25aa-4348-9562-91d1ba5c2e66"), (short)6, null, new Guid("5d3064d5-22a4-47fe-b8f4-ae7f92188595"), (short)3, "Software" },
                    { new Guid("af282acd-99d1-4c28-afba-c5c51b98d867"), (short)6, null, new Guid("5d3064d5-22a4-47fe-b8f4-ae7f92188595"), (short)2, "Licenses" },
                    { new Guid("fd409f4f-bf32-488e-8d07-eea9cb51cd72"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("1476d39d-e091-47ad-b952-1bde818a3e4e"), (short)1, "Ownership type" },
                    { new Guid("5d3064d5-22a4-47fe-b8f4-ae7f92188595"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("02d68fce-97e4-4df8-8379-f1cb868b8f37"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("a654a8a9-4e65-4edd-b16e-dd036b6b304c"), (short)2, "Frequency" },
                    { new Guid("725a01ed-5ba7-44b1-bc96-4f09ec91063c"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("a654a8a9-4e65-4edd-b16e-dd036b6b304c"), (short)1, "Ownership type" },
                    { new Guid("a654a8a9-4e65-4edd-b16e-dd036b6b304c"), (short)6, null, new Guid("77306f76-30af-4a51-b834-dab9602fb512"), (short)5, "Other" },
                    { new Guid("67b13e33-dd18-413b-a4db-ad33352b67c1"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("00faf68d-cc8c-4c73-b55b-e54148a86851"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("1476d39d-e091-47ad-b952-1bde818a3e4e"), (short)2, "Frequency" },
                    { new Guid("e9b83bea-5a69-4335-969f-3efc28e638c1"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("085b8968-a2d8-4706-957d-c56549be7aa0"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("47a0e259-07ab-4f64-bf82-4f525eba0892"), (short)1, "Ownership type" },
                    { new Guid("16729818-1818-4e2d-9971-e3b4174f5bc3"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f09a8dc8-5423-4d24-9c54-c81acda07fd1"), (short)1, "Ownership type" },
                    { new Guid("e06effaa-a8ec-4c81-b732-34f35b7d7443"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("3ae14858-cc63-4693-ada9-251c06c46908"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("ab419973-136d-4098-a9cf-6ca91c56ad91"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("4b3c456e-c4d5-46ba-a575-44c8e8c3aac8"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("f6ee355a-2d83-400c-8db4-feafc22c964d"), (short)13, null, null, (short)1, "Associations" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7099869a-7f49-474f-a9df-2f9b994e68b2"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("ff2832a1-3d4a-488f-922a-968dcfc492b1"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("8f49bbd1-5db1-4eba-8429-d0e8bc735055"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("c7ff09c9-43ae-40a4-adb7-4b3ba9e0ed9a"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("837f1f3a-a47f-443f-a10c-3e02eeaaa483"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("1623a3d8-af81-4f4e-8fa4-fbb83d833230"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("59060030-cf95-4bc3-85da-d728b04ed545"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("bf7b526a-ad7f-4815-97cb-fcefbcb87074"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("46c84ab0-fa42-43f9-a5fb-f29d2301dc18"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("095d6f4d-2a8f-4cc7-bb01-114df3c7cdea"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("540e54ec-9080-4fee-ac74-a82eb731c946"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("47a0e259-07ab-4f64-bf82-4f525eba0892"), (short)2, "Frequency" },
                    { new Guid("47a0e259-07ab-4f64-bf82-4f525eba0892"), (short)6, null, new Guid("67b13e33-dd18-413b-a4db-ad33352b67c1"), (short)4, "Other" },
                    { new Guid("f09a8dc8-5423-4d24-9c54-c81acda07fd1"), (short)6, null, new Guid("77306f76-30af-4a51-b834-dab9602fb512"), (short)4, "Raw materials" },
                    { new Guid("634aebc1-764b-4fa1-8e59-3f0dd6294f9e"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("c4104a88-8ac9-4408-a1fa-aad9c2a42fc0"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ccb178b5-d29e-473f-a263-c906a9be3c1f"), (short)1, "Ownership type" },
                    { new Guid("1af09c9e-ded2-4807-91cd-143b54c45d97"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("55866910-0e70-4d63-a66a-e4ff3b5bbe75"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("6b950ac4-2986-41a6-8bcd-538eb5d92c90"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("dac5fc74-bdb2-43dc-b5e5-7cbead488358"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("2b748b8e-1b88-409c-a045-141769b244f0"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("32329257-8a9d-4c37-a1fa-db52b57209c5"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("e813290a-25b0-43b9-9ff3-ac4a34046883"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("e0aa1af7-baa1-4fd6-91c4-b5eac22d4b04"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("44ca822f-eba1-46d2-9610-d5e9bd6b9317"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("df441782-15c9-4eff-a691-fb1b3ff7c865"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("33d4053b-1f4b-496b-b229-2b5258172e13"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("1886086e-b34f-4a5e-ba3e-0aa4e38dd165"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("791b3142-a38c-4de9-b78d-ade2398af933"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("8d3e4de8-4e67-4188-beb4-2d7bb35d2b7e"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("edc8c4fe-5f6e-4cc4-b37c-17cfe3c6bb54"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("43ce1f10-aa1d-48ce-9f49-b6eef5c97683"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("c8a34662-8092-45b0-8f61-0ead7bf1e2e6"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("c9c45e49-1370-4594-a2f8-4bb50189e8a9"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ccb178b5-d29e-473f-a263-c906a9be3c1f"), (short)2, "Frequency" },
                    { new Guid("afc4173c-5dda-4fc1-9d13-bf79f046d887"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("bc12998e-a399-4dfd-a32a-6e0e2dad1d7b"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("ccb178b5-d29e-473f-a263-c906a9be3c1f"), (short)6, null, new Guid("77306f76-30af-4a51-b834-dab9602fb512"), (short)3, "Transport" },
                    { new Guid("0f2cfaf5-174e-4d68-b7d9-76609fd013f5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("cd0fe7eb-c03f-4ca8-99a2-3a689d356044"), (short)2, "Frequency" },
                    { new Guid("3c321a90-68c7-4f3d-b128-b3abd9bc2dd5"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("cd0fe7eb-c03f-4ca8-99a2-3a689d356044"), (short)1, "Ownership type" },
                    { new Guid("cd0fe7eb-c03f-4ca8-99a2-3a689d356044"), (short)6, null, new Guid("77306f76-30af-4a51-b834-dab9602fb512"), (short)2, "Equipment" },
                    { new Guid("88bc178d-8ef6-44d8-ae58-7c89d1750c99"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("7dccdae0-5df7-48f5-9de4-92173db702a0"), (short)2, "Frequency" },
                    { new Guid("240797c7-f5cd-4933-862d-75def92d57fe"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("7dccdae0-5df7-48f5-9de4-92173db702a0"), (short)1, "Ownership type" },
                    { new Guid("7dccdae0-5df7-48f5-9de4-92173db702a0"), (short)6, null, new Guid("77306f76-30af-4a51-b834-dab9602fb512"), (short)1, "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("77306f76-30af-4a51-b834-dab9602fb512"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("2d69e13f-149b-4087-a658-e548241f5fdc"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("4b84829d-cdd3-448b-bce5-329a42aebcf1"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("3ddaa060-ec52-4b9a-8fad-912bed878fef"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("244d74f2-368e-4ff1-867e-a9df28a92b30"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("bb38c334-6ecd-4e6e-9745-23fc50897829"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("ef576701-80cd-42a4-84cd-d3d44461f5b3"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("34a8bef9-1953-4bbb-8127-9760a196830f"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("5c95b7f0-92d0-44b5-86c7-952a7daebb71"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("662b0ab1-cbed-41b1-a0b9-2d1383396a20"), (short)1, "a", null, (short)20, "Discounts" }
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
                    { new Guid("b4860f1a-5de6-4705-a46a-8b4f196f24b9"), "A.01", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("fedc9ca2-4bbe-468c-9c4b-5fceaf2fea02"), "H.51.22", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Space transport" },
                    { new Guid("7442d373-900d-4633-ae55-a952c060d5b7"), "H.52", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Warehousing and support activities for transportation" },
                    { new Guid("26fbcdd9-cb8e-468c-a5e8-290bef7a892b"), "H.52.1", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Warehousing and storage" },
                    { new Guid("f57958f8-1ce3-47df-b1ac-24a328c46c07"), "H.52.10", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Warehousing and storage" },
                    { new Guid("0c712542-7e1d-4086-b1ec-df949cfe6892"), "H.52.2", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Support activities for transportation" },
                    { new Guid("5e6aba37-388f-4e32-8586-689d0e9bba0e"), "H.52.21", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Service activities incidental to land transportation" },
                    { new Guid("1b400ae4-37d5-4e44-81c4-801580f03102"), "H.52.22", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Service activities incidental to water transportation" },
                    { new Guid("52f21949-3da8-4fab-935c-e89994123647"), "H.52.23", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Service activities incidental to air transportation" },
                    { new Guid("7203850f-8c63-496b-b542-cc27af5ac96c"), "H.52.24", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Cargo handling" },
                    { new Guid("135540ab-e9a0-4ae3-add5-41e8098666dd"), "H.52.29", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Other transportation support activities" },
                    { new Guid("1b73b372-ec19-4997-beb8-0628ce93ce80"), "H.53", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Postal and courier activities" },
                    { new Guid("535abfe1-2fd0-4c07-be61-14496522ff8a"), "H.53.1", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Postal activities under universal service obligation" },
                    { new Guid("04419a06-d772-4a3c-91ad-fd1784f22d99"), "H.51.21", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Freight air transport" },
                    { new Guid("d9604b4d-9bbf-40d9-89ef-8a80ec166617"), "H.53.10", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Postal activities under universal service obligation" },
                    { new Guid("0302858c-5744-44c2-8538-d68216a78849"), "H.53.20", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Other postal and courier activities" },
                    { new Guid("dc2711ce-002e-4868-9ec5-ff89d2398596"), "I.55", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Accommodation" },
                    { new Guid("70dc19bd-2b3b-4077-822b-6f222e1c9825"), "I.55.1", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Hotels and similar accommodation" },
                    { new Guid("36b100b3-b438-42ef-861b-dc594bcd3078"), "I.55.10", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Hotels and similar accommodation" },
                    { new Guid("ea60409c-6043-4251-a814-84cd20e04401"), "I.55.2", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Holiday and other short-stay accommodation" },
                    { new Guid("457de1a6-4c49-465e-aba7-c30730d53bfb"), "I.55.20", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Holiday and other short-stay accommodation" },
                    { new Guid("c94516a0-04ad-4c05-a052-b940b8ae8cba"), "I.55.3", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("886332ec-5263-4b61-87c0-8e9f1bbcdb8a"), "I.55.30", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("14ab31bc-67b3-4c64-9362-66c5fed5e983"), "I.55.9", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Other accommodation" },
                    { new Guid("e357c2d4-2080-46fe-8b7e-ef10364de84b"), "I.55.90", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Other accommodation" },
                    { new Guid("53991bb0-245a-41a7-b98f-577d1b48dcbb"), "I.56", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Food and beverage service activities" },
                    { new Guid("0106cfce-6aa3-4624-840d-ca69cc14747b"), "I.56.1", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Restaurants and mobile food service activities" },
                    { new Guid("5dbb02cf-9f0f-40ee-bce3-6049db94197a"), "H.53.2", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Other postal and courier activities" },
                    { new Guid("202b54c5-15d0-4bd5-aae7-f156b9b4af25"), "H.51.2", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Freight air transport and space transport" },
                    { new Guid("2703a6e8-6816-4bf0-ab66-a1a9c18d6138"), "H.51.10", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Passenger air transport" },
                    { new Guid("8246a80f-8f95-440d-a9cb-f5556636cbdb"), "H.51.1", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Passenger air transport" },
                    { new Guid("8ebdf1a5-b435-4cb4-a4a4-7edf8c66a528"), "G.47.9", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("7cfa62d1-fc82-46f0-b3b6-882c7779e0d9"), "G.47.91", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("fe27eaf0-e327-42d0-823f-b1f7940d78ec"), "G.47.99", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("c79db65f-bfa6-400a-965f-2365fcbb66b3"), "H.49", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Land transport and transport via pipelines" },
                    { new Guid("3d1febe0-6baa-4308-8997-3440616caac3"), "H.49.1", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Passenger rail transport, interurban" },
                    { new Guid("b5d3b13b-7998-4d44-b991-5ca20522840b"), "H.49.10", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Passenger rail transport, interurban" },
                    { new Guid("3ffae2bf-e1f6-48cb-8fdc-abcacdfd6cf3"), "H.49.2", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Freight rail transport" },
                    { new Guid("bcbeeb8d-1bf5-42d1-bc1d-3cf4fa80d3e0"), "H.49.20", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Freight rail transport" },
                    { new Guid("3bd8d843-75d7-46bb-98f8-285b91e1cd52"), "H.49.3", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Other passenger land transport" },
                    { new Guid("8cb607a7-5ee6-4116-855c-69b3407f2e30"), "H.49.31", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Urban and suburban passenger land transport" },
                    { new Guid("7e23e3ca-669e-4f63-a05c-ea08ddbf89f2"), "H.49.32", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4353b6ba-2a9d-48f8-91cb-447ea0f0d937"), "H.49.39", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Other passenger land transport n.e.c." },
                    { new Guid("a8ad1739-4e1d-4dd0-b007-204791a71475"), "H.49.4", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Freight transport by road and removal services" },
                    { new Guid("ae0c2352-2539-44a2-bd75-d70a998ccdc2"), "H.49.41", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Freight transport by road" },
                    { new Guid("07129114-4e4e-4fcf-8bfa-7d030940608f"), "H.49.42", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Removal services" },
                    { new Guid("40967b06-07d2-4f02-a2cc-b312b22f7890"), "H.49.5", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Transport via pipeline" },
                    { new Guid("b6d556d3-866f-4d36-a1d1-0a0ac518e267"), "H.49.50", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Transport via pipeline" },
                    { new Guid("cabd06a8-c2c1-47f5-92f1-85b5387a4327"), "H.50", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Water transport" },
                    { new Guid("53b3fbd1-ec52-4ed5-aaa3-5fc1de8c6365"), "H.50.1", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Sea and coastal passenger water transport" },
                    { new Guid("28c21191-c048-47df-adf8-727960221b63"), "H.50.10", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Sea and coastal passenger water transport" },
                    { new Guid("2cca3ac0-3c4f-4ede-aed6-f43b1e56858f"), "H.50.2", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Sea and coastal freight water transport" },
                    { new Guid("31f5876a-afbd-425f-bdbf-276ab8f3ac0f"), "H.50.20", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Sea and coastal freight water transport" },
                    { new Guid("21e72b54-5a94-4bb3-8c40-31e15c34c63c"), "H.50.3", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Inland passenger water transport" },
                    { new Guid("32f0ef62-6f56-4554-ba0f-47b69ecd143d"), "H.50.30", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Inland passenger water transport" },
                    { new Guid("5796a664-f0e1-4158-878c-b7061854fcd2"), "H.50.4", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Inland freight water transport" },
                    { new Guid("00ebdb69-dade-4242-a63e-a5e497a3a1a6"), "H.50.40", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Inland freight water transport" },
                    { new Guid("ae33abfc-7490-431d-bea0-af6d62dbe346"), "H.51", new Guid("b7606a21-104e-48e3-b2d9-b6babf251344"), "Air transport" },
                    { new Guid("857c6794-ee6c-45b3-9665-71859a87d70c"), "I.56.10", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Restaurants and mobile food service activities" },
                    { new Guid("45312a43-ca51-486f-a1be-a431ac08ba64"), "G.47.89", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("78000297-8384-46f0-a708-111049039908"), "I.56.2", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Event catering and other food service activities" },
                    { new Guid("b6ef9c8a-628a-4f22-b641-43783914ae22"), "I.56.29", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Other food service activities" },
                    { new Guid("85ea1cc0-d85d-448f-99da-7cd0752b67cb"), "J.61.30", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Satellite telecommunications activities" },
                    { new Guid("2eedee8d-9f6e-4d2d-9fec-57fbdbec9890"), "J.61.9", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other telecommunications activities" },
                    { new Guid("afc1c73a-0c43-4629-848a-e33066ed0fec"), "J.61.90", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other telecommunications activities" },
                    { new Guid("0c7773fc-568e-4fc1-bdfa-afdb7fb562be"), "J.62", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Computer programming, consultancy and related activities" },
                    { new Guid("7b131b16-495a-4aeb-9ef3-9d9bf341fab7"), "J.62.0", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Computer programming, consultancy and related activities" },
                    { new Guid("d7e80312-e05f-4c0c-bcce-962a06ebcb8d"), "J.62.01", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Computer programming activities" },
                    { new Guid("63717a65-6449-4980-bb27-9ba5c2a3c33a"), "J.62.02", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Computer consultancy activities" },
                    { new Guid("271228f6-1cf1-4491-887e-b547f6113f09"), "J.62.03", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Computer facilities management activities" },
                    { new Guid("2101c4ef-e2a0-49d4-af8b-42eba3517b4a"), "J.62.09", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other information technology and computer service activities" },
                    { new Guid("9dff22b9-b33f-46c2-905e-204c5b6c1a44"), "J.63", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Information service activities" },
                    { new Guid("599730e0-168b-494b-accc-0086c14bbb8b"), "J.63.1", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("7e1187ce-fdba-48df-be00-307dfa175d4c"), "J.63.11", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Data processing, hosting and related activities" },
                    { new Guid("077825fd-1018-4b8b-b154-bde17d985905"), "J.61.3", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Satellite telecommunications activities" },
                    { new Guid("0c90ee5e-fcf8-4359-bc8e-16a5f6a070a6"), "J.63.12", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Web portals" },
                    { new Guid("9c5454a6-28e0-4e7c-963d-b5fc1b05302a"), "J.63.91", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "News agency activities" },
                    { new Guid("55aef4a3-3c15-41fe-97a3-2a6afc3854bf"), "J.63.99", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other information service activities n.e.c." },
                    { new Guid("947be2c4-9df8-4154-b17f-ef27f6f4e39e"), "K.64", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("212739fc-e588-404b-99da-81333f06b35c"), "K.64.1", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Monetary intermediation" },
                    { new Guid("4f47b1f7-2794-49b0-a6f7-6fe17d01f89d"), "K.64.11", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Central banking" },
                    { new Guid("ca065e0e-70cd-4d77-9004-aaba0f249781"), "K.64.19", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Other monetary intermediation" },
                    { new Guid("f53847c3-be43-4b34-86fd-e9bcb3d91694"), "K.64.2", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Activities of holding companies" },
                    { new Guid("a389f4f6-50ea-4444-937b-d61f7ea051b0"), "K.64.20", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("efcf378e-6ac4-46e2-9043-b87bd78a9177"), "K.64.3", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Trusts, funds and similar financial entities" },
                    { new Guid("9c8c38e6-85e5-43e3-aa81-5754b35c39b0"), "K.64.30", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Trusts, funds and similar financial entities" },
                    { new Guid("2ecd2b36-de46-42db-bedf-7d0718770b4c"), "K.64.9", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("d5c62af0-3cfd-4e0e-9224-8d87dc924275"), "K.64.91", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Financial leasing" },
                    { new Guid("3157e0a1-eb3f-4028-9813-b51e206f9a03"), "J.63.9", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other information service activities" },
                    { new Guid("bc93ab2c-3aa7-45ed-93c5-d88c314c2981"), "J.61.20", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Wireless telecommunications activities" },
                    { new Guid("6bbbe4e2-d964-4c9f-a9ab-efe61839659d"), "J.61.2", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Wireless telecommunications activities" },
                    { new Guid("2499a491-877b-4f9e-8dd5-25c70b3b4cd0"), "J.61.10", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Wired telecommunications activities" },
                    { new Guid("9696c5c2-734b-4738-b271-739d32849e39"), "I.56.3", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Beverage serving activities" },
                    { new Guid("e6073dbb-f9cc-4ebb-a7b0-5cd3b45167a3"), "I.56.30", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Beverage serving activities" },
                    { new Guid("8b241168-6c87-441d-87c8-481a87b0feb3"), "J.58", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Publishing activities" },
                    { new Guid("a8e4a202-db40-47be-830b-f4ab7abcdac7"), "J.58.1", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("d2ad0fab-f2f3-4cd1-a5e6-52246610a15f"), "J.58.11", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Book publishing" },
                    { new Guid("1804c103-98a5-4f14-a24c-5c7f37555f97"), "J.58.12", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Publishing of directories and mailing lists" },
                    { new Guid("90750dee-6b80-4d0e-b117-a3e285159e58"), "J.58.13", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Publishing of newspapers" },
                    { new Guid("6368eb1c-35db-4bbc-9123-bb1d2225f254"), "J.58.14", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Publishing of journals and periodicals" },
                    { new Guid("0bd28d08-a16b-48c8-8d7c-3573e535900d"), "J.58.19", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other publishing activities" },
                    { new Guid("32cbdea8-6ea8-49e1-a084-7c8e0fa2a222"), "J.58.2", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Software publishing" },
                    { new Guid("b9cb80f3-0e0b-4a5c-9ece-7aed63320eb3"), "J.58.21", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Publishing of computer games" },
                    { new Guid("7e66ba7b-140f-45aa-9352-338c4f178f1b"), "J.58.29", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Other software publishing" },
                    { new Guid("1229fe46-48ae-4a5f-8d22-fa6256d6b0b5"), "J.59", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("49f87be4-c49c-4128-9f14-4b1a1540103b"), "J.59.1", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Motion picture, video and television programme activities" },
                    { new Guid("d5f97651-f835-4220-8c7e-3efc4c2487df"), "J.59.11", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Motion picture, video and television programme production activities" },
                    { new Guid("a661da35-7710-4412-8efe-a7c2508f9c85"), "J.59.12", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("03d4b5aa-b89d-4427-a493-6928c8c544d8"), "J.59.13", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("51a21179-96ec-4b56-9da6-8fe5181debb2"), "J.59.14", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Motion picture projection activities" },
                    { new Guid("ba92acf5-a533-4c1c-adc4-9b253c082584"), "J.59.2", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Sound recording and music publishing activities" },
                    { new Guid("7e9f709a-ff73-421b-b651-2c6fa9444015"), "J.59.20", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Sound recording and music publishing activities" },
                    { new Guid("b2aa2462-ebbd-42bf-aa7a-e1badb9f255c"), "J.60", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Programming and broadcasting activities" },
                    { new Guid("2a33044b-936b-4dff-b072-ebedd6e046f8"), "J.60.1", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Radio broadcasting" },
                    { new Guid("838bc724-cdfc-4957-95f7-244ef702b89c"), "J.60.10", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Radio broadcasting" },
                    { new Guid("92950db9-7e07-4743-9e8e-a72da3d09ed4"), "J.60.2", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Television programming and broadcasting activities" },
                    { new Guid("cecd084b-1622-4cb0-912e-b289079d91cd"), "J.60.20", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Television programming and broadcasting activities" },
                    { new Guid("78bd584f-4f3e-4df4-99c8-01bdd698e7ee"), "J.61", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Telecommunications" },
                    { new Guid("efa6808c-93e9-4467-ba09-6de396f3d50a"), "J.61.1", new Guid("b8eed88f-6c10-4e92-8744-0dec304c8dce"), "Wired telecommunications activities" },
                    { new Guid("bd3d4fe8-baf6-4840-afbd-a8924e6988e2"), "I.56.21", new Guid("46410180-ada4-40fd-9522-8c7afb29b7d9"), "Event catering activities" },
                    { new Guid("57cbd24c-5f82-4b72-b4f4-4eb43a5e7b47"), "K.64.92", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Other credit granting" },
                    { new Guid("a0929002-4dcf-44ea-ab54-11fd50075c5b"), "G.47.82", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("0e5f765a-091f-4ce4-a988-44a6bc133de5"), "G.47.8", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale via stalls and markets" },
                    { new Guid("2a93a714-6f70-4bd9-b61d-934f7151ea71"), "G.46.19", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("5be01ad2-3e7c-46d4-bf2f-61bff3e9e66a"), "G.46.2", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("329ca64f-abd3-4449-bc28-ff55c7f3881d"), "G.46.21", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("8b0095da-5194-4ce2-a4e9-a0f7241b5095"), "G.46.22", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of flowers and plants" },
                    { new Guid("b6d6f553-37cf-49b4-8180-aa591cb7f965"), "G.46.23", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of live animals" },
                    { new Guid("38225a59-8a31-452b-bfe6-d053c8631dff"), "G.46.24", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of hides, skins and leather" },
                    { new Guid("ed3507ae-3b39-4c6c-9580-8a5070c1c6e4"), "G.46.3", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("3dd1313b-9ea9-4bec-ae62-461b6fa44ec2"), "G.46.31", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of fruit and vegetables" },
                    { new Guid("9f758c2d-b2c2-4656-9776-620d535d6e12"), "G.46.32", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of meat and meat products" },
                    { new Guid("33a90a55-38fb-4e3d-853f-7024fe3af03b"), "G.46.33", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("da40d856-23ed-4776-9a6c-2cde004cdebd"), "G.46.34", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of beverages" },
                    { new Guid("288e64a5-d671-49e6-ae3a-219161931a90"), "G.46.35", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of tobacco products" },
                    { new Guid("aabad8fa-e387-4522-a92e-82cf655e5c4f"), "G.46.18", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents specialised in the sale of other particular products" },
                    { new Guid("60f33b8d-4ecb-4aea-bdfe-bf85e6abd127"), "G.46.36", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("6d9c8c48-d786-46f0-9285-03ac8e35aaf2"), "G.46.38", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("fa8f1d72-7d56-4511-9938-f188ff7e182c"), "G.46.39", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("0c391609-4fad-4f04-8166-8feb7678fe2b"), "G.46.4", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of household goods" },
                    { new Guid("22ecc9db-577c-4252-9506-98837c0d56f0"), "G.46.41", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of textiles" },
                    { new Guid("a81645bf-9115-45c9-b883-b05c400110da"), "G.46.42", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of clothing and footwear" },
                    { new Guid("48249e73-175b-407b-9e7a-5aa779f62280"), "G.46.43", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of electrical household appliances" },
                    { new Guid("9fd584ed-3b57-413a-b6e9-a990be01aa24"), "G.46.44", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("f9bc8307-41a3-4968-97d2-4522bdd0c316"), "G.46.45", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of perfume and cosmetics" },
                    { new Guid("37272fc2-88d1-4a0b-a0e0-896f29a7399d"), "G.46.46", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of pharmaceutical goods" },
                    { new Guid("ea9cdaa5-5251-4693-8e69-abd94641bfc3"), "G.46.47", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("39c9ba26-91ea-4583-8f27-ebff50c1f4ad"), "G.46.48", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of watches and jewellery" },
                    { new Guid("d3915761-22ba-4da1-8e10-1368fdd2d71c"), "G.46.49", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of other household goods" },
                    { new Guid("a1d0ab19-0b7c-440c-8e2f-de8e681c9559"), "G.46.37", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("459c0bc5-b584-4317-8886-f10aceec2204"), "G.46.17", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("b9245e3d-7266-4e88-ba83-f21b80c7a4d4"), "G.46.16", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("96aa9671-6da2-492a-ad88-c7c793aa5ebf"), "G.46.15", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("8e44ba4a-e90d-49fc-802b-89586223496d"), "F.43.29", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Other construction installation" },
                    { new Guid("92a54193-52f3-4b26-b728-0fdaa6df4583"), "F.43.3", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Building completion and finishing" },
                    { new Guid("55ae15fb-94e8-423b-a2b9-5be5e9bc7606"), "F.43.31", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Plastering" },
                    { new Guid("13deb097-4501-40b3-ade7-be76481ab928"), "F.43.32", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Joinery installation" },
                    { new Guid("159448a0-592b-4cc4-81db-98a32dcf45cb"), "F.43.33", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Floor and wall covering" },
                    { new Guid("bdc06488-4c44-4595-8f23-3fb60374f98c"), "F.43.34", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Painting and glazing" },
                    { new Guid("97548229-495d-484a-956e-f7f0bac4f7f8"), "F.43.39", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Other building completion and finishing" },
                    { new Guid("8bf98744-1c64-43f1-b87f-02646e55f7c7"), "F.43.9", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Other specialised construction activities" },
                    { new Guid("25525536-ea6b-4580-b806-6c10196d4a17"), "F.43.91", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Roofing activities" },
                    { new Guid("11932d6d-0eb7-4107-98b9-5823917cd691"), "F.43.99", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Other specialised construction activities n.e.c." },
                    { new Guid("0a8b59f9-db9c-4c7c-8b44-7e1f8e726cce"), "G.45", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("aa2f7ccb-237a-4bba-bd75-e37669a4323f"), "G.45.1", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Sale of motor vehicles" },
                    { new Guid("e7852ff0-3251-4021-9094-8bee882dbe00"), "G.45.11", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Sale of cars and light motor vehicles" },
                    { new Guid("ae81d1be-50b4-4169-b534-ad4fe5b541a6"), "G.45.19", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Sale of other motor vehicles" },
                    { new Guid("ce9401d8-a670-4ae1-b670-fd8e4f3d05d0"), "G.45.2", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6dd30bb2-5ba4-4414-b49e-41fb8d1a2f28"), "G.45.20", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Maintenance and repair of motor vehicles" },
                    { new Guid("d67f4395-779c-4296-b6ed-ec438cb066bd"), "G.45.3", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("1b672e46-b35d-4c87-b444-ece0a1f43744"), "G.45.31", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("4ccac688-9dd1-4fe9-8be0-0c9b7f7ae38c"), "G.45.32", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("bab2eefc-a533-48f9-b7ba-b99ed6ec565b"), "G.45.4", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("af636e4b-0cbf-4ef0-b41a-e710492e407e"), "G.45.40", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("909eed8d-0a2d-40eb-92f7-ba18b86ddc80"), "G.46", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("c4ff383f-99c1-4b73-a92d-e1c909e943be"), "G.46.1", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale on a fee or contract basis" },
                    { new Guid("8ed1acea-4edf-4539-824b-dbf7d61f216f"), "G.46.11", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("fcad9c03-3412-4af5-89f2-516c51af8e29"), "G.46.12", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("fff68f2f-6ea5-494e-87bf-7d16a844d7a3"), "G.46.13", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("847a734f-048c-4c51-a5a4-1485efb2ee73"), "G.46.14", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("390aa553-0b65-4608-984e-8ca84923b00e"), "G.46.5", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of information and communication equipment" },
                    { new Guid("3d353303-f764-4cfd-82f6-f1ba4715d416"), "G.47.81", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("670aa33b-6c5b-4ac2-9831-ec6758532df9"), "G.46.51", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("8d2dc9a4-5e65-49df-8fc6-0a22a19bf281"), "G.46.6", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("7cbad374-5da0-4ced-a7a8-08d5b4e55506"), "G.47.4", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("3171259e-05bb-4628-9364-5bd1731598cf"), "G.47.41", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("edbbb28b-7a91-479b-a739-be43400017e0"), "G.47.42", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("7efa49ec-a218-43e4-91ea-d36c046bd6ae"), "G.47.43", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("100b57a8-7888-4cbd-8f9a-86496d84e010"), "G.47.5", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("0f7b9edc-c116-4820-a265-6e3c12b6b79a"), "G.47.51", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of textiles in specialised stores" },
                    { new Guid("6ae5f583-7ba1-4c52-992d-433f05778b0a"), "G.47.52", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("1d0f07a9-9ad0-43ac-a5bb-a9cbab4d0e4f"), "G.47.53", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("45ca415d-965f-4a5d-8653-877f50da454c"), "G.47.54", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("d8a16cf4-7f1e-4824-97be-14938b191f02"), "G.47.59", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("2f60497e-f0fd-4767-b725-8f0b64b429ce"), "G.47.6", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("7c8e1727-7e0e-43e7-9370-d4176f9956b4"), "G.47.61", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of books in specialised stores" },
                    { new Guid("1e0d2699-648a-4015-8497-76f83f9d7050"), "G.47.30", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("46f414a7-be72-461b-a1e1-1d0882610599"), "G.47.62", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("64a3db0b-31e7-4153-854f-e1844dbb5894"), "G.47.64", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("d4c57578-c09c-417a-9ffb-deff41a4b775"), "G.47.65", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("6ab71e5a-5d9a-4798-b580-08ca03769a1c"), "G.47.7", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of other goods in specialised stores" },
                    { new Guid("f85d55e5-c3be-4fab-bcf3-b6cc9c3a7c0a"), "G.47.71", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of clothing in specialised stores" },
                    { new Guid("63b22f16-7fd5-472b-b21f-01f86e7da500"), "G.47.72", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("866249e2-a319-497d-8786-00d3c4fadffe"), "G.47.73", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Dispensing chemist in specialised stores" },
                    { new Guid("6a3afbb5-487c-4a6d-94f3-b8cf807bfcd2"), "G.47.74", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("9c8f9d8f-d317-466d-b692-9026a07d867b"), "G.47.75", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("f538e197-e3bf-40d5-a590-1969af531860"), "G.47.76", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("5c706d5c-ab0c-4913-887b-24d1c1254fc3"), "G.47.77", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("612fdb60-e50e-4a65-8cb2-da3d28db648f"), "G.47.78", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("89c767ed-e9f5-4545-86e8-53fc36a07b1a"), "G.47.79", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4335eb37-16cb-47da-a5bb-1c1fe76777db"), "G.47.63", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("7eaceb32-09f0-4654-bfed-631037ac11fe"), "G.47.3", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("e6c57b6c-c9ca-4a3b-b426-a0d754d43f18"), "G.47.29", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Other retail sale of food in specialised stores" },
                    { new Guid("3352b74a-9f9c-46ed-8f05-20bd7953aeea"), "G.47.26", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("7eff1d7a-fc68-4cfb-8ec1-de8a437394a3"), "G.46.61", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("6521e26e-6379-4cf0-a7b3-fe3a1d60f4de"), "G.46.62", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of machine tools" },
                    { new Guid("8ae36ff6-83fa-4c83-80c0-7c7cee1330d4"), "G.46.63", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("d34ae3ff-668a-41d7-bd1f-29f48c69bcc7"), "G.46.64", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("e110d5f5-3135-45d5-a8c6-a3c9918d4e9e"), "G.46.65", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of office furniture" },
                    { new Guid("96f274d5-e8a2-4a61-b012-88c71a8e7d76"), "G.46.66", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of other office machinery and equipment" },
                    { new Guid("185d63c3-f837-4f82-92f8-c3f74fa81283"), "G.46.69", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of other machinery and equipment" },
                    { new Guid("f0147115-9564-4658-93ac-8cf94cac0d2a"), "G.46.7", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Other specialised wholesale" },
                    { new Guid("dba1dbd1-c589-4017-8185-e270e81d1e2b"), "G.46.71", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("37a195a9-fc0f-4bab-831e-286ce073e61f"), "G.46.72", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of metals and metal ores" },
                    { new Guid("7649b9c9-6c37-4d9a-a92e-10247d153650"), "G.46.73", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("6e01b85b-b6f8-45ca-b4c2-15044d70201f"), "G.46.74", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("99f52554-3b0e-491f-8e4a-309d5508d84c"), "G.46.75", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of chemical products" },
                    { new Guid("d0148459-b4ae-46a4-8790-ebd635fcda34"), "G.46.76", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of other intermediate products" },
                    { new Guid("c5852d6e-d1b0-44ed-aad4-2bda72edf437"), "G.46.77", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of waste and scrap" },
                    { new Guid("ac4f7cf8-5a01-4e5c-8e1d-03f358288ed1"), "G.46.9", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Non-specialised wholesale trade" },
                    { new Guid("3f772063-fa17-4f3c-8401-eb2b0b357149"), "G.46.90", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Non-specialised wholesale trade" },
                    { new Guid("58d9582e-95fb-454f-a6f7-102ecbc4ae1f"), "G.47", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("81bd8e79-67a7-4aa9-ab01-11a74121206d"), "G.47.1", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale in non-specialised stores" },
                    { new Guid("7a796960-7d83-4d42-afe4-02336b5f1ecb"), "G.47.11", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("cf70aac7-2c8e-4195-82a8-0ac0ced31561"), "G.47.19", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Other retail sale in non-specialised stores" },
                    { new Guid("e46c52bc-68a7-444d-8805-f6f12793802a"), "G.47.2", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("71b753d8-3834-4b99-a60e-06e016cd10a1"), "G.47.21", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("deb536f1-ea05-4863-aa74-7aefcc7dfc7d"), "G.47.22", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("28bd6ad9-e9c7-4496-98fb-c14e87084fda"), "G.47.23", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("5e37a9b7-2cf1-49fb-afed-68ea2249c50b"), "G.47.24", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("b499c677-417b-42dd-9680-6c2142fe7f58"), "G.47.25", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Retail sale of beverages in specialised stores" },
                    { new Guid("3e939e69-9ceb-4fa3-a228-a683b79049f7"), "G.46.52", new Guid("ed2c28a9-e1a8-4137-8e5f-fff757ffed17"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("67722a93-c7f4-4ec1-9a4e-388d966d6fbc"), "F.43.22", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("80f29176-1492-4240-b558-1026d7bd526f"), "K.64.99", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("be54e987-ee23-49c9-aeef-eb7c8c8d4347"), "K.65.1", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Insurance" },
                    { new Guid("72d421b1-5db3-4033-9cfc-a2a089dc2344"), "P.85.6", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Educational support activities" },
                    { new Guid("b52e4d6a-36f6-4bb7-a700-1d0e6a7291b3"), "P.85.60", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Educational support activities" },
                    { new Guid("2dcb10ed-092a-4176-8c20-5cdec85e2272"), "Q.86", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Human health activities" },
                    { new Guid("4b2756ed-b453-4a5a-a459-ff416bbbe4c1"), "Q.86.1", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Hospital activities" },
                    { new Guid("0bfe5eb8-38b6-4adb-a0b8-a32574ff26af"), "Q.86.10", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Hospital activities" },
                    { new Guid("5ed6eb69-afc6-4cc1-9ac0-55a3a3746b52"), "Q.86.2", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Medical and dental practice activities" },
                    { new Guid("4c01d398-5d4b-452e-bf1d-fa3743c0f780"), "Q.86.21", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a8e76c5a-bbcf-490c-b070-3cc8332523e8"), "Q.86.22", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Specialist medical practice activities" },
                    { new Guid("c187362e-d680-426f-a611-f5ee2e208a71"), "Q.86.23", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Dental practice activities" },
                    { new Guid("130da8bf-8a71-40ac-b2b6-2632c832a56f"), "Q.86.9", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Other human health activities" },
                    { new Guid("2b16f2dc-c09f-456a-a590-f1c6495c5229"), "Q.86.90", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Other human health activities" },
                    { new Guid("7230c1e6-7c68-413c-a8b0-31f3769f96f2"), "Q.87", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential care activities" },
                    { new Guid("5bf1f91e-0561-49d1-80f1-a78cb9250cf2"), "P.85.59", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Other education n.e.c." },
                    { new Guid("f64bbb6f-e857-4eb3-a01e-6d21c9ce9783"), "Q.87.1", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential nursing care activities" },
                    { new Guid("7e218264-47cd-4e85-8bbb-a74a4b9fd26c"), "Q.87.2", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("81c5aa69-02eb-461b-8b2d-db8ab073803f"), "Q.87.20", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("46f57cdf-32de-4a1b-9137-443ff8aadbd8"), "Q.87.3", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential care activities for the elderly and disabled" },
                    { new Guid("4bad231b-b61d-4a5d-b16f-8ddc8f9a19c0"), "Q.87.30", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential care activities for the elderly and disabled" },
                    { new Guid("6fb0a867-1b49-487f-8dd8-8b08fbe50b91"), "Q.87.9", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Other residential care activities" },
                    { new Guid("74bc1bde-eb55-4040-9711-fb75e1f8db33"), "Q.87.90", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Other residential care activities" },
                    { new Guid("f402efeb-9a99-4ece-acc6-71210c11a5a7"), "Q.88", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Social work activities without accommodation" },
                    { new Guid("3acc3012-9a7d-477e-92fa-cc485512cc0c"), "Q.88.1", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("e8621cd5-7327-4d6a-a4d8-66cf78e6a055"), "Q.88.10", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("6660525d-51ce-477f-bc38-08aedadf371b"), "Q.88.9", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Other social work activities without accommodation" },
                    { new Guid("b9c9b587-a0e3-45a1-8515-2258b369c8fb"), "Q.88.91", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Child day-care activities" },
                    { new Guid("1266204b-47c3-42d6-9d97-de861555e6ea"), "Q.88.99", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("3ac9a0d2-f3de-452d-bbd5-3a6d3dc17283"), "Q.87.10", new Guid("26cf3645-613d-49c2-b1d7-1e284fd70991"), "Residential nursing care activities" },
                    { new Guid("e2917271-ef9d-472a-8342-8b84a7f5d7de"), "P.85.53", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Driving school activities" },
                    { new Guid("fe557e07-19c7-488a-9a42-4d5aad719d56"), "P.85.52", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Cultural education" },
                    { new Guid("c5cf2c9a-b5ea-439d-96c7-2e90007b44a5"), "P.85.51", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Sports and recreation education" },
                    { new Guid("cec828c6-5cd8-4546-baee-103bb25d8579"), "N.82.91", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Packaging activities" },
                    { new Guid("44d2efe1-3c55-47e7-8877-a8622e6845a4"), "N.82.99", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other business support service activities n.e.c." },
                    { new Guid("6324ffdb-b54f-4aed-8f4b-76bf728a4392"), "O.84", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Public administration and defence; compulsory social security" },
                    { new Guid("d982a83d-f03b-4cea-9919-524131c51fde"), "O.84.1", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("a8faf319-67a2-4393-bf0c-ae8a44f72a7c"), "O.84.11", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "General public administration activities" },
                    { new Guid("ddb5bb6c-a667-4507-94d9-80c7295b38cd"), "O.84.12", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("3f884569-5fa1-465b-8229-64af2a222b3a"), "O.84.13", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("3e8863c6-14b7-48ed-814e-80c5797f5ed8"), "O.84.2", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Provision of services to the community as a whole" },
                    { new Guid("71725b7a-48cd-4b14-b378-405e142fda7c"), "O.84.21", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Foreign affairs" },
                    { new Guid("9dae1981-dbd9-4e25-ace0-2c6faa2d6f79"), "O.84.22", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Defence activities" },
                    { new Guid("396cad83-bccf-4d67-b255-2c16a3a7efeb"), "O.84.23", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Justice and judicial activities" },
                    { new Guid("a0cda046-2521-4a10-8194-338d107dcccb"), "O.84.24", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Public order and safety activities" },
                    { new Guid("f761d292-cc03-4c90-8867-c6a0e205267c"), "O.84.25", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Fire service activities" },
                    { new Guid("a46c257f-50ab-45d9-8d10-0fc704ee48b8"), "O.84.3", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Compulsory social security activities" },
                    { new Guid("9654574d-5495-440a-a70b-8938e081d04a"), "O.84.30", new Guid("a40737a7-0702-43ce-8922-dca840d49d23"), "Compulsory social security activities" },
                    { new Guid("80ba0c8a-650e-454b-99d6-5a8525505ce4"), "P.85", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Education" },
                    { new Guid("7056fbdc-5e94-484b-874a-53a7b4338952"), "P.85.1", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Pre-primary education" },
                    { new Guid("fdee68f5-965e-4603-8474-ae48826d227c"), "P.85.10", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Pre-primary education" },
                    { new Guid("f6222b41-ee22-4368-919a-ac71695cb74a"), "P.85.2", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("86f41f1e-f1d8-47f7-9d1b-1e21dd0b4c85"), "P.85.20", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Primary education" },
                    { new Guid("828f59f6-670f-4ee8-8223-5908b69a301f"), "P.85.3", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Secondary education" },
                    { new Guid("bd37bd17-9db7-445e-82ec-300303b7cfc2"), "P.85.31", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "General secondary education" },
                    { new Guid("fbe56e34-3634-4706-bfa1-0d783eee4f73"), "P.85.32", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Technical and vocational secondary education" },
                    { new Guid("fd762e6d-f293-4d19-865f-eecedadf0837"), "P.85.4", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Higher education" },
                    { new Guid("c8575d40-d128-4946-b88d-dadd4c135675"), "P.85.41", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Post-secondary non-tertiary education" },
                    { new Guid("100a1c8c-3cee-4492-a4e8-b252dba5ffa7"), "P.85.42", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Tertiary education" },
                    { new Guid("24c9680e-a8eb-49d9-92e9-6153d20ee2ed"), "P.85.5", new Guid("9b57f0bf-4bd5-4442-9662-4b4c0827ecac"), "Other education" },
                    { new Guid("424bd47a-d904-4f48-891f-b504325ad746"), "R.90", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Creative, arts and entertainment activities" },
                    { new Guid("9d3cbc59-7011-45b9-8e0b-5eaf5ae398a3"), "N.82.92", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("e3cf8662-e7b8-420d-9293-f44d9edab0bc"), "R.90.0", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Creative, arts and entertainment activities" },
                    { new Guid("acaa269b-8fec-4234-b646-036cbe8408e2"), "R.90.02", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Support activities to performing arts" },
                    { new Guid("c0213579-dcc1-4279-9a13-46ec1fb92831"), "S.95.1", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of computers and communication equipment" },
                    { new Guid("44a61f52-fe0d-497d-a774-a16ae254a463"), "S.95.11", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of computers and peripheral equipment" },
                    { new Guid("7a4c31e8-9635-410e-bb1e-c843d339c900"), "S.95.12", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of communication equipment" },
                    { new Guid("43b864a8-8f78-4db4-a799-a5492ffecf7e"), "S.95.2", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of personal and household goods" },
                    { new Guid("138b3326-13fb-45f9-97b5-a6e9cce04a52"), "S.95.21", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of consumer electronics" },
                    { new Guid("80d8dd6d-5aef-4bba-9335-78061acf4919"), "S.95.22", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("2723ce3d-2cd6-4bcf-88e8-6a423b7cb220"), "S.95.23", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of footwear and leather goods" },
                    { new Guid("752cf813-7b61-4940-8d41-d52553385290"), "S.95.24", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of furniture and home furnishings" },
                    { new Guid("8d79e561-37f7-442c-a260-5427c7099202"), "S.95.25", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of watches, clocks and jewellery" },
                    { new Guid("15b62572-e905-4f8a-844a-d8fc6c1f6816"), "S.95.29", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of other personal and household goods" },
                    { new Guid("13545cc0-17a1-4a1b-8f63-a1d03280ba92"), "S.96", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Other personal service activities" },
                    { new Guid("6f035948-5a2c-42e3-b7f6-ed8197d34f8d"), "S.96.0", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Other personal service activities" },
                    { new Guid("6fc4e97e-21ba-4c06-add9-f632ba1a44aa"), "S.95", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Repair of computers and personal and household goods" },
                    { new Guid("4567d367-b3b3-4515-bef8-35668ef4a5a0"), "S.96.01", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("14a858d4-d289-4088-8055-6a4245e62ba9"), "S.96.03", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Funeral and related activities" },
                    { new Guid("9b334b60-2af6-4027-9b40-eeb5dfc9f31d"), "S.96.04", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Physical well-being activities" },
                    { new Guid("4df41c4e-5369-426e-8f7f-4f5ed4dacec5"), "S.96.09", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Other personal service activities n.e.c." },
                    { new Guid("dccf0873-de2c-4f85-af01-3da61b7663a7"), "T.97", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Activities of households as employers of domestic personnel" },
                    { new Guid("ea7f3629-4b4d-4812-8c26-7dc6281a8a79"), "T.97.0", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Activities of households as employers of domestic personnel" },
                    { new Guid("90b3ff4c-0604-487d-9ca0-bd31fa3da913"), "T.97.00", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Activities of households as employers of domestic personnel" },
                    { new Guid("5caa536a-f0d6-43b9-9f42-0d8189cc809b"), "T.98", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("a1d58d59-4d75-4b36-b9d7-c892b308538c"), "T.98.1", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("13870e51-a174-4e02-b52c-219e5a321798"), "T.98.10", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("1d0c3c4b-2568-4cc6-9764-4f81d628c7e7"), "T.98.2", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("59286d06-55f9-4996-b0e5-3b818aa6f562"), "T.98.20", new Guid("ae41d7de-2689-4869-911a-7a239df00cf2"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("89be61bd-d267-4226-bcf5-29700f9ad677"), "U.99", new Guid("1fd26d14-c6e8-4720-8a95-8bbe268c7326"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("105df747-5611-41c4-b7c6-b3e0951035d2"), "S.96.02", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Hairdressing and other beauty treatment" },
                    { new Guid("e398eba9-3187-4012-9b50-8b27524f5868"), "S.94.99", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of other membership organisations n.e.c." },
                    { new Guid("4fb214e0-e95c-4271-8d24-c75c73578beb"), "S.94.92", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of political organisations" },
                    { new Guid("3930d614-289f-416d-9be7-118dfcfd1e23"), "S.94.91", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0d9caf4c-b625-4d17-b403-333944a3fb29"), "R.90.03", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Artistic creation" },
                    { new Guid("f8787864-80c5-4875-94ca-d0757adaeff2"), "R.90.04", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Operation of arts facilities" },
                    { new Guid("eebeb333-85f1-4532-93d8-1a494b42fd95"), "R.91", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("7523df10-b286-4861-9330-b749039af8d1"), "R.91.0", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("d1ea632f-238a-45f8-bc3b-5afc35c6b5ea"), "R.91.01", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Library and archives activities" },
                    { new Guid("b9544c5c-d53f-489b-9f05-b3dccf313682"), "R.91.02", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Museums activities" },
                    { new Guid("0b914826-e913-4454-b192-53c695ae4a22"), "R.91.03", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("2d80e774-5de4-43e5-9df7-20e79c0ce756"), "R.91.04", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("e1c7b23d-8f9f-4a69-b005-08bdae3ecf1d"), "R.92", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Gambling and betting activities" },
                    { new Guid("4de60587-e497-432d-a76f-85f09add5f09"), "R.92.0", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Gambling and betting activities" },
                    { new Guid("c28206a7-714f-4add-9b1d-a34f7d499e2c"), "R.92.00", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Gambling and betting activities" },
                    { new Guid("353d5430-96f2-4e1c-ba72-7bc7643e99a7"), "R.93", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Sports activities and amusement and recreation activities" },
                    { new Guid("b65a1e4a-9ba8-492c-a4f4-3bae27375ac1"), "R.93.1", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Sports activities" },
                    { new Guid("78d32192-be93-4241-b802-669b96af5eec"), "R.93.11", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Operation of sports facilities" },
                    { new Guid("36c193f1-918f-434f-abed-f87af26309ac"), "R.93.12", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Activities of sport clubs" },
                    { new Guid("b461645d-775b-4920-a3b5-5d7e2d205715"), "R.93.13", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Fitness facilities" },
                    { new Guid("fa66bb69-14b2-4582-9b34-0ded3416b431"), "R.93.19", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Other sports activities" },
                    { new Guid("9f1d4a8c-d3fd-4fd0-b10c-78a91afbecb3"), "R.93.2", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Amusement and recreation activities" },
                    { new Guid("cfb145fa-57be-4367-8a1d-efd337c5cd68"), "R.93.21", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Activities of amusement parks and theme parks" },
                    { new Guid("a308f44b-f569-47fb-8782-2c62f36562f1"), "R.93.29", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Other amusement and recreation activities" },
                    { new Guid("6b71c8e1-2563-4c9e-8223-fcb7b08312c7"), "S.94", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of membership organisations" },
                    { new Guid("cf5b7580-372e-4bb7-8c3c-7db8ce14a94d"), "S.94.1", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("dbc7b809-ab1b-43c5-b63b-06387a3ff266"), "S.94.11", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of business and employers membership organisations" },
                    { new Guid("50887581-a5fb-4fb8-8bb2-6d44214228ee"), "S.94.12", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of professional membership organisations" },
                    { new Guid("982f2d7d-07d7-49ae-b484-821073a9fb0e"), "S.94.2", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of trade unions" },
                    { new Guid("729b3c83-8459-46de-a572-6e2743f0282e"), "S.94.20", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of trade unions" },
                    { new Guid("619bcdaf-6e28-4b4b-bdd7-9bbec15ac193"), "S.94.9", new Guid("318a8290-3b8b-4bd8-91a8-80bd7b1d50aa"), "Activities of other membership organisations" },
                    { new Guid("1039f4d1-334b-48ea-b230-150aff4917bb"), "R.90.01", new Guid("804c84af-d105-46ea-990d-bc517abd54f4"), "Performing arts" },
                    { new Guid("04387ad2-3553-4bed-8647-a5c3fcd6bb94"), "K.65", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("42f6a0b6-3db7-4cee-8b3a-ec94e89b7c94"), "N.82.9", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Business support service activities n.e.c." },
                    { new Guid("a8e9e8f3-865c-4b3d-9cc6-380324977735"), "N.82.3", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Organisation of conventions and trade shows" },
                    { new Guid("5ff41d3b-b1d3-4a02-97ea-3d7cb6f572db"), "M.70.1", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Activities of head offices" },
                    { new Guid("cbfd1e8d-aa58-41bd-910d-bed4ae06bd44"), "M.70.10", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Activities of head offices" },
                    { new Guid("cdba28b0-f884-44f0-9d76-9a7012da08ed"), "M.70.2", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Management consultancy activities" },
                    { new Guid("69e8fc85-d277-4c66-893a-691002abb5c5"), "M.70.21", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Public relations and communication activities" },
                    { new Guid("0d5234db-99cc-40a9-b015-b5298b969fc0"), "M.70.22", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Business and other management consultancy activities" },
                    { new Guid("4ae17dcc-bbcd-44c0-9f26-6a70ed744c7c"), "M.71", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("b43f15b5-39de-412e-9d49-cd19a966459a"), "M.71.1", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("9ea340c3-7cb2-4a00-b1e2-e2c5c238e5cf"), "M.71.11", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Architectural activities" },
                    { new Guid("f3afe670-5c41-4cf8-b0a7-0bdf7fb8f66a"), "M.71.12", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Engineering activities and related technical consultancy" },
                    { new Guid("ee0f70e1-3e27-4021-9ab5-9154c3f59ad9"), "M.71.2", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Technical testing and analysis" },
                    { new Guid("0f3a315f-fa12-4e5e-9516-8ebea1efe715"), "M.71.20", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("311ed3ed-628b-45a5-ad08-c117f777709c"), "M.72", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Scientific research and development" },
                    { new Guid("771c0b2b-0af6-4b11-a6ee-29dc2a09ddc4"), "M.70", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Activities of head offices; management consultancy activities" },
                    { new Guid("985e9856-3f4f-4b0f-814c-bae6b523ec9e"), "M.72.1", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("b73ebf5b-ecb7-421e-9cc1-2b96593f3f52"), "M.72.19", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("f8bde7cc-8760-4d58-af96-ba9a65637933"), "M.72.2", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("b5dbc7ca-ad78-4071-bc50-a326638e0390"), "M.72.20", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("ad7fa3e1-97a1-46ea-a5b5-d0f85fb49b7d"), "M.73", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Advertising and market research" },
                    { new Guid("03df938f-cff6-4b82-8566-770bcc13bc07"), "M.73.1", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Advertising" },
                    { new Guid("a717353f-f223-4d58-9575-4cc9117c5da2"), "M.73.11", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Advertising agencies" },
                    { new Guid("85c99f1b-0b80-4275-9b74-43ba9d8a59fa"), "M.73.12", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Media representation" },
                    { new Guid("9f0f3d51-52fb-4f3b-95a5-c9a5cc3a36c8"), "M.73.2", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Market research and public opinion polling" },
                    { new Guid("0feaf8a1-5bd3-4283-9d6a-7c20f11e77b3"), "M.73.20", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Market research and public opinion polling" },
                    { new Guid("0cf97262-52c3-4850-b346-eebdec259ddb"), "M.74", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Other professional, scientific and technical activities" },
                    { new Guid("e8ffec00-e2ec-405f-8809-284c026578da"), "M.74.1", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Specialised design activities" },
                    { new Guid("c3d2cf0d-5a0c-4526-b0e2-526488fd16cf"), "M.74.10", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Specialised design activities" },
                    { new Guid("20f1a521-e70b-4975-b362-361265fba9f6"), "M.72.11", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Research and experimental development on biotechnology" },
                    { new Guid("fb2ed24a-3745-43a5-8d70-91d4f3da5569"), "M.69.20", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("1ee8c1a7-207a-468f-9644-560526d2b8c2"), "M.69.2", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("b488aa34-b0d9-4957-8186-b06518e5724b"), "M.69.10", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Legal activities" },
                    { new Guid("17b7f80e-ec13-4734-87f0-f16ece24d30a"), "K.65.11", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Life insurance" },
                    { new Guid("9500db16-5781-4aab-afca-ea770eeea38e"), "K.65.12", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Non-life insurance" },
                    { new Guid("e2b33702-2581-4a2f-b057-7998e0c6b00d"), "K.65.2", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Reinsurance" },
                    { new Guid("1943f3c9-d8d2-4f0e-b00c-2a30153adfa3"), "K.65.20", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Reinsurance" },
                    { new Guid("81f56659-7e75-4433-912b-8e481c8cda53"), "K.65.3", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Pension funding" },
                    { new Guid("f380be24-0fe3-4ef7-bca4-a51e5bc3232f"), "K.65.30", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Pension funding" },
                    { new Guid("17594603-1154-4f0b-b140-80fb6b9e6566"), "K.66", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("01ad3b35-4b7f-4b51-a25d-a65e58f98201"), "K.66.1", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("5abce2bc-cd82-4d45-93ae-41e46cb19f33"), "K.66.11", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Administration of financial markets" },
                    { new Guid("d591fc3b-cf05-4947-b4c0-fb4c34fab476"), "K.66.12", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Security and commodity contracts brokerage" },
                    { new Guid("e621663c-2393-4bcc-8699-c1a059b88627"), "K.66.19", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("0a55a4ea-ddb5-46f1-aa6f-fa4cfd166f92"), "K.66.2", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("9e779419-1be0-41c1-a7bf-1293e6939ee2"), "K.66.21", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Risk and damage evaluation" },
                    { new Guid("d4eca07e-b2b3-4780-9f38-388944429ee9"), "K.66.22", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Activities of insurance agents and brokers" },
                    { new Guid("f9614198-10b2-4b5a-bfd3-0d4cc5f305b0"), "K.66.29", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("5af82660-a105-4546-b347-4441a467ecb4"), "K.66.3", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Fund management activities" },
                    { new Guid("0f33341a-2b25-480a-9a3c-a40a06853835"), "K.66.30", new Guid("f224da09-8420-4142-a072-3e1cb634f555"), "Fund management activities" },
                    { new Guid("0bce96a6-5d16-4e81-8999-ecef86beb658"), "L.68", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Real estate activities" },
                    { new Guid("af31a408-6eca-47b0-9684-ae0534701d66"), "L.68.1", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Buying and selling of own real estate" },
                    { new Guid("0286c4bc-95ad-44fd-ac99-3aa5ae514180"), "L.68.10", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Buying and selling of own real estate" },
                    { new Guid("e5d687f5-5e8d-43ce-80f0-4e9583a65196"), "L.68.2", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Renting and operating of own or leased real estate" },
                    { new Guid("5f910aa7-ce0e-4a8d-907f-cc0f9ddbe3a9"), "L.68.20", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Renting and operating of own or leased real estate" },
                    { new Guid("29f6271e-ca51-45ea-8603-fe7f4754ab61"), "L.68.3", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("359dc3c4-5f57-410b-93c0-53c85800c9ba"), "L.68.31", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Real estate agencies" },
                    { new Guid("3d219883-dd26-4171-bcd8-0ad4be43f4c9"), "L.68.32", new Guid("93028a9d-e485-4ccc-8828-0689447a4e2e"), "Management of real estate on a fee or contract basis" },
                    { new Guid("45f2fdc8-bbc4-482a-b758-91fe2d4e5a73"), "M.69", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Legal and accounting activities" },
                    { new Guid("b9c7e09e-f00b-439e-aa9c-f4515054b75c"), "M.69.1", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Legal activities" },
                    { new Guid("7d1841d0-6ee9-4e61-827e-46e28cfa629a"), "M.74.2", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Photographic activities" },
                    { new Guid("3f644a27-8eb9-4b69-957b-05ca77797063"), "N.82.30", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Organisation of conventions and trade shows" },
                    { new Guid("86a0ea3f-15be-498e-9aa8-7014d276fb11"), "M.74.20", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Photographic activities" },
                    { new Guid("a48410b5-c3d1-4a1a-bc2a-78f10a406333"), "M.74.30", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Translation and interpretation activities" },
                    { new Guid("b29a9427-6d65-40b9-a18b-2e93d2f6c716"), "N.79.11", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Travel agency activities" },
                    { new Guid("7983898e-4bee-41df-8d0f-f716fda2b886"), "N.79.12", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Tour operator activities" },
                    { new Guid("88252d14-e962-454b-96b7-128de06b046f"), "N.79.9", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other reservation service and related activities" },
                    { new Guid("6750b4a6-8776-4e8b-a527-82abd0af8713"), "N.79.90", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other reservation service and related activities" },
                    { new Guid("8ec9bd21-fa0f-47f7-a07d-a198695b9cc4"), "N.80", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Security and investigation activities" },
                    { new Guid("d899a974-25f8-414e-a1ad-9a50765569c3"), "N.80.1", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Private security activities" },
                    { new Guid("8329a16a-4807-440f-a1b3-0da1078fb4cf"), "N.80.10", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Private security activities" },
                    { new Guid("c5eec391-6de5-48f3-8fa7-1ed8e54d877c"), "N.80.2", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Security systems service activities" },
                    { new Guid("d46b70e8-6bce-4cba-8ac6-fce2ebbc7dad"), "N.80.20", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Security systems service activities" },
                    { new Guid("4e8a8bfe-46c2-4a0e-b068-ee846df3e054"), "N.80.3", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Investigation activities" },
                    { new Guid("595e2fa4-851f-4d92-8b5e-20ee5e356e5f"), "N.80.30", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Investigation activities" },
                    { new Guid("094d5766-ae2b-42fd-a22b-8054fa88cb8c"), "N.81", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Services to buildings and landscape activities" },
                    { new Guid("ae5fef43-a99d-4634-ace0-68e66ca21480"), "N.79.1", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Travel agency and tour operator activities" },
                    { new Guid("b16309bd-5d7b-4c6f-a20d-826f04aac925"), "N.81.1", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Combined facilities support activities" },
                    { new Guid("482ca482-511a-4db9-9714-c25aedecd84e"), "N.81.2", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Cleaning activities" },
                    { new Guid("5c175e92-c803-420d-ad45-c07ad4e4d6a1"), "N.81.21", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "General cleaning of buildings" },
                    { new Guid("bb88618d-2e5f-449a-bfdd-6837baa0a500"), "N.81.22", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other building and industrial cleaning activities" },
                    { new Guid("e4d3b660-f75a-4798-a441-56b88c57b273"), "N.81.29", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other cleaning activities" },
                    { new Guid("9d8a7948-91c5-4de1-80dc-9ee2980f4240"), "N.81.3", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Landscape service activities" },
                    { new Guid("fa14a1bf-f094-4d94-9c79-5545ee181fff"), "N.81.30", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Landscape service activities" },
                    { new Guid("e8a0e04d-611c-4882-ac52-90b7f46a25e2"), "N.82", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Office administrative, office support and other business support activities" },
                    { new Guid("17f7dee4-58fd-4b2e-b707-6ec5019b54f6"), "N.82.1", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Office administrative and support activities" },
                    { new Guid("8dc10f3c-98a9-4995-8ada-460d8db750fc"), "N.82.11", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Combined office administrative service activities" },
                    { new Guid("66dae27d-61a9-4f5b-a526-4f3280610c00"), "N.82.19", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("a908eeaa-b34b-43fb-b476-c8dc3164ac43"), "N.82.2", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Activities of call centres" },
                    { new Guid("d9346ccb-bbe7-4170-96e7-0ec7111930c3"), "N.82.20", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Activities of call centres" },
                    { new Guid("f4af9d44-0b25-4f5d-bbf7-736cf747547f"), "N.81.10", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Combined facilities support activities" },
                    { new Guid("8a6f6989-62d4-4add-9703-c2161bdc436f"), "N.79", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("8c86f40a-38fa-4146-8e50-ffa198d9ba8a"), "N.78.30", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other human resources provision" },
                    { new Guid("190b120f-c5a5-467a-a98d-f43f58893772"), "N.78.3", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Other human resources provision" },
                    { new Guid("b22743ab-2a57-49ff-b277-85cf61412936"), "M.74.9", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("4a085519-a7a8-4b70-bbda-9e3b6370e6ba"), "M.74.90", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("41a96cea-0f85-44ba-9625-80d7246140fa"), "M.75", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Veterinary activities" },
                    { new Guid("305afbbb-f3b3-45e1-9abb-0dfcb5e77f4b"), "M.75.0", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("74e41e42-8763-431c-8785-67762d438261"), "M.75.00", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Veterinary activities" },
                    { new Guid("ee5726d5-118d-41dc-bb14-6641991c9e16"), "N.77", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Rental and leasing activities" },
                    { new Guid("c0ac0fe3-18b3-4564-a6cd-32c7fb971ba6"), "N.77.1", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of motor vehicles" },
                    { new Guid("039e4e57-4747-4d68-8cdf-0d116680dc0d"), "N.77.11", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("1141a4be-efdc-4843-bfd0-feffd6e939f4"), "N.77.12", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of trucks" },
                    { new Guid("063de3f6-3012-45cc-8d50-89f0515f72de"), "N.77.2", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of personal and household goods" },
                    { new Guid("5a15fb7a-8af1-4a9f-8b1a-cc9d31375d8e"), "N.77.21", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("5bfee7a7-a87c-4bad-93c6-24833f0155ca"), "N.77.22", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting of video tapes and disks" },
                    { new Guid("d087f1f2-2710-4fa7-a5dd-bd01a39118dd"), "N.77.29", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of other personal and household goods" },
                    { new Guid("7ac1b496-9091-4c18-9836-6312aad830ae"), "N.77.3", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("c454c7ee-613b-4c83-9775-7e495e1ca08d"), "N.77.31", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("07289c30-0dc7-4b79-93df-9dca1add5308"), "N.77.32", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("3f53b7f3-b414-4bb9-b1e6-d45f91885d90"), "N.77.33", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("b287d3e1-c023-4973-b214-ba7a2528951a"), "N.77.34", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of water transport equipment" },
                    { new Guid("fe3974a5-ceb1-4559-8146-a9147c3704fd"), "N.77.35", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of air transport equipment" },
                    { new Guid("3b32c688-4483-409b-bbf0-286a3b6a38c0"), "N.77.39", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("50f25d28-2cc7-4451-b6f7-08bf9f94ee5f"), "N.77.4", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("4c3cd214-9285-41a2-b81e-ec7faabce0de"), "N.77.40", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("969fbbe4-42b1-4dd7-804a-c2ad0fb7765a"), "N.78", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Employment activities" },
                    { new Guid("7ee6653e-55ac-422b-85ff-48f192f3d36d"), "N.78.1", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Activities of employment placement agencies" },
                    { new Guid("1b8d25d3-d75d-469e-8ffc-a3b54bd051fa"), "N.78.10", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Activities of employment placement agencies" },
                    { new Guid("b02b150c-6414-4664-b022-23cace5fe8b5"), "N.78.2", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Temporary employment agency activities" },
                    { new Guid("e9f953a9-2a91-4bac-a171-a9c672a54afa"), "N.78.20", new Guid("5225576a-f8f8-402b-86a4-946aa6b4841d"), "Temporary employment agency activities" },
                    { new Guid("d4fd8fb7-15b7-4c65-820b-ff6deed51732"), "M.74.3", new Guid("c3b30db3-d025-495c-9fae-24fa4658a004"), "Translation and interpretation activities" },
                    { new Guid("41cd4ffc-860d-4897-9255-6a1a19fd21c5"), "U.99.0", new Guid("1fd26d14-c6e8-4720-8a95-8bbe268c7326"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("a5571cbc-a67f-4cc0-b3f9-05865692f7a4"), "F.43.21", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Electrical installation" },
                    { new Guid("fbeee103-a60d-4556-93ef-2022b2e9ca5c"), "F.43.13", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Test drilling and boring" },
                    { new Guid("ca3bb47a-0db0-4a02-b98f-9cd64bd42b1a"), "C.14.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of articles of fur" },
                    { new Guid("3b4c0415-8d30-494b-8594-427c30d31397"), "C.14.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of articles of fur" },
                    { new Guid("f375c931-e918-4ba6-a7fa-2e5b36a422c9"), "C.14.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("25a19eeb-0ceb-46ee-88c1-e061c625cc6c"), "C.14.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("b888e810-5428-44af-9750-d76e18d1ef8a"), "C.14.39", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("c84ae4ee-1780-451b-b34d-216097c00346"), "C.15", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of leather and related products" },
                    { new Guid("96ad0a85-0db9-40b8-9211-dc788007fb85"), "C.15.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("fafb6e50-2707-4cd0-99ee-24f53083d332"), "C.15.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("06ad44e4-75c8-43e8-a8aa-8470f6f9dafe"), "C.15.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("d06a93e5-57fd-4839-bf4c-86cd17d87f73"), "C.15.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of footwear" },
                    { new Guid("0aa2bbd2-7ecf-49ae-a9c2-2f5f66f6873f"), "C.15.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of footwear" },
                    { new Guid("8f892177-2ad4-426c-a63e-155e72acae69"), "C.16", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("089e329d-7b55-4d01-8af0-a8f67814d07f"), "C.14.19", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("686dbf29-7654-4451-a41e-613843b4bd6c"), "C.16.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Sawmilling and planing of wood" },
                    { new Guid("76b65bdc-27c5-44bf-b277-6ecefae766a1"), "C.16.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2c526652-44a6-42be-b456-d3d29babcdec"), "C.16.21", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("26f24d5c-603b-4a83-af19-609fe1c30374"), "C.16.22", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of assembled parquet floors" },
                    { new Guid("e37e29a0-68ec-4fac-8388-ff34f411d786"), "C.16.23", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("528ab97a-447a-4dd4-bf50-d98f9f14cda1"), "C.16.24", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wooden containers" },
                    { new Guid("f0889ae8-0ca3-45d4-825e-d02836582295"), "C.16.29", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("2edc5c9e-23e6-4cdb-be07-0bf11f82975e"), "C.17", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of paper and paper products" },
                    { new Guid("4281ec2e-d794-4215-9d94-a1b62e379af4"), "C.17.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("b71dba6e-1530-4186-a292-9fc1ec3d4499"), "C.17.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of pulp" },
                    { new Guid("09f396b8-8a8c-4b88-ad8d-23ce9c8fd7a9"), "C.17.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of paper and paperboard" },
                    { new Guid("5bad182a-f419-4657-8a3e-4a692068d4ef"), "C.17.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("a17a2804-4d6b-49c2-8e17-924cfea4200e"), "C.17.21", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("21477743-79b1-43c7-85e7-f93d8dab74b6"), "C.16.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Sawmilling and planing of wood" },
                    { new Guid("14d6f0e1-12d6-491d-b782-55ee93721539"), "C.14.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of underwear" },
                    { new Guid("7ab55abe-89db-4c88-89b5-cd50af837600"), "C.14.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other outerwear" },
                    { new Guid("2394e55e-aa24-44fc-9505-48cd9c5c21fd"), "C.14.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of workwear" },
                    { new Guid("284dcf3a-9acf-4e0b-a1c6-444fedd83ded"), "C.11.02", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wine from grape" },
                    { new Guid("4532ad9f-d4db-48c4-a485-97b7f3700a8d"), "C.11.03", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cider and other fruit wines" },
                    { new Guid("81f557a1-8c4a-45d2-a20b-2e8e217ea2e9"), "C.11.04", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("845b8da4-5a2a-44ee-9f6c-43ef1c499517"), "C.11.05", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of beer" },
                    { new Guid("3deecc31-c73a-407d-b4e3-23c3e775b4d2"), "C.11.06", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of malt" },
                    { new Guid("4b253ac9-7e1e-4d45-994b-22a5c6c8f529"), "C.11.07", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("bb1bbf4f-0599-417c-9220-032906baa46e"), "C.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tobacco products" },
                    { new Guid("98bc57b4-b44f-48e4-895a-9a237e1cb326"), "C.12.0", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tobacco products" },
                    { new Guid("81f1e1f4-982c-4656-b3f0-4295cae4f55f"), "C.12.00", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tobacco products" },
                    { new Guid("38fe7d9a-1eae-4c3a-adf3-cf2dcb1f7a96"), "C.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of textiles" },
                    { new Guid("32a2a6fd-e491-459b-8c64-adb4410bf0c9"), "C.13.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Preparation and spinning of textile fibres" },
                    { new Guid("e11ec0fe-cd60-4d71-849b-0eb64d2feada"), "C.13.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Preparation and spinning of textile fibres" },
                    { new Guid("274cea32-dea0-4593-83e6-ed2a25f294f9"), "C.13.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Weaving of textiles" },
                    { new Guid("a027c181-02a0-4273-aaa9-41adfe81d323"), "C.13.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Weaving of textiles" },
                    { new Guid("4a833851-46af-401c-b6fe-c2f7d0b823da"), "C.13.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Finishing of textiles" },
                    { new Guid("85b97747-467c-4a9e-b2bf-fd50685f6dca"), "C.13.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Finishing of textiles" },
                    { new Guid("2daa1015-066e-4715-97ee-d051e63694f0"), "C.13.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other textiles" },
                    { new Guid("c593d08f-d662-4331-95ff-57e43deb1d46"), "C.13.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("0818520d-29e1-4fe6-8a42-d6fc21a01fe4"), "C.13.92", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("ab31c3ca-eae3-471e-a96d-951cfd942104"), "C.13.93", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of carpets and rugs" },
                    { new Guid("e3eedaaf-5db7-41bc-947d-b7e091eec535"), "C.13.94", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("fd0941e3-aef7-49ba-9925-5e77e8a218e0"), "C.13.95", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("9adf4d8a-daf0-4b2e-bd57-aed6f6dce0d0"), "C.13.96", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("f741787f-c3a3-4539-9ff7-969797393214"), "C.13.99", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other textiles n.e.c." },
                    { new Guid("73357351-15e3-4c52-9363-ef3c7794cacf"), "C.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wearing apparel" },
                    { new Guid("139923f3-1aa6-413b-bceb-c09d148cde51"), "C.14.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("eb8be1c7-d3e0-48b3-946d-1dd987564220"), "C.14.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("58139c1d-2dcc-4b35-8f57-0a3c540f74d0"), "C.17.22", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("8b6e798c-233f-45ac-b0ba-1f5a6128d4b4"), "C.11.01", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("963c7484-47bd-4da3-8d6b-aeb60456f06a"), "C.17.23", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of paper stationery" },
                    { new Guid("a16c6bc3-ba43-4f64-bf30-b4e5fff2073b"), "C.17.29", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("64275985-0cc3-48d1-8a15-4f6aee8908a3"), "C.20.52", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of glues" },
                    { new Guid("469d9194-1f0e-4191-ac4e-3d0aab08fb5c"), "C.20.53", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of essential oils" },
                    { new Guid("2502bb8d-720e-4e7c-afb9-c49b9cc70ccf"), "C.20.59", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("d1fb5f11-149c-46c7-95e9-6d5b3892c22a"), "C.20.6", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of man-made fibres" },
                    { new Guid("411e1e9f-3e07-499b-97a5-74445f5216b0"), "C.20.60", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of man-made fibres" },
                    { new Guid("9e88cc3f-c65c-4ab8-9459-8f303ff1386a"), "C.21", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("cfd60334-5969-4070-839c-b3bc8b431558"), "C.21.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("3c2c470c-8404-44c6-b38b-42bc0fc790c0"), "C.21.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("d85d8355-ebc5-4954-acac-b6c1b6e63d11"), "C.21.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("c6cb1f75-1af2-482b-814f-c2fae3f1e9f6"), "C.21.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("dfdeae7c-884e-4e8f-9d85-7398037b209d"), "C.22", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of rubber and plastic products" },
                    { new Guid("905181b0-e092-4ac5-bb8b-b67825e740a9"), "C.22.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of rubber products" },
                    { new Guid("0c998bba-8268-49e5-8ded-c3455bac6032"), "C.20.51", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of explosives" },
                    { new Guid("c97d5dee-ede2-43eb-b17b-d9f82aae9863"), "C.22.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("bde70d72-b400-4605-94e8-5860e11822bb"), "C.22.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of plastics products" },
                    { new Guid("b2fc3a9a-9391-4bce-aeef-23316096eafa"), "C.22.21", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("b4c6a5cb-6cec-430e-9bec-1f3004fd6b81"), "C.22.22", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of plastic packing goods" },
                    { new Guid("6f5e8f09-1f6b-404a-bdc8-1a2d3e280892"), "C.22.23", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("78f46101-e959-492b-a6d5-9882b71b1290"), "C.22.29", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other plastic products" },
                    { new Guid("281fc7c3-b7ed-424b-a03f-dbb4732d024d"), "C.23", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("ed498588-f1c1-4f18-81ed-c98bed1d37cb"), "C.23.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of glass and glass products" },
                    { new Guid("60749cf1-fc80-4a2d-af3a-46404e102819"), "C.23.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of flat glass" },
                    { new Guid("0d13c3dd-bd11-402d-a451-035775df626a"), "C.23.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Shaping and processing of flat glass" },
                    { new Guid("647fde72-11bf-4a10-bdfe-80e297ae2263"), "C.23.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of hollow glass" },
                    { new Guid("9952f988-dedf-489d-aedd-292defcd3765"), "C.23.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of glass fibres" },
                    { new Guid("c001cc60-6553-4ee4-849f-90bb7d65f1b1"), "C.23.19", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("ad345792-003a-4c26-93ba-aeed4a4c2be8"), "C.22.19", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other rubber products" },
                    { new Guid("aabaddfc-76e7-40d0-bf00-058463863b34"), "C.20.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other chemical products" },
                    { new Guid("45a386b7-1f8e-40e0-8444-7331ccd7eb53"), "C.20.42", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("293b5827-6711-438d-b21a-293ea8847494"), "C.20.41", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("5ce8baff-2ccb-40e1-951a-016c6ed8ae9f"), "C.18", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Printing and reproduction of recorded media" },
                    { new Guid("40267b1f-f92a-4860-971b-4fc5100d7b46"), "C.18.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Printing and service activities related to printing" },
                    { new Guid("32b8c1ad-3e80-4fe1-8ff4-fa97d4c780a6"), "C.18.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Printing of newspapers" },
                    { new Guid("d9152818-c58a-4d9f-89e4-9a7c030c0b3a"), "C.18.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Other printing" },
                    { new Guid("98833192-eccc-4f09-abe0-950b3f3802d5"), "C.18.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Pre-press and pre-media services" },
                    { new Guid("2d95a602-576a-417a-9455-7d3bb3de9400"), "C.18.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Binding and related services" },
                    { new Guid("42a4f266-4deb-4c89-87d1-89e5a7b51eca"), "C.18.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Reproduction of recorded media" },
                    { new Guid("f4996e5b-b090-446a-9396-4edfc87bc59b"), "C.18.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("40110a90-6071-49a2-aebe-7ce559e24832"), "C.19", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("b80f23bc-bfe9-47d4-8dec-b3baa3065cea"), "C.19.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of coke oven products" },
                    { new Guid("2e2fa340-1c9c-4e95-8bf9-79d313944daa"), "C.19.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of coke oven products" },
                    { new Guid("c0c0b756-afd1-4bcb-b5a3-31f63fbb3b32"), "C.19.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of refined petroleum products" },
                    { new Guid("1d35f33c-63f3-4450-a674-5ea9328a2b60"), "C.19.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of refined petroleum products" },
                    { new Guid("f38d4b50-0139-4ad3-ae65-e4f304b9e69a"), "C.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of chemicals and chemical products" },
                    { new Guid("25bfbfaf-f70a-423f-a8f1-8cddef322b8c"), "C.20.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("3041a3d7-962b-4bfe-8ef1-8d47eb9810ba"), "C.20.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of industrial gases" },
                    { new Guid("9d80ebbd-bf60-4c79-addd-de8587728a90"), "C.20.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of dyes and pigments" },
                    { new Guid("47c0cb15-9c12-4060-a027-ce4c4dfb6264"), "C.20.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("3e609e69-e242-4a88-9f39-3f91ad85d2a7"), "C.20.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other organic basic chemicals" },
                    { new Guid("fa285ba6-4090-4eb5-bf3b-f6cb6c7fa326"), "C.20.15", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("72c29955-fc01-46ce-a151-370c515f18f5"), "C.20.16", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of plastics in primary forms" },
                    { new Guid("43e77fea-581e-4646-bc91-f3feb88c6ee1"), "C.20.17", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("5ac1364d-47f0-4149-b107-0c5226a1d59e"), "C.20.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("97d771b2-bd8a-4853-8b99-84cddf959033"), "C.20.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("c2611fba-7938-408b-9881-a4eac72d3103"), "C.20.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("e548a0b8-5f0d-4bc1-980e-776955652194"), "C.20.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("27c4323c-27cf-47a8-bfcb-d2f958149b6f"), "C.20.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("8a27f987-1b96-4bc8-a43f-5e3806dbfb4a"), "C.17.24", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wallpaper" },
                    { new Guid("9602e92c-d1c1-4b08-b686-8ef0538ddda0"), "C.23.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of refractory products" },
                    { new Guid("409a573a-a543-4f1f-a6a3-2912662e8cb5"), "C.11.0", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of beverages" },
                    { new Guid("6ad1da82-20dd-4ddc-bafb-2ac0b8054528"), "C.10.92", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of prepared pet foods" },
                    { new Guid("e7237cf5-7391-4768-9480-2c3af84e0952"), "A.01.6", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("86146918-916b-42ff-a8dc-83ec96d18cb9"), "A.01.61", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Support activities for crop production" },
                    { new Guid("1c26b8b3-a124-4328-b34a-f53117309557"), "A.01.62", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Support activities for animal production" },
                    { new Guid("1a3dc41d-d348-4446-a05a-9c79cb0e4597"), "A.01.63", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Post-harvest crop activities" },
                    { new Guid("76187eba-dc0c-468d-98ff-b83ed8979af0"), "A.01.64", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Seed processing for propagation" },
                    { new Guid("f2a12c3d-7fdf-49a4-9cf9-12598100a422"), "A.01.7", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Hunting, trapping and related service activities" },
                    { new Guid("e8a87c4e-0ce8-43ce-b907-8bc91cc57f45"), "A.01.70", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Hunting, trapping and related service activities" },
                    { new Guid("2b5a34e4-2135-4914-8b6c-34b59574b90e"), "A.02", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Forestry and logging" },
                    { new Guid("c7844d27-d947-4385-afd7-9d072c84c0fb"), "A.02.1", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Silviculture and other forestry activities" },
                    { new Guid("e899d2e4-38ba-4b36-b52f-c9def108f70c"), "A.02.10", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Silviculture and other forestry activities" },
                    { new Guid("dddcb350-38bc-4417-9244-ac131744d6ca"), "A.02.2", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Logging" },
                    { new Guid("97b8157a-ec10-44f6-b834-fb9e97513b01"), "A.02.20", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Logging" },
                    { new Guid("f5e3aaea-a4d5-4163-a097-27428040fc19"), "A.01.50", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Mixed farming" },
                    { new Guid("5dd1e5e2-43b6-4255-9f17-0116dcef51d4"), "A.02.3", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Gathering of wild growing non-wood products" },
                    { new Guid("5a9e458d-ed72-4c51-8146-dbc49fd1855a"), "A.02.4", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Support services to forestry" },
                    { new Guid("c8b51b55-2538-4c9b-9e57-d4f97c0d0b6f"), "A.02.40", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Support services to forestry" },
                    { new Guid("f94ab628-f85b-4590-abe6-f078a5706fc8"), "A.03", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Fishing and aquaculture" },
                    { new Guid("4fdee4a5-380d-4a91-a28b-854926cbf86b"), "A.03.1", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Fishing" },
                    { new Guid("f6c15233-1287-4a94-9272-3fa11730a24a"), "A.03.11", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f6dbe32f-7763-465d-8e60-a558cf70abda"), "A.03.12", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Freshwater fishing" },
                    { new Guid("d5476697-d46a-4fa9-9a08-840cc8cf4048"), "A.03.2", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Aquaculture" },
                    { new Guid("30c80e1f-164a-4591-ac26-625964ac3c99"), "A.03.21", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Marine aquaculture" },
                    { new Guid("fd73a597-e4ae-466b-ae2a-a2e1366d299b"), "A.03.22", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Freshwater aquaculture" },
                    { new Guid("a2d300ee-8063-4305-b26e-2684e0b7fb06"), "B.05", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of coal and lignite" },
                    { new Guid("7faa6f10-d41b-41a5-aa33-c65ea0c635fe"), "B.05.1", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of hard coal" },
                    { new Guid("026e6c03-62ef-4cd4-8bc6-73a24c2cfd36"), "B.05.10", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of hard coal" },
                    { new Guid("97476f1d-3475-456a-9485-05b3f12566d0"), "A.02.30", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Gathering of wild growing non-wood products" },
                    { new Guid("1234045b-c7ae-49ef-87c3-2d6f69afb048"), "A.01.5", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Mixed farming" },
                    { new Guid("951aff30-954e-4618-9487-d67425c3a401"), "A.01.49", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of other animals" },
                    { new Guid("e76e98e2-8691-4979-8ff3-bdd1257e115e"), "A.01.47", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of poultry" },
                    { new Guid("df7d95bd-dc81-4175-91bd-4a1f8e60de1a"), "A.01.1", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of non-perennial crops" },
                    { new Guid("b9ce7a7e-041d-4eae-a185-af8fb238f912"), "A.01.11", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("d6e859cf-3c18-4ec8-8a11-4bdfcd7f2424"), "A.01.12", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of rice" },
                    { new Guid("20f9350e-1e8a-471e-8cdb-f296214fbd70"), "A.01.13", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("581cf424-9cb7-403e-904e-e5ddb7971e8f"), "A.01.14", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of sugar cane" },
                    { new Guid("0281a597-b08e-4b68-8c5d-5f69aae86693"), "A.01.15", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of tobacco" },
                    { new Guid("ac348481-0bcb-4ad2-8728-0d621188ee6f"), "A.01.16", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of fibre crops" },
                    { new Guid("d4fbe9c3-de22-4def-b18d-86edbfa5b861"), "A.01.19", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of other non-perennial crops" },
                    { new Guid("615d7bde-383e-42d9-b9af-fa70f81c89d1"), "A.01.2", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of perennial crops" },
                    { new Guid("aeb17c38-c226-4aae-894e-1c7ccdd59fbc"), "A.01.21", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of grapes" },
                    { new Guid("a0c7a601-d4ca-4795-aa61-675f0963362e"), "A.01.22", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of tropical and subtropical fruits" },
                    { new Guid("fcb7679c-c3e7-4f1a-b373-4a5cbb46af6c"), "A.01.23", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of citrus fruits" },
                    { new Guid("a6c4a0c1-a881-492f-b75d-ed914f98cf9f"), "A.01.24", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of pome fruits and stone fruits" },
                    { new Guid("705c533f-989c-4ac4-99f3-488078636e9c"), "A.01.25", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("3c10c35b-6923-462d-abd5-33e5e617871e"), "A.01.26", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of oleaginous fruits" },
                    { new Guid("01491f18-c787-4d97-a564-3a1e52fdcb0e"), "A.01.27", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of beverage crops" },
                    { new Guid("cc25188d-f49d-4e6a-a981-d16b41b9ab32"), "A.01.28", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("d26029a4-49da-4036-b984-73c26283395e"), "A.01.29", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Growing of other perennial crops" },
                    { new Guid("0f9a4d8e-63dc-430c-a1b0-fc4428b43ea2"), "A.01.3", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Plant propagation" },
                    { new Guid("5de66cb7-6a0d-42bb-afd5-89830b8e0a79"), "A.01.30", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Plant propagation" },
                    { new Guid("5bccafa4-703d-4a02-b55b-9feeb0dd82ba"), "A.01.4", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Animal production" },
                    { new Guid("fbea1fa2-2dd0-44d5-8ac7-c24e8c09a5bb"), "A.01.41", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of dairy cattle" },
                    { new Guid("a3e907c4-a91f-4bdc-ade0-3a36776910bc"), "A.01.42", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of other cattle and buffaloes" },
                    { new Guid("9aaff185-aa67-4f84-9f81-14cacce0b314"), "A.01.43", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of horses and other equines" },
                    { new Guid("cb5a2cbb-0682-43d5-94b1-890235967f3f"), "A.01.44", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of camels and camelids" },
                    { new Guid("fdd2bf3d-b632-484c-af2f-9233c70a08c5"), "A.01.45", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of sheep and goats" },
                    { new Guid("c96e7ba4-856c-436a-933a-802c42d89e88"), "A.01.46", new Guid("2dd12739-2ff7-4318-9b3b-0c5316c674c5"), "Raising of swine/pigs" },
                    { new Guid("1bfc2171-eb8b-40bf-84d4-d3d33a7e455f"), "B.05.2", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of lignite" },
                    { new Guid("d41977ff-5017-4c61-a348-5a3fe7865d33"), "C.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of beverages" },
                    { new Guid("175fd5a9-b23f-4c07-86fe-e43a9fb9c1c9"), "B.05.20", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of lignite" },
                    { new Guid("58da86ec-5ae9-4753-8c8e-a2a4d33bc0cf"), "B.06.1", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ed86da0e-acb6-439a-8ecf-5bbb205fb92d"), "C.10.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of potatoes" },
                    { new Guid("9323c00f-5273-4532-a058-7678d263b3a4"), "C.10.32", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("42354eb6-4ecd-44f8-be98-ebed59ebf8ee"), "C.10.39", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("56d05081-188d-4d88-87a2-cde3bedead90"), "C.10.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("967d2f96-acf3-45db-9206-5cfa2fd0aa67"), "C.10.41", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of oils and fats" },
                    { new Guid("de5edbdb-72ec-469b-b7dc-d0b06345b52d"), "C.10.42", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("27a7d7f7-67db-46b8-a43c-789c5254de9b"), "C.10.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of dairy products" },
                    { new Guid("b995dbab-4bc3-4464-82a3-b01287721231"), "C.10.51", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Operation of dairies and cheese making" },
                    { new Guid("88259679-ba4b-4e14-9e7b-afc9e335b2cf"), "C.10.52", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ice cream" },
                    { new Guid("79453bc7-cbe2-4687-8270-4830c51160f1"), "C.10.6", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("41521424-5b64-4581-86c7-8253fff5fb85"), "C.10.61", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of grain mill products" },
                    { new Guid("93155805-db00-4125-ab8b-12dd89c12548"), "C.10.62", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of starches and starch products" },
                    { new Guid("30daebc8-8a1c-4bc7-a07e-039b79d1e601"), "C.10.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("ac6a801a-fedd-4f67-bd7e-95f0af560d36"), "C.10.7", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("df2c07d2-7734-46e4-a1d6-1b978fcc9d8d"), "C.10.72", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("54e220ec-9ade-4eaa-adf0-315b046fafdc"), "C.10.73", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("f6b10a40-36c3-4ad7-94cf-c25f3c9cf18f"), "C.10.8", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other food products" },
                    { new Guid("84a78439-421e-455e-aee3-15ad61c76ac6"), "C.10.81", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of sugar" },
                    { new Guid("8409921d-fd05-492b-b5f7-c884af4c7aad"), "C.10.82", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("fc37327e-2bbc-4ecd-bc73-61965c2323cb"), "C.10.83", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing of tea and coffee" },
                    { new Guid("af7744ee-ac40-43ae-8d29-3cfc4aaa8c55"), "C.10.84", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of condiments and seasonings" },
                    { new Guid("ccf937fd-c66e-45c1-ba27-a9f28f1d9366"), "C.10.85", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of prepared meals and dishes" },
                    { new Guid("f1bb3923-9a2b-4c76-9ba1-3c27cb6359d5"), "C.10.86", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("bd00416e-61f1-4110-8e1c-fe0af2db97e5"), "C.10.89", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other food products n.e.c." },
                    { new Guid("e302a9ee-11fe-4949-88cb-b02a4756650d"), "C.10.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of prepared animal feeds" },
                    { new Guid("cf9d8d45-4a48-47e1-be9a-4f69f1bbc596"), "C.10.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("93c025c9-536d-4eab-94ba-14acf174882c"), "C.10.71", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("fa993f1b-6bed-4042-86df-b53814e011b0"), "C.10.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("269696b3-1c83-4f10-89ed-72a34722241d"), "C.10.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("e4e659a9-e64e-4368-b0df-55382c4a699b"), "C.10.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Production of meat and poultry meat products" },
                    { new Guid("48a0d560-d274-4974-90c7-23c7e0915954"), "B.06.10", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of crude petroleum" },
                    { new Guid("3a6eb541-55ec-443a-8738-f3aac2bd3a70"), "B.06.2", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of natural gas" },
                    { new Guid("9cdf5a6e-a04f-4781-b5e8-66a53778c552"), "B.06.20", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of natural gas" },
                    { new Guid("900a39b5-904c-4dc8-a93f-43ea5d04b6c6"), "B.07", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of metal ores" },
                    { new Guid("3ac36a73-56ee-41a3-89cd-7643faa7760e"), "B.07.1", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of iron ores" },
                    { new Guid("b1503d4f-88f2-4fc4-bd01-16fc65f1a835"), "B.07.10", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of iron ores" },
                    { new Guid("331278fe-66c2-4660-88c6-5efb48503b53"), "B.07.2", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of non-ferrous metal ores" },
                    { new Guid("6bb7e68b-7af7-440f-b272-9b233d2c86fd"), "B.07.21", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of uranium and thorium ores" },
                    { new Guid("ef581012-7d3b-4887-bae6-e889ea990f81"), "B.07.29", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of other non-ferrous metal ores" },
                    { new Guid("2e9867f5-65c1-4090-a3e6-fed0666cb0af"), "B.08", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Other mining and quarrying" },
                    { new Guid("beef00ca-743e-40fb-b8b2-29e5b89780f5"), "B.08.1", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Quarrying of stone, sand and clay" },
                    { new Guid("6b692324-8c36-4048-a87e-704095608f5b"), "B.08.11", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9871286d-602d-4a84-ab94-810a9d8d009b"), "B.08.12", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("60aafe5a-1d9c-444b-a5c3-e51495d5662d"), "B.08.9", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining and quarrying n.e.c." },
                    { new Guid("ed1faecf-a55e-44d6-a9bd-8b7cbdd2626d"), "B.08.91", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("cf9bcb59-b036-49c1-bc57-2d212510ab8e"), "B.08.92", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of peat" },
                    { new Guid("06ac0427-30eb-426b-9376-a3b72e4f3aa5"), "B.08.93", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of salt" },
                    { new Guid("bc92ffdd-9701-4ecc-845c-3081366aecf7"), "B.08.99", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Other mining and quarrying n.e.c." },
                    { new Guid("ba73ba35-9277-4646-b421-8939dbfa781f"), "B.09", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Mining support service activities" },
                    { new Guid("62c363ae-a4c7-4653-aae7-5fe981179bfe"), "B.09.1", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("1f8a58dc-7011-4e9b-a515-8944f4f050fe"), "B.09.10", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("edf233b7-b561-453f-b381-cdad63f90fd5"), "B.09.9", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Support activities for other mining and quarrying" },
                    { new Guid("75b27e8c-3a16-4ec1-874d-f5eca84ae0c8"), "B.09.90", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Support activities for other mining and quarrying" },
                    { new Guid("d59d829f-f276-444d-ba25-1ccd29edaee0"), "C.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of food products" },
                    { new Guid("eb839b1d-90a8-4e2e-bb5a-23507fa8d6fe"), "C.10.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("da360359-de73-4c75-8356-8769e6bbf005"), "C.10.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of meat" },
                    { new Guid("3f5c0f50-4f21-4823-a426-75e1c1b5f9fb"), "C.10.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing and preserving of poultry meat" },
                    { new Guid("5399b429-e222-4336-a3c7-8224732c81d8"), "B.06", new Guid("05d938d7-83a9-427c-a99f-c050f73f2b97"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("40d2f0df-cecd-4bec-a9fa-484c1267f163"), "F.43.2", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("89ee3ec3-6a27-48e8-ac94-e53006532461"), "C.23.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of refractory products" },
                    { new Guid("efe00844-9b4d-483b-af32-f2d5679d02ee"), "C.23.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("a9c8e8ee-6184-4ffa-8c36-c52dbe171274"), "C.30.92", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("039a0956-83a2-44d3-89ae-265e0d6f9ca9"), "C.30.99", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("5f0e373e-2339-49a6-9caa-7741a2967b3c"), "C.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of furniture" },
                    { new Guid("ef8fdb75-0277-4739-a7b0-74473a4f2f5d"), "C.31.0", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of furniture" },
                    { new Guid("3876e68e-3262-4408-a849-438da2712985"), "C.31.01", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of office and shop furniture" },
                    { new Guid("10aaa58b-e548-4644-8a73-90d5ce41aceb"), "C.31.02", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of kitchen furniture" },
                    { new Guid("7323fbac-79fa-4ea5-8136-a66dc06ea973"), "C.31.03", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of mattresses" },
                    { new Guid("9ca77bf3-e7cb-4a46-8378-16f862f2e893"), "C.31.09", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other furniture" },
                    { new Guid("79733ae6-5388-4a42-a36b-a3c7f3d3fa34"), "C.32", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Other manufacturing" },
                    { new Guid("1679fb3f-0b3d-486a-bb87-ad0d41cb592b"), "C.32.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("674ce225-7e6d-433a-9ccf-ae6a866cc16c"), "C.32.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Striking of coins" },
                    { new Guid("4f8326a6-4071-4678-8251-84db2c398787"), "C.32.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of jewellery and related articles" },
                    { new Guid("c05aa692-6d87-4880-9cb0-5b76bb67add2"), "C.30.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of motorcycles" },
                    { new Guid("da2a898f-4253-4df6-9a89-a3e2e8420df7"), "C.32.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("51a1f3b7-cd8b-46d3-86b8-a96b93c99038"), "C.32.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of musical instruments" },
                    { new Guid("ea4b4c79-a0da-46f9-a8f0-c94b532d2d79"), "C.32.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of sports goods" },
                    { new Guid("8ed70d1d-78e0-4838-b55d-cacce6cfc329"), "C.32.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of sports goods" },
                    { new Guid("4eeedb66-77ae-4179-a4fe-3e64991f0160"), "C.32.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of games and toys" },
                    { new Guid("41c0c588-fd85-405f-86f8-ad26c4fe8072"), "C.32.40", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of games and toys" },
                    { new Guid("2d652445-1a4f-475b-9cb2-b175dffc5eb6"), "C.32.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("4ac893ab-42f0-4795-afdc-e9fbf5941ee5"), "C.32.50", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("5c5df6e3-54ac-4ffa-bed8-988dd079a1e3"), "C.32.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacturing n.e.c." },
                    { new Guid("9a88a814-9063-4c67-9fac-1d67d7b7b988"), "C.32.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("103fa9f4-5c97-45a0-9908-e60a75b21a0c"), "C.32.99", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Other manufacturing n.e.c." },
                    { new Guid("fe0d2c19-f392-4e94-8282-818bc1aa8d84"), "C.33", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair and installation of machinery and equipment" },
                    { new Guid("b6915583-cf7f-46fb-8ff4-d6b5ed0f1164"), "C.33.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("09a15a16-86b3-4fca-bda2-1ad68fb38651"), "C.32.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of musical instruments" },
                    { new Guid("8e52f6c7-e7b3-46bc-822b-6c9fb51a8508"), "C.30.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("5c653b12-9423-4854-91f4-9c728007667a"), "C.30.40", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of military fighting vehicles" },
                    { new Guid("6776fcdf-7fe8-4580-811b-b1b5f0c3088a"), "C.30.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of military fighting vehicles" },
                    { new Guid("cd3ab16a-44ea-4cfa-b3eb-2522a5995fef"), "C.28.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("9baac7be-3fd4-4b20-8a89-5c47d0d2a4a8"), "C.28.41", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of metal forming machinery" },
                    { new Guid("5effbf1c-e599-4596-88c7-4fb23375a592"), "C.28.49", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other machine tools" },
                    { new Guid("1b1230c4-0e90-43af-99a6-102c05e4ff0d"), "C.28.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other special-purpose machinery" },
                    { new Guid("34baa257-5a7d-45cc-88da-1d8a8cdd1372"), "C.28.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of machinery for metallurgy" },
                    { new Guid("259ebcf1-e3f8-4df4-89e8-48dd2c507104"), "C.28.92", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("994f975c-6393-461b-b38a-e96e82ee7e4c"), "C.28.93", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("a69b84eb-8178-483f-a4e8-19cd0b6258dc"), "C.28.94", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("dac4c277-9cc1-4457-8b16-a1a1582f8f41"), "C.28.95", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("75485e99-cff1-46c2-a9c6-9afd5160a81f"), "C.28.96", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("7f91c7bc-e4e0-43aa-ba04-13896afddff9"), "C.28.99", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("19468d0f-7e3c-4c67-8f0e-b7cc01a761f7"), "C.29", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("f11e79dd-c00c-4e2c-9b77-416a89972334"), "C.29.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of motor vehicles" },
                    { new Guid("a740761c-0e54-4de2-b5bf-99321d592abe"), "C.29.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of motor vehicles" },
                    { new Guid("e33ed516-c896-45e3-afed-30f6227c6325"), "C.29.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("f564c8ef-e700-4442-8dbf-f315624de8b3"), "C.29.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("06a8f2c4-aaba-493c-909c-bd5415915117"), "C.29.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("dbc4e2c9-5704-4284-8493-10d1ae2f7f87"), "C.29.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("8aea7a5e-5b88-485c-ba49-4b11247dd04d"), "C.29.32", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("ec1cc08d-eb8e-4fb6-a26d-0b469f73f1c1"), "C.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other transport equipment" },
                    { new Guid("85079877-9555-43a3-a8f8-62e52b3af052"), "C.30.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Building of ships and boats" },
                    { new Guid("ab2b3521-9f3d-453e-8930-fca706b58bb1"), "C.30.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Building of ships and floating structures" },
                    { new Guid("ddcf8f07-4fd2-44b3-b119-8526c21bbd43"), "C.30.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Building of pleasure and sporting boats" },
                    { new Guid("bd23a5e5-28e8-433d-91e9-b817eb579595"), "C.30.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("41f4107c-5689-4f14-90c3-ed644f86682f"), "C.30.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("56cc261a-5d5b-4714-8b8b-6312ddc7c075"), "C.30.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("768a9997-709d-4340-a519-5df2bfe0d194"), "C.30.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("3a80bb08-2833-4629-a093-cded95a178d7"), "C.33.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair of fabricated metal products" },
                    { new Guid("e3cffe4d-33c0-497e-a971-98c72fe209dd"), "C.28.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("7ebae103-13ce-489a-a7df-d2e01c87a72a"), "C.33.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair of machinery" },
                    { new Guid("04b4580d-d4f5-47a9-adc3-ebf5204126a9"), "C.33.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair of electrical equipment" },
                    { new Guid("7163fd87-4269-4e03-8668-ada155949c3f"), "E.38.3", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Materials recovery" },
                    { new Guid("d8a6046e-bead-4fc7-aa14-248627d5d642"), "E.38.31", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Dismantling of wrecks" },
                    { new Guid("415a8912-7e21-4fe7-b030-ba5fe78a44ac"), "E.38.32", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Recovery of sorted materials" },
                    { new Guid("02991862-61a1-485b-9727-97e5268565dc"), "E.39", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b3e98ca5-fe8a-46e1-aa61-491ef8da8f4f"), "E.39.0", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Remediation activities and other waste management services" },
                    { new Guid("a15dd07b-1303-4151-9cab-3def0c4c68e1"), "E.39.00", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Remediation activities and other waste management services" },
                    { new Guid("f0ac35ab-1356-4e1c-81a4-3f2d11a0799e"), "F.41", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of buildings" },
                    { new Guid("fced3518-83de-4ddb-914a-9e05a6e404c4"), "F.41.1", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Development of building projects" },
                    { new Guid("f722c61d-3732-47c2-ae4b-07d5dabf8cb0"), "F.41.10", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Development of building projects" },
                    { new Guid("9fcda733-14ae-47a1-b18a-26f3088c8834"), "F.41.2", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of residential and non-residential buildings" },
                    { new Guid("f9568af5-3d5f-4f96-ae37-a3e936a7b8b9"), "F.41.20", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of residential and non-residential buildings" },
                    { new Guid("f14df25c-ef2a-4ce2-b2bd-b3ebcc4e3116"), "F.42", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Civil engineering" },
                    { new Guid("deb66e31-b0c1-42de-ac45-5728b9ff1b25"), "E.38.22", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Treatment and disposal of hazardous waste" },
                    { new Guid("1945cf33-33d5-4a07-b4f1-019e14758662"), "F.42.1", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of roads and railways" },
                    { new Guid("b523199f-53f5-4cac-b846-ed73c56d20d7"), "F.42.12", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of railways and underground railways" },
                    { new Guid("9d82e026-abb7-4b8f-b6e5-1f9907e4144f"), "F.42.13", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of bridges and tunnels" },
                    { new Guid("92e131ae-c524-442e-b6e1-2a53e44c70a4"), "F.42.2", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of utility projects" },
                    { new Guid("ff4c4e7e-26ad-49b6-befb-b7133b61b0f9"), "F.42.21", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of utility projects for fluids" },
                    { new Guid("13a84c58-3bbf-4afb-844a-fd8819bfb176"), "F.42.22", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("edffe056-b1f9-4c1c-8cec-8d1b75903bdc"), "F.42.9", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of other civil engineering projects" },
                    { new Guid("e2a512b8-78e7-48a0-9255-fae5b5298a2f"), "F.42.91", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of water projects" },
                    { new Guid("03173d6b-74c7-4892-83bc-ab30eff484c9"), "F.42.99", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("cac1014a-a3b5-4c6d-bc9d-f2381cc87b54"), "F.43", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Specialised construction activities" },
                    { new Guid("4b959750-b3f4-4089-a97d-c1dc2aa1bc86"), "F.43.1", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Demolition and site preparation" },
                    { new Guid("fa9c0057-64b7-4a40-ae39-148c48ae4314"), "F.43.11", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Demolition" },
                    { new Guid("d32f9b18-6412-4222-8252-a04c85002421"), "F.43.12", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Site preparation" },
                    { new Guid("4c187806-3a07-413c-b9ee-3e2aaf199a04"), "F.42.11", new Guid("d58fcb59-0ef5-4d64-b91c-15606d5fc336"), "Construction of roads and motorways" },
                    { new Guid("62eb6ea4-0552-4e64-af1f-9b8130cc1d34"), "E.38.21", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("172114e8-8494-4541-a91f-db2e7d8c9106"), "E.38.2", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Waste treatment and disposal" },
                    { new Guid("b046808a-0768-4000-b88f-19cdf45133ff"), "E.38.12", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Collection of hazardous waste" },
                    { new Guid("44f21ab6-d74d-4c9b-8cc4-a89b99cb64c2"), "C.33.15", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair and maintenance of ships and boats" },
                    { new Guid("fa5881b4-653d-4c3f-bd86-69bdbcbd4c5d"), "C.33.16", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("90fa4674-3e5a-425a-b1dc-19d23e35d46c"), "C.33.17", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair and maintenance of other transport equipment" },
                    { new Guid("bd346ae9-2522-4086-9612-2f036b6744c7"), "C.33.19", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair of other equipment" },
                    { new Guid("3ddf4052-2c5a-44b8-aed7-0aceb3fd97e4"), "C.33.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Installation of industrial machinery and equipment" },
                    { new Guid("957bb9c6-53ee-48d2-a52d-0be752a86f3b"), "C.33.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Installation of industrial machinery and equipment" },
                    { new Guid("9aa29e70-5e69-407b-b4a1-a74d36cdf72a"), "D.35", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("7b531a5f-7c88-4c57-8b82-444366225ab2"), "D.35.1", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Electric power generation, transmission and distribution" },
                    { new Guid("18b907d7-b881-4f42-9745-eb4ea7151b2d"), "D.35.11", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Production of electricity" },
                    { new Guid("37e0bdbe-a07e-4279-ae30-34028a7241cf"), "D.35.12", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Transmission of electricity" },
                    { new Guid("d72a2d3e-9b0d-4cce-9578-cb7c6668fe3a"), "D.35.13", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Distribution of electricity" },
                    { new Guid("7415bfca-548f-472c-a136-f5d49e30c6e8"), "D.35.14", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Trade of electricity" },
                    { new Guid("29148804-e713-4f74-a688-6f6ba8987e4a"), "D.35.2", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("a8b74b60-b505-436d-bd6b-544476c9004c"), "D.35.21", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Manufacture of gas" },
                    { new Guid("677a073b-3210-404b-952b-afe4ee120c1a"), "D.35.22", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Distribution of gaseous fuels through mains" },
                    { new Guid("6583c6d5-d03a-4cd5-ac82-ef86a0b6d243"), "D.35.23", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("252ef1f4-f139-4a0a-a596-f599d2d7522b"), "D.35.3", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Steam and air conditioning supply" },
                    { new Guid("e1d056ba-d176-489c-bdc9-dda53298059f"), "D.35.30", new Guid("9a71ef5e-a888-47e2-b093-0e1f93dfcf9a"), "Steam and air conditioning supply" },
                    { new Guid("b1d8c417-728f-438c-b75c-54b89cc7f1ac"), "E.36", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Water collection, treatment and supply" },
                    { new Guid("7b1f3d22-8844-468c-9624-2dba350aed14"), "E.36.0", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Water collection, treatment and supply" },
                    { new Guid("d50b72e9-fa04-4250-b04b-c808ee52a0ac"), "E.36.00", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Water collection, treatment and supply" },
                    { new Guid("9ee8f218-d89d-480e-a3ec-832da274e068"), "E.37", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Sewerage" },
                    { new Guid("a19b05cb-3475-4c10-8225-3d487067a917"), "E.37.0", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Sewerage" },
                    { new Guid("6948a376-b21d-4bcd-8c1c-a0b2046430b3"), "E.37.00", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Sewerage" },
                    { new Guid("4fbdbc6b-cdbd-43b2-a149-7053ec23e3c6"), "E.38", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("be2ca744-ad18-4e3b-9429-5a94c3e35b22"), "E.38.1", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Waste collection" },
                    { new Guid("a169460a-b867-4860-89aa-98ff00b2d225"), "E.38.11", new Guid("7bef9517-df2b-4d5b-be0d-fdcb97fe1613"), "Collection of non-hazardous waste" },
                    { new Guid("cf392e02-9b00-4dd6-9165-361017bf6c03"), "C.33.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Repair of electronic and optical equipment" },
                    { new Guid("f6be7488-b78b-4127-a147-7e4e209c700c"), "C.23.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of clay building materials" },
                    { new Guid("ba307b7f-c0a9-4998-9f81-62a13eaa77ba"), "C.28.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("6b772bc3-5a34-4209-b5ee-7ada8b3f4098"), "C.28.25", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("9434c543-3853-4f1b-a6af-b233e2ec0898"), "C.24.34", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Cold drawing of wire" },
                    { new Guid("b1ea884b-0952-438e-b968-11c3dc4accb2"), "C.24.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("e2b332f1-75f4-4d03-bb8d-689da3addfd8"), "C.24.41", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Precious metals production" },
                    { new Guid("844ecc9b-d2cc-455d-8d94-8ea92a27f714"), "C.24.42", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Aluminium production" },
                    { new Guid("3fada7d2-0e1e-4c63-a6d8-0d0965172c0f"), "C.24.43", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Lead, zinc and tin production" },
                    { new Guid("32a65b0e-fa85-49a6-85e7-5eb02a210cf9"), "C.24.44", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Copper production" },
                    { new Guid("c3ebc97a-7a8f-46ce-a288-288ec044e195"), "C.24.45", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Other non-ferrous metal production" },
                    { new Guid("9affa1b4-f771-4a9f-939f-208ba1a56c46"), "C.24.46", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Processing of nuclear fuel" },
                    { new Guid("94942149-a0cb-419e-aba0-4b62395e8158"), "C.24.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Casting of metals" },
                    { new Guid("c5a6de1c-d93f-48b5-8858-74237dcc78fd"), "C.24.51", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Casting of iron" },
                    { new Guid("2ebb9bb7-00c8-4544-bdf9-f28b07f24997"), "C.24.52", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Casting of steel" },
                    { new Guid("9a3d8d77-471e-41e7-96b2-55fd6878d225"), "C.24.53", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Casting of light metals" },
                    { new Guid("bf252524-1f22-46c4-a911-e415fe4cd92f"), "C.24.33", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Cold forming or folding" },
                    { new Guid("85c871f8-a3c3-41f2-8318-a79d62172632"), "C.24.54", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Casting of other non-ferrous metals" },
                    { new Guid("5b2c2b30-03ef-4ce9-928b-01eefbdfaa7b"), "C.25.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of structural metal products" },
                    { new Guid("76a8572b-dfa8-447f-b73c-db52a7ebd87b"), "C.25.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("72f8f37d-d898-4617-91dd-41d709d8b73b"), "C.25.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of doors and windows of metal" },
                    { new Guid("37ffa88b-23cb-479b-8179-1a486f078c52"), "C.25.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("09459074-0caf-47cb-9b5b-d0f658a410ce"), "C.25.21", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("0a6136d9-155f-4848-9c6e-5f9c92d0244c"), "C.25.29", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("b4d2c1b5-2533-427d-b227-5ad849737a59"), "C.25.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("0a10f8a2-9c8b-4563-b2a2-ef88f54210ec"), "C.25.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("f4ccd4a8-7e95-4a13-82c9-ea7ad83659d2"), "C.25.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of weapons and ammunition" },
                    { new Guid("ff12ce04-1349-4b65-9056-c6bb66215c8c"), "C.25.40", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of weapons and ammunition" },
                    { new Guid("21c014f1-5c7b-4101-8e93-e9f323afeeef"), "C.25.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("e70e0764-40cb-4468-a7ed-ac2d37b79d19"), "C.25.50", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("71f3c65e-c2ee-4208-bd7b-f85eb8da783b"), "C.25", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("28b5009c-5bdd-487b-bc72-adc13287baf6"), "C.24.32", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Cold rolling of narrow strip" },
                    { new Guid("403b17d4-f74c-4ec9-a090-55cd5c2c6c50"), "C.24.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Cold drawing of bars" },
                    { new Guid("20ce1bf2-b50f-41e4-a6c9-634fad71b106"), "C.24.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other products of first processing of steel" },
                    { new Guid("67ec98eb-d0b3-4988-a90e-cb67c0727ce6"), "C.23.32", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("975be43d-95c4-4d9d-bb58-b9bd51eec6df"), "C.23.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("2163ed4c-b5ae-4e40-a021-f7e88e5a2f11"), "C.23.41", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("182f5187-0811-4715-b7d0-72f4eaaa3a8d"), "C.23.42", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("49c9e650-a5cb-4951-af9f-3ef8feed1618"), "C.23.43", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("41ab6a73-5c0e-4990-83ac-c0b38ff0fbf1"), "C.23.44", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other technical ceramic products" },
                    { new Guid("081157f5-9dac-43b9-be9a-006595744f46"), "C.23.49", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other ceramic products" },
                    { new Guid("f9a2f6f3-e83e-4082-b150-761e0ec179a5"), "C.23.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cement, lime and plaster" },
                    { new Guid("f8892e5b-fb3b-4d05-a77b-96e9821b26ac"), "C.23.51", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cement" },
                    { new Guid("95d7a748-766f-401b-9ba1-39670ab44448"), "C.23.52", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of lime and plaster" },
                    { new Guid("231abe35-60e5-4129-92c8-6da44cbf4206"), "C.23.6", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("a996fab7-e801-44ce-a330-fe1ceec1ee2d"), "C.23.61", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("18c526ad-1f8b-40f6-a3ea-de29ee91324a"), "C.23.62", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("63fc4bc8-e4ca-4e21-9b6d-2efae4883787"), "C.23.63", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ready-mixed concrete" },
                    { new Guid("37271acb-d88d-4d23-a344-334ff93d3edf"), "C.23.64", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of mortars" },
                    { new Guid("7cc9eba5-dcb1-4cfa-b21e-baf7c7a066d4"), "C.23.65", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fibre cement" },
                    { new Guid("77318065-f4ff-4ade-813d-a7a142c08abd"), "C.23.69", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("7bdc2baa-aac8-4e11-a769-b2af3b9dc99e"), "C.23.7", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Cutting, shaping and finishing of stone" },
                    { new Guid("010c5c2c-d607-41d5-aed4-80d849954f0f"), "C.23.70", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Cutting, shaping and finishing of stone" },
                    { new Guid("cbe8c941-7f33-40da-8267-92caead55081"), "C.23.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("97d4c464-3fa1-4953-a593-9d605620e303"), "C.23.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Production of abrasive products" },
                    { new Guid("2453b6cb-9481-49a6-9959-67677ca34c8f"), "C.23.99", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("b7282c74-06b2-4830-8c79-3528dcce72a1"), "C.24", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic metals" },
                    { new Guid("abfa44a2-ecd4-4b0c-8f65-099f0f65bdda"), "C.24.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("9ac41136-adfa-40a3-9e22-fde3b7a61450"), "C.24.10", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("203047f4-052a-4cab-9968-404c965bae88"), "C.24.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("a9589ff5-9f41-4e9b-9c17-6745e97c2a84"), "C.24.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("6a42232a-4329-4e14-bdda-44a7ebb26c04"), "C.25.6", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Treatment and coating of metals; machining" },
                    { new Guid("c035ff4e-aef6-4274-95ba-952fddd40e2c"), "C.28.29", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("46b1687d-7b49-4cd0-94cc-a7e51554d5ce"), "C.25.61", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Treatment and coating of metals" },
                    { new Guid("2a6d9321-5356-42b8-9e9d-577b2d40dc2f"), "C.25.7", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("2b0ac305-51ba-4b1d-941a-85a37161a1d4"), "C.27.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("4db0cc6d-20ef-426e-b14f-5c0de7b08315"), "C.27.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of batteries and accumulators" },
                    { new Guid("f2c445a6-f80a-4ac8-b03c-95fad0e01424"), "C.27.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of batteries and accumulators" },
                    { new Guid("d87959d4-7384-442f-b10b-b7ed7c7e20aa"), "C.27.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wiring and wiring devices" },
                    { new Guid("26bb8127-a8be-4ebd-a1b1-7f6f27d5f6a2"), "C.27.31", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fibre optic cables" },
                    { new Guid("a75fb384-08eb-46fd-9176-87370efb292f"), "C.27.32", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("78bef733-62c7-4d0f-9dcc-479ae6f54ef3"), "C.27.33", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wiring devices" },
                    { new Guid("23f28591-327f-4f02-bec5-dc3461f7906a"), "C.27.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d1cc5444-1781-4ccb-895f-63c039aa0b7a"), "C.27.40", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electric lighting equipment" },
                    { new Guid("3bb091ab-5066-4725-b992-c250ec41f271"), "C.27.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of domestic appliances" },
                    { new Guid("956c903b-4465-4af9-80b6-031a6a64dfd9"), "C.27.51", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electric domestic appliances" },
                    { new Guid("e1d30221-1001-4666-9f48-8eb62b8e4c5d"), "C.27.52", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("8f215c08-610a-41d6-8247-89f40a6d53d2"), "C.27.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("9fe8a22c-01df-4c45-9dda-9016f4a7385c"), "C.27.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other electrical equipment" },
                    { new Guid("f16682c2-aa69-43ff-bf84-53b1e88f4237"), "C.28", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("1226dd66-8693-40d5-8860-546f72f47467"), "C.28.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of general-purpose machinery" },
                    { new Guid("319e6962-a377-4e11-80a4-05be7994281e"), "C.28.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("dc379960-df35-459f-ae2e-2a9421a90c27"), "C.28.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fluid power equipment" },
                    { new Guid("002cc089-e499-4efe-a6f5-a775db3fca17"), "C.28.13", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other pumps and compressors" },
                    { new Guid("83037b7e-258b-4e03-84f0-603a32028f4d"), "C.28.14", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other taps and valves" },
                    { new Guid("e430666f-5e17-4637-8522-a61159d8e02b"), "C.28.15", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("fb49fb70-75b0-4a4b-9848-f33c15daa827"), "C.28.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other general-purpose machinery" },
                    { new Guid("a68daaaa-45fc-4a79-8092-054e7e5e7ea5"), "C.28.21", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("f1c86477-50b1-4836-9ba0-68c155c9b81e"), "C.28.22", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of lifting and handling equipment" },
                    { new Guid("b0dbc0d4-e5ce-44fb-bd65-a62a9156dd70"), "C.28.23", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("ed65ace8-294a-4e6b-9d01-9510213df08d"), "C.28.24", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of power-driven hand tools" },
                    { new Guid("c82b0481-c002-4b45-b768-ef5df2763952"), "C.27.90", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other electrical equipment" },
                    { new Guid("f48da278-6d96-4150-9e03-2f40e5fdd9cb"), "C.27.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("6cb08c6e-8f3d-40e6-b60f-78615cdca6b2"), "C.27", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electrical equipment" },
                    { new Guid("236865e6-69c0-4b4f-a78e-f1b5979a190f"), "C.26.80", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of magnetic and optical media" },
                    { new Guid("9a2b6704-a99c-46ed-9fa7-1938a0e42e00"), "C.25.71", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of cutlery" },
                    { new Guid("891f3bbf-cb14-47b6-b1b2-b3ba124096cb"), "C.25.72", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of locks and hinges" },
                    { new Guid("7d885162-969a-438a-bec9-78736e0ef9e4"), "C.25.73", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of tools" },
                    { new Guid("b08b68a2-b5f0-4bd6-a280-591cb590eab1"), "C.25.9", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other fabricated metal products" },
                    { new Guid("289f501e-527f-45f1-956b-220b17447438"), "C.25.91", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of steel drums and similar containers" },
                    { new Guid("b5bfc3ee-48cd-4c95-b136-daec03002ca1"), "C.25.92", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of light metal packaging" },
                    { new Guid("b0088c06-0aa7-4773-953c-fded4684d1dc"), "C.25.93", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of wire products, chain and springs" },
                    { new Guid("254bf43c-5edd-475e-ac55-76a451787256"), "C.25.94", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("1fdd25b7-b6e4-4fb6-bae5-5fa4e7a22478"), "C.25.99", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("f06f9735-0dc8-44b6-8a52-6dc5b15b517b"), "C.26", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("897f633f-f482-4157-a763-b8fe3d2b92b0"), "C.26.1", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electronic components and boards" },
                    { new Guid("caf2aa12-0c86-4d99-8d47-ef888ce760f5"), "C.26.11", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of electronic components" },
                    { new Guid("e85dd86e-3728-402e-8fe9-5e94d6713a9c"), "C.26.12", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of loaded electronic boards" },
                    { new Guid("4544dd24-b450-482d-9998-4e4f6b695b1f"), "C.26.2", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("ff42beb1-5288-4848-9ed1-12293e3c4dd0"), "C.26.20", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("c7b98b90-75b8-4dab-bc9d-7f7d7e357ceb"), "C.26.3", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of communication equipment" },
                    { new Guid("124f96f9-8a4f-414a-bd76-10e588723041"), "C.26.30", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of communication equipment" },
                    { new Guid("95b63c90-44fe-4e30-afd3-d3668c532286"), "C.26.4", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of consumer electronics" },
                    { new Guid("2494d3b9-c681-492c-bc66-9c8668155412"), "C.26.40", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of consumer electronics" },
                    { new Guid("2354f9a0-312b-4b48-93e3-9110bd6e99c9"), "C.26.5", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("20447619-941f-4c94-8b5a-da6f639deb62"), "C.26.51", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("729fb232-d644-4954-9e7a-a99f92241dbe"), "C.26.52", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of watches and clocks" },
                    { new Guid("2b6e3765-0f25-4680-84fb-59d223e2e8de"), "C.26.6", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("8e7a5f7e-0f73-4b60-9644-514f63bed615"), "C.26.60", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("560ad77e-e68c-484f-b61b-e88af374e85d"), "C.26.7", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("243ee7c8-7a80-4bfe-82ac-2f1d89100760"), "C.26.70", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("86fa23a8-b939-4ee1-bf58-51e116e91231"), "C.26.8", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Manufacture of magnetic and optical media" },
                    { new Guid("c8ea4893-bf7a-460b-97b3-7037123fb5a1"), "C.25.62", new Guid("cdcad068-377b-4020-880c-cde5196056b1"), "Machining" },
                    { new Guid("d9390a57-1c49-42cf-b727-37353f6db5b3"), "U.99.00", new Guid("1fd26d14-c6e8-4720-8a95-8bbe268c7326"), "Activities of extraterritorial organisations and bodies" }
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
                name: "Languages");

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
