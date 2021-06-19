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
                    { new Guid("f883ddf0-5d8b-4fed-bd23-bd548e62ef52"), "AT", "Austria" },
                    { new Guid("f2aa2096-fb29-4f7a-b093-480662a9d6c1"), "LU", "Luxembourg" },
                    { new Guid("ac62e557-5b44-45b6-893b-90d575b33c6a"), "MT", "Malta" },
                    { new Guid("125dd411-cb90-4c6d-97e0-2d9cbe7d2b8e"), "NL", "Netherlands" },
                    { new Guid("99182b0f-60ab-4934-b1ca-6ee7b5177e27"), "MK", "North Macedonia" },
                    { new Guid("decad40d-ac08-4a39-bc94-bb20742f7751"), "NO", "Norway" },
                    { new Guid("076b7649-fa8c-449b-8b20-7a0f090ba6ac"), "PL", "Poland" },
                    { new Guid("d14ac2b6-42c8-490a-b0b8-768ae1cc4c03"), "PT", "Portugal" },
                    { new Guid("91bd88f2-2306-4ee8-ba89-b999449d3439"), "RS", "Serbia" },
                    { new Guid("d1abf92c-1c99-4121-9c12-87b1d7fe5452"), "SK", "Slovakia" },
                    { new Guid("b82204ef-e4e0-43b9-a13c-08da4e6cd6ea"), "SI", "Slovenia" },
                    { new Guid("abec23e6-53e8-4781-8d7c-b13227a1a060"), "ES", "Spain" },
                    { new Guid("09c7de0f-5c6d-4285-98ce-729bb90d42d1"), "SE", "Sweden" },
                    { new Guid("ff65ab71-8307-41e4-9562-f5ec3f363480"), "CH", "Switzerland" },
                    { new Guid("a1858b95-23a2-42e5-b4de-d23b64dd8080"), "TR", "Turkey" },
                    { new Guid("59873b6e-b3cd-4f61-a9d7-2e26c6209cee"), "UK", "United Kingdom" },
                    { new Guid("28053832-56ec-4965-85d6-4a3740753ce1"), "LT", "Lithuania" },
                    { new Guid("6ab1d45d-ac10-4910-bd35-d9fc3bf37914"), "LI", "Liechtenstein" },
                    { new Guid("ab1c195d-92e4-4933-ae1e-6c2248e72c89"), "RO", "Romania" },
                    { new Guid("31c5e870-e010-4a0d-ac04-95acbd3e03a3"), "IT", "Italy" },
                    { new Guid("8807c907-2602-435e-b775-a28a92ee823d"), "BG", "Bulgaria" },
                    { new Guid("1e49e328-0585-4d17-a41e-de5f63f2f67c"), "HR", "Croatia" },
                    { new Guid("251bde3d-501b-4115-b39a-8d211d19075e"), "CY", "Cyprus" },
                    { new Guid("98a5062b-4b9f-42f7-adfa-f7511fe7a2fb"), "CZ", "Czechia" },
                    { new Guid("7e0b50a5-3a8a-402b-8668-947d86a9d11c"), "DK", "Denmark" },
                    { new Guid("d9636e5d-43b8-4ebd-98f9-3e79b8e35b67"), "EE", "Estonia" },
                    { new Guid("3f4d0d5d-df90-420d-959c-46dac63338f8"), "BE", "Belgium" },
                    { new Guid("572a5294-8176-434e-a620-6c1cab82c874"), "LV", "Latvia" },
                    { new Guid("e486f388-3d22-411d-9603-01712e22494b"), "FR", "France" },
                    { new Guid("6600ecd1-42e8-4551-be6c-b30ed33a9b43"), "DE", "Germany" },
                    { new Guid("797a963f-f2ac-453b-900d-25cc925dfbba"), "EL", "Greece" },
                    { new Guid("9db4787e-c6a6-442e-af85-297199ca9406"), "HU", "Hungary" },
                    { new Guid("7ce7a764-454d-4346-8f79-eb2e33957367"), "IS", "Iceland" },
                    { new Guid("68aaccaf-45c5-41d3-928c-b53d480cec43"), "IE", "Ireland" },
                    { new Guid("d2509e19-ebc1-4ecc-8f74-4f1d0e1af19d"), "FI", "Finland" },
                    { new Guid("67294a13-5cc7-4957-bf30-b7e6f8668f08"), "BA", "Bosnia and Herzegovina" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("eceb3b43-aa82-491e-bfc9-c26a66598b4a"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b1abc288-b7f1-4b97-90a8-485c0726eb36"), (short)6, null, new Guid("39363367-4498-4e25-961b-30e5277824b3"), (short)5, "Other" },
                    { new Guid("0231c1bb-182e-40c6-a804-8af92e044597"), (short)6, null, new Guid("852a36a2-c211-4e93-b40c-adb3db9c4fc3"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("ed633691-5072-4941-b841-454a981e2964"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("71700013-f3f9-44dd-ad40-9e846d2d5c4e"), (short)2, "Frequency" },
                    { new Guid("8849710d-2c62-42dc-8150-aa227ed0c1ef"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("71700013-f3f9-44dd-ad40-9e846d2d5c4e"), (short)1, "Ownership type" },
                    { new Guid("71700013-f3f9-44dd-ad40-9e846d2d5c4e"), (short)6, null, new Guid("852a36a2-c211-4e93-b40c-adb3db9c4fc3"), (short)2, "Administrative" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("44ba2dde-39c8-4f10-bc52-d3d28e47a0a2"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b6caaf9a-f2e0-40d2-a1cb-0c0ec6d39088"), (short)2, "Frequency" },
                    { new Guid("0ecb37f4-d020-4e2b-9b6e-0c86dc3c526b"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("b6caaf9a-f2e0-40d2-a1cb-0c0ec6d39088"), (short)1, "Ownership type" },
                    { new Guid("b6caaf9a-f2e0-40d2-a1cb-0c0ec6d39088"), (short)6, null, new Guid("852a36a2-c211-4e93-b40c-adb3db9c4fc3"), (short)1, "Specialists & Know-how" },
                    { new Guid("852a36a2-c211-4e93-b40c-adb3db9c4fc3"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("9e841747-c68f-437d-9940-0de27c3b19ef"), (short)6, null, new Guid("6b65f3dd-a03c-4952-9452-dadd75b4a95a"), (short)4, "Other" },
                    { new Guid("c65de7f2-fd1e-4866-8d0b-c35e30e5e169"), (short)6, null, new Guid("6b65f3dd-a03c-4952-9452-dadd75b4a95a"), (short)3, "Software" },
                    { new Guid("684b0412-7cb6-4d11-a691-054d991c247a"), (short)6, null, new Guid("6b65f3dd-a03c-4952-9452-dadd75b4a95a"), (short)2, "Licenses" },
                    { new Guid("cadc5b01-fc48-42b2-b666-d8bca086a0b6"), (short)6, null, new Guid("6b65f3dd-a03c-4952-9452-dadd75b4a95a"), (short)1, "Brands" },
                    { new Guid("6b65f3dd-a03c-4952-9452-dadd75b4a95a"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("f0963886-06c3-486d-b7ee-415cda75f74c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b1abc288-b7f1-4b97-90a8-485c0726eb36"), (short)2, "Frequency" },
                    { new Guid("5e97e24d-008b-4423-95f9-f6aa928bde9e"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("b1abc288-b7f1-4b97-90a8-485c0726eb36"), (short)1, "Ownership type" },
                    { new Guid("9a115814-1361-42de-b497-218947fe7421"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("0231c1bb-182e-40c6-a804-8af92e044597"), (short)1, "Ownership type" },
                    { new Guid("de3a1b7e-4484-4a80-bb29-3f953ff534c6"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0231c1bb-182e-40c6-a804-8af92e044597"), (short)2, "Frequency" },
                    { new Guid("7e084d1a-80b7-47f4-8d57-5fb9011517d6"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("bdf5d695-c9d1-44c4-b282-9c031afa9a9e"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("2aa82b9b-55ad-4edf-b803-e3fcd824aa81"), (short)1, "Ownership type" },
                    { new Guid("cab8caad-5718-466e-b141-e621e7f68ff0"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("5693e3a7-4087-4e72-979c-764047ef1f93"), (short)1, "Ownership type" },
                    { new Guid("cc393f2e-3124-4469-98d3-5195f253ab59"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("287a2707-bbef-422c-9add-d54ff88649e9"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("7a96e169-cc5d-4996-8501-e9b62244f88f"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("ebfd74de-b7f7-427e-be29-6fc948732f12"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("325f8665-e772-4cf3-be74-3dd2298fe9c9"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("2255b227-0123-445d-83f5-353daed34dc0"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("5cc7826c-bc2f-4f46-abb8-bd94d6d7750f"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("84b8b59c-1d4a-4551-a280-1c9cb3f8dee7"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("c70fba2d-acaa-4ee7-8fa1-eb36a58465fd"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("60a78cd6-b604-42c1-9d59-ab1ad00a6ef8"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("d3f84d79-d537-4022-b5d5-d8f9658ad86b"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("3c1446e9-7ed7-401c-9114-62c332d92d21"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("a43cf479-36a8-45a7-876f-e5d1f088b84c"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("d83b96a6-a9dd-4973-bc08-a21de75e4410"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("62658529-7218-4b71-889e-91463db28a81"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("f9efe749-c3bf-444b-a546-848ef49f19b5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("2aa82b9b-55ad-4edf-b803-e3fcd824aa81"), (short)2, "Frequency" },
                    { new Guid("2aa82b9b-55ad-4edf-b803-e3fcd824aa81"), (short)6, null, new Guid("852a36a2-c211-4e93-b40c-adb3db9c4fc3"), (short)4, "Other" },
                    { new Guid("5693e3a7-4087-4e72-979c-764047ef1f93"), (short)6, null, new Guid("39363367-4498-4e25-961b-30e5277824b3"), (short)4, "Raw materials" },
                    { new Guid("67b4e40c-d48a-4b01-bcde-7a61dec32cf8"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("b389a9eb-cfcb-4625-9aa5-f169271bf4bd"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3377b6d1-eea1-4e73-aa94-433431be3809"), (short)1, "Ownership type" },
                    { new Guid("267b3b8d-c88f-4eb7-8b51-8572c441256d"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("4c6d22ac-8410-483d-9489-f058ed83b1c4"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("c6de9a9b-debd-4d1a-af6b-64c9d85d0635"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("d034bd4a-8be8-4f02-bae3-f4323a518e5f"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("572d591f-d760-4bff-9da7-89651598db1e"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("84399838-624b-432c-b770-1e8d1ffad910"), (short)1, "a", null, (short)11, "Management processes" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("7f4dddd5-b172-492f-a7a2-b2fe2848fcf7"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("798b27e2-e249-48fb-b45e-7eaee1b4e1a2"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("2168a6f1-4fbf-4540-9206-20c37e225d74"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("47968e45-6a29-4689-bf81-30037fd052cc"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("caf0b5b9-f418-4634-aa09-9d5f7184fcdb"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("e02e201b-c691-4cc6-b181-76684b155e00"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("6ed5a4d0-b196-4bd0-89f1-1a0503c13bc1"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("e878f418-42a2-466a-8106-276b30aef1d4"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("0c025a79-10c2-46a6-a335-59bc45988e1b"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("f34af46d-f673-473f-b0a5-24e59dfcd7d9"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("fb9743d2-a68f-43b5-bc91-44094fb041f0"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("5a557a67-8dd0-4ca9-8d4b-26509bb8e0d6"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("858499c2-f5d4-4043-bbe3-c04edbd2e797"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("6b665ffe-ef4b-4361-8a1a-8a7d22cb405a"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("3377b6d1-eea1-4e73-aa94-433431be3809"), (short)6, null, new Guid("39363367-4498-4e25-961b-30e5277824b3"), (short)3, "Transport" },
                    { new Guid("9e399546-02bd-4dbf-a6a3-c07d323a9b38"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("39aef0a6-c362-4fdf-8bb5-c14790992d25"), (short)2, "Frequency" },
                    { new Guid("b0b71b74-d6b7-4b31-b63f-273570313073"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("39aef0a6-c362-4fdf-8bb5-c14790992d25"), (short)1, "Ownership type" },
                    { new Guid("39aef0a6-c362-4fdf-8bb5-c14790992d25"), (short)6, null, new Guid("39363367-4498-4e25-961b-30e5277824b3"), (short)2, "Equipment" },
                    { new Guid("b85d17b1-9a8c-45f6-9b93-ca901d772ed3"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("271dcdbc-abd8-4d19-9865-1e950236746b"), (short)2, "Frequency" },
                    { new Guid("f42bb076-a3f6-493c-94f9-0ad6e0ad919f"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("271dcdbc-abd8-4d19-9865-1e950236746b"), (short)1, "Ownership type" },
                    { new Guid("271dcdbc-abd8-4d19-9865-1e950236746b"), (short)6, null, new Guid("39363367-4498-4e25-961b-30e5277824b3"), (short)1, "Buildings" },
                    { new Guid("39363367-4498-4e25-961b-30e5277824b3"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("7c4c92fb-30d8-4c78-a9c7-3ee124aec71c"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("5c37d7c4-7d20-4da1-b5ce-6d41585e1640"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("9cd25ae8-85b8-4107-996a-20c696c9b71f"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("6f4fdaf2-218e-4c07-b8b0-fe67793d26fe"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("01818a10-ef95-4a49-8872-f03cf9696cb8"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("3116451a-5cd5-4d7f-8c30-2e7adfbb95d6"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("3003b2a3-17ba-45ca-8735-3efc837455a2"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("5f330fe3-1310-4e51-8149-7bd1d0f00c5e"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("cffad898-6e6e-4fca-b640-1c1cc7d1b306"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3377b6d1-eea1-4e73-aa94-433431be3809"), (short)2, "Frequency" }
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
