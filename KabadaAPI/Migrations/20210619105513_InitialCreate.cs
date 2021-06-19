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
                    { new Guid("5217330d-da4f-410f-9e0f-e97bb262246c"), "AT", "Austria" },
                    { new Guid("5052cba9-9aad-4ff2-b35e-6f853aa72cc0"), "LU", "Luxembourg" },
                    { new Guid("4e662bda-e747-456e-88f8-f83c3237ef1f"), "MT", "Malta" },
                    { new Guid("08b14c17-343e-494a-becb-23e966603633"), "MK", "North Macedonia" },
                    { new Guid("d5fb60ba-2b01-4762-825b-e1894d55db7c"), "NO", "Norway" },
                    { new Guid("38071ff6-6f66-4028-8ee2-7e0bfe45f04f"), "PL", "Poland" },
                    { new Guid("fd5f61b6-d42d-44c2-af7f-5df07907e76e"), "PT", "Portugal" },
                    { new Guid("5de0942b-616c-4f91-a188-689af5fcbd92"), "RO", "Romania" },
                    { new Guid("ce93dbce-2e76-4612-be9f-b885c14b5283"), "RS", "Serbia" },
                    { new Guid("64e57cd3-b5e2-4437-9248-5c2df814a252"), "SK", "Slovakia" },
                    { new Guid("1a67af91-fbb5-4803-b28a-410d58809833"), "SI", "Slovenia" },
                    { new Guid("998f2de6-2fac-4caa-af23-78b3bd3f9fc4"), "ES", "Spain" },
                    { new Guid("dcb32fca-296e-43a0-9a20-313b3c09430c"), "SE", "Sweden" },
                    { new Guid("025cd6b8-9392-4bc4-90c0-f27472b1f337"), "CH", "Switzerland" },
                    { new Guid("3f5735d5-6638-4fca-b28b-d9eef23bbdb9"), "TR", "Turkey" },
                    { new Guid("dff30f06-79a5-47b8-a551-081f64f46d54"), "UK", "United Kingdom" },
                    { new Guid("4c3bb679-10b5-45bf-8f40-efa4428b7386"), "LT", "Lithuania" },
                    { new Guid("8e76c9fe-cbfb-4b46-b363-708554912a77"), "LI", "Liechtenstein" },
                    { new Guid("992ec9f9-040a-44df-8e39-1dfc978e79f2"), "NL", "Netherlands" },
                    { new Guid("1ddeefe4-96f5-427c-9b62-1fe1247aa80d"), "IT", "Italy" },
                    { new Guid("0cf73f1a-b06d-45b4-8a1c-ef87bdfeb718"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("d8efe539-0c49-421f-b93b-9fc5b4bb6362"), "BE", "Belgium" },
                    { new Guid("aaefc073-1fd4-4d22-a40b-0fd4f048d1de"), "BG", "Bulgaria" },
                    { new Guid("151a64e0-0e00-4730-b17b-cdba7ff249c6"), "LV", "Latvia" },
                    { new Guid("475255dc-d6e1-4870-a8dc-2c839a43f48b"), "CY", "Cyprus" },
                    { new Guid("8e1865b0-92ec-4314-a0a1-6f49a59509e2"), "CZ", "Czechia" },
                    { new Guid("3f8c0736-13ec-4669-9e07-94b1da6a64d4"), "DK", "Denmark" },
                    { new Guid("06947c29-cb19-43dd-931e-efbdfa29beb1"), "EE", "Estonia" },
                    { new Guid("bd492ef2-175f-40e9-ae67-c64967674f07"), "HR", "Croatia" },
                    { new Guid("78967201-1b83-4183-aa10-03bee732acec"), "FR", "France" },
                    { new Guid("36d0ec49-dfb3-4794-9464-6757e7b96966"), "DE", "Germany" },
                    { new Guid("8846678b-b79b-4a41-8abf-82e2e5b2ad3c"), "EL", "Greece" },
                    { new Guid("46d3282e-0fc2-46d8-a727-7fc704d703a5"), "HU", "Hungary" },
                    { new Guid("8689792b-bdee-4e1f-a7d9-46f49fbf4cf4"), "IS", "Iceland" },
                    { new Guid("39aaee76-28e0-4687-90ce-c4b778addca3"), "IE", "Ireland" },
                    { new Guid("b29bde57-8e8f-4061-99ed-9e7d3e0e9580"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "P", "EN", "Education" },
                    { new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("eb69e668-d56f-4faf-adee-e79dc90933be"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "L", "EN", "Real estate activities" },
                    { new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "J", "EN", "Information and communication" },
                    { new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "C", "EN", "Manufacturing" },
                    { new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "B", "EN", "Mining and quarrying" },
                    { new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "F", "EN", "Construction" },
                    { new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "H", "EN", "Transporting and storage" },
                    { new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("b3fb24ff-b68e-410e-a0d3-54c7d5d9a204"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("9ac33514-a69b-476b-aaba-389de5782ca8"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("f4a01811-e6d9-4e66-9324-2ab1b8ae096b"), (short)1, "Ownership type" },
                    { new Guid("3500df6b-ec7a-4fb1-8a90-e516c859eb2d"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("472ca397-e4cf-40bd-84ff-66e07c7d7e17"), (short)2, "Frequency" },
                    { new Guid("9ed35b2d-0bcb-4abb-b82f-2ca66866bb62"), (short)6, null, new Guid("a39a5f91-6637-4c3c-8ec6-9abafbe0fa79"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("460c0999-d6b3-4a36-8feb-1ad9d7adcc28"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("472ca397-e4cf-40bd-84ff-66e07c7d7e17"), (short)1, "Ownership type" },
                    { new Guid("472ca397-e4cf-40bd-84ff-66e07c7d7e17"), (short)6, null, new Guid("a39a5f91-6637-4c3c-8ec6-9abafbe0fa79"), (short)2, "Administrative" },
                    { new Guid("59ef68dd-f132-42db-880c-d670fbae88e5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f4a01811-e6d9-4e66-9324-2ab1b8ae096b"), (short)2, "Frequency" },
                    { new Guid("f4a01811-e6d9-4e66-9324-2ab1b8ae096b"), (short)6, null, new Guid("a39a5f91-6637-4c3c-8ec6-9abafbe0fa79"), (short)1, "Specialists & Know-how" },
                    { new Guid("92fc7e39-1757-42e2-9ccc-932cc64fa9dc"), (short)6, null, new Guid("7f832a52-147b-422a-8c29-a9b432f1053c"), (short)1, "Brands" },
                    { new Guid("7478b14f-552b-405f-8045-5097c84453d9"), (short)6, null, new Guid("7f832a52-147b-422a-8c29-a9b432f1053c"), (short)4, "Other" },
                    { new Guid("34e52c65-b450-44b8-a05e-3e9d6e20ecd3"), (short)6, null, new Guid("7f832a52-147b-422a-8c29-a9b432f1053c"), (short)3, "Software" },
                    { new Guid("634d278a-8714-41f6-833b-095d3c7fef58"), (short)6, null, new Guid("7f832a52-147b-422a-8c29-a9b432f1053c"), (short)2, "Licenses" },
                    { new Guid("491aac38-2157-467a-aabf-790884d9b987"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("9ed35b2d-0bcb-4abb-b82f-2ca66866bb62"), (short)1, "Ownership type" },
                    { new Guid("7f832a52-147b-422a-8c29-a9b432f1053c"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("9fad78b2-c3ed-40a6-8bb3-457d77a154f1"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9185aacf-7d71-4e94-a652-65b3b53a3033"), (short)2, "Frequency" },
                    { new Guid("f8e682b6-9566-479c-9c87-1563f0b2b844"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9185aacf-7d71-4e94-a652-65b3b53a3033"), (short)1, "Ownership type" },
                    { new Guid("9185aacf-7d71-4e94-a652-65b3b53a3033"), (short)6, null, new Guid("b6470dc8-a835-4664-bb63-6f5df8482b89"), (short)5, "Other" },
                    { new Guid("a39a5f91-6637-4c3c-8ec6-9abafbe0fa79"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("f1994705-80ef-4e15-8b52-db85b2704fbf"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9ed35b2d-0bcb-4abb-b82f-2ca66866bb62"), (short)2, "Frequency" },
                    { new Guid("2fa522ca-a715-4f1f-9b92-54570b8f6b07"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("7051b6ca-7056-4548-b84c-fc9137c142c6"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("00e701ff-faa0-4438-ba05-65e113b7e367"), (short)1, "Ownership type" },
                    { new Guid("0afd23f3-749a-464c-93ef-fe16131db91a"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9ca0dd2c-10d2-4365-9cf8-1f66310f79f0"), (short)1, "Ownership type" },
                    { new Guid("ae8bbc91-8379-422a-b645-7316726e7160"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("45353427-45c0-4618-b5bf-42c2464fc907"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("04c757b4-74a1-4a6a-98a1-0d7dfb548727"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("74b21415-e3e1-4289-9a87-345a8a412173"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("1bc818b5-fd01-4bd8-bf01-17f8c38bc05b"), (short)13, null, null, (short)1, "Associations" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e35064dd-cc59-4b8d-b66a-896cc9af98d3"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("f992adf6-de47-44e0-95de-3653bf2f9645"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("3c872c50-3932-4302-8551-85583c300741"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("bad44a4b-965e-4c55-ad57-2f3a4013dbfb"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("6a408fba-e4d0-4d7c-9361-76fa75d45adb"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("13685571-4add-4664-a611-0971a99f9335"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("8d0fa2ed-8911-4ac6-9979-34eefb2ff3aa"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("31177ea1-1eb6-45bf-a102-56e1b898487b"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("01c1b842-bb9f-48d1-a05c-c1fb754c668e"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("6aed21bb-2271-4603-a8fa-28394f662fe7"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("94cea6e5-c4c9-4d1d-ba36-50d4e5e0815a"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("00e701ff-faa0-4438-ba05-65e113b7e367"), (short)2, "Frequency" },
                    { new Guid("00e701ff-faa0-4438-ba05-65e113b7e367"), (short)6, null, new Guid("a39a5f91-6637-4c3c-8ec6-9abafbe0fa79"), (short)4, "Other" },
                    { new Guid("9ca0dd2c-10d2-4365-9cf8-1f66310f79f0"), (short)6, null, new Guid("b6470dc8-a835-4664-bb63-6f5df8482b89"), (short)4, "Raw materials" },
                    { new Guid("2991bc48-4387-4f93-acf8-8f24d74b2b80"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("319455e5-02e7-415f-8a55-87a5422b7159"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9b3adfda-2ce4-483f-8253-0a628789bad9"), (short)1, "Ownership type" },
                    { new Guid("017637a6-9571-4d4a-9e2f-6a900e04eb35"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("b95d2975-7e28-4da1-b1e5-8d3e8c178af9"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("f19cb653-77f5-429f-b9e2-781d42e76e97"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("81f330cb-da46-4422-ab6e-8260a3283aa3"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("0e80e90c-b759-4a4e-ad78-d1f9752b5e70"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("bc7ba00f-aaa6-435f-9ede-9d98b53890bc"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("e5127291-63dc-4742-a2bb-abc7493b2187"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("409bbfc3-81f4-49f6-8595-13c168f74e8b"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("310d4124-2e71-4d1e-bf9e-83a0d62b512e"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("9cde12ee-ac8a-47fa-9f0f-29366edc2c90"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("0c43802a-d04b-47b9-abae-762df0027f3a"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("f5ca3cc8-8c37-40ba-809b-c4467f779092"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("88e239ab-e895-4ea6-bb0f-4869e8a70f61"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("f8f22a28-5ecb-4b15-a62e-e5eaccbd8dc0"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("41659f4a-a6ba-480d-b973-2eab9d79b965"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("8cb9504c-92fc-4ef4-bb20-67996880fa05"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("acfca707-992a-4883-8176-6877d327c4d7"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("bf88fc40-0d24-4986-beaf-0397db61ccfd"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9b3adfda-2ce4-483f-8253-0a628789bad9"), (short)2, "Frequency" },
                    { new Guid("5ded08bc-a1c1-4447-9c10-e1cc74e8816f"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("39ca5d1d-d90e-4dd7-a580-5347df2785ea"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("9b3adfda-2ce4-483f-8253-0a628789bad9"), (short)6, null, new Guid("b6470dc8-a835-4664-bb63-6f5df8482b89"), (short)3, "Transport" },
                    { new Guid("7bfa0987-4e95-4a7c-9839-593bcd488c54"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("7d5fcd15-2093-4e12-8d45-353ddb2f595e"), (short)2, "Frequency" },
                    { new Guid("0b77f97d-2658-4df1-b6ac-32ef0660fb12"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("7d5fcd15-2093-4e12-8d45-353ddb2f595e"), (short)1, "Ownership type" },
                    { new Guid("7d5fcd15-2093-4e12-8d45-353ddb2f595e"), (short)6, null, new Guid("b6470dc8-a835-4664-bb63-6f5df8482b89"), (short)2, "Equipment" },
                    { new Guid("73d186aa-17ed-42b0-bef8-1670ae5b4ef6"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("25a1e054-7528-4960-832e-797c9b552bd2"), (short)2, "Frequency" },
                    { new Guid("4e5f250e-15ae-408f-9be4-da645bc78150"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("25a1e054-7528-4960-832e-797c9b552bd2"), (short)1, "Ownership type" },
                    { new Guid("25a1e054-7528-4960-832e-797c9b552bd2"), (short)6, null, new Guid("b6470dc8-a835-4664-bb63-6f5df8482b89"), (short)1, "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b6470dc8-a835-4664-bb63-6f5df8482b89"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("a68cb09e-8b91-4371-8a02-8ac42aacb77c"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("ba3bff0e-4790-4817-9d43-dc23632692b8"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("c9ee5106-c0a0-49a9-aedc-75f2fc9b590d"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("1bd9ef69-1984-4fe8-9954-75119eea0fb0"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("f5f14082-a76d-4368-8054-8e50d4b321d9"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("74f68ac7-cd70-421e-bc9c-99cd96ae9c98"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("29817beb-0030-4232-a158-26257e5368cb"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("c6ebf2db-e94a-44b5-91ce-64bb01991018"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("ced03299-6fde-43ca-8dff-d3bb1bdba9c4"), (short)1, "a", null, (short)20, "Discounts" }
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
                    { new Guid("dd7a0e46-b7b4-4e1a-9e31-546014f1528b"), "A.01", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("0c02eff3-7bc0-4fda-a8ed-d47d535c04c0"), "H.51.22", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Space transport" },
                    { new Guid("2229a495-20dd-40f3-be13-2419b647cadc"), "H.52", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Warehousing and support activities for transportation" },
                    { new Guid("067f110b-50f5-4acc-b9ec-e07898ab11a0"), "H.52.1", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Warehousing and storage" },
                    { new Guid("48aac927-b8c9-4b4e-a6d2-3d27ca80cd25"), "H.52.10", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Warehousing and storage" },
                    { new Guid("77b6cd69-e653-40c7-b12a-c0732672b941"), "H.52.2", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Support activities for transportation" },
                    { new Guid("753336bd-d52b-4e2d-8d68-22c9ddda3543"), "H.52.21", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Service activities incidental to land transportation" },
                    { new Guid("d6b5a0c1-9490-40ca-a534-3568e2403755"), "H.52.22", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Service activities incidental to water transportation" },
                    { new Guid("5b7bfb91-fa90-42c1-a08b-c6089ea971c1"), "H.52.23", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Service activities incidental to air transportation" },
                    { new Guid("e8d0524e-7658-4ec2-a52c-a9ed591d7567"), "H.52.24", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Cargo handling" },
                    { new Guid("e15b7a17-75d0-4e2a-baee-b395b14833ac"), "H.52.29", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Other transportation support activities" },
                    { new Guid("7c6bde59-e101-4c1f-811d-415fa641caf7"), "H.53", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Postal and courier activities" },
                    { new Guid("26921e1a-23f0-462b-ad1f-0bfbedff163e"), "H.53.1", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Postal activities under universal service obligation" },
                    { new Guid("1bbf46f2-c659-4573-9f90-e06ad40c26dc"), "H.51.21", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Freight air transport" },
                    { new Guid("340fe0ce-c143-4726-a7d1-a761cf3087ae"), "H.53.10", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Postal activities under universal service obligation" },
                    { new Guid("338400fc-8d40-4564-b3d8-ac3ba8a62f22"), "H.53.20", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Other postal and courier activities" },
                    { new Guid("8021ca25-ec9e-4ffb-a3a4-3937f1f0064d"), "I.55", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Accommodation" },
                    { new Guid("e467bda5-a9d2-4eb6-b702-2764d493c102"), "I.55.1", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Hotels and similar accommodation" },
                    { new Guid("ac56836c-508d-46e4-9c7e-b8c5e3cbd804"), "I.55.10", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Hotels and similar accommodation" },
                    { new Guid("d61c43ba-c183-42a9-aca6-7972be5d2a42"), "I.55.2", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Holiday and other short-stay accommodation" },
                    { new Guid("96577be0-68ed-4756-af6b-1b7affcd7bf5"), "I.55.20", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Holiday and other short-stay accommodation" },
                    { new Guid("1bf78d5a-0b35-4923-8b32-82c47ce753ed"), "I.55.3", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("d4569951-4d90-478f-8f9b-a4cac0f8cd9e"), "I.55.30", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("c9814d43-7b47-40cc-a95d-13ae63a60c46"), "I.55.9", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Other accommodation" },
                    { new Guid("be4c86eb-1ac2-46d8-a7e7-38a9d9a7aab9"), "I.55.90", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Other accommodation" },
                    { new Guid("fe5b67a0-fb8c-459d-8a4f-66b890cd4d69"), "I.56", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Food and beverage service activities" },
                    { new Guid("11ce5766-8db0-4c92-beb2-99f3d427bb34"), "I.56.1", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Restaurants and mobile food service activities" },
                    { new Guid("c3e8113c-c772-46a9-8811-d0ac94a8c939"), "H.53.2", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Other postal and courier activities" },
                    { new Guid("95ee487f-4f0e-4314-8bdd-d9ab91575ac4"), "H.51.2", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Freight air transport and space transport" },
                    { new Guid("c5247f11-21b3-441a-8f4b-028ff23c9671"), "H.51.10", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Passenger air transport" },
                    { new Guid("c6bb4284-a2fe-45e0-917e-56c1d2cd0ee1"), "H.51.1", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Passenger air transport" },
                    { new Guid("36ffa4ab-a2b0-4bda-bf7f-892aa8f30706"), "G.47.9", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("dfd2a51b-32a1-4eaa-ad0c-5b36f742dbd8"), "G.47.91", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("81ab1cdf-90ea-4ae8-8c5f-c027ae14a0ef"), "G.47.99", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("a8bd5a6e-7849-4599-a8c8-821b453cd74f"), "H.49", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Land transport and transport via pipelines" },
                    { new Guid("83179a0a-4406-4b50-a3c0-3736fdfec52a"), "H.49.1", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Passenger rail transport, interurban" },
                    { new Guid("edb082f2-429c-402e-9423-fa4a547cf8e4"), "H.49.10", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Passenger rail transport, interurban" },
                    { new Guid("e1b816a4-ced3-4735-aacc-110ef8814495"), "H.49.2", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Freight rail transport" },
                    { new Guid("2b75f5f5-6458-444e-b052-f59acb3c0139"), "H.49.20", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Freight rail transport" },
                    { new Guid("1b970ec2-748c-47dc-93b3-19a1200b9512"), "H.49.3", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Other passenger land transport" },
                    { new Guid("e6e71185-1e21-44ca-a87d-58b0ac942109"), "H.49.31", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Urban and suburban passenger land transport" },
                    { new Guid("bd15bfbb-932b-4952-99a1-917c1b285162"), "H.49.32", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("68ad56da-0ebf-4292-97d6-928874fdb575"), "H.49.39", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Other passenger land transport n.e.c." },
                    { new Guid("4fbe305d-ee3d-445d-bd72-5c060cfcbdf5"), "H.49.4", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Freight transport by road and removal services" },
                    { new Guid("74df24f7-140e-4513-a1b8-e55e21919e4a"), "H.49.41", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Freight transport by road" },
                    { new Guid("a535d524-8019-4db3-b6df-01281154e8f8"), "H.49.42", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Removal services" },
                    { new Guid("92e3c856-cfc0-47e4-b03e-9f8ed932a648"), "H.49.5", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Transport via pipeline" },
                    { new Guid("fce7be13-edb8-4160-b909-4219236e4a8f"), "H.49.50", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Transport via pipeline" },
                    { new Guid("2515c12f-ceab-4134-8f48-0585e97f8e56"), "H.50", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Water transport" },
                    { new Guid("0b570f09-5ec9-4273-ab3e-140a02584aef"), "H.50.1", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Sea and coastal passenger water transport" },
                    { new Guid("47c09bd8-7a81-4dcc-ae64-1c195c6c399d"), "H.50.10", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Sea and coastal passenger water transport" },
                    { new Guid("92dfb3c6-7794-40b8-8dc0-889fa62505eb"), "H.50.2", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Sea and coastal freight water transport" },
                    { new Guid("14a2d36e-45af-4910-af14-94040da38f98"), "H.50.20", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Sea and coastal freight water transport" },
                    { new Guid("1bf08ec8-e304-4a7b-8380-af75ab549b32"), "H.50.3", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Inland passenger water transport" },
                    { new Guid("215661ab-ed4e-4b07-9598-359485a26bb3"), "H.50.30", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Inland passenger water transport" },
                    { new Guid("91127f11-bc8b-4c46-9bfb-cecc38b16bbf"), "H.50.4", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Inland freight water transport" },
                    { new Guid("66332c58-056e-43fd-a980-cfdddc057bf9"), "H.50.40", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Inland freight water transport" },
                    { new Guid("58b06ac4-b449-4a33-8dfe-de005b6cf1b6"), "H.51", new Guid("9816ba42-a86a-4c28-83db-f1b645aba004"), "Air transport" },
                    { new Guid("21cd543d-55f9-4429-a318-0f3cf3af4408"), "I.56.10", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Restaurants and mobile food service activities" },
                    { new Guid("508fa670-9a5b-4862-8468-6681657426b1"), "G.47.89", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("c8c14670-cf27-40a1-9707-dca51b059c1a"), "I.56.2", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Event catering and other food service activities" },
                    { new Guid("e437e6a2-95c6-45f5-ad8e-534448ba051a"), "I.56.29", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Other food service activities" },
                    { new Guid("2dadcbd7-d712-4ab7-8071-3205c53d1deb"), "J.61.30", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Satellite telecommunications activities" },
                    { new Guid("1588d69f-0960-4e8d-995d-67ede3047d09"), "J.61.9", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other telecommunications activities" },
                    { new Guid("e5ce862a-beec-4097-b42a-8867ceb90316"), "J.61.90", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other telecommunications activities" },
                    { new Guid("545ddda9-4ab4-4df7-9ed3-0d89e780da94"), "J.62", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Computer programming, consultancy and related activities" },
                    { new Guid("5e38988b-f00f-4918-8fed-d8bee324d84f"), "J.62.0", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Computer programming, consultancy and related activities" },
                    { new Guid("c1a7d8bb-2b65-4811-9513-c9ee1ebe9e83"), "J.62.01", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Computer programming activities" },
                    { new Guid("cd4d5428-a44b-4a2e-acf1-78d6c9b927fc"), "J.62.02", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Computer consultancy activities" },
                    { new Guid("dcd4e1ba-fe80-44ef-801b-9a0e9c449026"), "J.62.03", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Computer facilities management activities" },
                    { new Guid("46d9e578-b835-4a7e-9181-7fecc8229a08"), "J.62.09", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other information technology and computer service activities" },
                    { new Guid("4bfde92c-ff02-4476-a099-d649a94e2f43"), "J.63", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Information service activities" },
                    { new Guid("2032e07d-1172-43d5-a041-0a23d749a6d9"), "J.63.1", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("e4022a1a-a287-4a7f-8fdd-d89a09922569"), "J.63.11", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Data processing, hosting and related activities" },
                    { new Guid("68e859d6-5c57-45e3-9b02-f22a2832fe5a"), "J.61.3", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Satellite telecommunications activities" },
                    { new Guid("c1eec041-4c46-40dd-8eb6-35c04d34027e"), "J.63.12", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Web portals" },
                    { new Guid("11e9b7cc-dfbc-498b-854a-5981350ec46f"), "J.63.91", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "News agency activities" },
                    { new Guid("de21878e-3f5f-4b08-b9ab-71903b375fbb"), "J.63.99", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other information service activities n.e.c." },
                    { new Guid("06c6d7cd-11e6-407a-a3a4-7bc6f27c366f"), "K.64", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("26f3d8d0-17f6-495b-b1af-200e2b628bb1"), "K.64.1", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Monetary intermediation" },
                    { new Guid("f0ef8458-b06b-4055-a875-d34717a3daeb"), "K.64.11", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Central banking" },
                    { new Guid("ae36bf58-5c2f-45cb-9f7d-d2c88087405e"), "K.64.19", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Other monetary intermediation" },
                    { new Guid("73527eb1-e5f0-468a-8163-3235d8fb93b2"), "K.64.2", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Activities of holding companies" },
                    { new Guid("e427d3da-2bdf-4967-aa64-beff8ce2bdfc"), "K.64.20", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("778a3370-25ff-4796-8751-2a489805623d"), "K.64.3", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Trusts, funds and similar financial entities" },
                    { new Guid("388ba8a4-816a-40df-9a93-ef8be217e52c"), "K.64.30", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Trusts, funds and similar financial entities" },
                    { new Guid("cd1ca742-6186-49bb-8da5-fbec948f5142"), "K.64.9", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("3190287e-d7ac-445a-8fec-9205b96d409e"), "K.64.91", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Financial leasing" },
                    { new Guid("52db1888-3a39-4fbf-84f6-f5f81629fc88"), "J.63.9", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other information service activities" },
                    { new Guid("906ca695-d497-4ffc-a8a0-aefe1009872f"), "J.61.20", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Wireless telecommunications activities" },
                    { new Guid("ca0d3972-e72a-4299-a7e7-fe5fb382ea0c"), "J.61.2", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Wireless telecommunications activities" },
                    { new Guid("70fbf944-fb80-47e5-bf43-3855233aa4b8"), "J.61.10", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Wired telecommunications activities" },
                    { new Guid("e068fbd8-24a3-4df0-b788-cd4a2a57e804"), "I.56.3", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Beverage serving activities" },
                    { new Guid("6eca3d10-90af-4154-bd10-6f65c86a8a55"), "I.56.30", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Beverage serving activities" },
                    { new Guid("3b8357aa-80f9-41d8-ae88-d6c9e88d3b4f"), "J.58", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Publishing activities" },
                    { new Guid("f8a46c13-cfc9-4e8b-87b1-3aaed5e66e34"), "J.58.1", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("dce9fc01-da07-4af1-b3fe-dc5ec3665a1d"), "J.58.11", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Book publishing" },
                    { new Guid("f6c59cf1-8f47-4839-a4fe-e9967a6799e8"), "J.58.12", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Publishing of directories and mailing lists" },
                    { new Guid("2b253c64-b5b0-4fa5-bdf9-f470f566d4ef"), "J.58.13", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Publishing of newspapers" },
                    { new Guid("0bec9765-2331-4cae-9081-3204720b204b"), "J.58.14", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Publishing of journals and periodicals" },
                    { new Guid("b5727cff-e3fa-4832-8d9e-beac87c5fe59"), "J.58.19", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other publishing activities" },
                    { new Guid("ebc6d24d-42ba-4840-8fed-c9fbb99315a3"), "J.58.2", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Software publishing" },
                    { new Guid("4c74d505-2e9a-42ce-aee6-33e8d24e8061"), "J.58.21", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Publishing of computer games" },
                    { new Guid("2c315cf1-1251-4459-a240-0e20df873cfa"), "J.58.29", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Other software publishing" },
                    { new Guid("14afa03d-afbb-45f8-b299-e0bc1b590772"), "J.59", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("3a8c05b6-2da2-4d3a-ac4c-f8289460a824"), "J.59.1", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Motion picture, video and television programme activities" },
                    { new Guid("113bd33a-915c-494a-9929-003d3be190b0"), "J.59.11", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Motion picture, video and television programme production activities" },
                    { new Guid("0158df47-f48d-4555-bf0c-b21410acbf49"), "J.59.12", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("cc286071-c9db-420a-92c3-2f0e91e1a1be"), "J.59.13", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("616d03ea-bc0a-4df8-83dc-757544ecb2e1"), "J.59.14", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Motion picture projection activities" },
                    { new Guid("1882a633-7187-4f74-be4f-3222f6e43933"), "J.59.2", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Sound recording and music publishing activities" },
                    { new Guid("ee88cce9-a8fb-45e8-b84f-d1e4de9e935e"), "J.59.20", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Sound recording and music publishing activities" },
                    { new Guid("e5ff7992-6c4d-4a78-b226-729a2792de5e"), "J.60", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Programming and broadcasting activities" },
                    { new Guid("bd06b728-3a35-40e8-b827-e1023619cdf0"), "J.60.1", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Radio broadcasting" },
                    { new Guid("121360f1-15fb-45ac-b564-cac4767902bf"), "J.60.10", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Radio broadcasting" },
                    { new Guid("7b444e05-a1ef-40e2-889e-dc6d9feac4d5"), "J.60.2", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Television programming and broadcasting activities" },
                    { new Guid("8ac1d6e9-fada-474a-a081-a7f25b457ae8"), "J.60.20", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Television programming and broadcasting activities" },
                    { new Guid("20d5bf1e-5033-4934-b532-2ce9f00c737d"), "J.61", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Telecommunications" },
                    { new Guid("09cb5b2b-cff0-4873-b04a-c1c306801342"), "J.61.1", new Guid("4bda4415-ce11-4944-97a4-7c461a9226d5"), "Wired telecommunications activities" },
                    { new Guid("738ee16c-f6b2-48d5-9295-700477a6e26d"), "I.56.21", new Guid("bf091239-f956-4d19-9fa5-48e0e4d2a32d"), "Event catering activities" },
                    { new Guid("ad7b1e78-1e92-4ca1-80ee-afbfe97a7619"), "K.64.92", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Other credit granting" },
                    { new Guid("1aba99e7-2cbd-4217-87d2-9b7d916b76eb"), "G.47.82", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("b2c50718-658b-4486-ad98-18d5ceff61a8"), "G.47.8", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale via stalls and markets" },
                    { new Guid("335d043d-bc69-4d40-add6-d27b518793e4"), "G.46.19", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("402ff277-a9a9-459d-98f5-c40c2d11ffe0"), "G.46.2", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("1de284a3-f9b4-4ada-aaf7-e56e54285f47"), "G.46.21", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9bbc7c4d-beac-484e-8e89-0e5cabaaaf8b"), "G.46.22", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of flowers and plants" },
                    { new Guid("146372dc-b71b-4f07-a25d-91ad5fd5d153"), "G.46.23", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of live animals" },
                    { new Guid("43569286-6b56-4f82-b208-d0bc6a0f2917"), "G.46.24", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of hides, skins and leather" },
                    { new Guid("e5159ad4-ed7c-4e72-96fb-cb63a4bdc4e7"), "G.46.3", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("7dba632b-00ec-49a6-a175-2b8134bc33dd"), "G.46.31", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of fruit and vegetables" },
                    { new Guid("fde49abd-aeb3-4aa6-83d1-a097673d1703"), "G.46.32", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of meat and meat products" },
                    { new Guid("a28d60f6-a5a9-485a-abb6-59b7a29afd61"), "G.46.33", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("fb663bd8-ed24-453a-8ee0-51ada3c70a19"), "G.46.34", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of beverages" },
                    { new Guid("ab4ee52f-03ac-4819-8d8d-f65d5dfe8d4e"), "G.46.35", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of tobacco products" },
                    { new Guid("a94654be-6bd4-49d5-90b8-1486602a7cbf"), "G.46.18", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents specialised in the sale of other particular products" },
                    { new Guid("53305514-1741-4330-b316-fd6e52981692"), "G.46.36", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("2d9d4cac-7568-4287-afaf-d5af94a87100"), "G.46.38", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("d6cd086f-7bc9-43ad-802e-c34cceba64f1"), "G.46.39", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("7d42289b-2314-4ab9-a2fd-d9978aa8fb6e"), "G.46.4", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of household goods" },
                    { new Guid("c852dcea-6465-42c8-b84d-33f5e3c65588"), "G.46.41", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of textiles" },
                    { new Guid("0347c0be-4095-4246-a8b5-9117a35578c3"), "G.46.42", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of clothing and footwear" },
                    { new Guid("f31a27a4-fcee-41cd-97c8-a06f70279bdb"), "G.46.43", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of electrical household appliances" },
                    { new Guid("3deadfc4-3609-4340-8f4c-94c42a84ec77"), "G.46.44", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("83b06849-5253-4f52-b91d-794e8e717dda"), "G.46.45", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of perfume and cosmetics" },
                    { new Guid("5b7df0c8-0a4d-49b6-a792-296ffeb6dd86"), "G.46.46", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of pharmaceutical goods" },
                    { new Guid("c58973c9-2cc1-4994-8bbf-0c7a2b9083e7"), "G.46.47", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("c240774c-a0b3-4c03-940c-9cdc1a2a71a9"), "G.46.48", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of watches and jewellery" },
                    { new Guid("013969b3-89c9-4262-afd4-e4ef5e10d3aa"), "G.46.49", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of other household goods" },
                    { new Guid("4cbb980c-732f-4ece-9d48-884ad3a3292e"), "G.46.37", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("e81b6c55-acae-4354-b9a3-3ffed1c8299a"), "G.46.17", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("e3e1a234-6c88-4cd2-b70e-5a84f9be10d9"), "G.46.16", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("e17e9f4d-6c3f-4b2c-a7e4-81a3d3b062ee"), "G.46.15", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("f00e0571-4103-4a50-bfd4-f31244439d49"), "F.43.29", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Other construction installation" },
                    { new Guid("a5bae7a9-52a4-4409-abd1-4726c20272fc"), "F.43.3", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Building completion and finishing" },
                    { new Guid("6780b59c-63e2-4cf9-847c-0f85e511df7e"), "F.43.31", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Plastering" },
                    { new Guid("c882e9d0-839e-4d36-8290-c6b2e172b5c1"), "F.43.32", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Joinery installation" },
                    { new Guid("6ef9aecf-a459-45a8-b53f-6352e9ffd431"), "F.43.33", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Floor and wall covering" },
                    { new Guid("b68dea2c-bc5a-484f-a613-033522f69405"), "F.43.34", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Painting and glazing" },
                    { new Guid("39db0b03-64d0-4c96-90a2-2ee2bed50fa0"), "F.43.39", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Other building completion and finishing" },
                    { new Guid("5820a3d9-76f7-452f-92ba-3299f17f84b6"), "F.43.9", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Other specialised construction activities" },
                    { new Guid("5278fd47-008a-4b46-95b0-01549e961a69"), "F.43.91", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Roofing activities" },
                    { new Guid("8a76b664-d48f-4489-9216-123e50ed04a1"), "F.43.99", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Other specialised construction activities n.e.c." },
                    { new Guid("2253b9c7-7c36-493e-979e-18df337e862c"), "G.45", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("b5e7a7cb-2396-4b54-a6e6-a3837471d653"), "G.45.1", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Sale of motor vehicles" },
                    { new Guid("c8abd5ad-b44f-4541-8d95-077b74b2d68a"), "G.45.11", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Sale of cars and light motor vehicles" },
                    { new Guid("14badcf4-2cf0-4c2c-ba92-603af0f82f52"), "G.45.19", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Sale of other motor vehicles" },
                    { new Guid("d73a2df6-89b0-4460-88b3-ca6e0b054029"), "G.45.2", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2d080d65-aa72-48d0-b46e-b55d95a8bbf6"), "G.45.20", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Maintenance and repair of motor vehicles" },
                    { new Guid("470c606e-6210-45d3-898b-65c36cf0243a"), "G.45.3", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("6ea7b069-6cc6-4842-a0ee-d94f169a729e"), "G.45.31", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("61f0b7d6-3ccb-480b-a05f-8e53f2323f93"), "G.45.32", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("cf354d89-23a7-4086-892e-ec5aa11b1029"), "G.45.4", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("f9508fb7-3ebe-49bf-8da7-7e0b39345061"), "G.45.40", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("c6833b3f-7a57-4d5a-8ef7-2bd0c8fd9706"), "G.46", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("929c5429-14ab-4e03-a045-3e7cc56fed91"), "G.46.1", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale on a fee or contract basis" },
                    { new Guid("ea5fa945-1197-4c74-ad61-55a08f81832b"), "G.46.11", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("3241ac7b-0b42-456d-ba35-869558790a8b"), "G.46.12", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("5f25578c-d725-451d-8bba-c1b99ce1274b"), "G.46.13", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("ae1314e5-319a-4751-883c-7f2e455d09c7"), "G.46.14", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("6a1176ec-e069-4ff1-bcb9-c764fa037a7c"), "G.46.5", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of information and communication equipment" },
                    { new Guid("56cdceb1-0725-4bcb-9142-3dcb8b3c6ccf"), "G.47.81", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("a2c829cb-9643-436c-8441-9185bea0ab11"), "G.46.51", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("d77a20f1-74c3-49e6-9d91-b27aa6fe9d7f"), "G.46.6", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("a937bdb6-a8fa-456f-bb50-6649fa611f17"), "G.47.4", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("29e6ab8e-6a97-4077-80c3-bf748d6c5c1c"), "G.47.41", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("0d0d2b54-571f-42d2-bff9-fa8610c0d3ac"), "G.47.42", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("66635d7c-699b-4679-87f1-0df7ef5d8476"), "G.47.43", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("68425514-1965-407f-aa3b-116a6d4c018e"), "G.47.5", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("55c58d02-e983-4d3b-9559-2c767e3d403b"), "G.47.51", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of textiles in specialised stores" },
                    { new Guid("b4ae4eb2-7e6c-4c2b-a1cd-fd50bdc6a3e3"), "G.47.52", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("a4c35af9-6652-45d1-b708-e948443f6bc1"), "G.47.53", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("2e47093e-1eaf-419f-bbf6-bf4ad1f8f91f"), "G.47.54", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("f5c51eca-f66b-4978-99c5-1e19418032ce"), "G.47.59", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("b944b36d-81d3-4200-938b-f06decb190f4"), "G.47.6", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("8ed313bb-acf3-4ad9-aeea-dc36031fba51"), "G.47.61", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of books in specialised stores" },
                    { new Guid("e294bbbb-71a7-460a-999d-35525d25476e"), "G.47.30", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("8d9793b3-c00d-4f2a-a6fa-d6dd90636378"), "G.47.62", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("2ed5c4d5-4cd6-4e19-899e-3cec37c0bd0d"), "G.47.64", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("335d96e8-5e2d-4bd7-ba03-0f925e59c6d3"), "G.47.65", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("8b2fac1f-025a-4846-af52-76c4dc1064ad"), "G.47.7", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of other goods in specialised stores" },
                    { new Guid("f48b4fc5-88b2-4e54-b125-748b50edbbe1"), "G.47.71", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of clothing in specialised stores" },
                    { new Guid("7281f927-7d13-4ff5-8a47-163a421449cc"), "G.47.72", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("348a26b3-de66-421d-88ff-6a32255f7824"), "G.47.73", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Dispensing chemist in specialised stores" },
                    { new Guid("a46657bb-a769-45d4-bb21-2e3a90addbf4"), "G.47.74", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("af635aad-7930-427e-96d2-b4a8e97b11ea"), "G.47.75", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("c251e052-4deb-407c-a7b3-95220557f122"), "G.47.76", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("5b7e66d1-7449-416b-9490-c36ddc8850fb"), "G.47.77", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("1ccc4f0b-af1e-4b5c-9508-5ff967a01a08"), "G.47.78", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("10eb7a15-fc33-4681-9363-ee3e2c518339"), "G.47.79", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("86d9da5c-911f-4a7f-a6c2-c78ef69cfbe9"), "G.47.63", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("78657b3f-7841-4d05-82a4-f0c573b7f58c"), "G.47.3", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("a27325b9-15a0-41e6-a938-4dfa74379221"), "G.47.29", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Other retail sale of food in specialised stores" },
                    { new Guid("022d88e7-207b-4703-9521-bb1a6cedd667"), "G.47.26", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("0077a541-52bb-4289-95b5-a151fe5233a3"), "G.46.61", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("bc6f84ab-8de2-42eb-b996-299d9f507a0b"), "G.46.62", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of machine tools" },
                    { new Guid("0d86cdb3-71d5-4e35-b31a-05b8f85fdfcc"), "G.46.63", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("03cc4316-b39a-4d17-b315-89be24d55fbf"), "G.46.64", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("b95e61ac-c8fd-4a97-9010-a430b8e36c43"), "G.46.65", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of office furniture" },
                    { new Guid("284b19cd-3b81-4260-bfb6-f39d67254849"), "G.46.66", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of other office machinery and equipment" },
                    { new Guid("fc9ed43a-d121-45a5-a130-0318fbe32a6a"), "G.46.69", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of other machinery and equipment" },
                    { new Guid("04b57ece-ff1d-4e09-b47d-6801fa588b22"), "G.46.7", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Other specialised wholesale" },
                    { new Guid("399b5a26-f930-4dda-b388-7d97251e748c"), "G.46.71", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("12fdb532-c285-4a12-b919-51eb5479a91c"), "G.46.72", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of metals and metal ores" },
                    { new Guid("e13905fe-b78f-441e-a4f1-ee0aec8d0f23"), "G.46.73", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("500a2b95-3349-4a7c-b680-1b47323b2f01"), "G.46.74", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("5a9cd211-b3da-47ce-a4d5-1e850ac4a074"), "G.46.75", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of chemical products" },
                    { new Guid("82468518-eae3-43e6-9ed9-643262360ae5"), "G.46.76", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of other intermediate products" },
                    { new Guid("e0138b45-f7eb-44ff-9b50-74b8475fabf2"), "G.46.77", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of waste and scrap" },
                    { new Guid("981b716b-200c-4b89-9161-8878871e5a11"), "G.46.9", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Non-specialised wholesale trade" },
                    { new Guid("1f03abfe-867e-49e8-a6a2-bba40f3e41a6"), "G.46.90", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Non-specialised wholesale trade" },
                    { new Guid("ebbc3eba-e828-499f-8fa8-514367943928"), "G.47", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("140e11c5-d3d0-4005-8ed1-143ec283994b"), "G.47.1", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale in non-specialised stores" },
                    { new Guid("c2453bab-83d5-47d5-8358-491d4406bf25"), "G.47.11", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("9d1188cd-5151-40ce-bc60-9ddb63a0969c"), "G.47.19", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Other retail sale in non-specialised stores" },
                    { new Guid("ce55311c-7b1e-4009-ae9f-7341dd870972"), "G.47.2", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("969a1d61-9294-4e05-a0c2-b9b8061ca541"), "G.47.21", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("fb81b926-2c4b-4580-94cb-41422486ae73"), "G.47.22", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("a04a43b2-293f-44b3-9c70-be223f8a0d93"), "G.47.23", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("eb0bdde7-7638-425d-af09-4f25a1ed27ee"), "G.47.24", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("10585843-d214-44a0-87aa-c16bdf612296"), "G.47.25", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Retail sale of beverages in specialised stores" },
                    { new Guid("a1d76d41-8eb4-4076-acec-fe344b339106"), "G.46.52", new Guid("b0c128d0-b9ff-4f25-9477-3a1e5ba57d1e"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("dabfd856-2475-4219-9a18-c3fe7ed416f4"), "F.43.22", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("c05cc1e8-8528-4dea-91c1-041b0ba5af45"), "K.64.99", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("9fc3a09d-ad09-4a80-9104-097c08d8c82f"), "K.65.1", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Insurance" },
                    { new Guid("e091d9a5-f3cc-4ab2-8fda-435c254d9f58"), "P.85.6", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Educational support activities" },
                    { new Guid("9387c8fb-0612-4ff2-8c7a-1c23ac43e29b"), "P.85.60", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Educational support activities" },
                    { new Guid("7f0452e4-e907-45e4-932b-3b85e125bffa"), "Q.86", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Human health activities" },
                    { new Guid("f183a046-e893-4a99-bb97-f5b514f68d64"), "Q.86.1", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Hospital activities" },
                    { new Guid("3e0dfc54-e4bd-46d8-9f21-b7ee8f510016"), "Q.86.10", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Hospital activities" },
                    { new Guid("43d2e6bd-4433-47e6-9106-1696f024894b"), "Q.86.2", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Medical and dental practice activities" },
                    { new Guid("ff553beb-d86c-422a-8b86-7e27cbe5016d"), "Q.86.21", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("489cb24e-011b-4558-92d7-5ce7a78d63d0"), "Q.86.22", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Specialist medical practice activities" },
                    { new Guid("4f21bd3f-991a-4c3f-8ebb-7844eeb3e5a8"), "Q.86.23", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Dental practice activities" },
                    { new Guid("311227e8-36e1-4add-b5c3-bb91f844ad86"), "Q.86.9", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Other human health activities" },
                    { new Guid("acf292fb-8d8f-4137-b687-2c92e3f128b1"), "Q.86.90", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Other human health activities" },
                    { new Guid("733e342a-f0f6-496c-8879-1d3199f0cf7e"), "Q.87", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential care activities" },
                    { new Guid("957ab4b3-23ef-4a8e-a83a-bd450aec8f94"), "P.85.59", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Other education n.e.c." },
                    { new Guid("127e8b1e-2105-4d98-b414-8e4c1fedcebb"), "Q.87.1", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential nursing care activities" },
                    { new Guid("6a598637-ae3b-4a86-a759-b239c75d0b8b"), "Q.87.2", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("636d8c44-34be-43d5-9c79-031a184d9bb7"), "Q.87.20", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("d68d36da-bf46-45ea-b2f7-34de87b8bb2c"), "Q.87.3", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential care activities for the elderly and disabled" },
                    { new Guid("fd468d01-6494-4ebc-beb2-7cca4481afe9"), "Q.87.30", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential care activities for the elderly and disabled" },
                    { new Guid("0e71d8e2-7cce-45e0-8f65-52731e1370af"), "Q.87.9", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Other residential care activities" },
                    { new Guid("f0902d36-5eed-4f82-b056-8eb3b8ade3d6"), "Q.87.90", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Other residential care activities" },
                    { new Guid("06614e72-94a2-4e9a-987c-d50751d57baf"), "Q.88", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Social work activities without accommodation" },
                    { new Guid("28d3d568-eae0-4ce9-8c24-87c790fdb1d6"), "Q.88.1", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("76161555-f41e-4ff4-a52a-08439c260586"), "Q.88.10", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("ff23d54e-9dca-43bc-98f0-eea4dd228998"), "Q.88.9", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Other social work activities without accommodation" },
                    { new Guid("838fb2bc-5669-4dd4-bb46-f9875974fcd1"), "Q.88.91", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Child day-care activities" },
                    { new Guid("2253c313-4079-4563-9494-8f1c8318b418"), "Q.88.99", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("c64f7fd2-0cc9-436b-8915-bcb9bdee4d51"), "Q.87.10", new Guid("e226bd73-2d3b-4aab-9ecd-263b2a319e9a"), "Residential nursing care activities" },
                    { new Guid("cf180576-82fb-4328-a19f-8d9ff0064929"), "P.85.53", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Driving school activities" },
                    { new Guid("096de7d0-cfe6-4902-9190-ec6dc4429bd2"), "P.85.52", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Cultural education" },
                    { new Guid("8a5e0ca3-c0e4-4960-8cfe-ada305fa8861"), "P.85.51", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Sports and recreation education" },
                    { new Guid("b37188e4-07f5-4f6d-896c-efaaf4c67489"), "N.82.91", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Packaging activities" },
                    { new Guid("7daaea81-8e34-4c88-8a95-e09bf0bd6ba3"), "N.82.99", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other business support service activities n.e.c." },
                    { new Guid("39ef4d18-7376-4b30-b817-12f476307a1e"), "O.84", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Public administration and defence; compulsory social security" },
                    { new Guid("c6d42d54-4c1e-4991-923c-64b78f872774"), "O.84.1", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("658900b7-215a-4340-a480-81bad3ff18dd"), "O.84.11", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "General public administration activities" },
                    { new Guid("a6e17de5-bcd0-42e9-8edc-756f4c42c3fc"), "O.84.12", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("61a3206a-b363-4b3e-8f56-9b1a5f473a87"), "O.84.13", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("38056ab4-04e4-4202-97f7-9541f37094d3"), "O.84.2", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Provision of services to the community as a whole" },
                    { new Guid("385ac236-34f6-49e0-9364-c511d796ba65"), "O.84.21", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Foreign affairs" },
                    { new Guid("f0962e1b-b97d-4976-8b5e-ae57afd066d8"), "O.84.22", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Defence activities" },
                    { new Guid("f2ddd646-8231-49c2-95f1-d376ba12dc3c"), "O.84.23", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Justice and judicial activities" },
                    { new Guid("0bff81f9-22c6-4e66-8a69-b60786fff5d1"), "O.84.24", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Public order and safety activities" },
                    { new Guid("dda20a24-59ad-405b-9da4-531699071605"), "O.84.25", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Fire service activities" },
                    { new Guid("01f17fa4-9b1f-4e65-bfe2-b46bdc400b08"), "O.84.3", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Compulsory social security activities" },
                    { new Guid("66406887-16c3-4261-b802-3ecc73b12ebd"), "O.84.30", new Guid("24966b83-7436-4906-ad7f-dc12ede23aeb"), "Compulsory social security activities" },
                    { new Guid("a0c452d0-d33c-483a-bf04-7369b418bb1b"), "P.85", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Education" },
                    { new Guid("ad6cc609-b12b-4602-a884-d2ae63f6b976"), "P.85.1", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Pre-primary education" },
                    { new Guid("58b8833c-6b2d-4fe0-b853-fcf4d5ee681f"), "P.85.10", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Pre-primary education" },
                    { new Guid("5bb1c395-0e06-42ba-987c-5e096ad73151"), "P.85.2", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("720f9756-04c4-433e-b2c8-8052277e98c5"), "P.85.20", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Primary education" },
                    { new Guid("52ced68b-f7ef-41ae-9d55-7f3364c3b985"), "P.85.3", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Secondary education" },
                    { new Guid("a79a4705-362a-4efa-8263-75d46d7b0239"), "P.85.31", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "General secondary education" },
                    { new Guid("a7d55c2f-9112-428c-a6af-524c467a243f"), "P.85.32", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Technical and vocational secondary education" },
                    { new Guid("0e717507-2995-461b-88ba-23695f69f106"), "P.85.4", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Higher education" },
                    { new Guid("dd0c324c-244f-4e60-b435-993c644c9dd4"), "P.85.41", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Post-secondary non-tertiary education" },
                    { new Guid("92158f92-dd6c-4b15-b532-f485c5c8013e"), "P.85.42", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Tertiary education" },
                    { new Guid("92c0d365-5ac3-4a9e-8fae-763b4c99b041"), "P.85.5", new Guid("88506514-3596-4428-a63e-6934844e3fc3"), "Other education" },
                    { new Guid("0ab388c5-d56d-44cc-a4cd-e7080e49d20a"), "R.90", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Creative, arts and entertainment activities" },
                    { new Guid("78ce9b03-6cf6-4336-b70f-50620064acb8"), "N.82.92", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("571d306c-9f64-4e37-a4ff-bf1eeaae4dd2"), "R.90.0", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Creative, arts and entertainment activities" },
                    { new Guid("84c00111-d552-44a7-8ee8-11131dc0064c"), "R.90.02", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Support activities to performing arts" },
                    { new Guid("13ef53b7-8249-4e26-90a6-ee98b3657613"), "S.95.1", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of computers and communication equipment" },
                    { new Guid("ec1f0bdc-ab31-4a47-96b1-c22ad45dbc53"), "S.95.11", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of computers and peripheral equipment" },
                    { new Guid("b3f09b9d-4520-4538-a413-81cb1da071e6"), "S.95.12", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of communication equipment" },
                    { new Guid("a637860c-916c-499c-b4b3-b8923ee50b8e"), "S.95.2", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of personal and household goods" },
                    { new Guid("70777bbb-2701-4798-88f8-1ff46c1dc1bf"), "S.95.21", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of consumer electronics" },
                    { new Guid("3a2a3527-9d90-4922-aead-38955f6c2f45"), "S.95.22", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("f09584f1-0aff-4c71-9944-c0b4b501168d"), "S.95.23", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of footwear and leather goods" },
                    { new Guid("74301d64-2dc7-4568-afce-883e9814f9ed"), "S.95.24", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of furniture and home furnishings" },
                    { new Guid("785415bc-2db7-4150-91dd-65413d661f44"), "S.95.25", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of watches, clocks and jewellery" },
                    { new Guid("182a1f91-abba-431a-bf9b-07d0874b5997"), "S.95.29", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of other personal and household goods" },
                    { new Guid("8491f8a1-d3a6-4d81-ac7e-3bf6ba7d12c6"), "S.96", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Other personal service activities" },
                    { new Guid("f26d01bb-9297-4417-9090-ecdcedef3c43"), "S.96.0", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Other personal service activities" },
                    { new Guid("6dac51a4-53b9-4380-a329-146bbb876dde"), "S.95", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Repair of computers and personal and household goods" },
                    { new Guid("a1821c57-1093-42fd-9ba6-a0e37f54388e"), "S.96.01", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("c6d01d60-3f90-4062-9222-30409cee75a8"), "S.96.03", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Funeral and related activities" },
                    { new Guid("70a48efd-d5fc-4cce-8cdb-f5512772e54f"), "S.96.04", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Physical well-being activities" },
                    { new Guid("e3019684-dba1-40b4-8956-3b6933674425"), "S.96.09", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Other personal service activities n.e.c." },
                    { new Guid("a5be002f-71d4-4930-875c-7f08c0a9b2bd"), "T.97", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Activities of households as employers of domestic personnel" },
                    { new Guid("c4c7eb15-eda3-4a06-bbe6-b6e8c3fc14b8"), "T.97.0", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Activities of households as employers of domestic personnel" },
                    { new Guid("aedda5ba-5e4e-4047-9187-fb589ba8b458"), "T.97.00", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Activities of households as employers of domestic personnel" },
                    { new Guid("2ddf2a23-8aac-403b-b92f-2d4409c37385"), "T.98", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("d7136680-8f67-4937-9fed-90feada9aaba"), "T.98.1", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("d37b1764-4026-4bc4-b1c1-66f4fba499e2"), "T.98.10", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("0f189150-de9e-47fd-b6b3-e54c7ec0e70f"), "T.98.2", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("9471cf9c-326f-4fa6-9239-5cd9f7b2ce11"), "T.98.20", new Guid("b65cb2be-084d-4e9b-8551-fdb649a077e4"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("95b239f0-a491-4224-b0c9-aa6666f8f681"), "U.99", new Guid("eb69e668-d56f-4faf-adee-e79dc90933be"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("9fa9080a-2a95-457f-89c5-5a7b30f330b6"), "S.96.02", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Hairdressing and other beauty treatment" },
                    { new Guid("4009a151-2dbf-4964-9ab2-c0c231147962"), "S.94.99", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of other membership organisations n.e.c." },
                    { new Guid("5195873f-a623-4e5f-af9f-be0c5d1be010"), "S.94.92", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of political organisations" },
                    { new Guid("2c6c3925-4805-4cd5-b2c5-95e8bb9a3117"), "S.94.91", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("359c804d-95c0-4aa7-a1e5-f63f536c6c68"), "R.90.03", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Artistic creation" },
                    { new Guid("ac495875-0696-4504-b21f-63c971269b2a"), "R.90.04", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Operation of arts facilities" },
                    { new Guid("1d9e75f1-f01a-4e06-b43d-bb7409eca177"), "R.91", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("4aebf1e7-6206-4dc6-b064-681c6ccdc300"), "R.91.0", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("91e90966-10e1-49bf-8ddf-f86cc156e31d"), "R.91.01", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Library and archives activities" },
                    { new Guid("c7dcf386-6e66-45f2-9737-42d396a0ab34"), "R.91.02", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Museums activities" },
                    { new Guid("e408b116-ee9b-43f3-9ef3-e8fd728988d8"), "R.91.03", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("2b9c9063-c084-45a2-a37a-b442c8236dbd"), "R.91.04", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("2bf43bd4-c756-4385-81ec-59742edef27b"), "R.92", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Gambling and betting activities" },
                    { new Guid("e648567c-cbcc-4767-8a4e-5d32a0ac61a6"), "R.92.0", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Gambling and betting activities" },
                    { new Guid("8df9b93b-d582-4738-bfbe-cfccb48cff73"), "R.92.00", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Gambling and betting activities" },
                    { new Guid("b319dd90-50e7-4114-b85f-4b429615f369"), "R.93", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Sports activities and amusement and recreation activities" },
                    { new Guid("e4e2b18d-7c1d-4ce0-adab-542653847d3c"), "R.93.1", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Sports activities" },
                    { new Guid("30890ee3-99a3-4b6e-b625-50ed7b16d44b"), "R.93.11", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Operation of sports facilities" },
                    { new Guid("00cfeba7-4b6d-4569-95c6-3c820280d26f"), "R.93.12", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Activities of sport clubs" },
                    { new Guid("5934dbd8-380a-477c-98a1-babe2f3774db"), "R.93.13", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Fitness facilities" },
                    { new Guid("b4232ea2-cfa8-4741-a6e6-764f74b0e106"), "R.93.19", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Other sports activities" },
                    { new Guid("c8acb350-5a7c-4456-956b-607b535ea3ff"), "R.93.2", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Amusement and recreation activities" },
                    { new Guid("c85dfb49-766b-49f9-be6d-25eb889478cf"), "R.93.21", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Activities of amusement parks and theme parks" },
                    { new Guid("5f579b61-5601-4e46-8fb0-a642b785171d"), "R.93.29", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Other amusement and recreation activities" },
                    { new Guid("a6acce51-3eb7-49cc-a095-c3e2744aa335"), "S.94", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of membership organisations" },
                    { new Guid("b32212c7-4e24-456b-be48-0208796111e6"), "S.94.1", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("63af0b2c-4c20-4700-9fa4-c782de42f0e6"), "S.94.11", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of business and employers membership organisations" },
                    { new Guid("ce0cc9e5-512e-4218-a6ab-a8bdf6e55632"), "S.94.12", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of professional membership organisations" },
                    { new Guid("8334234e-c376-490a-af51-2ef88e459d9e"), "S.94.2", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of trade unions" },
                    { new Guid("6a475cc3-d0cb-4644-aff6-8f493e0add10"), "S.94.20", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of trade unions" },
                    { new Guid("bc336afd-da1e-4874-86c2-b55a77ad6857"), "S.94.9", new Guid("afa42615-9fd4-439f-b047-c38ba8e23773"), "Activities of other membership organisations" },
                    { new Guid("f7f99101-3b03-4c60-bb2d-85bfe04d55c9"), "R.90.01", new Guid("33277888-149f-4b50-8eb6-3c2e8b95fc7f"), "Performing arts" },
                    { new Guid("8fc74df1-7bd8-4cf5-9a63-395e7df29a20"), "K.65", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("3a9a0632-2a07-4d2d-8727-08da251c9a93"), "N.82.9", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Business support service activities n.e.c." },
                    { new Guid("f3cef898-12e9-43f3-898d-81b48835813a"), "N.82.3", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Organisation of conventions and trade shows" },
                    { new Guid("9550974c-ecd9-41d3-a9a8-774a31038183"), "M.70.1", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Activities of head offices" },
                    { new Guid("4d55692b-d8e2-4d16-a6d3-a6f8a82c6f8c"), "M.70.10", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Activities of head offices" },
                    { new Guid("f9508dd1-7374-4608-8c58-0ccbd5f8b56e"), "M.70.2", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Management consultancy activities" },
                    { new Guid("5759d67f-3cc1-46d1-b277-cbbe691cf660"), "M.70.21", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Public relations and communication activities" },
                    { new Guid("76350671-d7b4-4515-944d-05df04554c9c"), "M.70.22", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Business and other management consultancy activities" },
                    { new Guid("39df3f1e-948c-4a60-a5b0-ab959f70af69"), "M.71", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("b1a7237a-edf1-409d-9122-0ef6a864b04b"), "M.71.1", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("080f8641-f224-46e2-9abd-0b26226a9e54"), "M.71.11", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Architectural activities" },
                    { new Guid("8d48cfaa-9fce-4bf6-b404-bb9c5997f0a6"), "M.71.12", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Engineering activities and related technical consultancy" },
                    { new Guid("45a6db76-7a3d-4c21-a336-c5fbcd40a08a"), "M.71.2", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Technical testing and analysis" },
                    { new Guid("724765d7-e111-4e9f-9534-f293f64dd640"), "M.71.20", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("244cca7d-75ed-4653-8e21-291a93e38c7f"), "M.72", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Scientific research and development" },
                    { new Guid("00d23c89-1de8-4eb3-a6c9-6f7d6e962374"), "M.70", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Activities of head offices; management consultancy activities" },
                    { new Guid("f4274037-4625-4e5e-8e80-3650e9b59115"), "M.72.1", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("97a429d0-ff70-4884-bbd7-4800783dba3f"), "M.72.19", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("c8d12ea9-476c-42ec-8c00-597ac239d032"), "M.72.2", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("9c13b5a6-ef38-4b06-ac4e-834780ab21ed"), "M.72.20", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("bfa1614e-b421-499e-b458-23d7a28058d8"), "M.73", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Advertising and market research" },
                    { new Guid("e5fe699a-8837-40ba-a74b-9fb71f329468"), "M.73.1", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Advertising" },
                    { new Guid("6f163999-4263-432a-b27e-8870f326ec40"), "M.73.11", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Advertising agencies" },
                    { new Guid("24ee3c1f-ac12-44da-a4d1-d915b52c927e"), "M.73.12", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Media representation" },
                    { new Guid("aa2bdb52-23f4-4d59-98c7-2b9af35bf407"), "M.73.2", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Market research and public opinion polling" },
                    { new Guid("37aa4b7d-b796-4d8b-8f15-dd66d01cbb3a"), "M.73.20", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Market research and public opinion polling" },
                    { new Guid("fbfbfc0c-8693-4700-84aa-2d5232373201"), "M.74", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Other professional, scientific and technical activities" },
                    { new Guid("41f7d92d-9483-4e4e-8dd1-93ebe96744be"), "M.74.1", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Specialised design activities" },
                    { new Guid("bce07105-400e-4cad-bcfe-b7a612cc2358"), "M.74.10", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Specialised design activities" },
                    { new Guid("a67e97b1-fd6c-4789-8990-7a47bf88cf4d"), "M.72.11", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Research and experimental development on biotechnology" },
                    { new Guid("522c4365-ecae-429d-9833-f0f0904b4379"), "M.69.20", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("819df264-6ff1-4b1c-bce8-257d2f02c396"), "M.69.2", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("3be4f52c-c8fb-4645-ad8c-ae32524646e6"), "M.69.10", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Legal activities" },
                    { new Guid("25302a07-8c25-4ed7-80bd-69d25a8f28d1"), "K.65.11", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Life insurance" },
                    { new Guid("311777bc-c8b6-4f7b-9362-58580219ddb2"), "K.65.12", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Non-life insurance" },
                    { new Guid("ac504881-1182-4234-928b-a9b815a46360"), "K.65.2", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Reinsurance" },
                    { new Guid("06f4c198-39a7-4120-83a3-16e31d5c5cb6"), "K.65.20", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Reinsurance" },
                    { new Guid("8e49372a-4658-42e7-8b16-49f19873f3bb"), "K.65.3", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Pension funding" },
                    { new Guid("c32da618-bc11-41e6-a7d0-a7080f7c0cf0"), "K.65.30", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Pension funding" },
                    { new Guid("708dc960-9f5f-4e4a-addd-a629b0e8cd48"), "K.66", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("ecfbd149-7bb6-4df6-9343-0a7c87e2cbac"), "K.66.1", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("06b54bfb-3ad4-4807-bf86-756fe6935db0"), "K.66.11", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Administration of financial markets" },
                    { new Guid("123130d5-c2fa-428d-b685-c9de71e726c6"), "K.66.12", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Security and commodity contracts brokerage" },
                    { new Guid("ac00b36b-67d9-48ee-9c92-144a68bb6857"), "K.66.19", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("50dd6523-981f-4959-9dbb-cc078b87f402"), "K.66.2", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("13b2fc52-da53-4b7b-b7ec-50600eaa861a"), "K.66.21", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Risk and damage evaluation" },
                    { new Guid("25dcec5e-e86b-4767-a373-5f3ec3c04272"), "K.66.22", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Activities of insurance agents and brokers" },
                    { new Guid("8ec57526-0a66-4365-a3e4-6be2171818e6"), "K.66.29", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("d92d13d6-730e-4646-aeac-10be8cc7d110"), "K.66.3", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Fund management activities" },
                    { new Guid("bfdd8aa2-2761-4f7c-97a1-7ba02a1e1c26"), "K.66.30", new Guid("667e1b5c-a8ab-4ad1-ba36-cb0b0b174cbd"), "Fund management activities" },
                    { new Guid("ba01e4ca-bfff-470e-af05-49d2dae3ad96"), "L.68", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Real estate activities" },
                    { new Guid("d856ed2f-f731-4894-b2f0-37b452ddbb35"), "L.68.1", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Buying and selling of own real estate" },
                    { new Guid("77a2ff5d-95e3-49df-af61-263aea97093d"), "L.68.10", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Buying and selling of own real estate" },
                    { new Guid("ae1669fd-a66e-492c-916e-c76acf6f9282"), "L.68.2", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Renting and operating of own or leased real estate" },
                    { new Guid("77e16cd6-fac8-4014-aa96-e56312d8bd5f"), "L.68.20", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Renting and operating of own or leased real estate" },
                    { new Guid("1b1e6a3e-9a96-4a08-a61c-04d2d446207a"), "L.68.3", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6eb2d7b1-cd14-40c2-861c-40efd55cbdb8"), "L.68.31", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Real estate agencies" },
                    { new Guid("f38e45f4-6b18-419a-babb-70f523c2ad52"), "L.68.32", new Guid("cce04003-f93b-42ec-b493-a82cf54f520b"), "Management of real estate on a fee or contract basis" },
                    { new Guid("74938f2d-a766-49bd-a074-174421b44d51"), "M.69", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Legal and accounting activities" },
                    { new Guid("3bf1ef0c-c81b-4cf4-824b-1c20b94455d0"), "M.69.1", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Legal activities" },
                    { new Guid("c7ae91e8-23c0-4266-b3d1-d4dbf0072adf"), "M.74.2", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Photographic activities" },
                    { new Guid("eaddeab1-28e3-4361-b2f5-cf9e848892c9"), "N.82.30", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Organisation of conventions and trade shows" },
                    { new Guid("9ebb004c-0e0a-4189-ae51-b44299288ac3"), "M.74.20", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Photographic activities" },
                    { new Guid("ead605e7-0b27-4de3-8c13-4c078d83abcf"), "M.74.30", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Translation and interpretation activities" },
                    { new Guid("f3754c18-9219-47b5-ad76-5f2520d01af9"), "N.79.11", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Travel agency activities" },
                    { new Guid("a239d262-2655-40dd-9704-cccddb16cf5f"), "N.79.12", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Tour operator activities" },
                    { new Guid("c19aef27-704a-440c-8f63-5b6dedb746e6"), "N.79.9", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other reservation service and related activities" },
                    { new Guid("1cdd1280-5da8-4d2a-baf5-77f2049c0290"), "N.79.90", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other reservation service and related activities" },
                    { new Guid("54550068-c353-42fe-849e-72555ee8c61f"), "N.80", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Security and investigation activities" },
                    { new Guid("b238b4cc-05a2-406d-af02-36c7ead29e96"), "N.80.1", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Private security activities" },
                    { new Guid("4e93e828-9e3e-42a3-8605-4636eba262f8"), "N.80.10", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Private security activities" },
                    { new Guid("3c1cc38b-f8b2-488c-b25e-6a79c96ee691"), "N.80.2", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Security systems service activities" },
                    { new Guid("f13dbdac-abdd-44fa-aabd-7619cc0660c1"), "N.80.20", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Security systems service activities" },
                    { new Guid("0d7a31e1-3ed6-4fe7-be60-664ba5c10cea"), "N.80.3", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Investigation activities" },
                    { new Guid("c880d3df-e119-4655-8b3b-5aecee2ccef2"), "N.80.30", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Investigation activities" },
                    { new Guid("cba64c17-0282-48ef-9c29-ddee66dd62b8"), "N.81", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Services to buildings and landscape activities" },
                    { new Guid("cd6da1f4-deda-4baa-aa14-2015a0109dd2"), "N.79.1", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Travel agency and tour operator activities" },
                    { new Guid("fdad66f8-6c08-4f9e-a596-759af245e5c4"), "N.81.1", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Combined facilities support activities" },
                    { new Guid("306cead3-0f10-48ad-b046-5e8bef0fa1f4"), "N.81.2", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Cleaning activities" },
                    { new Guid("7e84d4a2-35b5-46fb-a5e5-40a3e2c71536"), "N.81.21", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "General cleaning of buildings" },
                    { new Guid("5841dd84-36d6-4098-ad8f-608be8750cfc"), "N.81.22", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other building and industrial cleaning activities" },
                    { new Guid("255297b9-6224-4e56-a679-14542759a268"), "N.81.29", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other cleaning activities" },
                    { new Guid("c8f02240-1b30-442e-89c9-1f11c78b8982"), "N.81.3", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Landscape service activities" },
                    { new Guid("f36e2059-775e-41fd-9ccb-9964b90eb7a2"), "N.81.30", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Landscape service activities" },
                    { new Guid("9033412f-5957-467b-a185-f450178f0ff2"), "N.82", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Office administrative, office support and other business support activities" },
                    { new Guid("5ec13d8a-dd64-4582-8fd7-d864d7dc4255"), "N.82.1", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Office administrative and support activities" },
                    { new Guid("4edc950f-1070-47d2-b382-e16fefb38d7e"), "N.82.11", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Combined office administrative service activities" },
                    { new Guid("942f33d1-ac4a-4544-8e03-a41188dfc26e"), "N.82.19", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("adaab10a-ea6c-49d1-988e-4bc53cb09d89"), "N.82.2", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Activities of call centres" },
                    { new Guid("7f08ae3b-cce5-4992-a788-580ca0ad2293"), "N.82.20", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Activities of call centres" },
                    { new Guid("51e5a6cb-691f-4415-879c-003895f940d9"), "N.81.10", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Combined facilities support activities" },
                    { new Guid("313d9f00-aaad-4f88-89d1-b61448a53960"), "N.79", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("5878da43-aaec-4718-b6cd-32de7959915f"), "N.78.30", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other human resources provision" },
                    { new Guid("0a560cf8-e019-4847-871e-a8ca084aade9"), "N.78.3", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Other human resources provision" },
                    { new Guid("27b379d2-aec3-4258-a0e3-0033b4deb77c"), "M.74.9", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("9fb6dfcf-036a-42f5-b7ce-0799cc8216da"), "M.74.90", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("b7a3fb3f-547c-42f1-b32a-a06b8b7d50b8"), "M.75", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Veterinary activities" },
                    { new Guid("592eceb3-7da0-47ce-85e4-b019f853dde4"), "M.75.0", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ea67f0c2-5e0b-4bca-857e-c24794717e12"), "M.75.00", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Veterinary activities" },
                    { new Guid("7f1307b8-fe74-4853-944a-a4c5adcfa472"), "N.77", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Rental and leasing activities" },
                    { new Guid("3fdf7916-c836-4631-a742-3abd1a35f118"), "N.77.1", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of motor vehicles" },
                    { new Guid("50affff2-20c5-402d-888d-626d102d43fc"), "N.77.11", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("51578405-ce54-4eb4-ad3f-83c22d445cce"), "N.77.12", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of trucks" },
                    { new Guid("750cbafe-e16e-4889-8372-1ad57f66de9e"), "N.77.2", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of personal and household goods" },
                    { new Guid("1e73a794-97ed-424a-afa9-0d88177d0047"), "N.77.21", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("c85f0497-cc46-41b2-ab63-e483d01705c6"), "N.77.22", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting of video tapes and disks" },
                    { new Guid("9ec2dcf9-702c-4f68-a0aa-19527f358b3e"), "N.77.29", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of other personal and household goods" },
                    { new Guid("1bc0871e-43d0-46c0-9c2e-7364ef1f62f2"), "N.77.3", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("715e1ccc-1b9e-464a-87b7-1b048d94d405"), "N.77.31", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("72937bce-1f07-463e-8de0-15f03c2121ef"), "N.77.32", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("c01ab3d8-bbdc-49f7-976c-6b1b5b31d8ac"), "N.77.33", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("cec8eba8-fcbc-45df-90c6-cb7e602a9352"), "N.77.34", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of water transport equipment" },
                    { new Guid("82115f06-9b03-4501-88e0-0f6a6c5aa20a"), "N.77.35", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of air transport equipment" },
                    { new Guid("68aabd6a-d4a2-4642-bab8-8b31c38b8a3d"), "N.77.39", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("a43e7366-c688-499c-a9f3-a07cbbd98ba7"), "N.77.4", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("2c19e6c8-d79e-40cd-abf5-3cb23b9434eb"), "N.77.40", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("158f823d-3752-44fd-ac90-8c5c7373cbed"), "N.78", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Employment activities" },
                    { new Guid("4642cec9-0fc2-4406-b2b7-dcba3a0f4cf9"), "N.78.1", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Activities of employment placement agencies" },
                    { new Guid("2427ed5c-601d-469f-b2b5-b1f886384c12"), "N.78.10", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Activities of employment placement agencies" },
                    { new Guid("383e09fd-52b5-4a7b-bef4-c19f3a218c51"), "N.78.2", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Temporary employment agency activities" },
                    { new Guid("da032cee-99e3-4b82-95de-a3eae2c3ec8d"), "N.78.20", new Guid("a66a1be0-1ccc-4336-ba15-a14e3141bea9"), "Temporary employment agency activities" },
                    { new Guid("73377fc0-4824-4a2a-8696-97da94145986"), "M.74.3", new Guid("c156c51b-507f-4730-8938-acf2272d2845"), "Translation and interpretation activities" },
                    { new Guid("fad83026-82d3-49df-82e9-5b286579a19c"), "U.99.0", new Guid("eb69e668-d56f-4faf-adee-e79dc90933be"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("c31df8ff-5ced-4347-9607-81bb2c0fde06"), "F.43.21", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Electrical installation" },
                    { new Guid("823e74ca-3cf7-4017-b04f-10482e831360"), "F.43.13", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Test drilling and boring" },
                    { new Guid("27f322c1-cec7-4d24-9768-eed984ade306"), "C.14.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of articles of fur" },
                    { new Guid("fb2d22a1-8042-439b-aff2-a954b4e6fad7"), "C.14.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of articles of fur" },
                    { new Guid("a53b94f8-744b-4928-bca2-d73f40e47293"), "C.14.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("d3b763a5-cecd-4a66-a741-021d7a65e938"), "C.14.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("15fc27eb-d097-4de5-995d-bacc81024d85"), "C.14.39", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("ef2761ef-1b56-4c4b-8c85-4560889c1bb6"), "C.15", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of leather and related products" },
                    { new Guid("f8017128-53f5-41ea-8d50-28d0e4157c72"), "C.15.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("66885d63-f78f-4bcd-931b-01680452033e"), "C.15.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("2a1fe91f-74c0-4818-a186-0ab628b09041"), "C.15.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("1be9683f-e5a5-41b6-8db4-2938be5dce32"), "C.15.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of footwear" },
                    { new Guid("43fe6078-7b39-4b97-b646-23959ef676d1"), "C.15.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of footwear" },
                    { new Guid("7910aaaa-aac3-44c7-bff4-b349963bcffe"), "C.16", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("a20101de-f3f7-4c3c-8ad6-5b665a11ed4f"), "C.14.19", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("46779704-5249-4d37-8e69-39b918be8307"), "C.16.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Sawmilling and planing of wood" },
                    { new Guid("2331b4c3-5873-4161-aeb1-a581fe7907f3"), "C.16.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f25be55c-5926-4f94-851b-f58b4e027a1a"), "C.16.21", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("fb58873e-6d12-4bcf-bb3c-6c081928fdab"), "C.16.22", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of assembled parquet floors" },
                    { new Guid("c1bebd40-75ad-4b57-99bc-ea9f11ec34d2"), "C.16.23", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("1a4fd183-7c81-4f9d-baf1-89f5b57428ec"), "C.16.24", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wooden containers" },
                    { new Guid("a22e4218-0285-4e5a-a0c7-e83693e8372c"), "C.16.29", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("0e8d9f4d-69f8-4a68-9ef5-11e27ac56791"), "C.17", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of paper and paper products" },
                    { new Guid("93cb18c7-9432-42e1-8b27-ead2380815cc"), "C.17.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("75efa2a7-fc9b-42fe-9a6b-a9dd4b6ff512"), "C.17.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of pulp" },
                    { new Guid("06b55710-8026-4b02-8b2f-03dd7a9370c1"), "C.17.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of paper and paperboard" },
                    { new Guid("b71b10e2-621c-41e0-90b1-5bfac2f8b33b"), "C.17.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("877f0bd0-d0ce-4b43-aa74-d4bc737a6294"), "C.17.21", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("a15ca7bd-da9b-47ae-86bb-74ae8573892e"), "C.16.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Sawmilling and planing of wood" },
                    { new Guid("25a461c8-a913-4517-bb5e-b822110c813c"), "C.14.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of underwear" },
                    { new Guid("b9cb2225-325f-4611-ba4f-37a167c9a014"), "C.14.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other outerwear" },
                    { new Guid("7a490467-bafd-4485-bc60-f4554f84c189"), "C.14.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of workwear" },
                    { new Guid("a9e4ff5a-790f-4524-9569-30f31aa236f5"), "C.11.02", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wine from grape" },
                    { new Guid("b37eb503-5bdb-44f1-a1e0-1dc55f8a7490"), "C.11.03", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cider and other fruit wines" },
                    { new Guid("171cc4b0-215c-451e-ae1d-7dc2386b7154"), "C.11.04", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("148e9aff-7ba8-461b-bbeb-760e7cec13c0"), "C.11.05", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of beer" },
                    { new Guid("5faa2046-7c07-481d-961e-23a7d9f381e9"), "C.11.06", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of malt" },
                    { new Guid("9fc2d1c3-e02c-4212-abfd-445938af32ae"), "C.11.07", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("9b0b5cd1-7e10-40e4-8918-1482b24cb792"), "C.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tobacco products" },
                    { new Guid("ca9fb2c7-0028-41b9-8998-43cd770599e8"), "C.12.0", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tobacco products" },
                    { new Guid("146c62f2-2339-41ca-b254-e2ca3609eb29"), "C.12.00", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tobacco products" },
                    { new Guid("ab9d307c-e5e4-441b-afa3-fa8b72e2a632"), "C.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of textiles" },
                    { new Guid("031b634a-0cb4-4d56-bfa5-12c6657f6b14"), "C.13.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Preparation and spinning of textile fibres" },
                    { new Guid("fad11171-8245-449b-865d-879dc72855c2"), "C.13.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Preparation and spinning of textile fibres" },
                    { new Guid("59a912c6-15bc-4f4e-9948-fc3abc9741b5"), "C.13.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Weaving of textiles" },
                    { new Guid("da03911c-63a8-41bc-a499-9a244ad0953c"), "C.13.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Weaving of textiles" },
                    { new Guid("a9e699dc-cab9-4d3b-9aa3-c8e258ea3da4"), "C.13.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Finishing of textiles" },
                    { new Guid("546c16da-89de-4a95-922a-49f2be83e925"), "C.13.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Finishing of textiles" },
                    { new Guid("1ba9fdab-6065-45fc-8d6c-8d3e75c913be"), "C.13.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other textiles" },
                    { new Guid("f4001b12-4b8d-43ed-8a30-97c9531bb4a8"), "C.13.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("0c2dad5d-10b3-4b2e-a583-5bf71c00bd6e"), "C.13.92", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("1a74c554-2a54-4126-ad66-24874ec316ae"), "C.13.93", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of carpets and rugs" },
                    { new Guid("b5c64e98-8e7d-49e9-864c-e980f896ec39"), "C.13.94", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("522f45b5-1abc-46dd-9a81-fe7142af9a0d"), "C.13.95", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("cc0b1188-ae27-4a47-a9aa-8d7fa16799be"), "C.13.96", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("fb69c779-80f1-4740-b88b-84b7a5b492d1"), "C.13.99", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other textiles n.e.c." },
                    { new Guid("92a3f91c-e264-499f-b88f-d4bcee529606"), "C.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wearing apparel" },
                    { new Guid("93cc14b3-ab93-4c93-bb84-873342958022"), "C.14.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("cfddbc89-d673-47a6-b6c4-541598fa626a"), "C.14.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9bb45084-0682-4f5e-8418-997ffb9934bb"), "C.17.22", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("6b4ac515-a012-4cf3-9904-526c51d3481c"), "C.11.01", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("d59149b7-53d3-4045-839f-b6f7e732804a"), "C.17.23", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of paper stationery" },
                    { new Guid("70bb5038-1756-4574-9bc7-205ec111a28f"), "C.17.29", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("b6398888-b5b2-4e0d-a67a-93fbc229b3fb"), "C.20.52", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of glues" },
                    { new Guid("470ada15-ef3e-4159-b2f2-615631724884"), "C.20.53", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of essential oils" },
                    { new Guid("f56a2370-7ae6-4ca3-9d57-e5dd7627f0f7"), "C.20.59", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("d6ac72d3-0b41-4464-acb7-75c621fd8dc7"), "C.20.6", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of man-made fibres" },
                    { new Guid("e2c6bcce-3bf5-4d94-83e5-c1d55b5f712a"), "C.20.60", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of man-made fibres" },
                    { new Guid("68c5c7ff-c9ad-4e4a-a0e4-43fbd08916b0"), "C.21", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("f0483792-f1c5-4b18-97f3-dfb0ccb2cbbc"), "C.21.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("85d1e468-f986-430e-87a8-953594d795b8"), "C.21.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("1b853151-823f-4c51-b08c-fdce55ca0868"), "C.21.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("9c288f74-ad7d-4495-8cea-a413610b1590"), "C.21.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("5dfc4bae-69db-4500-b3c3-4305baf206f8"), "C.22", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of rubber and plastic products" },
                    { new Guid("7d485805-acb1-4366-9730-e131172900f2"), "C.22.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of rubber products" },
                    { new Guid("801e9442-c189-40d1-82fc-fc66e2227ddc"), "C.20.51", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of explosives" },
                    { new Guid("5a5be25d-d409-4a3c-9e90-bc9b182e68cd"), "C.22.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("d89059b0-e014-44d5-9401-feb2f775c8ec"), "C.22.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of plastics products" },
                    { new Guid("3b7ef494-9657-4d3a-bf1c-2b19e13e6367"), "C.22.21", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("11b8b1e8-0889-4853-ba5d-65569a8eab0e"), "C.22.22", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of plastic packing goods" },
                    { new Guid("db81eae3-25d8-4961-96c0-72d6ace3edcb"), "C.22.23", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("ba29bb17-5c0a-411c-8bb8-e88df95eab7e"), "C.22.29", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other plastic products" },
                    { new Guid("691542b8-9f30-4514-bbe5-a9a1e57473d0"), "C.23", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("ca85266b-704a-4da6-9514-bf561f1083de"), "C.23.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of glass and glass products" },
                    { new Guid("f5f35613-2ad8-483d-a7f0-1c989124ee50"), "C.23.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of flat glass" },
                    { new Guid("6294370b-d71d-4062-84cf-6ed4e87d2305"), "C.23.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Shaping and processing of flat glass" },
                    { new Guid("42c81f0f-0063-43fe-8812-af6edd2d9b8d"), "C.23.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of hollow glass" },
                    { new Guid("ea737023-038d-4828-89e0-434dafc9271d"), "C.23.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of glass fibres" },
                    { new Guid("09c84720-ec9e-46c4-bb58-dced4d5055e1"), "C.23.19", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("1650b428-2c4d-4d47-9c99-3358bae827e5"), "C.22.19", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other rubber products" },
                    { new Guid("c30579df-ed1c-4bef-8660-75c9cd1067b1"), "C.20.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other chemical products" },
                    { new Guid("ba7cbe12-eb54-4a38-9a6a-242eac71b0df"), "C.20.42", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("980d404f-9420-42e8-88db-ac5cf942da5f"), "C.20.41", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("0486b58d-52f3-4e5b-9f5b-a8b9602e9ac9"), "C.18", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Printing and reproduction of recorded media" },
                    { new Guid("39f4bbd3-4a30-4714-ad45-7536d6c215e0"), "C.18.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Printing and service activities related to printing" },
                    { new Guid("dc571190-5f4e-40e1-a476-902f4b0eb44f"), "C.18.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Printing of newspapers" },
                    { new Guid("a626a655-0e5f-4d7d-bf8f-c3f57556d4f2"), "C.18.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Other printing" },
                    { new Guid("3b8b02e8-c380-4dfb-a202-6671613a50c9"), "C.18.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Pre-press and pre-media services" },
                    { new Guid("ba9624ea-97bb-4047-b527-2573650a6f39"), "C.18.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Binding and related services" },
                    { new Guid("443d22ed-ebc1-45de-b03a-cb45561a8f08"), "C.18.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Reproduction of recorded media" },
                    { new Guid("71025339-43d1-4f1c-bf5d-5072e17e808e"), "C.18.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("97d39e49-122b-41c8-b507-c46395452b86"), "C.19", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("62774202-d955-4f80-988d-6bfca7b6666e"), "C.19.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of coke oven products" },
                    { new Guid("dc5f04f8-abd1-4c4a-86df-b9d04edd96f7"), "C.19.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of coke oven products" },
                    { new Guid("481ba042-21ae-4e93-a67f-4e2e577387b2"), "C.19.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of refined petroleum products" },
                    { new Guid("35ff09ff-1453-438c-a5d2-2611c8dc7811"), "C.19.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of refined petroleum products" },
                    { new Guid("4b025dce-79d0-4818-9324-0fff24a26daf"), "C.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of chemicals and chemical products" },
                    { new Guid("3e865597-e371-48ac-be8e-fd9d6dcb7abd"), "C.20.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("40ca3f4d-72b1-4cd2-8989-6a2aade76c87"), "C.20.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of industrial gases" },
                    { new Guid("77218cab-a12b-4274-ac00-02d51a3ef31b"), "C.20.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of dyes and pigments" },
                    { new Guid("40855956-26ba-4c7e-a519-03b9e2bd65ea"), "C.20.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("92ae2129-89b6-4846-b826-87ca2cf0a824"), "C.20.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other organic basic chemicals" },
                    { new Guid("ad55956d-b8b4-4c8d-9091-4a725137a1d8"), "C.20.15", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("61d2259b-3607-4bb3-8b7e-b3b4aecc03aa"), "C.20.16", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of plastics in primary forms" },
                    { new Guid("00500172-d654-481f-b3d8-7a9a193defa4"), "C.20.17", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("a5a7a931-88f5-4c7b-96f0-be51841931a4"), "C.20.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("08e5917c-359e-4ef2-9502-a96ff74d303c"), "C.20.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("7f341d0a-6ad9-4095-b53f-bab7e4a23425"), "C.20.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("dde2ce15-0432-46a5-9f71-729b0249d731"), "C.20.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("6b7986fa-922e-4b0d-92f3-d024b5f800bb"), "C.20.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("35fd60f5-eeb8-489c-bd90-9bb51c25b78d"), "C.17.24", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wallpaper" },
                    { new Guid("bf533005-bd36-45ee-b9d8-e2822186b66f"), "C.23.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of refractory products" },
                    { new Guid("bdbeb554-6cf3-42d6-a23a-8e26541c7951"), "C.11.0", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of beverages" },
                    { new Guid("dc24f468-ad8f-42e6-8693-810cca7441e6"), "C.10.92", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of prepared pet foods" },
                    { new Guid("70af1819-eba3-4bc9-971b-79ab168f4807"), "A.01.6", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("7fa0083c-4c42-4d7a-ab92-6e7d712b96eb"), "A.01.61", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Support activities for crop production" },
                    { new Guid("d39642ee-1c59-441c-aa1a-e2d7acafa22c"), "A.01.62", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Support activities for animal production" },
                    { new Guid("b9784608-af53-4f41-9ccf-46fba91427fd"), "A.01.63", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Post-harvest crop activities" },
                    { new Guid("902a46cc-1abb-4469-9b5c-bf6bada717fe"), "A.01.64", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Seed processing for propagation" },
                    { new Guid("b95078df-fa5e-44db-89b6-0beaf8d2c727"), "A.01.7", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Hunting, trapping and related service activities" },
                    { new Guid("fe1d5176-5ed5-47d1-9d6c-9ef66bf2dfa0"), "A.01.70", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Hunting, trapping and related service activities" },
                    { new Guid("2d8eaa6f-54e5-44b8-8e8e-ed5c91bbb5ed"), "A.02", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Forestry and logging" },
                    { new Guid("b228caf1-5903-4aac-b378-2484596a5039"), "A.02.1", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Silviculture and other forestry activities" },
                    { new Guid("67cdb0fd-f5cf-479d-ac63-a33438272632"), "A.02.10", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Silviculture and other forestry activities" },
                    { new Guid("4d896d11-8cb5-40ba-8d66-849535bb7c57"), "A.02.2", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Logging" },
                    { new Guid("83af0724-e075-4d15-b0d0-682a2e8a10f2"), "A.02.20", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Logging" },
                    { new Guid("7f23198c-1bce-45ab-a29b-d3ad8ef634cd"), "A.01.50", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Mixed farming" },
                    { new Guid("7b03d44c-b4b3-413c-9edc-eeb47d9d2e18"), "A.02.3", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Gathering of wild growing non-wood products" },
                    { new Guid("3588927e-6a4f-4d01-b3ad-a540ef51466f"), "A.02.4", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Support services to forestry" },
                    { new Guid("e95d22d4-24b7-40d6-8f1a-e27d3ded98a9"), "A.02.40", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Support services to forestry" },
                    { new Guid("cb0cec23-4ed7-4c54-abbb-0ee1a858247c"), "A.03", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Fishing and aquaculture" },
                    { new Guid("5cb4afa9-c939-41c6-80f9-dd0532aa3024"), "A.03.1", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Fishing" },
                    { new Guid("b223bcd3-3f7c-4ee2-a912-ae77ae540048"), "A.03.11", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("707d21af-eef7-404f-be5b-5bc14428b8fa"), "A.03.12", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Freshwater fishing" },
                    { new Guid("d87ff523-b5bb-49cb-958f-c49db4ef918b"), "A.03.2", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Aquaculture" },
                    { new Guid("8aa837f3-b769-4913-bd96-ef73db7e6533"), "A.03.21", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Marine aquaculture" },
                    { new Guid("2fdbffec-f19a-4e4b-9a60-8ebdb1bf3d87"), "A.03.22", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Freshwater aquaculture" },
                    { new Guid("030621c9-8068-4b1e-a598-19ae7a5ebcfe"), "B.05", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of coal and lignite" },
                    { new Guid("c992313f-c58d-41cf-aa40-66b4c62d5c47"), "B.05.1", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of hard coal" },
                    { new Guid("b9d99485-08d4-42e5-8b57-876d6bd7cbe9"), "B.05.10", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of hard coal" },
                    { new Guid("86ffedfc-3e05-46b1-9ce6-5ad49635c5b7"), "A.02.30", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Gathering of wild growing non-wood products" },
                    { new Guid("92102add-6837-4464-a5f0-af5ecca8e658"), "A.01.5", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Mixed farming" },
                    { new Guid("c93ca502-cd98-4cc8-8482-273f4f771ef4"), "A.01.49", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of other animals" },
                    { new Guid("69858ced-4261-416a-bf88-2643a92a039d"), "A.01.47", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of poultry" },
                    { new Guid("cc989b7b-ce51-4320-8728-e833d130d019"), "A.01.1", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of non-perennial crops" },
                    { new Guid("8d1ae470-f1de-4560-bf8c-b0e10cf3a0a0"), "A.01.11", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("a6aa7e00-1127-4e92-9859-da41c696042e"), "A.01.12", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of rice" },
                    { new Guid("39bad28f-52f3-4da4-b3ff-951bbe491cd2"), "A.01.13", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("4a804eaa-eac9-49fe-b205-5e066a7562a2"), "A.01.14", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of sugar cane" },
                    { new Guid("8b20f132-0780-4756-8e3b-fe8ac0d1bb8f"), "A.01.15", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of tobacco" },
                    { new Guid("69c965ff-c045-41b3-9e8b-3afcd194c720"), "A.01.16", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of fibre crops" },
                    { new Guid("6367d6e5-ade7-4210-954d-7277754ba6b8"), "A.01.19", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of other non-perennial crops" },
                    { new Guid("1979ff68-e0be-4226-be75-94fb43815b76"), "A.01.2", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of perennial crops" },
                    { new Guid("b6eb62a5-ed28-477d-bd38-5ee50d131f16"), "A.01.21", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of grapes" },
                    { new Guid("1dd66b4e-93fa-4b9d-a5d5-95558b9c39b0"), "A.01.22", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of tropical and subtropical fruits" },
                    { new Guid("4e67342f-467b-47eb-af43-4525843fc700"), "A.01.23", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of citrus fruits" },
                    { new Guid("fee7dddd-982c-4582-870b-36e4688ee699"), "A.01.24", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of pome fruits and stone fruits" },
                    { new Guid("67f15128-d5f8-4965-92d4-edd643f83ed1"), "A.01.25", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("a9c8db06-0239-4d53-a54b-c14cb3677566"), "A.01.26", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of oleaginous fruits" },
                    { new Guid("97f62b25-9736-47ea-aaa3-f7870f34f354"), "A.01.27", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of beverage crops" },
                    { new Guid("2b5eea61-d669-46e0-ad65-e08204fe5d70"), "A.01.28", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("5aabeb9a-9619-4652-a01a-917d5c23c97b"), "A.01.29", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Growing of other perennial crops" },
                    { new Guid("67c464c2-8cd9-4b23-88fb-a9319538c6b6"), "A.01.3", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Plant propagation" },
                    { new Guid("52780104-d780-4829-8655-707909d8e956"), "A.01.30", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Plant propagation" },
                    { new Guid("7ccaea0c-f534-4208-8742-74d2bd6f51e2"), "A.01.4", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Animal production" },
                    { new Guid("cf37ef9e-1da7-4b51-9d0c-00539efad884"), "A.01.41", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of dairy cattle" },
                    { new Guid("395acaa1-2255-4e09-9825-aeea21b3f82d"), "A.01.42", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of other cattle and buffaloes" },
                    { new Guid("4808b21a-de3e-45ac-953b-ce19dd373ac0"), "A.01.43", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of horses and other equines" },
                    { new Guid("4b44bb0d-d730-4d46-a49b-e17b01a87c6f"), "A.01.44", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of camels and camelids" },
                    { new Guid("e2db4cfe-f102-4144-a194-19abd51363cb"), "A.01.45", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of sheep and goats" },
                    { new Guid("781249aa-128b-43da-8678-23c9655e132e"), "A.01.46", new Guid("97ba6444-e851-409c-8b2c-2fcf60037c85"), "Raising of swine/pigs" },
                    { new Guid("1f725381-cc3a-40e6-9b18-fd065e57461d"), "B.05.2", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of lignite" },
                    { new Guid("b0c0947e-6619-47b7-b736-cff795470ffc"), "C.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of beverages" },
                    { new Guid("061a8dc8-b88e-4167-9a2d-e2728a66fd1e"), "B.05.20", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of lignite" },
                    { new Guid("71d3e2ba-db75-4421-9035-20b01e1d8dd9"), "B.06.1", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c786ad20-23c3-417c-b373-828f76a7e481"), "C.10.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of potatoes" },
                    { new Guid("4648a300-3c38-4df1-82a2-c0d15af18027"), "C.10.32", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("564d0164-8a15-41e5-b75c-05cd1d7311dd"), "C.10.39", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("a60f5a4b-dcd0-4b8b-9c46-969427610c89"), "C.10.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("573100b0-17e9-4e54-897d-d10cdd4178a5"), "C.10.41", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of oils and fats" },
                    { new Guid("374d511f-83b3-4288-b99d-ba4ac007b07c"), "C.10.42", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("3605a15d-d46b-4381-8b3a-32571882f0ce"), "C.10.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of dairy products" },
                    { new Guid("541f890f-56b5-4263-aa72-3bcf8bd36390"), "C.10.51", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Operation of dairies and cheese making" },
                    { new Guid("132df0fb-253f-49dc-8cef-382487128dab"), "C.10.52", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ice cream" },
                    { new Guid("6e39e684-8599-4a94-bc26-e7e8ce42c83b"), "C.10.6", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("bf83bf79-0430-41a6-9716-63e3f5e3c632"), "C.10.61", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of grain mill products" },
                    { new Guid("18d26058-238b-46e1-9ce0-93ff4267c5bc"), "C.10.62", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of starches and starch products" },
                    { new Guid("440f7e4d-e07e-41a1-88d7-c98ea6a5c77f"), "C.10.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("848a3b96-4097-4756-a4ce-743facbdef8b"), "C.10.7", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("6ff3b0c1-588c-4a7c-93d9-63368ddea5c8"), "C.10.72", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("33bded39-6df3-438a-af61-c22a6122209d"), "C.10.73", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("ffa08923-1824-490c-b582-430c0be66df4"), "C.10.8", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other food products" },
                    { new Guid("b8fce271-37bf-4ba1-a4d5-ea202665c99a"), "C.10.81", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of sugar" },
                    { new Guid("6dd82164-cbb4-465b-9a0f-49ea530eea17"), "C.10.82", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("9955ddb1-f471-4d70-ac14-8dd7a7b063fc"), "C.10.83", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing of tea and coffee" },
                    { new Guid("f6fb4d91-a2ad-4340-92f3-90a405f93208"), "C.10.84", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of condiments and seasonings" },
                    { new Guid("d0ff8a44-447e-4edf-ac0d-6cc18ca8f723"), "C.10.85", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of prepared meals and dishes" },
                    { new Guid("453ab8e6-16bd-4ead-bb01-54f804c261a8"), "C.10.86", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("04f8a75f-750b-4c26-9628-fd44843cf209"), "C.10.89", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other food products n.e.c." },
                    { new Guid("ebf120e7-b5e1-4140-a9fb-d6f3f69db499"), "C.10.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of prepared animal feeds" },
                    { new Guid("760f5c2d-b667-4b66-820f-1ea03e8fb995"), "C.10.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("d8284f96-bf04-4833-87e1-2e1d4c950b26"), "C.10.71", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("521f8720-6fff-4d0d-ad10-01b25c4ba5eb"), "C.10.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("6e0a1579-240d-493e-bc94-f288c743fbfe"), "C.10.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("f9eb5d75-434b-41fc-86ce-9bb52bb983ca"), "C.10.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Production of meat and poultry meat products" },
                    { new Guid("8d6ab6e4-aaee-4d0e-9616-7ac37623b792"), "B.06.10", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of crude petroleum" },
                    { new Guid("b517dea7-0ddb-4576-ab5c-63339980d668"), "B.06.2", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of natural gas" },
                    { new Guid("195cf49b-17cc-495f-be7d-55b74b68cf67"), "B.06.20", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of natural gas" },
                    { new Guid("86a63a60-90e2-42e5-86c9-a7ed16be7a6f"), "B.07", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of metal ores" },
                    { new Guid("71fd9a82-3357-4aae-b29a-0d05a0e11fcf"), "B.07.1", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of iron ores" },
                    { new Guid("261d8408-59dc-49c9-b00f-637767f3dd08"), "B.07.10", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of iron ores" },
                    { new Guid("489fe602-e8a7-408a-be86-7cf135bbc3df"), "B.07.2", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of non-ferrous metal ores" },
                    { new Guid("0d6e00b8-8f29-4428-aa3c-907e7973bc32"), "B.07.21", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of uranium and thorium ores" },
                    { new Guid("b40fd34c-223f-4056-882e-8ab5c12e5291"), "B.07.29", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of other non-ferrous metal ores" },
                    { new Guid("f90c209b-decb-4d88-8d9d-1ef5acba3c2f"), "B.08", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Other mining and quarrying" },
                    { new Guid("59566e4c-5760-4bed-a93c-0b8496faabaf"), "B.08.1", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Quarrying of stone, sand and clay" },
                    { new Guid("c9f819cc-0955-4ef4-8bbf-413a2bd3f1bf"), "B.08.11", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("0ae48561-40e5-4600-9d39-57682bbec0be"), "B.08.12", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("422763eb-fa9b-45ce-b469-898156da6955"), "B.08.9", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining and quarrying n.e.c." },
                    { new Guid("d0953017-d61c-47de-acfe-980983d3b789"), "B.08.91", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("48dac76d-3685-4e21-b2ea-1ce7cbcb8205"), "B.08.92", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of peat" },
                    { new Guid("59d0c01b-a0be-4a55-b69f-76ce674dbdab"), "B.08.93", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of salt" },
                    { new Guid("2584c12d-89fc-46ee-8439-103be205b079"), "B.08.99", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Other mining and quarrying n.e.c." },
                    { new Guid("592eac35-7da4-4dbf-8607-3dd3bba1b14e"), "B.09", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Mining support service activities" },
                    { new Guid("e00bf51b-1ed6-41a5-93d6-f24e1ce01983"), "B.09.1", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("44aa05ec-5ac6-46a1-b1ff-d828a6b273e2"), "B.09.10", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("760cd37f-abc0-4005-8104-24a9eccbc54a"), "B.09.9", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Support activities for other mining and quarrying" },
                    { new Guid("9817b389-3f57-4a6a-ae24-225602d04afa"), "B.09.90", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Support activities for other mining and quarrying" },
                    { new Guid("31547d93-0d6c-4b21-bb89-6ef05d9b302c"), "C.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of food products" },
                    { new Guid("0966aac3-0b49-4fd0-903e-cfc68aa3d60b"), "C.10.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("fabe0b9f-16e5-481f-9797-15643a65c75c"), "C.10.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of meat" },
                    { new Guid("3ad35d71-72e9-4545-8614-9adb98d34047"), "C.10.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing and preserving of poultry meat" },
                    { new Guid("90babf0e-2173-4610-9704-c1a9dd303af3"), "B.06", new Guid("fc679afa-8d76-4edd-8076-8eb3c689c5ee"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("c65acc5b-ef6d-4102-97f3-29dcaa2a54b2"), "F.43.2", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("52135109-e845-4b0c-886d-99311a8474d5"), "C.23.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of refractory products" },
                    { new Guid("30653f3e-b1f5-435c-bc85-c063ed79b11d"), "C.23.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("239a0245-85c9-45f6-8d89-491556b3f4e7"), "C.30.92", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("d6099b79-cde9-4a33-aa12-95fe6daf2b50"), "C.30.99", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("39b1c675-d52c-4c2e-a3ef-88b93081489a"), "C.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of furniture" },
                    { new Guid("9b5ff62b-e055-41f5-bbd8-a66588a3593f"), "C.31.0", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of furniture" },
                    { new Guid("ea2edf54-4876-470c-bfb0-72250b52cf57"), "C.31.01", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of office and shop furniture" },
                    { new Guid("3718cb0e-8ccc-4816-8230-411f7f1e9430"), "C.31.02", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of kitchen furniture" },
                    { new Guid("a09b0052-3573-4ece-9446-af926afe555d"), "C.31.03", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of mattresses" },
                    { new Guid("3764094a-0166-498e-91de-ea76950ccb07"), "C.31.09", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other furniture" },
                    { new Guid("bdd7b573-6293-421e-b3f2-5b607b59171c"), "C.32", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Other manufacturing" },
                    { new Guid("96966d53-7c31-48ec-9b0b-f4dd03a26c23"), "C.32.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("172dc7ca-4b5e-4729-a928-7bcb9d16060f"), "C.32.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Striking of coins" },
                    { new Guid("2ef3776f-6301-4681-bca5-37b2ba3176eb"), "C.32.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of jewellery and related articles" },
                    { new Guid("680a1d22-3f25-4ff6-89b4-18e63473ef5d"), "C.30.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of motorcycles" },
                    { new Guid("9c0bdd48-3f7b-426a-89f3-a84b5644e432"), "C.32.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("1ed1b92f-3c50-4922-9d74-ee07bbb4960e"), "C.32.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of musical instruments" },
                    { new Guid("9c633364-1251-4a3a-a369-7e6111710d0a"), "C.32.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of sports goods" },
                    { new Guid("ac468ea9-d8ab-412e-816f-4bb81da027c4"), "C.32.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of sports goods" },
                    { new Guid("67a0e7f9-75e2-47b1-93db-59a119a1863d"), "C.32.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of games and toys" },
                    { new Guid("a944b8e3-42ce-4d77-91d5-391ac08c5d53"), "C.32.40", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of games and toys" },
                    { new Guid("807ca5ac-5d00-4354-91e6-abfd3d505ded"), "C.32.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("9328bfd4-306d-47a5-b57d-ff213a1a0cfc"), "C.32.50", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("c4688ff7-2352-4466-975a-680580e57121"), "C.32.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacturing n.e.c." },
                    { new Guid("1fcebdb7-2198-4a98-8a57-3652ed021592"), "C.32.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5469e352-e459-4113-99b0-6d9a4f6f3acd"), "C.32.99", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Other manufacturing n.e.c." },
                    { new Guid("f2d38b82-65a1-4edf-ad60-5cee51dc4f62"), "C.33", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair and installation of machinery and equipment" },
                    { new Guid("06bd9fc1-3178-402d-a309-11a32b913841"), "C.33.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("c916ecb2-b406-4d8a-b1cd-8196689cf368"), "C.32.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of musical instruments" },
                    { new Guid("3d164abd-379e-4cc2-aac9-beb8783490ea"), "C.30.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("4351ece1-6ba4-4863-aa49-8537b165e90a"), "C.30.40", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of military fighting vehicles" },
                    { new Guid("1d8a9dbc-5b17-4cf7-b73b-ba1ee4bd320b"), "C.30.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of military fighting vehicles" },
                    { new Guid("8e4a1a13-bfe5-47ab-a27c-44ba5ff458df"), "C.28.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("40c5f03c-b70c-4f1b-9e49-ae6ea26e6acb"), "C.28.41", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of metal forming machinery" },
                    { new Guid("afb17a7f-0e4f-4d8f-85fc-a00d159333a9"), "C.28.49", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other machine tools" },
                    { new Guid("b92c98bb-12a1-4ad0-9dd7-5e93f491c46f"), "C.28.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other special-purpose machinery" },
                    { new Guid("15076edb-2865-447b-a8ad-e8a083902c5f"), "C.28.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of machinery for metallurgy" },
                    { new Guid("4ada4e24-59ae-46d1-b818-9575b42065c9"), "C.28.92", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("ad6e103f-74b8-4ad5-ad44-f9fc59cdddcd"), "C.28.93", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("d944332c-0d83-40d0-a364-d537de0c6760"), "C.28.94", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("9c145d69-2378-416b-b260-f4309f31c514"), "C.28.95", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("1a96f9ac-fa27-4bcb-bb01-31e40d738217"), "C.28.96", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("6951ac2b-6598-4296-a232-f3310f159243"), "C.28.99", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("e582a7e2-80fb-45d3-a73a-7a7353ef121e"), "C.29", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("7719624c-3837-4022-80c3-a0d3a62bc2a7"), "C.29.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of motor vehicles" },
                    { new Guid("1f9bfa92-5539-42e9-82d0-ec985407353a"), "C.29.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of motor vehicles" },
                    { new Guid("c991347b-5dcc-42bb-beee-7eaa7d42a304"), "C.29.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("81586431-cd7e-4255-8033-b33fb67ef508"), "C.29.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("a3242da9-6852-47ef-80da-3d22a334871b"), "C.29.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("569ef79e-75c1-4b13-8ff5-4cba8c0de832"), "C.29.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("d7494ae0-651e-4fd1-b746-1031b56ee0b0"), "C.29.32", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("4d41e45f-de4e-474d-950d-f60156e5d4f8"), "C.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other transport equipment" },
                    { new Guid("3e1a6f6a-fc87-448c-b219-7027dee3d787"), "C.30.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Building of ships and boats" },
                    { new Guid("a6cff404-76bc-4d99-8404-bcd7b3f25cc6"), "C.30.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Building of ships and floating structures" },
                    { new Guid("828af889-fb0e-4a7f-95c6-b0d75b1d610a"), "C.30.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Building of pleasure and sporting boats" },
                    { new Guid("f756d4b4-aa8c-4621-93e0-e8055facbc22"), "C.30.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("427dd6fe-5a45-4d31-94e8-031391809513"), "C.30.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("54f4dc43-a427-403b-bb3e-2f56f86bcf8e"), "C.30.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("fb5ad35d-a45e-4ee7-8922-52a8561f1517"), "C.30.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("86c483cb-35dc-4bb8-90cd-43ff63b82619"), "C.33.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair of fabricated metal products" },
                    { new Guid("4e953aa8-ab65-4b75-8fd2-b78af02a6e4b"), "C.28.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("bff966a9-ffdc-4a47-9786-f0c99322399c"), "C.33.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair of machinery" },
                    { new Guid("7edb7180-e0ea-4a86-bb02-9cea98c638ce"), "C.33.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair of electrical equipment" },
                    { new Guid("8ed03dae-5797-4c36-bc7e-66a7ffd07357"), "E.38.3", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Materials recovery" },
                    { new Guid("c698c50e-c0c6-49b5-95e4-db4c6722d5e5"), "E.38.31", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Dismantling of wrecks" },
                    { new Guid("8a578eea-0d70-43d0-8ede-03824a3e884f"), "E.38.32", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Recovery of sorted materials" },
                    { new Guid("39edcb2e-fa2c-438d-a16a-d605476a1bf0"), "E.39", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c8e7222e-3d67-4a07-81b3-659e57868df1"), "E.39.0", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Remediation activities and other waste management services" },
                    { new Guid("1921695b-414f-4af2-9113-43fc688f8652"), "E.39.00", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Remediation activities and other waste management services" },
                    { new Guid("57df5bd8-9f24-413b-8bb9-d50309155215"), "F.41", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of buildings" },
                    { new Guid("d386e80a-d1c2-4a6b-a55c-fbb101c29a77"), "F.41.1", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Development of building projects" },
                    { new Guid("ff799f8a-9129-4374-a99f-9efeb7963f37"), "F.41.10", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Development of building projects" },
                    { new Guid("fab3b155-4c15-45e4-9944-37ea9a585769"), "F.41.2", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of residential and non-residential buildings" },
                    { new Guid("6243f7b6-5372-4cdc-bb24-1a0f45ee652c"), "F.41.20", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of residential and non-residential buildings" },
                    { new Guid("f3cdf453-55c6-4542-960c-322c218c832a"), "F.42", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Civil engineering" },
                    { new Guid("562218eb-daa4-464a-b843-6e7b00590600"), "E.38.22", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Treatment and disposal of hazardous waste" },
                    { new Guid("4c5a64e2-8546-4b8e-ae83-55de65a7d6da"), "F.42.1", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of roads and railways" },
                    { new Guid("d3d10977-0bda-4123-bbf3-f604ab09ddae"), "F.42.12", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of railways and underground railways" },
                    { new Guid("3a071b7d-42c0-48b9-93a4-9d702f605a89"), "F.42.13", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of bridges and tunnels" },
                    { new Guid("f637516e-8c82-477e-84cb-657f8ccac0b6"), "F.42.2", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of utility projects" },
                    { new Guid("e9180db8-dd25-4e17-95e1-8b07af782305"), "F.42.21", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of utility projects for fluids" },
                    { new Guid("79cde98d-cd43-4cd4-9a87-0ecd58c97ef7"), "F.42.22", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("67747eee-cbb9-4f1d-b57b-b993ea42e494"), "F.42.9", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of other civil engineering projects" },
                    { new Guid("c4fefe26-eda6-4ce1-8285-663a5ae2f474"), "F.42.91", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of water projects" },
                    { new Guid("57918671-2173-482b-b51b-f7e2710b72c9"), "F.42.99", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("3f4ae92d-b51b-48a4-b724-e9bbc32c06a7"), "F.43", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Specialised construction activities" },
                    { new Guid("6c3ee25a-fd9d-422d-bcba-fe539393b2ba"), "F.43.1", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Demolition and site preparation" },
                    { new Guid("bd22dabb-0d57-4414-9719-2e17a24c1712"), "F.43.11", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Demolition" },
                    { new Guid("52ccb278-9c1e-489d-963d-76c056f559c7"), "F.43.12", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Site preparation" },
                    { new Guid("8c592fbd-a961-4ac5-b56d-40b978c272b1"), "F.42.11", new Guid("42f6b42a-2d0c-47a5-a109-bf9b9d129a9c"), "Construction of roads and motorways" },
                    { new Guid("ccd52e43-f7bd-4817-b7c9-42f5129d340e"), "E.38.21", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("d0649b27-199a-4643-aa71-db6d3b646718"), "E.38.2", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Waste treatment and disposal" },
                    { new Guid("3bf9bd8a-e395-4244-8ba0-0cc2ba844c0a"), "E.38.12", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Collection of hazardous waste" },
                    { new Guid("e22c6683-c8c8-4941-b223-0a2a5891fce5"), "C.33.15", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair and maintenance of ships and boats" },
                    { new Guid("6d2c0d01-457f-42fd-bbdb-bf264bacfac8"), "C.33.16", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("0eb4e151-a731-4e61-b129-a606ab67acf8"), "C.33.17", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair and maintenance of other transport equipment" },
                    { new Guid("c6c058d3-797c-46b2-8438-0e71c624da49"), "C.33.19", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair of other equipment" },
                    { new Guid("6df3b79a-2dcd-49ff-b5bf-c17ae6e0afb7"), "C.33.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Installation of industrial machinery and equipment" },
                    { new Guid("58db2dbb-0c0d-4779-bcac-f7ae04c6c745"), "C.33.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Installation of industrial machinery and equipment" },
                    { new Guid("b808130f-40b5-496c-814e-2d887f50790d"), "D.35", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("9a2f6b1b-a063-4b6a-a3a8-5995d220f1d0"), "D.35.1", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Electric power generation, transmission and distribution" },
                    { new Guid("f8277ead-d586-41f8-a5c4-807fbd33034a"), "D.35.11", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Production of electricity" },
                    { new Guid("9027f4ac-9f78-40a3-b040-da8a4107cdf2"), "D.35.12", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Transmission of electricity" },
                    { new Guid("f9b50a3b-6e4f-4b65-bda3-07ebd3997818"), "D.35.13", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Distribution of electricity" },
                    { new Guid("486aa317-af7b-4ee9-bce0-e0ba58bd67d6"), "D.35.14", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Trade of electricity" },
                    { new Guid("2e4fe034-ff88-47a3-b95d-220e9d186ba3"), "D.35.2", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("7086bc06-5b03-4c39-a944-fd886fc5e1ea"), "D.35.21", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Manufacture of gas" },
                    { new Guid("c40281d3-9d38-4980-a9db-a653a7bda25b"), "D.35.22", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Distribution of gaseous fuels through mains" },
                    { new Guid("b88b7a50-5122-4974-8cef-ebc919bb9995"), "D.35.23", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("4f884d6d-9c55-496f-a211-c693395625f5"), "D.35.3", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Steam and air conditioning supply" },
                    { new Guid("783bc403-4845-4cd6-9db0-9547d366ed3d"), "D.35.30", new Guid("9262a49b-6c95-43ad-a641-ed9d88e1ee27"), "Steam and air conditioning supply" },
                    { new Guid("951471c4-169f-4c4a-86e8-e0eb942a358c"), "E.36", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Water collection, treatment and supply" },
                    { new Guid("97938447-f8fb-4dd8-bfc5-ada1ec737b3e"), "E.36.0", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Water collection, treatment and supply" },
                    { new Guid("fd450987-716f-437e-974d-ea3cd91c910a"), "E.36.00", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Water collection, treatment and supply" },
                    { new Guid("f1af26d0-d1a4-4890-9134-49f5d6f5d759"), "E.37", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Sewerage" },
                    { new Guid("47b3f6d1-0cc8-4c94-948f-aeffb7f5d4bf"), "E.37.0", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Sewerage" },
                    { new Guid("1a8546b8-7fae-493d-9ea0-fcb6d758aca2"), "E.37.00", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Sewerage" },
                    { new Guid("8482d8a2-94b2-4efd-9065-f26264c88bc6"), "E.38", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("63ca5d23-9c9a-4077-9d96-b530d9056c6f"), "E.38.1", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Waste collection" },
                    { new Guid("184c939d-e6ab-490e-b4be-9c9a41b9d059"), "E.38.11", new Guid("d75175ea-49e4-4a8c-b3cb-0934a7b49383"), "Collection of non-hazardous waste" },
                    { new Guid("3b43ca4a-29a6-4eb9-ac4a-b3b7092a255f"), "C.33.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Repair of electronic and optical equipment" },
                    { new Guid("0e4e6eb4-9c3c-4d30-aef3-748902bdb5e5"), "C.23.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of clay building materials" },
                    { new Guid("1cdad218-4352-4e4e-918b-896a96641615"), "C.28.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("c18abc07-bf1e-453c-9b79-d54ed67e0edb"), "C.28.25", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("114678e0-b97f-44d7-915d-43685c66c955"), "C.24.34", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Cold drawing of wire" },
                    { new Guid("07d3eebe-7f9d-4031-8080-d0dacb8719de"), "C.24.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("204cf735-87bc-4973-b47f-d1ec01ee5cd7"), "C.24.41", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Precious metals production" },
                    { new Guid("186446e8-1b00-4b6e-803e-9482327851e6"), "C.24.42", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Aluminium production" },
                    { new Guid("3703cf69-7d19-459a-b751-e6eb5567803c"), "C.24.43", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Lead, zinc and tin production" },
                    { new Guid("3e4db193-7503-42c8-a6eb-8dffc59bd2ef"), "C.24.44", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Copper production" },
                    { new Guid("fa3d8de0-f4d5-4c7c-a5aa-eed3b157b4e4"), "C.24.45", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Other non-ferrous metal production" },
                    { new Guid("add45d11-2e88-4248-ac15-ce322028f2b3"), "C.24.46", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Processing of nuclear fuel" },
                    { new Guid("774edede-ecf2-45c7-b7b0-b65eb1ab7a29"), "C.24.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Casting of metals" },
                    { new Guid("94bd1644-b086-4e71-9845-095c02ffb0e6"), "C.24.51", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Casting of iron" },
                    { new Guid("fcd48590-ac4b-45f8-9294-ec3e158ceb8f"), "C.24.52", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Casting of steel" },
                    { new Guid("1b812dcb-c383-48e7-a30e-0545bc55459b"), "C.24.53", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Casting of light metals" },
                    { new Guid("1ba485d5-26d7-47c1-8f50-33a8f7f95c6e"), "C.24.33", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Cold forming or folding" },
                    { new Guid("7448e010-aa30-4c88-8de1-6c41be40a449"), "C.24.54", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Casting of other non-ferrous metals" },
                    { new Guid("a819d03f-8f43-4ccc-8646-9d82b8436d9a"), "C.25.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of structural metal products" },
                    { new Guid("021c0bbe-cc65-4c86-912d-05eeed1035b3"), "C.25.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("f9a7d125-826d-4bd9-b70a-1c2280885d71"), "C.25.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of doors and windows of metal" },
                    { new Guid("04e65750-2a6a-439c-8786-c283642cec92"), "C.25.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("867e4b97-3f51-4fdb-8c1e-79d1359c339c"), "C.25.21", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("07d69a2f-df7d-4831-b723-153cddfa542a"), "C.25.29", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("9cf6f819-0b13-4a8e-babf-17d1199d50f8"), "C.25.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("74a794e4-e265-4478-a6c1-3ff67c0e39bd"), "C.25.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("af0f07bd-a55d-498c-bcec-4cfb5d286057"), "C.25.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of weapons and ammunition" },
                    { new Guid("2c8af58d-86bd-4cc6-ad46-5eb7788f195b"), "C.25.40", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of weapons and ammunition" },
                    { new Guid("4246abd5-8384-47c4-b67e-d08347c001b7"), "C.25.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("a83c2d6c-739d-4443-9071-a780fcf110ce"), "C.25.50", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("a487c563-d0d1-4f4f-9fce-ed323cfe6db4"), "C.25", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("db0dd1e3-4c39-4590-8870-dd8f8834131e"), "C.24.32", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Cold rolling of narrow strip" },
                    { new Guid("006870b7-a33d-436c-a5b9-b449564145a6"), "C.24.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Cold drawing of bars" },
                    { new Guid("76221fb6-a3f3-44ef-bb82-21425eaf02f3"), "C.24.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other products of first processing of steel" },
                    { new Guid("0e88ec0c-1744-4621-8d61-6542adeb5c3d"), "C.23.32", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("4a6c4e47-2fc1-436c-838e-3cd7aa4c9cd1"), "C.23.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("ebcddb17-3a87-481c-8278-3829c904ff31"), "C.23.41", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("3f9eb009-4058-466a-875b-7dfdf2a761d4"), "C.23.42", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("3c4ffe1e-0810-424d-8529-fa2f8c9def59"), "C.23.43", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("c44b0acc-c0bb-4809-82ec-35d1946a3ab2"), "C.23.44", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other technical ceramic products" },
                    { new Guid("b8b96ccb-89e6-4f6d-a5fa-00487402d74c"), "C.23.49", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other ceramic products" },
                    { new Guid("4944f7ac-e769-40c8-9aaa-c921c22c9e1a"), "C.23.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cement, lime and plaster" },
                    { new Guid("de54e634-3204-43fa-be8e-fdcd23ce3686"), "C.23.51", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cement" },
                    { new Guid("595cc1ef-b683-4d9d-9a97-b57bf13536f7"), "C.23.52", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of lime and plaster" },
                    { new Guid("99250553-34de-4925-9d88-72504c9b1c9a"), "C.23.6", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("3737dd60-918d-4ce2-b9f9-4449b891256e"), "C.23.61", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("4e160233-708c-4a47-ba04-28c73a022bdf"), "C.23.62", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("9430f164-c8f6-4cad-8c60-ed6b63a3e2af"), "C.23.63", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ready-mixed concrete" },
                    { new Guid("b513208e-1179-4687-9d10-a7aee6aa89a6"), "C.23.64", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of mortars" },
                    { new Guid("7b35772f-42b2-426c-ae8b-0cc04335246f"), "C.23.65", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fibre cement" },
                    { new Guid("8e7e1117-10a7-4c5f-b737-b960cda34263"), "C.23.69", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("17b01569-b4b3-4166-a29a-656f1e6d1f5e"), "C.23.7", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Cutting, shaping and finishing of stone" },
                    { new Guid("8cc87411-955d-4eec-ade8-470b46a4cbb8"), "C.23.70", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Cutting, shaping and finishing of stone" },
                    { new Guid("7791be69-b991-4b33-a83c-aab9f57190c3"), "C.23.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("61e952df-bc20-4200-9519-a87aca9c7bb4"), "C.23.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Production of abrasive products" },
                    { new Guid("d657b2a0-5e85-46b7-ab8a-ff040749d3fc"), "C.23.99", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("87827e6e-72fa-4832-83d2-9df753acab21"), "C.24", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic metals" },
                    { new Guid("bfe8fd63-ee05-45e1-872e-749aaae1408b"), "C.24.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("5415c88a-c17a-4017-bd44-53779a0eecc7"), "C.24.10", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("9396daf0-214f-4ec2-a0e6-e72ced634bc7"), "C.24.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("d7717458-d843-46c9-8201-ab83fe6d5d78"), "C.24.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("cf47ad5b-08de-4cb0-815e-76058491ac28"), "C.25.6", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Treatment and coating of metals; machining" },
                    { new Guid("e3e90a30-db14-4739-b72f-61b410612d6e"), "C.28.29", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("1fbb7888-838c-4722-b677-23c161bce75a"), "C.25.61", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Treatment and coating of metals" },
                    { new Guid("dec80ace-8153-4ed1-8802-09cd7a6485e0"), "C.25.7", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("8aa44c1c-c71e-4691-ab5b-3c6b2845fcee"), "C.27.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("f793c68a-9338-4eac-8d5b-7069b06cfb14"), "C.27.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of batteries and accumulators" },
                    { new Guid("67c9520b-835b-4667-be21-3cc9c4ca09c2"), "C.27.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of batteries and accumulators" },
                    { new Guid("a8fdb9bb-45fe-4e4e-99c1-268b5f0628b5"), "C.27.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wiring and wiring devices" },
                    { new Guid("4f43d768-8414-4c61-86cb-c8078afd2514"), "C.27.31", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fibre optic cables" },
                    { new Guid("75a20a29-383e-4158-bdeb-724a6312dec2"), "C.27.32", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("15994990-faa7-48e9-8522-8181225d2b60"), "C.27.33", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wiring devices" },
                    { new Guid("8a13c50e-8a3a-417d-9ba1-21a6229cb2ec"), "C.27.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1d6f3e0c-3374-476b-aa7e-012e7c9930eb"), "C.27.40", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electric lighting equipment" },
                    { new Guid("50fc7228-5120-42d8-b185-aac1f5beba84"), "C.27.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of domestic appliances" },
                    { new Guid("2f794576-42d5-4358-a59c-173896e6ea62"), "C.27.51", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electric domestic appliances" },
                    { new Guid("a66d44ee-7b2a-4220-9eb9-9d1d46ff8150"), "C.27.52", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("cdf9ea94-08aa-4d1f-93a1-9d99a576221b"), "C.27.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("2288c538-3cc9-4e83-a3d7-b8613c29d8d3"), "C.27.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other electrical equipment" },
                    { new Guid("dc776ebb-f599-4d6c-b1b0-2f27bda2edf7"), "C.28", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("f50de84d-3181-420e-9827-84add3078136"), "C.28.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of general-purpose machinery" },
                    { new Guid("7eda3b63-715e-49c3-99f6-34c34c3a6160"), "C.28.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("903d40ad-4703-40d8-8850-012d262479fa"), "C.28.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fluid power equipment" },
                    { new Guid("27237285-c78c-46a6-afe7-1f3cc6c0c363"), "C.28.13", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other pumps and compressors" },
                    { new Guid("5f7e3674-c349-46c3-9f80-c51db22d046b"), "C.28.14", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other taps and valves" },
                    { new Guid("e681580c-dc95-4a4a-ab33-8025cd97b152"), "C.28.15", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("d20b54e8-3676-49ac-9d01-8083dbfe9b25"), "C.28.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other general-purpose machinery" },
                    { new Guid("8373dcbc-00b9-439e-a62b-4bafdce23762"), "C.28.21", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("a7457557-ea4f-4e48-aa7c-756745151020"), "C.28.22", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of lifting and handling equipment" },
                    { new Guid("adc2ffbb-3325-4f04-903f-0386aa528036"), "C.28.23", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("997bc217-d512-477d-bf82-4a4d1ee60254"), "C.28.24", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of power-driven hand tools" },
                    { new Guid("7878e91d-8298-400d-b20a-c5276ffcf998"), "C.27.90", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other electrical equipment" },
                    { new Guid("cf99bd7d-3c6e-4da1-afcf-064e478287c2"), "C.27.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("22fab8f0-af69-48e5-8745-6d6be124e880"), "C.27", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electrical equipment" },
                    { new Guid("0ebf21e0-658f-4029-856b-02b12cbd0674"), "C.26.80", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of magnetic and optical media" },
                    { new Guid("f6e427d6-7add-4205-8b84-2e6f2d01e23f"), "C.25.71", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of cutlery" },
                    { new Guid("020c2906-1d02-453d-8541-e7581aeded15"), "C.25.72", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of locks and hinges" },
                    { new Guid("749115dd-b868-468a-9631-24761331dba3"), "C.25.73", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of tools" },
                    { new Guid("d67cf475-a298-4e3a-825a-967db9a0bf1f"), "C.25.9", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other fabricated metal products" },
                    { new Guid("05b231ec-889c-426f-92fd-319d432bfa04"), "C.25.91", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of steel drums and similar containers" },
                    { new Guid("e7774c9c-2919-4c47-9344-7ff1f73915de"), "C.25.92", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of light metal packaging" },
                    { new Guid("b65bebbc-f31c-4bb5-8f48-ee2a2f482365"), "C.25.93", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of wire products, chain and springs" },
                    { new Guid("7645afd2-bb85-4dab-a6f2-10a4a83a6b1d"), "C.25.94", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("4ad0e3d6-4dce-4bd0-8f64-d229eebaa0dc"), "C.25.99", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("3203a5c4-c64d-46a5-8853-715909ba6f90"), "C.26", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("8c78325f-b366-4669-9e24-b7f54b10e684"), "C.26.1", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electronic components and boards" },
                    { new Guid("37e078a3-8298-4a24-af1f-843c2269e33a"), "C.26.11", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of electronic components" },
                    { new Guid("0e45e21a-4437-4b68-a52e-17830d4324ad"), "C.26.12", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of loaded electronic boards" },
                    { new Guid("accc2f9c-8ca9-4fe1-b30b-21ec3e8e6b7f"), "C.26.2", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("dca99a98-c692-4ce6-9f55-113714bbb221"), "C.26.20", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("a58b8a31-8a9f-4e9e-9aa2-09965c177a38"), "C.26.3", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of communication equipment" },
                    { new Guid("fa94fc83-24fc-424b-b426-d4a8688d4938"), "C.26.30", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of communication equipment" },
                    { new Guid("b029fde9-391f-4f3a-9d8d-340e507b3b08"), "C.26.4", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of consumer electronics" },
                    { new Guid("1c17caf9-88ae-4920-9a3a-f07daf8d4e7e"), "C.26.40", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of consumer electronics" },
                    { new Guid("9a7fafef-e314-4277-8f83-65d705e685cd"), "C.26.5", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("778ed2d1-01a0-4c79-900f-c72ebcf6fd63"), "C.26.51", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("f8c621ef-f4b3-4734-bcfd-f6dfa6e031ed"), "C.26.52", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of watches and clocks" },
                    { new Guid("3384fd39-d08b-42f6-bd11-988b13dd34e0"), "C.26.6", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("51927d5f-2946-4269-85bd-ba1c880947d0"), "C.26.60", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("ef23d818-b85d-424a-9193-b9a8aa0d1c65"), "C.26.7", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("b2efe5b4-6bf6-4e95-942f-445263198bb2"), "C.26.70", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("0cbc4b55-9b7d-4a28-a6ea-b87fa0bb0334"), "C.26.8", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Manufacture of magnetic and optical media" },
                    { new Guid("a375c87f-a84e-42d6-bb97-530fb0eba0d0"), "C.25.62", new Guid("f314dc62-e774-47cb-96e5-dd852f841573"), "Machining" },
                    { new Guid("9eeecedf-80a8-42f7-90b5-b01eb5a6853e"), "U.99.00", new Guid("eb69e668-d56f-4faf-adee-e79dc90933be"), "Activities of extraterritorial organisations and bodies" }
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
