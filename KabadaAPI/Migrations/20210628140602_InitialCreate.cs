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
                    { new Guid("4e1b9509-915c-41e3-bb80-3c7f5d6b51bd"), "AT", "Austria" },
                    { new Guid("ce278997-12e8-4e58-8ac7-aa642f49fb1d"), "LU", "Luxembourg" },
                    { new Guid("94903c52-1319-4075-8498-5e91ba201341"), "MT", "Malta" },
                    { new Guid("b29de875-7ffd-4fb4-898a-7b6b3ccbf1af"), "MK", "North Macedonia" },
                    { new Guid("7318ffe4-f17b-4e0b-8539-66a7c54759c5"), "NO", "Norway" },
                    { new Guid("23d7155d-b4c4-4112-b486-4a48f5db0153"), "PL", "Poland" },
                    { new Guid("8d985b6e-911e-4128-9f5b-d9ee376bf709"), "PT", "Portugal" },
                    { new Guid("e66a80c8-3662-4fc7-8d28-6552f67e3677"), "RO", "Romania" },
                    { new Guid("5a3556a8-fc66-4c2c-8388-f38bbea0951c"), "RS", "Serbia" },
                    { new Guid("036510a6-97fb-44ff-af89-b565d98279f4"), "SK", "Slovakia" },
                    { new Guid("da954016-580d-447a-8a7b-68b43b056070"), "SI", "Slovenia" },
                    { new Guid("cedfe6a1-7969-4793-aa4c-217fef09ff61"), "ES", "Spain" },
                    { new Guid("61983e8c-96f7-4e40-9eb2-51e0a6681c8f"), "SE", "Sweden" },
                    { new Guid("bdae27ac-35b3-4528-bd61-14f6ccfa9545"), "CH", "Switzerland" },
                    { new Guid("d8a3dd98-9d3e-4dba-8231-e2aba9fac0c0"), "TR", "Turkey" },
                    { new Guid("66ab0dbd-0b1f-45ec-82b2-9cb3ee680237"), "UK", "United Kingdom" },
                    { new Guid("eb0652c3-5b9c-49bb-8c3b-cb4a93c3fb45"), "LT", "Lithuania" },
                    { new Guid("529aa8c3-9f68-4a6e-af01-d3bbdb0e0ad4"), "LI", "Liechtenstein" },
                    { new Guid("4ff20eb1-e0f2-4d42-9d94-de9d1c513a90"), "NL", "Netherlands" },
                    { new Guid("ec6147d9-c738-408f-b7c3-a97b1347ef60"), "IT", "Italy" },
                    { new Guid("68e4f9b5-360a-4e15-aed8-c6bb6ac49b89"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("f897eba1-a1fe-4e35-8172-824a30161237"), "BE", "Belgium" },
                    { new Guid("29f3b648-44ce-424c-88c3-fdb240c54edb"), "BG", "Bulgaria" },
                    { new Guid("1a76431a-9354-44a4-89d6-0cced9e07822"), "LV", "Latvia" },
                    { new Guid("ebce5073-5e95-4d3e-9028-57e7d308a71c"), "CY", "Cyprus" },
                    { new Guid("8ae9d70d-53a0-4e40-beca-dded0d2976f5"), "CZ", "Czechia" },
                    { new Guid("4d527bae-bca7-4516-b2ba-3355131b064f"), "DK", "Denmark" },
                    { new Guid("fc7dd336-7678-4ec8-9282-c2998ee72523"), "EE", "Estonia" },
                    { new Guid("06c80ba4-7b94-49f0-b0d4-4962541c3959"), "HR", "Croatia" },
                    { new Guid("cac787a0-5309-4dbf-b276-f4338163bac0"), "FR", "France" },
                    { new Guid("c87a56fa-bc48-48bb-ace4-0870ae229e95"), "DE", "Germany" },
                    { new Guid("bb81f2b4-bd84-42ce-a15a-57f72906cf08"), "EL", "Greece" },
                    { new Guid("ef9f902a-d7db-4651-a248-40f573ec11b4"), "HU", "Hungary" },
                    { new Guid("d627f312-f7ae-4d19-a291-f1b900121270"), "IS", "Iceland" },
                    { new Guid("5afdea09-ed7a-4470-8039-0048e06186a2"), "IE", "Ireland" },
                    { new Guid("00a152a4-6873-4417-bcb6-40dd54443b8a"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "P", "EN", "Education" },
                    { new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("93fb6644-f8fa-49fa-a07d-20b6393c1693"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("f62c4021-251e-4258-9950-556a5a690686"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "L", "EN", "Real estate activities" },
                    { new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "J", "EN", "Information and communication" },
                    { new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "H", "EN", "Transporting and storage" },
                    { new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "F", "EN", "Construction" },
                    { new Guid("68667e77-d160-4285-ab99-9930b5506350"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "C", "EN", "Manufacturing" },
                    { new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "B", "EN", "Mining and quarrying" },
                    { new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("e8957871-c8ef-4558-a680-536cbde8a35d"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("e65c8acc-8ff3-44ec-a4ca-36a909cb229f"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("8c0bc2de-5591-4c59-bbe9-e0a7684a13df"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("ed173024-92f6-436c-8c6d-606a47757e0e"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("0be4a479-71b4-4d98-b9f3-6e623eab8bf6"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("07cb49b4-6a8e-483e-8e06-49514448815f"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("5997e433-e69d-4bda-8bc7-7fa7e4ef4dad"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("5fd49633-5bb4-404b-9e41-d5c5c4e61d9d"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("9f0c6496-6308-437b-8940-4540e3556b44"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("f86c1020-a8aa-49d8-9140-ed8242680aad"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("fe9b2776-dd8d-4be9-9603-9c1e3377f165"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("137f6c7d-87c9-4059-94a9-53244054ce91"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("9f9dca04-c273-45d6-90bd-37a2061e7157"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("0ef15955-871e-4a02-8bf3-0f0b6479a890"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("c117c21f-0a63-440a-a1cf-9b2f4983e1a3"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("c8aa9306-6be5-4aad-80cc-8ff81294efb1"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("37b4a6fe-dedd-4734-b10f-662d92bc2dfa"), (short)2, "Frequency" },
                    { new Guid("b15170c7-fcc0-41a5-a23e-9c7beabd4f65"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("9bb9c727-7c26-4bfb-aa77-cc8c4bc99ac5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("87bc2edf-c894-4391-9b03-96b9d1ea65a3"), (short)2, "Frequency" },
                    { new Guid("881583cf-e1e2-42ed-a3e9-3ee5bdc78a40"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("87bc2edf-c894-4391-9b03-96b9d1ea65a3"), (short)1, "Ownership type" },
                    { new Guid("87bc2edf-c894-4391-9b03-96b9d1ea65a3"), (short)6, null, new Guid("2ff1909e-373f-4385-a071-2faa9b4ec7c0"), (short)4, "Other" },
                    { new Guid("24313126-fdcc-4709-a4ee-a70a2e04cb6d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("37b4a6fe-dedd-4734-b10f-662d92bc2dfa"), (short)1, "Ownership type" },
                    { new Guid("37b4a6fe-dedd-4734-b10f-662d92bc2dfa"), (short)6, null, new Guid("2ff1909e-373f-4385-a071-2faa9b4ec7c0"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("7ec230ac-c746-4259-8100-ab64c9ac6b3b"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d4f5963e-172c-495d-a338-eb467e119168"), (short)2, "Frequency" },
                    { new Guid("4400dc06-0f84-4170-80f7-d9c4cbfd24b3"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("d4f5963e-172c-495d-a338-eb467e119168"), (short)1, "Ownership type" },
                    { new Guid("d4f5963e-172c-495d-a338-eb467e119168"), (short)6, null, new Guid("2ff1909e-373f-4385-a071-2faa9b4ec7c0"), (short)2, "Administrative" },
                    { new Guid("8c5add2b-a52f-4627-ae9d-484f67962598"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b4baed5e-ebfe-4c79-bbff-c8c1f997e29d"), (short)2, "Frequency" },
                    { new Guid("9180c5b3-0857-4038-b46c-81cb3a4d9b7d"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("b4baed5e-ebfe-4c79-bbff-c8c1f997e29d"), (short)1, "Ownership type" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b4baed5e-ebfe-4c79-bbff-c8c1f997e29d"), (short)6, null, new Guid("2ff1909e-373f-4385-a071-2faa9b4ec7c0"), (short)1, "Specialists & Know-how" },
                    { new Guid("2ff1909e-373f-4385-a071-2faa9b4ec7c0"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("5794cffc-a517-426a-9086-eeb801e2fb03"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("63858d07-1864-407a-8838-35a7462fe300"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("1965f117-158a-404b-8bfb-befff95fd39c"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("4f99de60-02d8-4bc0-8771-9b269ad0b1d1"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("dd6670d6-cdc4-4cd7-91b8-175e1b29d5f1"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("926114df-9997-4710-ab76-d84699e94481"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("1730a6f0-e4f8-4165-803b-c21d6e63f50a"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("90f49dff-eb84-4e70-9157-aba427eb8a4b"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("59d277a9-1517-4701-9c4b-60774107224b"), (short)6, null, new Guid("9b2341be-fc79-44ab-b8d7-42f118cf5aae"), (short)4, "Other" },
                    { new Guid("e20f83e5-6dbf-495d-85fe-d60b278df72c"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("17729c79-44bc-477d-817b-2306962c5132"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("120a8579-7b26-488e-9529-9749d9069dce"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("0014b534-b913-46e6-b74e-38d0c3da1abe"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("883be027-3cb7-4bb9-925a-8ecf3878435e"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("bf9e8989-a7b6-4f0b-b1f3-240f75ab97b2"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("5f759a2d-5971-4b0c-ab7d-e8e30932b358"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("7e38e59d-a189-40cb-9adf-eb459180b904"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("97539514-c7d9-4211-9574-8a3b074b6456"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("f121a603-c602-48de-892a-951fc5afffc6"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("dc709b61-8169-4454-a69a-11c7f04013b9"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("ab74504e-5ff6-450c-9e25-6e9be309ecf4"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("a1d1d613-80fc-4c5e-a91b-5a08c42aaedb"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("84f78955-d1b5-4b31-bd48-4c177c149737"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("4964d6cb-c953-4d78-a58a-9b0657727547"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("e90d4ce6-87bc-4426-85ab-1683745f7c8d"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("268ae3f0-d220-45b8-9917-72088cab5b69"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("3085983f-134c-490b-ae50-0455157f62a1"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("2a8db74f-5448-4a8c-a437-c3b4df156407"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("88ffb907-ab6d-4b07-a862-8c36921147ae"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("962e0280-db8f-41c1-a9b7-67b5bfb21530"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("e0f91cb0-4cb9-45bf-8b1a-2ece392eb4fa"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("675e2460-9dcb-44a5-9c43-ecda0f4da3c4"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("2c67ea67-ccdb-4696-94a0-d372689d90dc"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("b5e13449-bc10-4d08-ade2-3f0c3dd9e4bb"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("7b190b89-6b30-4e12-9aae-64c1b40cc7b9"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("0c611ce7-4081-445b-87a7-b21062a589b3"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("35a4aaca-b93f-4039-b042-873c8679bba6"), (short)6, null, new Guid("9b2341be-fc79-44ab-b8d7-42f118cf5aae"), (short)3, "Software" },
                    { new Guid("99f2c60c-c176-422d-bc7c-8c6468e6bfa8"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("e08fe2fe-19db-4709-965c-9d9746062562"), (short)6, null, new Guid("9b2341be-fc79-44ab-b8d7-42f118cf5aae"), (short)1, "Brands" },
                    { new Guid("a76807cb-d076-43fa-a19b-753d0b01f133"), (short)3, null, null, (short)7, "Interest rate" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("2292dcb9-d94d-4b73-a372-63f322806548"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("0de0fb01-08b3-4e88-aaad-9ded63f9b91a"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("4b865af6-647d-4c3a-9b33-1c981941cf2c"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("bc92df70-3806-4163-9491-0a7f4f2b3d65"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("2f7b50cb-d21c-42f9-916e-2cc00a15222a"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("404082e3-7088-4ad3-aed8-86734d81d94f"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("af4337a1-d8e4-41c4-aa44-79eb07882a34"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("5bfd28aa-4a9f-4976-8d46-7898c86c0907"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("1e8e4e4d-7bf1-463e-8549-cffa32ce48d9"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("c36a04ce-d5d4-470a-96eb-70d6206337e2"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("4a1fa5f6-3cd1-4c75-8540-713c03c6c2e1"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("494a8c90-f2ed-4afb-afdf-b66b09fb093e"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("5141847d-8eb3-4bd1-895d-346f536069a7"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("c81f0f0c-1022-48a7-9669-56faebf24daa"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("736b62b4-8090-465e-b62f-4810436d1211"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("154d972b-1837-4b50-88ad-82a41fa9a1e5"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("e85ee83a-1360-4fdb-8818-a32a18e9bb39"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("ee6f5dfa-d81d-4948-b979-f2e576f74b8c"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("4f43c2b8-aba0-4298-be50-be572dac3c0e"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("ca3d2ea8-0f88-4569-9307-8687f8cbb2a6"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("e4c22f9d-9478-4597-a7f2-e6d28a1e89b0"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("f1ce3328-07e1-4b1f-8e1c-65073ec6db3e"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("e931663b-8868-4117-9dd6-2bdef34bf41f"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("0e65d979-4ca0-4be3-9ca8-a7cd113384df"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("237b1bc1-719c-47f5-bcec-58d5eea51e89"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("40ecfd67-96ce-4c8d-abb2-f7562a1ce4ba"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("1f60b43e-02da-4f90-8b49-ebe8bacb913a"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("52a81ff2-269a-4f16-b46b-d42cbd335470"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("59ea2075-45c4-44d3-8842-c5df9fdd0af5"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("1ca83358-8c1c-413f-b15a-6c6fe177359b"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("b3682641-5c38-4a3d-a5b4-476cb3dfd572"), (short)6, null, new Guid("9b2341be-fc79-44ab-b8d7-42f118cf5aae"), (short)2, "Licenses" },
                    { new Guid("c8609420-99c1-4209-9443-1e4bef53b404"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("81e589b3-5f7b-48b1-a55b-421c5d9a8f1a"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("9b2341be-fc79-44ab-b8d7-42f118cf5aae"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("060b571c-8ecd-48f6-ae15-1dc8a7480e67"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4223454b-592e-409f-aab1-179743a71bab"), (short)2, "Frequency" },
                    { new Guid("11c26ac6-fdd5-4b14-8a7d-b7121ee34dd6"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("4223454b-592e-409f-aab1-179743a71bab"), (short)1, "Ownership type" },
                    { new Guid("4223454b-592e-409f-aab1-179743a71bab"), (short)6, null, new Guid("018131cb-dc11-44cc-a3fd-817b49bf1121"), (short)5, "Other" },
                    { new Guid("b24865a7-96b3-4cf2-ab78-a95628a0da4d"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("a2be411d-0e8d-47ec-8d67-e80f8be06890"), (short)1, "Ownership type" },
                    { new Guid("a2be411d-0e8d-47ec-8d67-e80f8be06890"), (short)6, null, new Guid("018131cb-dc11-44cc-a3fd-817b49bf1121"), (short)4, "Raw materials" },
                    { new Guid("f2c93081-33f6-44fd-8aef-f4406ece6457"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("cc6d654a-ab6b-441f-a4b1-de07e7910e6d"), (short)2, "Frequency" },
                    { new Guid("1808d247-f216-41d6-9a22-9914f4df1e84"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("cc6d654a-ab6b-441f-a4b1-de07e7910e6d"), (short)1, "Ownership type" },
                    { new Guid("cc6d654a-ab6b-441f-a4b1-de07e7910e6d"), (short)6, null, new Guid("018131cb-dc11-44cc-a3fd-817b49bf1121"), (short)3, "Transport" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("a40a8e12-c83b-4ac4-8254-7b6f36f2386c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("0e63f438-e8b6-4cfb-ae3e-8533a2b4c8c4"), (short)2, "Frequency" },
                    { new Guid("ece0494c-c15d-4227-9239-46de64afc6cf"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("0e63f438-e8b6-4cfb-ae3e-8533a2b4c8c4"), (short)1, "Ownership type" },
                    { new Guid("0e63f438-e8b6-4cfb-ae3e-8533a2b4c8c4"), (short)6, null, new Guid("018131cb-dc11-44cc-a3fd-817b49bf1121"), (short)2, "Equipment" },
                    { new Guid("5ad30231-e87f-4c9e-af77-c080f73e13c0"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b4a39352-6635-4e63-9cd1-63f8249224bd"), (short)2, "Frequency" },
                    { new Guid("431c01aa-c842-464a-88c7-36c57758cd25"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("b4a39352-6635-4e63-9cd1-63f8249224bd"), (short)1, "Ownership type" },
                    { new Guid("efc96c4c-aace-4e5f-b9c0-3376e0551f5f"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("b4a39352-6635-4e63-9cd1-63f8249224bd"), (short)6, null, new Guid("018131cb-dc11-44cc-a3fd-817b49bf1121"), (short)1, "Buildings" },
                    { new Guid("bdfa3852-f57a-4769-8077-6577e5519990"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("4233e105-72bd-4cab-bf45-4b88718a1c8f"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("feee35ca-5278-45cc-bb45-c6ed331af38d"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("37f7e3a9-fddf-42b5-8d06-f5d5afe0de5b"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("157954d0-8976-47bc-b44b-637432f03317"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("9e66afe3-cac8-4d68-9d5f-43f39b208f00"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("1db30767-eed0-48f0-ae24-a7ed1767c5a6"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("97e236ad-cc62-40f4-b695-c720f56467ff"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("2a244945-d72a-4d2d-b249-fbed2f6eb2f8"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("4c7c1b2b-1a44-47e3-a520-2a74eb1d57c4"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("31ac4bfd-1b5a-4cf4-a251-89e6a0f9bf6e"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("80b5c4d9-d283-4560-8132-5e21daf9ca1b"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("34cd19d7-6e9b-4860-ad84-f4abc0f0bdea"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("018131cb-dc11-44cc-a3fd-817b49bf1121"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" }
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
                    { new Guid("013e4121-ac69-4f64-98da-7532ca07ef1f"), "A.01", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("126cfa86-265a-42cb-b329-fd88b7ca666f"), "H.51.22", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Space transport" },
                    { new Guid("c2a32aab-8416-482d-a728-945c1d3bf9ab"), "H.52", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Warehousing and support activities for transportation" },
                    { new Guid("7776b91e-a425-44b6-8aee-0e1bb646426e"), "H.52.1", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Warehousing and storage" },
                    { new Guid("d5f31d8c-ae90-4585-bd88-bc51345c3b84"), "H.52.10", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Warehousing and storage" },
                    { new Guid("b23a100a-8664-4f55-8859-1f5a09e0b600"), "H.52.2", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Support activities for transportation" },
                    { new Guid("fa285f0e-a263-4616-a0dd-ebb481ce2584"), "H.52.21", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Service activities incidental to land transportation" },
                    { new Guid("6bea889c-7635-4146-8391-f33a473dea43"), "H.52.22", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Service activities incidental to water transportation" },
                    { new Guid("c534786d-812f-45ca-a141-7dbfc7c2b3ef"), "H.52.23", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Service activities incidental to air transportation" },
                    { new Guid("bc47ffe2-f3c2-4257-84ed-c869882c4a6d"), "H.52.24", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Cargo handling" },
                    { new Guid("ccb017c2-6bd7-4ee5-a315-8680eeb88d2b"), "H.52.29", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Other transportation support activities" },
                    { new Guid("a0e824a1-a5c6-4d2a-8ea0-ba063e145c8d"), "H.53", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Postal and courier activities" },
                    { new Guid("14145d58-5939-4836-832e-4c9feba002be"), "H.53.1", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Postal activities under universal service obligation" },
                    { new Guid("79c18ee3-2b9b-4a93-81fd-8b29c520891b"), "H.51.21", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Freight air transport" },
                    { new Guid("fa9055ed-f4c9-4917-8743-395a1e1598e7"), "H.53.10", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Postal activities under universal service obligation" },
                    { new Guid("21eddb28-4c4b-47be-8fc6-0ba9446712a0"), "H.53.20", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Other postal and courier activities" },
                    { new Guid("bc908725-7320-46ff-9e0e-dd1c82829b58"), "I.55", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Accommodation" },
                    { new Guid("27f6fb00-fc27-4772-af5b-c8d335fd7c8c"), "I.55.1", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Hotels and similar accommodation" },
                    { new Guid("61af777a-d8f6-4a83-9409-11721fa367e1"), "I.55.10", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Hotels and similar accommodation" },
                    { new Guid("03c65798-8fa4-4a3c-8650-60dceb69a2dc"), "I.55.2", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Holiday and other short-stay accommodation" },
                    { new Guid("60c6759a-b534-43de-b1e0-94cd3f7c5036"), "I.55.20", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Holiday and other short-stay accommodation" },
                    { new Guid("a5fa1404-b4ba-4b91-9082-6dda08b422c6"), "I.55.3", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("7bf16a44-11fe-4e80-b06a-bdaee5cea381"), "I.55.30", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("40125ade-a2eb-4f08-9f13-6cd9f3a75a39"), "I.55.9", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Other accommodation" },
                    { new Guid("0f90cbb2-fef1-469e-8231-d2bf3f79c3ea"), "I.55.90", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Other accommodation" },
                    { new Guid("43dca9f5-58fa-4734-a896-dbb0aeeec3cf"), "I.56", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Food and beverage service activities" },
                    { new Guid("3884c1f1-2d81-4ecb-aa4c-70191369fd4f"), "I.56.1", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Restaurants and mobile food service activities" },
                    { new Guid("004e5d1a-84b0-4ee7-b6fa-6592b44bb76b"), "H.53.2", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Other postal and courier activities" },
                    { new Guid("279bfa2e-ff00-42e0-8123-100b8f0b57f9"), "H.51.2", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Freight air transport and space transport" },
                    { new Guid("9b676a87-c7b7-4cef-8d62-76eb55679935"), "H.51.10", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Passenger air transport" },
                    { new Guid("a651f003-4965-482b-94e3-e6f9f3687440"), "H.51.1", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Passenger air transport" },
                    { new Guid("f7dc74bd-2633-4502-bff6-d625dd3fa1a0"), "G.47.9", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("aa13bd14-44df-4b59-a857-ce04e14d33d4"), "G.47.91", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("7b32fc05-2858-4e96-8cbf-22923c39b5fc"), "G.47.99", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("2eaa1582-9bc3-46a3-9e68-a29fb360928e"), "H.49", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Land transport and transport via pipelines" },
                    { new Guid("2cd73d8b-ec58-423f-a846-352d726f2cec"), "H.49.1", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Passenger rail transport, interurban" },
                    { new Guid("03e968bb-6301-4016-b795-d84aaf4f5d4a"), "H.49.10", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Passenger rail transport, interurban" },
                    { new Guid("b11cd313-6114-4dc2-b191-fc5b6b1aa82c"), "H.49.2", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Freight rail transport" },
                    { new Guid("31fe1195-5c74-4821-9146-ca5769f40880"), "H.49.20", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Freight rail transport" },
                    { new Guid("6029f26c-e3d2-407f-8b0d-05c700219504"), "H.49.3", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Other passenger land transport" },
                    { new Guid("abc958f8-2066-4984-b4ed-11e08071ffbd"), "H.49.31", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Urban and suburban passenger land transport" },
                    { new Guid("62c61834-404d-4a75-b782-3aed9f04bd40"), "H.49.32", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("431c1d25-370c-4380-b151-bfdbd167598e"), "H.49.39", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Other passenger land transport n.e.c." },
                    { new Guid("8802bdae-b203-49d1-8356-434b6084038f"), "H.49.4", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Freight transport by road and removal services" },
                    { new Guid("bd0a8e8c-81c4-439a-ac3e-f62251043ed8"), "H.49.41", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Freight transport by road" },
                    { new Guid("cda72e12-69d6-483d-8031-35f326b5b472"), "H.49.42", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Removal services" },
                    { new Guid("948c6b0f-af07-4ca6-a2b4-575914314279"), "H.49.5", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Transport via pipeline" },
                    { new Guid("a56e175d-91f1-4b92-b518-e6b20d2c2215"), "H.49.50", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Transport via pipeline" },
                    { new Guid("eb18101a-fc02-4591-849a-40701516394a"), "H.50", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Water transport" },
                    { new Guid("73e7bbbb-e120-4724-9d7e-c879419f43cc"), "H.50.1", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Sea and coastal passenger water transport" },
                    { new Guid("5c5d4ad5-1034-417e-bbbb-96345689bfa4"), "H.50.10", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Sea and coastal passenger water transport" },
                    { new Guid("209f4e11-ffe3-4fe2-9f46-6d00fcc363a4"), "H.50.2", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Sea and coastal freight water transport" },
                    { new Guid("05a6df0b-281d-4765-afab-6ecae68a8cf5"), "H.50.20", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Sea and coastal freight water transport" },
                    { new Guid("a6f10e42-0e3f-4889-ab3d-bfb1f561cd66"), "H.50.3", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Inland passenger water transport" },
                    { new Guid("8f01c8b0-2b3e-467b-a158-66e4f4b67fa8"), "H.50.30", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Inland passenger water transport" },
                    { new Guid("cb50568c-048d-4698-acc3-d0d79d1fbdb1"), "H.50.4", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Inland freight water transport" },
                    { new Guid("d5839f04-a78c-4f5e-8caf-a501621d0d2d"), "H.50.40", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Inland freight water transport" },
                    { new Guid("26933dcc-487b-45bc-a9cf-ece288f55d11"), "H.51", new Guid("ca209301-9a4a-4376-977b-390f6929c76a"), "Air transport" },
                    { new Guid("214ccded-f3cd-4cac-b01c-93ccc5934d13"), "I.56.10", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Restaurants and mobile food service activities" },
                    { new Guid("efafb13c-a7b9-4041-a011-fd905158fc03"), "G.47.89", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("34f0611f-9c98-41c7-a2c2-1cc95a58a846"), "I.56.2", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Event catering and other food service activities" },
                    { new Guid("2fd15bc1-ca50-4eef-980c-86a30accac5c"), "I.56.29", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Other food service activities" },
                    { new Guid("710b2972-9007-471f-a941-51e2603efaf7"), "J.61.30", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Satellite telecommunications activities" },
                    { new Guid("e4683a91-9150-4728-bf3c-84294db9641c"), "J.61.9", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other telecommunications activities" },
                    { new Guid("1718545a-aa65-4912-902d-210d0df0757b"), "J.61.90", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other telecommunications activities" },
                    { new Guid("42e36bd7-8f95-4ca7-bb05-90d9073fbd6c"), "J.62", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Computer programming, consultancy and related activities" },
                    { new Guid("c105a049-b29d-41aa-bc93-7ab2be399d26"), "J.62.0", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Computer programming, consultancy and related activities" },
                    { new Guid("e4eda25f-1a3d-4b09-bc0b-404fbd678e11"), "J.62.01", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Computer programming activities" },
                    { new Guid("2cbe0907-b569-45fd-bf3f-f5c12690aa5a"), "J.62.02", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Computer consultancy activities" },
                    { new Guid("66a24575-42c2-4b70-b73f-76c0159c930c"), "J.62.03", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Computer facilities management activities" },
                    { new Guid("21268209-2a59-4e50-a84f-60f823ed774f"), "J.62.09", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other information technology and computer service activities" },
                    { new Guid("a48d8e0e-1410-4e26-a587-bbf3b494d1bd"), "J.63", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Information service activities" },
                    { new Guid("d822bd37-cc8c-4360-93e0-2cf7677202cf"), "J.63.1", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("78527568-feb9-49a2-9639-585c1b0aca7f"), "J.63.11", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Data processing, hosting and related activities" },
                    { new Guid("503a74f4-7179-4da4-ad4e-1e0003ea8e6c"), "J.61.3", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Satellite telecommunications activities" },
                    { new Guid("5c0e2914-823f-47f7-9d01-9015d25eb6b5"), "J.63.12", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Web portals" },
                    { new Guid("9ab1bdf5-2f57-43e4-b197-8201d70c15b4"), "J.63.91", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "News agency activities" },
                    { new Guid("33861652-31b4-4fda-88d6-330268491b1d"), "J.63.99", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other information service activities n.e.c." },
                    { new Guid("73ed431b-11e0-48f2-b94b-e6c0f2ade0ff"), "K.64", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("083a4a75-f15e-4eb3-b276-7299d6672642"), "K.64.1", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Monetary intermediation" },
                    { new Guid("7630a9c7-15c4-4e6b-a771-0d6cea311b33"), "K.64.11", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Central banking" },
                    { new Guid("b4ec5449-0eb6-4ac1-8a59-966c506dcc3a"), "K.64.19", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Other monetary intermediation" },
                    { new Guid("b26b6935-1685-4fab-a38b-4994c7cc3407"), "K.64.2", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Activities of holding companies" },
                    { new Guid("86080096-98cd-4af8-beb2-bce9739e5817"), "K.64.20", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6babde3d-7f5a-4375-b4a4-93b407b9b3ff"), "K.64.3", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Trusts, funds and similar financial entities" },
                    { new Guid("deef4633-4632-471f-8944-b95b5b6a8dd2"), "K.64.30", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Trusts, funds and similar financial entities" },
                    { new Guid("a5676781-47b9-416d-8da8-d8fd6310a1e6"), "K.64.9", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("42d2145f-2fed-4c37-8129-f67111041aa8"), "K.64.91", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Financial leasing" },
                    { new Guid("3eea5bb8-555f-4b3e-9234-108d2e4ab528"), "J.63.9", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other information service activities" },
                    { new Guid("cf8ea4fe-40bd-49e4-8510-1018f18d9fe6"), "J.61.20", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Wireless telecommunications activities" },
                    { new Guid("0b63bdb1-5c28-49d3-8fdd-4ee8555658ba"), "J.61.2", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Wireless telecommunications activities" },
                    { new Guid("cf9a9ec8-d2a8-434e-ba28-86fbeb830b15"), "J.61.10", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Wired telecommunications activities" },
                    { new Guid("9bed7165-1ab4-4c4e-8bca-c391d61fec96"), "I.56.3", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Beverage serving activities" },
                    { new Guid("a887d764-8c4c-4548-93a3-3a3daeab4844"), "I.56.30", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Beverage serving activities" },
                    { new Guid("5eb021bc-1a4b-4b19-b2b9-b069e663c539"), "J.58", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Publishing activities" },
                    { new Guid("9cf5ac47-4476-47cb-b562-9718e7888966"), "J.58.1", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("3f038758-76a4-4b3f-b125-d5ce5d3fca5b"), "J.58.11", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Book publishing" },
                    { new Guid("20d9670c-3849-4cde-a4dc-5e19d755df3b"), "J.58.12", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Publishing of directories and mailing lists" },
                    { new Guid("3fdc5ef1-1d7b-4f37-9df0-a3a572a383be"), "J.58.13", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Publishing of newspapers" },
                    { new Guid("f5d599ec-f3aa-49e8-9655-aac39bbb802d"), "J.58.14", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Publishing of journals and periodicals" },
                    { new Guid("608d33c5-5d0a-4071-9b35-2e158a1c0e85"), "J.58.19", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other publishing activities" },
                    { new Guid("59033d4c-2c0a-45c2-84bd-14349ac68d25"), "J.58.2", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Software publishing" },
                    { new Guid("b8c378f8-6022-4d70-9633-8171bb956156"), "J.58.21", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Publishing of computer games" },
                    { new Guid("4e7fcd47-ea09-4079-9889-d0cdbf1a8127"), "J.58.29", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Other software publishing" },
                    { new Guid("4fbd3e5d-4532-4999-b7ba-a83ac6c04a0a"), "J.59", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("e1c42436-c8fb-485f-9afd-44d7caa1b529"), "J.59.1", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Motion picture, video and television programme activities" },
                    { new Guid("c0a2ba6f-4192-4e62-b676-551e4046e57c"), "J.59.11", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Motion picture, video and television programme production activities" },
                    { new Guid("7c388d6a-0018-4989-bb1f-acee3b02230f"), "J.59.12", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("6c445aca-7b4d-44f8-979c-726ac73e2449"), "J.59.13", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("125ab7d2-8212-4092-92fd-39babcaf3545"), "J.59.14", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Motion picture projection activities" },
                    { new Guid("2add5867-33ad-4eb5-b4f6-f4e6cfe2bdba"), "J.59.2", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Sound recording and music publishing activities" },
                    { new Guid("368c0c2f-a614-415c-9f0b-b72039a70b40"), "J.59.20", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Sound recording and music publishing activities" },
                    { new Guid("f387c109-896c-4c44-ad3b-84874173fcac"), "J.60", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Programming and broadcasting activities" },
                    { new Guid("46880adf-70b8-49b9-9d04-10fa1fb1262c"), "J.60.1", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Radio broadcasting" },
                    { new Guid("5316394c-9cd0-4ea1-9862-7116bfcfe12b"), "J.60.10", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Radio broadcasting" },
                    { new Guid("5658bbf4-605d-4e1e-8d25-7e26b40ad231"), "J.60.2", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Television programming and broadcasting activities" },
                    { new Guid("46bcd744-57a9-46f8-ade8-1c5998addb97"), "J.60.20", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Television programming and broadcasting activities" },
                    { new Guid("c39ebeb3-96ed-41b6-8b8c-b45eca595133"), "J.61", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Telecommunications" },
                    { new Guid("231f4184-a179-4de3-a122-2b1d6b37313d"), "J.61.1", new Guid("06590523-328f-45b0-824f-6fe51626eb8a"), "Wired telecommunications activities" },
                    { new Guid("f39b9c91-e254-445a-8ce8-b5dfac97b23e"), "I.56.21", new Guid("157143fc-f398-4c85-bb8b-5a3c15cb69a9"), "Event catering activities" },
                    { new Guid("9f655bc2-115a-408a-83f9-0bfffe54589c"), "K.64.92", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Other credit granting" },
                    { new Guid("70e2353a-0fcb-4f02-9313-57d432cbf5b7"), "G.47.82", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("f6f618b5-0c1d-4729-8a4d-617d9a663657"), "G.47.8", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale via stalls and markets" },
                    { new Guid("b7bd6038-51b9-4edb-ba1e-0b0b23770b1e"), "G.46.19", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("566cf972-ef3b-441a-9ce2-504199d56fa8"), "G.46.2", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("d015edb8-91e9-46eb-a884-927b9e4d7d75"), "G.46.21", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("979c0cf3-1cad-48d9-ab69-1ae28273c7e2"), "G.46.22", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of flowers and plants" },
                    { new Guid("0ba17b39-17b3-4545-aa62-18e881606968"), "G.46.23", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of live animals" },
                    { new Guid("efabae02-bdba-40bd-a02b-d7130bf544b0"), "G.46.24", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of hides, skins and leather" },
                    { new Guid("b8cc4fe2-df73-481c-9c03-09c8440483bd"), "G.46.3", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("3fd4f093-da69-4a0b-b591-b801e04e4c21"), "G.46.31", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of fruit and vegetables" },
                    { new Guid("b2be06e4-abe4-4906-bdf8-2a23efc3cd0c"), "G.46.32", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of meat and meat products" },
                    { new Guid("f5ac754c-35f6-42cb-bc7c-7b258d383dd5"), "G.46.33", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("cbeecea5-8915-4ffe-9799-7a5e6b345a62"), "G.46.34", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of beverages" },
                    { new Guid("482f7bde-f265-4f0d-84a6-1721759076a6"), "G.46.35", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of tobacco products" },
                    { new Guid("0896e801-3905-41ca-b4ab-481336e5eb94"), "G.46.18", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents specialised in the sale of other particular products" },
                    { new Guid("2dc27024-4e37-4f7a-a7f7-102973df72b0"), "G.46.36", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("83bbe650-21b1-4ca7-ad23-efeac7be0c61"), "G.46.38", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("28d4d578-6564-47f8-a5b4-ae0aa9f9edce"), "G.46.39", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("6ee2832a-e5f5-4fd8-ba0c-54b4221a2bc4"), "G.46.4", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of household goods" },
                    { new Guid("5004fa72-332f-4059-bda5-01c508410322"), "G.46.41", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of textiles" },
                    { new Guid("46333ab4-8ba0-4df2-92c2-d013163166e7"), "G.46.42", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of clothing and footwear" },
                    { new Guid("0d55bb8e-e966-49ce-b7a2-d2944ef7233a"), "G.46.43", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of electrical household appliances" },
                    { new Guid("f641e8dc-0584-411d-a57d-19d5e2c22be0"), "G.46.44", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("ce614933-d324-4c76-aa9c-2d7162d8fd8d"), "G.46.45", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of perfume and cosmetics" },
                    { new Guid("915f8962-6eb6-49ff-8f03-1dfbb70665f9"), "G.46.46", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of pharmaceutical goods" },
                    { new Guid("1f5fc04d-67df-4cfc-a6a2-7e1958bf2f85"), "G.46.47", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("b75ce7b6-8ce9-4968-8ac8-a881fb35df1d"), "G.46.48", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of watches and jewellery" },
                    { new Guid("a984007e-2aaf-433f-9163-3f2d010eae02"), "G.46.49", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of other household goods" },
                    { new Guid("666a3147-52ae-48b1-8dd3-ab57a725f0ff"), "G.46.37", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("9746c17e-2e04-4281-b9e3-187f52fa4608"), "G.46.17", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("25296f06-7f1b-4b3a-a48f-b3a7df4114d1"), "G.46.16", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("ccea7a18-7c99-45c5-91d0-d91f166d7b29"), "G.46.15", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("5a32647c-26f2-4645-a9c1-5de54a00f9ce"), "F.43.29", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Other construction installation" },
                    { new Guid("30155b79-71a2-451d-8d8b-25a378c65f57"), "F.43.3", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Building completion and finishing" },
                    { new Guid("eab695c3-29c6-4add-871e-b292f7f79e05"), "F.43.31", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Plastering" },
                    { new Guid("911101e3-cb34-415d-999b-7ca29a25b43d"), "F.43.32", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Joinery installation" },
                    { new Guid("2e7bb1b0-dcbb-4413-b003-83ea86b5e871"), "F.43.33", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Floor and wall covering" },
                    { new Guid("28a13695-b180-4b8d-bee5-d20aac5facef"), "F.43.34", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Painting and glazing" },
                    { new Guid("5b908c87-76e4-4c0e-b313-350b551531a1"), "F.43.39", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Other building completion and finishing" },
                    { new Guid("f0fa664a-d7ee-481a-821f-c23243722e0a"), "F.43.9", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Other specialised construction activities" },
                    { new Guid("d03e071b-c417-4621-8d70-085fcbf11750"), "F.43.91", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Roofing activities" },
                    { new Guid("37f0f5ec-9dbf-4aec-9ba6-29ae89d72e6e"), "F.43.99", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Other specialised construction activities n.e.c." },
                    { new Guid("2f001d6a-2715-46e1-8677-558a6404761a"), "G.45", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("eab87db7-5c76-4512-bbc2-1bed2d9e3d62"), "G.45.1", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Sale of motor vehicles" },
                    { new Guid("47564cb2-54a1-4aca-af13-afb4caaeb6ab"), "G.45.11", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Sale of cars and light motor vehicles" },
                    { new Guid("92786979-43a6-4edf-be03-d6a0deb096e4"), "G.45.19", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Sale of other motor vehicles" },
                    { new Guid("7b5e1c8c-27d8-4d19-bfc9-36067bd081a0"), "G.45.2", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fec01967-5f81-4adb-8eed-7477f8cc56c3"), "G.45.20", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Maintenance and repair of motor vehicles" },
                    { new Guid("d2d42e8e-6c69-4513-83c9-02ab9425c320"), "G.45.3", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("24e1590f-fce9-4605-9f48-4c38eeb734c2"), "G.45.31", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("9d98be43-62b6-44be-b6a0-7f32ddf5abaa"), "G.45.32", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("8f83fd20-b231-47fd-b2a9-dde8bf47e27d"), "G.45.4", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("9da5a03a-1e28-400d-bd1d-f4ac6ad0c128"), "G.45.40", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("6a8733f5-a961-47b1-8a22-8d926c6ac16b"), "G.46", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("e34fe593-8dfc-45b0-9763-328cce82b344"), "G.46.1", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale on a fee or contract basis" },
                    { new Guid("b96abde8-0dad-48f9-b7b2-fa6674ae62d7"), "G.46.11", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("157c5810-ddb8-40f5-89d7-f5331684c4b5"), "G.46.12", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("e1c62a36-c1cb-4f44-86e5-673fb102f298"), "G.46.13", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("2b2dc5f5-4198-42d7-a190-abf1dba4f3f3"), "G.46.14", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("c01c3ebd-9130-463a-8b25-0a080eab6552"), "G.46.5", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of information and communication equipment" },
                    { new Guid("93c4ec1a-ece8-4d45-b9e1-74b6e131fc4f"), "G.47.81", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("175fea29-47f8-4b8f-be8a-21b46d8cbd2c"), "G.46.51", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("33969255-05f9-4811-a8da-fd01ebe38bba"), "G.46.6", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("a20c218e-b398-4fb5-a211-e1287870d267"), "G.47.4", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("6bb19cc4-030d-4139-88bc-dc083f5a9ca2"), "G.47.41", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("8f566615-d239-425f-83a5-60e6a4258da3"), "G.47.42", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("cb4693f8-d521-4f19-abd1-9034acf3807b"), "G.47.43", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("65732700-c61f-4631-a897-0200d4016ee5"), "G.47.5", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("29b2546f-f5f8-405e-be21-384865f34332"), "G.47.51", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of textiles in specialised stores" },
                    { new Guid("eaf8cc8a-cbb6-4160-b286-de3c485aab95"), "G.47.52", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("6f779307-0f4d-4cb3-bea7-df66bb8d0716"), "G.47.53", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("85f5b570-8622-4d82-8384-86a629250706"), "G.47.54", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("3d5942a4-b5bf-47b2-adbe-db5f455d23e4"), "G.47.59", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("26f63cdc-d4dd-487c-833d-2737ce23a026"), "G.47.6", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("a721b210-4e9b-4129-96c4-2fda0daef860"), "G.47.61", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of books in specialised stores" },
                    { new Guid("92ddb704-5b98-4e29-b160-c5569df19400"), "G.47.30", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("858102d2-f259-4148-a341-f654038ed1dd"), "G.47.62", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("470d0c16-817b-4910-a1e3-eddacaf6cfcf"), "G.47.64", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("07485cc9-9a25-483b-b319-2247bfc31a45"), "G.47.65", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("f8d8e671-4949-4e07-9c26-8013dec3d6fb"), "G.47.7", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of other goods in specialised stores" },
                    { new Guid("decc26b2-daea-480e-8ade-513f65ae1b31"), "G.47.71", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of clothing in specialised stores" },
                    { new Guid("068185d2-ab38-434a-9df6-09ece7ecfbca"), "G.47.72", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("c7dd125c-75f9-4325-8206-41147aadde62"), "G.47.73", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Dispensing chemist in specialised stores" },
                    { new Guid("b9b3b6b6-ee05-444d-8f3f-a078c80f6183"), "G.47.74", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("a33b4d03-e024-4b15-952f-0c20f4c3081e"), "G.47.75", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("eb4d677e-5ce3-4e7e-aaa5-4e4d9a77f58d"), "G.47.76", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("1ea59796-0efb-46a7-9261-1acfb5ab6b9e"), "G.47.77", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("da256316-bb62-4d9b-9ce9-74161d78b40e"), "G.47.78", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("81e173f6-2c08-4ba3-aef3-cda1cc3379f6"), "G.47.79", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("14909178-0fb6-4745-a3c1-dacedf581fee"), "G.47.63", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("aa8736fa-abbf-4e7c-bf7d-cbcaf809b0cd"), "G.47.3", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("a29cdb28-e8b1-4e5c-9c44-0b4d6f2729b8"), "G.47.29", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Other retail sale of food in specialised stores" },
                    { new Guid("60381df9-36d5-4fc5-b19b-dbb804dc75f3"), "G.47.26", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("76e7045d-a07f-47e9-bd01-3a69b5c43405"), "G.46.61", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("7df04155-fffe-43b9-8b7c-6cc5cbe4289d"), "G.46.62", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of machine tools" },
                    { new Guid("775ed6bd-d902-4c15-9bf5-96431efb276f"), "G.46.63", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("6290ca5a-8bf7-4a2f-a347-e5fd1fbdbc83"), "G.46.64", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("9d2b98f2-d9f7-4127-ba4c-74eaa7f4d8e0"), "G.46.65", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of office furniture" },
                    { new Guid("6b49272c-821b-45c6-9392-8300b54938e2"), "G.46.66", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of other office machinery and equipment" },
                    { new Guid("3b0cbad0-f225-45c8-8e43-7a0ac5d8531d"), "G.46.69", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of other machinery and equipment" },
                    { new Guid("e11e6127-f4f5-4114-8d6e-ff9ecc806728"), "G.46.7", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Other specialised wholesale" },
                    { new Guid("a9488789-6315-4ebe-8a88-ed3e5833bc1e"), "G.46.71", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("26babcf2-5db8-4da0-8770-55b5c6c55dae"), "G.46.72", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of metals and metal ores" },
                    { new Guid("c6afb838-913b-462c-b70c-17540577f870"), "G.46.73", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("f5d9448a-2636-428d-a261-f3731ee03d7c"), "G.46.74", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("212fb13c-18db-4568-91fb-06a433a40d92"), "G.46.75", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of chemical products" },
                    { new Guid("60bdd8d8-6504-450b-8245-400f4f0fe36e"), "G.46.76", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of other intermediate products" },
                    { new Guid("6e23518c-5e90-4e12-b9a8-545278db850d"), "G.46.77", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of waste and scrap" },
                    { new Guid("83f3437e-0e9c-4827-81d2-53792a8814a2"), "G.46.9", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Non-specialised wholesale trade" },
                    { new Guid("9f801a83-e052-4473-89ef-1dcceacb4627"), "G.46.90", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Non-specialised wholesale trade" },
                    { new Guid("570e469a-efd1-4504-ae32-a1f687187b52"), "G.47", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("073dd4ad-ff58-47ec-bded-2ab70fb2a06a"), "G.47.1", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale in non-specialised stores" },
                    { new Guid("c71eedcf-6c50-4bc8-ac8b-ace5e14075d5"), "G.47.11", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("7bc3ab86-7db8-4bc1-8fa1-7e02d750d502"), "G.47.19", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Other retail sale in non-specialised stores" },
                    { new Guid("9914acea-45d5-41f2-9d9e-bfc8de9e80f2"), "G.47.2", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("dd42ac23-e649-4c35-a7fe-e6960e877bf4"), "G.47.21", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("c4036f02-9444-4297-8bf1-37b7461ed7f1"), "G.47.22", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("e383ffa0-a21b-45e6-bb9c-ae43554339d6"), "G.47.23", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("e1cee859-edb8-4894-b2e9-6055829da1ba"), "G.47.24", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("0806180b-ae54-48f2-8bd1-a1f318649193"), "G.47.25", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Retail sale of beverages in specialised stores" },
                    { new Guid("8576c93d-8741-4e1d-ad4a-b79e7e0de6f3"), "G.46.52", new Guid("29b49f87-d791-4185-b638-c41bf5822032"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("54718f55-73ee-43d1-b497-58c59f5364e8"), "F.43.22", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("5f7771bb-fc57-477e-8f12-fc8a14f36ca1"), "K.64.99", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("aca7bbd8-18c4-4577-88a1-40682bccf155"), "K.65.1", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Insurance" },
                    { new Guid("ee5170c2-0359-4bdb-b7fa-e331ef358257"), "P.85.6", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Educational support activities" },
                    { new Guid("7f6247cc-19d5-4abe-b2c9-a4d455af5aaf"), "P.85.60", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Educational support activities" },
                    { new Guid("ea42c3ab-fb87-4987-a84e-e89a79459000"), "Q.86", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Human health activities" },
                    { new Guid("833a696d-5bfb-4cb3-9e46-8080d035c1a3"), "Q.86.1", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Hospital activities" },
                    { new Guid("7d4ae439-e991-485d-ada7-76485a8b9a30"), "Q.86.10", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Hospital activities" },
                    { new Guid("d0b24240-2123-48ca-8ffd-8725a0add04d"), "Q.86.2", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Medical and dental practice activities" },
                    { new Guid("28375720-657c-48f6-afc9-cfe6510e1add"), "Q.86.21", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c70854e0-0193-49d9-9918-d7860109fec3"), "Q.86.22", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Specialist medical practice activities" },
                    { new Guid("2c5bb42d-ce96-4c1f-a82a-4e74db50b900"), "Q.86.23", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Dental practice activities" },
                    { new Guid("f46495aa-e09b-43c1-b037-da4a2507acfe"), "Q.86.9", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Other human health activities" },
                    { new Guid("e9d54fc0-9fd1-4929-8e1a-2b2a32548a8d"), "Q.86.90", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Other human health activities" },
                    { new Guid("c6058260-89bc-4ebf-b5d2-d3a19bd905f0"), "Q.87", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential care activities" },
                    { new Guid("51e721ed-69bb-4883-83b8-76ac6731afa5"), "P.85.59", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Other education n.e.c." },
                    { new Guid("b7f3c7f8-8fb8-4474-89e9-711e98fdefdb"), "Q.87.1", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential nursing care activities" },
                    { new Guid("61082429-e582-46f0-9c86-25357badd89a"), "Q.87.2", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("373eabd5-a480-4c00-ba4c-f23089a65216"), "Q.87.20", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("1b744816-2c87-4039-9c57-8afc91565c61"), "Q.87.3", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential care activities for the elderly and disabled" },
                    { new Guid("bbf3ba97-9a12-4d99-89dd-80186da95621"), "Q.87.30", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential care activities for the elderly and disabled" },
                    { new Guid("3be92eea-ef90-4185-83d6-67529555070a"), "Q.87.9", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Other residential care activities" },
                    { new Guid("89b992de-dec1-4f56-aff0-f08cc131a70e"), "Q.87.90", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Other residential care activities" },
                    { new Guid("f6f3def9-91f4-4a28-bd2c-28fd4d916c4e"), "Q.88", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Social work activities without accommodation" },
                    { new Guid("fc471115-e95f-4af5-92b9-c54a2bc1d37f"), "Q.88.1", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("7cd57578-1641-43e7-87c0-c49f61d95966"), "Q.88.10", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("1bedcc0f-82f8-485a-92c0-86acc502f623"), "Q.88.9", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Other social work activities without accommodation" },
                    { new Guid("8686fb2e-a997-4a58-bb14-4af0d6918589"), "Q.88.91", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Child day-care activities" },
                    { new Guid("ef25ea89-500f-4525-96d3-e47384ee1baa"), "Q.88.99", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("6681dc60-1fac-4903-863c-0edf7fb20f54"), "Q.87.10", new Guid("c5b1612c-edeb-4dc8-8c4d-5215b33adbdd"), "Residential nursing care activities" },
                    { new Guid("4f0f41f2-3a0e-4245-b714-adafc9c05ae1"), "P.85.53", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Driving school activities" },
                    { new Guid("bfc7d082-0b31-4d17-9423-5460d67884a7"), "P.85.52", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Cultural education" },
                    { new Guid("8dfac0b1-eaed-4ee9-af53-8d1969ad1ead"), "P.85.51", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Sports and recreation education" },
                    { new Guid("3b51517d-6d85-41dc-88bd-1760e7ceb7b4"), "N.82.91", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Packaging activities" },
                    { new Guid("a6bbac6e-eda3-44ef-95fe-064430620d03"), "N.82.99", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other business support service activities n.e.c." },
                    { new Guid("5e152c05-81c4-4424-94af-f19be9699b69"), "O.84", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Public administration and defence; compulsory social security" },
                    { new Guid("8db10cba-8999-4f4f-a014-f0b2102fd062"), "O.84.1", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("a790b389-1b58-4f36-8267-67ea19d9f00f"), "O.84.11", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "General public administration activities" },
                    { new Guid("1824f0a8-3618-4e46-8c0c-bf6a9560efb7"), "O.84.12", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("6c871dbc-5562-4a7b-96c1-dfe72f6e6d77"), "O.84.13", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("ead9b9e6-035f-4ecc-b044-c49ae835fefd"), "O.84.2", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Provision of services to the community as a whole" },
                    { new Guid("adba13df-96b2-43b1-8082-5215e94c90ee"), "O.84.21", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Foreign affairs" },
                    { new Guid("9837a1ec-51d9-42c8-84c4-1ece53cb8ed6"), "O.84.22", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Defence activities" },
                    { new Guid("c18b70c4-67c9-4a8c-94b6-70edfbf3b2ac"), "O.84.23", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Justice and judicial activities" },
                    { new Guid("86723de5-f4c3-4bb2-be5f-bae49228644d"), "O.84.24", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Public order and safety activities" },
                    { new Guid("2e886121-6b41-4bcb-8a04-6a3363e15e16"), "O.84.25", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Fire service activities" },
                    { new Guid("94379960-184a-442c-8f17-29ce127b4f67"), "O.84.3", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Compulsory social security activities" },
                    { new Guid("85c1cdd8-63a7-4e1b-9a24-58f21da8da96"), "O.84.30", new Guid("4b965867-747f-4d2a-809e-c39f52799406"), "Compulsory social security activities" },
                    { new Guid("5bf9c8fa-fbbe-44d8-ab00-224be825809d"), "P.85", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Education" },
                    { new Guid("826dd965-9f58-463c-9123-28c2ca2110fd"), "P.85.1", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Pre-primary education" },
                    { new Guid("f4b404ef-178c-4d8a-8275-621bad50c711"), "P.85.10", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Pre-primary education" },
                    { new Guid("d655a2a9-f8b6-4e9a-87e2-3e2cf6f5b3c5"), "P.85.2", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bc37361f-e961-4a14-bfda-25c886ac85bf"), "P.85.20", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Primary education" },
                    { new Guid("7b67f9b7-b835-4361-bf3b-fa304961499e"), "P.85.3", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Secondary education" },
                    { new Guid("0edafcc1-3942-4865-8356-42893eb90885"), "P.85.31", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "General secondary education" },
                    { new Guid("c0377a73-e3bc-4f0d-bd1a-52f4bf89d69d"), "P.85.32", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Technical and vocational secondary education" },
                    { new Guid("90c284a8-1655-4d2b-ad24-c50adc5ff661"), "P.85.4", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Higher education" },
                    { new Guid("c381cea1-9eb1-41b9-8c80-271a8cd8521e"), "P.85.41", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Post-secondary non-tertiary education" },
                    { new Guid("349aa36f-cde8-480d-9963-411baf9b89f0"), "P.85.42", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Tertiary education" },
                    { new Guid("1da8dbf6-1df1-4f35-8c8a-05b5e224979f"), "P.85.5", new Guid("841af133-b4e0-41b9-995d-23ff17af7ff2"), "Other education" },
                    { new Guid("1a354579-a26f-41a9-85d0-e9580a0fdb81"), "R.90", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Creative, arts and entertainment activities" },
                    { new Guid("284e7929-9657-48f7-b1e5-677582788324"), "N.82.92", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("279ffcc8-d778-4301-ac9e-ad3482eb192c"), "R.90.0", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Creative, arts and entertainment activities" },
                    { new Guid("05df535a-a37a-44c6-8755-b70d4ae9d3d3"), "R.90.02", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Support activities to performing arts" },
                    { new Guid("0c6380c4-c768-42d1-b0ee-d49bc9cc186d"), "S.95.1", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of computers and communication equipment" },
                    { new Guid("54fd891e-b2b5-44d4-9782-8827d83c71e7"), "S.95.11", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of computers and peripheral equipment" },
                    { new Guid("7389b04c-b4dc-4b23-abc2-1263572fd7a1"), "S.95.12", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of communication equipment" },
                    { new Guid("d3336a4c-698a-4613-bb0a-b0a6a3e54abe"), "S.95.2", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of personal and household goods" },
                    { new Guid("9445e6b8-e62c-42f8-bdbc-7c2f4fc7ae7b"), "S.95.21", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of consumer electronics" },
                    { new Guid("fa71ec9f-ccae-4bb6-befb-f02782ec02cd"), "S.95.22", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("601af30c-8ccf-48ae-9da3-85677e6b6765"), "S.95.23", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of footwear and leather goods" },
                    { new Guid("7033de41-d554-4c5c-bcc0-5a8646d569a6"), "S.95.24", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of furniture and home furnishings" },
                    { new Guid("295ff18f-34ff-4edd-bfbb-6a6edc98d634"), "S.95.25", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of watches, clocks and jewellery" },
                    { new Guid("79b1d76b-b4e5-4874-b71c-55b686aa946e"), "S.95.29", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of other personal and household goods" },
                    { new Guid("f2d17ce7-b1eb-4377-a31e-8bf8ee5a2688"), "S.96", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Other personal service activities" },
                    { new Guid("a210d54f-6e17-4b82-82c1-ec6be230a27e"), "S.96.0", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Other personal service activities" },
                    { new Guid("c59381de-7ced-4940-b6fa-eda43d65362e"), "S.95", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Repair of computers and personal and household goods" },
                    { new Guid("43e8093b-ad38-4e24-ba8f-f1313ad12f81"), "S.96.01", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("c786cbc0-49df-4628-b5d9-fecef5cccf86"), "S.96.03", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Funeral and related activities" },
                    { new Guid("d0205013-ca78-471b-80e1-cd5b640d80e5"), "S.96.04", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Physical well-being activities" },
                    { new Guid("46cc307b-399a-404c-874c-f28c18e6088b"), "S.96.09", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Other personal service activities n.e.c." },
                    { new Guid("9ee22e1b-021b-41dd-9481-93f550d956b9"), "T.97", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Activities of households as employers of domestic personnel" },
                    { new Guid("aaf52085-057c-44ef-a171-bd6bc0b1a3d6"), "T.97.0", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Activities of households as employers of domestic personnel" },
                    { new Guid("cc8a5963-1b48-4d94-8c96-179313f4b57b"), "T.97.00", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Activities of households as employers of domestic personnel" },
                    { new Guid("d82a4d1c-35ab-4e12-b91c-1758b358bbad"), "T.98", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("c097e786-9ba7-43cc-8cc7-8f4ccb3a7cd2"), "T.98.1", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("f1ad30b6-2133-48c5-b6cb-8c9c56963126"), "T.98.10", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("2cca406a-6b3f-43de-a05f-9b1d4774648a"), "T.98.2", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("1f28ec92-6535-4f7f-8376-304ba9a87212"), "T.98.20", new Guid("bc216c34-1209-4c19-bb08-3c59d3030d96"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("1924b250-8496-4445-a50d-0d12a06c13d6"), "U.99", new Guid("93fb6644-f8fa-49fa-a07d-20b6393c1693"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("c104df1e-aa1f-4196-9734-25ae1e9313bc"), "S.96.02", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Hairdressing and other beauty treatment" },
                    { new Guid("85535581-393c-4635-ba67-c5a8ab7f656f"), "S.94.99", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of other membership organisations n.e.c." },
                    { new Guid("67041f48-f330-447e-9a5e-ef381cd25491"), "S.94.92", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of political organisations" },
                    { new Guid("e825c0dd-2778-4b16-b314-f4870229a618"), "S.94.91", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("466ff6d8-7ae5-489a-8241-84f716783404"), "R.90.03", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Artistic creation" },
                    { new Guid("73c28c3c-3165-45da-bd5d-e98b7108cd9e"), "R.90.04", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Operation of arts facilities" },
                    { new Guid("099aa3eb-8d4d-4293-b2aa-e2fd1823796b"), "R.91", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("b5dc1eb9-7e5d-43a9-b281-6f79d901b477"), "R.91.0", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("6136e345-b495-42c5-9cdd-53aa92cfdb18"), "R.91.01", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Library and archives activities" },
                    { new Guid("9400a554-96e6-4223-a1b9-07e5ebf68f51"), "R.91.02", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Museums activities" },
                    { new Guid("bdadcd21-80bf-4ec3-a3cf-07900f0a1591"), "R.91.03", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("0ea3135b-e0f1-455c-9964-a4718108cb3d"), "R.91.04", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("4e54549a-83ac-4fd4-919e-dc15de9bd061"), "R.92", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Gambling and betting activities" },
                    { new Guid("9a4cf639-6ec1-49ac-ab77-8c4129a67f43"), "R.92.0", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Gambling and betting activities" },
                    { new Guid("f630d030-d6a8-4274-bc38-a1802b648188"), "R.92.00", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Gambling and betting activities" },
                    { new Guid("8fbaf70a-7285-4ff3-9be7-83651fb04ea5"), "R.93", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Sports activities and amusement and recreation activities" },
                    { new Guid("e5edf92f-79b2-42fb-b27d-9a56f82476ce"), "R.93.1", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Sports activities" },
                    { new Guid("4e9472c8-7ef3-43a4-a609-831afe481e6e"), "R.93.11", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Operation of sports facilities" },
                    { new Guid("308e50a6-479d-4eb9-aa95-fdf53ed1a584"), "R.93.12", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Activities of sport clubs" },
                    { new Guid("b5298ff3-ffcb-4d41-9d30-7fb7fc0ca2bb"), "R.93.13", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Fitness facilities" },
                    { new Guid("9a275f04-2300-4b57-b86a-8faecd2d2771"), "R.93.19", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Other sports activities" },
                    { new Guid("3b492ea3-987d-4e10-b0ea-f77e9111c722"), "R.93.2", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Amusement and recreation activities" },
                    { new Guid("f542c9db-3c36-46c4-998c-a2ab808172e4"), "R.93.21", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Activities of amusement parks and theme parks" },
                    { new Guid("6f1a0d39-06c4-4c15-8f54-affcd4a3b808"), "R.93.29", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Other amusement and recreation activities" },
                    { new Guid("d5a2e7d0-d2a9-414a-9c64-d1b12f86091f"), "S.94", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of membership organisations" },
                    { new Guid("4f330d51-29a9-4dad-839b-0141d9d312b8"), "S.94.1", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("64ea91dd-6f90-4dda-ad41-229d18039d8e"), "S.94.11", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of business and employers membership organisations" },
                    { new Guid("52d7ad9c-8990-4c00-9ef7-4cba21b569c7"), "S.94.12", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of professional membership organisations" },
                    { new Guid("dc07d6c9-96ac-4c82-ac30-04cf9e773c4d"), "S.94.2", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of trade unions" },
                    { new Guid("37ab0439-5226-4557-95ae-8c3190131665"), "S.94.20", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of trade unions" },
                    { new Guid("bf62931d-e6ea-45c1-807b-5cd37ca6a461"), "S.94.9", new Guid("1be25458-c43d-4afe-836d-f931feb4620a"), "Activities of other membership organisations" },
                    { new Guid("53f74503-06ee-474f-a0a0-34d10571fdcb"), "R.90.01", new Guid("f62c4021-251e-4258-9950-556a5a690686"), "Performing arts" },
                    { new Guid("32b4eb80-fc47-4489-bc53-39b12b69b46d"), "K.65", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("71addf7e-8f37-4f7d-91a3-aea10c5d138d"), "N.82.9", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Business support service activities n.e.c." },
                    { new Guid("69f1cfda-bfab-4382-8ecf-38dd67af688e"), "N.82.3", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Organisation of conventions and trade shows" },
                    { new Guid("616a23a6-da2f-49c8-8a9d-b3ad60be6804"), "M.70.1", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Activities of head offices" },
                    { new Guid("62abd6dd-d017-418d-88cd-8010540a2ebb"), "M.70.10", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Activities of head offices" },
                    { new Guid("08369905-9ca5-4bc7-a462-80884c1740d0"), "M.70.2", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Management consultancy activities" },
                    { new Guid("765d090e-8d92-45b8-b805-2402d0b5970c"), "M.70.21", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Public relations and communication activities" },
                    { new Guid("43b5e4ad-eb6c-4f3b-9284-137b1b672698"), "M.70.22", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Business and other management consultancy activities" },
                    { new Guid("70e4d58c-af37-42cd-a7ae-dc5bf07199fe"), "M.71", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("e5e67e59-78aa-4e76-9d81-0b02fa5c3eea"), "M.71.1", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("8477880b-5ecd-4457-9f7c-affae8dab7c3"), "M.71.11", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Architectural activities" },
                    { new Guid("aa239112-bb81-4f8b-935b-19c7e99cea30"), "M.71.12", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Engineering activities and related technical consultancy" },
                    { new Guid("7a82d7f5-2d0e-4029-b09f-040147a35e6b"), "M.71.2", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Technical testing and analysis" },
                    { new Guid("bacfcbd0-da13-4a94-9617-f2e5a5fddb32"), "M.71.20", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7ece8029-254c-42c8-94f2-0720188080c0"), "M.72", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Scientific research and development" },
                    { new Guid("ceae1786-df15-42e9-8f00-9d1f5d82d17a"), "M.70", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Activities of head offices; management consultancy activities" },
                    { new Guid("739e2d22-2b59-406b-bc4e-693f446a9369"), "M.72.1", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("47c87d82-36ba-41cd-bfae-921453c7d28c"), "M.72.19", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("10311769-88e8-4e86-aa6e-caa6c7f7a48c"), "M.72.2", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("87259e69-f409-4684-8f35-b839f0caad94"), "M.72.20", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("22190873-e7b2-45cf-bdb4-bb33300d62ab"), "M.73", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Advertising and market research" },
                    { new Guid("f1e33a2a-3993-48c8-a0db-0cf01b93409b"), "M.73.1", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Advertising" },
                    { new Guid("edbbf7dc-0d48-4362-87a9-36ed5ddfd6fc"), "M.73.11", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Advertising agencies" },
                    { new Guid("64bc4977-6539-45e3-9e58-8912d44744a5"), "M.73.12", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Media representation" },
                    { new Guid("e39b5a3a-db72-4e0e-916b-74024f2c899c"), "M.73.2", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Market research and public opinion polling" },
                    { new Guid("fe159cdb-8afe-44d7-8b26-3969554c813f"), "M.73.20", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Market research and public opinion polling" },
                    { new Guid("682a7cfb-1b06-4cda-959d-4c45123228fe"), "M.74", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Other professional, scientific and technical activities" },
                    { new Guid("7782fb8f-5324-4974-be1d-9123ebb26da4"), "M.74.1", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Specialised design activities" },
                    { new Guid("992c9370-1b14-4fcc-bef9-ba814b2faf81"), "M.74.10", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Specialised design activities" },
                    { new Guid("3132a8a8-f69c-4b75-9964-32df5098baaf"), "M.72.11", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Research and experimental development on biotechnology" },
                    { new Guid("57f5fe01-58e7-4f09-9323-2f1003f44ba8"), "M.69.20", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("00c7b3a7-0fe4-4365-95c4-9442c5a8f48a"), "M.69.2", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("658ee583-0af3-47ce-b678-83f757b3c72b"), "M.69.10", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Legal activities" },
                    { new Guid("ad001f34-48e3-43c3-8aa4-1f16e5faa2aa"), "K.65.11", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Life insurance" },
                    { new Guid("e3d1b4ea-b307-4bfd-bf49-f1c32db9a08b"), "K.65.12", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Non-life insurance" },
                    { new Guid("179c78a5-10e2-4efc-96f3-66e81db1848f"), "K.65.2", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Reinsurance" },
                    { new Guid("f5911c9b-743b-4fc0-bf02-cc2ed7a1b95a"), "K.65.20", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Reinsurance" },
                    { new Guid("dab376e6-e1db-4bbc-a58a-de6b52ee1fa7"), "K.65.3", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Pension funding" },
                    { new Guid("55bbd090-37b0-40d5-8867-61654aa11078"), "K.65.30", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Pension funding" },
                    { new Guid("510e7546-e386-4d4e-a36d-126629449222"), "K.66", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("524bb173-3418-4440-a5cb-cabeae9e761a"), "K.66.1", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("1536d24e-2740-48ca-88db-8edd6036e24b"), "K.66.11", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Administration of financial markets" },
                    { new Guid("fcb08b3d-6815-496b-b6c4-c81fff249196"), "K.66.12", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Security and commodity contracts brokerage" },
                    { new Guid("1e8ea153-f9b0-49c7-9603-7b966d5e990c"), "K.66.19", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("cf2ccca9-2e8d-435f-8b0f-740a48c0db7e"), "K.66.2", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("6f3b00a1-fa3d-4a2d-a323-89d8b273d4cd"), "K.66.21", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Risk and damage evaluation" },
                    { new Guid("4dc03d33-07ac-4d83-8072-50aaafc2de11"), "K.66.22", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Activities of insurance agents and brokers" },
                    { new Guid("4ccc1a9f-3c47-4774-bb33-c0b42c436135"), "K.66.29", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("6f83b104-cdf7-46d9-8495-518139a56afc"), "K.66.3", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Fund management activities" },
                    { new Guid("f449695a-938d-4173-a500-d8775a8422b7"), "K.66.30", new Guid("3d2757a2-8806-4e6c-b436-2708705dcad0"), "Fund management activities" },
                    { new Guid("33740c93-75ed-4683-bdd7-6f735d81dcb9"), "L.68", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Real estate activities" },
                    { new Guid("e598ceac-dc4b-47b9-823e-3d252008f459"), "L.68.1", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Buying and selling of own real estate" },
                    { new Guid("4ae46206-d054-4053-b902-21d7fe8feeaa"), "L.68.10", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Buying and selling of own real estate" },
                    { new Guid("2e55be26-7af6-4563-b46c-4c730622de6f"), "L.68.2", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Renting and operating of own or leased real estate" },
                    { new Guid("2784a574-e72e-47d3-8a38-29a9b034a9d7"), "L.68.20", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Renting and operating of own or leased real estate" },
                    { new Guid("ba822709-4f87-4d5c-b1f1-f778ba339bd5"), "L.68.3", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("01dcf96e-706d-4d17-8d16-af15e643439e"), "L.68.31", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Real estate agencies" },
                    { new Guid("88cfa449-a0b2-4ae4-b55c-7668440065dd"), "L.68.32", new Guid("0f107ed4-c1a7-4e2f-82e5-1b71f084a6d8"), "Management of real estate on a fee or contract basis" },
                    { new Guid("d886747d-db4f-4554-8384-f5f501dce8b8"), "M.69", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Legal and accounting activities" },
                    { new Guid("e52eebaf-2f65-4b0c-add0-cefe51f05740"), "M.69.1", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Legal activities" },
                    { new Guid("56bd1918-eb61-4490-859d-f0fa522c5180"), "M.74.2", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Photographic activities" },
                    { new Guid("c81708fc-ba8b-4cc1-82fc-1bcd6b218494"), "N.82.30", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Organisation of conventions and trade shows" },
                    { new Guid("85149393-2b65-418d-b2e9-58889d290be1"), "M.74.20", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Photographic activities" },
                    { new Guid("8971e806-276f-47a7-918a-6961d51162fc"), "M.74.30", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Translation and interpretation activities" },
                    { new Guid("9e25b57c-0973-4773-a3c1-8ad7bc2e0583"), "N.79.11", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Travel agency activities" },
                    { new Guid("8cc6f0ce-2b4e-493f-b398-acbf704e6f27"), "N.79.12", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Tour operator activities" },
                    { new Guid("75878065-4b56-4a37-8c2a-22971ea0b813"), "N.79.9", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other reservation service and related activities" },
                    { new Guid("8f94b8e7-38d1-45de-9b7a-b29a3a61db17"), "N.79.90", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other reservation service and related activities" },
                    { new Guid("c51105d4-2ff0-426b-84e9-9ddb10257318"), "N.80", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Security and investigation activities" },
                    { new Guid("3f0300c2-dbd1-48c2-aa40-7c522cf2797c"), "N.80.1", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Private security activities" },
                    { new Guid("31142912-17b1-44d0-a362-dac673dfc511"), "N.80.10", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Private security activities" },
                    { new Guid("bb23d3d7-f1fe-4aa8-9faa-2ee7831fb041"), "N.80.2", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Security systems service activities" },
                    { new Guid("8895864b-352c-4247-8bdf-b500e7da8cab"), "N.80.20", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Security systems service activities" },
                    { new Guid("0df9895a-d4d4-4cfd-869e-a1c02df2e910"), "N.80.3", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Investigation activities" },
                    { new Guid("1648b786-482b-411d-838f-823b15bca827"), "N.80.30", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Investigation activities" },
                    { new Guid("aa31be47-35d6-40fb-a496-211d257c562c"), "N.81", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Services to buildings and landscape activities" },
                    { new Guid("9cd690a8-2a51-4667-8afc-d726d6bc02fb"), "N.79.1", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Travel agency and tour operator activities" },
                    { new Guid("aeafc4ac-1fc4-4953-beea-373ff32e56ad"), "N.81.1", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Combined facilities support activities" },
                    { new Guid("2949ac04-051b-45e6-8596-edb6df3e9c05"), "N.81.2", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Cleaning activities" },
                    { new Guid("f4395eca-f87d-4ebe-b6e7-7951e1b349d4"), "N.81.21", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "General cleaning of buildings" },
                    { new Guid("236a02bf-1815-45cd-87b3-75e9bb326d1a"), "N.81.22", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other building and industrial cleaning activities" },
                    { new Guid("d6205313-c329-4c69-920d-f5da11f420d0"), "N.81.29", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other cleaning activities" },
                    { new Guid("55147ed6-90ad-4911-9149-45f7e6873c36"), "N.81.3", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Landscape service activities" },
                    { new Guid("281ca7d4-b3f0-4bd9-940c-a12fd92a47af"), "N.81.30", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Landscape service activities" },
                    { new Guid("11e36494-1665-413f-b277-c93935b694b0"), "N.82", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Office administrative, office support and other business support activities" },
                    { new Guid("71a3e989-5bac-4a50-beb4-6f706bd872bc"), "N.82.1", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Office administrative and support activities" },
                    { new Guid("8738220e-e43e-42a1-a7c5-5e9bcb6b6dfb"), "N.82.11", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Combined office administrative service activities" },
                    { new Guid("860e0497-d246-448c-829f-ac86b4ee2470"), "N.82.19", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("aa5ca916-cf10-4c1b-b4d5-13c28241b2d5"), "N.82.2", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Activities of call centres" },
                    { new Guid("bb4a5420-ca72-4cd8-ad42-637bbf3450f8"), "N.82.20", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Activities of call centres" },
                    { new Guid("dd7aa711-296d-4754-87c6-aa2eee82740d"), "N.81.10", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Combined facilities support activities" },
                    { new Guid("9f6f19a9-6d26-4da7-a073-317000f59423"), "N.79", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("0711a426-095d-4be9-ac5e-010ba6b4df3c"), "N.78.30", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other human resources provision" },
                    { new Guid("615c43b7-abdb-4023-b738-dc8db1decb0f"), "N.78.3", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Other human resources provision" },
                    { new Guid("8f63f373-67ee-4474-a72b-c0b2761b9a77"), "M.74.9", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("acf2fc16-8f00-46f1-9322-bc406874a1ae"), "M.74.90", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("0f3b430f-8c36-4224-b398-4a487ad94650"), "M.75", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Veterinary activities" },
                    { new Guid("2720bf9c-7955-4e58-bfac-888063a0550c"), "M.75.0", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("967af7b2-dea6-4a7f-95bc-9164e3b865b4"), "M.75.00", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Veterinary activities" },
                    { new Guid("22e16aa8-90c2-4f84-8f67-cad76df9daa0"), "N.77", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Rental and leasing activities" },
                    { new Guid("dd2521ae-0a2d-452b-962c-61c9c84ec6cb"), "N.77.1", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of motor vehicles" },
                    { new Guid("765b3530-d116-43dd-ad8e-48e65b8c1464"), "N.77.11", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("8190c05d-83fa-47cf-b73e-12cea689159a"), "N.77.12", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of trucks" },
                    { new Guid("d0b13006-1ae7-4491-8791-1b07c88de36b"), "N.77.2", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of personal and household goods" },
                    { new Guid("2db2baeb-40b4-428f-907f-657e979d19b8"), "N.77.21", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("fa7e456f-9fc2-41b3-817f-5927fab4a2e9"), "N.77.22", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting of video tapes and disks" },
                    { new Guid("78734918-4a46-4c48-a2f3-d227cb4a3cb0"), "N.77.29", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of other personal and household goods" },
                    { new Guid("f41e5b0f-7ba6-4290-b19f-8432cd179519"), "N.77.3", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("3406e88e-896c-4e0f-8ec6-ede7f573dc39"), "N.77.31", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("1b800cd9-b310-4f77-86aa-ffbcfcdfdacb"), "N.77.32", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("14d15323-9c9c-41d1-8b2f-c432264b93e0"), "N.77.33", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("d3e1a525-e47a-4d51-b0e4-87f249c07923"), "N.77.34", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of water transport equipment" },
                    { new Guid("933e4263-c2a7-4d77-a2c5-e68e7453eb8d"), "N.77.35", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of air transport equipment" },
                    { new Guid("07d89c60-492d-4965-b18f-24bd421a28d8"), "N.77.39", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("4d482dcd-6c43-4b21-84eb-2155ac6c9c0d"), "N.77.4", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("3ad6689c-8dd7-4ef1-b3b1-7b30ccfc97f3"), "N.77.40", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("914823d2-59a5-4727-a107-49581d5cee91"), "N.78", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Employment activities" },
                    { new Guid("8d9904bd-b59f-4642-8dc5-51dde29b1dda"), "N.78.1", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Activities of employment placement agencies" },
                    { new Guid("98f0d20a-5592-4a80-b7bd-59403ed75976"), "N.78.10", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Activities of employment placement agencies" },
                    { new Guid("0911f522-1cd3-4ae5-924f-898b5d24a4af"), "N.78.2", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Temporary employment agency activities" },
                    { new Guid("808b93b5-dcf1-4774-a923-8382e11e087a"), "N.78.20", new Guid("076cf439-48f3-4c0d-aa5d-f46851f9eb7f"), "Temporary employment agency activities" },
                    { new Guid("bc425ca5-2cce-4fd3-ab18-3290021d3fa3"), "M.74.3", new Guid("6b9d7839-67de-4a4f-b5de-57440fa48fdd"), "Translation and interpretation activities" },
                    { new Guid("7eff08d1-2bf1-4a06-981e-288438a4f770"), "U.99.0", new Guid("93fb6644-f8fa-49fa-a07d-20b6393c1693"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("62626013-7ed3-4870-955b-759f63da80a5"), "F.43.21", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Electrical installation" },
                    { new Guid("512b6325-e7f4-42f5-ad47-be6fab1904d9"), "F.43.13", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Test drilling and boring" },
                    { new Guid("605b5de7-7765-4826-85fd-febf8959e354"), "C.14.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of articles of fur" },
                    { new Guid("0276010d-b4ac-4fd1-888a-4502a36f9518"), "C.14.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of articles of fur" },
                    { new Guid("b71e0692-71b1-48cf-9ff2-eaa8eb6eb85e"), "C.14.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("ea9e37e5-2646-4cd8-802e-97ac3f1f6506"), "C.14.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("3ad76b14-43f6-4f94-bde4-23b61b124d0b"), "C.14.39", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("87309f95-c47c-4683-9d3e-e42c758bd032"), "C.15", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of leather and related products" },
                    { new Guid("b31c87c9-3446-4968-98c6-a05ea0a60e22"), "C.15.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("b5af4f8c-ad68-4251-91ad-4aeb20f7769e"), "C.15.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("82a5ce5d-02e0-460d-9841-c2285ba25dee"), "C.15.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("cc22886b-6381-4ee3-acfe-3402b78a86e1"), "C.15.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of footwear" },
                    { new Guid("b6bcb1ee-bd94-4126-88bd-c8ea1a29437d"), "C.15.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of footwear" },
                    { new Guid("59aacfb6-532b-4644-8743-e0b74571667e"), "C.16", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("4c6c83dc-7cfd-4378-8f8d-59d3dfc86b10"), "C.14.19", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("01692638-18a7-447d-8740-2065a63e9131"), "C.16.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Sawmilling and planing of wood" },
                    { new Guid("86720fbb-9571-4d25-99df-26f1c689649a"), "C.16.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9361b58f-9274-48d4-8063-ba18aa3ae92f"), "C.16.21", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("27fe506f-73f2-4811-9f91-e7800decc543"), "C.16.22", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of assembled parquet floors" },
                    { new Guid("cd5ec68c-d851-4de0-b7d7-5f0c526ca001"), "C.16.23", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("3577afc7-b94d-494f-9a25-0af4c5cf36c1"), "C.16.24", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wooden containers" },
                    { new Guid("38da5acd-ee45-4bf1-8a6a-55aadf0cca6c"), "C.16.29", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("ba6814ac-4e0b-4531-a85d-5da70067c41e"), "C.17", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of paper and paper products" },
                    { new Guid("0de43f3f-0e9d-4320-9b10-24c2c559b0a5"), "C.17.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("6b0901f5-6725-4121-8c48-9a05118f626a"), "C.17.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of pulp" },
                    { new Guid("14b9fed1-b145-4fea-b964-c17de71622c0"), "C.17.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of paper and paperboard" },
                    { new Guid("894e03ad-08f4-4b22-ab65-95ddeb956ae2"), "C.17.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("3cd05a98-6d04-4221-acb9-948a78424104"), "C.17.21", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("d220247a-32ee-489b-95c7-c417525cbec1"), "C.16.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Sawmilling and planing of wood" },
                    { new Guid("c52368b4-0ecb-4811-b242-5921ca43ed53"), "C.14.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of underwear" },
                    { new Guid("4f379565-7310-4735-ac21-dc61557264ec"), "C.14.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other outerwear" },
                    { new Guid("80d48e8b-d132-48e2-9912-07c529eb48e9"), "C.14.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of workwear" },
                    { new Guid("727cf7a2-6ff6-40e1-9782-2319997e944b"), "C.11.02", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wine from grape" },
                    { new Guid("b77faf52-5dc2-49da-afd8-81aa5a503e48"), "C.11.03", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cider and other fruit wines" },
                    { new Guid("bbb2c564-5be2-4d39-8a67-1bf609d5751f"), "C.11.04", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("2237e4a9-36bd-42f2-8caf-cffc12329184"), "C.11.05", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of beer" },
                    { new Guid("ad063a47-97e5-4489-a6f0-49bf4b0e0d0b"), "C.11.06", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of malt" },
                    { new Guid("45d75bcc-b4ea-4e1e-b234-33a43cb1e20c"), "C.11.07", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("427e4334-f7fb-4e2c-b807-0d2456cea864"), "C.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tobacco products" },
                    { new Guid("93405deb-80e0-489f-83d1-d4325eacc64f"), "C.12.0", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tobacco products" },
                    { new Guid("c37bc5d5-85e0-49d0-99dc-35d0bb4f2314"), "C.12.00", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tobacco products" },
                    { new Guid("aa42510a-acc5-4c03-816d-ecf5bce21ade"), "C.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of textiles" },
                    { new Guid("02aab54e-a39a-4ac4-942d-267e376868e4"), "C.13.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Preparation and spinning of textile fibres" },
                    { new Guid("14fdbd19-0bc3-45c0-b23d-b82c5f6ee3b2"), "C.13.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Preparation and spinning of textile fibres" },
                    { new Guid("cae140b2-23af-43d7-bb4a-1c3a4d886814"), "C.13.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Weaving of textiles" },
                    { new Guid("d1326b43-678b-434e-a930-62aabc8a3bdb"), "C.13.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Weaving of textiles" },
                    { new Guid("1e7020d7-f01f-447a-8205-e55705b5a0e1"), "C.13.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Finishing of textiles" },
                    { new Guid("d73dfe75-579b-4d8f-a9d3-891cba363896"), "C.13.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Finishing of textiles" },
                    { new Guid("bc4c2a64-33d2-4475-a2e2-dcd6c5e7d52a"), "C.13.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other textiles" },
                    { new Guid("c6296125-85d5-4511-89f4-aa9bb43b638d"), "C.13.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("32c5c75d-d609-46c3-9303-b765c3299192"), "C.13.92", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("d06ab040-fd63-40e4-ba40-e79c7ea5d96d"), "C.13.93", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of carpets and rugs" },
                    { new Guid("e99458e9-f978-4503-a31c-354fd6d9f85f"), "C.13.94", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("1fd6b065-1105-4bea-a930-0bdd6550df35"), "C.13.95", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("de13d39f-36ad-460a-8641-a53a9c15b974"), "C.13.96", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("bbd6242d-6630-4878-9f81-c52da0fe870b"), "C.13.99", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other textiles n.e.c." },
                    { new Guid("34c025d5-b895-4c7e-b182-7252480f745a"), "C.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wearing apparel" },
                    { new Guid("79ed89b1-4326-4352-a992-b34daf3c2320"), "C.14.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("79b379a7-fa47-4b27-b064-e1ec24e22908"), "C.14.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("29856bbc-035e-4156-97ad-1e7fd674d55c"), "C.17.22", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("b45afd56-f874-4a02-8853-25b57e4a68a0"), "C.11.01", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("c55cb940-ba83-423e-84d9-bcd522324e92"), "C.17.23", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of paper stationery" },
                    { new Guid("abb4ea64-a83c-4771-8796-288498b20d5b"), "C.17.29", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("cb1404bc-1195-48e3-819b-b166ad4c85e6"), "C.20.52", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of glues" },
                    { new Guid("2f36dcab-f265-4869-b0f4-163b8444a843"), "C.20.53", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of essential oils" },
                    { new Guid("12b189f4-99b7-41b7-a859-b9055fdfb254"), "C.20.59", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("997cedb9-9254-4117-81ca-cc9c2f765da3"), "C.20.6", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of man-made fibres" },
                    { new Guid("bba98391-23c1-4a2a-89f9-4b89a05facf2"), "C.20.60", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of man-made fibres" },
                    { new Guid("9f4ba105-93c8-496a-a37f-71d92c7a9d54"), "C.21", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("36dfd36a-aaa2-4326-82c0-85226ca25e5b"), "C.21.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("35829d8b-5e4b-4348-8650-6c45283f65ea"), "C.21.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("9120ed8b-1440-4c83-9ef0-ea9f502eb0f5"), "C.21.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("3ab6b5f6-53d8-498b-a056-8a98600b2e37"), "C.21.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("b2120980-892e-4b9f-9bc6-782bf2e13dd9"), "C.22", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of rubber and plastic products" },
                    { new Guid("a7760fec-64ba-4779-923b-7624dbe9b1b6"), "C.22.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of rubber products" },
                    { new Guid("16e7922f-2b86-4944-973b-5804cc6375b4"), "C.20.51", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of explosives" },
                    { new Guid("34ba34d2-6686-4a39-ad94-6d7e85d91f6b"), "C.22.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("e6913bf3-d400-4d00-b3b8-69acd0a4cfd5"), "C.22.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of plastics products" },
                    { new Guid("a3ed5a17-8882-46ea-be27-687a02487432"), "C.22.21", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("7594ce2e-e3ea-413a-a84a-5e2a2bcc6bf1"), "C.22.22", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of plastic packing goods" },
                    { new Guid("e25dbf56-9257-42d9-bc08-84adc86953a2"), "C.22.23", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("78e1579c-0831-4672-9a22-5408121f01cc"), "C.22.29", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other plastic products" },
                    { new Guid("902d8ad5-3be8-4fa7-8a5b-666526112a8a"), "C.23", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("00f99846-f92b-4bc4-96df-d7b9405584b9"), "C.23.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of glass and glass products" },
                    { new Guid("700a11ed-98af-493d-a43b-1defb7f4f6d9"), "C.23.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of flat glass" },
                    { new Guid("7ef0ad08-e2b4-41de-8fc1-65d1fb0fd2cc"), "C.23.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Shaping and processing of flat glass" },
                    { new Guid("8516385a-ca49-4e85-b18f-8bcc2d246df6"), "C.23.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of hollow glass" },
                    { new Guid("1712d3ef-d5c1-4ac9-8ed1-2efee88d335d"), "C.23.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of glass fibres" },
                    { new Guid("327779b0-5b46-4295-810e-50440363596e"), "C.23.19", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("576c722d-0545-4fe2-bee8-03d957e6ccf3"), "C.22.19", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other rubber products" },
                    { new Guid("e04df070-3d58-4ce5-a9f1-dd01ab672e25"), "C.20.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other chemical products" },
                    { new Guid("db81d9ed-2db0-462b-84a0-eedd75dcc76f"), "C.20.42", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("13717e7c-4806-4c93-bde8-15367bf6718a"), "C.20.41", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("4d06842c-b45a-430d-b0ec-4a9ec97716d7"), "C.18", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Printing and reproduction of recorded media" },
                    { new Guid("7991bf7b-941c-41dd-9545-40fdaf087be7"), "C.18.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Printing and service activities related to printing" },
                    { new Guid("521ba63f-e5be-48e1-bac2-b40029ad81ef"), "C.18.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Printing of newspapers" },
                    { new Guid("208bd281-5740-41cb-808a-358399a0a5ef"), "C.18.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Other printing" },
                    { new Guid("4762fb83-7aad-47c5-9e5f-fe7fe602476e"), "C.18.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Pre-press and pre-media services" },
                    { new Guid("ce236f55-6f0d-40f3-8699-05e6a038e70e"), "C.18.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Binding and related services" },
                    { new Guid("e79457fe-b62e-4606-aa2a-67a354aac038"), "C.18.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Reproduction of recorded media" },
                    { new Guid("73a49efb-e1bc-4473-952b-da791b9499ea"), "C.18.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("9f96d629-5019-4865-ac0c-ad87f7231f3b"), "C.19", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("3e0d8689-c9c7-46f6-8d7d-094eb4ec30f3"), "C.19.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of coke oven products" },
                    { new Guid("952e9c3a-4493-4364-afc0-3f464b445fd3"), "C.19.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of coke oven products" },
                    { new Guid("a6e9c6b3-20b4-4c9c-ad6e-9be7479e9011"), "C.19.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of refined petroleum products" },
                    { new Guid("654457df-a522-4e03-9f59-f2166e78fbdc"), "C.19.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of refined petroleum products" },
                    { new Guid("702c224d-30ff-48ad-a7fe-5d9fa278315d"), "C.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of chemicals and chemical products" },
                    { new Guid("0222f2f9-7bb9-4222-9555-7e70b29cfbca"), "C.20.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("175f810c-caf8-4377-9b8c-fd9963b69566"), "C.20.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of industrial gases" },
                    { new Guid("b6589f19-320c-454e-9070-1be1bb72ff18"), "C.20.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of dyes and pigments" },
                    { new Guid("5c890521-ae55-4387-ba33-c3609f518831"), "C.20.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("06df9a76-abb6-40a9-8a74-bdeb6259ff53"), "C.20.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other organic basic chemicals" },
                    { new Guid("9ee694e3-1907-4c87-8a10-0d3831d338b4"), "C.20.15", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("ef48764c-1748-4c21-9cf1-13fcf2264360"), "C.20.16", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of plastics in primary forms" },
                    { new Guid("5dbffdfe-417a-4428-90fc-7a4c1533edc3"), "C.20.17", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("425edbd8-5d82-4b5d-a268-3a49f73f537a"), "C.20.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("9f3a5535-a2fe-41a7-a851-2d62f45f500a"), "C.20.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("42f4f8b0-71f4-4cec-9e08-a1d0c7247f78"), "C.20.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("a95cc6e2-e558-40fb-bf2d-ea1c68a6d0e3"), "C.20.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("e4896c47-b752-4437-a873-a4675d504f8d"), "C.20.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("1258e4f3-11c6-4118-834b-d231d78977d4"), "C.17.24", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wallpaper" },
                    { new Guid("92112b64-44f8-499b-b344-37dde5972cff"), "C.23.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of refractory products" },
                    { new Guid("9973275d-8854-434c-8bc4-03bd72cda253"), "C.11.0", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of beverages" },
                    { new Guid("6a0e4ef3-0020-4985-898c-b0a8387fd78c"), "C.10.92", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of prepared pet foods" },
                    { new Guid("36c72b14-5af7-42e5-b513-c6f83eedc390"), "A.01.6", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("876aaf31-e3a6-4893-ac0a-e59788fcd283"), "A.01.61", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Support activities for crop production" },
                    { new Guid("4131d994-e5fb-4903-b1b0-b1915d0b61de"), "A.01.62", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Support activities for animal production" },
                    { new Guid("c9ad4c37-cdf8-4922-ad74-7dc80d14abc8"), "A.01.63", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Post-harvest crop activities" },
                    { new Guid("8a842418-f972-4a02-bea7-a9626e6b8770"), "A.01.64", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Seed processing for propagation" },
                    { new Guid("07307157-863b-4cd8-aabd-992759a5bb23"), "A.01.7", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Hunting, trapping and related service activities" },
                    { new Guid("01f650aa-e33a-4995-9e0a-b9a0d3a09832"), "A.01.70", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Hunting, trapping and related service activities" },
                    { new Guid("c43592bd-774f-42ca-a428-cb9532d03c46"), "A.02", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Forestry and logging" },
                    { new Guid("c576aac8-abda-45e0-bee2-33928a2835c7"), "A.02.1", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Silviculture and other forestry activities" },
                    { new Guid("fe07329b-3539-4201-a574-31e660afe51d"), "A.02.10", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Silviculture and other forestry activities" },
                    { new Guid("d22a75f8-1d38-4ba9-aec9-7b9d1fd5e8f3"), "A.02.2", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Logging" },
                    { new Guid("a8c71aef-2b6e-46e1-a03c-6f5159db61ee"), "A.02.20", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Logging" },
                    { new Guid("c110cc23-3fad-4eed-9700-a359a912265b"), "A.01.50", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Mixed farming" },
                    { new Guid("5d960d8c-0a48-4759-a1e9-1c01b0441b8b"), "A.02.3", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Gathering of wild growing non-wood products" },
                    { new Guid("ca778975-ff27-4c4b-81ad-6876724f16ef"), "A.02.4", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Support services to forestry" },
                    { new Guid("11d27142-bfb7-4183-88a7-948e7f9a4e80"), "A.02.40", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Support services to forestry" },
                    { new Guid("e37de508-b10b-4cb6-b25d-666caa5e01f7"), "A.03", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Fishing and aquaculture" },
                    { new Guid("e8421f28-f584-460a-a16a-0b4d1e581ebf"), "A.03.1", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Fishing" },
                    { new Guid("1207bd46-c81e-4138-bdda-f3f359ee069a"), "A.03.11", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("246a9f83-d081-462e-9d60-4f2ecd5a5c03"), "A.03.12", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Freshwater fishing" },
                    { new Guid("d7bc78b5-2990-4193-bf97-ee555d956c4f"), "A.03.2", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Aquaculture" },
                    { new Guid("b5198dd6-bc0c-405b-afab-74115b3b2cb1"), "A.03.21", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Marine aquaculture" },
                    { new Guid("529af45c-abe8-4a9f-aaf2-fc6e9f240517"), "A.03.22", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Freshwater aquaculture" },
                    { new Guid("3c78f1bf-36ee-4f3a-8b33-08b089ab0dc4"), "B.05", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of coal and lignite" },
                    { new Guid("35d362d4-afb7-4f51-8429-98db00fde93b"), "B.05.1", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of hard coal" },
                    { new Guid("71f7451a-4b9d-4119-8d56-50b7e9c83806"), "B.05.10", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of hard coal" },
                    { new Guid("4503eb5f-efc2-4541-847e-75a986b698f1"), "A.02.30", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Gathering of wild growing non-wood products" },
                    { new Guid("de349ea7-a13a-48d5-97ca-8a3c9aba7123"), "A.01.5", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Mixed farming" },
                    { new Guid("283e033c-fa3a-41b2-8e14-131ed462c86e"), "A.01.49", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of other animals" },
                    { new Guid("f5de8b48-377d-40c1-86a4-2bcf283f1ec0"), "A.01.47", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of poultry" },
                    { new Guid("5076c17b-f3f1-45e1-ae97-c067f60a0f30"), "A.01.1", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of non-perennial crops" },
                    { new Guid("9a6d838b-ab93-4503-9ded-84dc06bb5b72"), "A.01.11", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("6bcbbe2d-b025-473e-8052-6e4b78f983d6"), "A.01.12", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of rice" },
                    { new Guid("e25be179-7956-4a1f-8f68-bd59c915818c"), "A.01.13", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("bcb72df0-12d5-4b63-bef4-9f23375bd9f8"), "A.01.14", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of sugar cane" },
                    { new Guid("5646c28b-3668-42c7-b883-46ce2a210120"), "A.01.15", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of tobacco" },
                    { new Guid("7f00a3a4-def6-492e-9a70-02e94fd64de6"), "A.01.16", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of fibre crops" },
                    { new Guid("2ccd1daf-5967-43df-9fb0-90518598b8e4"), "A.01.19", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of other non-perennial crops" },
                    { new Guid("9ab1ecb7-ae5a-4b3e-b33e-a646538ce613"), "A.01.2", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of perennial crops" },
                    { new Guid("1d6aeed0-a885-4834-bced-7cb229dfa931"), "A.01.21", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of grapes" },
                    { new Guid("06872cb3-a449-4ca6-b50f-c3ca331559d0"), "A.01.22", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of tropical and subtropical fruits" },
                    { new Guid("c62b4783-49b7-4ca0-9f60-55afb155a65d"), "A.01.23", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of citrus fruits" },
                    { new Guid("1066c34b-fe64-4790-8250-a6b311152e9b"), "A.01.24", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of pome fruits and stone fruits" },
                    { new Guid("abae6dc7-2430-47d1-9b2c-61ec32dae229"), "A.01.25", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("c715eba6-eab2-4c0d-8cd0-3043d9065a67"), "A.01.26", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of oleaginous fruits" },
                    { new Guid("2196fbea-fe57-426d-bedb-fa2032bae725"), "A.01.27", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of beverage crops" },
                    { new Guid("3c5203ed-67e4-4459-8f0f-53d6be976b45"), "A.01.28", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("e82fdeb2-93e1-4848-8633-f6ece6690dab"), "A.01.29", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Growing of other perennial crops" },
                    { new Guid("9d244a68-4f90-4b3e-9873-47f139a43208"), "A.01.3", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Plant propagation" },
                    { new Guid("b2e5b8ee-f4bb-410c-b27d-1d314cafea58"), "A.01.30", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Plant propagation" },
                    { new Guid("d376e339-d304-4ff9-a06d-d608860712c4"), "A.01.4", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Animal production" },
                    { new Guid("f5e27254-16a4-4ff4-af7f-32fb7e79a89a"), "A.01.41", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of dairy cattle" },
                    { new Guid("4a167d12-1a9e-4abe-8113-ffb6db39a626"), "A.01.42", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of other cattle and buffaloes" },
                    { new Guid("9afc6a2c-7293-470c-b6c5-b587fab76ff0"), "A.01.43", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of horses and other equines" },
                    { new Guid("a772ca6f-ea25-48c1-9854-5c369f871d73"), "A.01.44", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of camels and camelids" },
                    { new Guid("26715b8a-eb9e-41c9-8e0e-264d66cb9014"), "A.01.45", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of sheep and goats" },
                    { new Guid("89d4f7e3-4a1b-4fbd-b9e1-85b31602f103"), "A.01.46", new Guid("cc51ad28-1ea9-463f-a413-a42af1dafe5b"), "Raising of swine/pigs" },
                    { new Guid("5dc9493b-422e-49f1-8d53-f1de825348c2"), "B.05.2", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of lignite" },
                    { new Guid("49a9a61c-6731-4611-811c-c5fda83ba63b"), "C.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of beverages" },
                    { new Guid("33f770f2-e89b-4002-b65f-dee0761623a3"), "B.05.20", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of lignite" },
                    { new Guid("5a9ae30d-e665-4771-80fe-c8de9a2cb950"), "B.06.1", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b2c0813f-482f-44da-b55e-72eec2359ab8"), "C.10.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of potatoes" },
                    { new Guid("6c676a73-aee0-4371-a03e-c1bc47900ba0"), "C.10.32", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("c575d2be-f8ba-42d9-bfc2-884f6a7ae8e3"), "C.10.39", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("cce4acab-8fc9-4c9c-b532-f22bb875e4ad"), "C.10.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("a3057f7c-7318-4398-928c-836931ce78a1"), "C.10.41", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of oils and fats" },
                    { new Guid("0c0dcfc8-c9db-49c3-aa6e-c1de4ec71a64"), "C.10.42", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("c710462d-9f8a-46a9-bd13-115370240a67"), "C.10.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of dairy products" },
                    { new Guid("65da613b-0625-4a74-94f1-495169f72b38"), "C.10.51", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Operation of dairies and cheese making" },
                    { new Guid("cfac5a82-6377-4938-a477-a47169dc26c8"), "C.10.52", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ice cream" },
                    { new Guid("a7b10ffe-55fe-4161-830a-b9c2abd678d9"), "C.10.6", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("5fd305e1-4ac6-402b-b4cd-c9219eefeae6"), "C.10.61", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of grain mill products" },
                    { new Guid("12db4205-8f9a-444f-89dd-5ff4d39793e7"), "C.10.62", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of starches and starch products" },
                    { new Guid("d13232bc-e9a4-4ddd-a147-bb14c2765857"), "C.10.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("deefdac6-2854-44e1-9089-50e868cc5c3a"), "C.10.7", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("ddeec5b9-e338-4d08-8cf9-5a59e971df4b"), "C.10.72", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("6ff791ab-7b3a-4e38-81f5-2a8c4b7eab72"), "C.10.73", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("cbdbf518-6d53-4b2f-86e5-3a94aef7c493"), "C.10.8", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other food products" },
                    { new Guid("30fc37ab-eb35-42eb-8913-6892de7c7bb1"), "C.10.81", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of sugar" },
                    { new Guid("37c1284c-3424-4978-9bcf-c12cfb350103"), "C.10.82", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("84ddae3f-0087-4633-acf1-9ec88181540d"), "C.10.83", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing of tea and coffee" },
                    { new Guid("21f1d710-ad36-4302-8705-cdc83343b569"), "C.10.84", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of condiments and seasonings" },
                    { new Guid("ce4a944f-140a-4b46-ac37-f22414ba8069"), "C.10.85", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of prepared meals and dishes" },
                    { new Guid("8de1f1c1-8cc7-432a-afc2-7f7922ed664a"), "C.10.86", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("32ed3fb9-6537-476f-84a0-7d3bb9b64e04"), "C.10.89", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other food products n.e.c." },
                    { new Guid("4002537b-6dfe-4bc2-b4c5-04b6cce83950"), "C.10.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of prepared animal feeds" },
                    { new Guid("dafba8c2-68a4-492d-bceb-68ea42d13fcd"), "C.10.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("de748aa3-c3e9-4f6d-b120-db8bac5ffcf0"), "C.10.71", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("c432a4e4-41f0-47c5-9c85-819202e55082"), "C.10.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("accfe4a6-b306-4513-bb76-7cc88c4e7405"), "C.10.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("10a111bb-d63a-4935-8f38-d2b8b1e8bbd4"), "C.10.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Production of meat and poultry meat products" },
                    { new Guid("fa7f0930-7130-4f82-ae51-765170e0f3a3"), "B.06.10", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of crude petroleum" },
                    { new Guid("881ca6e3-b268-480e-9b70-0bedccd7d61b"), "B.06.2", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of natural gas" },
                    { new Guid("2a133802-672a-40dd-9f30-1c936e73249a"), "B.06.20", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of natural gas" },
                    { new Guid("8d268ecd-2573-465b-84a2-d6b09acba49b"), "B.07", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of metal ores" },
                    { new Guid("598547cd-2a8e-4d4e-9fcc-f8b0327ce72f"), "B.07.1", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of iron ores" },
                    { new Guid("9f6f1ff7-2060-49fe-9f84-e8b8c73ee560"), "B.07.10", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of iron ores" },
                    { new Guid("a6328c28-5cbc-45d5-918e-92927c420e46"), "B.07.2", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of non-ferrous metal ores" },
                    { new Guid("a55b5bc9-4ce6-44b7-88a9-d14f1d9b6bde"), "B.07.21", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of uranium and thorium ores" },
                    { new Guid("4c9c37e9-cfb4-43f0-9536-2114db3401ac"), "B.07.29", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of other non-ferrous metal ores" },
                    { new Guid("df32c3cb-051e-4fa6-925e-11e22d330c9f"), "B.08", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Other mining and quarrying" },
                    { new Guid("c9f4265d-be6d-477f-8b34-0f945df148a3"), "B.08.1", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Quarrying of stone, sand and clay" },
                    { new Guid("430921b3-3141-4e2c-897c-5b62bb6823d6"), "B.08.11", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("393242e0-2328-46fc-b714-aa36c89bac4f"), "B.08.12", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("2bb3c1db-cbd8-40c3-aa3e-b7810cb0c260"), "B.08.9", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining and quarrying n.e.c." },
                    { new Guid("fbd597b7-ab8e-4d46-b693-c5d9686a1e7c"), "B.08.91", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("6c6d1c33-e2ee-447b-9712-a9a517907012"), "B.08.92", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of peat" },
                    { new Guid("a2975e23-dc21-428d-8edc-d6b397f5e5cb"), "B.08.93", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of salt" },
                    { new Guid("7c79e3da-8657-4f89-ab37-fefca3912a9d"), "B.08.99", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Other mining and quarrying n.e.c." },
                    { new Guid("4999979d-723c-46ea-a6c1-7c5ac7a07eb3"), "B.09", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Mining support service activities" },
                    { new Guid("c39aedd9-ed6f-4bf6-9e82-6f14061f37ee"), "B.09.1", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("4b3125be-d2a0-4b85-97d7-ad04618349de"), "B.09.10", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("002b2741-c6b3-492a-93d3-87fb7b907e18"), "B.09.9", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Support activities for other mining and quarrying" },
                    { new Guid("cd67595a-8193-4ffb-b097-e75c1cab5cd7"), "B.09.90", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Support activities for other mining and quarrying" },
                    { new Guid("5f25095f-fc26-4f6e-9513-94bb4af73adf"), "C.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of food products" },
                    { new Guid("97c622d8-f6f0-41e9-909a-4d9032d265d2"), "C.10.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("d2a17690-c5d7-4ef2-be6c-e0c695da3642"), "C.10.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of meat" },
                    { new Guid("a43082e9-bed3-407a-80e4-f3f2801e923e"), "C.10.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing and preserving of poultry meat" },
                    { new Guid("16f894b8-cd88-44c3-97b7-26b1ea6cdc4e"), "B.06", new Guid("ef47b3b1-cda4-4049-9245-40417236913a"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("c0712aa8-10a7-4fa0-ad71-5f9f8b16045c"), "F.43.2", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("0b65bd16-f119-4bb8-9a97-38b70eb0f454"), "C.23.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of refractory products" },
                    { new Guid("399c7316-62e1-42e2-ac6e-a053e0ccb8e0"), "C.23.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("505b6d77-d8b8-44f4-b785-028af5fc8845"), "C.30.92", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("d6df9fd0-2637-4e05-8c76-e302ebc6c669"), "C.30.99", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("441df907-5445-4429-9570-1c69aeadc50e"), "C.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of furniture" },
                    { new Guid("7fd1d42b-63f6-42c3-9772-f869f031d4bf"), "C.31.0", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of furniture" },
                    { new Guid("a3f6b4d0-a979-4933-9277-21b7bf889321"), "C.31.01", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of office and shop furniture" },
                    { new Guid("82f56838-1ec1-4dd8-b4b7-5e2db8b13424"), "C.31.02", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of kitchen furniture" },
                    { new Guid("7e16f04a-ecb2-47a0-b2de-b3e41f0a11d0"), "C.31.03", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of mattresses" },
                    { new Guid("d3ace7fc-9d03-44f4-9875-2e3628b795c9"), "C.31.09", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other furniture" },
                    { new Guid("1545c462-f601-4b8c-8e3e-fc85851052b8"), "C.32", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Other manufacturing" },
                    { new Guid("c3488750-1074-4004-940b-9b024f83988d"), "C.32.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("b688174a-aae9-442c-badf-89e00c5efab1"), "C.32.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Striking of coins" },
                    { new Guid("73eba2e4-e169-4dee-9752-4fa46958d52b"), "C.32.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of jewellery and related articles" },
                    { new Guid("fdc1e8e5-b61d-44b2-9d63-52a89e6c90a0"), "C.30.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of motorcycles" },
                    { new Guid("6fb25739-bfbf-4261-a865-20942dc6807c"), "C.32.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("5d488211-2fe4-4f90-a99c-871eb7316da1"), "C.32.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of musical instruments" },
                    { new Guid("4623b6ea-92e1-49bd-b5e7-d07b5f065741"), "C.32.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of sports goods" },
                    { new Guid("5f29c68f-bd2a-4d19-aba4-dd76d74ecb3d"), "C.32.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of sports goods" },
                    { new Guid("422b8eba-d8a2-46ab-a467-41916009af54"), "C.32.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of games and toys" },
                    { new Guid("c6c51076-2262-43fb-8756-cffe154db8bf"), "C.32.40", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of games and toys" },
                    { new Guid("1fa71d62-cec6-4979-9712-dc84339fa597"), "C.32.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("0103462c-e14a-40d4-9b06-888a2ef9785d"), "C.32.50", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("65755af3-cbed-479b-b56f-72686cb4c4ec"), "C.32.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacturing n.e.c." },
                    { new Guid("a276a821-9c4f-429b-af9d-1ddc6521e8fd"), "C.32.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b411ff67-7593-437d-bf25-5ac4a5732664"), "C.32.99", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Other manufacturing n.e.c." },
                    { new Guid("39609d9d-9973-4c43-8165-6486f591c815"), "C.33", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair and installation of machinery and equipment" },
                    { new Guid("79d05bcb-f734-4db3-9b54-052d4fe82664"), "C.33.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("9e65ff7b-9aaa-4dff-8cce-368f7395a410"), "C.32.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of musical instruments" },
                    { new Guid("ebe4e7a2-f52e-4075-8710-2af0369c9ba4"), "C.30.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("52d7444a-0dea-4d9e-95dd-7116e47cbdca"), "C.30.40", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of military fighting vehicles" },
                    { new Guid("8a45f42b-db3e-4e7e-aeda-0b95eb39f702"), "C.30.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of military fighting vehicles" },
                    { new Guid("a8a20389-84a3-4918-a331-fd7d5257fb08"), "C.28.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("77c846f1-68f4-4630-bec8-8f3ac8fe03bd"), "C.28.41", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of metal forming machinery" },
                    { new Guid("8f4dcde8-172a-4823-946c-51464d9ef274"), "C.28.49", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other machine tools" },
                    { new Guid("8b33260e-801c-4473-8969-635149b87cd3"), "C.28.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other special-purpose machinery" },
                    { new Guid("a4fc5c41-a490-4cc5-80c7-e410f4311400"), "C.28.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of machinery for metallurgy" },
                    { new Guid("45ce4358-f86f-4ac7-b4f8-2e07d7c69cf2"), "C.28.92", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("f5dfa586-65b8-4d0f-86b3-f3f4828c55e7"), "C.28.93", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("aa8fc171-4d26-495a-a342-85a485883b3a"), "C.28.94", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("2ea07466-3550-4b2c-949f-bdcb858e62b1"), "C.28.95", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("0e155ac2-1d58-4819-8e3f-de344aecc73b"), "C.28.96", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("20f1b8ce-926b-4aa5-9d83-aae7e76be39c"), "C.28.99", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("619ca14f-484f-47b0-9246-e75979b7ab48"), "C.29", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("7b63b2e3-6b10-4838-89ab-3d35e180f443"), "C.29.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of motor vehicles" },
                    { new Guid("cf55e810-3c26-4790-be28-16634556f047"), "C.29.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of motor vehicles" },
                    { new Guid("2ee640a0-a87c-4649-a38f-c3cc326a0d26"), "C.29.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("05c78093-fb94-4295-a834-1a05b98eefcf"), "C.29.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("9afffe58-6155-4dec-8643-49de3ac5184a"), "C.29.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("a9b10d6a-e4e6-40ba-b005-fa6d391d2aee"), "C.29.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("d18626be-8211-494e-ac47-c95b968106e5"), "C.29.32", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("277458a4-b5b4-495c-b20f-82a136b76f4a"), "C.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other transport equipment" },
                    { new Guid("5dcbf7f9-57e4-4862-92c4-0c4b947ce25c"), "C.30.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Building of ships and boats" },
                    { new Guid("a6dfcf1e-62a6-469c-8538-9fb74203486f"), "C.30.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Building of ships and floating structures" },
                    { new Guid("ccdefb17-90dd-4f47-a2b4-ea377fe168fb"), "C.30.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Building of pleasure and sporting boats" },
                    { new Guid("290b7241-1748-4c92-aa29-942315fe828c"), "C.30.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("dfd8a816-800e-4206-8b0b-35fa9a946ac1"), "C.30.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("2dfb107a-6d1c-480c-ad00-83a6d131f657"), "C.30.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("cf817818-71f6-4052-b921-6efa5a97eead"), "C.30.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("f7a6a4fd-d99e-4f92-b4da-675d0512b7f7"), "C.33.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair of fabricated metal products" },
                    { new Guid("956ec6bb-8fc6-4a91-941c-3ab512b1896b"), "C.28.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("84034f7c-caca-4c10-8111-be8d460823ae"), "C.33.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair of machinery" },
                    { new Guid("ac38b3ef-3674-4ddc-b2ae-1fcadcd3795f"), "C.33.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair of electrical equipment" },
                    { new Guid("35f58bdc-5c47-42ba-a785-d25b0d989a9c"), "E.38.3", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Materials recovery" },
                    { new Guid("c8c039f9-a399-47e3-a15d-a29c6192b44e"), "E.38.31", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Dismantling of wrecks" },
                    { new Guid("2d6839de-30b0-4ba8-a56c-5bee072dca14"), "E.38.32", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Recovery of sorted materials" },
                    { new Guid("1e6b6544-7b5a-4f03-a0e9-299b2df51b08"), "E.39", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3bc2d902-25a7-4d3d-acbd-a20c3199b293"), "E.39.0", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Remediation activities and other waste management services" },
                    { new Guid("97aa02bc-2b71-4ccc-97c1-8049bfaa0694"), "E.39.00", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Remediation activities and other waste management services" },
                    { new Guid("1c3367a8-39cc-473d-bbb2-9bb4ef659ea1"), "F.41", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of buildings" },
                    { new Guid("b3dd7b64-3ea2-4221-9ec2-f8eaa72ef491"), "F.41.1", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Development of building projects" },
                    { new Guid("0ea33f69-7393-4850-9e62-c9b431a5b73d"), "F.41.10", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Development of building projects" },
                    { new Guid("0c45d77d-d517-4f96-b401-37cce5d56772"), "F.41.2", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of residential and non-residential buildings" },
                    { new Guid("032fa418-22fd-443f-93c8-bb72089454c3"), "F.41.20", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of residential and non-residential buildings" },
                    { new Guid("154a50ed-0bcf-4efc-a195-2f88c32b6212"), "F.42", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Civil engineering" },
                    { new Guid("084a48d4-978a-4374-8645-f33b54212f0a"), "E.38.22", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Treatment and disposal of hazardous waste" },
                    { new Guid("a76486b3-db24-4418-8973-f0e773b0edfb"), "F.42.1", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of roads and railways" },
                    { new Guid("0aae85e4-93b0-4524-afba-74b1ccf54ba1"), "F.42.12", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of railways and underground railways" },
                    { new Guid("dd859d0b-38cd-41c2-968a-bf3a2c50e06a"), "F.42.13", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of bridges and tunnels" },
                    { new Guid("aba53c87-cff7-4774-9187-aa35e36fb9c1"), "F.42.2", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of utility projects" },
                    { new Guid("37c4937d-ff72-46a0-8ad1-6b02d8e722c8"), "F.42.21", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of utility projects for fluids" },
                    { new Guid("3cec9f32-7619-44f3-8640-c6b96184a915"), "F.42.22", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("a4300e53-46b3-4bea-9d11-96feafec1eea"), "F.42.9", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of other civil engineering projects" },
                    { new Guid("1fd22ce4-573b-4199-aae5-9031dfb3d909"), "F.42.91", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of water projects" },
                    { new Guid("96fce0ae-0743-40be-a9f2-900c72b84786"), "F.42.99", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("82c76410-37e5-437e-a6ff-79383c913bf9"), "F.43", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Specialised construction activities" },
                    { new Guid("b91c5823-11e0-410c-a817-41e5685ec163"), "F.43.1", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Demolition and site preparation" },
                    { new Guid("d86f0e6a-4d77-40ce-ad4a-ba105ac43da4"), "F.43.11", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Demolition" },
                    { new Guid("e2db60b8-ac77-4a6e-9b25-7dc42ed476c0"), "F.43.12", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Site preparation" },
                    { new Guid("5539a4f6-158b-43be-a0cc-2beeebd5f6f4"), "F.42.11", new Guid("8eb8c252-69c7-4644-970c-21b5bf1fa459"), "Construction of roads and motorways" },
                    { new Guid("45892d7c-77f3-4189-a48d-671f15276e4d"), "E.38.21", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("be6e2fa5-3fc5-499e-b0a8-f7bfdaa04cdd"), "E.38.2", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Waste treatment and disposal" },
                    { new Guid("32bc08fe-c119-4e93-809a-f48401a53e64"), "E.38.12", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Collection of hazardous waste" },
                    { new Guid("52da8503-513e-4e98-8a0e-64c9240126f9"), "C.33.15", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair and maintenance of ships and boats" },
                    { new Guid("5ddd4a20-7746-4090-8e9f-054bd2fc98b3"), "C.33.16", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("390b133d-3ce8-4a39-a55f-37e55b5a2584"), "C.33.17", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair and maintenance of other transport equipment" },
                    { new Guid("55da7f9e-0cc9-49bf-885a-2b8bbe446adc"), "C.33.19", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair of other equipment" },
                    { new Guid("614df7db-6819-46aa-9ccd-ff06865dcc39"), "C.33.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Installation of industrial machinery and equipment" },
                    { new Guid("8b9f5620-2581-44bd-8509-98c47f5a14c7"), "C.33.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Installation of industrial machinery and equipment" },
                    { new Guid("c8a8d956-d3e5-47ef-a8d9-fed442ca7ed4"), "D.35", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("d1ae4f5e-60bf-4dfd-9649-eb4539c9003c"), "D.35.1", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Electric power generation, transmission and distribution" },
                    { new Guid("dff01689-ed36-455c-b566-0163f828603c"), "D.35.11", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Production of electricity" },
                    { new Guid("fd97cbad-7917-4b73-837a-55bdbb5f8ac1"), "D.35.12", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Transmission of electricity" },
                    { new Guid("9638278d-1857-44b1-bef6-494c0b16683f"), "D.35.13", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Distribution of electricity" },
                    { new Guid("5532d774-1091-4127-a94d-f79fc0415db9"), "D.35.14", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Trade of electricity" },
                    { new Guid("2d4319f9-0f7e-4eeb-9d28-a54395330fec"), "D.35.2", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("24bb1db3-37db-4c19-9a73-244158238fcb"), "D.35.21", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Manufacture of gas" },
                    { new Guid("1e0e3f0c-30cc-4eba-8c5d-0200631a1885"), "D.35.22", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Distribution of gaseous fuels through mains" },
                    { new Guid("3416a998-a065-46b6-82d9-380cce3f1cde"), "D.35.23", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("cea52af8-d4e4-499c-b5b0-2d148e4842bd"), "D.35.3", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Steam and air conditioning supply" },
                    { new Guid("b1e0026c-4510-47e3-93b1-c966824ad268"), "D.35.30", new Guid("11cdcc9b-d247-476f-932f-49a1cd3a09b1"), "Steam and air conditioning supply" },
                    { new Guid("5ab53c49-ea97-4312-be40-010ff548cf33"), "E.36", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Water collection, treatment and supply" },
                    { new Guid("824aebcd-4b7b-4dac-afbf-73030a6c0494"), "E.36.0", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Water collection, treatment and supply" },
                    { new Guid("fb3928c2-2fc1-4033-a262-ddc98d20b731"), "E.36.00", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Water collection, treatment and supply" },
                    { new Guid("764ae146-938b-4039-b3a9-a2c1f58e90da"), "E.37", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Sewerage" },
                    { new Guid("389ae8a2-aaee-48ac-8530-acb59fc389a2"), "E.37.0", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Sewerage" },
                    { new Guid("41e14e9f-be09-4cd5-953c-52a2cc985381"), "E.37.00", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Sewerage" },
                    { new Guid("e55ad0d2-1f72-4bda-9531-a8c661fd34ec"), "E.38", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("b2b3da15-c945-4c0f-a61b-7c0844673c85"), "E.38.1", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Waste collection" },
                    { new Guid("2f7b8d7e-a929-4140-bcd6-d3732960fe27"), "E.38.11", new Guid("68667e77-d160-4285-ab99-9930b5506350"), "Collection of non-hazardous waste" },
                    { new Guid("9c567878-4435-4f32-be59-bc69a5180826"), "C.33.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Repair of electronic and optical equipment" },
                    { new Guid("a16cf0de-4a48-453a-a855-51f4d74a51c8"), "C.23.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of clay building materials" },
                    { new Guid("35bfde01-69de-4854-8215-cb6ac8853074"), "C.28.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("a8b17e54-b278-4592-ad4e-d18968f6a1f4"), "C.28.25", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("0042c49e-4b6c-4d89-892b-502c239cf821"), "C.24.34", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Cold drawing of wire" },
                    { new Guid("74b0a3ce-950f-4813-9da4-e1880e33a287"), "C.24.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("0df30d08-db6f-4383-a318-86866e717395"), "C.24.41", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Precious metals production" },
                    { new Guid("33e62ddb-2ab1-4f7e-b05d-5fbfbd219018"), "C.24.42", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Aluminium production" },
                    { new Guid("143840ef-5ae3-4c87-8366-ebc44c27fec3"), "C.24.43", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Lead, zinc and tin production" },
                    { new Guid("9e6e0d8d-ff3f-4b02-b56e-54cd1af8363f"), "C.24.44", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Copper production" },
                    { new Guid("5dc40e0b-3775-4686-8891-391c02e5ba4c"), "C.24.45", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Other non-ferrous metal production" },
                    { new Guid("f75d54fd-0aa2-49ff-9f40-e09f6f51be73"), "C.24.46", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Processing of nuclear fuel" },
                    { new Guid("4ae4ed98-8ea2-45c4-ae97-e36852a690fd"), "C.24.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Casting of metals" },
                    { new Guid("e0f213ca-7035-4fd8-9d25-08d6c505dcd7"), "C.24.51", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Casting of iron" },
                    { new Guid("de49d2f6-8673-49c2-9895-d4a26797ff12"), "C.24.52", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Casting of steel" },
                    { new Guid("5c006e28-d26a-4dbb-af95-b743de5834a2"), "C.24.53", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Casting of light metals" },
                    { new Guid("5a4897ac-a62c-4b45-adc3-e64f1b305b0d"), "C.24.33", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Cold forming or folding" },
                    { new Guid("e769dda0-576e-47ee-a728-f0a5b06bb960"), "C.24.54", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Casting of other non-ferrous metals" },
                    { new Guid("dde78b9a-a847-47f6-ae03-21f5ee5146ee"), "C.25.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of structural metal products" },
                    { new Guid("5f3ac225-5086-440a-87bc-d10f91e4bd6c"), "C.25.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("9e9d916d-7018-4c78-9c1c-fafbc7fc4ca6"), "C.25.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of doors and windows of metal" },
                    { new Guid("4d35fd23-1a41-4846-acb9-ee5b9f70f59b"), "C.25.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("0abd428b-d00c-4d02-aa34-eaa8b629018d"), "C.25.21", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("3ad2fa2a-e5e5-402e-9508-047d27ba5e95"), "C.25.29", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("54e19ae6-89fb-45c7-861b-193e898331f9"), "C.25.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("0cbed877-588c-4a83-9bc7-bab73ced1cc2"), "C.25.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("6e3a8a4c-1b72-4cf6-849d-8bc667b346a9"), "C.25.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of weapons and ammunition" },
                    { new Guid("40ad1f8f-b354-42cb-9d23-f6bb0abb6d95"), "C.25.40", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of weapons and ammunition" },
                    { new Guid("4f18a044-69b2-47be-908f-2449cb47e158"), "C.25.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("a08edca6-3e6c-4ebc-8352-14ddbd244ea1"), "C.25.50", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("2b8e37b3-93c5-4c67-a47c-c062f6b42b68"), "C.25", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("45750b5c-7098-4954-bc4e-c45ceb29b99f"), "C.24.32", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Cold rolling of narrow strip" },
                    { new Guid("4b6c9b00-7f46-4bff-8df4-6ee05c82ae2d"), "C.24.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Cold drawing of bars" },
                    { new Guid("627448ab-4fe0-4cb1-969c-24e6c18669fc"), "C.24.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other products of first processing of steel" },
                    { new Guid("9388a5eb-f2ba-4613-b508-59caa261667f"), "C.23.32", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("0869b852-989a-4c4d-b0a0-622708b6231b"), "C.23.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("3a444873-4562-40ba-b81d-cf79c13f6ed8"), "C.23.41", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("229824e9-53c0-493c-a52d-8fc9d7aa7893"), "C.23.42", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("a16fe7e2-e540-4c59-b46c-21952a5dc864"), "C.23.43", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("f511807a-7f0a-4dcf-bef1-aed3e4e6f63c"), "C.23.44", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other technical ceramic products" },
                    { new Guid("f5d5e9ec-c5ac-4bed-9036-d99ea80cef5c"), "C.23.49", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other ceramic products" },
                    { new Guid("c4cec8ad-100a-4346-9e18-dd574ae45ab4"), "C.23.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cement, lime and plaster" },
                    { new Guid("dad12330-71ae-4d4e-b8dd-bcf296bf59b2"), "C.23.51", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cement" },
                    { new Guid("7948060b-f897-4bfb-adff-d4d7c63076cf"), "C.23.52", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of lime and plaster" },
                    { new Guid("8602e1a5-bfe5-4683-b09b-390325d0a858"), "C.23.6", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("692e71bc-d897-4b3b-bccd-6ab9e747d43f"), "C.23.61", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("dd9b7b02-5720-45e3-8932-bc550d12c0c9"), "C.23.62", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("21c19f76-0464-4c45-870a-72229b928919"), "C.23.63", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ready-mixed concrete" },
                    { new Guid("de74ece0-a64b-4d54-a28a-855792c7133c"), "C.23.64", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of mortars" },
                    { new Guid("87299919-2bd4-43a2-903d-07acc889c64a"), "C.23.65", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fibre cement" },
                    { new Guid("dfb7cb6e-cef4-42aa-afe6-2e8d4eedf729"), "C.23.69", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("198a1819-908e-49cf-a776-6f7e8ac9c728"), "C.23.7", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Cutting, shaping and finishing of stone" },
                    { new Guid("db09b5bd-da26-4894-aead-b8fba62d1656"), "C.23.70", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Cutting, shaping and finishing of stone" },
                    { new Guid("7a813a53-f51c-4001-aa4a-5311e286f992"), "C.23.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("52696c31-dc32-480a-9e3f-0c1e39d75944"), "C.23.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Production of abrasive products" },
                    { new Guid("9309ea92-4c30-41a9-9e51-6e085d9d50e7"), "C.23.99", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("013a7233-9bff-4e4a-8dd4-924382627631"), "C.24", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic metals" },
                    { new Guid("456258fe-6755-48a3-a057-66e57e2eb593"), "C.24.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("12f6e549-6353-4bec-9d50-11fd9944a2c7"), "C.24.10", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("5e05c8cb-d7f6-4f01-a605-df1d879ddfb4"), "C.24.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("d4b0b88e-83f9-4010-bc1a-d366da3d9a7d"), "C.24.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("d0bb5454-ba00-45c0-91f7-053648781177"), "C.25.6", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Treatment and coating of metals; machining" },
                    { new Guid("41bd9a11-c116-487a-9ea1-95e6e39fbcdb"), "C.28.29", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("d0f0ffed-82d0-4b7c-95f0-a0dbda684f53"), "C.25.61", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Treatment and coating of metals" },
                    { new Guid("742c6184-d3fd-4c7b-979e-e3ce110ea63e"), "C.25.7", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("edff110a-4803-495c-9128-96cb90de95e0"), "C.27.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("4d6a54e6-1527-4876-8d4f-9adf4fc47fc5"), "C.27.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of batteries and accumulators" },
                    { new Guid("b35786f1-bb58-4dc9-9ca8-8f1e6a59a6f1"), "C.27.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of batteries and accumulators" },
                    { new Guid("61d502ca-87bd-430b-908f-a47f25c7f3de"), "C.27.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wiring and wiring devices" },
                    { new Guid("577a1b04-00c8-4607-bd37-76331b1607bc"), "C.27.31", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fibre optic cables" },
                    { new Guid("a47a828a-8cdb-4d8c-ac73-7bf514b829f6"), "C.27.32", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("6f876471-f9e3-4d5c-bd0a-a44f4fda606f"), "C.27.33", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wiring devices" },
                    { new Guid("1bff68e7-c074-4e24-95b7-d4c5e12392f6"), "C.27.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1da4a3ac-3a68-496d-9378-28d458ef420b"), "C.27.40", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electric lighting equipment" },
                    { new Guid("04a7eb69-efaf-4ed8-9c34-153182392732"), "C.27.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of domestic appliances" },
                    { new Guid("af11f646-b61c-4fbf-9312-bf21dae58467"), "C.27.51", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electric domestic appliances" },
                    { new Guid("790650a9-5ed5-4b5a-a2a3-dd0f17264cd7"), "C.27.52", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("ca1f60eb-0f6b-4f04-9895-4a39b961fb81"), "C.27.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("3a8b1c0f-4ce3-42c7-b8f2-06553522a5fb"), "C.27.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other electrical equipment" },
                    { new Guid("e07cb891-3f8a-4591-9c66-c0e8178116f9"), "C.28", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("f274ba96-5f76-4c0e-bd47-2e21ca4da211"), "C.28.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of general-purpose machinery" },
                    { new Guid("c2481aad-2852-4109-9d41-fff024e42760"), "C.28.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("5a9d4284-1f44-40e4-b3be-8448cf38112e"), "C.28.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fluid power equipment" },
                    { new Guid("13955ae8-ee25-4f28-9b12-d1821e17f1ff"), "C.28.13", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other pumps and compressors" },
                    { new Guid("9e521210-61e0-4616-9c09-db4b2cfb9691"), "C.28.14", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other taps and valves" },
                    { new Guid("1ce4d990-9a1e-4134-a707-80441dbd2c35"), "C.28.15", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("09bcb069-d20e-41bc-b8e0-e2029265be15"), "C.28.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other general-purpose machinery" },
                    { new Guid("8b40eb0e-e67e-4e54-ba97-19f11c24c8b2"), "C.28.21", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("4e4ba23e-b130-4558-a4b2-7db2a782d25c"), "C.28.22", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of lifting and handling equipment" },
                    { new Guid("f9355efc-549c-451e-8839-09fd55261b33"), "C.28.23", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("afb7f479-99cd-4663-91ed-f3ba947dab63"), "C.28.24", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of power-driven hand tools" },
                    { new Guid("b8f3cc25-4fb9-4283-9660-a725b1d4b3f2"), "C.27.90", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other electrical equipment" },
                    { new Guid("0c43dabb-3aa7-4cbc-9123-4bdc8fc34430"), "C.27.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("e2f5b79f-98ff-4586-9906-c9768f2e0ea6"), "C.27", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electrical equipment" },
                    { new Guid("b69fdf8c-2d19-46ab-b112-9c9a42c1ebeb"), "C.26.80", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of magnetic and optical media" },
                    { new Guid("93c16ae9-3a7e-4dcd-bf7d-a58a54ed0e02"), "C.25.71", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of cutlery" },
                    { new Guid("99215744-3608-43be-9139-eeb213554d2c"), "C.25.72", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of locks and hinges" },
                    { new Guid("228b562e-e189-4a49-b75d-8e018a965f7b"), "C.25.73", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of tools" },
                    { new Guid("a0fdde52-6763-4208-a7a2-a51ac884dd66"), "C.25.9", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other fabricated metal products" },
                    { new Guid("d9a7037b-7913-40c8-881c-01371e41dfbc"), "C.25.91", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of steel drums and similar containers" },
                    { new Guid("5908e092-4384-4bcf-b612-846dcbeca3d1"), "C.25.92", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of light metal packaging" },
                    { new Guid("3ae8a876-b729-457e-adad-d190270a0e1f"), "C.25.93", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of wire products, chain and springs" },
                    { new Guid("05532824-a0fc-4a7d-a7d4-12e448440d52"), "C.25.94", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("a72c1130-f924-4650-bc1d-115a6b80f3de"), "C.25.99", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("972aceff-7d6f-4709-98d9-1927aef457d9"), "C.26", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("8b92d71a-e1f3-4906-a18a-911abbc3d2f0"), "C.26.1", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electronic components and boards" },
                    { new Guid("fc86d5f8-6618-4624-bdac-5226d0ecc96a"), "C.26.11", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of electronic components" },
                    { new Guid("4d20302e-d153-4c82-b542-f1fae29029ca"), "C.26.12", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of loaded electronic boards" },
                    { new Guid("fa136137-3532-4d0b-a094-388c890a997f"), "C.26.2", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("c27e6bc8-3475-43e2-8770-d288a53168c6"), "C.26.20", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("f04178ac-e1ca-4571-89d4-82595c0e14a6"), "C.26.3", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of communication equipment" },
                    { new Guid("bd3068fa-718a-4938-8b15-c768d1169c9a"), "C.26.30", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of communication equipment" },
                    { new Guid("b9fc2ac4-2a7e-4f81-921f-5b5776b52607"), "C.26.4", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of consumer electronics" },
                    { new Guid("9d605b32-971e-4c8c-adca-40bdae8a4112"), "C.26.40", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of consumer electronics" },
                    { new Guid("6aa910d2-c500-4b3b-88a4-554218602ce5"), "C.26.5", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2f73ba5f-7062-49a6-98d8-07d36a1b0110"), "C.26.51", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("0da1d226-251c-4a9c-b2a2-11b58434a3d2"), "C.26.52", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of watches and clocks" },
                    { new Guid("55d44e0e-82b2-4661-83f1-baeaafe685b0"), "C.26.6", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("e102df17-47bd-4b7a-a120-e86e284b974e"), "C.26.60", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("072c1f20-76c4-424c-afe5-b3b57f88d185"), "C.26.7", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("755b59a1-b6d7-4e0e-a5bd-e1bd42314f50"), "C.26.70", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("a0b186a9-b07f-43e6-be23-d0ad3aeb79af"), "C.26.8", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Manufacture of magnetic and optical media" },
                    { new Guid("66313c61-e4d2-4098-b216-40b99851073a"), "C.25.62", new Guid("6906ec72-f741-4fce-bb68-44cf5891f7cd"), "Machining" },
                    { new Guid("232bfb85-215a-4d28-8b1a-9ab6afa1d84f"), "U.99.00", new Guid("93fb6644-f8fa-49fa-a07d-20b6393c1693"), "Activities of extraterritorial organisations and bodies" }
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
