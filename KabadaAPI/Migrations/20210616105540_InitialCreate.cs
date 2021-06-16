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
                    { new Guid("3e128a45-f2e8-4448-af0a-264d7cede543"), "AT", "Austria" },
                    { new Guid("64f56e64-e8f1-45cd-904f-64076423dc9f"), "LU", "Luxembourg" },
                    { new Guid("c0cf3334-2fb4-4e14-9a29-d64ec212379e"), "MT", "Malta" },
                    { new Guid("7f30fb4a-0474-4e4a-bac6-02e43c2fcf6c"), "NL", "Netherlands" },
                    { new Guid("5e9b4f8b-183f-4be9-b5d1-da1c4c1892b5"), "MK", "North Macedonia" },
                    { new Guid("e9428454-e251-41da-82eb-94dd2bc6417f"), "NO", "Norway" },
                    { new Guid("46f9ad24-d99f-4bf2-a178-96bac68deafc"), "PL", "Poland" },
                    { new Guid("6a35b01d-8344-4234-ae37-1f369c96be3e"), "PT", "Portugal" },
                    { new Guid("2c86a137-f7a8-442b-bd85-cce086a681d2"), "RO", "Romania" },
                    { new Guid("ee7f45b2-dedb-41d3-b249-ad4ce217c983"), "RS", "Serbia" },
                    { new Guid("10a3e067-ff38-4bc7-bc31-9b87271647f0"), "SK", "Slovakia" },
                    { new Guid("4a206a3a-eff7-489d-b42f-f5d7dfc0ec3e"), "SI", "Slovenia" },
                    { new Guid("33b28f32-c0d0-45b6-9cd2-1eaa429a9331"), "ES", "Spain" },
                    { new Guid("a99e40e9-da70-43a9-9b1f-e06a8928ca85"), "SE", "Sweden" },
                    { new Guid("e7ae0d87-db8a-4ba1-b132-f8efe4620f29"), "TR", "Turkey" },
                    { new Guid("9a456220-18a3-4a49-a69f-8876f4538f07"), "UK", "United Kingdom" },
                    { new Guid("3fc19e14-950c-4698-8bd7-0b47eaebde2e"), "LT", "Lithuania" },
                    { new Guid("312b9e65-5659-4339-98f7-ee6a0f92ad7d"), "LI", "Liechtenstein" },
                    { new Guid("fce5b0db-8d0c-4ef2-9140-fe2a91afe95d"), "CH", "Switzerland" },
                    { new Guid("065cd383-1c55-4d07-9759-fe87a0dd21ec"), "IT", "Italy" },
                    { new Guid("4c4b08a3-527a-46bc-a8d4-8095ce01a61b"), "LV", "Latvia" },
                    { new Guid("fb5a3dba-1897-4130-9f39-9c653efe5568"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("591c8db0-d204-42b8-875d-bbaed5224ee7"), "BG", "Bulgaria" },
                    { new Guid("1983d649-911f-47ee-868c-776722508470"), "HR", "Croatia" },
                    { new Guid("345096e7-e3d8-49f4-9539-64d70c08c1da"), "CY", "Cyprus" },
                    { new Guid("b20d9c52-87b2-4d09-aa88-216bce7af99c"), "CZ", "Czechia" },
                    { new Guid("82a2474f-de2b-4fb0-98ee-6fda4eefbac8"), "DK", "Denmark" },
                    { new Guid("09575b33-abe4-4c85-8e1a-876879f57caa"), "BE", "Belgium" },
                    { new Guid("9ce39b1d-18cd-4d6f-b221-866a90627648"), "FI", "Finland" },
                    { new Guid("bcc34d36-c1b1-4244-9d68-d10abf5ee42e"), "FR", "France" },
                    { new Guid("beb14375-6ec0-420f-9713-75c49eda2c9d"), "DE", "Germany" },
                    { new Guid("3a4d71c7-c870-4c47-ba0a-78c109cd63ef"), "EL", "Greece" },
                    { new Guid("87bcc430-0157-4bfe-9955-01e840050b18"), "HU", "Hungary" },
                    { new Guid("55fa3d91-d9c4-410c-9952-14913b0c9184"), "IS", "Iceland" },
                    { new Guid("40163f71-0ba2-4c67-b37f-0a079e92e8ec"), "EE", "Estonia" },
                    { new Guid("a6e55a02-1922-4a7e-a01a-51a68cbb617b"), "IE", "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7a7386a0-10f9-4ada-8711-6f3eccf6a795"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("624e80f5-5eb8-4bd2-93dd-4d737463a880"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("65670f71-7729-463c-9131-83a3119b4294"), (short)2, "Frequency" },
                    { new Guid("5d491e1b-238b-4641-930c-1f9334042221"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("65670f71-7729-463c-9131-83a3119b4294"), (short)1, "Ownership type" },
                    { new Guid("65670f71-7729-463c-9131-83a3119b4294"), (short)6, null, new Guid("3ab4aa6a-2fd3-40a2-9661-cb21831bdeeb"), (short)5, "Other" },
                    { new Guid("00a19544-b871-42a6-9a9b-460b1b313b54"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9983752c-495a-49df-bcb6-f0af1692887e"), (short)1, "Ownership type" },
                    { new Guid("9aadccde-7593-4ae2-8ad3-a68416600c26"), (short)6, null, new Guid("3ab4aa6a-2fd3-40a2-9661-cb21831bdeeb"), (short)3, "Transport" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("665bbaa9-b444-4f47-9b18-4eac262992ed"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9aadccde-7593-4ae2-8ad3-a68416600c26"), (short)2, "Frequency" },
                    { new Guid("4dfb13ba-8e7a-44a5-89f7-20e204515032"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9aadccde-7593-4ae2-8ad3-a68416600c26"), (short)1, "Ownership type" },
                    { new Guid("19e73ade-b2b8-4455-82f2-c2d5f9a7b044"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("cc48f122-7307-41a7-bd5a-d4352eaccae6"), (short)2, "Frequency" },
                    { new Guid("d5088ba2-3115-406c-ba8c-054e30cf3494"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("cc48f122-7307-41a7-bd5a-d4352eaccae6"), (short)1, "Ownership type" },
                    { new Guid("a5f1ab2d-303e-4fae-a701-d90747e58ffb"), (short)6, null, new Guid("7a7386a0-10f9-4ada-8711-6f3eccf6a795"), (short)1, "Brands" },
                    { new Guid("cc48f122-7307-41a7-bd5a-d4352eaccae6"), (short)6, null, new Guid("3ab4aa6a-2fd3-40a2-9661-cb21831bdeeb"), (short)2, "Equipment" },
                    { new Guid("9983752c-495a-49df-bcb6-f0af1692887e"), (short)6, null, new Guid("3ab4aa6a-2fd3-40a2-9661-cb21831bdeeb"), (short)4, "Raw materials" },
                    { new Guid("296d5af0-2081-4e16-b962-e44834e87df6"), (short)6, null, new Guid("7a7386a0-10f9-4ada-8711-6f3eccf6a795"), (short)2, "Licenses" },
                    { new Guid("ef34011e-27f2-48bf-a0c0-a8f0ef6d1cab"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("43cf7216-43e9-46c2-a13e-2c490ae74dc3"), (short)2, "Frequency" },
                    { new Guid("97954f5b-a08b-4a20-8eb1-3fbfb49f6ecd"), (short)6, null, new Guid("7a7386a0-10f9-4ada-8711-6f3eccf6a795"), (short)4, "Other" },
                    { new Guid("6c747538-0f23-4df8-a146-38253f7d0d22"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("41905c3f-a276-4c0e-a50a-12ac6ea8528c"), (short)6, null, new Guid("6c747538-0f23-4df8-a146-38253f7d0d22"), (short)1, "Specialists & Know-how" },
                    { new Guid("3729b630-d1c5-4ee8-b265-319ec9bcb873"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("41905c3f-a276-4c0e-a50a-12ac6ea8528c"), (short)1, "Ownership type" },
                    { new Guid("f616eff1-4d20-4488-a645-6dc371f182f6"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("41905c3f-a276-4c0e-a50a-12ac6ea8528c"), (short)2, "Frequency" },
                    { new Guid("43cf7216-43e9-46c2-a13e-2c490ae74dc3"), (short)6, null, new Guid("6c747538-0f23-4df8-a146-38253f7d0d22"), (short)2, "Administrative" },
                    { new Guid("de7e8626-dd9c-4e49-92ef-f4de93826ca6"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("43cf7216-43e9-46c2-a13e-2c490ae74dc3"), (short)1, "Ownership type" },
                    { new Guid("02a8271b-e605-4ad0-98b5-aac6d2234f8d"), (short)6, null, new Guid("6c747538-0f23-4df8-a146-38253f7d0d22"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("faae72ac-d25c-434c-aa89-20d7358dae13"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("02a8271b-e605-4ad0-98b5-aac6d2234f8d"), (short)1, "Ownership type" },
                    { new Guid("462ea77a-aefa-40a6-a53a-dac96da53b7d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("02a8271b-e605-4ad0-98b5-aac6d2234f8d"), (short)2, "Frequency" },
                    { new Guid("5e9988ea-4e1b-4086-8aa3-6558b1757327"), (short)6, null, new Guid("6c747538-0f23-4df8-a146-38253f7d0d22"), (short)4, "Other" },
                    { new Guid("56018bbe-d782-4b4a-848e-ab935e1e7934"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("5e9988ea-4e1b-4086-8aa3-6558b1757327"), (short)1, "Ownership type" },
                    { new Guid("6e1b314b-4ca3-4f28-b9ec-a8947bfb251e"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("5e9988ea-4e1b-4086-8aa3-6558b1757327"), (short)2, "Frequency" },
                    { new Guid("6f684521-db20-4778-b147-0057b67203c3"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("5de92430-de46-4585-ac4d-09a609fe3dd9"), (short)2, "Frequency" },
                    { new Guid("9f0eb5a3-8701-4022-b3e2-93407ac6ea08"), (short)6, null, new Guid("7a7386a0-10f9-4ada-8711-6f3eccf6a795"), (short)3, "Software" },
                    { new Guid("dfa6ab0d-ccc1-4860-b22c-5c31734e8f8c"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("5de92430-de46-4585-ac4d-09a609fe3dd9"), (short)1, "Ownership type" },
                    { new Guid("8d8fe810-52fc-4d07-ac0e-579f98075f02"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("3ab4aa6a-2fd3-40a2-9661-cb21831bdeeb"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("3e82184d-d008-4758-8ff5-5ce2e88b2416"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("bb6808d8-8805-4484-b05c-aa07303c2409"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("079f42d4-47d7-4df4-abba-f50b068d8e4f"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("bebc0b35-0c28-43c9-9985-99bf42afb8dc"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("ce11d48a-98de-4187-8573-a11e65b84e6d"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("3ce84d91-81d1-489b-a511-5d02c585aba7"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("f08b9928-6c1d-4dc1-95ce-24dbadd806a3"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("e6e424c3-8cd0-4cd8-b123-bd04a838e36f"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("39c1d3e7-1bee-436a-87c1-f0506e620d29"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("c6138b7c-7ba1-48b1-8d3b-c8cc0d334496"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("5074931f-063f-4de9-bcfa-cff75ac63036"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("df0383e3-4ef3-422b-9c62-0ed6f7c4fc23"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("78991cec-dfc3-4f62-a406-69f692366e29"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("5de92430-de46-4585-ac4d-09a609fe3dd9"), (short)6, null, new Guid("3ab4aa6a-2fd3-40a2-9661-cb21831bdeeb"), (short)1, "Buildings" },
                    { new Guid("34356bc5-a9a9-402a-bf2c-64f6fc9dc228"), (short)1, "a", null, (short)15, "Packaging and labeling" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("1887aa34-0dd6-4680-a863-09bd7d71174c"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("3f78e393-b323-4df0-8414-6bab833b5dc3"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("dbc4fc6a-9cfa-44e7-b9b7-64cd6c9a0554"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("b2f42fdd-07fe-42f7-a5a5-e213da64e2af"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("e96c2336-a96a-484a-8511-627d028d5f84"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("b9cfb1ab-45b9-4666-957d-ca48cfeb46a7"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("5068c469-7ed0-40bc-9da4-901a45caa05e"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("c05f4c3f-1554-4d19-a0c1-703d4cbb7a70"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("f64ec1b0-7635-4823-8922-df8117bef88b"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("006dab47-f56f-497c-bd92-c4e8a7ff3755"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("7bec036b-e509-43e4-a3d7-b5a076cbec4c"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("08face55-dba0-4a02-827a-51523c185889"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("7242f7d8-d690-4981-beea-a4057239bcee"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("e69546fd-d565-4713-99cc-f51667a03b59"), (short)1, "a", null, (short)16, "Complementary and after-sales service" }
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
