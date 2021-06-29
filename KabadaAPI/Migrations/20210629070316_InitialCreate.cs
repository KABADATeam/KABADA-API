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
                    { new Guid("672b93a9-64c7-41de-9262-801cf2923b0c"), "AT", "Austria" },
                    { new Guid("af814cb7-6148-4b76-bd2c-5edae87381a7"), "LU", "Luxembourg" },
                    { new Guid("23b7c053-eeb3-4452-b44b-c68743b07379"), "MT", "Malta" },
                    { new Guid("9c9b8fc9-d367-402b-8e4d-0ee72b53f34e"), "MK", "North Macedonia" },
                    { new Guid("369c953d-5e2b-4cae-961e-60a5dcce58cf"), "NO", "Norway" },
                    { new Guid("8e24707a-322e-4334-8a44-c8565abcdd3d"), "PL", "Poland" },
                    { new Guid("3cfe20a8-3165-4b9f-ab3b-f8bb3bdc02ad"), "PT", "Portugal" },
                    { new Guid("9156f9bc-fca5-4646-be21-34f47c8cd616"), "RO", "Romania" },
                    { new Guid("7de99301-80cc-4cba-8d1f-9cb087463f7e"), "RS", "Serbia" },
                    { new Guid("744a1ed6-a2b8-4161-98e1-c5800b963965"), "SK", "Slovakia" },
                    { new Guid("45be91dd-84d8-4451-a04f-e8a3dec11a5d"), "SI", "Slovenia" },
                    { new Guid("663ffc86-fade-4636-b541-aed597546b48"), "ES", "Spain" },
                    { new Guid("74dbd6e2-12a3-4372-a5eb-36ead720edd5"), "SE", "Sweden" },
                    { new Guid("e50db742-5206-41e5-8db7-e9f43d248021"), "CH", "Switzerland" },
                    { new Guid("5d1790ac-3196-43c7-a39d-1f0608c9a420"), "TR", "Turkey" },
                    { new Guid("600b2b8f-c6c0-4ca0-aabf-b28eed494962"), "UK", "United Kingdom" },
                    { new Guid("d3e1ad64-793c-4ed1-89cf-aa0b0617d694"), "LT", "Lithuania" },
                    { new Guid("0ceaf912-d89a-4b24-a0ab-dc2159c02378"), "LI", "Liechtenstein" },
                    { new Guid("26df4b23-d676-45b9-a897-821222efe1ee"), "NL", "Netherlands" },
                    { new Guid("c1e06400-ebee-4415-a3cf-f84e1f8c940c"), "IT", "Italy" },
                    { new Guid("b7b8ef47-3d33-44aa-babe-8cb4ccab172a"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("3721becc-124b-4194-b7b1-842db30acb56"), "BE", "Belgium" },
                    { new Guid("20266ec1-264e-4554-8d10-56f0bf697bf0"), "BG", "Bulgaria" },
                    { new Guid("b089150e-96d9-4353-9245-b93bffc97b13"), "LV", "Latvia" },
                    { new Guid("830f098f-7881-4940-9d35-9583522676fb"), "CY", "Cyprus" },
                    { new Guid("064b9984-34a5-49f2-b7a5-9e8b84e32b01"), "CZ", "Czechia" },
                    { new Guid("f03bfc32-1dae-4f52-8e45-d331504d6407"), "DK", "Denmark" },
                    { new Guid("70313333-c2cc-4b38-9158-f0df58b39918"), "EE", "Estonia" },
                    { new Guid("8adf48aa-d781-4163-b334-024530ef3981"), "HR", "Croatia" },
                    { new Guid("e67b3e11-d6fd-40ec-b0c7-799035534e1a"), "FR", "France" },
                    { new Guid("b00c7043-d6b3-48a8-b176-5db7e9e9e00b"), "DE", "Germany" },
                    { new Guid("22596a1a-024f-4284-9f4b-03151030f25c"), "EL", "Greece" },
                    { new Guid("9e54e1fd-fc1c-4f5e-83cc-1251923518f5"), "HU", "Hungary" },
                    { new Guid("bbbf04ee-5059-4107-af67-0817f341cace"), "IS", "Iceland" },
                    { new Guid("9a494b72-6867-4404-8586-00de004cf782"), "IE", "Ireland" },
                    { new Guid("4207f243-4e49-4a58-baee-ad94199ca4bc"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "P", "EN", "Education" },
                    { new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("1ed48518-10cc-4ce8-9821-464f819882c7"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "L", "EN", "Real estate activities" },
                    { new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "J", "EN", "Information and communication" },
                    { new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "C", "EN", "Manufacturing" },
                    { new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "B", "EN", "Mining and quarrying" },
                    { new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "H", "EN", "Transporting and storage" },
                    { new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "F", "EN", "Construction" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("df4b97ca-dd71-4561-ad43-6a70ffacb01f"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e5b7d1fa-ccfe-4182-ae84-b5aef0fa0b49"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("612e2e00-aec2-46b5-94cd-adf24c1947e3"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("610cd63e-701b-4700-b06c-b622d3c3f704"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("f6909bcc-0115-45dc-a09e-645463b1ec40"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("d13af812-3505-4a7c-9494-8a75d7437c63"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("cdea30ab-d5c3-475b-8d34-27e0c190d655"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("13976583-2570-43e2-bcdd-9fcca888572a"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("a3670193-906f-4a89-8f3c-4a42e28c796e"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("6b76afbb-31c0-4db4-b714-336fae723e30"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("e993ee77-30b4-470c-9d91-02eadaa6c12d"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("1c75c625-ba71-4352-b8a2-c818707396d2"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("cc35f6c2-4614-4a02-a154-1b6bc22ee7b0"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("a3598371-2b8f-4bd0-a5b7-1f818a81ec1a"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("b9b700e0-1ddb-4bcf-a6dd-493578ee257f"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("1b1fc53c-2099-4f9e-b7e3-7ac8d5a603db"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("e3b2698e-2001-44ce-bbcd-3e1c46ea3205"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("cc55fecd-3f2e-4cdc-8ed6-7643edecf174"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("1d5271e1-c558-4526-aa15-c0f6795abdac"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("f9eca43b-7a92-481e-bc1c-959f7d08ae42"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("6e3b7b02-40ab-4d2c-a621-fb9e3c8955d2"), (short)2, "Frequency" },
                    { new Guid("b2d8418e-0c6b-4b58-8e36-8c3d4add54de"), (short)6, null, new Guid("f1bf7cbe-4a95-4461-9811-385a71324439"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("c60e59e0-43e7-4fb7-914e-f055836d7639"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("b2d8418e-0c6b-4b58-8e36-8c3d4add54de"), (short)1, "Ownership type" },
                    { new Guid("4f8a0d97-9697-4c8b-b7ab-b758fba6e8d1"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b2d8418e-0c6b-4b58-8e36-8c3d4add54de"), (short)2, "Frequency" },
                    { new Guid("d77ee8a4-86a6-49a7-a09c-e2291ceb1a28"), (short)6, null, new Guid("f1bf7cbe-4a95-4461-9811-385a71324439"), (short)4, "Other" },
                    { new Guid("f63d3f67-15bf-4b54-8fe9-c36020cce6c1"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("d77ee8a4-86a6-49a7-a09c-e2291ceb1a28"), (short)1, "Ownership type" },
                    { new Guid("047313ac-7965-4021-8d53-b59fdf6547ae"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d77ee8a4-86a6-49a7-a09c-e2291ceb1a28"), (short)2, "Frequency" },
                    { new Guid("19ab42b6-6506-4347-b932-0db7612a83bf"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b9f2575d-7ac7-44e9-b4af-08e7d2cdb908"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("a73e6563-845f-492f-b5cf-0ad65fab1843"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("8008303d-8356-49fc-a8f7-03507f533345"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("4df012f6-9275-4385-af69-4a2721f30c4e"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("51eb7d89-cb3a-47f5-bc39-4284e971a9a4"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("bcd2d2a5-80cb-42d7-9cbd-2ce8bbc00a5b"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("15214fda-0315-455f-9c74-2b3608b12b66"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("c4ed3012-38a4-496b-9682-38cc9a91ae98"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("3fa9dc8d-3904-4609-a2be-d7350aa25a6e"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("2d8c54bc-efa6-46ed-8318-4a1af11ade85"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("d747181a-1cbb-44ed-a879-ad6360233573"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("31b84bdc-6564-4aa3-b0e6-53c5f9c5bbdb"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("5b90f083-e64e-4f50-9b91-e59766247c83"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("ed4d9578-791c-4c9e-9915-212c8aa7bd09"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("385b895d-40f3-499a-9336-91902a993c68"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("3bc3fee5-7349-4f6d-8b0c-9ddcf33a19eb"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("871b0f62-4791-4611-b480-b55d3af69951"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("b30163df-bc62-41b9-9f97-6aa86973d9d7"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("631b9947-b13d-4e2b-b2c0-5bc9becd375d"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("05ac8f9b-8c86-4809-b365-40177dae7732"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("bf5465dd-63bc-4125-8cb5-5ab90b8bb619"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("f9257211-6555-409c-aa2a-88d52fb5ec5b"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("7a6891eb-3aba-4a1a-af0f-4a66b5135c33"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("fe42ad0e-fb92-45b1-be20-62924ff60371"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("4a6e6ad9-be02-4c7b-918c-075e20cd82d0"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("56cf44ff-4371-44dc-9c10-a2a76cbaba80"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("6e3b7b02-40ab-4d2c-a621-fb9e3c8955d2"), (short)1, "Ownership type" },
                    { new Guid("2996e8d2-9886-4d6f-a9a6-6bb359e68779"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("92f2bde0-5f8e-484d-9e43-d20555e8f47a"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("dc277d27-5dcc-486f-9f47-c8579f4a3596"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("a2a2fd62-b940-4791-97ad-0db4ec35c989"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("5418c1d4-a55a-4f3e-8863-898ede270279"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("421ef79e-2827-418b-bbc6-c8c67f4da23b"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("f939238e-4a64-44f0-82c6-edb7e9440936"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("3af6f302-5ed9-47a5-abba-3138a921b6a4"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("c0161320-1ae2-48ad-b679-3c839c394d25"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("776c3e6f-ee44-4693-bfff-959663fff817"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("f956e777-38af-4479-a094-17012f055e61"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("3ddafd0b-5ff4-4292-ba02-3f17816d9fc4"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("cddf3723-8ad5-4d7e-8d57-ac6dc4f0e791"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("21c2c7dd-75d2-4c0d-a5af-06fbf4a76485"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("87c8981f-b0c1-40c3-a77b-20420f812544"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("426e9de4-18ad-4923-b4f1-f99f6152e048"), (short)15, null, null, (short)25, "Extraordinariness" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7afa5df3-ed54-4f56-939d-73d98ebd9d65"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("d021314b-025b-43d2-9caa-c87dd30b7cbe"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("6d3c2b1a-23fd-4b1c-9d81-1c51581c7e29"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("6e3b7b02-40ab-4d2c-a621-fb9e3c8955d2"), (short)6, null, new Guid("f1bf7cbe-4a95-4461-9811-385a71324439"), (short)2, "Administrative" },
                    { new Guid("b5bcfd19-dbc1-4b06-96ad-e629ba447da2"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("bb4c6609-03de-402c-b5b0-40c14ebef53b"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("c26d076d-2748-462b-8590-6e5a5ce85587"), (short)1, "Ownership type" },
                    { new Guid("112378a5-f727-4065-b4d0-dae0be1d0e1c"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("77f22744-78b5-491c-b044-1f9f7e6754ce"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("c6bb1f2a-6998-4740-9509-a2ed81a5769a"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("cdd0fe2f-859e-41c7-996a-e76e5538b3a0"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("3d9ca57a-fab4-42cd-888b-51839696e00d"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("f19a358c-5598-4abe-9c7a-88f21de51f99"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("10c65442-610f-4a77-86ac-1d36f7c8d10a"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("3ca7ce2b-3903-428c-b55f-b53245d958b9"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("141ac2ae-ad7d-410a-bd28-80d1460d098b"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("e8ade8f2-807b-41ec-b58d-417ebeb725fb"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("075006bb-f318-46e5-bed5-dbad67311ee6"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("183cde63-be0b-42b2-bb3a-be362a2a679f"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("19f276d0-7a59-445b-be8f-41bb7b7339b7"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("a79076be-bacd-450f-afa3-59bf2594a5a5"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("e1246890-a8a8-4e40-9cfc-97aef94e4947"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("557fa84d-4456-49e4-9935-959f58023374"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("eb5c56d7-f89e-47e3-93fb-cff5bcacd858"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("8fce59e3-08fc-4893-99bd-fe4fe7d0d16c"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("d8dee5a9-fb42-43be-b368-c23e317925d1"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("eeef9058-4e9a-41ed-8205-558f11618366"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("63619105-3cc2-4df8-955e-b44e581109ce"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("882b53b2-93bb-4d99-a81f-8e8fb4b75afe"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("d3c19090-47cf-4e25-b4ab-e15c7c9cf95a"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("48026306-d030-43f8-b0a4-e820bde51878"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("7341b520-40cd-46a0-897c-ca53846c0ab8"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("b2faa61f-d03a-4dbb-b828-1140b619a40a"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("dd7df57c-741d-4296-9683-0fed3df29c91"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("e933e261-d4fa-42bd-a056-daf3d56a565e"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("bc78de01-c60f-43ba-99cc-ca31d6a985c3"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("172af92b-a90e-479f-babe-beee6e49ae18"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("4c4c4668-6a78-4dd1-84bb-900687d782cf"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("70be63d7-28ed-458e-9b95-15dff47e4385"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("bf01eee9-da7f-4866-a50a-2e6d3dc6f4c1"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("2e1caf56-50c2-4e38-83f0-f1f266275917"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("3da44934-0c47-47ba-8a50-9099b9b46029"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("c26d076d-2748-462b-8590-6e5a5ce85587"), (short)2, "Frequency" },
                    { new Guid("d2ededd1-65da-4cb3-aad2-276f2f4f0dc3"), (short)3, null, null, (short)12, "New markets" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("46c0dee8-1808-44f9-b69b-28d3111247d5"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("dc7e56a1-f371-4866-a108-5a268e8a1317"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3113593a-a112-4383-abe5-9823674ec149"), (short)1, "Ownership type" },
                    { new Guid("d612fe1f-2247-4144-a84e-136af746aa27"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3113593a-a112-4383-abe5-9823674ec149"), (short)2, "Frequency" },
                    { new Guid("c1d674f0-7271-43ba-989f-f69c2a078d3d"), (short)6, null, new Guid("b3c22c40-ecd1-432b-80a6-86026c951e44"), (short)4, "Raw materials" },
                    { new Guid("07dc4207-e532-4ef1-916c-adb011d60ad0"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("c1d674f0-7271-43ba-989f-f69c2a078d3d"), (short)1, "Ownership type" },
                    { new Guid("8ad3d845-5d55-4548-9808-f3a32794a400"), (short)6, null, new Guid("b3c22c40-ecd1-432b-80a6-86026c951e44"), (short)5, "Other" },
                    { new Guid("190dc583-10f8-4efb-ada1-a35cb3a8f91c"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("8ad3d845-5d55-4548-9808-f3a32794a400"), (short)1, "Ownership type" },
                    { new Guid("3113593a-a112-4383-abe5-9823674ec149"), (short)6, null, new Guid("b3c22c40-ecd1-432b-80a6-86026c951e44"), (short)3, "Transport" },
                    { new Guid("3e99c86a-4680-4c83-95d4-b1d924c10cc8"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("8ad3d845-5d55-4548-9808-f3a32794a400"), (short)2, "Frequency" },
                    { new Guid("39ee55aa-1925-47cf-b946-c8827c93e1bb"), (short)6, null, new Guid("26c64309-23ae-4ea3-b5c0-7e5c4a27173c"), (short)1, "Brands" },
                    { new Guid("3f876308-c99e-4434-8821-1f86d5201c31"), (short)6, null, new Guid("26c64309-23ae-4ea3-b5c0-7e5c4a27173c"), (short)2, "Licenses" },
                    { new Guid("f1e73091-a9b6-4b0b-a893-9d608f8a14ef"), (short)6, null, new Guid("26c64309-23ae-4ea3-b5c0-7e5c4a27173c"), (short)3, "Software" },
                    { new Guid("c4ddf942-88ed-487f-82e9-2c49e6cb71df"), (short)6, null, new Guid("26c64309-23ae-4ea3-b5c0-7e5c4a27173c"), (short)4, "Other" },
                    { new Guid("f1bf7cbe-4a95-4461-9811-385a71324439"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("c26d076d-2748-462b-8590-6e5a5ce85587"), (short)6, null, new Guid("f1bf7cbe-4a95-4461-9811-385a71324439"), (short)1, "Specialists & Know-how" },
                    { new Guid("26c64309-23ae-4ea3-b5c0-7e5c4a27173c"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("f1f1bad8-7c9f-4058-9faf-0658be7c442e"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("1c3da47a-6912-4d00-af75-dffcc4ffa771"), (short)2, "Frequency" },
                    { new Guid("5c2061eb-9142-420a-9c70-f02c1f1e20a8"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("1c3da47a-6912-4d00-af75-dffcc4ffa771"), (short)1, "Ownership type" },
                    { new Guid("1c3da47a-6912-4d00-af75-dffcc4ffa771"), (short)6, null, new Guid("b3c22c40-ecd1-432b-80a6-86026c951e44"), (short)2, "Equipment" },
                    { new Guid("8375590a-872c-4101-b6e2-32e58d6d8490"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("680af10d-8397-483b-b1ba-2700eba0c4c1"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("b824f0d7-30c8-4918-93db-7997c671594e"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("56c6364d-7177-45e1-862c-1a9fdd0d7728"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("c0ec9513-7c2d-4b9c-9c2f-6ba44b2e09a5"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("7cbcf9ed-0e27-4f5c-a85e-5cc1dea5a9f6"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("0e74d0d4-01f5-4cb7-a920-f93d844bcdb6"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("1f833fd1-7fe1-4878-8b37-0b542434c290"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("73693d88-fe4c-4f4c-8045-f98151433e38"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("0ef26d46-286c-4f2d-a69a-cbfe1426da66"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("b3c22c40-ecd1-432b-80a6-86026c951e44"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("eea80378-055a-426b-afaa-6a2d1b628991"), (short)6, null, new Guid("b3c22c40-ecd1-432b-80a6-86026c951e44"), (short)1, "Buildings" },
                    { new Guid("2040b21e-304b-4dc1-a337-400b79d0923c"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("eea80378-055a-426b-afaa-6a2d1b628991"), (short)1, "Ownership type" },
                    { new Guid("2ab40a5c-a82c-4d2c-bd2d-0b615e17eb21"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("eea80378-055a-426b-afaa-6a2d1b628991"), (short)2, "Frequency" },
                    { new Guid("4f9a35f7-03aa-43a3-abde-ffc5bdbf635e"), (short)3, null, null, (short)23, "Bargaining power of buyers" }
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
                    { new Guid("d8c64831-80d3-451e-9197-fecd117bd9cb"), "A.01", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("19e5463f-cbd1-4f04-89b3-b3b39bf2ac24"), "H.51.22", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Space transport" },
                    { new Guid("3b8d151c-48fc-47d0-a3d8-bfae0da6f3f2"), "H.52", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Warehousing and support activities for transportation" },
                    { new Guid("17422a57-7f3f-43bf-a158-c278a83c8891"), "H.52.1", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Warehousing and storage" },
                    { new Guid("42abfa0d-7ec2-4093-ab75-55ac9f83e0ce"), "H.52.10", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Warehousing and storage" },
                    { new Guid("6418deb5-816b-4fe5-8cdd-fb9fe6376583"), "H.52.2", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Support activities for transportation" },
                    { new Guid("42864875-a269-4c19-8df1-a5c16620dc31"), "H.52.21", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Service activities incidental to land transportation" },
                    { new Guid("6f6fa452-8d7d-4122-bdb5-fd82c65aaf4a"), "H.52.22", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Service activities incidental to water transportation" },
                    { new Guid("dc3c7141-242d-4f68-ae18-f8d21f36582d"), "H.52.23", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Service activities incidental to air transportation" },
                    { new Guid("0aab67f2-b0b8-4f44-bb3c-5c221f6e364e"), "H.52.24", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Cargo handling" },
                    { new Guid("50d7119f-7b47-486a-81dc-5359466d3125"), "H.52.29", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Other transportation support activities" },
                    { new Guid("6dbf8e94-3a25-4f3b-82df-7e7f34c66f35"), "H.53", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Postal and courier activities" },
                    { new Guid("86946778-02aa-4196-ad6c-28e5377a9019"), "H.53.1", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Postal activities under universal service obligation" },
                    { new Guid("7aec551e-52ee-4d2d-a617-25b8d5be285c"), "H.51.21", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Freight air transport" },
                    { new Guid("07fb0a94-dab5-4ec3-94af-fdb39935a5ae"), "H.53.10", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Postal activities under universal service obligation" },
                    { new Guid("ce8691a0-8e6c-4f94-bc54-6d19ea0ac7b9"), "H.53.20", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Other postal and courier activities" },
                    { new Guid("9bc7b3a3-ebc4-4869-9a14-9eb3dae43f57"), "I.55", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Accommodation" },
                    { new Guid("6f3e328f-89b7-44ab-a5f4-cdfce6ee85b2"), "I.55.1", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Hotels and similar accommodation" },
                    { new Guid("3e123342-13e0-4204-be68-c85983094cc6"), "I.55.10", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Hotels and similar accommodation" },
                    { new Guid("3b1d6e4d-84e8-45d1-bd99-284b1dbd3848"), "I.55.2", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Holiday and other short-stay accommodation" },
                    { new Guid("87e5c1aa-7bf0-4fda-a570-363632127796"), "I.55.20", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Holiday and other short-stay accommodation" },
                    { new Guid("368e01bd-2a32-4c98-96a2-68b5cfc8705c"), "I.55.3", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("4daa9e9c-030e-4303-8587-8d97c600a0f7"), "I.55.30", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("f860bd41-0797-4b73-9a9f-d135b1eaae16"), "I.55.9", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Other accommodation" },
                    { new Guid("26042ffa-7c7b-4594-8175-ec8ecee9219c"), "I.55.90", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Other accommodation" },
                    { new Guid("b77655ff-1b0e-4f72-b2b7-1f5281bf1e61"), "I.56", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Food and beverage service activities" },
                    { new Guid("2898bb99-a9e9-4fe1-a947-ece458595aad"), "I.56.1", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Restaurants and mobile food service activities" },
                    { new Guid("e5089515-03f7-4634-a689-4c6782d8bdd1"), "H.53.2", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Other postal and courier activities" },
                    { new Guid("2650580d-6f8c-4536-bf3f-703fe83c8c85"), "H.51.2", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Freight air transport and space transport" },
                    { new Guid("eae7b6c0-436b-4243-a4f3-992f7b87a4d1"), "H.51.10", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Passenger air transport" },
                    { new Guid("75d2de9d-5e91-4d5c-9a57-93a325b8a81f"), "H.51.1", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Passenger air transport" },
                    { new Guid("dd902149-3a62-437b-a8ad-7caa2b95ed68"), "G.47.9", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("e232b3bb-0b19-4076-80c0-4bb5af98171f"), "G.47.91", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("55a7a548-ffe1-49dc-8754-0d62996251e6"), "G.47.99", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("6e001a42-1f31-4d08-8429-c2451e5fb981"), "H.49", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Land transport and transport via pipelines" },
                    { new Guid("329b474a-6d8c-456e-9969-4aa95be905b2"), "H.49.1", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Passenger rail transport, interurban" },
                    { new Guid("e5b79eea-3750-424e-b300-cd4257ca47d7"), "H.49.10", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Passenger rail transport, interurban" },
                    { new Guid("7b426b2f-98e1-44f6-9f6a-8d2ed19f19b1"), "H.49.2", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Freight rail transport" },
                    { new Guid("b925d447-bc2f-4741-9d7a-af504fde6493"), "H.49.20", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Freight rail transport" },
                    { new Guid("a3bed6c1-fa68-4477-8e01-a2b3978a2a77"), "H.49.3", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Other passenger land transport" },
                    { new Guid("8a8ec059-0774-4611-995b-a21b9788fdd2"), "H.49.31", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Urban and suburban passenger land transport" },
                    { new Guid("02c7d28a-e7ae-48ee-954f-c562d0373e2c"), "H.49.32", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3455d99f-2520-4cfb-89d2-8c4bfc1192b1"), "H.49.39", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Other passenger land transport n.e.c." },
                    { new Guid("3474523e-13d7-4da8-8a4b-6f647d35135f"), "H.49.4", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Freight transport by road and removal services" },
                    { new Guid("a915bba8-3169-40dc-8649-799b93c9b554"), "H.49.41", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Freight transport by road" },
                    { new Guid("1983938a-e3e3-4949-9857-d32c1f79176d"), "H.49.42", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Removal services" },
                    { new Guid("246fb551-39e4-4730-b908-e7d7fa74cf8d"), "H.49.5", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Transport via pipeline" },
                    { new Guid("b9a21eb8-2789-48d5-9f83-cd020f2ec1a7"), "H.49.50", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Transport via pipeline" },
                    { new Guid("36b50ffd-3e39-4a44-97df-c4579f0e6c1e"), "H.50", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Water transport" },
                    { new Guid("3043dd7b-ae0f-4260-8a06-fedf1b0e8385"), "H.50.1", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Sea and coastal passenger water transport" },
                    { new Guid("562070d7-d7ad-4c6c-b335-6e178d40462b"), "H.50.10", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Sea and coastal passenger water transport" },
                    { new Guid("8375bad6-6349-4dec-9334-75aa92861406"), "H.50.2", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Sea and coastal freight water transport" },
                    { new Guid("91373773-707f-4894-afdf-3fc225e725ea"), "H.50.20", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Sea and coastal freight water transport" },
                    { new Guid("6de00f5c-ee8c-4711-bb33-17bb0e399c91"), "H.50.3", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Inland passenger water transport" },
                    { new Guid("62325585-7292-4217-b8b9-947838e7268c"), "H.50.30", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Inland passenger water transport" },
                    { new Guid("d9c0bf88-dc58-40a1-9b3c-0165f011a453"), "H.50.4", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Inland freight water transport" },
                    { new Guid("9ad784bf-3652-4adc-811f-0b1e33632c6b"), "H.50.40", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Inland freight water transport" },
                    { new Guid("b1a0036e-263d-440a-b418-823ecb92ce45"), "H.51", new Guid("8fb268f7-ff54-4792-919e-f3a5ababc75c"), "Air transport" },
                    { new Guid("452995c1-fa0e-4b50-80c5-1fb26ff7dea9"), "I.56.10", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Restaurants and mobile food service activities" },
                    { new Guid("544e92ee-93a9-4ae1-9acc-82c349412387"), "G.47.89", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("3f889f91-b190-43e7-b558-dba249b89187"), "I.56.2", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Event catering and other food service activities" },
                    { new Guid("583c8074-eb43-4e45-8f88-86f91853cdc6"), "I.56.29", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Other food service activities" },
                    { new Guid("f002f8c8-8ea3-45b9-8116-ebceb6770e04"), "J.61.30", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Satellite telecommunications activities" },
                    { new Guid("c95bde89-0d7c-4326-a373-7c7f2067c64f"), "J.61.9", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other telecommunications activities" },
                    { new Guid("1846f0ab-ec8d-46d9-8cad-f9813b590f8f"), "J.61.90", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other telecommunications activities" },
                    { new Guid("98735574-6dcc-47f2-82be-da194f4ca3b4"), "J.62", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Computer programming, consultancy and related activities" },
                    { new Guid("b25ede4c-3039-4adb-bc50-782a9ccee787"), "J.62.0", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Computer programming, consultancy and related activities" },
                    { new Guid("1732d30f-53aa-4501-a3bb-6040f0ed1e82"), "J.62.01", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Computer programming activities" },
                    { new Guid("f3dc9d63-2bc9-4302-bb03-fb801e81f0c4"), "J.62.02", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Computer consultancy activities" },
                    { new Guid("911f6aa8-5a7d-4a65-9a96-8764b39c0f99"), "J.62.03", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Computer facilities management activities" },
                    { new Guid("0f65a9d5-cb18-400f-854b-0bc13b827b9d"), "J.62.09", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other information technology and computer service activities" },
                    { new Guid("552e1d9e-af39-4a38-a125-abcd53b51ad5"), "J.63", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Information service activities" },
                    { new Guid("95b04516-2858-4985-a7af-f906d8bbc286"), "J.63.1", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("a2ddfcf9-07f4-42dc-8270-a79a3f5b9542"), "J.63.11", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Data processing, hosting and related activities" },
                    { new Guid("f6960780-be0d-47f4-8cad-b24931b3d233"), "J.61.3", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Satellite telecommunications activities" },
                    { new Guid("61a3d9a4-c6aa-4f90-a496-12f332ff1682"), "J.63.12", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Web portals" },
                    { new Guid("2b4ff1f3-6672-4658-9bfc-d1af22a6c9b0"), "J.63.91", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "News agency activities" },
                    { new Guid("43fdfaa9-81ff-47b9-96dc-4cea9fef4684"), "J.63.99", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other information service activities n.e.c." },
                    { new Guid("1373de2f-8cac-4f40-bb7b-18d3fba892c4"), "K.64", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("0fb2a965-672c-49cf-ada9-a04751537eac"), "K.64.1", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Monetary intermediation" },
                    { new Guid("05b5acb2-41be-484d-8cff-effd1820a025"), "K.64.11", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Central banking" },
                    { new Guid("9322fc6e-2b67-4ea6-b6c0-8798bbd8e4e7"), "K.64.19", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Other monetary intermediation" },
                    { new Guid("0eda415d-22d3-4a1e-8809-d02960f230c1"), "K.64.2", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Activities of holding companies" },
                    { new Guid("c82836b2-54c8-4b1a-90b8-b37065594fe7"), "K.64.20", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a319d490-ec71-419d-88bf-92b3f2f1b11e"), "K.64.3", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Trusts, funds and similar financial entities" },
                    { new Guid("4ab20b66-611b-4116-95cb-4db95040e101"), "K.64.30", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Trusts, funds and similar financial entities" },
                    { new Guid("03a8beda-5b65-425e-855d-54fa8d3a09bd"), "K.64.9", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("82cad3a2-52bf-425e-910c-844e1e2c2ad5"), "K.64.91", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Financial leasing" },
                    { new Guid("76e1102e-d245-4918-82b1-3bb27a188456"), "J.63.9", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other information service activities" },
                    { new Guid("a11f326c-8e6d-4894-a2e3-6bd7495e6075"), "J.61.20", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Wireless telecommunications activities" },
                    { new Guid("53c2dfbc-f656-42d1-8566-41d57e98fd1b"), "J.61.2", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Wireless telecommunications activities" },
                    { new Guid("9cf9e354-cfca-418d-af97-11938e42d3bb"), "J.61.10", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Wired telecommunications activities" },
                    { new Guid("9cd2cdbc-9ec8-411a-9d7b-451dbfa4a5f2"), "I.56.3", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Beverage serving activities" },
                    { new Guid("26d33d47-d5fe-422e-beea-bf4d72366166"), "I.56.30", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Beverage serving activities" },
                    { new Guid("1d047daf-4c35-428e-8a42-6a9a57699491"), "J.58", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Publishing activities" },
                    { new Guid("dbb2280c-6ee5-4a02-a0f7-5e3e5ce5f7cc"), "J.58.1", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("bcf70403-bdeb-4b7a-9efa-5f44e9f38cf3"), "J.58.11", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Book publishing" },
                    { new Guid("36a841d4-c363-4604-aa89-1d01334ab84d"), "J.58.12", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Publishing of directories and mailing lists" },
                    { new Guid("b2848963-018f-4259-af64-41248402e307"), "J.58.13", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Publishing of newspapers" },
                    { new Guid("735a6584-131c-44d5-b474-4e7def95ad90"), "J.58.14", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Publishing of journals and periodicals" },
                    { new Guid("cdccfaf3-eadb-4b63-953f-9861f1804d8a"), "J.58.19", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other publishing activities" },
                    { new Guid("6d4e4fed-d49a-49b1-af75-121862b6b08b"), "J.58.2", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Software publishing" },
                    { new Guid("338ddcbb-c2d5-4b5b-a5a1-ea492b19b9c8"), "J.58.21", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Publishing of computer games" },
                    { new Guid("ec69e6e4-2f21-461f-ae44-d2e4808f29e4"), "J.58.29", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Other software publishing" },
                    { new Guid("22a7c129-d8d9-45f9-a404-24a83bb9532d"), "J.59", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("9df41f2e-7c5f-4948-af10-644d16106b2c"), "J.59.1", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Motion picture, video and television programme activities" },
                    { new Guid("5ed50ffa-73a1-4741-8fbc-093b01eb260c"), "J.59.11", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Motion picture, video and television programme production activities" },
                    { new Guid("d047025b-d828-4d84-af1b-ae03ae64b68d"), "J.59.12", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("95c25f72-b5fe-4457-b278-ccef3c52278e"), "J.59.13", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("563bb9de-366d-40a5-8bee-9b7fbde9a0ce"), "J.59.14", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Motion picture projection activities" },
                    { new Guid("21a93a8a-9065-426f-b8d8-da599d00ada3"), "J.59.2", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Sound recording and music publishing activities" },
                    { new Guid("2399d6da-985c-402a-bb44-abb56ead2cc7"), "J.59.20", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Sound recording and music publishing activities" },
                    { new Guid("4638e890-651d-4ad0-ad8f-2f726bbaa5c4"), "J.60", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Programming and broadcasting activities" },
                    { new Guid("9a6687ad-de04-4c4d-8577-67e006274e06"), "J.60.1", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Radio broadcasting" },
                    { new Guid("33080591-5d17-4f24-a557-2beeac3394e6"), "J.60.10", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Radio broadcasting" },
                    { new Guid("93fa8135-cf6b-410f-9942-3f5c875f4197"), "J.60.2", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Television programming and broadcasting activities" },
                    { new Guid("f7a5264f-fc03-4b65-b8bd-dc55bd3e0a12"), "J.60.20", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Television programming and broadcasting activities" },
                    { new Guid("9ea8102c-a363-41f1-9fe5-34f2f10abfe8"), "J.61", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Telecommunications" },
                    { new Guid("1815ee91-576c-48a2-9a30-f50add0125b1"), "J.61.1", new Guid("c36e7e20-30f0-442a-a18d-1d0e29482d6f"), "Wired telecommunications activities" },
                    { new Guid("12b04db4-9f2d-4228-9a02-3656ca66e0d3"), "I.56.21", new Guid("1882c81f-ee0d-445c-b942-aca5eb0e7e63"), "Event catering activities" },
                    { new Guid("3fbddd69-fb93-416f-ac64-2dcfdd9cc125"), "K.64.92", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Other credit granting" },
                    { new Guid("c837370d-e1d0-40d1-a859-7028f89e719a"), "G.47.82", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("c42cb35d-9f75-4481-a6e0-f86a79f2973b"), "G.47.8", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale via stalls and markets" },
                    { new Guid("c8c565bf-92f7-45ad-83fa-cc542ea47300"), "G.46.19", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("194acd26-9e4b-4f74-84dc-2b5273c4abf4"), "G.46.2", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("d902b805-36e7-421e-b317-ff0399355dfa"), "G.46.21", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("43765cd4-0c75-42d9-a74c-3b7f90f6273d"), "G.46.22", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of flowers and plants" },
                    { new Guid("6311320c-bcd1-40c5-84a4-3adcc73a2cb0"), "G.46.23", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of live animals" },
                    { new Guid("035e75fd-8bce-4684-ac82-13c3f7aac491"), "G.46.24", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of hides, skins and leather" },
                    { new Guid("39137c8b-0b1a-4486-8888-f61a48f2877d"), "G.46.3", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("4af2c75f-3728-4d90-afa4-0464dd0f9ad4"), "G.46.31", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of fruit and vegetables" },
                    { new Guid("e60ef9c0-0c05-4405-a1d2-dc3955d0357c"), "G.46.32", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of meat and meat products" },
                    { new Guid("8924b495-d458-48de-8019-b94b51ac07e9"), "G.46.33", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("8330c252-c490-4371-b434-22f0df357553"), "G.46.34", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of beverages" },
                    { new Guid("ec4c0ca5-ff30-4e28-abf3-24fdf0238c73"), "G.46.35", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of tobacco products" },
                    { new Guid("e81e81ec-5e8c-4746-885e-a8675021ab5c"), "G.46.18", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents specialised in the sale of other particular products" },
                    { new Guid("59be3b86-69b8-4776-8ad8-760b25b93243"), "G.46.36", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("596e4766-83fe-4b14-a3db-2f184a1d2b44"), "G.46.38", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("c24b7305-f911-4eaf-aa8b-393fdd45bdde"), "G.46.39", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("1781dba1-c07e-44f4-a045-1511eefc2ca6"), "G.46.4", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of household goods" },
                    { new Guid("9ad0bfc3-8f0a-4c6b-9eca-bb4e5a6bd76e"), "G.46.41", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of textiles" },
                    { new Guid("92583d59-18c2-48eb-ba28-fb6c653e0358"), "G.46.42", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of clothing and footwear" },
                    { new Guid("42a02bca-5cc1-46c4-a095-283f1913b915"), "G.46.43", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of electrical household appliances" },
                    { new Guid("e8599304-8d2e-4e41-97ee-015586cc48dd"), "G.46.44", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("daf1b391-792a-44dd-b6dd-2a71af6de156"), "G.46.45", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of perfume and cosmetics" },
                    { new Guid("d5a23a5c-1554-4841-bb34-bb8df2220f7d"), "G.46.46", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of pharmaceutical goods" },
                    { new Guid("16ad9f69-e93d-4748-b279-592c31537b5b"), "G.46.47", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("fa8cf081-2129-49fe-b41e-3085b175c9bf"), "G.46.48", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of watches and jewellery" },
                    { new Guid("5dec1327-023a-4067-a9e4-6c2837802cb3"), "G.46.49", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of other household goods" },
                    { new Guid("0e413e22-57fb-4831-8f54-89093ff7b2aa"), "G.46.37", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("ff595371-f771-431a-9794-b3ad2247a224"), "G.46.17", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("1bc4afe9-3e72-463f-a06d-9d4c88dee803"), "G.46.16", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("1215dd69-f07c-44d4-a8a6-a27c2d04aca8"), "G.46.15", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("14b536f1-6830-402a-8516-8ab4fa53aae3"), "F.43.29", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Other construction installation" },
                    { new Guid("c23dbc46-4272-4955-a993-b2201a0b4ee3"), "F.43.3", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Building completion and finishing" },
                    { new Guid("de4546ae-5806-4022-9032-41d949f05d9f"), "F.43.31", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Plastering" },
                    { new Guid("a73a487d-7a70-4960-81e2-c4169ef8060b"), "F.43.32", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Joinery installation" },
                    { new Guid("591b4ae5-43d2-4ba0-abf9-e8aa6ce42761"), "F.43.33", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Floor and wall covering" },
                    { new Guid("4dfc6bda-ce90-4b82-b2cf-96bddfd4db12"), "F.43.34", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Painting and glazing" },
                    { new Guid("7ba23f0a-9548-4845-b1d0-31c31cfbcfc0"), "F.43.39", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Other building completion and finishing" },
                    { new Guid("cff5464d-9dfc-4608-9311-93ad3de243d1"), "F.43.9", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Other specialised construction activities" },
                    { new Guid("286fe1ee-b941-41fd-8409-51934fd4e7e0"), "F.43.91", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Roofing activities" },
                    { new Guid("a89247ae-687b-46e4-b18b-9e2b0ec8d52c"), "F.43.99", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Other specialised construction activities n.e.c." },
                    { new Guid("313d36de-87d3-4e45-be03-0a68f5c5167a"), "G.45", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("1ea672ba-d3a8-477a-a748-57afe04e3e03"), "G.45.1", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Sale of motor vehicles" },
                    { new Guid("c64a495b-b3c8-490f-9d79-0a127449930e"), "G.45.11", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Sale of cars and light motor vehicles" },
                    { new Guid("8339e1f5-aff8-4f4d-9e2a-9c69887f3ad7"), "G.45.19", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Sale of other motor vehicles" },
                    { new Guid("5bae6ee6-3050-445f-9fc1-72034edb59de"), "G.45.2", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a978fdd5-f523-4073-afc8-b360fc9c2625"), "G.45.20", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Maintenance and repair of motor vehicles" },
                    { new Guid("bef4d9c5-865b-4ebb-8594-d66c42e288fd"), "G.45.3", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("f2af4515-2ab9-4c08-ae1a-f13d7f0ff2d6"), "G.45.31", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("9762c15c-eb14-46a6-827a-9f2e1ee8182e"), "G.45.32", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("c90326bb-5f96-4d2f-ba5e-ef5e86fcfc02"), "G.45.4", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("83ace6ea-bd69-4a05-b75a-65571824f6ff"), "G.45.40", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("7fb1f3fb-5f42-427d-9333-07a48f1cc972"), "G.46", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("e3757844-4927-472e-923d-81f18f88d083"), "G.46.1", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale on a fee or contract basis" },
                    { new Guid("d51988db-fe49-45bb-a996-75a891ac2658"), "G.46.11", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("a09e0b6f-54fa-4d44-a299-f1bc04788b24"), "G.46.12", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("a6acf6be-810a-41a4-863a-e6fbcd2b0170"), "G.46.13", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("3516fd8a-6887-482e-8012-1ea383ea1804"), "G.46.14", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("d8a921fe-f97f-4a12-b495-55149c6cc8a4"), "G.46.5", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of information and communication equipment" },
                    { new Guid("ecde60d9-27d5-4ed2-a21b-a1256ee1e670"), "G.47.81", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("69169cfc-0700-4950-ad10-f88178e42465"), "G.46.51", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("72f2c241-7cbe-4218-ab0a-67b4161e8993"), "G.46.6", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("e1223b75-0ef4-4eda-b216-cb30aad5d96f"), "G.47.4", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("511f3aca-7653-4b97-b969-9f3a45ddd81a"), "G.47.41", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("544a9fb5-379c-4ab9-8efa-a8cbb78f28a8"), "G.47.42", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("5df489ad-12a2-4aea-9ff6-1dcbe90fdc15"), "G.47.43", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("04914df8-eedd-41ca-a630-8e9b1c4860c6"), "G.47.5", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("11d65729-43dc-493b-bcfa-6b220442a626"), "G.47.51", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of textiles in specialised stores" },
                    { new Guid("20adc94b-1e06-4438-a2a7-3819eb031ace"), "G.47.52", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("c5a8fa82-722c-4d60-b7a3-605705714123"), "G.47.53", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("9e2e9dc2-b4ad-4a1c-a717-c337933b3230"), "G.47.54", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("8dc5101d-ac6e-4ca4-9bae-558b8f4b23e1"), "G.47.59", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("da944cf6-4c25-40ab-a6e9-dbdae9d701a6"), "G.47.6", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("281ab5c1-4f7a-45b2-b88f-4e748401eb1c"), "G.47.61", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of books in specialised stores" },
                    { new Guid("1bcd3a50-e5df-495d-a5bf-faf3d0b43720"), "G.47.30", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("1de34bec-d6f6-4582-8303-c04e8d3d6eb8"), "G.47.62", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("ff18d571-dcfb-4d13-ac9c-217641547fc0"), "G.47.64", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("e8590282-e14d-4171-81bf-63bb04234cc2"), "G.47.65", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("88df0fab-8645-43e6-891f-0dbe13535a73"), "G.47.7", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of other goods in specialised stores" },
                    { new Guid("df0587ae-b861-4ac5-8e00-1e4c1aae971b"), "G.47.71", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of clothing in specialised stores" },
                    { new Guid("e4b855f8-df61-4ae5-8204-fca248a9a93c"), "G.47.72", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("f2083a28-315c-462c-8af4-497c4d48121a"), "G.47.73", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Dispensing chemist in specialised stores" },
                    { new Guid("cbd2d083-4012-437f-869d-61aed8ea1904"), "G.47.74", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("4db02e9a-5b97-49c9-9cd1-7e7cf8e299a7"), "G.47.75", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("0fba925e-0851-4663-a05a-a8dc59042f9c"), "G.47.76", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("439b9f31-207b-40aa-b60c-c8fd165d89b3"), "G.47.77", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("5a5948ca-c502-44c7-b18b-9ba3a6330552"), "G.47.78", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("a69eb892-03d5-4516-95b4-ee5dae3b09b1"), "G.47.79", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("969faa30-6519-43fc-8453-050122222a04"), "G.47.63", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("c6810e36-988f-4f7c-8ca4-090a24e02130"), "G.47.3", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("bb16d3cc-1325-4b00-ad26-48245a1b0fb2"), "G.47.29", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Other retail sale of food in specialised stores" },
                    { new Guid("ca72b99d-bf31-4f04-9c0b-85f607b041b1"), "G.47.26", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("dcde0f34-9557-4f34-a996-ae87d6a87da3"), "G.46.61", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("df1486d0-f264-4cc8-8102-efe882d8e85e"), "G.46.62", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of machine tools" },
                    { new Guid("514d35d4-fd7e-47c1-bd69-5cb59233d415"), "G.46.63", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("04feeffa-2328-45a2-b6e9-50374031bb66"), "G.46.64", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("abae5ca9-d811-4dc0-9804-48bdf5d44093"), "G.46.65", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of office furniture" },
                    { new Guid("8f9f6bc7-471d-4546-a02b-1d59ab289cf9"), "G.46.66", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of other office machinery and equipment" },
                    { new Guid("05e74900-a32e-4c84-a4dc-ff94b90188aa"), "G.46.69", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of other machinery and equipment" },
                    { new Guid("80c2692b-103f-4ab5-afd7-867537cd1c9a"), "G.46.7", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Other specialised wholesale" },
                    { new Guid("d58966dd-7022-4746-9da0-9ba8fdba2165"), "G.46.71", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("0d435b7d-447b-4cfa-bb04-45a5bb8407ad"), "G.46.72", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of metals and metal ores" },
                    { new Guid("131a12fa-2145-4877-97de-8dba4e3bc80b"), "G.46.73", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("4678b45b-7849-4f71-af47-df095393f79c"), "G.46.74", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("00f9ab5d-673d-4919-beb9-a45600f45e1d"), "G.46.75", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of chemical products" },
                    { new Guid("f9ee4dc0-7452-4d55-9c71-dcc659ba5543"), "G.46.76", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of other intermediate products" },
                    { new Guid("4436f3c4-f017-4f65-ac74-b79e9d2e8c49"), "G.46.77", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of waste and scrap" },
                    { new Guid("c8b04a1a-96a2-48f6-b640-4f3ae23caaf3"), "G.46.9", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Non-specialised wholesale trade" },
                    { new Guid("8facc4b0-16a6-4c39-ac3b-85aea634f722"), "G.46.90", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Non-specialised wholesale trade" },
                    { new Guid("853634a0-8dfb-4a04-b853-cc2c194da3c3"), "G.47", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("4d6dca50-787a-4fe3-a899-b0575c2d3d29"), "G.47.1", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale in non-specialised stores" },
                    { new Guid("e24d7007-2ade-4231-8213-f416c2e1c96a"), "G.47.11", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("c981f651-a559-4b11-8554-b27b77d6f1e7"), "G.47.19", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Other retail sale in non-specialised stores" },
                    { new Guid("013561c4-a6c2-4d50-891d-b136afe842d7"), "G.47.2", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("f8298d9b-5c57-4a5d-8905-48983459268a"), "G.47.21", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("26df8266-3ea4-45d1-bbde-dac16ad09174"), "G.47.22", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("ad1ab21d-efa9-4514-a73a-e6b81b015b59"), "G.47.23", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("7f401149-6be8-4179-805c-f8afc154e94d"), "G.47.24", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("f6ced940-f714-4859-b23f-9a2e9b3c31ae"), "G.47.25", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Retail sale of beverages in specialised stores" },
                    { new Guid("4ccc949d-b8d4-464b-995c-e2300660645e"), "G.46.52", new Guid("27e7ad71-67b1-4c18-a19d-80648ba6ab26"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("51a3339f-5af5-4af5-b5a8-14dc8577f027"), "F.43.22", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("d2b1f68b-e3bd-4ec2-9e05-bc8adeba41f4"), "K.64.99", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("fb8341d9-d263-4fe6-aeba-3dc6e91d9531"), "K.65.1", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Insurance" },
                    { new Guid("ced71ed5-c689-4eb8-a6bf-f8111ac3150f"), "P.85.6", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Educational support activities" },
                    { new Guid("7c0690eb-79b6-4c10-b956-f59591938aab"), "P.85.60", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Educational support activities" },
                    { new Guid("63171db4-8799-4caf-a985-37d414c05c39"), "Q.86", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Human health activities" },
                    { new Guid("a48bb1ee-2ded-485d-885f-6e10aa51adb8"), "Q.86.1", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Hospital activities" },
                    { new Guid("d63c9c9f-a941-4a1a-a0d7-fd729f43c54e"), "Q.86.10", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Hospital activities" },
                    { new Guid("0a7f7662-00f4-4c68-9ab1-22ef3be93d82"), "Q.86.2", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Medical and dental practice activities" },
                    { new Guid("c1e7e385-cdde-46b8-96e7-059188d848e7"), "Q.86.21", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f9412530-11ab-44cb-afaa-75c12d89306c"), "Q.86.22", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Specialist medical practice activities" },
                    { new Guid("44e81140-a7ab-4467-b10f-41a3b6ff603a"), "Q.86.23", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Dental practice activities" },
                    { new Guid("e0475840-b433-46cd-a815-0b9d6ddde5d2"), "Q.86.9", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Other human health activities" },
                    { new Guid("dc851ca7-6ec0-4e53-95f2-f3d2a08ee670"), "Q.86.90", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Other human health activities" },
                    { new Guid("a5163150-a530-45a8-964d-3824dfe88e35"), "Q.87", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential care activities" },
                    { new Guid("551d9afa-7862-441f-8586-020d15c4bdc7"), "P.85.59", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Other education n.e.c." },
                    { new Guid("519c1274-0ffe-4525-a10e-eca915087238"), "Q.87.1", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential nursing care activities" },
                    { new Guid("595f8ecc-5409-48da-bcd4-e39c962fe74a"), "Q.87.2", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("33607434-dd07-40d0-8ab1-475bee7ea484"), "Q.87.20", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("487369ca-6b27-42ec-8af2-6c8c35b7184f"), "Q.87.3", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential care activities for the elderly and disabled" },
                    { new Guid("458213bd-39b5-451c-bce1-1ea1fb115ff3"), "Q.87.30", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential care activities for the elderly and disabled" },
                    { new Guid("784ee636-78cd-43e6-9705-93547b3ff3f0"), "Q.87.9", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Other residential care activities" },
                    { new Guid("0e672a48-bfe3-4e21-8342-696709a9893a"), "Q.87.90", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Other residential care activities" },
                    { new Guid("2b5340a5-6db5-4436-a6bb-b5c6349aa445"), "Q.88", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Social work activities without accommodation" },
                    { new Guid("909c9411-e405-4862-bc66-0f3cb4f32129"), "Q.88.1", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("6bdef91c-46b3-4672-a7fb-1108d8d47f9e"), "Q.88.10", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("8597d81f-d36b-492a-a6b7-f3771aa05b13"), "Q.88.9", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Other social work activities without accommodation" },
                    { new Guid("c3044473-76d7-49c9-badc-41930638b1da"), "Q.88.91", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Child day-care activities" },
                    { new Guid("093a7b8d-a69f-4a4c-8451-9c3532f2707d"), "Q.88.99", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("a49a269b-d17f-491c-acb6-f32c319c4dc9"), "Q.87.10", new Guid("01e9ec86-fe71-46ae-b7b4-295dc9a34cb6"), "Residential nursing care activities" },
                    { new Guid("1a3676fb-6b88-4f48-ac26-8d195b467f32"), "P.85.53", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Driving school activities" },
                    { new Guid("070e9136-5831-4844-8cb8-21bb093505e2"), "P.85.52", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Cultural education" },
                    { new Guid("9fc57d29-e827-43d2-a707-759d9e84bf9f"), "P.85.51", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Sports and recreation education" },
                    { new Guid("49b8c5db-ada5-4ed7-8105-07a1b4ca0785"), "N.82.91", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Packaging activities" },
                    { new Guid("c232cb7f-7fde-4cdc-a1d3-d5ad505f9fe8"), "N.82.99", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other business support service activities n.e.c." },
                    { new Guid("93bd00b8-e2dd-48dc-badb-e4ca09dce115"), "O.84", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Public administration and defence; compulsory social security" },
                    { new Guid("3c1bf204-7ff4-4e32-abae-1e904f1e56ff"), "O.84.1", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("8afc1095-a7d3-4523-bcd4-0c4276b136fb"), "O.84.11", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "General public administration activities" },
                    { new Guid("db7b1c49-7e90-4abf-a024-737ad2c3dfe3"), "O.84.12", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("affbe91e-e5c4-4b64-bbef-106eb8579478"), "O.84.13", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("15ce7b1a-9af5-4ad6-8aca-45e321d6ba57"), "O.84.2", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Provision of services to the community as a whole" },
                    { new Guid("d510650d-5921-41d8-97b3-f46e150633be"), "O.84.21", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Foreign affairs" },
                    { new Guid("47340c13-06f3-4b83-9be7-b94035139773"), "O.84.22", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Defence activities" },
                    { new Guid("ea85e3b3-c874-410d-96c8-b67e33b23259"), "O.84.23", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Justice and judicial activities" },
                    { new Guid("4e3f6535-f64a-4adb-87c1-b3eb33b9bd78"), "O.84.24", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Public order and safety activities" },
                    { new Guid("8a770f9c-e335-4a7e-b199-460db7022e89"), "O.84.25", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Fire service activities" },
                    { new Guid("783d1f0e-2499-4f84-bc37-0a8b9cc24f73"), "O.84.3", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Compulsory social security activities" },
                    { new Guid("0a67e178-ee37-42fe-bbfa-169eb6ffc29e"), "O.84.30", new Guid("6a5ceda8-0849-488b-9446-84cf0a67501e"), "Compulsory social security activities" },
                    { new Guid("3b6c0085-3452-4504-a40d-4812641d1f4a"), "P.85", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Education" },
                    { new Guid("a9e8b07e-2667-446a-b3c9-1b1a1df75725"), "P.85.1", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Pre-primary education" },
                    { new Guid("52042001-62ad-4cb8-858e-814aa05190d1"), "P.85.10", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Pre-primary education" },
                    { new Guid("74cd388d-abbb-42db-8cd0-6b14a7b96b37"), "P.85.2", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("707afe99-92ac-461b-b291-c84855f759c2"), "P.85.20", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Primary education" },
                    { new Guid("7897298c-db23-42b6-94d0-185551205fb4"), "P.85.3", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Secondary education" },
                    { new Guid("21e8c316-3e7d-4217-b914-616cc7acc20e"), "P.85.31", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "General secondary education" },
                    { new Guid("3beec49a-b7ea-4425-a3ec-74d0b0051e87"), "P.85.32", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Technical and vocational secondary education" },
                    { new Guid("0b35e1c4-d50a-42df-95ad-4c56c80dbe50"), "P.85.4", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Higher education" },
                    { new Guid("f8e5048f-eff0-4e2d-89f3-2906276bbdca"), "P.85.41", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Post-secondary non-tertiary education" },
                    { new Guid("b6f3394f-3c98-4d89-945c-7613d89c291e"), "P.85.42", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Tertiary education" },
                    { new Guid("9c598099-d170-4151-927e-1696bf255047"), "P.85.5", new Guid("7f798401-9e58-4716-ae66-6dff475a128d"), "Other education" },
                    { new Guid("81611994-bf16-4761-b421-ab1a024ed633"), "R.90", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Creative, arts and entertainment activities" },
                    { new Guid("617d795f-f8f1-4724-a74c-1be554a4d8bf"), "N.82.92", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("19b2c4c3-9ede-4a8a-a227-1de5d44ef1c7"), "R.90.0", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Creative, arts and entertainment activities" },
                    { new Guid("e19f59ec-d16d-427b-af26-1734477c6576"), "R.90.02", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Support activities to performing arts" },
                    { new Guid("5ced4de7-4b3b-4830-bc04-c0b6f04d0e62"), "S.95.1", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of computers and communication equipment" },
                    { new Guid("e4779476-58fe-4093-b354-12d0ae6c0040"), "S.95.11", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of computers and peripheral equipment" },
                    { new Guid("56ff9392-f5f8-4acc-be99-67cf2fe095b1"), "S.95.12", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of communication equipment" },
                    { new Guid("7ef4f987-b599-4a86-a81a-b13b50ccb97c"), "S.95.2", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of personal and household goods" },
                    { new Guid("3ae0251d-e72d-4aac-8487-c2861b4c0d47"), "S.95.21", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of consumer electronics" },
                    { new Guid("707da878-5804-4fc3-9205-0f21f1822b0b"), "S.95.22", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("895aaba6-ebd3-4004-9a1c-d9b8f453b3e9"), "S.95.23", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of footwear and leather goods" },
                    { new Guid("a7026470-2fb8-4261-9815-f2ada91d6c04"), "S.95.24", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of furniture and home furnishings" },
                    { new Guid("be9e59b2-e06e-40e6-8ace-a557b711f230"), "S.95.25", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of watches, clocks and jewellery" },
                    { new Guid("403f4892-0b41-498c-8097-9ec4b19c9d27"), "S.95.29", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of other personal and household goods" },
                    { new Guid("bf42eb77-3d45-4c57-bee5-8d6258fb5c4c"), "S.96", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Other personal service activities" },
                    { new Guid("c309c056-9622-4251-89a2-705f60a53fd2"), "S.96.0", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Other personal service activities" },
                    { new Guid("63f2caef-feeb-4b41-9f68-6337d05fb9cb"), "S.95", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Repair of computers and personal and household goods" },
                    { new Guid("c5af7607-ccba-41f1-a5ab-3c0c8d9b4133"), "S.96.01", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("8e048d7d-63a1-460d-ad7b-7591c28d3293"), "S.96.03", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Funeral and related activities" },
                    { new Guid("1d0a3adb-7ce1-4be1-b05e-cca5eb3874b8"), "S.96.04", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Physical well-being activities" },
                    { new Guid("17e74291-0023-49d3-a930-5c1c072a0e11"), "S.96.09", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Other personal service activities n.e.c." },
                    { new Guid("7890d81c-23cd-427d-a2a5-7315c779a564"), "T.97", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Activities of households as employers of domestic personnel" },
                    { new Guid("80581422-790c-45f5-8df9-b17db978c376"), "T.97.0", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Activities of households as employers of domestic personnel" },
                    { new Guid("b891db8c-933c-4cca-ae1d-e925e4ab3229"), "T.97.00", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Activities of households as employers of domestic personnel" },
                    { new Guid("f008e50f-31a0-4b41-96ad-182ffa8d8e2f"), "T.98", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("ca3ae7b8-c087-4659-9ab8-4fbdff345126"), "T.98.1", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("5ac371f6-201f-452b-8ab4-34326851ca88"), "T.98.10", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("f073d59d-fed7-4adb-99ef-61e48be1cb12"), "T.98.2", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("7bea8fd6-0083-41af-9f07-6ff75cdc0f56"), "T.98.20", new Guid("741edf64-a06f-4bc0-81d6-65745b084f86"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("ed40a60b-dbb5-4598-9a98-0ecaea2ff299"), "U.99", new Guid("1ed48518-10cc-4ce8-9821-464f819882c7"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("cf84ad1c-b37e-4d8b-a734-9e3277144747"), "S.96.02", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Hairdressing and other beauty treatment" },
                    { new Guid("cd842377-cf53-4447-8f6f-0f6c370cbe7d"), "S.94.99", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of other membership organisations n.e.c." },
                    { new Guid("a4dcccec-6f96-4aa1-a447-d9a881d356db"), "S.94.92", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of political organisations" },
                    { new Guid("ab40d24b-153f-4c4f-a2ae-23ae57a0b1a6"), "S.94.91", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f8297274-da53-4390-b776-f54ef2ad5d86"), "R.90.03", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Artistic creation" },
                    { new Guid("f0f1d90e-4338-494f-87a3-355cbebeb966"), "R.90.04", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Operation of arts facilities" },
                    { new Guid("3ca73897-b8e9-46fb-9f5a-1ce31494e885"), "R.91", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("c20f9b25-d2b0-4bdc-a3da-e3b5fb1a0f04"), "R.91.0", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("1c469aa7-bfd4-4ff4-bf3d-85d1e63aa7e4"), "R.91.01", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Library and archives activities" },
                    { new Guid("b9d03bc4-f1c9-4d01-a9f3-ff4190fc9087"), "R.91.02", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Museums activities" },
                    { new Guid("c03f0653-832a-43c1-a92e-bceb5b1baa46"), "R.91.03", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("512f9c20-a302-4c14-a9e4-8356980a48bb"), "R.91.04", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("434b713d-d603-42e3-9504-d68cb6672d55"), "R.92", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Gambling and betting activities" },
                    { new Guid("1d32426d-62e6-4c4f-a230-43d7361abcea"), "R.92.0", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Gambling and betting activities" },
                    { new Guid("1c223980-d716-454b-820c-bf216ce8ba14"), "R.92.00", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Gambling and betting activities" },
                    { new Guid("0c974652-a7c6-4f63-ad03-8223d6395a9a"), "R.93", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Sports activities and amusement and recreation activities" },
                    { new Guid("fe5a91d7-6d5b-45d5-b380-15e21797a678"), "R.93.1", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Sports activities" },
                    { new Guid("69ecb64b-42ab-4c89-a362-ca9839bd1849"), "R.93.11", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Operation of sports facilities" },
                    { new Guid("03fe9a1a-37f1-49ef-afde-68aa9c562b93"), "R.93.12", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Activities of sport clubs" },
                    { new Guid("093b4666-645a-41f7-af67-cd90edb03074"), "R.93.13", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Fitness facilities" },
                    { new Guid("67980ff9-986e-4a92-ab13-9b6c6b0c99c0"), "R.93.19", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Other sports activities" },
                    { new Guid("d3308555-691b-4fd9-9652-2425416cefeb"), "R.93.2", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Amusement and recreation activities" },
                    { new Guid("c2589475-3f4f-4c9e-81e2-5769f6fa1d05"), "R.93.21", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Activities of amusement parks and theme parks" },
                    { new Guid("539114ee-3551-4e5c-bd32-36fcde0ea8f1"), "R.93.29", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Other amusement and recreation activities" },
                    { new Guid("eb5bb1aa-4e6e-4106-b6ed-4d842af13f6c"), "S.94", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of membership organisations" },
                    { new Guid("5f0ba13d-7175-4ed2-9df3-e2a9c0eddc96"), "S.94.1", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("4fe5a6c9-696d-4058-b9f2-bb6cbdeb6242"), "S.94.11", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of business and employers membership organisations" },
                    { new Guid("1542245a-5d79-486e-9575-eb64b7e121f5"), "S.94.12", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of professional membership organisations" },
                    { new Guid("93b3ac91-90db-4d7d-b65c-887fce203304"), "S.94.2", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of trade unions" },
                    { new Guid("7276e976-ed1e-4998-956a-34e8911b6f4b"), "S.94.20", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of trade unions" },
                    { new Guid("33277496-8b4a-45c6-bb15-1a3a43c5c4a7"), "S.94.9", new Guid("0e028338-0812-417f-94fe-369ba81529c6"), "Activities of other membership organisations" },
                    { new Guid("2c500ccc-c66d-45f3-b76a-f8ca7019b4b4"), "R.90.01", new Guid("c2270634-960c-4b8d-b99f-66873adbb525"), "Performing arts" },
                    { new Guid("14effffd-2082-4ffb-af88-b3d39e24cde1"), "K.65", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("91482be4-9ac9-4e72-be4c-39c565603850"), "N.82.9", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Business support service activities n.e.c." },
                    { new Guid("206b7572-2e99-4c19-8007-db04288b9f91"), "N.82.3", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Organisation of conventions and trade shows" },
                    { new Guid("599b65d8-195b-4da5-8ee1-bf175084a327"), "M.70.1", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Activities of head offices" },
                    { new Guid("e33b02d2-a388-48ea-ab7a-a37f7e6e544f"), "M.70.10", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Activities of head offices" },
                    { new Guid("c6473400-7c48-4173-b643-cab492c60878"), "M.70.2", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Management consultancy activities" },
                    { new Guid("8b2b1077-9c22-4682-bbe3-32cdb80a8a7c"), "M.70.21", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Public relations and communication activities" },
                    { new Guid("3028e234-b463-4d42-a6b5-5c237cd3ccee"), "M.70.22", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Business and other management consultancy activities" },
                    { new Guid("2ed7201c-1e6b-4dba-a087-bfe22fefa7ab"), "M.71", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("6ec7b335-250a-4d38-9c0d-4a8da09466d6"), "M.71.1", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("afcbe857-f3c2-4380-bbbc-8f245bafa9b7"), "M.71.11", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Architectural activities" },
                    { new Guid("0cad0520-3bad-42f6-8d43-0cad6d1b1e7c"), "M.71.12", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Engineering activities and related technical consultancy" },
                    { new Guid("2336ce3f-f175-4318-b4b7-fc7776e2a5dc"), "M.71.2", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Technical testing and analysis" },
                    { new Guid("a4fcc5b4-e52c-49ac-8cce-09db3eaf3124"), "M.71.20", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1ffa1f6a-7b19-44c6-a34a-a5e431bbfda5"), "M.72", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Scientific research and development" },
                    { new Guid("eefa9036-11d4-4019-9ecd-07c98116aca0"), "M.70", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Activities of head offices; management consultancy activities" },
                    { new Guid("8e474d14-ff77-4caa-9282-afadd537e097"), "M.72.1", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("8a06467b-008f-486e-b47c-c39063b292dd"), "M.72.19", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("eac1bbf1-f63b-44c5-b007-9dd1d64493c8"), "M.72.2", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("ecf41c25-c7f6-4a91-ae8f-f48b6060be24"), "M.72.20", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("ba59f062-b565-4890-9b70-90c8f7e673d9"), "M.73", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Advertising and market research" },
                    { new Guid("8812e972-4e22-460a-a7db-e2adad551aff"), "M.73.1", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Advertising" },
                    { new Guid("f8e35fb6-66b2-44f0-a008-217fc0830d6e"), "M.73.11", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Advertising agencies" },
                    { new Guid("fe5677c8-fb9e-4131-a2f3-d10fad9d9126"), "M.73.12", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Media representation" },
                    { new Guid("8d7608ee-3f1b-4914-9b4a-44a08fdd4ab9"), "M.73.2", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Market research and public opinion polling" },
                    { new Guid("e4cc6ae7-41be-475d-a1d1-01fa9556b7f1"), "M.73.20", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Market research and public opinion polling" },
                    { new Guid("36d9fdb8-2452-4283-8282-4b612c9cd4d4"), "M.74", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Other professional, scientific and technical activities" },
                    { new Guid("24131725-d2f1-4c5e-bab1-48c36ff2f5f1"), "M.74.1", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Specialised design activities" },
                    { new Guid("f5878db3-fb36-4eac-9e0d-c711aa806d51"), "M.74.10", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Specialised design activities" },
                    { new Guid("8add7f0d-dd16-4d1f-9c6b-394878fae2f0"), "M.72.11", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Research and experimental development on biotechnology" },
                    { new Guid("53129aa7-97ac-42a4-8543-c43d6da5e7bf"), "M.69.20", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("8e9c9205-5fd9-4b32-9237-73aac322ea23"), "M.69.2", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("74d34bd3-bb6b-4032-8507-ac069e754ed4"), "M.69.10", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Legal activities" },
                    { new Guid("643bfbce-92cf-4897-a651-b96042b74881"), "K.65.11", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Life insurance" },
                    { new Guid("9ec0e00b-36de-48a8-ab4a-a3aa5e846dd0"), "K.65.12", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Non-life insurance" },
                    { new Guid("868a0da3-ccff-4923-b02b-06e742fe60df"), "K.65.2", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Reinsurance" },
                    { new Guid("038ca787-0c90-4673-a7a5-cb089beebac4"), "K.65.20", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Reinsurance" },
                    { new Guid("c7f726e2-6d71-4550-835d-a94b70de4bbe"), "K.65.3", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Pension funding" },
                    { new Guid("080d1c66-2245-41c4-92f1-768e6ed99e6d"), "K.65.30", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Pension funding" },
                    { new Guid("45645795-9660-4e4e-906a-ede521ff722f"), "K.66", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("e7307402-6956-40a2-a5db-eb597c724c76"), "K.66.1", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("9055c8fe-53f0-4f6c-9b9d-e9f79858df6f"), "K.66.11", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Administration of financial markets" },
                    { new Guid("c40cfd6e-3e49-4a4e-9aa0-10a6b8c5e59e"), "K.66.12", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Security and commodity contracts brokerage" },
                    { new Guid("e090ce54-206c-4a80-a769-f521e18a8fa1"), "K.66.19", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("3e804413-504f-487e-bc7f-211e895e22df"), "K.66.2", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("1404ea8a-ecf8-43b6-a0ed-09acfe9e4ba9"), "K.66.21", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Risk and damage evaluation" },
                    { new Guid("9de9aa3d-6d80-4dd7-8138-9d7c1bde99e4"), "K.66.22", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Activities of insurance agents and brokers" },
                    { new Guid("b9bb9001-aa2e-462e-98fe-d2da3917f797"), "K.66.29", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("e64a08e2-d4df-4b5d-a132-e8ff7566cede"), "K.66.3", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Fund management activities" },
                    { new Guid("4c3bd163-1729-45de-ad17-99ee692bace0"), "K.66.30", new Guid("5bcbb638-4c03-4303-a5a1-01341d71d8bb"), "Fund management activities" },
                    { new Guid("db2671be-4ffc-461c-afc3-4734a02b8c56"), "L.68", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Real estate activities" },
                    { new Guid("34b8d9c0-53e3-4d70-89ec-eca13f4560c8"), "L.68.1", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Buying and selling of own real estate" },
                    { new Guid("bb66b174-4d83-4680-80e1-bb358dcc01a5"), "L.68.10", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Buying and selling of own real estate" },
                    { new Guid("441e3d87-09fb-431a-bdbb-8be59bd38ed5"), "L.68.2", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Renting and operating of own or leased real estate" },
                    { new Guid("9ecaf532-40f8-4610-896f-3f260a2e902f"), "L.68.20", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Renting and operating of own or leased real estate" },
                    { new Guid("b8cb6bea-46f4-4919-95e8-b625ef09e9eb"), "L.68.3", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("102e8606-d1eb-4046-88e9-e29d9ef2c2ec"), "L.68.31", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Real estate agencies" },
                    { new Guid("947681d3-768b-42b0-9ba2-1374c2fc3bdf"), "L.68.32", new Guid("dbc78fd1-8b42-4fb3-ba83-867db2bc39a5"), "Management of real estate on a fee or contract basis" },
                    { new Guid("ebadbf14-cbed-4298-9fbf-47e90b466c13"), "M.69", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Legal and accounting activities" },
                    { new Guid("956d7f03-a1e1-467a-83b9-1b5a9fc26412"), "M.69.1", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Legal activities" },
                    { new Guid("7c9f4b92-8363-4cf2-bf7b-baef214e41f0"), "M.74.2", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Photographic activities" },
                    { new Guid("084ec1db-4051-405f-ad6b-14478fd79219"), "N.82.30", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Organisation of conventions and trade shows" },
                    { new Guid("d8f9263c-07a8-4fba-9119-351848c20394"), "M.74.20", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Photographic activities" },
                    { new Guid("87c64406-f694-4c0c-afcb-4c74396c6c51"), "M.74.30", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Translation and interpretation activities" },
                    { new Guid("3aefde6d-96f5-4f3a-86a8-f54b1b11a4ca"), "N.79.11", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Travel agency activities" },
                    { new Guid("deb422d2-fc6c-4379-93ec-ffe6f9b65093"), "N.79.12", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Tour operator activities" },
                    { new Guid("46a66f42-cf13-40e9-9db4-f547910dffab"), "N.79.9", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other reservation service and related activities" },
                    { new Guid("7f2c05de-8971-4c8a-bdb8-d1d9f1be747c"), "N.79.90", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other reservation service and related activities" },
                    { new Guid("0da4d5f0-2043-4a7a-9395-3db257a712e8"), "N.80", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Security and investigation activities" },
                    { new Guid("f9e3b124-dd92-4acc-b977-a4509793a1b7"), "N.80.1", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Private security activities" },
                    { new Guid("5b8c067d-bc1e-42cb-a160-87b6ee57079c"), "N.80.10", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Private security activities" },
                    { new Guid("15358479-2090-4cef-a09c-34a24a2f4b01"), "N.80.2", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Security systems service activities" },
                    { new Guid("0bef8e0f-7367-4775-ba2d-5038df0cd08c"), "N.80.20", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Security systems service activities" },
                    { new Guid("fc2a94c3-4503-426c-abd5-46854b1c02e4"), "N.80.3", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Investigation activities" },
                    { new Guid("7ff93bd2-c9e9-405c-bce3-b774440d7166"), "N.80.30", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Investigation activities" },
                    { new Guid("d7316612-9d5c-410d-999c-a9a0499371c3"), "N.81", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Services to buildings and landscape activities" },
                    { new Guid("3b8ebaa6-312e-4cbf-be71-8eda8b215e75"), "N.79.1", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Travel agency and tour operator activities" },
                    { new Guid("2e222b44-5724-415c-a107-45c7db3729fe"), "N.81.1", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Combined facilities support activities" },
                    { new Guid("45417c78-638b-45bb-86cf-96a1d967d885"), "N.81.2", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Cleaning activities" },
                    { new Guid("5e0979c4-b05f-4589-956b-94291a3859b4"), "N.81.21", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "General cleaning of buildings" },
                    { new Guid("3645cf3d-96eb-42f7-b2ce-cf6e07e9fdc1"), "N.81.22", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other building and industrial cleaning activities" },
                    { new Guid("9c743cf3-938e-4331-837f-a02bb13f00f3"), "N.81.29", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other cleaning activities" },
                    { new Guid("12729526-2348-4679-ae2b-a2b8ac55ec9a"), "N.81.3", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Landscape service activities" },
                    { new Guid("51b0370a-cdba-4ddc-aac4-654252b7f6dc"), "N.81.30", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Landscape service activities" },
                    { new Guid("2be53632-df27-4ca8-9ecf-70c9929a07dd"), "N.82", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Office administrative, office support and other business support activities" },
                    { new Guid("acfb4730-13fc-4cd2-8b2e-429d1173fb3a"), "N.82.1", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Office administrative and support activities" },
                    { new Guid("edae3874-8534-4e0f-9831-35fee1f453b9"), "N.82.11", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Combined office administrative service activities" },
                    { new Guid("90f02b4b-7234-4772-9c8a-ac87a2dfc021"), "N.82.19", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("4324bdb1-7fc4-4cf0-b735-a7afcdd39a9c"), "N.82.2", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Activities of call centres" },
                    { new Guid("431a609a-4c35-436a-8a98-ec54f3678af6"), "N.82.20", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Activities of call centres" },
                    { new Guid("442ece0e-196f-4e53-8682-d34d1ac2d6b0"), "N.81.10", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Combined facilities support activities" },
                    { new Guid("df502c6b-5de6-4a49-80d7-b12d1e7c1f35"), "N.79", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("014c70d8-168a-412e-a2b0-a8dff003c869"), "N.78.30", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other human resources provision" },
                    { new Guid("0e222f16-c53e-42bb-9472-38437ac964fe"), "N.78.3", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Other human resources provision" },
                    { new Guid("4319bc27-9ba9-446a-b3c8-da1bfe62363e"), "M.74.9", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("56f1ccec-ae91-4d51-b69c-564a18008ebc"), "M.74.90", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("627bfe7c-9d03-43d7-8f37-3e22d1d60599"), "M.75", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Veterinary activities" },
                    { new Guid("980370ad-b8c8-41bc-9223-39a938c03d41"), "M.75.0", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c69e6da2-170f-425d-863f-9ea1e6e17127"), "M.75.00", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Veterinary activities" },
                    { new Guid("607b65ab-6417-463d-8e2f-50dbdf0b38a0"), "N.77", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Rental and leasing activities" },
                    { new Guid("bbd5d85d-af14-4583-ac63-af557db6d6b0"), "N.77.1", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of motor vehicles" },
                    { new Guid("746a89ed-67cd-442e-81bf-9f41c4299c42"), "N.77.11", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("5f797680-25a9-4925-a399-0fd39f3635c9"), "N.77.12", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of trucks" },
                    { new Guid("15516537-f060-4712-9acb-3fcac40acdee"), "N.77.2", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of personal and household goods" },
                    { new Guid("4d25b470-a368-404f-bb3f-7fb6724daa3f"), "N.77.21", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("5aa70b17-3092-402f-8a83-e5aafab0fd30"), "N.77.22", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting of video tapes and disks" },
                    { new Guid("a0e8a069-7686-4b90-bc2a-e5a69e290377"), "N.77.29", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of other personal and household goods" },
                    { new Guid("314fc24f-d41d-46d8-b410-22a17fc7bd02"), "N.77.3", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("4336485b-9e17-49ab-8111-61a1becac4c4"), "N.77.31", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("082eb8a8-8765-4d94-81bc-be950a3f43f5"), "N.77.32", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("8f253a89-ee07-404b-a407-9412c26de73f"), "N.77.33", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("c9829d5c-d2e9-430f-adbf-8b8b5621ab73"), "N.77.34", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of water transport equipment" },
                    { new Guid("ec067ef5-874f-49e0-b56c-f69028fc8a0f"), "N.77.35", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of air transport equipment" },
                    { new Guid("a91155c7-e47b-4062-8047-86d048d87c7d"), "N.77.39", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("6f4e45c2-426c-4314-809f-280ef3b9f2ff"), "N.77.4", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("960771d6-461d-4708-91ea-4dd2b628282b"), "N.77.40", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("94501a79-1ea4-4f99-858f-fd7560c11e1c"), "N.78", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Employment activities" },
                    { new Guid("27d71a57-0415-4658-a706-0d46dab31c7e"), "N.78.1", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Activities of employment placement agencies" },
                    { new Guid("569d7c1f-431f-43e9-9b54-dad9674146ca"), "N.78.10", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Activities of employment placement agencies" },
                    { new Guid("8064180a-ae9c-4aed-a1a3-e5fa8790cbe4"), "N.78.2", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Temporary employment agency activities" },
                    { new Guid("c2b78830-f90a-43de-9a60-4c95bb70bcf0"), "N.78.20", new Guid("301f7d19-2d00-4c09-9b51-96a0ce96b6a2"), "Temporary employment agency activities" },
                    { new Guid("4893da7a-e3bf-4f33-9247-6348f6f2c5c4"), "M.74.3", new Guid("5d5573eb-27f2-4c7e-a818-e416321fc8c0"), "Translation and interpretation activities" },
                    { new Guid("c1d6c228-9c7e-4778-95b4-96bdb326166e"), "U.99.0", new Guid("1ed48518-10cc-4ce8-9821-464f819882c7"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9c6296c8-362e-4860-ac70-ea68f974d766"), "F.43.21", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Electrical installation" },
                    { new Guid("056b6f2c-14f5-41e3-986f-dd73a3aa8fc9"), "F.43.13", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Test drilling and boring" },
                    { new Guid("7cd910fd-61a2-4d2b-8f8c-b6045b1e8bd3"), "C.14.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of articles of fur" },
                    { new Guid("24c4ff79-00da-49aa-bf46-d527553d0e34"), "C.14.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of articles of fur" },
                    { new Guid("08a85890-08e2-42e7-8835-2c4e9b97224f"), "C.14.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("f3e06644-2f1c-4254-ac4f-e3c90eedf250"), "C.14.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("b0e25fcd-d836-495b-a48a-7d8cdc9bc6e2"), "C.14.39", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("16b8059e-5a0c-4f44-b384-b5c5e2f180c5"), "C.15", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of leather and related products" },
                    { new Guid("296dba50-68de-4997-af0e-7bc83be2446e"), "C.15.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("398dc708-259b-4ed7-9866-5ae7ea4e66e9"), "C.15.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("01f271d7-4ef3-4dd9-b902-20c26e40b51b"), "C.15.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("2201741f-b100-46b7-b439-eff2e430ff93"), "C.15.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of footwear" },
                    { new Guid("c688d505-532b-492f-b5ea-441e68438ea2"), "C.15.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of footwear" },
                    { new Guid("552c686e-ff23-48c6-9f46-b80b248dbcf2"), "C.16", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("be061435-c280-4e39-8f56-10a67756b4db"), "C.14.19", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("5f6d9135-27b5-4957-b5d0-227d7da5a9c9"), "C.16.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Sawmilling and planing of wood" },
                    { new Guid("f4196fdc-5a57-422a-982d-dc5f52dba80a"), "C.16.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9819ee69-28f7-46d4-bdb1-8aab1cb4f7ff"), "C.16.21", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("35417302-0332-4462-aa6a-baef3cbe9b2e"), "C.16.22", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of assembled parquet floors" },
                    { new Guid("c42266db-8ed8-41d7-878b-cd4959d52e37"), "C.16.23", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("68df1720-32e6-4485-895e-2bb091b19ba5"), "C.16.24", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wooden containers" },
                    { new Guid("5673180a-1796-4e79-b8ae-e57573d17eb9"), "C.16.29", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("5ecb2372-4a8a-4d9f-9c63-453b576b1d74"), "C.17", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of paper and paper products" },
                    { new Guid("59697c0c-897c-4a60-8695-21556ec2888e"), "C.17.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("97d02582-7517-4d98-a4bc-c55f28c7c5bd"), "C.17.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of pulp" },
                    { new Guid("dcebd4a2-fa2f-4ee7-9718-37107d3a3b04"), "C.17.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of paper and paperboard" },
                    { new Guid("8bc0e33b-6da8-451d-9f62-698e82d2f03f"), "C.17.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("c0f83564-3dc3-498e-a92d-6506d3632fee"), "C.17.21", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("5eef877f-eb4e-4717-9d4d-28ff87635141"), "C.16.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Sawmilling and planing of wood" },
                    { new Guid("98287123-6c68-4cd4-83f7-480ce3fcebbf"), "C.14.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of underwear" },
                    { new Guid("81510b33-e3aa-4400-8471-47a7a3e76c1a"), "C.14.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other outerwear" },
                    { new Guid("1b09603c-fac9-480c-9802-b7b2607c2cd7"), "C.14.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of workwear" },
                    { new Guid("802ed4aa-06d1-4fdc-8c4e-445da335cf56"), "C.11.02", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wine from grape" },
                    { new Guid("0edcb4aa-a0e9-421b-b02a-b08d31422288"), "C.11.03", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cider and other fruit wines" },
                    { new Guid("1c741f12-0fbf-45c3-9527-b0aa7cec5c3e"), "C.11.04", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("c66f9c20-bda4-4606-907c-9cb81ec7c819"), "C.11.05", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of beer" },
                    { new Guid("bbf0063c-fc66-414c-872b-3fce41d71f36"), "C.11.06", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of malt" },
                    { new Guid("035f146a-2176-4502-ac39-dd5e3b345bfa"), "C.11.07", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("4cfa71e8-1b09-4440-b0ab-c2a84348034d"), "C.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tobacco products" },
                    { new Guid("c65cecc0-27b3-472b-8bd9-7aba747d0a28"), "C.12.0", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tobacco products" },
                    { new Guid("c3e89864-ca58-4afe-84fd-8a455ea92896"), "C.12.00", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tobacco products" },
                    { new Guid("d6ccc0d0-29a2-4672-be93-e76e7a14f3d0"), "C.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of textiles" },
                    { new Guid("9cb55ce7-7d61-4e76-9d66-b29c0e7eb403"), "C.13.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Preparation and spinning of textile fibres" },
                    { new Guid("df2b47c6-22cf-4458-b66c-444ad13c589e"), "C.13.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Preparation and spinning of textile fibres" },
                    { new Guid("c45f97bf-ca7d-4583-93c0-60390a2e25c5"), "C.13.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Weaving of textiles" },
                    { new Guid("23d0c7f5-f399-4a69-b7c9-4b675da9f0b9"), "C.13.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Weaving of textiles" },
                    { new Guid("d4242c78-1178-414b-8f3c-ef1b94eeebe5"), "C.13.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Finishing of textiles" },
                    { new Guid("3e4bdb21-961d-454c-821a-7d79c47ab171"), "C.13.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Finishing of textiles" },
                    { new Guid("571d161d-e83c-4645-b658-0712d6303030"), "C.13.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other textiles" },
                    { new Guid("8ab32089-e89a-4390-a4a6-c9f0c1ceb153"), "C.13.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("c21c67bf-6304-4f2c-8f05-2f74c86a5170"), "C.13.92", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("086715b3-7a7b-48a5-a00e-822dcd511f7c"), "C.13.93", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of carpets and rugs" },
                    { new Guid("c7cae937-5b96-4ee8-8a91-ad9d1a975519"), "C.13.94", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("76224637-52fb-45bf-a0f2-c4c1a9d0a9ed"), "C.13.95", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("162d3727-7cf4-4d09-a42b-00aaa20f0b6e"), "C.13.96", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("04a9b8ce-98ec-49d9-8209-aa44b95ca643"), "C.13.99", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other textiles n.e.c." },
                    { new Guid("ae033805-efe0-4658-9bef-e437fa6ef368"), "C.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wearing apparel" },
                    { new Guid("7cea6c89-f11d-473c-980b-2c5f27ac2e7a"), "C.14.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("69494993-da24-4523-a9cf-37555dbdb966"), "C.14.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7a4ac521-963d-4c8c-a19f-37cf11fcba55"), "C.17.22", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("29ad3bd6-961b-4c12-9530-10f72cd04397"), "C.11.01", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("455dc546-87a3-402b-a098-9577eb4513be"), "C.17.23", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of paper stationery" },
                    { new Guid("5f09020b-60d6-4322-9bf8-97e1203097aa"), "C.17.29", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("24588c97-5cf5-49b6-bded-7cc284b504c1"), "C.20.52", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of glues" },
                    { new Guid("ce99dc17-d30e-4d94-bdb5-58093e9e2a60"), "C.20.53", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of essential oils" },
                    { new Guid("7dfd507b-2cba-4bb3-b2e9-4e700731dcb5"), "C.20.59", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("87269dbd-f1b1-478c-ad2c-44216590f439"), "C.20.6", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of man-made fibres" },
                    { new Guid("6189756a-5fcb-4b8b-9e1e-db7ef4a6c416"), "C.20.60", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of man-made fibres" },
                    { new Guid("966700fb-561e-472a-ac2e-6d62d26750da"), "C.21", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("6c948392-c696-44c3-9892-1e248940d393"), "C.21.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("ea9f5e5d-c93e-4620-a3d0-a0826e59110d"), "C.21.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("928af809-e4cb-4381-b0fd-416cfd77bd68"), "C.21.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("8de48a46-ed52-4268-ab94-1e45004a1f18"), "C.21.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("9bdad0cd-3816-4acd-8696-dd41392f2a61"), "C.22", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of rubber and plastic products" },
                    { new Guid("f14f5d1f-7871-4df6-ba19-22c1b595da65"), "C.22.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of rubber products" },
                    { new Guid("61728066-e97c-407e-a2d4-c9c02970489d"), "C.20.51", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of explosives" },
                    { new Guid("e4af69e5-b42f-4d63-bd54-d0b380211b13"), "C.22.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("e812d08e-5c1d-4956-9fc6-d41b22e52d18"), "C.22.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of plastics products" },
                    { new Guid("e0602df6-018b-4c87-ba60-dd34d1c5e850"), "C.22.21", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("285d3d1d-3201-4887-a85f-51eb1f0afc78"), "C.22.22", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of plastic packing goods" },
                    { new Guid("3974f76b-9faf-4cf6-a164-3114bb86783d"), "C.22.23", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("6ed4131b-790f-486a-808b-1e77dc30fbdb"), "C.22.29", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other plastic products" },
                    { new Guid("c542e82b-e245-4cf1-9e4f-700e7184b715"), "C.23", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("bcca2b45-279d-4d96-a472-788e0476889f"), "C.23.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of glass and glass products" },
                    { new Guid("c4c59456-c27c-43de-9934-c64ef6d6637f"), "C.23.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of flat glass" },
                    { new Guid("b6a46531-8ec0-497c-ae68-0b2e12b9f31f"), "C.23.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Shaping and processing of flat glass" },
                    { new Guid("9c3b61ec-7dad-430a-90ef-e66d6cb7564c"), "C.23.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of hollow glass" },
                    { new Guid("79bf3051-5384-456a-8cf7-0120a0394173"), "C.23.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of glass fibres" },
                    { new Guid("3a69b5f7-8aa8-4661-8bc7-79e04724304a"), "C.23.19", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("6c01ff5d-2028-4071-a258-aff979dd38ce"), "C.22.19", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other rubber products" },
                    { new Guid("be45f071-9685-47c3-8e57-9f5897540f59"), "C.20.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other chemical products" },
                    { new Guid("ce0fa5ee-b7d0-4676-92cf-2f237f8d2513"), "C.20.42", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("2fcea43e-3c76-4033-89b6-063ff20f3436"), "C.20.41", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("986e85de-ae4b-4665-b9b6-51f59a1de715"), "C.18", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Printing and reproduction of recorded media" },
                    { new Guid("82eeb448-e38c-4e1c-9281-ab19fece3708"), "C.18.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Printing and service activities related to printing" },
                    { new Guid("11cacfe3-e187-4797-9302-b6c646a623b3"), "C.18.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Printing of newspapers" },
                    { new Guid("cdb46715-b863-4183-adb8-94ecb21c62ea"), "C.18.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Other printing" },
                    { new Guid("4473671c-7aa6-4242-8852-cce92bf7d805"), "C.18.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Pre-press and pre-media services" },
                    { new Guid("5f171243-7f96-49a7-a93d-3f05f69829a7"), "C.18.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Binding and related services" },
                    { new Guid("eeb9d908-cb99-4202-864b-f34cff0fcd56"), "C.18.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Reproduction of recorded media" },
                    { new Guid("e3f782cd-03c3-4fab-8b32-757407faa266"), "C.18.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("8e8018c2-6729-4a0e-9c15-8595136fc229"), "C.19", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("d7e9f758-c887-4f26-9c9f-1a210bc83233"), "C.19.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of coke oven products" },
                    { new Guid("08ddf799-721e-48bf-8982-b2f6283d988b"), "C.19.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of coke oven products" },
                    { new Guid("fe6f2b10-e5af-4999-8751-e840f4a39f56"), "C.19.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of refined petroleum products" },
                    { new Guid("cea7fb0b-9a8d-46e6-80ce-cfc10922d0db"), "C.19.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of refined petroleum products" },
                    { new Guid("ac57f2fb-6df4-42f8-8928-461b21fe178e"), "C.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of chemicals and chemical products" },
                    { new Guid("d2628bdc-e4f1-4198-865b-8b1c4a1feba8"), "C.20.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("75a185ba-8ff1-4267-ab74-97e0d842e222"), "C.20.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of industrial gases" },
                    { new Guid("f4faea65-8a7a-469c-ba3b-db173b5e9ca2"), "C.20.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of dyes and pigments" },
                    { new Guid("2ead1acf-94fb-4081-9d84-773207f2920e"), "C.20.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("59f43614-2527-4b99-ba63-5b6cfcf41ba6"), "C.20.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other organic basic chemicals" },
                    { new Guid("2e911806-e715-45a7-92e6-3a1ed2230256"), "C.20.15", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("a406ec64-a8b1-40b7-a14c-a342213e524f"), "C.20.16", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of plastics in primary forms" },
                    { new Guid("70211f62-4cb0-4dac-8b96-31e5d187ce32"), "C.20.17", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("ea339c2f-07ab-4d17-a25b-afbade4f1e37"), "C.20.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("bfda3155-ef20-4260-b15a-71fc090fb9c8"), "C.20.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("455872cc-e2cf-422a-9560-384cdcbcde2f"), "C.20.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("2fc8b19c-7a1b-4c0a-9327-0f0c3dccee50"), "C.20.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("c8c9682d-6a3f-472a-944c-82bc01c408b4"), "C.20.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("75860f15-1f79-4e38-bc94-f5f45147b76f"), "C.17.24", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wallpaper" },
                    { new Guid("8c52ea6d-78d8-4b88-b55a-2fedc4b393b9"), "C.23.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of refractory products" },
                    { new Guid("453596a8-4ef1-4214-926e-9cfe14670a85"), "C.11.0", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of beverages" },
                    { new Guid("0568babc-e0c4-46c2-91a6-eab0e64a8563"), "C.10.92", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of prepared pet foods" },
                    { new Guid("80af5753-1c7c-4255-9b18-769f5df7d67a"), "A.01.6", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("bbc44c24-1e23-4b24-a7f1-442b1c24464e"), "A.01.61", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Support activities for crop production" },
                    { new Guid("268210d5-5b6b-4aa6-ad77-d35d785ed793"), "A.01.62", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Support activities for animal production" },
                    { new Guid("22184603-0f43-42eb-a3f8-b37d9bddd8fd"), "A.01.63", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Post-harvest crop activities" },
                    { new Guid("18a8a53b-7b66-4c04-aef5-30ca29d4607f"), "A.01.64", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Seed processing for propagation" },
                    { new Guid("2b89a1b3-9c62-4c0f-803b-c716f26b634a"), "A.01.7", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Hunting, trapping and related service activities" },
                    { new Guid("b237dba1-a69f-42f6-ae0b-7141269c8aa0"), "A.01.70", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Hunting, trapping and related service activities" },
                    { new Guid("4faefddc-21a0-470f-8ccb-b1f5f0e81b22"), "A.02", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Forestry and logging" },
                    { new Guid("74057547-21c0-4827-8a2c-6e02f81e9455"), "A.02.1", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Silviculture and other forestry activities" },
                    { new Guid("3b360661-0575-4d1c-8c05-670461f8cf92"), "A.02.10", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Silviculture and other forestry activities" },
                    { new Guid("9be7093a-4ff9-403e-bec9-e93881db9bc9"), "A.02.2", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Logging" },
                    { new Guid("0c10d125-baa8-457b-afcf-bf0deff6ea77"), "A.02.20", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Logging" },
                    { new Guid("17498dc5-f1c2-4519-8a37-7e1316808714"), "A.01.50", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Mixed farming" },
                    { new Guid("fb12a6b2-23d2-4e17-9655-39db5b3388e1"), "A.02.3", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Gathering of wild growing non-wood products" },
                    { new Guid("2eafb2a6-3b78-4579-9c58-578af588725a"), "A.02.4", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Support services to forestry" },
                    { new Guid("b75161f9-2c5f-4a11-9ce9-9eb9e3c183ae"), "A.02.40", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Support services to forestry" },
                    { new Guid("388ed173-c9cb-4914-96a2-95f90912f958"), "A.03", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Fishing and aquaculture" },
                    { new Guid("5136c7bc-fcd6-4fd1-8d0e-4dba18d7a0f9"), "A.03.1", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Fishing" },
                    { new Guid("8762ea49-15c9-4561-82d7-9820a6c84d92"), "A.03.11", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c1042c63-a84e-4383-a583-6f1a956bdc09"), "A.03.12", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Freshwater fishing" },
                    { new Guid("09bb54b4-9455-4b75-aabd-a3985e25b070"), "A.03.2", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Aquaculture" },
                    { new Guid("36951c5c-a0cb-45ce-bad2-94bdd352ddd3"), "A.03.21", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Marine aquaculture" },
                    { new Guid("9b600442-3630-4684-96f1-0adc0bc489ce"), "A.03.22", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Freshwater aquaculture" },
                    { new Guid("6ad7eadc-bd4b-4df6-a2a8-c5a088ae8418"), "B.05", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of coal and lignite" },
                    { new Guid("20436b54-08b5-4b96-871b-154facf628a0"), "B.05.1", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of hard coal" },
                    { new Guid("60f5c07b-fab2-470d-9152-d2d51755b4a4"), "B.05.10", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of hard coal" },
                    { new Guid("f088ecc5-7c72-4ad6-9e7c-9b26c8af55eb"), "A.02.30", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Gathering of wild growing non-wood products" },
                    { new Guid("dd7bb56a-addd-46ac-8246-d5d9dce1465f"), "A.01.5", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Mixed farming" },
                    { new Guid("e3f95572-6c9d-4fe7-9e2a-c9a75b0dc809"), "A.01.49", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of other animals" },
                    { new Guid("48caad08-b993-4da0-9b23-7e6912bd065f"), "A.01.47", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of poultry" },
                    { new Guid("dccf39bc-6b60-4eb7-85cd-ded0954f7edd"), "A.01.1", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of non-perennial crops" },
                    { new Guid("33c36d61-afd4-4666-965b-df83aa22c2c4"), "A.01.11", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("8cc4ec31-f960-40ff-a648-a41ee593f3c9"), "A.01.12", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of rice" },
                    { new Guid("b8c40143-8e0c-463d-867f-0df920518f32"), "A.01.13", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("941f31b0-15fe-4cbd-b9ae-446190edf485"), "A.01.14", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of sugar cane" },
                    { new Guid("4073ae15-4c39-4ce2-9522-e9a5bba63d54"), "A.01.15", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of tobacco" },
                    { new Guid("db31fc95-a3e3-4689-9948-8f97cc5bd69b"), "A.01.16", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of fibre crops" },
                    { new Guid("ceab1d55-e5d8-4621-b339-0054e04bc302"), "A.01.19", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of other non-perennial crops" },
                    { new Guid("14acaa55-a49c-4ffd-8cb9-8ebc21bd983d"), "A.01.2", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of perennial crops" },
                    { new Guid("a2adb2a8-8f06-4950-b651-3929d3e96331"), "A.01.21", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of grapes" },
                    { new Guid("52f77b7a-fe19-49ce-8fbb-e5d0e25183bf"), "A.01.22", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of tropical and subtropical fruits" },
                    { new Guid("da8886e1-e8f5-41eb-84c7-332285cfa362"), "A.01.23", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of citrus fruits" },
                    { new Guid("a86060e3-cf67-4173-9792-3f71b1261ca2"), "A.01.24", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of pome fruits and stone fruits" },
                    { new Guid("a8780ecc-659b-4cb9-a613-130e38d248fd"), "A.01.25", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("4e9b4ee5-5218-4464-b471-ca3399a73cf0"), "A.01.26", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of oleaginous fruits" },
                    { new Guid("43c90355-ab93-433d-bbf1-a677e9bc5b93"), "A.01.27", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of beverage crops" },
                    { new Guid("556f4a5b-c9ff-49d6-adf5-b564d7653baa"), "A.01.28", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("00481f02-5b95-4c54-85da-3c938650c5e7"), "A.01.29", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Growing of other perennial crops" },
                    { new Guid("347ecd64-cbae-4ad0-847b-b9e91cef6edd"), "A.01.3", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Plant propagation" },
                    { new Guid("8caa0ed2-cbf9-43d5-94c1-e2568de7217c"), "A.01.30", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Plant propagation" },
                    { new Guid("8345a773-78f0-4d18-8d65-b189364de849"), "A.01.4", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Animal production" },
                    { new Guid("038f2585-c920-4b05-9db4-8d95250edab6"), "A.01.41", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of dairy cattle" },
                    { new Guid("bcfdb68a-fce9-424e-a640-37eef6a74bd2"), "A.01.42", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of other cattle and buffaloes" },
                    { new Guid("c2475210-2c9f-474a-a8c1-8015bc833ea9"), "A.01.43", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of horses and other equines" },
                    { new Guid("96c849b2-c284-406e-afc3-7447cb9d2552"), "A.01.44", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of camels and camelids" },
                    { new Guid("782b3431-e6d2-4ce6-bd05-e2a754343f7d"), "A.01.45", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of sheep and goats" },
                    { new Guid("3689f2e0-7785-422d-b9b0-82b9bf3283a9"), "A.01.46", new Guid("4428c474-1a95-4517-b58a-8bc5051944a8"), "Raising of swine/pigs" },
                    { new Guid("b3bb586b-a1cf-4e39-a913-a10739512191"), "B.05.2", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of lignite" },
                    { new Guid("8458486e-b8d4-449c-bbe9-249ff18d78d6"), "C.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of beverages" },
                    { new Guid("53766679-2602-418f-a0de-3f25876ee3a8"), "B.05.20", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of lignite" },
                    { new Guid("4abba047-0622-46d7-b421-62ef8c045b41"), "B.06.1", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("06e3cb95-46c6-48c4-9feb-a74c97d68f2e"), "C.10.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of potatoes" },
                    { new Guid("457e709f-a3ca-407e-bcc5-0bc26f07dd6a"), "C.10.32", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("b9deaf29-e378-4433-a3cc-7a4d32644626"), "C.10.39", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("42dea2be-f747-4d1c-bcd9-ba7398884d55"), "C.10.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("d23fc8fc-0341-47b6-8df6-21e8dd85b371"), "C.10.41", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of oils and fats" },
                    { new Guid("efc36a00-8181-4359-bb5a-13fce6646519"), "C.10.42", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("ee18f704-f6af-4d98-a15b-6d4dc718dca0"), "C.10.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of dairy products" },
                    { new Guid("33206247-7193-4113-beb0-afdeb10228d9"), "C.10.51", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Operation of dairies and cheese making" },
                    { new Guid("5e8463d8-7a2b-492f-9a14-33ba3279313e"), "C.10.52", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ice cream" },
                    { new Guid("c92cba2a-9bef-4524-8e68-311850b6ca3e"), "C.10.6", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("9736e19b-38aa-412f-97ff-e0525bbc3dff"), "C.10.61", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of grain mill products" },
                    { new Guid("5d54fc33-8730-417a-ac38-21c3618278cc"), "C.10.62", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of starches and starch products" },
                    { new Guid("d7c8ea8d-43ab-4fdc-bcb1-5e679593859e"), "C.10.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("8257be02-ddc7-4925-a4ea-fe15afffede1"), "C.10.7", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("d3702c71-79dd-4eca-adbf-c4e32bfbffaf"), "C.10.72", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("c1665ad8-0c26-41c5-b4a3-43b4175ed9a1"), "C.10.73", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("a0a4cbe9-238a-4a99-821a-16ce8c2bf78e"), "C.10.8", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other food products" },
                    { new Guid("b906c3da-5128-41c0-8da1-7ad237faa69f"), "C.10.81", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of sugar" },
                    { new Guid("bbdc48ad-e269-400c-9f4a-7c3f2392b5f8"), "C.10.82", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("f28369a1-218e-459b-8647-01f89d7c6153"), "C.10.83", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing of tea and coffee" },
                    { new Guid("896cc782-ee13-4908-910c-346384b2d152"), "C.10.84", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of condiments and seasonings" },
                    { new Guid("4b8f372f-3a77-491f-a7e3-aea0b691de75"), "C.10.85", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of prepared meals and dishes" },
                    { new Guid("c8cb4125-08b3-4dc6-a54a-e306c55b5969"), "C.10.86", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("660fa654-4ce2-4cd9-b5c5-e226bf34474f"), "C.10.89", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other food products n.e.c." },
                    { new Guid("c9dc0418-f2cc-4ccf-a834-549abf3e1e64"), "C.10.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of prepared animal feeds" },
                    { new Guid("8532471f-65fd-46ac-82f7-4d401498a771"), "C.10.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("33c4ae72-4e6e-4c0d-b9e3-1cc58f439684"), "C.10.71", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("de78d7af-7c21-4ee0-adfd-8de0c248df31"), "C.10.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("a6d11a05-ecbd-4ed5-9e06-e4d489dc867d"), "C.10.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("1da0b9f0-471b-469a-a177-0cbd1593cd0a"), "C.10.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Production of meat and poultry meat products" },
                    { new Guid("ecdf3de2-8705-442d-9e53-c12955a7b268"), "B.06.10", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of crude petroleum" },
                    { new Guid("09820a2b-31b7-49f1-8604-5d4d1ced00d3"), "B.06.2", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of natural gas" },
                    { new Guid("89d62622-3ac9-4ab7-96d4-b1a766796d02"), "B.06.20", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of natural gas" },
                    { new Guid("24d007a9-26a3-4605-bc7d-95c9176d9717"), "B.07", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of metal ores" },
                    { new Guid("f94c9cc4-9873-432b-9922-9f4398706b01"), "B.07.1", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of iron ores" },
                    { new Guid("928b5711-edfe-4fe2-8bca-ad4e6637e85b"), "B.07.10", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of iron ores" },
                    { new Guid("0658b358-3d2d-4a07-842a-e388a6010e3e"), "B.07.2", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of non-ferrous metal ores" },
                    { new Guid("77cf7795-d6a3-4622-b713-a5a906c3a929"), "B.07.21", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of uranium and thorium ores" },
                    { new Guid("c759db0d-be7b-465e-8ef5-70d88c91d971"), "B.07.29", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of other non-ferrous metal ores" },
                    { new Guid("c97b8409-17bb-40c0-888a-3121a81893c2"), "B.08", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Other mining and quarrying" },
                    { new Guid("779b7557-6635-4c47-b7eb-3dcb28834cd5"), "B.08.1", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Quarrying of stone, sand and clay" },
                    { new Guid("0612cbdc-2d0c-44c5-b8b3-b32d931bd4c0"), "B.08.11", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0b78bb60-a1ed-4296-a8c1-146144af49b1"), "B.08.12", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("2ee612d2-76f5-465f-a009-9431bd9df6d7"), "B.08.9", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining and quarrying n.e.c." },
                    { new Guid("387c2f93-541d-4895-a99c-c6ee33320db8"), "B.08.91", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("b5be6c07-6083-41f5-9fd5-db8e398fca69"), "B.08.92", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of peat" },
                    { new Guid("c54bd547-7cfb-4130-9c17-59a706b17843"), "B.08.93", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of salt" },
                    { new Guid("9cdd03db-aca0-4421-8e20-e758985bc041"), "B.08.99", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Other mining and quarrying n.e.c." },
                    { new Guid("03489bb1-a2a2-4e25-8688-a4a86b5a74b4"), "B.09", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Mining support service activities" },
                    { new Guid("ae662791-ae91-4dbb-aa39-5eb022d1a378"), "B.09.1", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("4c3b55f6-6ad5-4317-98f4-6e7aa835ba66"), "B.09.10", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("6e3ca410-985b-422b-82fc-deaacda54cd0"), "B.09.9", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Support activities for other mining and quarrying" },
                    { new Guid("638a054e-a8fd-44fd-a52f-eb7a6da8d38b"), "B.09.90", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Support activities for other mining and quarrying" },
                    { new Guid("69928a80-74fe-479c-9041-0ad425954297"), "C.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of food products" },
                    { new Guid("6070253e-ea46-41ed-b7a1-0c11aaa78d5b"), "C.10.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("68efd64b-5dad-4285-b34e-89bffdb38a77"), "C.10.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of meat" },
                    { new Guid("ef58635e-8079-42aa-a8a6-d5a3e7ad3deb"), "C.10.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing and preserving of poultry meat" },
                    { new Guid("7328502d-2cea-4bf6-81ed-58da148de94a"), "B.06", new Guid("51b5a275-6c94-40f3-9b8c-c0d738748ce5"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("9d654566-5e86-4062-93e4-8a13ed56fc21"), "F.43.2", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("3c0b47b4-318e-46ef-b086-84c2f33b10dc"), "C.23.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of refractory products" },
                    { new Guid("42be0055-ca63-4bc1-9263-f7ef19f86521"), "C.23.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("453cee56-2808-42c9-9898-dfdb9107058e"), "C.30.92", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("34007899-4316-4734-925a-09cc942f13fc"), "C.30.99", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("fc6ec730-977d-4ec7-9bdb-bf86ecb15d4c"), "C.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of furniture" },
                    { new Guid("fdac659d-80d8-4805-ba01-21a261fe7d65"), "C.31.0", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of furniture" },
                    { new Guid("9f47505b-49d5-4830-885d-89b8dda4d023"), "C.31.01", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of office and shop furniture" },
                    { new Guid("1dad0592-b3e9-452f-9929-0449733538e8"), "C.31.02", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of kitchen furniture" },
                    { new Guid("dbf84f1d-3229-4f64-b558-bad8d81f18a7"), "C.31.03", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of mattresses" },
                    { new Guid("82cb1301-1b03-4b17-be46-760313dfa059"), "C.31.09", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other furniture" },
                    { new Guid("4067331f-859a-473a-8972-b4949eae1be6"), "C.32", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Other manufacturing" },
                    { new Guid("82fb7a20-e1b9-445e-ba0d-56ce20021d35"), "C.32.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("96d507ca-7efa-48d4-b7fb-60be1a0e5563"), "C.32.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Striking of coins" },
                    { new Guid("cdf4aa38-260e-46c8-8af8-7c127f3670a1"), "C.32.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of jewellery and related articles" },
                    { new Guid("fd34296e-df0d-410b-8eec-f063614d9fd5"), "C.30.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of motorcycles" },
                    { new Guid("cadf0c6c-395d-4fa3-ba67-9c8fe2d9cc6d"), "C.32.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("0360ac2c-27d7-4fcf-898f-7f596e61d03d"), "C.32.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of musical instruments" },
                    { new Guid("45ff0c16-23e0-4a9a-b20f-f631836914a8"), "C.32.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of sports goods" },
                    { new Guid("5344b391-bdbf-4486-a5c8-61611c0f5f31"), "C.32.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of sports goods" },
                    { new Guid("fcf7236d-690f-42b6-848c-ba2c6d63afb3"), "C.32.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of games and toys" },
                    { new Guid("ee1b7f49-952e-45a9-8bbf-10396b9db968"), "C.32.40", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of games and toys" },
                    { new Guid("a366299b-5ed2-4b47-9fa2-d582abf86480"), "C.32.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("abaad4c7-adbc-4889-90ea-dfa8cc1fc7d5"), "C.32.50", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("54ee548d-39e9-47e0-963b-089dc6222e2e"), "C.32.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacturing n.e.c." },
                    { new Guid("2ce6ef7a-6020-4a39-a2bb-3a0769763abf"), "C.32.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2f75708c-8b8f-41a9-8d64-bb46495f1d7a"), "C.32.99", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Other manufacturing n.e.c." },
                    { new Guid("986dfa07-db45-42d8-bc6b-4f36224f98fd"), "C.33", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair and installation of machinery and equipment" },
                    { new Guid("a9a00dc2-4b04-449e-a9d0-77d1e8a2eeb9"), "C.33.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("e962214c-68dc-4a8e-880e-e8163acffe4d"), "C.32.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of musical instruments" },
                    { new Guid("7c689baa-0ca7-4c57-865d-c9ef59ca5c2f"), "C.30.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("1dead2d0-af89-47eb-9c79-190a6daccb79"), "C.30.40", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of military fighting vehicles" },
                    { new Guid("d3057f50-b360-474a-86d5-a85bf21ec505"), "C.30.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of military fighting vehicles" },
                    { new Guid("e6cc3f99-1a63-4d49-9071-e3b1c105e031"), "C.28.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("3819d20b-fa98-4b34-a0ae-65abc9cb8560"), "C.28.41", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of metal forming machinery" },
                    { new Guid("74f0e683-22fa-4046-bc7a-f3880f00352d"), "C.28.49", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other machine tools" },
                    { new Guid("9fd58ec4-3a69-470f-9eb2-86096b53a45e"), "C.28.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other special-purpose machinery" },
                    { new Guid("52ce33fb-8ac0-4ba6-a555-e351730ab0bf"), "C.28.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of machinery for metallurgy" },
                    { new Guid("c3859b87-b32f-48b8-88f2-49797ec54db8"), "C.28.92", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("fc2329dc-9723-4bb6-bfe5-05d575ccef30"), "C.28.93", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("bc0ec76d-e3d2-404b-8e54-e78bd78c8f70"), "C.28.94", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("685a7c83-ec4a-498c-893e-75d1eebf1769"), "C.28.95", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("a3fb23a1-6b78-4964-951e-3496d5ca66db"), "C.28.96", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("0c7d4739-767e-418f-b546-7564b86b2a5a"), "C.28.99", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("98bab3ca-16d5-4b5b-96b4-6c56218ff965"), "C.29", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("ecf741ac-91b8-4b25-b258-dc85e129163a"), "C.29.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of motor vehicles" },
                    { new Guid("91a2539d-ceb2-43db-a52c-f83693d91ba6"), "C.29.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of motor vehicles" },
                    { new Guid("176cbc77-734e-4177-8edb-ee7cde31e2d3"), "C.29.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("a1bcc9f4-38e0-46d1-9e60-32fe7f431002"), "C.29.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("7f389156-3981-48ae-ba59-d000da629f6a"), "C.29.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("6db4cd8b-2558-4239-ac26-fe1a41caa9d8"), "C.29.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("068e7d8d-4d69-4d45-8cd6-97d47b64a14d"), "C.29.32", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("ead267e4-29eb-4ff0-84f6-99aa1941d681"), "C.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other transport equipment" },
                    { new Guid("cfb7f526-eb2f-4d08-b5ce-2a5585dfe932"), "C.30.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Building of ships and boats" },
                    { new Guid("464655e6-6479-49f3-ae16-87f1e5123ede"), "C.30.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Building of ships and floating structures" },
                    { new Guid("7c1a3b4a-9079-492b-8999-1911311b1ae7"), "C.30.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Building of pleasure and sporting boats" },
                    { new Guid("cde251f2-070e-48e9-abdb-e9fec52346fb"), "C.30.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("bb72e1a2-87e3-4033-8073-712c48d9f428"), "C.30.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("ffa27741-4c71-461f-97fb-cab21cd5302b"), "C.30.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("2c2730f2-0fc1-4a14-b60c-e6f59acc76c5"), "C.30.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("44b5eb00-2bbf-4aba-9c67-0f1579d2077d"), "C.33.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair of fabricated metal products" },
                    { new Guid("3ee7ea19-0e03-4d2f-a046-019758421397"), "C.28.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("b2866676-7c59-4da9-8e6a-6260b6491275"), "C.33.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair of machinery" },
                    { new Guid("7b4f04ba-584c-4690-b11a-2b69847479bc"), "C.33.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair of electrical equipment" },
                    { new Guid("0597aa6d-6239-4b89-b5ca-4abeb6572d4c"), "E.38.3", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Materials recovery" },
                    { new Guid("c9452e8f-271c-4035-9c0c-bad0f1c645c7"), "E.38.31", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Dismantling of wrecks" },
                    { new Guid("31447ca5-ffb0-4865-92f6-e6351c32d164"), "E.38.32", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Recovery of sorted materials" },
                    { new Guid("45bdfe95-a6fd-427f-b81b-9c8a4939e485"), "E.39", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("619ce745-0320-4499-9e7d-81a7106a2bae"), "E.39.0", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Remediation activities and other waste management services" },
                    { new Guid("9cfc8e6e-1005-4597-bbe1-450e8b323adf"), "E.39.00", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Remediation activities and other waste management services" },
                    { new Guid("782d7836-edba-4311-9db9-b497936397a8"), "F.41", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of buildings" },
                    { new Guid("12fa288f-b8e0-4b66-b489-a5c05f69aa81"), "F.41.1", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Development of building projects" },
                    { new Guid("946dc671-9838-4c1f-b239-652462bc8374"), "F.41.10", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Development of building projects" },
                    { new Guid("8c3b6bdc-857f-4450-8767-158094ece785"), "F.41.2", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of residential and non-residential buildings" },
                    { new Guid("fe78d452-72d5-471a-b020-2d62be65fac5"), "F.41.20", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of residential and non-residential buildings" },
                    { new Guid("62cf7994-cbd5-413c-9d62-c5592e870c8b"), "F.42", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Civil engineering" },
                    { new Guid("2c79b735-3b30-4c06-bfd4-9f4f794878c2"), "E.38.22", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Treatment and disposal of hazardous waste" },
                    { new Guid("2bfebce1-be4e-41e6-a144-84eb2c61b5d3"), "F.42.1", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of roads and railways" },
                    { new Guid("ed3f4bc2-5d66-4671-8d8e-5a15e00c82e8"), "F.42.12", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of railways and underground railways" },
                    { new Guid("da17b0ed-e59e-4b24-a129-f3a1e59c23e3"), "F.42.13", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of bridges and tunnels" },
                    { new Guid("874e0004-6a6b-4b74-b9d3-72f1a3011a55"), "F.42.2", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of utility projects" },
                    { new Guid("b1e80920-88d1-4db6-a8b1-e790791c34f5"), "F.42.21", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of utility projects for fluids" },
                    { new Guid("a405f4ec-1a18-4067-ab95-7cc11385eaa8"), "F.42.22", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("42d3503f-f9e5-4c7a-bb92-f0414dd28cba"), "F.42.9", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of other civil engineering projects" },
                    { new Guid("2d22b21b-abac-4cdb-a47a-c8e64ef54ff3"), "F.42.91", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of water projects" },
                    { new Guid("ea912171-daf1-467f-b9bf-eba8c827d22a"), "F.42.99", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("a4d94b4b-fa9b-417b-8547-2f39ed84886d"), "F.43", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Specialised construction activities" },
                    { new Guid("e7d52da4-d14a-43dd-a1b4-841aa59edd84"), "F.43.1", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Demolition and site preparation" },
                    { new Guid("37239318-7664-4af5-b807-95ccd5aba036"), "F.43.11", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Demolition" },
                    { new Guid("b89d7929-3b4b-4fd2-bf19-c03f03c88fa7"), "F.43.12", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Site preparation" },
                    { new Guid("0c638c8b-1846-4481-a667-dd173c53356f"), "F.42.11", new Guid("ec38a06e-4ffd-4212-8f9d-bb7b9f6df81b"), "Construction of roads and motorways" },
                    { new Guid("985ad614-c819-418f-bf9c-1378124227a8"), "E.38.21", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("8313ea1a-cc2b-47dc-a4fa-15b9bca83d34"), "E.38.2", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Waste treatment and disposal" },
                    { new Guid("0db99eec-9f19-4481-830b-cc9d3dc8e12b"), "E.38.12", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Collection of hazardous waste" },
                    { new Guid("20b80b92-2cad-4d79-8eca-7f6e2b691f58"), "C.33.15", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair and maintenance of ships and boats" },
                    { new Guid("bc3f5c9d-7ab7-41e1-badd-513e0a78d629"), "C.33.16", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("7a5ee70c-8de9-4e7d-a6a6-da2ba33ef810"), "C.33.17", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair and maintenance of other transport equipment" },
                    { new Guid("850f57b9-75eb-4627-b442-15b571259664"), "C.33.19", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair of other equipment" },
                    { new Guid("3dc672c7-8606-4bfe-8e9b-c4f536c3e98d"), "C.33.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Installation of industrial machinery and equipment" },
                    { new Guid("e8930cb1-7e0b-432a-b7fc-20e98c84e708"), "C.33.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Installation of industrial machinery and equipment" },
                    { new Guid("14176cea-2b35-4df2-a72e-a69c93fa375e"), "D.35", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("ed03354d-d372-4daa-b664-c0844fed577c"), "D.35.1", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Electric power generation, transmission and distribution" },
                    { new Guid("a6977ebb-4ce1-4255-9527-e4f89ba7818e"), "D.35.11", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Production of electricity" },
                    { new Guid("fa23463c-b1f6-41ed-a070-ae52701ec6fb"), "D.35.12", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Transmission of electricity" },
                    { new Guid("49fcf41f-a4b8-44d9-aeac-57bcefb88195"), "D.35.13", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Distribution of electricity" },
                    { new Guid("52e895a7-8483-41f9-b76c-42578c9668c0"), "D.35.14", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Trade of electricity" },
                    { new Guid("558e4635-bee9-419b-bec7-f0cd72974fee"), "D.35.2", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("ba975b67-87c0-4670-8fd6-7e3624c7e22b"), "D.35.21", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Manufacture of gas" },
                    { new Guid("ae49385f-537b-40b7-8993-2a9cf764139d"), "D.35.22", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Distribution of gaseous fuels through mains" },
                    { new Guid("a9091a95-1ae0-46c6-bef4-f776363dedda"), "D.35.23", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e4efff9d-a5c7-43d9-8245-b4ff0fcbd95d"), "D.35.3", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Steam and air conditioning supply" },
                    { new Guid("0750295c-deff-4e90-8931-246ba46dc630"), "D.35.30", new Guid("26728d1d-7451-4fde-b988-960a76ce721e"), "Steam and air conditioning supply" },
                    { new Guid("4869cda8-0a89-4cea-b957-cef7d279a7fb"), "E.36", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Water collection, treatment and supply" },
                    { new Guid("7abe00f8-a823-4884-9ea6-2b91ab2f92b5"), "E.36.0", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Water collection, treatment and supply" },
                    { new Guid("6f2969a0-c851-4a07-b320-d88e8e7e4739"), "E.36.00", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Water collection, treatment and supply" },
                    { new Guid("c640bc56-bb80-4ad0-96df-af4618f2c22f"), "E.37", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Sewerage" },
                    { new Guid("f11b07e6-0eed-4fb6-b428-c042458f677b"), "E.37.0", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Sewerage" },
                    { new Guid("86c6ead0-f5b8-4391-a3eb-3005bead5710"), "E.37.00", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Sewerage" },
                    { new Guid("74e9774b-a5e2-4d77-8231-3fd4fb21a621"), "E.38", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("c49c6ccd-8cdc-439f-bfd7-e25405e9bba5"), "E.38.1", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Waste collection" },
                    { new Guid("079ae82b-7761-42cf-b2be-3d415e9a16af"), "E.38.11", new Guid("ee51d064-4513-4d54-8ed9-45a325f4af0d"), "Collection of non-hazardous waste" },
                    { new Guid("73630c1a-d77a-46ca-af92-c0604cd22f47"), "C.33.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Repair of electronic and optical equipment" },
                    { new Guid("cad6e38e-fff6-48f1-9145-bc978fa59a3f"), "C.23.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of clay building materials" },
                    { new Guid("6898fded-3b65-4819-9ec1-0984e3cf2d17"), "C.28.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("e7b85d6d-fc8c-4e24-b4e8-91944ca58ff5"), "C.28.25", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("7080ba67-2f82-4d67-8b35-1db7447c2803"), "C.24.34", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Cold drawing of wire" },
                    { new Guid("36649710-af27-46a1-9440-910dfd9ab0af"), "C.24.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("1d28dd49-c949-427b-ac32-ed565bb814be"), "C.24.41", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Precious metals production" },
                    { new Guid("ef933294-5f2b-44e3-8572-3bb6c6d42655"), "C.24.42", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Aluminium production" },
                    { new Guid("9d695be2-ee82-462d-b8f0-00e10d488109"), "C.24.43", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Lead, zinc and tin production" },
                    { new Guid("7d8e9533-1f0b-4c46-a1dd-72631d73317f"), "C.24.44", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Copper production" },
                    { new Guid("8fb14372-aa9f-4ace-adb0-91ec5f7b6a31"), "C.24.45", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Other non-ferrous metal production" },
                    { new Guid("42a0e5db-7e51-4920-bcf6-22f9f9534e2a"), "C.24.46", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Processing of nuclear fuel" },
                    { new Guid("88b87282-d35a-49c2-ac08-3d4157de1ed4"), "C.24.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Casting of metals" },
                    { new Guid("26c03227-b596-404c-9740-20fda1b61cc2"), "C.24.51", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Casting of iron" },
                    { new Guid("7da5062f-d6aa-47bb-abd3-645bdbb3131b"), "C.24.52", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Casting of steel" },
                    { new Guid("a1bc78a7-9d46-413d-9d5b-f5b782a02eb9"), "C.24.53", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Casting of light metals" },
                    { new Guid("0af50b4c-684d-4159-b61a-49067e7bb31f"), "C.24.33", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Cold forming or folding" },
                    { new Guid("3043058c-0876-4ac0-9a6c-85fa9010af95"), "C.24.54", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Casting of other non-ferrous metals" },
                    { new Guid("e52c85f4-19d0-4f49-9375-7b5c0ea9cc4f"), "C.25.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of structural metal products" },
                    { new Guid("3ed8c8d2-a553-4461-809d-c9ce798e4562"), "C.25.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("5482510a-0488-481c-b294-cf4a85829f52"), "C.25.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of doors and windows of metal" },
                    { new Guid("71d369da-4c13-4beb-bbbd-45df80e0aa6a"), "C.25.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("d086f46b-7889-4a5c-af42-4a2484bb77ef"), "C.25.21", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("5d764fef-57f9-4bba-b608-4bf487c55e9b"), "C.25.29", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("f1d1f4e9-83d0-4789-9e4f-92b89eea20e2"), "C.25.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("7f227e19-8012-44c1-b85f-f60dea420c0f"), "C.25.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("9135535d-b8ba-4e56-a6c7-fba40bb69aae"), "C.25.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of weapons and ammunition" },
                    { new Guid("f4792288-f8b8-4f96-a800-69cccd579184"), "C.25.40", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of weapons and ammunition" },
                    { new Guid("b5c1fbf6-4ec7-4492-a308-b895010a1344"), "C.25.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("52824b89-1758-4137-9a78-29b3c650c225"), "C.25.50", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("04e0fdad-76b3-4897-b299-1f4f41358788"), "C.25", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b66d3ffb-7fda-49fc-b29a-1b81be86fd3d"), "C.24.32", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Cold rolling of narrow strip" },
                    { new Guid("07ac0fdb-9748-4bf6-8253-8ea55f1fc45f"), "C.24.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Cold drawing of bars" },
                    { new Guid("ed5d7bf2-80b5-4c52-8818-1431fe36aea9"), "C.24.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other products of first processing of steel" },
                    { new Guid("bbee0fb1-08ac-4c0d-a92a-b3b32b8d5a31"), "C.23.32", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("626c9d4c-6224-4202-a089-90b4a94c2e4b"), "C.23.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("b1358e9d-d1bc-4362-a565-65dc2abf1ccb"), "C.23.41", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("6ea712e5-2336-4c6c-b26b-7066c4b115bc"), "C.23.42", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("634d19fe-aa16-41e3-957c-0ed6a4f00140"), "C.23.43", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("5595ee55-cbc0-4f3c-ab57-d8c8053b5cb8"), "C.23.44", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other technical ceramic products" },
                    { new Guid("db06a133-1422-4108-9c59-3d2eb5e379f5"), "C.23.49", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other ceramic products" },
                    { new Guid("1c88851c-e747-441f-952d-d067f6f0e6bc"), "C.23.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cement, lime and plaster" },
                    { new Guid("9dd30b35-8c22-405d-b15d-69db97e3c6b2"), "C.23.51", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cement" },
                    { new Guid("2789bc2d-9d3f-40e5-a685-325f90ff71fc"), "C.23.52", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of lime and plaster" },
                    { new Guid("80329016-2ac8-4712-b46d-2a3c406483b0"), "C.23.6", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("47e96225-d2e2-4c82-801d-5551f426a7ab"), "C.23.61", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("acc28ff5-77f7-40fd-b9b7-597794a26501"), "C.23.62", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("fda9e8d9-f451-4aa5-959a-d9513260a2a3"), "C.23.63", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ready-mixed concrete" },
                    { new Guid("b548d482-ecaf-4c3b-acb2-b22f9292a723"), "C.23.64", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of mortars" },
                    { new Guid("f2c1bfe4-b87c-4918-84a2-293d90c4add8"), "C.23.65", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fibre cement" },
                    { new Guid("f9bcdfae-6a9e-4221-b138-c530e5181c6b"), "C.23.69", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("2abb28e3-add9-46ef-af3e-a4c8b8e77f63"), "C.23.7", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Cutting, shaping and finishing of stone" },
                    { new Guid("1e8b1aed-a06d-4baf-984d-09edcdae8654"), "C.23.70", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Cutting, shaping and finishing of stone" },
                    { new Guid("11cfb866-aef6-4414-bf1e-58185306a616"), "C.23.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("9ae3d564-8b2e-4487-8789-013cd04ecd21"), "C.23.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Production of abrasive products" },
                    { new Guid("aec4fc5e-843e-4f10-8bec-0e29d9178416"), "C.23.99", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("d7067f27-82e2-4382-b14a-289de461174d"), "C.24", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic metals" },
                    { new Guid("8eae6692-fa85-4f0e-871d-998e525bdff4"), "C.24.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("dcd28f83-6005-4a32-93f5-7786d455610d"), "C.24.10", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("4b736c2f-8fb7-4892-8fbc-e2b1cce71a8d"), "C.24.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("49bb5678-3de3-4f1e-9cb9-31fadb6712e8"), "C.24.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("8c7c0526-c605-40f2-ba48-58b3ffc7230e"), "C.25.6", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Treatment and coating of metals; machining" },
                    { new Guid("d6a3a8ad-695e-4275-bdca-64d10c7e027b"), "C.28.29", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("f0d1cfbc-c757-457d-8eed-0087a4804d5e"), "C.25.61", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Treatment and coating of metals" },
                    { new Guid("425d99b0-a58c-4531-921d-87fe06661923"), "C.25.7", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("3cdfd17c-dc04-4267-a569-ce943860956f"), "C.27.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("90103d5b-1247-47d8-bb1c-d03f151527bc"), "C.27.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of batteries and accumulators" },
                    { new Guid("55df316b-2fa1-4b89-9e51-1c2b0f756c21"), "C.27.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of batteries and accumulators" },
                    { new Guid("e30a0828-1bf8-4221-a5ae-d0e2c748d41c"), "C.27.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wiring and wiring devices" },
                    { new Guid("b82ee039-cb77-40a0-bc4a-5fd59774ed12"), "C.27.31", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fibre optic cables" },
                    { new Guid("1f2d233c-4610-4721-92c1-00c46a369d98"), "C.27.32", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("e36ae290-16e9-4bce-8e69-3a05aa97b264"), "C.27.33", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wiring devices" },
                    { new Guid("baaf02d4-0986-4a64-a605-3711c253886b"), "C.27.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d3bd6612-2baf-4d2e-bb95-ad26be677fa1"), "C.27.40", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electric lighting equipment" },
                    { new Guid("bef7e44f-b7a4-475f-a918-ef48fa87cca8"), "C.27.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of domestic appliances" },
                    { new Guid("845ba96f-7eeb-4e64-84d6-23b8628690ee"), "C.27.51", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electric domestic appliances" },
                    { new Guid("724fb4f1-af2d-49d1-b3dc-5a466d5f5dfb"), "C.27.52", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("c5be60a2-7f00-4b4b-9bd3-4ffa396ab795"), "C.27.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("972acaac-bf7c-409f-973d-73df2692b35d"), "C.27.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other electrical equipment" },
                    { new Guid("b6b7cedd-6ba6-4d2b-affd-24718f92a6d9"), "C.28", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("43366fa3-e318-421d-96ea-702bbb946b6d"), "C.28.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of general-purpose machinery" },
                    { new Guid("c3dda6bc-217c-4f3c-b608-2502d245ad43"), "C.28.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("033da17e-502d-455e-8d48-45d493515dd2"), "C.28.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fluid power equipment" },
                    { new Guid("d2f2e032-2166-4d7b-9c68-6d40d0b6ee9c"), "C.28.13", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other pumps and compressors" },
                    { new Guid("d41aa311-2128-4d46-9300-230be784cb34"), "C.28.14", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other taps and valves" },
                    { new Guid("2801f8fc-05c0-4ee3-8324-b23f0e388905"), "C.28.15", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("5ea4c430-fb61-4162-97df-b7467e5f731a"), "C.28.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other general-purpose machinery" },
                    { new Guid("62033bea-1eba-424d-8f97-d24a51577708"), "C.28.21", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("ddb363e4-5d72-4991-bcc8-fd8c3b8abf39"), "C.28.22", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of lifting and handling equipment" },
                    { new Guid("8e26fd82-d00a-46d1-ba4a-fe96d6f6b414"), "C.28.23", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("e5c92dfd-1c91-43b8-8dc4-59943211b1ae"), "C.28.24", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of power-driven hand tools" },
                    { new Guid("1a4d96eb-b52d-4128-aeb3-0cb405174d96"), "C.27.90", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other electrical equipment" },
                    { new Guid("51f7cf4d-12a3-4e89-989c-d7551cd5f829"), "C.27.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("0670c921-c690-4fd0-b447-36806987c25c"), "C.27", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electrical equipment" },
                    { new Guid("2fba3657-2265-45d1-b12b-7b57c310bcad"), "C.26.80", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of magnetic and optical media" },
                    { new Guid("a087bd85-93b7-455f-846f-f25047dd5c57"), "C.25.71", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of cutlery" },
                    { new Guid("76e1c3de-f6a0-4a65-9fee-75a63c6e0bf8"), "C.25.72", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of locks and hinges" },
                    { new Guid("4e65f093-8077-4b24-b1bd-597f859c0c00"), "C.25.73", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of tools" },
                    { new Guid("be8fde7f-359e-49b7-b2d6-164ba8fb62e9"), "C.25.9", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other fabricated metal products" },
                    { new Guid("c3bc1c61-4fee-4d35-b5f0-56dd66c12dc1"), "C.25.91", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of steel drums and similar containers" },
                    { new Guid("771b530f-a426-46de-a337-1b2bbdc23776"), "C.25.92", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of light metal packaging" },
                    { new Guid("52f6a43c-bf07-4142-b75f-b198e1e95c21"), "C.25.93", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of wire products, chain and springs" },
                    { new Guid("d82c5809-8ed9-4448-8b3b-342bfdc3d2a7"), "C.25.94", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("14f14708-0983-4843-a732-b9577bb95c9a"), "C.25.99", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("3f72f8bb-57b6-41b1-b6b6-880ac32cbb82"), "C.26", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("f3bb035b-5f00-4449-90de-460e233dd209"), "C.26.1", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electronic components and boards" },
                    { new Guid("5df8d25b-0830-4c48-8dfe-df1be41e3e14"), "C.26.11", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of electronic components" },
                    { new Guid("7d4387b5-c58c-4136-a875-8c749c3ab5f6"), "C.26.12", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of loaded electronic boards" },
                    { new Guid("b0fec4ff-fabf-4fff-8f05-349364829ff6"), "C.26.2", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("61760add-8a3f-453b-a8f6-e7932a3799a4"), "C.26.20", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("6424623a-c6d5-4697-a400-c260330842c9"), "C.26.3", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of communication equipment" },
                    { new Guid("fd437d1e-6c83-4a38-8176-d8eac7a21276"), "C.26.30", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of communication equipment" },
                    { new Guid("52566b16-d01d-46d7-b05a-398a6d0441cf"), "C.26.4", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of consumer electronics" },
                    { new Guid("4c429cda-3d67-4a3d-8db9-d8dfe8f580c1"), "C.26.40", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of consumer electronics" },
                    { new Guid("aee7a1ed-1140-41ad-a340-33fa13b8bd88"), "C.26.5", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("294486f9-b19b-4746-a548-e6a4bed5239b"), "C.26.51", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("2b8e66ba-e450-4dd6-b939-ec258f576608"), "C.26.52", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of watches and clocks" },
                    { new Guid("95c779b9-1f9e-4bec-8145-ffa7fb59a07b"), "C.26.6", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("3e0899e8-d7ec-4db7-81a8-5af299c90e47"), "C.26.60", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("2c944789-1f64-4811-901a-0fcc53550eab"), "C.26.7", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("e649d057-3948-42f2-a799-92ae229fc4f8"), "C.26.70", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("90240e54-c112-4392-a4db-f9c37be3b44f"), "C.26.8", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Manufacture of magnetic and optical media" },
                    { new Guid("1bfe4b77-ae8c-4504-a81b-6ccaad5c78a7"), "C.25.62", new Guid("8402f430-a482-40f2-bd08-c49a32c0f516"), "Machining" },
                    { new Guid("db1831da-e140-45f7-8eb7-6378a0ca249f"), "U.99.00", new Guid("1ed48518-10cc-4ce8-9821-464f819882c7"), "Activities of extraterritorial organisations and bodies" }
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
