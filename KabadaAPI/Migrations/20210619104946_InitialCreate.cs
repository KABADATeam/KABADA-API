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
                    { new Guid("7cb10808-2ae7-4480-b437-fe055efa831e"), "AT", "Austria" },
                    { new Guid("20022a0f-88e1-40a7-8ab3-92535629cff1"), "LU", "Luxembourg" },
                    { new Guid("8f3637a4-6e7f-4b1a-b176-cfb66b4a696f"), "MT", "Malta" },
                    { new Guid("88a0e3bf-faf0-4fc6-ac5f-9053f3639a1b"), "MK", "North Macedonia" },
                    { new Guid("fab67181-7af5-40f4-afca-7f4577cd46fa"), "NO", "Norway" },
                    { new Guid("603168fd-8fa1-4be4-9a71-60dc7c1e80a8"), "PL", "Poland" },
                    { new Guid("320da358-0df7-4e98-801b-2378598e440a"), "PT", "Portugal" },
                    { new Guid("62a56d25-41ae-405e-bc05-d7703deb7961"), "RO", "Romania" },
                    { new Guid("ada288ce-512c-481f-b22b-7bc5aa2bb039"), "RS", "Serbia" },
                    { new Guid("a53e1222-3ce3-4fc8-93ce-1ef0340e4b97"), "SK", "Slovakia" },
                    { new Guid("b5ca45ee-48cc-4603-88bf-68c5917e7213"), "SI", "Slovenia" },
                    { new Guid("7798abcc-70a6-46e7-9b15-6a10733f805a"), "ES", "Spain" },
                    { new Guid("af583fc0-95a7-451e-81bf-15254ab4a4a0"), "SE", "Sweden" },
                    { new Guid("aa183468-e16c-4fe2-93d2-e4b36893829d"), "CH", "Switzerland" },
                    { new Guid("d5cd04f5-5590-44eb-9ec8-e34d2c63af2c"), "TR", "Turkey" },
                    { new Guid("a305b475-907f-4d6f-b189-b113d19e9506"), "UK", "United Kingdom" },
                    { new Guid("ae553075-b13b-4a99-9e59-6ae138be1d45"), "LT", "Lithuania" },
                    { new Guid("df5c967f-6a26-4e91-8f19-36960d52db9a"), "LI", "Liechtenstein" },
                    { new Guid("0d72a973-44af-455c-b420-c1cc5009581f"), "NL", "Netherlands" },
                    { new Guid("3bc30583-e10b-4430-b411-4f6b44b5764d"), "IT", "Italy" },
                    { new Guid("ae6171cc-04eb-42b1-a522-50252f82042a"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("43051aa7-8cbe-4fd4-8aa9-74b015a5ae3e"), "BE", "Belgium" },
                    { new Guid("4e392b9d-18d9-4cb9-9102-729a03d837d6"), "BG", "Bulgaria" },
                    { new Guid("2b87bc23-e527-4158-9056-1d654e40ab62"), "LV", "Latvia" },
                    { new Guid("3cc9e570-ca98-40b5-b1e7-ef93770b0b3c"), "CY", "Cyprus" },
                    { new Guid("ef784333-4549-4d4d-aaa6-41a5328947d3"), "CZ", "Czechia" },
                    { new Guid("d95c634f-5a1e-43a7-91a2-01f920df04f0"), "DK", "Denmark" },
                    { new Guid("080dea09-9c99-4879-8bb0-9b046ed55714"), "EE", "Estonia" },
                    { new Guid("c6dd7b9f-c650-4749-b2ae-ef36e35c0f02"), "HR", "Croatia" },
                    { new Guid("a282d129-c5c7-48b3-9248-fcdfcd76552e"), "FR", "France" },
                    { new Guid("02065c90-0881-4fcc-b649-bc9f5bf356f1"), "DE", "Germany" },
                    { new Guid("961900e2-3fe8-4dbb-a47c-95cffbaf668d"), "EL", "Greece" },
                    { new Guid("64791482-da69-462f-b4d4-ab37a8c16f27"), "HU", "Hungary" },
                    { new Guid("0f9085d4-7841-415f-bc42-2820b6623598"), "IS", "Iceland" },
                    { new Guid("6b771d40-163d-4bd3-95d2-f1e2413076ad"), "IE", "Ireland" },
                    { new Guid("6d41c867-5026-4038-88f8-3c640b9bab92"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "P", "EN", "Education" },
                    { new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("4172a573-6423-473e-9984-825cb545902b"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("bfd64441-c86b-4b14-9190-d01e19c7c164"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "L", "EN", "Real estate activities" },
                    { new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("70c63896-98b2-4074-858e-fd431396be24"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "J", "EN", "Information and communication" },
                    { new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "C", "EN", "Manufacturing" },
                    { new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "B", "EN", "Mining and quarrying" },
                    { new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "F", "EN", "Construction" },
                    { new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "H", "EN", "Transporting and storage" },
                    { new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("537431bd-3607-410f-bea9-42e771f50c2f"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("56c5d7cc-0c89-45d8-a11b-f0c4fe1f6eae"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("c0c65402-ae57-4be2-8af6-2f3d7128503d"), (short)1, "Ownership type" },
                    { new Guid("cd9a0a1c-91d4-4ed9-b9b5-7d8fde88b228"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4af02279-6d57-4629-a25a-9a6f503a6eba"), (short)2, "Frequency" },
                    { new Guid("2a6a9c46-5d9d-4385-9c86-035bea111da7"), (short)6, null, new Guid("04fcec30-4258-4ef4-a32b-1dac87e11a44"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("587ce329-9909-4653-b0d7-124dfe277d4e"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("4af02279-6d57-4629-a25a-9a6f503a6eba"), (short)1, "Ownership type" },
                    { new Guid("4af02279-6d57-4629-a25a-9a6f503a6eba"), (short)6, null, new Guid("04fcec30-4258-4ef4-a32b-1dac87e11a44"), (short)2, "Administrative" },
                    { new Guid("721223aa-80cd-40c9-a528-14be36f96b13"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("c0c65402-ae57-4be2-8af6-2f3d7128503d"), (short)2, "Frequency" },
                    { new Guid("c0c65402-ae57-4be2-8af6-2f3d7128503d"), (short)6, null, new Guid("04fcec30-4258-4ef4-a32b-1dac87e11a44"), (short)1, "Specialists & Know-how" },
                    { new Guid("58b3d675-ed7d-4f33-8855-d624cbd39915"), (short)6, null, new Guid("273acaec-29d9-4737-b204-13fe478455f9"), (short)1, "Brands" },
                    { new Guid("c7a1fc8c-03be-4aa3-8be6-9c32dc715818"), (short)6, null, new Guid("273acaec-29d9-4737-b204-13fe478455f9"), (short)4, "Other" },
                    { new Guid("8a58c46a-0698-4305-a094-921fe1902e77"), (short)6, null, new Guid("273acaec-29d9-4737-b204-13fe478455f9"), (short)3, "Software" },
                    { new Guid("8173b6ad-c4a0-4bfe-9685-9a2b42edc274"), (short)6, null, new Guid("273acaec-29d9-4737-b204-13fe478455f9"), (short)2, "Licenses" },
                    { new Guid("77259b57-9307-4e6a-bee5-b2f271256640"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("2a6a9c46-5d9d-4385-9c86-035bea111da7"), (short)1, "Ownership type" },
                    { new Guid("273acaec-29d9-4737-b204-13fe478455f9"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("1ecbde64-6029-46f7-bb30-6337bb88ab8f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ae29905d-c91b-4cea-9075-fce51c249114"), (short)2, "Frequency" },
                    { new Guid("f45e7585-2c8c-4d44-b0e7-13b789237d89"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ae29905d-c91b-4cea-9075-fce51c249114"), (short)1, "Ownership type" },
                    { new Guid("ae29905d-c91b-4cea-9075-fce51c249114"), (short)6, null, new Guid("4c68fe49-77fc-4142-b8d8-6ba371fd8472"), (short)5, "Other" },
                    { new Guid("04fcec30-4258-4ef4-a32b-1dac87e11a44"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("6be0c540-4c1e-4928-bb4b-5f989ec065e0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("2a6a9c46-5d9d-4385-9c86-035bea111da7"), (short)2, "Frequency" },
                    { new Guid("da75ffda-ddca-4a34-8758-899ca387e5a3"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("2e71ba8f-d259-42ac-baf9-78f916dc1e4a"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("01980e94-e802-466f-9dc8-889751a4b406"), (short)1, "Ownership type" },
                    { new Guid("abb416c8-8470-4e0b-ba28-ec0dd68621ce"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("913fe3c7-495b-40d4-a9eb-04442dd3fe04"), (short)1, "Ownership type" },
                    { new Guid("d2289ca2-b25c-4308-b022-79ec919171b5"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("e90bfaf0-e93b-4761-9ebb-e712a213a1b2"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("41d6a7fa-9716-4eb3-a096-2a27b0b3717a"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("e5f32d17-6058-4fa8-b5c6-3f52ebf96aa8"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("955c5e6e-41d3-47a9-8fbf-035ec2d25d20"), (short)13, null, null, (short)1, "Associations" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("4b6bf94e-3e16-40e0-8de9-df017a821ca2"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("442e063b-55db-41e4-a89d-6b5b9c35cf5c"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("bf173067-9c2e-4cd4-9a2a-9d0c22409150"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("7c9243f9-60ae-4284-9055-9430b903603f"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("226f5ea3-2038-4236-a297-18db489a3f4a"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("3982b37b-dd25-4014-9e35-6a3c4bae1e20"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("9bc85756-5894-4f65-84c6-16cc3243bbe1"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("61995b00-7d70-45a5-b1b0-359eed4f72a9"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("105d8728-b3b6-46e9-aaf8-ec54fca35f30"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("5abc1795-4132-472b-a667-86fec81321b7"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("4e60d6e2-76fa-454e-830f-7d58b47a4b0f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("01980e94-e802-466f-9dc8-889751a4b406"), (short)2, "Frequency" },
                    { new Guid("01980e94-e802-466f-9dc8-889751a4b406"), (short)6, null, new Guid("04fcec30-4258-4ef4-a32b-1dac87e11a44"), (short)4, "Other" },
                    { new Guid("913fe3c7-495b-40d4-a9eb-04442dd3fe04"), (short)6, null, new Guid("4c68fe49-77fc-4142-b8d8-6ba371fd8472"), (short)4, "Raw materials" },
                    { new Guid("28472fce-c097-4139-a041-59df909c310a"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("238f8d4e-a843-4035-90d3-f3c55bbdd5f8"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f03a9fc1-2993-4931-95c6-134f1ec637c0"), (short)1, "Ownership type" },
                    { new Guid("a67d0857-99d0-4fcf-8724-63e32d362d55"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("fb580ff6-6a0e-4376-8fec-f26d066b96c0"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("7c12bdaa-7408-42fa-bb0d-fa59eb84330b"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("3b93ec71-0da8-4fe1-81ae-c06068d781d1"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("55f48a3d-c017-489b-b816-2a8f5db986ee"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("7c1386a1-8c8b-492c-899e-3790fa39fdf2"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("4c7a881b-4f25-454c-b3a4-585c5e5680af"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("513a6f63-f97e-4ab3-9edd-8ace87398b36"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("8bfef051-8734-4b06-bcfa-70f9273b07b9"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("701eca1c-45ab-442f-9b43-34e2c60f8979"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("5c63934e-a0d9-491f-9962-c19fabb199ef"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("0a08bb29-2949-49f3-bd93-89647567072a"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("74920865-7ef9-47fd-8707-346f5f6b0a84"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("f5343c05-7644-47bb-82b2-8d8fd9fc3fb0"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("be4e9789-f702-4105-867f-48080eeea562"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("4fee4496-ec12-4178-991c-e3dc7ef27ff2"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("43561aa5-2031-48bd-a559-76be04b5fa81"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("4d4445e8-1c86-4d4d-ae95-b73b895438e9"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f03a9fc1-2993-4931-95c6-134f1ec637c0"), (short)2, "Frequency" },
                    { new Guid("f37edf34-a77b-4523-82f6-c8f5d4708c84"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("a86a0fbf-f06d-4caa-b3c6-b3207a6963c4"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("f03a9fc1-2993-4931-95c6-134f1ec637c0"), (short)6, null, new Guid("4c68fe49-77fc-4142-b8d8-6ba371fd8472"), (short)3, "Transport" },
                    { new Guid("326ffe2d-e70f-4eac-b10e-a6d64e27f492"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("a3878238-fb6e-4a10-8d5f-a161bee11d2f"), (short)2, "Frequency" },
                    { new Guid("37975fe0-2a4b-4bec-8b2f-89c374314f3d"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("a3878238-fb6e-4a10-8d5f-a161bee11d2f"), (short)1, "Ownership type" },
                    { new Guid("a3878238-fb6e-4a10-8d5f-a161bee11d2f"), (short)6, null, new Guid("4c68fe49-77fc-4142-b8d8-6ba371fd8472"), (short)2, "Equipment" },
                    { new Guid("e1e076db-3141-45a0-8be2-8a45877a12cb"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("665e102a-27f7-421f-8780-67749caee1cb"), (short)2, "Frequency" },
                    { new Guid("8cb6eb30-e395-47b0-bc04-adf4daac78e3"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("665e102a-27f7-421f-8780-67749caee1cb"), (short)1, "Ownership type" },
                    { new Guid("665e102a-27f7-421f-8780-67749caee1cb"), (short)6, null, new Guid("4c68fe49-77fc-4142-b8d8-6ba371fd8472"), (short)1, "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("4c68fe49-77fc-4142-b8d8-6ba371fd8472"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("78f83582-4135-4c7e-86a8-9b9566b93144"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("160d7f71-ad79-42f3-a10b-0e531feca975"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("ec1f2a2c-7654-49de-9f1a-d4d959398953"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("0cb0794c-aa53-403d-92df-6816eca7746d"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("10d40e09-e2a6-4d89-b546-cb4c10676ccd"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("f1e75af7-d143-4e7e-9616-be205a9a0350"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("1ecb7032-01e3-4b81-8d3c-adafd8e4d0c8"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("f05044df-9372-4b9d-85af-584064bf8570"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("973737a8-8d47-45f4-a8b2-5d2cf5b9a269"), (short)1, "a", null, (short)20, "Discounts" }
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
                    { new Guid("2f4b2ca8-94a8-418b-96ef-a02dd5ca134d"), "A.01", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("7c3342cc-f805-4cdd-ac9c-2a45b508656b"), "H.51.22", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Space transport" },
                    { new Guid("79639e90-8e1c-4696-87a2-5592f2da8e9b"), "H.52", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Warehousing and support activities for transportation" },
                    { new Guid("10666b3e-c28a-49da-b4b6-4dec84e9bfe5"), "H.52.1", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Warehousing and storage" },
                    { new Guid("782eebc2-3bd6-4dc0-b9a6-eb279ddd5268"), "H.52.10", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Warehousing and storage" },
                    { new Guid("42b2069b-eaa3-4d13-92bc-a8fad3b38f98"), "H.52.2", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Support activities for transportation" },
                    { new Guid("3ec31706-c25f-4e8d-aafa-1c34fc2764c8"), "H.52.21", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Service activities incidental to land transportation" },
                    { new Guid("10ae8d46-a0da-4149-84a2-f7f6cd26d418"), "H.52.22", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Service activities incidental to water transportation" },
                    { new Guid("fb990e39-8f38-4740-92ac-0ffc737ad4b9"), "H.52.23", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Service activities incidental to air transportation" },
                    { new Guid("17035c3d-e5e6-44d0-8d36-3b3551c5b9e7"), "H.52.24", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Cargo handling" },
                    { new Guid("bd7f1c69-1604-43b5-b914-33efac4b1ccf"), "H.52.29", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Other transportation support activities" },
                    { new Guid("edfdac76-f754-42a0-9e23-07b4577beae9"), "H.53", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Postal and courier activities" },
                    { new Guid("edd8f44e-7b21-4e20-b65f-0fdcaefffd28"), "H.53.1", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Postal activities under universal service obligation" },
                    { new Guid("bfe62436-1688-41a6-9fbd-2ed1c63d67a7"), "H.51.21", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Freight air transport" },
                    { new Guid("7b01d06b-9700-4649-a670-af7c8d2755c3"), "H.53.10", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Postal activities under universal service obligation" },
                    { new Guid("9a11ac5a-c717-4128-aba0-d881891164d1"), "H.53.20", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Other postal and courier activities" },
                    { new Guid("e46f322a-c47a-4d29-9a3c-e2756ea94694"), "I.55", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Accommodation" },
                    { new Guid("86816e39-d17e-4183-8397-f4c0c1302342"), "I.55.1", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Hotels and similar accommodation" },
                    { new Guid("225e4bcf-e97b-4662-a2e9-41f013f8ff5d"), "I.55.10", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Hotels and similar accommodation" },
                    { new Guid("3e685191-2ac3-41ea-a304-ea137eee32a3"), "I.55.2", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Holiday and other short-stay accommodation" },
                    { new Guid("61438ff9-662b-4fe5-ae39-4b576545353e"), "I.55.20", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Holiday and other short-stay accommodation" },
                    { new Guid("f80632a9-259a-421f-9354-e14d8b4c1281"), "I.55.3", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("298644c4-3e0d-4210-9e2f-455fea524720"), "I.55.30", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("1741b8d3-3326-4206-945a-98a66114d5b7"), "I.55.9", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Other accommodation" },
                    { new Guid("c560acf0-83fb-4ba4-bc7d-2fe0a1ad3e55"), "I.55.90", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Other accommodation" },
                    { new Guid("ac450603-1ddf-41e4-998d-9419d7fd86fc"), "I.56", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Food and beverage service activities" },
                    { new Guid("de37ac66-53c5-4b27-80b6-1833785a2bf2"), "I.56.1", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Restaurants and mobile food service activities" },
                    { new Guid("d630f726-7e48-4db1-ae84-438279e007bb"), "H.53.2", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Other postal and courier activities" },
                    { new Guid("5f4a0ed0-e1df-43af-83f3-3026414bd2ee"), "H.51.2", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Freight air transport and space transport" },
                    { new Guid("1a89f261-c963-4d6d-9e0b-f81bbd103e8d"), "H.51.10", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Passenger air transport" },
                    { new Guid("ee41f2fa-29a7-4ee5-9ec3-4f97b24ca040"), "H.51.1", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Passenger air transport" },
                    { new Guid("fe083d6d-f846-4592-be21-745d0bf2ac4a"), "G.47.9", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("d04622b7-3dfb-48fa-89a2-77d002f35497"), "G.47.91", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("0569eb1a-61f2-4289-92e8-723ed4c3c768"), "G.47.99", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("7dbd24e3-fcdd-426f-a637-7ed79cd39c8c"), "H.49", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Land transport and transport via pipelines" },
                    { new Guid("a044a129-0588-4f1c-a018-ef1547c3f36f"), "H.49.1", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Passenger rail transport, interurban" },
                    { new Guid("51527206-e068-4dbb-8ee5-751da4d71fb1"), "H.49.10", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Passenger rail transport, interurban" },
                    { new Guid("cebf2203-146d-4b1c-aded-9e82fb16872e"), "H.49.2", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Freight rail transport" },
                    { new Guid("70424182-939c-4f73-9c66-a1fc9d0a3ddd"), "H.49.20", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Freight rail transport" },
                    { new Guid("ed714bf2-9ce0-4ef3-a807-6c5139a548b8"), "H.49.3", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Other passenger land transport" },
                    { new Guid("50dd08b6-917b-45d5-99dd-ccee3011ae5c"), "H.49.31", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Urban and suburban passenger land transport" },
                    { new Guid("3fa877cb-0fd2-4092-b9fb-2bb61af50ce4"), "H.49.32", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9a45d41f-37bd-49b1-bf73-63497218c89f"), "H.49.39", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Other passenger land transport n.e.c." },
                    { new Guid("abe8054e-6d2e-45a2-8be9-9c6a475d80d1"), "H.49.4", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Freight transport by road and removal services" },
                    { new Guid("9c475112-8de4-4dc9-a6c0-007a7957f74c"), "H.49.41", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Freight transport by road" },
                    { new Guid("d09ff59d-2740-41f5-b6d9-dd8cda9da95e"), "H.49.42", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Removal services" },
                    { new Guid("5b36fbf3-265e-48f6-a29b-8fab12f53d91"), "H.49.5", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Transport via pipeline" },
                    { new Guid("12230fff-2430-434a-96b9-56d83a37e1ee"), "H.49.50", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Transport via pipeline" },
                    { new Guid("cdb75f93-833d-4a6d-8097-d23abf020155"), "H.50", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Water transport" },
                    { new Guid("70014bc4-194f-42b8-95ac-47d9db7cb9ff"), "H.50.1", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Sea and coastal passenger water transport" },
                    { new Guid("c81e4478-c4db-4aa6-8035-62abc8c269b2"), "H.50.10", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Sea and coastal passenger water transport" },
                    { new Guid("47aaef1f-f5e3-4c66-8735-27d5259857c1"), "H.50.2", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Sea and coastal freight water transport" },
                    { new Guid("bc714c41-3aaa-4612-90fa-1b42c14cc5e4"), "H.50.20", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Sea and coastal freight water transport" },
                    { new Guid("30b7ada1-7aa7-4875-99fb-2216ca8ee326"), "H.50.3", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Inland passenger water transport" },
                    { new Guid("66f10129-1bec-4406-beda-2e291dc47a18"), "H.50.30", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Inland passenger water transport" },
                    { new Guid("4a0d97f7-14f5-4d1b-8767-a9ce0d4c16a3"), "H.50.4", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Inland freight water transport" },
                    { new Guid("7f72faa1-8c5b-4564-bb82-77cad8605f0d"), "H.50.40", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Inland freight water transport" },
                    { new Guid("cc33da1f-0f54-4d32-b7e1-c8eb02d13f5b"), "H.51", new Guid("e111a390-958b-42fb-bfe0-6b0c1da02ff4"), "Air transport" },
                    { new Guid("669b00e4-72b3-4529-a652-74974d2f3198"), "I.56.10", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Restaurants and mobile food service activities" },
                    { new Guid("88f772cf-486c-41a7-9b89-8d4229f5c5bb"), "G.47.89", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("12e1f1f4-52a2-4df1-bd5c-5c788ecb8d86"), "I.56.2", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Event catering and other food service activities" },
                    { new Guid("f7ac6514-ef7b-4522-9832-8cf62e784a86"), "I.56.29", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Other food service activities" },
                    { new Guid("f73af7df-5e57-4acf-ae6e-8f23ceef4bb2"), "J.61.30", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Satellite telecommunications activities" },
                    { new Guid("f94c23fa-73b5-4cdb-85eb-3a5dfd371436"), "J.61.9", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other telecommunications activities" },
                    { new Guid("45daa4fe-a284-4f14-8a2c-17c8793be988"), "J.61.90", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other telecommunications activities" },
                    { new Guid("2106c025-13a0-46f2-8878-870a4aae9f86"), "J.62", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Computer programming, consultancy and related activities" },
                    { new Guid("6b5ac396-1805-4a6e-ab91-9c4b8434cb70"), "J.62.0", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Computer programming, consultancy and related activities" },
                    { new Guid("643894b2-f4fc-4595-aaf2-26a5d705b0e0"), "J.62.01", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Computer programming activities" },
                    { new Guid("e263752d-908b-49a3-a0a0-a38576ef22b9"), "J.62.02", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Computer consultancy activities" },
                    { new Guid("b75d97ad-d4e5-4323-b52d-5827d1921886"), "J.62.03", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Computer facilities management activities" },
                    { new Guid("07a25799-2c91-4fc7-b2fc-a254e5a84e27"), "J.62.09", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other information technology and computer service activities" },
                    { new Guid("fd180d1d-55eb-4e0c-8f39-7788274fee2c"), "J.63", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Information service activities" },
                    { new Guid("d974912e-afbc-403a-9239-802852c1a19c"), "J.63.1", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("1abf1c50-65c0-40d5-9ed5-169db27b05a5"), "J.63.11", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Data processing, hosting and related activities" },
                    { new Guid("ee06e490-c7fc-48c5-acb3-bf093ddbe830"), "J.61.3", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Satellite telecommunications activities" },
                    { new Guid("a7ce1f38-66bb-4de1-b11d-19c9270b4dda"), "J.63.12", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Web portals" },
                    { new Guid("398bd757-3165-40b6-a313-931c846680fa"), "J.63.91", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "News agency activities" },
                    { new Guid("19646c46-311f-43bc-a02a-4e5ac89b246a"), "J.63.99", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other information service activities n.e.c." },
                    { new Guid("c908fecf-bb51-411f-baab-840ae26b0e5d"), "K.64", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("17e8de40-71d4-4624-b8d9-40defaeed3bc"), "K.64.1", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Monetary intermediation" },
                    { new Guid("71077937-684c-487b-9fb7-55d4231bdf1c"), "K.64.11", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Central banking" },
                    { new Guid("01fa2f56-283d-4203-aad2-04fa21787039"), "K.64.19", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Other monetary intermediation" },
                    { new Guid("54c1e3f1-0cc9-4ac2-91c0-ee60e0f4b50f"), "K.64.2", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Activities of holding companies" },
                    { new Guid("d3f5bed6-bee6-467e-b3e1-19ea3a16f295"), "K.64.20", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d295223f-0e07-4dba-9907-3d47119fd390"), "K.64.3", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Trusts, funds and similar financial entities" },
                    { new Guid("fd506912-d676-44f8-b6ae-e006cc7d5261"), "K.64.30", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Trusts, funds and similar financial entities" },
                    { new Guid("28ac7016-ecdf-4e45-b3a6-4634189ba173"), "K.64.9", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("6bace0a9-b1f7-41c5-81f2-789b077ab650"), "K.64.91", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Financial leasing" },
                    { new Guid("2457679e-01e8-4c04-b975-4585c74df3b4"), "J.63.9", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other information service activities" },
                    { new Guid("c0d914be-4c96-492d-adb3-b47f1563eff0"), "J.61.20", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Wireless telecommunications activities" },
                    { new Guid("d436170f-abcd-495e-8721-1924ae6c3d38"), "J.61.2", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Wireless telecommunications activities" },
                    { new Guid("34df1b98-5905-46c6-a161-be1b3ec73d45"), "J.61.10", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Wired telecommunications activities" },
                    { new Guid("5a26bed8-fb7b-44df-9d95-6c760647c370"), "I.56.3", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Beverage serving activities" },
                    { new Guid("e5c03f07-0a1f-4bee-bb7a-154c487f6185"), "I.56.30", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Beverage serving activities" },
                    { new Guid("da94a0f8-70d8-45ac-bb5f-634873610d30"), "J.58", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Publishing activities" },
                    { new Guid("dce6ec08-1928-42fd-ba07-e83721249d15"), "J.58.1", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("724563f5-f458-4d8f-b583-291c3958d7c1"), "J.58.11", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Book publishing" },
                    { new Guid("98da00f9-6673-4ecf-a1dd-73c8555a9f5e"), "J.58.12", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Publishing of directories and mailing lists" },
                    { new Guid("73e3a37f-5372-4010-8922-3efa481bf846"), "J.58.13", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Publishing of newspapers" },
                    { new Guid("bf838a3e-7059-45b4-aa55-19d983a9cfcd"), "J.58.14", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Publishing of journals and periodicals" },
                    { new Guid("fb529a65-e5f4-44c7-9cf0-171b0bb88533"), "J.58.19", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other publishing activities" },
                    { new Guid("35789e2b-5bec-44e3-909d-dfec0ea156a9"), "J.58.2", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Software publishing" },
                    { new Guid("fc1ba19d-286f-4012-aa45-c4a05f7b22a1"), "J.58.21", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Publishing of computer games" },
                    { new Guid("05b4f931-8c56-40f4-8138-a17254f4af34"), "J.58.29", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Other software publishing" },
                    { new Guid("2451ce59-b774-4d64-a0e9-9596841151e4"), "J.59", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("81314cac-a3ee-40dd-aa62-acad147ec34e"), "J.59.1", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Motion picture, video and television programme activities" },
                    { new Guid("70e3a99d-f279-487a-82b4-44b8a86e77a5"), "J.59.11", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Motion picture, video and television programme production activities" },
                    { new Guid("c8fd831f-3e51-48bf-96a6-8209c4e3320b"), "J.59.12", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("0b5f3c36-2ad2-4eae-946b-c6e144630c8e"), "J.59.13", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("bca0ff28-2bff-4b8a-b397-831d5ec6abf9"), "J.59.14", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Motion picture projection activities" },
                    { new Guid("4acb4cdb-094c-46e7-a9b2-7ad4ee3d1374"), "J.59.2", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Sound recording and music publishing activities" },
                    { new Guid("97c56226-1945-4f49-8a2c-92762a61e67b"), "J.59.20", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Sound recording and music publishing activities" },
                    { new Guid("1d9bfa75-8ae0-4ee9-8426-12c68fd71fc8"), "J.60", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Programming and broadcasting activities" },
                    { new Guid("bd59a88b-1828-435a-aa14-b7b76d214582"), "J.60.1", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Radio broadcasting" },
                    { new Guid("f0479986-4c91-42db-9942-e255ba3a47b8"), "J.60.10", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Radio broadcasting" },
                    { new Guid("908134da-bcab-46f7-b25a-5c3875ddc0c9"), "J.60.2", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Television programming and broadcasting activities" },
                    { new Guid("a4a18e73-d8c9-4272-a421-ba67f5155229"), "J.60.20", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Television programming and broadcasting activities" },
                    { new Guid("4c10c3eb-a7d9-4325-a176-9c500f6e8be5"), "J.61", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Telecommunications" },
                    { new Guid("d00a7a63-d9df-4a5e-81d4-611b683b7b56"), "J.61.1", new Guid("a744303e-de58-4ed2-ad31-ed5c1df12756"), "Wired telecommunications activities" },
                    { new Guid("5b1ce4b7-b5d2-405b-8885-65bad36df7e5"), "I.56.21", new Guid("884d4722-a653-4816-a794-e9308bd8eefb"), "Event catering activities" },
                    { new Guid("bef8aab0-35ad-4556-a0b2-17012889cc99"), "K.64.92", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Other credit granting" },
                    { new Guid("0ca668c8-14e2-4356-997a-80f4236e9a52"), "G.47.82", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("12b7788a-5de7-4c9d-81a4-d94d95568476"), "G.47.8", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale via stalls and markets" },
                    { new Guid("3398ef90-1a70-486b-9218-ac91ea659431"), "G.46.19", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("6c8e5ee2-15ff-4504-b91e-2add66845def"), "G.46.2", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("63da6902-3bda-45ae-a960-96ad81f9d9c6"), "G.46.21", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d700f5f0-74a2-4df5-9f43-3a51df5741ea"), "G.46.22", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of flowers and plants" },
                    { new Guid("a59cee30-7e9d-4b1d-9f37-6c38844ba516"), "G.46.23", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of live animals" },
                    { new Guid("cbd5aaf2-300f-4283-a5ea-ad9cf4935d05"), "G.46.24", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of hides, skins and leather" },
                    { new Guid("4ab1ef26-6122-44a5-b4c5-93727e2c5cf1"), "G.46.3", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("2fd8179b-c168-4af8-a543-5d0dc5d883bb"), "G.46.31", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of fruit and vegetables" },
                    { new Guid("d2941bff-0589-402f-8f80-ad4e4cd7c603"), "G.46.32", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of meat and meat products" },
                    { new Guid("431f93dd-18fc-4274-9afd-c5f9870131a5"), "G.46.33", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("33ac9754-4d68-4192-84b5-c6010cd71219"), "G.46.34", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of beverages" },
                    { new Guid("47f4be8c-f690-4b3f-aa2e-7a9ae8a89d6e"), "G.46.35", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of tobacco products" },
                    { new Guid("4453f9f2-b8cc-42db-94df-3f3c7dd71bf9"), "G.46.18", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents specialised in the sale of other particular products" },
                    { new Guid("b3b79d91-0991-4a9a-adfc-313d2c9af6ff"), "G.46.36", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("e88e3c75-678d-402d-91d0-aa3159d8997f"), "G.46.38", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("777c6b2a-e472-4336-88db-e61a2f3757fe"), "G.46.39", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("c3724a2a-0da9-427f-892b-ce484bf823b5"), "G.46.4", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of household goods" },
                    { new Guid("43daa75d-5b7f-44d0-aa83-a4aebafa9b29"), "G.46.41", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of textiles" },
                    { new Guid("abd436c7-ff6d-48c1-a4ba-8f4432deafa4"), "G.46.42", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of clothing and footwear" },
                    { new Guid("5b194ff8-971f-46a8-92c9-487548a091a6"), "G.46.43", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of electrical household appliances" },
                    { new Guid("3688fadd-e9f0-4a89-af43-732feed0fc42"), "G.46.44", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("f7114395-ea40-4d52-a4b6-27f7e4882d99"), "G.46.45", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of perfume and cosmetics" },
                    { new Guid("39011e85-140c-488c-9327-d1e08ebc766c"), "G.46.46", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of pharmaceutical goods" },
                    { new Guid("39776325-2984-485d-a7a7-3dd05ba82a72"), "G.46.47", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("79b7bdd9-e275-4a13-86ef-368445d28bb0"), "G.46.48", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of watches and jewellery" },
                    { new Guid("a0b1cd56-5c05-4eca-a498-3ca75f3043bc"), "G.46.49", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of other household goods" },
                    { new Guid("2af172a1-9152-431c-b7c6-48fdf15ada2c"), "G.46.37", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("04dd3e23-e889-44fe-8f41-ae0fdc9e80bb"), "G.46.17", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("5a76ab01-5e0d-415a-8dbe-c7c13a560328"), "G.46.16", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("2b4f5b81-343f-4620-b2a5-212561bccac2"), "G.46.15", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("7b7d0a6e-b17b-4105-a558-5da90097445a"), "F.43.29", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Other construction installation" },
                    { new Guid("74378907-ee08-4942-80d7-b058518df2ba"), "F.43.3", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Building completion and finishing" },
                    { new Guid("11fd82dd-05ea-4c8f-a4bf-f9f58f89199e"), "F.43.31", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Plastering" },
                    { new Guid("586e8770-7d52-43c0-90f3-018565e360e9"), "F.43.32", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Joinery installation" },
                    { new Guid("f1bcb20d-9959-415b-892b-3a247f132634"), "F.43.33", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Floor and wall covering" },
                    { new Guid("acdd4fcf-1d6c-4520-b396-e198a3b2f77f"), "F.43.34", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Painting and glazing" },
                    { new Guid("de23a946-8892-4214-8c13-8a42f0a18f23"), "F.43.39", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Other building completion and finishing" },
                    { new Guid("6135c1eb-f191-419a-b934-7f1b9be1a50c"), "F.43.9", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Other specialised construction activities" },
                    { new Guid("417555ff-fd13-4cb4-866e-b41afd4f3ad8"), "F.43.91", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Roofing activities" },
                    { new Guid("0dd25067-b013-4272-a7c0-d5a9fed06b5f"), "F.43.99", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Other specialised construction activities n.e.c." },
                    { new Guid("58ff5f86-7136-4609-996b-aa2280614f2c"), "G.45", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("165bc48b-9432-4ea6-9a4c-1941ddabd95e"), "G.45.1", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Sale of motor vehicles" },
                    { new Guid("3d20e289-420f-4c52-92bd-eabdb443c0f4"), "G.45.11", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Sale of cars and light motor vehicles" },
                    { new Guid("1cceb9ec-bde5-4736-a615-02a3ffc742ab"), "G.45.19", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Sale of other motor vehicles" },
                    { new Guid("dfceceb8-a924-47bf-afd3-ea2f96f5f978"), "G.45.2", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("46afa7a6-d61a-4590-9955-aa74e4dfdf59"), "G.45.20", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Maintenance and repair of motor vehicles" },
                    { new Guid("a04f0e88-4936-4fc3-a9d7-da97c7810fde"), "G.45.3", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("2519ea22-ae48-474f-84ea-8993a47a348d"), "G.45.31", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("c92cb121-2b2a-43f2-aebd-253a8aa379e5"), "G.45.32", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("37072754-2634-4e10-b334-1facd1fb1838"), "G.45.4", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("8c1334f3-8de6-40ee-88bf-16b7ea2ee7ba"), "G.45.40", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("fc5a6ff4-1720-43db-9b3e-b0ea41df2a4b"), "G.46", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("5c7edbd5-c623-426b-9d51-cee664221964"), "G.46.1", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale on a fee or contract basis" },
                    { new Guid("f1189724-98c6-4fea-bb01-e6326c510a01"), "G.46.11", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("128c17db-4672-4702-b1ad-adb5e52d147f"), "G.46.12", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("7b63a280-f233-44e9-af3d-f15d178135c7"), "G.46.13", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("a02431fe-7c0d-4e14-a6a8-4ac50e72f99f"), "G.46.14", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("230d23e1-5c17-470a-bbcf-7d457ea95305"), "G.46.5", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of information and communication equipment" },
                    { new Guid("85c2ed5c-ab41-45b6-990e-c9a2dcdc7e91"), "G.47.81", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("3afc3d96-af7e-4b55-912e-803350ad6646"), "G.46.51", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("1a695e11-e76f-4c3a-b2fe-a77654b21103"), "G.46.6", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("2435558d-9b4e-4f8c-9c3d-63b07cada532"), "G.47.4", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("8d8db57c-6be9-480d-8156-5e65d84f0487"), "G.47.41", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("c2a52016-eac3-4f0d-9b30-f5295a5a33eb"), "G.47.42", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("9c0b179a-49a3-4ba1-b7dc-37fa174fac85"), "G.47.43", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("eba2fab8-2d04-4080-9a8e-22d85d3569af"), "G.47.5", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("45f240dd-b22a-415c-99b0-a6e8be04edfe"), "G.47.51", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of textiles in specialised stores" },
                    { new Guid("9357de62-0595-47bc-a8e6-9dd98dc38a7c"), "G.47.52", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("cf322e5b-4d15-4bef-8a77-55c311d3c9a4"), "G.47.53", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("70edca27-fcb6-4e36-b00c-0bb6eae53c9f"), "G.47.54", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("188801e8-99ab-4029-aae0-276c6a8689d7"), "G.47.59", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("a14d92d0-e5ff-4dc6-8c16-10aef22018b1"), "G.47.6", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("000df813-6919-4afc-abc9-d14cb8b55e50"), "G.47.61", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of books in specialised stores" },
                    { new Guid("fac61cc6-b584-4423-af33-da48d5a32c4d"), "G.47.30", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("7483381f-18ef-4b10-93fa-1cec6cb3a36e"), "G.47.62", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("01ce4bcf-ca93-40b6-bc12-46cc6bfc0555"), "G.47.64", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("1bbfd88b-9944-4d29-9297-1cdb519065ca"), "G.47.65", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("2a1b2012-857d-4dc4-8503-23caae76b4b7"), "G.47.7", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of other goods in specialised stores" },
                    { new Guid("4abe40b6-5af0-495d-9c88-c831d1d211e5"), "G.47.71", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of clothing in specialised stores" },
                    { new Guid("4db4348b-3c23-45f6-b912-4181da20c593"), "G.47.72", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("eb732a14-0294-4692-9e31-e86bd70544c3"), "G.47.73", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Dispensing chemist in specialised stores" },
                    { new Guid("20dc1949-7b70-430c-8386-f3270e57a2a2"), "G.47.74", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("d5e9a41a-9f1a-42ba-b4ee-1283875a4f77"), "G.47.75", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("d4fbff63-6ae4-40a4-bfa1-86fd1da0cd2d"), "G.47.76", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("4ea76414-8800-4c19-a5ef-f2f61d7c431c"), "G.47.77", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("f646adf2-555f-4d2b-a327-7bfa881737b1"), "G.47.78", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("c7237a4a-9dc0-4255-bc99-f81006d0e35f"), "G.47.79", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2f1ae5be-baf2-4a96-8973-3c63cd57625d"), "G.47.63", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("32e6e80a-3aac-444d-9bd0-bc2cb9af70a6"), "G.47.3", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("d398e1fe-697e-4980-b93a-5810ce828ce7"), "G.47.29", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Other retail sale of food in specialised stores" },
                    { new Guid("85baa590-cb7b-4c5f-a05c-7bba32b97e02"), "G.47.26", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("98a04fe2-05ad-4eab-9a7f-f4521b9447e0"), "G.46.61", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("efdf58b4-4c94-47f1-ac85-fd6afdae08a9"), "G.46.62", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of machine tools" },
                    { new Guid("6346eb81-14cd-43ad-a9c2-ac47b13fc5a1"), "G.46.63", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("ed4f78e3-21ab-4ee0-b02c-a5eac2716da6"), "G.46.64", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("322ae34d-68de-4a7c-8b5b-cd77c9520da1"), "G.46.65", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of office furniture" },
                    { new Guid("71af6ea0-5321-4753-8781-7eef962b9a71"), "G.46.66", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of other office machinery and equipment" },
                    { new Guid("d071bbd2-b5b4-4c86-846a-f31cdf97c748"), "G.46.69", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of other machinery and equipment" },
                    { new Guid("b7f48920-c251-41ca-9736-f346124fe91e"), "G.46.7", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Other specialised wholesale" },
                    { new Guid("ddff37cb-137b-4143-970f-2d4f779ac07d"), "G.46.71", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("9e06cf82-3d92-4ac0-8a5e-60227c4c11f3"), "G.46.72", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of metals and metal ores" },
                    { new Guid("8efd7a8f-f81d-4600-a006-e6cc87cd72c6"), "G.46.73", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("524354e7-c29f-41f3-9160-c40dc0fd24a0"), "G.46.74", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("7e90a757-0264-453e-b107-abd990dd929c"), "G.46.75", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of chemical products" },
                    { new Guid("6f997add-498a-45a2-9d43-b851b49a6a81"), "G.46.76", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of other intermediate products" },
                    { new Guid("bc9ac5d8-1683-4e6c-9a3c-c82339ce6629"), "G.46.77", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of waste and scrap" },
                    { new Guid("b973bee8-f9b3-465f-ae99-32cad542d5d4"), "G.46.9", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Non-specialised wholesale trade" },
                    { new Guid("e9543fb6-085f-49c5-9de3-4cbc426fae2a"), "G.46.90", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Non-specialised wholesale trade" },
                    { new Guid("a1300414-efe8-4990-b1fb-6329ba023095"), "G.47", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("ab70c465-5994-429c-8257-f7ba6ab09348"), "G.47.1", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale in non-specialised stores" },
                    { new Guid("8bb1828e-9e20-4403-8c01-b564e4f1f12d"), "G.47.11", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("de33873d-0b8f-41a1-8a50-850e43b48f90"), "G.47.19", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Other retail sale in non-specialised stores" },
                    { new Guid("fdff0506-2a08-4d1e-b562-669fc34a463f"), "G.47.2", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("9d490b26-37b8-4f42-9cb7-96d96c570c75"), "G.47.21", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("0aaecb89-f1cb-4d9f-9497-bffb4bb67982"), "G.47.22", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("a99b9a03-7dc9-40c4-8d42-3622f7b7aa7a"), "G.47.23", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("50b06ccc-7142-483c-93a4-3bd4b7e6ec8f"), "G.47.24", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("7ddebc4f-aeb4-4500-991d-d84d636c2e64"), "G.47.25", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Retail sale of beverages in specialised stores" },
                    { new Guid("70f55460-e84f-401c-9d94-cbc7222127cc"), "G.46.52", new Guid("dcab7370-97ca-4ae5-ae43-b6d13c6ce09b"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("d6620fcb-d5cc-45c6-be45-b82d2584ee2c"), "F.43.22", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("c80d5979-32a0-41b4-96b7-f2db9200f06f"), "K.64.99", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("3b0691bd-bdb3-4791-b856-ed0777e80a80"), "K.65.1", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Insurance" },
                    { new Guid("81fd80f9-433e-4391-9812-0306a884c9f1"), "P.85.6", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Educational support activities" },
                    { new Guid("d8cdc5a8-5bd9-4f9f-8487-fc49baf4d736"), "P.85.60", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Educational support activities" },
                    { new Guid("88f568d9-712b-4bcc-8d32-18ba7c1e00b1"), "Q.86", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Human health activities" },
                    { new Guid("d7253c60-3860-445f-8580-0f395bb3a528"), "Q.86.1", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Hospital activities" },
                    { new Guid("fc952bd2-c25b-443e-aec8-38e290ac28e0"), "Q.86.10", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Hospital activities" },
                    { new Guid("731034ed-c2b1-4e36-a808-f74078bbf1dc"), "Q.86.2", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Medical and dental practice activities" },
                    { new Guid("e7bace2e-f9db-47b3-8f86-4e3ee7662d1d"), "Q.86.21", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9b8ec972-669e-4e18-8265-529670f3308a"), "Q.86.22", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Specialist medical practice activities" },
                    { new Guid("f97b6e25-be54-4fe0-a0d7-4a7f21f156b6"), "Q.86.23", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Dental practice activities" },
                    { new Guid("ce394b86-80d7-4c7f-bc86-00438cda90f0"), "Q.86.9", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Other human health activities" },
                    { new Guid("3a4eaba6-7986-429f-a5f6-716688330b3c"), "Q.86.90", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Other human health activities" },
                    { new Guid("3bfa64d0-e559-4177-9d7d-080515292786"), "Q.87", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential care activities" },
                    { new Guid("62770e20-c3fd-483d-9631-5656f26fff59"), "P.85.59", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Other education n.e.c." },
                    { new Guid("29791240-37e0-40d5-9104-d1b8dc57a9fd"), "Q.87.1", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential nursing care activities" },
                    { new Guid("47663ee4-ffba-437e-80ff-3cce67a46186"), "Q.87.2", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("391e83b4-543d-4dc9-bab8-db6de410e872"), "Q.87.20", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("db20edaa-9d08-4cb6-9019-8f36ec8e098c"), "Q.87.3", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential care activities for the elderly and disabled" },
                    { new Guid("f46b9088-b562-4141-92d6-d1e957536090"), "Q.87.30", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential care activities for the elderly and disabled" },
                    { new Guid("8347c48b-d8e1-403c-b500-c6f283a7f1e0"), "Q.87.9", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Other residential care activities" },
                    { new Guid("7b7124e5-6ea2-4193-b5fc-48665bdb9b30"), "Q.87.90", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Other residential care activities" },
                    { new Guid("8ce0c6f7-80f4-459a-a865-179727200a6e"), "Q.88", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Social work activities without accommodation" },
                    { new Guid("3cce2762-d776-4af6-9fa4-ad4a93044198"), "Q.88.1", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("5ce01ced-3ca7-48e0-bdda-36f1a798eb13"), "Q.88.10", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("68c5f8bd-f299-452d-beae-1b18e3eaf829"), "Q.88.9", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Other social work activities without accommodation" },
                    { new Guid("aaee6e5e-a735-47cb-b352-be109e6938ab"), "Q.88.91", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Child day-care activities" },
                    { new Guid("ba9d02dd-310d-43ca-9713-bbeac079292a"), "Q.88.99", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("749ee7e0-30b6-4095-a9ea-72d2c490ab61"), "Q.87.10", new Guid("0d4b527d-f8b8-40ee-b8c7-42133995647f"), "Residential nursing care activities" },
                    { new Guid("0410d800-91f5-4b58-9ab5-409890aae331"), "P.85.53", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Driving school activities" },
                    { new Guid("a18ffc2c-fc16-452d-9abb-35995b07d0a5"), "P.85.52", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Cultural education" },
                    { new Guid("5e6bf91e-29b4-420f-99f9-490d2fff4a91"), "P.85.51", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Sports and recreation education" },
                    { new Guid("6a826e4a-3088-44e4-a5a4-a55385912241"), "N.82.91", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Packaging activities" },
                    { new Guid("2386aabc-0a94-4f82-b7c6-ecd86160b537"), "N.82.99", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other business support service activities n.e.c." },
                    { new Guid("6e4dc6f9-cd55-4727-84fe-0c36f3560868"), "O.84", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Public administration and defence; compulsory social security" },
                    { new Guid("788dea26-fa6b-4a5f-9057-7bc986c4d343"), "O.84.1", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("380fe150-b961-47d7-a810-2d6b5c81fd85"), "O.84.11", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "General public administration activities" },
                    { new Guid("ad049b86-ed2d-4255-8b1c-be2609a6a23a"), "O.84.12", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("43f45def-d695-49e7-9341-9df3aaca64ea"), "O.84.13", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("3674f64e-0c03-4f2f-906e-bac0ab57a4b0"), "O.84.2", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Provision of services to the community as a whole" },
                    { new Guid("e44f6a14-cdfd-4be8-bd3a-52d40645ef29"), "O.84.21", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Foreign affairs" },
                    { new Guid("2a11f424-91d0-415f-a71c-dab9a84a7443"), "O.84.22", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Defence activities" },
                    { new Guid("ecaeb611-c402-477b-8f01-39dcc47afee1"), "O.84.23", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Justice and judicial activities" },
                    { new Guid("574110e1-2b97-421f-a7da-dee4f274481e"), "O.84.24", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Public order and safety activities" },
                    { new Guid("a157216f-d6e3-46b3-8564-489d09a36cfd"), "O.84.25", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Fire service activities" },
                    { new Guid("da1be8c6-057b-4753-ade0-0b1db1d8c5c2"), "O.84.3", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Compulsory social security activities" },
                    { new Guid("4a909d26-9c04-47f8-a6d8-a91ffe65116f"), "O.84.30", new Guid("531b559c-b9bd-4fbf-9a03-7635e196d269"), "Compulsory social security activities" },
                    { new Guid("8d0a162f-5b6d-4a5f-8379-996f57699e9a"), "P.85", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Education" },
                    { new Guid("f3faa76f-73ae-4fe1-a41f-124cf3ae1518"), "P.85.1", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Pre-primary education" },
                    { new Guid("53a25026-0ef2-4cab-bb59-f3cccca7c592"), "P.85.10", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Pre-primary education" },
                    { new Guid("a1ffc5e4-dad2-4ccc-8f0b-3adff3f4197b"), "P.85.2", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c5477cbb-7da1-4af4-8af5-ce8e6e0a120f"), "P.85.20", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Primary education" },
                    { new Guid("1ad54175-70ff-4aa7-8b69-00b9d2955b82"), "P.85.3", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Secondary education" },
                    { new Guid("4909fe03-e5b6-4c79-aab9-55c995c1bdb9"), "P.85.31", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "General secondary education" },
                    { new Guid("e24cc946-ee44-48a2-a8b0-7660f18b71c4"), "P.85.32", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Technical and vocational secondary education" },
                    { new Guid("27af0a76-56d7-41eb-a96f-04ee8903561e"), "P.85.4", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Higher education" },
                    { new Guid("c6f4e8a8-1cb4-4b93-b1c3-7a4c57da8cc5"), "P.85.41", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Post-secondary non-tertiary education" },
                    { new Guid("cca42a01-1ef5-491c-b8b5-a87b5c28fbca"), "P.85.42", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Tertiary education" },
                    { new Guid("08f2f8e4-db0a-4db8-b560-e6a3846382c1"), "P.85.5", new Guid("ac7f54e6-aea7-48df-909f-40daf319587f"), "Other education" },
                    { new Guid("c85d5801-790b-4563-bfa2-5d8d742efb7f"), "R.90", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Creative, arts and entertainment activities" },
                    { new Guid("fac87f74-42c5-4b40-a52e-d84e35f055e1"), "N.82.92", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("0dca491c-0c6e-4743-8208-577ce6f796ad"), "R.90.0", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Creative, arts and entertainment activities" },
                    { new Guid("78c36efc-9b82-46a5-97cb-a5e1bbc3ca28"), "R.90.02", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Support activities to performing arts" },
                    { new Guid("e25b31eb-1aa2-4be6-a0cc-a7067aa8defa"), "S.95.1", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of computers and communication equipment" },
                    { new Guid("5c0b0b7b-a1db-44d1-80eb-86a70b27394d"), "S.95.11", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of computers and peripheral equipment" },
                    { new Guid("d55b7713-edb2-4e82-84da-6035da3632d6"), "S.95.12", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of communication equipment" },
                    { new Guid("64e608a7-dcbb-43a3-86ed-558e84d5877d"), "S.95.2", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of personal and household goods" },
                    { new Guid("6b2f7570-4a03-4cea-9f19-6d8a4124599e"), "S.95.21", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of consumer electronics" },
                    { new Guid("1d6ceba5-41d4-443f-a60a-2fdcdfbdae39"), "S.95.22", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("5e4837c0-43bd-4659-9cfd-52ba043b2c53"), "S.95.23", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of footwear and leather goods" },
                    { new Guid("68691f4c-e911-4753-ac88-a3cadd3f188c"), "S.95.24", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of furniture and home furnishings" },
                    { new Guid("ed9fd784-e026-4c5a-b0b8-db47449c8333"), "S.95.25", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of watches, clocks and jewellery" },
                    { new Guid("054be395-c1a2-44ec-a8e0-eed5bdc41585"), "S.95.29", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of other personal and household goods" },
                    { new Guid("6df7a95b-3d3d-4c35-8bba-b261c40a01fa"), "S.96", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Other personal service activities" },
                    { new Guid("692e9c1b-d69c-47b9-b8ef-f2f5105eb390"), "S.96.0", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Other personal service activities" },
                    { new Guid("66841868-4db2-403d-bd4e-70823b480268"), "S.95", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Repair of computers and personal and household goods" },
                    { new Guid("c30d7f93-ab70-4a09-8781-1584c99b51b3"), "S.96.01", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("fd64a646-a455-421c-af00-c3b29dfbeaf7"), "S.96.03", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Funeral and related activities" },
                    { new Guid("7195808e-a914-415c-b4d9-13e7d055bfdc"), "S.96.04", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Physical well-being activities" },
                    { new Guid("d97be8c1-0ee6-41d2-821e-9b07c2ece381"), "S.96.09", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Other personal service activities n.e.c." },
                    { new Guid("db94bf52-5d64-4b90-afa1-d5b1de0a2b43"), "T.97", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("0056ea47-38a6-484c-8884-add727b2c84d"), "T.97.0", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("0daaef28-d6fa-4b87-b908-ec4807484669"), "T.97.00", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("d1f91ee9-8225-4069-b0c2-19ebf341adf7"), "T.98", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("851698b1-64c2-46b7-98bf-9002143742d7"), "T.98.1", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("38f3fa23-67c0-4f6f-acfc-ccbba81d0e4c"), "T.98.10", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("ca8c566b-21d8-4e28-939e-fb5c3216eb28"), "T.98.2", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("de6fb04d-8d26-4f9e-a0f5-1d97536a796b"), "T.98.20", new Guid("4172a573-6423-473e-9984-825cb545902b"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("3147715e-6e38-4d2d-b916-df0fdeb02c34"), "U.99", new Guid("bfd64441-c86b-4b14-9190-d01e19c7c164"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("440cf1e8-c200-4700-87e5-0975cf2c6e27"), "S.96.02", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Hairdressing and other beauty treatment" },
                    { new Guid("03d8c45e-e03e-4dba-84e2-60570544e7a0"), "S.94.99", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of other membership organisations n.e.c." },
                    { new Guid("2bef4e53-b07e-42fd-bb7f-e424398feff8"), "S.94.92", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of political organisations" },
                    { new Guid("552dbba5-4571-454f-90f1-99cb161020bb"), "S.94.91", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("13c32732-8012-49ff-a427-7a393b4092cb"), "R.90.03", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Artistic creation" },
                    { new Guid("2f291b81-ae7b-4f37-be4b-2b144f15e9f7"), "R.90.04", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Operation of arts facilities" },
                    { new Guid("0fe792ef-8d43-4a4d-93dc-34c3cce3117c"), "R.91", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("d28454bc-26c7-4508-ae1e-5cb5532f2683"), "R.91.0", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("9b2a701d-377e-4bfa-a658-1afdf9059120"), "R.91.01", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Library and archives activities" },
                    { new Guid("0b0e4f6c-b348-4bf4-be99-762eda725a44"), "R.91.02", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Museums activities" },
                    { new Guid("c760b8b3-9c9e-425b-b32a-82bc651c068f"), "R.91.03", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("4ee4bb5e-b701-4d82-895d-e87254e0f715"), "R.91.04", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("a3fb46f0-8de1-44a1-9ea9-cfd762ca28e9"), "R.92", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Gambling and betting activities" },
                    { new Guid("c7c71514-c08f-4355-acd7-6c20ef1b3d84"), "R.92.0", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Gambling and betting activities" },
                    { new Guid("38cdf12e-7aa7-4236-8360-01f4e47e30fb"), "R.92.00", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Gambling and betting activities" },
                    { new Guid("474119a4-e4dd-4340-ad09-20d1092ec3c4"), "R.93", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Sports activities and amusement and recreation activities" },
                    { new Guid("3659f5af-2de9-4910-aec6-50f7ba162488"), "R.93.1", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Sports activities" },
                    { new Guid("6601bb77-a191-40ad-856a-066a638c12fc"), "R.93.11", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Operation of sports facilities" },
                    { new Guid("db00b842-9d05-494e-86bc-0dfc692909a9"), "R.93.12", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Activities of sport clubs" },
                    { new Guid("9200438f-1bb2-42f2-b3ad-da641d62bb1c"), "R.93.13", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Fitness facilities" },
                    { new Guid("4fba8f75-be18-4190-b0fa-916ef13b0dd6"), "R.93.19", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Other sports activities" },
                    { new Guid("783cbfcd-19ae-430e-b1b6-164f8a927a05"), "R.93.2", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Amusement and recreation activities" },
                    { new Guid("172f2a0e-0a1a-466c-beb4-80807fd3d51e"), "R.93.21", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Activities of amusement parks and theme parks" },
                    { new Guid("b5627f0d-909c-46c7-99bb-4dbf0767e484"), "R.93.29", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Other amusement and recreation activities" },
                    { new Guid("b8a1cc4f-747d-48ce-ace0-3e960b08ac85"), "S.94", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of membership organisations" },
                    { new Guid("eea0a171-d392-496b-b201-8cd61ba6420d"), "S.94.1", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("87c8a7b5-d205-4297-89be-750062dcb8b8"), "S.94.11", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of business and employers membership organisations" },
                    { new Guid("48aad0a6-ff41-4e9e-a52b-48a5f74e53da"), "S.94.12", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of professional membership organisations" },
                    { new Guid("32698792-c81b-4581-aa94-6186855ebd16"), "S.94.2", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of trade unions" },
                    { new Guid("b5741b88-047d-4720-bbf1-d75d063302ce"), "S.94.20", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of trade unions" },
                    { new Guid("a3eb9b07-d307-4660-89b7-91aaa6cca71b"), "S.94.9", new Guid("ad67997d-a4c7-4b9a-bd9d-bb8283b80a89"), "Activities of other membership organisations" },
                    { new Guid("23bd49f6-acb1-4e42-a24e-014de865fdb0"), "R.90.01", new Guid("11c31533-c3c0-46f7-824c-92faa4140858"), "Performing arts" },
                    { new Guid("3602ac95-4a04-48d6-b82e-9c361e476e2b"), "K.65", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("731a4d69-0c7d-4ce2-af66-33ea52e372d9"), "N.82.9", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Business support service activities n.e.c." },
                    { new Guid("378dd445-6c14-4eac-8e96-685c14fe3ccc"), "N.82.3", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Organisation of conventions and trade shows" },
                    { new Guid("8cc2b86c-efe1-4f7c-a901-413966807a5e"), "M.70.1", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Activities of head offices" },
                    { new Guid("6ebeff29-ccaa-4c93-bd92-db5a7de840ad"), "M.70.10", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Activities of head offices" },
                    { new Guid("b4842b00-131a-4857-807b-e99c0a9a4e31"), "M.70.2", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Management consultancy activities" },
                    { new Guid("0652eb8e-f224-4fce-a872-a5378d9b2585"), "M.70.21", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Public relations and communication activities" },
                    { new Guid("fdb0adc7-931e-4293-a3c4-521a647d9b41"), "M.70.22", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Business and other management consultancy activities" },
                    { new Guid("c69e9061-9717-46cf-8e60-770df2634e7c"), "M.71", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("c8bd2120-0676-484b-a5ff-98839a5e9d35"), "M.71.1", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("d915b05a-d0f7-4c18-bcf4-53273f30cb9d"), "M.71.11", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Architectural activities" },
                    { new Guid("3d75109d-a609-4ec1-b212-e5761c8ffc84"), "M.71.12", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Engineering activities and related technical consultancy" },
                    { new Guid("cb37411c-71da-465f-890c-5679da6e30f7"), "M.71.2", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Technical testing and analysis" },
                    { new Guid("96221bf8-79c2-48fd-a27b-dc313972063f"), "M.71.20", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4e5bdc8f-1dba-42a2-ada2-ad94d9e6a968"), "M.72", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Scientific research and development" },
                    { new Guid("fded7aac-3fda-4714-89c2-f0033eeb0df4"), "M.70", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Activities of head offices; management consultancy activities" },
                    { new Guid("ffb51a80-a501-4dd9-a374-648c4e79ce52"), "M.72.1", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("65649799-51d6-4d0e-a117-21d510df2dd1"), "M.72.19", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("dbd13e59-d503-471a-aef1-c9cd39679ce7"), "M.72.2", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("6e2c6c74-d5c8-43a7-94fc-7cd52dcbcf09"), "M.72.20", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("a5ac770a-ae5f-4f6b-94c5-17574cfc4f43"), "M.73", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Advertising and market research" },
                    { new Guid("5a8ac2de-2246-45dc-ba56-342c84a56fa3"), "M.73.1", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Advertising" },
                    { new Guid("3292a324-8157-44b2-ada8-9598a74a65c6"), "M.73.11", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Advertising agencies" },
                    { new Guid("0537ba8b-6251-4884-93ca-b9ed7f5328a7"), "M.73.12", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Media representation" },
                    { new Guid("ac221c6d-ca67-4335-8f1b-e59240a829e9"), "M.73.2", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Market research and public opinion polling" },
                    { new Guid("2e326f83-8cb5-41ce-8d97-0811fa698530"), "M.73.20", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Market research and public opinion polling" },
                    { new Guid("76aff54b-4905-474a-89ae-e1df58c6bf46"), "M.74", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Other professional, scientific and technical activities" },
                    { new Guid("e8f86f6a-1a06-48bc-8dce-b13aac15a9b3"), "M.74.1", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Specialised design activities" },
                    { new Guid("86de7a0d-750b-477a-abb8-cf8ab184acb0"), "M.74.10", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Specialised design activities" },
                    { new Guid("9583eff2-24e0-4422-bc32-33a110d89076"), "M.72.11", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Research and experimental development on biotechnology" },
                    { new Guid("c53bf2ca-00fc-411e-a962-0a894c0e4bc7"), "M.69.20", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("09f9981b-9e76-4870-9964-3edc01bd553a"), "M.69.2", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("44efc2d1-383c-4c7a-b49d-6308b201bbd4"), "M.69.10", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Legal activities" },
                    { new Guid("5910162e-8b16-4c8d-a6ab-40d1b2f6a3de"), "K.65.11", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Life insurance" },
                    { new Guid("13566970-cb33-4f37-8fba-8348f6b5a60d"), "K.65.12", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Non-life insurance" },
                    { new Guid("0eb1aae4-25e2-4d2c-8588-57a02ef201de"), "K.65.2", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Reinsurance" },
                    { new Guid("79dbf1fe-1b31-4351-9ffe-4a7d9551273d"), "K.65.20", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Reinsurance" },
                    { new Guid("2ba485d3-f75a-4a85-ad8a-f72b9da6af38"), "K.65.3", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Pension funding" },
                    { new Guid("86e7dc5e-3ca0-46f2-9114-34f79c7c2349"), "K.65.30", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Pension funding" },
                    { new Guid("4b92b222-703c-484e-b3f5-e79bd9db38c5"), "K.66", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("60c63e13-4aa9-45d0-82a0-1c5047dacca4"), "K.66.1", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("a74f099b-d782-44f1-b169-ca7af5797696"), "K.66.11", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Administration of financial markets" },
                    { new Guid("1d2b3c78-8d75-455b-91d3-d0f503641d6b"), "K.66.12", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Security and commodity contracts brokerage" },
                    { new Guid("26c0e751-8245-4d1d-9735-1a6cbdece214"), "K.66.19", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("f7259661-d0c5-4540-9262-897a74caf30d"), "K.66.2", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("cf9086f4-427d-4819-afa7-ca4edc61f1dc"), "K.66.21", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Risk and damage evaluation" },
                    { new Guid("e2cb93e8-2b14-47f0-afbb-86381398494f"), "K.66.22", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Activities of insurance agents and brokers" },
                    { new Guid("6cc20cc9-27d3-4f57-8b0b-4c3a14e5fdad"), "K.66.29", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("4a09f6ad-9541-4486-8163-efcfaa648e15"), "K.66.3", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Fund management activities" },
                    { new Guid("acaa6361-e882-46f7-a087-0ddfd15d51cd"), "K.66.30", new Guid("ba6c12cf-a10e-4d44-8cb7-07d85660a6dd"), "Fund management activities" },
                    { new Guid("1205c672-5776-47d6-8d54-ba676fb654d8"), "L.68", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Real estate activities" },
                    { new Guid("ad83f0fa-ab52-4a31-959a-34f78d0c43b5"), "L.68.1", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Buying and selling of own real estate" },
                    { new Guid("58f6940f-5e47-436e-b7c8-1e28177b4499"), "L.68.10", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Buying and selling of own real estate" },
                    { new Guid("005024b8-aca4-4982-b37e-8e6023232fb0"), "L.68.2", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Renting and operating of own or leased real estate" },
                    { new Guid("af265d6c-cc7b-42bd-a50d-b24846cebeaa"), "L.68.20", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Renting and operating of own or leased real estate" },
                    { new Guid("6d213cbe-c22b-4c88-ad38-9cdee5c9a243"), "L.68.3", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0281dc54-df19-4b19-96df-553bc0532231"), "L.68.31", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Real estate agencies" },
                    { new Guid("ed88df8d-0e93-4b69-9333-24ca811491c7"), "L.68.32", new Guid("9483755a-bae7-4aab-a4a2-a18df3e3b793"), "Management of real estate on a fee or contract basis" },
                    { new Guid("555b2b5b-1425-4e31-973b-434999e55b42"), "M.69", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Legal and accounting activities" },
                    { new Guid("d47ba79d-6665-42e9-88e5-24404ba33740"), "M.69.1", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Legal activities" },
                    { new Guid("3f103c9f-d544-4b9e-9230-e7168a3337e9"), "M.74.2", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Photographic activities" },
                    { new Guid("4c99a6cc-ba3c-4e6a-810e-9d9e4f4b9139"), "N.82.30", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Organisation of conventions and trade shows" },
                    { new Guid("11dac285-1bb6-429f-8132-b5905817aa9f"), "M.74.20", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Photographic activities" },
                    { new Guid("33a5e283-009b-4a53-92d5-4a56318e21e1"), "M.74.30", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Translation and interpretation activities" },
                    { new Guid("2e248f45-4419-4a12-8af4-2815033e9bc4"), "N.79.11", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Travel agency activities" },
                    { new Guid("e0051876-528b-432e-acfc-8ac6e818399b"), "N.79.12", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Tour operator activities" },
                    { new Guid("93b5e748-b8d9-4bf2-bb78-2043f4d154f3"), "N.79.9", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other reservation service and related activities" },
                    { new Guid("4afb3ec6-e6a5-44cc-8fa9-4d5c91f4cfe1"), "N.79.90", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other reservation service and related activities" },
                    { new Guid("771ba553-f7d2-46fa-82ed-ecfb7d674bca"), "N.80", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Security and investigation activities" },
                    { new Guid("d123fd5d-0bf0-4ec0-bc28-6cb46d29f1e5"), "N.80.1", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Private security activities" },
                    { new Guid("c482667d-2c4f-4e95-98d7-4dde51726bdb"), "N.80.10", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Private security activities" },
                    { new Guid("6b15ca30-be02-43f7-9fef-08496dc4b426"), "N.80.2", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Security systems service activities" },
                    { new Guid("d44ffd7b-df2c-4b40-aff3-663c5368bf73"), "N.80.20", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Security systems service activities" },
                    { new Guid("95e750d0-6dc6-4527-bf80-eb932f375e01"), "N.80.3", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Investigation activities" },
                    { new Guid("334f529d-f8cf-46af-9cc7-0580d800fa02"), "N.80.30", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Investigation activities" },
                    { new Guid("c8cf662c-31ce-4b73-ba3f-67baa8617511"), "N.81", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Services to buildings and landscape activities" },
                    { new Guid("64f42381-4cef-46f9-ae3b-7c24c0fd849a"), "N.79.1", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Travel agency and tour operator activities" },
                    { new Guid("c3ded7c9-5ece-480a-8b6e-15eb1c329fe7"), "N.81.1", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Combined facilities support activities" },
                    { new Guid("0d780f31-f3ae-4bb6-a70a-f8f5eaa75083"), "N.81.2", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Cleaning activities" },
                    { new Guid("83befb5a-532d-49fc-9500-6dacd70f698c"), "N.81.21", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "General cleaning of buildings" },
                    { new Guid("85e0fe2f-16be-4878-be98-468b37a7de4f"), "N.81.22", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other building and industrial cleaning activities" },
                    { new Guid("6c95d2fb-8805-481d-b33e-d14c75a74c7f"), "N.81.29", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other cleaning activities" },
                    { new Guid("3c5a0fc4-b633-49ea-88fb-5b87e6ad7916"), "N.81.3", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Landscape service activities" },
                    { new Guid("210e0e6d-678a-4bb6-aabe-e087674f667e"), "N.81.30", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Landscape service activities" },
                    { new Guid("8a9e14c1-764b-4c64-9574-04fdbf76a14c"), "N.82", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Office administrative, office support and other business support activities" },
                    { new Guid("9c982302-862b-4af5-92aa-1d1da0185d01"), "N.82.1", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Office administrative and support activities" },
                    { new Guid("23f3ea75-9149-416d-abdc-297a52fd4ecb"), "N.82.11", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Combined office administrative service activities" },
                    { new Guid("93a04eeb-630e-40f6-8928-2fb0eef7eb10"), "N.82.19", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("57e1983d-7781-4551-b15a-6c62e57ec3fb"), "N.82.2", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Activities of call centres" },
                    { new Guid("eb448e68-fc7f-4e41-800c-73362e26947b"), "N.82.20", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Activities of call centres" },
                    { new Guid("6d7e964a-7b1e-4b68-858f-473c67f99598"), "N.81.10", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Combined facilities support activities" },
                    { new Guid("8f824fed-d96a-4b77-80e8-3bda85216411"), "N.79", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("3b986e25-9c3c-4422-804d-ce67f41a22f1"), "N.78.30", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other human resources provision" },
                    { new Guid("ee138f5e-3226-410d-a945-692d6e5b9e88"), "N.78.3", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Other human resources provision" },
                    { new Guid("357421ca-3321-47fd-877f-4b0a7803cc49"), "M.74.9", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("4da75769-d19e-4b8e-ad45-80b75fec7dbb"), "M.74.90", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("90812988-5427-4542-a97f-99b8d5f8a226"), "M.75", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Veterinary activities" },
                    { new Guid("ad1f04ec-8303-41f6-9643-a4f25e57a9b8"), "M.75.0", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6bc99063-8b8b-49d6-a18c-5b5aa4afa3bb"), "M.75.00", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Veterinary activities" },
                    { new Guid("29f38ed9-2b12-4477-a7bf-90a53220b47b"), "N.77", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Rental and leasing activities" },
                    { new Guid("9e7a2301-5e85-4994-b8ac-e7c9771a4c64"), "N.77.1", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of motor vehicles" },
                    { new Guid("63989773-5ea9-4705-91e9-47ff27177881"), "N.77.11", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("5252f0fe-a018-4ab2-b01b-da9eb1dd85cc"), "N.77.12", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of trucks" },
                    { new Guid("733d20ba-8de1-43b9-b830-d73588e4085f"), "N.77.2", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of personal and household goods" },
                    { new Guid("0d91d1f1-5544-40c3-91e4-9391db869fca"), "N.77.21", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("fb1a775b-4092-498f-9935-bf804973dae5"), "N.77.22", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting of video tapes and disks" },
                    { new Guid("41148464-4736-457f-8a79-f2c135308efc"), "N.77.29", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of other personal and household goods" },
                    { new Guid("c68090f8-dad7-47e6-8ccf-0dd334c4f9be"), "N.77.3", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("bea13687-daf9-4558-958d-e13f0eb5dcbe"), "N.77.31", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("2bcf103c-95e0-4cdf-a5a8-360e5ab17774"), "N.77.32", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("4c7a3ed8-4615-4593-aad9-5db316fcb817"), "N.77.33", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("e4289416-6813-49fa-8f7d-90ee73afb63d"), "N.77.34", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of water transport equipment" },
                    { new Guid("ec5f9bea-cdaa-4f0a-9efb-a16decef7529"), "N.77.35", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of air transport equipment" },
                    { new Guid("e7665509-bda1-410d-aaf8-55f524420377"), "N.77.39", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("81c9a2d9-e2fb-496b-a462-a80f0219caca"), "N.77.4", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("f3f29332-7db9-416e-a43d-d50bb9c84f0b"), "N.77.40", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("878f4727-fc4e-43ee-9a51-2c379f829e6b"), "N.78", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Employment activities" },
                    { new Guid("a3b1c555-5960-420d-b9da-c98bd31295f8"), "N.78.1", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Activities of employment placement agencies" },
                    { new Guid("21c14156-ebe6-45cf-825c-4fb8ca5e4efa"), "N.78.10", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Activities of employment placement agencies" },
                    { new Guid("8152bf36-3ab9-40b7-91d5-f5b9bef745b9"), "N.78.2", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Temporary employment agency activities" },
                    { new Guid("6ca458b6-cd23-405c-a187-2cb2b02eefa9"), "N.78.20", new Guid("d3319bca-1d5c-4677-813a-5a0f2a554f9f"), "Temporary employment agency activities" },
                    { new Guid("dd223485-a8e1-463a-b236-a3fca878ebb3"), "M.74.3", new Guid("70c63896-98b2-4074-858e-fd431396be24"), "Translation and interpretation activities" },
                    { new Guid("983d67e0-83a4-46bb-82b1-81b6dd2f2c8a"), "U.99.0", new Guid("bfd64441-c86b-4b14-9190-d01e19c7c164"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("ba554462-b339-473a-aee1-1a675a2dbd05"), "F.43.21", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Electrical installation" },
                    { new Guid("165a4323-5b08-412a-bb47-b4622d9052f2"), "F.43.13", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Test drilling and boring" },
                    { new Guid("0dd2fd8b-cefd-48c3-9d33-78b15f0cf912"), "C.14.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of articles of fur" },
                    { new Guid("ec9f0161-4e5e-4a05-a02b-472bdbebbecf"), "C.14.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of articles of fur" },
                    { new Guid("bad75984-6313-40b4-9d95-1b0c8c1316ac"), "C.14.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("41c3cbc0-60de-4028-a0e2-d13f0d75cf3c"), "C.14.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("0e517950-cb19-4cdc-966e-533144219d35"), "C.14.39", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("d2978940-4fa2-4dec-b34e-d7c530d68d15"), "C.15", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of leather and related products" },
                    { new Guid("0258af43-89f1-43d2-9973-ff81b66100f5"), "C.15.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("dfce3633-309e-4248-bf79-db7803bb209a"), "C.15.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("31931d5c-277b-4c8a-b852-c97fc001639e"), "C.15.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("29c62347-f9e5-4502-a07d-085bb121010d"), "C.15.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of footwear" },
                    { new Guid("09913d7b-9c47-4ecf-a6d5-f8bbbe047679"), "C.15.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of footwear" },
                    { new Guid("95c164c1-f6fc-4fca-9c72-50fa05b25847"), "C.16", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("676a29d8-5f82-4892-afc0-dae15127c139"), "C.14.19", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("7db93cfe-62d6-4a52-9cbc-ce4fbee583e2"), "C.16.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Sawmilling and planing of wood" },
                    { new Guid("baa524e1-253a-4eed-9cca-52cdfc62cd09"), "C.16.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("de789fed-a682-4963-b5a0-d32ea0b00e8c"), "C.16.21", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("af5b7e45-028a-4d4e-9525-e921436e66c1"), "C.16.22", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of assembled parquet floors" },
                    { new Guid("27e89d8d-58c6-4725-870b-f269afc2d316"), "C.16.23", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("3ab40198-8736-4947-8f2c-d62d467f285e"), "C.16.24", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wooden containers" },
                    { new Guid("69f0204d-269b-4953-b428-eacbb5f67927"), "C.16.29", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("77cfdd00-5e8a-4b4d-a766-c77abbb7c4db"), "C.17", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of paper and paper products" },
                    { new Guid("f9cd0f19-7ff0-4c66-b170-3dabff8bd139"), "C.17.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("3772fde0-1285-4913-afb9-40eef4b0d64c"), "C.17.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of pulp" },
                    { new Guid("ae81cffc-e0ff-4af8-80ad-a5855faf5f17"), "C.17.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of paper and paperboard" },
                    { new Guid("1fcd7977-e6c4-4733-a998-aaf97c0cba8f"), "C.17.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("d14189ce-500b-433b-a6d3-fcc744c631c6"), "C.17.21", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("66c951e5-6eac-4546-944d-c694eed2c880"), "C.16.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Sawmilling and planing of wood" },
                    { new Guid("138c4979-21c5-4c42-ab1d-907228a9fdf0"), "C.14.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of underwear" },
                    { new Guid("5a730594-ec82-4244-b080-a12483b86ac3"), "C.14.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other outerwear" },
                    { new Guid("fe5b2d8a-3e25-4ba6-b538-4e9a661e4713"), "C.14.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of workwear" },
                    { new Guid("a152b851-6faf-44f6-9769-88d7cf8ca7a6"), "C.11.02", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wine from grape" },
                    { new Guid("514be6dd-2220-40de-b795-68e734843b79"), "C.11.03", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cider and other fruit wines" },
                    { new Guid("78b7b09d-81b4-43d3-af19-e1986eff96c1"), "C.11.04", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("aa0e0817-8da3-46e1-8309-83a796bba300"), "C.11.05", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of beer" },
                    { new Guid("8b78571d-5f41-456f-b761-b13cd6289921"), "C.11.06", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of malt" },
                    { new Guid("3e0db320-148e-45f6-926d-5fa991d58ea3"), "C.11.07", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("be0bf7c7-78d9-4e49-b05c-44cc38305b4f"), "C.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tobacco products" },
                    { new Guid("ef60b581-2586-4f17-ab03-73f1279de308"), "C.12.0", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tobacco products" },
                    { new Guid("e6c7b05b-ebd0-45f9-ae09-5fcd80af3249"), "C.12.00", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tobacco products" },
                    { new Guid("6a0994fa-c301-4749-b647-1da861aac563"), "C.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of textiles" },
                    { new Guid("f5889f48-c4d2-40cb-926d-69e262589009"), "C.13.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Preparation and spinning of textile fibres" },
                    { new Guid("2d08d32f-f343-4c0e-8b58-892cb0c34a10"), "C.13.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Preparation and spinning of textile fibres" },
                    { new Guid("3244402b-1bd2-4536-899d-e513523fcf88"), "C.13.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Weaving of textiles" },
                    { new Guid("e0e3895c-f587-4460-bc64-7dd9c265b7ab"), "C.13.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Weaving of textiles" },
                    { new Guid("2f67b430-7f04-49e6-9fa1-1025c67c16d3"), "C.13.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Finishing of textiles" },
                    { new Guid("668568ba-63c2-418c-9108-15cd64733b84"), "C.13.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Finishing of textiles" },
                    { new Guid("c3514065-44ca-48d6-bc91-d191141c5aa6"), "C.13.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other textiles" },
                    { new Guid("03afe9af-7b87-4665-a39e-9130ae6d6408"), "C.13.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("962dd88b-dc06-4f45-8de3-8a4821598591"), "C.13.92", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("294c0bfc-a434-4ead-b53a-278d7796728e"), "C.13.93", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of carpets and rugs" },
                    { new Guid("49d511d0-88f9-4f5b-a8aa-97946a233940"), "C.13.94", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("2c5db6b5-2f2c-453c-a889-8b3274c56bb9"), "C.13.95", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("d985492d-7b17-4b6d-8ef7-00b59fa4b4f5"), "C.13.96", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("a67530a1-281f-4ef6-a3fa-7da1478bd018"), "C.13.99", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other textiles n.e.c." },
                    { new Guid("2bc96364-2b4a-44d5-9677-335af4c2530b"), "C.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wearing apparel" },
                    { new Guid("b80d2223-e4f4-47f4-8636-1fc28ab57f57"), "C.14.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("8099ea9b-f5b1-4473-9299-cc61f50d0eb6"), "C.14.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0a25447a-67ad-4638-b06e-83d40b29f96e"), "C.17.22", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("fbb72deb-648c-41f7-944e-1ee75f4eee9a"), "C.11.01", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("d35aa2f2-965e-4906-a522-8488214233e6"), "C.17.23", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of paper stationery" },
                    { new Guid("9a8f4b5f-230e-4a9d-b1c3-43a6c185838c"), "C.17.29", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("89bb3dc3-8b42-49f6-a212-513fe100f411"), "C.20.52", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of glues" },
                    { new Guid("360b42da-ec53-4d93-a37e-a1ea5c82fb7b"), "C.20.53", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of essential oils" },
                    { new Guid("a8bd8526-3b2e-42f1-be30-5784b925958c"), "C.20.59", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("802e3818-3df2-4138-97f8-48e6062aca71"), "C.20.6", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of man-made fibres" },
                    { new Guid("5baa02c2-c819-465a-8400-4c95f3fdf5a0"), "C.20.60", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of man-made fibres" },
                    { new Guid("298dce45-c852-4404-8adc-88528e7c3472"), "C.21", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("aedbfd85-a9e6-4605-b11a-791574b7217e"), "C.21.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("eb5faccd-74b2-414c-b665-adffa4d784be"), "C.21.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("e8393ae3-a118-4e7c-8874-cd95b93b54bb"), "C.21.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("1a56850c-6fc8-4eb7-a3b2-3b952f330804"), "C.21.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("9a1789c9-cb32-470b-af44-52415f7d6e8f"), "C.22", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of rubber and plastic products" },
                    { new Guid("7b5c27a9-3d7c-4549-86d3-0b036e7c1b86"), "C.22.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of rubber products" },
                    { new Guid("9705aeef-dc83-4eb0-8427-882d7c03feac"), "C.20.51", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of explosives" },
                    { new Guid("935d62d4-1fa9-4d9e-95cf-d711a3dbf90a"), "C.22.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("ecdbf37f-4ee1-4d5f-8467-c2f83312550e"), "C.22.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of plastics products" },
                    { new Guid("962abf13-169b-4606-b762-994a759d6b00"), "C.22.21", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("ff94a5f5-921d-4e6f-ae8d-d4bbae93ef5c"), "C.22.22", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of plastic packing goods" },
                    { new Guid("61e7f090-98ce-4f87-88f0-bb220a2d8075"), "C.22.23", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("248bc4c6-bafd-4026-bbff-1ca2564f90ae"), "C.22.29", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other plastic products" },
                    { new Guid("a019f699-0311-4dc6-86d5-8793e152d88f"), "C.23", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("2d82a5da-f475-49b8-9082-5da6f72b773f"), "C.23.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of glass and glass products" },
                    { new Guid("51aa600f-00be-451e-b1b3-047e752d1a10"), "C.23.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of flat glass" },
                    { new Guid("d35e9c94-8e3e-4f8d-8b0b-4fa5a66a8a64"), "C.23.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Shaping and processing of flat glass" },
                    { new Guid("cf4092b1-8765-45d4-aab7-d729b27e1515"), "C.23.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of hollow glass" },
                    { new Guid("f0dc244c-105f-4470-abf1-f4b37acdb222"), "C.23.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of glass fibres" },
                    { new Guid("ce8876c4-5504-4be7-82ab-88a510f2d73a"), "C.23.19", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("3c5b42ed-a075-4609-a39f-a0d5a0fbb72e"), "C.22.19", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other rubber products" },
                    { new Guid("c6fe4aba-e2ca-4476-bab8-9478bb60f882"), "C.20.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other chemical products" },
                    { new Guid("d87f7771-6921-4852-8fac-da6122a75eeb"), "C.20.42", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("c2785b15-febe-46b6-a9a8-4bf019494900"), "C.20.41", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("bef1f274-afdc-4484-afc9-f778039498d8"), "C.18", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Printing and reproduction of recorded media" },
                    { new Guid("b05a9bc9-69a7-4533-b2d2-99fc985ffbac"), "C.18.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Printing and service activities related to printing" },
                    { new Guid("d6acf909-766d-4207-ba7f-34f7c44a15a6"), "C.18.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Printing of newspapers" },
                    { new Guid("631c7778-91ec-416b-b01d-8051b45ccd6b"), "C.18.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Other printing" },
                    { new Guid("83cb01b1-e6a0-4509-8f36-c7a68ec514c1"), "C.18.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Pre-press and pre-media services" },
                    { new Guid("6c5ca487-093a-4c00-b18b-05d14695c983"), "C.18.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Binding and related services" },
                    { new Guid("48f8a6f1-5785-44af-b5f2-31a11b00dcd8"), "C.18.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Reproduction of recorded media" },
                    { new Guid("0e9454a5-faa0-4ece-a575-f287488f1959"), "C.18.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e115142f-6ae1-41be-9758-7f25242b8be7"), "C.19", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("f9a0281d-821c-4943-81d9-2f55049dfa9c"), "C.19.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of coke oven products" },
                    { new Guid("39eacb59-bab8-4b84-be15-154f0c121abe"), "C.19.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of coke oven products" },
                    { new Guid("cce294d0-5659-402a-b2be-995fd5ac13c3"), "C.19.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of refined petroleum products" },
                    { new Guid("215d50f0-9f9d-4df2-b170-9a4d77dd4213"), "C.19.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of refined petroleum products" },
                    { new Guid("da8504b9-7f8f-40b8-9153-fef3a67e9081"), "C.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of chemicals and chemical products" },
                    { new Guid("3bb22744-3004-4456-ba2a-67dc3a76a2f9"), "C.20.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("06d27cad-df44-4908-8bde-f60f0b84ee74"), "C.20.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of industrial gases" },
                    { new Guid("38d47cf0-9e93-443b-82af-5c102212bff0"), "C.20.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of dyes and pigments" },
                    { new Guid("6ea98935-d723-4276-b348-c5ba97b1804f"), "C.20.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("1ef10fbc-a396-411a-8935-e4f6a62784dd"), "C.20.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other organic basic chemicals" },
                    { new Guid("c1d8019c-8379-4ea9-836f-ed4e91dc336f"), "C.20.15", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("d3947714-9da8-4120-a097-6007a177d296"), "C.20.16", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of plastics in primary forms" },
                    { new Guid("64704719-038b-48f8-8d54-60208b6790f1"), "C.20.17", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("72d6a34e-3c39-4406-9c80-a4ff10e30be8"), "C.20.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("e875cb42-717b-42d9-a8f5-3d6f96247697"), "C.20.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("8b1869d4-7207-4a31-b444-37f717025114"), "C.20.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("1c9e5248-b60a-4221-b47d-5138838aeccc"), "C.20.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("e3380b4d-cb6f-4738-b0a1-48bb1d9992db"), "C.20.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("8bd897aa-56b4-414d-bcfe-e3364052193e"), "C.17.24", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wallpaper" },
                    { new Guid("b3bb8158-f378-44e7-abdc-401ffbb39869"), "C.23.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of refractory products" },
                    { new Guid("96f4040e-2fc6-4350-a75c-01b248fb8a6e"), "C.11.0", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of beverages" },
                    { new Guid("3662f8b9-aea6-48ef-b29d-801a113a19e7"), "C.10.92", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of prepared pet foods" },
                    { new Guid("77c5c416-025b-414c-a4f9-163eb30e7643"), "A.01.6", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("11649794-b935-4abf-904e-6712d66cd8b7"), "A.01.61", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Support activities for crop production" },
                    { new Guid("ea403c65-f5d3-4471-bae6-7dde93d6c97e"), "A.01.62", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Support activities for animal production" },
                    { new Guid("b70f1bb2-1030-4b39-acbd-392b4aaf78fe"), "A.01.63", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Post-harvest crop activities" },
                    { new Guid("a2dd26c1-3603-445b-ade3-5760715c58cf"), "A.01.64", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Seed processing for propagation" },
                    { new Guid("312f3adc-a395-4e76-89a8-a80f588f0240"), "A.01.7", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Hunting, trapping and related service activities" },
                    { new Guid("0dde153e-acdd-41e5-9c20-4040aea832ce"), "A.01.70", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Hunting, trapping and related service activities" },
                    { new Guid("57036567-8d2d-47cf-ab24-6311875cb7a1"), "A.02", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Forestry and logging" },
                    { new Guid("b9e8509a-15a5-43cf-b0f7-90f45e8e9941"), "A.02.1", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Silviculture and other forestry activities" },
                    { new Guid("56d0fd7b-c9c4-46d6-a6ff-6071dd61d7de"), "A.02.10", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Silviculture and other forestry activities" },
                    { new Guid("bc10d442-c4c0-41ed-81c2-ffa8693f7be2"), "A.02.2", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Logging" },
                    { new Guid("3df1967f-1e2c-43d4-aee1-a30643ba5768"), "A.02.20", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Logging" },
                    { new Guid("d42fdf89-23c4-49ff-b475-9f9152658d04"), "A.01.50", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Mixed farming" },
                    { new Guid("b7e66154-26fb-4ca0-b512-583974b747b4"), "A.02.3", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Gathering of wild growing non-wood products" },
                    { new Guid("8508d702-562d-490b-98c9-611325b14207"), "A.02.4", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Support services to forestry" },
                    { new Guid("e90a4b63-3a95-47c8-8b2b-88a925c9ffcf"), "A.02.40", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Support services to forestry" },
                    { new Guid("c71c1a0d-5b96-497a-95d9-c56f5e2fab9e"), "A.03", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Fishing and aquaculture" },
                    { new Guid("9c9f0603-6802-44cb-a8f7-f9c22c66c3e3"), "A.03.1", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Fishing" },
                    { new Guid("63f76088-bc01-4115-9049-1745c19725b4"), "A.03.11", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("94d46619-5bbf-4925-8c23-2ed4e3373a86"), "A.03.12", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Freshwater fishing" },
                    { new Guid("f95208b5-82a6-4a40-8e84-e53f2bbbf79d"), "A.03.2", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Aquaculture" },
                    { new Guid("08585e7d-7717-420b-b650-9b8a9d3b1d0f"), "A.03.21", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Marine aquaculture" },
                    { new Guid("b20e8161-d942-4115-929e-54607b4958ee"), "A.03.22", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Freshwater aquaculture" },
                    { new Guid("d66a73be-ae66-44ff-a21f-b42b038f10c0"), "B.05", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of coal and lignite" },
                    { new Guid("d878df4f-6505-41cc-a104-7b6516e8c223"), "B.05.1", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of hard coal" },
                    { new Guid("357579ab-66b0-4e11-8a6f-1b1f2bd39f9c"), "B.05.10", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of hard coal" },
                    { new Guid("adb32b35-d207-498f-9fd0-e490c4099b19"), "A.02.30", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Gathering of wild growing non-wood products" },
                    { new Guid("be5d8569-edfc-41d7-a5e5-fbeb0533eb9e"), "A.01.5", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Mixed farming" },
                    { new Guid("2d613a22-3e1a-4d94-9d12-65454f2f7fa5"), "A.01.49", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of other animals" },
                    { new Guid("674b86ea-c5c3-47b5-b88a-445106099c48"), "A.01.47", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of poultry" },
                    { new Guid("58a84719-6b53-4660-8b7b-0c8f73bffe4c"), "A.01.1", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of non-perennial crops" },
                    { new Guid("0f0c4911-1c98-4103-8fd4-362eb081dba3"), "A.01.11", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("028ccaa9-8493-46b0-be24-c54bf7de19a3"), "A.01.12", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of rice" },
                    { new Guid("2b6e9a9f-2da8-4dc4-a458-53aa0e55a852"), "A.01.13", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("bdfbcd16-9490-4036-a77b-418eff723372"), "A.01.14", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of sugar cane" },
                    { new Guid("4b443135-57d1-4258-a1e9-e4d3e9fd4c8e"), "A.01.15", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of tobacco" },
                    { new Guid("22f0ecfd-16db-4e65-ae72-d405bca9610b"), "A.01.16", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of fibre crops" },
                    { new Guid("6a8edf9e-a15f-4ee0-a973-9c5a1b8f59a9"), "A.01.19", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of other non-perennial crops" },
                    { new Guid("24f0b00f-1d02-427c-bb3d-86710f336a08"), "A.01.2", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of perennial crops" },
                    { new Guid("850f220f-cc9d-4c96-ab82-7eb0776a3b17"), "A.01.21", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of grapes" },
                    { new Guid("0f82eb7b-1742-45e7-aa80-e8a53c013c6a"), "A.01.22", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of tropical and subtropical fruits" },
                    { new Guid("02a2f316-685e-4819-a3ab-b470c94179d8"), "A.01.23", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of citrus fruits" },
                    { new Guid("f1707e7a-4d92-4dff-b11c-44214e1a5d49"), "A.01.24", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of pome fruits and stone fruits" },
                    { new Guid("610e124e-fce9-4186-afae-2fa74c007874"), "A.01.25", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("bd42c4c0-b90f-4ae6-a952-af3ffe6015fd"), "A.01.26", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of oleaginous fruits" },
                    { new Guid("40f61b15-c621-49cb-9070-ef647bda1074"), "A.01.27", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of beverage crops" },
                    { new Guid("ce0ed80a-c456-45a5-bc3f-b7aedd90e6d2"), "A.01.28", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("421a7abf-3a54-4d02-82ac-c38c4c7064da"), "A.01.29", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Growing of other perennial crops" },
                    { new Guid("d2cda624-6fd5-4302-8641-9c71dd233eba"), "A.01.3", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Plant propagation" },
                    { new Guid("4453d6af-4afe-43b8-8eea-0a6c5d88b04c"), "A.01.30", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Plant propagation" },
                    { new Guid("e449e08f-606e-43fe-9e66-4e1a9f8e1d9b"), "A.01.4", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Animal production" },
                    { new Guid("3d85d4cd-9f22-4deb-b70e-1afa8cb9c9b4"), "A.01.41", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of dairy cattle" },
                    { new Guid("7b5b9a6d-efec-4cf2-94ca-bc1e76a6fc1a"), "A.01.42", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of other cattle and buffaloes" },
                    { new Guid("5a7de1c3-dd4b-4930-980d-256bf2e4d036"), "A.01.43", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of horses and other equines" },
                    { new Guid("a127e37f-0d2e-4957-8a37-3246ca470338"), "A.01.44", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of camels and camelids" },
                    { new Guid("4cdd9c6b-9a41-42d1-86af-c69eaea922e2"), "A.01.45", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of sheep and goats" },
                    { new Guid("a8c20bea-1296-4cad-9756-ff52e7c7e21f"), "A.01.46", new Guid("cda51936-ba2b-43ac-ab53-b6246d025d2e"), "Raising of swine/pigs" },
                    { new Guid("973c9a02-2e6d-4fc5-b8fe-abea745e0dc0"), "B.05.2", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of lignite" },
                    { new Guid("0fc8a840-3fc8-4488-9122-e7a766de1ee6"), "C.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of beverages" },
                    { new Guid("04561fda-e830-489b-84be-629064678839"), "B.05.20", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of lignite" },
                    { new Guid("358cb01b-3c1a-47d1-b301-c7ae707a3751"), "B.06.1", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fdc6169d-d393-4b7b-84ef-979b1f227675"), "C.10.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of potatoes" },
                    { new Guid("3a7c555f-c45e-47da-bde2-2bd734de18b8"), "C.10.32", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("fe9ef7c9-505c-4adf-a723-812431686293"), "C.10.39", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("7a767273-59ed-413f-8573-4e54213dfbed"), "C.10.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("1b4f3f9d-d48b-4e36-b242-59dd4a079774"), "C.10.41", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of oils and fats" },
                    { new Guid("47843ba3-0d1f-464c-91a6-bf4918590325"), "C.10.42", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("9c213abf-904f-45d8-87f5-ed6397b5ff4f"), "C.10.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of dairy products" },
                    { new Guid("a0fddc71-2388-4dcb-9d5f-c2e286c38f2b"), "C.10.51", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Operation of dairies and cheese making" },
                    { new Guid("225821fb-a1ce-4ce9-b34e-4413352d4902"), "C.10.52", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ice cream" },
                    { new Guid("f0bf88b6-dbf1-4e0b-b313-8aa856a43698"), "C.10.6", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("a354021b-0b62-43a4-93ee-e55e1fcb18fa"), "C.10.61", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of grain mill products" },
                    { new Guid("cf7af61f-1abf-40bb-ab4a-185abd9a7c34"), "C.10.62", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of starches and starch products" },
                    { new Guid("8db77311-f293-47fb-b5e9-130d1fdc454e"), "C.10.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("ced12ec0-a2ab-40e7-81fb-8b4e2ac30cec"), "C.10.7", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("08240959-3fe6-4e81-8b67-19fd179e83af"), "C.10.72", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("fd2015b9-c2e9-4814-8444-c2f161d26b2e"), "C.10.73", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("14b47e01-a098-4a70-b643-e5042d2e28b3"), "C.10.8", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other food products" },
                    { new Guid("067c0724-7376-4088-b53a-54f86f480e08"), "C.10.81", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of sugar" },
                    { new Guid("8069f63a-f77f-4278-bbb4-3e0a84d45d3e"), "C.10.82", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("a2780950-0d0f-4183-bc67-c86dc75ea32f"), "C.10.83", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing of tea and coffee" },
                    { new Guid("f64b6acc-5b01-477f-a7c1-ba2a0fb3a271"), "C.10.84", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of condiments and seasonings" },
                    { new Guid("ceaba2ba-3e28-44b9-9d26-56e13f6c8c81"), "C.10.85", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of prepared meals and dishes" },
                    { new Guid("18622b5b-dc64-4cd0-a361-c68c2a1d69bb"), "C.10.86", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("053ee09b-2c7a-4f70-839f-1012c6af4e0c"), "C.10.89", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other food products n.e.c." },
                    { new Guid("c278a565-b73b-4274-9b1c-581bb9b2707b"), "C.10.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of prepared animal feeds" },
                    { new Guid("f727ac31-d32d-46da-b4cb-e2ab676b5596"), "C.10.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("f7e2a4b8-896b-4d3a-b9e5-570bb02a1c9b"), "C.10.71", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("0470168e-d6cc-4120-b4b0-87dbb89cd2ca"), "C.10.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("562f6d7a-7672-4c98-a843-5dcb7d42ebfa"), "C.10.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("1a877bac-8ddf-4dfa-a6ee-ab5fd5fd0316"), "C.10.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Production of meat and poultry meat products" },
                    { new Guid("76f3ee9e-76c4-4727-9ae9-4162c664c9a2"), "B.06.10", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of crude petroleum" },
                    { new Guid("544b1ae7-c8e9-42c6-b85b-eebdb33a843d"), "B.06.2", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of natural gas" },
                    { new Guid("152cf8ac-8d3d-4371-ba73-194bf331f45e"), "B.06.20", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of natural gas" },
                    { new Guid("6fc3fe19-37f6-4fc4-9571-a246990d6b58"), "B.07", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of metal ores" },
                    { new Guid("934dbec4-b1f6-4392-a55a-a615d3739a8b"), "B.07.1", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of iron ores" },
                    { new Guid("3c540f43-779e-404d-baca-82a2096c00a7"), "B.07.10", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of iron ores" },
                    { new Guid("b6344c14-dcbf-4eca-88c4-01d358bd06cf"), "B.07.2", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of non-ferrous metal ores" },
                    { new Guid("1e368299-fbbd-4495-81e7-2b25068e6b86"), "B.07.21", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of uranium and thorium ores" },
                    { new Guid("dcf7b1c3-6255-4fea-a6dd-025419fe8770"), "B.07.29", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of other non-ferrous metal ores" },
                    { new Guid("a6565817-a3b1-49e5-b3a3-9bbbb54280bf"), "B.08", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Other mining and quarrying" },
                    { new Guid("28b7a617-575f-42e0-b49a-f184dbf6cc82"), "B.08.1", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Quarrying of stone, sand and clay" },
                    { new Guid("66061853-6cda-4f1b-8a45-963bb0e9c960"), "B.08.11", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("cd426ba2-9d41-4875-ba8c-445b196c24a1"), "B.08.12", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("8dce0c39-751e-41ae-9353-296ee782a8e0"), "B.08.9", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining and quarrying n.e.c." },
                    { new Guid("9a216d28-dee9-423c-b722-715fa571f1c9"), "B.08.91", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("5c4dd93c-84bc-4a9d-ba35-b58670221b37"), "B.08.92", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of peat" },
                    { new Guid("4da8e2f1-f4ac-413d-83f1-01d7b5f58dad"), "B.08.93", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of salt" },
                    { new Guid("867d8a32-b49e-4b78-bf9e-8d266607c550"), "B.08.99", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Other mining and quarrying n.e.c." },
                    { new Guid("c21c6d86-e341-484e-91d0-c1fb28b7ec77"), "B.09", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Mining support service activities" },
                    { new Guid("dfdb58f0-930e-47d3-98b0-6d0745c01fcc"), "B.09.1", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("17520525-7e0a-4af2-8b49-79f3b0c862c5"), "B.09.10", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("d9e143b5-50f7-4cad-9b89-4cd127ea1816"), "B.09.9", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Support activities for other mining and quarrying" },
                    { new Guid("9ec8a851-ce32-4caf-871b-0166a2967ab7"), "B.09.90", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Support activities for other mining and quarrying" },
                    { new Guid("c61e4f0f-1916-47c7-a4e0-a508b2a8a6ae"), "C.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of food products" },
                    { new Guid("1c202e00-511d-4dcb-8ff7-6b8634d0ff81"), "C.10.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("6e5821e9-e9d9-47b7-bde7-e8031054af23"), "C.10.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of meat" },
                    { new Guid("284045fe-686e-45e4-83b3-c256749ad38e"), "C.10.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing and preserving of poultry meat" },
                    { new Guid("8f55c6d7-270a-4ea5-8f08-2f6e14ae9892"), "B.06", new Guid("1d0949f7-1dff-4910-bde8-55c5149de11f"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("46904aab-266e-47e5-97ea-82c2ce2bb2ef"), "F.43.2", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("cc54a2eb-d243-48ce-832f-9fd0049ce0b4"), "C.23.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of refractory products" },
                    { new Guid("6867e701-c5c9-41bc-96a5-9f9f4ba5a20e"), "C.23.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("df40f6ac-a72a-4bc0-a6c5-a8afc26271f9"), "C.30.92", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("4b65623d-97a9-4737-bdac-8e052efff8a4"), "C.30.99", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("b9de92e9-8dfe-4f2e-87fa-aadd8aa0066f"), "C.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of furniture" },
                    { new Guid("8202c5b8-831b-4f6c-bd21-d8ebbbbcbf3b"), "C.31.0", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of furniture" },
                    { new Guid("e1acf72c-a3eb-4dd8-a9c8-ff65a45db4ee"), "C.31.01", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of office and shop furniture" },
                    { new Guid("7cfc8527-e4f6-4c2b-a76d-d95477d92546"), "C.31.02", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of kitchen furniture" },
                    { new Guid("639e1005-d259-451a-8041-2a705c61f189"), "C.31.03", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of mattresses" },
                    { new Guid("3586c51b-24a1-4e54-82a2-7f6f97f756ea"), "C.31.09", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other furniture" },
                    { new Guid("3968460e-d8cb-497b-a667-cfe45ea112a6"), "C.32", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Other manufacturing" },
                    { new Guid("94a5ec91-f9e8-47d5-819f-652a3be0e348"), "C.32.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("4ba24b2d-c2bd-486b-9547-7834eebb3e7e"), "C.32.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Striking of coins" },
                    { new Guid("ba35f4da-95c6-42d2-8d09-ba12339a4ced"), "C.32.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of jewellery and related articles" },
                    { new Guid("7a6d1652-a8f7-4852-96c3-cadba4b84980"), "C.30.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of motorcycles" },
                    { new Guid("abeb4fa4-c9e6-40b5-a63b-867531024302"), "C.32.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("9399e961-60e3-487f-8e1c-a06759f9bac2"), "C.32.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of musical instruments" },
                    { new Guid("b0e8e3f7-4265-4e0d-94dd-1a01c828e139"), "C.32.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of sports goods" },
                    { new Guid("2cd7b298-eb7e-4900-8c7d-20c093e33d8d"), "C.32.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of sports goods" },
                    { new Guid("9107ad0c-17b3-4277-bd41-9852bc4493e4"), "C.32.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of games and toys" },
                    { new Guid("ecfffc4b-d3fb-420a-98ae-eb34110f9d98"), "C.32.40", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of games and toys" },
                    { new Guid("6acccf17-260a-4d81-8bb5-491b5789d5e4"), "C.32.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("def3767b-c031-4df9-bdb2-823ee6b98282"), "C.32.50", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("3e02cb2e-fd03-4e51-8341-57619fd3aa06"), "C.32.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacturing n.e.c." },
                    { new Guid("1e736cb7-fc7d-473e-92f5-948d8a8acbb1"), "C.32.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("efd53d52-cf6f-4a0a-8d1f-5671b2a9dd9b"), "C.32.99", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Other manufacturing n.e.c." },
                    { new Guid("bbd03dc8-7a26-47f3-8b11-afa46ba659a4"), "C.33", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair and installation of machinery and equipment" },
                    { new Guid("326aa5e7-eedd-4312-9aad-c921f1af394a"), "C.33.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("cb01a855-c427-440e-ae91-3de011a197e5"), "C.32.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of musical instruments" },
                    { new Guid("b9ec5fd1-4d7a-4543-92a5-b06a85d716ea"), "C.30.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("690544a0-2b25-4801-a3ac-bb915f926769"), "C.30.40", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of military fighting vehicles" },
                    { new Guid("07c487a9-b74a-4a37-ad4b-c7964ea20c18"), "C.30.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of military fighting vehicles" },
                    { new Guid("64ac1b67-4dae-4dd4-afd9-c93aa62f4e62"), "C.28.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("ba850d22-a67c-4e2c-a006-2fbccd4cb5dd"), "C.28.41", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of metal forming machinery" },
                    { new Guid("cc64e7aa-df9f-48ec-a8fa-294a83d3b972"), "C.28.49", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other machine tools" },
                    { new Guid("f36efc2b-ff5d-4776-accf-db855cc3fece"), "C.28.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other special-purpose machinery" },
                    { new Guid("4a147a05-f4eb-4b27-adf8-d585c259c1ed"), "C.28.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of machinery for metallurgy" },
                    { new Guid("3b2e8cbe-479d-40a9-a524-bf46987de621"), "C.28.92", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("59888920-b848-4ae5-9897-2333972e5bb1"), "C.28.93", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("aa22d33c-82e0-4010-bfba-fe5399177066"), "C.28.94", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("986448ea-e29d-40eb-9fc5-0c8e3783c55a"), "C.28.95", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("afba3647-8801-4bd8-a26c-a9649e4d2770"), "C.28.96", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("3eee0617-0c74-4288-8308-14a6e539a853"), "C.28.99", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("7a19943f-286b-412c-9803-4b3e2a434b2a"), "C.29", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("2d2fdeb5-3843-4d8c-8487-ab5ad1ccfe1e"), "C.29.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of motor vehicles" },
                    { new Guid("3dfdae97-fcb0-4b6b-9cc6-0b43104cf568"), "C.29.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of motor vehicles" },
                    { new Guid("9b9a9570-1411-47ef-8039-7b8d929fcb4f"), "C.29.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("00a81100-9135-47cb-8aee-ff5ac784b971"), "C.29.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("14c46639-da2f-4c17-9c69-04b2bc7d2404"), "C.29.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("22a1dac7-f018-4f70-a96e-e37c2647749d"), "C.29.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("de528445-47b1-4d0b-a5d2-d7242c5750cf"), "C.29.32", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("5beb2699-f2c0-4854-8069-593979f9fef7"), "C.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other transport equipment" },
                    { new Guid("1f721c31-6a6c-46ec-a552-d9224e6589ab"), "C.30.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Building of ships and boats" },
                    { new Guid("18c25c9b-d032-4af9-9256-4c0831055b1c"), "C.30.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Building of ships and floating structures" },
                    { new Guid("2b43cd48-f479-47a3-af0c-fbf0a7e40399"), "C.30.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Building of pleasure and sporting boats" },
                    { new Guid("fc92a9cc-ff13-4af2-9370-7ab3b38a4124"), "C.30.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("91e29391-1ed4-4402-95d4-ed9272f32f6e"), "C.30.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("ad1f73b5-dddf-4652-9ca7-a8ffef6d990e"), "C.30.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("38eeb6b0-9ec4-44a9-87b4-c046e6d6e265"), "C.30.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("b11d3667-7601-489e-a075-042f937e0597"), "C.33.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair of fabricated metal products" },
                    { new Guid("ff2aeeb2-1b01-43df-9ab9-6c2626ac8a4e"), "C.28.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("494c579d-f4e8-4620-9730-542eec5fe5f5"), "C.33.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair of machinery" },
                    { new Guid("cfe17744-9734-4494-869e-05f32238d78f"), "C.33.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair of electrical equipment" },
                    { new Guid("46db9363-c9d9-42da-b5c2-3b6cc76a335b"), "E.38.3", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Materials recovery" },
                    { new Guid("6ce91527-6060-4bc4-82a8-e949533d7da0"), "E.38.31", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Dismantling of wrecks" },
                    { new Guid("b748e8bf-e3a0-412d-a205-9207df1b06aa"), "E.38.32", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Recovery of sorted materials" },
                    { new Guid("795afea4-227c-4d41-8259-fa995acc2d2a"), "E.39", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f4838d6f-db87-4932-82aa-a6a669df5be1"), "E.39.0", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Remediation activities and other waste management services" },
                    { new Guid("267e72af-3088-4df2-8634-077db8cec97f"), "E.39.00", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Remediation activities and other waste management services" },
                    { new Guid("c676d3a6-45a4-4785-9c20-c6a9c0a325f6"), "F.41", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of buildings" },
                    { new Guid("b300ad01-9c0b-4f74-bbc3-6c055f1a3711"), "F.41.1", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Development of building projects" },
                    { new Guid("351a5149-1daa-4120-a7ff-6d6b6723d222"), "F.41.10", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Development of building projects" },
                    { new Guid("0e485623-a169-43ba-840a-016f1cf3c527"), "F.41.2", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of residential and non-residential buildings" },
                    { new Guid("2a8cd3bb-0ac7-4c89-9bd6-387b7dab4e3a"), "F.41.20", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of residential and non-residential buildings" },
                    { new Guid("746bfd93-caef-4ae7-8bca-7e1f67828f82"), "F.42", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Civil engineering" },
                    { new Guid("04f544c4-cfe0-4cab-9118-cc2e39bc8058"), "E.38.22", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Treatment and disposal of hazardous waste" },
                    { new Guid("bc7aa12d-af2a-4877-86b9-acf9f6e46c58"), "F.42.1", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of roads and railways" },
                    { new Guid("8c099d34-ac9b-4dfb-81ac-f364ef71ba93"), "F.42.12", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of railways and underground railways" },
                    { new Guid("8ac29bcb-fae4-4f17-812d-bbc539310f67"), "F.42.13", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of bridges and tunnels" },
                    { new Guid("86104ade-38df-488e-8455-5c192830ccf4"), "F.42.2", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of utility projects" },
                    { new Guid("60329afa-d71a-467e-90bf-9d67b0ed7756"), "F.42.21", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of utility projects for fluids" },
                    { new Guid("3ebdb4d6-1ce3-423d-8c80-426100412a7f"), "F.42.22", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("0260118c-71d3-4dab-86e3-5abcbd456e0e"), "F.42.9", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of other civil engineering projects" },
                    { new Guid("af937458-de33-4b58-bee6-4fa28245b069"), "F.42.91", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of water projects" },
                    { new Guid("b7d61a3b-a604-4e1c-ba0f-f4c483e36e0b"), "F.42.99", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("e6a513f9-c07b-4818-9dea-18531090a6ea"), "F.43", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Specialised construction activities" },
                    { new Guid("76cd5a22-8083-4266-a3b0-fa32941cdc83"), "F.43.1", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Demolition and site preparation" },
                    { new Guid("2644c88c-9255-4723-80af-4f9f2b945456"), "F.43.11", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Demolition" },
                    { new Guid("d748c824-7b2f-4179-a89b-8f33a02fe23d"), "F.43.12", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Site preparation" },
                    { new Guid("c19c5cf4-5124-42d4-840a-3986f203e4df"), "F.42.11", new Guid("c121876d-d19a-4181-a142-f77b1f92bf95"), "Construction of roads and motorways" },
                    { new Guid("d36a56d4-b4c0-42bd-8ed0-90c964e734b7"), "E.38.21", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("85a7c4c6-64c3-4edf-924c-019d55198869"), "E.38.2", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Waste treatment and disposal" },
                    { new Guid("4b77dfd8-3cef-4f2d-b497-c10dfb1a8c9c"), "E.38.12", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Collection of hazardous waste" },
                    { new Guid("6773959c-27f8-41bb-9987-ec2c66232e51"), "C.33.15", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair and maintenance of ships and boats" },
                    { new Guid("860ab45f-ce0f-45d1-9804-7d6bade867ba"), "C.33.16", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("1347df11-b425-4f6e-8c31-9c0f6bc5c9ed"), "C.33.17", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair and maintenance of other transport equipment" },
                    { new Guid("00019904-45ae-4dd3-a220-8e6bdbe5b720"), "C.33.19", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair of other equipment" },
                    { new Guid("94bd5211-11c8-41b3-b67f-f91a3d32dd1f"), "C.33.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Installation of industrial machinery and equipment" },
                    { new Guid("1dc5497f-c192-4d30-8e90-7e4fa041e2fe"), "C.33.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Installation of industrial machinery and equipment" },
                    { new Guid("b6228469-401e-424f-a36c-4f6908c5c58b"), "D.35", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("f6385fca-be4c-45ac-ba75-e302f869bfc9"), "D.35.1", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Electric power generation, transmission and distribution" },
                    { new Guid("a77f90cd-e712-4160-add7-5a5b519eb361"), "D.35.11", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Production of electricity" },
                    { new Guid("777b6bdf-45bf-4bae-91b0-6da51e5e5b75"), "D.35.12", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Transmission of electricity" },
                    { new Guid("b8da76e4-584a-4593-b5f9-2b80c075f85a"), "D.35.13", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Distribution of electricity" },
                    { new Guid("a9492fb2-bafc-451a-ba96-734837b4a531"), "D.35.14", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Trade of electricity" },
                    { new Guid("e0cd2536-8d2a-4000-9870-5766a1473e66"), "D.35.2", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("222784b0-a4c7-497a-a57b-883e1e2adfb7"), "D.35.21", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Manufacture of gas" },
                    { new Guid("69f20532-4df3-47a5-9f70-be662ae893da"), "D.35.22", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Distribution of gaseous fuels through mains" },
                    { new Guid("2c643d2f-8aa1-43ab-ac86-414b5d5d42c0"), "D.35.23", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("839c4c04-d061-426c-ad82-4a29ce03b05a"), "D.35.3", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Steam and air conditioning supply" },
                    { new Guid("4fedbd1e-01ac-45e6-8cdc-77337101845a"), "D.35.30", new Guid("ae840323-3f88-48fe-b261-c4feb17ec8c4"), "Steam and air conditioning supply" },
                    { new Guid("b446baf0-4a6c-46b2-8be0-271d187c1236"), "E.36", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Water collection, treatment and supply" },
                    { new Guid("2d98c6e4-5ec7-4613-9bf2-41d47083f489"), "E.36.0", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Water collection, treatment and supply" },
                    { new Guid("6a03e549-28b4-4168-aef6-2437694c177a"), "E.36.00", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Water collection, treatment and supply" },
                    { new Guid("9415e665-d2d9-4784-90fd-5ca7a9d9b446"), "E.37", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Sewerage" },
                    { new Guid("4019931e-89cd-4820-a70d-423f86e42a44"), "E.37.0", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Sewerage" },
                    { new Guid("b87f14f5-ba01-4871-a0b1-a9ba4104a5da"), "E.37.00", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Sewerage" },
                    { new Guid("7d6dcfed-5735-42e4-824b-289bd0764a59"), "E.38", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("920ce1fe-b881-4497-bfb1-9fea104c5f24"), "E.38.1", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Waste collection" },
                    { new Guid("4922e4ac-4c42-440c-b8ff-16cecf2e5b7a"), "E.38.11", new Guid("212d4c9f-ffb7-49ad-8f96-42d68c90a96f"), "Collection of non-hazardous waste" },
                    { new Guid("026889bb-e24b-4dc8-ad36-48c56388aa70"), "C.33.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Repair of electronic and optical equipment" },
                    { new Guid("7de84462-7d3c-4890-b56b-bc9f054316b3"), "C.23.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of clay building materials" },
                    { new Guid("11ced251-61a6-47a9-ae6e-acfecf08cd84"), "C.28.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("2a5fc4c0-12ab-4d4d-806c-0213e6d38758"), "C.28.25", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("e79ff383-c925-413b-a852-73c7892dd207"), "C.24.34", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Cold drawing of wire" },
                    { new Guid("cd98e39c-1585-4af2-85af-f8cc3d6e8a24"), "C.24.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("e3b60f9a-d22b-4e2d-aa4a-15655b072c6d"), "C.24.41", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Precious metals production" },
                    { new Guid("9df4d456-8e16-4633-9f4b-5c64efbfbe8a"), "C.24.42", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Aluminium production" },
                    { new Guid("54885c93-75ca-4846-ad23-276b6cb15ade"), "C.24.43", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Lead, zinc and tin production" },
                    { new Guid("455eab6e-f95b-4d82-9170-cd0e9e18f76d"), "C.24.44", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Copper production" },
                    { new Guid("53302408-0cb9-4c45-ad65-a5f1b5a575b8"), "C.24.45", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Other non-ferrous metal production" },
                    { new Guid("13cc3154-811a-473a-8068-5f44d6e29db8"), "C.24.46", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Processing of nuclear fuel" },
                    { new Guid("a7dbbbd0-802e-42ee-b5cb-f96147653e2f"), "C.24.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Casting of metals" },
                    { new Guid("f622d7a8-e605-40ff-8a0f-377a31434d8d"), "C.24.51", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Casting of iron" },
                    { new Guid("54067bf6-65e8-4057-a534-0691210dd0a2"), "C.24.52", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Casting of steel" },
                    { new Guid("f7d72656-cfb8-4a02-8273-da1a38e10301"), "C.24.53", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Casting of light metals" },
                    { new Guid("872358e0-6e7b-4766-9842-a9ba53e7eeac"), "C.24.33", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Cold forming or folding" },
                    { new Guid("9849a035-cb6b-4638-b7c0-0b778c3cb053"), "C.24.54", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Casting of other non-ferrous metals" },
                    { new Guid("1a45359d-150b-4cdd-b276-f205c5dbe8b3"), "C.25.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of structural metal products" },
                    { new Guid("78dab62d-0d05-43e1-b1ef-503683d1f8b6"), "C.25.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("f452d666-8fa8-410e-8393-8f6bbdd9e41a"), "C.25.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of doors and windows of metal" },
                    { new Guid("377b319c-23b6-4864-8fbf-74b9feaa6d25"), "C.25.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("ca073f49-603e-4fe8-84ea-bf1814cbf9f8"), "C.25.21", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("94f04a7d-93c3-4154-9e30-e218e7660005"), "C.25.29", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("d1d8ac42-1dc7-4b3a-9aa0-8bdb71483379"), "C.25.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("977563cd-4251-4f60-a1a5-cf6c80e68ce7"), "C.25.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("65e254cc-8c86-4548-9554-a1e60f1b7542"), "C.25.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of weapons and ammunition" },
                    { new Guid("9ece6f25-9356-45f2-96cb-dd9279605c3a"), "C.25.40", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of weapons and ammunition" },
                    { new Guid("528385aa-2b44-4d43-a25c-3cb21af6e2e6"), "C.25.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("c2c8d126-fc72-4813-abde-648b8b2784aa"), "C.25.50", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("212d62ec-32d7-4d1d-bbe5-3d36270e0604"), "C.25", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("48058d4f-3e20-466f-85ee-00698384fb67"), "C.24.32", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Cold rolling of narrow strip" },
                    { new Guid("cb206f43-f1cb-4a85-8773-28aaba093dbb"), "C.24.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Cold drawing of bars" },
                    { new Guid("3ae9d542-8029-4552-8976-13d1c7eff83a"), "C.24.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other products of first processing of steel" },
                    { new Guid("f700e0c9-1357-4a1b-ab9f-1d3bb35a6444"), "C.23.32", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("dffed5f3-b505-4382-887e-b10983685e44"), "C.23.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("0581b33f-a67b-4ea8-b2c3-e0e089e8b8a2"), "C.23.41", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("5d09dc13-3b32-4e67-a16c-a33282bc51b7"), "C.23.42", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("cd0d0019-21ff-4169-b3f5-24049282b052"), "C.23.43", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("828caac4-9837-4f62-88ed-531ca8bc49f6"), "C.23.44", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other technical ceramic products" },
                    { new Guid("951519f8-0a82-4fe9-bda3-b0b229e53e60"), "C.23.49", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other ceramic products" },
                    { new Guid("a60f5c39-1d45-40bb-9a04-df8e9ef593ea"), "C.23.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cement, lime and plaster" },
                    { new Guid("848868b3-3ec6-45fe-b0bf-1e10788daf3e"), "C.23.51", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cement" },
                    { new Guid("92330c30-70ae-40e8-8722-679d89427880"), "C.23.52", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of lime and plaster" },
                    { new Guid("a71ed9cc-efdd-44d3-aed3-585134c0e447"), "C.23.6", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("44746462-4021-466d-8791-6ce67c3a8ca8"), "C.23.61", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("aa8dfe79-b2c2-4626-95ea-6028137dd581"), "C.23.62", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("a52811c2-e736-4bb4-b591-fa2770b276ed"), "C.23.63", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ready-mixed concrete" },
                    { new Guid("92f60f07-c997-42df-b37f-b2896af59242"), "C.23.64", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of mortars" },
                    { new Guid("f32c4665-07fe-49eb-9770-bb32da1ee1fe"), "C.23.65", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fibre cement" },
                    { new Guid("9ce250ec-f51b-4857-8b85-92c630be9735"), "C.23.69", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("86839e92-7f44-4b84-8d96-9199ea432f74"), "C.23.7", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Cutting, shaping and finishing of stone" },
                    { new Guid("ab0f72ff-6344-41b6-adec-a0e9d9adc0a4"), "C.23.70", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Cutting, shaping and finishing of stone" },
                    { new Guid("a431025a-95b6-420a-8861-92726d0b4c4f"), "C.23.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("c0acd9f9-78db-4d72-b785-e567a1ca255d"), "C.23.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Production of abrasive products" },
                    { new Guid("0df01fb9-c289-4248-8b0a-c3b645555b46"), "C.23.99", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("8637bc83-3bfa-49ff-92ff-4ad731ffe60b"), "C.24", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic metals" },
                    { new Guid("274ba6d8-4429-42e5-9776-ce9737df31e3"), "C.24.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("27cf4b8d-b3e2-4e53-a258-c4791aff8a85"), "C.24.10", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("822b1a64-d025-4fb7-9c59-ab99a8a0554a"), "C.24.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("c4955298-0e0f-40d3-be95-ba3554ff5307"), "C.24.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("61c27727-adef-45b5-821f-0f89004b2cda"), "C.25.6", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Treatment and coating of metals; machining" },
                    { new Guid("05d54490-e4af-4792-9b1e-140e65833b77"), "C.28.29", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("7395dc0b-0773-4ec4-aeb3-66182284e94e"), "C.25.61", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Treatment and coating of metals" },
                    { new Guid("31edb457-2502-483d-8ecc-99a8b5d1673c"), "C.25.7", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("c6285d3a-8823-466d-a8ff-754ef0ec2d19"), "C.27.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("f9011f76-5f44-4fe0-8a77-900a765f25ba"), "C.27.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of batteries and accumulators" },
                    { new Guid("b8511785-0a9b-40c7-abcd-79f1b6991511"), "C.27.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of batteries and accumulators" },
                    { new Guid("9ca3772d-f466-4844-9563-ee32722bc9c1"), "C.27.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wiring and wiring devices" },
                    { new Guid("8880d848-bc0d-4bfe-8961-bd8e3a412585"), "C.27.31", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fibre optic cables" },
                    { new Guid("6c1b53fc-cf12-419c-b55c-ee83e2becaa4"), "C.27.32", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("2d6a63fc-99f4-4c5b-9a77-acdc91daf531"), "C.27.33", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wiring devices" },
                    { new Guid("e484cea0-1b96-4ab6-a052-0b58661b31d8"), "C.27.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e4c56e43-a750-4aff-bb18-44fafb6ac448"), "C.27.40", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electric lighting equipment" },
                    { new Guid("6385a3f8-f194-4721-8c10-973e5b802fbd"), "C.27.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of domestic appliances" },
                    { new Guid("61c6225f-5d65-4429-a110-2ec62a2f32d4"), "C.27.51", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electric domestic appliances" },
                    { new Guid("2813366c-ab89-4301-905c-a126c9734881"), "C.27.52", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("30945d8f-9c07-4022-aae3-6cac0e1468c3"), "C.27.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("6f8c7566-4087-439e-b3f7-b2bd11ec64aa"), "C.27.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other electrical equipment" },
                    { new Guid("2f45b8ce-e546-4fdc-ab9e-fb9d718659fb"), "C.28", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("4dd8da68-c74d-4322-8922-dfb716f22e32"), "C.28.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of general-purpose machinery" },
                    { new Guid("e863da84-e339-4102-bd6b-4a70cf0669d1"), "C.28.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("2c2afa4a-61fb-4cb9-9ecc-18e17448a871"), "C.28.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fluid power equipment" },
                    { new Guid("300a79ff-f60d-47bc-b664-4c2270b43dc0"), "C.28.13", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other pumps and compressors" },
                    { new Guid("11fd2de2-94e8-442d-87a3-e3c073eefacb"), "C.28.14", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other taps and valves" },
                    { new Guid("a8d43043-44aa-4234-9d2c-f6c6c2dff115"), "C.28.15", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("d917b946-8516-4f7b-b7fc-e93c98b0b615"), "C.28.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other general-purpose machinery" },
                    { new Guid("0a9ec6ca-9856-4579-ba76-5f8364aa0088"), "C.28.21", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("bfd23b17-ddf4-4822-8ed8-2c300501e51a"), "C.28.22", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of lifting and handling equipment" },
                    { new Guid("5fb38d15-ba5f-4871-b7c1-aaffc8181431"), "C.28.23", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("2cfc4f78-a6e1-4a1f-8ba7-4d0f39efc7fb"), "C.28.24", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of power-driven hand tools" },
                    { new Guid("3283a376-3e71-4e95-82c9-74728d32ad51"), "C.27.90", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other electrical equipment" },
                    { new Guid("7af73d80-6981-4b6f-80ed-a3c5dea95349"), "C.27.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("01767c63-9585-4f89-9874-2deaa60c98d5"), "C.27", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electrical equipment" },
                    { new Guid("1671f8e7-e933-4544-ad95-4e7a26eb8d9d"), "C.26.80", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of magnetic and optical media" },
                    { new Guid("7581e5ca-272d-4798-922c-21934ab237ab"), "C.25.71", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of cutlery" },
                    { new Guid("be373e86-3c06-4144-9e67-f7570994f524"), "C.25.72", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of locks and hinges" },
                    { new Guid("8ab2d6c7-157b-46c7-914a-6be14784db77"), "C.25.73", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of tools" },
                    { new Guid("c3935be3-625f-4ff7-96e7-d7a45c453416"), "C.25.9", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other fabricated metal products" },
                    { new Guid("cc0f962f-0e38-47c4-91a3-101f29fe0eb5"), "C.25.91", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of steel drums and similar containers" },
                    { new Guid("dd2d1834-bae6-458f-b93a-ebf6b24b287a"), "C.25.92", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of light metal packaging" },
                    { new Guid("54936149-186f-4b13-8832-96b409f5a237"), "C.25.93", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of wire products, chain and springs" },
                    { new Guid("511418c1-008e-4f05-9adb-6d3238975a13"), "C.25.94", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("609d2dde-484a-41ae-a933-acdba564a4db"), "C.25.99", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("e6d95c23-d7d4-4c7a-a6c3-0e72ae4649b0"), "C.26", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("347aadb6-082e-47ba-bc1d-0e04ee1d16eb"), "C.26.1", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electronic components and boards" },
                    { new Guid("1116326b-51c5-4d15-9b88-02ed91335f01"), "C.26.11", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of electronic components" },
                    { new Guid("8bb9a8a0-9aab-4664-a8ca-50516a416058"), "C.26.12", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of loaded electronic boards" },
                    { new Guid("dfc59384-8ae4-4f11-99a4-b4e6bea00f07"), "C.26.2", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("7df10694-fa5e-4764-9073-8a7bf582985c"), "C.26.20", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("87559897-4ac6-423a-b5dd-991c313fda8b"), "C.26.3", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of communication equipment" },
                    { new Guid("61298cc7-0822-4e96-a5bf-c00eb0508d80"), "C.26.30", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of communication equipment" },
                    { new Guid("6a8e101e-d433-484d-84dc-73bdc4e6aa96"), "C.26.4", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of consumer electronics" },
                    { new Guid("e431f7aa-9789-4a7d-9ad0-70feffc6c9a4"), "C.26.40", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of consumer electronics" },
                    { new Guid("b553d0d6-dfc6-4f68-8aa7-d18dcf42defb"), "C.26.5", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b85ff692-f0ec-43e2-a7ee-290f7d857e03"), "C.26.51", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("4a3a84ac-99b6-4d3b-92d1-894404b696a5"), "C.26.52", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of watches and clocks" },
                    { new Guid("ea419de8-5f70-4570-85d8-01dd1039993e"), "C.26.6", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("6cc56e21-6eb9-48a8-a533-927dbc14b89f"), "C.26.60", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("027f23a6-f4aa-43d2-8814-d22893fd06d4"), "C.26.7", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("14937bc6-c80e-4af5-b6c0-073c25ca0dc3"), "C.26.70", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("2cbda976-7837-4682-b828-d00c16176692"), "C.26.8", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Manufacture of magnetic and optical media" },
                    { new Guid("36752848-e16e-47a4-92a1-6869990b1502"), "C.25.62", new Guid("daf2e4e6-995d-42d6-ba6a-f75629cc514b"), "Machining" },
                    { new Guid("00390d7e-2831-48e4-9c3f-c2a88044f463"), "U.99.00", new Guid("bfd64441-c86b-4b14-9190-d01e19c7c164"), "Activities of extraterritorial organisations and bodies" }
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
