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
                    Id = table.Column<int>(type: "int", nullable: false),
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
                    IsPropositionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCostCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRevenueCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsChannelsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerSegmentsCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Plan_SpecificAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    AttrVal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderValue = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_SpecificAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_SpecificAttributes_BusinessPlans_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlans",
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
                    { new Guid("ee11b6e3-8c61-4fa1-afea-68686d473c7c"), "AT", "Austria" },
                    { new Guid("f7ce9786-0155-4747-942f-2eef4fcb9f81"), "LU", "Luxembourg" },
                    { new Guid("d9caa94b-e52e-4f51-be1f-01f3e07eb8e5"), "MT", "Malta" },
                    { new Guid("75d7ed83-78a1-478d-ba4e-d389c003da54"), "MK", "North Macedonia" },
                    { new Guid("44d4b7a6-bd55-4966-84ff-afe58cae6ac8"), "NO", "Norway" },
                    { new Guid("4903aa02-4591-43b7-a502-f7c75ea00d99"), "PL", "Poland" },
                    { new Guid("c9e9ebe0-1ae2-426e-9ead-26c2bd7c14c2"), "PT", "Portugal" },
                    { new Guid("28f37da4-f43a-4eca-989b-3dd99e0e8c80"), "RO", "Romania" },
                    { new Guid("5b5d32b8-cf76-4c5e-ad16-e601cc4687ea"), "RS", "Serbia" },
                    { new Guid("f950a7bd-f9e1-4085-8bda-9dd679d68a27"), "SK", "Slovakia" },
                    { new Guid("484bb4e8-51df-485a-a150-598cfe260d9b"), "SI", "Slovenia" },
                    { new Guid("e1a7e274-ee5c-4bbe-afd7-82913f40adfc"), "ES", "Spain" },
                    { new Guid("b268b072-25f7-4396-802e-12c2097eb3d3"), "SE", "Sweden" },
                    { new Guid("8aff0374-e137-4cbb-927a-77206fb5ba3a"), "CH", "Switzerland" },
                    { new Guid("44bd99b1-c083-4e3a-9e85-84ff50276e65"), "TR", "Turkey" },
                    { new Guid("6d07089a-dfd4-45af-9ed8-c6c851c1f2e4"), "UK", "United Kingdom" },
                    { new Guid("df370d26-8079-4a1f-a6bd-bd137b4229a2"), "LT", "Lithuania" },
                    { new Guid("d652a10b-12c0-4f56-8702-86d3523e4cce"), "LI", "Liechtenstein" },
                    { new Guid("2372fde0-b8b9-420a-a677-b5c26193b87b"), "NL", "Netherlands" },
                    { new Guid("fc4fb3df-2497-407d-a453-4941c9ec19e2"), "IT", "Italy" },
                    { new Guid("ff56cf7e-cd5a-4206-9cc0-b106857bcb01"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("691bd516-92c3-4cb6-9eba-e6492bd4d924"), "BE", "Belgium" },
                    { new Guid("b30479d4-899f-474a-b5f1-4e81b549538a"), "BG", "Bulgaria" },
                    { new Guid("c6857522-a495-4aed-85c3-c44b00989897"), "LV", "Latvia" },
                    { new Guid("621bb54c-dcf0-472a-8340-802c1f15581a"), "CY", "Cyprus" },
                    { new Guid("6dcea215-2a45-4d2a-8e3a-8077a3b20e8f"), "CZ", "Czechia" },
                    { new Guid("9fca2348-50af-489b-a42a-719a2062795b"), "DK", "Denmark" },
                    { new Guid("b973c2c4-a1d6-450c-9a48-ef22419dc0db"), "EE", "Estonia" },
                    { new Guid("634bc4c4-2f3d-4e88-9cfc-9a208c6164b8"), "HR", "Croatia" },
                    { new Guid("fa7fcd8a-626b-4b38-bb96-800f8b744bfd"), "FR", "France" },
                    { new Guid("584c5054-1f61-49cf-9ded-fd7951db7ff3"), "DE", "Germany" },
                    { new Guid("7d0eb57b-3474-4d30-a77c-adfe1b95e947"), "EL", "Greece" },
                    { new Guid("22dd65b1-dafd-46e1-af21-f74ffb8e1d58"), "HU", "Hungary" },
                    { new Guid("020bb639-eee6-44b0-ae98-6f1fbe3c8bc7"), "IS", "Iceland" },
                    { new Guid("aa7e8729-b35d-4a01-8da2-b87e3c913b87"), "IE", "Ireland" },
                    { new Guid("f77f8a37-bcd0-42f3-9241-cf1987cac959"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "P", "EN", "Education" },
                    { new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("b2357c9f-d1cd-4306-a8b0-4c32107de95a"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "L", "EN", "Real estate activities" },
                    { new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "J", "EN", "Information and communication" },
                    { new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "B", "EN", "Mining and quarrying" },
                    { new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "H", "EN", "Transporting and storage" },
                    { new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "F", "EN", "Construction" },
                    { new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "C", "EN", "Manufacturing" },
                    { new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("fae18307-febe-4822-b107-720e27bdad87"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("d907262a-e4bb-4b97-80c5-3844382ec2c4"), (short)23, null, new Guid("d8aba1f3-43ba-491f-a5dc-da8f7621766e"), (short)3, "Equipment" },
                    { new Guid("99a217aa-f7b8-42f0-8892-efd5f4236bbe"), (short)23, null, new Guid("d8aba1f3-43ba-491f-a5dc-da8f7621766e"), (short)4, "Other" },
                    { new Guid("b21b1139-7cf5-4208-8ca9-6c36b2b7f844"), (short)23, null, new Guid("81f0583d-e804-4cd3-8c21-38505ff99592"), (short)1, "Other" },
                    { new Guid("39e04bac-e5a0-4cd7-bc6d-ed8fc86ee47c"), (short)23, null, new Guid("598aaa07-b892-4397-8076-61eca4b21363"), (short)1, "Other" },
                    { new Guid("31d5e595-f315-40c3-96de-c6802707c379"), (short)23, null, new Guid("d8aba1f3-43ba-491f-a5dc-da8f7621766e"), (short)2, "Office" },
                    { new Guid("598aaa07-b892-4397-8076-61eca4b21363"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("7ea0be50-fb1e-45e7-a015-719213d5d4c1"), (short)23, null, new Guid("d8aba1f3-43ba-491f-a5dc-da8f7621766e"), (short)1, "Manufacturing building" },
                    { new Guid("ffa903ca-0bc3-4323-ae55-d7b7226364f9"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("11478d56-4257-410e-b113-92a7fc8d2f53"), (short)23, null, new Guid("fbee5c2c-fb59-406e-893f-a3f9cbbf2a7e"), (short)1, "Other" },
                    { new Guid("fbee5c2c-fb59-406e-893f-a3f9cbbf2a7e"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("1d711bdb-9db6-4357-be7f-908ffdeacc67"), (short)23, null, new Guid("ffa903ca-0bc3-4323-ae55-d7b7226364f9"), (short)1, "Other" },
                    { new Guid("6c13e623-4583-4825-9825-55b005f896a3"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("5c73bb0a-dcb3-4694-a8e6-72f8c2f2f060"), (short)23, null, new Guid("d434441a-5a7d-4af2-af99-a87aa5edfbd2"), (short)1, "Other" },
                    { new Guid("d434441a-5a7d-4af2-af99-a87aa5edfbd2"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("d8aba1f3-43ba-491f-a5dc-da8f7621766e"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("1629d401-7757-409d-8c6c-100f2a896d58"), (short)23, null, new Guid("6c13e623-4583-4825-9825-55b005f896a3"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("2980ef3a-439d-47ad-bb3c-baefff01a1ad"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("f9e87dc8-a9ea-43a5-94db-0705dcf53d03"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("500f650c-32f6-4ebb-a4aa-b93bde36fd29"), (short)23, null, new Guid("f9e87dc8-a9ea-43a5-94db-0705dcf53d03"), (short)1, "Other" },
                    { new Guid("81b99cf1-a8e2-496b-93c5-016a67dec3ff"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("96db3ad2-c7b8-4f61-bd72-dc081edab214"), (short)23, null, new Guid("81b99cf1-a8e2-496b-93c5-016a67dec3ff"), (short)1, "Other" },
                    { new Guid("f4bf4fab-8625-4d54-94a6-d26dcd4b9049"), (short)23, null, new Guid("2980ef3a-439d-47ad-bb3c-baefff01a1ad"), (short)1, "Other" },
                    { new Guid("5078f3b4-500b-41fa-a011-29293bb6c725"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("6c1d4b61-c2ad-45d2-aee1-d261266a5484"), (short)23, null, new Guid("5078f3b4-500b-41fa-a011-29293bb6c725"), (short)1, "Transport" },
                    { new Guid("e05b75c6-0db1-417a-bd47-de08063ba9da"), (short)23, null, new Guid("5078f3b4-500b-41fa-a011-29293bb6c725"), (short)2, "Cost of warehouse" },
                    { new Guid("da77edf8-323c-424f-8985-ba79c07b785e"), (short)23, null, new Guid("5078f3b4-500b-41fa-a011-29293bb6c725"), (short)3, "Fees to distributors" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b480b891-f727-4e51-9efc-371e03f21911"), (short)23, null, new Guid("5078f3b4-500b-41fa-a011-29293bb6c725"), (short)4, "Other" },
                    { new Guid("8008e0eb-e22d-4c66-8f96-5890dfd95f77"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("cc451281-cb8f-4382-a295-8300531e1233"), (short)23, null, new Guid("8008e0eb-e22d-4c66-8f96-5890dfd95f77"), (short)1, "Other" },
                    { new Guid("5aad62af-ed0d-42d4-acb7-68333ffea52a"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("4fc18851-7e7a-4592-b086-6f2120ee79cd"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("a34bd0b6-1680-4f70-9e5e-7a03c69758db"), (short)23, null, new Guid("6c13e623-4583-4825-9825-55b005f896a3"), (short)2, "Other" },
                    { new Guid("81f0583d-e804-4cd3-8c21-38505ff99592"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("01b1e7fc-b946-4d7e-8af6-30f29d71019a"), (short)23, null, new Guid("c95a8ef5-db7b-4c8a-865a-940c1cd61605"), (short)1, "Manufacturing buildings" },
                    { new Guid("00673bc6-224d-49b3-8ee5-84e14c99d198"), (short)23, null, new Guid("9448461f-53b9-48c8-98e6-52f58fd4815e"), (short)4, "Marketing" },
                    { new Guid("b90d671c-7bb5-4f04-8e75-d1e5f2e9f98d"), (short)23, null, new Guid("5a91a347-1880-4db9-b337-a86ececa1159"), (short)4, "Other" },
                    { new Guid("44b13388-13c6-423d-82c4-f4544a06f135"), (short)23, null, new Guid("5a91a347-1880-4db9-b337-a86ececa1159"), (short)3, "Transport" },
                    { new Guid("98155d56-6a31-4825-a265-a38eff1d7a22"), (short)23, null, new Guid("5a91a347-1880-4db9-b337-a86ececa1159"), (short)2, "Production equipment and machinery" },
                    { new Guid("71e72a0d-00e7-4071-8f7a-9b54164cf632"), (short)23, null, new Guid("5a91a347-1880-4db9-b337-a86ececa1159"), (short)1, "IT (office) equipment" },
                    { new Guid("5a91a347-1880-4db9-b337-a86ececa1159"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("62750a54-a16c-4a2c-9592-3e0d494203f9"), (short)23, null, new Guid("c95a8ef5-db7b-4c8a-865a-940c1cd61605"), (short)4, "Other" },
                    { new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("d6eb734d-aa59-4979-b2bc-286c9f0c2c0d"), (short)23, null, new Guid("c95a8ef5-db7b-4c8a-865a-940c1cd61605"), (short)3, "Sales buildings (shops)" },
                    { new Guid("cec7ebda-4e48-4051-9810-3bafd162d983"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("c95a8ef5-db7b-4c8a-865a-940c1cd61605"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("59e9a6b3-012d-4930-9c12-e91808d6c148"), (short)23, null, new Guid("77748335-482a-4fcf-bb26-2c66fcf59d46"), (short)1, "Other" },
                    { new Guid("77748335-482a-4fcf-bb26-2c66fcf59d46"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("d06e16b5-fe0b-4eaf-ad0a-0ee103ddad94"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("c17c0235-8782-43c7-b07c-2b7f42de5117"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("09aaca5d-90c8-43e1-8ff9-5241ed2673a9"), (short)23, null, new Guid("c95a8ef5-db7b-4c8a-865a-940c1cd61605"), (short)2, "Inventory buildings" },
                    { new Guid("ee888226-8d10-4332-986b-265992606e97"), (short)23, null, new Guid("9448461f-53b9-48c8-98e6-52f58fd4815e"), (short)5, "Other" },
                    { new Guid("3ebcd36c-788e-4ede-bee3-fd4caf6e9b4c"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)1, "Electricity" },
                    { new Guid("96a40b5c-50cb-42e8-8620-0f3efde058e3"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)3, "Gas" },
                    { new Guid("3ce009f9-f169-427a-a5d9-abca1dc37f6d"), (short)23, null, new Guid("9448461f-53b9-48c8-98e6-52f58fd4815e"), (short)3, "Finance management" },
                    { new Guid("18e951aa-2a6c-4b35-8818-be0f0b09761c"), (short)23, null, new Guid("9448461f-53b9-48c8-98e6-52f58fd4815e"), (short)2, "Factory workers / service" },
                    { new Guid("feca0408-a550-45f5-b924-f68820467329"), (short)23, null, new Guid("9448461f-53b9-48c8-98e6-52f58fd4815e"), (short)1, "Management" },
                    { new Guid("9448461f-53b9-48c8-98e6-52f58fd4815e"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("9d4a2afa-84ec-46a7-9d07-1ee633ad4750"), (short)23, null, new Guid("a77d4a33-9206-4d6a-be16-050ac623658e"), (short)1, "Other" },
                    { new Guid("a77d4a33-9206-4d6a-be16-050ac623658e"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("005ec7e6-57bd-4adf-be99-009f339013c9"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)2, "Water" },
                    { new Guid("235da9b5-f280-49ae-b887-58f2de6b0fad"), (short)23, null, new Guid("3ba7b4f6-8b08-4676-9c86-0ed41bf13f1e"), (short)3, "Other" },
                    { new Guid("4cb632b6-f7d9-481a-84ff-af2c94919b67"), (short)23, null, new Guid("3ba7b4f6-8b08-4676-9c86-0ed41bf13f1e"), (short)1, "Accountant" },
                    { new Guid("3ba7b4f6-8b08-4676-9c86-0ed41bf13f1e"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("e2e2295f-7317-4492-ae48-bbe4054dd60b"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)7, "Other" },
                    { new Guid("20d1a744-ff29-4a04-b57e-ed8253441a4d"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)6, "Communication" },
                    { new Guid("1b5f42e1-c6fb-46f3-b18d-2e92d1a8f5fc"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)5, "Maintenance" },
                    { new Guid("a4c04e8e-ef2f-4f82-b776-5990a84377f0"), (short)23, null, new Guid("6580ca52-0610-4879-b555-d4e245f1cc68"), (short)4, "Heat" },
                    { new Guid("b0eb87a7-d8de-4a94-bb71-dc4f41c0b5aa"), (short)23, null, new Guid("3ba7b4f6-8b08-4676-9c86-0ed41bf13f1e"), (short)2, "IT support" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e156900e-1689-4eba-b211-d08fb13efdf4"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("5f6c8ee8-cb3e-40d4-abb9-9e18d9201660"), (short)28, null, new Guid("1649432a-8d41-4b0c-9eb6-be388d90a344"), (short)4, "" },
                    { new Guid("07a99913-19f0-44b4-b48f-f103788be6a9"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("042d03b0-82eb-4342-9342-ca2215472532"), (short)32, null, null, (short)6, "65 - 74" },
                    { new Guid("c783b114-902a-4908-be73-510a8d8965b2"), (short)32, null, null, (short)7, "75 years or older" },
                    { new Guid("8e564b45-ad0d-4c6d-8903-5b99cf8aff38"), (short)32, null, null, (short)8, "All age groups" },
                    { new Guid("29d3c6f3-93ff-40a0-a91a-cb4ea687df97"), (short)33, null, null, (short)1, "Low" },
                    { new Guid("331b2165-d849-4053-82ba-f223d013c7cf"), (short)33, null, null, (short)2, "Medium" },
                    { new Guid("50c51c9b-ff00-4e77-b5de-79317eb35359"), (short)33, null, null, (short)3, "High" },
                    { new Guid("050cab6f-20e5-4966-8e41-b1b21bae5948"), (short)34, null, null, (short)1, "Primary" },
                    { new Guid("01302874-149b-410f-906f-cf69ae2a5f2b"), (short)34, null, null, (short)2, "Secondary" },
                    { new Guid("4bae0e13-55fe-473a-92ad-6358f647204f"), (short)34, null, null, (short)3, "Higher education" },
                    { new Guid("30b2cab9-578c-413a-b625-3dbe4f64bdd7"), (short)35, null, null, (short)1, "Domestic" },
                    { new Guid("1b16bbb6-f07f-4fde-bb1d-d5114954a437"), (short)35, null, null, (short)2, "Domestic Urban" },
                    { new Guid("c7c06601-c528-4bca-950a-e8fc077392fc"), (short)35, null, null, (short)3, "Domestic Rural" },
                    { new Guid("ba64302f-08c6-44f8-81de-08eff5e34dc9"), (short)35, null, null, (short)4, "Foreign" },
                    { new Guid("679f38c3-24e6-4c58-8ffd-c48077b61f89"), (short)35, null, null, (short)5, "Foreign Urban" },
                    { new Guid("b9428f84-5da1-4fab-99b3-2dc22ed19541"), (short)35, null, null, (short)6, "Foreign Rural" },
                    { new Guid("076412bc-86c6-46bd-8830-f9fccaee5ef0"), (short)35, null, null, (short)7, "Transnational" },
                    { new Guid("511be0d2-aee3-4635-a8c1-6201dbfe431f"), (short)36, null, null, (short)1, "Small" },
                    { new Guid("c80af72c-31e8-4562-96a7-ee5c0540ad12"), (short)40, null, null, (short)4, "Other" },
                    { new Guid("d6b5eac1-b5bb-4116-b453-20a380fb71ed"), (short)40, null, null, (short)3, "Printed Promotional/informative materials" },
                    { new Guid("8a7f50c8-eab0-421c-8c62-57103e4965f8"), (short)40, null, null, (short)2, "Ads and Commercials" },
                    { new Guid("5074b023-b810-4fbf-8892-bb735cd125ee"), (short)40, null, null, (short)1, "Word of Mouth" },
                    { new Guid("39cb1d59-2f67-485d-bd73-8a51e4299264"), (short)39, null, null, (short)2, "female" },
                    { new Guid("fd9e5a80-20f0-43ce-a5c9-238692b7fe18"), (short)39, null, null, (short)1, "male" },
                    { new Guid("784d2a4a-30a3-429c-8ed6-1c954b920fc6"), (short)32, null, null, (short)5, "35 - 64" },
                    { new Guid("b9b890ef-83b2-4080-a422-bb82111a41bb"), (short)38, null, null, (short)4, "Non-Government organisations" },
                    { new Guid("a49ccaf6-2d6c-4aaf-b506-96dc6b74cf37"), (short)38, null, null, (short)2, "National Government" },
                    { new Guid("d9386b2a-bb21-49d6-943e-ceb36b220249"), (short)38, null, null, (short)1, "International Organisations" },
                    { new Guid("68f8b20b-6b7c-4ceb-a9df-70e06557792e"), (short)37, null, null, (short)2, "Services" },
                    { new Guid("604f0afc-5561-4ec6-b8d7-71e2cd3441d6"), (short)37, null, null, (short)1, "Goods" },
                    { new Guid("fa081119-c55c-4af6-bde3-bf986db04195"), (short)36, null, null, (short)3, "Large" },
                    { new Guid("a84fa2db-0e1a-47fb-9095-adbf29f66f5e"), (short)36, null, null, (short)2, "Medium" },
                    { new Guid("ab6412fd-c1e1-4545-8bc7-cd63c13ecaa3"), (short)38, null, null, (short)3, "Muncipality" },
                    { new Guid("7137598a-3302-464b-8d61-48546d385b9a"), (short)32, null, null, (short)4, "25 - 34" },
                    { new Guid("c0b2af79-fb1b-41d7-99f8-11cde9cab3b4"), (short)32, null, null, (short)3, "18 - 24" },
                    { new Guid("30c3fd48-d19b-4265-b6c6-9f69b27a07cc"), (short)32, null, null, (short)2, "12 - 17" },
                    { new Guid("803b1cce-c992-42e0-8ab7-38b285551d6d"), (short)30, null, new Guid("a134b310-e157-4298-998c-4a168f2ea3c3"), (short)1, "Fixed location" },
                    { new Guid("a134b310-e157-4298-998c-4a168f2ea3c3"), (short)29, null, new Guid("e4400e02-45e8-43b8-b727-a6a4a9761b15"), (short)1, "Physical" },
                    { new Guid("e4400e02-45e8-43b8-b727-a6a4a9761b15"), (short)28, null, new Guid("1649432a-8d41-4b0c-9eb6-be388d90a344"), (short)1, "Own shop" },
                    { new Guid("1649432a-8d41-4b0c-9eb6-be388d90a344"), (short)27, null, null, (short)1, "Direct sales" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("929685d8-3a05-4832-8504-d31fc9ef22f8"), (short)26, null, new Guid("bfa0d71d-ac83-4e21-8af0-95aa5c72479e"), (short)4, "Auctions" },
                    { new Guid("eea42201-79bf-4c26-bcd3-02890ddbb0c8"), (short)26, null, new Guid("bfa0d71d-ac83-4e21-8af0-95aa5c72479e"), (short)3, "Real time market" },
                    { new Guid("8abf5e0a-a871-4007-92b2-58ea3b844e7a"), (short)30, null, new Guid("a134b310-e157-4298-998c-4a168f2ea3c3"), (short)2, "Mobile" },
                    { new Guid("253bc4af-cf88-49c6-b431-51d25ffbf6b3"), (short)26, null, new Guid("bfa0d71d-ac83-4e21-8af0-95aa5c72479e"), (short)2, "Yield management" },
                    { new Guid("bfa0d71d-ac83-4e21-8af0-95aa5c72479e"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("a86050fb-5579-4045-b36c-cd05acd78e47"), (short)26, null, new Guid("fca6fe43-2a6c-418d-8150-c308f69fef7d"), (short)3, "Volume dependent" },
                    { new Guid("1b09ca67-30c1-4dd9-b7c6-a82966729b23"), (short)26, null, new Guid("fca6fe43-2a6c-418d-8150-c308f69fef7d"), (short)2, "Product feature dependent" },
                    { new Guid("1ee9e225-1327-4c82-b950-52e2bd935400"), (short)26, null, new Guid("fca6fe43-2a6c-418d-8150-c308f69fef7d"), (short)1, "List price" },
                    { new Guid("fca6fe43-2a6c-418d-8150-c308f69fef7d"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("2a00830c-982e-4b2f-ac74-32a8c6ec4615"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("4dac87a6-dbc9-4bff-98c3-203e87cafc9f"), (short)26, null, new Guid("bfa0d71d-ac83-4e21-8af0-95aa5c72479e"), (short)1, "Negotiation" },
                    { new Guid("0fb97197-026e-4367-89ff-ac5da958d7ea"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("27553f7b-3d19-48fa-91a2-808db0402351"), (short)31, null, new Guid("a134b310-e157-4298-998c-4a168f2ea3c3"), (short)1, "Self pickup" },
                    { new Guid("60c955f6-f549-482a-b87c-768202cbcb59"), (short)31, null, new Guid("a134b310-e157-4298-998c-4a168f2ea3c3"), (short)3, "Courier service" },
                    { new Guid("7a0f5417-4020-4576-975a-a9cae5d18998"), (short)32, null, null, (short)1, "Under 12" },
                    { new Guid("de62373f-c905-4c2c-b137-ae1a8872bd19"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("81b4185e-67e5-46f4-ae6c-9d1a000e7ce1"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("982ac56d-f3ee-4fda-9736-684bbb731cc5"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("e2dbadf4-cf0c-43a6-8870-45cee008236e"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("e0aff84e-b942-4053-9078-46021f2a1910"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("f3e546f7-eb79-45d8-9789-24191c2075c1"), (short)31, null, new Guid("a134b310-e157-4298-998c-4a168f2ea3c3"), (short)2, "Delivery to home" },
                    { new Guid("89d81d37-37f0-4821-aaf6-a0ac9d45761c"), (short)28, null, new Guid("1649432a-8d41-4b0c-9eb6-be388d90a344"), (short)3, "Direct visit" },
                    { new Guid("a720ffb3-db51-4ab4-abf1-be203d040e27"), (short)31, null, new Guid("89b8ff4e-e8e9-4b7e-8a77-9f8c415187d9"), (short)3, "To the email" },
                    { new Guid("2de587cf-0659-4e3d-b0e1-8b1ba1b923b3"), (short)31, null, new Guid("89b8ff4e-e8e9-4b7e-8a77-9f8c415187d9"), (short)2, "Courier service" },
                    { new Guid("1137e43a-6bb2-463e-b31f-cf58a8b857c7"), (short)31, null, new Guid("89b8ff4e-e8e9-4b7e-8a77-9f8c415187d9"), (short)1, "Own delivery" },
                    { new Guid("abbc6008-931f-440e-8dec-c0e9ef32f8ad"), (short)30, null, new Guid("89b8ff4e-e8e9-4b7e-8a77-9f8c415187d9"), (short)2, "Platform" },
                    { new Guid("6c144f5b-d27c-44c2-bbd7-9974642e186d"), (short)30, null, new Guid("89b8ff4e-e8e9-4b7e-8a77-9f8c415187d9"), (short)1, "Own website" },
                    { new Guid("89b8ff4e-e8e9-4b7e-8a77-9f8c415187d9"), (short)29, null, new Guid("e4400e02-45e8-43b8-b727-a6a4a9761b15"), (short)2, "Online" },
                    { new Guid("73b0903e-1ec3-4018-8ce6-e5241a5ef962"), (short)28, null, new Guid("1649432a-8d41-4b0c-9eb6-be388d90a344"), (short)2, "Market/Fairs" },
                    { new Guid("aa19246f-b5d5-42d7-9e47-33f78da46133"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("e0a111fa-bbf3-4d12-a642-393f58973c60"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("b5d07f13-1346-44b0-a70b-49573a68121f"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("137d90f4-d086-44c0-bc96-0e121de8f7fe"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("ab10275b-0de6-42a0-92a1-e3072755eb75"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("cf580e25-f76b-47eb-b703-8510cdc00ca5"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("bf927531-5d0a-4e3c-8c66-dd5f8bd7eb00"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("9cb981f1-7609-4584-b165-ab748b82560e"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("ed0b889f-337e-4f76-879d-378617c7875b"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("d8bea203-7293-4b5c-88bd-dc4d099c44bd"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("bd476a42-5953-4225-b842-e70b71e4588f"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("cff20cd8-3ac3-4d89-b507-bc1a894bca70"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("9108ed04-1968-471d-84f5-7f8b29da2866"), (short)3, null, null, (short)23, "Bargaining power of buyers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("8c9c4a9b-f6a5-423b-ba11-bd7d33e6ac15"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("d1a2a09e-5f24-4f3a-a1ea-9de90f771209"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("66c21b25-7535-45d1-8f71-1d28179973ce"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("0cbd8461-948c-4f26-babd-4d245305a7e9"), (short)6, null, new Guid("66c21b25-7535-45d1-8f71-1d28179973ce"), (short)1, "Buildings" },
                    { new Guid("ea48e183-6f36-4f4b-ae5d-22786d749bf7"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("0cbd8461-948c-4f26-babd-4d245305a7e9"), (short)1, "Ownership type" },
                    { new Guid("1364740c-9e37-424d-8532-a6a0dea222dc"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0cbd8461-948c-4f26-babd-4d245305a7e9"), (short)2, "Frequency" },
                    { new Guid("a6c8f1d0-d96a-4ace-b895-78fc10e11d5a"), (short)6, null, new Guid("66c21b25-7535-45d1-8f71-1d28179973ce"), (short)2, "Equipment" },
                    { new Guid("67619252-8159-4bb9-abfc-4f0b471bdafd"), (short)6, null, new Guid("e7e45e36-c3df-47f6-a843-36518fefd1d6"), (short)3, "Software" },
                    { new Guid("913a2ae8-05fe-48e8-aa09-444462f7dfe6"), (short)6, null, new Guid("e7e45e36-c3df-47f6-a843-36518fefd1d6"), (short)2, "Licenses" },
                    { new Guid("a5fdfd9f-9dee-4b4a-8bb0-decdc4f9e47c"), (short)6, null, new Guid("e7e45e36-c3df-47f6-a843-36518fefd1d6"), (short)1, "Brands" },
                    { new Guid("e7e45e36-c3df-47f6-a843-36518fefd1d6"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("c8f79983-17e1-4f68-bd4f-4fa74b0e0e9b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("483c1337-8b41-40d2-8202-06d6a9c6c32f"), (short)2, "Frequency" },
                    { new Guid("b7d6f87a-f888-412c-adab-2c1caf89abde"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("483c1337-8b41-40d2-8202-06d6a9c6c32f"), (short)1, "Ownership type" },
                    { new Guid("cbc4178a-443a-43ea-96fb-c473c52d13c3"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("483c1337-8b41-40d2-8202-06d6a9c6c32f"), (short)6, null, new Guid("66c21b25-7535-45d1-8f71-1d28179973ce"), (short)5, "Other" },
                    { new Guid("b4706b8e-e787-44cb-acee-a1c8d1ffc72c"), (short)6, null, new Guid("66c21b25-7535-45d1-8f71-1d28179973ce"), (short)4, "Raw materials" },
                    { new Guid("496e16e8-87ec-482f-a16e-035b77041ec5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("a48c1dad-d31a-466e-abd2-255bd67b5807"), (short)2, "Frequency" },
                    { new Guid("7ff025f7-5c85-4623-ae83-a7107de9993f"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("a48c1dad-d31a-466e-abd2-255bd67b5807"), (short)1, "Ownership type" },
                    { new Guid("a48c1dad-d31a-466e-abd2-255bd67b5807"), (short)6, null, new Guid("66c21b25-7535-45d1-8f71-1d28179973ce"), (short)3, "Transport" },
                    { new Guid("705d2d7a-3eb5-417a-b79d-cb23ce257e93"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("a6c8f1d0-d96a-4ace-b895-78fc10e11d5a"), (short)2, "Frequency" },
                    { new Guid("4166c7d2-368f-4e12-bd9b-e786b4367ce0"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("a6c8f1d0-d96a-4ace-b895-78fc10e11d5a"), (short)1, "Ownership type" },
                    { new Guid("d49500d1-54b2-42c2-9e80-57cb81125436"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("b4706b8e-e787-44cb-acee-a1c8d1ffc72c"), (short)1, "Ownership type" },
                    { new Guid("c48778a2-01d2-4e2a-a809-3379b5a571af"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("74615915-e293-44e7-bc9d-6fee0f8ecd39"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("257826e5-2f6c-4323-8c60-0230d7ca5907"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("d7c57b40-9bf1-42b8-9cd0-2f50a0b769a9"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("dfdc2602-2b92-4e58-8706-43a82a6539cd"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("2e64e88e-8cef-4bd9-800f-b0e226780cca"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("2026bd31-6155-4fb9-889a-402664c21f30"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("2dad0ee1-5dee-4d6f-97c0-fe7e0ecb8719"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("8018f4d9-c303-41f7-afbd-18d6b4041bcc"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("5a295133-e834-4ba2-9c2a-db0f00194747"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("eda3ff42-73e1-46b5-b751-c16344ddbf53"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("fc7a3984-b9f6-4999-8e37-09c5e85aea93"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("385ac6dd-5219-4e3c-908a-6aee8fc41e0e"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("3f2c1ad0-d996-4727-9c41-e3fbec934719"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("a8636b75-b2de-4b77-bfd6-901a40455e74"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("3e2bde00-bae4-4607-af13-f083a9f3476f"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("b68dc60e-37c0-4e52-bd7e-7bec3b9e0dce"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("254caecf-4323-4764-a5f1-235a3118cddc"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("37614670-0536-4c1d-883b-4cf2910836f8"), (short)6, null, new Guid("e7e45e36-c3df-47f6-a843-36518fefd1d6"), (short)4, "Other" },
                    { new Guid("505086a4-4f45-4143-8143-3cda004cf644"), (short)1, "a", null, (short)16, "Complementary and after-sales service" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e7864824-a602-4ee1-9f81-3c7f9dd1322a"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("4c4ceeac-02e6-43c0-b020-b403acd6e6d3"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("210fb4a1-b4d1-4aca-9035-b5dbcabb01ad"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("20b1acee-1066-4a63-8602-184fa33d1f96"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("4254d4ab-5cfc-4c60-b32c-1f56c16f7363"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("c3e72588-4386-478b-8cec-9ac1bc10688b"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("066c3080-e4de-4ee4-a943-fe2722b86486"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("3fb5a592-3f3d-428f-9fbd-c109a842976e"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("9e0d8a6d-5352-4bd5-9be5-6bff24c9ee43"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("2163fcd4-f9e6-469b-ae2e-94dbfe6e4f3b"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("9308ca4d-8ae7-4100-9940-74b85ab1a2a6"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("307bac57-b801-46a9-9662-acfa6acd331f"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("2fe5a7ad-db04-4d54-a07f-310ba490ed49"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("37201725-0b4a-41c1-af19-580acb85335c"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("9f81e5a9-b69f-4c34-8d49-a2c052e1235c"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("4ab06386-3d0e-437f-8b09-730fcc40a3b1"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("49d9f457-236c-4c49-bb71-47e887bafae5"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("e065b2a3-b355-498e-a87e-027428a78422"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("518f1fb6-86f4-4da8-9dc1-1bf79b4a70a8"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("befba34d-b916-4ee7-a761-19e4d376b854"), (short)1, "Ownership type" },
                    { new Guid("483ceef1-c492-48aa-9b2e-af09be4832da"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("040f9d0b-e154-437c-8c16-554832b03a98"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("441f392c-4cc1-49a5-9414-f8520ecaf360"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("ead6c27e-60e3-4a81-8df8-8c04601f75b1"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("32742582-83af-49ff-bfde-a34d45364bcd"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("3d84d451-222f-44a3-98a9-75ac036fb84c"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("3ca66c52-d8d2-454c-97c4-24c6182fd87d"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("145b2808-35e4-4d02-b657-dbc1ccbd274c"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("fb8fd033-2cc2-40e0-9db5-b1fd3ca6f3c3"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("89ec61be-94b4-4921-834a-f53f63fba056"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("d4089c3a-5533-4294-aca8-e5faa9979a23"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("04ad1032-c471-4e09-8a49-288853c62f44"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("02882212-4a44-457b-a888-e77aac552cb4"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("3ec5bdf8-a61a-425c-a78d-fa7e0b409deb"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("190b22ab-b95d-4130-bdb7-31c017b861d0"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("3983528e-e77b-4020-bccb-5ff5079cf2aa"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("a7c41a71-64ac-4c9f-9ba6-25aa8a001a33"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("fd4f9c3a-7da2-4211-83d9-5c89252998ee"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("769433d7-72c8-41f1-a4aa-1ad3c8e23e6b"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("2219daa5-b544-41ca-aeba-c24965bff88a"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("bb770d7d-c64b-4460-b40c-a4db3ba7a21b"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("42030645-f4c2-4c28-a739-a2997cb68e62"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("e5ce74fd-796e-42e1-a32f-60b8a4d7dc3f"), (short)17, null, null, (short)2, "Economy" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("2b8d8510-49b2-4c15-82e5-dbf1df2984be"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("aebce471-5181-4803-a8d0-a2e7a0c858ba"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("3596f44c-2a32-4619-814d-05d19bd76fe6"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("5b07ccdb-40ab-434a-bb11-4c73e038c2c7"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("3ca4df64-8ae4-46cd-8849-7645df039054"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("3b6cd63c-c63b-4e8f-a994-46ac48f3fc23"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("d89ff9a2-b175-451d-967a-d4be4c941f37"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("f6e6c58e-0e85-4b7d-8b29-7da02097d394"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("7d7b2a36-4b28-4aeb-a2c1-6ea44f331568"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("befba34d-b916-4ee7-a761-19e4d376b854"), (short)6, null, new Guid("e065b2a3-b355-498e-a87e-027428a78422"), (short)1, "Specialists & Know-how" },
                    { new Guid("8238d74f-5d30-4e90-ac6f-517855578043"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("19f3c37e-4e20-47e6-9552-bb0e99e182bc"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("111680aa-4336-4bb5-b7f2-e9a2f6633c21"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("63729f9a-26d2-4e1e-aaf3-a785cf3fba4d"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("17d2fd9f-0291-4ab7-91a3-9a2debd805c4"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("71e6b91e-3309-4edb-8f37-fa6da91d24c3"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("1c54c3eb-94d8-46ce-9198-fee4923b4405"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9a8c62f9-867d-40da-b98c-70ff1cf200de"), (short)2, "Frequency" },
                    { new Guid("5f170639-e235-4dc8-af18-aafa5d63ff1e"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("9a8c62f9-867d-40da-b98c-70ff1cf200de"), (short)1, "Ownership type" },
                    { new Guid("7030abd1-530f-48d2-bd89-0ebe123ff14e"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("9a8c62f9-867d-40da-b98c-70ff1cf200de"), (short)6, null, new Guid("e065b2a3-b355-498e-a87e-027428a78422"), (short)4, "Other" },
                    { new Guid("db14c39a-30c8-4042-a0e8-28a4e23e2292"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("4e38b0d4-e0a1-4035-834c-c0fa480a7e13"), (short)1, "Ownership type" },
                    { new Guid("4e38b0d4-e0a1-4035-834c-c0fa480a7e13"), (short)6, null, new Guid("e065b2a3-b355-498e-a87e-027428a78422"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("b0efae45-cf9d-402f-a68c-c51e5500f4e8"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("933a16f0-b58b-422a-8076-60ce0be480ed"), (short)2, "Frequency" },
                    { new Guid("9f7f15db-f471-4bb1-9e9e-5367c43e54a0"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("933a16f0-b58b-422a-8076-60ce0be480ed"), (short)1, "Ownership type" },
                    { new Guid("933a16f0-b58b-422a-8076-60ce0be480ed"), (short)6, null, new Guid("e065b2a3-b355-498e-a87e-027428a78422"), (short)2, "Administrative" },
                    { new Guid("51d6707a-7c01-4aba-8df3-27651145a11e"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("befba34d-b916-4ee7-a761-19e4d376b854"), (short)2, "Frequency" },
                    { new Guid("e8ae2109-8ecb-4fe6-af77-65025aa4271d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4e38b0d4-e0a1-4035-834c-c0fa480a7e13"), (short)2, "Frequency" },
                    { new Guid("50fd6473-8e1a-498e-96c1-1687069e6205"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("98fd1c93-c280-47c2-86a4-ddcf0cf72935"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("0ab555c0-475f-4660-baca-65cebae15930"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("eb47a978-5869-4eca-9630-e520f551d87c"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("920cae72-d402-4128-9a9a-1fea638ba1ff"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("0b284dff-bf50-4525-80b2-de50c56489bf"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("c8e32f11-54ae-4414-bf4c-5c92f2ed4aa4"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("426a0a46-86da-4823-99b1-b91fd52c8d05"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("f8f60f60-f937-4295-9b20-748b5ea6443e"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("c1820513-097e-4f00-a2d7-e34567dc3c54"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("69d44180-24e3-48b5-bbd0-e636b76fe4ea"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("47b412f3-b3f3-4597-be29-c0ab7f03efcc"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("fc742c79-cf19-47d8-8c7d-23cdcb2bf6ca"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("95088920-23c6-40a2-8ec4-24f31796e620"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("238973e0-7441-4a54-bbd5-d7e2c333644f"), (short)12, null, null, (short)4, "Financiers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("0af8f786-5206-484a-b4f2-a07360fb9cd3"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("fe70e743-69b7-4208-bf81-f3bd768e3e72"), (short)13, null, null, (short)1, "Consultants" }
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
                    { new Guid("f9508c80-af46-4073-9368-0081409ca479"), "A.01", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("e405eed3-8c42-4145-86e3-7f467601139d"), "H.51.22", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Space transport" },
                    { new Guid("e224e701-2a50-4280-bab2-01348d9d01f8"), "H.52", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Warehousing and support activities for transportation" },
                    { new Guid("f3d12a86-f98e-498c-a44f-c6a102f7fb4d"), "H.52.1", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Warehousing and storage" },
                    { new Guid("000b423f-2ec9-4d88-980a-a78e05478c99"), "H.52.10", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Warehousing and storage" },
                    { new Guid("5d070cf5-adbe-4ad1-a954-03515a7a88ef"), "H.52.2", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Support activities for transportation" },
                    { new Guid("ca2cfe90-b61a-4459-808d-c2a9998450f1"), "H.52.21", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Service activities incidental to land transportation" },
                    { new Guid("267aec7e-f8e4-47c1-af1d-0e0aaac7346c"), "H.52.22", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Service activities incidental to water transportation" },
                    { new Guid("da79f3d0-3c5c-4bf1-896b-44abe5ed09d2"), "H.52.23", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Service activities incidental to air transportation" },
                    { new Guid("7cfa34f8-3321-4168-a466-8ba81bd546e3"), "H.52.24", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Cargo handling" },
                    { new Guid("80e62adb-d133-4530-87dc-0e65e0281fe4"), "H.52.29", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Other transportation support activities" },
                    { new Guid("88321dc5-cb94-4bef-b00c-593218d0ccc2"), "H.53", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Postal and courier activities" },
                    { new Guid("acf9c784-664a-4905-9ca2-95590d1c7e6e"), "H.53.1", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Postal activities under universal service obligation" },
                    { new Guid("befef08d-a698-43dd-b982-9dabbc938859"), "H.51.21", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Freight air transport" },
                    { new Guid("a187701b-72ea-4461-bc59-dd1210ea3fdd"), "H.53.10", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Postal activities under universal service obligation" },
                    { new Guid("02f00246-7565-46fa-9fd5-d312b0ae4494"), "H.53.20", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Other postal and courier activities" },
                    { new Guid("059f6e48-17f8-4fc4-873d-7abb6d143f5c"), "I.55", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Accommodation" },
                    { new Guid("b18327c3-e9fb-4cac-9787-ca9d3ac49d94"), "I.55.1", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Hotels and similar accommodation" },
                    { new Guid("5be5926a-d630-4b54-858a-668f859ff803"), "I.55.10", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Hotels and similar accommodation" },
                    { new Guid("d5555c66-b1de-4b10-b59d-bc12e143c9bf"), "I.55.2", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Holiday and other short-stay accommodation" },
                    { new Guid("e748de6d-09e0-4b9f-9b2d-1be6fb2b0e0a"), "I.55.20", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Holiday and other short-stay accommodation" },
                    { new Guid("92532280-3e43-41fb-b631-094eebba7da0"), "I.55.3", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("28bac6b6-8adb-41c9-a390-888a0ba49145"), "I.55.30", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("64758ff7-694f-4171-9648-766c4b3bccf3"), "I.55.9", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Other accommodation" },
                    { new Guid("ff784551-8a0e-4a27-8da1-87438251e19c"), "I.55.90", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Other accommodation" },
                    { new Guid("17b6f77c-d69d-4ca2-aeed-66fc7a0a3483"), "I.56", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Food and beverage service activities" },
                    { new Guid("c630f827-4684-43a3-9936-973468c4d0b4"), "I.56.1", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Restaurants and mobile food service activities" },
                    { new Guid("d81ec65d-f55c-4dc9-93f5-f44e0d2497fa"), "H.53.2", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Other postal and courier activities" },
                    { new Guid("43694923-15d5-400b-9854-0313f338d801"), "H.51.2", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Freight air transport and space transport" },
                    { new Guid("88d6d66a-89cb-4815-8baa-6214d732ec3b"), "H.51.10", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Passenger air transport" },
                    { new Guid("c504f2bb-d82d-4fee-93fd-ddf18f117a99"), "H.51.1", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Passenger air transport" },
                    { new Guid("d3dd916d-a891-4d1d-838e-81fee46fa849"), "G.47.9", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("b32bbc7e-d1b1-4a80-8c3e-1b0387511850"), "G.47.91", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("573ce054-c20c-4a53-9084-80f3a994d4d9"), "G.47.99", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("b66608e4-ca65-4119-b9b7-254795eb08ef"), "H.49", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Land transport and transport via pipelines" },
                    { new Guid("e59ee939-bdc4-47e8-af93-3e4ea1e21a62"), "H.49.1", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Passenger rail transport, interurban" },
                    { new Guid("cca25a82-a6e9-4179-83f8-2182e1577136"), "H.49.10", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Passenger rail transport, interurban" },
                    { new Guid("eb7a948a-136a-4e62-b6db-5f2e1d76fa22"), "H.49.2", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Freight rail transport" },
                    { new Guid("50bbd89a-23e6-4b91-8c49-35854b052278"), "H.49.20", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Freight rail transport" },
                    { new Guid("883f2faa-053d-4bb7-8799-7eef983951bc"), "H.49.3", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Other passenger land transport" },
                    { new Guid("9a850c14-bfb4-4e9c-ba2f-c2cc74f0aa9d"), "H.49.31", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Urban and suburban passenger land transport" },
                    { new Guid("ae899f00-e388-4b41-a618-cf504cefbb50"), "H.49.32", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("734b10fd-8875-44fe-b915-46cba7f47e57"), "H.49.39", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Other passenger land transport n.e.c." },
                    { new Guid("2b541cd3-606e-40a9-acec-6dd85456e526"), "H.49.4", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Freight transport by road and removal services" },
                    { new Guid("2e604170-b457-48b3-92ed-e6c38bcf0d96"), "H.49.41", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Freight transport by road" },
                    { new Guid("f6326338-94e6-464c-a0f0-3cb182c5250c"), "H.49.42", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Removal services" },
                    { new Guid("f24f6999-ec8b-476d-af7e-8542e23c0d8e"), "H.49.5", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Transport via pipeline" },
                    { new Guid("f2189b3c-0168-437e-a27b-42d31e2bec59"), "H.49.50", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Transport via pipeline" },
                    { new Guid("d89b9860-b2fd-4a9d-ae69-157e60810731"), "H.50", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Water transport" },
                    { new Guid("b69ea307-9654-458c-8b2e-ca344deea1e7"), "H.50.1", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Sea and coastal passenger water transport" },
                    { new Guid("14498256-cc99-4559-8b37-99dc137dc5bb"), "H.50.10", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Sea and coastal passenger water transport" },
                    { new Guid("f949d654-3335-4043-9198-c2ab09341efa"), "H.50.2", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Sea and coastal freight water transport" },
                    { new Guid("fed6b621-1292-4ee2-9dff-df2ff33b1f79"), "H.50.20", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Sea and coastal freight water transport" },
                    { new Guid("e6905444-4e07-4200-89ab-05db150fd164"), "H.50.3", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Inland passenger water transport" },
                    { new Guid("1756da00-f26f-47b9-b518-cdfb8a8abdf5"), "H.50.30", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Inland passenger water transport" },
                    { new Guid("5a54b0bb-b770-4de0-ac19-b53418c33a03"), "H.50.4", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Inland freight water transport" },
                    { new Guid("b094f690-4745-4da5-8aa6-ebad76b7cc9b"), "H.50.40", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Inland freight water transport" },
                    { new Guid("60890990-0a09-43bb-9baa-deaa2813ada0"), "H.51", new Guid("d500975d-dc2a-42ad-aa0b-e560f3d5cdb5"), "Air transport" },
                    { new Guid("aa450254-e8a4-4b3b-885b-2c7b90d1c6ed"), "I.56.10", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Restaurants and mobile food service activities" },
                    { new Guid("42dcd7be-7540-476f-8877-1376aa87eb0b"), "G.47.89", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("f02ed1fd-c9a8-4ad6-bb78-da4037e3a255"), "I.56.2", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Event catering and other food service activities" },
                    { new Guid("cf2301ea-9db7-47f0-ace1-a57f52c60310"), "I.56.29", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Other food service activities" },
                    { new Guid("1b1b9c67-da1e-461b-846e-7e712dee4b36"), "J.61.30", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Satellite telecommunications activities" },
                    { new Guid("a6a6dca8-0fa4-4799-a89f-ba2f0475fe98"), "J.61.9", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other telecommunications activities" },
                    { new Guid("002218a6-0928-4c5a-9be1-341158e2f0d3"), "J.61.90", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other telecommunications activities" },
                    { new Guid("27cc816c-8a6e-407d-9088-cf6cf40115f4"), "J.62", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Computer programming, consultancy and related activities" },
                    { new Guid("39ecda89-d8c2-40a9-909b-33271cfa250a"), "J.62.0", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Computer programming, consultancy and related activities" },
                    { new Guid("e12886c4-aab0-455f-9027-1103539b7dee"), "J.62.01", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Computer programming activities" },
                    { new Guid("23f3953f-9f7e-49ce-9d2f-272968bc3090"), "J.62.02", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Computer consultancy activities" },
                    { new Guid("c81b4aa0-2508-4b4a-90a5-993a14b987d8"), "J.62.03", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Computer facilities management activities" },
                    { new Guid("cb215bb8-c322-49a7-a1b8-73fbc9895400"), "J.62.09", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other information technology and computer service activities" },
                    { new Guid("e5725528-5271-4f68-b6e5-0e775bd1cf8f"), "J.63", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Information service activities" },
                    { new Guid("bd3ebaf2-26ac-442d-8d5d-5f520d9d6fc8"), "J.63.1", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("b032b0c1-ab39-4833-be40-28f60877c959"), "J.63.11", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Data processing, hosting and related activities" },
                    { new Guid("76b0a98c-9bae-4e10-b44e-c7dd781a370f"), "J.61.3", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Satellite telecommunications activities" },
                    { new Guid("a906d627-57eb-46e2-97f1-8ddd9835f97f"), "J.63.12", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Web portals" },
                    { new Guid("6a288c54-8b6c-4238-b295-85831680b9d7"), "J.63.91", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "News agency activities" },
                    { new Guid("51bd014e-19a5-430a-9a9c-200324343682"), "J.63.99", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other information service activities n.e.c." },
                    { new Guid("2d13c886-0c2c-419b-add5-3e2b052926ab"), "K.64", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("9df217c9-91ae-48e1-be6d-462f7082463a"), "K.64.1", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Monetary intermediation" },
                    { new Guid("9590a13d-a897-44d2-b49a-4bf038f634dc"), "K.64.11", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Central banking" },
                    { new Guid("e9c031d6-c066-4731-a468-5c496ff08801"), "K.64.19", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Other monetary intermediation" },
                    { new Guid("aab92e50-f199-4169-a521-ca8efdb8e603"), "K.64.2", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Activities of holding companies" },
                    { new Guid("579fed7c-defa-443b-aa48-231e2c556701"), "K.64.20", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a9bd2997-f679-4869-a74e-a4a488b89a52"), "K.64.3", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Trusts, funds and similar financial entities" },
                    { new Guid("e5741f13-c300-471e-8d97-c00115bf5e6f"), "K.64.30", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Trusts, funds and similar financial entities" },
                    { new Guid("36a789ae-2f0f-459a-81b3-ac3840332f3a"), "K.64.9", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("e831d337-4c72-46e4-a713-7baf5e476d03"), "K.64.91", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Financial leasing" },
                    { new Guid("c27aca46-a623-43ea-b901-6575108d69de"), "J.63.9", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other information service activities" },
                    { new Guid("5053cb21-828b-4083-b9bd-88d1088953fd"), "J.61.20", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Wireless telecommunications activities" },
                    { new Guid("a1d78626-720c-4a9b-8876-57b97bcf854e"), "J.61.2", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Wireless telecommunications activities" },
                    { new Guid("38fe39ad-53a2-4f40-bc36-25e299b014db"), "J.61.10", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Wired telecommunications activities" },
                    { new Guid("f0067f16-9f14-4937-bec4-f7d8b8d7d1e0"), "I.56.3", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Beverage serving activities" },
                    { new Guid("5e954778-dfda-40b9-86b9-927748b3e0c7"), "I.56.30", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Beverage serving activities" },
                    { new Guid("3eb7a49a-e201-4a30-94eb-5501fdcaabd2"), "J.58", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Publishing activities" },
                    { new Guid("485c8c99-0390-43ce-8794-c871b380c6d4"), "J.58.1", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("054a2e58-002c-4a1e-babc-0a3905dcb5eb"), "J.58.11", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Book publishing" },
                    { new Guid("53dc74fb-de3b-4593-a40c-6eb82926c033"), "J.58.12", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Publishing of directories and mailing lists" },
                    { new Guid("dadf9bdc-bb39-497e-b954-b00ee28c0a51"), "J.58.13", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Publishing of newspapers" },
                    { new Guid("698cf62f-88c8-4845-b343-acccd0693a41"), "J.58.14", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Publishing of journals and periodicals" },
                    { new Guid("98eab626-495a-4ffb-ad1e-5d340cea6a2f"), "J.58.19", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other publishing activities" },
                    { new Guid("6f128a32-9b6b-42f5-bdb4-ee12c900482f"), "J.58.2", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Software publishing" },
                    { new Guid("84d87e58-715c-4ee9-ae3d-a39f64f5f53b"), "J.58.21", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Publishing of computer games" },
                    { new Guid("8c7dc17d-0420-42a0-8bf1-815e1a742f9f"), "J.58.29", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Other software publishing" },
                    { new Guid("c653651b-3d95-4598-8f9e-5f926cc04347"), "J.59", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("df6e42fc-68fa-4911-927e-62102a87f339"), "J.59.1", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Motion picture, video and television programme activities" },
                    { new Guid("dbbc5b27-eee0-4bf5-b357-15794c6068d5"), "J.59.11", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Motion picture, video and television programme production activities" },
                    { new Guid("eefc8f1f-48c1-4506-90d7-21001c7ccaae"), "J.59.12", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("173a4835-f74a-4056-b03e-2190fcb1a0a5"), "J.59.13", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("8ac7ae7a-5ff1-41bd-9f55-d67c6dfb9f78"), "J.59.14", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Motion picture projection activities" },
                    { new Guid("4c96faa0-780f-4ea3-b11d-ded16a69cd7a"), "J.59.2", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Sound recording and music publishing activities" },
                    { new Guid("921f9eac-8803-4a71-99cf-e85c3730f37c"), "J.59.20", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Sound recording and music publishing activities" },
                    { new Guid("0c32ae61-93c2-4ffc-ac42-046ba747b0c6"), "J.60", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Programming and broadcasting activities" },
                    { new Guid("1addfa0f-ee3d-4a45-b4bd-33bb733416b3"), "J.60.1", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Radio broadcasting" },
                    { new Guid("c598b3db-0b72-41dc-92bc-a46ac52efe8e"), "J.60.10", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Radio broadcasting" },
                    { new Guid("1776c2c5-65bf-4cfa-8b54-5285257dd540"), "J.60.2", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Television programming and broadcasting activities" },
                    { new Guid("6c97db01-cd7b-4a66-bfff-5caad9368531"), "J.60.20", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Television programming and broadcasting activities" },
                    { new Guid("4ef01ca5-4ec5-477b-9a41-a6725d139781"), "J.61", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Telecommunications" },
                    { new Guid("0af94a17-1711-4dca-aa57-ccba63502676"), "J.61.1", new Guid("a359600b-1fc8-4682-bc6d-685ed9329cc1"), "Wired telecommunications activities" },
                    { new Guid("ccde32e9-2611-4894-a2f2-317cf7b40cad"), "I.56.21", new Guid("9a6b5dd4-d30c-4426-baf2-659279210b3d"), "Event catering activities" },
                    { new Guid("762d134a-d351-4c6a-a228-52ea72b955e0"), "K.64.92", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Other credit granting" },
                    { new Guid("4041d741-f06a-4ec8-9269-ae87d184add9"), "G.47.82", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("7901b42e-c3e1-4b55-ba3d-cfff347fc3b1"), "G.47.8", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale via stalls and markets" },
                    { new Guid("98fc42e0-8fc7-4ab8-8f5a-11a8d96f8bd8"), "G.46.19", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("909a27f4-3cc4-46d5-ab01-bedd8f4f937c"), "G.46.2", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("ba1a32cb-f509-4f75-954f-eac74ae7ded9"), "G.46.21", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9e913175-93c7-466d-b24c-80ff5bc2863f"), "G.46.22", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of flowers and plants" },
                    { new Guid("3ec824f7-4d20-45e3-9793-016d37a8e2cc"), "G.46.23", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of live animals" },
                    { new Guid("199c9ad1-c874-4f96-8d2f-1421faa05d2e"), "G.46.24", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of hides, skins and leather" },
                    { new Guid("ea1d2e57-9ea4-4526-96a9-7c61a03a4c0d"), "G.46.3", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("8b8f0f57-4294-4160-a9e5-f3543d6e8d5c"), "G.46.31", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of fruit and vegetables" },
                    { new Guid("d8eac2b5-31dd-4ded-bd55-010400310bf3"), "G.46.32", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of meat and meat products" },
                    { new Guid("084a20a8-bfb1-4595-b07e-5f723db79f6d"), "G.46.33", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("ac23bcb6-46c6-402d-9340-4b8ddbbdb8b3"), "G.46.34", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of beverages" },
                    { new Guid("130dea24-c279-468e-8c38-7facb2aaaa8b"), "G.46.35", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of tobacco products" },
                    { new Guid("57dc4fc7-975c-48d7-85e1-3727e39ff25c"), "G.46.18", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents specialised in the sale of other particular products" },
                    { new Guid("3acde210-07e2-40d2-9ada-8bbbd388048d"), "G.46.36", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("856478db-36f2-4e16-bc93-717f548f989a"), "G.46.38", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("6f8f518b-ad15-43be-8c6a-c76801fce38e"), "G.46.39", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("df95a38f-e53d-4f42-9930-54f01d215ef5"), "G.46.4", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of household goods" },
                    { new Guid("e20fd10f-1ee0-433c-be6b-e254be1baf14"), "G.46.41", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of textiles" },
                    { new Guid("ba57da7d-51a4-406b-8c8a-3acf8aaa6a96"), "G.46.42", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of clothing and footwear" },
                    { new Guid("7eea1b8b-1047-4ee4-9b4e-5e31abfb5784"), "G.46.43", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of electrical household appliances" },
                    { new Guid("39572a36-b0e9-48c9-abe1-38372e5e6079"), "G.46.44", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("ffec79a4-47b9-4346-a02b-addff1ba9725"), "G.46.45", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of perfume and cosmetics" },
                    { new Guid("3c4e92cd-0d28-4424-b50b-43ad14300b7e"), "G.46.46", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of pharmaceutical goods" },
                    { new Guid("88af4460-3814-417a-b53a-cd9e45b97c90"), "G.46.47", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("03443fca-9db0-4bf2-8889-0deb813a5de5"), "G.46.48", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of watches and jewellery" },
                    { new Guid("5b30eb4a-e1f2-4f89-857c-bc37975fb055"), "G.46.49", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of other household goods" },
                    { new Guid("488cc155-3cbf-4bdf-a364-d16796c7a2ec"), "G.46.37", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("a86f950e-a22c-4c25-a51e-93a30811d81f"), "G.46.17", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("1f0311bf-315a-4181-ac25-73398a157d88"), "G.46.16", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("ccebadd9-1490-48e6-be03-c6f86118033f"), "G.46.15", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("1099ed87-4bd9-489f-b7ae-af0e9266d59c"), "F.43.29", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Other construction installation" },
                    { new Guid("76a57d0e-d62e-4aaa-8340-bad2befacc81"), "F.43.3", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Building completion and finishing" },
                    { new Guid("1efb2979-4042-42d3-9507-d53c72772e76"), "F.43.31", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Plastering" },
                    { new Guid("8eb2a9ab-504b-42c9-aa12-3a9afc62ff9b"), "F.43.32", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Joinery installation" },
                    { new Guid("144e1d86-9bda-4ea5-8395-9e24ef187a96"), "F.43.33", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Floor and wall covering" },
                    { new Guid("d8802b1d-7baf-4412-9878-a12f13cbd2a4"), "F.43.34", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Painting and glazing" },
                    { new Guid("8a1a4b57-f50d-4c3b-b2c3-908000ba944f"), "F.43.39", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Other building completion and finishing" },
                    { new Guid("d457d784-75d3-4584-8a65-0e53d1360c3f"), "F.43.9", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Other specialised construction activities" },
                    { new Guid("5999764b-5c51-4192-bc21-ec183f74cc9f"), "F.43.91", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Roofing activities" },
                    { new Guid("a55b6c7e-8e59-49a4-951f-30749283c94e"), "F.43.99", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Other specialised construction activities n.e.c." },
                    { new Guid("4a9dd32e-fa2c-4df5-b10d-0b33a5596a81"), "G.45", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("58500650-fb73-4a0d-aff9-a84ec37cc87f"), "G.45.1", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Sale of motor vehicles" },
                    { new Guid("b6d25423-6ddb-4e8a-bf07-1ffddd6e9b64"), "G.45.11", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Sale of cars and light motor vehicles" },
                    { new Guid("5bd44917-14ae-43d9-acdb-d749912e808a"), "G.45.19", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Sale of other motor vehicles" },
                    { new Guid("a8d468a1-ace0-4876-a92f-5b5668c81752"), "G.45.2", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f8362a2e-6245-4c63-9013-a885c1b05ea3"), "G.45.20", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Maintenance and repair of motor vehicles" },
                    { new Guid("21c001e5-4f15-421a-b908-63a76f31d59f"), "G.45.3", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("c5097e8e-94bb-48cc-8674-9b2671a7d9ca"), "G.45.31", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("648f2738-fd00-4940-9475-7bc7fc19fa3c"), "G.45.32", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("61f48c50-4227-4c00-a445-a0e59ef70a78"), "G.45.4", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("049ff6f9-8195-47da-be63-54b210ed02c6"), "G.45.40", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("e6cd3589-1ee1-4258-ab9b-7d9206186968"), "G.46", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("fda21b4e-6591-46a8-8c58-45171a7d87df"), "G.46.1", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale on a fee or contract basis" },
                    { new Guid("36f993ef-7074-4028-856e-e0e20e88afa0"), "G.46.11", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("20f2e0d5-6bc4-49b7-83fe-639a24f4e3f2"), "G.46.12", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("4d928c96-2c47-413a-81b9-7073895c9d9f"), "G.46.13", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("1f269492-8a17-4e89-8015-5b05d32389ea"), "G.46.14", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("194df1a6-70f6-4e55-b549-eb23e86f58c4"), "G.46.5", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of information and communication equipment" },
                    { new Guid("4ccc617c-6bf5-480a-9dfe-6c943b9428ba"), "G.47.81", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("c176dec4-42be-44a9-aefc-137ab0bb3e4f"), "G.46.51", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("a66fbcf7-0e56-4e97-b8b0-4017f5469b51"), "G.46.6", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("ba2dd16f-f119-42d9-a75c-c990010bfbd8"), "G.47.4", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("d3b1e1cb-7b07-4132-b5e9-d6218e2d068a"), "G.47.41", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("a377ab0a-2892-4d9d-a6cf-2e73fdb09a31"), "G.47.42", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("7225be32-107a-4bef-8d2a-eec6f1397b76"), "G.47.43", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("879758d5-b0ce-4684-9120-427b5e6818c6"), "G.47.5", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("c3f98119-c1db-439a-84aa-2a3a189f2475"), "G.47.51", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of textiles in specialised stores" },
                    { new Guid("2de86af4-5d72-4bc8-93c3-d3d3ea2514ce"), "G.47.52", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("730daa8d-5be3-48b5-8b29-546edb9ec9d3"), "G.47.53", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("ec5e79a1-c862-4728-956a-20d6b2c3b8a9"), "G.47.54", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("5841a2a5-16e1-436d-a7c6-aac0a7c74df1"), "G.47.59", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("d9469aef-f234-4121-882a-91c8693b85f7"), "G.47.6", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("d5ef9656-e790-4a6f-8ca7-3698b57c139c"), "G.47.61", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of books in specialised stores" },
                    { new Guid("574565b7-4494-4ed3-9826-2069c6e50706"), "G.47.30", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("61a43ee5-f642-4559-bbd8-e9d7511e323e"), "G.47.62", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("ae859da3-8403-400d-a9d6-c38f64169036"), "G.47.64", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("0e45a1ca-849f-4992-9c76-89df7d99ec01"), "G.47.65", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("8160c552-8500-4d5c-bc58-52aec8691d7e"), "G.47.7", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of other goods in specialised stores" },
                    { new Guid("9a41f603-0d1d-4596-ba9f-82d74d2ed8d0"), "G.47.71", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of clothing in specialised stores" },
                    { new Guid("0323c5d7-0f1f-4282-821f-fc967c474efa"), "G.47.72", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("9a55bba8-9ce3-49be-a01c-416d1bfa52d1"), "G.47.73", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Dispensing chemist in specialised stores" },
                    { new Guid("14a27370-41c3-4a1d-97f3-3b02572eee00"), "G.47.74", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("45efe117-5cdb-4822-85bf-518523bc1fa7"), "G.47.75", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("0c2bf362-ebdd-41e2-8de9-ea9c3df9503a"), "G.47.76", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("0a3d19ab-0c5e-4526-9d28-106f14c9d795"), "G.47.77", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("7fc7fc6a-98ca-41f8-bf38-c6ed1522f026"), "G.47.78", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("5bc6fcca-eeec-440c-8c74-dab74d91da3c"), "G.47.79", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c3db08dc-0c95-4ed8-b1b4-50bd387f6f85"), "G.47.63", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("2a25897f-4471-4d13-8b62-7fcb37fd3eae"), "G.47.3", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("94da5195-3f11-41cb-871b-aebe15b22286"), "G.47.29", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Other retail sale of food in specialised stores" },
                    { new Guid("c849bef5-519b-4b9e-ab91-976dc0f0b84b"), "G.47.26", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("a2d03a96-b616-419b-b045-6395ad6e06cb"), "G.46.61", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("cf7c3fb8-d678-4ab8-9efd-c1ec95e9174e"), "G.46.62", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of machine tools" },
                    { new Guid("3133e963-d2a3-42e4-a6fc-b9cc64a316ce"), "G.46.63", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("fa97e96e-e59b-4b65-b8f2-2863d4de679f"), "G.46.64", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("adf3c85d-0a97-43fa-a09a-544b47ec5815"), "G.46.65", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of office furniture" },
                    { new Guid("f7e7d047-5671-4ec5-a518-8e8ec0900967"), "G.46.66", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of other office machinery and equipment" },
                    { new Guid("954318f1-4eb0-46d4-aa67-c2b5b2c11fe8"), "G.46.69", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of other machinery and equipment" },
                    { new Guid("fce6738f-ef10-4701-9285-c8021edafad6"), "G.46.7", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Other specialised wholesale" },
                    { new Guid("7b34ac76-b78f-4a79-abd4-ef4ce7e35462"), "G.46.71", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("84574b80-8d26-4c88-93e9-fa129991fb2b"), "G.46.72", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of metals and metal ores" },
                    { new Guid("c24deb1f-6417-4cf5-a5bd-a62909a97d01"), "G.46.73", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("2aabfb4a-4d90-463b-8470-2ebcd417b71e"), "G.46.74", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("5f2259af-d5bc-4b01-90eb-4267c5b38ffc"), "G.46.75", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of chemical products" },
                    { new Guid("98fb9b2d-1e64-41a6-90ce-fe0aa96889bf"), "G.46.76", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of other intermediate products" },
                    { new Guid("9339a35c-80d5-4cf6-82f1-574eaf71752f"), "G.46.77", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of waste and scrap" },
                    { new Guid("44eec424-a896-4184-8c09-2bb167a782a1"), "G.46.9", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Non-specialised wholesale trade" },
                    { new Guid("1c27b1b9-6337-4c0f-a2a7-dc00976f5322"), "G.46.90", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Non-specialised wholesale trade" },
                    { new Guid("b89ab69a-2f4e-448b-be16-2d12a2c0c937"), "G.47", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("af6ef40a-a0d8-44ce-ac40-0b0c04f5b020"), "G.47.1", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale in non-specialised stores" },
                    { new Guid("73421095-ce18-4a8b-b587-677356b0ca3f"), "G.47.11", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("dd8661fa-0b9c-405e-9110-9dd722c7d323"), "G.47.19", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Other retail sale in non-specialised stores" },
                    { new Guid("61bf991c-be92-4445-ad27-87ee915d49c1"), "G.47.2", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("888fa708-b922-4f09-8402-115accedeaff"), "G.47.21", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("cdf508c6-9def-4cf7-9b8e-446d4111d473"), "G.47.22", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("0a011724-08cc-41e0-afaf-f32cdaa09866"), "G.47.23", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("0c50400b-63b4-4e07-99f4-5d2a5dbfbd8a"), "G.47.24", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("fed9e493-59ca-4bd5-8abf-b31b54f23f67"), "G.47.25", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Retail sale of beverages in specialised stores" },
                    { new Guid("2f6f0ae6-2a68-4c71-bafa-0f155aabbaa1"), "G.46.52", new Guid("c901e3fa-802e-4224-b984-55224696bd91"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("1a046dbc-6dd2-46b2-a697-2a9ab1a65de2"), "F.43.22", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("1b54c12c-a56a-4a54-9217-c6f283f4b5f8"), "K.64.99", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("af2b609d-671f-4287-83b6-05fc6257d87c"), "K.65.1", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Insurance" },
                    { new Guid("748b274f-f30b-4fb0-a35f-77625d1809f9"), "P.85.6", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Educational support activities" },
                    { new Guid("4bb9b646-42bc-4f2f-8b10-19cd339fad5f"), "P.85.60", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Educational support activities" },
                    { new Guid("59d22cfe-a093-4145-9191-143d9b19a814"), "Q.86", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Human health activities" },
                    { new Guid("07f89aab-f9bc-4006-91fa-dfbcc5c3d1ef"), "Q.86.1", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Hospital activities" },
                    { new Guid("afb622a2-dc5a-4a24-bd38-e76dd8de1ec4"), "Q.86.10", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Hospital activities" },
                    { new Guid("573c3e7c-73b3-4d02-9373-ae70937eef99"), "Q.86.2", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Medical and dental practice activities" },
                    { new Guid("7ca26c0e-fb17-4d91-9987-cd4b755ed90f"), "Q.86.21", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b13fe670-5f5d-41a3-9b7b-ee815f0cec13"), "Q.86.22", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Specialist medical practice activities" },
                    { new Guid("96041579-0e80-4ed1-b54c-a4bfb364cdf6"), "Q.86.23", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Dental practice activities" },
                    { new Guid("dd53497a-6d22-4588-a69d-c6848ef47915"), "Q.86.9", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Other human health activities" },
                    { new Guid("af154521-6701-4e57-b4cb-b2f6c6a15621"), "Q.86.90", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Other human health activities" },
                    { new Guid("81f6e7ca-b71a-4c7d-bfae-78866a8606d7"), "Q.87", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential care activities" },
                    { new Guid("5e63d3ea-a182-4b69-9ab9-4571a93dc04c"), "P.85.59", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Other education n.e.c." },
                    { new Guid("98636ea0-554d-4b8d-be93-bc4209e0f61a"), "Q.87.1", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential nursing care activities" },
                    { new Guid("00abda02-6882-4bf5-adf2-5f81a2c1e070"), "Q.87.2", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("56964c46-5e40-44f2-8452-54802205d9c7"), "Q.87.20", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("072d8e04-bfa2-4056-8f9a-fb3e3dea5515"), "Q.87.3", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential care activities for the elderly and disabled" },
                    { new Guid("cb2799d6-8dc7-4d0c-8ec6-30cd961d7641"), "Q.87.30", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential care activities for the elderly and disabled" },
                    { new Guid("5806ea84-4721-4044-a862-2a4babc1f99b"), "Q.87.9", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Other residential care activities" },
                    { new Guid("a2f790c9-d3bd-428a-ae30-1e83daa7ce4a"), "Q.87.90", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Other residential care activities" },
                    { new Guid("1835a6c2-dc46-472e-bc9b-f5d235e47cd8"), "Q.88", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Social work activities without accommodation" },
                    { new Guid("08e60a79-0e46-411e-9670-3d73e0f2a748"), "Q.88.1", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("0dd53e17-af8a-46ef-8d7d-04850428d281"), "Q.88.10", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("91cd4f1a-b522-4d02-a78c-88f2ac248b7a"), "Q.88.9", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Other social work activities without accommodation" },
                    { new Guid("74323add-d12d-430f-bcfe-c21d4a57c710"), "Q.88.91", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Child day-care activities" },
                    { new Guid("df20efe2-c94d-4eae-b465-777a9fcc5a7c"), "Q.88.99", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("115301f2-3f42-46b4-a112-46c44587fd18"), "Q.87.10", new Guid("7c1e36bd-3db4-4c1d-81e6-09877a043583"), "Residential nursing care activities" },
                    { new Guid("117fbd0b-fabf-4eb3-93d6-2076ef75e0f8"), "P.85.53", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Driving school activities" },
                    { new Guid("4d7772fb-0a01-46b7-bd66-e2af8cf45833"), "P.85.52", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Cultural education" },
                    { new Guid("e630a8c1-e0dd-40a0-a2a0-8b63ba117563"), "P.85.51", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Sports and recreation education" },
                    { new Guid("fc33ffa3-c349-4049-af47-f002f9ca5304"), "N.82.91", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Packaging activities" },
                    { new Guid("44a29f6b-8672-4c87-900f-3aeba21dcb8d"), "N.82.99", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other business support service activities n.e.c." },
                    { new Guid("ccb7c9b5-c615-4eaf-b0db-43875993971f"), "O.84", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Public administration and defence; compulsory social security" },
                    { new Guid("adb3a066-16e0-40f3-8bc8-2e1923f34eed"), "O.84.1", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("dcc3071d-d26a-44bc-94ee-25936e3be257"), "O.84.11", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "General public administration activities" },
                    { new Guid("9240b415-ae37-4aae-a86e-48dfefb78b0a"), "O.84.12", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("f5805a01-cdbd-4ee9-847b-ea8d3cfad4a6"), "O.84.13", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("23562705-6896-4c33-8397-9fd6d6ba9fe3"), "O.84.2", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Provision of services to the community as a whole" },
                    { new Guid("d03076f9-5a6e-4a04-afae-028fea02776d"), "O.84.21", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Foreign affairs" },
                    { new Guid("126b232b-d03a-41af-b24e-6a64e3d1a594"), "O.84.22", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Defence activities" },
                    { new Guid("0cec91d3-b3bf-4499-b7d5-f8a11bf67e6a"), "O.84.23", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Justice and judicial activities" },
                    { new Guid("0f5e5f0f-f311-4c96-8088-b029ad967fa1"), "O.84.24", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Public order and safety activities" },
                    { new Guid("47c147d2-cc62-4b91-afae-767039c574e5"), "O.84.25", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Fire service activities" },
                    { new Guid("a1faeff7-bfff-47be-9f01-ff8c2e87895c"), "O.84.3", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Compulsory social security activities" },
                    { new Guid("157728b4-8450-4095-adbd-5d4f1f54a347"), "O.84.30", new Guid("0aa581ee-4aed-4e65-9fca-405ae32a1ba3"), "Compulsory social security activities" },
                    { new Guid("efa22af4-8904-4211-a67c-dc4733bd8071"), "P.85", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Education" },
                    { new Guid("d327e05f-03af-4dd2-b756-3b7508c1d764"), "P.85.1", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Pre-primary education" },
                    { new Guid("a2ab9431-5d46-420a-bd01-cfefffb24322"), "P.85.10", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Pre-primary education" },
                    { new Guid("faac6f11-b10f-48e9-b346-bd9bd00f65f2"), "P.85.2", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a161b476-ada6-429f-b774-09bc51ce019e"), "P.85.20", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Primary education" },
                    { new Guid("4a564197-c8b3-4ab6-893c-8140a6cbcc53"), "P.85.3", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Secondary education" },
                    { new Guid("82fcf00c-555f-4c3f-845e-119ca80e2a36"), "P.85.31", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "General secondary education" },
                    { new Guid("44a2d68d-98ae-4a00-8434-e392a4403d11"), "P.85.32", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Technical and vocational secondary education" },
                    { new Guid("7f92a420-3c9b-4b24-bbbf-e3f949c9f3e7"), "P.85.4", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Higher education" },
                    { new Guid("91d93c34-401a-4fe3-b47e-2ef0bca63cde"), "P.85.41", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Post-secondary non-tertiary education" },
                    { new Guid("3ba019f0-8420-4840-8923-ec1dc33a9042"), "P.85.42", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Tertiary education" },
                    { new Guid("4e510f51-f2a5-4bb9-9d41-fd36ee9b23ef"), "P.85.5", new Guid("d2febf73-18f2-4d2a-9a41-f517b5cb0bfe"), "Other education" },
                    { new Guid("5be5df7b-0fdd-4124-bc4e-98e4079b09e4"), "R.90", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Creative, arts and entertainment activities" },
                    { new Guid("a2e16473-eb6a-4dd2-b64a-3a4f0c7fb146"), "N.82.92", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("01769f63-a9d4-411b-9a24-e91997a9c482"), "R.90.0", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Creative, arts and entertainment activities" },
                    { new Guid("e3b4aa1c-2678-4c0e-b5a4-70ecedf29689"), "R.90.02", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Support activities to performing arts" },
                    { new Guid("2715b34b-f952-4bcc-ac72-7ef8b3455e69"), "S.95.1", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of computers and communication equipment" },
                    { new Guid("0c5b3092-d18e-45fd-a470-6fe24370fc44"), "S.95.11", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of computers and peripheral equipment" },
                    { new Guid("a55057f0-c014-4900-8146-a6c72aa1be47"), "S.95.12", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of communication equipment" },
                    { new Guid("b6ef7ca4-05ce-447f-b8a4-90a43d95b50c"), "S.95.2", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of personal and household goods" },
                    { new Guid("97ccd7e3-60aa-4fec-aad0-3ea490c779ac"), "S.95.21", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of consumer electronics" },
                    { new Guid("c027ddeb-4af1-4268-995b-d9188f4f9fe1"), "S.95.22", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("65acab96-3a4a-4115-bc4d-adea49cc50bb"), "S.95.23", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of footwear and leather goods" },
                    { new Guid("fb68b87d-0ec2-400c-9902-744fa49c9e06"), "S.95.24", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of furniture and home furnishings" },
                    { new Guid("4a1dfb34-56fa-4704-830b-30356b4c16ce"), "S.95.25", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of watches, clocks and jewellery" },
                    { new Guid("31eab49e-8aa7-4e1e-ad29-cbd7c3fbd476"), "S.95.29", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of other personal and household goods" },
                    { new Guid("1d2d873c-f3c1-4588-986c-04dcba75e8e9"), "S.96", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Other personal service activities" },
                    { new Guid("c3c3d38b-f5a0-4c8a-a996-e36b7a0368d8"), "S.96.0", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Other personal service activities" },
                    { new Guid("63be6395-1302-4cdd-89a1-b07b4ba0d33f"), "S.95", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Repair of computers and personal and household goods" },
                    { new Guid("0ed2b993-59c6-4a5b-a2ec-f5be175f6f81"), "S.96.01", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("a854e12a-3690-4f74-a7dd-7bdd9e31febe"), "S.96.03", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Funeral and related activities" },
                    { new Guid("eef1b6db-5709-45c1-8f35-ec8a7a650b15"), "S.96.04", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Physical well-being activities" },
                    { new Guid("8276cfe6-1c2c-4060-b14a-1d603e9ece1b"), "S.96.09", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Other personal service activities n.e.c." },
                    { new Guid("ae0c0d3c-f372-4cca-8342-0a6eec50f1ca"), "T.97", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Activities of households as employers of domestic personnel" },
                    { new Guid("0f409608-51f3-458a-a7cc-e4a011a03994"), "T.97.0", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Activities of households as employers of domestic personnel" },
                    { new Guid("75c7f94e-148a-4d3f-afe1-d13a318339bb"), "T.97.00", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Activities of households as employers of domestic personnel" },
                    { new Guid("f3111028-fac2-4864-a5ab-0e8122bba6f8"), "T.98", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("cd1c9942-cd89-4f0d-bf37-098e9732bf8a"), "T.98.1", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("7e6d9c4d-b072-488d-83c1-aac5f5db0146"), "T.98.10", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("6f1a06ce-cb53-49c5-a2be-6f809227b77b"), "T.98.2", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("0ad3140d-c9db-4a94-81db-8e4c37b472a5"), "T.98.20", new Guid("b7fca014-7af9-4976-9276-928eadc1293c"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("fc802d84-3fc5-4001-b1f4-32ffe4e1c7b8"), "U.99", new Guid("b2357c9f-d1cd-4306-a8b0-4c32107de95a"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("2135f1e5-3441-4e18-8b15-4662d95b1929"), "S.96.02", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Hairdressing and other beauty treatment" },
                    { new Guid("8e58fd81-c931-427c-91c4-3b1b9fb6d784"), "S.94.99", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of other membership organisations n.e.c." },
                    { new Guid("07faaed6-8ccc-4a8b-95f8-033126a16981"), "S.94.92", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of political organisations" },
                    { new Guid("98da0ecc-ef3c-4ecb-b955-88427502772c"), "S.94.91", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4e8d5fbd-506e-4062-80de-2c7cd32fd558"), "R.90.03", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Artistic creation" },
                    { new Guid("fe99fb8f-c0f3-4e68-88fe-b79adde305d9"), "R.90.04", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Operation of arts facilities" },
                    { new Guid("d78ae96d-55fb-4b89-958b-de39f9690f4c"), "R.91", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("910f493f-ee45-4767-be91-c84afe0ee2bc"), "R.91.0", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("a95cc0cf-8062-48ba-b73b-e07f14e29408"), "R.91.01", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Library and archives activities" },
                    { new Guid("768c05cb-ffc4-413f-b82b-be7e33cdd160"), "R.91.02", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Museums activities" },
                    { new Guid("26ae9fd1-bad8-46cd-8c2c-52ab271d5119"), "R.91.03", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("513e9dad-2f60-4966-ae79-f0518f46b4bd"), "R.91.04", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("368d61c6-cf73-4374-a214-7a3cace001f2"), "R.92", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Gambling and betting activities" },
                    { new Guid("ae42b6fa-17c9-4f89-882f-8291dbf7fb56"), "R.92.0", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Gambling and betting activities" },
                    { new Guid("b3e888f2-2eb2-451a-abf2-2598eea32abd"), "R.92.00", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Gambling and betting activities" },
                    { new Guid("beebf1a3-5b63-4b1f-a509-5454bf08422a"), "R.93", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Sports activities and amusement and recreation activities" },
                    { new Guid("a7f1bca4-9a9a-4455-b7d6-0f585f0245c5"), "R.93.1", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Sports activities" },
                    { new Guid("ca2781b0-3117-49ae-a5ae-84c43777456b"), "R.93.11", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Operation of sports facilities" },
                    { new Guid("33991c12-bc36-466b-8d23-be772c57083a"), "R.93.12", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Activities of sport clubs" },
                    { new Guid("fd311040-40bd-42b5-959d-5ed2e9b27498"), "R.93.13", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Fitness facilities" },
                    { new Guid("e4ce5088-c7e6-445b-bc51-f5c5a1f39378"), "R.93.19", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Other sports activities" },
                    { new Guid("66553bd7-083b-496a-a3be-362f24504392"), "R.93.2", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Amusement and recreation activities" },
                    { new Guid("07cf190d-6e10-418c-abdc-0030f1a4b566"), "R.93.21", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Activities of amusement parks and theme parks" },
                    { new Guid("61792975-e9ab-4cb4-a71b-801c2d8d4609"), "R.93.29", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Other amusement and recreation activities" },
                    { new Guid("f8014329-9c98-47af-a608-1863b4381c8c"), "S.94", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of membership organisations" },
                    { new Guid("91815281-61e7-4933-a25c-be1726c05562"), "S.94.1", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("7a138af8-b869-42c6-817a-8f60169ef99d"), "S.94.11", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of business and employers membership organisations" },
                    { new Guid("fca359de-5d77-402c-9159-2c99a70fa536"), "S.94.12", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of professional membership organisations" },
                    { new Guid("2d43e727-ce05-4f85-8d2c-3b742d086ad8"), "S.94.2", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of trade unions" },
                    { new Guid("e3ac8728-0991-4d3e-a2ee-a64ee6a816a2"), "S.94.20", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of trade unions" },
                    { new Guid("0b140edc-d376-445e-b996-4a872b1e5bdc"), "S.94.9", new Guid("ef4a3737-17bd-487d-bab9-665ebc4cedb6"), "Activities of other membership organisations" },
                    { new Guid("7f5df536-8947-46b0-9d04-f4df49f266ab"), "R.90.01", new Guid("5a5f7a3b-565f-4cd3-9a25-69ec4c2d577c"), "Performing arts" },
                    { new Guid("1bf26fb1-f0c0-4375-8b78-f2b0b5ed9605"), "K.65", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("6c1fe6d3-0005-4bea-abae-7bf55a502ccb"), "N.82.9", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Business support service activities n.e.c." },
                    { new Guid("79c6b1e8-457e-4359-959f-46f6e385ee79"), "N.82.3", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Organisation of conventions and trade shows" },
                    { new Guid("3b9fa187-e5ba-4eeb-8604-21c497a7466e"), "M.70.1", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Activities of head offices" },
                    { new Guid("41f512c3-cd7f-4eb4-baae-0ef982f87ed9"), "M.70.10", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Activities of head offices" },
                    { new Guid("02f260ef-aaab-47ce-982c-824274bfd0f5"), "M.70.2", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Management consultancy activities" },
                    { new Guid("43b56ae7-5aff-4142-883f-52217661d08f"), "M.70.21", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Public relations and communication activities" },
                    { new Guid("9cad95fa-1978-4514-80bb-52fdd7a6e3dd"), "M.70.22", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Business and other management consultancy activities" },
                    { new Guid("53475f2d-3768-43d1-9425-c767f94667da"), "M.71", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("3a85c60a-af00-4e0e-abc9-eda16faef0b8"), "M.71.1", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("b96bae53-8737-4411-b76e-44849ef63f23"), "M.71.11", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Architectural activities" },
                    { new Guid("2ff97030-cfa2-4740-b55c-b749476eb8cf"), "M.71.12", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Engineering activities and related technical consultancy" },
                    { new Guid("cedfab77-e551-469e-a254-02460a1cd69e"), "M.71.2", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Technical testing and analysis" },
                    { new Guid("357f950b-89ed-43a2-9d50-62bd28d59112"), "M.71.20", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("df0a8817-efaa-40ce-85f0-05f844028d83"), "M.72", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Scientific research and development" },
                    { new Guid("3e797ff8-faed-4595-9f98-b5e247ea9bb1"), "M.70", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Activities of head offices; management consultancy activities" },
                    { new Guid("9e1ccf0b-7966-4723-84a5-07d4ed851bf5"), "M.72.1", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("0e8f8720-a518-4f43-9bd8-705413be574d"), "M.72.19", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("df3824ce-54a7-46e7-909f-793e095e1c38"), "M.72.2", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("d531bcfd-e511-41bf-873f-e8f00bfec33f"), "M.72.20", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("28b02cc0-eae6-4903-9ffc-587d62c1c8c2"), "M.73", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Advertising and market research" },
                    { new Guid("3a920f9c-e439-44ac-a8a7-df3039bc8043"), "M.73.1", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Advertising" },
                    { new Guid("04636af3-fffd-460f-a811-0795721c2556"), "M.73.11", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Advertising agencies" },
                    { new Guid("4f8f738c-abaa-4ea6-b920-e66d7174bf44"), "M.73.12", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Media representation" },
                    { new Guid("057c0457-9bed-4aa4-a20e-eceee8c09b99"), "M.73.2", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Market research and public opinion polling" },
                    { new Guid("b9d419af-f626-406a-99bc-20c872833625"), "M.73.20", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Market research and public opinion polling" },
                    { new Guid("64013cb9-29a5-4122-b2a0-9260c434ce1c"), "M.74", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Other professional, scientific and technical activities" },
                    { new Guid("68198c7c-bd5d-4151-b16b-1ea6b55bcc03"), "M.74.1", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Specialised design activities" },
                    { new Guid("c1f2013c-69d1-48cc-8532-9ce33904130e"), "M.74.10", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Specialised design activities" },
                    { new Guid("530f49c8-72d5-4cd2-b4f2-534176653390"), "M.72.11", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Research and experimental development on biotechnology" },
                    { new Guid("ee2258e7-3653-4ce2-9bbc-c37268730a09"), "M.69.20", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("6fc57a8c-953f-4a10-a879-609b5783916e"), "M.69.2", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("ba45eaad-4e4d-46d8-aa95-f0ce9758c665"), "M.69.10", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Legal activities" },
                    { new Guid("75c43fd8-f791-42d6-b8e5-4357f4b0d77a"), "K.65.11", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Life insurance" },
                    { new Guid("5a5d2f78-fec0-4522-b8ad-86a903a75903"), "K.65.12", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Non-life insurance" },
                    { new Guid("11e809d4-6ee5-4f5f-a880-0fbcd5f41eb7"), "K.65.2", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Reinsurance" },
                    { new Guid("fe7016f8-e83e-4430-bd7a-edaa1d963913"), "K.65.20", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Reinsurance" },
                    { new Guid("a21b2d68-47db-4849-b052-f233cf07a367"), "K.65.3", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Pension funding" },
                    { new Guid("8472837d-d9a4-4eaa-a54a-9bac2c7fbea6"), "K.65.30", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Pension funding" },
                    { new Guid("0b6c0497-2485-4a99-b3aa-4e003eb7c00e"), "K.66", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("581f07a8-45b4-46d1-aea4-05fdb79a8dbd"), "K.66.1", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("4e3ee01b-88a1-42bf-b4cb-8083d3e49954"), "K.66.11", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Administration of financial markets" },
                    { new Guid("e08d3aaa-75b7-48f9-82db-00fe7eec5b1d"), "K.66.12", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Security and commodity contracts brokerage" },
                    { new Guid("a6549db9-d484-4ce8-b08c-fef050c15555"), "K.66.19", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("940c5c2d-b4cb-41fd-b24d-2f445fc19a3c"), "K.66.2", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("008ba695-4beb-48f0-8e24-2a771cbee1a1"), "K.66.21", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Risk and damage evaluation" },
                    { new Guid("af1088cf-e83f-4e84-a2ff-53fce7cde099"), "K.66.22", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Activities of insurance agents and brokers" },
                    { new Guid("0828cfef-4988-4ef5-9655-ad45fff632da"), "K.66.29", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("e3937577-16b6-4aaa-83c5-41fa68245ea2"), "K.66.3", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Fund management activities" },
                    { new Guid("0c4aee35-81b2-433b-80e0-44a0d223c640"), "K.66.30", new Guid("0a67e06a-070c-4c87-97b7-2ec5c7cbaf47"), "Fund management activities" },
                    { new Guid("2d469665-482c-4d21-b4c9-00cecd5f541c"), "L.68", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Real estate activities" },
                    { new Guid("a51d6aba-1659-4bf1-8df4-94e3bb3e942a"), "L.68.1", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Buying and selling of own real estate" },
                    { new Guid("379ac9f4-ce9d-432e-8030-7546d32a74ed"), "L.68.10", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Buying and selling of own real estate" },
                    { new Guid("912e237b-a7e9-48bc-b9ce-a3c7cd1c9432"), "L.68.2", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Renting and operating of own or leased real estate" },
                    { new Guid("a1524d65-3f9d-44d7-9009-d579efc89919"), "L.68.20", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Renting and operating of own or leased real estate" },
                    { new Guid("8b81fb26-08f8-49d5-bcc9-781d8d7b0ebd"), "L.68.3", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c80cf7a8-e99c-4259-a6d2-9175748b9118"), "L.68.31", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Real estate agencies" },
                    { new Guid("4f3cab5f-116e-49fc-8415-1b2960606852"), "L.68.32", new Guid("754473c3-b93a-4f35-91c9-7381f58f9bfa"), "Management of real estate on a fee or contract basis" },
                    { new Guid("23a59d9d-9d4c-4d60-af12-17b7c0c3937e"), "M.69", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Legal and accounting activities" },
                    { new Guid("40ffe189-3269-4554-91b2-3e336313025d"), "M.69.1", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Legal activities" },
                    { new Guid("56e8ff51-5a61-4494-8c63-9addd75ba00a"), "M.74.2", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Photographic activities" },
                    { new Guid("57ddfab7-eb23-4f5a-a16e-9f0394d35474"), "N.82.30", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Organisation of conventions and trade shows" },
                    { new Guid("6542640d-0dfa-4328-83f3-6012e7dbbae0"), "M.74.20", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Photographic activities" },
                    { new Guid("0b330e1b-16eb-4de8-a431-331d4cdf6538"), "M.74.30", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Translation and interpretation activities" },
                    { new Guid("79e86a09-1922-4182-a6f0-a6d0f3428519"), "N.79.11", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Travel agency activities" },
                    { new Guid("5739f2e5-ee56-429e-8dc6-262470839343"), "N.79.12", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Tour operator activities" },
                    { new Guid("2965bf40-e0f5-4022-a292-f960b3854986"), "N.79.9", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other reservation service and related activities" },
                    { new Guid("7cff1327-871c-48e9-a819-c2f5eb9bb2d9"), "N.79.90", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other reservation service and related activities" },
                    { new Guid("63a7cc04-ddda-43db-8754-32c56e1a37aa"), "N.80", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Security and investigation activities" },
                    { new Guid("db490881-18c6-4207-be8a-761c4a305762"), "N.80.1", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Private security activities" },
                    { new Guid("00f78b87-1de6-4c11-8e68-c3f448df8a11"), "N.80.10", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Private security activities" },
                    { new Guid("1f1b05d9-9acd-4259-8dd1-8886fd2aad07"), "N.80.2", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Security systems service activities" },
                    { new Guid("584a27bc-8ec3-4cf9-b1ce-071d8ea454cf"), "N.80.20", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Security systems service activities" },
                    { new Guid("6ce745e3-fc64-45d1-9446-27539a489c9b"), "N.80.3", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Investigation activities" },
                    { new Guid("711f6d61-acae-42e8-8314-43127fd7a49e"), "N.80.30", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Investigation activities" },
                    { new Guid("716d705a-ff1e-4841-8c7f-f784eaf66b1c"), "N.81", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Services to buildings and landscape activities" },
                    { new Guid("c32c8c8e-360a-45db-8202-9ab1eba4d6a4"), "N.79.1", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Travel agency and tour operator activities" },
                    { new Guid("0cda8a2f-be9e-442a-b52a-2697cbdc0218"), "N.81.1", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Combined facilities support activities" },
                    { new Guid("e2c9d270-3347-42a7-9ec7-431cdc74dead"), "N.81.2", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Cleaning activities" },
                    { new Guid("17597cc5-75f9-478f-a876-d264634a70a6"), "N.81.21", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "General cleaning of buildings" },
                    { new Guid("f480652a-7e40-4d3b-ab81-e35a3478bc40"), "N.81.22", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other building and industrial cleaning activities" },
                    { new Guid("a9c63da7-2bb4-4af9-9c3e-02b435786052"), "N.81.29", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other cleaning activities" },
                    { new Guid("b957d8e2-9309-4b55-8ea2-d5ae30ab2de4"), "N.81.3", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Landscape service activities" },
                    { new Guid("d11ee37d-560d-46b5-9976-9207e2efd015"), "N.81.30", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Landscape service activities" },
                    { new Guid("d0079bdc-a997-47c7-b3dd-4f2b0729a7ff"), "N.82", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Office administrative, office support and other business support activities" },
                    { new Guid("812efcdd-40c3-4f80-aeb4-9d99cad019a9"), "N.82.1", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Office administrative and support activities" },
                    { new Guid("2251bc31-9e9e-4330-9494-c17a68ba1298"), "N.82.11", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Combined office administrative service activities" },
                    { new Guid("29982c70-9f7b-45d8-aad9-11afe12f39a6"), "N.82.19", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("08f6acc4-4f3c-4995-91de-fb8d5086d00a"), "N.82.2", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Activities of call centres" },
                    { new Guid("823b80c1-fdd1-4036-8cca-628582731a21"), "N.82.20", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Activities of call centres" },
                    { new Guid("377ba947-262e-4dd7-bdbc-1bf6cb4bf727"), "N.81.10", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Combined facilities support activities" },
                    { new Guid("5d26a0bc-8802-4cbc-8a94-bfb19aa7d396"), "N.79", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("0835fc7c-d194-43ac-9af2-a507e07c03c7"), "N.78.30", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other human resources provision" },
                    { new Guid("8a9310f5-710f-4242-a053-782473687072"), "N.78.3", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Other human resources provision" },
                    { new Guid("97021e21-2f22-4671-86ba-0a46e6e6b3e4"), "M.74.9", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("290e1135-9e1b-494d-b6ea-d108ba0ec7b8"), "M.74.90", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("18b2f675-0095-4e30-a3ec-8cf227502956"), "M.75", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Veterinary activities" },
                    { new Guid("c451942f-9b41-4102-af13-8ae580b0e021"), "M.75.0", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4c0b3299-2d2d-4197-8765-165ed8f80edd"), "M.75.00", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Veterinary activities" },
                    { new Guid("66f61730-6194-400f-ab25-3d61568bd739"), "N.77", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Rental and leasing activities" },
                    { new Guid("5221a55c-683c-4e48-8d33-3fb86454ab58"), "N.77.1", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of motor vehicles" },
                    { new Guid("48c363ce-95ca-48ce-9fea-a616c21d1c84"), "N.77.11", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("d4010086-22f1-47c1-8232-4c2c721806d8"), "N.77.12", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of trucks" },
                    { new Guid("26e538b1-c363-4a57-8219-52d00a6bcb58"), "N.77.2", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of personal and household goods" },
                    { new Guid("2f16cff1-9842-46e8-8892-6cced8363362"), "N.77.21", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("ee68954b-6eb7-4fdb-9b7c-d0c379541799"), "N.77.22", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting of video tapes and disks" },
                    { new Guid("77f4e726-a874-465d-9b59-e5e926bef08e"), "N.77.29", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of other personal and household goods" },
                    { new Guid("95d73353-b8e6-43f1-8c87-8ed39d5c9e59"), "N.77.3", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("5194bb78-03fc-4c15-9440-8e4bffc4f534"), "N.77.31", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("408723b0-e053-496a-94e8-84e8c20b218c"), "N.77.32", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("6cff601b-36cc-4f88-ab35-bd9f31fcbcf7"), "N.77.33", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("830fb38a-b710-43a6-8b97-777152a70611"), "N.77.34", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of water transport equipment" },
                    { new Guid("ea632e19-056b-4576-aaf9-dbe1920e7577"), "N.77.35", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of air transport equipment" },
                    { new Guid("650f9942-46cd-4f8a-a427-f6a2c0df0585"), "N.77.39", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("e8491831-f196-4906-a747-22fe11e5dba7"), "N.77.4", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("0a75301e-31ff-4a4f-b8fc-03fe31138aff"), "N.77.40", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("4504b920-6a7f-4d6a-af7d-5560c2bbdc76"), "N.78", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Employment activities" },
                    { new Guid("083b780e-90a7-4cd7-b848-5b8439314d10"), "N.78.1", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Activities of employment placement agencies" },
                    { new Guid("327417c2-884c-4da8-b262-fe0b66cba82b"), "N.78.10", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Activities of employment placement agencies" },
                    { new Guid("e2b81894-ac0e-4372-9162-f21ff8afbd4d"), "N.78.2", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Temporary employment agency activities" },
                    { new Guid("b441ac75-52e1-4697-b423-567ef540bbca"), "N.78.20", new Guid("89a6f236-06ad-4e2e-9188-fc7391666941"), "Temporary employment agency activities" },
                    { new Guid("d097d97d-15f6-47c7-adc6-584ee38083d6"), "M.74.3", new Guid("139f607c-c5ff-41d7-adcf-05435d832ba7"), "Translation and interpretation activities" },
                    { new Guid("19267088-8064-4f24-9c09-7afe69a56de4"), "U.99.0", new Guid("b2357c9f-d1cd-4306-a8b0-4c32107de95a"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9f7e6088-79db-4795-b621-0ae4d7b3aaba"), "F.43.21", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Electrical installation" },
                    { new Guid("8ad25adc-0664-4efa-b18a-c18a4050fed6"), "F.43.13", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Test drilling and boring" },
                    { new Guid("2b40518d-9e20-4a86-99a1-9869f993c0c6"), "C.14.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of articles of fur" },
                    { new Guid("e3da9384-732c-40b7-8e3a-12dd4a351d0d"), "C.14.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of articles of fur" },
                    { new Guid("f7ab1ef1-4c90-4e18-928b-92db4a36773a"), "C.14.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("4a64f6cb-6e42-414a-ab62-51a466b5d112"), "C.14.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("57766d9c-716c-4cf7-913e-4aea19f8d9eb"), "C.14.39", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("6f8e8b12-2fc0-477d-b668-f38cf375e16c"), "C.15", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of leather and related products" },
                    { new Guid("6af88cd4-91b9-4269-8cc7-8950f78d9e93"), "C.15.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("fe90919d-c040-46cb-ab99-4dab1a2c7111"), "C.15.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("1060f2a2-f540-4ef9-bf54-d3910472e531"), "C.15.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("a35b677f-9a60-43fc-b550-2ba8360b79f8"), "C.15.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of footwear" },
                    { new Guid("756856a1-1272-46ed-b362-1ec1d552e472"), "C.15.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of footwear" },
                    { new Guid("667f3e92-5e7a-4dd0-9125-6637b374d041"), "C.16", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("33cbbfe8-00ee-4d6e-a303-d7533ee958f2"), "C.14.19", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("345b5c96-e787-417c-a04f-833267a7f157"), "C.16.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Sawmilling and planing of wood" },
                    { new Guid("d31e2747-8e68-4c22-a170-be184b64e794"), "C.16.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b82bc579-73fb-4974-8f80-829e872e79dd"), "C.16.21", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("c963910c-9df3-434e-8343-de1586c3a66c"), "C.16.22", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of assembled parquet floors" },
                    { new Guid("4a2e8509-6e25-425f-ada9-a7a7f6e0c59b"), "C.16.23", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("51783d93-8deb-4f7e-a6ea-1f7c0e155452"), "C.16.24", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wooden containers" },
                    { new Guid("34cd27dd-48e9-4422-9e57-e68320c434e3"), "C.16.29", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("b6bbd5c9-4660-4595-8644-ab54b4a6a029"), "C.17", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of paper and paper products" },
                    { new Guid("fbd19a73-988f-49c8-96e2-ebeb0fcc91ac"), "C.17.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("426f881f-72f7-4aaa-a420-e2af8443ff51"), "C.17.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of pulp" },
                    { new Guid("d7c106cd-fcc5-4e9b-b554-b1f32ec1d270"), "C.17.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of paper and paperboard" },
                    { new Guid("fbb97233-e5f0-4d59-8ac0-4b08b7966bd3"), "C.17.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("70cad065-fd3c-424e-8383-d1abe394e9ea"), "C.17.21", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("504c5519-b50a-454e-8741-32b1a28c403e"), "C.16.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Sawmilling and planing of wood" },
                    { new Guid("3fd1335e-3278-4af5-b18d-9eb6ec7781fd"), "C.14.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of underwear" },
                    { new Guid("4a1d2a88-cde6-44f5-86bc-86c4759eb0af"), "C.14.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other outerwear" },
                    { new Guid("cfe33f46-1dd6-4675-85b6-9a167d688cac"), "C.14.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of workwear" },
                    { new Guid("74771e97-baeb-4301-abb9-cad9e10f7522"), "C.11.02", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wine from grape" },
                    { new Guid("c8fa7de0-7152-45c1-b735-4ed960cdedb9"), "C.11.03", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cider and other fruit wines" },
                    { new Guid("0b8a92c7-7693-4e33-b809-cb9c3018f94a"), "C.11.04", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("fb283d9f-3721-47c0-a5be-89bf6b80cfc8"), "C.11.05", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of beer" },
                    { new Guid("75ea557a-a73d-4516-b099-1be1b02398df"), "C.11.06", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of malt" },
                    { new Guid("5601f35b-7cb8-4402-a778-9ff6d3683ea0"), "C.11.07", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("4f9aba62-a805-4268-a726-e8235e8a850f"), "C.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tobacco products" },
                    { new Guid("9eba434c-824c-4453-95c9-f188b7b4cf9f"), "C.12.0", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tobacco products" },
                    { new Guid("020c6384-c2dd-4df5-8d7c-abde524d42c8"), "C.12.00", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tobacco products" },
                    { new Guid("27ce23ef-7d83-452a-8b6e-0852728bf917"), "C.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of textiles" },
                    { new Guid("739f549b-16de-4bc8-9957-7ce822d97111"), "C.13.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Preparation and spinning of textile fibres" },
                    { new Guid("9e11ff8e-b6a5-4458-8b3a-00bfe00eb94a"), "C.13.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Preparation and spinning of textile fibres" },
                    { new Guid("141896f6-f243-4b1f-8dc7-df929988b1dd"), "C.13.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Weaving of textiles" },
                    { new Guid("c142e4e7-df81-42b7-997d-ef467b85a1ea"), "C.13.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Weaving of textiles" },
                    { new Guid("63778d40-8ae6-46e0-b4ad-ff3a69ecc852"), "C.13.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Finishing of textiles" },
                    { new Guid("fdc1e171-82d5-4967-89ab-b3b851301a5d"), "C.13.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Finishing of textiles" },
                    { new Guid("b1382f5a-0caf-43bc-9940-54b9c5272f54"), "C.13.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other textiles" },
                    { new Guid("cfce4c42-8d2b-4e9e-ac63-b53e0b832af5"), "C.13.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("bcb5eaf6-062f-42b9-9c99-d846c2fb91be"), "C.13.92", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("f6ef4613-ae8f-47a0-87fc-2a667514eb60"), "C.13.93", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of carpets and rugs" },
                    { new Guid("26342e99-6075-4e8a-99fe-24dd828a32ef"), "C.13.94", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("f6598b26-64c1-481a-9416-8e905b32da1c"), "C.13.95", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("a62bf8dd-6a7f-40fe-a7f1-ee863e38c625"), "C.13.96", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("5c5c7d33-8e42-47c7-a169-c990560bcf18"), "C.13.99", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other textiles n.e.c." },
                    { new Guid("ecc8f0ef-42a4-447f-8277-31d377cb076c"), "C.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wearing apparel" },
                    { new Guid("13846918-4a01-42e1-b71e-dc1721ab01c7"), "C.14.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("a4ffc3c3-7b0f-4916-b5f4-a093ad7327be"), "C.14.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("39d549a5-0dea-42fb-bda4-83c26f60dfb6"), "C.17.22", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("c13dfc0d-9055-4b9d-9a07-d103d6e8cdb1"), "C.11.01", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("9cbbef93-cc29-478f-9723-ecc4bda9d366"), "C.17.23", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of paper stationery" },
                    { new Guid("98bc119a-97a6-4688-8500-65374d1ea1da"), "C.17.29", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("1bf23fb4-4054-44c6-99f4-0fe8f0b095f1"), "C.20.52", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of glues" },
                    { new Guid("875744fb-3c90-4f97-8c40-58264bd7ee7a"), "C.20.53", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of essential oils" },
                    { new Guid("91927fe9-156d-4aec-af3f-021f256f346f"), "C.20.59", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("98ca1e8a-10d3-494c-a39d-e6ed0272081f"), "C.20.6", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of man-made fibres" },
                    { new Guid("c1226513-070d-47e1-ad27-185766374aef"), "C.20.60", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of man-made fibres" },
                    { new Guid("56887f1e-1b79-4087-b216-2896fefa977b"), "C.21", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("67bb95d6-3be5-482f-ab83-af4eb4898e27"), "C.21.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("6e9d9f5a-ded7-4544-8d0c-53688bac3adb"), "C.21.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("3cac427b-ca19-4b33-8f1d-6a1ea392fc11"), "C.21.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("896e51e1-389d-4e6c-ac98-180ee4b695fe"), "C.21.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("aaca4de0-0323-4a25-b3a2-65844ff10905"), "C.22", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of rubber and plastic products" },
                    { new Guid("4475b67d-ffce-46a0-8786-094c64acbdff"), "C.22.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of rubber products" },
                    { new Guid("bdfff0e2-cf0b-467e-a69b-63ae377cabf5"), "C.20.51", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of explosives" },
                    { new Guid("133a68d6-abab-4aee-b06c-e3c0940cc7d8"), "C.22.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("6145fce9-490c-4b55-b89c-f22d3141bf28"), "C.22.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of plastics products" },
                    { new Guid("e310d22f-52a0-4f4d-be2c-14d9349c3b5d"), "C.22.21", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("41ba1c8e-c604-49e3-b5a2-90d6ac810d35"), "C.22.22", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of plastic packing goods" },
                    { new Guid("e5a3af87-0b7d-4d19-9dde-9949eb1ce216"), "C.22.23", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("8aba9c6a-3023-4329-9ccb-423688d2e1ee"), "C.22.29", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other plastic products" },
                    { new Guid("b16a3e04-40c0-486c-b3ae-fd3083cd72c8"), "C.23", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("d07676f9-4cf5-4888-b042-e3e9eb71cbf7"), "C.23.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of glass and glass products" },
                    { new Guid("1c638844-cb9e-4760-b965-293a4df6e5d2"), "C.23.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of flat glass" },
                    { new Guid("a14c928f-5426-4c7a-a7eb-830f49a355e4"), "C.23.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Shaping and processing of flat glass" },
                    { new Guid("c9d8f598-8ce8-46c6-b3d0-44c88d3bb8e7"), "C.23.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of hollow glass" },
                    { new Guid("342d203e-9ced-48a9-8d00-f74e4ef8fbca"), "C.23.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of glass fibres" },
                    { new Guid("f663c97a-deac-436f-85c2-c51c7acd933f"), "C.23.19", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("e77ed9e1-7415-4535-a5c9-ab0a709d0bc3"), "C.22.19", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other rubber products" },
                    { new Guid("8d2d048e-f6f0-4b05-af98-a1110bfc5c51"), "C.20.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other chemical products" },
                    { new Guid("b4e17860-6a90-4140-a952-2a10dcf7c5f5"), "C.20.42", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("906894a0-98c3-4392-bf50-4b57bd85c00f"), "C.20.41", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("84ad50b6-5c76-4566-a2ed-598fe63bd7ab"), "C.18", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Printing and reproduction of recorded media" },
                    { new Guid("def26750-039b-4bcf-b8b0-eb8439a1ca0d"), "C.18.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Printing and service activities related to printing" },
                    { new Guid("f2edd24a-9767-4fac-a5c0-c8780374f2f0"), "C.18.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Printing of newspapers" },
                    { new Guid("ce5ef643-9032-4bc4-8569-7facc602c9d9"), "C.18.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Other printing" },
                    { new Guid("12866c98-8bc9-45ce-88fd-7261bbc5a5c6"), "C.18.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Pre-press and pre-media services" },
                    { new Guid("6ef0c3e8-ab01-4b05-b9e5-b7e4fb12ac9e"), "C.18.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Binding and related services" },
                    { new Guid("30b5349c-a832-4ff4-8c71-888a831761f0"), "C.18.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Reproduction of recorded media" },
                    { new Guid("c151508e-7ef3-47e9-a68b-88886d0a4a7f"), "C.18.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("74af4dad-caa4-4a19-9363-e9e3b954c999"), "C.19", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("c4c35d65-1ad9-4c68-a9d5-dbbb02c261d9"), "C.19.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of coke oven products" },
                    { new Guid("a6b8505d-7b40-4ee4-a552-75f025ab58b0"), "C.19.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of coke oven products" },
                    { new Guid("580e60bc-00be-417c-b30d-c0a7723f9c4f"), "C.19.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of refined petroleum products" },
                    { new Guid("6b6c3be3-1197-49e0-9188-2a68f6b2978c"), "C.19.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of refined petroleum products" },
                    { new Guid("bf5be5f9-3071-44df-a3ba-a9f85397e440"), "C.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of chemicals and chemical products" },
                    { new Guid("b2cee359-9682-42d5-a692-fcef63eed1b6"), "C.20.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("bb7357ad-434b-402a-bff2-497c7be40c61"), "C.20.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of industrial gases" },
                    { new Guid("8cd5d77b-11af-4420-a7f2-9e102f97c44e"), "C.20.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of dyes and pigments" },
                    { new Guid("033a1c3a-dbfd-433a-949a-5211cae5dcbd"), "C.20.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("83991f78-3576-43bc-97f4-8768321f254c"), "C.20.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other organic basic chemicals" },
                    { new Guid("e43c1534-48be-40ec-ba51-acd152584bc2"), "C.20.15", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("dfeb49f6-4c15-4d90-81f4-d85f7166e0c9"), "C.20.16", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of plastics in primary forms" },
                    { new Guid("4ccdd55e-b4b6-4f93-8615-49d8c07bd2a2"), "C.20.17", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("edd7354f-2850-4bc3-9c1f-db365d24a94c"), "C.20.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("b146470d-b36c-443a-aa67-45a76f3a9d3f"), "C.20.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("2a9303dc-0fbb-4acf-9192-3561d0561d75"), "C.20.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("cadf05b1-6859-42cc-8660-aba3b439d741"), "C.20.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("f2590ada-2411-428c-b2d6-0d87c2b99a1c"), "C.20.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("db519b19-7cbf-42ba-a4fd-608be2a728d5"), "C.17.24", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wallpaper" },
                    { new Guid("6b2e6512-716d-4e9d-989f-8d67507e62e5"), "C.23.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of refractory products" },
                    { new Guid("f38d07e2-c88b-4aa6-b2a0-b814a6a2214b"), "C.11.0", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of beverages" },
                    { new Guid("ffe3d2b0-b4b2-4730-877d-ef53c16f9a71"), "C.10.92", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of prepared pet foods" },
                    { new Guid("e351eb77-f46b-4165-a739-b0b56de8a95d"), "A.01.6", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("5cf73a05-42b3-4c65-8dac-9cf2f6e72b4a"), "A.01.61", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Support activities for crop production" },
                    { new Guid("74df3656-6c61-44ae-a0b2-ff09f9bdab65"), "A.01.62", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Support activities for animal production" },
                    { new Guid("2c4669a8-fc17-431f-a7eb-9063f180a3a6"), "A.01.63", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Post-harvest crop activities" },
                    { new Guid("8255ce42-48dd-4013-88d7-fbbf3b40ad88"), "A.01.64", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Seed processing for propagation" },
                    { new Guid("d39a903d-fe16-48d7-8e55-0e255e393d0c"), "A.01.7", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Hunting, trapping and related service activities" },
                    { new Guid("5519a4e8-f6a4-4f59-908b-840c761b2e22"), "A.01.70", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Hunting, trapping and related service activities" },
                    { new Guid("61c39421-60dd-49ca-b138-6f1c508f6236"), "A.02", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Forestry and logging" },
                    { new Guid("a1d01a52-e990-49c6-a224-c65aaa8c8c35"), "A.02.1", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Silviculture and other forestry activities" },
                    { new Guid("161422fe-79d7-4425-8841-aeb13ffb1074"), "A.02.10", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Silviculture and other forestry activities" },
                    { new Guid("116beb89-6053-4e29-b8e4-326eecab9302"), "A.02.2", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Logging" },
                    { new Guid("4208a212-d6cd-487d-a535-721b6f044d69"), "A.02.20", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Logging" },
                    { new Guid("6cd4eb3d-03af-4dca-89a5-24dddc32a0f4"), "A.01.50", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Mixed farming" },
                    { new Guid("0784111a-619b-4084-ad37-46195b65063b"), "A.02.3", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Gathering of wild growing non-wood products" },
                    { new Guid("1e5c1993-319a-452b-9470-7cbbacd46a02"), "A.02.4", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Support services to forestry" },
                    { new Guid("c7e81c6c-9a43-4cb9-b13e-180d5cf31d8b"), "A.02.40", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Support services to forestry" },
                    { new Guid("cadbbc56-48e7-43d0-b11b-effa410a3cb9"), "A.03", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Fishing and aquaculture" },
                    { new Guid("1274e58e-53ec-484c-82de-de6bde38fbd0"), "A.03.1", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Fishing" },
                    { new Guid("4669f5a4-5775-47d7-837d-86f3316f5c57"), "A.03.11", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("adb6f420-ad40-42b4-9354-d976b3fe1514"), "A.03.12", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Freshwater fishing" },
                    { new Guid("28a818e7-bb90-4ac0-8556-703382721126"), "A.03.2", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Aquaculture" },
                    { new Guid("b96da92f-3f52-4b31-93dd-e0d65db87b1e"), "A.03.21", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Marine aquaculture" },
                    { new Guid("02a9ddd6-ec6c-4abc-87ab-9400a5e388ab"), "A.03.22", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Freshwater aquaculture" },
                    { new Guid("a6125d52-f7cf-4780-946b-97b72279c917"), "B.05", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of coal and lignite" },
                    { new Guid("f7311d2b-1ae4-414d-9126-1517cb4ae7a7"), "B.05.1", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of hard coal" },
                    { new Guid("57fd7345-2ed9-430f-9110-d0801a4d79f4"), "B.05.10", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of hard coal" },
                    { new Guid("c49cc90e-e342-4077-8f68-797f94abd0ba"), "A.02.30", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Gathering of wild growing non-wood products" },
                    { new Guid("778840e7-5caa-48f5-a172-0b6d298698d4"), "A.01.5", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Mixed farming" },
                    { new Guid("e2b21e2d-84b4-4ac8-8571-4af8cfeaacfa"), "A.01.49", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of other animals" },
                    { new Guid("a090a55f-f874-49a0-8577-3a5cbe46e391"), "A.01.47", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of poultry" },
                    { new Guid("f2f2627b-bcfc-453f-9a74-59ed43bc478c"), "A.01.1", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of non-perennial crops" },
                    { new Guid("3dff0d27-7650-4887-ab5b-3d4f14f54fdc"), "A.01.11", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("2d42458a-2e0b-4956-aa47-3d166a0335e7"), "A.01.12", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of rice" },
                    { new Guid("4b8a2d8f-59ed-4082-9652-312aa0c62c98"), "A.01.13", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("6ffff813-9da3-4431-9f53-36f1549013ea"), "A.01.14", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of sugar cane" },
                    { new Guid("b1c2e082-1ec3-4772-9e98-946cd7b1b762"), "A.01.15", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of tobacco" },
                    { new Guid("d246fad8-925d-425c-92ce-c2caa7f3a6f9"), "A.01.16", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of fibre crops" },
                    { new Guid("6df24915-b63d-4fb3-aacc-9a7b41bbc7ab"), "A.01.19", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of other non-perennial crops" },
                    { new Guid("48bdcb0c-a5c6-4d5f-87f2-bbdbda474cb9"), "A.01.2", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of perennial crops" },
                    { new Guid("249784b3-60fc-4353-b888-578e32fe148c"), "A.01.21", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of grapes" },
                    { new Guid("44cf50a6-e451-4358-b311-4cb69f1449cd"), "A.01.22", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of tropical and subtropical fruits" },
                    { new Guid("086707b5-37a1-4803-8252-e0d017234b58"), "A.01.23", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of citrus fruits" },
                    { new Guid("134bad8a-ee32-4aac-a192-6f214981ea63"), "A.01.24", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of pome fruits and stone fruits" },
                    { new Guid("04a04161-8faa-4150-b179-df1d434e8c53"), "A.01.25", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("b8487053-8d7b-4013-8805-bd51032134cf"), "A.01.26", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of oleaginous fruits" },
                    { new Guid("cc937095-bd65-4077-a783-8e75ac9c1caa"), "A.01.27", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of beverage crops" },
                    { new Guid("fc97ae32-62c1-4b57-80ae-04b7761ca01f"), "A.01.28", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("7f4c059b-0e2a-4fe6-9213-f5f441ce350e"), "A.01.29", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Growing of other perennial crops" },
                    { new Guid("7b56d857-ee5f-46de-bce1-c4cfbc4c56f1"), "A.01.3", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Plant propagation" },
                    { new Guid("5200afd1-0c1a-4352-a9e7-83b45df3f029"), "A.01.30", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Plant propagation" },
                    { new Guid("a76bf4f0-eea9-47f0-837f-7012dcc1cce3"), "A.01.4", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Animal production" },
                    { new Guid("b0ad7c72-198c-44ee-8ba3-8ac78d3f8279"), "A.01.41", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of dairy cattle" },
                    { new Guid("04b622b2-13fe-4074-8d4d-9d25ffcd3037"), "A.01.42", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of other cattle and buffaloes" },
                    { new Guid("d54f9a18-f69d-4b65-a501-0074aec2197d"), "A.01.43", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of horses and other equines" },
                    { new Guid("25e9d88d-78d9-4af1-8eb5-49edf3fe6406"), "A.01.44", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of camels and camelids" },
                    { new Guid("25757c87-3d86-4151-8f03-4811f0d77f3a"), "A.01.45", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of sheep and goats" },
                    { new Guid("8ca7ff2b-2670-4c51-a951-ae37e5978d33"), "A.01.46", new Guid("1206b59d-248d-4690-b9cc-2525c4a2ada4"), "Raising of swine/pigs" },
                    { new Guid("0f54229d-1b46-4d3d-b926-ae7d6eac328d"), "B.05.2", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of lignite" },
                    { new Guid("6b553e9a-7777-4db7-96b2-46be17049333"), "C.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of beverages" },
                    { new Guid("c6848586-2b47-4325-a08f-4c9e9e814d20"), "B.05.20", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of lignite" },
                    { new Guid("3e51b64a-3a52-40b2-b404-e7a581d11e09"), "B.06.1", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fe80d38e-d8ff-4d57-8e6d-8c0b5996238f"), "C.10.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of potatoes" },
                    { new Guid("edafac79-5a25-4f3f-bb46-73a4c8f25b0e"), "C.10.32", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("605f4c57-3652-4805-a4e1-590f9aaf6189"), "C.10.39", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("5fd0776b-4025-4490-9236-81ee65f5a6cb"), "C.10.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("a48ced37-9bb2-4975-85e7-537459557cff"), "C.10.41", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of oils and fats" },
                    { new Guid("2da6acfc-f0d6-4dd9-bf2c-e494b668d70f"), "C.10.42", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("56e3e54d-aac4-49ef-8bfb-6242e36ae482"), "C.10.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of dairy products" },
                    { new Guid("73c1ffa2-4bc4-4ec6-bb00-63a4fc46226f"), "C.10.51", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Operation of dairies and cheese making" },
                    { new Guid("0256304b-e01f-458a-b16b-4ef27a07d377"), "C.10.52", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ice cream" },
                    { new Guid("8f2ec866-8f28-4ac9-9172-c7887cbd3af2"), "C.10.6", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("78aa7147-b1e6-444d-90ca-af37a8270917"), "C.10.61", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of grain mill products" },
                    { new Guid("2f53737e-8f5d-4f95-aaee-f59fce0b515b"), "C.10.62", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of starches and starch products" },
                    { new Guid("bd242b9c-f561-41da-9a6f-7a1f94d72a11"), "C.10.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("139c5f5f-e360-41ed-93b4-01aa72f56c85"), "C.10.7", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("800ffd1a-178c-47e1-8221-cfdd55b25b62"), "C.10.72", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("5d82f96e-272e-466c-9377-65081e4c9327"), "C.10.73", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("2ec5ff2b-d340-41f1-b0be-727b761b1919"), "C.10.8", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other food products" },
                    { new Guid("3c337890-1217-4047-ba3b-63647755ac8f"), "C.10.81", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of sugar" },
                    { new Guid("5ce910f0-00e0-4197-86bf-bf6d64fc404c"), "C.10.82", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("759b6bf3-ac67-4ff4-b677-0f158cc97397"), "C.10.83", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing of tea and coffee" },
                    { new Guid("10a2418f-9db7-406d-98e9-e403bd2b6546"), "C.10.84", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of condiments and seasonings" },
                    { new Guid("e16d5fde-5fcd-4b3f-b4b0-9205b039ecd2"), "C.10.85", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of prepared meals and dishes" },
                    { new Guid("9025c4c4-1469-4113-9819-aaa528260292"), "C.10.86", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("c28fa0c5-117f-444e-93f3-db93d99868c7"), "C.10.89", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other food products n.e.c." },
                    { new Guid("75f7ba09-2739-4464-bee1-f8cbc3a0292f"), "C.10.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of prepared animal feeds" },
                    { new Guid("d7c3b764-34d0-4057-bc17-8e05cdf04feb"), "C.10.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("9a80ca43-117d-4874-81e5-72f62f157266"), "C.10.71", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("6c5ea4c9-3f5f-4a9f-8570-905dfdd25498"), "C.10.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("e15dbdfd-f09d-4fef-a8f2-53ac537f2c90"), "C.10.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("96865c7e-966c-4308-ab60-3013c2ff7383"), "C.10.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Production of meat and poultry meat products" },
                    { new Guid("03c953cd-027e-4e8e-b0be-7a8fe1193ab2"), "B.06.10", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of crude petroleum" },
                    { new Guid("577bb3b5-cf4d-4750-b616-24e6d67c7e92"), "B.06.2", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of natural gas" },
                    { new Guid("083c92f3-3826-4f0f-877e-b65879c3a024"), "B.06.20", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of natural gas" },
                    { new Guid("24426991-535c-4517-bac2-920314f4d2b7"), "B.07", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of metal ores" },
                    { new Guid("38042f24-139c-43e8-8a68-5096c067a0dc"), "B.07.1", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of iron ores" },
                    { new Guid("4f46ef9f-62ad-4e57-890a-47d2e6e40efe"), "B.07.10", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of iron ores" },
                    { new Guid("400cc04e-2c46-493c-96eb-6aa4a37ed2a3"), "B.07.2", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of non-ferrous metal ores" },
                    { new Guid("a030af4f-b6c2-463e-a1d8-7d34fa3ecd09"), "B.07.21", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of uranium and thorium ores" },
                    { new Guid("8a8bc1e4-86a4-423b-875f-3cc01eef5203"), "B.07.29", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of other non-ferrous metal ores" },
                    { new Guid("05797225-fdd4-49cc-ac1a-9e73436a123b"), "B.08", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Other mining and quarrying" },
                    { new Guid("160fea0a-e395-48df-acd2-f623979d8b58"), "B.08.1", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Quarrying of stone, sand and clay" },
                    { new Guid("7750e89e-d0b1-487a-baaa-facfe12afa3d"), "B.08.11", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a4008e09-46c1-4cca-bda6-75fc610c9284"), "B.08.12", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("c0afc6d7-d285-45ac-8bb8-ee8dafe88536"), "B.08.9", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining and quarrying n.e.c." },
                    { new Guid("7f055cbb-359c-4102-b546-16af5b4b4641"), "B.08.91", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("b24cb4ae-9512-4956-b3a7-e84a79389532"), "B.08.92", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of peat" },
                    { new Guid("2a6f182b-0e7a-4a6b-a8ca-f13e96f6d877"), "B.08.93", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of salt" },
                    { new Guid("6533f864-9b72-4046-b0af-d12625bd5037"), "B.08.99", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Other mining and quarrying n.e.c." },
                    { new Guid("505e5a48-a221-4f0d-b64b-86d8e9b53081"), "B.09", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Mining support service activities" },
                    { new Guid("937a9d36-a9ee-47a5-bdc2-e7bd2e64c608"), "B.09.1", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("3eaf9f3f-c545-4598-96b9-3619e56ca4ff"), "B.09.10", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("c122d960-d682-428c-85dd-8fdf738ced5e"), "B.09.9", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Support activities for other mining and quarrying" },
                    { new Guid("7820c14f-3843-412e-a537-91c02f90e672"), "B.09.90", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Support activities for other mining and quarrying" },
                    { new Guid("57d38bc6-589f-47e9-a596-d893da6ad4d6"), "C.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of food products" },
                    { new Guid("2808cd77-4b98-4db9-ab15-05c3ecd7f437"), "C.10.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("a3bf290b-97c0-4f91-950d-19a72132a64b"), "C.10.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of meat" },
                    { new Guid("5dc93f4d-5364-47da-a002-718b8d58f96e"), "C.10.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing and preserving of poultry meat" },
                    { new Guid("fa8ec673-4de2-4816-8462-37f14511b613"), "B.06", new Guid("e410d45e-8735-4869-bf66-97eef88ebd8a"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("10186a03-07b4-457e-a42f-b91a6ff5fc37"), "F.43.2", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("66fb5f29-c639-41df-9f03-3e6182246e51"), "C.23.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of refractory products" },
                    { new Guid("3a5225da-401b-45ff-8419-22164d3f8048"), "C.23.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("1eff4652-2054-4f04-bef6-5124d963341f"), "C.30.92", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("19114e21-a814-494b-868c-b6cc405703a9"), "C.30.99", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("c0fba768-be85-4e5b-8986-1aefc69d9a7d"), "C.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of furniture" },
                    { new Guid("7ca80354-446c-4e4a-876c-a93b1636efdf"), "C.31.0", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of furniture" },
                    { new Guid("3f882a8a-3b7b-425f-bb8a-13b38ca66bce"), "C.31.01", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of office and shop furniture" },
                    { new Guid("d1efdbaa-b3c3-4053-ac93-762d2f71e3c7"), "C.31.02", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of kitchen furniture" },
                    { new Guid("176bea0b-a25d-4c42-b2c4-160f0f50d961"), "C.31.03", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of mattresses" },
                    { new Guid("de192de1-5c3d-4846-af73-94c9ee0bc35a"), "C.31.09", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other furniture" },
                    { new Guid("5a621732-c56a-4833-8180-4c4ed5c700b8"), "C.32", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Other manufacturing" },
                    { new Guid("b9cbba42-5361-4c6a-bce5-e8cd9bb6deba"), "C.32.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("de3d18a4-6076-4cc3-83a7-ab96ade26ef7"), "C.32.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Striking of coins" },
                    { new Guid("083942ec-7c2a-4888-9dda-8463b9db49c6"), "C.32.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of jewellery and related articles" },
                    { new Guid("aa7426f8-7521-455f-85fc-92782b4596dd"), "C.30.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of motorcycles" },
                    { new Guid("ee1d707f-8548-4eed-841a-228837937387"), "C.32.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("519ca74c-d9d5-4ac5-a3df-82870df71ad8"), "C.32.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of musical instruments" },
                    { new Guid("8ec41ce6-2602-4384-85de-13a6af97aadb"), "C.32.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of sports goods" },
                    { new Guid("a2ecc8bb-9926-4544-af0f-f05ef72f87a6"), "C.32.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of sports goods" },
                    { new Guid("370d2fb2-eb50-41d5-b2ee-bcf4398ff208"), "C.32.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of games and toys" },
                    { new Guid("766dbcb0-e918-4182-a6fd-7205478520d2"), "C.32.40", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of games and toys" },
                    { new Guid("10c1d738-bdf7-4297-ac66-265a457619e1"), "C.32.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("13d89496-1905-44aa-8ecc-afa287b9da6e"), "C.32.50", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("b4101604-5167-400c-9fff-b8b5e4b2fb9c"), "C.32.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacturing n.e.c." },
                    { new Guid("362c882f-9576-448c-bf6f-3947e3c9bf01"), "C.32.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bf6166b1-0a8a-4205-97d1-a442640ebe7a"), "C.32.99", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Other manufacturing n.e.c." },
                    { new Guid("5474da28-466a-4dab-b3cb-8424de5c931a"), "C.33", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair and installation of machinery and equipment" },
                    { new Guid("2a687d34-77da-49f5-bd47-ee9639d68f8e"), "C.33.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("82516705-d241-4820-acd1-1919f61d4db8"), "C.32.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of musical instruments" },
                    { new Guid("11f0b03a-f81a-4edf-b432-016b7f895992"), "C.30.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("e02b895e-596c-4bf7-8586-5b9bedc3cd7b"), "C.30.40", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of military fighting vehicles" },
                    { new Guid("7e25e0c0-8e6d-43df-995d-00940ce7811a"), "C.30.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of military fighting vehicles" },
                    { new Guid("859d3a75-873f-4f5f-af9a-9832cccce381"), "C.28.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("9468d9bd-fe28-45df-acc0-a6a1fc14ac29"), "C.28.41", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of metal forming machinery" },
                    { new Guid("ab4b05d3-8022-45cb-8e83-d377b8cc5440"), "C.28.49", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other machine tools" },
                    { new Guid("229e49a8-fecb-4ea3-8a20-18cd1001dce0"), "C.28.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other special-purpose machinery" },
                    { new Guid("fd1c03f2-a59e-4a37-8930-f820417fe7f6"), "C.28.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of machinery for metallurgy" },
                    { new Guid("80938758-d6c4-4b4f-a78e-028a153ad75a"), "C.28.92", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("7b4854eb-eab2-4c7e-80e6-1b801cf7e170"), "C.28.93", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("d0466ad0-3416-4547-b5f8-8389477ea629"), "C.28.94", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("749be9cc-d57c-4a70-9b4c-e4b7a4f721e4"), "C.28.95", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("4c4c3c41-2127-47e7-93b1-49ba17135f52"), "C.28.96", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("a54cc11d-8daf-4216-aa5d-1d428c252edd"), "C.28.99", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("4674a0db-16a7-4071-a3c0-a713c950d818"), "C.29", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("3995436d-7b75-4aa4-9baa-97d9cf351831"), "C.29.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of motor vehicles" },
                    { new Guid("e2ced6d9-4632-4e41-8c6c-0cdc34645553"), "C.29.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of motor vehicles" },
                    { new Guid("94799d50-6f28-4015-a099-cade885253db"), "C.29.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("3d89ba51-b152-4605-9e53-38e8bf03bde4"), "C.29.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("1d5278f0-0199-4048-b9a4-f56623acdecd"), "C.29.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("02956522-bcfd-4444-a890-b2e9785a839b"), "C.29.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("d4a43d27-2d0a-4796-929c-e7435e6c8800"), "C.29.32", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("8c56d8c0-4726-44bb-8a04-7c6d459ec6b1"), "C.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other transport equipment" },
                    { new Guid("d76d4d80-0d83-494f-9cf8-b77730a08f65"), "C.30.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Building of ships and boats" },
                    { new Guid("b8b3cf09-43d3-4dfd-aa0e-245af2a8d069"), "C.30.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Building of ships and floating structures" },
                    { new Guid("1eed56a4-5040-444f-9d20-054434208c4b"), "C.30.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Building of pleasure and sporting boats" },
                    { new Guid("119fa465-480f-491e-ae89-cb73b83432c1"), "C.30.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("50a42544-49cc-463e-a9e1-0ba30a5f6aba"), "C.30.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("a39d977f-01a5-4d6a-80be-03aedb4356b4"), "C.30.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("5240eeec-d4b4-484c-be5b-6a7335555c7d"), "C.30.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("995cc3ed-3dd2-49a3-92e6-6e3df843994a"), "C.33.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair of fabricated metal products" },
                    { new Guid("37481d5e-71b3-4840-83dc-06e83d2eccec"), "C.28.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("57fa0155-35c7-499a-9fc6-a52e37251c2a"), "C.33.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair of machinery" },
                    { new Guid("87436859-c114-4c9f-8e08-ce820e55e89c"), "C.33.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair of electrical equipment" },
                    { new Guid("ccc6d1ab-1c48-4973-acca-2da74a45fe9e"), "E.38.3", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Materials recovery" },
                    { new Guid("acc1e5ab-0464-44e7-84dc-ae29a18db0da"), "E.38.31", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Dismantling of wrecks" },
                    { new Guid("f3ca9059-0870-4db5-b632-5484fcf491bd"), "E.38.32", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Recovery of sorted materials" },
                    { new Guid("12a08b88-a550-42fb-a1ec-f248ba3cc82b"), "E.39", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("540ab6a7-7802-455c-b321-b314d0897f20"), "E.39.0", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Remediation activities and other waste management services" },
                    { new Guid("67e3d72d-3e28-4e14-848f-af2dabfbc2d7"), "E.39.00", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Remediation activities and other waste management services" },
                    { new Guid("b9f5ab3c-7fa3-4fd5-88b0-9358da755dad"), "F.41", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of buildings" },
                    { new Guid("93409111-d86e-4888-92a3-0e9e992683d0"), "F.41.1", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Development of building projects" },
                    { new Guid("832217dc-787a-47ff-877d-e5f752c1a116"), "F.41.10", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Development of building projects" },
                    { new Guid("51175b9c-e203-450d-b378-98cfe13b138b"), "F.41.2", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of residential and non-residential buildings" },
                    { new Guid("18ecfa1e-b943-4f88-9fef-c1e42d21adf0"), "F.41.20", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of residential and non-residential buildings" },
                    { new Guid("d5d0fba7-4937-4345-b61d-641ed8a80b11"), "F.42", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Civil engineering" },
                    { new Guid("a29dd322-5cf1-4ffa-8228-ecf576395644"), "E.38.22", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Treatment and disposal of hazardous waste" },
                    { new Guid("f4f973cb-2d58-47b4-8238-65986647a90e"), "F.42.1", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of roads and railways" },
                    { new Guid("b1121e86-3fe0-43d2-b7fc-8c467b647209"), "F.42.12", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of railways and underground railways" },
                    { new Guid("1e7535f7-ea73-4271-be2a-23fdd0c5609e"), "F.42.13", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of bridges and tunnels" },
                    { new Guid("ec8605a0-a81f-4e38-9b46-cde6c7c6d491"), "F.42.2", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of utility projects" },
                    { new Guid("13c06034-98f1-40b7-b754-ad082d67ce8d"), "F.42.21", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of utility projects for fluids" },
                    { new Guid("61bd2357-24ba-4048-8079-5086b61549bb"), "F.42.22", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("15583b5a-ef11-4448-951f-7157cc088ad9"), "F.42.9", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of other civil engineering projects" },
                    { new Guid("a8c4d06f-9db7-49f1-ba07-59e53e86a654"), "F.42.91", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of water projects" },
                    { new Guid("bd4f27a7-6c2a-4cae-a973-13e2edf0ec05"), "F.42.99", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("2927b25b-4a14-4596-80eb-f03538ee1e07"), "F.43", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Specialised construction activities" },
                    { new Guid("96a78d2e-f153-4d7d-8d4b-149c80fde6b6"), "F.43.1", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Demolition and site preparation" },
                    { new Guid("ee04da74-9f67-452b-9407-2b96b5fae726"), "F.43.11", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Demolition" },
                    { new Guid("5bb68b47-5efb-48ec-b016-cd89c08ce1c3"), "F.43.12", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Site preparation" },
                    { new Guid("7634d9ee-5bd5-44c8-9a4a-4ab4a1fdaf97"), "F.42.11", new Guid("79ec8a56-1f1b-47c1-9566-bd52ea5d069e"), "Construction of roads and motorways" },
                    { new Guid("e3a72e22-a8b3-4df5-8d9c-5879ca6f2f13"), "E.38.21", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("5a613fae-9822-4842-9a53-88fa71314c38"), "E.38.2", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Waste treatment and disposal" },
                    { new Guid("6ef2b0b7-90df-4f9b-81d6-edd3bb3c9a91"), "E.38.12", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Collection of hazardous waste" },
                    { new Guid("978eae22-4e13-4af2-bb84-363d80def560"), "C.33.15", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair and maintenance of ships and boats" },
                    { new Guid("1f5397ce-42f6-409d-ae92-dcf83c93fc50"), "C.33.16", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("30351e06-e133-45f1-af1b-a275fe536b63"), "C.33.17", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair and maintenance of other transport equipment" },
                    { new Guid("1b379513-059e-4aa7-8e5f-8a5d3fa46c70"), "C.33.19", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair of other equipment" },
                    { new Guid("e4770e76-4419-4718-ba0e-6a0ac8d7a3d4"), "C.33.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Installation of industrial machinery and equipment" },
                    { new Guid("abc9553f-cf4d-4054-8c9f-b8544a0326e5"), "C.33.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Installation of industrial machinery and equipment" },
                    { new Guid("246c2e1f-c57a-4b57-947e-261c657144f8"), "D.35", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("8fb0d960-2a2e-48ab-beda-5550427936b6"), "D.35.1", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Electric power generation, transmission and distribution" },
                    { new Guid("4a3999ca-8f1c-4249-94f2-cdd9f3944023"), "D.35.11", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Production of electricity" },
                    { new Guid("a6c3f723-49db-45d2-ab13-444dd88bf9e3"), "D.35.12", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Transmission of electricity" },
                    { new Guid("e0b2bf73-3e43-4b6f-9b75-27cc956c1439"), "D.35.13", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Distribution of electricity" },
                    { new Guid("7c9df3cb-c297-4a1e-a28c-af7bf4c7446c"), "D.35.14", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Trade of electricity" },
                    { new Guid("6d85c33d-4a48-4e0b-b59d-cefe5f7326b2"), "D.35.2", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("65f4ae3a-ea4b-447c-a381-f65bb556ddbf"), "D.35.21", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Manufacture of gas" },
                    { new Guid("76297c40-dfd3-4210-b78b-4dff067a072c"), "D.35.22", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Distribution of gaseous fuels through mains" },
                    { new Guid("af9f6f79-d521-47b1-8ba2-39022e036871"), "D.35.23", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("62391678-a50a-498e-b78f-5f171a1c9ee3"), "D.35.3", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Steam and air conditioning supply" },
                    { new Guid("c2d8b4dd-e50b-43ca-acbc-f2bb1f4cc256"), "D.35.30", new Guid("8ff8ee95-b669-4044-86ce-cfb95372f53e"), "Steam and air conditioning supply" },
                    { new Guid("94865d1d-8345-40a0-ad39-353df9979d3f"), "E.36", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Water collection, treatment and supply" },
                    { new Guid("fe98fea2-8b8a-4b09-9436-c1eb32db2244"), "E.36.0", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Water collection, treatment and supply" },
                    { new Guid("a43c6e85-c3ba-4b07-87a4-95b0c31c4017"), "E.36.00", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Water collection, treatment and supply" },
                    { new Guid("d903c597-9545-473d-b437-d5537486a13b"), "E.37", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Sewerage" },
                    { new Guid("c489c893-6902-41b8-ba11-5306dd16dbe1"), "E.37.0", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Sewerage" },
                    { new Guid("f06c3a30-454a-4999-81ef-63d662e4ab02"), "E.37.00", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Sewerage" },
                    { new Guid("607eec02-5e27-4923-986d-ab6d744fcc66"), "E.38", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("58c4f66b-1407-4d14-9663-1d841dcfae6d"), "E.38.1", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Waste collection" },
                    { new Guid("89cc90db-f764-4f81-9bd6-f000d774a405"), "E.38.11", new Guid("4e9c7e3b-1848-4d23-8686-96444e727ca8"), "Collection of non-hazardous waste" },
                    { new Guid("e61c6070-b1fe-49bb-a921-d9a32484fe16"), "C.33.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Repair of electronic and optical equipment" },
                    { new Guid("581e0521-ceb3-420f-938f-6f8dc8ba3ff5"), "C.23.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of clay building materials" },
                    { new Guid("93e5491c-d7f9-4df5-a84a-e0e702d0f8e0"), "C.28.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("841b34a1-86b3-4861-9f7c-b4994f62dd8f"), "C.28.25", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("90af034d-c595-4ef7-8800-555e6112f1b8"), "C.24.34", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Cold drawing of wire" },
                    { new Guid("d58ddbff-cadb-479e-b605-f5e505598b57"), "C.24.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("c6d3f2b8-867a-4712-ab68-7ac5e8e51d85"), "C.24.41", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Precious metals production" },
                    { new Guid("f853033a-5d06-482d-857e-9df2719c5e15"), "C.24.42", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Aluminium production" },
                    { new Guid("e02e2dbc-23ca-49eb-ab47-636f18ae322f"), "C.24.43", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Lead, zinc and tin production" },
                    { new Guid("842111b9-dc1e-4b55-a5c9-60e8a30ebda7"), "C.24.44", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Copper production" },
                    { new Guid("2f126c97-a48e-424b-b052-5656f6a5f4f3"), "C.24.45", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Other non-ferrous metal production" },
                    { new Guid("ba23a896-4f6f-4e62-b9ce-a957a67db624"), "C.24.46", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Processing of nuclear fuel" },
                    { new Guid("b07e25d0-ae96-4d53-893b-822aab36ebeb"), "C.24.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Casting of metals" },
                    { new Guid("af839001-f15d-44d7-8d50-60a697188622"), "C.24.51", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Casting of iron" },
                    { new Guid("3f3a4b73-d5f8-4054-bfbd-d1ad721a6a5e"), "C.24.52", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Casting of steel" },
                    { new Guid("3ae592e3-2902-4e60-8ab5-b78b0f72a9c6"), "C.24.53", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Casting of light metals" },
                    { new Guid("74c39768-1589-43a1-8afc-03901512cd55"), "C.24.33", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Cold forming or folding" },
                    { new Guid("248c3911-0ce1-4a45-9edf-89e00f1c523a"), "C.24.54", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Casting of other non-ferrous metals" },
                    { new Guid("e7b5b895-33d4-478e-b90a-0aea6d8aac97"), "C.25.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of structural metal products" },
                    { new Guid("5f51c6df-8492-4070-be27-fb4bf708a1bd"), "C.25.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("488dbceb-9928-449e-bc7c-2499893da5da"), "C.25.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of doors and windows of metal" },
                    { new Guid("0506a9ab-d4ac-439b-b4a1-2902b972cd8f"), "C.25.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("06c32759-e865-492a-95eb-a920a12a95fe"), "C.25.21", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("e11716b8-36e2-41fc-b648-f6441e2ec1a3"), "C.25.29", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("22f4c7d0-014e-4517-99e2-1006707254ee"), "C.25.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("6899b039-b429-401e-974a-e5879403a4b8"), "C.25.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("b6fde68b-a431-4b4d-8a00-c0320410660a"), "C.25.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of weapons and ammunition" },
                    { new Guid("0e8622d0-8e09-46b5-ba63-f1667971daaa"), "C.25.40", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of weapons and ammunition" },
                    { new Guid("07b45a4a-ae85-4a3d-b229-1ed7f8350e3d"), "C.25.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("3ac2e277-21fb-4894-a849-784680651d4b"), "C.25.50", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("f5a654ac-074c-4553-ad41-d6991b4015f9"), "C.25", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ef473969-6773-40b7-91b0-51c378e36ee0"), "C.24.32", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Cold rolling of narrow strip" },
                    { new Guid("98aacaae-2630-4dcc-9540-1d5f1d336da6"), "C.24.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Cold drawing of bars" },
                    { new Guid("1068d24e-261d-44b8-bba2-df14789215ac"), "C.24.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other products of first processing of steel" },
                    { new Guid("5a591101-9df8-46f1-a3bc-a7e7fcc31651"), "C.23.32", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("c1d0c126-80d5-4ed2-91f6-0acaee0f6e2a"), "C.23.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("5b960f7e-87c2-43ec-84d7-1f78f9f9ad85"), "C.23.41", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("2b5ac3f7-2c5a-4dbf-bb12-9b358544f84d"), "C.23.42", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("ff80f314-422b-44fb-8f35-3b57886d9a91"), "C.23.43", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("8623cf3f-84c1-4294-83f1-30c4a8c91a8f"), "C.23.44", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other technical ceramic products" },
                    { new Guid("97ac5fc2-799d-45f1-8f00-bbbfc8c63612"), "C.23.49", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other ceramic products" },
                    { new Guid("2afbf8d4-c765-4745-8946-005de9419b9d"), "C.23.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cement, lime and plaster" },
                    { new Guid("985c0f1d-57e6-49dc-a891-41651e946b41"), "C.23.51", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cement" },
                    { new Guid("01ba7302-31b4-4306-b847-511748c9109f"), "C.23.52", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of lime and plaster" },
                    { new Guid("047e7656-c343-419c-8d7a-b861bfe1d236"), "C.23.6", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("78e2441b-c62f-4740-b744-b0781d564c71"), "C.23.61", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("f48bc567-205e-4543-9ca6-cef97c1f31f9"), "C.23.62", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("94cacf7f-f7fb-4d01-a506-60c5b931c394"), "C.23.63", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ready-mixed concrete" },
                    { new Guid("d8750598-20c6-4183-adcc-9f7bced0a2ff"), "C.23.64", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of mortars" },
                    { new Guid("ce970122-2755-499d-af8a-847f36ec9efa"), "C.23.65", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fibre cement" },
                    { new Guid("56a4cf10-4292-4763-859f-32955252f5b1"), "C.23.69", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("33f1fda0-9685-491e-85eb-2f9abc7528da"), "C.23.7", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Cutting, shaping and finishing of stone" },
                    { new Guid("d7448736-82cd-4b85-81b5-7a88f09f8d96"), "C.23.70", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Cutting, shaping and finishing of stone" },
                    { new Guid("3a234e53-e746-468e-8b38-80e847099515"), "C.23.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("5dbc3143-861b-4c63-b0bb-da3240cd7943"), "C.23.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Production of abrasive products" },
                    { new Guid("3ecaf091-4c1d-4ac4-b63b-a8db11b4daa3"), "C.23.99", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("8274b7aa-7bee-4dba-9722-65a881edc9bd"), "C.24", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic metals" },
                    { new Guid("da65e4e7-b894-460e-9663-58683238b85c"), "C.24.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("97a13db6-925c-4420-a4f2-b1716e227592"), "C.24.10", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("987c91b3-4ee1-4b9b-8811-d3a88796b206"), "C.24.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("e18f7205-8d97-409f-90fb-f3e7a7920006"), "C.24.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("b593b83a-5fee-4e1a-b249-f7f0b486a3c7"), "C.25.6", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Treatment and coating of metals; machining" },
                    { new Guid("334ad851-c5f4-48a0-bc39-c7ca4d7e6196"), "C.28.29", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("8610f26b-1e19-4593-9d8e-1a76bcce31ad"), "C.25.61", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Treatment and coating of metals" },
                    { new Guid("3f71ec8b-bca0-4ae2-bc21-72ae62341f84"), "C.25.7", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("65f5a78b-6661-4edb-b08c-497d7a709411"), "C.27.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("bb3991a8-f89b-46e7-9e6d-61df3ad6aec3"), "C.27.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of batteries and accumulators" },
                    { new Guid("e9025fc6-d11f-4d58-aae7-92263668ec93"), "C.27.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of batteries and accumulators" },
                    { new Guid("d09ea8ed-18f4-4078-8b95-d46c197883f4"), "C.27.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wiring and wiring devices" },
                    { new Guid("97c93959-73b8-4fb6-aa24-a5f555b2c2ae"), "C.27.31", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fibre optic cables" },
                    { new Guid("e328d915-20e1-49a7-acaa-b1b6199b2843"), "C.27.32", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("51a8b1d4-1ed7-4625-b579-c4d8c054564d"), "C.27.33", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wiring devices" },
                    { new Guid("26ecf387-60ad-4314-8b5c-baf6402dc3ca"), "C.27.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e033b5df-5840-44d8-a657-33ca1fc9bd95"), "C.27.40", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electric lighting equipment" },
                    { new Guid("e81b2376-3525-468c-a1f7-40f407332dda"), "C.27.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of domestic appliances" },
                    { new Guid("5b824e18-6490-47ff-a849-868ce57f1847"), "C.27.51", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electric domestic appliances" },
                    { new Guid("c7867ccc-e186-4fc6-8257-ac65113a1643"), "C.27.52", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("29c49aaf-dbb5-4eb5-a8e6-c169a02af30a"), "C.27.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("db2e9c0c-f63e-44e5-84e2-46f85a081c0c"), "C.27.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other electrical equipment" },
                    { new Guid("7055d260-e197-47dd-9a2f-2d257dee707a"), "C.28", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("ac4ca77c-cf9a-47e1-adcd-aeb9ba1e39d2"), "C.28.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of general-purpose machinery" },
                    { new Guid("0e7654c5-c992-4f18-b5cf-a0d27c6070bb"), "C.28.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("07560aa1-f797-494e-940f-5fa901001718"), "C.28.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fluid power equipment" },
                    { new Guid("3744edd4-c52e-4ed9-b30b-3ed7459e9a9e"), "C.28.13", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other pumps and compressors" },
                    { new Guid("d1130474-54c0-441d-abff-5a22d966aec3"), "C.28.14", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other taps and valves" },
                    { new Guid("d924b83c-0c15-495e-9120-59918089f00e"), "C.28.15", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("8901e1d0-66d5-4b62-8150-d8c9eb3fc4b0"), "C.28.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other general-purpose machinery" },
                    { new Guid("7c142dc7-c2a5-4efc-adcc-5c85b097cad9"), "C.28.21", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("379c3fbd-98df-4a61-a444-83fbd9da7ad0"), "C.28.22", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of lifting and handling equipment" },
                    { new Guid("96b23822-2cdd-462b-9012-fe9ea3488cda"), "C.28.23", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("8d0740be-aa33-448c-b7bf-d40182aebb98"), "C.28.24", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of power-driven hand tools" },
                    { new Guid("d653db12-1825-4e4c-ae4f-19b377d8e903"), "C.27.90", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other electrical equipment" },
                    { new Guid("fe8a5ffd-7c0f-43e6-bc83-0f26866d22b8"), "C.27.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("4dc62d2d-5c6d-4768-a491-00dd7ff6f748"), "C.27", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electrical equipment" },
                    { new Guid("f2c86b5c-76e8-4515-8bec-c647fe634bea"), "C.26.80", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of magnetic and optical media" },
                    { new Guid("a713b2c1-6cdc-4ef9-a0c0-f8352da42458"), "C.25.71", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of cutlery" },
                    { new Guid("0c83ea92-b683-494a-abe9-b2bdd531120e"), "C.25.72", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of locks and hinges" },
                    { new Guid("a8259268-5144-43aa-a08f-3b44761f3def"), "C.25.73", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of tools" },
                    { new Guid("62ee2b88-bf94-4d4d-8179-d924ad0e8335"), "C.25.9", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other fabricated metal products" },
                    { new Guid("34508375-8dea-4803-9fd4-8b37b6517df5"), "C.25.91", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of steel drums and similar containers" },
                    { new Guid("f1859669-e804-4cb2-bcf2-fd38557cbe28"), "C.25.92", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of light metal packaging" },
                    { new Guid("a3ffa082-c770-4b59-9ba6-b571555de75c"), "C.25.93", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of wire products, chain and springs" },
                    { new Guid("43c8c68d-c3d9-41bf-95cb-cc536751b349"), "C.25.94", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("e24107dd-98b6-4904-a476-0737eb04739e"), "C.25.99", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("53355e32-dbd1-49f0-a9a9-7b4b3f376b0c"), "C.26", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("61498b20-8008-4ec5-9a54-ed949354d04f"), "C.26.1", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electronic components and boards" },
                    { new Guid("d6523487-ebbc-44d4-8ea5-f5114204170e"), "C.26.11", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of electronic components" },
                    { new Guid("9a31f78f-04ec-478f-bf5f-7ffb79beab03"), "C.26.12", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of loaded electronic boards" },
                    { new Guid("a73fd9ae-39ed-4054-93ff-c4395a4cc73b"), "C.26.2", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("b3499cc3-aa29-4349-b583-3a03e66f256c"), "C.26.20", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("e5593641-c292-475c-bac4-dfef35215bb4"), "C.26.3", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of communication equipment" },
                    { new Guid("91c7ec09-ac1d-463d-8247-a98b89efa227"), "C.26.30", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of communication equipment" },
                    { new Guid("5274bcb0-2818-4786-8b16-17a29259b616"), "C.26.4", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of consumer electronics" },
                    { new Guid("067eac02-c4bc-4be2-9569-b6b43b764c6d"), "C.26.40", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of consumer electronics" },
                    { new Guid("cc208de2-527c-4bfa-bfe4-aface9b6661a"), "C.26.5", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("afd8e90b-46f6-412c-89dc-af6ad882365e"), "C.26.51", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("cfb8338c-2146-4a3e-8db0-a8ab7fa930bd"), "C.26.52", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of watches and clocks" },
                    { new Guid("adccf99c-c18f-45e3-bc74-9ff94fab56f0"), "C.26.6", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("13d00851-788b-4be4-a9a5-0dcd5b3341c6"), "C.26.60", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("ee76e9e6-6bae-4ecb-8137-0eb3cba9844d"), "C.26.7", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("3001d7f0-93cc-4823-8a33-1ad89e329019"), "C.26.70", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("1cf84355-feea-4c65-a660-db636962a1e1"), "C.26.8", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Manufacture of magnetic and optical media" },
                    { new Guid("7cb6542e-f86c-454c-a8c1-165331a66280"), "C.25.62", new Guid("7f92b51d-8222-45c0-9e74-8c498409ab7a"), "Machining" },
                    { new Guid("f3ca2a51-9df0-42c5-b5e8-088f3e74205a"), "U.99.00", new Guid("b2357c9f-d1cd-4306-a8b0-4c32107de95a"), "Activities of extraterritorial organisations and bodies" }
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
                name: "IX_Plan_SpecificAttributes_BusinessPlanId",
                table: "Plan_SpecificAttributes",
                column: "BusinessPlanId");

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
                name: "Plan_SpecificAttributes");

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
