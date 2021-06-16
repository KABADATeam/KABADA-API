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
                    { new Guid("d4e0fd55-1d1d-4bcc-9882-a2433109f690"), "AT", "Austria" },
                    { new Guid("50f86867-4324-41b3-a637-fcecf883396e"), "LU", "Luxembourg" },
                    { new Guid("15c24f4c-a609-4238-8b12-e2c148e18644"), "MT", "Malta" },
                    { new Guid("d0191967-44e0-44f4-bceb-6aa95cfca820"), "NL", "Netherlands" },
                    { new Guid("45195bb0-d530-4021-8bc8-3120c2e24ef9"), "MK", "North Macedonia" },
                    { new Guid("cec4a420-5e0e-43e6-b03a-92e0f42d915e"), "NO", "Norway" },
                    { new Guid("04773d0d-8858-4b80-8397-c9e1b29b9bac"), "PL", "Poland" },
                    { new Guid("b67c7327-9d8c-4372-a138-8336ce440514"), "PT", "Portugal" },
                    { new Guid("1e7e8ac7-3b89-4a3f-9772-cf72844c5dee"), "RO", "Romania" },
                    { new Guid("484425d2-dbf1-4405-83aa-e9659e3992af"), "RS", "Serbia" },
                    { new Guid("f83ac670-b2d9-4cb1-acf8-071576360e88"), "SK", "Slovakia" },
                    { new Guid("ffb86feb-7234-4aaf-a37c-6abf09c072b2"), "SI", "Slovenia" },
                    { new Guid("3831c7db-3b31-40d8-a7b0-81348d032931"), "ES", "Spain" },
                    { new Guid("2d703c95-6e6e-4a79-853d-97f6e8c87e0a"), "SE", "Sweden" },
                    { new Guid("a29998c5-424d-4de7-9519-5594789ec2eb"), "TR", "Turkey" },
                    { new Guid("a90fa945-9031-4034-88ae-eac1e7a7ecdc"), "UK", "United Kingdom" },
                    { new Guid("0d3e0cc1-9b78-408a-8a75-26e37e76a5f6"), "LT", "Lithuania" },
                    { new Guid("544b9e3f-a43c-49c1-8dcb-ff0a6acbf9ff"), "LI", "Liechtenstein" },
                    { new Guid("dcb3f3e2-d48e-4820-b5ff-631078ae86d0"), "CH", "Switzerland" },
                    { new Guid("d460376b-7ce8-486d-aa19-3d666648c476"), "IT", "Italy" },
                    { new Guid("8c79d5a1-a3bc-4d0f-a8bf-7814fa010a9b"), "LV", "Latvia" },
                    { new Guid("e39c59b3-eb76-4e41-a4cb-d64d14966246"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("2e10e071-704e-4a7a-8b61-b648e4d94b90"), "BG", "Bulgaria" },
                    { new Guid("6aedc642-7d69-4e68-a56e-605a88496777"), "HR", "Croatia" },
                    { new Guid("e23644ec-0f0c-40ac-85f4-377789516294"), "CY", "Cyprus" },
                    { new Guid("e4b0db87-fc51-4127-9aa5-c0642c8c28eb"), "CZ", "Czechia" },
                    { new Guid("cc8fdf48-fd14-48ce-83a5-c756490d644e"), "DK", "Denmark" },
                    { new Guid("f48248a8-a2db-4647-9447-a65cb84ff385"), "BE", "Belgium" },
                    { new Guid("e0c3a22d-148e-4de7-b3eb-b08e97ea99d9"), "FI", "Finland" },
                    { new Guid("8073b119-3bcf-40c1-9949-01d129279387"), "FR", "France" },
                    { new Guid("5788860f-3d5b-4780-bf9f-927f20f33a1b"), "DE", "Germany" },
                    { new Guid("0becb4b5-bff9-495a-bf78-a5c0286b5b8f"), "EL", "Greece" },
                    { new Guid("d795802a-44ca-4e33-a982-1a745fbd7951"), "HU", "Hungary" },
                    { new Guid("1f519b96-e9a8-404f-8752-6ebdd5b8e0c2"), "IS", "Iceland" },
                    { new Guid("59e81d0c-7ce6-4c2f-8cf0-0becd0e4a375"), "EE", "Estonia" },
                    { new Guid("4e3893f4-7752-4c43-80cb-f66acfd36c8f"), "IE", "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("c597782f-8c15-45f7-b35f-e7816f367775"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("1fdc383c-2648-4211-98bf-63633599ed8f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3c362689-b916-42f0-817b-b3b28201cfa1"), (short)2, "Frequency" },
                    { new Guid("c4aaffb4-fe64-4120-8bcf-73417c58c200"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3c362689-b916-42f0-817b-b3b28201cfa1"), (short)1, "Ownership type" },
                    { new Guid("3c362689-b916-42f0-817b-b3b28201cfa1"), (short)6, null, new Guid("e9da852b-53e5-4867-9421-e8d10710db6e"), (short)5, "Other" },
                    { new Guid("a74a5da9-b2aa-442c-b8eb-7657f7316fb4"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("50ad2055-07fa-4aed-849b-1d34383c39fa"), (short)1, "Ownership type" },
                    { new Guid("93c3762a-1167-4072-8971-9b0ae4efc235"), (short)6, null, new Guid("e9da852b-53e5-4867-9421-e8d10710db6e"), (short)3, "Transport" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b01d4ce5-b9ab-458a-8f3d-0938fd41071b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("93c3762a-1167-4072-8971-9b0ae4efc235"), (short)2, "Frequency" },
                    { new Guid("e35fcd99-91a3-4801-9ac9-6f0de323ed37"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("93c3762a-1167-4072-8971-9b0ae4efc235"), (short)1, "Ownership type" },
                    { new Guid("fdd1055c-6d5c-4bb4-8c4f-8bc07954a585"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f4a3c056-a780-460d-baf4-174d41f7cd17"), (short)2, "Frequency" },
                    { new Guid("a4fbbb1f-876a-43ca-97ac-bf8ef90bf3f4"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f4a3c056-a780-460d-baf4-174d41f7cd17"), (short)1, "Ownership type" },
                    { new Guid("ff4ab428-d072-409c-9f0b-9d1bbf154a25"), (short)6, null, new Guid("c597782f-8c15-45f7-b35f-e7816f367775"), (short)1, "Brands" },
                    { new Guid("f4a3c056-a780-460d-baf4-174d41f7cd17"), (short)6, null, new Guid("e9da852b-53e5-4867-9421-e8d10710db6e"), (short)2, "Equipment" },
                    { new Guid("50ad2055-07fa-4aed-849b-1d34383c39fa"), (short)6, null, new Guid("e9da852b-53e5-4867-9421-e8d10710db6e"), (short)4, "Raw materials" },
                    { new Guid("3308ad06-db11-4a3f-af03-3d7ccacb6557"), (short)6, null, new Guid("c597782f-8c15-45f7-b35f-e7816f367775"), (short)2, "Licenses" },
                    { new Guid("d83c9efd-0cdb-4aa6-b34e-5a195441ad60"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("e6e9fff2-702b-4b75-aeb6-63364a25d2c3"), (short)2, "Frequency" },
                    { new Guid("93c346e5-b325-4ddd-b019-442c67be3876"), (short)6, null, new Guid("c597782f-8c15-45f7-b35f-e7816f367775"), (short)4, "Other" },
                    { new Guid("c7a5d11f-092e-4618-b46c-49543c8cda5e"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("0dfc4ae0-9dc1-4597-a002-4e027a5a7695"), (short)6, null, new Guid("c7a5d11f-092e-4618-b46c-49543c8cda5e"), (short)1, "Specialists & Know-how" },
                    { new Guid("b821ffed-3147-43ac-8ca8-16ab5b1853d0"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("0dfc4ae0-9dc1-4597-a002-4e027a5a7695"), (short)1, "Ownership type" },
                    { new Guid("2d29030e-57f1-4b4b-b1df-717ae31ba334"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0dfc4ae0-9dc1-4597-a002-4e027a5a7695"), (short)2, "Frequency" },
                    { new Guid("e6e9fff2-702b-4b75-aeb6-63364a25d2c3"), (short)6, null, new Guid("c7a5d11f-092e-4618-b46c-49543c8cda5e"), (short)2, "Administrative" },
                    { new Guid("acd9995b-0003-41e9-a573-ac9a26e290fb"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("e6e9fff2-702b-4b75-aeb6-63364a25d2c3"), (short)1, "Ownership type" },
                    { new Guid("115e6d17-fdb9-46d9-b312-5489990c84db"), (short)6, null, new Guid("c7a5d11f-092e-4618-b46c-49543c8cda5e"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("fa577636-c89c-48df-a895-8170c68f1518"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("115e6d17-fdb9-46d9-b312-5489990c84db"), (short)1, "Ownership type" },
                    { new Guid("decec754-b0d0-456d-ae77-5549250c6a0d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("115e6d17-fdb9-46d9-b312-5489990c84db"), (short)2, "Frequency" },
                    { new Guid("808df8f9-4510-43e6-a98a-32fb360f4c4c"), (short)6, null, new Guid("c7a5d11f-092e-4618-b46c-49543c8cda5e"), (short)4, "Other" },
                    { new Guid("a07871ce-6a3b-4a50-b942-5d6441e332b8"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("808df8f9-4510-43e6-a98a-32fb360f4c4c"), (short)1, "Ownership type" },
                    { new Guid("e13a6a74-ffe6-4956-b81f-9ad929df548f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("808df8f9-4510-43e6-a98a-32fb360f4c4c"), (short)2, "Frequency" },
                    { new Guid("04024f0e-854c-4f5a-835c-3b45fc889d29"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("bb90edee-c97b-4803-8475-ef344a773c02"), (short)2, "Frequency" },
                    { new Guid("5e725d78-30b0-4854-8e7a-50c659de4a75"), (short)6, null, new Guid("c597782f-8c15-45f7-b35f-e7816f367775"), (short)3, "Software" },
                    { new Guid("b453f6b5-b149-4d16-b881-b82c5736c88f"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("bb90edee-c97b-4803-8475-ef344a773c02"), (short)1, "Ownership type" },
                    { new Guid("2083b1af-00b8-4bd6-afc6-23f92cac5ea3"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("e9da852b-53e5-4867-9421-e8d10710db6e"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("49c0fe09-dc8a-4790-8798-9a5c2d68e551"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("a60609ed-b366-465f-af72-270d90bd29ea"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("28cef61e-f5f6-4e12-aba1-4062e28956d1"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("0539a498-88e5-488f-b34e-aed54e1c30e8"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("c72bdf54-3fa6-4d67-9277-fda3b10a9f0f"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("e688ddb3-859a-4d76-a520-08723e223737"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("0199d89d-f4eb-45a9-9345-b63dedb68cec"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("0cf31d90-bcd3-4907-9fe4-ac433ad6b181"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("bbe7f7e1-743f-40e6-b04e-f3119ae64b87"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("638b7c4e-c692-49b8-a8e0-4636d32313fd"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("fc77fad2-8a83-44a1-998d-fb00174806b3"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("e8115c4e-54a0-49b0-a48e-46947e29caa5"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("f0e22260-4981-4e44-82fc-258e8f7d1c92"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("bb90edee-c97b-4803-8475-ef344a773c02"), (short)6, null, new Guid("e9da852b-53e5-4867-9421-e8d10710db6e"), (short)1, "Buildings" },
                    { new Guid("c26b95ad-3ecc-440e-b45b-e890697164a7"), (short)1, "a", null, (short)15, "Packaging and labeling" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e3dd6c6a-7cd3-4620-99b6-ac8acb4f8221"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("cd9e85ae-684a-4a86-8051-5617a14dcaa6"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("ba2ca585-c546-4cfd-a2aa-0ad417d2366f"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("9019ff86-ac7a-44cd-91ed-75ec4019ec86"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("c1ebf3b4-01ba-4ad2-80ed-2f9f800313c0"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("0e10287e-f817-49ae-93eb-a6eb07def9ab"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("71bcb904-4618-4ff3-9e51-e16d58d52d2d"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("d718d324-53c2-44ef-b034-c55981c6e86a"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("2a519826-56b3-4537-bb49-3ff7e838e944"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("c6b12dac-2064-47e0-be73-f9a07a04855b"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("ea57cc4e-9d78-4678-8ac3-3e67c57102fd"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("b34c44c8-b5e3-4631-8a80-0028f760bc3c"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("c606530d-7486-46b4-9534-44d74f88a36f"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("f584ebb0-033e-408a-9901-a59a3430e868"), (short)1, "a", null, (short)16, "Complementary and after-sales service" }
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
