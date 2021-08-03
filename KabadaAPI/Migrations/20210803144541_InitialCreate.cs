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
                    { new Guid("ae4b8dfe-ccba-4ea2-baa9-7dab7b1ae82e"), "AT", "Austria" },
                    { new Guid("0b79067b-c210-434e-b8f1-87c213823f3b"), "LU", "Luxembourg" },
                    { new Guid("88cc71c6-017c-4a51-bca1-35da3a15f7b3"), "MT", "Malta" },
                    { new Guid("d1e350e9-0d91-45e6-9ceb-04b3f770fdf7"), "MK", "North Macedonia" },
                    { new Guid("fe1c5422-0449-4184-a914-8c0d0e82b69f"), "NO", "Norway" },
                    { new Guid("4d2840f9-4624-4137-aefc-c9d6b4da1de5"), "PL", "Poland" },
                    { new Guid("3daac19c-b038-47c4-b257-d77d930a409d"), "PT", "Portugal" },
                    { new Guid("a19d7eb6-3f5b-4e9b-814a-9ca11577f8e5"), "RO", "Romania" },
                    { new Guid("ad256493-5c63-42f4-abc5-87e6e308a916"), "RS", "Serbia" },
                    { new Guid("10125852-255c-4554-8e4d-235ab5448d37"), "SK", "Slovakia" },
                    { new Guid("f8ec33a3-50ec-4186-a184-01cf31896d94"), "SI", "Slovenia" },
                    { new Guid("b33f6af6-c2e6-41ad-b79d-715118241a27"), "ES", "Spain" },
                    { new Guid("1a0c0c64-e1c5-4aa8-bd96-612e8e5a5f2f"), "SE", "Sweden" },
                    { new Guid("63ba4e14-a8a5-4df0-8e04-65eeac8e5c94"), "CH", "Switzerland" },
                    { new Guid("c8e00926-e753-4881-be83-fb075ab2fe44"), "TR", "Turkey" },
                    { new Guid("1ffa04c5-7ed2-4a7e-8552-3e16d3fcc82d"), "UK", "United Kingdom" },
                    { new Guid("dd0c3777-fb7f-4f61-a346-7f0464f2ef24"), "LT", "Lithuania" },
                    { new Guid("1dec92f4-a35a-400c-8947-60de3e2e80ed"), "LI", "Liechtenstein" },
                    { new Guid("3ccf038a-a271-477b-9c62-003610152b37"), "NL", "Netherlands" },
                    { new Guid("100c89f0-cbb3-4579-b84f-2a66a24e9e60"), "IT", "Italy" },
                    { new Guid("775ef8bd-66e9-4070-b169-f560f6d660ea"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("260fc8d2-599e-427f-8e9f-22bc843cbe65"), "BE", "Belgium" },
                    { new Guid("5294af9a-bbbc-40cd-a545-07cfdc6cff22"), "BG", "Bulgaria" },
                    { new Guid("167e80dd-ab2f-4fee-a4c8-7b68f8634d6d"), "LV", "Latvia" },
                    { new Guid("c206a650-a55c-45a4-83eb-d2ffbac43c70"), "CY", "Cyprus" },
                    { new Guid("ab628b34-ff97-433e-ad0d-e000233ad198"), "CZ", "Czechia" },
                    { new Guid("ef8de9c6-96bb-4a1f-b1d1-0b052f0ed908"), "DK", "Denmark" },
                    { new Guid("500eb72d-863e-426d-b1e6-0f4b942fe4cd"), "EE", "Estonia" },
                    { new Guid("f9957b40-6838-4a0d-a40f-103aa3702f95"), "HR", "Croatia" },
                    { new Guid("57984fc8-a7ea-476a-96a2-1f5d907cac5b"), "FR", "France" },
                    { new Guid("8b9e71f3-fdfb-4c25-af18-b493f9c0b12f"), "DE", "Germany" },
                    { new Guid("fdbe6cea-2895-4e5b-91f7-752b76d4a418"), "EL", "Greece" },
                    { new Guid("e1ce5f03-27d0-4773-bb51-52d1e84610fa"), "HU", "Hungary" },
                    { new Guid("737e2916-1693-4125-b8d9-fc7fb7d3ece7"), "IS", "Iceland" },
                    { new Guid("979c417e-1f98-4346-811a-0e2b47a14d2f"), "IE", "Ireland" },
                    { new Guid("002b3642-4743-4705-9635-c97d8372435b"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "P", "EN", "Education" },
                    { new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("9585c938-abe5-4fcb-b51b-dabf10a69694"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "L", "EN", "Real estate activities" },
                    { new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "J", "EN", "Information and communication" },
                    { new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "B", "EN", "Mining and quarrying" },
                    { new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "H", "EN", "Transporting and storage" },
                    { new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "F", "EN", "Construction" },
                    { new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "C", "EN", "Manufacturing" },
                    { new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("91dc6739-e965-45cf-92a8-aca0fe75a5f7"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("fb031109-129d-4cbf-8fc1-5aee8717edf9"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("a3cbcf41-654f-4f50-9b26-7f43efaaed57"), (short)23, null, new Guid("fb031109-129d-4cbf-8fc1-5aee8717edf9"), (short)1, "Manufacturing building" },
                    { new Guid("097ee34f-a623-49a0-9c6e-a1953239054d"), (short)23, null, new Guid("b330fc83-0253-4cc1-9715-6ebbdeff9b58"), (short)4, "Marketing" },
                    { new Guid("673a34ee-26b0-4098-8796-b1e87e28941b"), (short)23, null, new Guid("fb031109-129d-4cbf-8fc1-5aee8717edf9"), (short)3, "Equipment" },
                    { new Guid("49e83a32-2ba7-446b-a61e-3d6dd0cdfceb"), (short)23, null, new Guid("a027ecf6-081b-4763-9db8-0a034ac87e5e"), (short)1, "Other" },
                    { new Guid("47eb0274-d8eb-4d86-af06-278b3fbf4337"), (short)23, null, new Guid("fb031109-129d-4cbf-8fc1-5aee8717edf9"), (short)2, "Office" },
                    { new Guid("a027ecf6-081b-4763-9db8-0a034ac87e5e"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("71c6e503-90fb-4827-8e75-f84d782fe0e8"), (short)23, null, new Guid("231a817c-b6e1-43c6-96b5-0eeaa28ee307"), (short)1, "Other" },
                    { new Guid("1496717f-4b97-4825-a43b-63073f9ccbd3"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("8476fabf-e25d-49c2-ab6a-f351f1a4d7d7"), (short)23, null, new Guid("34f9fd49-3f17-4f49-a507-e8c6c3afa7c9"), (short)1, "Other" },
                    { new Guid("34f9fd49-3f17-4f49-a507-e8c6c3afa7c9"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("614b08ca-b1c9-41ee-b1a6-a556f57c4176"), (short)23, null, new Guid("fb031109-129d-4cbf-8fc1-5aee8717edf9"), (short)4, "Other" },
                    { new Guid("231a817c-b6e1-43c6-96b5-0eeaa28ee307"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("75ea1183-650c-4a4c-9786-80ee35b92d3e"), (short)23, null, new Guid("b330fc83-0253-4cc1-9715-6ebbdeff9b58"), (short)5, "Other" },
                    { new Guid("368bae93-bddc-437d-be37-97562c6a0e7c"), (short)23, null, new Guid("1496717f-4b97-4825-a43b-63073f9ccbd3"), (short)1, "Other" },
                    { new Guid("c758d55f-ef6c-4c7d-95ab-6837f2e82983"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("23100fd4-7957-40dc-a290-c8052a3b38f5"), (short)23, null, new Guid("5d85b3e8-bcac-44e0-b601-a469ff32a8fc"), (short)1, "Other" },
                    { new Guid("fa9e7583-684d-4c41-8501-b13269b7da5d"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("36f24207-8136-4e31-ac30-2be0c4815d22"), (short)23, null, new Guid("fa9e7583-684d-4c41-8501-b13269b7da5d"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("ffe24b43-d34d-4cf1-a3c2-b94c970df6d3"), (short)23, null, new Guid("fa9e7583-684d-4c41-8501-b13269b7da5d"), (short)2, "Other" },
                    { new Guid("5d85b3e8-bcac-44e0-b601-a469ff32a8fc"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("5e43873e-9fb1-43d1-ba7b-04a75722ff14"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("8f6ab506-d4aa-492b-816c-4a0cc7039902"), (short)23, null, new Guid("5e43873e-9fb1-43d1-ba7b-04a75722ff14"), (short)1, "Other" },
                    { new Guid("b9e959a5-6da1-46e9-95a9-dc00e9631510"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("53a76d7b-ea28-48bf-be86-3e7a8389c348"), (short)23, null, new Guid("b9e959a5-6da1-46e9-95a9-dc00e9631510"), (short)1, "Other" },
                    { new Guid("851ad891-8257-4e11-b597-c26dde8b6407"), (short)22, null, null, (short)8, "Distribution" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("3cd86e0f-35fd-4c09-87a0-033ca4edf91b"), (short)23, null, new Guid("851ad891-8257-4e11-b597-c26dde8b6407"), (short)1, "Transport" },
                    { new Guid("a2415f51-083b-404d-8633-22c8c17ea5e1"), (short)23, null, new Guid("851ad891-8257-4e11-b597-c26dde8b6407"), (short)2, "Cost of warehouse" },
                    { new Guid("499ab3a1-9db0-4f5c-9fab-3a549aa1461e"), (short)23, null, new Guid("851ad891-8257-4e11-b597-c26dde8b6407"), (short)3, "Fees to distributors" },
                    { new Guid("abd4f9f4-a375-4579-80d7-95440609efd6"), (short)23, null, new Guid("851ad891-8257-4e11-b597-c26dde8b6407"), (short)4, "Other" },
                    { new Guid("5a56af7e-a3f4-4024-81a0-768ca81bebfd"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("91509c12-40fc-43fb-8212-b4d88d49b6d1"), (short)23, null, new Guid("c758d55f-ef6c-4c7d-95ab-6837f2e82983"), (short)1, "Other" },
                    { new Guid("6f8a6b79-8f74-48aa-8a29-e490b19e1d8b"), (short)23, null, new Guid("b330fc83-0253-4cc1-9715-6ebbdeff9b58"), (short)3, "Finance management" },
                    { new Guid("a8088ea1-c16e-4145-8608-9817d77b8f33"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("70506c58-1089-4f56-9805-83843b0f0af0"), (short)23, null, new Guid("b330fc83-0253-4cc1-9715-6ebbdeff9b58"), (short)1, "Management" },
                    { new Guid("5c827ec5-fb77-4d93-b376-fab75735652b"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("a2f1dd8e-ac0c-43bb-ad2c-8867f293a161"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("86dafad5-0422-4a3d-ada1-9e14ef561e5f"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("682b69f9-cd33-4ea1-96fb-f0ceaa857389"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("e2128901-b30c-4275-bbcd-80244d1abea1"), (short)23, null, new Guid("5a56af7e-a3f4-4024-81a0-768ca81bebfd"), (short)1, "Other" },
                    { new Guid("19876677-5dfe-42b8-a3a9-adf113f2daee"), (short)23, null, new Guid("a8088ea1-c16e-4145-8608-9817d77b8f33"), (short)1, "Other" },
                    { new Guid("c35effce-9905-4d22-9109-1efd5a31c3c6"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("bc0abcb9-16f6-48d0-ba9f-486f044c1d0c"), (short)23, null, new Guid("c35effce-9905-4d22-9109-1efd5a31c3c6"), (short)1, "Manufacturing buildings" },
                    { new Guid("115ffead-5489-4bcd-97ab-d79043f52ce4"), (short)23, null, new Guid("c35effce-9905-4d22-9109-1efd5a31c3c6"), (short)2, "Inventory buildings" },
                    { new Guid("4a72e575-0cc6-4f3d-93ef-643ea8711cf2"), (short)23, null, new Guid("c35effce-9905-4d22-9109-1efd5a31c3c6"), (short)3, "Sales buildings (shops)" },
                    { new Guid("64ed587e-2bf6-465f-9221-8165e95f6a1a"), (short)23, null, new Guid("c35effce-9905-4d22-9109-1efd5a31c3c6"), (short)4, "Other" },
                    { new Guid("ef3f1712-2da6-4ca9-b445-ad99cb68a7ad"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("96a515c0-d092-438d-9a32-1aaea4536ac6"), (short)23, null, new Guid("ef3f1712-2da6-4ca9-b445-ad99cb68a7ad"), (short)1, "IT (office) equipment" },
                    { new Guid("523a8564-5fe3-4e6f-bb19-d1b7723d2b23"), (short)23, null, new Guid("ef3f1712-2da6-4ca9-b445-ad99cb68a7ad"), (short)2, "Production equipment and machinery" },
                    { new Guid("a213ec65-f2c4-45ed-9fb7-a919d656b0e2"), (short)23, null, new Guid("ef3f1712-2da6-4ca9-b445-ad99cb68a7ad"), (short)3, "Transport" },
                    { new Guid("b326c0f7-7ae8-423e-b007-315500aad7cb"), (short)23, null, new Guid("ef3f1712-2da6-4ca9-b445-ad99cb68a7ad"), (short)4, "Other" },
                    { new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("b330fc83-0253-4cc1-9715-6ebbdeff9b58"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("f27eb4ec-406b-430d-94a1-ef113d1fe472"), (short)23, null, new Guid("a6b8d811-f021-4e7b-af70-b9bacce258a7"), (short)1, "Other" },
                    { new Guid("a6b8d811-f021-4e7b-af70-b9bacce258a7"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("85c08db6-93a4-425f-b62d-b82272ddbae8"), (short)23, null, new Guid("b6a603b0-17be-450d-a833-82fa26c83ec3"), (short)3, "Other" },
                    { new Guid("8a415d2b-2bce-4c71-8d95-445c55ab43f6"), (short)23, null, new Guid("b6a603b0-17be-450d-a833-82fa26c83ec3"), (short)2, "IT support" },
                    { new Guid("40212957-4276-4e7c-8bfe-33291257f086"), (short)23, null, new Guid("b6a603b0-17be-450d-a833-82fa26c83ec3"), (short)1, "Accountant" },
                    { new Guid("12d993c5-38a1-4358-8ddd-18d6e4e3996b"), (short)23, null, new Guid("b330fc83-0253-4cc1-9715-6ebbdeff9b58"), (short)2, "Factory workers / service" },
                    { new Guid("b6a603b0-17be-450d-a833-82fa26c83ec3"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("59725141-0bef-4018-a45e-c8371202416d"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)6, "Communication" },
                    { new Guid("4abe5ccc-be42-40fb-ad16-12db8dec3100"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)5, "Maintenance" },
                    { new Guid("31049cab-ecbf-4403-8b37-c654c880549b"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)4, "Heat" },
                    { new Guid("797972f1-8e9f-41c8-bb42-91f71abb7da3"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)3, "Gas" },
                    { new Guid("9728d9e1-7ca2-4939-929c-2ddf7332eaa6"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)2, "Water" },
                    { new Guid("c7f4f478-4491-426e-8c74-a5af28cdf771"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)1, "Electricity" },
                    { new Guid("4b421312-7c8b-4806-806c-b90c8f36c419"), (short)23, null, new Guid("b14e5307-5e0d-44d4-af6f-13d17c87a73b"), (short)7, "Other" },
                    { new Guid("b429e343-add0-46b6-b1c7-3e090357fdc1"), (short)24, null, null, (short)1, "Asset sale" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e0cadfcc-103e-475c-bd5b-73cbc8b740f0"), (short)31, null, new Guid("4f0af6bd-ae84-42e5-a718-16567ad6b78e"), (short)3, "To the email" },
                    { new Guid("9239ea31-2ba7-4a50-a131-9320fd35de2a"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("696a0099-4609-4048-b4cc-ce30f0ba038f"), (short)32, null, null, (short)2, "12 - 17" },
                    { new Guid("9f8febd2-a26c-4d9b-8320-ea5fe8bef152"), (short)32, null, null, (short)3, "18 - 24" },
                    { new Guid("47c92585-5b66-4647-8ccc-cefc9d1bbaf4"), (short)32, null, null, (short)4, "25 - 34" },
                    { new Guid("142093ab-23e3-4b3d-8e55-97d1f31c6444"), (short)32, null, null, (short)5, "35 - 64" },
                    { new Guid("2b1122f7-c62f-47cf-a7c1-b4c27096b806"), (short)32, null, null, (short)6, "65 - 74" },
                    { new Guid("9f56b44b-191a-4628-84f2-7484aa9c48b3"), (short)32, null, null, (short)7, "75 years or older" },
                    { new Guid("e0e21336-f189-484b-8e97-0b5ea62376cd"), (short)32, null, null, (short)8, "All age groups" },
                    { new Guid("a8ae9f3a-6432-4270-a92d-006a4672978e"), (short)33, null, null, (short)1, "Low" },
                    { new Guid("6cbf3b1c-a115-4f64-b42d-066e3554fb0a"), (short)33, null, null, (short)2, "Medium" },
                    { new Guid("5a5e3cac-3ad3-4a57-9f1d-c5cd2a2e19a2"), (short)33, null, null, (short)3, "High" },
                    { new Guid("5269e6b1-d583-47af-9741-c4babf601983"), (short)34, null, null, (short)1, "Primary" },
                    { new Guid("e626d18b-854d-4753-a7a7-5b446bdb7808"), (short)34, null, null, (short)2, "Secondary" },
                    { new Guid("dfd3a533-9fa6-4af8-83fc-7db1fe238d50"), (short)34, null, null, (short)3, "Higher education" },
                    { new Guid("34315e22-005e-4a4d-9d4b-8cebf37ef222"), (short)35, null, null, (short)1, "Domestic" },
                    { new Guid("32be8593-0440-42da-a10a-ccebdcf726b2"), (short)35, null, null, (short)2, "Domestic Urban" },
                    { new Guid("b30cbbab-9976-451e-acae-4ac6a31624ea"), (short)35, null, null, (short)3, "Domestic Rural" },
                    { new Guid("22d12c47-d732-4d93-afb7-ff437fc49c8a"), (short)35, null, null, (short)4, "Foreign" },
                    { new Guid("6aef5a2d-b675-41dc-b3fb-7e4635e7455c"), (short)39, null, null, (short)2, "female" },
                    { new Guid("60b39e69-06d2-4be5-b88a-ee331ab74f8b"), (short)39, null, null, (short)1, "male" },
                    { new Guid("85aa90de-8c79-4b73-832d-28bb2b55045e"), (short)38, null, null, (short)4, "Non-Government organisations" },
                    { new Guid("2f18448d-60d8-4908-9c8e-679e0621037d"), (short)38, null, null, (short)3, "Muncipality" },
                    { new Guid("cc6a6dc6-61b0-4e67-bdba-ae14ed556f0d"), (short)38, null, null, (short)2, "National Government" },
                    { new Guid("8892a280-94ca-4c71-bb51-2338d162730b"), (short)38, null, null, (short)1, "International Organisations" },
                    { new Guid("bf1948e8-ce7c-42a2-9060-d531b2770494"), (short)32, null, null, (short)1, "Under 12" },
                    { new Guid("92687ca9-6e93-4137-a2ed-7f02be2e01f6"), (short)37, null, null, (short)2, "Services" },
                    { new Guid("c2c68127-0aff-4c3d-9893-580899347020"), (short)36, null, null, (short)3, "Large" },
                    { new Guid("dd5ff26f-741f-4741-bc4d-a9123ed69b3f"), (short)36, null, null, (short)2, "Medium" },
                    { new Guid("cfebbd23-a3d5-494f-a197-f9f6800176fc"), (short)36, null, null, (short)1, "Small" },
                    { new Guid("26343755-4732-46c9-9f62-a91faea26cdc"), (short)35, null, null, (short)7, "Transnational" },
                    { new Guid("b30d2d87-976e-4644-8043-e6afa9086ec5"), (short)35, null, null, (short)6, "Foreign Rural" },
                    { new Guid("4868e058-02a7-42c7-a757-cc1f48569dce"), (short)35, null, null, (short)5, "Foreign Urban" },
                    { new Guid("5ff24518-299a-4b0b-8cc4-196aadd06318"), (short)37, null, null, (short)1, "Goods" },
                    { new Guid("648607f6-d6f8-4de4-9a3d-54868c00d4e0"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("4b4b5f79-3f5f-4031-ad05-78b5eb7c79fb"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("01c29f5a-b913-40a0-af96-6fcc27ad3e4d"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("529eb58f-3e93-4102-b274-8cc4ec738bfd"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("3b2180ce-d4c8-4d86-8972-8eb0a7ca637f"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("dad34a03-cfe8-4dbe-8f5f-1571ee68b6e7"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("54da932a-38aa-4b2b-bb2e-8ccd0fc4a2fe"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("18d398b6-58b8-4fb2-b1e7-70a6dcfd7715"), (short)25, null, null, (short)1, "Fixed pricing" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("4d8adc6a-1a2c-47b6-83d0-d17588031ce5"), (short)26, null, new Guid("18d398b6-58b8-4fb2-b1e7-70a6dcfd7715"), (short)1, "List price" },
                    { new Guid("2062786b-ffc6-483b-a09c-2e3849028570"), (short)26, null, new Guid("18d398b6-58b8-4fb2-b1e7-70a6dcfd7715"), (short)2, "Product feature dependent" },
                    { new Guid("8567d709-7cfc-4ab1-91a8-86242196289f"), (short)26, null, new Guid("18d398b6-58b8-4fb2-b1e7-70a6dcfd7715"), (short)3, "Volume dependent" },
                    { new Guid("e22c3f5a-c723-4e4c-b4c1-62e677e2b533"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("b3ea07e9-0995-4dcd-8d6b-45ed62091d0e"), (short)26, null, new Guid("e22c3f5a-c723-4e4c-b4c1-62e677e2b533"), (short)1, "Negotiation" },
                    { new Guid("4f1e2545-88b3-44c8-8ba0-2144c7ac93a5"), (short)26, null, new Guid("e22c3f5a-c723-4e4c-b4c1-62e677e2b533"), (short)2, "Yield management" },
                    { new Guid("b5320039-9f8c-4dd7-8279-987d37331925"), (short)26, null, new Guid("e22c3f5a-c723-4e4c-b4c1-62e677e2b533"), (short)3, "Real time market" },
                    { new Guid("9a15ca8c-d067-44ee-971e-4c9d3239709a"), (short)26, null, new Guid("e22c3f5a-c723-4e4c-b4c1-62e677e2b533"), (short)4, "Auctions" },
                    { new Guid("bbe29a6d-d4db-40b7-b709-d314c3ff2b45"), (short)27, null, null, (short)1, "Direct sales" },
                    { new Guid("2baaff47-c108-421f-9410-4fd775ee40da"), (short)28, null, new Guid("bbe29a6d-d4db-40b7-b709-d314c3ff2b45"), (short)1, "Own shop" },
                    { new Guid("21d6ba34-4855-49e2-a33d-dba253ba674c"), (short)29, null, new Guid("2baaff47-c108-421f-9410-4fd775ee40da"), (short)1, "Physical" },
                    { new Guid("a6599ecf-c630-40ad-8b0b-06c7c70275ef"), (short)30, null, new Guid("21d6ba34-4855-49e2-a33d-dba253ba674c"), (short)1, "Fixed location" },
                    { new Guid("b7eabe98-1117-4481-a4c6-d3334fafa062"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("a12f8007-08bc-4280-a6e0-dc25e08fe7a6"), (short)28, null, new Guid("bbe29a6d-d4db-40b7-b709-d314c3ff2b45"), (short)4, "" },
                    { new Guid("42ae5bdd-d2dd-4840-9934-780b89ebda5c"), (short)28, null, new Guid("bbe29a6d-d4db-40b7-b709-d314c3ff2b45"), (short)3, "Direct visit" },
                    { new Guid("6bc92c20-8ef0-4436-9982-3b2249cb5931"), (short)28, null, new Guid("bbe29a6d-d4db-40b7-b709-d314c3ff2b45"), (short)2, "Market/Fairs" },
                    { new Guid("d9e89d52-19c6-4cc7-bad2-774b44b35693"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("f67f863a-54cb-4dfb-9132-f2d8b09414cf"), (short)31, null, new Guid("4f0af6bd-ae84-42e5-a718-16567ad6b78e"), (short)2, "Courier service" },
                    { new Guid("aca4a087-8302-455e-8177-f0c53d1e2148"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("8f537408-d387-44bd-baa3-bba7e2ac328d"), (short)31, null, new Guid("4f0af6bd-ae84-42e5-a718-16567ad6b78e"), (short)1, "Own delivery" },
                    { new Guid("d8ae3f73-fc9f-4622-b7ed-31d6c24ca43d"), (short)30, null, new Guid("4f0af6bd-ae84-42e5-a718-16567ad6b78e"), (short)1, "Own website" },
                    { new Guid("4f0af6bd-ae84-42e5-a718-16567ad6b78e"), (short)29, null, new Guid("2baaff47-c108-421f-9410-4fd775ee40da"), (short)2, "Online" },
                    { new Guid("1c260d3e-3b15-4b51-89f7-64ddf18d3d74"), (short)31, null, new Guid("21d6ba34-4855-49e2-a33d-dba253ba674c"), (short)3, "Courier service" },
                    { new Guid("0e7a8d6f-2c43-4142-9c82-ee8995fcd411"), (short)31, null, new Guid("21d6ba34-4855-49e2-a33d-dba253ba674c"), (short)2, "Delivery to home" },
                    { new Guid("1c89ca00-6b37-4fb7-8413-fa0c64eaba73"), (short)31, null, new Guid("21d6ba34-4855-49e2-a33d-dba253ba674c"), (short)1, "Self pickup" },
                    { new Guid("c034a482-9a40-4ea9-a916-1a573a8f412f"), (short)30, null, new Guid("21d6ba34-4855-49e2-a33d-dba253ba674c"), (short)2, "Mobile" },
                    { new Guid("e254e651-2d8b-4787-aed6-df2b7577d01b"), (short)30, null, new Guid("4f0af6bd-ae84-42e5-a718-16567ad6b78e"), (short)2, "Platform" },
                    { new Guid("d59efa48-f69c-4771-9d0c-ed506713df7c"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("7f251466-ad03-4fc7-b36c-57963516ba0b"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("e1587a62-8520-40b5-9bc4-794a3a4d94fd"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("93638471-a856-4f81-b736-238dc4a64831"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("75eafef0-b606-4e83-9f4f-fe8384592d7c"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("ab1227c6-b6da-4a0d-ba51-fcf59b6eb968"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("7c63c94d-61a5-4c2a-8b13-3269137e759c"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("ef733462-62bf-4c39-8a93-c133617b5bbd"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("c92b63f6-f176-434a-b727-00c425e69207"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("4fe7bd6e-f670-4524-9b85-aad50aa1e39f"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("799f4d7e-b6c2-4818-891f-71cc68f2789d"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("ae8b693d-b327-4ec1-8589-25c75718e3b8"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("83b21a20-ef19-4f62-886b-263589842a07"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("58ffcc4c-a957-4015-805a-c962bb3f9f52"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("6cdaa7d0-c140-4181-9b73-e1ede9c90a4f"), (short)3, null, null, (short)24, "Potential/future competition" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("5131d8ee-42c0-4fc1-b3ea-c2a8b61396b6"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("a30ef19d-c289-4d95-81a2-a32816610bd4"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("279d6bfa-3506-4263-9784-9dc2adae900b"), (short)6, null, new Guid("a30ef19d-c289-4d95-81a2-a32816610bd4"), (short)1, "Buildings" },
                    { new Guid("a39d22cf-eee3-4ad8-b479-a9320a65ce15"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("279d6bfa-3506-4263-9784-9dc2adae900b"), (short)1, "Ownership type" },
                    { new Guid("7ce49e6e-177a-46cb-a8c3-b674e71d911c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("279d6bfa-3506-4263-9784-9dc2adae900b"), (short)2, "Frequency" },
                    { new Guid("02d9ff4e-4d8f-415c-8478-0b0287c8244d"), (short)6, null, new Guid("91b9f07a-9a2e-4b86-b6df-ee80b0c05c4d"), (short)2, "Licenses" },
                    { new Guid("55506af7-2130-4323-8324-fa3fa7fcde43"), (short)6, null, new Guid("91b9f07a-9a2e-4b86-b6df-ee80b0c05c4d"), (short)1, "Brands" },
                    { new Guid("91b9f07a-9a2e-4b86-b6df-ee80b0c05c4d"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("012b0b3d-4f9a-4289-8925-429020338ac1"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("07ae3bd6-d96a-4f58-9518-961a5f317aff"), (short)2, "Frequency" },
                    { new Guid("51061aa9-abce-41b7-a55c-81a1d1a265f1"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("07ae3bd6-d96a-4f58-9518-961a5f317aff"), (short)1, "Ownership type" },
                    { new Guid("07ae3bd6-d96a-4f58-9518-961a5f317aff"), (short)6, null, new Guid("a30ef19d-c289-4d95-81a2-a32816610bd4"), (short)5, "Other" },
                    { new Guid("a4728bbc-dbfc-4288-a32c-b1d7588d4240"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("c40058e4-ef88-4569-9579-72dfb47c0019"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3f078c7e-2c52-437f-9a80-2bff070daa2e"), (short)1, "Ownership type" },
                    { new Guid("14a261db-fb74-4a38-8492-de715a22e0c0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("dd260bf3-cafc-4d25-8ddb-97a01d3997e7"), (short)2, "Frequency" },
                    { new Guid("e54279ba-2b96-4e0e-816c-e230cb90a706"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("dd260bf3-cafc-4d25-8ddb-97a01d3997e7"), (short)1, "Ownership type" },
                    { new Guid("dd260bf3-cafc-4d25-8ddb-97a01d3997e7"), (short)6, null, new Guid("a30ef19d-c289-4d95-81a2-a32816610bd4"), (short)3, "Transport" },
                    { new Guid("f574e65c-1907-4c00-bdc1-cf9304f49824"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f50a2ff2-6a84-4101-b9f4-8c6d6e057a5d"), (short)2, "Frequency" },
                    { new Guid("28f8da7d-3c98-4f7e-a51a-dc1b4adfa269"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("f50a2ff2-6a84-4101-b9f4-8c6d6e057a5d"), (short)1, "Ownership type" },
                    { new Guid("f50a2ff2-6a84-4101-b9f4-8c6d6e057a5d"), (short)6, null, new Guid("a30ef19d-c289-4d95-81a2-a32816610bd4"), (short)2, "Equipment" },
                    { new Guid("3f078c7e-2c52-437f-9a80-2bff070daa2e"), (short)6, null, new Guid("a30ef19d-c289-4d95-81a2-a32816610bd4"), (short)4, "Raw materials" },
                    { new Guid("8e52c2df-e3d3-4f7e-9b21-4a33e9dea55a"), (short)6, null, new Guid("91b9f07a-9a2e-4b86-b6df-ee80b0c05c4d"), (short)3, "Software" },
                    { new Guid("274faab9-34b5-4818-a056-316f5963a67d"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("9453db7f-9998-423b-9099-b2a979c08c14"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("9271c072-42b0-44db-97cf-328b050fccd5"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("6bfcf907-65ae-43a7-90b4-9254be613800"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("f6630928-1759-4263-8963-9e70db2e3e23"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("629cfffa-8f9a-4d01-9d9d-bf17452a52dc"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("47236fff-c5a5-4d1c-b152-813a907b1175"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("6dfeb520-fc9d-43d9-b272-54afcf687431"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("f38877b5-8f43-4895-9ce1-3a9ecfc86dd3"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("d1c4fc1e-10fb-4472-96b0-7903d933d2d4"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("acf296e3-8b0c-4f8a-a149-446f22e294e3"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("a1069833-c36e-40a3-bbac-f4b8a8103c29"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("fdbcb03f-c5e5-4706-abbe-f183631b14ea"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("afeb5fce-c890-4956-bc63-1e114ef660f2"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("e945b674-270e-4ff9-b3f7-423cb1125295"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("70377c23-2626-4247-9d0e-33b7819f3f37"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("00014955-df34-4f01-9331-c51316ed4363"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("f2c727fc-2c55-47f5-b4c8-83d21a736085"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("daebc513-b924-4602-8952-be2d53ba6225"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("0d3f9448-cfe8-4aee-ba97-ac0ef7c7e564"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("5631cc18-3147-4e48-bb30-201a58d9bfc9"), (short)3, null, null, (short)7, "Interest rate" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("30b1e1bb-a2c0-423f-b9b2-6ffae177af6c"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("8aebe5fb-5374-417e-b5c2-6d85e0d4dd52"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("9f77daa3-d5fa-4310-9e32-d58bf1b90472"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("289524a4-571c-4eed-b021-c655e61253e0"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("ce1c7166-8523-4ca5-bdbb-feb9eaa5397a"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("9db22ebe-ba82-4dff-8ac1-8a9bedabe61c"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("7aa4973f-3186-4e2d-be07-b21f1cc4e818"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("899db7eb-35c3-4ecd-96c0-45a204cc976a"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("67aeabd4-4496-4a66-9636-301d3a40da49"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("9fec8e0a-8d9a-4aef-8bd5-c087ea82b34b"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("8525725a-295f-42ff-821e-c7a895ae95c5"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("4465cedc-4c43-422c-82d2-d6fa5ea90fe2"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("dcc37f1f-8d81-4896-a34d-4afbf2fa0410"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("17b0e2b2-7e98-4fc8-a497-ffb4cd00be7c"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("e637b106-f2df-4f9a-848e-bed84124f07d"), (short)6, null, new Guid("91b9f07a-9a2e-4b86-b6df-ee80b0c05c4d"), (short)4, "Other" },
                    { new Guid("07dafa10-6139-472d-8d8b-b93186c167a5"), (short)6, null, new Guid("4382dc38-a049-488a-8184-53c02ec95e71"), (short)1, "Specialists & Know-how" },
                    { new Guid("5e0e2082-f092-4295-9a10-87dcb2fe3b1f"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("0738f36f-53de-447f-ac8c-d862f1cceb4b"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("a1ee6b6c-9690-4ba8-a96e-2c0a1ac047a8"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("6100f630-0429-4755-b3d4-dc676727d267"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("fb52a837-49a6-4f3f-866b-7a0a16198ae5"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("e969bb84-d55a-4bcd-80bf-c3cf1e9f264f"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("642221ad-f06e-4efa-9d90-9396711fd081"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("7ebba6d7-f585-4aba-b12b-3f4bc23b2be7"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("70cb98a4-df33-4cae-929e-61c0a8632325"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("ba247697-2882-4f9f-8f36-3449de4e4df2"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("177467af-2e6a-477f-8629-d2e6355ad02f"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("dcb66f9a-bf5b-458b-8e3b-f8ae72af2d23"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("44ef1049-8760-4d10-a00d-6641d3741a20"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("107ceeba-64bf-4f6e-ad5e-ef8a57488854"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("3d985da4-e8e7-494a-9fa8-e560562af7ea"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("18c0963f-dd2b-4b5a-aaa0-e130e74e7f27"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("8c6a4b28-270f-452a-8768-d8c81d2c89fb"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("a007c276-7d8a-4d25-99fb-df9616bd0e57"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("f97bfdca-382d-4a58-8c58-25c6ea4d0b57"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("579ae9db-5902-43d2-8429-77069d84b7b0"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("c865b124-1eba-4e09-9da1-739e5d9eaf10"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("c5b717ec-c06c-4d7d-bc6d-374330484276"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("7ae87cf5-ccf3-453c-afa4-018eedfb62f5"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("18e1b191-0fca-4aa7-89cb-ca9221bedc0c"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("6ac5749c-b85c-40a9-87a3-f5f586aa3d95"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("e091ad1e-b0bd-4cf5-a5eb-f6ddc6875953"), (short)17, null, null, (short)1, "Free" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7ef61e02-d26c-4ede-a00a-1e869c9fa825"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("08b2ff70-4445-4622-96dd-c24781543a5d"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("ecf501f0-5d33-4f46-8a4b-07ff1a8fc1e1"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("b9b6fdbd-2441-494a-84e6-9efd346e0636"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("5017dbf7-219a-4090-be25-e40fee2a14f0"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("4382dc38-a049-488a-8184-53c02ec95e71"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("93108bb4-ac0a-4a27-ad7c-dc86bb0992ab"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("0326d45d-dd2b-4cf8-9b14-044ad6c5efd4"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("1f96bf81-2c3f-4e46-ab32-a67a68f8f743"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("fd47bcae-670c-416f-81d7-7e28c729638e"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("f667dcc5-c362-45cf-87ac-3095f7a7e879"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("eab90267-fc65-453e-a0a2-9911b57ad594"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0b7c6863-2f20-4869-89e1-cefab18452e1"), (short)2, "Frequency" },
                    { new Guid("b8bab421-fd22-411b-a01a-b092ca66d531"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("0b7c6863-2f20-4869-89e1-cefab18452e1"), (short)1, "Ownership type" },
                    { new Guid("0b7c6863-2f20-4869-89e1-cefab18452e1"), (short)6, null, new Guid("4382dc38-a049-488a-8184-53c02ec95e71"), (short)4, "Other" },
                    { new Guid("853c1a6b-0d07-465d-9628-c6e191ec837b"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("90f5f813-7249-4d33-817c-76a73a242791"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("c7f586e4-dc99-4640-a81f-8c62dd109cb3"), (short)2, "Frequency" },
                    { new Guid("c7f586e4-dc99-4640-a81f-8c62dd109cb3"), (short)6, null, new Guid("4382dc38-a049-488a-8184-53c02ec95e71"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("65122e53-d4fb-403b-bb21-840f660d1fb7"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b63b7604-d116-4ca7-a728-2550e4a7c2a7"), (short)2, "Frequency" },
                    { new Guid("20161930-a6a9-4194-82af-767cfe0b81bf"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("b63b7604-d116-4ca7-a728-2550e4a7c2a7"), (short)1, "Ownership type" },
                    { new Guid("b63b7604-d116-4ca7-a728-2550e4a7c2a7"), (short)6, null, new Guid("4382dc38-a049-488a-8184-53c02ec95e71"), (short)2, "Administrative" },
                    { new Guid("2a054e28-08c7-421c-90b5-fe96e2dd87f2"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("07dafa10-6139-472d-8d8b-b93186c167a5"), (short)2, "Frequency" },
                    { new Guid("f46e221d-edde-44f1-b5cb-471342f2035a"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("07dafa10-6139-472d-8d8b-b93186c167a5"), (short)1, "Ownership type" },
                    { new Guid("a5e71fd9-5162-404a-8042-c418cdc2b9b1"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("c7f586e4-dc99-4640-a81f-8c62dd109cb3"), (short)1, "Ownership type" },
                    { new Guid("967cfee9-21a1-4c35-ac6e-7cd6c2c91fd6"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("e5be23bc-223f-487e-bd2f-f0b378c42c28"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("22c90c88-9136-454c-b396-5dea35fea73a"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("aa7ce9a0-beb5-4170-b750-fff3b4f761b5"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("0f04a801-cdb2-4276-ab03-a542ddea3704"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("2557bfe2-e36c-4a61-b6d4-42fc52d4f122"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("0243fca0-d4cf-4c8c-a026-85264754c41e"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("9c365add-2ec0-4752-a42b-f37bcd763b6e"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("5f88bc02-017d-4a4a-9c91-d94d4d92c6a0"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("89f2c5a7-5c4c-4271-a06c-b01d0cdad667"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("740c33bb-7bc8-42a9-8563-58e11b561004"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("59247316-408a-42e7-8873-69c775a6b1dd"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("b3dd99c6-fd7d-43f9-9558-aa9c429cb69a"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("7b311e55-e1be-4917-9c1f-d1a3dccf1b17"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("c8bb2635-6ae4-4d50-aecf-1e056a91728d"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("8c76a744-6843-4da5-b12c-aa4221f22768"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("de4ae86d-8e7c-4980-93c6-a10b86700698"), (short)13, null, null, (short)1, "Non-governmental institutions" }
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
                    { new Guid("246a48f8-cce7-44a1-9997-ecf265c5ffec"), "A.01", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("802bddfa-8e16-499d-9044-471d4df7969d"), "H.51.22", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Space transport" },
                    { new Guid("9f99fb0a-081a-4b0c-ae98-6be27b518366"), "H.52", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Warehousing and support activities for transportation" },
                    { new Guid("25d5c75b-05a3-4782-991a-c409ea1446cc"), "H.52.1", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Warehousing and storage" },
                    { new Guid("aa71ec73-f36e-4b14-86c6-38e8a33e8157"), "H.52.10", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Warehousing and storage" },
                    { new Guid("411be0e6-fac7-4578-97af-2252d98b5c2a"), "H.52.2", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Support activities for transportation" },
                    { new Guid("69655e48-80ff-4829-aa87-140b1cca7bc0"), "H.52.21", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Service activities incidental to land transportation" },
                    { new Guid("458136b1-b91c-4586-aa80-a654e8b5f837"), "H.52.22", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Service activities incidental to water transportation" },
                    { new Guid("2cf99c63-f2d2-4062-88a9-d0e169a98be6"), "H.52.23", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Service activities incidental to air transportation" },
                    { new Guid("2ce060c0-db00-466e-9025-51afb52e4e25"), "H.52.24", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Cargo handling" },
                    { new Guid("cb9892f9-3877-4180-bcc6-554fa1f625d6"), "H.52.29", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Other transportation support activities" },
                    { new Guid("bc096f98-44ea-4036-a58c-e15b429eb9be"), "H.53", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Postal and courier activities" },
                    { new Guid("afe7e5b5-4300-4f9f-ab25-c85233f780db"), "H.53.1", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Postal activities under universal service obligation" },
                    { new Guid("9ff93f9c-4007-49bb-8742-7b1deebf8539"), "H.51.21", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Freight air transport" },
                    { new Guid("3cc8045f-42ac-45e5-8431-4528a8e8a477"), "H.53.10", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Postal activities under universal service obligation" },
                    { new Guid("b1cbfcc1-021e-42cc-b184-ab6136981592"), "H.53.20", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Other postal and courier activities" },
                    { new Guid("3be0de54-5e12-43a8-b0e2-b0f8e28dd5b0"), "I.55", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Accommodation" },
                    { new Guid("ac2327b6-7e8d-4cd0-ad19-fc24c0d82561"), "I.55.1", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Hotels and similar accommodation" },
                    { new Guid("9f7ae13f-728e-4ee6-bdbd-c2ce9cc08f74"), "I.55.10", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Hotels and similar accommodation" },
                    { new Guid("7c650787-d33e-4a0a-9e93-e583fa883ada"), "I.55.2", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Holiday and other short-stay accommodation" },
                    { new Guid("85a8044a-0f4f-473e-abfc-ca87c1e2ac88"), "I.55.20", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Holiday and other short-stay accommodation" },
                    { new Guid("79a4f8c3-e9f6-4d21-8ece-b669ed4e8e14"), "I.55.3", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("0fbc5006-e861-4a7b-94b1-f857a03ba3fd"), "I.55.30", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("49b07741-381d-4ee8-8539-1fbcb0268f66"), "I.55.9", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Other accommodation" },
                    { new Guid("80c58449-9766-4c4e-aee0-bad09a58088b"), "I.55.90", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Other accommodation" },
                    { new Guid("39f27661-5218-44bc-85a0-4bd1b15be620"), "I.56", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Food and beverage service activities" },
                    { new Guid("906c404a-6cca-4442-ae54-23865e66c27f"), "I.56.1", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Restaurants and mobile food service activities" },
                    { new Guid("5c67ac97-d97e-4232-80e2-130d913f0c50"), "H.53.2", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Other postal and courier activities" },
                    { new Guid("c2660ac4-6d75-46af-baf1-67b41ae9e57c"), "H.51.2", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Freight air transport and space transport" },
                    { new Guid("492ae049-720d-408e-94c2-ed434c3fccfd"), "H.51.10", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Passenger air transport" },
                    { new Guid("a6f464ff-8002-4336-bc70-0cdeb5303fb8"), "H.51.1", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Passenger air transport" },
                    { new Guid("929cefd5-8be7-4dc7-8d01-1903f817cee5"), "G.47.9", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("ee6936a4-22f5-4399-9d7b-49a45b96f2ae"), "G.47.91", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("8874ca9b-8f69-4c4b-aea5-9f16684bd8f7"), "G.47.99", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("0a451f42-51a5-423d-a604-c54e368a5258"), "H.49", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Land transport and transport via pipelines" },
                    { new Guid("194e94e0-f2b6-43fe-acc3-48e41b6d324b"), "H.49.1", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Passenger rail transport, interurban" },
                    { new Guid("49a62cb1-e396-440a-ab34-f8d3f1bc35b4"), "H.49.10", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Passenger rail transport, interurban" },
                    { new Guid("182cef2a-3ee7-480b-bb75-a0095b9e3ad9"), "H.49.2", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Freight rail transport" },
                    { new Guid("edbd6d56-d096-4286-871d-0b36ec096e4c"), "H.49.20", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Freight rail transport" },
                    { new Guid("897d5f02-4137-4362-aad0-0b15b996e3e3"), "H.49.3", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Other passenger land transport" },
                    { new Guid("0f456c21-19a5-4b2e-9fb5-bc347edb8f99"), "H.49.31", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Urban and suburban passenger land transport" },
                    { new Guid("721a6ac3-faf9-4d7f-9bd2-1b2cd56fcff6"), "H.49.32", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("80272e5b-df3c-4b39-880e-d28e01dd4023"), "H.49.39", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Other passenger land transport n.e.c." },
                    { new Guid("31f6f85f-da7f-446d-9e5e-b0281b31b60b"), "H.49.4", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Freight transport by road and removal services" },
                    { new Guid("bdf56ebc-9c60-4db3-ada6-522609ec3b25"), "H.49.41", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Freight transport by road" },
                    { new Guid("ef29a3e9-22bc-42cc-ab03-a42d44d5931d"), "H.49.42", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Removal services" },
                    { new Guid("60cb060e-dcd9-4964-870d-0d6616dd238c"), "H.49.5", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Transport via pipeline" },
                    { new Guid("4d50337f-bce2-4aef-82e5-dddfc4a2c5ce"), "H.49.50", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Transport via pipeline" },
                    { new Guid("8246f26c-8b54-4581-958e-fa158e6ae6cc"), "H.50", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Water transport" },
                    { new Guid("17826590-b865-4c2c-b556-873a386a4ef1"), "H.50.1", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Sea and coastal passenger water transport" },
                    { new Guid("7dc4977a-28ff-4a0b-8138-8056a63ec916"), "H.50.10", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Sea and coastal passenger water transport" },
                    { new Guid("c27b9b60-66c2-474b-9539-ccfd8c71173e"), "H.50.2", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Sea and coastal freight water transport" },
                    { new Guid("2931dde8-fb6a-44b4-914a-cad35945cf7c"), "H.50.20", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Sea and coastal freight water transport" },
                    { new Guid("d372e4dc-f8f5-4947-82c5-7e75775d4d49"), "H.50.3", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Inland passenger water transport" },
                    { new Guid("fe377eb7-77e2-4173-9832-6e269b44e817"), "H.50.30", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Inland passenger water transport" },
                    { new Guid("dd83bef8-e279-4373-aba4-098f511e346d"), "H.50.4", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Inland freight water transport" },
                    { new Guid("4be0c0ca-cd7e-4f98-b225-a56b7014f64f"), "H.50.40", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Inland freight water transport" },
                    { new Guid("4964a8d4-f0c3-44f6-bea8-05bec8cbf42d"), "H.51", new Guid("dd6df2b2-89d2-4272-8e74-2312cf532552"), "Air transport" },
                    { new Guid("17775fc7-70fe-4b98-9bd7-f12198f0305f"), "I.56.10", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Restaurants and mobile food service activities" },
                    { new Guid("cf1d8748-a82f-412b-adce-70d964793c0a"), "G.47.89", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("57e87da5-8b62-4c8c-b717-f3d84903a16d"), "I.56.2", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Event catering and other food service activities" },
                    { new Guid("c072c3ee-ce3d-4fb6-be99-4ec2fdb9e316"), "I.56.29", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Other food service activities" },
                    { new Guid("b533cf0f-0430-4065-a873-c720d7343622"), "J.61.30", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Satellite telecommunications activities" },
                    { new Guid("a192341c-138b-4227-84c9-52c473a6f2d8"), "J.61.9", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other telecommunications activities" },
                    { new Guid("55b60514-2e76-4aab-8b17-42e9a3b9b374"), "J.61.90", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other telecommunications activities" },
                    { new Guid("714d63af-28d5-462a-89c7-6ec924761be0"), "J.62", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Computer programming, consultancy and related activities" },
                    { new Guid("3362928b-74c1-4a54-a825-4da240d3e104"), "J.62.0", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Computer programming, consultancy and related activities" },
                    { new Guid("3aa7f35d-4eef-4a5d-9ea1-b62db62bb038"), "J.62.01", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Computer programming activities" },
                    { new Guid("79f4bc0b-61ca-4dab-8741-cfb76037c107"), "J.62.02", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Computer consultancy activities" },
                    { new Guid("0677b558-276f-4f46-a81d-f32f437e8dbe"), "J.62.03", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Computer facilities management activities" },
                    { new Guid("d82d2f27-b7ae-4470-94c2-41bc0bc7d6bc"), "J.62.09", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other information technology and computer service activities" },
                    { new Guid("3a191ce5-8d66-4383-ab12-bcbe4a04e7ae"), "J.63", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Information service activities" },
                    { new Guid("128d2711-dd59-4ed6-b159-c7c768d0bd79"), "J.63.1", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("d82f9280-c901-4e7b-9dc6-62276fa571b7"), "J.63.11", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Data processing, hosting and related activities" },
                    { new Guid("19f63cdc-22bc-4659-9658-9a90dcd0e7e7"), "J.61.3", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Satellite telecommunications activities" },
                    { new Guid("02a314af-e7ff-4cb1-a24c-045886f8b75b"), "J.63.12", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Web portals" },
                    { new Guid("8846f06a-0dd9-4b6b-a105-2cf3040a39c8"), "J.63.91", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "News agency activities" },
                    { new Guid("42ea85c8-808d-4a05-a505-eccff14eeabd"), "J.63.99", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other information service activities n.e.c." },
                    { new Guid("b8d41faa-d9ea-4763-a367-ce409d7f6b57"), "K.64", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("d3e54405-c26e-459b-a0b8-a60ed59edf42"), "K.64.1", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Monetary intermediation" },
                    { new Guid("73fa7219-05fa-4ae9-b741-2b9d63805953"), "K.64.11", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Central banking" },
                    { new Guid("922b44e9-5f46-4412-9904-35cd24d342c4"), "K.64.19", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Other monetary intermediation" },
                    { new Guid("a43549bb-87ed-4479-8b94-535fa13752a3"), "K.64.2", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Activities of holding companies" },
                    { new Guid("c0fbec24-46d7-4ead-a742-c8a4e27a7f91"), "K.64.20", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4c79144e-a341-432b-aaa7-4e0386db1ff9"), "K.64.3", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Trusts, funds and similar financial entities" },
                    { new Guid("a21138ee-42ee-496a-a8a3-235b61040412"), "K.64.30", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Trusts, funds and similar financial entities" },
                    { new Guid("8db06660-3921-44d7-b44b-91f13c196f30"), "K.64.9", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("65602c77-c11d-46a6-aeb8-f0901241da6d"), "K.64.91", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Financial leasing" },
                    { new Guid("7f5d8d2d-521a-4347-be81-098b9d9f1f21"), "J.63.9", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other information service activities" },
                    { new Guid("0c1e7d7b-fc06-4e43-8ecb-c030ea241009"), "J.61.20", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Wireless telecommunications activities" },
                    { new Guid("73ae1af9-efeb-42d0-aef7-c45ba9e536f0"), "J.61.2", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Wireless telecommunications activities" },
                    { new Guid("05d1743f-7349-4b2e-ac34-06d6adb6ae2e"), "J.61.10", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Wired telecommunications activities" },
                    { new Guid("55b9eba1-b73b-4033-8b6d-a2c3298929b1"), "I.56.3", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Beverage serving activities" },
                    { new Guid("3605d432-5cd9-414d-b932-324405314ea4"), "I.56.30", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Beverage serving activities" },
                    { new Guid("2234409a-82e4-408a-908b-2fd4fdcd2d47"), "J.58", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Publishing activities" },
                    { new Guid("b9b51ff2-76a0-450f-bb19-fcb3bc33dfb0"), "J.58.1", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("1f4041e0-f961-496d-8620-462e83c9b6dc"), "J.58.11", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Book publishing" },
                    { new Guid("a9fa8663-0c55-456e-9a7c-aaa824e509ea"), "J.58.12", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Publishing of directories and mailing lists" },
                    { new Guid("57ad382c-4271-4850-89c1-a17b04807af7"), "J.58.13", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Publishing of newspapers" },
                    { new Guid("74657faf-70e5-43f7-adef-6b441466dc40"), "J.58.14", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Publishing of journals and periodicals" },
                    { new Guid("a5b6e153-22dd-425a-af26-5847f1917df3"), "J.58.19", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other publishing activities" },
                    { new Guid("b1fbc7df-1e24-446e-b960-4d2b1cfde581"), "J.58.2", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Software publishing" },
                    { new Guid("8b7e7ab7-581f-44a1-a602-9f94adf9f0e8"), "J.58.21", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Publishing of computer games" },
                    { new Guid("b5228ec5-113e-4871-a32a-945f8c09a681"), "J.58.29", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Other software publishing" },
                    { new Guid("c6e8fbe5-1a2d-4059-a106-963f2de5dc8d"), "J.59", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("a5e75500-b5e5-48a0-824a-d455e2b760aa"), "J.59.1", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Motion picture, video and television programme activities" },
                    { new Guid("d2b68616-57d9-4516-b4ef-272785580f82"), "J.59.11", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Motion picture, video and television programme production activities" },
                    { new Guid("65b97350-1342-4cb3-9376-9d6828184cb0"), "J.59.12", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("a3c56cb1-e033-457c-ae56-267ff20d9cd3"), "J.59.13", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("9accd089-9a2e-4449-9aec-a0a6c2314800"), "J.59.14", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Motion picture projection activities" },
                    { new Guid("f3a509ad-2e63-472e-863f-1f0027006d00"), "J.59.2", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Sound recording and music publishing activities" },
                    { new Guid("37f8fa8c-8874-4a2c-ac0c-9d175ec30dab"), "J.59.20", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Sound recording and music publishing activities" },
                    { new Guid("25322f59-536c-44cd-94a8-a90cfb73c80b"), "J.60", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Programming and broadcasting activities" },
                    { new Guid("f3264807-f215-4903-975d-ba672a0ca790"), "J.60.1", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Radio broadcasting" },
                    { new Guid("f57af1bd-95ac-4bda-8c6e-f586e0c09c9c"), "J.60.10", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Radio broadcasting" },
                    { new Guid("c6995d40-00a9-47b6-898c-c1ea8b0959a4"), "J.60.2", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Television programming and broadcasting activities" },
                    { new Guid("e1628814-90ab-4f96-981e-85e41ad90ca0"), "J.60.20", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Television programming and broadcasting activities" },
                    { new Guid("0a2113a7-4e08-4ca6-860e-0921669a8b96"), "J.61", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Telecommunications" },
                    { new Guid("8daedabb-322e-4b21-bf22-266596aa570f"), "J.61.1", new Guid("40b8a97f-1fb1-4db8-aa60-d288c0fb4d21"), "Wired telecommunications activities" },
                    { new Guid("3132c4f1-b12b-4990-b2ca-33b2c6926c73"), "I.56.21", new Guid("5e114cc2-4c7b-4fb0-9d53-ecc15806b60b"), "Event catering activities" },
                    { new Guid("7fab9d82-5186-47c2-931b-3bb8ce3892c7"), "K.64.92", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Other credit granting" },
                    { new Guid("eef2c038-ad19-4b40-93c8-986dbe863dad"), "G.47.82", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("58ce980c-d801-4762-9593-9a36146d11dd"), "G.47.8", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale via stalls and markets" },
                    { new Guid("63a1e94f-c030-48c7-9099-970750f1d951"), "G.46.19", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("cf21e12a-2bf7-4a8b-9fef-69a12b634e8e"), "G.46.2", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("2de7db12-64ab-48e4-9cb0-0d4c4b4e3832"), "G.46.21", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fe2e02be-ca76-4d50-ad8b-9916c9143a05"), "G.46.22", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of flowers and plants" },
                    { new Guid("584ca06d-3043-4f9a-b3ac-123eb5ceefdf"), "G.46.23", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of live animals" },
                    { new Guid("d63c15b7-86de-407a-9942-108e1ba62e66"), "G.46.24", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of hides, skins and leather" },
                    { new Guid("87520d22-f0a6-43a6-9889-48d62f04836b"), "G.46.3", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("ec4bb517-3c5c-4dd4-9801-a525ca5edd54"), "G.46.31", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of fruit and vegetables" },
                    { new Guid("c622325b-17eb-448c-845d-dbed8236669b"), "G.46.32", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of meat and meat products" },
                    { new Guid("133de06c-bd2b-4d9c-9f11-b8bf94a8c72d"), "G.46.33", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("21628268-9944-499e-864a-ba6e9081dbf4"), "G.46.34", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of beverages" },
                    { new Guid("97b17efe-c309-414c-a0ef-3ed0aab22e1c"), "G.46.35", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of tobacco products" },
                    { new Guid("391c809a-9412-4a21-b2b4-6b9c5564afa4"), "G.46.18", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents specialised in the sale of other particular products" },
                    { new Guid("9f9ba0ca-f88e-4ee5-bd6d-a5a011cedbe7"), "G.46.36", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("94270096-3a14-4493-8c65-0afd45f023c6"), "G.46.38", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("58093baf-882e-43c0-b3b3-942d780be041"), "G.46.39", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("bfef5021-7d0e-4029-9b23-e2ba4ba153aa"), "G.46.4", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of household goods" },
                    { new Guid("0a771f64-4b7e-45cb-92a3-d52cff3ed68c"), "G.46.41", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of textiles" },
                    { new Guid("6b5ea09f-da5e-403d-b570-e49e8410dfdd"), "G.46.42", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of clothing and footwear" },
                    { new Guid("be4e6e39-d6e7-4cb1-a6ec-5337f7fb28a0"), "G.46.43", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of electrical household appliances" },
                    { new Guid("7c55b6f6-020a-4768-8eb8-ac27b8a03f60"), "G.46.44", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("a18cb5d7-ba01-4d7a-a079-1587d752ffda"), "G.46.45", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of perfume and cosmetics" },
                    { new Guid("7ce27a37-25c0-4b76-8964-0477928cd08c"), "G.46.46", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of pharmaceutical goods" },
                    { new Guid("480eac31-fa01-4e90-b868-5b22e9043989"), "G.46.47", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("7e2377c0-cddc-4ba1-9451-374d2ee161a6"), "G.46.48", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of watches and jewellery" },
                    { new Guid("b025a182-a783-48bc-9369-af00aa1c72c3"), "G.46.49", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of other household goods" },
                    { new Guid("e23a4a51-c81d-4367-a3a5-014f3ddb7e45"), "G.46.37", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("85125c42-beaa-4f98-b3bc-8404161ff14a"), "G.46.17", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("49c287f0-b21b-47e8-b2f4-884546ae920e"), "G.46.16", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("e9375865-a581-4f63-8f19-bc4772f38c54"), "G.46.15", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("bd286882-cb49-476a-9ffd-061a44311efb"), "F.43.29", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Other construction installation" },
                    { new Guid("385543f7-5f47-4e54-a17d-550392df4d32"), "F.43.3", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Building completion and finishing" },
                    { new Guid("90abcf94-8042-46f8-8262-e9d97201b6a0"), "F.43.31", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Plastering" },
                    { new Guid("c424a5cd-f591-4125-8e22-cf876d48eb4d"), "F.43.32", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Joinery installation" },
                    { new Guid("93e3d363-c18f-464c-a14c-8b2fd690dba2"), "F.43.33", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Floor and wall covering" },
                    { new Guid("097df91c-5fad-4043-98e8-2f2bdf768297"), "F.43.34", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Painting and glazing" },
                    { new Guid("8e25f3c2-e2b9-49a2-9e1f-3b822c1819ff"), "F.43.39", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Other building completion and finishing" },
                    { new Guid("045cf319-5e8a-4a10-8a4a-45805530b75f"), "F.43.9", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Other specialised construction activities" },
                    { new Guid("c24fa0e7-34da-4c99-9ca5-93a7b3dd8f7f"), "F.43.91", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Roofing activities" },
                    { new Guid("232fa170-a6a0-4107-8dea-5173ea36aceb"), "F.43.99", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Other specialised construction activities n.e.c." },
                    { new Guid("2dbc2717-5be0-4776-ab83-501e0eb32a1e"), "G.45", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("fb972a7e-915a-4289-88ca-99b65300a456"), "G.45.1", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Sale of motor vehicles" },
                    { new Guid("2dc6ffa6-d361-4cad-a304-5210123237a2"), "G.45.11", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Sale of cars and light motor vehicles" },
                    { new Guid("b251c8e9-ab6f-4bce-a0e4-926d28395e6e"), "G.45.19", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Sale of other motor vehicles" },
                    { new Guid("da575d30-b5e7-4c34-a814-f5d8f4df5dfc"), "G.45.2", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a8276a2d-4df1-46e1-a10c-f5000ee3d203"), "G.45.20", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Maintenance and repair of motor vehicles" },
                    { new Guid("5593b123-e4b4-4620-8d46-84422c01ff0f"), "G.45.3", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("5e8016f3-1913-46d7-b456-e159873c7748"), "G.45.31", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("b17cdeec-c2e3-4737-86ff-4eec08756705"), "G.45.32", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("dd1d1468-6388-4617-9227-593075456a69"), "G.45.4", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("d87c9abc-aa20-4fe7-87ea-0b1ebc8763b4"), "G.45.40", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("b9733f31-9b67-49cc-b286-1f3ea3187d1c"), "G.46", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("d6869a89-3064-40e5-af3d-34d20db4676e"), "G.46.1", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale on a fee or contract basis" },
                    { new Guid("49b001b2-49ff-435e-afa7-3d1e5b8f5593"), "G.46.11", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("05acce7f-35d9-4e5f-8302-b7540b591163"), "G.46.12", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("6be0c13a-ac78-42bf-8435-acec22f09cfd"), "G.46.13", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("b68a7572-d961-41cf-a54c-3303aed8cf0c"), "G.46.14", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("1cfec65f-448b-46bb-984c-2d0c91e49df9"), "G.46.5", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of information and communication equipment" },
                    { new Guid("89f178e5-a1c6-400c-a2c8-3100b6823acc"), "G.47.81", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("bf782b8c-f7f2-46a3-abfa-d347c47f32b0"), "G.46.51", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("49a7aee2-b961-4ab1-b029-6b6f3a1260d4"), "G.46.6", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("b975b6b8-6fa6-47cf-90b9-2ad4c541ff76"), "G.47.4", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("077478e0-c09d-4a24-96e0-8758ec275a94"), "G.47.41", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("62a4051e-b10c-4c01-be79-373cb31d2abf"), "G.47.42", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("e29801bf-8e07-4a53-a6ac-95c811fdf6f4"), "G.47.43", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("78052e31-fb4f-44c3-82c1-f68ad1d03bc4"), "G.47.5", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("a3818a8f-e120-427c-9de7-bca57f611fc9"), "G.47.51", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of textiles in specialised stores" },
                    { new Guid("e794e04e-bb7e-4f68-b842-1bc5c70cbd8c"), "G.47.52", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("47372c03-8de9-4047-9830-2a43ef4a325d"), "G.47.53", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("e658a738-fe80-4fc7-beee-3942f844479c"), "G.47.54", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("ceb3048c-eeba-4874-bcf0-5dce4054a361"), "G.47.59", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("8412991f-8ca1-4883-b5cc-934f9a82cdb0"), "G.47.6", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("cdd6f751-21d1-4e3a-ad7e-a556b00c185e"), "G.47.61", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of books in specialised stores" },
                    { new Guid("8a7bba59-fdcb-4c5f-86d9-b5c925bc0433"), "G.47.30", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("01e805a0-fb1d-48ad-8daa-d86e9f27afb4"), "G.47.62", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("e32bfc92-5639-49f9-9872-db0124a16928"), "G.47.64", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("fb5c7801-f0af-4b1b-972f-3fda519ff242"), "G.47.65", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("b537b0f0-f851-481a-a172-2e51152ef950"), "G.47.7", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of other goods in specialised stores" },
                    { new Guid("a2ab5156-bc6e-4858-890e-63fd667ec07d"), "G.47.71", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of clothing in specialised stores" },
                    { new Guid("09b0dfb6-0b22-4dfd-adb7-6cd1decc706d"), "G.47.72", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("09c77314-d2a5-4adf-8d66-27c232747937"), "G.47.73", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Dispensing chemist in specialised stores" },
                    { new Guid("3833953b-f6b6-4dda-91a4-5838151d425c"), "G.47.74", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("4d535a59-b047-4f0a-8b1e-f03cc29b98d6"), "G.47.75", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("439d270d-9130-4682-b4f6-c20e6bf6c5d3"), "G.47.76", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("f51d1b07-1889-4ccf-8064-bdd177251944"), "G.47.77", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("e5ac81ab-c8ae-420b-bd48-66ff86183607"), "G.47.78", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("01158bcf-e745-4811-9212-012f0733ee3c"), "G.47.79", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b92a474a-0a76-4867-9225-340667a1b235"), "G.47.63", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("e44a88f7-24f9-4925-83e8-41c1e78f8efe"), "G.47.3", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("1701bc8f-87d5-4a37-a7a5-eb32a77ac51f"), "G.47.29", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Other retail sale of food in specialised stores" },
                    { new Guid("e2e2f4f3-0836-4e40-b38d-d22cc4bbc1b6"), "G.47.26", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("0fe059f8-5255-4956-98fe-30f8959dc20d"), "G.46.61", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("24137dc3-24e9-41cf-8c01-68ac72085233"), "G.46.62", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of machine tools" },
                    { new Guid("48c106a0-b7cf-434b-a0ac-e1968a9dd1a2"), "G.46.63", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("76d77f39-4213-4b70-b39d-31992e346312"), "G.46.64", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("3cdd37d5-812d-48ca-a406-f9aaa0d7138d"), "G.46.65", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of office furniture" },
                    { new Guid("c6b6446f-0340-48b5-b40f-008b6ee8e213"), "G.46.66", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of other office machinery and equipment" },
                    { new Guid("2f53a106-1892-4b9b-b3f7-7a766a24d2ca"), "G.46.69", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of other machinery and equipment" },
                    { new Guid("fbe7adf1-99e1-4016-ae5e-0e9e40bf8f68"), "G.46.7", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Other specialised wholesale" },
                    { new Guid("fb53daf6-21c4-4210-bc65-aa7adcd5f7a8"), "G.46.71", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("52770984-c0e9-42ce-9c5a-4e0547ab7f4a"), "G.46.72", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of metals and metal ores" },
                    { new Guid("7b39e49b-f984-4438-b48b-ff854b7d1ad8"), "G.46.73", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("c5891182-7ec7-45f6-bbd2-c528cf4b7bcc"), "G.46.74", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("02b52e07-6fe0-4b3b-8def-304386754439"), "G.46.75", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of chemical products" },
                    { new Guid("126477ca-38b3-4a47-9e93-2181ed31bf18"), "G.46.76", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of other intermediate products" },
                    { new Guid("ff07a402-e95d-4534-a356-8100a2ac27cf"), "G.46.77", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of waste and scrap" },
                    { new Guid("2c0c3191-bc76-4c3c-9732-f4ae6a88432c"), "G.46.9", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Non-specialised wholesale trade" },
                    { new Guid("d5c67cca-f05e-4505-9d34-189104af0d07"), "G.46.90", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Non-specialised wholesale trade" },
                    { new Guid("b3e1c730-30ed-4bbf-84db-3430db5d3a37"), "G.47", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("4d5a7a41-b265-4ed5-b967-53fcfca061ab"), "G.47.1", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale in non-specialised stores" },
                    { new Guid("ec827554-1163-494b-9812-2515296121d5"), "G.47.11", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("893e983a-7f07-4ea4-abe4-14a67fe7359b"), "G.47.19", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Other retail sale in non-specialised stores" },
                    { new Guid("9899980e-044d-4d16-b495-6fbc6e1c0525"), "G.47.2", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("978ffab5-48e7-44d5-94d3-c3532d697c20"), "G.47.21", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("c2c60864-eab9-4227-be25-089b0823fb19"), "G.47.22", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("907e087d-5641-4e53-ab4c-706f5e7b2dcc"), "G.47.23", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("00893b1d-1b54-491b-8a99-4ced5496630a"), "G.47.24", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("8f8ddf9d-4f8f-4d59-ae20-d98cf2af5cb3"), "G.47.25", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Retail sale of beverages in specialised stores" },
                    { new Guid("b8750615-ef46-4340-a4b5-bfff6af6fc5a"), "G.46.52", new Guid("a639ba43-9ef6-4b49-83d4-4d09dd3f534c"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("2bd72b01-902e-46fb-bfb0-aaf0a074bea6"), "F.43.22", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("17ea534e-f3cd-4caf-b7f2-baede6ed991c"), "K.64.99", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("c997674c-e0cb-4fd3-8e1a-cba877137dcf"), "K.65.1", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Insurance" },
                    { new Guid("aa279363-8d9a-485a-9b5c-18cf9f41bd1f"), "P.85.6", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Educational support activities" },
                    { new Guid("a9db52b6-c9d2-4a9d-aa3c-3ce716270659"), "P.85.60", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Educational support activities" },
                    { new Guid("40f9e6a1-b25f-4d78-9291-3fbe742eeb0e"), "Q.86", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Human health activities" },
                    { new Guid("b81c6537-86c6-4898-a572-91966c4e5342"), "Q.86.1", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Hospital activities" },
                    { new Guid("93dd7745-49fd-4d91-9cd9-a42383359dc3"), "Q.86.10", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Hospital activities" },
                    { new Guid("35d9d71e-e571-49cd-bc33-bc02db40b3bc"), "Q.86.2", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Medical and dental practice activities" },
                    { new Guid("3e80a00d-f379-416a-b0d0-5a406d3f6f83"), "Q.86.21", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4980fc1b-efc6-4a76-abe8-43ea9f86aac6"), "Q.86.22", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Specialist medical practice activities" },
                    { new Guid("672946d4-e794-4d7a-81c9-fd20c25283ef"), "Q.86.23", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Dental practice activities" },
                    { new Guid("d2a457ed-64d0-4d11-82db-17d1badd3ea2"), "Q.86.9", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Other human health activities" },
                    { new Guid("0e310163-0c55-45e4-8137-1fc535ed007f"), "Q.86.90", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Other human health activities" },
                    { new Guid("39ab36c5-c496-4c98-8885-a81cb0d1e502"), "Q.87", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential care activities" },
                    { new Guid("50ea4b50-c385-4a2b-b3fa-ce0f9256876e"), "P.85.59", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Other education n.e.c." },
                    { new Guid("8c24a1c0-6ff2-4b9a-b068-9ca7ba959afa"), "Q.87.1", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential nursing care activities" },
                    { new Guid("2c50db54-e8bf-4128-8394-09e38527d2e7"), "Q.87.2", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("2b236131-ce5f-4bff-997f-368d3872e926"), "Q.87.20", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("2929a3cb-bdd8-4611-a49f-70ede35937eb"), "Q.87.3", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential care activities for the elderly and disabled" },
                    { new Guid("0260c64d-1555-44c0-a0b0-557236b45afd"), "Q.87.30", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential care activities for the elderly and disabled" },
                    { new Guid("596d43ae-1fe4-4c9f-bc87-d844b7b03948"), "Q.87.9", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Other residential care activities" },
                    { new Guid("1c804d69-21b5-4122-8fc0-b916e18fdcc4"), "Q.87.90", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Other residential care activities" },
                    { new Guid("f517a08a-3915-4e7b-919b-69ea0431d27f"), "Q.88", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Social work activities without accommodation" },
                    { new Guid("0570a279-4a1d-41fb-be12-a498490ccc2a"), "Q.88.1", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("89b9103e-c0fc-4c88-b952-428b7ea1e0bb"), "Q.88.10", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("fae93237-9941-47bd-8353-991d483cd551"), "Q.88.9", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Other social work activities without accommodation" },
                    { new Guid("7dd6bbf5-9732-4c4e-bd46-24febf532f0b"), "Q.88.91", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Child day-care activities" },
                    { new Guid("5d3d9637-503a-408b-8976-16cabc19b0f9"), "Q.88.99", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("fa184d0c-d932-45d5-b01a-dab2ae6298a4"), "Q.87.10", new Guid("720ff6fd-7866-49c2-a420-1dcd712f9592"), "Residential nursing care activities" },
                    { new Guid("32f140c6-1d14-4748-85d5-94d4f08c8766"), "P.85.53", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Driving school activities" },
                    { new Guid("ed575ed1-a529-4118-8103-db622936f6c0"), "P.85.52", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Cultural education" },
                    { new Guid("223ee12a-b675-4930-9fdc-ab79dd1780de"), "P.85.51", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Sports and recreation education" },
                    { new Guid("66839c58-c469-4a11-a15d-155c82fb47fd"), "N.82.91", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Packaging activities" },
                    { new Guid("0f891de7-1048-44a4-8363-a01eab7b27fa"), "N.82.99", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other business support service activities n.e.c." },
                    { new Guid("22af8675-402e-4d88-be26-bf4cceadfd10"), "O.84", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Public administration and defence; compulsory social security" },
                    { new Guid("8a750609-e177-4df1-a172-0675bf9010b5"), "O.84.1", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("21752b8a-9c1f-4370-9077-a1a2451b8070"), "O.84.11", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "General public administration activities" },
                    { new Guid("243a9cac-c7c8-45d6-9d9d-ac53d30db0ed"), "O.84.12", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("12013825-6aee-432a-91c0-556863731e54"), "O.84.13", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("9a148e7c-2fcf-463c-af69-0257267f3e49"), "O.84.2", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Provision of services to the community as a whole" },
                    { new Guid("9696132a-e123-4b2b-83f2-5632647966dd"), "O.84.21", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Foreign affairs" },
                    { new Guid("6817ae4e-8b3b-426d-a053-d1ab978b775c"), "O.84.22", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Defence activities" },
                    { new Guid("54b82c35-cd7a-4652-8208-2570098a4e71"), "O.84.23", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Justice and judicial activities" },
                    { new Guid("48b30671-2515-4dd7-b282-184fdaa10b0c"), "O.84.24", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Public order and safety activities" },
                    { new Guid("c27306f7-0b2c-491b-a57d-2b15684b2649"), "O.84.25", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Fire service activities" },
                    { new Guid("b0e43565-0f16-4b86-bbdb-70ff028ed7e3"), "O.84.3", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Compulsory social security activities" },
                    { new Guid("20c5f95c-8b72-46ea-a50d-2df9ab460e80"), "O.84.30", new Guid("94871cc6-f604-419e-bf69-e762f9902b5f"), "Compulsory social security activities" },
                    { new Guid("2adf930c-ca6e-4234-917a-23dd76988b67"), "P.85", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Education" },
                    { new Guid("b7a58c22-2ae3-4d90-b8ce-57a2db1553de"), "P.85.1", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Pre-primary education" },
                    { new Guid("ba8bf0df-e8fe-4d94-a50e-132ad5cc05ab"), "P.85.10", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Pre-primary education" },
                    { new Guid("556ae1fb-66de-4251-9ea3-373558057a12"), "P.85.2", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fac6bc7d-36f6-4727-a768-00073f15a257"), "P.85.20", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Primary education" },
                    { new Guid("31498f80-6eec-4e62-bebf-c194e83be2d9"), "P.85.3", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Secondary education" },
                    { new Guid("dd587b45-9e44-4bee-9110-8fb9c4d151bc"), "P.85.31", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "General secondary education" },
                    { new Guid("8be0657d-abc7-426f-a1b8-3853b5182ae6"), "P.85.32", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Technical and vocational secondary education" },
                    { new Guid("57f3e203-33da-4c55-bb2e-190ba2815081"), "P.85.4", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Higher education" },
                    { new Guid("bf4d3fcf-4786-4cb8-ad7f-98491feb3ea5"), "P.85.41", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Post-secondary non-tertiary education" },
                    { new Guid("67b24367-16ef-4cfb-ae8c-9996965c60b1"), "P.85.42", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Tertiary education" },
                    { new Guid("750ea88b-b876-4fea-aae0-af983847185c"), "P.85.5", new Guid("5efa8c37-369d-4e4c-a264-91e150617a15"), "Other education" },
                    { new Guid("225f5022-d2c4-4032-8e73-9991d0e5a15b"), "R.90", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Creative, arts and entertainment activities" },
                    { new Guid("6bb4c838-742b-4955-9ed1-b6454634dc5d"), "N.82.92", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("5eab1982-2c14-440e-a966-af4b726c54e1"), "R.90.0", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Creative, arts and entertainment activities" },
                    { new Guid("d9387754-22f0-478d-a4cf-ca563df7fd82"), "R.90.02", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Support activities to performing arts" },
                    { new Guid("9b2132fd-e389-472d-b0d4-c3fe8b5d031d"), "S.95.1", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of computers and communication equipment" },
                    { new Guid("8ef62ec0-fd0b-4e56-952d-c72d2864c6a2"), "S.95.11", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of computers and peripheral equipment" },
                    { new Guid("1130ec8e-df19-4ce3-8ca0-5c0e7d711e40"), "S.95.12", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of communication equipment" },
                    { new Guid("361cdc99-fa79-41fa-b4ab-5618c6810b17"), "S.95.2", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of personal and household goods" },
                    { new Guid("7a8c8bdd-4cf9-4d65-bda6-1a53d5565927"), "S.95.21", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of consumer electronics" },
                    { new Guid("d7cbc0b1-b923-4551-9249-22260c2fbc56"), "S.95.22", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("c9137b61-9026-4294-9cdb-4c5f1dfdf970"), "S.95.23", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of footwear and leather goods" },
                    { new Guid("87fa5ee7-2b04-4ae1-be20-7bd5c7892223"), "S.95.24", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of furniture and home furnishings" },
                    { new Guid("161e57fe-2f83-48c9-a133-0f56464e53dc"), "S.95.25", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of watches, clocks and jewellery" },
                    { new Guid("13727d1d-aae2-4170-93ab-6efc20f23a54"), "S.95.29", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of other personal and household goods" },
                    { new Guid("54081272-e49e-485e-94b7-a840c994b3a7"), "S.96", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Other personal service activities" },
                    { new Guid("91bba8e7-d684-4837-902c-a4e1f2e5f87f"), "S.96.0", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Other personal service activities" },
                    { new Guid("1f7b7cd4-8cf2-4419-b7b3-046069a15495"), "S.95", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Repair of computers and personal and household goods" },
                    { new Guid("e3f573da-d71f-4e25-ae7c-b3e1d68949ca"), "S.96.01", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("0871f93a-a771-4b83-ae4c-f2d2fa8d14cf"), "S.96.03", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Funeral and related activities" },
                    { new Guid("db47ae6d-8baf-4fd9-87cd-1fea49ebb9fb"), "S.96.04", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Physical well-being activities" },
                    { new Guid("42615bbf-0e74-43e2-835b-2f0e825bf938"), "S.96.09", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Other personal service activities n.e.c." },
                    { new Guid("256977f7-810d-47d2-a529-0c73530bd6f2"), "T.97", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Activities of households as employers of domestic personnel" },
                    { new Guid("b067a92d-3e1d-4fb8-a9c8-406d2a5d1737"), "T.97.0", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Activities of households as employers of domestic personnel" },
                    { new Guid("0379e231-29ee-4ce3-b44d-9b3fc0c8e40b"), "T.97.00", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Activities of households as employers of domestic personnel" },
                    { new Guid("04ad3539-6c7b-4770-be6b-e52266544160"), "T.98", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("3ca2108b-05c5-490e-91be-e07122086198"), "T.98.1", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("9e8c4a75-dd58-46da-839b-9857d2925ef7"), "T.98.10", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("772922bc-77c1-45fc-9ac0-a584a78946cc"), "T.98.2", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("f8c57d07-bc58-4fa3-a724-8d32c7c7d870"), "T.98.20", new Guid("2790bfc3-8895-4784-836f-0204c794577f"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("01868f44-e651-4ca5-a8b4-a015cc321413"), "U.99", new Guid("9585c938-abe5-4fcb-b51b-dabf10a69694"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("81c80a00-e9ad-405d-8db6-25c5925fb854"), "S.96.02", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Hairdressing and other beauty treatment" },
                    { new Guid("94e4d331-6542-4a6c-871e-4ffab093e5e7"), "S.94.99", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of other membership organisations n.e.c." },
                    { new Guid("36ba8d9a-8695-4d68-9f84-5a77bdb29712"), "S.94.92", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of political organisations" },
                    { new Guid("9d45f1a6-8502-4076-b095-9441a04c115b"), "S.94.91", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0bf6b807-d081-4761-aabb-1b0c3a8651ec"), "R.90.03", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Artistic creation" },
                    { new Guid("3796cd82-37f9-4d9b-b76b-b3521f409177"), "R.90.04", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Operation of arts facilities" },
                    { new Guid("33221662-8093-4496-8c31-f8349116bff5"), "R.91", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("cb065de4-1fe2-45f7-99fc-e3cb5cfe4943"), "R.91.0", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("629d3d18-b991-4c15-be54-ac94d1ee26bd"), "R.91.01", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Library and archives activities" },
                    { new Guid("0d68a7d0-7c79-4615-ac55-8e4f48a838cb"), "R.91.02", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Museums activities" },
                    { new Guid("d8827221-294f-4ccb-9358-f0e1621b4636"), "R.91.03", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("9b91e612-ecbd-46d0-9267-c1320c878ced"), "R.91.04", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("97ded494-1fb8-4355-a035-f2e0a8d01822"), "R.92", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Gambling and betting activities" },
                    { new Guid("4819be20-5396-4432-9417-17a5dce83e17"), "R.92.0", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Gambling and betting activities" },
                    { new Guid("ff199473-0c41-4630-9a38-59d850375a85"), "R.92.00", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Gambling and betting activities" },
                    { new Guid("ed12d4e4-473b-4f26-a8c4-6507be918d54"), "R.93", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Sports activities and amusement and recreation activities" },
                    { new Guid("cafd366c-5448-41fb-aeee-5ce1378d779c"), "R.93.1", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Sports activities" },
                    { new Guid("78955610-de27-4950-b85f-0bbd14b555f9"), "R.93.11", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Operation of sports facilities" },
                    { new Guid("5552b31b-323e-4bcf-ac0d-8a484e5fcdde"), "R.93.12", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Activities of sport clubs" },
                    { new Guid("7652038b-5953-4ba3-ad8e-cbcd1cef9f08"), "R.93.13", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Fitness facilities" },
                    { new Guid("560c29d5-e001-45a3-ba17-b2152142ed6a"), "R.93.19", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Other sports activities" },
                    { new Guid("2388fe19-6e72-440e-a202-dd3dbbd0b086"), "R.93.2", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Amusement and recreation activities" },
                    { new Guid("68ad7c23-08ed-4e78-b3e2-e89d6a436fd2"), "R.93.21", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Activities of amusement parks and theme parks" },
                    { new Guid("41c0563f-ee02-4465-aae4-fcebe4c34340"), "R.93.29", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Other amusement and recreation activities" },
                    { new Guid("9930623b-02fc-432f-8498-4fdef07bad1c"), "S.94", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of membership organisations" },
                    { new Guid("aa548df6-fb12-43cc-b7b1-e48d5cddee2a"), "S.94.1", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("6f4a08c0-7598-4cc7-813f-223b1e8f9984"), "S.94.11", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of business and employers membership organisations" },
                    { new Guid("38694f42-c4b3-4fa8-854e-d8256e2ed305"), "S.94.12", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of professional membership organisations" },
                    { new Guid("38e82f9a-0175-4fe7-9045-d6f1099e2584"), "S.94.2", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of trade unions" },
                    { new Guid("7e99e9dd-ed85-4dba-9d71-a1f95b071e47"), "S.94.20", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of trade unions" },
                    { new Guid("81a75ac9-54e6-4425-b653-b07d2888bc04"), "S.94.9", new Guid("5ef3d5a4-5457-448a-bff8-42821806193f"), "Activities of other membership organisations" },
                    { new Guid("71bb35c9-d460-45c3-b943-5ba714761e35"), "R.90.01", new Guid("6cc643ed-cd5d-426b-9aa6-663116843196"), "Performing arts" },
                    { new Guid("9e593930-38dc-4778-9b72-8d9425fd5603"), "K.65", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("53f50388-8baa-4234-a607-1e4cdbe9c238"), "N.82.9", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Business support service activities n.e.c." },
                    { new Guid("deba2402-daca-40a7-a3f9-7be6844f1b3e"), "N.82.3", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Organisation of conventions and trade shows" },
                    { new Guid("6f79bbd2-8952-423f-b9ce-0e8c050aa3b6"), "M.70.1", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Activities of head offices" },
                    { new Guid("da91246a-4b50-4011-8861-49d241ab2c03"), "M.70.10", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Activities of head offices" },
                    { new Guid("fe1ac131-9cd0-47fa-bc47-42d3ded7d84e"), "M.70.2", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Management consultancy activities" },
                    { new Guid("6a317d28-4d7e-4288-ba12-a822f29b56f8"), "M.70.21", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Public relations and communication activities" },
                    { new Guid("9bf40e0e-90a8-41fd-9115-b3a925e3ec07"), "M.70.22", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Business and other management consultancy activities" },
                    { new Guid("3c15928d-bd87-45d4-905b-8d3bf3c9a2bf"), "M.71", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("b99fb5e9-da10-4cd2-ab37-cec011d1e9c6"), "M.71.1", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("a6d2ae2c-e569-4fa4-a54f-0f2aaaaad422"), "M.71.11", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Architectural activities" },
                    { new Guid("631006d6-1e9a-43ff-8259-b62575ee34aa"), "M.71.12", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Engineering activities and related technical consultancy" },
                    { new Guid("d5bd0f11-8775-46a1-a17f-c536a42b1d69"), "M.71.2", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Technical testing and analysis" },
                    { new Guid("b7513b30-17f4-4b40-83b5-1afe400ed6e7"), "M.71.20", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("50048fc4-0ff1-4830-9550-3ba556a40839"), "M.72", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Scientific research and development" },
                    { new Guid("af90ec9e-850f-4299-86fc-ad547a67cdad"), "M.70", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Activities of head offices; management consultancy activities" },
                    { new Guid("0728f140-9791-47d6-9890-962617d88afc"), "M.72.1", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("5eb7966b-9d62-4e26-824f-e5296cf986bb"), "M.72.19", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("defc2496-890d-42fe-aa19-43c17763f6d2"), "M.72.2", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("7bb8c1b0-695b-4ce4-aa4b-5375e1789570"), "M.72.20", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("3755122e-6b7c-4538-9fcd-02ec27166350"), "M.73", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Advertising and market research" },
                    { new Guid("b4999ee4-49cf-4dd1-a508-a03c0847b112"), "M.73.1", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Advertising" },
                    { new Guid("deb2ffa0-f92c-45e4-b88f-6c6a2437e1b5"), "M.73.11", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Advertising agencies" },
                    { new Guid("2ee51976-00ab-4f7b-b126-7fa87b2f1dd2"), "M.73.12", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Media representation" },
                    { new Guid("24815c36-f676-4cb1-89b0-72ebc8660f04"), "M.73.2", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Market research and public opinion polling" },
                    { new Guid("e4b4928d-2341-44b4-8262-dc748af2d983"), "M.73.20", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Market research and public opinion polling" },
                    { new Guid("a97a0f67-b240-40c4-b15c-dcba621091f5"), "M.74", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Other professional, scientific and technical activities" },
                    { new Guid("3463f4df-bdf1-42e4-8fef-6d055a47d940"), "M.74.1", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Specialised design activities" },
                    { new Guid("facee72d-65e2-41f1-bef5-6f45f8b566a7"), "M.74.10", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Specialised design activities" },
                    { new Guid("78fea639-0457-4745-a0c0-ffbbdb7677a2"), "M.72.11", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Research and experimental development on biotechnology" },
                    { new Guid("82ecd418-c0a5-4ccc-932b-26f85f72be20"), "M.69.20", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("5d6c2790-d3e3-41e0-81ce-32266bc9bab0"), "M.69.2", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("61e51d0c-3eb5-4843-948f-4391adb29e02"), "M.69.10", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Legal activities" },
                    { new Guid("0459cc9b-bc60-41b0-a1a4-cbf5de89de71"), "K.65.11", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Life insurance" },
                    { new Guid("081d2875-80ef-43da-971d-126c511a7f02"), "K.65.12", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Non-life insurance" },
                    { new Guid("96bef0b9-5ca3-4491-a088-4bc427fb5ac7"), "K.65.2", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Reinsurance" },
                    { new Guid("c0a3ab50-3306-4038-9de5-8b54fba80fbc"), "K.65.20", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Reinsurance" },
                    { new Guid("83dc51b1-52c0-47ab-bd49-d44c891571fb"), "K.65.3", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Pension funding" },
                    { new Guid("6b125197-7664-4208-ad6a-21ff51bac462"), "K.65.30", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Pension funding" },
                    { new Guid("2ac50ec0-c367-4476-bdd2-4b396e7bc36d"), "K.66", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("2795e639-79d3-4f25-9006-a5e463d3d3d9"), "K.66.1", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("9aa4eaea-6f3c-437a-ae60-33eeff73cbd1"), "K.66.11", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Administration of financial markets" },
                    { new Guid("adf2e980-c976-4946-b69e-2cf8b587ef17"), "K.66.12", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Security and commodity contracts brokerage" },
                    { new Guid("c771b785-b925-45eb-b9c4-928775c1cefb"), "K.66.19", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("b7b68329-2e1c-4492-aa80-97e7a18304a8"), "K.66.2", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("7bddaa1e-ea81-4bd2-b369-bbbace1279b9"), "K.66.21", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Risk and damage evaluation" },
                    { new Guid("7c40213b-a324-4e22-82f7-3d0d99933ed8"), "K.66.22", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Activities of insurance agents and brokers" },
                    { new Guid("eade534c-c1d9-464e-bf7a-b74496354f42"), "K.66.29", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("765d8a38-50ad-46ca-a04e-f10fdcaf4728"), "K.66.3", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Fund management activities" },
                    { new Guid("7eda5e63-b9ed-4b71-a66d-cf15a2df0acb"), "K.66.30", new Guid("b236592d-9ac0-4623-83c5-61f44a7c4428"), "Fund management activities" },
                    { new Guid("514ee9ef-3ab4-4b38-8613-6c13eee4e842"), "L.68", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Real estate activities" },
                    { new Guid("26d1a5d0-c5d7-439b-92bc-7057692cb7da"), "L.68.1", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Buying and selling of own real estate" },
                    { new Guid("97ad480f-fc60-4a07-bede-ac3c950fc8c9"), "L.68.10", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Buying and selling of own real estate" },
                    { new Guid("795b2d1d-a2ab-4b7c-b117-b912f592c5ea"), "L.68.2", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Renting and operating of own or leased real estate" },
                    { new Guid("beb67833-54d2-40a4-9491-d5ffc63e890b"), "L.68.20", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Renting and operating of own or leased real estate" },
                    { new Guid("b41bc794-8b53-4548-a753-a87652541b7b"), "L.68.3", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("cc5e0cc9-64a3-4c02-9ffd-ed76acdb6eec"), "L.68.31", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Real estate agencies" },
                    { new Guid("3dd09b80-ac66-4c0c-b803-625b49d6aa85"), "L.68.32", new Guid("278132dd-ae28-45f7-b008-b4f3a9386814"), "Management of real estate on a fee or contract basis" },
                    { new Guid("94507732-a730-4d1a-a8cc-abfb3bf8e94e"), "M.69", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Legal and accounting activities" },
                    { new Guid("ed97ffa9-58b7-4d6f-bb3f-75ca7255890a"), "M.69.1", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Legal activities" },
                    { new Guid("b2471af4-a525-4b10-93a8-aa02f36a150f"), "M.74.2", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Photographic activities" },
                    { new Guid("6eec8958-a9af-419f-a9ae-97683abc86cb"), "N.82.30", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Organisation of conventions and trade shows" },
                    { new Guid("119deb6e-4517-4adb-b990-8b4749b9471d"), "M.74.20", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Photographic activities" },
                    { new Guid("58a8a582-0327-43a0-8b55-81613ea7b491"), "M.74.30", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Translation and interpretation activities" },
                    { new Guid("c60543a7-2e1f-4635-a4fe-b6a9117f5ff2"), "N.79.11", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Travel agency activities" },
                    { new Guid("33139b1a-af02-43db-b910-b7e4fab7b504"), "N.79.12", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Tour operator activities" },
                    { new Guid("72fc70b8-ee40-4a14-9def-7e6858425c7e"), "N.79.9", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other reservation service and related activities" },
                    { new Guid("97ce4236-dfc5-4575-8aef-a5efba420bc5"), "N.79.90", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other reservation service and related activities" },
                    { new Guid("6f6d1f7e-c124-461a-ad77-b122e3de4c62"), "N.80", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Security and investigation activities" },
                    { new Guid("e0c0807e-5271-491e-a96b-07ab6afeb6e0"), "N.80.1", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Private security activities" },
                    { new Guid("5d9ec27a-347a-431a-a234-b2d941755484"), "N.80.10", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Private security activities" },
                    { new Guid("0aec24f3-d272-4522-82c0-df40edea94bf"), "N.80.2", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Security systems service activities" },
                    { new Guid("3350e85d-e1ff-401b-9587-865e9b1d6557"), "N.80.20", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Security systems service activities" },
                    { new Guid("2fc73b25-769b-40e3-a546-754b004dab77"), "N.80.3", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Investigation activities" },
                    { new Guid("7b032401-eef4-47fe-bd77-86623e3c520a"), "N.80.30", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Investigation activities" },
                    { new Guid("37fe9d08-cf32-45d8-ba50-7119da950fb5"), "N.81", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Services to buildings and landscape activities" },
                    { new Guid("3a22d3cf-3923-4a1e-8f35-29882b20829f"), "N.79.1", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Travel agency and tour operator activities" },
                    { new Guid("1c56665b-c2c5-41b4-97c6-028be654a19c"), "N.81.1", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Combined facilities support activities" },
                    { new Guid("ea3e2379-e3c7-4192-b86a-d9e78e3130e5"), "N.81.2", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Cleaning activities" },
                    { new Guid("8b513b42-ed81-4af8-b91d-31860ab79e1e"), "N.81.21", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "General cleaning of buildings" },
                    { new Guid("35409f5e-a140-462e-8106-18a40f5c651c"), "N.81.22", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other building and industrial cleaning activities" },
                    { new Guid("d0e4e828-9a1e-4840-8639-aa059e4de5d0"), "N.81.29", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other cleaning activities" },
                    { new Guid("c5484b3c-0d29-4006-9c24-712be563efc3"), "N.81.3", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Landscape service activities" },
                    { new Guid("d549b02f-e25d-4453-a957-e069b7359c33"), "N.81.30", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Landscape service activities" },
                    { new Guid("53c2836a-e649-4aa8-bd57-bc9a222edd09"), "N.82", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Office administrative, office support and other business support activities" },
                    { new Guid("db630932-b6ea-44b5-9161-608564cbc9b7"), "N.82.1", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Office administrative and support activities" },
                    { new Guid("50275cba-37c4-429f-a3fa-2ef9ab3a6a34"), "N.82.11", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Combined office administrative service activities" },
                    { new Guid("01b9ffac-ce51-498b-abb5-b654903f5411"), "N.82.19", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("df9844b0-d6b1-465b-8e7a-1f8f5a36cb48"), "N.82.2", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Activities of call centres" },
                    { new Guid("28ac8d7c-3df3-4713-b3f0-8c9820b1ae0f"), "N.82.20", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Activities of call centres" },
                    { new Guid("ac7ac203-32a4-47ae-bf80-950b6e35687e"), "N.81.10", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Combined facilities support activities" },
                    { new Guid("8246e419-9501-42c7-ac1d-16c061078487"), "N.79", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("1430b732-1d15-43f9-bbc7-e4e7a33b534c"), "N.78.30", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other human resources provision" },
                    { new Guid("02cff8be-6e08-44b9-91ca-4fe4d047a45e"), "N.78.3", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Other human resources provision" },
                    { new Guid("d643dd88-5cee-46c8-b6df-ddfe5dbe93df"), "M.74.9", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("4b23b8f5-639f-4039-8d1d-e351545765bf"), "M.74.90", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("2af0c441-d0f4-4a40-882b-532b875a9230"), "M.75", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Veterinary activities" },
                    { new Guid("637e72a5-e0f8-48d0-90bb-f7da52fc88b1"), "M.75.0", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ef3d9cdc-cd64-4e28-87ce-a6587da614be"), "M.75.00", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Veterinary activities" },
                    { new Guid("676d87ed-e31a-49da-bcc2-83abd973d425"), "N.77", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Rental and leasing activities" },
                    { new Guid("3aa107e4-4aa1-423a-a14d-89a99cce6759"), "N.77.1", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of motor vehicles" },
                    { new Guid("013d184e-19dd-45f3-9e05-47f854a26c42"), "N.77.11", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("bf7b9a0f-b223-479f-aca2-a973fce63d3d"), "N.77.12", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of trucks" },
                    { new Guid("cc229af4-fc0a-4bff-9cef-2f91d0aa54f1"), "N.77.2", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of personal and household goods" },
                    { new Guid("93d5b406-c508-455e-b9b3-3852c750b9ed"), "N.77.21", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("c8456d90-830f-4828-b241-8cdee71a106e"), "N.77.22", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting of video tapes and disks" },
                    { new Guid("6c25dfeb-762d-41e0-a59e-62c8b979cfd5"), "N.77.29", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of other personal and household goods" },
                    { new Guid("aef3b00e-900e-4c64-a151-f07ca9cf071b"), "N.77.3", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("4fc6b503-9ff0-4dd5-a070-3e625eb159d8"), "N.77.31", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("35c7ac72-db3a-4f7b-b15b-e8f5473c47b8"), "N.77.32", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("6791193c-ebaf-41fe-b535-ac1526546d68"), "N.77.33", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("34838e0d-3730-41e8-94df-b267e2bb9748"), "N.77.34", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of water transport equipment" },
                    { new Guid("8da7e074-6d79-4454-a02a-b7995df7baea"), "N.77.35", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of air transport equipment" },
                    { new Guid("62cf166b-e92f-4a58-bbee-adf834d3ce49"), "N.77.39", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("ad8ff516-d49c-4c04-9735-7497b74ec65a"), "N.77.4", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("4106f4a5-0d0d-46c2-861f-e9ea9af9e263"), "N.77.40", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("3f89fa27-585d-4849-9c37-5a7bba21c4df"), "N.78", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Employment activities" },
                    { new Guid("db3ebd48-229f-4ba1-9f10-6111fad81aaf"), "N.78.1", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Activities of employment placement agencies" },
                    { new Guid("b6b1973f-a358-4d4a-9a8c-28ca6815a093"), "N.78.10", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Activities of employment placement agencies" },
                    { new Guid("6eb24e30-b0fb-4321-a8de-7f4234b62d2e"), "N.78.2", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Temporary employment agency activities" },
                    { new Guid("d2f22f3f-5582-4077-82fe-c615883a27cb"), "N.78.20", new Guid("5e0710ea-526b-499f-adbc-34dd153727db"), "Temporary employment agency activities" },
                    { new Guid("50e66184-15e2-4289-883e-08fe99b53cf4"), "M.74.3", new Guid("9dee4377-60fd-47e3-8771-a2fee6ce6c58"), "Translation and interpretation activities" },
                    { new Guid("53b0aed3-699b-4fdb-a199-68b9e6d7fc8c"), "U.99.0", new Guid("9585c938-abe5-4fcb-b51b-dabf10a69694"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("5fba98d5-5737-4e16-a8f1-ad33de4d4832"), "F.43.21", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Electrical installation" },
                    { new Guid("3b88394d-9c02-47f3-ac3f-9081a747aa41"), "F.43.13", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Test drilling and boring" },
                    { new Guid("bc93870a-3976-4e30-be32-3aa2fe177b73"), "C.14.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of articles of fur" },
                    { new Guid("3bc05971-f4e1-4974-a50e-09b3f85b9e61"), "C.14.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of articles of fur" },
                    { new Guid("2d076d53-43df-4ff3-9fb0-3a57465ec89c"), "C.14.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("dbd9055b-2333-43e5-9f61-b30087b42c1b"), "C.14.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("c9ed66a9-1284-4a29-903a-ed8123961ce7"), "C.14.39", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("921fc96a-fcfb-481a-a9af-c5c6aafa8187"), "C.15", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of leather and related products" },
                    { new Guid("eaf69ccc-470c-41c2-926f-6f7159a712a7"), "C.15.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("7dfe48e9-d787-4d1c-9290-ddfa51e60079"), "C.15.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("6ccc6658-a820-4297-8bdb-93fdb64462ce"), "C.15.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("55ddb53d-e028-4d01-b019-713512859872"), "C.15.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of footwear" },
                    { new Guid("85e4a4ad-cb1d-46ca-9896-7ffafed743cd"), "C.15.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of footwear" },
                    { new Guid("573cdf0a-f427-45ac-9999-b0f84feb7d63"), "C.16", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("132a2d5b-9f4c-464a-9523-a2ce2a995e04"), "C.14.19", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("0d942489-b83b-4fd7-9ede-8ed752337397"), "C.16.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Sawmilling and planing of wood" },
                    { new Guid("bc6c1ef8-6035-47a3-a310-2c1c1f48a62b"), "C.16.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("55b52a76-9c16-4357-a307-b4130dac8b7a"), "C.16.21", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("722de415-add6-4bf5-af82-173b10385ef6"), "C.16.22", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of assembled parquet floors" },
                    { new Guid("f86031d9-1f16-447a-83fd-27bd5f95ec26"), "C.16.23", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("4da3c453-b451-46f4-a15e-0449a61e1c77"), "C.16.24", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wooden containers" },
                    { new Guid("2f554d6d-f8d7-4022-9fc3-b6f3e6954738"), "C.16.29", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("857f5eff-7cb3-43e7-ae1c-bc1b45ba86ad"), "C.17", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of paper and paper products" },
                    { new Guid("624f7336-f8da-4825-90d9-e5d04bc7132b"), "C.17.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("ab766fb0-5fc7-4dcf-b0fa-625102f9c617"), "C.17.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of pulp" },
                    { new Guid("2d9bea66-bd75-4e48-ba70-b048040c40e0"), "C.17.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of paper and paperboard" },
                    { new Guid("53c9f22f-6a8c-44e6-bcff-9abe07d2deae"), "C.17.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("35caf3fb-32f1-4292-8201-fa5fb964b4d1"), "C.17.21", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("e90526f7-86c9-4f4e-a438-96b612c67aa4"), "C.16.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Sawmilling and planing of wood" },
                    { new Guid("ad31c387-1dbd-4529-8c65-46dba7326372"), "C.14.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of underwear" },
                    { new Guid("1e7a240e-6e9f-47f7-8764-5079821dac2b"), "C.14.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other outerwear" },
                    { new Guid("c6cad0af-fc82-4552-9766-812da2b88c2a"), "C.14.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of workwear" },
                    { new Guid("d8056bfc-a7d2-4a06-847c-988a5f3b625e"), "C.11.02", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wine from grape" },
                    { new Guid("65fe73fa-4c16-43ce-989e-3dc275c2c76b"), "C.11.03", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cider and other fruit wines" },
                    { new Guid("db39845e-bf25-4152-a32d-7947d9e75770"), "C.11.04", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("6c43c809-01c1-4466-998b-72f949ba0251"), "C.11.05", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of beer" },
                    { new Guid("c2a85919-37fb-4221-876c-5532813ea985"), "C.11.06", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of malt" },
                    { new Guid("3029170a-8e7a-4964-b9d3-82bb2ef494e5"), "C.11.07", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("a2848146-67e7-4a43-a30e-55e4ffa4609b"), "C.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tobacco products" },
                    { new Guid("d266e091-a016-487d-b91b-aac7e634d299"), "C.12.0", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tobacco products" },
                    { new Guid("f02e9c4d-a178-4a47-90f8-7ccec6b66324"), "C.12.00", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tobacco products" },
                    { new Guid("dd92db88-b798-4e7f-930d-59d86a4d9438"), "C.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of textiles" },
                    { new Guid("5652cf1a-1572-4fd3-bd2c-c80f65624d43"), "C.13.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Preparation and spinning of textile fibres" },
                    { new Guid("83108792-65a0-4647-ac15-2662e1507154"), "C.13.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Preparation and spinning of textile fibres" },
                    { new Guid("a3044ad8-c93d-4a75-bb65-46c7214d249b"), "C.13.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Weaving of textiles" },
                    { new Guid("08d1cdab-3b83-4d19-9800-8838b30a0b72"), "C.13.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Weaving of textiles" },
                    { new Guid("e24bb8b1-b2eb-47f2-b52a-c6dfe08b2ec2"), "C.13.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Finishing of textiles" },
                    { new Guid("4e77f663-d50b-40ec-b7e7-6773defed6ad"), "C.13.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Finishing of textiles" },
                    { new Guid("2599c31c-c8d3-4265-bf76-a8748a33cf31"), "C.13.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other textiles" },
                    { new Guid("7cb716a7-a6fe-4aca-8519-19ba2f262d3a"), "C.13.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("666d6171-1284-46d4-bc75-ea35c4a02b20"), "C.13.92", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("7a8da816-18a4-45fd-8ea3-8762ef4643cc"), "C.13.93", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of carpets and rugs" },
                    { new Guid("3574b5e3-39ea-4bf0-bb0d-8215d42f3d46"), "C.13.94", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("88c9fc53-71ed-4349-bef7-f8f44bec0ee8"), "C.13.95", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("1739a57a-6a4c-4238-b02f-6a480bf37e14"), "C.13.96", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("b26e4e0a-eb50-4201-b072-ca3405eb6542"), "C.13.99", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other textiles n.e.c." },
                    { new Guid("e663ad85-c6e6-472e-8489-d45d155cf037"), "C.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wearing apparel" },
                    { new Guid("6fad2246-ab38-45da-8ae5-b1657d0aa681"), "C.14.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("9b0ba6e4-27be-49f1-8806-91db009ea4fd"), "C.14.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("18366f1e-1854-4eac-8f3a-3e8cb9f54b14"), "C.17.22", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("b6da0742-221b-41f0-b6b7-aa5df3edb7cc"), "C.11.01", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("5cd82e3c-224d-4c10-99bb-5afec1de3bb4"), "C.17.23", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of paper stationery" },
                    { new Guid("4639d8d2-eb32-42e4-b992-b21b385476ea"), "C.17.29", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("d4709c8b-3266-4656-8a81-b7ad12442031"), "C.20.52", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of glues" },
                    { new Guid("9c9785ee-3e07-441d-9c4e-4e850a95f4a4"), "C.20.53", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of essential oils" },
                    { new Guid("856f5380-5efd-4e47-a596-7886c5e7eff2"), "C.20.59", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("d84f95b3-f0cf-46c4-bb6f-4ac4e5e81eee"), "C.20.6", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of man-made fibres" },
                    { new Guid("44c08d8a-2e5c-45a0-8584-bd57791a1619"), "C.20.60", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of man-made fibres" },
                    { new Guid("7d58930f-82e2-4e37-bd6a-079ee8a27cad"), "C.21", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("60dda23f-5b3f-42d5-bc25-4a2254792ac2"), "C.21.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("6e2e006d-e5b2-41b0-9e0c-f7d340c1126c"), "C.21.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("0e2afffd-0e81-4154-a860-89330e787533"), "C.21.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("d713bf94-26fb-478e-924a-65b86e626a0f"), "C.21.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("2cb9b2ea-f22d-4718-af5c-d773edb64e2c"), "C.22", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of rubber and plastic products" },
                    { new Guid("9e85de0b-369e-497e-ac4b-d307f600d010"), "C.22.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of rubber products" },
                    { new Guid("7bee23a1-b2ef-4eab-8e5b-6a8843abb416"), "C.20.51", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of explosives" },
                    { new Guid("17cbe056-f94d-46c4-975f-ffc5e76fa343"), "C.22.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("8d77fae1-8168-41fb-874c-16c86a94d809"), "C.22.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of plastics products" },
                    { new Guid("a986c266-84b6-4d07-9d94-3e206d78cb2f"), "C.22.21", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("bc4c7872-5d8a-4e07-a8ca-a64864ab736e"), "C.22.22", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of plastic packing goods" },
                    { new Guid("6fd8f075-8581-4048-816c-286ef8101009"), "C.22.23", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("c1e73b8f-0959-4162-abc0-e4386ea0d9a1"), "C.22.29", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other plastic products" },
                    { new Guid("21c8cfb3-f6e8-4d95-a654-877cc0bf2808"), "C.23", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("4a780b07-1b62-4b92-8114-aa4b8b4333d5"), "C.23.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of glass and glass products" },
                    { new Guid("d89731d5-f6d2-4769-86dd-ace41984d0a0"), "C.23.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of flat glass" },
                    { new Guid("ed7b23a3-b632-43d1-961e-b0d92d367916"), "C.23.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Shaping and processing of flat glass" },
                    { new Guid("ab3beaf6-b3d4-4bba-a02c-57f40fb964b7"), "C.23.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of hollow glass" },
                    { new Guid("5db74c17-4073-44ab-83f3-d102a443a2ec"), "C.23.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of glass fibres" },
                    { new Guid("96200e6f-b61e-416e-a7a3-ed08836ea250"), "C.23.19", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("a0330597-0094-42c5-8114-17eb5cd30600"), "C.22.19", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other rubber products" },
                    { new Guid("ed50b492-f839-47a8-83b8-c81961ae7474"), "C.20.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other chemical products" },
                    { new Guid("29316030-b0bf-42db-a415-ca731084d915"), "C.20.42", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("63bd30b3-a8f0-44b4-9a72-10e84c91d5f3"), "C.20.41", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("81fa890e-363c-455f-8fa5-63a99f0f8475"), "C.18", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Printing and reproduction of recorded media" },
                    { new Guid("4c0e775c-7637-4e04-8378-e53337755d35"), "C.18.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Printing and service activities related to printing" },
                    { new Guid("e09716de-9685-4a4a-b29f-4a0e2f280596"), "C.18.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Printing of newspapers" },
                    { new Guid("f1d28c87-08f5-44d4-8084-4142b2787d6d"), "C.18.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Other printing" },
                    { new Guid("3fd112af-8a6b-49b2-9f6c-0c4b458f5eea"), "C.18.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Pre-press and pre-media services" },
                    { new Guid("4e01db47-fb30-4a00-9eaa-395918f54799"), "C.18.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Binding and related services" },
                    { new Guid("d9a453cb-e7f1-46b6-9d70-1f024997976b"), "C.18.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Reproduction of recorded media" },
                    { new Guid("bc004b43-bf86-4ad3-b754-f858950086a2"), "C.18.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3856e87e-59ae-4937-94b9-5b42be587613"), "C.19", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("42c2186d-bdcb-4f23-85f6-7b1d5a69354c"), "C.19.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of coke oven products" },
                    { new Guid("a9574d08-83ac-4da7-a9db-dc7133516139"), "C.19.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of coke oven products" },
                    { new Guid("aca14c7b-aff8-467f-ab3d-bee7b2e7a90f"), "C.19.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of refined petroleum products" },
                    { new Guid("b348f13f-ae91-4e79-a445-917fd902636c"), "C.19.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of refined petroleum products" },
                    { new Guid("124e581a-2a9a-4fd5-bd6b-2634290fea88"), "C.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of chemicals and chemical products" },
                    { new Guid("65930221-a01d-42d3-b02d-c635df131a51"), "C.20.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("8f6ce16c-6058-46b0-b20d-dbe43e9b9803"), "C.20.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of industrial gases" },
                    { new Guid("1b2c5cdb-ba6e-4119-b230-760f1a64800c"), "C.20.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of dyes and pigments" },
                    { new Guid("67e02b00-3e43-4a28-88db-42ea68bbd520"), "C.20.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("3b498e95-7eff-43df-9815-1a3c7181a7b9"), "C.20.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other organic basic chemicals" },
                    { new Guid("99edbc39-7906-4bb2-8537-d35b29f437aa"), "C.20.15", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("7deb6f4f-0ad1-4f27-b8be-f7ab2bb70096"), "C.20.16", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of plastics in primary forms" },
                    { new Guid("ad5944bd-03de-44c7-a118-bdacf25a012f"), "C.20.17", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("1eda640d-69e2-4972-b911-9a1af690e279"), "C.20.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("b90cd668-49eb-4184-8468-ed04f4e2b9c4"), "C.20.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("f58684e2-1be3-4427-82d3-b50faac8a62d"), "C.20.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("403f5bab-4f96-42ee-a929-6509968918a5"), "C.20.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("8d519b42-2765-4e13-b7c0-1f72ceab6ef4"), "C.20.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("de71ca62-1ff1-4e28-9700-4c47e16dbeee"), "C.17.24", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wallpaper" },
                    { new Guid("ab868b91-997e-4e1f-8d28-fe5540512337"), "C.23.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of refractory products" },
                    { new Guid("40455f6a-8708-46d9-98c6-9f18c41eb265"), "C.11.0", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of beverages" },
                    { new Guid("a570bf2f-bc87-4556-92ae-a4091fa2d91a"), "C.10.92", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of prepared pet foods" },
                    { new Guid("11eea798-9f05-473e-a41f-019ef0b4eb5f"), "A.01.6", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("31ae6d59-2124-428b-ae6b-a7bd5e9e6376"), "A.01.61", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Support activities for crop production" },
                    { new Guid("2cd0f1e0-4f05-4d45-bc30-4d9c5b1df47d"), "A.01.62", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Support activities for animal production" },
                    { new Guid("09eb9fd6-8c9f-45f3-87c2-72fd9909cae0"), "A.01.63", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Post-harvest crop activities" },
                    { new Guid("7d07b032-30e3-4bf3-89b2-521ef2ded898"), "A.01.64", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Seed processing for propagation" },
                    { new Guid("96e8d34f-9f37-414d-924e-5dc4d5dba288"), "A.01.7", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Hunting, trapping and related service activities" },
                    { new Guid("1938aa25-a0e5-4e6c-ae0b-15ae323dd25b"), "A.01.70", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Hunting, trapping and related service activities" },
                    { new Guid("f7e1ecb0-1615-4cca-b39f-05876adcaa64"), "A.02", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Forestry and logging" },
                    { new Guid("ed680669-013d-4647-979d-874e3f911236"), "A.02.1", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Silviculture and other forestry activities" },
                    { new Guid("9ae5b7df-d7b2-4307-a89f-45ef5a9f9f9d"), "A.02.10", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Silviculture and other forestry activities" },
                    { new Guid("78ab967b-f539-4862-b3c4-755d6710f3bd"), "A.02.2", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Logging" },
                    { new Guid("434e768e-fca8-4fb6-83c1-2a8b1f19cace"), "A.02.20", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Logging" },
                    { new Guid("f1bd3f40-d901-4e8a-a33a-13ed79df4b56"), "A.01.50", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Mixed farming" },
                    { new Guid("87ec5d9a-588f-4504-aec6-425c457af83c"), "A.02.3", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Gathering of wild growing non-wood products" },
                    { new Guid("74791a81-c906-49a0-a281-35dacc21131e"), "A.02.4", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Support services to forestry" },
                    { new Guid("fe4e950a-ef8b-4f25-9d1c-0cff7929b44e"), "A.02.40", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Support services to forestry" },
                    { new Guid("c390cfb7-f58c-4650-8cdc-8d1ae25d35ba"), "A.03", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Fishing and aquaculture" },
                    { new Guid("48236132-79c7-47a5-824b-e35e8b803c01"), "A.03.1", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Fishing" },
                    { new Guid("c956e6e7-9b89-48c6-90c0-11fa90017085"), "A.03.11", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a8ff96ff-4ead-4620-b78c-fd7e4a310c1c"), "A.03.12", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Freshwater fishing" },
                    { new Guid("facbad85-abf4-4381-92f3-70a64fdc411f"), "A.03.2", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Aquaculture" },
                    { new Guid("57db666f-ba41-4e4a-9c34-7865c4cbe490"), "A.03.21", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Marine aquaculture" },
                    { new Guid("c87e603a-82ca-40cc-b772-94bc63b140d6"), "A.03.22", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Freshwater aquaculture" },
                    { new Guid("c84a355b-952e-4e04-be22-266fe2622b4e"), "B.05", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of coal and lignite" },
                    { new Guid("6b9546a3-4462-4337-b937-5c6d8f53229f"), "B.05.1", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of hard coal" },
                    { new Guid("acd9f97c-c466-40ee-9e82-29998aee7f79"), "B.05.10", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of hard coal" },
                    { new Guid("2476b249-12e1-4e4c-8ff6-65d978df5794"), "A.02.30", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Gathering of wild growing non-wood products" },
                    { new Guid("518a00e2-d86a-4956-b95e-81e53cafb063"), "A.01.5", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Mixed farming" },
                    { new Guid("1b4db55f-c07a-4dcb-99ab-2a8c374a829f"), "A.01.49", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of other animals" },
                    { new Guid("cc2f8b1c-9c9c-4568-8d80-f2064823b3a3"), "A.01.47", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of poultry" },
                    { new Guid("10721f3a-3836-4639-b0c3-0855dcbdf57a"), "A.01.1", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of non-perennial crops" },
                    { new Guid("91df244f-fd3f-45e0-b14f-85747af8b3d7"), "A.01.11", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("de21b317-29c4-40a1-899e-211b9eb74bb0"), "A.01.12", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of rice" },
                    { new Guid("f7a1f0ad-eba2-4104-875e-3dab4a5ec0b5"), "A.01.13", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("61e27750-a01f-40bd-aed2-95fd68e8a349"), "A.01.14", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of sugar cane" },
                    { new Guid("06d65f9b-f3cc-4a80-8c97-1db6e16063d0"), "A.01.15", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of tobacco" },
                    { new Guid("70ca9ee5-1ce5-4352-96d8-f8bf114d09ed"), "A.01.16", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of fibre crops" },
                    { new Guid("a805e62d-5ac8-4d88-af5e-9636573198db"), "A.01.19", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of other non-perennial crops" },
                    { new Guid("8b374c3a-91ac-40ad-a6ff-99ea1e13def1"), "A.01.2", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of perennial crops" },
                    { new Guid("b5e5ae68-7063-4fde-bd76-4fe1c6d63bce"), "A.01.21", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of grapes" },
                    { new Guid("ab01ca58-6022-4b50-bb27-ee6e7fdc8a34"), "A.01.22", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of tropical and subtropical fruits" },
                    { new Guid("ea65ed38-5810-4f2a-8204-e0954d7989ac"), "A.01.23", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of citrus fruits" },
                    { new Guid("8db9ff3e-1020-4e6b-b256-95d3b3ba5a21"), "A.01.24", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of pome fruits and stone fruits" },
                    { new Guid("f64981d8-5b89-46f5-999c-efa5f65f25e9"), "A.01.25", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("c5fa2fb5-b434-44f6-ada3-2d889f88de1c"), "A.01.26", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of oleaginous fruits" },
                    { new Guid("523447a9-7ccb-428b-b43f-72eca7b78bd6"), "A.01.27", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of beverage crops" },
                    { new Guid("cf09fa6b-4059-4b3d-96c4-cc853162e858"), "A.01.28", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("c727addf-171c-4660-bab5-5a635a0805e5"), "A.01.29", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Growing of other perennial crops" },
                    { new Guid("2e429b89-7aa2-4385-8798-d212b5557bb1"), "A.01.3", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Plant propagation" },
                    { new Guid("e831c6e5-f262-4f31-8e31-cdd5a3151a41"), "A.01.30", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Plant propagation" },
                    { new Guid("f80d5255-893e-41de-aa42-92c8b14fade4"), "A.01.4", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Animal production" },
                    { new Guid("a2b3604a-a8dc-4f9a-91f2-ce13974e917e"), "A.01.41", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of dairy cattle" },
                    { new Guid("046c35bf-e1a4-4d54-9b09-a1ffa1f03bc5"), "A.01.42", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of other cattle and buffaloes" },
                    { new Guid("8db91c14-ee57-4805-89a9-9e72e1ce0c1c"), "A.01.43", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of horses and other equines" },
                    { new Guid("4f422ea6-25a3-4650-96b9-fb2239581e1d"), "A.01.44", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of camels and camelids" },
                    { new Guid("7e152bd1-d81a-47f8-862e-ef42a6af7278"), "A.01.45", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of sheep and goats" },
                    { new Guid("d6a78754-4071-4acc-92e1-862d7fbf0459"), "A.01.46", new Guid("3fa92366-eca1-4944-bf7b-de799c62cbf4"), "Raising of swine/pigs" },
                    { new Guid("8e8deb40-1081-4170-b03c-b00836796275"), "B.05.2", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of lignite" },
                    { new Guid("a86d5050-a44c-4f87-9fff-3cd583aeb260"), "C.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of beverages" },
                    { new Guid("f8c3eb02-31de-4148-9f49-bc01813baec4"), "B.05.20", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of lignite" },
                    { new Guid("cdd1fe97-3a71-45df-9e4b-caedf81a40ce"), "B.06.1", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0062b8c4-d91e-4c99-9691-7bca06db91aa"), "C.10.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of potatoes" },
                    { new Guid("1c078999-ad29-4e35-8e33-659ce93682f4"), "C.10.32", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("a2f33252-78b9-4f18-abe8-58d98fa3cc8c"), "C.10.39", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("e3fc1cd5-2aeb-45f4-8f50-c5a5ab7c969d"), "C.10.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("4ea49577-1900-4a30-a538-859fc971d306"), "C.10.41", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of oils and fats" },
                    { new Guid("aded54d0-3b8d-462e-8f9d-abcf4a7c32ec"), "C.10.42", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("2dbed5b4-1c6d-40ea-939e-e1a2b1cf7302"), "C.10.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of dairy products" },
                    { new Guid("dd575158-8a94-4ab5-8d02-f4202e097190"), "C.10.51", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Operation of dairies and cheese making" },
                    { new Guid("d07ff0fe-ba91-4c50-9b8f-890231eee6d0"), "C.10.52", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ice cream" },
                    { new Guid("97bfacb2-9644-4bd2-a334-ff5027371985"), "C.10.6", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("efd18127-67bb-4779-9fd6-31b19a0622ae"), "C.10.61", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of grain mill products" },
                    { new Guid("3adaae36-d3c0-494e-b860-c47677b73047"), "C.10.62", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of starches and starch products" },
                    { new Guid("41758f46-1a34-4ad6-9aad-6718cb80d696"), "C.10.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("21339fe7-f132-4d2b-ae46-0a6c30ee1278"), "C.10.7", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("303a5585-077a-4164-b750-03329a9f9c3d"), "C.10.72", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("d1f88db4-cd7d-40f3-88d9-74298b63e89d"), "C.10.73", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("ce208742-ef1b-4108-af70-dc00163b28bf"), "C.10.8", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other food products" },
                    { new Guid("d6a3011d-0b44-4da5-8413-7d1738badc9a"), "C.10.81", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of sugar" },
                    { new Guid("6889e5f3-deaf-4647-9071-3fc9c540ee2d"), "C.10.82", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("75597d99-19db-45a4-ae62-7e7580e3bdf2"), "C.10.83", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing of tea and coffee" },
                    { new Guid("19d22d64-ed56-41fb-9ba8-c7765d4fda42"), "C.10.84", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of condiments and seasonings" },
                    { new Guid("4b3d8bf3-d81e-46c9-a27c-2a0a2ccf02c4"), "C.10.85", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of prepared meals and dishes" },
                    { new Guid("eaf5c163-4166-431b-b933-4858a86ab37c"), "C.10.86", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("a9e0fc01-66d0-490c-a1bc-457b4ceec8bf"), "C.10.89", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other food products n.e.c." },
                    { new Guid("b2b4aaae-f3b5-47ae-8759-503ad3a7d2f8"), "C.10.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of prepared animal feeds" },
                    { new Guid("d42e2523-ad89-4a03-b3b7-d37e5e5ef23b"), "C.10.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("7ee3ecb7-a027-4b49-a935-0053310497b0"), "C.10.71", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("a39ca2db-a3de-4815-b385-4aa3193ed0ca"), "C.10.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("71b45b0b-49ce-4c6e-9104-cf98fc8c414a"), "C.10.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("e9ae51ed-7e16-4318-9277-9f3445189028"), "C.10.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Production of meat and poultry meat products" },
                    { new Guid("7acf35fc-e9e6-421d-bc96-3962061b3c6f"), "B.06.10", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of crude petroleum" },
                    { new Guid("5dd7a827-7a15-4399-9bf6-b851ee6f4845"), "B.06.2", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of natural gas" },
                    { new Guid("0d25d6e2-3fb7-4057-ade6-67ee1b447435"), "B.06.20", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of natural gas" },
                    { new Guid("b76869c4-d3c2-4a7b-a127-24dd2274adc9"), "B.07", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of metal ores" },
                    { new Guid("cb0f9f4d-7fac-4f10-8623-444b812e5c9e"), "B.07.1", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of iron ores" },
                    { new Guid("dd4459b1-d3c1-480e-8594-274eb7944d4e"), "B.07.10", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of iron ores" },
                    { new Guid("36e797da-be1c-4654-a3f9-8cb3d9dcd745"), "B.07.2", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of non-ferrous metal ores" },
                    { new Guid("bf8aba7b-96c0-45c6-9133-9e4729bbfca1"), "B.07.21", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of uranium and thorium ores" },
                    { new Guid("eeaee839-807d-4768-b8c2-1a49f8aaab21"), "B.07.29", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of other non-ferrous metal ores" },
                    { new Guid("d413e4e3-7a89-4c71-81f7-eda4f1a9cd31"), "B.08", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Other mining and quarrying" },
                    { new Guid("8f662e32-1557-4022-8160-d8fb3fd2169a"), "B.08.1", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Quarrying of stone, sand and clay" },
                    { new Guid("9bc0090a-07a8-4f06-9faa-0ffcb47dea5b"), "B.08.11", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("75c2c3ba-b337-4215-ad22-3496717e1121"), "B.08.12", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("6968597e-6442-41a1-8e9b-62bddd4e1139"), "B.08.9", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining and quarrying n.e.c." },
                    { new Guid("711492c1-d934-4d40-95ef-ee861b6b11ec"), "B.08.91", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("a25f0366-6add-4eab-85ad-e3b6bc00451b"), "B.08.92", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of peat" },
                    { new Guid("21ef3d7c-9f25-4f40-8dae-1b1caed67f8d"), "B.08.93", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of salt" },
                    { new Guid("ff59a186-806f-438a-976e-e262b413bfbd"), "B.08.99", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Other mining and quarrying n.e.c." },
                    { new Guid("799a09e4-6d2d-494f-bbeb-29825a8de44c"), "B.09", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Mining support service activities" },
                    { new Guid("f1f6a766-d1d5-4834-a583-459b1da37c1c"), "B.09.1", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("e8265479-ebf3-4e69-bee9-fdf4eef7dffe"), "B.09.10", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("8742acdb-85ef-4d2e-bbb9-e3ec3a6ff525"), "B.09.9", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Support activities for other mining and quarrying" },
                    { new Guid("5793b076-99c3-4b84-85c8-2e7f491f42a5"), "B.09.90", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Support activities for other mining and quarrying" },
                    { new Guid("b580a088-f40c-4276-8006-4653f7a43550"), "C.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of food products" },
                    { new Guid("a8184b27-e4a2-4df9-a5e1-3e1f07ba5bce"), "C.10.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("ce554449-6973-4b2c-a6cd-26758c8851d8"), "C.10.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of meat" },
                    { new Guid("63b0c808-2958-4e6c-a190-34e60d1bccaf"), "C.10.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing and preserving of poultry meat" },
                    { new Guid("cc82925d-6987-470b-ab71-3b8dd33bb448"), "B.06", new Guid("ac88ba1e-bc59-4082-8725-a8eb05f79fa7"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("285add24-9b76-4a56-a096-dca2b8d3ae31"), "F.43.2", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("03a5d30b-8084-44d6-af6f-7ed68f219ad2"), "C.23.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of refractory products" },
                    { new Guid("cc2562a5-5961-462f-824b-a81a2bba960a"), "C.23.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("44e84447-5539-4ee0-9f76-881f1ad334a8"), "C.30.92", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("39f6b1bb-261b-4a68-8719-f4247fa902d4"), "C.30.99", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("1c6ff65a-3ddc-4b90-b9d1-08be93ab41fd"), "C.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of furniture" },
                    { new Guid("8fb3745f-28d2-4275-addd-a0939e94d622"), "C.31.0", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of furniture" },
                    { new Guid("c2bfd014-87d4-40d8-8eb8-6b04a1fbd75e"), "C.31.01", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of office and shop furniture" },
                    { new Guid("6dd1602d-e18a-4d8d-b98e-479968949383"), "C.31.02", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of kitchen furniture" },
                    { new Guid("8e7a4895-4047-498a-88df-e0d6ccbe54ad"), "C.31.03", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of mattresses" },
                    { new Guid("e01c00ab-ddb3-4102-89fc-3765f6f3a7b8"), "C.31.09", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other furniture" },
                    { new Guid("6f20e9f5-2e24-4caf-b3ea-68531ee3b928"), "C.32", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Other manufacturing" },
                    { new Guid("730f7304-6fa5-4ed5-9a88-7f0c3b933381"), "C.32.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("a094f163-79e8-4804-b1b0-226a84318df4"), "C.32.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Striking of coins" },
                    { new Guid("cc9bacdb-1d92-4f7b-9e3e-a87be35718cb"), "C.32.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of jewellery and related articles" },
                    { new Guid("c1159bf0-d12a-4359-a9e1-72f8cdb8c6ea"), "C.30.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of motorcycles" },
                    { new Guid("024052b8-84b3-4e0a-99a0-6bc0605490c4"), "C.32.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("c84c35b9-7bb2-4b28-98c4-e90564218680"), "C.32.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of musical instruments" },
                    { new Guid("f0d5ff01-f6e9-4359-9f37-d59ee536b05b"), "C.32.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of sports goods" },
                    { new Guid("1f43a761-d413-426c-9be1-76a273e5b8be"), "C.32.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of sports goods" },
                    { new Guid("a0502281-5c73-450a-9775-f527cc2ec37b"), "C.32.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of games and toys" },
                    { new Guid("da082173-2207-434b-adba-ffb5e93eb2eb"), "C.32.40", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of games and toys" },
                    { new Guid("44ea1bda-f59c-4bcb-bea7-c861eb910f0e"), "C.32.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("ecfb7b65-3836-474b-b168-b9e6a0cb117f"), "C.32.50", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("ac899259-3b3f-44ea-9f66-d31855992d8d"), "C.32.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacturing n.e.c." },
                    { new Guid("baa29ec5-039e-43e2-9ee7-987ac4876945"), "C.32.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fa28cba1-244a-493a-8b47-3b33b89f4fbc"), "C.32.99", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Other manufacturing n.e.c." },
                    { new Guid("847d0fe1-50bf-4648-951a-7ce7b6039ab8"), "C.33", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair and installation of machinery and equipment" },
                    { new Guid("b505fa44-0ca1-47dd-b512-1972be8da193"), "C.33.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("fbc0fe21-45bf-471e-b01b-6df519f47ae9"), "C.32.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of musical instruments" },
                    { new Guid("01dd0f81-afdb-4a0b-9cf8-9be0456c0179"), "C.30.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("b97f5e58-f878-4ee7-910a-30f8f09e5491"), "C.30.40", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of military fighting vehicles" },
                    { new Guid("56fc0ec4-7235-4324-93a2-dc59d6a7073c"), "C.30.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of military fighting vehicles" },
                    { new Guid("5bbe2eaa-5e0f-4ff1-b117-3df116233ae2"), "C.28.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("bb6ee44f-32bd-4614-8411-c80ceccc0a7d"), "C.28.41", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of metal forming machinery" },
                    { new Guid("10d23f22-2c34-487d-af5f-e86a385b7fed"), "C.28.49", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other machine tools" },
                    { new Guid("34edc1a5-92bf-4cec-b837-d28f36e1566c"), "C.28.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other special-purpose machinery" },
                    { new Guid("5392598a-5fcf-4004-a8ba-41c8d0c6de5f"), "C.28.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of machinery for metallurgy" },
                    { new Guid("dd8d15e3-a5e7-4034-8b0f-17929cd4dcb8"), "C.28.92", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("d36ad0dc-3738-4735-a702-fc5e2c28e687"), "C.28.93", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("b539cb94-ca44-4d2f-82b4-e82dfdbb8221"), "C.28.94", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("21488fb4-d4cc-4d80-a95f-63634e5b48e1"), "C.28.95", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("fbf987a2-ddd0-432b-a815-25df2d83b6df"), "C.28.96", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("80729ae8-92db-417a-8143-37c973708aeb"), "C.28.99", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("db306d47-290f-43bf-8383-8a20ae01a2e3"), "C.29", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("be4166eb-ccdc-4895-84d3-4929379be354"), "C.29.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of motor vehicles" },
                    { new Guid("5df7aa6b-83a7-41ab-8c13-5dcad343bad2"), "C.29.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of motor vehicles" },
                    { new Guid("53a46d6b-125d-412d-9e36-5ec6eb9508a7"), "C.29.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("c66fae82-7cde-4b25-8a8f-d257c389b413"), "C.29.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("8a79a1b0-95f7-4c86-bf23-2c1b0e755d87"), "C.29.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("d3a3135d-be37-4c10-a6f6-4a18eef719a0"), "C.29.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("f4d440b5-2c42-4499-b384-a340ca20357f"), "C.29.32", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("80fd52c3-f89f-4673-87a2-269a80551efd"), "C.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other transport equipment" },
                    { new Guid("15ce8162-1329-47e6-b28e-26e669032e5e"), "C.30.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Building of ships and boats" },
                    { new Guid("61126a95-4ef5-4b34-ae44-0784f90d0931"), "C.30.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Building of ships and floating structures" },
                    { new Guid("4eaf4835-b73a-43fa-96c9-8aeccf9f3fe4"), "C.30.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Building of pleasure and sporting boats" },
                    { new Guid("fed09d87-2e49-4995-b8c4-13590d6ebba7"), "C.30.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("af382696-5801-46cf-99cd-c4b332693e28"), "C.30.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("931c34ef-aacd-434b-a859-cafc70fcf9f1"), "C.30.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("80c1a739-3e0a-4840-96da-ea8672a93e7c"), "C.30.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("4a3382a1-0906-4fbe-a629-9c370776d112"), "C.33.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair of fabricated metal products" },
                    { new Guid("3fea59b1-01fc-48f0-bee8-ddd5b9ac8c34"), "C.28.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("681b6ec5-c65e-4d79-a85a-efe07fab5578"), "C.33.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair of machinery" },
                    { new Guid("95656bac-b948-4910-8ae8-9cfcad233289"), "C.33.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair of electrical equipment" },
                    { new Guid("98d4cc04-2292-4d2f-a87c-86f31c045a74"), "E.38.3", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Materials recovery" },
                    { new Guid("24890c5c-1a71-4296-9fa0-a3acfffd7a6e"), "E.38.31", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Dismantling of wrecks" },
                    { new Guid("254762bb-34c5-46bc-9460-2eabb1d77a86"), "E.38.32", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Recovery of sorted materials" },
                    { new Guid("47075444-41ce-467e-a9ac-655296d5a2a5"), "E.39", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("42130bae-99d4-4880-94e1-f334ef028ae2"), "E.39.0", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Remediation activities and other waste management services" },
                    { new Guid("631ffce5-d5b8-4ead-b35d-74f75966b8ef"), "E.39.00", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Remediation activities and other waste management services" },
                    { new Guid("4966369f-3155-44c7-a70a-9876def5fa16"), "F.41", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of buildings" },
                    { new Guid("c1e563f7-af7e-4ed4-8175-be6dae69d30d"), "F.41.1", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Development of building projects" },
                    { new Guid("f8f7f5ae-3132-4e5e-a86d-66d25d5ffcdb"), "F.41.10", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Development of building projects" },
                    { new Guid("f2d2d58c-4edc-4c72-95c8-65f102baf11d"), "F.41.2", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of residential and non-residential buildings" },
                    { new Guid("1c2fd026-d274-4973-8281-78bac4b86b43"), "F.41.20", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of residential and non-residential buildings" },
                    { new Guid("21232c21-33f9-44c3-b45c-9fe0ec9798e2"), "F.42", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Civil engineering" },
                    { new Guid("f4d1f497-b277-4fd4-8ca9-cc16f44c08fb"), "E.38.22", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Treatment and disposal of hazardous waste" },
                    { new Guid("af388cfd-8b1f-4d6b-bbb4-29ac93db2955"), "F.42.1", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of roads and railways" },
                    { new Guid("1855b56c-bc0c-4d52-bf66-d961a19f8377"), "F.42.12", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of railways and underground railways" },
                    { new Guid("57436b95-1272-4960-bf37-465eadfb5fe3"), "F.42.13", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of bridges and tunnels" },
                    { new Guid("d3af7fa3-7e39-45f7-955f-c5fa096a7071"), "F.42.2", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of utility projects" },
                    { new Guid("f2bedf16-113a-4c00-8763-2e11a7e58654"), "F.42.21", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of utility projects for fluids" },
                    { new Guid("c3018580-b4fd-462b-b0e8-9253621e560e"), "F.42.22", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("bbeb6f97-2914-4fc0-a737-0ff0d9bc9487"), "F.42.9", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of other civil engineering projects" },
                    { new Guid("c1c6a3c7-b178-4f8f-bc01-d49dae9599b2"), "F.42.91", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of water projects" },
                    { new Guid("5e21e5c8-6ce0-46cf-81b8-9cbeaf7e4e57"), "F.42.99", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("7ae77a42-2a37-4c2c-95a9-27cc9bfe54b4"), "F.43", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Specialised construction activities" },
                    { new Guid("e39b2466-12bf-424c-835b-99e59d5045f5"), "F.43.1", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Demolition and site preparation" },
                    { new Guid("fe1f7ba2-1e98-4c1e-8fe3-046503558eeb"), "F.43.11", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Demolition" },
                    { new Guid("7348e22b-87dc-4a31-a189-c3822a178795"), "F.43.12", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Site preparation" },
                    { new Guid("b0f9deca-83dc-4e1c-bf94-44e50e9bf3d4"), "F.42.11", new Guid("bb0e2afd-718f-42b1-9e7c-30b97dfef0f4"), "Construction of roads and motorways" },
                    { new Guid("e986a909-0bf8-478e-9f90-4053b59250f9"), "E.38.21", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("a4ff84c4-4b9a-482c-9068-bccf6341681b"), "E.38.2", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Waste treatment and disposal" },
                    { new Guid("bcbad5d2-4ebe-4e96-88b9-670c9e66cfbb"), "E.38.12", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Collection of hazardous waste" },
                    { new Guid("aca47113-4f77-46e5-a91c-91b693458427"), "C.33.15", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair and maintenance of ships and boats" },
                    { new Guid("7b59484c-0827-4606-906b-e1a69c001adf"), "C.33.16", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("3564e7fe-e7d6-429b-922f-8f187f3c13ca"), "C.33.17", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair and maintenance of other transport equipment" },
                    { new Guid("51fb7330-e4bd-4bc1-a19f-2447fa704f75"), "C.33.19", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair of other equipment" },
                    { new Guid("ee6a6499-f1e9-48d0-8a7f-729380636199"), "C.33.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Installation of industrial machinery and equipment" },
                    { new Guid("4c79c5a2-d987-4b78-8f8e-b071ffa25fcb"), "C.33.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Installation of industrial machinery and equipment" },
                    { new Guid("c67bcb49-9df0-45c9-82af-b7b6a56184bd"), "D.35", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("5bfa590a-7b08-4118-9d87-4db93a6804f4"), "D.35.1", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Electric power generation, transmission and distribution" },
                    { new Guid("33ca4e31-ed38-457a-bde4-59619e57154e"), "D.35.11", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Production of electricity" },
                    { new Guid("f6e0cd98-87a5-4d24-bd08-ae3a07b5b3f1"), "D.35.12", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Transmission of electricity" },
                    { new Guid("b4207bbb-923e-4481-b354-46a34afc3ef4"), "D.35.13", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Distribution of electricity" },
                    { new Guid("a51f0567-078e-4631-9512-5e8ad63f6877"), "D.35.14", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Trade of electricity" },
                    { new Guid("85b45e60-c5d3-417f-87d2-be4b9d8637f4"), "D.35.2", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("a2fc5d74-9ec3-41f8-9981-128ee6344a87"), "D.35.21", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Manufacture of gas" },
                    { new Guid("1d6164b1-6bc5-4690-a2b9-c1d257974d0c"), "D.35.22", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Distribution of gaseous fuels through mains" },
                    { new Guid("9a8a423e-173f-44fa-9312-b9f5c16b1391"), "D.35.23", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("726030f5-c933-4236-9b31-7c38486c5fe1"), "D.35.3", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Steam and air conditioning supply" },
                    { new Guid("fc404f59-d2fa-4ca8-901f-4bc95a866cee"), "D.35.30", new Guid("3a700f46-ade9-4622-a74b-81422e938f02"), "Steam and air conditioning supply" },
                    { new Guid("0ba3bf7b-2995-4ceb-be6b-3893c69db1fe"), "E.36", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Water collection, treatment and supply" },
                    { new Guid("3570d714-9077-49be-b4ec-af7201c7da76"), "E.36.0", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Water collection, treatment and supply" },
                    { new Guid("6282f3c0-7b71-4fae-9d33-a03d08b92d33"), "E.36.00", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Water collection, treatment and supply" },
                    { new Guid("19b34fb1-71bc-4cc5-b89c-1062640fb58d"), "E.37", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Sewerage" },
                    { new Guid("9c656a81-fd54-4fe0-8db1-bd1d9d6c6298"), "E.37.0", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Sewerage" },
                    { new Guid("8fa0f423-9c02-4ab1-a22d-beca8d9a6f95"), "E.37.00", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Sewerage" },
                    { new Guid("05353d4e-e16d-45ce-beb7-fc0a2b709145"), "E.38", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("52925c22-e04a-48ae-962c-456e73e920ad"), "E.38.1", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Waste collection" },
                    { new Guid("5cb21f93-b62a-4a5f-a6c4-319710081f8b"), "E.38.11", new Guid("bf132edc-44c4-4baf-9f84-c03ae822f72a"), "Collection of non-hazardous waste" },
                    { new Guid("fdcd280e-143c-48f0-9e5a-26a6d7c30ae5"), "C.33.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Repair of electronic and optical equipment" },
                    { new Guid("ca9a701f-297c-4237-a5d9-80013c588bf0"), "C.23.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of clay building materials" },
                    { new Guid("fdeb8abe-2627-4bc8-a65d-cb573a115945"), "C.28.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("394bc888-f1c2-49ce-a97e-9caf4468c6b0"), "C.28.25", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("178309a6-e6f3-49f9-97df-f594eb9f3917"), "C.24.34", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Cold drawing of wire" },
                    { new Guid("507b0bbc-1c42-4c5a-9199-328c39ef7fc7"), "C.24.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("07b6a31f-c669-4b5d-96aa-298907bd3f1d"), "C.24.41", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Precious metals production" },
                    { new Guid("00f3577d-0929-433e-83a3-a039acd9e07d"), "C.24.42", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Aluminium production" },
                    { new Guid("e81de1ba-848f-4e8d-8f86-cf1ba9e13258"), "C.24.43", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Lead, zinc and tin production" },
                    { new Guid("29fb69b0-2523-4b04-a8db-5ceb59879517"), "C.24.44", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Copper production" },
                    { new Guid("b02117aa-c0b4-443b-af2c-17124f05bf83"), "C.24.45", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Other non-ferrous metal production" },
                    { new Guid("7a334c3b-b12f-4143-926e-eaa4d1686189"), "C.24.46", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Processing of nuclear fuel" },
                    { new Guid("6feb60ab-eed6-44dd-af66-7ca8f82f0e49"), "C.24.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Casting of metals" },
                    { new Guid("989b469e-8ed9-4f0a-904c-fed213375d6d"), "C.24.51", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Casting of iron" },
                    { new Guid("b95359a6-2565-4b20-966c-62531aa833d7"), "C.24.52", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Casting of steel" },
                    { new Guid("4e92d897-c02e-44df-b24c-32db9ebb3537"), "C.24.53", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Casting of light metals" },
                    { new Guid("ecbc9619-05b5-44d0-9d13-ac7a9fdd49fb"), "C.24.33", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Cold forming or folding" },
                    { new Guid("75b8d2a1-dbdd-4ca6-aa45-511211b96091"), "C.24.54", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Casting of other non-ferrous metals" },
                    { new Guid("3b140863-3002-414e-aecd-b75c82ea5de3"), "C.25.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of structural metal products" },
                    { new Guid("aebc5f6c-9faa-4b3e-9b7c-2f36f81102be"), "C.25.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("5f649631-3de5-4e6e-9fe4-7fb21d636ebc"), "C.25.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of doors and windows of metal" },
                    { new Guid("17b91f1c-dde5-417b-89a2-a205df2f9115"), "C.25.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("635e4e9a-c658-4ccc-83b3-b84bf94e2d3e"), "C.25.21", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("1649cd49-7546-43dc-a920-2992eaf3bcf4"), "C.25.29", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("df17935d-9fbf-46ee-ac86-abf1ceecfbc1"), "C.25.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("6d96a0af-b774-407e-bbf8-e13ed20ff268"), "C.25.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("1a3b169d-2214-44af-9d24-02118a59bfd5"), "C.25.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of weapons and ammunition" },
                    { new Guid("ad0e7f91-4de5-4448-99a1-8cf76e264e22"), "C.25.40", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of weapons and ammunition" },
                    { new Guid("811cef9b-77df-4ae2-8a3b-8bd17acc8747"), "C.25.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("8f4dc1b2-eddb-42fb-8d8b-791b3e723d12"), "C.25.50", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("a466fea2-1e31-4b44-97a0-0f6e528d953a"), "C.25", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("71f7fcb2-4be6-46a6-bea5-edf580deda4c"), "C.24.32", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Cold rolling of narrow strip" },
                    { new Guid("a001ca3c-8371-4247-b364-daf663ff0b7b"), "C.24.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Cold drawing of bars" },
                    { new Guid("c09e8d7e-1086-4c76-baf6-0a298a6d3ced"), "C.24.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other products of first processing of steel" },
                    { new Guid("64ed8e49-fcb3-42ed-b2ec-48bde2b6c60b"), "C.23.32", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("edad9b14-5cc1-4976-b0e1-ab9879be266a"), "C.23.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("1a04e8e1-cd81-4374-9211-8ae25047971a"), "C.23.41", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("0582302e-843c-4f5f-9739-20380577c5ee"), "C.23.42", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("7739f73d-1c91-474b-81c9-01dec9290f68"), "C.23.43", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("c5e79775-d76d-46ad-bb63-d61c17afb9a1"), "C.23.44", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other technical ceramic products" },
                    { new Guid("b054c019-af58-4eb2-9dc5-b3514407dd65"), "C.23.49", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other ceramic products" },
                    { new Guid("335bcb25-a581-4eb4-9a3c-f7bfaa1acc70"), "C.23.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cement, lime and plaster" },
                    { new Guid("d9c4fb4f-fd4e-4956-94db-202f6e43f76f"), "C.23.51", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cement" },
                    { new Guid("5070cd00-8b55-46af-81b8-232baf2f6278"), "C.23.52", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of lime and plaster" },
                    { new Guid("314a8912-c2a8-494d-b7d3-4d30fdfd87ca"), "C.23.6", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("72df318f-7265-45dd-b06e-1d34907f2849"), "C.23.61", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("8fbdf97d-5370-4c1f-a882-1fa672767648"), "C.23.62", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("da4a8d5f-3372-42c9-9e09-bd86148c018a"), "C.23.63", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ready-mixed concrete" },
                    { new Guid("4e9dc33d-3084-4f1a-89f7-14750b43529a"), "C.23.64", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of mortars" },
                    { new Guid("3789c9cc-2c80-4e9e-a653-77310b476aa1"), "C.23.65", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fibre cement" },
                    { new Guid("b3f3393f-d8c9-404c-863d-277ec0b1e717"), "C.23.69", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("2c1bb2c8-f867-4093-abad-04ac2428e695"), "C.23.7", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Cutting, shaping and finishing of stone" },
                    { new Guid("3d33bf1a-32fb-43d2-aa9e-c7a4ff080b2b"), "C.23.70", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Cutting, shaping and finishing of stone" },
                    { new Guid("93504e3e-41b0-4b4f-823a-8078ee34ffbf"), "C.23.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("1ad904a2-0523-4204-a3de-95526bc37922"), "C.23.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Production of abrasive products" },
                    { new Guid("a6e961f4-dbe0-44e5-932f-563188ae4852"), "C.23.99", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("96eda088-f7ab-4dcc-b2d7-eba8f4acfdc6"), "C.24", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic metals" },
                    { new Guid("24e9a54f-5ad8-40dc-9553-bb57b8b5cd9b"), "C.24.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("d22e9370-aee1-4c55-bbb7-5dad800163e8"), "C.24.10", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("e3fc4052-9c7f-4324-a22b-8447c9b17e72"), "C.24.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("e1d1d1ff-d485-431d-a702-cf92313a14f5"), "C.24.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("d22da379-93a9-432e-8dd7-16a8e36d1502"), "C.25.6", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Treatment and coating of metals; machining" },
                    { new Guid("fd95029a-17ab-439b-9e80-76217755053f"), "C.28.29", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("fd8039dd-25b4-41ae-bc62-8c2b8e22c35c"), "C.25.61", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Treatment and coating of metals" },
                    { new Guid("eb684e7f-8291-4ae0-b1fd-0aea9aba65cb"), "C.25.7", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("b5fc3cf3-9962-489d-a09a-c478c1edab86"), "C.27.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("e49c6e4b-6b1e-4992-ad64-d07e1055f4a2"), "C.27.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of batteries and accumulators" },
                    { new Guid("fb943ab3-dd62-4fb8-9c32-bbda07ae5f7e"), "C.27.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of batteries and accumulators" },
                    { new Guid("53f54b28-50f5-484e-b3df-7c61fc86fd48"), "C.27.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wiring and wiring devices" },
                    { new Guid("08f19b25-c018-444b-901b-a2b5384f12fd"), "C.27.31", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fibre optic cables" },
                    { new Guid("66755c0f-fc32-449e-a5fb-0d4b652b447b"), "C.27.32", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("e379aaa5-0520-4673-b0d1-6c83d7e85c5b"), "C.27.33", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wiring devices" },
                    { new Guid("bfaee054-5fe6-4551-a446-f797f125937d"), "C.27.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d0a71eeb-3476-4055-bb0e-e7cb8c0f8485"), "C.27.40", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electric lighting equipment" },
                    { new Guid("324e2492-18e0-4036-bb22-a46be55ab7a4"), "C.27.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of domestic appliances" },
                    { new Guid("85a613e5-71c6-4b62-a1bc-f0177254b214"), "C.27.51", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electric domestic appliances" },
                    { new Guid("b79ad4cc-11b3-40b8-8afc-139553990836"), "C.27.52", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("520dd3e7-7b8d-4e3e-baf2-ac8175510fbd"), "C.27.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("4b46eec6-24e0-482c-b6e1-4da1e91b8bac"), "C.27.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other electrical equipment" },
                    { new Guid("b8d5f297-6b1c-421a-a646-12df36851b85"), "C.28", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("c596c4d9-d120-470d-bf26-4b6906097ee7"), "C.28.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of general-purpose machinery" },
                    { new Guid("954595df-debc-4777-b4b6-ef90e6e0c77a"), "C.28.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("4ba352e0-ae9b-4a94-bcfe-a5c53bcff079"), "C.28.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fluid power equipment" },
                    { new Guid("d9fa4339-74f4-40a7-b65a-4f89ec5ba347"), "C.28.13", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other pumps and compressors" },
                    { new Guid("d3ac628f-4518-415a-8f50-934806748988"), "C.28.14", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other taps and valves" },
                    { new Guid("152ff701-2c9e-4420-85be-e5dfe738137d"), "C.28.15", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("b6aa2d65-d17b-4174-b68b-8364c8bccc29"), "C.28.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other general-purpose machinery" },
                    { new Guid("1b466fc4-1914-4b93-a35f-4464335eb625"), "C.28.21", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("8357be86-580f-4ddc-b9d6-06d7cc881cf4"), "C.28.22", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of lifting and handling equipment" },
                    { new Guid("d4c0c4cf-603d-4e2e-9540-37114d67efc8"), "C.28.23", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("495c1ac8-246e-46f2-bf19-ede64c91916b"), "C.28.24", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of power-driven hand tools" },
                    { new Guid("9f6904f9-814f-4abe-988d-205bbab3706d"), "C.27.90", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other electrical equipment" },
                    { new Guid("b1ff7413-cdc9-4638-a519-c944701ea689"), "C.27.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("b79856bf-8226-44a6-b984-d720f926f3f5"), "C.27", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electrical equipment" },
                    { new Guid("b0eb0c4e-0234-443d-b87a-6165691d2f58"), "C.26.80", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of magnetic and optical media" },
                    { new Guid("a682b0ef-1c67-4229-9383-9a8280734d2f"), "C.25.71", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of cutlery" },
                    { new Guid("5b99355a-5000-4475-b32d-cbfa96361eba"), "C.25.72", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of locks and hinges" },
                    { new Guid("d333bc8c-9105-409f-a6a8-afe02f91cc00"), "C.25.73", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of tools" },
                    { new Guid("ecbda571-b085-4e68-96f5-b7dcd1381321"), "C.25.9", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other fabricated metal products" },
                    { new Guid("8a0ffc12-9527-4e65-832d-a82819ed43a7"), "C.25.91", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of steel drums and similar containers" },
                    { new Guid("7070e20a-b107-4457-98eb-5bd292369e69"), "C.25.92", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of light metal packaging" },
                    { new Guid("5cc57664-d37f-458a-b773-f4a98b10598c"), "C.25.93", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of wire products, chain and springs" },
                    { new Guid("9c8dab8f-51c6-477f-89b9-5350cbd1d56b"), "C.25.94", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("2601bd82-c926-4ba3-8962-d5731ef1a71b"), "C.25.99", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("73f1f42e-d69c-44f0-8c1c-afef8a4b4ecb"), "C.26", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("10256387-b9c7-4cd3-aab5-919b5f1e64f5"), "C.26.1", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electronic components and boards" },
                    { new Guid("3bc1e468-5c64-4bdb-b444-9193cbbe8212"), "C.26.11", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of electronic components" },
                    { new Guid("df6609e7-783a-46f5-b6f3-eeb266ef9159"), "C.26.12", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of loaded electronic boards" },
                    { new Guid("ed7ab057-3549-4729-9689-80b35f917b25"), "C.26.2", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("4a172f7f-011b-409b-bb5e-f58b6f1121ab"), "C.26.20", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("992eb16a-8510-497b-a9da-7f2ee6df1744"), "C.26.3", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of communication equipment" },
                    { new Guid("f27bb3e8-c5a6-4ea7-9317-89e703852b5c"), "C.26.30", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of communication equipment" },
                    { new Guid("367b5d08-74df-47a5-9dd3-d965f3855aac"), "C.26.4", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of consumer electronics" },
                    { new Guid("333c0d50-a15e-4afe-964f-f0898478043f"), "C.26.40", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of consumer electronics" },
                    { new Guid("e9010e78-3279-4ff3-a506-64dad4ff8467"), "C.26.5", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bfff829b-915f-4874-b331-dadab0278b69"), "C.26.51", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("9eaf96f4-8975-40d1-b084-bee24afffc89"), "C.26.52", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of watches and clocks" },
                    { new Guid("97875bf9-231a-4895-aa60-e2ccced194c4"), "C.26.6", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("0e410af2-1f1e-4490-8ec6-5b0cb8a31668"), "C.26.60", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("dcb1f5d8-b990-460d-94e2-52f5d5a54830"), "C.26.7", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("e8e491ca-7418-41a6-b255-f6ca59618209"), "C.26.70", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("2efea599-30c4-4b26-9e8f-51af6eb5bc95"), "C.26.8", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Manufacture of magnetic and optical media" },
                    { new Guid("f630ffba-66d4-4f08-a638-e905aa93c5f1"), "C.25.62", new Guid("f9a8dbd7-ef95-422d-9fb1-ad91e5fd3b23"), "Machining" },
                    { new Guid("185485be-bbf4-4e6a-b472-7f2fb92ca7f1"), "U.99.00", new Guid("9585c938-abe5-4fcb-b51b-dabf10a69694"), "Activities of extraterritorial organisations and bodies" }
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
