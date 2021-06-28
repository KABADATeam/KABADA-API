﻿using System;
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
                    IsPropositionCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("18c5768c-3b85-45b6-b083-a68c00c82f17"), "AT", "Austria" },
                    { new Guid("a2742ca4-c428-4a36-a4dd-b9edd4bd594b"), "LU", "Luxembourg" },
                    { new Guid("e0020d56-abc6-41e3-9ef8-45a4d76dde26"), "MT", "Malta" },
                    { new Guid("cd8fd29c-e335-472e-ac23-d4b32366b1b0"), "MK", "North Macedonia" },
                    { new Guid("a1523c0b-2213-4364-9223-bfaceb62ecb9"), "NO", "Norway" },
                    { new Guid("0d089144-a723-44bb-857e-bf8a690a76d1"), "PL", "Poland" },
                    { new Guid("21d083c1-b31f-41f7-b435-5e4c23271ec2"), "PT", "Portugal" },
                    { new Guid("b1eb57ac-4402-42c2-84cc-066728b660ac"), "RO", "Romania" },
                    { new Guid("5940d816-c803-4c6a-bec4-c6242594c671"), "RS", "Serbia" },
                    { new Guid("21676297-b083-4e3a-898a-b18a6d25f99a"), "SK", "Slovakia" },
                    { new Guid("38cb7ed8-1ab6-44d1-9b13-1fb2d0192e6a"), "SI", "Slovenia" },
                    { new Guid("4120dcb3-89ab-4ddd-a682-bc98a30f7f0c"), "ES", "Spain" },
                    { new Guid("38842c11-6065-4841-acad-f449741a84a6"), "SE", "Sweden" },
                    { new Guid("7a26d60f-1aab-4b46-af4f-869c3a8ce2e3"), "CH", "Switzerland" },
                    { new Guid("c05f8d90-2cf5-4567-834b-c7f26e93e706"), "TR", "Turkey" },
                    { new Guid("9d5e1770-bc76-4161-a83e-c0aaa60c0ddf"), "UK", "United Kingdom" },
                    { new Guid("c1b6e6c4-4fd4-4a9a-b5c4-70eef0db2def"), "LT", "Lithuania" },
                    { new Guid("95270305-b8cc-4f77-bc54-d2ad9997ca23"), "LI", "Liechtenstein" },
                    { new Guid("a5d0949e-fa4a-4935-88dd-229378434ab2"), "NL", "Netherlands" },
                    { new Guid("3078529f-18c6-49c7-92d7-e8b81623fca1"), "IT", "Italy" },
                    { new Guid("7c1d066b-c824-4dbd-a655-8d4a3d90cce4"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("46accb0c-4d0d-4a8a-b9d0-f12ba3123080"), "BE", "Belgium" },
                    { new Guid("031e657f-24b1-4f97-b981-260c53ad3eb4"), "BG", "Bulgaria" },
                    { new Guid("c5a2426f-0ccc-4c86-bd81-6072c90d8c02"), "LV", "Latvia" },
                    { new Guid("28f0fe26-c855-4b81-9b5f-247d6eb1223e"), "CY", "Cyprus" },
                    { new Guid("136d8ab7-9a4c-40c6-829d-d121bb95bb5b"), "CZ", "Czechia" },
                    { new Guid("87aa4da8-5409-443f-aeab-1b5f87a23a22"), "DK", "Denmark" },
                    { new Guid("ad95c117-b0db-4d8e-b3aa-1e2a15f30aaf"), "EE", "Estonia" },
                    { new Guid("98949989-4031-410c-b2d9-94a27edec458"), "HR", "Croatia" },
                    { new Guid("b5648406-e594-40b6-a279-414a888a1f70"), "FR", "France" },
                    { new Guid("84ecb189-9776-4741-984b-9d037925db78"), "DE", "Germany" },
                    { new Guid("dbd7bcff-6ec3-4729-ac78-48ff3c3fd2ac"), "EL", "Greece" },
                    { new Guid("af15203f-d6d0-4040-8582-0b73606bb7fd"), "HU", "Hungary" },
                    { new Guid("ce5efda8-ad23-4ceb-80ed-fa6059db8caf"), "IS", "Iceland" },
                    { new Guid("b81a5bbc-b11b-4cf4-a8b5-6d723801b7cc"), "IE", "Ireland" },
                    { new Guid("98e8425d-86b9-4fc9-b742-0e8770fdd8df"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("55ebded7-9ace-451f-818e-27db73241340"), "P", "EN", "Education" },
                    { new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("5e126224-7239-4cd7-aa2d-c55ba0259318"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "L", "EN", "Real estate activities" },
                    { new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "H", "EN", "Transporting and storage" },
                    { new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "F", "EN", "Construction" },
                    { new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "J", "EN", "Information and communication" },
                    { new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "C", "EN", "Manufacturing" },
                    { new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "B", "EN", "Mining and quarrying" },
                    { new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "A", "EN", "Agriculture, forestry and fishing" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("ea110c33-61da-491c-b191-44fb3aadc190"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("0e3ec967-2877-476f-8e16-03bfc841e4ab"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b8ecc136-11c1-4a08-97f7-532d0e64fc5d"), (short)2, "Frequency" },
                    { new Guid("bcd577b4-657a-4c1e-830e-04af1d5dba8e"), (short)6, null, new Guid("b0f89103-6bcc-4f17-b6ae-ae752f88b8a0"), (short)2, "Administrative" },
                    { new Guid("be3992fe-61a7-4bf7-88a8-43f5bcc20845"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("b8ecc136-11c1-4a08-97f7-532d0e64fc5d"), (short)1, "Ownership type" },
                    { new Guid("b8ecc136-11c1-4a08-97f7-532d0e64fc5d"), (short)6, null, new Guid("b0f89103-6bcc-4f17-b6ae-ae752f88b8a0"), (short)1, "Specialists & Know-how" },
                    { new Guid("b0f89103-6bcc-4f17-b6ae-ae752f88b8a0"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("0b865f11-4627-4e23-ad62-f52a33f97b3e"), (short)6, null, new Guid("ed605382-f61d-4b31-a0cf-66eae026b226"), (short)4, "Other" },
                    { new Guid("b1c6e32d-cf0e-4e49-807f-32c9f1664dfc"), (short)6, null, new Guid("ed605382-f61d-4b31-a0cf-66eae026b226"), (short)3, "Software" },
                    { new Guid("5d674ebc-cf04-478c-8e66-c4726ed6c76f"), (short)6, null, new Guid("ed605382-f61d-4b31-a0cf-66eae026b226"), (short)2, "Licenses" },
                    { new Guid("a5bb7712-d9b6-48d1-a37b-00faceb28b27"), (short)6, null, new Guid("ed605382-f61d-4b31-a0cf-66eae026b226"), (short)1, "Brands" },
                    { new Guid("ed605382-f61d-4b31-a0cf-66eae026b226"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("4ad6dca9-344c-4fab-ae4a-3e07b2b6003e"), (short)6, null, new Guid("c7d61755-04f9-44c5-a6d1-04008fbd59c6"), (short)4, "Raw materials" },
                    { new Guid("3c3239cc-8006-48cd-925b-2c19ede0e756"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("d843b968-e3c8-4fdc-8b6a-7d2459b7a67a"), (short)1, "Ownership type" },
                    { new Guid("d843b968-e3c8-4fdc-8b6a-7d2459b7a67a"), (short)6, null, new Guid("c7d61755-04f9-44c5-a6d1-04008fbd59c6"), (short)5, "Other" },
                    { new Guid("b16d8d5d-df65-49f7-8be9-dcf7d124af7d"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("4ad6dca9-344c-4fab-ae4a-3e07b2b6003e"), (short)1, "Ownership type" },
                    { new Guid("6e70a084-7805-4518-820a-55509f7fc4a2"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("bcd577b4-657a-4c1e-830e-04af1d5dba8e"), (short)1, "Ownership type" },
                    { new Guid("1395ebf9-128d-4a49-b1e0-06800635112d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("978daff8-8908-4c89-9042-ebf2d790133d"), (short)2, "Frequency" },
                    { new Guid("39cbdc10-fb31-4e67-b192-44810a2e702e"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("978daff8-8908-4c89-9042-ebf2d790133d"), (short)1, "Ownership type" },
                    { new Guid("978daff8-8908-4c89-9042-ebf2d790133d"), (short)6, null, new Guid("c7d61755-04f9-44c5-a6d1-04008fbd59c6"), (short)3, "Transport" },
                    { new Guid("0c00f0d6-0b9d-4840-9978-4b82f1ab2c12"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fd439aa9-6962-4c0d-ad59-c3d23f472dd2"), (short)2, "Frequency" },
                    { new Guid("d1ad44b3-e86d-478f-8d1f-04ac373ff9a6"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("fd439aa9-6962-4c0d-ad59-c3d23f472dd2"), (short)1, "Ownership type" },
                    { new Guid("fd439aa9-6962-4c0d-ad59-c3d23f472dd2"), (short)6, null, new Guid("c7d61755-04f9-44c5-a6d1-04008fbd59c6"), (short)2, "Equipment" },
                    { new Guid("1d8c8280-04a2-4028-bfa0-9311d653dfaf"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d843b968-e3c8-4fdc-8b6a-7d2459b7a67a"), (short)2, "Frequency" },
                    { new Guid("93f36eb6-92d7-4e5b-b402-1ea0d0267f15"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("bcd577b4-657a-4c1e-830e-04af1d5dba8e"), (short)2, "Frequency" },
                    { new Guid("ab25762a-7c2d-4709-9c29-6ae3524348a5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fcf9eaba-6b2e-4dd1-ab7c-8ee435fe5b57"), (short)2, "Frequency" },
                    { new Guid("c5b3832a-c04a-4492-85ce-e7fa99a4df36"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("be8e04ca-3143-4b50-8c91-a84089a04774"), (short)1, "Ownership type" },
                    { new Guid("7032455d-3df3-4123-89e5-292cdb51f0ec"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0ffc0772-028e-44ba-8f88-13b71fd63144"), (short)2, "Frequency" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("23fdce4f-2805-47a1-94a0-9e3c27977cbc"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("01bb2e89-00ef-4772-aa20-89ca18fabfde"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("452323e8-b558-4735-9eee-ef19b275fbc1"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("dbaf30ea-2efb-45b3-9c4d-2df604d0d952"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("c22a1ec6-ceca-40aa-bda4-4c40ab904d76"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("899d6946-6ace-43b2-8ede-6225409421bf"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("1e329a5e-006a-4a83-842b-0aeb8f3342b7"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("a2c82c95-a749-4540-854e-5a9b6b66e968"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("58a94170-481d-4bf6-8700-edfa150a78aa"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("be8e04ca-3143-4b50-8c91-a84089a04774"), (short)6, null, new Guid("b0f89103-6bcc-4f17-b6ae-ae752f88b8a0"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("b3b8f51f-7b50-444a-a4e1-afdb6ba896ee"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("ad122fcc-0654-45bc-a3fd-cf17a5977afe"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("27ac6087-a379-4d5d-8a38-f54ffd7e0937"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("f391fc3e-68aa-4c00-875b-6194fa569c37"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("0b48173f-9669-48dc-86a3-5be462d4a4d5"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("9bf5e050-fde0-4e2b-a419-a8c4e325fd1d"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("b2d6492b-d768-430c-a7fa-bb361fc7b681"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("d40703a7-96c0-47f5-ad63-9a9237de9cca"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("4ecc4d7e-659e-4ff2-9345-6660aaa8ccbc"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("fcf9eaba-6b2e-4dd1-ab7c-8ee435fe5b57"), (short)1, "Ownership type" },
                    { new Guid("fcf9eaba-6b2e-4dd1-ab7c-8ee435fe5b57"), (short)6, null, new Guid("b0f89103-6bcc-4f17-b6ae-ae752f88b8a0"), (short)4, "Other" },
                    { new Guid("bac90bcd-4095-48e8-bc96-3afd252df590"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("be8e04ca-3143-4b50-8c91-a84089a04774"), (short)2, "Frequency" },
                    { new Guid("f203a07e-3f55-4325-8a63-a49333606e86"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("7158d34f-52dc-4dcc-a945-24601ff27402"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("0ffc0772-028e-44ba-8f88-13b71fd63144"), (short)1, "Ownership type" },
                    { new Guid("377ab63e-d498-415b-b106-698ba1e41c6e"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("c7d61755-04f9-44c5-a6d1-04008fbd59c6"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("1473355d-190f-4dc8-a310-5b2f6d1da276"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("781daf6c-8361-431c-9a03-d579e1291602"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("53d64010-541d-4d36-a2b7-9e68726f36f5"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("fbff3c96-46e8-4851-a9d8-127a5a745b72"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("9526bc98-81a6-4bad-9abc-adc2c2fac5da"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("ca2860ad-9eff-44d1-b0fe-9a43b9ae2883"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("01fd747d-f3c7-4ca6-9749-23465511e910"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("408fc4f9-d613-4d12-a03b-ea9d28e3a7a9"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("18f76837-a740-4869-b63a-80f83c2baf49"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("dc5a6253-270e-4bdc-9a42-b65dc6ae54c3"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("0cefacec-07d5-40af-b2ec-51e03e7dbba9"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("759bc6bd-daaf-4dfc-bf70-9cbf7769ab58"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("b0c2e7e1-c798-4232-9de7-a8efd36af66b"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("90469bb2-bf6b-429a-87ec-0d2f956d3857"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("8b32923b-e3ae-442b-b0c4-f7424a2599f2"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("d33a62b3-2040-47cd-a4b4-a10a4226bf5f"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("2e9f52c6-904c-4785-a857-d2a2944f5813"), (short)1, "a", null, (short)5, "Skills and experience of employees" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("fe251f0f-f5c1-4e8c-96e0-b169d8aadfc1"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("c49d7572-6d31-434a-a03e-0b0145968e0b"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("6f483544-8a57-4bb9-99ba-7f32eb1301e0"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("b088c77a-e96e-4143-bbfb-751abdfe797b"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("c8c400c7-f8ae-4e0b-9150-66678f601012"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("0ffc0772-028e-44ba-8f88-13b71fd63144"), (short)6, null, new Guid("c7d61755-04f9-44c5-a6d1-04008fbd59c6"), (short)1, "Buildings" },
                    { new Guid("cabae5e9-0811-4728-af99-3b2427436c7a"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("06f44139-8e1e-4c79-8484-c88f04586e13"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("091754b2-16b6-4119-b3f5-da1828626e7e"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("9d7609ea-2e55-4ad7-b09b-f4e509d1a931"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("ec0c61fa-8865-4d64-b4bf-556ca51bf882"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("f2ca2fd1-7bc2-49ad-b670-d6ad764831d4"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("18838833-ed4b-4105-84fc-2f058bdf976b"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("7acd4a85-9e84-4ff2-97c7-e6a82d4e167a"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("6691655e-4bd8-4eac-9112-bf0148d57e59"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("84f2d3e2-684b-43be-a5c5-9ba173bfc33f"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("af40a569-39a8-4327-987d-2e6a33ea2a8f"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("9a6e63e5-c4ec-4346-a581-059074d949b5"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("9df30c28-2bec-487d-a94b-9d7a0084b57e"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("6b1c7a43-9cb3-40eb-8a10-78a5a5ceceb1"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("2a98bf53-94fe-4575-9246-8a4c12324120"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("f223d74b-db02-425c-a7b9-0e457aaa5127"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("44c412ef-5773-4d4c-bd9c-2105f8f8c7de"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("e4dd0fb0-82f3-467d-a74b-f0f0fdd679b3"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("3a03f2fc-d500-4225-ad76-1337e15f32e3"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("7d30eddd-8fd5-48ed-a1e5-63dd8da73355"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("c1dd3c42-f2e1-4b22-a3fa-eaaa9806cd71"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("6c3ee2bc-e22b-465a-8299-2642e71e199f"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("816534a8-8808-48ad-8b16-e96b29cb35ac"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("03d8ca46-6f39-4891-ace2-c557c9c757fe"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("0bf45a9f-4359-4af6-b8a3-5684167273a4"), (short)3, null, null, (short)2, "Government regulation" }
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
                    { new Guid("70323dea-405d-46cb-9c4c-b9a5fc47d16e"), "A.01", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("39318cc6-cb03-4b9a-9807-b646116f09f6"), "H.51.22", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Space transport" },
                    { new Guid("26f5705d-7187-41c2-8243-25c0976e2fc0"), "H.52", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Warehousing and support activities for transportation" },
                    { new Guid("371f0d0b-a19b-4f79-9421-f0b688e03ce8"), "H.52.1", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Warehousing and storage" },
                    { new Guid("b3026249-911f-4554-a12e-dc9bd27f7167"), "H.52.10", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Warehousing and storage" },
                    { new Guid("2cc262bb-858d-41e8-bea2-133e66a07138"), "H.52.2", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Support activities for transportation" },
                    { new Guid("40af38e2-13b0-401f-92e9-ef61b7dc9f5d"), "H.52.21", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Service activities incidental to land transportation" },
                    { new Guid("7fe35f50-dd56-4443-8924-1fbfb4964a70"), "H.52.22", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Service activities incidental to water transportation" },
                    { new Guid("53bdf011-ad19-4c95-b195-26f71903fc1b"), "H.52.23", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Service activities incidental to air transportation" },
                    { new Guid("294f40a9-5fbd-415c-b758-2a0f53ff991d"), "H.52.24", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Cargo handling" },
                    { new Guid("34d69695-f868-4814-82b0-3ce25df178ef"), "H.52.29", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Other transportation support activities" },
                    { new Guid("3dcec81a-9328-4a0b-88ba-872605b56eef"), "H.53", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Postal and courier activities" },
                    { new Guid("4a880def-b72a-4564-9982-6e571ac21b92"), "H.53.1", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Postal activities under universal service obligation" },
                    { new Guid("44d388c8-2322-48f1-87c9-759f06671633"), "H.51.21", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Freight air transport" },
                    { new Guid("b4bf574d-cf1f-48ae-be2f-ef41a5bfc1ef"), "H.53.10", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Postal activities under universal service obligation" },
                    { new Guid("c880dcd0-d289-46fb-8abb-a66295c62062"), "H.53.20", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Other postal and courier activities" },
                    { new Guid("e8c6303b-b981-48b9-b131-ae90d159312d"), "I.55", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Accommodation" },
                    { new Guid("f8b55c96-6c6e-4df1-8df3-5ff4e71a41aa"), "I.55.1", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Hotels and similar accommodation" },
                    { new Guid("d28d300d-b0b7-4d79-83fd-3a0c370a9e9c"), "I.55.10", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Hotels and similar accommodation" },
                    { new Guid("79af2ac6-d433-422b-80d9-e68ca86fb108"), "I.55.2", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Holiday and other short-stay accommodation" },
                    { new Guid("85c52b15-a6ef-4ce5-80bc-de749d274ac6"), "I.55.20", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Holiday and other short-stay accommodation" },
                    { new Guid("627e8a33-b2cf-473e-ab8d-e92b29319ed4"), "I.55.3", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("ab43b856-b0ac-474e-bdb6-e80394183134"), "I.55.30", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("34887531-35b6-41b6-bf38-b487b1d70873"), "I.55.9", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Other accommodation" },
                    { new Guid("ac966d01-4c17-4df9-8242-b2701cec920f"), "I.55.90", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Other accommodation" },
                    { new Guid("399fb87f-fe71-45b9-9e3d-bad329c79bb7"), "I.56", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Food and beverage service activities" },
                    { new Guid("b326b1a1-49af-4b1e-b525-5bd2d3c73876"), "I.56.1", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Restaurants and mobile food service activities" },
                    { new Guid("305d3ce6-5071-40f4-92ff-de21774d4be8"), "H.53.2", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Other postal and courier activities" },
                    { new Guid("b13171f0-bc96-410a-8df1-0c5091764da5"), "H.51.2", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Freight air transport and space transport" },
                    { new Guid("a4de2a52-2c02-4014-84ae-950e32aeafa9"), "H.51.10", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Passenger air transport" },
                    { new Guid("222c5104-a14f-4eed-a040-239a412924bc"), "H.51.1", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Passenger air transport" },
                    { new Guid("2eb3aa5c-4040-45bf-a326-ae958820bc6c"), "G.47.9", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("e956b31a-b23f-48ef-b89e-804bc92c0517"), "G.47.91", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("f1e46eb1-8cd0-4c92-8e96-1b1b85d51519"), "G.47.99", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("264fee3b-6cc5-42bc-bc87-4aa4211be640"), "H.49", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Land transport and transport via pipelines" },
                    { new Guid("a0be7973-89f5-46e3-82e0-60daa371b5ef"), "H.49.1", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Passenger rail transport, interurban" },
                    { new Guid("180afb70-b3cf-4c8f-873b-3138dc33ec0d"), "H.49.10", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Passenger rail transport, interurban" },
                    { new Guid("db586fef-ab6d-4975-bc55-4b76608f89d6"), "H.49.2", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Freight rail transport" },
                    { new Guid("a12b1510-9d55-4de4-a6ba-e27497130ef5"), "H.49.20", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Freight rail transport" },
                    { new Guid("b1c4467a-a137-4dbf-b168-20069a554b94"), "H.49.3", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Other passenger land transport" },
                    { new Guid("f841009c-20b1-4c97-be25-d71d7a3b6f6b"), "H.49.31", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Urban and suburban passenger land transport" },
                    { new Guid("d40d02bb-0292-4c2b-a50a-e1d70498a816"), "H.49.32", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("63cd8256-afdd-4289-b4b0-f9d0a44ca8f3"), "H.49.39", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Other passenger land transport n.e.c." },
                    { new Guid("0c5db251-2e5e-4f8b-ae24-2e553a5fa3de"), "H.49.4", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Freight transport by road and removal services" },
                    { new Guid("372fa5a5-ef01-40f2-bbc7-e3eb73d350af"), "H.49.41", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Freight transport by road" },
                    { new Guid("fe0e9179-e5fa-4696-ac2c-229479775d45"), "H.49.42", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Removal services" },
                    { new Guid("31e7b6ec-5186-4a4d-932e-65cf1f92b75d"), "H.49.5", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Transport via pipeline" },
                    { new Guid("42483d6b-6a00-40d0-bb45-130617b8c20f"), "H.49.50", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Transport via pipeline" },
                    { new Guid("91d462fb-0f04-42d7-951f-3ac36d82fa81"), "H.50", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Water transport" },
                    { new Guid("cf1c72b6-7f9d-4127-9b56-77ed4e5858d1"), "H.50.1", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Sea and coastal passenger water transport" },
                    { new Guid("6c5c64b7-cf2d-484a-a060-dc87f4bf20c7"), "H.50.10", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Sea and coastal passenger water transport" },
                    { new Guid("25c43461-5a10-47d8-888b-d82e983e34b8"), "H.50.2", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Sea and coastal freight water transport" },
                    { new Guid("4575f4e3-158d-48f7-8057-036a78131925"), "H.50.20", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Sea and coastal freight water transport" },
                    { new Guid("4146bc57-2acb-4b4f-9a56-fab4c39399d2"), "H.50.3", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Inland passenger water transport" },
                    { new Guid("aec5ae67-8c90-4fbf-8c26-b39b4ba3545f"), "H.50.30", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Inland passenger water transport" },
                    { new Guid("fdbe2e43-0cdf-4135-96ba-5a24b70fbd08"), "H.50.4", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Inland freight water transport" },
                    { new Guid("401428a0-8115-4f09-b467-b764639e3cf9"), "H.50.40", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Inland freight water transport" },
                    { new Guid("5e517a4a-78fc-4782-831f-758acc688df4"), "H.51", new Guid("a8185848-9f36-429b-b6d1-f0dbfb56969d"), "Air transport" },
                    { new Guid("522db0ae-db23-4082-ac7e-a444bfe6a0dd"), "I.56.10", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Restaurants and mobile food service activities" },
                    { new Guid("c499d8ce-495b-4b97-8270-6dfd2f302511"), "G.47.89", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("5c693f3b-f531-44e0-afb6-e8417e99b1a9"), "I.56.2", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Event catering and other food service activities" },
                    { new Guid("e3523c37-e053-4203-9392-27e66e089df8"), "I.56.29", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Other food service activities" },
                    { new Guid("75fdaf71-8b5f-4458-a1a6-5e8d0dfcfcc8"), "J.61.30", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Satellite telecommunications activities" },
                    { new Guid("8cd2f693-98e3-4e36-b2e8-4c479600ce29"), "J.61.9", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other telecommunications activities" },
                    { new Guid("04ac670f-e927-4e6a-a71a-8b5104732a61"), "J.61.90", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other telecommunications activities" },
                    { new Guid("c721ba46-e4c2-4410-97dd-90eafb409374"), "J.62", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Computer programming, consultancy and related activities" },
                    { new Guid("b2629114-8933-4eed-8c37-566ac450f242"), "J.62.0", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Computer programming, consultancy and related activities" },
                    { new Guid("a7a79523-60b8-464a-bce3-78e147015636"), "J.62.01", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Computer programming activities" },
                    { new Guid("47dfa13e-7828-440c-8ccf-aacaed5c8a2b"), "J.62.02", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Computer consultancy activities" },
                    { new Guid("aa91640a-9019-49ab-84f4-d7b392f9481e"), "J.62.03", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Computer facilities management activities" },
                    { new Guid("f5b4a217-eb1e-4588-ab30-63d315e8dcdc"), "J.62.09", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other information technology and computer service activities" },
                    { new Guid("6420bf9b-63b8-4423-90bb-f2138b33fd4d"), "J.63", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Information service activities" },
                    { new Guid("6211f6de-f450-418a-848f-6456cce35da4"), "J.63.1", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("dfe06555-d327-48d3-a1d9-c9b3a54336b8"), "J.63.11", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Data processing, hosting and related activities" },
                    { new Guid("66f829e8-200c-47de-ab7b-4e34359641fe"), "J.61.3", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Satellite telecommunications activities" },
                    { new Guid("382d4914-d9ed-4b2f-919b-53ea835758be"), "J.63.12", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Web portals" },
                    { new Guid("52c117bc-2205-4ba4-8211-74aa52aa9226"), "J.63.91", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "News agency activities" },
                    { new Guid("0ff9739b-be0f-4e55-8baf-11af018c9a1c"), "J.63.99", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other information service activities n.e.c." },
                    { new Guid("8c6b4119-96c1-4e3f-9930-5e452db0fe3d"), "K.64", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("685bf764-7fa3-4974-a214-5564385d3ba1"), "K.64.1", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Monetary intermediation" },
                    { new Guid("df9a9f2b-1a3b-4bdf-8a8f-a1665b825fce"), "K.64.11", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Central banking" },
                    { new Guid("ef2bdb02-68b5-4bfe-b888-8883b6afa7fc"), "K.64.19", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Other monetary intermediation" },
                    { new Guid("f4999933-c321-4266-a05a-80926298c154"), "K.64.2", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Activities of holding companies" },
                    { new Guid("042edb1c-f2c0-46ec-8548-e824491dee61"), "K.64.20", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("716398e0-4d84-4ca4-8424-943ae0eb75d0"), "K.64.3", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Trusts, funds and similar financial entities" },
                    { new Guid("697c7d09-aff9-4e86-9871-6d35e0bbc259"), "K.64.30", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Trusts, funds and similar financial entities" },
                    { new Guid("6d81fcbd-8644-4a86-9c12-8b2108864284"), "K.64.9", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("fd08139c-a687-46f6-a648-a07b814eb754"), "K.64.91", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Financial leasing" },
                    { new Guid("5ab67070-cf6e-477f-8f9a-959136f1a741"), "J.63.9", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other information service activities" },
                    { new Guid("c401841a-7733-4e75-9d4d-5020ba4c492f"), "J.61.20", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Wireless telecommunications activities" },
                    { new Guid("dd6c7135-d627-4857-9c93-c8a57b016f29"), "J.61.2", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Wireless telecommunications activities" },
                    { new Guid("d9fab897-3e14-40c7-bb2d-2d425db289f9"), "J.61.10", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Wired telecommunications activities" },
                    { new Guid("f031cd30-5b81-4fcd-9652-ff58d5602971"), "I.56.3", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Beverage serving activities" },
                    { new Guid("bebc2b10-d4f3-4a32-96e1-b90aec7682e4"), "I.56.30", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Beverage serving activities" },
                    { new Guid("0eaa2c51-2bcc-4480-b848-9ee8a48f94d8"), "J.58", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Publishing activities" },
                    { new Guid("7fc8675c-e456-48a2-9af4-35251c82d072"), "J.58.1", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("60909e48-eb38-452f-8e65-15572c47a930"), "J.58.11", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Book publishing" },
                    { new Guid("26b91832-a43c-4ea2-a21e-ddfed222796a"), "J.58.12", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Publishing of directories and mailing lists" },
                    { new Guid("345033f9-31c8-4df9-8c1a-9982cef1b37d"), "J.58.13", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Publishing of newspapers" },
                    { new Guid("efbe6446-a40f-4ace-9162-5c7d051f1614"), "J.58.14", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Publishing of journals and periodicals" },
                    { new Guid("a4ee9b7c-46a3-4f58-8516-89fd11652ae5"), "J.58.19", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other publishing activities" },
                    { new Guid("d7f4069f-e8e2-420b-9589-6519a85e5808"), "J.58.2", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Software publishing" },
                    { new Guid("a8e4c22e-64ab-43a4-9580-31e110e75352"), "J.58.21", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Publishing of computer games" },
                    { new Guid("3e7d86c8-7784-4802-bd50-857329349455"), "J.58.29", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Other software publishing" },
                    { new Guid("c344ecc9-2722-4e63-9f26-18208a74f216"), "J.59", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("cfa6c53d-569e-4139-b09e-0a7f9a7903eb"), "J.59.1", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Motion picture, video and television programme activities" },
                    { new Guid("36af3c4b-62e2-489f-8a0b-6e072df75b84"), "J.59.11", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Motion picture, video and television programme production activities" },
                    { new Guid("272811a6-d1dd-4e73-80fb-60cfe8321776"), "J.59.12", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("92d17a96-96df-4ebe-8bad-6cfe52308a9c"), "J.59.13", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("dcbe2e71-b584-4b5f-98d2-37fce392188a"), "J.59.14", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Motion picture projection activities" },
                    { new Guid("e3405cb2-7a16-4004-b534-e9863a90a05b"), "J.59.2", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Sound recording and music publishing activities" },
                    { new Guid("60fbeb5c-d58b-40f6-9b6a-7027462e68ad"), "J.59.20", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Sound recording and music publishing activities" },
                    { new Guid("5a09ae64-164e-448b-aba6-5f482a9f9598"), "J.60", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Programming and broadcasting activities" },
                    { new Guid("457b2271-f64d-488d-ae9c-310ebc475fb0"), "J.60.1", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Radio broadcasting" },
                    { new Guid("3352b5fa-9bb7-4ed6-928c-173050f71021"), "J.60.10", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Radio broadcasting" },
                    { new Guid("7a173cc5-e8a9-4919-9393-6ce22e88e0a4"), "J.60.2", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Television programming and broadcasting activities" },
                    { new Guid("052e5055-739f-4b2d-ba11-3e67eef70188"), "J.60.20", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Television programming and broadcasting activities" },
                    { new Guid("ce420579-05fa-480d-87f9-25c03e46f732"), "J.61", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Telecommunications" },
                    { new Guid("9b37e20d-c597-4e58-b2ed-c2a8f0718eb0"), "J.61.1", new Guid("e2d58cdd-6b59-458f-ab34-e1bdbf6183da"), "Wired telecommunications activities" },
                    { new Guid("d2c7ef31-87d6-4159-8db8-1bffb56459f3"), "I.56.21", new Guid("1dc2ea00-1530-43dc-b9b4-3724143c37e5"), "Event catering activities" },
                    { new Guid("324da3c6-aa95-47aa-93cd-985444d80715"), "K.64.92", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Other credit granting" },
                    { new Guid("df3ad534-5ac8-4314-bf52-e2cdfe65c4fa"), "G.47.82", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("38ac1d4a-d679-4971-b0c8-d947d1b46bc2"), "G.47.8", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale via stalls and markets" },
                    { new Guid("fca9967e-c910-4343-bf98-99783ad39e2e"), "G.46.19", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("ce2a97af-d907-4722-a0c7-ce24e3b74470"), "G.46.2", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("7430f932-b623-4fa8-89f7-071fecbdeaf6"), "G.46.21", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("21a8ee6b-2a03-4d15-9eef-3e4d85a27429"), "G.46.22", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of flowers and plants" },
                    { new Guid("168a01f8-9966-4d37-b305-13c02216af46"), "G.46.23", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of live animals" },
                    { new Guid("197ecc2c-ad0d-4401-b3a7-6a8c08d3a71c"), "G.46.24", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of hides, skins and leather" },
                    { new Guid("14eea21d-65c5-45eb-a575-6671922113bb"), "G.46.3", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("e6503c3e-6c82-46b9-a4e1-45828f561c87"), "G.46.31", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of fruit and vegetables" },
                    { new Guid("3110f279-3c5f-482f-9e4a-7d690608054f"), "G.46.32", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of meat and meat products" },
                    { new Guid("978287ba-85bf-4d97-ae45-9d3f18645f81"), "G.46.33", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("937154c9-a3e0-41a1-981e-cde65c7dfe20"), "G.46.34", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of beverages" },
                    { new Guid("01ceee02-8c48-4598-a8fe-456730e0a2ba"), "G.46.35", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of tobacco products" },
                    { new Guid("2c894b73-ceba-4e87-bfb4-679049f699cc"), "G.46.18", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents specialised in the sale of other particular products" },
                    { new Guid("f781d0bd-a024-48be-aa5f-f4f2b82c011d"), "G.46.36", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("71f06274-8ed0-4b66-936e-db3562ebb11b"), "G.46.38", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("fbd13139-73af-486a-ae8d-6aa5c10e5ff1"), "G.46.39", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("b2bcee5c-4cfc-4223-97cf-beb99c496c80"), "G.46.4", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of household goods" },
                    { new Guid("5e88d02f-fd4c-4f5a-a7da-0fb400bc6c77"), "G.46.41", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of textiles" },
                    { new Guid("1738b26e-0707-46b5-a5fc-e61566c225d0"), "G.46.42", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of clothing and footwear" },
                    { new Guid("7d742cbd-dfd9-4e70-87f9-2b45dccfb5d1"), "G.46.43", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of electrical household appliances" },
                    { new Guid("567ce8d9-4e9e-49ed-9709-de789d0cf8fd"), "G.46.44", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("bb866c2d-4226-43c2-883d-bd5353812a73"), "G.46.45", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of perfume and cosmetics" },
                    { new Guid("73415561-89ad-496a-b4cc-bdddf8961da8"), "G.46.46", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of pharmaceutical goods" },
                    { new Guid("1e86e32f-879b-49dd-8350-2e417c180eb8"), "G.46.47", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("40fe639b-02bc-430b-af81-573074cd7363"), "G.46.48", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of watches and jewellery" },
                    { new Guid("daa6f1dd-56db-4bdc-9960-93897f9f84fa"), "G.46.49", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of other household goods" },
                    { new Guid("64e1891c-2232-4146-98fb-50c5007b1825"), "G.46.37", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("5850e2a5-4c36-4884-8aaa-e1d5160b5738"), "G.46.17", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("15cadd96-f48c-4d64-9a7d-3b93eb54d553"), "G.46.16", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("69a2bbfd-aab2-4ed2-b61f-a5dff180af69"), "G.46.15", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("65df5373-b573-45f2-8f25-d2e40f66ebcf"), "F.43.29", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Other construction installation" },
                    { new Guid("1eb2b51b-773b-4cc8-952a-c7c216e8faac"), "F.43.3", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Building completion and finishing" },
                    { new Guid("095ed371-a537-457f-9189-e17a3a355d78"), "F.43.31", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Plastering" },
                    { new Guid("113a0541-994d-4884-bed3-154bc730fe68"), "F.43.32", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Joinery installation" },
                    { new Guid("de2caa9a-6792-469e-94ba-2ef94d90026d"), "F.43.33", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Floor and wall covering" },
                    { new Guid("77cc13c6-7a81-4db5-9ecf-271e05a884a4"), "F.43.34", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Painting and glazing" },
                    { new Guid("68c69379-b310-41e9-9743-9dd707b98a63"), "F.43.39", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Other building completion and finishing" },
                    { new Guid("47946d41-5527-440e-8a64-13171e0285eb"), "F.43.9", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Other specialised construction activities" },
                    { new Guid("955ab265-f924-436c-aa2d-afbca034f4aa"), "F.43.91", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Roofing activities" },
                    { new Guid("eb6acf43-bbd6-41a5-be42-c15e6f1e8913"), "F.43.99", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Other specialised construction activities n.e.c." },
                    { new Guid("88281e26-8f2a-44dc-8e50-f8e1b1ebced9"), "G.45", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("d63ef7bb-a0f3-4c59-8c5b-64c59dc63af0"), "G.45.1", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Sale of motor vehicles" },
                    { new Guid("95c7d1f9-83f4-4cd5-8212-eca450027ba1"), "G.45.11", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Sale of cars and light motor vehicles" },
                    { new Guid("f69bc0ea-f21b-4c30-b79e-156558a53dda"), "G.45.19", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Sale of other motor vehicles" },
                    { new Guid("72699364-c9c9-4189-b5cd-2fcb62a127d5"), "G.45.2", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1789dc5f-b194-411b-9ba7-f7d6d46d95c6"), "G.45.20", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Maintenance and repair of motor vehicles" },
                    { new Guid("0b33abdd-7333-4b2c-b789-854c0150ed1d"), "G.45.3", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("7340cd6c-9264-43a1-bc79-a27115b9c6ff"), "G.45.31", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("6606c3d7-7536-4d7f-a441-fc62aa0748c4"), "G.45.32", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("e79f92ca-1251-422c-b331-fed6580a3d75"), "G.45.4", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("493234cf-89d0-42c6-915b-1c686569fb5f"), "G.45.40", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("24e6031f-ae27-4f4f-a1bf-ecb800d6540e"), "G.46", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("7bce7c60-8aed-4a04-8580-6852fb6fc285"), "G.46.1", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale on a fee or contract basis" },
                    { new Guid("15b0505f-5beb-4a4f-9491-762a338b813c"), "G.46.11", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("a2703a53-8a10-47b9-8442-40e7ea454562"), "G.46.12", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("ac7be5e1-4644-48b2-b0bf-dd41b907ec55"), "G.46.13", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("6771ae31-74d7-4259-a379-4a56dd9505f6"), "G.46.14", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("df06cc1d-2a43-4faa-ac44-dc0919e6f283"), "G.46.5", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of information and communication equipment" },
                    { new Guid("7c5b6f53-548e-44d3-aeff-0aa06256aac3"), "G.47.81", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("95cb4dcc-a653-44d4-ac15-866b91e7729e"), "G.46.51", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("12da9c26-b680-4321-8880-6fe04622bafa"), "G.46.6", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("bc661a76-f02d-4b68-8778-e6902f116f9d"), "G.47.4", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("d8a6f135-2a1b-4824-be7c-50529949bbf0"), "G.47.41", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("373a24f2-25ad-4147-b1cb-648568d3bf13"), "G.47.42", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("3d1d79c2-843a-463a-8b1a-0735e9e49b5f"), "G.47.43", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("793bbc98-eeef-4df3-8977-447f77232d4f"), "G.47.5", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("10136e14-f898-46ee-9239-bbfe5a1b6a48"), "G.47.51", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of textiles in specialised stores" },
                    { new Guid("d3ebced7-eb60-4337-897c-fb97f82ca5fa"), "G.47.52", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("6fd0eacf-5b34-42eb-ad0f-304de81d6c05"), "G.47.53", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("ceb4e821-5d93-42f3-a47e-2194e2dc1ea1"), "G.47.54", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("efaf62df-dec7-4b8d-bfa0-c67b25607f24"), "G.47.59", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("1da39d34-8356-49af-92c6-ac56c4a29cb0"), "G.47.6", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("10b9c1e0-6de1-4cb9-903d-7a682ca16cd8"), "G.47.61", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of books in specialised stores" },
                    { new Guid("333fd4a6-0f60-4ba3-bab2-931d32eb0b50"), "G.47.30", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("7f366873-81a2-4e6a-bb91-eb0da3a520ec"), "G.47.62", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("c9588d94-259b-4fb5-9d53-4c3a9352e5fb"), "G.47.64", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("ce7d80e0-6b41-4eee-a0b7-69d3c8b3ded0"), "G.47.65", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("b6d64dc8-9f06-4388-a129-695e2adc02d6"), "G.47.7", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of other goods in specialised stores" },
                    { new Guid("742e8fce-72ed-4f3d-a269-6899002a0267"), "G.47.71", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of clothing in specialised stores" },
                    { new Guid("669550a9-7a75-4614-96bb-618b21484d38"), "G.47.72", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("3229a6bf-8a66-43f4-b967-e17f95f62aa1"), "G.47.73", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Dispensing chemist in specialised stores" },
                    { new Guid("13508c83-6eed-4ccf-9d46-948d64a22cfd"), "G.47.74", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("52a95ca7-3387-4771-8987-f888209ed01d"), "G.47.75", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("8ac88e71-0dfb-4b3c-9b05-6c8f49a99850"), "G.47.76", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("dbc4ef8f-9de0-4fb4-8bed-be396d83185d"), "G.47.77", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("db4fa41f-127a-493a-9574-2639844f2f33"), "G.47.78", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("b618c716-8511-4a46-a4ea-650351b9b17f"), "G.47.79", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7131d285-a33d-4a75-abb0-97322d9d00ef"), "G.47.63", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("008dc8b3-ab25-40c7-8108-6344938e56fa"), "G.47.3", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("aae31598-1513-4cb1-b79d-8f0e64cd3eaa"), "G.47.29", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Other retail sale of food in specialised stores" },
                    { new Guid("592d2722-1cc7-470a-97cb-6f984fc73824"), "G.47.26", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("47b9bfd5-a670-43b0-8a60-7ffe23abd286"), "G.46.61", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("d6e66d49-1c85-430f-89c6-390c22525859"), "G.46.62", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of machine tools" },
                    { new Guid("220b3f93-2ad0-4fe6-95ae-afa3f7fa9c1f"), "G.46.63", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("c0abc5cc-7396-4bd4-baaa-df5d40bfaa76"), "G.46.64", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("02a578a5-82e8-40fc-b27a-be0a8b5e0115"), "G.46.65", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of office furniture" },
                    { new Guid("e01de4ec-d7c2-40d6-887a-e220da95fc90"), "G.46.66", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of other office machinery and equipment" },
                    { new Guid("d793f698-ee4f-4692-bf21-0f8a1ceaa375"), "G.46.69", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of other machinery and equipment" },
                    { new Guid("445f8eb0-54d8-4bdc-a687-6f5848dadaff"), "G.46.7", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Other specialised wholesale" },
                    { new Guid("b61782a7-5945-4e30-bec4-3be4f7d11195"), "G.46.71", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("61f60a0a-571f-4a55-8b5b-b20b49b96ea7"), "G.46.72", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of metals and metal ores" },
                    { new Guid("25c55afc-ac2f-4f56-9294-fa068dac9c33"), "G.46.73", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("4f75b804-8daf-4a04-8210-b1b774a2abc8"), "G.46.74", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("fc1eeb7b-3f4f-4240-b99e-50728b63d699"), "G.46.75", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of chemical products" },
                    { new Guid("03cfeb8a-7bcd-4a58-927c-0553ea6ff680"), "G.46.76", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of other intermediate products" },
                    { new Guid("a5885e45-12a6-4b40-93f9-d7a9496cae1a"), "G.46.77", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of waste and scrap" },
                    { new Guid("8a4399dc-d8f6-49c4-b948-616f583bcdb2"), "G.46.9", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Non-specialised wholesale trade" },
                    { new Guid("230d9853-134f-402a-a730-e7fa5dcc8437"), "G.46.90", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Non-specialised wholesale trade" },
                    { new Guid("fb12c18c-0013-4250-b634-64b8930a99e2"), "G.47", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("aeef24ca-8346-4876-b5f6-eac3dd8a57b1"), "G.47.1", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale in non-specialised stores" },
                    { new Guid("23db972c-006c-4f5f-92ae-f46041a161b8"), "G.47.11", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("ee0ef06d-8471-4b7a-afb6-5d2c81c10262"), "G.47.19", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Other retail sale in non-specialised stores" },
                    { new Guid("ca088e81-4c01-4a0b-8bc1-ea47a9603451"), "G.47.2", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("4ea8aee0-0084-4756-902a-dd19395f9115"), "G.47.21", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("7544c5b7-4d10-4a11-a9be-71f7a3c5449e"), "G.47.22", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("d37d8ec4-8987-4421-bfa8-d3c7693657f3"), "G.47.23", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("1409ee22-ed88-44d3-8711-ef6c7b904f21"), "G.47.24", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("de9bd38c-3571-41c3-bc6c-7dd7d9974cb3"), "G.47.25", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Retail sale of beverages in specialised stores" },
                    { new Guid("2c1b61d5-0be5-42a6-a94b-7808e680e1f1"), "G.46.52", new Guid("ae83fbc4-ea4b-4ba1-b5f7-dcdd3f064192"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("1a64215a-50a0-479a-97b0-e4831dc3aeeb"), "F.43.22", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("6e5a78c1-cb23-4dce-9f59-39317ba7b34a"), "K.64.99", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("1868eb48-72ee-492c-b081-f54eb4c3f7bf"), "K.65.1", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Insurance" },
                    { new Guid("4362c3a6-c718-439b-923b-49ce5fe3518f"), "P.85.6", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Educational support activities" },
                    { new Guid("9462f09b-0664-46a6-b90b-ff460491ae1a"), "P.85.60", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Educational support activities" },
                    { new Guid("a68d9244-f76a-4cb2-9122-f692bb687b63"), "Q.86", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Human health activities" },
                    { new Guid("7e87e714-cb16-4960-b3b8-4bfb421b7f61"), "Q.86.1", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Hospital activities" },
                    { new Guid("9b4752b2-7f6f-41a6-88fe-ae5fb3e292ac"), "Q.86.10", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Hospital activities" },
                    { new Guid("93c2e5be-6ccb-44de-810f-9f6d44f0dc2a"), "Q.86.2", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Medical and dental practice activities" },
                    { new Guid("f48a3a51-e65c-4087-bd6a-c792d36ce8ff"), "Q.86.21", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("157cf0b5-43c2-4af2-bcd2-402268a4742f"), "Q.86.22", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Specialist medical practice activities" },
                    { new Guid("51cf3d10-3233-426a-9750-e2439be0868d"), "Q.86.23", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Dental practice activities" },
                    { new Guid("16f4ffc0-92df-4802-beed-761d5213ca39"), "Q.86.9", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Other human health activities" },
                    { new Guid("48f2ed04-4d23-47f0-96ca-ef720e909dbe"), "Q.86.90", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Other human health activities" },
                    { new Guid("e69720ee-0f6f-41de-a17d-f82a2cd628bd"), "Q.87", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential care activities" },
                    { new Guid("c62791dd-e75c-4c4b-b308-f1cbd78d26dc"), "P.85.59", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Other education n.e.c." },
                    { new Guid("dae3d702-b73b-4fb1-a125-79f2823c2091"), "Q.87.1", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential nursing care activities" },
                    { new Guid("c8531be1-96fc-4dd1-8c83-78ec17cc1100"), "Q.87.2", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("fae2b2ac-eaf4-4a61-b324-bf6c2693c879"), "Q.87.20", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("a020b85a-28d1-4715-8784-02431d7c1870"), "Q.87.3", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential care activities for the elderly and disabled" },
                    { new Guid("725a2b2e-7337-4fc8-8a4c-f5010cb83f30"), "Q.87.30", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential care activities for the elderly and disabled" },
                    { new Guid("c230409d-ea47-4ce8-af29-66e1218108f5"), "Q.87.9", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Other residential care activities" },
                    { new Guid("89fa0eb8-9210-402f-878e-cf0bb5ec6d4a"), "Q.87.90", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Other residential care activities" },
                    { new Guid("a06acf54-f4b0-43c8-8cc4-3e93d084003c"), "Q.88", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Social work activities without accommodation" },
                    { new Guid("b4247127-2d9a-4b5d-b9c4-a6f952adfdd3"), "Q.88.1", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("8ebea588-287c-40fb-92e2-b210ba423a1b"), "Q.88.10", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("1787d7fa-cb06-4a44-95ee-aed4d9b6fb8c"), "Q.88.9", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Other social work activities without accommodation" },
                    { new Guid("32fc7e92-ec85-443e-bb13-e58d1eaa80c8"), "Q.88.91", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Child day-care activities" },
                    { new Guid("068a3546-9f13-4721-8b70-541626558ab4"), "Q.88.99", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("307565aa-fb3c-439d-967b-f73eda08e821"), "Q.87.10", new Guid("c2ffe8a7-8202-4641-8730-59fe00c4cd24"), "Residential nursing care activities" },
                    { new Guid("f85abcf7-1561-49ca-9df4-06ac47949807"), "P.85.53", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Driving school activities" },
                    { new Guid("2c2dff33-8885-4dc5-9e5b-8ff443eafde2"), "P.85.52", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Cultural education" },
                    { new Guid("1d393b03-3bb2-4ae3-8606-eb910f66a81b"), "P.85.51", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Sports and recreation education" },
                    { new Guid("d3f3d60b-df94-48fa-82cd-9f105aa9a15d"), "N.82.91", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Packaging activities" },
                    { new Guid("fb5c6d58-e4a1-47c0-8900-5f6017811cc8"), "N.82.99", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other business support service activities n.e.c." },
                    { new Guid("735c4500-16cc-45e0-9b5e-df9ef23974db"), "O.84", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Public administration and defence; compulsory social security" },
                    { new Guid("fa4dbee1-50c1-436c-8872-24a307f98de5"), "O.84.1", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("a2befe47-4d2f-4b95-af8f-b49b501c3723"), "O.84.11", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "General public administration activities" },
                    { new Guid("a12cbeab-1839-4859-a293-566fc4812e5a"), "O.84.12", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("abe7afc3-da1c-43f0-9353-0000272ea383"), "O.84.13", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("383e1201-b938-4a84-bf35-121b70f5271a"), "O.84.2", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Provision of services to the community as a whole" },
                    { new Guid("6c7afe73-3d1d-4636-9c44-4929ab1600a5"), "O.84.21", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Foreign affairs" },
                    { new Guid("1e639af2-0f66-4623-b844-da7081b55abd"), "O.84.22", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Defence activities" },
                    { new Guid("df72af7d-ef70-478e-a2d3-e53ec950579c"), "O.84.23", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Justice and judicial activities" },
                    { new Guid("8648e28e-be25-48f9-b997-326d47a36bb1"), "O.84.24", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Public order and safety activities" },
                    { new Guid("edb192ea-4c6a-45a7-86f4-eb53850649eb"), "O.84.25", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Fire service activities" },
                    { new Guid("7f9abccb-8464-4422-88f0-61531b070fa6"), "O.84.3", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Compulsory social security activities" },
                    { new Guid("4a2dad3f-99d1-4381-9544-4740977dff14"), "O.84.30", new Guid("3374c109-b136-40ca-9c7f-9681aa39c356"), "Compulsory social security activities" },
                    { new Guid("9788cd78-71c8-46f4-9a53-37a75be6227d"), "P.85", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Education" },
                    { new Guid("4c868552-c1c6-4116-a3f6-f0c30b3efd3b"), "P.85.1", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Pre-primary education" },
                    { new Guid("907b1d12-ed7a-424d-a133-63d937679db1"), "P.85.10", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Pre-primary education" },
                    { new Guid("072a5130-36a5-4525-b249-bb4cc0ed03c4"), "P.85.2", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("21dd3333-5b4b-48d8-b662-a47aaf5d6b98"), "P.85.20", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Primary education" },
                    { new Guid("1adca154-9600-4bf7-a612-fec470d780e2"), "P.85.3", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Secondary education" },
                    { new Guid("4232d7bf-de5e-4ba1-ac84-a87a180a541b"), "P.85.31", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "General secondary education" },
                    { new Guid("320ab69b-f6df-4458-beec-8f9e434da7c7"), "P.85.32", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Technical and vocational secondary education" },
                    { new Guid("b54aef00-919c-4a5a-8bf8-ad38f44d1326"), "P.85.4", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Higher education" },
                    { new Guid("5a61cc45-4b48-4862-a242-a11a09026f76"), "P.85.41", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Post-secondary non-tertiary education" },
                    { new Guid("9c3a1fff-5081-48d4-9995-c03b33637063"), "P.85.42", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Tertiary education" },
                    { new Guid("ca237413-043b-4969-acbf-65bc173b9481"), "P.85.5", new Guid("55ebded7-9ace-451f-818e-27db73241340"), "Other education" },
                    { new Guid("571ca87c-b6f9-40cc-ad05-b41ff56646b8"), "R.90", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Creative, arts and entertainment activities" },
                    { new Guid("86cc2865-d15f-4452-b042-dedb89d40481"), "N.82.92", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("f4094320-6fc0-47e7-87f0-69ed44336a88"), "R.90.0", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Creative, arts and entertainment activities" },
                    { new Guid("3312cf5e-ee09-42b4-b158-98eed084cc1f"), "R.90.02", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Support activities to performing arts" },
                    { new Guid("10847a45-5f1a-48ef-804b-85ce55fe5855"), "S.95.1", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of computers and communication equipment" },
                    { new Guid("ac10cfb8-718a-488c-9040-0f0f2ee2e738"), "S.95.11", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of computers and peripheral equipment" },
                    { new Guid("8270c0de-08f1-483b-ad82-19df0622f0c9"), "S.95.12", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of communication equipment" },
                    { new Guid("34955894-854e-4a1f-95d2-2ca76d78a66c"), "S.95.2", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of personal and household goods" },
                    { new Guid("0709a56b-df6a-47ec-a32c-8f75ed9d5d88"), "S.95.21", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of consumer electronics" },
                    { new Guid("cf2aebd3-b3d5-4254-8296-aa9c553f7bfa"), "S.95.22", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("03e8f54b-8a60-431c-91ee-f635a717229f"), "S.95.23", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of footwear and leather goods" },
                    { new Guid("d0012749-49bd-4320-bdc6-c2446a2e4777"), "S.95.24", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of furniture and home furnishings" },
                    { new Guid("376894b4-f1ac-4d2f-8e9b-eda55daeefa1"), "S.95.25", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of watches, clocks and jewellery" },
                    { new Guid("edbf408d-44ff-4c51-aacf-b370298669d3"), "S.95.29", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of other personal and household goods" },
                    { new Guid("0ec4e47a-ce1b-4ef9-a654-c2061332963f"), "S.96", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Other personal service activities" },
                    { new Guid("e61f8a45-2d56-43e7-8618-e777c9ddb715"), "S.96.0", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Other personal service activities" },
                    { new Guid("a6e1ef0b-b772-4e79-a6e6-c752c55d722c"), "S.95", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Repair of computers and personal and household goods" },
                    { new Guid("d52d7da5-3dd9-435d-8427-61a298477b44"), "S.96.01", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("8b5b2874-8039-4362-8bd1-d92659a025b6"), "S.96.03", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Funeral and related activities" },
                    { new Guid("a82847bc-ae8b-49a4-8797-6c01e93a4a87"), "S.96.04", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Physical well-being activities" },
                    { new Guid("6ff6016d-606a-4199-a96b-2ce6ab8b5d3a"), "S.96.09", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Other personal service activities n.e.c." },
                    { new Guid("0c2dda7a-0ecd-40eb-86f9-50e1ef27c7f3"), "T.97", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Activities of households as employers of domestic personnel" },
                    { new Guid("b22fe058-eaae-4d7b-a219-da9b29041464"), "T.97.0", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Activities of households as employers of domestic personnel" },
                    { new Guid("bdd10fd6-2315-4545-b4b2-5bd75bf34baa"), "T.97.00", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Activities of households as employers of domestic personnel" },
                    { new Guid("355ca179-433a-4235-b178-382a337c9917"), "T.98", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("feeb571d-aa68-4912-af2f-21b234635af9"), "T.98.1", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("693861bb-0106-4ede-beec-37c452f4a09c"), "T.98.10", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("b4aa360d-ad80-449a-9fa3-defa2b991f53"), "T.98.2", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("8f2bb55f-8604-4884-8285-44d7a17d9c44"), "T.98.20", new Guid("a6f25b15-6507-423d-b00a-7e19af1ae153"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("6d0a013e-3518-4069-93d6-36a5ea2a3b0a"), "U.99", new Guid("5e126224-7239-4cd7-aa2d-c55ba0259318"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("b4eff91f-ad25-42d1-87c5-68b7e75b6c09"), "S.96.02", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Hairdressing and other beauty treatment" },
                    { new Guid("38b713d9-547b-48eb-b280-fa599db34289"), "S.94.99", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of other membership organisations n.e.c." },
                    { new Guid("ebf7c863-5b4e-4bf5-a829-673947a29c9b"), "S.94.92", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of political organisations" },
                    { new Guid("4f8250b1-a1c1-4c6f-a95e-44d5b652c75e"), "S.94.91", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("cdd77f9b-836b-4339-8ee3-f4361a238eaa"), "R.90.03", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Artistic creation" },
                    { new Guid("bd99fe0f-48f5-416e-acff-dec07edc5bd2"), "R.90.04", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Operation of arts facilities" },
                    { new Guid("490c2e1a-b5fa-4d5f-909a-fc2f2c401700"), "R.91", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("48a28041-728a-49a6-9b27-d1f6faa7a3bf"), "R.91.0", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("8b7684a7-ed04-4d40-aadb-392e817283d9"), "R.91.01", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Library and archives activities" },
                    { new Guid("c580bf5c-702c-45b6-9a08-049245af5b89"), "R.91.02", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Museums activities" },
                    { new Guid("c91417df-938f-4941-8774-88f9a09b695a"), "R.91.03", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("e439617e-86d5-467c-9cf4-6ee44f7ffaf8"), "R.91.04", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("29fbaad3-85da-4ac3-8469-17993ee2e0f8"), "R.92", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Gambling and betting activities" },
                    { new Guid("2681095d-3f90-4fdc-96f3-c8fed81f498e"), "R.92.0", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Gambling and betting activities" },
                    { new Guid("e0dd6975-489f-4971-bdbc-8d6732afc164"), "R.92.00", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Gambling and betting activities" },
                    { new Guid("3b49e52a-316a-433b-a016-a3fb0d77c6f5"), "R.93", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Sports activities and amusement and recreation activities" },
                    { new Guid("1728c7a4-c20c-4adf-a249-a53de8132aaf"), "R.93.1", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Sports activities" },
                    { new Guid("c6315b49-fa67-4ab3-ae96-7dc98819928a"), "R.93.11", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Operation of sports facilities" },
                    { new Guid("d8f29741-1407-43e1-a69e-8126bd2e4bb9"), "R.93.12", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Activities of sport clubs" },
                    { new Guid("7c039d06-011d-422e-9493-a6e5bcb7c427"), "R.93.13", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Fitness facilities" },
                    { new Guid("13ea0489-bbd9-495f-b060-0bee7a672151"), "R.93.19", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Other sports activities" },
                    { new Guid("87c51606-e468-4376-8d00-ba590cab82bc"), "R.93.2", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Amusement and recreation activities" },
                    { new Guid("b9377369-3edb-4ed4-85ca-1e94569a0dd4"), "R.93.21", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Activities of amusement parks and theme parks" },
                    { new Guid("3642e460-48e5-47d0-aec2-8b7f20bc3800"), "R.93.29", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Other amusement and recreation activities" },
                    { new Guid("661f1dff-332d-4041-a85d-069dc0d4cfa0"), "S.94", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of membership organisations" },
                    { new Guid("e2bd44fe-560e-44c2-826f-68d717256013"), "S.94.1", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("96ccf22b-1209-403d-a933-15d01a6c8863"), "S.94.11", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of business and employers membership organisations" },
                    { new Guid("1e0f12f8-dd7b-4993-8eb4-9bb2c7a23e17"), "S.94.12", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of professional membership organisations" },
                    { new Guid("e51d689e-e9f4-44a3-9d54-d7bc2c169e4e"), "S.94.2", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of trade unions" },
                    { new Guid("e71c00dc-f13e-4e99-b4cf-b1fbfa172292"), "S.94.20", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of trade unions" },
                    { new Guid("5552c8f8-a99b-4e00-bf1f-de6c932b73dd"), "S.94.9", new Guid("a7a52f34-7e90-4ef6-9d2a-68fd4c540cc3"), "Activities of other membership organisations" },
                    { new Guid("1abafe34-31b1-4cf1-8126-c9b80c3a9e06"), "R.90.01", new Guid("7ea8e243-beb8-4921-99e5-623e5e2e56f5"), "Performing arts" },
                    { new Guid("b1a56227-3e7d-486f-b0bd-51a02197bf08"), "K.65", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("290b459f-0907-490c-9de1-070268f5a639"), "N.82.9", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Business support service activities n.e.c." },
                    { new Guid("3f643266-6666-4b95-9273-9bb7b3a5df23"), "N.82.3", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Organisation of conventions and trade shows" },
                    { new Guid("45acb3f1-6065-4a68-8d11-d2eb5c73bc20"), "M.70.1", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Activities of head offices" },
                    { new Guid("a9c564e9-f798-4eff-b700-4afb7580091a"), "M.70.10", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Activities of head offices" },
                    { new Guid("a94e4921-81b9-4283-ad1c-e63f7bee3b42"), "M.70.2", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Management consultancy activities" },
                    { new Guid("a4be9ab2-7f86-4a01-96ae-8946b459e73b"), "M.70.21", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Public relations and communication activities" },
                    { new Guid("27ae815b-ce99-4621-af7d-6a1e313f3a2a"), "M.70.22", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Business and other management consultancy activities" },
                    { new Guid("2e487327-8033-4d9c-bacd-c8935b40c0c4"), "M.71", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("0c976e9b-777c-4dc2-b052-108ccf137079"), "M.71.1", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("af73722c-eae9-4f35-b650-605e6b2b4095"), "M.71.11", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Architectural activities" },
                    { new Guid("3d96dd4d-a867-496e-a41f-6065479469a6"), "M.71.12", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Engineering activities and related technical consultancy" },
                    { new Guid("9673119d-00c9-4bb4-8569-07358ab47f93"), "M.71.2", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Technical testing and analysis" },
                    { new Guid("785c5f59-5bd3-41c4-8fcc-6daa3f1d4bd1"), "M.71.20", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("80677525-516c-4f2d-9a59-d7e93c063de3"), "M.72", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Scientific research and development" },
                    { new Guid("f3f0275e-fc36-4f29-b2d0-edd51cb4f22f"), "M.70", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Activities of head offices; management consultancy activities" },
                    { new Guid("ff5f99e5-66c7-41f5-b46b-8662d252a295"), "M.72.1", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("79829650-32f3-4691-b6fc-68839b3d84b8"), "M.72.19", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("12478f03-1194-44ba-bc9f-85ed131a7bd4"), "M.72.2", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("0da22f83-0a37-4d08-aea4-3ddd0def541c"), "M.72.20", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("992f7415-f2ce-4f2d-b92d-8762ab654a05"), "M.73", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Advertising and market research" },
                    { new Guid("bbd54df5-ac7e-4926-a6dd-32df30c26b73"), "M.73.1", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Advertising" },
                    { new Guid("e7c96158-4449-43cf-a441-9cd722d91e46"), "M.73.11", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Advertising agencies" },
                    { new Guid("8a375ac3-4b69-44f6-a7f7-9251d3211500"), "M.73.12", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Media representation" },
                    { new Guid("32cb544c-38de-4117-b206-fe76f28d6e4e"), "M.73.2", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Market research and public opinion polling" },
                    { new Guid("92c8a1c9-41b1-4c8d-95ec-112197a6af02"), "M.73.20", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Market research and public opinion polling" },
                    { new Guid("3921f237-6304-43f3-90b0-fb25966899c0"), "M.74", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Other professional, scientific and technical activities" },
                    { new Guid("1c9a535b-b31b-4d8e-bbd5-ae401fe8dd68"), "M.74.1", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Specialised design activities" },
                    { new Guid("3828f60a-96d6-4a9b-9db1-c7e02a980f19"), "M.74.10", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Specialised design activities" },
                    { new Guid("c2eeaeb2-3ad7-4015-bc0b-5b6d12314c0f"), "M.72.11", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Research and experimental development on biotechnology" },
                    { new Guid("065cb566-dc31-441f-a757-661df8511224"), "M.69.20", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("5fc395ae-ad7b-4c9a-b207-2aa0fde22682"), "M.69.2", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("a5efc05a-c81e-4206-8166-a4dd583f5206"), "M.69.10", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Legal activities" },
                    { new Guid("6fff91e4-ff51-4850-a5ee-941921a51620"), "K.65.11", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Life insurance" },
                    { new Guid("309381d7-0390-4734-aad6-2eaebf5feb8e"), "K.65.12", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Non-life insurance" },
                    { new Guid("e7815836-eca5-49ff-96b8-a200e6b9d2e2"), "K.65.2", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Reinsurance" },
                    { new Guid("585ae281-1be1-460c-937b-08ed1904b9f5"), "K.65.20", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Reinsurance" },
                    { new Guid("3bdbe306-28f6-4042-b12e-e06067ebc92f"), "K.65.3", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Pension funding" },
                    { new Guid("33571fa1-ea85-461f-a21b-528716c03ab5"), "K.65.30", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Pension funding" },
                    { new Guid("a05d73e1-43d0-4ff2-b193-92925418610d"), "K.66", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("0f631b97-ca57-4fbf-b052-5605b915b2c8"), "K.66.1", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("b76f7d89-f414-4784-9fa9-04901cf45b5e"), "K.66.11", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Administration of financial markets" },
                    { new Guid("ed7fbf15-8273-4031-99f2-934757346f0b"), "K.66.12", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Security and commodity contracts brokerage" },
                    { new Guid("29d3bf1e-bc9b-4602-bc60-e00628946581"), "K.66.19", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("06ce3df4-dc4c-4de1-ade3-7be41244a044"), "K.66.2", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("f7e1fa2c-345d-4c57-9e48-f5b1536c351a"), "K.66.21", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Risk and damage evaluation" },
                    { new Guid("3b80de72-e54d-4cb7-84da-5e3c0b222ded"), "K.66.22", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Activities of insurance agents and brokers" },
                    { new Guid("fbcb52b0-bb76-4b79-8b27-d5e014c9744f"), "K.66.29", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("c9f3ac84-006e-4800-a975-b87e3d9ef92d"), "K.66.3", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Fund management activities" },
                    { new Guid("6963b6aa-0d16-4c11-ad4b-2d23a1faf984"), "K.66.30", new Guid("07065472-0ed4-4523-b5a2-cf1e2bf1e483"), "Fund management activities" },
                    { new Guid("2f87d15d-8a23-407c-b2da-09c0f7707f78"), "L.68", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Real estate activities" },
                    { new Guid("97b5c013-6260-4478-ae95-3f06dc0adebf"), "L.68.1", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Buying and selling of own real estate" },
                    { new Guid("d014cef8-fe1d-4ba9-a949-de44f290b33a"), "L.68.10", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Buying and selling of own real estate" },
                    { new Guid("bd73fab4-f76c-435c-81ec-ba333ca0b391"), "L.68.2", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Renting and operating of own or leased real estate" },
                    { new Guid("8b6d9ec6-eee9-4626-90f9-b9aa713a8f0e"), "L.68.20", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Renting and operating of own or leased real estate" },
                    { new Guid("555c5863-9c7f-4a11-adf2-3ba91a6e0864"), "L.68.3", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fa7c9f75-33fa-4b6a-a3e0-23ede2778505"), "L.68.31", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Real estate agencies" },
                    { new Guid("a22f1847-316c-472f-9c98-036c037098b7"), "L.68.32", new Guid("a035be43-8484-49db-91bf-c93ae12c1f7c"), "Management of real estate on a fee or contract basis" },
                    { new Guid("bf09d8b9-1a60-4c84-961b-5ecff026d3d8"), "M.69", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Legal and accounting activities" },
                    { new Guid("c508e468-c12a-4cf8-9b5b-578334a835f5"), "M.69.1", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Legal activities" },
                    { new Guid("ad2c401f-0a73-48a6-9a81-7d402a2b0ac3"), "M.74.2", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Photographic activities" },
                    { new Guid("1d6f6c96-fb40-400c-b874-5b61d25bcf53"), "N.82.30", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Organisation of conventions and trade shows" },
                    { new Guid("13303c55-6470-4466-b873-0195a82c586a"), "M.74.20", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Photographic activities" },
                    { new Guid("957a3b15-bfa6-4fe4-bbde-79ee7c2716a1"), "M.74.30", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Translation and interpretation activities" },
                    { new Guid("263292df-a21b-49f5-a906-a9b2a55dc130"), "N.79.11", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Travel agency activities" },
                    { new Guid("6ab138f6-d833-4534-b9c9-9d7c4d9a3955"), "N.79.12", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Tour operator activities" },
                    { new Guid("6039b841-56dc-46a6-b147-140365db8c6f"), "N.79.9", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other reservation service and related activities" },
                    { new Guid("c6c79b43-6fbc-4785-b896-9357a75d431b"), "N.79.90", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other reservation service and related activities" },
                    { new Guid("4b636df9-0010-4852-ae6e-41c528f66e44"), "N.80", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Security and investigation activities" },
                    { new Guid("5a16070c-d6b8-4aa6-a924-b24ad990274b"), "N.80.1", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Private security activities" },
                    { new Guid("79b0e54c-7ee4-4167-9a02-a6e163b209ff"), "N.80.10", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Private security activities" },
                    { new Guid("dd17021d-cd21-4b8f-ae63-a45a12caeaec"), "N.80.2", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Security systems service activities" },
                    { new Guid("6c022340-b089-4594-8bb7-e166be2d8b9a"), "N.80.20", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Security systems service activities" },
                    { new Guid("d862d27d-a704-427d-90b6-f555869a4865"), "N.80.3", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Investigation activities" },
                    { new Guid("88f147d3-a232-41a9-a05f-9117072db56f"), "N.80.30", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Investigation activities" },
                    { new Guid("fd8d034d-e123-49d9-b542-9f66f7964b36"), "N.81", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Services to buildings and landscape activities" },
                    { new Guid("0579b2be-c7a4-4d7a-b877-9c0364199956"), "N.79.1", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Travel agency and tour operator activities" },
                    { new Guid("8750cafd-7256-4346-bdc2-c9fc80fd37cc"), "N.81.1", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Combined facilities support activities" },
                    { new Guid("8887806a-192e-4735-9000-60058eda0297"), "N.81.2", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Cleaning activities" },
                    { new Guid("443cc4a5-8960-43ae-8fe7-ee49de98b21a"), "N.81.21", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "General cleaning of buildings" },
                    { new Guid("78254abb-4d32-4550-86ba-722146658968"), "N.81.22", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other building and industrial cleaning activities" },
                    { new Guid("be717b9e-46e0-4b60-909c-f6d473ea72af"), "N.81.29", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other cleaning activities" },
                    { new Guid("65e516ee-90a5-4daf-96f7-4aa63d8d8921"), "N.81.3", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Landscape service activities" },
                    { new Guid("0fd670bd-014d-4fb4-b441-755405172fe1"), "N.81.30", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Landscape service activities" },
                    { new Guid("be5a3659-7b26-449e-9937-bda9d99fca43"), "N.82", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Office administrative, office support and other business support activities" },
                    { new Guid("ef74e41a-e168-4a40-a178-05c45d26743f"), "N.82.1", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Office administrative and support activities" },
                    { new Guid("47b47b15-ccb4-4d7b-93dd-efddc54a2db1"), "N.82.11", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Combined office administrative service activities" },
                    { new Guid("5eb19dae-870b-4cb2-80d4-5064644599ad"), "N.82.19", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("386ab927-9a50-4a4b-9813-20800b437823"), "N.82.2", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Activities of call centres" },
                    { new Guid("aa8fda75-dac6-4ff3-bcda-748c3978e5f6"), "N.82.20", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Activities of call centres" },
                    { new Guid("660dd272-f911-4482-8f9a-c0c81e150af6"), "N.81.10", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Combined facilities support activities" },
                    { new Guid("5ee4d2a1-e7f5-4f2f-9db1-3501d604cf41"), "N.79", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("0a265f60-342a-4f9f-8a9b-4aa6fe429f8e"), "N.78.30", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other human resources provision" },
                    { new Guid("8477908e-2ad2-49cd-b025-867b18e8743b"), "N.78.3", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Other human resources provision" },
                    { new Guid("e56ea77c-716c-4bb6-bf57-2f07bf779067"), "M.74.9", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("f63cfdd0-8fc3-4142-9ca7-2184e55e61a3"), "M.74.90", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("29e6ae4d-48af-4e17-845a-b1bea15e3cd0"), "M.75", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Veterinary activities" },
                    { new Guid("479b2368-995e-47ff-b154-2ea84a91d02b"), "M.75.0", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f01d4983-ccdb-43b0-81e9-650a906df291"), "M.75.00", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Veterinary activities" },
                    { new Guid("81bc4f72-722c-4075-9cf8-b8da7716e10a"), "N.77", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Rental and leasing activities" },
                    { new Guid("f56bc6be-83fa-47cc-b206-83ce8b1fba63"), "N.77.1", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of motor vehicles" },
                    { new Guid("88d443de-9407-4454-8ce3-be50628e048a"), "N.77.11", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("12785491-c050-4754-b2cd-c24937256794"), "N.77.12", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of trucks" },
                    { new Guid("56b2e69a-10d7-4582-b3ed-1226fd548f3f"), "N.77.2", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of personal and household goods" },
                    { new Guid("3d5936be-16fb-4a3b-8a66-86414ca4c426"), "N.77.21", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("c9a0d535-9efe-4c4c-827e-c7e5b3d34d85"), "N.77.22", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting of video tapes and disks" },
                    { new Guid("d8541211-c91b-455d-ac2f-68d7e1855c98"), "N.77.29", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of other personal and household goods" },
                    { new Guid("8a764c60-d802-420f-8045-f2074d60b131"), "N.77.3", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("8f75a60d-9f8a-471e-8266-03c4e32428f3"), "N.77.31", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("aba97aa1-e884-4782-9ac6-a8b944842bf3"), "N.77.32", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("91b440d7-02cd-4c24-8de1-837b7a4bbf89"), "N.77.33", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("18feed72-836e-40a2-a295-f57ff715bd8d"), "N.77.34", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of water transport equipment" },
                    { new Guid("ae2d4c80-c82e-4622-a0ac-b35106656347"), "N.77.35", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of air transport equipment" },
                    { new Guid("88960ebb-61ae-4723-a53d-3127bc5aafcf"), "N.77.39", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("f4174c60-4f56-4c58-a0a9-d4f632242fa3"), "N.77.4", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("ee10b7ed-46bc-425a-88da-9907f0e20a65"), "N.77.40", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("aadf7d17-8f1d-422c-9abb-430650c71548"), "N.78", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Employment activities" },
                    { new Guid("0cdf3c12-4877-44b7-93d5-680a5da825f3"), "N.78.1", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Activities of employment placement agencies" },
                    { new Guid("2b436e35-a7d4-4776-9734-d32a7d9c0e83"), "N.78.10", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Activities of employment placement agencies" },
                    { new Guid("ed8d02b5-a02d-4fa4-91fd-fb2845d38c20"), "N.78.2", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Temporary employment agency activities" },
                    { new Guid("c005474b-63e2-4dda-92ab-105bd4839f5a"), "N.78.20", new Guid("9c4ddf83-0a56-4570-9d4d-fef65ddb8cc4"), "Temporary employment agency activities" },
                    { new Guid("a95b6126-530a-47db-be6b-3609a1dba515"), "M.74.3", new Guid("13027098-e9ee-4fd4-8f0c-2e7d741571d0"), "Translation and interpretation activities" },
                    { new Guid("8d6b336b-1c4c-4035-86d5-52215f230484"), "U.99.0", new Guid("5e126224-7239-4cd7-aa2d-c55ba0259318"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("7ca3924d-f98c-4e1e-b7c2-4ab74f8d2490"), "F.43.21", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Electrical installation" },
                    { new Guid("372befdb-6f0a-413d-9d59-407c4987c1b8"), "F.43.13", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Test drilling and boring" },
                    { new Guid("b9c9f0dd-afa9-4ec9-8e37-5e9e10233ec1"), "C.14.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of articles of fur" },
                    { new Guid("2a2e1e27-5ef6-47af-b2a1-4768761d42c7"), "C.14.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of articles of fur" },
                    { new Guid("11ffddca-4915-42c1-8a13-1a76d96f9582"), "C.14.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("e3c37071-46eb-4f7d-8991-1402820e5209"), "C.14.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("8748dba4-5365-4063-82ed-52b892bbb256"), "C.14.39", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("20e7b2b3-542f-4151-adf6-ce4583dff68c"), "C.15", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of leather and related products" },
                    { new Guid("d7563ecd-a0be-4804-93e5-8031c2d724c2"), "C.15.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("acd4b121-6035-45ec-8f2b-a9cb2b37268f"), "C.15.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("d8ddd2a3-f008-4cb0-8fc3-efcacd4a710c"), "C.15.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("8dfb34ab-858c-46fb-8609-43396ecf740d"), "C.15.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of footwear" },
                    { new Guid("83dce512-61a0-4b55-ae17-02dc0e9d6442"), "C.15.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of footwear" },
                    { new Guid("e4e9262e-f635-456b-89a6-d92b88d07023"), "C.16", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("a83689b0-4539-440b-a68a-adf14fd0492f"), "C.14.19", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("3844be7b-bc27-41ff-b8a2-fd5e78ea4739"), "C.16.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Sawmilling and planing of wood" },
                    { new Guid("6862d363-278c-4dc4-80c1-c013f6292fad"), "C.16.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("39d8efec-4d4f-448a-9953-ff13762b47d3"), "C.16.21", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("19752639-bc8a-4519-ba72-69fa93030bb7"), "C.16.22", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of assembled parquet floors" },
                    { new Guid("cc32889f-0cad-4aff-805d-6fe5f37ec28a"), "C.16.23", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("d5737e48-6178-4cae-b0d1-1cd5db9d9442"), "C.16.24", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wooden containers" },
                    { new Guid("66105122-bd58-4a74-9cb5-412bcceaea71"), "C.16.29", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("bdd863f8-5d7a-4fd4-b9b7-2ebf6e46f748"), "C.17", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of paper and paper products" },
                    { new Guid("ee090a6a-a342-480f-9889-7ac538f53274"), "C.17.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("06ada472-1265-4e80-89b7-097d0cc5488d"), "C.17.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of pulp" },
                    { new Guid("90bc1bbe-bcd9-4f1a-8630-71aea8fb308a"), "C.17.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of paper and paperboard" },
                    { new Guid("1807ffd0-792f-461a-b097-d3ed736d7b22"), "C.17.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("330c66c1-ea07-4ae7-92d8-2ba8327f0897"), "C.17.21", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("efd54d33-2d80-4700-8310-90b584e90eed"), "C.16.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Sawmilling and planing of wood" },
                    { new Guid("615cc576-7d37-4c65-86da-fb1f355a06a7"), "C.14.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of underwear" },
                    { new Guid("21f0e215-dad3-46b9-9d13-74f768a74c2d"), "C.14.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other outerwear" },
                    { new Guid("089191ec-d5c5-4909-ab35-1d35c6d0cfc9"), "C.14.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of workwear" },
                    { new Guid("a33ecac9-05d8-4fd0-9cc2-06a6f597ee8f"), "C.11.02", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wine from grape" },
                    { new Guid("20674c56-b078-43e2-a0a3-6052a87fa343"), "C.11.03", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cider and other fruit wines" },
                    { new Guid("1d5a4f5f-720e-4b69-9c95-6ae1400f35be"), "C.11.04", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("8970b534-4188-409b-98a1-9d6f3728fca8"), "C.11.05", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of beer" },
                    { new Guid("e4067a45-8561-4352-a0f7-062fa77be5ca"), "C.11.06", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of malt" },
                    { new Guid("cef40079-8c55-4374-a30c-d343c18ce3de"), "C.11.07", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("9501f581-1da4-4afb-861b-3b994fa37e20"), "C.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tobacco products" },
                    { new Guid("ebfb4c12-4cf8-4596-9f18-ca736abf343e"), "C.12.0", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tobacco products" },
                    { new Guid("013ef760-5f8f-4cf3-8f70-8179ee94f602"), "C.12.00", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tobacco products" },
                    { new Guid("c09fc799-d5b9-439a-b6b2-982d7c4bc51b"), "C.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of textiles" },
                    { new Guid("a33d3bd9-c4dd-43b7-a211-58cc41ae8aa2"), "C.13.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Preparation and spinning of textile fibres" },
                    { new Guid("214c192d-4274-45ac-8d95-ddf5f6ef4ec9"), "C.13.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Preparation and spinning of textile fibres" },
                    { new Guid("c6229418-7be9-4e1f-8f05-2ce69bee9d0f"), "C.13.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Weaving of textiles" },
                    { new Guid("2d93110e-876c-4174-a525-aff85317f024"), "C.13.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Weaving of textiles" },
                    { new Guid("fc3ac67d-33c3-41b8-a1a1-2a35a4c58ecb"), "C.13.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Finishing of textiles" },
                    { new Guid("3d281a5e-c0ef-4d01-a294-5c13d1d2564a"), "C.13.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Finishing of textiles" },
                    { new Guid("323c829b-518a-4d9e-a9c3-7c2f0d8b430f"), "C.13.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other textiles" },
                    { new Guid("b81c3572-3f3c-4f12-b9b7-29c1e3c0b79a"), "C.13.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("f0af4dee-e34e-4355-ac0a-35fbbc99a300"), "C.13.92", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("1d05c1d6-abfd-4ddf-ae75-66159a8c23d2"), "C.13.93", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of carpets and rugs" },
                    { new Guid("2f2b1052-af03-4ce4-a82d-71c664e7dda5"), "C.13.94", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("71ee4f44-02b8-4670-b8b9-56691ff7ea6d"), "C.13.95", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("f418e9e2-a56b-4cfc-a85b-899d89f6fb60"), "C.13.96", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("434ba420-262a-41f1-a782-a041dd85efd7"), "C.13.99", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other textiles n.e.c." },
                    { new Guid("73f6af4d-f421-425e-a4db-f8a99c6445e8"), "C.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wearing apparel" },
                    { new Guid("94f8f65b-7b55-4c84-b3b8-e7cc0cbb91c3"), "C.14.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("61791f5b-d9d8-456e-b428-03e58e5d1004"), "C.14.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("92f9a07e-1dcd-458d-8b12-3ec3e832cbcd"), "C.17.22", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("2b4571d1-2168-47a9-b747-0bdd9e6b32c4"), "C.11.01", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("b4548e72-f8e2-4d2b-8da5-69e15893905a"), "C.17.23", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of paper stationery" },
                    { new Guid("e32ba2cd-4055-4c34-90b1-35093d20bec1"), "C.17.29", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("8a5a53e2-9a6d-4c6f-bfef-8d8f460c1c9a"), "C.20.52", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of glues" },
                    { new Guid("c817c67d-6fd2-49ec-9798-2b983bc5fb9e"), "C.20.53", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of essential oils" },
                    { new Guid("07171e99-3dbf-4085-bcc3-b96ab5b15519"), "C.20.59", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("aae71f54-c7ea-4e84-9b0e-b3be775a908e"), "C.20.6", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of man-made fibres" },
                    { new Guid("1a78e03b-96e2-42c9-a50c-333f101fe340"), "C.20.60", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of man-made fibres" },
                    { new Guid("6b153d9b-60c8-4e41-b488-90e48573b7be"), "C.21", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("e91c76a4-72d3-441d-8f02-ae87f9848faf"), "C.21.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("54cb15ef-7373-4ee0-915b-52c5864a87cc"), "C.21.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("7b327e24-5579-45a2-b749-9f2bdc799c96"), "C.21.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("1ef24ed3-d029-43d9-ba9c-ddeb0cd6209f"), "C.21.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("8b428998-f540-426b-80fd-e41f7b8e7358"), "C.22", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of rubber and plastic products" },
                    { new Guid("e22c88d9-7dc1-4ec8-9729-8a7bcb9d4e3a"), "C.22.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of rubber products" },
                    { new Guid("ccf7c85b-9eeb-435d-b081-f92c5c2f807a"), "C.20.51", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of explosives" },
                    { new Guid("572825b1-8dbf-499e-8933-7c3ddded9d0d"), "C.22.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("52b384c5-8dc6-4b85-a749-c9d743ca6438"), "C.22.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of plastics products" },
                    { new Guid("e2dabc25-15cd-40f0-9d22-45f66e7a2bc8"), "C.22.21", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("e3c3aad2-8c94-43d3-9017-99ba565d2307"), "C.22.22", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of plastic packing goods" },
                    { new Guid("0bb253da-6f93-4c2e-914f-cea9d08113f7"), "C.22.23", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("16a17197-45f9-4dca-9c08-7409159815b1"), "C.22.29", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other plastic products" },
                    { new Guid("973ed91a-0b7b-4068-9fa3-7d9e7783e945"), "C.23", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("08e080d8-88c4-4b56-87e6-4313f698fbb7"), "C.23.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of glass and glass products" },
                    { new Guid("157a01ac-cce6-4756-93f9-bb02f6aae4a9"), "C.23.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of flat glass" },
                    { new Guid("b61120c6-075d-4afa-902e-db8154db1618"), "C.23.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Shaping and processing of flat glass" },
                    { new Guid("286bdaa3-8928-4164-9406-74d0d23431b9"), "C.23.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of hollow glass" },
                    { new Guid("c49d8fe4-6a77-46a8-88a0-d4884e010770"), "C.23.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of glass fibres" },
                    { new Guid("2bcb8035-7cdb-4f3e-9cf2-f11cc0b43464"), "C.23.19", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("206d426b-5948-4f79-a4ce-29cc0ffc8a73"), "C.22.19", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other rubber products" },
                    { new Guid("f8a5203d-f678-481c-bfc6-c3155794b03a"), "C.20.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other chemical products" },
                    { new Guid("8c03623b-5465-4173-9e4f-44058cbfac94"), "C.20.42", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("6b98f02b-4f34-459e-9403-59a595727017"), "C.20.41", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("a13e391a-6695-4526-9f05-f51e077c94bb"), "C.18", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Printing and reproduction of recorded media" },
                    { new Guid("97505ec5-abe2-4aa3-ac96-f9bc40ca5b8c"), "C.18.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Printing and service activities related to printing" },
                    { new Guid("d68db88f-a3d1-4872-9147-a84aa3e87934"), "C.18.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Printing of newspapers" },
                    { new Guid("67c1b832-a7ee-459b-b6dd-526fffe073a3"), "C.18.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Other printing" },
                    { new Guid("b1bed883-9286-4225-94cd-cf2b180ab892"), "C.18.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Pre-press and pre-media services" },
                    { new Guid("dea3df12-f357-47f3-9b82-edc2ad49ea34"), "C.18.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Binding and related services" },
                    { new Guid("b24dfb4e-ef77-4c4d-a05f-10a912118c21"), "C.18.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Reproduction of recorded media" },
                    { new Guid("5711b08a-8d01-49b4-b519-1b57d140c5a5"), "C.18.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a1204205-bdc4-4ab9-83d4-95dd5dd5ceb9"), "C.19", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("934c3b18-3038-4583-aeb2-3c00de59debd"), "C.19.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of coke oven products" },
                    { new Guid("a05e2064-d5e2-4e76-9c74-5fac3f2b2011"), "C.19.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of coke oven products" },
                    { new Guid("5c330a89-0fb9-4453-b74c-150767528d7b"), "C.19.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of refined petroleum products" },
                    { new Guid("9fea93ae-f365-4e87-a2ab-ad96325fb062"), "C.19.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of refined petroleum products" },
                    { new Guid("7639c344-92f3-402c-90b6-a2f0c15a4004"), "C.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of chemicals and chemical products" },
                    { new Guid("b828080e-587e-48c7-8cbc-ab94f663d333"), "C.20.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("7ab07697-41c0-4bdd-9513-56c43aef37fd"), "C.20.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of industrial gases" },
                    { new Guid("06fb153d-16a4-49dd-8e30-89c3231baa49"), "C.20.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of dyes and pigments" },
                    { new Guid("5f2f5b19-5503-4f4a-bb98-b1c87376a6d4"), "C.20.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("c6b0f94b-f78f-402f-b570-51b06709f908"), "C.20.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other organic basic chemicals" },
                    { new Guid("2c04379e-9d9d-474d-a2c1-3ea70a76a656"), "C.20.15", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("79e49d91-2772-43b2-89f8-5bf6c1b393b5"), "C.20.16", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of plastics in primary forms" },
                    { new Guid("5005c96a-04f7-4473-bd8d-8ca66de8f7d8"), "C.20.17", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("b3a4d66a-6930-492c-b9fa-721d5ff363be"), "C.20.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("51087cef-ba87-43be-913d-46ebc83bb209"), "C.20.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("12b6276c-ab28-4e8b-97e3-e04773ebb415"), "C.20.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("96180ac7-4715-4f23-a2ce-3ffda44c5741"), "C.20.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("9516e0a7-5f83-46fc-97af-558c8758ab4a"), "C.20.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("71eaad49-da16-474c-b6e4-e412ce8b5ed3"), "C.17.24", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wallpaper" },
                    { new Guid("1d2b37ca-ef3b-49db-9adf-35a15ee88b38"), "C.23.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of refractory products" },
                    { new Guid("2feb1a5f-b53a-4e4a-8dbd-8a6d5dd64cdd"), "C.11.0", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of beverages" },
                    { new Guid("5d18a2bb-83ee-4d46-ab0c-02bf5feae0c0"), "C.10.92", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of prepared pet foods" },
                    { new Guid("c824ee82-6a55-48a0-b72f-d324b390ec7f"), "A.01.6", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("32542f4e-4b3f-478f-a34b-6b15fe017b3c"), "A.01.61", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Support activities for crop production" },
                    { new Guid("f06dcaef-c1dd-463e-ab7b-57d5c22df727"), "A.01.62", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Support activities for animal production" },
                    { new Guid("e2430885-fa4b-483d-8b4c-2dacd223f33a"), "A.01.63", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Post-harvest crop activities" },
                    { new Guid("9d5921da-afdf-46e7-bfc8-f0d80673e52e"), "A.01.64", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Seed processing for propagation" },
                    { new Guid("19704445-50fd-4304-ac56-c81393fdfd21"), "A.01.7", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Hunting, trapping and related service activities" },
                    { new Guid("f8bf13d2-694a-4773-a6d0-70457b12d419"), "A.01.70", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Hunting, trapping and related service activities" },
                    { new Guid("53cdc21c-518f-4b52-80ce-55a9e3bd06b1"), "A.02", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Forestry and logging" },
                    { new Guid("72ccc4ca-6a64-4957-ae6e-c9679dcaa2b0"), "A.02.1", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Silviculture and other forestry activities" },
                    { new Guid("47897ecc-52e4-474d-a054-689ff0c1e1a4"), "A.02.10", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Silviculture and other forestry activities" },
                    { new Guid("accc2467-cf7c-4e75-8353-31a44b802ab1"), "A.02.2", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Logging" },
                    { new Guid("44fcd874-235b-48a0-a2a7-db38f830eeb1"), "A.02.20", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Logging" },
                    { new Guid("c8f6ea9b-3440-44ec-b508-84a2b32577b3"), "A.01.50", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Mixed farming" },
                    { new Guid("f8232a27-faec-4286-b068-c85fb0849041"), "A.02.3", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Gathering of wild growing non-wood products" },
                    { new Guid("68b36cbf-1da9-4853-9eec-08a5db2302f7"), "A.02.4", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Support services to forestry" },
                    { new Guid("f3cd487a-3e96-4401-98ef-419382fe59fa"), "A.02.40", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Support services to forestry" },
                    { new Guid("34214c71-c928-43d4-b8c0-d61ff771ed43"), "A.03", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Fishing and aquaculture" },
                    { new Guid("464dfbb1-f558-4bea-86ba-2fd994894b57"), "A.03.1", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Fishing" },
                    { new Guid("50e16e62-6fcd-4e93-9129-99261ba907c3"), "A.03.11", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("42343b53-ad5f-4532-ba7c-6e084552ca5d"), "A.03.12", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Freshwater fishing" },
                    { new Guid("0107b3ea-43dd-43ba-a0c7-0e42f10de414"), "A.03.2", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Aquaculture" },
                    { new Guid("41433f4b-cf58-4456-9262-25e6e176e19f"), "A.03.21", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Marine aquaculture" },
                    { new Guid("48a1009b-4935-4730-ac8b-27dd6167c022"), "A.03.22", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Freshwater aquaculture" },
                    { new Guid("6a8f1287-d019-4031-bc47-6d89e9af25be"), "B.05", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of coal and lignite" },
                    { new Guid("4d9301ae-d9d7-4afc-877d-d60715adaa60"), "B.05.1", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of hard coal" },
                    { new Guid("681458b9-109e-482e-a286-91494d1a7e83"), "B.05.10", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of hard coal" },
                    { new Guid("d0fb51f1-d81f-4853-968d-7d51ff472a5e"), "A.02.30", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Gathering of wild growing non-wood products" },
                    { new Guid("b2419f45-4fa0-4131-9caf-d30792e894bf"), "A.01.5", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Mixed farming" },
                    { new Guid("4a65c5f6-a886-4e7a-9559-885a150fb0c4"), "A.01.49", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of other animals" },
                    { new Guid("d6cb5b6a-14a5-47a5-817b-06957cd64ed3"), "A.01.47", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of poultry" },
                    { new Guid("02d24bb0-800c-4f00-9908-9098c209a52c"), "A.01.1", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of non-perennial crops" },
                    { new Guid("7b6291bc-20e1-4dbc-ae93-5fceceae5afb"), "A.01.11", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("596fb961-6261-420f-be30-5c0b6b10261c"), "A.01.12", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of rice" },
                    { new Guid("c722c07f-56a5-43ec-8420-77babfc59cdf"), "A.01.13", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("c5bfac2b-ff9d-4c29-87eb-3d1dfc5e7334"), "A.01.14", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of sugar cane" },
                    { new Guid("73b685ff-3db6-4220-9958-d7d4c9119f2b"), "A.01.15", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of tobacco" },
                    { new Guid("8400bc9b-86e0-497c-bce2-eb3d28e6f7f5"), "A.01.16", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of fibre crops" },
                    { new Guid("a99a066d-6d34-4a19-8a3c-ce273dc3e77f"), "A.01.19", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of other non-perennial crops" },
                    { new Guid("c18118d6-92ef-4d86-aad3-b4ac46454220"), "A.01.2", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of perennial crops" },
                    { new Guid("6a27cc6b-74d8-4f86-99cf-af58fc30676f"), "A.01.21", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of grapes" },
                    { new Guid("b2cd0152-1282-4476-ac9a-6dd3b5b9a57b"), "A.01.22", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of tropical and subtropical fruits" },
                    { new Guid("10e56cb0-4ac5-4584-965b-2a5bde51a8e0"), "A.01.23", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of citrus fruits" },
                    { new Guid("d1baaed5-b462-4b4e-886d-f113cc6d0bba"), "A.01.24", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of pome fruits and stone fruits" },
                    { new Guid("15701c0f-d353-47f8-9b06-c0289052566d"), "A.01.25", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("733543dc-48d1-463d-886a-28361b5311fb"), "A.01.26", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of oleaginous fruits" },
                    { new Guid("22658664-e8da-4c8a-9f0e-031ae2e4ae2e"), "A.01.27", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of beverage crops" },
                    { new Guid("8d57e6ce-5177-48a9-9978-09c60a32ba49"), "A.01.28", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("fafc9030-7677-4dac-b52e-94889af27714"), "A.01.29", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Growing of other perennial crops" },
                    { new Guid("d1cc117d-a5f6-4f64-9765-dd55e75e51bd"), "A.01.3", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Plant propagation" },
                    { new Guid("abbbad4e-6a5e-4143-844d-ab810b7bca31"), "A.01.30", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Plant propagation" },
                    { new Guid("8233f62d-5742-42a5-a5c7-e1c483966fe3"), "A.01.4", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Animal production" },
                    { new Guid("40926dfe-5716-4420-9cda-b7a4b6e00af6"), "A.01.41", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of dairy cattle" },
                    { new Guid("0f25397d-ed1b-4278-8d42-1e0d46d8360e"), "A.01.42", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of other cattle and buffaloes" },
                    { new Guid("080e8c5e-0e51-40ef-84d7-4c267d1dae43"), "A.01.43", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of horses and other equines" },
                    { new Guid("87765843-4d2e-4f6f-8bb9-d68cdf6020e5"), "A.01.44", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of camels and camelids" },
                    { new Guid("2560e434-f0bb-419a-aa20-906e27c336b3"), "A.01.45", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of sheep and goats" },
                    { new Guid("b0eda1ab-7b98-46d2-bdc2-9c93a4e15300"), "A.01.46", new Guid("642c99b8-9240-41ed-b038-72f3804088a9"), "Raising of swine/pigs" },
                    { new Guid("f49096ea-43d7-4334-b48b-ee424755f093"), "B.05.2", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of lignite" },
                    { new Guid("e1fe7a47-1188-43c7-af7b-fc68f600367b"), "C.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of beverages" },
                    { new Guid("dc826c7c-e502-4632-87aa-41808066432a"), "B.05.20", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of lignite" },
                    { new Guid("7f5dd0da-084a-43b3-80f6-b35b110e37d3"), "B.06.1", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4f37e9cf-b682-48f0-a823-df23956c87c1"), "C.10.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of potatoes" },
                    { new Guid("d5443b63-b1ad-4310-809d-dcc535be924f"), "C.10.32", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("f0ff57a4-5dce-41bf-a47f-cf8410439fef"), "C.10.39", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("e80f26ae-d9ed-42f7-9437-2af1ca58e9cd"), "C.10.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("0f040a45-c9a1-46eb-af8f-627ff4001014"), "C.10.41", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of oils and fats" },
                    { new Guid("15147bf2-108c-4556-b7e9-cda4bfa270e6"), "C.10.42", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("b880e24e-8d88-4c03-ba73-75d1194d045c"), "C.10.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of dairy products" },
                    { new Guid("54da070f-7fa0-4ca4-be65-d54ec6454dbf"), "C.10.51", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Operation of dairies and cheese making" },
                    { new Guid("357fa32d-2ed4-4c70-b7f3-43ea2bd86b3e"), "C.10.52", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ice cream" },
                    { new Guid("acb9e7c5-f1e3-4069-91f1-1bf1aee2a7af"), "C.10.6", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("739936d1-b7cc-48c7-947b-40d49f3d2e1a"), "C.10.61", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of grain mill products" },
                    { new Guid("25044b1e-e70f-40cb-b23e-5d909032baec"), "C.10.62", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of starches and starch products" },
                    { new Guid("7165e0cc-82cf-4c89-8937-ffc9e0f74096"), "C.10.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("4388d2a9-7fb4-4905-93be-52507994f75e"), "C.10.7", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("70ad04a0-fa22-4248-8830-f19104b362d2"), "C.10.72", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("03344daf-9af7-4cd8-84f2-0206fc9aab83"), "C.10.73", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("01639525-8c95-4f6c-9997-239ba5dfaabb"), "C.10.8", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other food products" },
                    { new Guid("37adb5f5-291e-4346-996e-ae434efb47fa"), "C.10.81", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of sugar" },
                    { new Guid("6110f9e5-3648-4f61-9a41-aaaa64db2e5a"), "C.10.82", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("989d4dec-c7bc-48ee-9fa2-eaa05bba9d69"), "C.10.83", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing of tea and coffee" },
                    { new Guid("dae6eb98-776b-421f-8613-01561cc90ebe"), "C.10.84", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of condiments and seasonings" },
                    { new Guid("b00092b5-6a49-4047-b6ce-bae2efb1ea7f"), "C.10.85", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of prepared meals and dishes" },
                    { new Guid("d07c634a-dc0c-4595-a53d-b77dec783e11"), "C.10.86", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("7aba8cfa-2eff-4dc8-b8de-549ff2fa9ade"), "C.10.89", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other food products n.e.c." },
                    { new Guid("8702b473-df40-48dd-a4e3-01edd88b50ad"), "C.10.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of prepared animal feeds" },
                    { new Guid("c51bf6bd-9b3c-41d3-a756-7f0074be3ecb"), "C.10.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("eabc4772-39e7-4888-b4ed-72a2f575b9a1"), "C.10.71", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("fb41b8e5-f9cc-475e-9d40-800f2559ac86"), "C.10.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("f95dc102-ec39-476b-9540-5ca310055111"), "C.10.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("049f8335-a170-4283-9322-34629151827d"), "C.10.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Production of meat and poultry meat products" },
                    { new Guid("e95f591d-02af-40b4-8824-d560e9a4926c"), "B.06.10", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of crude petroleum" },
                    { new Guid("f6b49ab5-297b-40df-9cb8-d0498f469ee1"), "B.06.2", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of natural gas" },
                    { new Guid("d10b3d91-1ef4-4855-9b88-8285c50d19ce"), "B.06.20", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of natural gas" },
                    { new Guid("7bf79551-d2c7-4b8f-ac25-d19d1a49147d"), "B.07", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of metal ores" },
                    { new Guid("d9100d5e-4dd2-452a-9b62-ed84b1699435"), "B.07.1", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of iron ores" },
                    { new Guid("a0bdac40-930a-4afb-a546-afa835036058"), "B.07.10", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of iron ores" },
                    { new Guid("51b52b04-d452-4764-a799-5cbc757b66ad"), "B.07.2", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of non-ferrous metal ores" },
                    { new Guid("23aaf895-779d-4998-865f-70e45097472c"), "B.07.21", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of uranium and thorium ores" },
                    { new Guid("3b2e64e6-4c72-4a25-ba1e-811477044eb0"), "B.07.29", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of other non-ferrous metal ores" },
                    { new Guid("f99155c1-2143-4c5f-9805-9c93af0ea236"), "B.08", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Other mining and quarrying" },
                    { new Guid("f91603f6-556d-4172-a647-dcdbbecf68b4"), "B.08.1", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Quarrying of stone, sand and clay" },
                    { new Guid("ca75c923-2a9c-4184-a913-4a95f8af7789"), "B.08.11", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d7e0d9da-00b3-4e68-a89d-32873c387404"), "B.08.12", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("8432e775-4f0c-406c-96e7-50ea7d7e2331"), "B.08.9", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining and quarrying n.e.c." },
                    { new Guid("73bb2c5f-5597-4cbf-92e8-b87def3e8ea5"), "B.08.91", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("8200f7d9-9791-4a05-9150-183cd53025a2"), "B.08.92", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of peat" },
                    { new Guid("51e30ff2-c01d-419e-9520-a0283a6c4d34"), "B.08.93", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of salt" },
                    { new Guid("d70a7d71-ec9a-40d5-9e2f-df1a8168b214"), "B.08.99", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Other mining and quarrying n.e.c." },
                    { new Guid("fe4fd17f-8ac7-481c-8a60-25808c092b79"), "B.09", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Mining support service activities" },
                    { new Guid("cfca75f6-bfc0-4fab-8ee7-b297cb3dbadd"), "B.09.1", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("22b326b5-dd93-451e-8444-91b32c96e472"), "B.09.10", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("34c577dc-4f6a-44db-afe2-1d4c54cb246d"), "B.09.9", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Support activities for other mining and quarrying" },
                    { new Guid("c20446bf-0bb9-49ed-9a85-8f8bf8266425"), "B.09.90", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Support activities for other mining and quarrying" },
                    { new Guid("4523f31b-3b05-4620-84d8-102c5b485429"), "C.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of food products" },
                    { new Guid("6cd0800b-086e-4eae-a161-987a1fa5cd3f"), "C.10.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("3d8f952a-2955-4228-a9c9-c038548e0807"), "C.10.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of meat" },
                    { new Guid("ff9911f4-5cbb-4ac4-84cb-2b94e0b219c5"), "C.10.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing and preserving of poultry meat" },
                    { new Guid("4b15be9d-be7d-4a96-bccd-ad03f7884950"), "B.06", new Guid("74255faa-fad3-4543-a795-909d5a04f818"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("49411b14-fb89-4dc7-a2d5-94123f539ec9"), "F.43.2", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("6a25569f-b528-40e3-a5d2-791842fb6843"), "C.23.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of refractory products" },
                    { new Guid("cb333e25-8f30-4244-8860-ee3d833ad448"), "C.23.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("166349bf-cd22-4ae3-a92a-9c7619a442b8"), "C.30.92", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("a2374651-d740-4a33-8086-2884148fcde8"), "C.30.99", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("c277ef48-365a-4b6b-b3d4-ba896ae14a09"), "C.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of furniture" },
                    { new Guid("04b2d93d-c088-47eb-b393-76744fbf1d90"), "C.31.0", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of furniture" },
                    { new Guid("47ab806c-62c1-427f-bd81-f1907b606a01"), "C.31.01", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of office and shop furniture" },
                    { new Guid("5f94407e-a282-466d-b37b-c32fab4d0e83"), "C.31.02", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of kitchen furniture" },
                    { new Guid("32e81127-6708-400b-b570-9de54a6248c1"), "C.31.03", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of mattresses" },
                    { new Guid("0a2c4c3b-94cd-4610-8347-04764d2a623b"), "C.31.09", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other furniture" },
                    { new Guid("2a9b1bb8-af62-43ac-84bd-71765f6cd62e"), "C.32", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Other manufacturing" },
                    { new Guid("c2497e4d-7134-4604-a789-f64cc1c18c9b"), "C.32.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("58dffb25-928d-48ed-9868-e1e879fe3369"), "C.32.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Striking of coins" },
                    { new Guid("85717b9d-00ef-4a86-a3d4-ac9a31ca7f0f"), "C.32.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of jewellery and related articles" },
                    { new Guid("e4d8097d-2eab-4e85-ac70-5e01106af112"), "C.30.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of motorcycles" },
                    { new Guid("9aefc318-d4ab-4433-a28b-7f7725ff35cc"), "C.32.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("bd7594bb-d867-4e6f-9bd6-e4dbc8dbeb41"), "C.32.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of musical instruments" },
                    { new Guid("7c1d102b-6ae2-42ff-be0d-d1f739269a8b"), "C.32.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of sports goods" },
                    { new Guid("59133eae-1a72-48cd-b156-cb0f7db7bdde"), "C.32.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of sports goods" },
                    { new Guid("09aa76df-b457-44ce-a891-4239ed310d46"), "C.32.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of games and toys" },
                    { new Guid("5942e171-f3c2-4e60-9796-f286a4b4c837"), "C.32.40", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of games and toys" },
                    { new Guid("c3e14350-c056-47ef-a9a2-133f7cd0405a"), "C.32.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("dacd0f10-96ec-47ac-8af1-0f3e62ee95c4"), "C.32.50", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("35ae65af-0158-4fbd-8f90-fb00617bc53f"), "C.32.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacturing n.e.c." },
                    { new Guid("01cdbc94-11d6-4717-aa1a-783828ea9330"), "C.32.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("77b02837-e41f-4cb2-8c49-63e64e1f4d05"), "C.32.99", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Other manufacturing n.e.c." },
                    { new Guid("9412474f-0338-4c14-aa48-b9543bda0e10"), "C.33", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair and installation of machinery and equipment" },
                    { new Guid("ee702f3a-4162-4091-abc8-79f3d6b4e03b"), "C.33.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("937bef4e-f881-4ff3-a5de-113881ab1ccd"), "C.32.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of musical instruments" },
                    { new Guid("86ec5f81-073f-47d8-acd1-e40574cffc1e"), "C.30.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("572fe0e2-ae68-4e87-839e-b2861e1539b7"), "C.30.40", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of military fighting vehicles" },
                    { new Guid("1106e590-5c46-43d3-b9a0-3b2ba3fd4387"), "C.30.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of military fighting vehicles" },
                    { new Guid("a8a09839-de19-4e8c-a47f-31441f865315"), "C.28.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("b12c1573-0586-4c84-ae5c-a742b18a8ea4"), "C.28.41", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of metal forming machinery" },
                    { new Guid("dff93631-62b2-4a21-81f7-7c0a63acca8e"), "C.28.49", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other machine tools" },
                    { new Guid("357517ed-1b10-4cf5-b27a-1afbb2bda096"), "C.28.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other special-purpose machinery" },
                    { new Guid("afa88735-4577-4515-a6bb-0bf2c31b6527"), "C.28.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of machinery for metallurgy" },
                    { new Guid("9786fa32-0be3-4966-8856-a068bbb41ac2"), "C.28.92", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("7e45c1a9-521a-4cd7-934b-c12efd4b133e"), "C.28.93", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("146a1170-5e6c-4777-baa5-3bc8a63b0631"), "C.28.94", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("8745dd31-8f4a-4d52-9333-3acd21ec4aab"), "C.28.95", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("fd1bd4c5-71f6-4c19-9ab4-789cc9c72481"), "C.28.96", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("bbaebe08-8f59-4b8b-a765-6c567dd6fb44"), "C.28.99", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("df201562-a219-43e0-a399-bcd6bf1b8281"), "C.29", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("2a1445c3-ba13-4da9-9cb8-d226279a2b6d"), "C.29.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of motor vehicles" },
                    { new Guid("84c8b5af-90ac-4b12-abcc-dc42d663bb66"), "C.29.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of motor vehicles" },
                    { new Guid("4a0a3446-9407-452e-83aa-4da0f5769362"), "C.29.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("40c9c5bc-fc0e-4b81-bc85-23a95fa09381"), "C.29.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("8c79d1f0-6798-4e59-addc-71d507da8cf4"), "C.29.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("7d2ec066-5f34-435c-8662-5d0541a09a7e"), "C.29.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("f9f10931-742f-4d39-9946-3736b392c041"), "C.29.32", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("6acf9e61-48ac-45f4-8e96-e6f22bf2963a"), "C.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other transport equipment" },
                    { new Guid("67852b6d-81a5-4e3e-b60a-819f94bda94a"), "C.30.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Building of ships and boats" },
                    { new Guid("d695bd5b-f557-478a-a0cd-3ef07d9d0c39"), "C.30.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Building of ships and floating structures" },
                    { new Guid("b1729d2e-1573-44a3-9a98-fa96d66663ac"), "C.30.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Building of pleasure and sporting boats" },
                    { new Guid("5f27b5f4-5320-4e4d-822d-1ff78c1fd719"), "C.30.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("ba7069ae-008b-48ef-9f9b-df7e13ce907b"), "C.30.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("6bb7cf8a-7311-40b6-a154-9c5903ef4180"), "C.30.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("7d41b68d-abb9-4de1-a007-19fe94c692e1"), "C.30.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("1f7622a8-775e-4c8e-8d6a-3001ffab2095"), "C.33.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair of fabricated metal products" },
                    { new Guid("07cec7cc-ef8d-4626-81e5-8b74d1ae8132"), "C.28.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("2ac190b3-e0d7-4fcc-aab2-585878a4da6d"), "C.33.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair of machinery" },
                    { new Guid("bd11ba82-9324-4ee0-90e0-4117e47a4198"), "C.33.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair of electrical equipment" },
                    { new Guid("11dba6e9-a18b-4124-a363-101ecf268b80"), "E.38.3", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Materials recovery" },
                    { new Guid("916f2eb6-e771-4ccd-bf1d-85b05e11356c"), "E.38.31", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Dismantling of wrecks" },
                    { new Guid("ed580bfe-4221-4526-9350-a4afba68f9d7"), "E.38.32", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Recovery of sorted materials" },
                    { new Guid("a7533f48-9bb1-4f1a-b0d0-6bb5da686d43"), "E.39", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1796736d-2d24-489b-951a-f03b305e1a2a"), "E.39.0", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Remediation activities and other waste management services" },
                    { new Guid("f37675dc-c315-4858-b3db-3360076836bd"), "E.39.00", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Remediation activities and other waste management services" },
                    { new Guid("98d5c9f4-20f5-42ae-9a2d-aa98abc8d39f"), "F.41", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of buildings" },
                    { new Guid("2ae0cecc-8cb3-4dfa-9b7d-d9b3f598a291"), "F.41.1", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Development of building projects" },
                    { new Guid("0894a13c-9187-485f-ba75-f38f5a15cc05"), "F.41.10", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Development of building projects" },
                    { new Guid("4d88e746-24b5-4410-a67f-0021ff3883e0"), "F.41.2", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of residential and non-residential buildings" },
                    { new Guid("75ad60d5-0e03-4be0-a9d2-b3eadaf8f332"), "F.41.20", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of residential and non-residential buildings" },
                    { new Guid("8ad73dbf-0d48-4859-8c2e-82edb3d8f261"), "F.42", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Civil engineering" },
                    { new Guid("fd6922e3-359e-4acc-b151-3d66855a5fbd"), "E.38.22", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Treatment and disposal of hazardous waste" },
                    { new Guid("5ea4a9e0-5eb8-49e5-875e-4cf5ab8bbc7f"), "F.42.1", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of roads and railways" },
                    { new Guid("6a143df6-6f93-45ef-a6ee-0bc62c19f68b"), "F.42.12", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of railways and underground railways" },
                    { new Guid("7b451e8b-9548-4cbc-a88c-e3048ef74531"), "F.42.13", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of bridges and tunnels" },
                    { new Guid("bde54f16-a823-4f5d-82d0-b46527d0d82c"), "F.42.2", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of utility projects" },
                    { new Guid("6a5a9e67-e6ec-4358-955e-1930fed4cab4"), "F.42.21", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of utility projects for fluids" },
                    { new Guid("929477e7-3f1c-4ec9-9dfa-89ae4d9c3c71"), "F.42.22", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("6c640a00-b251-41e6-a0bd-543bf0e6ee6c"), "F.42.9", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of other civil engineering projects" },
                    { new Guid("688a4bb8-4e3b-45b2-9079-859a093f7cdb"), "F.42.91", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of water projects" },
                    { new Guid("78fcfca5-95e3-4a5a-8373-40f6ffe7e736"), "F.42.99", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("76b2bbc1-c36d-491d-bff1-3f5323d3e512"), "F.43", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Specialised construction activities" },
                    { new Guid("55a23564-659a-48e7-b571-d0b0925225b6"), "F.43.1", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Demolition and site preparation" },
                    { new Guid("c343a342-7fd4-4d29-b1b5-e310c96378e2"), "F.43.11", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Demolition" },
                    { new Guid("d08a7293-d0fb-4c64-998e-fda4e7e6326c"), "F.43.12", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Site preparation" },
                    { new Guid("2637b32a-9983-4137-918f-3aa8182611ab"), "F.42.11", new Guid("f4e4253f-ec19-4211-86b1-bcc0b9e7a29c"), "Construction of roads and motorways" },
                    { new Guid("70c5a211-71e6-4700-8eba-cb12b8df21b9"), "E.38.21", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("44f6e92f-2e1e-426e-924f-2ac38a06eea2"), "E.38.2", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Waste treatment and disposal" },
                    { new Guid("cab60260-0d80-4edc-8051-5e3d1ee283d1"), "E.38.12", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Collection of hazardous waste" },
                    { new Guid("f16e8a3f-8e00-41b0-9aeb-03328c6d31dd"), "C.33.15", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair and maintenance of ships and boats" },
                    { new Guid("8ea5cacc-9d76-45f1-8d22-189a54a0b6ad"), "C.33.16", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("e1569923-eea6-4ed4-9287-365c864c8b2d"), "C.33.17", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair and maintenance of other transport equipment" },
                    { new Guid("1f292ea2-5e80-481f-acd2-2fab12576df8"), "C.33.19", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair of other equipment" },
                    { new Guid("6e3b833b-1552-49b3-b074-1d1ecfa0f2bb"), "C.33.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Installation of industrial machinery and equipment" },
                    { new Guid("0ace5029-debe-43e5-a824-e9db9e76e80d"), "C.33.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Installation of industrial machinery and equipment" },
                    { new Guid("dcbb867a-8fca-449d-a1ff-979c8237f4b0"), "D.35", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("c574a392-87ea-4cb5-83ba-c7a1d798e66a"), "D.35.1", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Electric power generation, transmission and distribution" },
                    { new Guid("06e021ed-f6c3-441f-9823-358eb8bca0f8"), "D.35.11", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Production of electricity" },
                    { new Guid("ec88b39c-8b8e-4ea3-a003-a5535d396303"), "D.35.12", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Transmission of electricity" },
                    { new Guid("2d8e4536-1deb-48a5-8711-4cb8f78eea17"), "D.35.13", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Distribution of electricity" },
                    { new Guid("71ec3044-afae-4e79-9d0c-803665e27670"), "D.35.14", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Trade of electricity" },
                    { new Guid("dfc310b9-30b3-438b-9dc9-b469da8f2b59"), "D.35.2", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("15872abc-f24c-44d3-a261-8e1fdfbacabb"), "D.35.21", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Manufacture of gas" },
                    { new Guid("8f0d6311-5790-4651-a8cd-b0943f8e118e"), "D.35.22", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Distribution of gaseous fuels through mains" },
                    { new Guid("e29758f3-5086-457b-958b-e97e9dadb546"), "D.35.23", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5ab3f89f-5375-453c-aa26-152654a474a5"), "D.35.3", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Steam and air conditioning supply" },
                    { new Guid("c8c21349-f92a-4320-95eb-1510fc66fd54"), "D.35.30", new Guid("e357c16d-bc7c-48f3-a21b-f48023823d8f"), "Steam and air conditioning supply" },
                    { new Guid("8816103a-1fa1-43b6-a2a3-fdce6490bf05"), "E.36", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Water collection, treatment and supply" },
                    { new Guid("d23636ec-c3ff-4c2d-b88d-3a757450e4c3"), "E.36.0", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Water collection, treatment and supply" },
                    { new Guid("6359c34d-e6d9-4750-8d02-66f672ceaae3"), "E.36.00", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Water collection, treatment and supply" },
                    { new Guid("9cdfe354-aba0-4940-a40b-2b382f6865b3"), "E.37", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Sewerage" },
                    { new Guid("fedad90e-e024-41b8-a4cf-6944cf1b408b"), "E.37.0", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Sewerage" },
                    { new Guid("5932456b-9150-4eda-967d-e2d8754d627d"), "E.37.00", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Sewerage" },
                    { new Guid("5ed57eca-0f25-42d0-9781-a8420bc56408"), "E.38", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("e2831e9e-9e7a-4a45-bc8a-ca0570639b3c"), "E.38.1", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Waste collection" },
                    { new Guid("ebf08a4f-ed85-4803-8c45-5b115056d381"), "E.38.11", new Guid("b724c1e1-623a-4da4-9228-1ec3e2f81240"), "Collection of non-hazardous waste" },
                    { new Guid("5a9c2988-007a-4985-8f18-6417b5f6a982"), "C.33.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Repair of electronic and optical equipment" },
                    { new Guid("bf743e73-3736-4abd-809b-077ed58b8923"), "C.23.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of clay building materials" },
                    { new Guid("4451cf09-0363-4bac-b757-746ded0df757"), "C.28.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("7324d396-a0c8-4ea4-8aea-3a25a8c1d9f5"), "C.28.25", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("ade9e432-c61e-45bb-a6c3-01e0ba6ff174"), "C.24.34", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Cold drawing of wire" },
                    { new Guid("c0cc78a5-f20e-4b54-b8eb-3df4fcf8c2fe"), "C.24.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("5bf78753-3d35-435a-aa85-fe680eba8491"), "C.24.41", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Precious metals production" },
                    { new Guid("33db8d5b-232a-4392-9502-a89eefea7376"), "C.24.42", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Aluminium production" },
                    { new Guid("9b219c88-f3e7-4a2c-95b9-f10fb853f47a"), "C.24.43", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Lead, zinc and tin production" },
                    { new Guid("e2776d70-b0d2-43a0-8ea9-f9a6dd16e660"), "C.24.44", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Copper production" },
                    { new Guid("2a43274d-ebc2-47af-b202-c3aa5e02a434"), "C.24.45", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Other non-ferrous metal production" },
                    { new Guid("e66b8ed5-d8a8-44a4-a6cc-b2e7fcea6e50"), "C.24.46", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Processing of nuclear fuel" },
                    { new Guid("f2a6084a-c6b3-48d7-8112-82ebf7ccc988"), "C.24.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Casting of metals" },
                    { new Guid("44ce54ac-9985-4986-997e-6dd1e0bd3d2a"), "C.24.51", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Casting of iron" },
                    { new Guid("880f514d-5c4f-4321-937f-1559287ec641"), "C.24.52", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Casting of steel" },
                    { new Guid("83b1ddcb-2a52-4a6f-a823-59e5e9e9d1a4"), "C.24.53", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Casting of light metals" },
                    { new Guid("794f988c-e512-4766-b4d9-cc37bf591f20"), "C.24.33", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Cold forming or folding" },
                    { new Guid("b5378556-f909-4fe2-9055-8b6f8e2c8701"), "C.24.54", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Casting of other non-ferrous metals" },
                    { new Guid("f5ad224c-accd-4457-8321-1412d4b2baee"), "C.25.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of structural metal products" },
                    { new Guid("81f86ecc-a2a7-43d0-9595-ae4c82282b2a"), "C.25.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("eca31b2e-40ae-427f-8ce2-1d0d65ac1bf4"), "C.25.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of doors and windows of metal" },
                    { new Guid("7a3985ac-40cb-4638-b780-d86784e45ee2"), "C.25.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("4086f92a-5b72-4297-a323-4383de4c540b"), "C.25.21", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("df67c85a-8c5e-4fdc-88b9-aa95b53e1302"), "C.25.29", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("a051df9c-bfb4-454d-8114-36ed5d424c00"), "C.25.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("58add185-8644-4cd2-ae3c-4843bf56c9fd"), "C.25.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("215d9922-fce0-4cf1-8292-ba7e96e72fad"), "C.25.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of weapons and ammunition" },
                    { new Guid("4e937504-9f60-4474-bb6c-c62690eba245"), "C.25.40", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of weapons and ammunition" },
                    { new Guid("2ab88dbe-f884-4b1d-8e61-eb7c23614b37"), "C.25.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("8e939350-043c-4041-8f0d-c7cb753f163a"), "C.25.50", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("3aef3d16-96ca-4b12-a4b1-8a070860d13d"), "C.25", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("14757d61-8afa-4918-82df-c3ccc9c8507d"), "C.24.32", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Cold rolling of narrow strip" },
                    { new Guid("1bd62e93-0774-4666-9bf4-ece48ed64274"), "C.24.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Cold drawing of bars" },
                    { new Guid("8ffcbdd5-0753-4377-9608-c9f28dbc231b"), "C.24.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other products of first processing of steel" },
                    { new Guid("9e95c207-d5fe-44a4-89a0-2050e3e5c6aa"), "C.23.32", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("b7712e86-09df-4ce7-bc32-ea75f437e89a"), "C.23.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("8a4623ae-429c-49c2-b53b-663de8cb6c3e"), "C.23.41", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("e810d5a5-fcfc-407c-aa63-42d129b176aa"), "C.23.42", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("f3a7ddf9-d9fb-448a-af55-f8edb47cd279"), "C.23.43", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("de348ec4-ec10-49ee-a22d-2b285f68c0f8"), "C.23.44", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other technical ceramic products" },
                    { new Guid("90e0ba83-2537-4c61-9bc8-4f4472a8cbc1"), "C.23.49", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other ceramic products" },
                    { new Guid("9cc219a5-e0cf-42b1-939b-c35920fa1b12"), "C.23.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cement, lime and plaster" },
                    { new Guid("e37fa8a4-bfa9-4db1-83c2-1a7f6301f359"), "C.23.51", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cement" },
                    { new Guid("56433c1e-1f23-417e-b9dc-9eef01514c3e"), "C.23.52", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of lime and plaster" },
                    { new Guid("bfc1e379-77a3-4083-af4e-c459ca0e5de7"), "C.23.6", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("df77e57e-fd32-4ece-aff3-3eabecb71b08"), "C.23.61", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("616f0891-7415-406e-83ff-04924382b872"), "C.23.62", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("a9b437d8-ac78-42a4-bce0-23d453e26a16"), "C.23.63", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ready-mixed concrete" },
                    { new Guid("1f9c2edb-5e42-463c-a1d1-cc80a33c0862"), "C.23.64", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of mortars" },
                    { new Guid("9f3ceb74-c928-4e11-b899-9426a36e5d61"), "C.23.65", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fibre cement" },
                    { new Guid("bacc41ba-7c6c-4f1a-99c9-dc3f85cfb70c"), "C.23.69", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("be7158fa-c089-4432-b2a6-0396533a424a"), "C.23.7", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Cutting, shaping and finishing of stone" },
                    { new Guid("6e7c5c0b-ea46-4dbf-933f-18de4c7fdbdf"), "C.23.70", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Cutting, shaping and finishing of stone" },
                    { new Guid("13041979-19ab-4cf7-88e9-8c5ef87b3eda"), "C.23.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("2ee92073-1ffa-40eb-a31e-d6afe1c522e8"), "C.23.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Production of abrasive products" },
                    { new Guid("283d7c38-3bdf-4594-8d03-b78d33b69385"), "C.23.99", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("574da0de-96c6-4779-8f68-33c534aed5eb"), "C.24", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic metals" },
                    { new Guid("f79c785f-d4fe-4d8b-a00a-ad0e947fb253"), "C.24.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("9a3bf5c7-5922-4271-998d-94bf50d8f3ec"), "C.24.10", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("a2da5cd8-2e93-4351-9fd8-de026500c17c"), "C.24.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("e46ab8a1-dba1-4c50-a2ff-ed66c54968ef"), "C.24.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("254ab82a-34e8-4596-ad52-10190dc0441d"), "C.25.6", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Treatment and coating of metals; machining" },
                    { new Guid("9b551ce9-19fd-4d89-834d-bf5155a78902"), "C.28.29", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("69604856-1562-430a-8995-a18134571739"), "C.25.61", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Treatment and coating of metals" },
                    { new Guid("ddf0e81b-52e1-4bd2-bcaf-1b2acf53c7c9"), "C.25.7", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("b87e23ba-b305-48a3-ad67-7607f85aca4c"), "C.27.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("d84a9c81-67b0-4dee-98a7-64b21f51436d"), "C.27.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of batteries and accumulators" },
                    { new Guid("189fecbb-a688-4135-9e30-4a81d6e3a11c"), "C.27.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of batteries and accumulators" },
                    { new Guid("68693ef9-f9c5-4fc8-bf96-7ab22468c188"), "C.27.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wiring and wiring devices" },
                    { new Guid("f0648bbe-7f59-4612-9b2c-84d0295a0ef9"), "C.27.31", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fibre optic cables" },
                    { new Guid("3363d62b-1796-4f22-a888-3be4bb7f5c67"), "C.27.32", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("2ade0c0c-3b2f-444c-858a-36ecfa7c0f38"), "C.27.33", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wiring devices" },
                    { new Guid("8c4a0479-dadc-4eca-9714-8e9aec561dd3"), "C.27.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("38ba69e3-d8f8-4a4c-83e8-fa68e3569c2e"), "C.27.40", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electric lighting equipment" },
                    { new Guid("a0274ed6-2dda-4cd2-9c79-b9bc9cd4a23a"), "C.27.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of domestic appliances" },
                    { new Guid("eecc3480-79cd-477b-bbce-4ad7792ff01f"), "C.27.51", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electric domestic appliances" },
                    { new Guid("505dc829-7bc4-4f01-a839-cb26aba4469d"), "C.27.52", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("07473a56-edaa-4bb2-86f7-38b303beb5e3"), "C.27.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("44e3dc30-08b3-4328-a26e-7b320ba3b862"), "C.27.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other electrical equipment" },
                    { new Guid("573b6747-2add-444b-b6ce-b57c1741221d"), "C.28", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("0a356e51-ac27-44ef-b0fe-cb6574c8eb97"), "C.28.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of general-purpose machinery" },
                    { new Guid("c441a669-ce5e-4606-8aba-b05963f22b9c"), "C.28.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("610a0608-238f-4132-b79a-e757db3e3610"), "C.28.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fluid power equipment" },
                    { new Guid("7c2b06f4-31c5-4946-98de-6201f24a0385"), "C.28.13", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other pumps and compressors" },
                    { new Guid("4dc2b66b-30d4-4a17-9246-2eb8f1fb554c"), "C.28.14", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other taps and valves" },
                    { new Guid("804901ea-a73b-4208-b6a3-3ce7b44adc20"), "C.28.15", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("6c1296f0-f068-4196-801b-1078f500b151"), "C.28.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other general-purpose machinery" },
                    { new Guid("b350b741-fe05-44e7-ad30-78dad0f96740"), "C.28.21", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("edceb484-3f78-4298-826b-6e182cc12c77"), "C.28.22", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of lifting and handling equipment" },
                    { new Guid("85f0b647-824d-4630-9723-48ceb091c916"), "C.28.23", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("264253b7-f80f-443f-82d1-426563ecdceb"), "C.28.24", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of power-driven hand tools" },
                    { new Guid("16923c51-142f-48fa-8285-d7eace899864"), "C.27.90", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other electrical equipment" },
                    { new Guid("c12e3ee6-5b7f-4fb8-b536-32db2366da9b"), "C.27.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("81a546fa-b109-4e1d-be04-8111f3835128"), "C.27", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electrical equipment" },
                    { new Guid("1b5f6860-b4cc-4c73-955e-28b41c058943"), "C.26.80", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of magnetic and optical media" },
                    { new Guid("dd1c574f-9bf0-4ffd-9f11-3c75efc561c8"), "C.25.71", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of cutlery" },
                    { new Guid("061d49f2-0d6f-4441-917d-cd8a0fb3d867"), "C.25.72", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of locks and hinges" },
                    { new Guid("5d6befb5-102a-4625-9283-b15a8b1171bd"), "C.25.73", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of tools" },
                    { new Guid("a5963a88-8be5-4550-96fa-a3156973981c"), "C.25.9", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other fabricated metal products" },
                    { new Guid("c25e681b-ddcb-4875-9d4e-fb8774c309a4"), "C.25.91", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of steel drums and similar containers" },
                    { new Guid("3ea1af95-d72f-47e9-a7d8-d406beff649c"), "C.25.92", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of light metal packaging" },
                    { new Guid("4106064d-339e-4be6-8c9c-799e245800df"), "C.25.93", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of wire products, chain and springs" },
                    { new Guid("e1591892-8486-4492-914c-7400255149a4"), "C.25.94", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("b03a589f-c46d-4e68-abb3-dbd2ba793527"), "C.25.99", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("e847fef4-323c-4cb9-bcf4-30f3c85586d7"), "C.26", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("341c7a0f-90e4-4a01-97b6-c7f81013d10c"), "C.26.1", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electronic components and boards" },
                    { new Guid("17d008e0-fc38-4afe-927a-aff24decb1e7"), "C.26.11", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of electronic components" },
                    { new Guid("5cddc75e-d965-46b1-b840-70e2253d8811"), "C.26.12", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of loaded electronic boards" },
                    { new Guid("93b74c58-7557-436e-b959-6851159964cc"), "C.26.2", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("506e4f86-4675-497b-8872-c01698928fca"), "C.26.20", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("79ad11b2-5fc1-408e-a249-5e166d1cd0c9"), "C.26.3", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of communication equipment" },
                    { new Guid("e703b148-2353-4796-9038-6dc0e40bd41b"), "C.26.30", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of communication equipment" },
                    { new Guid("9f4ba2f1-e9d7-4d64-b02a-17ddb69e35df"), "C.26.4", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of consumer electronics" },
                    { new Guid("b0ce868e-bdf2-4c02-8304-817e3dcfb8ba"), "C.26.40", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of consumer electronics" },
                    { new Guid("62a2f557-8b8b-49a7-aba2-d9e726d57bc6"), "C.26.5", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0be9cafb-7c0a-41c9-9933-4dbbc40fb7f4"), "C.26.51", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("81d1852b-a961-4c15-8492-a0cc8afc8dce"), "C.26.52", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of watches and clocks" },
                    { new Guid("2adb940d-eea7-42db-8b3f-3088e00281a1"), "C.26.6", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("71735716-0a65-480b-b610-e7632d9e1798"), "C.26.60", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("307f63f5-7ffa-432f-acc5-daba7b2f5240"), "C.26.7", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("f0556a72-0536-46c7-8694-d1f03fb465fb"), "C.26.70", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("0c20f97f-8e59-4c59-b7e9-e826c5304076"), "C.26.8", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Manufacture of magnetic and optical media" },
                    { new Guid("70b184e8-29a1-4222-a238-f2c530f8ebc2"), "C.25.62", new Guid("1b5039de-82eb-433d-9e58-6d7fced93971"), "Machining" },
                    { new Guid("e12db117-e9fc-4118-86de-213057f3d545"), "U.99.00", new Guid("5e126224-7239-4cd7-aa2d-c55ba0259318"), "Activities of extraterritorial organisations and bodies" }
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
