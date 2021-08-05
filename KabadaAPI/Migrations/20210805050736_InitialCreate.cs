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
                    IsCustomerSegmentsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerRelationshipCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("021ab522-e35e-4fb6-8d86-f00fe10a8824"), "AT", "Austria" },
                    { new Guid("e85c27ff-6872-454c-83e4-582e007c3685"), "LU", "Luxembourg" },
                    { new Guid("4a795978-699c-40b3-be48-90a4aabc463d"), "MT", "Malta" },
                    { new Guid("778e71e5-76c7-4b8a-9045-a90091b43099"), "MK", "North Macedonia" },
                    { new Guid("25fff7b7-41cc-4d8d-a48e-c72e7b5fc0a8"), "NO", "Norway" },
                    { new Guid("dfd37e1c-8564-4be9-b4b7-d8d578910b98"), "PL", "Poland" },
                    { new Guid("0c7cc391-c6b7-4390-9b69-212de6664d71"), "PT", "Portugal" },
                    { new Guid("4f13e2d9-9ba8-4c06-8f1e-ea3d18b90d9a"), "RO", "Romania" },
                    { new Guid("c646ccfa-6601-40b8-8c70-d65f6a1e11d6"), "RS", "Serbia" },
                    { new Guid("bce5ecbb-4400-4a33-b222-e0147095ef85"), "SK", "Slovakia" },
                    { new Guid("0d265b9a-043a-4438-8f09-bdc526791969"), "SI", "Slovenia" },
                    { new Guid("4ef7ba15-eef0-4657-8369-7ee4f5be86a8"), "ES", "Spain" },
                    { new Guid("d7e52704-5607-4071-9835-0e2dd86a88c2"), "SE", "Sweden" },
                    { new Guid("8a5c727f-5a95-4cc3-8502-d1c8b3f053b2"), "CH", "Switzerland" },
                    { new Guid("c1f62937-f558-4248-9a0b-315bf0ea0741"), "TR", "Turkey" },
                    { new Guid("bad56838-edae-4d6e-a96c-4964cfff9436"), "UK", "United Kingdom" },
                    { new Guid("427688d9-954b-4909-99fd-396209c41073"), "LT", "Lithuania" },
                    { new Guid("c228f059-30fb-467c-92d1-34f5c403238e"), "LI", "Liechtenstein" },
                    { new Guid("9b4d3416-9e4a-46cd-9f52-d86759eda7e0"), "NL", "Netherlands" },
                    { new Guid("ea9216bd-e844-49a9-8a30-eb56fdfe777d"), "IT", "Italy" },
                    { new Guid("88217e8e-a1e3-4fc1-b4c2-2de8bfff1f6e"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("f7188b7d-dcdd-41c3-9e5e-ab9930af6817"), "BE", "Belgium" },
                    { new Guid("3ec8b7aa-cfbc-42c2-9f05-6603feac54f2"), "BG", "Bulgaria" },
                    { new Guid("56acf8b9-c982-4a33-b22b-35899653ecf8"), "LV", "Latvia" },
                    { new Guid("1e6b2e6f-521c-4ae9-a616-386de5a61757"), "CY", "Cyprus" },
                    { new Guid("70852801-5e00-497c-b59e-757f8a160553"), "CZ", "Czechia" },
                    { new Guid("66112b4a-a00f-4cae-88e3-5be7ea02643c"), "DK", "Denmark" },
                    { new Guid("399383b1-8a16-42fe-9185-2752b05aec14"), "EE", "Estonia" },
                    { new Guid("70fe59cf-5f05-4ce6-8ad5-ce8994197ad1"), "HR", "Croatia" },
                    { new Guid("f8d4297c-00f6-46b8-a0e0-564a9ff5247c"), "FR", "France" },
                    { new Guid("3cf5c05d-fa89-4bc9-96d7-f9bab8a09911"), "DE", "Germany" },
                    { new Guid("5d19262d-55d4-4921-b242-8357cee7f46a"), "EL", "Greece" },
                    { new Guid("8f38b228-31f2-4c84-87c8-41ce2cf4ef98"), "HU", "Hungary" },
                    { new Guid("b9005c55-e830-48f8-8f42-5c830b1c91d0"), "IS", "Iceland" },
                    { new Guid("6e6d3ebe-dd75-4883-b1dc-d93e957b5c53"), "IE", "Ireland" },
                    { new Guid("fea5bc4c-0cbd-46b3-beb1-4ec8433de138"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "P", "EN", "Education" },
                    { new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("5d20d174-871b-4a7a-9b75-c4daf279e8a3"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "L", "EN", "Real estate activities" },
                    { new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "J", "EN", "Information and communication" },
                    { new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "B", "EN", "Mining and quarrying" },
                    { new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "H", "EN", "Transporting and storage" },
                    { new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "F", "EN", "Construction" },
                    { new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("abac8698-9687-4533-831c-edd96128e214"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "C", "EN", "Manufacturing" },
                    { new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("30d933cc-3e89-4829-801e-7242bdc2d848"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("5f2da5be-64b0-473b-80c5-9f4aab7c1288"), (short)23, null, new Guid("6bcd36d5-b7b3-4353-b023-44bb809d3f03"), (short)3, "Equipment" },
                    { new Guid("2451bf53-eaef-44c9-8b9b-f30fe33af2c7"), (short)23, null, new Guid("6bcd36d5-b7b3-4353-b023-44bb809d3f03"), (short)4, "Other" },
                    { new Guid("dee9b308-10ca-44c9-9b23-24b041470481"), (short)23, null, new Guid("57a8c93b-edfd-4abc-851a-8e9fa6a42353"), (short)1, "Other" },
                    { new Guid("e3ddf457-02e7-4ac2-a32f-24ba90dcdfe1"), (short)23, null, new Guid("d35ad59e-909a-4aa2-b70e-9dbb938a4592"), (short)1, "Other" },
                    { new Guid("3f8f8161-4252-482d-abdb-dc254d1508ff"), (short)23, null, new Guid("6bcd36d5-b7b3-4353-b023-44bb809d3f03"), (short)2, "Office" },
                    { new Guid("d35ad59e-909a-4aa2-b70e-9dbb938a4592"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("3e581281-d696-434c-a5d1-36c57fd4728f"), (short)23, null, new Guid("6bcd36d5-b7b3-4353-b023-44bb809d3f03"), (short)1, "Manufacturing building" },
                    { new Guid("0268a224-eaba-4a7a-81a6-6fa527571eb0"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("ae765843-26f4-416e-8ad6-ff9c855c506d"), (short)23, null, new Guid("2b1a5666-67e4-4f9d-badd-0cbc38f14cf3"), (short)1, "Other" },
                    { new Guid("2b1a5666-67e4-4f9d-badd-0cbc38f14cf3"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("1ef2a230-ec8f-4f4b-9fd2-8a53aecc4e28"), (short)23, null, new Guid("0268a224-eaba-4a7a-81a6-6fa527571eb0"), (short)1, "Other" },
                    { new Guid("891481bc-022f-4f3a-97c4-fc3a4c81638f"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("367f64bf-c468-4e83-bd00-69417a7a3704"), (short)23, null, new Guid("2408b7b4-6dc8-46d7-bf25-0eb281d15c01"), (short)1, "Other" },
                    { new Guid("2408b7b4-6dc8-46d7-bf25-0eb281d15c01"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("6bcd36d5-b7b3-4353-b023-44bb809d3f03"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("46fde0db-7666-4c46-b197-f5d6be2aa464"), (short)23, null, new Guid("891481bc-022f-4f3a-97c4-fc3a4c81638f"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("b01acccc-24c0-4dd9-817e-4ddafd72d316"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("408dad0d-0ba6-4c7d-b0f8-5e70c5d60592"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("102b63e0-d638-424f-93cd-6f6dc846a5a5"), (short)23, null, new Guid("408dad0d-0ba6-4c7d-b0f8-5e70c5d60592"), (short)1, "Other" },
                    { new Guid("a0111704-8c1f-4d82-a846-e89af138eabb"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("d0d53355-4ef5-46ab-afa7-69302a39bd12"), (short)23, null, new Guid("a0111704-8c1f-4d82-a846-e89af138eabb"), (short)1, "Other" },
                    { new Guid("036a81cf-398f-4290-a602-0dd2f9da95e6"), (short)23, null, new Guid("b01acccc-24c0-4dd9-817e-4ddafd72d316"), (short)1, "Other" },
                    { new Guid("2ebbf26d-18d5-49f0-9411-4e7ba594d382"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("f14338d9-affc-46e3-98dd-45293f9f6cd6"), (short)23, null, new Guid("2ebbf26d-18d5-49f0-9411-4e7ba594d382"), (short)1, "Transport" },
                    { new Guid("96fc846f-b696-44f9-a5f8-1676c7002e26"), (short)23, null, new Guid("2ebbf26d-18d5-49f0-9411-4e7ba594d382"), (short)2, "Cost of warehouse" },
                    { new Guid("4531ce03-5fbc-40ed-9167-bd33ce5e3db1"), (short)23, null, new Guid("2ebbf26d-18d5-49f0-9411-4e7ba594d382"), (short)3, "Fees to distributors" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("2bd01492-5ae6-4af1-a39c-71e3d80e97bf"), (short)23, null, new Guid("2ebbf26d-18d5-49f0-9411-4e7ba594d382"), (short)4, "Other" },
                    { new Guid("e4fe5cbd-7332-4adb-8eb4-f9052d073687"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("936aa491-e545-411e-87ff-1526eb5baa7c"), (short)23, null, new Guid("e4fe5cbd-7332-4adb-8eb4-f9052d073687"), (short)1, "Other" },
                    { new Guid("6271e429-7ad3-42be-b657-ebcb684b7955"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("e39d4111-6ff5-48f2-b250-08c44187ca93"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("cd2220aa-8a10-4340-8194-4b8f0914cc36"), (short)23, null, new Guid("891481bc-022f-4f3a-97c4-fc3a4c81638f"), (short)2, "Other" },
                    { new Guid("57a8c93b-edfd-4abc-851a-8e9fa6a42353"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("528f2967-7be0-4f4a-9583-ff96eb2bce19"), (short)23, null, new Guid("d914b9ba-aa1d-43b9-a94d-1f7731f2402b"), (short)1, "Manufacturing buildings" },
                    { new Guid("4587d611-d55c-4a19-ba13-d2e21a7477ba"), (short)23, null, new Guid("ad9032b9-8ebd-4d44-80ff-d707563ee965"), (short)4, "Marketing" },
                    { new Guid("9ef1dd8f-ded3-496c-be6f-f08d1edce3c8"), (short)23, null, new Guid("4ab6fb02-8c76-4761-8d92-204e13676425"), (short)4, "Other" },
                    { new Guid("e0b4bbfc-23fc-4a43-af58-444476be1b44"), (short)23, null, new Guid("4ab6fb02-8c76-4761-8d92-204e13676425"), (short)3, "Transport" },
                    { new Guid("ac000c23-e36d-4bdf-bfd6-b11312f6a05b"), (short)23, null, new Guid("4ab6fb02-8c76-4761-8d92-204e13676425"), (short)2, "Production equipment and machinery" },
                    { new Guid("8135b96f-6596-4dc9-9732-7b5ad7b3a2b9"), (short)23, null, new Guid("4ab6fb02-8c76-4761-8d92-204e13676425"), (short)1, "IT (office) equipment" },
                    { new Guid("4ab6fb02-8c76-4761-8d92-204e13676425"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("091996da-ed55-4099-a8b6-a2114dc490df"), (short)23, null, new Guid("d914b9ba-aa1d-43b9-a94d-1f7731f2402b"), (short)4, "Other" },
                    { new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("dbe7de8f-720d-4fb3-95f6-f61c9a60e1e1"), (short)23, null, new Guid("d914b9ba-aa1d-43b9-a94d-1f7731f2402b"), (short)3, "Sales buildings (shops)" },
                    { new Guid("8ffe0ffb-a859-4be1-a040-58ff704bedf4"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("d914b9ba-aa1d-43b9-a94d-1f7731f2402b"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("ae2dbe8c-039d-44e4-ba03-9c9cf1359eb8"), (short)23, null, new Guid("ec957287-299e-4f38-bbeb-a3be887eeca0"), (short)1, "Other" },
                    { new Guid("ec957287-299e-4f38-bbeb-a3be887eeca0"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("ed9730bf-d4fe-4fc4-8747-a62c7c0e5e87"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("7de01afa-9ffb-4339-993f-82bb99c0c8c4"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("e0b94c01-12eb-4608-b50c-4c4ac087f948"), (short)23, null, new Guid("d914b9ba-aa1d-43b9-a94d-1f7731f2402b"), (short)2, "Inventory buildings" },
                    { new Guid("6d658ea2-6dac-48c8-891e-0002cdb1f73b"), (short)23, null, new Guid("ad9032b9-8ebd-4d44-80ff-d707563ee965"), (short)5, "Other" },
                    { new Guid("e8fc1085-e6cb-46d3-ba85-49f59ca74e3c"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)1, "Electricity" },
                    { new Guid("6a8c3007-27b0-4c4a-ab97-4eb0b3838e67"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)3, "Gas" },
                    { new Guid("9acf6cb5-f2c0-4ddb-a2e0-f2494d35b155"), (short)23, null, new Guid("ad9032b9-8ebd-4d44-80ff-d707563ee965"), (short)3, "Finance management" },
                    { new Guid("9e5fce8a-cef8-4c1b-8dc2-db850966cdae"), (short)23, null, new Guid("ad9032b9-8ebd-4d44-80ff-d707563ee965"), (short)2, "Factory workers / service" },
                    { new Guid("08c1db3c-7e58-4016-8643-198ad471d1e7"), (short)23, null, new Guid("ad9032b9-8ebd-4d44-80ff-d707563ee965"), (short)1, "Management" },
                    { new Guid("ad9032b9-8ebd-4d44-80ff-d707563ee965"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("6c2bafe0-c058-49f8-89db-7df9d1826a4d"), (short)23, null, new Guid("95b53a2f-4da3-4458-a86a-0ddbe448a386"), (short)1, "Other" },
                    { new Guid("95b53a2f-4da3-4458-a86a-0ddbe448a386"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("3ee243af-b315-4a97-a7f9-c72e523feba6"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)2, "Water" },
                    { new Guid("2d7851fe-1c75-45f6-94b9-a3b9267e4884"), (short)23, null, new Guid("fbbfbc13-c671-4e4b-b2b6-4f2844d318fc"), (short)3, "Other" },
                    { new Guid("40fef4d2-1d8e-4f1e-b0de-9cc9ab5abfe5"), (short)23, null, new Guid("fbbfbc13-c671-4e4b-b2b6-4f2844d318fc"), (short)1, "Accountant" },
                    { new Guid("fbbfbc13-c671-4e4b-b2b6-4f2844d318fc"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("cdafb18b-f67d-4d57-b591-ccdc9257df66"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)7, "Other" },
                    { new Guid("50b68d0a-4d6f-40d3-b267-921788b569b7"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)6, "Communication" },
                    { new Guid("d81ca488-cf3c-44be-804b-d196f05e9c5f"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)5, "Maintenance" },
                    { new Guid("eeec53c1-b654-4c1f-83e0-057feb177c83"), (short)23, null, new Guid("0841f168-5107-451b-a54f-358dbdead735"), (short)4, "Heat" },
                    { new Guid("6e389b61-83fe-413e-8403-0e801931af26"), (short)23, null, new Guid("fbbfbc13-c671-4e4b-b2b6-4f2844d318fc"), (short)2, "IT support" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("bca261f9-74c4-4ad0-beea-6a46df2577dc"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("641bc41d-10e9-45d1-b832-5f470e4173d0"), (short)28, null, new Guid("6bb71576-1ebe-4317-8115-bea2896482dc"), (short)4, "" },
                    { new Guid("eddf90d7-ca77-4081-8cdc-5b6a49eefe03"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("fcced1a6-70d9-4bcb-bddf-5a9388699fa0"), (short)32, null, null, (short)6, "65 - 74" },
                    { new Guid("929cf252-5a59-49ba-934d-196a0fa41790"), (short)32, null, null, (short)7, "75 years or older" },
                    { new Guid("1c16ed31-a497-4646-a51a-c56d4c6a2d3c"), (short)32, null, null, (short)8, "All age groups" },
                    { new Guid("fb6e27f3-fc01-407f-be0c-efc820020940"), (short)33, null, null, (short)1, "Low" },
                    { new Guid("0ad38cdd-7dca-4bc4-bcaf-bdcadedf97b9"), (short)33, null, null, (short)2, "Medium" },
                    { new Guid("c499f42f-a717-49d4-afbf-efc728934e4b"), (short)33, null, null, (short)3, "High" },
                    { new Guid("b70e1898-6c44-419e-bf83-d26faefc5d8f"), (short)34, null, null, (short)1, "Primary" },
                    { new Guid("f574e3b2-81ca-4c7d-a278-752897e2d3b0"), (short)34, null, null, (short)2, "Secondary" },
                    { new Guid("1f1b4da7-effc-4a6c-8926-9c8225e0c43b"), (short)34, null, null, (short)3, "Higher education" },
                    { new Guid("2d96bd23-6623-4d98-92a2-f99d75778e29"), (short)35, null, null, (short)1, "Domestic" },
                    { new Guid("ef9b0902-860a-4072-b67f-a8bf9101b942"), (short)35, null, null, (short)2, "Domestic Urban" },
                    { new Guid("368085df-ab60-463f-8dab-37cace3be33c"), (short)35, null, null, (short)3, "Domestic Rural" },
                    { new Guid("e109ffa3-276b-4e45-8013-ae185c5a5a11"), (short)35, null, null, (short)4, "Foreign" },
                    { new Guid("4e34a419-7899-4d5a-9b9c-debf663178f5"), (short)35, null, null, (short)5, "Foreign Urban" },
                    { new Guid("58ef2580-e260-42c8-8cf1-a9d033d3e916"), (short)35, null, null, (short)6, "Foreign Rural" },
                    { new Guid("4172d6c5-405c-4a45-bef3-696c6ed4dca9"), (short)35, null, null, (short)7, "Transnational" },
                    { new Guid("8d7d5731-4ed2-4afe-859d-ce2ff2333a57"), (short)36, null, null, (short)1, "Small" },
                    { new Guid("5565b2d1-39b6-463a-b5c3-3dccc870c08b"), (short)40, null, null, (short)4, "Other" },
                    { new Guid("ea276b29-8121-4058-8840-a16fde0064b1"), (short)40, null, null, (short)3, "Printed Promotional/informative materials" },
                    { new Guid("17b84568-1594-4e52-aab1-8abc1c643fff"), (short)40, null, null, (short)2, "Ads and Commercials" },
                    { new Guid("08324d48-55ee-445a-bd99-00a5f77f8331"), (short)40, null, null, (short)1, "Word of Mouth" },
                    { new Guid("a9a9ad7e-e51d-45d1-95c8-f33d2599321b"), (short)39, null, null, (short)2, "female" },
                    { new Guid("ca10c024-c230-4761-b787-4633c7a3b1f8"), (short)39, null, null, (short)1, "male" },
                    { new Guid("70ab77b9-c646-4b68-8361-18463c08aad7"), (short)32, null, null, (short)5, "35 - 64" },
                    { new Guid("ecb0aa44-48b5-42e3-b41f-70e07f2c2ef9"), (short)38, null, null, (short)4, "Non-Government organisations" },
                    { new Guid("2ec5caa4-39ac-42df-bcdc-96e91ad10e98"), (short)38, null, null, (short)2, "National Government" },
                    { new Guid("16900358-c14e-43c0-84e0-b4e83fb9cfe3"), (short)38, null, null, (short)1, "International Organisations" },
                    { new Guid("9ca526be-2eb5-4a99-99aa-0a600a80da97"), (short)37, null, null, (short)2, "Services" },
                    { new Guid("36a3d7ad-d762-4c99-8b54-e79be3097817"), (short)37, null, null, (short)1, "Goods" },
                    { new Guid("300cde40-7fc7-4c8c-9b2b-7337e356ee81"), (short)36, null, null, (short)3, "Large" },
                    { new Guid("d54424f2-5d6d-423e-85be-4d19c81021ee"), (short)36, null, null, (short)2, "Medium" },
                    { new Guid("7858f1b2-88e1-4e78-8836-dac3d8600e5b"), (short)38, null, null, (short)3, "Muncipality" },
                    { new Guid("7bb8dbed-e22c-4c68-8bf4-f35d88a48ac1"), (short)32, null, null, (short)4, "25 - 34" },
                    { new Guid("008eda0f-77af-41a7-87fd-d77fe0a51143"), (short)32, null, null, (short)3, "18 - 24" },
                    { new Guid("c8e640fe-f369-4776-9ff0-fb7341954534"), (short)32, null, null, (short)2, "12 - 17" },
                    { new Guid("cbf1747f-47d0-4945-a569-7684d14c7565"), (short)30, null, new Guid("792741ff-24a2-41be-bbb4-6f2c6db16baf"), (short)1, "Fixed location" },
                    { new Guid("792741ff-24a2-41be-bbb4-6f2c6db16baf"), (short)29, null, new Guid("8a046c57-42e8-46b1-a955-04c6a9f5465c"), (short)1, "Physical" },
                    { new Guid("8a046c57-42e8-46b1-a955-04c6a9f5465c"), (short)28, null, new Guid("6bb71576-1ebe-4317-8115-bea2896482dc"), (short)1, "Own shop" },
                    { new Guid("6bb71576-1ebe-4317-8115-bea2896482dc"), (short)27, null, null, (short)1, "Direct sales" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("65e8faa1-772d-469f-b5f8-256ead31f60e"), (short)26, null, new Guid("ef6327cb-12c4-48ac-a970-0d3b7b30103f"), (short)4, "Auctions" },
                    { new Guid("68a37061-3a01-4726-a1a4-912c12adc998"), (short)26, null, new Guid("ef6327cb-12c4-48ac-a970-0d3b7b30103f"), (short)3, "Real time market" },
                    { new Guid("687d2972-59d3-4a70-afbd-95169ad69bd4"), (short)30, null, new Guid("792741ff-24a2-41be-bbb4-6f2c6db16baf"), (short)2, "Mobile" },
                    { new Guid("acc3cd9d-5e81-4a55-9823-7f4b7bd78c33"), (short)26, null, new Guid("ef6327cb-12c4-48ac-a970-0d3b7b30103f"), (short)2, "Yield management" },
                    { new Guid("ef6327cb-12c4-48ac-a970-0d3b7b30103f"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("9ca15f80-da3a-43c0-b205-cee9b1e505d6"), (short)26, null, new Guid("de57ffb3-c047-4bd9-89d1-a86988b1902d"), (short)3, "Volume dependent" },
                    { new Guid("c5e74d3c-84a5-48e9-9a9f-be527c06a4f6"), (short)26, null, new Guid("de57ffb3-c047-4bd9-89d1-a86988b1902d"), (short)2, "Product feature dependent" },
                    { new Guid("2d6a0bc0-ad5b-4aa4-a22f-ba9cddaa195b"), (short)26, null, new Guid("de57ffb3-c047-4bd9-89d1-a86988b1902d"), (short)1, "List price" },
                    { new Guid("de57ffb3-c047-4bd9-89d1-a86988b1902d"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("e9daa762-3b6c-4203-949e-40d845911437"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("d69d36f8-f1e3-4f24-8d60-974c9e802406"), (short)26, null, new Guid("ef6327cb-12c4-48ac-a970-0d3b7b30103f"), (short)1, "Negotiation" },
                    { new Guid("7ad3c92a-3881-4497-929e-a43656181d08"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("06f37efa-44dc-4307-aaf1-df0de34e75d5"), (short)31, null, new Guid("792741ff-24a2-41be-bbb4-6f2c6db16baf"), (short)1, "Self pickup" },
                    { new Guid("6da0b1ec-481f-467a-9c42-ceec67d66fc8"), (short)31, null, new Guid("792741ff-24a2-41be-bbb4-6f2c6db16baf"), (short)3, "Courier service" },
                    { new Guid("c8906332-fd4d-45d5-b78f-7fe77d8a5bc5"), (short)32, null, null, (short)1, "Under 12" },
                    { new Guid("d10937f8-680e-4e18-adef-32a8f4cf2ac3"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("af42fd9a-1073-4750-999f-b78dae58977d"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("afaed4de-2b11-4e27-8fce-9f2cf4d9455e"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("8fb437f6-2cec-4804-8615-ba173afe54f0"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("e815120a-0d07-49b9-92b8-6db6e2270ff1"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("b92bd6c5-f248-4089-87ff-fef5cd0bd55a"), (short)31, null, new Guid("792741ff-24a2-41be-bbb4-6f2c6db16baf"), (short)2, "Delivery to home" },
                    { new Guid("a4e42a23-f96b-4678-b7ba-21fb541cf9b1"), (short)28, null, new Guid("6bb71576-1ebe-4317-8115-bea2896482dc"), (short)3, "Direct visit" },
                    { new Guid("44d0fbb7-fd3f-4782-b422-b81f62d9b993"), (short)31, null, new Guid("c261139c-b879-4164-8dda-a52a6562ecc6"), (short)3, "To the email" },
                    { new Guid("f178125a-70ce-4bd1-a927-352ce1f87fb8"), (short)31, null, new Guid("c261139c-b879-4164-8dda-a52a6562ecc6"), (short)2, "Courier service" },
                    { new Guid("3531378d-2380-4be1-8715-c447e3bbbbab"), (short)31, null, new Guid("c261139c-b879-4164-8dda-a52a6562ecc6"), (short)1, "Own delivery" },
                    { new Guid("b7453899-6e48-4295-b079-fd61c8b56167"), (short)30, null, new Guid("c261139c-b879-4164-8dda-a52a6562ecc6"), (short)2, "Platform" },
                    { new Guid("d69af827-2e1f-46fb-9f11-a591728d1b78"), (short)30, null, new Guid("c261139c-b879-4164-8dda-a52a6562ecc6"), (short)1, "Own website" },
                    { new Guid("c261139c-b879-4164-8dda-a52a6562ecc6"), (short)29, null, new Guid("8a046c57-42e8-46b1-a955-04c6a9f5465c"), (short)2, "Online" },
                    { new Guid("f8021791-0b68-4e18-8cd7-07bcce16dbf0"), (short)28, null, new Guid("6bb71576-1ebe-4317-8115-bea2896482dc"), (short)2, "Market/Fairs" },
                    { new Guid("048f47a5-e4a3-4637-b08f-9ff1c36ce788"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("fd5db0c3-82ee-488b-a757-ebe7c1f40da2"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("992a7cb2-1bba-4568-9832-3ca45b7af5cd"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("75b559f2-c1ae-4909-9e06-25e957f1b20b"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("68a82820-e2e9-4ed5-a239-0c578b90fdb2"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("3201ba3e-1d97-4ac6-9a34-fe25433c4d12"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("b713d1c8-3e76-4d2a-bc52-5bad3cb4e28d"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("18ab9b75-12b5-40f5-ab97-d661bb03d7ab"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("fa43b796-ed6f-49c0-957c-f9f445bca962"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("bb747415-c353-4024-826a-64ce7b78df90"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("fa6cfbab-a66f-4a24-a876-e6ee462fce20"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("cb147c2c-4420-4832-9dae-d26f157445c7"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("e5035ec6-2670-44b1-b00f-40d83c35b601"), (short)3, null, null, (short)23, "Bargaining power of buyers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("1e9369a4-2528-4d49-9f5e-98e37586ba4c"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("a9133831-80a7-4c62-b312-41b937425d11"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("60caadfa-ded9-4c37-b7b7-ff9e9d502513"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("f5a9e945-a22a-436d-9b32-3960919b5f0a"), (short)6, null, new Guid("60caadfa-ded9-4c37-b7b7-ff9e9d502513"), (short)1, "Buildings" },
                    { new Guid("e11b2ca8-43da-4f14-917d-925ee4be9cde"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f5a9e945-a22a-436d-9b32-3960919b5f0a"), (short)1, "Ownership type" },
                    { new Guid("dabe9121-8525-4b35-b044-3efddc77bcd0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f5a9e945-a22a-436d-9b32-3960919b5f0a"), (short)2, "Frequency" },
                    { new Guid("f05cb8fe-c345-4bab-9023-35c15843d51a"), (short)6, null, new Guid("60caadfa-ded9-4c37-b7b7-ff9e9d502513"), (short)2, "Equipment" },
                    { new Guid("f4010d40-e383-4586-a182-8b1b0bf1c25c"), (short)6, null, new Guid("fcc687fa-5b2c-4e6a-876f-313ba3139863"), (short)3, "Software" },
                    { new Guid("dc48df3d-fc45-4fea-a156-934db749e8ec"), (short)6, null, new Guid("fcc687fa-5b2c-4e6a-876f-313ba3139863"), (short)2, "Licenses" },
                    { new Guid("a97100c8-1359-4309-aa74-1585e64e7b78"), (short)6, null, new Guid("fcc687fa-5b2c-4e6a-876f-313ba3139863"), (short)1, "Brands" },
                    { new Guid("fcc687fa-5b2c-4e6a-876f-313ba3139863"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("571e081a-5dd4-461a-830e-a4cc32e995d2"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("1a55457b-e994-4e4e-adee-0b5c62887611"), (short)2, "Frequency" },
                    { new Guid("4951632c-ad3d-4c6e-83e2-dcddbc03ab90"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("1a55457b-e994-4e4e-adee-0b5c62887611"), (short)1, "Ownership type" },
                    { new Guid("af9acaed-f6ce-4b2a-8086-d196766d6c30"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("1a55457b-e994-4e4e-adee-0b5c62887611"), (short)6, null, new Guid("60caadfa-ded9-4c37-b7b7-ff9e9d502513"), (short)5, "Other" },
                    { new Guid("815e11c4-5749-4158-a92f-a1905760c661"), (short)6, null, new Guid("60caadfa-ded9-4c37-b7b7-ff9e9d502513"), (short)4, "Raw materials" },
                    { new Guid("d3353ae0-db36-43cb-a8a1-dc6317728e2b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("82c7a729-f092-4fcf-898a-d7ee44ee8901"), (short)2, "Frequency" },
                    { new Guid("05f92013-cdf3-4acc-8436-70f8f3d3e625"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("82c7a729-f092-4fcf-898a-d7ee44ee8901"), (short)1, "Ownership type" },
                    { new Guid("82c7a729-f092-4fcf-898a-d7ee44ee8901"), (short)6, null, new Guid("60caadfa-ded9-4c37-b7b7-ff9e9d502513"), (short)3, "Transport" },
                    { new Guid("0372470a-a2f1-41e8-9176-a4f4b7f02b77"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f05cb8fe-c345-4bab-9023-35c15843d51a"), (short)2, "Frequency" },
                    { new Guid("1ce4f540-b900-4553-a2f2-54ed6530f946"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f05cb8fe-c345-4bab-9023-35c15843d51a"), (short)1, "Ownership type" },
                    { new Guid("5ca46c1b-673c-457c-b01f-e478d1cf28cd"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("815e11c4-5749-4158-a92f-a1905760c661"), (short)1, "Ownership type" },
                    { new Guid("090ed191-3464-436c-845b-7d79a047d3bb"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("cb64b3ad-245a-4f0a-bcbd-a90a0eb885c6"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("87876aee-b8d9-4703-a3ff-0a19572e2498"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("be89662d-ba7b-4ec8-9a14-7e2e1e9919ad"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("b7259ade-3e1f-4898-9ebd-8e172d603a05"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("8a91e432-ffa5-4330-b71b-87929ec65983"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("474b6c7c-2fc8-4d37-9426-7fb499835900"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("4fcc5549-fff9-4a2f-9a31-97bbde12dba6"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("0e3ab4c2-97a8-4d70-9fcd-bef0e6161ed9"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("eca0241b-5268-4b0e-ad64-e68fadf436f9"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("1a6bd4e2-c7a2-4f27-8512-b25fd8114c4a"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("dbbd3b35-12ce-4f1b-9a82-d75acd7296ec"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("dd908367-0698-4916-8274-c3fa0dc5efd6"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("2cfee467-22f7-4052-bfcc-4cdac5ab123e"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("3ad4e62a-917b-4608-81ba-391556a89e34"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("17625336-eeb4-44c7-a9bb-a2b070dafeec"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("a314ab85-24bc-4bb1-b773-ebd915a0bb31"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("84fa6459-f88f-42af-955e-60ce04b2227f"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("a3e0a420-cf2e-45be-849d-757094ae1819"), (short)6, null, new Guid("fcc687fa-5b2c-4e6a-876f-313ba3139863"), (short)4, "Other" },
                    { new Guid("e42b5829-de4a-425d-8caf-44709125e701"), (short)1, "a", null, (short)16, "Complementary and after-sales service" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("15cc8edb-631e-4d7d-8e57-da6428800f67"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("00fefd90-94bf-4ebc-93f0-c3626722c192"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("6a8e42d7-07b9-4c4d-a95e-eaa1d1f44c91"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("d78e36e7-4fd8-4104-b40e-7204357c196a"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("3ce6bdef-f887-402b-b3b7-86f481fa82d8"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("487c748a-0e6b-4473-b4d5-f321184816fa"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("b4709e71-9fa6-4c27-9733-7b2927103751"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("b3c88402-d8e8-4eb8-8f7b-204822c0db77"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("d77d548e-4546-4431-9b50-bea3b03a33db"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("067c871f-1259-4ab3-bbfb-417aa74f5b31"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("77c184a1-cbc4-4032-a4a1-e5a05715c879"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("b7d7d932-b925-4573-bfb6-edb9305ef376"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("03930d96-ef12-4d0d-af9e-71642687161b"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("0cc17096-cd07-4847-bbe0-68afea061895"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("20d15b7c-417a-44c7-89d7-2292a0bb6606"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("1ed45864-d157-49c9-857c-0b24fdeceb06"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("af719940-aa4a-4df2-94f6-9f72018e6f0c"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("4115079b-666e-4b36-a79b-fb2c0ec6938c"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("7a206b92-0cba-486d-a3bc-0d3a92d4285d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("9865f3f7-aa69-402b-9d74-e3cb2995b7e4"), (short)1, "Ownership type" },
                    { new Guid("172b1960-a0aa-4793-b596-6fb682e397af"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("e89a8cf5-b610-4dbe-85b2-5766dd91f21a"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("a0cbd299-0f6d-45c3-adc7-2ba3d4526cf5"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("ef3151df-4c7f-49ca-840f-6154878f04e3"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("8bf1a552-a5ec-4692-a9c9-1a07ad40d93b"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("5002fdb2-bcd7-417b-a2c6-7f84b8d969b6"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("16abd2e6-1b05-4dc9-967f-395a4fa8c62c"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("34198cff-efcd-43b9-998b-757387f13285"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("56a31f76-6245-4afd-9672-a2f9be91b03b"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("c0b98aa8-0d1a-4684-81c4-5c498f135291"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("36062d1e-eb09-423f-9b87-7c43b1480e58"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("35843e31-7075-4db8-bf42-cfebacbfdb69"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("87ebcdba-c07c-44e7-bd47-90d4195c4dca"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("e2f7cae1-c111-4ef8-b2cb-36ef32841568"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("3349e59b-7ac8-4eee-b26b-05385e63a1cd"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("93d50164-c7ba-4e44-898c-fc158bb2004f"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("fcfa0bf5-abb9-4446-bcb5-2038b38680a3"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("1e062d35-62c9-4657-987a-6e26d0b6e971"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("3c8800db-9cfe-49d0-89b7-a9a50de9a116"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("85dd56af-d21d-4b04-99ac-057b205003e4"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("89345d5e-45fa-4ea0-8ca4-f06338ee7f15"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("4fbb03ac-8456-45e0-b745-23c85a93354d"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("4e566e23-ece2-4d3f-845d-fcf47057569f"), (short)17, null, null, (short)2, "Economy" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e3d2b537-623d-4bdf-84d0-645b833d5e89"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("328e93f9-6fc0-4231-955a-53950f2c0e46"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("a90a17c8-839f-4cef-8453-f41469bf03b6"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("b184a8b8-9917-42b3-826e-b8ef45f43370"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("69a4f48d-7eab-4221-afd2-a9c84cc13f32"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("227c5c07-0d00-48d2-bf25-ce9a54ccc753"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("f3b33177-b0da-44c8-a4e9-ba9924320051"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("f2a042b1-76d2-436f-bebf-3988701a34fa"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("b3514d30-1f5e-4b7b-83bb-d6d4847a5c24"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("9865f3f7-aa69-402b-9d74-e3cb2995b7e4"), (short)6, null, new Guid("4115079b-666e-4b36-a79b-fb2c0ec6938c"), (short)1, "Specialists & Know-how" },
                    { new Guid("9f79f112-0b54-471c-a4fa-9d911bb5a215"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("7afba4bc-44bd-4c3f-858e-f9eca568bb83"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("095e1782-bfab-416c-8d11-eaa92c367eda"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("a8213303-3385-4a98-8574-23ca7678bf70"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("4d043b84-b497-415d-8735-6cd1550a1619"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("386c472f-b83e-49f8-b57b-fd5449dc3b49"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("7987b172-6b19-4bbe-b926-1c70037907fd"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("fa3fb6fa-dd8e-4bca-9e35-583f6b4c3f15"), (short)2, "Frequency" },
                    { new Guid("0bbe9726-e879-4682-9b3d-44f234c80100"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("fa3fb6fa-dd8e-4bca-9e35-583f6b4c3f15"), (short)1, "Ownership type" },
                    { new Guid("d347f6fa-3e20-415f-a6f0-f877c658249d"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("fa3fb6fa-dd8e-4bca-9e35-583f6b4c3f15"), (short)6, null, new Guid("4115079b-666e-4b36-a79b-fb2c0ec6938c"), (short)4, "Other" },
                    { new Guid("93d231dd-05a0-4874-a946-493f264bab63"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("a1fefc1f-87f2-4912-a9f9-f3cb1a800f12"), (short)1, "Ownership type" },
                    { new Guid("a1fefc1f-87f2-4912-a9f9-f3cb1a800f12"), (short)6, null, new Guid("4115079b-666e-4b36-a79b-fb2c0ec6938c"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("0347c7e1-8174-4851-b563-6c0d91eea1a8"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("72f7fe6c-4c81-4310-a392-dd409a138cd0"), (short)2, "Frequency" },
                    { new Guid("7cf55b4b-c372-45c5-b60a-078e35be5647"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("72f7fe6c-4c81-4310-a392-dd409a138cd0"), (short)1, "Ownership type" },
                    { new Guid("72f7fe6c-4c81-4310-a392-dd409a138cd0"), (short)6, null, new Guid("4115079b-666e-4b36-a79b-fb2c0ec6938c"), (short)2, "Administrative" },
                    { new Guid("27cfacd3-3d0b-415c-ae76-6ae67c505f8b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9865f3f7-aa69-402b-9d74-e3cb2995b7e4"), (short)2, "Frequency" },
                    { new Guid("39284c0f-b1d4-4212-86a8-3052b396f059"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("a1fefc1f-87f2-4912-a9f9-f3cb1a800f12"), (short)2, "Frequency" },
                    { new Guid("a705df02-a8b2-471e-8f36-1e93db6961f3"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("bf86b342-6788-499c-bb7e-7e66732cc701"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("bccbd3ca-ed0c-4348-bf96-fbd25b6702e4"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("86c0462d-417a-444f-b4e1-2a67f12e1491"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("e31b8f15-122d-42cc-8942-eb2f05a18da1"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("661a677f-9f80-4c81-bb29-5e7b75fedaec"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("e6310e56-1358-41fd-ac3c-d333ce0dc868"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("7b66809a-e664-485f-97ef-dc63e37b3bc1"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("068fe3f6-f95d-434b-9ed3-5cfba707d8b7"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("168cb289-a30e-4df4-8754-b76d30b22803"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("2d20259b-2624-4c63-828a-0bc509c21512"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("87d37547-e8f7-49de-9edd-87215f96b0b8"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("28720cd6-28a9-46bf-8abf-8c5efad782f5"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("4843d526-340f-46ab-a5b7-887c3b829fa5"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("81e4403b-9390-403d-bada-78628f0e188a"), (short)12, null, null, (short)4, "Financiers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("dd304b08-ad37-40ae-a2b6-746c7c29cc0e"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("7ab90df5-6513-452b-831a-1cae59f987b7"), (short)13, null, null, (short)1, "Consultants" }
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
                    { new Guid("7bbe73b4-5b62-4c97-bd04-df8206f0202e"), "A.01", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("23b09112-634f-4dc2-927b-29e006260e16"), "H.51.22", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Space transport" },
                    { new Guid("53ed044c-69f4-4b08-87fb-a8908ec2192c"), "H.52", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Warehousing and support activities for transportation" },
                    { new Guid("a2999780-067f-49a4-82b1-25a0307ca72a"), "H.52.1", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Warehousing and storage" },
                    { new Guid("eae69b06-9954-4c5a-93ad-def4447824af"), "H.52.10", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Warehousing and storage" },
                    { new Guid("1b524c4e-5a79-4bc4-b3d4-3f432bff348e"), "H.52.2", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Support activities for transportation" },
                    { new Guid("3fe835d3-7cff-4565-a548-06d037698668"), "H.52.21", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Service activities incidental to land transportation" },
                    { new Guid("dfc55e7f-83ab-460f-8c9d-bc6a387f40d4"), "H.52.22", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Service activities incidental to water transportation" },
                    { new Guid("3bd54e52-04f4-4018-8835-963e4c6f1e78"), "H.52.23", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Service activities incidental to air transportation" },
                    { new Guid("63d0d23a-d8b9-468c-a7a4-3f33b867b76a"), "H.52.24", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Cargo handling" },
                    { new Guid("6bcfce3a-356b-4dd1-afb5-eed5adb58050"), "H.52.29", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Other transportation support activities" },
                    { new Guid("e39516ae-97e0-4b9f-a8bf-41a322356fe3"), "H.53", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Postal and courier activities" },
                    { new Guid("23927793-5959-4025-bbd5-a52068b0d855"), "H.53.1", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Postal activities under universal service obligation" },
                    { new Guid("e0101574-66ba-4110-8b99-02a1e72933f5"), "H.51.21", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Freight air transport" },
                    { new Guid("ec45982c-3782-4e07-8a98-15febc8df79b"), "H.53.10", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Postal activities under universal service obligation" },
                    { new Guid("51a3ca49-68e6-46bf-9402-d987219bb985"), "H.53.20", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Other postal and courier activities" },
                    { new Guid("d73d1d07-f86e-444b-92a3-e89eb6427bb3"), "I.55", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Accommodation" },
                    { new Guid("637d8446-72cc-4468-af05-6a12b64ab5f7"), "I.55.1", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Hotels and similar accommodation" },
                    { new Guid("6c676dee-8a9b-487e-8fe6-aee890476c42"), "I.55.10", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Hotels and similar accommodation" },
                    { new Guid("bcedc83c-d1af-47e2-8c3f-3dd60917cb42"), "I.55.2", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Holiday and other short-stay accommodation" },
                    { new Guid("ef53df87-0731-45eb-9300-077d04c1f95f"), "I.55.20", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Holiday and other short-stay accommodation" },
                    { new Guid("ac23eaa5-1b74-4ef6-bdbd-d7203f84c948"), "I.55.3", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("05373920-a479-41e7-91bc-f93d95caa835"), "I.55.30", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("7816f4e1-bd36-4a12-8a0b-82a07ab85f34"), "I.55.9", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Other accommodation" },
                    { new Guid("8fb66f3b-8ac6-426e-aed4-383b6c6e7a16"), "I.55.90", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Other accommodation" },
                    { new Guid("013a2d60-f4f3-43dc-80f8-b47f12a1882d"), "I.56", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Food and beverage service activities" },
                    { new Guid("32791871-7d8a-47dd-82da-be28d0a28916"), "I.56.1", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Restaurants and mobile food service activities" },
                    { new Guid("fc92c316-43f0-43c9-853c-d61238c344f6"), "H.53.2", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Other postal and courier activities" },
                    { new Guid("2083df4d-f89e-4e4e-81f7-d10a0d5e5840"), "H.51.2", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Freight air transport and space transport" },
                    { new Guid("50ed8a0b-93d4-4017-bcba-d63afb70bbb1"), "H.51.10", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Passenger air transport" },
                    { new Guid("2f1dac5e-f3bf-4a3a-a56b-8dcf8277dae6"), "H.51.1", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Passenger air transport" },
                    { new Guid("4614d422-c266-4dfe-97d1-ed6695854f20"), "G.47.9", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("739cdb85-920f-4d03-b940-78e662a69e7b"), "G.47.91", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("acae1d97-16da-4e52-be94-c947e773c114"), "G.47.99", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("4541629a-0842-4ace-8cd8-9ff7565da12c"), "H.49", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Land transport and transport via pipelines" },
                    { new Guid("9e2a67a2-7f7c-42b7-9b7f-fbe79aeb289d"), "H.49.1", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Passenger rail transport, interurban" },
                    { new Guid("3154bd9a-8009-455e-8a28-4e730a15ed0d"), "H.49.10", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Passenger rail transport, interurban" },
                    { new Guid("1c70b7ef-7e69-4752-852f-e2f96a04bd68"), "H.49.2", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Freight rail transport" },
                    { new Guid("bac2546c-57e1-4603-bbb5-b0622c8d4dc6"), "H.49.20", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Freight rail transport" },
                    { new Guid("e9bb0843-ccf9-488c-b26d-a699a366e6a2"), "H.49.3", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Other passenger land transport" },
                    { new Guid("6336b6c1-9fd3-41c7-905f-556716e2f71c"), "H.49.31", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Urban and suburban passenger land transport" },
                    { new Guid("5a0e755a-ea85-4d68-a18c-4b957804d873"), "H.49.32", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("258f4efd-8e5c-4a93-b2cc-41163c576ecc"), "H.49.39", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Other passenger land transport n.e.c." },
                    { new Guid("d83b3ab8-b2df-4d11-833c-12c1fc2a4f35"), "H.49.4", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Freight transport by road and removal services" },
                    { new Guid("19a44529-d70f-401b-b3a5-7b0fe0730fc0"), "H.49.41", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Freight transport by road" },
                    { new Guid("a251e7db-c523-40e7-a0b1-27571e800e1b"), "H.49.42", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Removal services" },
                    { new Guid("c7492778-40cc-4a1c-9079-cdb82813bc0b"), "H.49.5", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Transport via pipeline" },
                    { new Guid("169f5ed5-f40b-4080-b000-05c6f199cb31"), "H.49.50", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Transport via pipeline" },
                    { new Guid("181d6b2b-7da7-4ca4-94b5-189cecb1e1ed"), "H.50", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Water transport" },
                    { new Guid("062b62cb-44ad-405d-a230-0a34c2ec63e7"), "H.50.1", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Sea and coastal passenger water transport" },
                    { new Guid("e1d7a00e-ef2a-409e-ab09-b4edd6392d16"), "H.50.10", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Sea and coastal passenger water transport" },
                    { new Guid("90bd4803-bdd4-4cd5-ac3f-f5106c75dc08"), "H.50.2", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Sea and coastal freight water transport" },
                    { new Guid("98bb090e-08ca-4f6f-9236-d5a15a9172d2"), "H.50.20", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Sea and coastal freight water transport" },
                    { new Guid("9dc7e8e4-775c-49cd-85a6-df5c0e726bb6"), "H.50.3", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Inland passenger water transport" },
                    { new Guid("2db8b5a7-9b74-4897-a4f4-34fcb8292fd6"), "H.50.30", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Inland passenger water transport" },
                    { new Guid("5530c775-910e-4b73-a01f-941308199076"), "H.50.4", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Inland freight water transport" },
                    { new Guid("56689202-a4ee-479c-9365-69a380132e01"), "H.50.40", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Inland freight water transport" },
                    { new Guid("a50145e3-a41a-4509-929b-126d42a8060f"), "H.51", new Guid("476d782a-229b-4117-98a2-f697a09cc803"), "Air transport" },
                    { new Guid("b1f6eb60-48b6-4445-b584-42d99a6910f1"), "I.56.10", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Restaurants and mobile food service activities" },
                    { new Guid("502b009b-d2fa-4fd5-9235-7e1c2fdb7707"), "G.47.89", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("4a3f8322-9fde-4110-a06d-494c38c2cd47"), "I.56.2", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Event catering and other food service activities" },
                    { new Guid("cf73c6d5-af8a-4f4d-965b-dcca34c5fb9d"), "I.56.29", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Other food service activities" },
                    { new Guid("65a974f5-df06-4322-b3e1-386ee98365ee"), "J.61.30", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Satellite telecommunications activities" },
                    { new Guid("7dbbe51c-8779-4a86-907d-81e1a293eb86"), "J.61.9", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other telecommunications activities" },
                    { new Guid("af1d8e71-1e86-4606-96a8-9c613d93cc7f"), "J.61.90", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other telecommunications activities" },
                    { new Guid("6de9fbae-1d0f-494d-8b11-091c88d436c2"), "J.62", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Computer programming, consultancy and related activities" },
                    { new Guid("0832c3fe-5e5d-4c4f-92d5-eeec3813bde0"), "J.62.0", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Computer programming, consultancy and related activities" },
                    { new Guid("a789617e-0e1c-4fae-a3b3-2f130ab52f51"), "J.62.01", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Computer programming activities" },
                    { new Guid("726f2766-11e0-4ebc-9a14-4e9f3697fe91"), "J.62.02", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Computer consultancy activities" },
                    { new Guid("e127191e-4992-4b88-aa78-0d63ffe03e46"), "J.62.03", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Computer facilities management activities" },
                    { new Guid("994fe92d-01e0-4f57-bfc3-43cfcaf1d3f8"), "J.62.09", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other information technology and computer service activities" },
                    { new Guid("b50d3af5-4588-461a-9ee0-bc21e9b2556e"), "J.63", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Information service activities" },
                    { new Guid("4df7a317-39f5-4c69-9b19-4b0067c2f5f2"), "J.63.1", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("0726e393-cfaa-4619-a119-5c767f898b22"), "J.63.11", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Data processing, hosting and related activities" },
                    { new Guid("3d80e572-d536-4ac3-9396-992945ec3088"), "J.61.3", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Satellite telecommunications activities" },
                    { new Guid("3f3a962a-1fdb-40d3-9353-709889f69d34"), "J.63.12", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Web portals" },
                    { new Guid("f0a0a83f-b1a4-479f-aea7-45532dab28ed"), "J.63.91", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "News agency activities" },
                    { new Guid("4f54da94-302b-42da-ab12-9bb871d02b0d"), "J.63.99", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other information service activities n.e.c." },
                    { new Guid("22d55c2b-02e1-44fa-a5e4-2bec626a405d"), "K.64", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("d8b83b8e-1fc9-4922-860c-031728e17b79"), "K.64.1", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Monetary intermediation" },
                    { new Guid("fe73e65c-f5ef-4219-98b1-064087834e68"), "K.64.11", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Central banking" },
                    { new Guid("c0431780-6bcb-4720-8c14-5c0d591d5b12"), "K.64.19", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Other monetary intermediation" },
                    { new Guid("fb342b21-96c7-427e-90b2-2bee1d648bc6"), "K.64.2", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Activities of holding companies" },
                    { new Guid("4705de64-1f5e-4bd6-a952-4de90dcc3317"), "K.64.20", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9a7c0c56-d1c3-43d8-99b8-07aded0edb49"), "K.64.3", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Trusts, funds and similar financial entities" },
                    { new Guid("bafd8a24-6e2a-49e9-b867-320d101e7604"), "K.64.30", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Trusts, funds and similar financial entities" },
                    { new Guid("e66cda21-81e8-4216-abd4-fee985f846c9"), "K.64.9", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("86e46b50-da98-4426-bfc2-d320ca074b95"), "K.64.91", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Financial leasing" },
                    { new Guid("ed0b765a-9bcd-4468-aee2-1301b393b6c9"), "J.63.9", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other information service activities" },
                    { new Guid("a0e4aa17-c7f5-41a1-b1aa-b3bee921a660"), "J.61.20", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Wireless telecommunications activities" },
                    { new Guid("bf553779-41bc-487a-9242-e9384333baab"), "J.61.2", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Wireless telecommunications activities" },
                    { new Guid("51f70dfc-f277-4733-884b-d37ca5c7055e"), "J.61.10", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Wired telecommunications activities" },
                    { new Guid("ab43c7fd-c86a-46a1-b7bc-1777040f0040"), "I.56.3", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Beverage serving activities" },
                    { new Guid("845bef1f-dc86-4249-8bcf-e9b0a4a13184"), "I.56.30", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Beverage serving activities" },
                    { new Guid("7fe8ce13-a5d9-4c57-a4f5-9301b0de312c"), "J.58", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Publishing activities" },
                    { new Guid("a2fffeba-6c1c-4312-8d30-72d9a6ad505f"), "J.58.1", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("29c09c55-4214-442e-bc59-5561c8e2b3c8"), "J.58.11", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Book publishing" },
                    { new Guid("8d7c0c2b-d3f4-418d-bf9c-1519ea41ac02"), "J.58.12", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Publishing of directories and mailing lists" },
                    { new Guid("5dead8b3-a6cb-4ef1-a122-fcbbaacc76cf"), "J.58.13", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Publishing of newspapers" },
                    { new Guid("23b7b47a-88c2-4a65-86be-603aa2a1e8b1"), "J.58.14", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Publishing of journals and periodicals" },
                    { new Guid("273be4c2-de25-44a8-8b74-f40a218e4546"), "J.58.19", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other publishing activities" },
                    { new Guid("5b3ce8c0-ea37-419b-95fb-fbb161d57ce5"), "J.58.2", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Software publishing" },
                    { new Guid("4615aba1-b71b-4779-8612-65db97d09491"), "J.58.21", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Publishing of computer games" },
                    { new Guid("97941921-b424-4a51-aad1-e298e47099c1"), "J.58.29", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Other software publishing" },
                    { new Guid("093e88e4-852d-48d7-a65a-c57f1da82feb"), "J.59", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("5d4df578-ed9d-41cc-9415-1d58541ff088"), "J.59.1", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Motion picture, video and television programme activities" },
                    { new Guid("a7d4cb37-c312-49dd-8d1c-c7589c61d276"), "J.59.11", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Motion picture, video and television programme production activities" },
                    { new Guid("f74a4b36-5d67-4936-9ec1-7f44cc357df7"), "J.59.12", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("6360d15b-90fc-4c59-96ab-15985d33c16f"), "J.59.13", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("9b634cb5-06a3-4f97-b0de-dbf9d3f5f8ff"), "J.59.14", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Motion picture projection activities" },
                    { new Guid("2bb191f3-c62a-4d39-bf99-395c1a5234ab"), "J.59.2", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Sound recording and music publishing activities" },
                    { new Guid("698a1d7b-06c0-4d7f-9ddf-283f6bb45ec9"), "J.59.20", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Sound recording and music publishing activities" },
                    { new Guid("9208863f-afc1-4b61-9d39-e343cf51b2a9"), "J.60", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Programming and broadcasting activities" },
                    { new Guid("b7b8c691-a945-40c3-857e-5792628a368c"), "J.60.1", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Radio broadcasting" },
                    { new Guid("5968a0d2-c04b-4501-97d9-deb4e3c20774"), "J.60.10", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Radio broadcasting" },
                    { new Guid("f880264f-8c58-4cc8-a82d-c70bc2885786"), "J.60.2", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Television programming and broadcasting activities" },
                    { new Guid("8feddfbf-6df0-49da-8255-2fa524f0913f"), "J.60.20", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Television programming and broadcasting activities" },
                    { new Guid("48f3cafe-b9f0-4498-a795-3c377cdcbbc5"), "J.61", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Telecommunications" },
                    { new Guid("7ec3a8f3-3391-49a8-8722-003d7bfe489e"), "J.61.1", new Guid("8aa09a85-7198-4275-b424-21c99dd0125a"), "Wired telecommunications activities" },
                    { new Guid("3e2a3654-eaea-4447-bd0f-9253168be15e"), "I.56.21", new Guid("48eb0050-8a22-4a55-96e4-707f29d61e91"), "Event catering activities" },
                    { new Guid("934e76cf-a6be-4aea-85ab-901b73118ab5"), "K.64.92", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Other credit granting" },
                    { new Guid("9174f4b5-77f6-489c-87f7-085ba77d6e47"), "G.47.82", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("eeb4fbf0-1f2f-4b54-b005-64a23ee5bce2"), "G.47.8", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale via stalls and markets" },
                    { new Guid("a352c167-ae0e-47c8-8b51-1f83fd57b1c9"), "G.46.19", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("73c83592-0bb6-4906-aab8-532d9f1f1c4f"), "G.46.2", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("bb1e2eb9-07c3-4f97-8655-2421aee64902"), "G.46.21", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f5c04d9e-a0f0-4729-86d1-3b5b17731d09"), "G.46.22", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of flowers and plants" },
                    { new Guid("614bcf38-fd20-4dee-a98a-14839857a5d4"), "G.46.23", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of live animals" },
                    { new Guid("bbb5050b-5aea-4dd1-895e-cee3eca54a87"), "G.46.24", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of hides, skins and leather" },
                    { new Guid("4eb44df2-0f81-427e-b500-66b8bd392d0f"), "G.46.3", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("2a71213b-58fd-4c28-ac21-47bd28e5db2e"), "G.46.31", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of fruit and vegetables" },
                    { new Guid("913c89e4-faec-41b8-9efc-b7f318fb1ff5"), "G.46.32", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of meat and meat products" },
                    { new Guid("fa8d6393-0f08-4129-8485-6d576ce5ea54"), "G.46.33", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("dcab5181-f4e5-460b-9976-fbb67c95388f"), "G.46.34", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of beverages" },
                    { new Guid("e00e78af-1721-421f-b743-88f20aa5bddf"), "G.46.35", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of tobacco products" },
                    { new Guid("e6f8c528-5328-4ab4-b64c-38008e95219d"), "G.46.18", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents specialised in the sale of other particular products" },
                    { new Guid("b8d873c5-ea26-45c0-9f2d-f335c1d64bbd"), "G.46.36", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("2160f0c9-3f0d-4515-b652-2a409d44729d"), "G.46.38", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("e5f6a70d-5903-4d79-a265-bb1047240167"), "G.46.39", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("cb8630af-3007-407b-a401-36c169c1995f"), "G.46.4", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of household goods" },
                    { new Guid("d40230ec-248c-4493-871a-5845674b340a"), "G.46.41", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of textiles" },
                    { new Guid("f99a8208-7b8d-4162-89fe-3dded1382ad1"), "G.46.42", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of clothing and footwear" },
                    { new Guid("1170e3b7-70d0-41af-bb9e-4f83700947d0"), "G.46.43", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of electrical household appliances" },
                    { new Guid("84e629d1-f637-4fce-b4bd-79c0fdb320f9"), "G.46.44", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("f6319367-07c6-4916-a79d-6b165a8e947b"), "G.46.45", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of perfume and cosmetics" },
                    { new Guid("87ffa0ae-7ea4-48b4-a559-116a64d93ba9"), "G.46.46", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of pharmaceutical goods" },
                    { new Guid("71a056c0-574f-4e80-b865-72e76eca7564"), "G.46.47", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("332237e9-b5a5-4334-9768-ee0a51c2be6c"), "G.46.48", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of watches and jewellery" },
                    { new Guid("72f29407-4cc4-47d4-a581-8cecb97de55b"), "G.46.49", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of other household goods" },
                    { new Guid("270d7820-ab6e-4b6f-9781-3ff60cbeb7e7"), "G.46.37", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("b5cce100-dbfe-48f5-978d-6a7fbc7cb074"), "G.46.17", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("f574c8d2-e66f-4e2b-aacb-821bc58f9c0b"), "G.46.16", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("b756d8dd-ff72-4fa7-b3c3-5612312c88ba"), "G.46.15", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("06b2b886-1f0b-4866-b9be-f6e67e9e5f69"), "F.43.29", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Other construction installation" },
                    { new Guid("97f00514-b2bc-4bdd-8974-11816758538f"), "F.43.3", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Building completion and finishing" },
                    { new Guid("63340454-eea0-454b-b005-57281c692ade"), "F.43.31", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Plastering" },
                    { new Guid("71b5af92-7cd0-4ad5-a33b-e14c35d0cd78"), "F.43.32", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Joinery installation" },
                    { new Guid("aec277f7-8d29-417d-949b-dfc27d784c47"), "F.43.33", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Floor and wall covering" },
                    { new Guid("66e217ed-3fda-4c51-bded-e97ca7bcb609"), "F.43.34", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Painting and glazing" },
                    { new Guid("401ea650-835b-4dad-bfaf-1e1b5e41c6f5"), "F.43.39", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Other building completion and finishing" },
                    { new Guid("3d552ae7-1ce8-4d61-a85b-80d1143795b7"), "F.43.9", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Other specialised construction activities" },
                    { new Guid("9183f0ca-bf0a-4897-85c5-0e2d3c26374b"), "F.43.91", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Roofing activities" },
                    { new Guid("3f0877ed-6a6e-48d7-a6d9-ab30c602cd7f"), "F.43.99", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Other specialised construction activities n.e.c." },
                    { new Guid("2d72e0c0-faf9-4ca4-a92a-dae463140a9d"), "G.45", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("dd305fa1-7636-4324-bc15-9380892ba1ec"), "G.45.1", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Sale of motor vehicles" },
                    { new Guid("e808e800-debe-4e70-939f-0d42b4e02a92"), "G.45.11", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Sale of cars and light motor vehicles" },
                    { new Guid("6ab01572-f53a-4e01-80fc-c54606503521"), "G.45.19", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Sale of other motor vehicles" },
                    { new Guid("13b2b95f-1923-4bd5-b952-fa8c8084e8e9"), "G.45.2", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c3ae38e3-025e-4c19-b3b8-f2c9367e5657"), "G.45.20", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Maintenance and repair of motor vehicles" },
                    { new Guid("8e1c4702-ff1e-4d35-b470-268d4d61f165"), "G.45.3", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("eb01bd3c-1653-4889-9919-6cc89ff832f2"), "G.45.31", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("6ecf4fbe-48cb-4dd0-90ce-06d368f34176"), "G.45.32", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("ff8dae46-958b-4402-bb51-a19daf23d913"), "G.45.4", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("059a8c9b-ca3d-4ef6-83f2-28989787971d"), "G.45.40", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("43066514-2f48-4bc9-be3a-9ca286a4defe"), "G.46", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("84fda943-858a-456f-88f2-a6808ec9ed73"), "G.46.1", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale on a fee or contract basis" },
                    { new Guid("79e77528-511f-4e4c-a646-c9e241e9c16a"), "G.46.11", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("3acc458d-4daa-432d-abe1-d1ddf856a7c5"), "G.46.12", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("0103e21c-f892-45c2-825d-33d7d275c079"), "G.46.13", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("5f4489e0-802d-4bfc-8bc4-6fa326ffef94"), "G.46.14", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("94ac36fe-ff32-4144-a3f6-554d1031c0b6"), "G.46.5", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of information and communication equipment" },
                    { new Guid("67a6d1e0-19c8-411f-9d52-b015911670fb"), "G.47.81", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("f1e83558-2480-4b72-a3d4-1705a76d9581"), "G.46.51", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("761872d0-41a1-44c3-a67d-c26637b7d263"), "G.46.6", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("d81ff6b4-b19e-4f4a-9a22-394e7bb0c135"), "G.47.4", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("b9371d53-e495-444f-a988-b1b2d1e86e3c"), "G.47.41", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("bb2ab552-b523-4234-bb2e-b839bed83216"), "G.47.42", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("f888b8c7-b20b-4134-aaff-2f9a3cd1e60e"), "G.47.43", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("a99da7db-15e4-46a9-b8c5-cd0249956ee2"), "G.47.5", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("ee97b714-6893-45de-9a0b-98ca1675b048"), "G.47.51", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of textiles in specialised stores" },
                    { new Guid("2a95fd1e-e071-49dc-8571-078f04865783"), "G.47.52", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("ee8586aa-ba54-4177-9d3f-4636dc2a8b63"), "G.47.53", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("c9bdccb2-f98e-4d8d-a49d-bf8bbaac8af4"), "G.47.54", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("9bb1fa53-c895-4c5e-85d4-e9bf2c26cb86"), "G.47.59", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("ffa7f87d-ab4a-4281-abd3-540c077b8650"), "G.47.6", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("78d78334-a4a5-4bb9-8768-53cc80780cf9"), "G.47.61", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of books in specialised stores" },
                    { new Guid("5f2b3ad4-1160-4ddf-9e15-65c41afa63fa"), "G.47.30", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("81f179b1-20ef-4b9b-a822-585f044177d2"), "G.47.62", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("3ca2ee95-f232-4f06-8072-73d38a0e87f2"), "G.47.64", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("ea3ea098-aa60-458c-90f4-344266d3db09"), "G.47.65", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("d6bc3ffa-3193-47b0-9953-a096c82ec856"), "G.47.7", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of other goods in specialised stores" },
                    { new Guid("0bad7f49-ca24-4275-b6d1-6bba7ebf5f6b"), "G.47.71", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of clothing in specialised stores" },
                    { new Guid("7c85f5d2-5059-4cf6-95d1-34a3f3c6b3a1"), "G.47.72", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("842f59b9-1c15-4e16-b6ef-a5cec80ffcb0"), "G.47.73", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Dispensing chemist in specialised stores" },
                    { new Guid("adc30868-4f5a-49b8-aba2-29ad0af5d6c0"), "G.47.74", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("8c039f77-a285-40ab-ad17-4414bd588b2c"), "G.47.75", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("69487311-847b-4b2b-b0a1-b11936d88b68"), "G.47.76", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("b2356f64-7973-4d8a-a569-82c2bfbc7ac2"), "G.47.77", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("ac85403c-5a8a-4390-9ca5-e570d255c7f3"), "G.47.78", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("3117e993-98a5-4e73-98e8-067e16af0699"), "G.47.79", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("98d79aab-35e5-4cda-90a5-47f28c44db4c"), "G.47.63", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("b354851d-6e40-43d7-992d-d823ebf21145"), "G.47.3", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("8d27bd48-7883-4728-ab2e-bc66be3938ab"), "G.47.29", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Other retail sale of food in specialised stores" },
                    { new Guid("0ac208c4-3b3d-49a5-89ca-7be7af2c580a"), "G.47.26", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("adf8ed76-cdba-410e-a4f8-d6470269737b"), "G.46.61", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("575a6af4-8578-472e-ba04-b2a538e31bbb"), "G.46.62", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of machine tools" },
                    { new Guid("00626267-84dc-4529-ad46-75b91abd623b"), "G.46.63", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("e90e1999-d886-4a51-a49a-19e8ad67a1c2"), "G.46.64", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("73598f9f-84af-490e-a7ff-6fc87c0e21a2"), "G.46.65", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of office furniture" },
                    { new Guid("a3c5bf9a-e825-4baa-ba64-cc56d487784b"), "G.46.66", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of other office machinery and equipment" },
                    { new Guid("9f71e617-8147-45d8-b09b-61acc4e718ec"), "G.46.69", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of other machinery and equipment" },
                    { new Guid("810b8f76-51f0-496a-a370-bb2826111e6a"), "G.46.7", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Other specialised wholesale" },
                    { new Guid("cca2e4c7-e575-45ec-aa1a-72466f0189be"), "G.46.71", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("9cbada32-cc09-4e07-9cf9-25d09c3a8556"), "G.46.72", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of metals and metal ores" },
                    { new Guid("a5d784f8-bcd1-49d7-b907-3ece78a3bb10"), "G.46.73", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("cac0e8bf-fc94-4cd6-838c-02929c7d3769"), "G.46.74", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("556f40e5-c4dd-42c9-b84f-014d47a3a4fb"), "G.46.75", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of chemical products" },
                    { new Guid("8496a9fc-0312-4438-b7f5-4483fa2b2445"), "G.46.76", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of other intermediate products" },
                    { new Guid("183c99a5-c8ac-4c04-8703-20af9e3929cc"), "G.46.77", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of waste and scrap" },
                    { new Guid("3912bcd6-a6f1-4d62-b986-04e81b61fdec"), "G.46.9", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Non-specialised wholesale trade" },
                    { new Guid("c7a97024-d437-4cd6-9fc8-692b46cd232f"), "G.46.90", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Non-specialised wholesale trade" },
                    { new Guid("4e755f60-239e-47f7-a926-6d37fc3b24ae"), "G.47", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("2386fab0-08aa-4cde-acd8-74b48f892a13"), "G.47.1", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale in non-specialised stores" },
                    { new Guid("c36ab820-2a5c-48ea-a59c-2e65d2f2ed9d"), "G.47.11", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("b1ccdc78-38ed-4b1a-9ecd-a620245833a4"), "G.47.19", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Other retail sale in non-specialised stores" },
                    { new Guid("beaf042c-2668-44e2-a64a-44fb6b10782c"), "G.47.2", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("56e5e775-5524-4bd4-99d7-a5a18fbef17f"), "G.47.21", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("e170d35b-dcb0-4638-bbf1-0ae59f823edd"), "G.47.22", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("a9910284-b68a-4e73-bbad-e37750fb5961"), "G.47.23", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("72e2d7f2-caf1-4599-a293-eb1fbbeaaca3"), "G.47.24", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("02e4b612-c95a-46cf-804c-004020097669"), "G.47.25", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Retail sale of beverages in specialised stores" },
                    { new Guid("d5dfebf4-59f5-40af-84f1-939706b5b421"), "G.46.52", new Guid("e6623a67-b034-4ce7-bb05-4d481ed3fb04"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("01043602-6ab5-4c39-88df-0088c078570c"), "F.43.22", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("158b96c6-196b-4c74-8f4e-0944e06ac36e"), "K.64.99", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("d24e01cd-07b0-4341-b381-40f3d0068410"), "K.65.1", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Insurance" },
                    { new Guid("d2f9a2ca-4084-4cd9-a675-55fad4f28229"), "P.85.6", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Educational support activities" },
                    { new Guid("d0358193-1003-4dfd-9eab-34b2ac530bc8"), "P.85.60", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Educational support activities" },
                    { new Guid("34552b0b-c470-418f-aad0-69f634acbfeb"), "Q.86", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Human health activities" },
                    { new Guid("feeefe6b-09a9-468a-bacd-8d29e0e1a1a9"), "Q.86.1", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Hospital activities" },
                    { new Guid("6bdde17d-1451-4df3-92f2-7a42e5e92314"), "Q.86.10", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Hospital activities" },
                    { new Guid("f2559028-2503-43ff-b5a6-83cbee6c4d62"), "Q.86.2", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Medical and dental practice activities" },
                    { new Guid("d09cb55f-76cd-478b-ad08-5c4cefd73396"), "Q.86.21", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d9196e4f-beed-44c2-8f0a-3b1810e0d74a"), "Q.86.22", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Specialist medical practice activities" },
                    { new Guid("e7518edc-ac55-4964-8072-184ddc5a0454"), "Q.86.23", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Dental practice activities" },
                    { new Guid("52a694d8-540b-43a5-a70e-775fbf6ec695"), "Q.86.9", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Other human health activities" },
                    { new Guid("24ef8bc7-44e3-4543-a7f4-7ea01fc72b9f"), "Q.86.90", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Other human health activities" },
                    { new Guid("88d21888-ff00-4acd-b99e-d00eb655cd55"), "Q.87", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential care activities" },
                    { new Guid("81165ad7-89bb-4694-879c-57080eb19203"), "P.85.59", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Other education n.e.c." },
                    { new Guid("5aaa3487-ea0f-4cb6-8fae-00d162194c91"), "Q.87.1", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential nursing care activities" },
                    { new Guid("71f9b6d8-ca35-4d7f-9558-a45816ea21f6"), "Q.87.2", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("35f1e1c5-7225-4ea9-a788-1a79ad0f9742"), "Q.87.20", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("3cd6b60b-4b2c-45af-a056-4d256c7ff2cc"), "Q.87.3", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential care activities for the elderly and disabled" },
                    { new Guid("c420e253-fc90-4ea6-b207-bcad6f8bce52"), "Q.87.30", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential care activities for the elderly and disabled" },
                    { new Guid("419bf6e6-21d9-49d0-9bfc-724ffa7b4f6a"), "Q.87.9", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Other residential care activities" },
                    { new Guid("06f9541f-bfa2-43ae-a343-f2c9eb2f61dc"), "Q.87.90", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Other residential care activities" },
                    { new Guid("40393ff1-4329-4878-9003-acda29ca4793"), "Q.88", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Social work activities without accommodation" },
                    { new Guid("66ee9ed3-2177-4569-9fe0-18a3eb85fe96"), "Q.88.1", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("10a4e06a-f8ba-4bc0-b1b4-31bed4d40063"), "Q.88.10", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("c4862cc7-8edb-4cfd-80e1-5fefb1b60a30"), "Q.88.9", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Other social work activities without accommodation" },
                    { new Guid("5fc98c96-5d0f-447a-aeea-b1c6e7ec18d3"), "Q.88.91", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Child day-care activities" },
                    { new Guid("51249b16-2186-4c98-a3c7-b7dc8175f7be"), "Q.88.99", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("b3d7e1e6-0760-4596-b478-8f5c76ac13a6"), "Q.87.10", new Guid("0c09cc32-bf58-49a8-a0c2-510e7c7b7371"), "Residential nursing care activities" },
                    { new Guid("442abfe9-dac8-4dd2-9b66-d3d61d794470"), "P.85.53", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Driving school activities" },
                    { new Guid("a211ffe8-0eac-4b50-b88a-26da52ff9ffd"), "P.85.52", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Cultural education" },
                    { new Guid("783d9ca7-3543-4113-86df-9cd2026b4681"), "P.85.51", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Sports and recreation education" },
                    { new Guid("dbe29458-1fcd-4513-8289-88e5f0cb8f45"), "N.82.91", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Packaging activities" },
                    { new Guid("39add3d0-49d2-48eb-afbf-3f34813dcfe2"), "N.82.99", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other business support service activities n.e.c." },
                    { new Guid("b8104308-3f2f-46f3-9b08-411d73bdba71"), "O.84", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Public administration and defence; compulsory social security" },
                    { new Guid("5f3dd232-ce75-4ac6-9f89-334fb936741b"), "O.84.1", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("15125d5e-fb90-4e3e-a91e-284f393547cb"), "O.84.11", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "General public administration activities" },
                    { new Guid("6ca33977-2899-4758-b93e-d17a767ea685"), "O.84.12", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("2db128d5-bb72-460f-aa75-2591baa0496a"), "O.84.13", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("80455c50-82ae-4dd3-824e-9ec95d6650c1"), "O.84.2", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Provision of services to the community as a whole" },
                    { new Guid("ec841966-cfe7-4c7c-ab38-8ea03158ec83"), "O.84.21", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Foreign affairs" },
                    { new Guid("5ff28396-0918-4d1c-971c-45b01669f854"), "O.84.22", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Defence activities" },
                    { new Guid("b20a2d34-6170-4abe-9e8e-47d9de577494"), "O.84.23", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Justice and judicial activities" },
                    { new Guid("953238a7-29cf-463f-b72d-823bd1455ad8"), "O.84.24", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Public order and safety activities" },
                    { new Guid("d25f8803-1c20-496c-9f80-482d289ec1a3"), "O.84.25", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Fire service activities" },
                    { new Guid("5c95fe95-4254-476f-9569-ec15ebfb4147"), "O.84.3", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Compulsory social security activities" },
                    { new Guid("76095da1-8e5b-497c-9a33-d3a9c18a76f1"), "O.84.30", new Guid("4b0e2f77-8f0c-4bf9-99ac-7a22b992ca20"), "Compulsory social security activities" },
                    { new Guid("8262d9e4-ae55-4b5a-840c-b4c40368d6f5"), "P.85", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Education" },
                    { new Guid("dcc3136a-d52d-4318-8fea-27ebebaf3bf4"), "P.85.1", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Pre-primary education" },
                    { new Guid("21787741-ee53-4fff-9c46-658681aed3ff"), "P.85.10", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Pre-primary education" },
                    { new Guid("d84bfbc6-e080-4751-921a-2c14a016cc65"), "P.85.2", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a347029a-1d7b-4857-8a93-a9ebaec0a8cb"), "P.85.20", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Primary education" },
                    { new Guid("4eb05c40-e8b3-4c5e-86d5-7ce2ab36dd4a"), "P.85.3", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Secondary education" },
                    { new Guid("019b6991-b8ed-4c0c-8f82-1ce8bab14f2d"), "P.85.31", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "General secondary education" },
                    { new Guid("5eeef374-d7d4-4aa2-be48-6718a30a6942"), "P.85.32", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Technical and vocational secondary education" },
                    { new Guid("d1dc1a98-fa4b-4cda-867d-f267e1a94681"), "P.85.4", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Higher education" },
                    { new Guid("96b2b2cb-6e5a-4e63-9cad-90949ef67265"), "P.85.41", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Post-secondary non-tertiary education" },
                    { new Guid("648bf703-a78d-4bfb-ae81-9c23bb741a94"), "P.85.42", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Tertiary education" },
                    { new Guid("75202aa4-4dd0-4f26-9141-9fb284087a16"), "P.85.5", new Guid("45917ee4-985d-46ac-abc8-52b9270d6f9f"), "Other education" },
                    { new Guid("d144cb59-5312-4c34-ba74-a423b03c183a"), "R.90", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Creative, arts and entertainment activities" },
                    { new Guid("72745880-a5c4-4b2f-b3a1-6df353b98bcf"), "N.82.92", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("2db1a163-8a61-4ae2-968e-8d515921d2eb"), "R.90.0", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Creative, arts and entertainment activities" },
                    { new Guid("9cc75c9d-ac54-4627-b6e5-25f23a5eb17c"), "R.90.02", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Support activities to performing arts" },
                    { new Guid("eba73dcb-3a54-4045-a750-429edbae5adf"), "S.95.1", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of computers and communication equipment" },
                    { new Guid("df93d2b0-59a0-4872-89b4-0ca061d060b7"), "S.95.11", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of computers and peripheral equipment" },
                    { new Guid("877848e6-df4c-477c-b95d-98f42033e39e"), "S.95.12", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of communication equipment" },
                    { new Guid("3d2e2e27-20ca-4cae-8076-64a346d5eafa"), "S.95.2", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of personal and household goods" },
                    { new Guid("a631c1a3-bb1c-4a43-9e4e-52d6bcf04903"), "S.95.21", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of consumer electronics" },
                    { new Guid("ff0d9185-4b49-42d1-82cb-8eed00aa607f"), "S.95.22", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("439c9ff4-146f-4de9-8c4e-f994864b80cb"), "S.95.23", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of footwear and leather goods" },
                    { new Guid("9c77ba87-3ca4-40b4-a608-16b841b034f1"), "S.95.24", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of furniture and home furnishings" },
                    { new Guid("155c7000-f4ff-4860-8f45-33ba337a7c4b"), "S.95.25", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of watches, clocks and jewellery" },
                    { new Guid("3092451a-cd3f-4e51-84b2-a611ad09ec98"), "S.95.29", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of other personal and household goods" },
                    { new Guid("c33276f2-2b27-45cc-a450-4753b88f75e1"), "S.96", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Other personal service activities" },
                    { new Guid("14348d95-ddfa-4a76-badd-144caf98d711"), "S.96.0", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Other personal service activities" },
                    { new Guid("b4fc5cfe-06ab-478e-8686-0a204bad7fe3"), "S.95", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Repair of computers and personal and household goods" },
                    { new Guid("97eb239f-8b78-40bb-9417-be53bcf5c83e"), "S.96.01", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("762bea0f-fa1e-4004-bbdc-cd81ba4f5853"), "S.96.03", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Funeral and related activities" },
                    { new Guid("2ad3e9a9-68d9-4275-8b44-e242e25862a3"), "S.96.04", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Physical well-being activities" },
                    { new Guid("7275c7d6-ab98-4ee5-952b-4889fb6da0f1"), "S.96.09", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Other personal service activities n.e.c." },
                    { new Guid("291b95b5-7f3d-479a-9884-86bbc9f1be7c"), "T.97", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("d3751e84-733a-4878-a6b1-570fda0fe235"), "T.97.0", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("98209894-519e-4161-8cbb-379233f0caab"), "T.97.00", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Activities of households as employers of domestic personnel" },
                    { new Guid("67cfa048-c136-4ddf-a11d-879492c94626"), "T.98", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("5e861db4-dca9-4dc4-89f2-24203a33093a"), "T.98.1", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("689316e4-c81b-4613-ae8b-2086b0ac1a3c"), "T.98.10", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("5924a8a5-2d2c-4cc0-a206-d2bc6b43386d"), "T.98.2", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("b3e10926-1899-4b02-af60-7a642ca9aeba"), "T.98.20", new Guid("d83b83ee-353b-4e07-9166-964df23f732b"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("8cbf59d0-aa1c-4931-b967-cdbdfe3516fe"), "U.99", new Guid("5d20d174-871b-4a7a-9b75-c4daf279e8a3"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("4a5f5107-2533-4c12-bf3d-7edc117c91ab"), "S.96.02", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Hairdressing and other beauty treatment" },
                    { new Guid("45be53b0-e85b-4974-8321-8a08b22c016d"), "S.94.99", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of other membership organisations n.e.c." },
                    { new Guid("2461bd61-1ca3-42aa-a6e0-538a4dd9d94a"), "S.94.92", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of political organisations" },
                    { new Guid("86ce40a3-bd16-47a5-bc68-0dd8cf49b215"), "S.94.91", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c5cd8f4c-92b9-4a79-b4a2-a467a3e1b5c6"), "R.90.03", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Artistic creation" },
                    { new Guid("c20e58da-ce80-4f3c-868e-c3c69db6434c"), "R.90.04", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Operation of arts facilities" },
                    { new Guid("710a7069-5816-4571-aecf-b2d4c99d9ccf"), "R.91", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("73df0c99-825a-4eda-8990-f80159adabf8"), "R.91.0", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("33006ab7-2637-4566-b765-dfe3eb697f2f"), "R.91.01", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Library and archives activities" },
                    { new Guid("d66dbd0f-ec70-4e7c-b5c9-ba7bf0a73e93"), "R.91.02", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Museums activities" },
                    { new Guid("4b3deba6-a3f2-4c74-b9ee-4ae5cb4f78aa"), "R.91.03", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("20fa0fcf-00f4-4c15-a830-8f1d9fa14ab2"), "R.91.04", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("c7397f5c-c66a-4323-a03e-69d1d3492d2b"), "R.92", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Gambling and betting activities" },
                    { new Guid("41586caf-36a6-4fde-9f4a-b07e4eec9097"), "R.92.0", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Gambling and betting activities" },
                    { new Guid("a811f9a0-8f37-40d5-a5a3-498a0fec16a3"), "R.92.00", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Gambling and betting activities" },
                    { new Guid("ac04e27e-5316-43c4-b879-c8fa23e98c68"), "R.93", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Sports activities and amusement and recreation activities" },
                    { new Guid("9ce76031-6d8f-4ff7-b5b3-f01e4eee89f3"), "R.93.1", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Sports activities" },
                    { new Guid("cd369d56-d443-43cb-8c1d-c4f1ba1181cb"), "R.93.11", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Operation of sports facilities" },
                    { new Guid("ade2ca8c-879a-459e-8be4-1daffe4a7012"), "R.93.12", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Activities of sport clubs" },
                    { new Guid("e581a83b-b53c-44a8-8ee1-56fa2c39753b"), "R.93.13", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Fitness facilities" },
                    { new Guid("10e87537-dcbe-42a1-ba9f-b1ed69c491ea"), "R.93.19", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Other sports activities" },
                    { new Guid("27fa5539-771b-4bf5-8e29-57d814ecdd10"), "R.93.2", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Amusement and recreation activities" },
                    { new Guid("6c3c66fa-f268-4ab5-befa-31d221b5d045"), "R.93.21", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Activities of amusement parks and theme parks" },
                    { new Guid("a3ec05d9-6e7b-4377-843a-4ee2ecaa43d8"), "R.93.29", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Other amusement and recreation activities" },
                    { new Guid("4233196b-a7bb-47d9-8665-eb01433a622c"), "S.94", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of membership organisations" },
                    { new Guid("50800249-6dfa-4240-8b15-e2ecb01a510c"), "S.94.1", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("da5b674d-640c-470f-af0c-235813f85a03"), "S.94.11", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of business and employers membership organisations" },
                    { new Guid("37c2b619-38dc-4db8-a916-0e69c57a7a1d"), "S.94.12", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of professional membership organisations" },
                    { new Guid("a435e117-cae3-401d-8727-7565fa6009a9"), "S.94.2", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of trade unions" },
                    { new Guid("0a9522d2-2467-48d6-a3f2-902ae751abbd"), "S.94.20", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of trade unions" },
                    { new Guid("fe94aa4f-dd3d-40e9-b12c-211a0770f5c2"), "S.94.9", new Guid("7ecb85a5-9d15-4172-aaad-afd4f03b8398"), "Activities of other membership organisations" },
                    { new Guid("79e7a240-fe8d-4137-a41f-27fd33060f5f"), "R.90.01", new Guid("840c9fb0-064d-4ca1-b5e0-a1b3f0cddaa5"), "Performing arts" },
                    { new Guid("624e1141-2313-4f81-8d79-4fab4c55ffa7"), "K.65", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("778b1f5f-cea9-4ecc-9204-8a53bb0a1ae8"), "N.82.9", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Business support service activities n.e.c." },
                    { new Guid("ad44ac34-8a8f-4aac-bfa9-baf8169862e5"), "N.82.3", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Organisation of conventions and trade shows" },
                    { new Guid("0173fd7e-1df1-420c-b10f-8afa2d9c345c"), "M.70.1", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Activities of head offices" },
                    { new Guid("6861abb5-dc54-4449-8195-008cf656e7c2"), "M.70.10", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Activities of head offices" },
                    { new Guid("8e84e631-cbeb-417b-9905-c3df66648bae"), "M.70.2", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Management consultancy activities" },
                    { new Guid("457e778c-eaf6-436b-9083-6b2a2b27152c"), "M.70.21", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Public relations and communication activities" },
                    { new Guid("06cdaf9c-a70c-43eb-804d-363779eb7f33"), "M.70.22", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Business and other management consultancy activities" },
                    { new Guid("e48cd212-e6fa-42bb-b3c6-d56f0d706a66"), "M.71", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("e458ff1d-7285-4b7a-9cbf-11f364a66f9d"), "M.71.1", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("1dbbba10-59b6-4974-b3fe-3a5738535cf4"), "M.71.11", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Architectural activities" },
                    { new Guid("74a67aac-ed7b-4a12-a1cd-0ab3c0705830"), "M.71.12", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Engineering activities and related technical consultancy" },
                    { new Guid("aa878c86-d8aa-4945-bdaf-28fe9d5a4855"), "M.71.2", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Technical testing and analysis" },
                    { new Guid("df06661c-460b-473c-8ee1-ba4274241ae4"), "M.71.20", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("13ab53b0-fde1-4b05-a76b-634eece8d309"), "M.72", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Scientific research and development" },
                    { new Guid("43de12df-5808-447d-b9ed-8175b5a5cce7"), "M.70", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Activities of head offices; management consultancy activities" },
                    { new Guid("a0ae579c-b950-413d-a6fd-fad4c0a20410"), "M.72.1", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("b1cb346f-96fd-4ed9-8029-577628ac27ea"), "M.72.19", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("f8a3ef7d-312f-4390-9652-8bcca28b07b3"), "M.72.2", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("4827a195-8d6e-4650-91ef-a80376084cb3"), "M.72.20", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("ae51fa43-cc44-4fbc-ae96-335ddd0c24a3"), "M.73", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Advertising and market research" },
                    { new Guid("84dcc260-48fa-4e63-8224-cb4e74bc401b"), "M.73.1", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Advertising" },
                    { new Guid("8e33e3cb-c436-4a1f-9ff9-f23b79bfcd99"), "M.73.11", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Advertising agencies" },
                    { new Guid("56b6ab7f-dd81-4e90-9e31-2928fe302380"), "M.73.12", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Media representation" },
                    { new Guid("632933d0-1993-4605-a1a0-38a863c6d1cc"), "M.73.2", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Market research and public opinion polling" },
                    { new Guid("4089d88a-a119-4a09-b0cb-9a8f561c4988"), "M.73.20", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Market research and public opinion polling" },
                    { new Guid("4b98b13e-2def-4f78-9bda-8d39625661bb"), "M.74", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Other professional, scientific and technical activities" },
                    { new Guid("ce71c864-b362-48fe-871e-560a9bfa06f8"), "M.74.1", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Specialised design activities" },
                    { new Guid("e7818a97-913a-494e-8d8b-d52f019ffa82"), "M.74.10", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Specialised design activities" },
                    { new Guid("87d6f3b9-0f92-4c93-910e-0967b731ffc1"), "M.72.11", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Research and experimental development on biotechnology" },
                    { new Guid("f287b002-9f94-4327-b70e-45a773b977d1"), "M.69.20", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("28fb8bef-9686-4627-8c79-b1058fba6d3c"), "M.69.2", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("481ae845-d373-4bfe-a9bb-a31eae20c39f"), "M.69.10", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Legal activities" },
                    { new Guid("fbe253af-3742-4ad7-935d-8621e3208af7"), "K.65.11", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Life insurance" },
                    { new Guid("7b6ac8e6-72f0-4b07-b4c4-b32d2ac5db1d"), "K.65.12", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Non-life insurance" },
                    { new Guid("51cd5cc4-571a-4171-a316-a7e1f181121f"), "K.65.2", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Reinsurance" },
                    { new Guid("b466685f-791a-4615-8700-762b38f125f3"), "K.65.20", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Reinsurance" },
                    { new Guid("2ff263ce-023e-40cf-aa22-4f6726c78dd9"), "K.65.3", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Pension funding" },
                    { new Guid("4500764f-0088-444b-9408-0c398c176efb"), "K.65.30", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Pension funding" },
                    { new Guid("e62818ab-74e8-4000-b61c-af6ee0565b6d"), "K.66", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("b00cfbbb-3802-459c-89f5-302335ffc8db"), "K.66.1", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("35680f91-9211-4000-af25-36024e627abe"), "K.66.11", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Administration of financial markets" },
                    { new Guid("62ba44d8-ee67-4b22-80f7-af1990de2350"), "K.66.12", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Security and commodity contracts brokerage" },
                    { new Guid("28b5e021-4cbc-4447-9134-04f3c4ca6947"), "K.66.19", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("37c62f25-5d45-40e1-b635-37c502445102"), "K.66.2", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("b1f2c87e-e828-4f28-b8ab-cd4db06449d2"), "K.66.21", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Risk and damage evaluation" },
                    { new Guid("77e499fd-92ca-43a6-9bcc-69bb9370166f"), "K.66.22", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Activities of insurance agents and brokers" },
                    { new Guid("4ffa4154-9ac6-4377-aeb8-270eda99c8d4"), "K.66.29", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("241f35e5-bf70-4937-9b5d-5bab11c1012e"), "K.66.3", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Fund management activities" },
                    { new Guid("21f521fc-f242-4e3c-b3c8-275ddd2ae441"), "K.66.30", new Guid("501ee2ed-ee75-43bb-b38e-39e044087f76"), "Fund management activities" },
                    { new Guid("fe9deda6-7257-4d95-ada7-1e71ac9410ad"), "L.68", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Real estate activities" },
                    { new Guid("f50166b9-1a9e-4c47-bb66-d7f154d441a5"), "L.68.1", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Buying and selling of own real estate" },
                    { new Guid("5eb04d2c-0f54-41a3-bca6-7b339d2331db"), "L.68.10", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Buying and selling of own real estate" },
                    { new Guid("bf19c6cc-9501-4c23-be40-e2fde87a4e3f"), "L.68.2", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Renting and operating of own or leased real estate" },
                    { new Guid("70ee107b-2c20-4451-8e7d-7ec98e452dc5"), "L.68.20", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Renting and operating of own or leased real estate" },
                    { new Guid("09f1d48d-e794-41c5-b4cb-0a42f800f7bf"), "L.68.3", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4ae9e289-e765-4165-81ed-ae547a59ba73"), "L.68.31", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Real estate agencies" },
                    { new Guid("f184fc20-5556-4528-875f-bae23d713a02"), "L.68.32", new Guid("c1044dd0-700a-45b9-8f5a-35cb7e5d2c96"), "Management of real estate on a fee or contract basis" },
                    { new Guid("73924875-f903-4215-a10d-3cef840b5105"), "M.69", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Legal and accounting activities" },
                    { new Guid("11001118-5f5c-4d70-97b6-511d6714a7f4"), "M.69.1", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Legal activities" },
                    { new Guid("274a26bd-80d5-45a5-945d-e0d20992fafd"), "M.74.2", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Photographic activities" },
                    { new Guid("aee25680-bc02-40c5-aad6-7568590533d6"), "N.82.30", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Organisation of conventions and trade shows" },
                    { new Guid("51c4fd48-7c7e-4112-8489-064f11775526"), "M.74.20", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Photographic activities" },
                    { new Guid("596e745c-2cdc-4268-b434-470aa3a91c05"), "M.74.30", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Translation and interpretation activities" },
                    { new Guid("9c8f284b-62db-4522-9ffd-2fc37538352d"), "N.79.11", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Travel agency activities" },
                    { new Guid("a092235f-9e35-4188-8f41-c83939f37101"), "N.79.12", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Tour operator activities" },
                    { new Guid("10de9bd7-eb63-4bdd-b7c2-25a8b1655b0c"), "N.79.9", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other reservation service and related activities" },
                    { new Guid("e86c39c7-df8c-4f59-aa70-65226cb6b32d"), "N.79.90", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other reservation service and related activities" },
                    { new Guid("92f97d10-c40c-4036-bcf5-2cc700158250"), "N.80", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Security and investigation activities" },
                    { new Guid("f138c777-5c2a-4245-894c-85b5ca4e6e43"), "N.80.1", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Private security activities" },
                    { new Guid("5e7fe0cb-1421-47b2-a25c-570446fc6dcc"), "N.80.10", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Private security activities" },
                    { new Guid("cba11fbe-96c9-4f2d-80b8-9e2b9d360b0b"), "N.80.2", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Security systems service activities" },
                    { new Guid("fe414215-a432-4fe0-9fd4-d9a8e342ee65"), "N.80.20", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Security systems service activities" },
                    { new Guid("971d260f-75ff-45fe-b3d6-9dafcb7ce678"), "N.80.3", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Investigation activities" },
                    { new Guid("5c0e5b22-f424-467b-af4e-24c88233d4ba"), "N.80.30", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Investigation activities" },
                    { new Guid("521b8d63-6543-4784-bfff-627e9e50eac0"), "N.81", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Services to buildings and landscape activities" },
                    { new Guid("1de35b22-da2f-4003-81bf-d059d7b4676e"), "N.79.1", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Travel agency and tour operator activities" },
                    { new Guid("abc8f28e-b87b-498e-8a64-895a965eba23"), "N.81.1", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Combined facilities support activities" },
                    { new Guid("694137c1-0ae0-4497-8e45-90313fd8fb9a"), "N.81.2", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Cleaning activities" },
                    { new Guid("39300d40-3e5b-43d6-b388-b271e6f77d2f"), "N.81.21", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "General cleaning of buildings" },
                    { new Guid("fe05f7b2-a0b2-402a-9f55-eb3520efa7b5"), "N.81.22", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other building and industrial cleaning activities" },
                    { new Guid("662ff642-9d05-447f-ad58-63d7c5a3e651"), "N.81.29", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other cleaning activities" },
                    { new Guid("9e8b1d4a-1691-41b2-8684-245808ea3a39"), "N.81.3", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Landscape service activities" },
                    { new Guid("4d218a0a-c91b-405b-b107-814577082368"), "N.81.30", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Landscape service activities" },
                    { new Guid("894de3a8-2caa-4008-90a1-2ea18d1664fe"), "N.82", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Office administrative, office support and other business support activities" },
                    { new Guid("2b4eea96-5d2d-4890-94e2-1590fbcb6496"), "N.82.1", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Office administrative and support activities" },
                    { new Guid("7a420d42-9fdf-4e19-b7e4-a5e4383f3285"), "N.82.11", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Combined office administrative service activities" },
                    { new Guid("7cef7518-4c4a-4cf4-a984-395d534ed2c5"), "N.82.19", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("0180c182-bb97-4238-8d1e-fe244f3cfdd4"), "N.82.2", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Activities of call centres" },
                    { new Guid("878488bf-20db-4f28-bb27-214aff69c1f4"), "N.82.20", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Activities of call centres" },
                    { new Guid("9df8333f-ff01-45dc-b07d-af91211b9767"), "N.81.10", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Combined facilities support activities" },
                    { new Guid("d9e362cd-456a-4851-a246-fba545e53ed6"), "N.79", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("e2bc8f0c-7c87-4c93-9e1b-9691cd109dbf"), "N.78.30", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other human resources provision" },
                    { new Guid("abbd612a-1f8f-4035-a928-91c771caa9bd"), "N.78.3", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Other human resources provision" },
                    { new Guid("a990f05f-6b88-4218-85de-882499b07850"), "M.74.9", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("647bb918-273f-4cb8-8f1c-a26a52de6fb2"), "M.74.90", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("21bad560-0ea5-477c-9b38-e887e2d3ac68"), "M.75", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Veterinary activities" },
                    { new Guid("a411d5bd-2b26-4ed1-a70f-8f5776b1d744"), "M.75.0", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e78a0122-893e-45ea-920e-20cd2f454ace"), "M.75.00", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Veterinary activities" },
                    { new Guid("6717e64a-ad8f-43b7-b84d-949a0bea5c8d"), "N.77", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Rental and leasing activities" },
                    { new Guid("c432d058-d95b-4563-bb9c-2f793949d37f"), "N.77.1", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of motor vehicles" },
                    { new Guid("a733257d-c703-4705-ad63-0baad4690c9f"), "N.77.11", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("f5f0a872-3682-4fb9-901d-46f43c8326a7"), "N.77.12", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of trucks" },
                    { new Guid("ae57f1b1-d2cf-4954-aae8-17db2f0de813"), "N.77.2", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of personal and household goods" },
                    { new Guid("e1c5d01e-e56a-4077-98e9-03731b7cdf24"), "N.77.21", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("bc880af1-3fd7-465e-843c-ba71b93f20f4"), "N.77.22", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting of video tapes and disks" },
                    { new Guid("032a0f7a-ab1f-48d0-8f58-cf0eb585d95f"), "N.77.29", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of other personal and household goods" },
                    { new Guid("4893254a-7002-439a-8cb9-44b823f401c3"), "N.77.3", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("db4da46e-50dd-473c-96a6-23e1c9a21ea9"), "N.77.31", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("83b1fc2f-466a-40e1-9e64-49b97d25ced6"), "N.77.32", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("243f5788-ea62-4fdb-a9f8-8bc2fc305c8e"), "N.77.33", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("acc3735a-ba39-45d6-9861-d1fe2fc3b1cb"), "N.77.34", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of water transport equipment" },
                    { new Guid("cb5fa966-feaf-4cda-a1fc-b35687a619a0"), "N.77.35", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of air transport equipment" },
                    { new Guid("2c195590-9a4b-4f82-8625-4ac680194eb5"), "N.77.39", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("00e8d115-3222-4147-ba3d-30f7b88ff261"), "N.77.4", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("1adcf836-22ef-4b29-8da9-a8ac6b22b34b"), "N.77.40", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("e47aa2b3-fec5-426a-ba0e-f1409f36ce25"), "N.78", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Employment activities" },
                    { new Guid("7fc79e9d-837c-4d5d-8c80-bf9f6b9ce2ab"), "N.78.1", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Activities of employment placement agencies" },
                    { new Guid("ee32536d-fbfe-4855-bcaa-7ed838c619af"), "N.78.10", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Activities of employment placement agencies" },
                    { new Guid("247ee850-a960-4e10-933e-aae4c716cc1f"), "N.78.2", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Temporary employment agency activities" },
                    { new Guid("76177258-0dca-409c-8126-e297a5be69d1"), "N.78.20", new Guid("8807ff22-6ae4-484f-8f17-845d51f1460d"), "Temporary employment agency activities" },
                    { new Guid("e65a91e2-76b6-4b63-98d8-daeba7b9a9fd"), "M.74.3", new Guid("837f04a4-62f4-4548-88cc-7b2d283f1de2"), "Translation and interpretation activities" },
                    { new Guid("ebd90866-610f-47dc-8d2c-8d8896c01b64"), "U.99.0", new Guid("5d20d174-871b-4a7a-9b75-c4daf279e8a3"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("413c4378-930d-4534-8575-11b5fee04a96"), "F.43.21", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Electrical installation" },
                    { new Guid("0a6587fb-1a27-4689-9200-24c6687f4d5a"), "F.43.13", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Test drilling and boring" },
                    { new Guid("da6dd701-faf0-4d22-ba57-584d95a09d65"), "C.14.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of articles of fur" },
                    { new Guid("74473d8b-7f2e-4b5f-99ad-15525a94d8be"), "C.14.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of articles of fur" },
                    { new Guid("b8150338-36dd-4972-901e-c7bf6b949a6a"), "C.14.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("707b1056-b414-47fd-afff-ff414f28b8f5"), "C.14.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("6cfc4467-57f1-4a1d-b2d2-1a09a5e47d66"), "C.14.39", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("a47d454a-881f-45f6-8fcb-787d3a440001"), "C.15", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of leather and related products" },
                    { new Guid("f33f6abd-f919-445f-aae7-0dc41be8ed0a"), "C.15.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("996c9e39-b02d-4302-af63-06b18f8b44a5"), "C.15.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("efd7cb46-05d3-40af-b12a-059a232e589f"), "C.15.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("adcad313-29e0-4228-93d2-ddcce85b04a3"), "C.15.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of footwear" },
                    { new Guid("5a220a39-a3e1-48d1-8fff-34bd34d9c28d"), "C.15.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of footwear" },
                    { new Guid("0e828385-29aa-49ed-bc55-c4493dde11ad"), "C.16", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("af43e3b9-f0ce-415b-b177-b8b70353fade"), "C.14.19", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("f7b2d490-a26a-4e3e-ad7b-dd812f3d2af1"), "C.16.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Sawmilling and planing of wood" },
                    { new Guid("7153aab7-7225-4355-9326-8e84250f9e6f"), "C.16.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ff4a41aa-3b36-4966-93dd-d3b7e7fdb21e"), "C.16.21", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("fdd9a9db-8131-4a4d-acab-4bc61e391976"), "C.16.22", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of assembled parquet floors" },
                    { new Guid("bf45af80-cd7c-4656-b875-eca937100859"), "C.16.23", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("b2153cb3-6a5a-46d4-90de-908f8eefa173"), "C.16.24", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wooden containers" },
                    { new Guid("7aa38817-ef2c-404c-831e-9886ee0b19a3"), "C.16.29", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("c322a2eb-e75e-4beb-86d1-46f4f79cd043"), "C.17", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of paper and paper products" },
                    { new Guid("68118447-9f2c-41df-88c0-ab08cbc6b3ce"), "C.17.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("ceabb6ec-5582-4484-9d38-16a0d98c1aee"), "C.17.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of pulp" },
                    { new Guid("67d76955-199a-4664-9327-e2bb6e68c821"), "C.17.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of paper and paperboard" },
                    { new Guid("54375e8e-a6d3-4597-9233-c83ad7e9a9ab"), "C.17.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("0b8ebb53-18a4-4f8f-b784-676a7e5ef0e1"), "C.17.21", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("ace5e561-ed00-4516-8c5e-4aaa1470df89"), "C.16.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Sawmilling and planing of wood" },
                    { new Guid("b8b033f2-6b14-483b-a2c6-c29c4caa940a"), "C.14.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of underwear" },
                    { new Guid("0fb789aa-8061-460a-8746-50496881f923"), "C.14.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other outerwear" },
                    { new Guid("e19d7e57-6104-4daa-a115-b7032355b518"), "C.14.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of workwear" },
                    { new Guid("ab46191f-4291-489a-9e9c-b7612d5953b0"), "C.11.02", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wine from grape" },
                    { new Guid("b701f1e1-ad86-4913-ab14-147ca1266ddf"), "C.11.03", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cider and other fruit wines" },
                    { new Guid("a7352e08-a2de-41cc-be5d-1c8d8044cecc"), "C.11.04", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("e107d1ce-3644-458b-969c-5b3b514c9eae"), "C.11.05", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of beer" },
                    { new Guid("f070a779-9ea6-4a20-baec-1b7423d96cdc"), "C.11.06", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of malt" },
                    { new Guid("56bfd84b-b091-4d3e-a46b-db694dd61276"), "C.11.07", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("b94c2838-c7a9-4f71-b205-9cc82a9ede31"), "C.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tobacco products" },
                    { new Guid("707f48a8-0b5a-44ac-b8eb-e000d7197bb5"), "C.12.0", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tobacco products" },
                    { new Guid("f05530dd-63ce-4c3b-9475-322439c0a7cd"), "C.12.00", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tobacco products" },
                    { new Guid("d610dce5-f53d-4c3d-9c98-8b174fa2d3cb"), "C.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of textiles" },
                    { new Guid("34ede971-94e2-414c-acd0-6c6ed962800b"), "C.13.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Preparation and spinning of textile fibres" },
                    { new Guid("77926a88-c5bd-4375-a383-8937576246ba"), "C.13.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Preparation and spinning of textile fibres" },
                    { new Guid("61cf3b3b-69b8-4328-84c0-f4c42621cacc"), "C.13.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Weaving of textiles" },
                    { new Guid("69d6a26f-2436-407b-b2b1-153917c1e2c5"), "C.13.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Weaving of textiles" },
                    { new Guid("c11e64aa-33ed-429f-b53c-fdaade9206b3"), "C.13.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Finishing of textiles" },
                    { new Guid("1d30ca61-f9a1-4572-9f71-67b3768cc0ac"), "C.13.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Finishing of textiles" },
                    { new Guid("4e0289d5-679d-459d-94ac-c85a4b32113d"), "C.13.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other textiles" },
                    { new Guid("07b94945-ca35-423f-9d63-1059b84a609c"), "C.13.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("6113ab1d-84f3-4870-a6e3-338f4ce70f93"), "C.13.92", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("dfc07321-3fb2-428e-bcaf-a31e2e2de463"), "C.13.93", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of carpets and rugs" },
                    { new Guid("d714ad23-c6ad-4017-a04c-0d73b0e5f75b"), "C.13.94", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("d7cceead-8ad8-4339-9f50-af97ed824c23"), "C.13.95", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("04c6c741-d60a-4032-8dd4-6fff6f6f4a38"), "C.13.96", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("19a0f82e-89ae-47a9-b76b-f06dd09b6a44"), "C.13.99", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other textiles n.e.c." },
                    { new Guid("aabdc08e-03ca-4448-8d3e-62b49e519d93"), "C.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wearing apparel" },
                    { new Guid("8a2a117e-034c-431a-9cfe-3fddb2df7147"), "C.14.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("dfbb9e63-f5db-4cbb-b786-7e0298b97578"), "C.14.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("024f1b76-add1-4b79-95ee-a79e77b9646f"), "C.17.22", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("994ec3f6-c543-4792-8f4b-72c6b8b54596"), "C.11.01", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("dd604a30-8247-4303-bdf4-03bed9b6be5e"), "C.17.23", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of paper stationery" },
                    { new Guid("4bdf43d8-e7a1-4bec-b6c0-c1ed2aa8567d"), "C.17.29", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("021922dc-e77d-4cf4-82bd-b8204b038ca2"), "C.20.52", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of glues" },
                    { new Guid("18fda6c1-fe72-4597-950f-b036595bb623"), "C.20.53", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of essential oils" },
                    { new Guid("80ec298b-ace0-40dd-9186-894ebec2774e"), "C.20.59", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("0dbfc791-6c53-4e25-9522-3ab4e4896c8a"), "C.20.6", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of man-made fibres" },
                    { new Guid("a29c20de-5722-46b6-8d68-2aed6f4c77e7"), "C.20.60", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of man-made fibres" },
                    { new Guid("8e8f3bff-275f-47df-a0fd-32e0a72a1813"), "C.21", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("193d92f0-02e0-49e5-9c73-044488739d3a"), "C.21.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("aa3bb1f7-81a7-49c9-b07a-379b0bc885f1"), "C.21.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("cb1214fc-3356-4ddf-b42d-3ac1329caf38"), "C.21.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("1a9eeb82-86fc-4df0-95a0-44e536baf9a9"), "C.21.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("c5db13b0-bc15-41c8-acce-d785f033ce22"), "C.22", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of rubber and plastic products" },
                    { new Guid("574e0df7-9b85-45d2-88b9-4bb251afd4c7"), "C.22.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of rubber products" },
                    { new Guid("9d1ad1c0-9389-4260-90d8-13abfb6ba812"), "C.20.51", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of explosives" },
                    { new Guid("effc4332-32c8-4ed5-950b-00992ddecb4a"), "C.22.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("5b52bd50-a223-4584-b7f7-8f34dd346604"), "C.22.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of plastics products" },
                    { new Guid("bf07f414-f01f-45f5-bc2c-3049030d3f7e"), "C.22.21", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("ad40a7be-0a82-4bcb-ad53-0a0e2e38aa4a"), "C.22.22", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of plastic packing goods" },
                    { new Guid("c2c2cd6d-8354-41a0-9bc0-9d11e6e851ac"), "C.22.23", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("0874be3b-166c-479a-81a4-143c98ec230f"), "C.22.29", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other plastic products" },
                    { new Guid("c86c074b-224f-40d6-a8e7-6cb4339f51d6"), "C.23", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("d7166639-356e-4f79-9296-61b243ab3974"), "C.23.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of glass and glass products" },
                    { new Guid("243f9254-9d97-4df4-9b57-f7c056a34e2b"), "C.23.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of flat glass" },
                    { new Guid("c256a20c-3a5c-4f8a-89ff-4760e4ff7b6e"), "C.23.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Shaping and processing of flat glass" },
                    { new Guid("b29a0178-f1e4-4e54-959a-f8eca2fdedf7"), "C.23.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of hollow glass" },
                    { new Guid("d91bf989-8e82-4a08-b0a1-c80633356ae7"), "C.23.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of glass fibres" },
                    { new Guid("532b1315-7648-4084-9db7-5894f4ccb74e"), "C.23.19", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("ecc5f691-a15e-493b-af9a-07ad1708820f"), "C.22.19", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other rubber products" },
                    { new Guid("26ce64f6-7674-41fc-83c5-896e9ed83ba9"), "C.20.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other chemical products" },
                    { new Guid("88b26b60-12b8-4b05-9e7c-b09d7bb97032"), "C.20.42", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("12228a3f-adcf-4534-bed1-6562b7733097"), "C.20.41", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("88fa9d3f-58af-4091-bbfa-8f5918d0b33d"), "C.18", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Printing and reproduction of recorded media" },
                    { new Guid("aef35b23-7419-4598-8626-477114dc39c2"), "C.18.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Printing and service activities related to printing" },
                    { new Guid("a1307cce-739e-4306-b651-94e0669f3078"), "C.18.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Printing of newspapers" },
                    { new Guid("1ef4b94f-522a-466a-8386-76f1c296279d"), "C.18.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Other printing" },
                    { new Guid("e87cfe27-a24f-4a33-a8e5-b7cc2906ea0e"), "C.18.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Pre-press and pre-media services" },
                    { new Guid("1ad8925c-67be-4f32-971a-ebfc0b3ed3d7"), "C.18.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Binding and related services" },
                    { new Guid("fce18e1e-4d11-4507-b1e1-563143f84480"), "C.18.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Reproduction of recorded media" },
                    { new Guid("464297a8-6981-4305-8c62-91f20481a692"), "C.18.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("666d356e-8e25-472a-93e6-8dffd3e40f64"), "C.19", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("6e92b44b-0d18-40c2-ab98-c80ad81d1831"), "C.19.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of coke oven products" },
                    { new Guid("2ec08fbf-82a2-48d9-b411-9efd501a5838"), "C.19.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of coke oven products" },
                    { new Guid("fc9f9ba1-7f62-4588-b032-8d9c33eb9037"), "C.19.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of refined petroleum products" },
                    { new Guid("e609fea3-05eb-40a5-a87e-aef07babc26b"), "C.19.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of refined petroleum products" },
                    { new Guid("c58f067e-9ae2-46df-a91b-a24977564b6c"), "C.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of chemicals and chemical products" },
                    { new Guid("b9766045-3d4b-4ecd-ac27-0e4bacac991c"), "C.20.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("d608c1b3-4013-4911-9632-3e1d06129bfe"), "C.20.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of industrial gases" },
                    { new Guid("f227dbe3-c801-4b28-89a2-375b2ba80286"), "C.20.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of dyes and pigments" },
                    { new Guid("c460271f-1bc7-4079-b44d-b95a2f679ec3"), "C.20.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("32ded84d-6ee3-43b3-8548-9b1a2b7a8f7b"), "C.20.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other organic basic chemicals" },
                    { new Guid("26a251a3-25e6-4dab-918f-eacf569dfe3d"), "C.20.15", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("0fed87db-2a1d-4d42-877e-eae2b0ab3e64"), "C.20.16", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of plastics in primary forms" },
                    { new Guid("725a6906-b8c5-4943-b935-3493c0f323f6"), "C.20.17", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("a2cb1449-1548-45db-8a1a-78f63e13cb81"), "C.20.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("5e9d45db-5497-4d77-ad5d-d2cba0a16cb2"), "C.20.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("1507bd51-1cdc-428e-895d-81cf68092483"), "C.20.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("dc064378-6aa8-448f-ba7d-61e444eeba83"), "C.20.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("dbde8c1a-6117-4241-9e9a-b6f9acfd654a"), "C.20.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("eabc14aa-20af-4a67-86d6-30043d88d7d7"), "C.17.24", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wallpaper" },
                    { new Guid("5ed0be78-396e-48ee-8ca5-3c7e6af12296"), "C.23.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of refractory products" },
                    { new Guid("31cf9f47-7815-4066-a14f-2aee42a2537e"), "C.11.0", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of beverages" },
                    { new Guid("bec91eb7-cc2f-4606-8ed2-00d12e2441ac"), "C.10.92", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of prepared pet foods" },
                    { new Guid("97436821-ce7f-4249-bec3-1a0c87eaf761"), "A.01.6", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("b396c3c9-7ea5-490b-b64f-92152c34af77"), "A.01.61", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Support activities for crop production" },
                    { new Guid("ad49df75-5b4f-4f81-803e-f75125d895fd"), "A.01.62", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Support activities for animal production" },
                    { new Guid("2e845881-d5b1-41a4-834d-e8e4e02a09e3"), "A.01.63", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Post-harvest crop activities" },
                    { new Guid("ad5e7a79-7ea1-4764-b8d4-af138cb1194c"), "A.01.64", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Seed processing for propagation" },
                    { new Guid("cbed6dc2-cf2b-4e53-ae27-299073c21880"), "A.01.7", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Hunting, trapping and related service activities" },
                    { new Guid("2386074e-8eda-4316-a5e9-abecaf776440"), "A.01.70", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Hunting, trapping and related service activities" },
                    { new Guid("5a59fecf-baef-49e3-93ad-e4138b94d4bd"), "A.02", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Forestry and logging" },
                    { new Guid("b4f69d23-7914-409b-8875-da129e6841f3"), "A.02.1", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Silviculture and other forestry activities" },
                    { new Guid("d5e11d2e-a51b-477a-9750-ae3b35154802"), "A.02.10", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Silviculture and other forestry activities" },
                    { new Guid("5d477adb-cd91-4abb-8455-8884aba5bdb8"), "A.02.2", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Logging" },
                    { new Guid("694ddad3-df37-40f8-9373-f54573aabc97"), "A.02.20", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Logging" },
                    { new Guid("ad693712-0364-482c-967d-553c86294e59"), "A.01.50", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Mixed farming" },
                    { new Guid("26e7124c-4a0b-44fb-9f2e-6de687f231fd"), "A.02.3", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Gathering of wild growing non-wood products" },
                    { new Guid("b6ede69a-4acf-4783-9b07-0ec1312a58e9"), "A.02.4", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Support services to forestry" },
                    { new Guid("1f16b0a8-2443-40f2-a43c-4b42f6c64329"), "A.02.40", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Support services to forestry" },
                    { new Guid("6f504ffb-b5f6-4dda-897f-d8f4ff170b4c"), "A.03", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Fishing and aquaculture" },
                    { new Guid("f37e5545-138c-4629-b68d-d43a77b1e16a"), "A.03.1", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Fishing" },
                    { new Guid("2be8dc0c-3fb6-4527-8ff8-6ec0f27dc84f"), "A.03.11", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bc7b410d-1efb-4d41-856d-32cbc5660455"), "A.03.12", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Freshwater fishing" },
                    { new Guid("fe3c29af-948a-407b-9d98-61a34164b020"), "A.03.2", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Aquaculture" },
                    { new Guid("9e208f41-5fc1-4f1a-b838-6b034bd758f4"), "A.03.21", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Marine aquaculture" },
                    { new Guid("87fe0fcd-7ee6-46b1-9a4d-ec45f6eaa7e3"), "A.03.22", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Freshwater aquaculture" },
                    { new Guid("9c41b221-d94f-4d9e-89e5-64b03cecd21c"), "B.05", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of coal and lignite" },
                    { new Guid("15296d5c-b672-4f91-82c8-0f3c68f8bc54"), "B.05.1", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of hard coal" },
                    { new Guid("3d565c46-96ca-40f1-ac42-107b118eaa03"), "B.05.10", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of hard coal" },
                    { new Guid("7dd66152-396e-4e14-8a0c-d5dc585fbf1b"), "A.02.30", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Gathering of wild growing non-wood products" },
                    { new Guid("867fe9a8-6414-4c25-b67b-00420fc2f024"), "A.01.5", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Mixed farming" },
                    { new Guid("804cbd7d-de41-46fd-a33e-7aa0f427183e"), "A.01.49", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of other animals" },
                    { new Guid("4a2ee746-e887-4653-b0dc-d175b4c94982"), "A.01.47", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of poultry" },
                    { new Guid("07c5c968-db5d-4ede-8be1-8d976db7c726"), "A.01.1", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of non-perennial crops" },
                    { new Guid("83b9658e-9167-46c0-9e6b-ee9a7e521ef4"), "A.01.11", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("f1f85954-d234-409f-b7d3-5b8bcb4ebd3a"), "A.01.12", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of rice" },
                    { new Guid("3f29787b-42ac-4f28-92dd-00d79521345e"), "A.01.13", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("1fcdb08a-7c0f-47f3-9c89-bcf004e7f37b"), "A.01.14", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of sugar cane" },
                    { new Guid("cbd2ea31-3b4f-415c-8e78-1d9d71d99688"), "A.01.15", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of tobacco" },
                    { new Guid("f8aee933-22d6-4b60-828d-7da04533fd82"), "A.01.16", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of fibre crops" },
                    { new Guid("a2f8b3fe-417e-4789-b15a-1161fa329791"), "A.01.19", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of other non-perennial crops" },
                    { new Guid("04793c0f-5534-4971-802c-d627cd1446d6"), "A.01.2", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of perennial crops" },
                    { new Guid("e34ecda7-2e42-428e-8a1a-beff36f13fa1"), "A.01.21", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of grapes" },
                    { new Guid("47cd47e4-809d-4798-82f4-1cf21c0546db"), "A.01.22", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of tropical and subtropical fruits" },
                    { new Guid("74f0a43a-1f26-4a8f-bd21-fad8ab1ebfa5"), "A.01.23", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of citrus fruits" },
                    { new Guid("0086e14d-7a24-4152-a735-55d7cc6cc59c"), "A.01.24", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of pome fruits and stone fruits" },
                    { new Guid("5dc17225-9e19-4a1f-b723-61847ede4f00"), "A.01.25", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("fe112324-6e03-4b19-a571-ebcfeb3b7bc3"), "A.01.26", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of oleaginous fruits" },
                    { new Guid("b8f8691c-c8f9-4cc8-97e3-9520a3b7d9cc"), "A.01.27", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of beverage crops" },
                    { new Guid("25ff3ff6-4f73-4457-b57f-a793bfe33f85"), "A.01.28", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("ca487c85-912f-4f83-9d02-80f768b8d8f8"), "A.01.29", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Growing of other perennial crops" },
                    { new Guid("4111b155-24f1-4705-93de-e720b7cdaa47"), "A.01.3", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Plant propagation" },
                    { new Guid("fc09a805-08bd-4f56-aa38-291869c0fd6b"), "A.01.30", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Plant propagation" },
                    { new Guid("ab28b258-4e0c-4758-b241-7e998c5028d4"), "A.01.4", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Animal production" },
                    { new Guid("02d8ce4f-d3f2-4e17-ab59-240eb60ff1b6"), "A.01.41", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of dairy cattle" },
                    { new Guid("f7b82287-3040-46a1-b582-f784f5e0a78d"), "A.01.42", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of other cattle and buffaloes" },
                    { new Guid("6ddfe9d9-64d1-4e12-aeeb-b98ea04bf438"), "A.01.43", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of horses and other equines" },
                    { new Guid("b1b87a92-971e-4edf-9dc2-7f299a477b79"), "A.01.44", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of camels and camelids" },
                    { new Guid("9e00e114-57db-4e49-8bb6-00a740a6ca4e"), "A.01.45", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of sheep and goats" },
                    { new Guid("d833aa82-c400-4d91-9c53-f1fca42de464"), "A.01.46", new Guid("a3cf818e-33bf-428f-8093-90bec17d97d7"), "Raising of swine/pigs" },
                    { new Guid("2fa54f56-534b-4516-b722-b18b346a22be"), "B.05.2", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of lignite" },
                    { new Guid("1f2eeedd-485a-4c57-872d-6a9e09d56f2a"), "C.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of beverages" },
                    { new Guid("5e06ff69-efc3-4599-ac59-3980a4d113e5"), "B.05.20", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of lignite" },
                    { new Guid("db4eed7b-3be7-437a-a102-bf64ba445562"), "B.06.1", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("95ea7717-54c0-4694-a494-e938a1402a78"), "C.10.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of potatoes" },
                    { new Guid("aa98efd1-28b0-4d52-aa54-3002c0c643dd"), "C.10.32", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("662f04e5-5b3d-4fcd-8652-2d2e34c2d980"), "C.10.39", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("fb85c7af-218f-41ae-8e6e-62d5b7f572a0"), "C.10.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("c4acee63-35b9-49eb-b7cf-f9d901bece9e"), "C.10.41", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of oils and fats" },
                    { new Guid("bd8840c2-4083-4ea2-beab-6cc8d9ca73c1"), "C.10.42", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("2be81f22-b759-4a46-a9c8-6348343cac5c"), "C.10.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of dairy products" },
                    { new Guid("3dd9cad2-afb6-4a4d-a7e6-8e47b1a21b2c"), "C.10.51", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Operation of dairies and cheese making" },
                    { new Guid("e3df0509-5b53-4f16-a827-0cf374af1488"), "C.10.52", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ice cream" },
                    { new Guid("ff932857-12de-4b66-879d-710a773ace4c"), "C.10.6", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("a3e19d0d-3ef7-4010-abf2-4e5ecbe9072c"), "C.10.61", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of grain mill products" },
                    { new Guid("14f0e662-8332-47ad-ba1f-883bcd311876"), "C.10.62", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of starches and starch products" },
                    { new Guid("4f4b23c1-664d-44f6-98fe-db97fd9d92bd"), "C.10.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("d88cafaa-06c1-4a89-aa3e-bb6fefbc4767"), "C.10.7", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("7fb9884b-1abd-421f-8a9d-b1414af10850"), "C.10.72", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("19a786b1-b90e-4d6e-b357-23c17d67c2c2"), "C.10.73", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("714c3ce6-2b7e-4814-9148-84d31b9356ba"), "C.10.8", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other food products" },
                    { new Guid("a46233f6-c304-40e0-8682-401a954b0843"), "C.10.81", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of sugar" },
                    { new Guid("1c18c7a6-f22d-4dfd-a97b-7fc4aa813c78"), "C.10.82", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("24ae0680-9b51-49e9-9b21-56b8e0f5c337"), "C.10.83", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing of tea and coffee" },
                    { new Guid("e2693c8c-683a-4d03-bf05-e3ae30f565a9"), "C.10.84", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of condiments and seasonings" },
                    { new Guid("ac4d7a46-ede6-4cd8-84b1-6d97a73ac957"), "C.10.85", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of prepared meals and dishes" },
                    { new Guid("7a60e016-71aa-49b0-9740-7a496ea0a8e3"), "C.10.86", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("3b5a9678-1e5e-4d35-a28e-3ccf333715e9"), "C.10.89", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other food products n.e.c." },
                    { new Guid("71d01999-3e7c-460f-ada5-70bc86827b54"), "C.10.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of prepared animal feeds" },
                    { new Guid("d82b4ada-3c43-4b47-bfe5-3fb181c8bffd"), "C.10.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("a9065359-d4e4-4c95-9217-72bd7cd44800"), "C.10.71", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("00bbe403-fac3-456e-bd87-b8b74e7845bb"), "C.10.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("8d6b7aec-a3b2-49f7-8414-039cb7cc0708"), "C.10.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("8d16331a-1fa5-4e5c-a3c6-542c78ae6e5a"), "C.10.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Production of meat and poultry meat products" },
                    { new Guid("1d36b321-2541-4bd2-ab83-833443a6beeb"), "B.06.10", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of crude petroleum" },
                    { new Guid("b904f28a-4556-4a49-a6d3-0f825649768a"), "B.06.2", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of natural gas" },
                    { new Guid("5672730c-3d05-4458-b7a2-c1111d211f69"), "B.06.20", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of natural gas" },
                    { new Guid("70f5914f-caee-4606-b146-ebe6b450a63b"), "B.07", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of metal ores" },
                    { new Guid("9b32ca6f-4695-44fe-8d11-2059ec73e92e"), "B.07.1", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of iron ores" },
                    { new Guid("4523b60f-ffd9-4cf9-8064-c6ab3ef4c401"), "B.07.10", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of iron ores" },
                    { new Guid("2c054b9b-54b6-4ede-a671-02d1fc637d88"), "B.07.2", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of non-ferrous metal ores" },
                    { new Guid("038ac0d6-2469-4191-90c8-4e9520d405f3"), "B.07.21", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of uranium and thorium ores" },
                    { new Guid("a5292c21-6918-4bf6-bab8-fbb30225cbe4"), "B.07.29", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of other non-ferrous metal ores" },
                    { new Guid("d02950f4-486b-48e4-ab36-1e8cb9922405"), "B.08", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Other mining and quarrying" },
                    { new Guid("c0f654eb-37dd-4cca-b1cf-defac4fb1d9c"), "B.08.1", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Quarrying of stone, sand and clay" },
                    { new Guid("8ee6259b-0d87-46bb-b680-8718430b98d1"), "B.08.11", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c9a20e36-63d0-432b-9691-e323ba792e14"), "B.08.12", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("d38f0cd1-8902-4471-92e7-7214bb3fa225"), "B.08.9", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining and quarrying n.e.c." },
                    { new Guid("bbddd5a2-a350-40a3-8efd-d0d4d43ea564"), "B.08.91", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("4b7cd4eb-74e0-44a0-838a-a40dab64a72d"), "B.08.92", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of peat" },
                    { new Guid("c4a22797-8555-46e3-8bc5-410029e5f434"), "B.08.93", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of salt" },
                    { new Guid("4d34ac89-8e80-45f6-8e1a-fb02a0d5397e"), "B.08.99", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Other mining and quarrying n.e.c." },
                    { new Guid("d914bcd0-ef33-4b8b-9c7a-fb2818b4a9de"), "B.09", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Mining support service activities" },
                    { new Guid("468f4d34-2e60-400f-9347-31b1f48a7d46"), "B.09.1", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("48c4b7cb-ded6-4497-865e-84200cbf6416"), "B.09.10", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("9ee53081-5ff1-407e-95b4-bc09ea00dd91"), "B.09.9", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Support activities for other mining and quarrying" },
                    { new Guid("305d13c6-da9e-47ca-b584-7c470866f77e"), "B.09.90", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Support activities for other mining and quarrying" },
                    { new Guid("2beac2aa-3b2e-46ad-abfe-851193e94e91"), "C.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of food products" },
                    { new Guid("96830af0-a227-4c4b-a588-d9abaae9e7ca"), "C.10.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("d741bfed-ad6c-400b-a8a0-6facf08757eb"), "C.10.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of meat" },
                    { new Guid("fd055512-c3c9-43de-a6ea-b71fd8a08c49"), "C.10.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing and preserving of poultry meat" },
                    { new Guid("80722854-8e08-484c-96fa-e5bc627014d8"), "B.06", new Guid("517857d3-d449-4f39-9d8b-9b96085d13d5"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("1c555c9b-30ea-44dc-855f-f2f08650b906"), "F.43.2", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("5beb8d11-3fd8-407a-9854-6ec5d82c2728"), "C.23.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of refractory products" },
                    { new Guid("f8b02486-dc87-4b40-a89e-dfd676119185"), "C.23.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("e0ca6977-0920-4aea-944c-0b3d741d6afd"), "C.30.92", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("fa84a0d0-e48f-4d30-ac28-a95bb4c094e6"), "C.30.99", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("1659adeb-d6a4-4862-95f7-fc4ce21cb7d3"), "C.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of furniture" },
                    { new Guid("75ae5f3e-224c-4bbd-b19d-ec5afbf6fd58"), "C.31.0", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of furniture" },
                    { new Guid("0726e865-66ff-4f00-a36e-3473b624af97"), "C.31.01", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of office and shop furniture" },
                    { new Guid("74dd622b-de68-428f-b93c-5fd1c6b58ffa"), "C.31.02", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of kitchen furniture" },
                    { new Guid("a3a2c5ed-037c-446b-9935-46dcd9eed519"), "C.31.03", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of mattresses" },
                    { new Guid("69e7458e-7709-42ec-9398-7f407fa6c7a2"), "C.31.09", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other furniture" },
                    { new Guid("3975f7fd-3c76-4e69-ad3f-2874bb5fab6f"), "C.32", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Other manufacturing" },
                    { new Guid("043fcd26-a499-4884-9295-cafdca618671"), "C.32.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("1dee2cd2-31d1-459d-b171-1f4543e6557c"), "C.32.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Striking of coins" },
                    { new Guid("e9886b30-9350-48be-aa97-d1af1aca4890"), "C.32.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of jewellery and related articles" },
                    { new Guid("73f8fdf3-1eef-40a1-9bd8-df1f7bf95e53"), "C.30.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of motorcycles" },
                    { new Guid("055bec2f-c0a7-4e8e-8543-f3d3735b661d"), "C.32.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("1fac9eb6-370a-4fe5-b5cf-b5e6c9f95d4e"), "C.32.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of musical instruments" },
                    { new Guid("3c3a81ff-863e-44e3-8cd9-72bdb792c3a0"), "C.32.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of sports goods" },
                    { new Guid("813824dd-9dd7-43e7-9eab-653b8ca70214"), "C.32.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of sports goods" },
                    { new Guid("c1c802ce-129b-4ccb-beed-92eb8bf70b1f"), "C.32.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of games and toys" },
                    { new Guid("e6b93803-970c-48ec-87dc-4190d1190ab9"), "C.32.40", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of games and toys" },
                    { new Guid("610395fd-f628-4250-8733-b3d2011f717e"), "C.32.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("fd9c5d15-f2e4-487b-895e-bc98f111f30c"), "C.32.50", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("b5f3b484-22d2-4f11-9fe6-8171e49f1990"), "C.32.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacturing n.e.c." },
                    { new Guid("d4b77185-9b7f-497d-8d5d-99930900ab47"), "C.32.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("97b9cc34-d131-476d-9d2d-cc6205fc07ed"), "C.32.99", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Other manufacturing n.e.c." },
                    { new Guid("07205fc9-c874-46e2-a30c-23f85b17c13b"), "C.33", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair and installation of machinery and equipment" },
                    { new Guid("09a90c37-8cc8-474d-afe7-6cf4a4724edc"), "C.33.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("4407e163-8163-44a7-bc81-fdf6f346b2de"), "C.32.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of musical instruments" },
                    { new Guid("fa3a06d4-6a21-4914-8cc1-481be0f012fe"), "C.30.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("53bb3067-a9d1-421c-b6e0-66a4cd637236"), "C.30.40", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of military fighting vehicles" },
                    { new Guid("aa193d18-f033-43be-be15-ec9efc2314dc"), "C.30.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of military fighting vehicles" },
                    { new Guid("9d2d6ef4-a74a-4cf8-9725-5287a454fc6e"), "C.28.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("9686457b-6585-44a0-9a89-d630734e5ba3"), "C.28.41", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of metal forming machinery" },
                    { new Guid("71a396e4-ce62-4cba-b3e1-9b1937457a73"), "C.28.49", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other machine tools" },
                    { new Guid("313c420f-0ec6-42eb-8406-bfedd7dc0a5d"), "C.28.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other special-purpose machinery" },
                    { new Guid("95f8a3aa-44a2-45de-8926-8c3b1d11ac15"), "C.28.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of machinery for metallurgy" },
                    { new Guid("0ad47a2d-f48a-4e4f-b223-fc4f59267394"), "C.28.92", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("422db6a5-c50a-4f8e-9ea6-315fd04e6aa3"), "C.28.93", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("dc8be761-7ee5-4c8b-a4c9-bc01d47424a9"), "C.28.94", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("88e7ecd1-4b01-4c6b-ab94-7143c7eb740a"), "C.28.95", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("b7254106-0559-4af1-b392-e7fcf902c043"), "C.28.96", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("ccd588a9-071e-477c-9eb0-c50f104bdae2"), "C.28.99", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("28cf04cf-8bdb-49cb-8c85-03ba553085f2"), "C.29", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("74b966cb-1e6e-4fa4-a987-3fa7ac031fc7"), "C.29.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of motor vehicles" },
                    { new Guid("1f0ba77a-cbf1-4e7d-b1fc-5c427a96b70c"), "C.29.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of motor vehicles" },
                    { new Guid("2dd96a82-49bc-4e49-9c8c-980abf850254"), "C.29.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("e2f5cd2a-dcb4-4dd8-b1ee-119532bd1426"), "C.29.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("828b87c8-48f2-4cf0-972b-f5c6f537a627"), "C.29.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("87e40595-3847-40f5-8307-4b324b3ca7da"), "C.29.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("5da84560-2407-4ae7-bdde-21687b8f9a06"), "C.29.32", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("d006da99-75de-4de3-b93c-22612ef9e6ba"), "C.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other transport equipment" },
                    { new Guid("01eb7b90-aeb3-4333-8423-0dcc66384068"), "C.30.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Building of ships and boats" },
                    { new Guid("78c63f66-5954-4bb8-8635-0056c0300caa"), "C.30.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Building of ships and floating structures" },
                    { new Guid("948adbcb-8611-4604-a943-ea1a63b22616"), "C.30.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Building of pleasure and sporting boats" },
                    { new Guid("208f2708-121c-486b-9fe9-d8fa8522b442"), "C.30.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("25d9127c-1337-4f5c-ae37-1a9f88b97aaf"), "C.30.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("a0d0b3b8-3e08-4134-bb48-ffaff7147f23"), "C.30.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("de75a702-60d6-49c7-8a1d-7fa09c49523d"), "C.30.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("6b2fad53-a044-443e-8fa6-0bb98823db5f"), "C.33.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair of fabricated metal products" },
                    { new Guid("5cf9db48-c443-49d1-98e9-fdf3c4a83613"), "C.28.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("60ac245c-f82f-4329-8419-ec063f58dadd"), "C.33.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair of machinery" },
                    { new Guid("067a4b10-1f73-4bf4-9dee-48aba7714155"), "C.33.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair of electrical equipment" },
                    { new Guid("7048271e-5dd7-46ab-9b77-9e812f7f1db3"), "E.38.3", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Materials recovery" },
                    { new Guid("c3da766b-2b09-4010-bb57-a2dd064ab0b5"), "E.38.31", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Dismantling of wrecks" },
                    { new Guid("420d49fe-cbb3-4659-8a26-abfa90f5fe17"), "E.38.32", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Recovery of sorted materials" },
                    { new Guid("61a8098a-75e2-466c-a25b-7191212fbfc5"), "E.39", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("205389cd-6954-4409-9c34-256ba4fbd8c8"), "E.39.0", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Remediation activities and other waste management services" },
                    { new Guid("3014cace-a253-4c34-a0c3-0a1638433876"), "E.39.00", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Remediation activities and other waste management services" },
                    { new Guid("80be8796-2e82-4366-9c92-146bbc7ccc98"), "F.41", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of buildings" },
                    { new Guid("31b8da9d-af8e-4e74-b795-0b2db53afa51"), "F.41.1", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Development of building projects" },
                    { new Guid("0948767e-37e5-4ab4-9b7d-a7db9127b1de"), "F.41.10", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Development of building projects" },
                    { new Guid("7cc497c0-9844-4ed6-bdc6-976d867eefcc"), "F.41.2", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of residential and non-residential buildings" },
                    { new Guid("91bcc862-b136-4f59-9c0b-cee68864fa76"), "F.41.20", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of residential and non-residential buildings" },
                    { new Guid("51a374ff-db1b-4d87-aece-3fc840d30975"), "F.42", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Civil engineering" },
                    { new Guid("655bdc5d-9974-40ab-b70f-cdb8cc5e848c"), "E.38.22", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Treatment and disposal of hazardous waste" },
                    { new Guid("3a163249-ea23-48ad-8612-5cea0d127e06"), "F.42.1", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of roads and railways" },
                    { new Guid("734350dd-ab8c-4212-89a0-8067561fe228"), "F.42.12", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of railways and underground railways" },
                    { new Guid("9404f7b0-fb15-4b3f-95fb-9c41ada39ffd"), "F.42.13", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of bridges and tunnels" },
                    { new Guid("b468b569-3a11-4a95-932b-e6025d49da21"), "F.42.2", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of utility projects" },
                    { new Guid("648ed63e-ea90-4486-8b48-cfb6b24d5b1b"), "F.42.21", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of utility projects for fluids" },
                    { new Guid("ee731f8f-ad0c-41b8-8da2-630c784c20c2"), "F.42.22", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("825966ed-568a-4912-9615-c68af957297f"), "F.42.9", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of other civil engineering projects" },
                    { new Guid("f5c53aa2-42ee-4564-b4c3-15b0d4fe8df2"), "F.42.91", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of water projects" },
                    { new Guid("898e948c-0b99-45c0-b6b3-cefca11c0540"), "F.42.99", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("353718c5-8987-4ded-8131-8ad7f38ee6db"), "F.43", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Specialised construction activities" },
                    { new Guid("97772002-f5bc-4c52-92c1-60d547b6ff4e"), "F.43.1", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Demolition and site preparation" },
                    { new Guid("6b40c035-c3c3-4da0-b343-2be0d8708f99"), "F.43.11", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Demolition" },
                    { new Guid("ce4fda77-06e7-40f0-a7e5-cd05d7a50b9a"), "F.43.12", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Site preparation" },
                    { new Guid("00c2deae-ae59-40f2-83f0-02fb5a271b47"), "F.42.11", new Guid("42c0c5ab-4173-45cc-84db-0a323030d9ed"), "Construction of roads and motorways" },
                    { new Guid("c6615efe-60c8-46ec-896c-ddc8414b570d"), "E.38.21", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("5423e146-99ed-4820-8cc3-af5bb1ad57f5"), "E.38.2", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Waste treatment and disposal" },
                    { new Guid("2e62412f-f9a5-468a-a679-71885493fd9c"), "E.38.12", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Collection of hazardous waste" },
                    { new Guid("554d59c0-383b-4edf-b682-f6e422424da8"), "C.33.15", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair and maintenance of ships and boats" },
                    { new Guid("8c84159c-e3c2-4b85-b986-8f71f0c44ae0"), "C.33.16", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("285ef6ad-d210-4838-b23a-2d0c0dbea1f9"), "C.33.17", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair and maintenance of other transport equipment" },
                    { new Guid("f931b6bc-abce-48ee-8aec-918a998d3181"), "C.33.19", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair of other equipment" },
                    { new Guid("7c6afb03-ea17-45e4-acfb-8955e35023be"), "C.33.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Installation of industrial machinery and equipment" },
                    { new Guid("cf1e3d9a-571e-48c1-a7ed-121fa280d52d"), "C.33.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Installation of industrial machinery and equipment" },
                    { new Guid("e5da7f84-63a9-4d56-a1da-7fbe98b79066"), "D.35", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("6e31de38-225d-41a8-aba6-1a81b0b6ce38"), "D.35.1", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Electric power generation, transmission and distribution" },
                    { new Guid("883c00e7-169e-4c8f-8be0-85ab9eee226a"), "D.35.11", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Production of electricity" },
                    { new Guid("9d6c25e3-f0de-4dd9-9a97-4485ff6edb0a"), "D.35.12", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Transmission of electricity" },
                    { new Guid("3aa931b9-81af-418c-867c-16e0a5c8927b"), "D.35.13", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Distribution of electricity" },
                    { new Guid("8edaf22e-fa32-4f45-8680-6b3a66b7692b"), "D.35.14", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Trade of electricity" },
                    { new Guid("e28df405-58bf-4fbb-8a9b-d4cc96e06b2d"), "D.35.2", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("f33e24fa-a0a8-477b-bf41-de7364296197"), "D.35.21", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Manufacture of gas" },
                    { new Guid("4172187f-c0a8-4179-9c0c-47bb0a354c8d"), "D.35.22", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Distribution of gaseous fuels through mains" },
                    { new Guid("15b0d088-19c5-4781-a89b-cc9c27275c56"), "D.35.23", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("80f3ce1a-8fda-4715-a142-8d7c1275ff00"), "D.35.3", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Steam and air conditioning supply" },
                    { new Guid("f290e44d-05e1-42a8-b6d9-a3c5163a6e5c"), "D.35.30", new Guid("abac8698-9687-4533-831c-edd96128e214"), "Steam and air conditioning supply" },
                    { new Guid("13a8f741-030f-4fd9-955d-d32363ad640c"), "E.36", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Water collection, treatment and supply" },
                    { new Guid("30e106bf-6715-42c5-8194-0cfbbdfbe9cf"), "E.36.0", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Water collection, treatment and supply" },
                    { new Guid("b3be5288-50f4-4701-b8f5-83e271111931"), "E.36.00", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Water collection, treatment and supply" },
                    { new Guid("4d42f66b-f832-4b0a-bd77-1f0ffd1ce582"), "E.37", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Sewerage" },
                    { new Guid("f35325cf-97e4-49bd-868d-85a42435cc02"), "E.37.0", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Sewerage" },
                    { new Guid("b4fe9a52-d471-467e-8dc1-f444ef77746c"), "E.37.00", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Sewerage" },
                    { new Guid("c676523a-724b-4e42-a0a7-10e3128e9efc"), "E.38", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("b8baa8a2-a3ff-4c70-a891-6abd510fc235"), "E.38.1", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Waste collection" },
                    { new Guid("350462b1-b652-40c8-851d-124da8dc54cf"), "E.38.11", new Guid("5c697a60-371c-4388-a55d-02d2931089b8"), "Collection of non-hazardous waste" },
                    { new Guid("ccced238-44c4-44e0-ab87-b0fb1427c01f"), "C.33.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Repair of electronic and optical equipment" },
                    { new Guid("21f45924-9ad5-43fe-a300-a88bf2b4a0b7"), "C.23.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of clay building materials" },
                    { new Guid("0a136d8b-49a1-4001-b2b2-17bcfa4fec77"), "C.28.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("6ecf840e-fdaa-4b18-be63-57f31f488cd6"), "C.28.25", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("f1879a8e-cd4e-459c-a459-b034eb0d442f"), "C.24.34", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Cold drawing of wire" },
                    { new Guid("cfdf5263-2345-4813-b7cc-acd723c5c73f"), "C.24.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("c39a0635-1d62-4e26-9257-50803de9eb3c"), "C.24.41", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Precious metals production" },
                    { new Guid("e72fef51-b019-46cf-a7b3-bcfe1a9cdfcb"), "C.24.42", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Aluminium production" },
                    { new Guid("86684006-a4ee-4173-a421-87ea308b1e97"), "C.24.43", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Lead, zinc and tin production" },
                    { new Guid("566b28bc-5607-4bca-ad16-336e70cade21"), "C.24.44", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Copper production" },
                    { new Guid("8ada5f6f-37d2-46c4-85ca-40658f4361f3"), "C.24.45", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Other non-ferrous metal production" },
                    { new Guid("da8ea3c0-c607-4a08-a114-aa8d067fd09a"), "C.24.46", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Processing of nuclear fuel" },
                    { new Guid("0b22494d-c537-43de-bcc7-d5fdd0f1ef58"), "C.24.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Casting of metals" },
                    { new Guid("ddc1b808-4c0e-429e-b0b3-5e1b799a2780"), "C.24.51", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Casting of iron" },
                    { new Guid("045a9eaa-8901-4c34-8cb0-8ebb7d640224"), "C.24.52", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Casting of steel" },
                    { new Guid("6ab21a55-ef52-49a9-8dde-a71f8f196232"), "C.24.53", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Casting of light metals" },
                    { new Guid("d37b7ae5-5c36-44f8-a1c3-be3c91e8ee37"), "C.24.33", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Cold forming or folding" },
                    { new Guid("582893aa-353d-4237-8c15-1d201902c1a9"), "C.24.54", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Casting of other non-ferrous metals" },
                    { new Guid("3aa93cad-df0a-484c-94f2-49963f2b5dba"), "C.25.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of structural metal products" },
                    { new Guid("56bf9bfe-2de6-4de7-9ab0-dc51abcc8bd5"), "C.25.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("13eda525-f268-413e-852f-c845908d1aaa"), "C.25.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of doors and windows of metal" },
                    { new Guid("6f7ae108-2d0e-4a0b-b90f-17f0a42868b4"), "C.25.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("530e2cb6-bd88-4cbd-b959-4d4be1b54d2e"), "C.25.21", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("f0964ea7-3545-48c6-976c-34b7763f34ad"), "C.25.29", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("92456e79-c687-498f-9685-fbba38bb6fec"), "C.25.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("9675e9a7-c3db-4f99-81bc-3be33ce6a1e8"), "C.25.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("4f666329-8ec3-4914-9c2c-ed477b9c9701"), "C.25.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of weapons and ammunition" },
                    { new Guid("ed52fff7-05f6-48d4-9d3f-aaca8e88dd4f"), "C.25.40", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of weapons and ammunition" },
                    { new Guid("a1b29d61-98f1-4ae8-9633-a6df6580521b"), "C.25.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("a092beee-0137-4be8-ae8e-259447804c05"), "C.25.50", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("4924679f-3502-4e5b-9af6-ddad707aa4c1"), "C.25", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e778d405-c6b2-4433-832c-6a2499d4a183"), "C.24.32", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Cold rolling of narrow strip" },
                    { new Guid("249ed5b2-7951-4d13-9836-1fcf78563112"), "C.24.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Cold drawing of bars" },
                    { new Guid("7f6f05cb-1fdb-473c-b64b-ff060701b0b3"), "C.24.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other products of first processing of steel" },
                    { new Guid("2f91a602-352e-4ca0-a74c-5d248706cdba"), "C.23.32", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("8ff2f933-5f77-49e0-ad21-826ca87cb992"), "C.23.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("c9d794e4-6201-4184-989f-f6a038e09286"), "C.23.41", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("69ea2e5e-3d73-40d6-a801-37ba73374cf1"), "C.23.42", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("b95a56ac-f52d-4d4e-96ef-ba29cbbd6d0c"), "C.23.43", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("778c57c0-2454-463d-af58-8e926203deb1"), "C.23.44", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other technical ceramic products" },
                    { new Guid("572d2496-281d-427b-a8f1-441a67ded74a"), "C.23.49", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other ceramic products" },
                    { new Guid("4565f7c5-0c09-42ee-89dc-0255ee825f01"), "C.23.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cement, lime and plaster" },
                    { new Guid("e9c20081-acde-43b3-a53e-65585b89bcd2"), "C.23.51", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cement" },
                    { new Guid("a8d4f6b7-3e6a-4d0e-bdbf-d19a63bb9c20"), "C.23.52", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of lime and plaster" },
                    { new Guid("2312c9ee-753c-42d6-b0e3-3a64093fcb42"), "C.23.6", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("cd0ef262-7925-4d8d-bc90-7999885d3443"), "C.23.61", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("2f80a8b3-5ddd-4dcc-9e26-4b171cd36f6d"), "C.23.62", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("824e8455-1843-47d0-9a91-4410dda61d80"), "C.23.63", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ready-mixed concrete" },
                    { new Guid("1585610c-2e08-451a-9fae-036fb5fd3be4"), "C.23.64", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of mortars" },
                    { new Guid("91594f27-3451-4b2d-bbcb-889e1691e762"), "C.23.65", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fibre cement" },
                    { new Guid("3f869bab-246b-4fdd-b014-fd06c658d7df"), "C.23.69", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("2a3c0f6e-cfee-4870-bad1-41a15ce1a33e"), "C.23.7", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Cutting, shaping and finishing of stone" },
                    { new Guid("1fdacef2-eefe-4b6d-be86-525d4fdead94"), "C.23.70", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Cutting, shaping and finishing of stone" },
                    { new Guid("09042021-3f22-4543-af2c-3c16b1aa09c4"), "C.23.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("f74f7404-9c1c-4f95-bfdf-2c77af01f7ff"), "C.23.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Production of abrasive products" },
                    { new Guid("ec24aea3-8ad9-4d58-907d-266459617c37"), "C.23.99", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("ddc29f65-fc68-453d-b3f2-bff45d46093d"), "C.24", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic metals" },
                    { new Guid("e7d41f55-198f-4186-87c4-1b81132fa300"), "C.24.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("a066c1b5-8f6c-48ec-ab40-2ec74ff57d80"), "C.24.10", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("a30a5c2e-1e3f-45a2-9429-33c2bd86ad5c"), "C.24.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("572791e6-755f-4009-926f-a16fa318284e"), "C.24.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("53858e42-b567-4001-88e4-2aa4025004c8"), "C.25.6", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Treatment and coating of metals; machining" },
                    { new Guid("86f1db38-f849-452d-a6f8-d85db773714c"), "C.28.29", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("e07301d4-2bea-47bb-bbc7-ad2b01864357"), "C.25.61", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Treatment and coating of metals" },
                    { new Guid("c87da803-cb2d-4fe5-bf77-16a663d213f8"), "C.25.7", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("2cd00444-da2b-42b2-b511-22896a531162"), "C.27.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("9b78bea9-818a-4a35-8aaa-ab8b422a0bad"), "C.27.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of batteries and accumulators" },
                    { new Guid("944f3749-98c2-4c3c-bc86-916d188a8d8a"), "C.27.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of batteries and accumulators" },
                    { new Guid("239cb3b0-a047-46d2-b2c0-8e46bf052949"), "C.27.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wiring and wiring devices" },
                    { new Guid("ab2f30d1-c6c8-452f-b9f3-94ba722dd654"), "C.27.31", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fibre optic cables" },
                    { new Guid("bf51d4d9-59c2-473e-ad53-aeaef782f27c"), "C.27.32", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("357b551a-c33e-4eac-866b-8ef453f5d694"), "C.27.33", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wiring devices" },
                    { new Guid("1ffb2583-116e-4f2a-a787-a6efeb38bd30"), "C.27.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6141a011-f640-4421-9c72-af567bf664dc"), "C.27.40", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electric lighting equipment" },
                    { new Guid("690b8ebe-79f3-4390-bc03-710177d2d61e"), "C.27.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of domestic appliances" },
                    { new Guid("48b4e12d-e5a8-4687-9bcd-a692da3e66ac"), "C.27.51", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electric domestic appliances" },
                    { new Guid("1c815058-0d22-47a8-9ed1-faff7fa55499"), "C.27.52", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("b7c12c81-3d26-4c78-8ff8-e76952616415"), "C.27.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("30ac58b9-a277-454f-bd9e-8b42eff8fb7d"), "C.27.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other electrical equipment" },
                    { new Guid("eba8f9fa-0be4-484a-ac8c-c59199cb6c4e"), "C.28", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("5edbe36a-1ef8-4c9e-8644-7c812e8c6c49"), "C.28.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of general-purpose machinery" },
                    { new Guid("bd59adf1-ec06-4d36-95bd-5eaa9f2d7662"), "C.28.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("ed3a709c-2cb4-4a52-965f-cedae58da4e4"), "C.28.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fluid power equipment" },
                    { new Guid("957e20dd-f9dd-4eb7-ac26-7ba50e5513ea"), "C.28.13", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other pumps and compressors" },
                    { new Guid("8ef25c38-e229-41f1-b96d-b53c1d9b313c"), "C.28.14", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other taps and valves" },
                    { new Guid("ad2f405e-0198-4749-b89f-5241685e9edf"), "C.28.15", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("ee99077e-c228-4d4d-adce-84a29934bb75"), "C.28.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other general-purpose machinery" },
                    { new Guid("990ab231-2d5e-4ff7-ad51-37a9d36dd6d2"), "C.28.21", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("8d4dcad4-b659-43bd-95c0-e758a06ae764"), "C.28.22", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of lifting and handling equipment" },
                    { new Guid("8737ecff-50e3-4947-93b3-0ecff733921e"), "C.28.23", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("6b19683a-8875-4dbb-a845-d0d7f75c58c9"), "C.28.24", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of power-driven hand tools" },
                    { new Guid("fb553446-d8bc-4a99-894f-f5168e5f9163"), "C.27.90", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other electrical equipment" },
                    { new Guid("f3ac37ef-3332-4c9a-a5ef-063fd13035c9"), "C.27.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("2490d455-9035-4737-8199-c79f545785bb"), "C.27", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electrical equipment" },
                    { new Guid("9f82c7ea-2dfc-4326-81c4-9830d36d327c"), "C.26.80", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of magnetic and optical media" },
                    { new Guid("5b1ce330-983d-4211-9878-6cc4e6593b2c"), "C.25.71", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of cutlery" },
                    { new Guid("d06753d0-1e71-4b6e-bf42-65496df339e7"), "C.25.72", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of locks and hinges" },
                    { new Guid("34d72f01-284d-48ed-a8d4-6c8bd42fc494"), "C.25.73", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of tools" },
                    { new Guid("7ddd79eb-2705-4653-a3aa-bc4a67588ee0"), "C.25.9", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other fabricated metal products" },
                    { new Guid("9cf96641-ece4-4b16-bb97-9469ea42798f"), "C.25.91", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of steel drums and similar containers" },
                    { new Guid("f6de9ad1-d101-4b14-b5ae-5ab0dbdc1b8d"), "C.25.92", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of light metal packaging" },
                    { new Guid("65ab1fc5-abce-4b6e-a275-eb9a48301ee7"), "C.25.93", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of wire products, chain and springs" },
                    { new Guid("507d354f-8069-472d-b4af-ea25ca0111a9"), "C.25.94", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("f85e5ae2-4606-497f-85d0-e0f8286a5420"), "C.25.99", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("2b59936e-4e48-4350-9789-525403fc3324"), "C.26", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("1d283a79-a9bb-43e3-8e2d-dbb528a91883"), "C.26.1", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electronic components and boards" },
                    { new Guid("cb19aadc-bea8-4104-864a-e15ec20caad5"), "C.26.11", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of electronic components" },
                    { new Guid("81b0a120-2884-4d61-9e93-3a980f64973b"), "C.26.12", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of loaded electronic boards" },
                    { new Guid("1de6062a-f2ed-4b14-ac14-0429395e3e87"), "C.26.2", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("2e571143-c32f-4ba2-904d-ef42e067a1ed"), "C.26.20", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("fcc26597-2f19-472b-ab7d-12352cedf486"), "C.26.3", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of communication equipment" },
                    { new Guid("f9a921ff-aead-4c56-8524-0db02e3ab491"), "C.26.30", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of communication equipment" },
                    { new Guid("c8c54cd4-46e7-47a7-b4f9-f4b52f53c644"), "C.26.4", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of consumer electronics" },
                    { new Guid("f482a6ae-abc3-41b1-9556-c09ce6edcfbe"), "C.26.40", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of consumer electronics" },
                    { new Guid("bbeff00b-352d-47fb-ae95-a842d2a6c7e7"), "C.26.5", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6d865a74-4d5b-4ba7-a848-3757010bc6db"), "C.26.51", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("d7f5653c-4897-4bb1-b998-de7526d31858"), "C.26.52", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of watches and clocks" },
                    { new Guid("55a2dd33-f4e3-44c4-bc29-d2fd21f9114a"), "C.26.6", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("77750661-b762-4691-a97f-0c2a3319c932"), "C.26.60", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("708c777e-14a3-4dd5-bbc3-30002804b231"), "C.26.7", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("c6dafa1f-82ee-42d3-8257-04a92c47d4cd"), "C.26.70", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("65031c98-2326-41ca-804e-6ed55d1c1c57"), "C.26.8", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Manufacture of magnetic and optical media" },
                    { new Guid("b2975a21-1294-4594-9cfa-aa13cd9469e9"), "C.25.62", new Guid("96feda42-e667-4b1e-b477-7a16ca00b0b3"), "Machining" },
                    { new Guid("b047b628-bef2-4d20-85b0-614a3f2d1370"), "U.99.00", new Guid("5d20d174-871b-4a7a-9b75-c4daf279e8a3"), "Activities of extraterritorial organisations and bodies" }
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
