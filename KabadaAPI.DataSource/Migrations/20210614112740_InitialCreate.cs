using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
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
                    { new Guid("b5872ebd-e57a-40aa-86ec-9b2a0741c694"), "AT", "Austria" },
                    { new Guid("fd09a859-fa08-4afc-b96b-32aff76350b7"), "LU", "Luxembourg" },
                    { new Guid("a09ef231-cd2b-4308-b556-cc785ccaff27"), "MT", "Malta" },
                    { new Guid("13da9327-3aa4-4181-af35-0c32103880a5"), "NL", "Netherlands" },
                    { new Guid("90a54674-a5cd-4399-8a7a-d66a13c01f13"), "MK", "North Macedonia" },
                    { new Guid("abc0ab2f-2715-41e4-993f-67f30809e811"), "NO", "Norway" },
                    { new Guid("f7fd7f2d-d879-4160-bf2c-4b54639105e3"), "PL", "Poland" },
                    { new Guid("2355ec33-081c-424c-8baa-7c5f542bcc13"), "PT", "Portugal" },
                    { new Guid("d90294c5-46ae-4628-a6fd-e4a0697bcb3c"), "RO", "Romania" },
                    { new Guid("4ec06aa2-ea9a-43f4-b9fe-9d409264c94c"), "RS", "Serbia" },
                    { new Guid("875fc182-02e5-4e00-9986-637d3165baf0"), "SK", "Slovakia" },
                    { new Guid("334ce5d4-fdfe-47ce-8957-af89596987d8"), "SI", "Slovenia" },
                    { new Guid("7e5d0629-1e5d-4e7c-ab05-471da5c22063"), "ES", "Spain" },
                    { new Guid("76676b76-0ac8-4356-bc2a-dd443151504e"), "CH", "Switzerland" },
                    { new Guid("859dc24f-5dc2-4d99-9108-4728e7a152b7"), "TR", "Turkey" },
                    { new Guid("2abbab27-ef65-489e-ad30-651075c37f39"), "UK", "United Kingdom" },
                    { new Guid("b49b07ee-1178-4b5e-8b54-b7144b926318"), "LT", "Lithuania" },
                    { new Guid("aa57b8d3-1274-4d38-8df8-577e43e8c98b"), "LI", "Liechtenstein" },
                    { new Guid("4da7bbd1-8272-44f2-bd41-07f8f67e4604"), "SE", "Sweden" },
                    { new Guid("2d9f818b-980a-4fb2-bfea-6bdd99d9ef68"), "IT", "Italy" },
                    { new Guid("a73ab775-28c3-4507-8053-cede3ffa4294"), "LV", "Latvia" },
                    { new Guid("17b71f31-ec46-4154-be81-161c6657c5d7"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("a4fa1703-c9db-4a3c-a8fc-b12ae1a261d5"), "BE", "Belgium" },
                    { new Guid("5ca43cb2-4f62-4298-a8a6-2da0385f8a21"), "HR", "Croatia" },
                    { new Guid("d25db4b5-14a6-4c8e-a1ee-4789e82f2efe"), "CY", "Cyprus" },
                    { new Guid("1a714dfc-1210-425b-b4a9-8cdd175d9b22"), "CZ", "Czechia" },
                    { new Guid("3d5151d5-e68b-463b-a692-d99d668d093a"), "DK", "Denmark" },
                    { new Guid("81b5d6f1-0f89-4b98-9ec0-f9aeeba3a30b"), "BG", "Bulgaria" },
                    { new Guid("112cc554-fde3-4c96-91d4-014725b1b7c6"), "FI", "Finland" },
                    { new Guid("54fbce70-8c59-4247-b05a-7b7d99e6abfb"), "FR", "France" },
                    { new Guid("a190a512-5487-47c8-8d9e-36c1fe367d88"), "DE", "Germany" },
                    { new Guid("c8637b40-37cd-4aa1-bad8-52c219748abf"), "EL", "Greece" },
                    { new Guid("0f74e853-419a-412e-9166-6fc74a4eb9be"), "HU", "Hungary" },
                    { new Guid("04018539-6595-43aa-81ed-2e34b85a31c6"), "IS", "Iceland" },
                    { new Guid("0f3a4c95-b086-43e7-b4b5-e8ad1bdbabb3"), "EE", "Estonia" },
                    { new Guid("3dd2bf5e-a026-4cc6-bb3c-b59776c6c6ad"), "IE", "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("4e1a8655-b359-434c-b5b1-76b59c4e98c0"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("4db5e670-16ea-4482-af34-bc3469bb997c"), (short)8, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)2, "Frequency" },
                    { new Guid("f74ea26e-c238-452a-abd7-a63793554aef"), (short)8, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)1, "Ownership type" },
                    { new Guid("18ea6e9c-02d4-4241-a8c7-ccf6943aa175"), (short)6, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)5, "Other" },
                    { new Guid("3228bccf-1946-4416-8602-a36205ea396c"), (short)6, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)4, "Resources" },
                    { new Guid("84692b32-d348-4343-bf44-23fe70eb9b6b"), (short)7, null, new Guid("edc8b3e5-11be-4249-a484-44ce2b859113"), (short)5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("272a015b-06d0-4ed9-8731-6126a354947d"), (short)6, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)2, "Production machinery" },
                    { new Guid("fbaaafd3-581d-4aaa-ade5-cfe677d3958c"), (short)7, null, new Guid("edc8b3e5-11be-4249-a484-44ce2b859113"), (short)4, "Sales Buildings (Shop)" },
                    { new Guid("d4706ede-1d06-4443-9dd3-bdf5455254fb"), (short)7, null, new Guid("edc8b3e5-11be-4249-a484-44ce2b859113"), (short)3, "Inventory Buildings" },
                    { new Guid("16f95ec9-1b9c-4a4c-8ab4-fa407b92777a"), (short)6, null, new Guid("4e1a8655-b359-434c-b5b1-76b59c4e98c0"), (short)1, "Brands" },
                    { new Guid("c71fdca3-3f2d-4035-8441-1203cf076481"), (short)7, null, new Guid("edc8b3e5-11be-4249-a484-44ce2b859113"), (short)2, "Manufacturing Buildings" },
                    { new Guid("2c5ca1e7-07c1-4668-817c-dba536021faf"), (short)6, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)3, "Transport" },
                    { new Guid("901ba8ba-0b0d-4da2-8980-d1746845b336"), (short)6, null, new Guid("4e1a8655-b359-434c-b5b1-76b59c4e98c0"), (short)2, "Licenses" },
                    { new Guid("5030932d-be75-43ba-9aef-890cbd9a673f"), (short)8, null, new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)2, "Frequency" },
                    { new Guid("a6be7028-3f67-4ba4-9c7c-d01b2f24d4b5"), (short)6, null, new Guid("4e1a8655-b359-434c-b5b1-76b59c4e98c0"), (short)4, "Other" },
                    { new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("7faf8d76-ea9d-45ba-b36f-a09083cc5aa8"), (short)6, null, new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)1, "Know-how" },
                    { new Guid("de1e2f94-f7c1-4377-8997-f2f66a8e7db1"), (short)6, null, new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)2, "Office" },
                    { new Guid("733cb9f6-a478-4842-b766-4438d5893009"), (short)6, null, new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)3, "Factory/service" },
                    { new Guid("6bc0e45d-8112-4387-91a2-e9967dcd1d07"), (short)6, null, new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)4, "Other" },
                    { new Guid("f6ce59df-e654-4eaf-a49d-2918e60a18a8"), (short)8, null, new Guid("59bbca95-7c2b-44f5-af84-10c66c2253bd"), (short)1, "Ownership type" },
                    { new Guid("2ed24357-d427-4ea0-81a6-82d6b951d306"), (short)5, "The financial resource includes cash, lines of credit and the ability to have stock option plans for employees. All businesses have key resources in finance, but some will have stronger financial resources than other, such as banks that are based entirely on the availability of this key resource.", null, (short)4, "Financial resources" },
                    { new Guid("5af56cca-5109-43dd-84b7-41f334d91812"), (short)6, null, new Guid("2ed24357-d427-4ea0-81a6-82d6b951d306"), (short)1, "For start-up" },
                    { new Guid("7cde693a-35fd-48fa-9926-4492f8d35579"), (short)6, null, new Guid("2ed24357-d427-4ea0-81a6-82d6b951d306"), (short)2, "Operational" },
                    { new Guid("95b04cca-a309-4bf7-a3f2-4d9420b29496"), (short)8, null, new Guid("2ed24357-d427-4ea0-81a6-82d6b951d306"), (short)1, "Is available?" },
                    { new Guid("b89c3363-3454-4043-b621-468b46a40dad"), (short)5, "", null, (short)5, "Other" },
                    { new Guid("f7e19352-5ff9-496e-9a88-31b61be7bde6"), (short)7, null, new Guid("edc8b3e5-11be-4249-a484-44ce2b859113"), (short)1, "Office" },
                    { new Guid("425eba14-b1d2-4d24-80b1-4babc65e9bda"), (short)6, null, new Guid("4e1a8655-b359-434c-b5b1-76b59c4e98c0"), (short)3, "Software" },
                    { new Guid("edc8b3e5-11be-4249-a484-44ce2b859113"), (short)6, null, new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)1, "Buildings" },
                    { new Guid("f56c9973-9245-4094-ba17-a3190b08f9fc"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("8b17d97f-33bd-4da5-b079-10b776fde626"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("5aa85b59-6d64-46d7-af52-f45dd738bd3a"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("fe54001b-8990-4f62-bb60-e082a4b07b6a"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("9b2cac64-b713-489f-b067-2972dd20d5fc"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("510e79ce-3e03-44cd-93e6-373c9d824d78"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("5c67d066-543c-46e7-8ba7-0de76013839d"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("91c8b1b3-da56-4a67-8e75-09d875d5416e"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("448b5afb-dfed-4a51-b391-22be6fd52b3d"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("3942cc1a-3cd5-40e0-8750-78b8bbde665a"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("d48d26a5-ae1c-4e0d-8652-dfeaa73ae85d"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("21d3c26f-744f-42c2-9aa7-1c0a6d4888f9"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("49902b60-1bf8-4350-ab22-b72afa3f3084"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("55da0563-1644-4866-ad21-cf196bf46a2b"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("6a57885f-d29c-4711-9cd4-418b6c19a934"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("f2afac72-bcf9-4772-a2d0-e3507acf7df4"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("640259b9-9766-40bb-baff-d37faf1bc76c"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("db0409ca-53e2-4490-9ace-b6866bc20b85"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("d13710e7-b11a-45b8-9582-0ad00b2f4ee5"), (short)1, "a", null, (short)18, "Return of goods" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("5f09beb6-83f5-4ab9-8475-e16bda459e9d"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("7b0165ff-eb32-4cb6-9fff-eff1856b017c"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("ac8b76f0-2969-4eb3-a7e8-89ef94b5a8c5"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("7f4b9787-fe1e-428a-a4b0-e189b731f0c9"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("cd3e23f5-d7e3-494f-8d04-c90f4582da75"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("a49db530-7bf3-4aed-a92a-1c3237b2e521"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("59bf3122-3552-4d82-97cd-1ef92a3da19e"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("93e41b78-e22c-4ec3-aa48-134eb49a71ee"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("3d516379-6434-4867-95f5-523fde0f1e22"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("1e8cbbc0-dadc-4384-b511-c300f27ff6ca"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("83236494-d936-4d77-845c-2e2e9167185e"), (short)1, "a", null, (short)15, "Packaging and labeling" }
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
