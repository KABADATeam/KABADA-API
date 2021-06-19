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
                    { new Guid("e47a0f1f-e14a-4231-bfa9-e85484efd818"), "AT", "Austria" },
                    { new Guid("daf241c8-60e4-4e31-8dd2-2061b129c198"), "LU", "Luxembourg" },
                    { new Guid("7f9d2e55-4580-438f-b194-5251ac02a82d"), "MT", "Malta" },
                    { new Guid("f4d7440f-f8e6-402d-95c1-a55e9930885a"), "NL", "Netherlands" },
                    { new Guid("7ef24448-71c7-4d2c-bcad-bbc3fa0eabf0"), "MK", "North Macedonia" },
                    { new Guid("675776ad-36cb-4958-9785-ab6e2da8b21c"), "NO", "Norway" },
                    { new Guid("27516f10-8e95-4189-a80b-aa0958f02851"), "PL", "Poland" },
                    { new Guid("d06f20ad-a196-463c-9524-d08053edfa20"), "PT", "Portugal" },
                    { new Guid("248503a5-8b2d-42f4-b681-d7b28d6861db"), "RS", "Serbia" },
                    { new Guid("145a868d-ddbd-40b6-b657-bee50f683771"), "SK", "Slovakia" },
                    { new Guid("2bef9da0-0120-496b-9056-1e50525ffa3e"), "SI", "Slovenia" },
                    { new Guid("07c96206-4fd6-47fc-98e9-b0b12e4ceae3"), "ES", "Spain" },
                    { new Guid("e62db802-b77b-4797-9ad7-67195ebbaa24"), "SE", "Sweden" },
                    { new Guid("1f9c07bc-9c09-40be-9678-970a5759c2a8"), "CH", "Switzerland" },
                    { new Guid("75f37eba-8e04-49b9-9200-57da240593ae"), "TR", "Turkey" },
                    { new Guid("db5491aa-b52c-4c24-a084-f42ce89902d1"), "UK", "United Kingdom" },
                    { new Guid("ce2003e0-0eb9-4708-90e8-221180378c7a"), "LT", "Lithuania" },
                    { new Guid("2a414d2e-5f82-4ab5-ba47-f052f93f5981"), "LI", "Liechtenstein" },
                    { new Guid("4879d19a-8166-4f3b-9cf6-63658d4b6848"), "RO", "Romania" },
                    { new Guid("f607c426-8be0-4660-9709-ac2111ec1074"), "IT", "Italy" },
                    { new Guid("2c1e621e-02a1-4d29-8f34-4b6cd2ab193e"), "BG", "Bulgaria" },
                    { new Guid("0c4451a5-d2a5-4d7c-829e-ffd04ffe59e0"), "HR", "Croatia" },
                    { new Guid("467fde52-fad4-4a7f-a925-d9e02e6c8844"), "CY", "Cyprus" },
                    { new Guid("882780ea-eaa0-4d8b-897d-2d51caf1f0c6"), "CZ", "Czechia" },
                    { new Guid("38a4d41b-b55c-4578-bbcd-59ff5281bc92"), "DK", "Denmark" },
                    { new Guid("74d4515c-7574-420b-bd9b-edcf80f7be3f"), "EE", "Estonia" },
                    { new Guid("3d3f7b59-3717-4111-8a50-26907cdb0a65"), "BE", "Belgium" },
                    { new Guid("bb8f69f8-7ef3-4526-8cbb-8feed6dd5f26"), "LV", "Latvia" },
                    { new Guid("a1e6a488-8f3e-4c25-b157-c05bc358b7e4"), "FR", "France" },
                    { new Guid("d35c8a9c-c8f6-45ce-9983-81dcd016b4ab"), "DE", "Germany" },
                    { new Guid("c131e9eb-a4d5-4976-93e8-ee7b71a4926a"), "EL", "Greece" },
                    { new Guid("c797cd25-289a-4d9b-8e3d-db01bbb75e78"), "HU", "Hungary" },
                    { new Guid("c37685bd-1a87-42c0-aafd-7408556d93c0"), "IS", "Iceland" },
                    { new Guid("6af0e5fd-7afc-49bd-b59a-0990a07675aa"), "IE", "Ireland" },
                    { new Guid("73be63ea-9229-4629-889c-9c89c7e9bfa1"), "FI", "Finland" },
                    { new Guid("d55c6935-696b-49ad-82fa-98a94482473a"), "BA", "Bosnia and Herzegovina" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("dfe6cbd9-0023-4bfd-9dd8-8cb42213739e"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("41de81e7-63aa-4688-81c5-a4d435ac9b10"), (short)6, null, new Guid("86edf8d3-2231-4a08-a107-25db42e3ab3b"), (short)5, "Other" },
                    { new Guid("661a5116-0ff0-4e3e-959e-784a26a65ee6"), (short)6, null, new Guid("7194e6a9-d3d4-40b3-8276-a5da003ce33c"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("7989d7b8-ee72-431a-9f42-0c75bb2ef2a7"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0dae0a24-d524-4efb-8e56-18432b667f21"), (short)2, "Frequency" },
                    { new Guid("802d7c03-b0e9-4a19-9a49-b26d00b6e03a"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("0dae0a24-d524-4efb-8e56-18432b667f21"), (short)1, "Ownership type" },
                    { new Guid("0dae0a24-d524-4efb-8e56-18432b667f21"), (short)6, null, new Guid("7194e6a9-d3d4-40b3-8276-a5da003ce33c"), (short)2, "Administrative" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("a80bb984-7bd4-4baa-8654-da88a054925c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("83b03ab8-b8fd-4a71-a335-dfddbcc55bd6"), (short)2, "Frequency" },
                    { new Guid("a9cba2cc-8028-4c22-a2ad-1de8020cb984"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("83b03ab8-b8fd-4a71-a335-dfddbcc55bd6"), (short)1, "Ownership type" },
                    { new Guid("83b03ab8-b8fd-4a71-a335-dfddbcc55bd6"), (short)6, null, new Guid("7194e6a9-d3d4-40b3-8276-a5da003ce33c"), (short)1, "Specialists & Know-how" },
                    { new Guid("7194e6a9-d3d4-40b3-8276-a5da003ce33c"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("6be21a9e-f7c7-421d-9684-556e425bdca6"), (short)6, null, new Guid("84824c93-6aef-4798-908b-9a6903d6a032"), (short)4, "Other" },
                    { new Guid("b7ec42f0-7460-416d-8f83-718b97facea0"), (short)6, null, new Guid("84824c93-6aef-4798-908b-9a6903d6a032"), (short)3, "Software" },
                    { new Guid("238fd15e-74fe-42c0-8e73-6478205f641c"), (short)6, null, new Guid("84824c93-6aef-4798-908b-9a6903d6a032"), (short)2, "Licenses" },
                    { new Guid("abd5e9d2-21df-4b57-87d3-5c4c1ca72acb"), (short)6, null, new Guid("84824c93-6aef-4798-908b-9a6903d6a032"), (short)1, "Brands" },
                    { new Guid("84824c93-6aef-4798-908b-9a6903d6a032"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("f6f4e0c8-4e29-4dbf-b166-a0a4fb37cfd5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("41de81e7-63aa-4688-81c5-a4d435ac9b10"), (short)2, "Frequency" },
                    { new Guid("c34f0f6f-b94f-4b8f-92ac-567a8df3c09c"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("41de81e7-63aa-4688-81c5-a4d435ac9b10"), (short)1, "Ownership type" },
                    { new Guid("c95363de-b653-4bad-8b18-234c337ea5dd"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("661a5116-0ff0-4e3e-959e-784a26a65ee6"), (short)1, "Ownership type" },
                    { new Guid("277e34d3-e035-44da-a40b-ab0461522078"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("661a5116-0ff0-4e3e-959e-784a26a65ee6"), (short)2, "Frequency" },
                    { new Guid("e3be3d33-d20e-4a61-9881-8d17033059d3"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("26ff0c82-3f93-4f8c-b735-880989e31d2e"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("8e1bdffc-0c30-4f51-b9c5-d90e2eb1b088"), (short)1, "Ownership type" },
                    { new Guid("22265b31-03a9-4946-8e8c-c2b073ae1a6d"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("09405fe4-90d2-4d9d-bb19-def9d8184d20"), (short)1, "Ownership type" },
                    { new Guid("42743a40-4b2c-48bc-a6f1-5112a6e48275"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("2cb5038c-598a-4c29-a767-1f8c99e61210"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("d6b6742d-6857-4639-bbe1-87939a1d6cfe"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("68972527-ce05-4f06-8bdb-7b60e59d5d1d"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("f97ad6ad-fa27-4105-b0c5-6de392fc9609"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("78b7beb9-16a0-4829-ba81-271cb55fa2f1"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("1d50533b-f007-4583-aff5-9d75c2f3f803"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("ad4e8bff-239b-4692-8f8d-29e8d7baa1b7"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("5e14cdd2-dc6e-4314-9b11-fe277be7db7b"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("b77b98a7-00bf-41ad-b40d-6d8a88744970"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("5379e2c3-3000-42d1-900e-5a5af1aba07a"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("539f8bc3-6dd5-4bf6-8c2d-caaf8b427102"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("1fbe65ed-ade4-4e7e-a592-81090a890b28"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("6afd03f8-3461-4413-b8d8-195e163a9c1a"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("0c2cfdb9-4a2f-41a8-880c-68aa4bf3dd35"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("7659def3-abda-4f19-b030-91dceac85046"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("8e1bdffc-0c30-4f51-b9c5-d90e2eb1b088"), (short)2, "Frequency" },
                    { new Guid("8e1bdffc-0c30-4f51-b9c5-d90e2eb1b088"), (short)6, null, new Guid("7194e6a9-d3d4-40b3-8276-a5da003ce33c"), (short)4, "Other" },
                    { new Guid("09405fe4-90d2-4d9d-bb19-def9d8184d20"), (short)6, null, new Guid("86edf8d3-2231-4a08-a107-25db42e3ab3b"), (short)4, "Raw materials" },
                    { new Guid("09dfdea5-06a1-4597-9bb2-7b52add32560"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("2fea0493-62e2-4bf8-bbe8-badee7cb325e"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("eb27d5d2-48d2-42ee-91b4-e02501ea2510"), (short)1, "Ownership type" },
                    { new Guid("037b177c-73ed-49d9-a743-bafeed983b4e"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("6f229f01-48ed-4f36-91a7-2b4cf621c4c2"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("0bbc965f-c017-43eb-8d6f-44420f2d4ab8"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("7186f107-fbd4-4fb4-972f-d0efb42530ba"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("0d065ef5-a6aa-442b-bea7-2bd39a690033"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("e739d874-35f2-45bb-8771-b9bf512962a2"), (short)1, "a", null, (short)11, "Management processes" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("01a6916d-8208-47fb-b02a-eb0897f2863e"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("97811a97-a7ac-4aa5-b9a6-33c2154e2884"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("60814dff-de37-4359-b108-c47708393011"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("b2146282-d4be-45aa-9fdf-6e8e0ed1be4a"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("24fc9136-3e95-4195-8e9d-a1a4675a34ae"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("fe0828da-ed5c-4042-bb95-c8131c63e797"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("fa8b485c-8fe2-4905-9f8d-1cc7361b7be3"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("7721dc70-1a8f-4a76-bf12-7509636e659a"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("e210f144-abb9-4247-81ef-ebd8a1b5c774"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("b48a7f2a-c5ab-403a-9691-26293365d1c1"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("85290dc7-fb70-4fb3-a6ec-da9f330c2661"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("90e37730-a42e-4202-b589-548597ca0aad"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("6b5b9f9a-865d-4350-9881-5c124255a972"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("5f564e8e-36a2-4159-836a-dc1c30ca30b8"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("eb27d5d2-48d2-42ee-91b4-e02501ea2510"), (short)6, null, new Guid("86edf8d3-2231-4a08-a107-25db42e3ab3b"), (short)3, "Transport" },
                    { new Guid("0987f623-ee4e-4b6a-8e37-2764c851fedf"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("dad0ac13-68c9-40fa-bcb5-0b9912758b72"), (short)2, "Frequency" },
                    { new Guid("1ebbd9c5-eba0-46ab-8f09-3296ee443be1"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("dad0ac13-68c9-40fa-bcb5-0b9912758b72"), (short)1, "Ownership type" },
                    { new Guid("dad0ac13-68c9-40fa-bcb5-0b9912758b72"), (short)6, null, new Guid("86edf8d3-2231-4a08-a107-25db42e3ab3b"), (short)2, "Equipment" },
                    { new Guid("6adacd6c-b52b-49cd-9cc1-e70de931f6a5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ca28300e-b35b-4f82-b5cc-93b9bffeec5c"), (short)2, "Frequency" },
                    { new Guid("a167debd-cc4a-428a-907a-4807f1367b93"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ca28300e-b35b-4f82-b5cc-93b9bffeec5c"), (short)1, "Ownership type" },
                    { new Guid("ca28300e-b35b-4f82-b5cc-93b9bffeec5c"), (short)6, null, new Guid("86edf8d3-2231-4a08-a107-25db42e3ab3b"), (short)1, "Buildings" },
                    { new Guid("86edf8d3-2231-4a08-a107-25db42e3ab3b"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("886e12b3-9ff5-44d2-a698-ae84e0cec7f0"), (short)3, "a", null, (short)0, "New substitute products" },
                    { new Guid("c55ff476-287a-43ad-9681-119e8f1a336d"), (short)3, "a", null, (short)0, "Trend changes" },
                    { new Guid("0c09ffe7-a1f9-4eed-830f-e9bfbb406b50"), (short)3, "a", null, (short)0, "Taking business courses (training)" },
                    { new Guid("46b04a22-4e16-4c3d-b60d-3bfd3f4d8102"), (short)3, "a", null, (short)0, "Unfulfilled customer need" },
                    { new Guid("363a83f9-722a-4096-81a7-213cde48c1bc"), (short)3, "a", null, (short)0, "New regulations" },
                    { new Guid("851072d0-dbdd-43ca-8630-ee2646e4f496"), (short)3, "a", null, (short)0, "Arrival of new technology" },
                    { new Guid("f177be3c-6958-42cd-a105-181aa1b92bb6"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("0d163a8c-b4af-4ee4-8b30-d080e791e4f7"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("9030aac0-8261-4fb3-89b9-651048fd3b52"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("eb27d5d2-48d2-42ee-91b4-e02501ea2510"), (short)2, "Frequency" }
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
                name: "Languages");

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
