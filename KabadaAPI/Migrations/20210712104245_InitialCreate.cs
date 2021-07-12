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
                    IsPropositionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCostCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRevenueCompleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("460dfb42-0516-4079-a93e-eaba91c22e25"), "AT", "Austria" },
                    { new Guid("486dc08f-7fb3-49e4-9300-41bf70a0069d"), "LU", "Luxembourg" },
                    { new Guid("5fa1203b-60e0-407b-b3a5-2a7199b8ef29"), "MT", "Malta" },
                    { new Guid("2d86f344-8512-48fa-b234-15f1a33c6ba2"), "MK", "North Macedonia" },
                    { new Guid("44851e0c-8b21-4ab4-8b0b-662d2818e50e"), "NO", "Norway" },
                    { new Guid("030a7c85-f8f7-4296-8369-809fe2325c32"), "PL", "Poland" },
                    { new Guid("5014ff41-d232-484b-9563-58328de984ef"), "PT", "Portugal" },
                    { new Guid("8f94943f-a7ee-4337-a436-16a9d1a3da92"), "RO", "Romania" },
                    { new Guid("481c263e-86fc-4ecb-8411-bdaf794e1847"), "RS", "Serbia" },
                    { new Guid("68811ce6-ee6f-4406-af55-5d3e14e2c538"), "SK", "Slovakia" },
                    { new Guid("a9da8fad-f10f-484f-83b2-557d0b1d8eb7"), "SI", "Slovenia" },
                    { new Guid("5de5fc7d-e1ad-4606-afdb-1a4c827f133f"), "ES", "Spain" },
                    { new Guid("36fbb563-175f-4762-9f02-f27962d418b9"), "SE", "Sweden" },
                    { new Guid("8cec237f-bbac-441e-bfce-7d3e1591d0dd"), "CH", "Switzerland" },
                    { new Guid("6a6331e8-1e5d-4658-8c43-11bb3f27ffbe"), "TR", "Turkey" },
                    { new Guid("1f225084-a80f-43e6-a377-baca9521a68e"), "UK", "United Kingdom" },
                    { new Guid("99d1bd1e-c620-42b3-a22c-b0528c1fec13"), "LT", "Lithuania" },
                    { new Guid("d15c9da8-2106-40af-9001-9fb7f80195d2"), "LI", "Liechtenstein" },
                    { new Guid("22bbdbd4-e39e-4099-8681-1fa18fbe7b99"), "NL", "Netherlands" },
                    { new Guid("a010a02d-33f8-42aa-aabc-b823713f6d73"), "IT", "Italy" },
                    { new Guid("9ac2450e-f1a7-4c43-9299-46fe8a628a2a"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("51310c22-d4cc-4ac7-8d1c-2ab0381a936c"), "BE", "Belgium" },
                    { new Guid("1032fdf5-ce76-4ba3-b70e-c9e55f5872f8"), "BG", "Bulgaria" },
                    { new Guid("16666bc0-8aa0-496d-9378-9ba3bd0d0843"), "LV", "Latvia" },
                    { new Guid("57996559-a107-491e-acfe-28030fa9aa4c"), "CY", "Cyprus" },
                    { new Guid("ea6b4934-8426-4ff7-a3b3-8f21dafb36e1"), "CZ", "Czechia" },
                    { new Guid("706ae89e-9fe8-421b-8668-9e29c9b77599"), "DK", "Denmark" },
                    { new Guid("d1c8d60c-1b78-4bd4-8e5e-a8f428d893f1"), "EE", "Estonia" },
                    { new Guid("98a16c85-83e5-48ae-9ad2-1ebd1569b1f7"), "HR", "Croatia" },
                    { new Guid("f47ed78f-280c-40ff-8030-b47c23f0bf2d"), "FR", "France" },
                    { new Guid("169574f0-5279-4ad1-9989-dd2d1236733c"), "DE", "Germany" },
                    { new Guid("90a0bde0-6393-4767-ae71-76ed8804008c"), "EL", "Greece" },
                    { new Guid("0ba25aae-b7ba-442c-a75d-9eb900f01e1e"), "HU", "Hungary" },
                    { new Guid("0a86b6b3-face-468f-9cd4-0fa78cf03391"), "IS", "Iceland" },
                    { new Guid("a1fbac0d-5efb-41fe-a79e-cc62aa904ea6"), "IE", "Ireland" },
                    { new Guid("9a61a282-d062-45cc-8b9f-768331085a88"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "P", "EN", "Education" },
                    { new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "S", "EN", "Other services activities" },
                    { new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "R", "EN", "Arts, entertainment and recreation" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("e3d2ecf6-4460-4227-980d-a244cff02f80"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "L", "EN", "Real estate activities" },
                    { new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "K", "EN", "Financial and insurance activities" },
                    { new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "H", "EN", "Transporting and storage" },
                    { new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "F", "EN", "Construction" },
                    { new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "C", "EN", "Manufacturing" },
                    { new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "B", "EN", "Mining and quarrying" },
                    { new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "J", "EN", "Information and communication" },
                    { new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "A", "EN", "Agriculture, forestry and fishing" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("e88413ab-3337-42c8-8bdb-42237768d988"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("05819386-5331-49bc-a795-6fcf6bb64ec8"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("5af50257-22d0-4a70-a09d-5b96d9de34f7"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("33b6e69a-9fd6-4b01-8b9c-87e3dad06391"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("c5b65fc8-5a29-4a36-a003-96de20c12c5e"), (short)23, null, new Guid("33b6e69a-9fd6-4b01-8b9c-87e3dad06391"), (short)1, "Other" },
                    { new Guid("8366284c-9db3-46f9-bf6b-c15b33dfeda5"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("c4825423-c10f-4c92-9ede-dd4560a455ef"), (short)23, null, new Guid("8366284c-9db3-46f9-bf6b-c15b33dfeda5"), (short)1, "Manufacturing buildings" },
                    { new Guid("2fd3508f-e71b-4aaf-be84-934eebb5ec0c"), (short)23, null, new Guid("8366284c-9db3-46f9-bf6b-c15b33dfeda5"), (short)2, "Inventory buildings" },
                    { new Guid("2f5b8d99-c53b-4f19-8076-2e15822ba54d"), (short)23, null, new Guid("8366284c-9db3-46f9-bf6b-c15b33dfeda5"), (short)3, "Sales buildings (shops)" },
                    { new Guid("a79ab983-1a9a-4f5b-a334-0a5c28924e97"), (short)23, null, new Guid("8366284c-9db3-46f9-bf6b-c15b33dfeda5"), (short)4, "Other" },
                    { new Guid("95b95ed2-ba02-4e58-9ae8-c4f42140fb0d"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("b7dc45d9-25ce-4351-afaf-d9a6af11401f"), (short)23, null, new Guid("95b95ed2-ba02-4e58-9ae8-c4f42140fb0d"), (short)1, "IT (office) equipment" },
                    { new Guid("e04220f6-9542-442a-ab52-8080f3f74f88"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)1, "Electricity" },
                    { new Guid("f226d8cf-6b88-408b-ac87-68ead7658861"), (short)23, null, new Guid("95b95ed2-ba02-4e58-9ae8-c4f42140fb0d"), (short)3, "Transport" },
                    { new Guid("aa187494-cd46-4843-85eb-e3bb40ff6dfa"), (short)23, null, new Guid("95b95ed2-ba02-4e58-9ae8-c4f42140fb0d"), (short)4, "Other" },
                    { new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("795f3869-ead4-420f-9ab5-b3c1136ece2e"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("0d9013e9-f9f5-4f3f-9b2b-81831040ff8a"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)2, "Water" },
                    { new Guid("7eb2b480-0726-41f5-af55-77e1214800bb"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)3, "Gas" },
                    { new Guid("16a565ef-c5ea-4484-91fe-a55471160966"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)4, "Heat" },
                    { new Guid("2c8c64f9-e534-4224-acfd-26caf1295196"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)5, "Maintenance" },
                    { new Guid("eec33b74-850b-4080-85c0-f0764173109c"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)6, "Communication" },
                    { new Guid("fe981105-8249-4c4e-82c3-05375e2241ab"), (short)23, null, new Guid("818e2155-4304-4703-b0de-fee6e61e2ae5"), (short)7, "Other" },
                    { new Guid("d8c4dd1f-f2e6-4119-ba1d-200b2d27c1d2"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("d29af9d9-8cca-4ab3-bc02-8a0aa50812eb"), (short)23, null, new Guid("d8c4dd1f-f2e6-4119-ba1d-200b2d27c1d2"), (short)1, "Accountant" },
                    { new Guid("7f65317c-389d-49f4-813e-b3d0a8a4d953"), (short)23, null, new Guid("95b95ed2-ba02-4e58-9ae8-c4f42140fb0d"), (short)2, "Production equipment and machinery" },
                    { new Guid("45137ffd-fbcc-410d-9cbc-15cec071d4c0"), (short)19, null, null, (short)3, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("dc5938c9-1832-4da2-ac6c-8ec32256c463"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("e68179e2-8343-4f21-abd0-f72ca78fc607"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("1669286e-7bff-4d6a-923f-9b0895d128c8"), (short)23, null, new Guid("d8c4dd1f-f2e6-4119-ba1d-200b2d27c1d2"), (short)2, "IT support" },
                    { new Guid("ab0391dc-915d-4246-95e5-87b4e4715500"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("2409df0e-8577-4eb2-952a-6927ce8a6101"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("665c4bb6-f285-4329-817d-be875a1e5b76"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("c1b635a5-cc25-441d-9d07-8bade8077d32"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("9f479b47-e49f-4d86-91ba-904a1de281d4"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("27357f1d-c4d4-446a-8813-5359c9eee8a3"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("502d1257-72f5-4c2d-9bde-44ff0e2d54ed"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("3eccc27e-6cea-4c0d-b368-d88139fef9be"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("ed249fb6-5442-492f-a4ad-b0e0baf96121"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("68e944f6-8905-4f66-9b54-331a2aa89fa9"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("4c97860d-f8c8-4224-9b66-36a6d7085598"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("e497b965-2d38-4a12-904d-d46766c117a6"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("d180aed5-1bbf-4963-87de-29f60bb8837a"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("f7cea2ff-e4e1-4b30-909f-f11a513a45ba"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("470e554b-0a4d-4e44-9a77-9276d8f88ea9"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("53688abe-1211-408a-b330-1192ff65553e"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("cc8d3eaf-6020-456d-b767-5854e2f38b8f"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("77a981f5-12be-4368-8d6d-7195594b96be"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("be5efa65-24d8-4135-bf00-7396ec47ee5a"), (short)17, null, null, (short)2, "Economy" },
                    { new Guid("9090c12d-4620-4f9a-9e58-8b3ae5e1e9fe"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("5db941ef-a22d-4860-a8b6-a6dd6903e74d"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("5fa0e46a-2399-4b57-81a2-25e4bb556b4f"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("65539c8f-1169-468e-b521-1c86221cd355"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("f2359ba7-6fde-4d43-a59a-7ef960efbef6"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("16e25c21-9805-4601-aed1-4c7554f63bd2"), (short)23, null, new Guid("d8c4dd1f-f2e6-4119-ba1d-200b2d27c1d2"), (short)3, "Other" },
                    { new Guid("0f1bc3b0-9a8b-409f-9a8e-616f70d3c657"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("2064070c-558b-41da-8c85-b52f58cb6c62"), (short)23, null, new Guid("9eb7f2e0-7f41-437f-901a-e9e39d17e613"), (short)1, "Other" },
                    { new Guid("6b572d93-a14e-4f09-8761-55e1fb836fd9"), (short)23, null, new Guid("dfbf16c8-4b51-45c3-99f5-e78af9d17782"), (short)1, "Other" },
                    { new Guid("6088905b-7666-4d6b-a791-09e931f9434c"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("df44beea-7342-408b-b32a-e86a294dc461"), (short)23, null, new Guid("6088905b-7666-4d6b-a791-09e931f9434c"), (short)1, "Transport" },
                    { new Guid("f795751f-6083-4094-ad04-6f9c841490a7"), (short)23, null, new Guid("6088905b-7666-4d6b-a791-09e931f9434c"), (short)2, "Cost of warehouse" },
                    { new Guid("090d9305-e123-4e20-a330-46162136043b"), (short)23, null, new Guid("6088905b-7666-4d6b-a791-09e931f9434c"), (short)3, "Fees to distributors" },
                    { new Guid("3a568aaa-93dc-4150-a05d-91e31272986d"), (short)23, null, new Guid("6088905b-7666-4d6b-a791-09e931f9434c"), (short)4, "Other" },
                    { new Guid("f439b3c5-631c-4a85-81c2-72664ca6f1c3"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("a078f0cd-47bb-437f-bc2f-1940f2954a16"), (short)23, null, new Guid("f439b3c5-631c-4a85-81c2-72664ca6f1c3"), (short)1, "Other" },
                    { new Guid("3ef9573a-c02e-464c-8375-3b88521d66fe"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("9df657e6-74c9-432d-8070-3992aa980a7a"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("84d1b547-9c88-4d85-89ba-707797e58741"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("dfbf16c8-4b51-45c3-99f5-e78af9d17782"), (short)22, null, null, (short)7, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("44383d0b-c55b-44fc-87d1-9249c65638a4"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("1aab0601-9e1b-4915-a5a5-497343cb8c14"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("6ee91ac4-73bd-4adc-96c5-2c494b3cd647"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("0103a997-7c5f-468c-be38-dc744ac5b396"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("bac991bd-aaa7-43d7-8dcf-575b67c42e02"), (short)26, null, new Guid("0103a997-7c5f-468c-be38-dc744ac5b396"), (short)1, "List price" },
                    { new Guid("7d7c8103-da5d-4a00-a3fa-251d7bfb5ad2"), (short)26, null, new Guid("0103a997-7c5f-468c-be38-dc744ac5b396"), (short)2, "Product feature dependent" },
                    { new Guid("e927c97d-28e3-4322-8722-d31757a278da"), (short)26, null, new Guid("0103a997-7c5f-468c-be38-dc744ac5b396"), (short)3, "Volume dependent" },
                    { new Guid("0dcfcfb5-5f82-481b-95b9-ccd4e91deaf5"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("f54c310f-ab8c-49b6-88e9-27de4a18ac85"), (short)26, null, new Guid("0dcfcfb5-5f82-481b-95b9-ccd4e91deaf5"), (short)1, "Negotiation" },
                    { new Guid("d00a7357-3240-4624-ada9-fb0d79e331e4"), (short)26, null, new Guid("0dcfcfb5-5f82-481b-95b9-ccd4e91deaf5"), (short)2, "Yield management" },
                    { new Guid("c272e72d-213c-4669-914c-034ff7c87e11"), (short)26, null, new Guid("0dcfcfb5-5f82-481b-95b9-ccd4e91deaf5"), (short)3, "Real time market" },
                    { new Guid("0a074745-8990-4a0d-a955-945a0fcc4904"), (short)26, null, new Guid("0dcfcfb5-5f82-481b-95b9-ccd4e91deaf5"), (short)4, "Auctions" },
                    { new Guid("1cff8c5d-eb23-4e77-af0d-d02c553cfabf"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("c83429f9-971a-41ca-8d41-e707bd33dd0c"), (short)23, null, new Guid("0f1bc3b0-9a8b-409f-9a8e-616f70d3c657"), (short)1, "Other" },
                    { new Guid("50645703-c8e3-43a9-af56-fa874cb08aee"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("773e966f-df41-4b34-836f-68f26b82e70c"), (short)23, null, new Guid("8eddf661-fcd6-4757-b679-a40125eeb0d9"), (short)1, "Other" },
                    { new Guid("f2a59e01-7087-43ae-8067-1aaa3ba4b481"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("89f1f1e0-ec6e-44b9-86c8-f0ca95a80f84"), (short)23, null, new Guid("f2a59e01-7087-43ae-8067-1aaa3ba4b481"), (short)1, "Management" },
                    { new Guid("04e5a033-39ec-456f-8767-4f3a4214a904"), (short)23, null, new Guid("f2a59e01-7087-43ae-8067-1aaa3ba4b481"), (short)2, "Factory workers / service" },
                    { new Guid("2b051021-a381-410e-8f61-e91befbda06f"), (short)23, null, new Guid("f2a59e01-7087-43ae-8067-1aaa3ba4b481"), (short)3, "Finance management" },
                    { new Guid("df756828-f8ab-4abe-94ef-b11931ec336c"), (short)23, null, new Guid("f2a59e01-7087-43ae-8067-1aaa3ba4b481"), (short)4, "Marketing" },
                    { new Guid("b2ad0a9b-69b3-4f99-8ee1-7551bad03265"), (short)23, null, new Guid("f2a59e01-7087-43ae-8067-1aaa3ba4b481"), (short)5, "Other" },
                    { new Guid("391a27a3-2508-4268-83c3-51699f5a94d3"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("a336fc8c-46e6-408e-bad3-8f0fdbc5c1bc"), (short)23, null, new Guid("391a27a3-2508-4268-83c3-51699f5a94d3"), (short)1, "Other" },
                    { new Guid("0550b89c-0384-4386-b651-6d98c3dbe18b"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("e0c668dc-0432-4011-909e-4b38144b58e8"), (short)23, null, new Guid("0550b89c-0384-4386-b651-6d98c3dbe18b"), (short)1, "Other" },
                    { new Guid("59b11236-7353-40aa-ba2b-ea47f27bedc5"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("96c782ca-7d0b-49dc-8b47-16dc1dd05b29"), (short)23, null, new Guid("59b11236-7353-40aa-ba2b-ea47f27bedc5"), (short)1, "Other" },
                    { new Guid("6bf3d7fa-caf6-4a1b-b97c-108cb50612c0"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("a25f58c9-4de6-45a9-98ed-5387bfa4d412"), (short)23, null, new Guid("6bf3d7fa-caf6-4a1b-b97c-108cb50612c0"), (short)1, "Other" },
                    { new Guid("abe04632-fdd4-48b8-80fe-62bfb1e40914"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("de78ef70-3dd7-45f2-bb38-3e9815a37847"), (short)23, null, new Guid("abe04632-fdd4-48b8-80fe-62bfb1e40914"), (short)1, "Manufacturing building" },
                    { new Guid("4a992cee-ca1f-4d4b-9a89-de7e607a7ace"), (short)23, null, new Guid("abe04632-fdd4-48b8-80fe-62bfb1e40914"), (short)2, "Office" },
                    { new Guid("05b3d03a-279b-4628-b0ca-786b9ec9d0f7"), (short)23, null, new Guid("abe04632-fdd4-48b8-80fe-62bfb1e40914"), (short)3, "Equipment" },
                    { new Guid("327be2f0-4289-4e64-bdf9-9dd154f01621"), (short)23, null, new Guid("abe04632-fdd4-48b8-80fe-62bfb1e40914"), (short)4, "Other" },
                    { new Guid("33c8f75b-1597-4728-983b-eae062b60392"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("2be2919e-8544-4a61-b46f-8c4441903de2"), (short)23, null, new Guid("33c8f75b-1597-4728-983b-eae062b60392"), (short)1, "Other" },
                    { new Guid("6ca68cc4-dbd2-4271-9810-cc0ddc52ddf1"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("0b038f14-b4e7-4627-931e-55449681f05a"), (short)23, null, new Guid("6ca68cc4-dbd2-4271-9810-cc0ddc52ddf1"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("149275d5-ad86-4062-9e92-077655ee9ab6"), (short)23, null, new Guid("6ca68cc4-dbd2-4271-9810-cc0ddc52ddf1"), (short)2, "Other" },
                    { new Guid("8eddf661-fcd6-4757-b679-a40125eeb0d9"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("9eb7f2e0-7f41-437f-901a-e9e39d17e613"), (short)21, null, null, (short)5, "Outsourcing of specified services" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("80a99492-7db1-4930-b494-196bf4e199de"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("31ed6615-f93c-40fb-b257-845d59256c93"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("12d9a461-ae61-4199-b581-ef35b28c5156"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("bccdbc42-ae5c-45b2-b53c-5241b4b0c96d"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("42873a5a-5b36-4a28-ab4c-5dfeec7b5d2c"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("0e03f9c7-3133-4c4b-a502-c843fe05818c"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("a2c273d5-a497-4d53-8de3-a5d562a00c72"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("978994e3-26cf-4ed7-bd3a-807c43bf07b7"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("e10e08de-d535-467f-916a-241c1cd384c2"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("13e0e54c-b602-4e95-a61b-835bf7e03cb6"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("6669ca49-bd84-487b-a829-e039b8e3cc5a"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("7c2be7d4-265c-4299-a532-1d141d6e3c7f"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("676860bd-717d-49b5-8a01-75ca82d47624"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("6f2af9fc-5786-4491-a8e2-fabfdf2ea9c9"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("67175e2b-89f9-4051-bf99-2041864cb943"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("a8338768-fe87-4b6d-9c08-5a2e6b6aa2d3"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("9c694fdb-34e7-4573-ac07-1d054c15681c"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("07d41dba-f79c-4b89-8a6a-72616ce78cc5"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("29591d8c-7a7f-44f2-964c-fce7ddc92d70"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("4ee89423-df50-4e55-a494-45d4d1bd2c14"), (short)3, null, null, (short)23, "Bargaining power of buyers" },
                    { new Guid("64f335b2-d37c-4e5b-a7ac-ac9f364e9c63"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("57044182-ed97-4690-979d-b6cc10d858e2"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("44b9c5fb-b5d9-42d1-bf95-53d722c256c8"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("9a49df29-dcf8-4be1-9ce8-6f9d6b868bab"), (short)6, null, new Guid("44b9c5fb-b5d9-42d1-bf95-53d722c256c8"), (short)1, "Buildings" },
                    { new Guid("e922332e-458c-4acb-b4e4-3010c3f7a9bc"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("9a49df29-dcf8-4be1-9ce8-6f9d6b868bab"), (short)1, "Ownership type" },
                    { new Guid("a6d4f946-6bc3-438e-a56d-24ed150732cf"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("9a49df29-dcf8-4be1-9ce8-6f9d6b868bab"), (short)2, "Frequency" },
                    { new Guid("7fe2a2d3-07fb-41b7-9f6e-0155e6233f4d"), (short)6, null, new Guid("44b9c5fb-b5d9-42d1-bf95-53d722c256c8"), (short)2, "Equipment" },
                    { new Guid("c2004460-5b74-4313-b5b5-c837b6e86a7f"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("c31e529f-6a90-48e0-9b93-379e369b61f0"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("725fd60e-9447-4b5c-9c94-d7d4b5566a23"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("dfc78bae-8fe2-4ffb-8c4c-b9045f140ce7"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("eaf69fcc-fbde-4bd2-9001-9028e53edd19"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("dcacbcd3-1053-4886-8288-6eee54939a00"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("a8b5de59-c51d-40f5-9f6b-56eabde4941f"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("f0093335-d0e4-46d1-91ca-6a63845d4bd7"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("113fd9f0-0808-4c71-9da3-7e4a44ad7d9f"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("b33eba77-ff5d-4d4f-a00d-a2be867dd2d8"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("c0612108-0015-4498-ad3b-fd142e44cd1d"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("67479d69-90a6-4a2e-a5d7-d8a875a6be89"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("d0dc169a-371a-49a5-b3f3-20b6a5e2a080"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("4f521da2-2d4c-462c-a4af-2d16ba7f3741"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("63fcc978-25e5-4ea1-9c86-6097ab725d1d"), (short)1, "a", null, (short)11, "Management processes" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("74468b98-073a-4730-a10d-92cbc352c772"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("6fcd7c3d-6ef3-4fa4-b22d-388e573affbe"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("49058db7-74bf-4599-ae27-0e14d647eae8"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("e23d247e-2f9e-4d21-830b-160d8ef7a65e"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("737eb6fc-4353-45d9-954c-6abfd2b37c26"), (short)1, "a", null, (short)16, "Complementary and after-sales service" },
                    { new Guid("41aec0a8-494a-407b-81f2-9b986e617898"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("775e6505-ab6b-4b6f-9371-22de8184fe20"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("9be365b2-1a35-4a07-8105-c945515e288d"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("2c344f33-8a23-4872-8d94-a96c7f1cf1d9"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("0cdc1a39-91cc-40b5-8372-2359717d09d2"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("a3141ed9-99f8-4415-851c-ffaad4a57964"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("aa6ae64d-6083-48cd-bf17-754dd554e5d8"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("b33a65e9-c235-465b-a23e-8a0338e1ee82"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("5e4d04c5-0ae6-48e4-aaa4-14307bfc4a8c"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("0d567fb3-6bf3-45a1-a8f8-99074b686a72"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("7fe2a2d3-07fb-41b7-9f6e-0155e6233f4d"), (short)1, "Ownership type" },
                    { new Guid("13d94b8c-54c4-444c-a382-79d872e3abc7"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("c32786e0-78b3-4f9b-b0f1-fb58c99483d2"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("7fe2a2d3-07fb-41b7-9f6e-0155e6233f4d"), (short)2, "Frequency" },
                    { new Guid("6a04ff4d-6217-4c27-a39e-cb2a77954cf7"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("1cd09f9a-e630-4cbc-933f-1313e0205203"), (short)1, "Ownership type" },
                    { new Guid("7820cb2e-024d-48a8-8741-a0cf84357ef8"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("ada16217-a09a-40c7-9dc0-5cf5cb74fdb4"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("b7931463-7573-451f-9205-e90ba4ab359b"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("1c60aad3-1783-4b29-abda-c712e175f253"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("d353eda7-8605-402f-8374-a6fed63fc373"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("08343684-76ce-4432-838f-be91e30da480"), (short)12, null, null, (short)4, "Financiers" },
                    { new Guid("0d39a7bf-d79a-4eec-9501-965e0050b251"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("5f22d739-6fe9-4903-97bd-bdd3bd3d4954"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("66ee9861-97a6-45c7-b276-80c3b83ae646"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("55fd87f6-e8ac-4c72-b588-0ef239e634dc"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("9a90e1c0-7cd6-4498-ae2b-7e12ca2f1a18"), (short)13, null, null, (short)1, "Consultants" },
                    { new Guid("a6da594c-3671-40c2-8a9c-a9f3b24a4771"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("eedded58-d4f2-458b-b0d5-538920a36834"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("d12d16cd-27d6-4987-abf3-7e9c1b51a32a"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("82342852-86c0-4e0f-9213-49ca67f7e0a9"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("764ef0ec-a499-44d7-b48c-9853b0e17911"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("87f86561-d305-456f-80be-224f7c26d2c8"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("b7e6a136-1c37-46e2-9a72-b3a39ff23533"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("e35db6cb-33df-4601-b73f-7778bb0ac677"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("d7373852-0ba4-4532-8b80-b7c1ebee6ad9"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("ff1c5c9f-0166-4895-9286-2f22962efcbc"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("2493a67b-b305-439b-8f1f-ef32829b89ea"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("f03e4469-47c0-4e9e-be7b-85c164a7461b"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("6df430c2-e6bf-4c29-bb60-610390a99fc5"), (short)11, null, null, (short)4, "Wholesalers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("1cd09f9a-e630-4cbc-933f-1313e0205203"), (short)6, null, new Guid("44b9c5fb-b5d9-42d1-bf95-53d722c256c8"), (short)3, "Transport" },
                    { new Guid("da94ca1a-243c-4d6c-a67a-190af3278d6a"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("9b0e81e3-8e10-4e23-9edb-e88955ab8afb"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("6b6941aa-9134-4a2e-a123-e3587e3e08cc"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("1cd09f9a-e630-4cbc-933f-1313e0205203"), (short)2, "Frequency" },
                    { new Guid("fbc4d879-5704-4912-af19-5df29e5e51e3"), (short)6, null, new Guid("44b9c5fb-b5d9-42d1-bf95-53d722c256c8"), (short)4, "Raw materials" },
                    { new Guid("b3f23e5b-634a-4f89-b755-5cfe3e1b5552"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("fbc4d879-5704-4912-af19-5df29e5e51e3"), (short)1, "Ownership type" },
                    { new Guid("c9dec977-f025-47c2-8506-d84ce1baccbe"), (short)6, null, new Guid("44b9c5fb-b5d9-42d1-bf95-53d722c256c8"), (short)5, "Other" },
                    { new Guid("482f37a4-f15b-47b9-8ce5-7a68d268df20"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("c9dec977-f025-47c2-8506-d84ce1baccbe"), (short)1, "Ownership type" },
                    { new Guid("15285d08-ac40-4182-8f67-7ed6100438cb"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("c9dec977-f025-47c2-8506-d84ce1baccbe"), (short)2, "Frequency" },
                    { new Guid("eb7f21d2-b8a1-4559-960e-f903b1ba5dd2"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("317bc3a6-0e28-4b71-99d6-59f907f7194b"), (short)6, null, new Guid("eb7f21d2-b8a1-4559-960e-f903b1ba5dd2"), (short)1, "Brands" },
                    { new Guid("344acf20-b8e1-4ce4-8634-2efff6a6b9a6"), (short)6, null, new Guid("eb7f21d2-b8a1-4559-960e-f903b1ba5dd2"), (short)2, "Licenses" },
                    { new Guid("de751223-4d6c-405a-9572-69c7e6d3a0a5"), (short)6, null, new Guid("eb7f21d2-b8a1-4559-960e-f903b1ba5dd2"), (short)3, "Software" },
                    { new Guid("5710f777-35d1-44d1-a2c9-6c8ca0156c51"), (short)6, null, new Guid("eb7f21d2-b8a1-4559-960e-f903b1ba5dd2"), (short)4, "Other" },
                    { new Guid("2494c535-dc5b-4eb3-b45e-e4ed5c6f6585"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("ae53b628-80d2-4ca5-91f6-61f0b13a74fd"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("e11b18c7-2fcf-433d-ba44-9bb6b0efc53a"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("d39ca072-a29d-43a8-9a4e-f66740b0b3ca"), (short)1, "Ownership type" },
                    { new Guid("48f5bd15-7d6c-467b-8b81-29dd12adfa1c"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("d39ca072-a29d-43a8-9a4e-f66740b0b3ca"), (short)2, "Frequency" },
                    { new Guid("70219493-972b-459a-9cf5-8d518e988c11"), (short)6, null, new Guid("ae53b628-80d2-4ca5-91f6-61f0b13a74fd"), (short)2, "Administrative" },
                    { new Guid("607b099e-c83e-481e-9870-de0d41ed49af"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("70219493-972b-459a-9cf5-8d518e988c11"), (short)1, "Ownership type" },
                    { new Guid("cf8abd24-096d-4bd0-a303-44396dd30dc4"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("70219493-972b-459a-9cf5-8d518e988c11"), (short)2, "Frequency" },
                    { new Guid("ee93560e-91ff-417f-bb13-d13ffb37a389"), (short)6, null, new Guid("ae53b628-80d2-4ca5-91f6-61f0b13a74fd"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("67584af3-b7ca-4901-b102-1c98a80b88bc"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("ee93560e-91ff-417f-bb13-d13ffb37a389"), (short)1, "Ownership type" },
                    { new Guid("1dcaea6d-5191-4f1d-b325-04c82167bc59"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ee93560e-91ff-417f-bb13-d13ffb37a389"), (short)2, "Frequency" },
                    { new Guid("f52ab692-9c71-4adc-ab30-045002160c5f"), (short)6, null, new Guid("ae53b628-80d2-4ca5-91f6-61f0b13a74fd"), (short)4, "Other" },
                    { new Guid("5c60da4c-ce16-48e5-8bd6-f938297db510"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("f52ab692-9c71-4adc-ab30-045002160c5f"), (short)1, "Ownership type" },
                    { new Guid("50338a22-bee9-4cf3-b0f2-568f7fba7fb2"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("f52ab692-9c71-4adc-ab30-045002160c5f"), (short)2, "Frequency" },
                    { new Guid("d39ca072-a29d-43a8-9a4e-f66740b0b3ca"), (short)6, null, new Guid("ae53b628-80d2-4ca5-91f6-61f0b13a74fd"), (short)1, "Specialists & Know-how" },
                    { new Guid("aa67fd7b-2f26-44a2-957a-11833e0566b5"), (short)15, null, null, (short)11, "Based on new technologies" }
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
                    { new Guid("c929bf33-8ed1-4a12-8abc-2d42353819d8"), "A.01", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("99482b09-9e72-4bc8-9725-ca4bfb8db295"), "H.51.22", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Space transport" },
                    { new Guid("7c90719d-6916-4f1f-8cdd-e0cda98b2990"), "H.52", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Warehousing and support activities for transportation" },
                    { new Guid("1dcc02e8-b89b-43a6-b46f-ca326eb3c881"), "H.52.1", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Warehousing and storage" },
                    { new Guid("6677a475-f9e8-4daf-a0b3-e7c69c0af264"), "H.52.10", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Warehousing and storage" },
                    { new Guid("51bdbd63-bee8-4a16-98db-a9a2b7173258"), "H.52.2", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Support activities for transportation" },
                    { new Guid("e29f74b4-ff29-4025-9218-8516ab9f1238"), "H.52.21", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Service activities incidental to land transportation" },
                    { new Guid("e8e68c82-9abb-4df4-835e-48ccde981029"), "H.52.22", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Service activities incidental to water transportation" },
                    { new Guid("c0862bd9-5eb6-45b3-b688-cb26e61d0216"), "H.52.23", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Service activities incidental to air transportation" },
                    { new Guid("e160fce5-8a7b-4c1b-b725-70e36983f256"), "H.52.24", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Cargo handling" },
                    { new Guid("bf734b58-57bc-4ee7-9114-66f01f0cba57"), "H.52.29", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Other transportation support activities" },
                    { new Guid("3d62fbe8-6eb6-4350-a1d9-432f8576105d"), "H.53", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Postal and courier activities" },
                    { new Guid("c0faad96-eb33-446f-a2f5-f4fadbe7ece9"), "H.53.1", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Postal activities under universal service obligation" },
                    { new Guid("2af2c347-0230-43c3-9bbf-e5a611dc85d1"), "H.51.21", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Freight air transport" },
                    { new Guid("6b7ccfdc-d3f1-4fb8-b150-9286816f2e82"), "H.53.10", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Postal activities under universal service obligation" },
                    { new Guid("91308343-043b-4641-b63b-3a49a374265b"), "H.53.20", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Other postal and courier activities" },
                    { new Guid("b93956c1-0756-40c0-afcd-1eecb47b723c"), "I.55", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Accommodation" },
                    { new Guid("af539358-48b3-4741-acdd-cb85a3d07d8b"), "I.55.1", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Hotels and similar accommodation" },
                    { new Guid("0de0033c-1144-44d9-a777-5e7508dc289a"), "I.55.10", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Hotels and similar accommodation" },
                    { new Guid("161c46b2-f542-4bda-bd4d-73fe91902a84"), "I.55.2", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Holiday and other short-stay accommodation" },
                    { new Guid("803e337c-8356-4e53-96b1-a27fc54e889b"), "I.55.20", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Holiday and other short-stay accommodation" },
                    { new Guid("3fc90fb7-e225-44e3-b9f8-6eae5521d9a7"), "I.55.3", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("1e4f28d4-1191-4c1d-b208-53d93a24ce91"), "I.55.30", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("80946b80-5370-49ff-ad66-8eec11695ab6"), "I.55.9", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Other accommodation" },
                    { new Guid("b983f33a-135d-47df-a05f-fbefafae350f"), "I.55.90", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Other accommodation" },
                    { new Guid("e7a005e8-c4d2-4c7a-adcd-1ac8359ae7fb"), "I.56", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Food and beverage service activities" },
                    { new Guid("4ed80c89-932e-44f1-8b46-bd6e17148da5"), "I.56.1", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Restaurants and mobile food service activities" },
                    { new Guid("dc4886a9-fdc3-4969-ae7c-33a961886cad"), "H.53.2", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Other postal and courier activities" },
                    { new Guid("1f440873-4c71-488b-bac0-3e4d1e6cb64a"), "H.51.2", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Freight air transport and space transport" },
                    { new Guid("79fa1122-54d2-489a-9fbc-4b233eceec09"), "H.51.10", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Passenger air transport" },
                    { new Guid("d53891b6-236c-4b81-8b75-38f10e5d31c1"), "H.51.1", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Passenger air transport" },
                    { new Guid("a65e790a-0e5e-4b41-b13e-2d1a21400aa2"), "G.47.9", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("8907dcc5-771c-4279-a5a7-b0178be832ee"), "G.47.91", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("b603e857-a145-4a71-b0d9-ff7769271136"), "G.47.99", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("9e04e295-56e6-40a8-9b1a-25138cfb76e4"), "H.49", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Land transport and transport via pipelines" },
                    { new Guid("302c8306-71d3-4fc2-9e89-37f20dfd4e76"), "H.49.1", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Passenger rail transport, interurban" },
                    { new Guid("7435d48f-00cf-4159-bfdd-d221128efd93"), "H.49.10", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Passenger rail transport, interurban" },
                    { new Guid("d93ac5f6-163a-4d0c-9e58-019242f8bebc"), "H.49.2", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Freight rail transport" },
                    { new Guid("3633b553-ccfe-4840-bb16-b71f29d7f622"), "H.49.20", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Freight rail transport" },
                    { new Guid("014bea27-f04d-4756-bd58-a5e3d58687de"), "H.49.3", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Other passenger land transport" },
                    { new Guid("437abbb6-eba1-4379-8e06-9dc516166950"), "H.49.31", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Urban and suburban passenger land transport" },
                    { new Guid("fb50c05a-70c3-49af-9a21-a76d9d05e49f"), "H.49.32", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ea31fe9f-8c02-4a76-92c9-6fd9339bf7eb"), "H.49.39", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Other passenger land transport n.e.c." },
                    { new Guid("caabadf2-2caf-43de-ad22-dd187db4c017"), "H.49.4", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Freight transport by road and removal services" },
                    { new Guid("6f875828-b4c5-40fb-8622-518a80f2df30"), "H.49.41", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Freight transport by road" },
                    { new Guid("a0d534f3-9f31-4fbd-8c10-2b0dfe66c721"), "H.49.42", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Removal services" },
                    { new Guid("587ffb37-1041-4198-83a1-5873fe172cdb"), "H.49.5", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Transport via pipeline" },
                    { new Guid("6b9b4080-3f04-4b17-b3e8-fd23ad9b820f"), "H.49.50", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Transport via pipeline" },
                    { new Guid("b697d7b7-b2f1-45e6-8eba-67e5718d6d4f"), "H.50", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Water transport" },
                    { new Guid("ad3e36e9-06be-4776-9de1-bd77b80a39f6"), "H.50.1", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Sea and coastal passenger water transport" },
                    { new Guid("f83820e7-ee55-447f-97d7-03d334d0ea61"), "H.50.10", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Sea and coastal passenger water transport" },
                    { new Guid("9f843b71-7b74-4628-933a-9895b6c71546"), "H.50.2", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Sea and coastal freight water transport" },
                    { new Guid("d3f23607-ef4a-4025-ae5d-58a7435694f5"), "H.50.20", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Sea and coastal freight water transport" },
                    { new Guid("44ba2927-20ad-415b-a7f3-ee152982a8b0"), "H.50.3", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Inland passenger water transport" },
                    { new Guid("c33753af-6328-4d15-bb47-68c21b916041"), "H.50.30", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Inland passenger water transport" },
                    { new Guid("00e34af5-dd0d-4ab8-ac5a-83038f7a34ae"), "H.50.4", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Inland freight water transport" },
                    { new Guid("c56302c4-28fd-4399-94fb-5af0ba4d46bf"), "H.50.40", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Inland freight water transport" },
                    { new Guid("2f7d83f8-d648-4b5a-b61b-3b79e08fcec3"), "H.51", new Guid("685d4c02-69e3-4480-a892-dafb246dcd77"), "Air transport" },
                    { new Guid("b3ae5ce9-8f26-42c2-a927-585725053426"), "I.56.10", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Restaurants and mobile food service activities" },
                    { new Guid("6aafb175-a327-4ad5-abee-e5c40379520c"), "G.47.89", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("42a899bb-1bb5-433a-8b6f-e160740264b6"), "I.56.2", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Event catering and other food service activities" },
                    { new Guid("ab118f29-a70b-4b09-8da0-fa4e22504735"), "I.56.29", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Other food service activities" },
                    { new Guid("6b9374b5-1452-4680-bdaa-cbd966c680e2"), "J.61.30", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Satellite telecommunications activities" },
                    { new Guid("b503efda-8914-4edd-b15e-1ad2266c0be4"), "J.61.9", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other telecommunications activities" },
                    { new Guid("a176c00f-ef09-4079-a5bc-d620574408c8"), "J.61.90", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other telecommunications activities" },
                    { new Guid("5941d42f-6033-438e-84e0-12c346148883"), "J.62", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Computer programming, consultancy and related activities" },
                    { new Guid("6bd489b4-8eb9-41c0-8af3-688ab8e28a69"), "J.62.0", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Computer programming, consultancy and related activities" },
                    { new Guid("20dda75d-bc84-43af-aa2b-40d7a3129272"), "J.62.01", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Computer programming activities" },
                    { new Guid("c199f7ed-18a4-41c0-96a0-32999e6729c4"), "J.62.02", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Computer consultancy activities" },
                    { new Guid("5e0be2fb-e8dc-4405-9aca-5e66e646f353"), "J.62.03", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Computer facilities management activities" },
                    { new Guid("830850f1-e145-444c-8617-82602b73b6e0"), "J.62.09", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other information technology and computer service activities" },
                    { new Guid("f9db3043-e6e6-41df-ba47-f4b24f2d43a6"), "J.63", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Information service activities" },
                    { new Guid("295f3659-1707-48ec-82a6-635d39daeef5"), "J.63.1", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("be2ea320-9892-497a-bea1-39b25f577d95"), "J.63.11", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Data processing, hosting and related activities" },
                    { new Guid("19452036-49d4-47ff-bbfb-15f5f78ca6e0"), "J.61.3", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Satellite telecommunications activities" },
                    { new Guid("6c575a75-e78c-4233-9286-c2994aa3991a"), "J.63.12", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Web portals" },
                    { new Guid("d96c4e9e-9449-475a-962a-3479c54df803"), "J.63.91", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "News agency activities" },
                    { new Guid("2fea9325-88ad-4ef2-992e-320b77b8b98b"), "J.63.99", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other information service activities n.e.c." },
                    { new Guid("5a65cbcb-7083-42e8-aa19-2ffbecb3257e"), "K.64", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("49114bf2-6655-4c47-8182-084107dae904"), "K.64.1", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Monetary intermediation" },
                    { new Guid("9d91bcc7-e968-42c3-aea2-059619c9d6c0"), "K.64.11", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Central banking" },
                    { new Guid("5068b34d-1772-4317-9f91-2e49f65aa150"), "K.64.19", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Other monetary intermediation" },
                    { new Guid("48251184-6708-495a-a816-0c1aba7247af"), "K.64.2", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Activities of holding companies" },
                    { new Guid("54319c96-af7b-4462-92df-1e496882baae"), "K.64.20", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("555e3b30-7f83-4946-a0d8-7ce9bb8b2e11"), "K.64.3", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Trusts, funds and similar financial entities" },
                    { new Guid("8431cac3-10ca-4799-ae03-c21d8b535b5c"), "K.64.30", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Trusts, funds and similar financial entities" },
                    { new Guid("f57db249-bcc6-42e6-a7b1-20f86d4063c3"), "K.64.9", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("775c9a76-89da-4c12-9e82-e48624fb26bf"), "K.64.91", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Financial leasing" },
                    { new Guid("3870d76c-8a39-4646-80eb-34f60ab302ed"), "J.63.9", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other information service activities" },
                    { new Guid("92a1de86-3dfd-4763-ad7c-6c2f22b54089"), "J.61.20", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Wireless telecommunications activities" },
                    { new Guid("dfb3ad07-2522-4fef-88f7-984954d404e3"), "J.61.2", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Wireless telecommunications activities" },
                    { new Guid("ba4b2768-6254-42fc-8c6c-3b0f97ad8926"), "J.61.10", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Wired telecommunications activities" },
                    { new Guid("a230ac96-424a-48c6-9205-7c660b355e24"), "I.56.3", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Beverage serving activities" },
                    { new Guid("f6ba9101-34e1-41b4-b786-812d1d26e6e1"), "I.56.30", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Beverage serving activities" },
                    { new Guid("c9673191-9c70-46a1-8566-14ed9eaee652"), "J.58", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Publishing activities" },
                    { new Guid("84b75e75-4cd4-4de6-ae74-84253ba298b5"), "J.58.1", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("a464968f-e803-4c34-9358-a2b76765b973"), "J.58.11", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Book publishing" },
                    { new Guid("dfb7a744-757d-439a-8ad1-15e1a0120ecf"), "J.58.12", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Publishing of directories and mailing lists" },
                    { new Guid("2110a4da-f1af-45ae-b8c6-e8fff80423dc"), "J.58.13", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Publishing of newspapers" },
                    { new Guid("4f8ab34b-8696-44dd-a04d-d3ddb5bb8011"), "J.58.14", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Publishing of journals and periodicals" },
                    { new Guid("14b2e319-73eb-49ba-997f-2f59c6c02c3a"), "J.58.19", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other publishing activities" },
                    { new Guid("3478cf03-9f79-4d3a-86f2-a05c0c061095"), "J.58.2", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Software publishing" },
                    { new Guid("cc332c32-1cbd-450c-8a4c-0d0c43ea8829"), "J.58.21", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Publishing of computer games" },
                    { new Guid("9f5f4eb0-f140-403e-9343-ffd9042b2e03"), "J.58.29", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Other software publishing" },
                    { new Guid("942ccae2-7c82-46ba-8fd9-cc7014fc53a0"), "J.59", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("b22b78b0-dd2a-4a43-b441-4b04fbfbcec7"), "J.59.1", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Motion picture, video and television programme activities" },
                    { new Guid("3d633961-2ce5-4e54-928e-832d501e6330"), "J.59.11", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Motion picture, video and television programme production activities" },
                    { new Guid("bf9673c5-4d3e-4096-bee4-491facf55526"), "J.59.12", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("915fa206-5a36-4ffd-8816-fe07a1f9f4ef"), "J.59.13", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("874e9244-c7c0-44d1-9efc-71e3fb0379ed"), "J.59.14", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Motion picture projection activities" },
                    { new Guid("f8af188c-187d-43ed-ab5e-2ff709c55680"), "J.59.2", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Sound recording and music publishing activities" },
                    { new Guid("9a2b4705-6713-4636-a431-3be31b11cf19"), "J.59.20", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Sound recording and music publishing activities" },
                    { new Guid("ba1f99da-bb97-4a7b-9b14-ebd2975de9d3"), "J.60", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Programming and broadcasting activities" },
                    { new Guid("976eb5f3-cdcc-4ab7-9513-f704067954ad"), "J.60.1", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Radio broadcasting" },
                    { new Guid("e3d6a693-d4bb-4a04-ab52-9cc46d29e284"), "J.60.10", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Radio broadcasting" },
                    { new Guid("3db12d21-056d-4168-8875-f42300630696"), "J.60.2", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Television programming and broadcasting activities" },
                    { new Guid("107b48ac-20c5-4668-900f-87135b7c9333"), "J.60.20", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Television programming and broadcasting activities" },
                    { new Guid("1330e418-0556-4686-9ab8-da1fb348242f"), "J.61", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Telecommunications" },
                    { new Guid("4aabd7ac-cec4-4aba-a037-b4a293453cfa"), "J.61.1", new Guid("8e4f2b5a-4d4f-4403-b375-0bfda3523dfc"), "Wired telecommunications activities" },
                    { new Guid("9f87dead-ed33-48f1-9cb9-9717d2257ee2"), "I.56.21", new Guid("abeac3c4-9eba-4fb0-9334-ede945ab1013"), "Event catering activities" },
                    { new Guid("bbe254c4-4dc1-475d-b2b2-f73415bdc8fc"), "K.64.92", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Other credit granting" },
                    { new Guid("2adeb9f7-6dfa-4ae4-8ab5-db51bc92415b"), "G.47.82", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("b782f10d-3aa7-4df5-93be-3012c098e480"), "G.47.8", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale via stalls and markets" },
                    { new Guid("e30d2708-4246-4c85-9f27-2d641d777b5f"), "G.46.19", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("81787878-fe94-4e07-821d-758e09960784"), "G.46.2", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("144cad46-fa38-403f-b322-005837e9b2ee"), "G.46.21", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("15f06818-1d6d-4b80-9edb-b94a56b04b0d"), "G.46.22", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of flowers and plants" },
                    { new Guid("b9bb412a-a62b-4337-8783-daa6d74ce109"), "G.46.23", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of live animals" },
                    { new Guid("110a41e7-ac3a-4923-bbf0-1b119ec50feb"), "G.46.24", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of hides, skins and leather" },
                    { new Guid("2d204e47-19f4-46bc-8b3c-74dc316ab547"), "G.46.3", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("f6a9e0ab-74f3-4b84-9ab2-987958ffcfdc"), "G.46.31", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of fruit and vegetables" },
                    { new Guid("eabe131c-38be-4084-b9cf-6f2268640ac6"), "G.46.32", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of meat and meat products" },
                    { new Guid("ca3d4cdc-6e68-49d3-8681-2d16067ad609"), "G.46.33", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("43eee390-f209-44b3-b81e-288f18eb2619"), "G.46.34", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of beverages" },
                    { new Guid("b237f20f-f598-46e6-a356-d6d233b64540"), "G.46.35", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of tobacco products" },
                    { new Guid("0a67dfaf-1d08-43f8-a441-e5b585df878b"), "G.46.18", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents specialised in the sale of other particular products" },
                    { new Guid("a6ebacdd-1d01-40a3-8c0c-495efbf5bbb0"), "G.46.36", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("2fc890f2-0216-472c-bc62-8c2b5d4c0393"), "G.46.38", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("7bf000a4-7a3b-4ea7-8f99-04cf046ef414"), "G.46.39", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("f327e1f4-905e-460e-8092-56795ec04658"), "G.46.4", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of household goods" },
                    { new Guid("13fc30f3-505a-4ef7-b806-67346c6031f2"), "G.46.41", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of textiles" },
                    { new Guid("989c45af-c827-461d-997c-3ef08e0b8947"), "G.46.42", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of clothing and footwear" },
                    { new Guid("816e583a-1e3e-453b-b4e2-5f56296b2b3a"), "G.46.43", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of electrical household appliances" },
                    { new Guid("55b432b8-794e-4ab4-9f4a-12558c878fcd"), "G.46.44", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("8125c02a-665f-4e5a-ab69-cd64938f7142"), "G.46.45", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of perfume and cosmetics" },
                    { new Guid("a36a6776-8242-4abd-a753-44e761be5cdc"), "G.46.46", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of pharmaceutical goods" },
                    { new Guid("52edae76-bd6f-4f4f-b756-13e1a6c3ced9"), "G.46.47", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("894adb5f-15ab-47ab-80ad-b7744c270adc"), "G.46.48", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of watches and jewellery" },
                    { new Guid("5c07a562-876f-4b90-b9dd-50a2d02a8ce4"), "G.46.49", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of other household goods" },
                    { new Guid("7aa34864-7af7-4767-9bed-e9190f4fb28a"), "G.46.37", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("23996341-c97f-4dbf-8b32-b4de139827b7"), "G.46.17", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("fc7a605b-d7dc-4dcb-ae04-abd5341d8167"), "G.46.16", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("cefa313e-95ec-4e10-8c9e-8ace955e83fc"), "G.46.15", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("94bc2420-f7a9-4b05-a116-011f72820cce"), "F.43.29", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Other construction installation" },
                    { new Guid("9559886d-ad08-4570-bdc8-aca6604ed20d"), "F.43.3", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Building completion and finishing" },
                    { new Guid("6f0afb44-ecab-4aed-a1ea-2fdc4565bbfa"), "F.43.31", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Plastering" },
                    { new Guid("be372a44-06f0-4e9c-9663-9bf14cc85397"), "F.43.32", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Joinery installation" },
                    { new Guid("f6a4d1fa-3f00-4e92-ba19-4c7c618dd6ce"), "F.43.33", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Floor and wall covering" },
                    { new Guid("e1628732-038c-4794-92e0-487dbaa2bb14"), "F.43.34", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Painting and glazing" },
                    { new Guid("6db69ca8-e800-4c58-a481-e9a2ca46bd97"), "F.43.39", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Other building completion and finishing" },
                    { new Guid("e1761580-c60d-4c3b-9c9a-75e8b33986ad"), "F.43.9", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Other specialised construction activities" },
                    { new Guid("9d57786c-e5e0-4d7b-aed2-62ca70f4f6b5"), "F.43.91", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Roofing activities" },
                    { new Guid("5c2a32b0-1d29-4522-b3ba-7cac821df471"), "F.43.99", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Other specialised construction activities n.e.c." },
                    { new Guid("aedfe8c2-92b0-435a-9bfc-bc451b5825ec"), "G.45", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("5bf28047-fba1-4a65-8ae3-ae6bbb793d98"), "G.45.1", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Sale of motor vehicles" },
                    { new Guid("56630ac6-e2db-40d5-841c-479234485e28"), "G.45.11", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Sale of cars and light motor vehicles" },
                    { new Guid("3ad19875-2ab2-4c33-b84b-22aebf6a5f9d"), "G.45.19", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Sale of other motor vehicles" },
                    { new Guid("0c585c21-bf57-4e44-8110-52c0929f1336"), "G.45.2", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f56b2ec5-b349-4663-9f87-bfa95187ef93"), "G.45.20", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Maintenance and repair of motor vehicles" },
                    { new Guid("f7bdc9c5-8deb-45f7-b8da-8439868bd9a1"), "G.45.3", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("b31d589b-5987-4a97-b1a7-a43ab4a8eb85"), "G.45.31", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("3524b753-f330-4d6e-b224-038592f190bd"), "G.45.32", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("7a4b8b05-45e3-4d1f-ab7b-4d34505945f8"), "G.45.4", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("531fbcb1-7eda-4bb7-a067-565ff092bdf9"), "G.45.40", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("ec5a798c-3495-4260-a2c4-5fc4d17c3c86"), "G.46", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("a637f067-b16b-4418-a2a9-47639c1a3d7e"), "G.46.1", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale on a fee or contract basis" },
                    { new Guid("ab9dfd44-d418-4497-b0f1-e29ebc94419e"), "G.46.11", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("89b53b30-bda2-4f3e-8ef2-9fbd3e2ae50c"), "G.46.12", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("2ce28d32-19af-432e-92a0-00cdf4e1c85e"), "G.46.13", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("2830c307-fc7f-4a9d-9fb7-7775a324c5dd"), "G.46.14", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("8c465a24-ce21-4d1a-9ce5-c16b38509449"), "G.46.5", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of information and communication equipment" },
                    { new Guid("f1f6c477-5de1-4b15-a504-b778db0609dd"), "G.47.81", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("34f597d9-1146-4459-ad83-bfec6f28852c"), "G.46.51", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("7cdbe998-699c-418e-a09f-f0d6fdd2b4f6"), "G.46.6", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("dc37f54b-fe82-45ad-a264-71078aab446a"), "G.47.4", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("9b59d62a-365a-4eaf-ad2a-6381f44514ae"), "G.47.41", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("ccf4c305-2329-45c7-ae74-791da7ae95c3"), "G.47.42", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("dc04fe5c-9cea-4d30-9ee9-c3f419e56959"), "G.47.43", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("233b9265-a2c5-4c16-af06-abe455746ed4"), "G.47.5", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("7319c790-9f99-4898-8be5-9b0c6d04a1cb"), "G.47.51", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of textiles in specialised stores" },
                    { new Guid("e2b6ac75-989e-4890-b846-154a4bba597f"), "G.47.52", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("5d349ed7-bd46-465d-9f5e-29b481b47bb7"), "G.47.53", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("1144d40b-7b81-4f61-8edc-5351b44aaac9"), "G.47.54", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("ad826ac6-678f-452e-bfca-b4406de25d43"), "G.47.59", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("928e46c0-4573-4e9a-a749-f21dbd1fa6f4"), "G.47.6", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("1c67ea21-cf3a-420e-ac11-202534495dca"), "G.47.61", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of books in specialised stores" },
                    { new Guid("7d9af2e5-6580-470a-b96f-85d34c4d24d5"), "G.47.30", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("b67c0cdd-f3e6-4bf3-9244-10de809ec87d"), "G.47.62", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("14ee63ab-7d7c-4596-bde1-6fe06176106e"), "G.47.64", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("74468848-25a8-4c6c-9a88-c0c6c015c827"), "G.47.65", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("46d9ffea-f434-4da6-a7b3-7997db7f7fc6"), "G.47.7", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of other goods in specialised stores" },
                    { new Guid("545e6148-bbcc-4255-883f-b83fac621de5"), "G.47.71", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of clothing in specialised stores" },
                    { new Guid("7a3893a9-5328-4109-b6b4-e9721413198d"), "G.47.72", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("642d912d-b643-4240-bcda-59d82bdfd30e"), "G.47.73", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Dispensing chemist in specialised stores" },
                    { new Guid("1d92f8b5-2c81-4702-9d17-94582f992386"), "G.47.74", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("9bc049e6-7f4c-4917-ba00-f69d6a3cc35d"), "G.47.75", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("4850af36-e784-4bb0-8728-01ef30aecc12"), "G.47.76", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("f20b040a-9792-446f-9b61-139c04a43478"), "G.47.77", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("4b959023-21e2-49f4-a9bb-dd92c1acac24"), "G.47.78", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("04bcbf1f-d33f-4113-b98d-326141c0c8fe"), "G.47.79", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7a24d472-5213-4539-96f0-fe574cff8bc6"), "G.47.63", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("32fe6b38-d6a9-4c37-adab-c3ace1ab6a54"), "G.47.3", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("8c2af1e7-cf2d-43e6-a216-18211bde8239"), "G.47.29", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Other retail sale of food in specialised stores" },
                    { new Guid("65641b8d-09ab-4160-8b03-1b88882c1f9a"), "G.47.26", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("91c3ba4d-827d-4a08-b76d-c25e01e4c67d"), "G.46.61", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("ec504846-efd3-42b6-ad91-d9dd047e6d14"), "G.46.62", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of machine tools" },
                    { new Guid("c09284d7-9ac3-4365-8f09-982a7653101c"), "G.46.63", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("bd424521-54f4-46d2-8807-951f0a8bbd51"), "G.46.64", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("2e556148-e97a-4dce-a515-80bf4a80ca96"), "G.46.65", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of office furniture" },
                    { new Guid("521f5058-152f-44b6-80d1-540bd98943e0"), "G.46.66", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of other office machinery and equipment" },
                    { new Guid("841fe7bb-58fb-4c39-8e68-d2fe4f4d0971"), "G.46.69", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of other machinery and equipment" },
                    { new Guid("1b805bda-eee4-4ea3-8f53-ec5a522c3ffc"), "G.46.7", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Other specialised wholesale" },
                    { new Guid("c5ee43ad-906d-451b-a091-ff184b59317e"), "G.46.71", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("b6c2750a-49f0-4fdd-a23f-67b7764885ca"), "G.46.72", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of metals and metal ores" },
                    { new Guid("b10879a2-0067-42b3-b0a3-ea902c66b3ac"), "G.46.73", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("dcb7e248-932f-46e5-87a3-17e21e054010"), "G.46.74", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("f415035b-b995-4073-a613-26b961df27bd"), "G.46.75", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of chemical products" },
                    { new Guid("ee555599-14fe-4edd-98f8-018c89c21456"), "G.46.76", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of other intermediate products" },
                    { new Guid("ee2e10f3-387a-4df0-b639-de5571c4cb18"), "G.46.77", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of waste and scrap" },
                    { new Guid("c5f12fe3-e85c-4ef5-8f52-b2c846590240"), "G.46.9", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Non-specialised wholesale trade" },
                    { new Guid("682b8223-3457-41d1-9ccc-9285091d3851"), "G.46.90", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Non-specialised wholesale trade" },
                    { new Guid("be71b1ed-ad5d-4220-b3df-5edfc74ec275"), "G.47", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("dd8a0eb6-5545-4052-ad7f-35c8c92c0956"), "G.47.1", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale in non-specialised stores" },
                    { new Guid("5b2aa95c-f2b8-4ff2-b5eb-86ceefeb2e78"), "G.47.11", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("b0ab74eb-9c1c-49a4-9bbd-004e5b3c1da5"), "G.47.19", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Other retail sale in non-specialised stores" },
                    { new Guid("ac4c646b-2863-411d-92f8-4b180872dc60"), "G.47.2", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("39b0e8a5-762e-458a-a687-beabc9ef0944"), "G.47.21", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("79c1155c-7d5b-40ea-b424-49e3bb5d0991"), "G.47.22", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("c9e76325-32e8-4a03-b6ab-4f232e824b32"), "G.47.23", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("d1f65d81-a94a-4237-9981-f189bcda861d"), "G.47.24", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("5049d4f0-1a98-4b38-a0dc-a14c47b35534"), "G.47.25", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Retail sale of beverages in specialised stores" },
                    { new Guid("ff22ac0a-7771-41df-8333-13928a8190e2"), "G.46.52", new Guid("d291b549-fb57-47ef-ba3b-e195e64d5e68"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("cdb1802b-afea-4dba-949d-ffb6b22f2858"), "F.43.22", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("7cb5fbed-fa7e-4f1b-b896-d175787a8ca3"), "K.64.99", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("42659f4a-6fe0-4d60-abcb-8b803f571f6b"), "K.65.1", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Insurance" },
                    { new Guid("2b6b0c1b-f0dd-4cc0-93a2-e91b3d6ebcb6"), "P.85.6", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Educational support activities" },
                    { new Guid("ee91449f-e9be-46d7-8ff7-f24ccad874e6"), "P.85.60", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Educational support activities" },
                    { new Guid("07148682-1add-4129-95ea-48478e74fd83"), "Q.86", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Human health activities" },
                    { new Guid("7a2846f0-029a-4723-b639-bc6732d47999"), "Q.86.1", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Hospital activities" },
                    { new Guid("0e9ea9ee-374a-4e4f-ab20-539fabdb74a8"), "Q.86.10", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Hospital activities" },
                    { new Guid("686b828a-fd7b-4956-9b53-00c73ab853d4"), "Q.86.2", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Medical and dental practice activities" },
                    { new Guid("7426f1fe-8990-41ba-a945-ffa0d212193d"), "Q.86.21", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("adbc0bb7-9838-4166-9677-3c01c49de1da"), "Q.86.22", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Specialist medical practice activities" },
                    { new Guid("4672d75e-3707-4dd1-a5f3-43f90af0f2fa"), "Q.86.23", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Dental practice activities" },
                    { new Guid("1fec860b-0049-4565-9e9f-793037194467"), "Q.86.9", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Other human health activities" },
                    { new Guid("8ff151b5-6cc9-4052-a3d9-8e3ba3ef2582"), "Q.86.90", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Other human health activities" },
                    { new Guid("d5447da0-1503-4a6b-85b6-89610d55a97f"), "Q.87", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential care activities" },
                    { new Guid("9dae7005-0a94-4452-9b5e-62f3702c1f44"), "P.85.59", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Other education n.e.c." },
                    { new Guid("b37a36eb-5aa1-4d9e-913f-0f51272649d6"), "Q.87.1", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential nursing care activities" },
                    { new Guid("a1b7dfc2-72af-46b6-8196-dc285cf845a6"), "Q.87.2", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("fe23f00e-ae0b-49d3-96d3-acc6fbf3fba2"), "Q.87.20", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("d0bed039-8a8d-4ee9-8226-3611ab58a53b"), "Q.87.3", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential care activities for the elderly and disabled" },
                    { new Guid("9eb778f5-279b-48e5-b327-6f67ad05ce3c"), "Q.87.30", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential care activities for the elderly and disabled" },
                    { new Guid("d8700035-de55-416e-b480-cc1bc2e5081e"), "Q.87.9", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Other residential care activities" },
                    { new Guid("57d364b1-0e1f-4a5c-9cca-725f454fd9d3"), "Q.87.90", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Other residential care activities" },
                    { new Guid("0069d3b1-eab9-4d8c-a54b-8aa98a149a85"), "Q.88", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Social work activities without accommodation" },
                    { new Guid("d4584eb3-4ba2-46fb-9575-1942334855bf"), "Q.88.1", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("3202bc49-aad2-416b-8480-d28f26f6aa63"), "Q.88.10", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("8052c198-3958-4a8d-be6e-c1929a5edec3"), "Q.88.9", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Other social work activities without accommodation" },
                    { new Guid("e29b3a76-1369-4fa3-8594-bee5ff4afa12"), "Q.88.91", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Child day-care activities" },
                    { new Guid("49666474-84ef-4679-bbd6-7a232f328334"), "Q.88.99", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("55f10253-4fde-4bd0-8eb6-d8c3d5b5d566"), "Q.87.10", new Guid("6e2492c3-f5fa-4063-85cb-d5fdc828a7c8"), "Residential nursing care activities" },
                    { new Guid("a9adc35e-07ff-4f6c-8066-d2d03c10794f"), "P.85.53", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Driving school activities" },
                    { new Guid("10401e9c-ceba-482f-b1fa-b96d6c8de01f"), "P.85.52", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Cultural education" },
                    { new Guid("62c79345-9165-4607-9e6f-ff06b1530fa0"), "P.85.51", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Sports and recreation education" },
                    { new Guid("a625a9f0-4c70-4648-af4e-d88bc624b954"), "N.82.91", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Packaging activities" },
                    { new Guid("90d98207-7222-46c2-a6d4-914101845cbe"), "N.82.99", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other business support service activities n.e.c." },
                    { new Guid("f04d2530-330e-4cda-ad8f-88c77d0dc825"), "O.84", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Public administration and defence; compulsory social security" },
                    { new Guid("398b6da8-6042-4910-8961-02c1f2f106a3"), "O.84.1", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("2e4e40ca-7f99-450f-b9ad-783a79418dfd"), "O.84.11", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "General public administration activities" },
                    { new Guid("f5704b69-320c-4e6b-a1d0-2226f9875721"), "O.84.12", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("451e9643-621b-4b13-a664-70fe9ae78095"), "O.84.13", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("5b09b86a-8352-4c03-bfaa-01d38c6e25da"), "O.84.2", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Provision of services to the community as a whole" },
                    { new Guid("cf083d58-4fbc-4418-911f-021684454566"), "O.84.21", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Foreign affairs" },
                    { new Guid("8d6fc52a-bc0f-4985-8d46-59993012b76d"), "O.84.22", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Defence activities" },
                    { new Guid("a8bae4e8-4164-4d1a-abdf-94a53ca07715"), "O.84.23", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Justice and judicial activities" },
                    { new Guid("0a846e59-1723-420d-8be6-0b2d9147dfbf"), "O.84.24", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Public order and safety activities" },
                    { new Guid("88f662d6-1572-4058-8b52-faf6e16b6a5b"), "O.84.25", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Fire service activities" },
                    { new Guid("e531b864-60d0-4f9f-936d-5667566947d3"), "O.84.3", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Compulsory social security activities" },
                    { new Guid("4c74750c-8b48-4f64-8803-fde10e085377"), "O.84.30", new Guid("136cc7b0-a06d-4334-a22f-e1b9c3d9c6cf"), "Compulsory social security activities" },
                    { new Guid("03d4eaea-9b71-4c3b-8403-f9e9202c0fb4"), "P.85", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Education" },
                    { new Guid("4b8cb515-4a71-4b25-8b33-fce475ee3b63"), "P.85.1", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Pre-primary education" },
                    { new Guid("06d50cfc-6c79-49a7-bc3e-a1b2d6c6eaa9"), "P.85.10", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Pre-primary education" },
                    { new Guid("dac95b23-d7ed-4494-a9c3-c586bc1d95dc"), "P.85.2", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ec62007a-4fd5-4a45-a159-486ac911c520"), "P.85.20", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Primary education" },
                    { new Guid("1a693e34-884f-48c9-beb3-1369e80b0c80"), "P.85.3", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Secondary education" },
                    { new Guid("869de486-a58c-4be9-95b1-147116f9a8a0"), "P.85.31", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "General secondary education" },
                    { new Guid("c83f118f-7ccd-456e-8e13-e4835dc713e5"), "P.85.32", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Technical and vocational secondary education" },
                    { new Guid("4fb101e5-96f1-4906-8aaf-fa03a44c5495"), "P.85.4", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Higher education" },
                    { new Guid("3bd356ec-c20c-4db5-9422-2a52b9b3f5d3"), "P.85.41", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Post-secondary non-tertiary education" },
                    { new Guid("de6c7f95-349d-4e2c-a10a-5c9bf270db10"), "P.85.42", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Tertiary education" },
                    { new Guid("a9009843-e19e-4e03-8fdb-4d78023e017a"), "P.85.5", new Guid("0214d3cc-7431-4867-b6bc-081f3977dc28"), "Other education" },
                    { new Guid("b2a18b22-afa6-4b6c-93e3-497ef0f1dccf"), "R.90", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Creative, arts and entertainment activities" },
                    { new Guid("99751e80-ec5a-41f2-9f17-798aa37f4ac0"), "N.82.92", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("6835ae42-9e45-4c54-9d98-3371643f024e"), "R.90.0", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Creative, arts and entertainment activities" },
                    { new Guid("0f06ff47-8673-4b23-81e0-6cd898096700"), "R.90.02", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Support activities to performing arts" },
                    { new Guid("b8971ecd-8a74-4f2d-97f0-ba079e15188b"), "S.95.1", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of computers and communication equipment" },
                    { new Guid("0a411886-5aeb-4974-9d08-92e829b6aabf"), "S.95.11", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of computers and peripheral equipment" },
                    { new Guid("1bdc066d-7f08-4e52-82a6-b673d3c43384"), "S.95.12", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of communication equipment" },
                    { new Guid("d53a36f2-0cc6-4649-939b-f03b9602d4d2"), "S.95.2", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of personal and household goods" },
                    { new Guid("9243ab4f-d0e6-454f-847f-b28083b86663"), "S.95.21", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of consumer electronics" },
                    { new Guid("3036c441-b5ae-42b6-9289-a2f75f075b25"), "S.95.22", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("e79b09f4-f155-452e-862c-607500a52e87"), "S.95.23", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of footwear and leather goods" },
                    { new Guid("39e14849-cdbc-4862-b241-fdd3814245bf"), "S.95.24", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of furniture and home furnishings" },
                    { new Guid("6e01f6de-f3fc-4eda-a01b-f7710fe98625"), "S.95.25", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of watches, clocks and jewellery" },
                    { new Guid("db26e3b0-2354-4d39-8ffe-d7a0710e6ff7"), "S.95.29", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of other personal and household goods" },
                    { new Guid("b9871e9f-1f63-4851-b01a-631c5f017f77"), "S.96", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Other personal service activities" },
                    { new Guid("1eac3821-1a30-4251-b039-6ea925a86629"), "S.96.0", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Other personal service activities" },
                    { new Guid("d08fc353-8c71-4928-899c-90fe186f854a"), "S.95", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Repair of computers and personal and household goods" },
                    { new Guid("e7763615-cb37-414f-b41f-ccfda35769c7"), "S.96.01", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("7690d033-d0b4-4337-b73d-ba33fef197f9"), "S.96.03", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Funeral and related activities" },
                    { new Guid("04867ebf-cccb-495e-af72-40b4d82d053c"), "S.96.04", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Physical well-being activities" },
                    { new Guid("d6f0a1cb-7f24-4934-8b03-4f0c32f66de3"), "S.96.09", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Other personal service activities n.e.c." },
                    { new Guid("8d70b4d2-06f6-47df-98ce-8a5508fbecd5"), "T.97", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Activities of households as employers of domestic personnel" },
                    { new Guid("d2709049-b075-44ea-b4e7-53ef99b0ffc9"), "T.97.0", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Activities of households as employers of domestic personnel" },
                    { new Guid("6b911e36-8510-4ce0-8890-ab3b26bffaa7"), "T.97.00", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Activities of households as employers of domestic personnel" },
                    { new Guid("f536b648-a192-4297-a106-5606e90a5e0e"), "T.98", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("20e359fb-f78f-4ce5-9c8d-7c1daec848da"), "T.98.1", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("672cc701-66f7-4fb9-bce7-2369feff7291"), "T.98.10", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("5e35c0ba-0120-475c-b7d9-e0c57029c04b"), "T.98.2", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("b86857b4-ef04-44fb-bb26-76b2e9e1625f"), "T.98.20", new Guid("dffe9b5a-be2d-4893-96e9-836ff5b2630e"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("2283b821-3a34-44ce-998e-64bb6daf5705"), "U.99", new Guid("e3d2ecf6-4460-4227-980d-a244cff02f80"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("ca4e0cd7-600c-4fa9-b9fa-d6fd0f7fd2e0"), "S.96.02", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Hairdressing and other beauty treatment" },
                    { new Guid("513858b8-b122-4926-a31f-c8bc34f82818"), "S.94.99", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of other membership organisations n.e.c." },
                    { new Guid("1d6e2d42-b569-4a02-b0d1-db96f47c614b"), "S.94.92", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of political organisations" },
                    { new Guid("499cf900-89aa-4418-8f1d-40d870231bd4"), "S.94.91", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d3110d92-3118-4770-bec3-355f3788564e"), "R.90.03", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Artistic creation" },
                    { new Guid("90a5177e-c10f-4162-aaa1-6b5783e01188"), "R.90.04", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Operation of arts facilities" },
                    { new Guid("5350cacc-3863-4ec4-8b67-57b9ed8e5f61"), "R.91", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("240c39f9-114d-4f81-902c-7c8283d01e99"), "R.91.0", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("11283fbb-d00b-4e41-a193-62f0c1121bd4"), "R.91.01", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Library and archives activities" },
                    { new Guid("b63b0031-acc1-4e52-8686-4c9f8218d09d"), "R.91.02", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Museums activities" },
                    { new Guid("d77d9787-7cc7-4ba1-b53b-7b552d63fe99"), "R.91.03", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("7b831c3a-b6f0-4e5f-8655-fe6fc7bfbc57"), "R.91.04", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("ffab0564-3c6e-4725-892d-dec784a37206"), "R.92", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Gambling and betting activities" },
                    { new Guid("e9687418-5fc5-414a-a7a4-8730678e347b"), "R.92.0", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Gambling and betting activities" },
                    { new Guid("4546e217-9195-4108-8bbf-e21985e7e6b7"), "R.92.00", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Gambling and betting activities" },
                    { new Guid("fbbb6107-722e-4ed8-9061-48459fd6e293"), "R.93", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Sports activities and amusement and recreation activities" },
                    { new Guid("88d6a6f1-637c-4920-b9bb-fd26d23e6678"), "R.93.1", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Sports activities" },
                    { new Guid("2e9edbf3-2f68-4b68-ac99-b661ed971f81"), "R.93.11", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Operation of sports facilities" },
                    { new Guid("12d7254c-4928-4012-817d-da473e0fede4"), "R.93.12", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Activities of sport clubs" },
                    { new Guid("3afa4303-a9b5-4754-b0b5-b1de4174c54a"), "R.93.13", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Fitness facilities" },
                    { new Guid("c9ac120a-6b6d-46be-9e63-8420ff30993b"), "R.93.19", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Other sports activities" },
                    { new Guid("2e54ae54-12ae-4614-8942-f5dcc4f16ed5"), "R.93.2", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Amusement and recreation activities" },
                    { new Guid("0ea92f91-415d-463b-a36a-f45e588d9bd6"), "R.93.21", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Activities of amusement parks and theme parks" },
                    { new Guid("fa2ad490-f624-43e4-bddf-a2b738bc775c"), "R.93.29", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Other amusement and recreation activities" },
                    { new Guid("d9299e4e-1e62-48f6-bf5e-d9491b3daeae"), "S.94", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of membership organisations" },
                    { new Guid("bb7f8df6-4eec-473e-bb0a-f417d419e92c"), "S.94.1", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("0e5943b7-93f5-4740-8c79-062bb0ad5e31"), "S.94.11", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of business and employers membership organisations" },
                    { new Guid("e92784a7-85a1-4153-a00a-00f3f9a64a65"), "S.94.12", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of professional membership organisations" },
                    { new Guid("fb42ada8-f7e1-481e-b090-a2f7b4493e93"), "S.94.2", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of trade unions" },
                    { new Guid("766c14ba-1303-4cdf-ae38-fcd6454c8603"), "S.94.20", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of trade unions" },
                    { new Guid("6e7d5b07-4182-4b93-bcad-f6504b660961"), "S.94.9", new Guid("5b943e67-bfc7-4a55-aa52-2bb9ffbcecee"), "Activities of other membership organisations" },
                    { new Guid("82c77c02-30b1-479d-a58e-e4b6e604d6f1"), "R.90.01", new Guid("5014d410-6bf0-4891-b0c0-287a41ae3f4c"), "Performing arts" },
                    { new Guid("5424039e-c724-4ea9-ba0d-f538ba86218c"), "K.65", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("f668a1f1-3b13-4af8-a87f-6f839761b0c6"), "N.82.9", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Business support service activities n.e.c." },
                    { new Guid("0c28145e-e857-4167-b5ff-089b968091ce"), "N.82.3", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Organisation of conventions and trade shows" },
                    { new Guid("d95510e5-430a-46d5-ae57-6e77145cc8e4"), "M.70.1", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Activities of head offices" },
                    { new Guid("be9ae874-4e16-47bf-bf70-51ebf7d1f7a2"), "M.70.10", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Activities of head offices" },
                    { new Guid("91544500-3f60-48d9-88ef-4a15c57916fb"), "M.70.2", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Management consultancy activities" },
                    { new Guid("738160a6-4dd2-4381-a9b2-12220ea746fb"), "M.70.21", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Public relations and communication activities" },
                    { new Guid("c6e2bce5-80d3-4dbc-bad8-b876ada40d62"), "M.70.22", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Business and other management consultancy activities" },
                    { new Guid("052ed295-2c2f-466e-9b8b-d257d2297949"), "M.71", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("1d756ac0-5a14-423f-854f-6aa6adfd9521"), "M.71.1", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("3d28219e-9020-48f1-b114-ca5911c537e1"), "M.71.11", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Architectural activities" },
                    { new Guid("ab9b23a0-b92f-4747-8901-7876ec18425c"), "M.71.12", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Engineering activities and related technical consultancy" },
                    { new Guid("a507e7f0-9d09-41f5-aa1f-18459304065c"), "M.71.2", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Technical testing and analysis" },
                    { new Guid("77b4b628-378b-459d-a8de-dd4e13c4061e"), "M.71.20", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("079800f3-7b98-4542-8337-5ccb0fa09a07"), "M.72", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Scientific research and development" },
                    { new Guid("93ccac98-60e1-4708-8575-b051765e292a"), "M.70", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Activities of head offices; management consultancy activities" },
                    { new Guid("a5133371-d847-45ed-9ba9-acf83be0aa13"), "M.72.1", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("c9ff0ced-eb36-43fc-853b-8bf875341db2"), "M.72.19", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("fdaa1569-33d6-4128-974b-6c130133dfb2"), "M.72.2", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("0cd2c555-10c5-4f21-b310-ef12f5038c1f"), "M.72.20", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("6377f80e-6c45-4732-a74e-ad504b1d416b"), "M.73", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Advertising and market research" },
                    { new Guid("3c166649-1a15-45c2-b4e2-9c18122bf937"), "M.73.1", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Advertising" },
                    { new Guid("482828ca-1955-43c2-9d5b-ad4d25fbed32"), "M.73.11", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Advertising agencies" },
                    { new Guid("c97158ce-c29c-4e5d-8f9a-e8a057c72b16"), "M.73.12", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Media representation" },
                    { new Guid("bfaa364b-b3c4-46ac-941f-70dab1f8ed05"), "M.73.2", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Market research and public opinion polling" },
                    { new Guid("6ebaf694-53ba-4fc3-b3c3-f81bafaefc47"), "M.73.20", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Market research and public opinion polling" },
                    { new Guid("5bba2fde-ccab-450d-988a-c1dd2d1a8427"), "M.74", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Other professional, scientific and technical activities" },
                    { new Guid("9fc72d62-f224-4e58-bcdd-00db4c90873e"), "M.74.1", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Specialised design activities" },
                    { new Guid("05806f24-0717-4d4e-9c36-a6b19b613b6e"), "M.74.10", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Specialised design activities" },
                    { new Guid("b18616f5-9b67-4299-a43d-8896629fb99f"), "M.72.11", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Research and experimental development on biotechnology" },
                    { new Guid("c775cc92-e6e3-4069-a90b-38c618c6ec94"), "M.69.20", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("2b4d803b-255c-469d-9405-7d1dd96028fc"), "M.69.2", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("b969f767-2efd-4dc5-8d2d-517ab41b0ed6"), "M.69.10", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Legal activities" },
                    { new Guid("86522252-df5a-4dbb-a6bd-69965f0e87e1"), "K.65.11", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Life insurance" },
                    { new Guid("7abccc1e-a596-4c87-a397-0484a1071b83"), "K.65.12", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Non-life insurance" },
                    { new Guid("45c0242f-eb76-41e4-9fb2-82efec459f9a"), "K.65.2", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Reinsurance" },
                    { new Guid("e1019e25-cba6-46f4-849d-75feca3de333"), "K.65.20", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Reinsurance" },
                    { new Guid("bc5322ca-87d3-44f4-9d2b-6f6d825e3aba"), "K.65.3", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Pension funding" },
                    { new Guid("7c7fac7e-54d2-4512-9b89-3eb686d2a593"), "K.65.30", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Pension funding" },
                    { new Guid("e30b8569-8f84-4fcf-8ca5-17f8c22b9285"), "K.66", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("b57bed84-c94a-4434-bf15-2c82678e4b4d"), "K.66.1", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("54d8c19c-b4d6-4507-98a4-639d63e27bac"), "K.66.11", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Administration of financial markets" },
                    { new Guid("949889dc-7150-4999-b996-2f8eb86eca94"), "K.66.12", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Security and commodity contracts brokerage" },
                    { new Guid("1043b2b5-578e-4139-92bd-7374647a2d8f"), "K.66.19", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("12bf5204-87e5-4f95-afb4-36cb21f9859a"), "K.66.2", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("f70839bc-597d-4fb4-b23b-8492896ccee8"), "K.66.21", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Risk and damage evaluation" },
                    { new Guid("555a5574-1689-4b75-a743-f0a73ccf475d"), "K.66.22", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Activities of insurance agents and brokers" },
                    { new Guid("e0b705e1-ecc1-4197-b79e-fb9ba7c86b19"), "K.66.29", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("420c20ef-9778-48b7-a4d7-fc54d195b7d1"), "K.66.3", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Fund management activities" },
                    { new Guid("cac1de3c-711a-4052-9fc6-2abb89b5d70e"), "K.66.30", new Guid("a5189292-0b18-43e5-945a-f314c375d8a3"), "Fund management activities" },
                    { new Guid("052ee3f0-7e6c-42bc-b5d8-b8ee7b9f8646"), "L.68", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Real estate activities" },
                    { new Guid("3e107779-dd52-4365-99df-520a58d9fe96"), "L.68.1", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Buying and selling of own real estate" },
                    { new Guid("b059ea43-8f1d-45b1-b7c1-f9447ab5db02"), "L.68.10", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Buying and selling of own real estate" },
                    { new Guid("076995ac-3127-4743-b543-ef33d87cacdf"), "L.68.2", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Renting and operating of own or leased real estate" },
                    { new Guid("f87d315b-448d-4b5b-ab12-23c575dce8d7"), "L.68.20", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Renting and operating of own or leased real estate" },
                    { new Guid("3c55aa3e-c80f-497e-92a7-0cddcb75751c"), "L.68.3", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("05000602-cfcb-4373-86a3-d26f01fcb164"), "L.68.31", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Real estate agencies" },
                    { new Guid("479dce9a-4507-4a9f-8b3e-859ad08ac68b"), "L.68.32", new Guid("1cb8a965-ac54-43b1-bce6-ba5e4ad5197a"), "Management of real estate on a fee or contract basis" },
                    { new Guid("31706b11-033f-4fdb-996b-220ae7444a5d"), "M.69", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Legal and accounting activities" },
                    { new Guid("34bac1ef-c735-4b8e-a59f-7fa6dd550992"), "M.69.1", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Legal activities" },
                    { new Guid("e44561c3-df59-49f9-b884-e0fa36ce425b"), "M.74.2", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Photographic activities" },
                    { new Guid("9342ef45-212e-4ba3-9e3b-e9464cd10358"), "N.82.30", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Organisation of conventions and trade shows" },
                    { new Guid("893015e1-4a87-45ef-946b-77b4e812d45a"), "M.74.20", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Photographic activities" },
                    { new Guid("14116923-c3ea-468c-b7e9-ff81df330ccf"), "M.74.30", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Translation and interpretation activities" },
                    { new Guid("35385cc5-b1ef-48d0-9c0a-771e65c33607"), "N.79.11", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Travel agency activities" },
                    { new Guid("cf84b13a-9e65-481f-a9cc-47c74636f544"), "N.79.12", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Tour operator activities" },
                    { new Guid("f47931f7-bd35-4d6e-8191-968902ef0fd8"), "N.79.9", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other reservation service and related activities" },
                    { new Guid("628b3947-5dc5-40e1-9e92-d72bd92ac6f9"), "N.79.90", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other reservation service and related activities" },
                    { new Guid("f25d95cb-7c08-45fc-a428-aa8972d30ae1"), "N.80", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Security and investigation activities" },
                    { new Guid("c3758bed-5ff2-4a21-9911-3cd8c715e649"), "N.80.1", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Private security activities" },
                    { new Guid("0627d657-6cea-41fb-85a5-92c0c3ab2955"), "N.80.10", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Private security activities" },
                    { new Guid("bd0df690-c988-4cb6-9d40-8902a87eb86e"), "N.80.2", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Security systems service activities" },
                    { new Guid("3e55bc9f-95f3-4604-9437-828777d5042d"), "N.80.20", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Security systems service activities" },
                    { new Guid("f6c5d0ab-49ab-407c-b70d-f182dc9c0b46"), "N.80.3", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Investigation activities" },
                    { new Guid("2c50e393-8972-4e5a-9b39-7e16a85fc742"), "N.80.30", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Investigation activities" },
                    { new Guid("8309cdd1-0d92-4c0d-a3e5-e3b80ab8a555"), "N.81", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Services to buildings and landscape activities" },
                    { new Guid("2c7adb15-5954-4b31-8a61-7f577270e3c2"), "N.79.1", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Travel agency and tour operator activities" },
                    { new Guid("31cc0a88-0c57-4bd1-8036-9a9e60fdfdfb"), "N.81.1", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Combined facilities support activities" },
                    { new Guid("7129dfd8-e2ff-41cc-8bf3-e11bcf03b286"), "N.81.2", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Cleaning activities" },
                    { new Guid("ec3861b2-4382-4731-a91b-738e8123d88a"), "N.81.21", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "General cleaning of buildings" },
                    { new Guid("09bdde0b-304e-467d-9333-9f7f5d6a85df"), "N.81.22", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other building and industrial cleaning activities" },
                    { new Guid("54a25246-ff79-4747-b939-c86c2bf73df1"), "N.81.29", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other cleaning activities" },
                    { new Guid("90108339-5495-46c7-a0d5-17649bdbfb6a"), "N.81.3", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Landscape service activities" },
                    { new Guid("fdb28dbb-6695-48b2-907a-bf336ff5280d"), "N.81.30", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Landscape service activities" },
                    { new Guid("984c2f74-46d1-4bed-b619-08b072472f06"), "N.82", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Office administrative, office support and other business support activities" },
                    { new Guid("febfb183-16b4-4b33-af75-1282e89e0305"), "N.82.1", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Office administrative and support activities" },
                    { new Guid("71ffac69-cbe2-4299-b1c6-7e0a21fc820f"), "N.82.11", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Combined office administrative service activities" },
                    { new Guid("88e66a1c-b3c5-4249-a48e-8f0dfc90cfef"), "N.82.19", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("1a7a83da-5683-4b48-be14-435b49ae6690"), "N.82.2", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Activities of call centres" },
                    { new Guid("6ce8379d-2622-4c58-8cb0-ab38e5235b76"), "N.82.20", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Activities of call centres" },
                    { new Guid("6eafbd9b-9605-4189-9e8a-c09fa00a0301"), "N.81.10", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Combined facilities support activities" },
                    { new Guid("86d45e9a-a6fa-4cd4-b1ac-613fa8f533d4"), "N.79", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("ebefdf90-1da8-4802-8730-66a0bf372d02"), "N.78.30", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other human resources provision" },
                    { new Guid("7f72d3ef-3a7e-404f-aa43-624a9c716365"), "N.78.3", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Other human resources provision" },
                    { new Guid("655c2d5e-49df-49a4-8ee2-f699ea133187"), "M.74.9", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("b839b97f-2188-4512-a927-f0907d51f099"), "M.74.90", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("3aa75dd9-e3ad-424a-8c79-3fee32960a10"), "M.75", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Veterinary activities" },
                    { new Guid("6ae1184f-f408-446c-b0c8-296891c4969d"), "M.75.0", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7636ac82-691d-46c4-97eb-53e5e13e536a"), "M.75.00", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Veterinary activities" },
                    { new Guid("54b69285-8f13-4a97-a191-7fcf032e759d"), "N.77", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Rental and leasing activities" },
                    { new Guid("0a22cbed-3d36-4faf-b096-715cd1948705"), "N.77.1", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of motor vehicles" },
                    { new Guid("66af557c-e95d-423c-91fb-1dfacb9378de"), "N.77.11", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("05b720e1-570b-4bac-a311-bfc5009eee4a"), "N.77.12", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of trucks" },
                    { new Guid("b88dac1e-5fe2-4b63-8655-29bc89e7bea6"), "N.77.2", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of personal and household goods" },
                    { new Guid("f14bdb26-b914-4bf3-a928-542c3ac2a392"), "N.77.21", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("5e10b053-343a-43ef-93b5-1718696030d4"), "N.77.22", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting of video tapes and disks" },
                    { new Guid("2cb33e49-1892-4476-8899-156240230b8f"), "N.77.29", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of other personal and household goods" },
                    { new Guid("a6cda9e9-a4b7-4e73-b92b-78737b7adf14"), "N.77.3", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("31c3f3ce-dd01-43e6-b9e5-4ec20d88fef3"), "N.77.31", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("ce9ca858-50a4-4e19-ade4-3668eb4379b6"), "N.77.32", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("02372be4-6300-4d48-a330-0b31f336eb33"), "N.77.33", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("3615fd0c-02ce-4f66-ba13-3975f745e633"), "N.77.34", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of water transport equipment" },
                    { new Guid("a486ba29-dcd3-4433-8861-1d2ce0c7298b"), "N.77.35", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of air transport equipment" },
                    { new Guid("50cb178e-9e71-42ac-adcf-198d59f3ad22"), "N.77.39", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("20ce1016-aa1a-49e6-9382-e8165ce02e06"), "N.77.4", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("823fe3ea-fbe4-485a-adea-b0de978b5a50"), "N.77.40", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("ba2ab008-9192-48f3-8bc4-a9aa83bdd448"), "N.78", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Employment activities" },
                    { new Guid("9d72829c-c80a-4f0d-8482-0bec9d151c2c"), "N.78.1", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Activities of employment placement agencies" },
                    { new Guid("ea25d043-3ff1-4b95-8ac9-1b488c20fc26"), "N.78.10", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Activities of employment placement agencies" },
                    { new Guid("ed645782-ea46-48a3-898b-0c0c468eee05"), "N.78.2", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Temporary employment agency activities" },
                    { new Guid("93923b44-cb5a-4ff3-99a1-c364faf6430e"), "N.78.20", new Guid("a0c3fb4e-4e3b-4f33-84a8-e062028abfc9"), "Temporary employment agency activities" },
                    { new Guid("0c4f9245-76b8-45f7-b84e-408f8d866eaa"), "M.74.3", new Guid("e3c4786e-7c86-49c5-aae2-775bbb4c25fd"), "Translation and interpretation activities" },
                    { new Guid("d821a440-7b88-4438-8149-cbee5d1efddb"), "U.99.0", new Guid("e3d2ecf6-4460-4227-980d-a244cff02f80"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("520f09f7-37c4-4950-b2ed-76041b7ecdfa"), "F.43.21", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Electrical installation" },
                    { new Guid("f377d931-557a-40a9-baf2-25a803784849"), "F.43.13", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Test drilling and boring" },
                    { new Guid("b657238d-858d-4384-af06-010bd9f98f18"), "C.14.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of articles of fur" },
                    { new Guid("9ae690ea-9a5a-4059-b884-ee8f822cce7e"), "C.14.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of articles of fur" },
                    { new Guid("8b248ef9-5491-436e-a992-83fe6d2c3cba"), "C.14.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("41ccad95-d877-4e6b-84d5-fde3b2ee347e"), "C.14.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("e54f84ef-d6e9-47a3-a509-81945e49c84a"), "C.14.39", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("229bf43a-3573-468f-a20b-8084741d86f5"), "C.15", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of leather and related products" },
                    { new Guid("e3971655-8678-4cf5-a62c-aed6f0afbf73"), "C.15.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("16ac2d7a-675c-40ad-a7fd-a35f3567c9f7"), "C.15.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("223cfc4c-786c-4847-9744-fe89b254226a"), "C.15.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("5e3e0003-5810-429e-8045-3ac133a76196"), "C.15.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of footwear" },
                    { new Guid("a3d462e1-10a0-4b1d-b306-07f8ddb2d1aa"), "C.15.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of footwear" },
                    { new Guid("4f13f2ac-0ac9-4c83-90ee-a3449bf4409e"), "C.16", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("cb6933b0-7763-4594-9e82-d01212b91bbb"), "C.14.19", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("0a2b3bdc-96c9-4a31-baaa-8e4e29617594"), "C.16.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Sawmilling and planing of wood" },
                    { new Guid("e1141252-9fe2-40c7-a563-55f1c2370c84"), "C.16.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("312f4ee0-7545-443f-8909-7a35bbf12909"), "C.16.21", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("29b7ac19-f7c8-4444-9ce0-c3bc9d0c0e09"), "C.16.22", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of assembled parquet floors" },
                    { new Guid("6ace5bc5-f7c0-4897-9062-b7a8987c4301"), "C.16.23", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("99f9fd07-7bf3-48c9-bec2-03791b5db0e7"), "C.16.24", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wooden containers" },
                    { new Guid("c9308032-85f3-44f5-a7d8-10e3ada96243"), "C.16.29", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("0c8f3ee1-d94a-4090-be1e-6b11113471c0"), "C.17", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of paper and paper products" },
                    { new Guid("98b11964-280b-4e98-b972-3ecd9e6fab91"), "C.17.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("088967df-ed6f-49df-a169-d9faa0010ae6"), "C.17.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of pulp" },
                    { new Guid("cbd7c6ad-b919-49d3-bf9e-070c97896e5c"), "C.17.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of paper and paperboard" },
                    { new Guid("ddbaa72f-076d-4cd5-bc11-f3cee5824e0d"), "C.17.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("d126da4c-0648-42d7-853e-70ccf8e09087"), "C.17.21", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("5f308c1b-01c9-4bb3-a57b-5fc5c2233754"), "C.16.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Sawmilling and planing of wood" },
                    { new Guid("70a2068b-3cfe-4f92-8e9b-0390e9941836"), "C.14.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of underwear" },
                    { new Guid("0ccd78e7-488a-4f22-9c00-83e36d223c34"), "C.14.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other outerwear" },
                    { new Guid("0fd8fb93-84d8-4479-8c08-7fe860e26ec0"), "C.14.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of workwear" },
                    { new Guid("5c4b3443-05a8-41c1-a71c-fe1b96c87582"), "C.11.02", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wine from grape" },
                    { new Guid("fb0d5b0b-9ea0-4d76-a576-24310c1f40b8"), "C.11.03", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cider and other fruit wines" },
                    { new Guid("45c4edbd-11cb-4cf4-80d3-f56089dcde0d"), "C.11.04", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("c2707416-b451-49a1-bbd5-0dbf9b5b4b59"), "C.11.05", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of beer" },
                    { new Guid("dc426a69-db3d-43e8-b76b-fef9c60e9f8c"), "C.11.06", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of malt" },
                    { new Guid("6c0efdc8-2893-45f0-89d1-9dc9ebb1042f"), "C.11.07", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("1584617a-dd1e-41ee-8be6-cd88336ff666"), "C.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tobacco products" },
                    { new Guid("1d1aaefa-1f72-4fd9-8282-58bfd43293c5"), "C.12.0", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tobacco products" },
                    { new Guid("8c724dd6-a15d-4705-a4b9-bac923df2fa4"), "C.12.00", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tobacco products" },
                    { new Guid("19823354-083d-4cb1-a00c-6a033e921666"), "C.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of textiles" },
                    { new Guid("ec4509e7-a26b-447e-9927-57579d952444"), "C.13.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Preparation and spinning of textile fibres" },
                    { new Guid("a6ba6f3a-c65e-4fce-916a-ac3688d97f58"), "C.13.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Preparation and spinning of textile fibres" },
                    { new Guid("9e17fa88-fd5f-4313-86a3-d0ab56a490fd"), "C.13.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Weaving of textiles" },
                    { new Guid("117db624-f83c-4ae3-ae8b-c102a4f78299"), "C.13.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Weaving of textiles" },
                    { new Guid("d3f97bdf-0adb-4add-8540-8f56de65525e"), "C.13.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Finishing of textiles" },
                    { new Guid("f3016157-f577-4ef6-9173-9b18cf6f871f"), "C.13.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Finishing of textiles" },
                    { new Guid("b826769d-2940-4898-bfbc-d970acb56540"), "C.13.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other textiles" },
                    { new Guid("fa766ebe-8a25-4550-8187-eba19b1ceaec"), "C.13.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("6cd2cbac-6e89-40a9-8e3f-272eac3bafa8"), "C.13.92", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("2bb16321-7d3d-496c-8e60-1cca13dc5230"), "C.13.93", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of carpets and rugs" },
                    { new Guid("d3279a9d-ad9f-46dc-9eeb-0f2b586da68a"), "C.13.94", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("ba93563f-9077-4d14-ac02-68cda02a8eba"), "C.13.95", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("974751e8-d820-4169-9f3c-84a2b475addd"), "C.13.96", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("f370a5cc-ea5f-48ae-80e0-aa05e52e640e"), "C.13.99", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other textiles n.e.c." },
                    { new Guid("60edf0d4-840c-4545-b21e-16c200706f14"), "C.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wearing apparel" },
                    { new Guid("cff6f079-064e-4fff-bbfa-9f248bbe4495"), "C.14.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("0da058cf-bda9-471c-8e83-0d9a7d51e2dc"), "C.14.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("ae7ca309-257f-4a53-8308-36804ccd11bb"), "C.17.22", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("f9d7732e-ce91-4548-9b92-97eb7ee752ee"), "C.11.01", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("7739acc9-c6ea-4f41-a70d-c42cf8eae084"), "C.17.23", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of paper stationery" },
                    { new Guid("5e069474-c5c1-4eb7-9f9d-1cbb5861d70d"), "C.17.29", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("3c8dc766-99b4-49d0-986b-27228569f5c3"), "C.20.52", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of glues" },
                    { new Guid("3adf594d-b107-457a-9463-2d582601f23b"), "C.20.53", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of essential oils" },
                    { new Guid("b316e6a8-c33e-4d8b-a2be-16c2a0f9d893"), "C.20.59", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("fbc0ebcb-30b9-45ec-a47a-b03a1da87114"), "C.20.6", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of man-made fibres" },
                    { new Guid("94eba13a-f8f3-4018-ae70-1c9b06075770"), "C.20.60", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of man-made fibres" },
                    { new Guid("2f766a5c-e5ad-4256-a7d8-516aeb337de4"), "C.21", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("389e063d-1498-403a-888d-163135f032eb"), "C.21.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("71f80417-e178-4f2e-be7a-10930960743d"), "C.21.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("b0df6da3-0d3e-40a1-9633-a70a559a7a71"), "C.21.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("9870179a-d792-4f61-a603-8786aa3a7f03"), "C.21.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("ccbdfa37-0c3d-460e-a529-ac39539782fc"), "C.22", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of rubber and plastic products" },
                    { new Guid("358140ae-6c13-480b-957a-5b7d75e88cb4"), "C.22.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of rubber products" },
                    { new Guid("0afc4711-e422-4453-a73f-9a00f7a23a5f"), "C.20.51", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of explosives" },
                    { new Guid("7481b83d-a78c-4a6c-8146-26993cdd6e93"), "C.22.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("f695b7fe-bcda-4e09-acc0-7ff37a828f80"), "C.22.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of plastics products" },
                    { new Guid("1cbfd60b-74b5-4116-9d93-249c7de598f3"), "C.22.21", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("1c5a9ec8-008a-4014-9b75-9ea70ec233bb"), "C.22.22", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of plastic packing goods" },
                    { new Guid("9bda6801-a826-4202-a894-ebbb16ecfb7d"), "C.22.23", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("c35f5fe4-5abd-4d8c-b73c-e9e949e57ea2"), "C.22.29", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other plastic products" },
                    { new Guid("554d3de6-7174-4d9e-ba28-fc7eb86df5b7"), "C.23", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("9b3a2160-f5f2-4874-bdd9-3b11e9c0e12d"), "C.23.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of glass and glass products" },
                    { new Guid("51282010-0687-4152-ac4e-3de23560f767"), "C.23.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of flat glass" },
                    { new Guid("bf4cebdf-6c99-4afb-954b-f9497b601d03"), "C.23.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Shaping and processing of flat glass" },
                    { new Guid("1c1064c1-16b7-4861-8293-04431735be74"), "C.23.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of hollow glass" },
                    { new Guid("b60b5643-6be8-49cd-a5fa-87aee9a931aa"), "C.23.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of glass fibres" },
                    { new Guid("a1e4a0e1-9763-4d1d-906a-72104d7be060"), "C.23.19", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("d6d92ea5-6b36-446d-be91-99854f230513"), "C.22.19", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other rubber products" },
                    { new Guid("85305d85-57d6-43b9-940f-c0a9f0486de2"), "C.20.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other chemical products" },
                    { new Guid("1010e8b6-793e-4fe9-84e2-0d16fffc4a81"), "C.20.42", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("361152dd-5e1e-4767-addc-03268f23e2ca"), "C.20.41", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("1d8a5669-3fb0-4ec1-b97b-b730d0880506"), "C.18", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Printing and reproduction of recorded media" },
                    { new Guid("59ed4399-bbdc-4755-8577-db3dea18f5d1"), "C.18.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Printing and service activities related to printing" },
                    { new Guid("aa573e08-7dcd-4f38-a967-9de9b36b8d7a"), "C.18.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Printing of newspapers" },
                    { new Guid("13b7fba1-dc04-4422-b160-79c157276d22"), "C.18.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Other printing" },
                    { new Guid("7d083477-af73-4d57-af7d-9090b08eca94"), "C.18.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Pre-press and pre-media services" },
                    { new Guid("c27d9518-a2fa-4738-a51d-618adebbfdf3"), "C.18.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Binding and related services" },
                    { new Guid("48e05573-e086-4113-a79e-49cacb540daf"), "C.18.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Reproduction of recorded media" },
                    { new Guid("2fdf7b82-169e-4657-b0de-7c741a26fc61"), "C.18.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("96b698ad-b9cd-4ecb-a608-f795b33f8741"), "C.19", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("98a69408-7b0a-43f6-aab5-ca0d6d66e107"), "C.19.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of coke oven products" },
                    { new Guid("57560b7a-e44f-4905-8b88-8c8e064f862a"), "C.19.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of coke oven products" },
                    { new Guid("4863190d-6611-48de-936f-6d3b802f92d6"), "C.19.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of refined petroleum products" },
                    { new Guid("019d6186-1b7e-4ef5-8569-cdbf6518736d"), "C.19.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of refined petroleum products" },
                    { new Guid("db1aa57f-f32e-41c0-b0d0-b707d095db3e"), "C.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of chemicals and chemical products" },
                    { new Guid("bae2f5b7-c673-44b8-ad96-ed741f16824f"), "C.20.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("f43c55e1-d42d-4344-82e9-895dcb3b0f5a"), "C.20.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of industrial gases" },
                    { new Guid("d546f1b7-8a9c-4dac-9d6b-a9652bc45b06"), "C.20.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of dyes and pigments" },
                    { new Guid("95ed7ed4-9f1a-4852-b603-6d115273931d"), "C.20.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("850e36c3-8264-4075-8095-d288366283fd"), "C.20.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other organic basic chemicals" },
                    { new Guid("02e2d514-dd84-4d9e-b587-e09e326f831c"), "C.20.15", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("2d4e3dd3-0d9d-4531-b503-f027777bba46"), "C.20.16", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of plastics in primary forms" },
                    { new Guid("eaba6609-bb61-487a-b023-10ad38a38541"), "C.20.17", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("344c07db-4bf3-40b8-b32e-16bc72773133"), "C.20.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("635be981-6240-485e-9e79-24f856159c47"), "C.20.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("e3138fc5-6972-4560-836e-6efa2dce3915"), "C.20.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("a0781495-b027-466c-80e7-6eea024f8f3e"), "C.20.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("b43dba00-2291-4b9e-8ef6-66e76fd4239c"), "C.20.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("4269b382-c6db-4cee-82e7-f3acc834fd28"), "C.17.24", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wallpaper" },
                    { new Guid("42ef84ec-3ac8-446a-a004-03117268e0fa"), "C.23.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of refractory products" },
                    { new Guid("a1065975-6a6d-4b79-987a-8f2345e593ab"), "C.11.0", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of beverages" },
                    { new Guid("3799f27f-d47e-4e54-af00-89e2e05acf1f"), "C.10.92", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of prepared pet foods" },
                    { new Guid("d758295d-feea-4cad-be82-50c4b3cd362f"), "A.01.6", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("9050e6aa-ec37-417f-8bee-c6cb66616357"), "A.01.61", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Support activities for crop production" },
                    { new Guid("820fafbc-7df8-463c-bedf-b8b7e584418a"), "A.01.62", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Support activities for animal production" },
                    { new Guid("21b5d06d-e08d-49dc-b379-501970668000"), "A.01.63", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Post-harvest crop activities" },
                    { new Guid("17a4e10c-a8d5-4ab9-90a1-1fa14d4073c1"), "A.01.64", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Seed processing for propagation" },
                    { new Guid("2662dfbb-344c-47c5-8cc5-c72a3ebb41e5"), "A.01.7", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Hunting, trapping and related service activities" },
                    { new Guid("b40dfe9d-1bf8-4591-87cb-1faf0cb85ab0"), "A.01.70", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Hunting, trapping and related service activities" },
                    { new Guid("e92138cc-848b-4ce1-9083-58a718402f49"), "A.02", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Forestry and logging" },
                    { new Guid("21d72c0b-7d33-4ab1-8d26-fcb777676d8e"), "A.02.1", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Silviculture and other forestry activities" },
                    { new Guid("afffac6d-3e52-4dd8-9f12-1cfc8e618bbf"), "A.02.10", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Silviculture and other forestry activities" },
                    { new Guid("4e3e096c-7535-4d6c-bc7e-8140fdfdd2c5"), "A.02.2", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Logging" },
                    { new Guid("59c23a07-8112-40e1-a7df-c84e628c7b5f"), "A.02.20", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Logging" },
                    { new Guid("83e50339-0c26-46dd-ade4-9081d3b58e01"), "A.01.50", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Mixed farming" },
                    { new Guid("891687c7-b59b-4d00-9183-6f64d49247b4"), "A.02.3", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Gathering of wild growing non-wood products" },
                    { new Guid("2ceb4a1f-3816-46d8-8440-12b178cd77c8"), "A.02.4", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Support services to forestry" },
                    { new Guid("e98e439e-28eb-4743-b35e-a61735db9b5d"), "A.02.40", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Support services to forestry" },
                    { new Guid("31193353-b03a-4233-ba1c-3fa16ac3425d"), "A.03", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Fishing and aquaculture" },
                    { new Guid("f4193e3e-fe37-4739-aef3-f129e3a0d1c1"), "A.03.1", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Fishing" },
                    { new Guid("264fc1e1-5aca-42c2-8cb6-22c60879b70a"), "A.03.11", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d490afe1-a54e-440e-89c9-d390f6f717c8"), "A.03.12", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Freshwater fishing" },
                    { new Guid("aa3bda96-4975-4cbd-95b7-929c4f069add"), "A.03.2", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Aquaculture" },
                    { new Guid("5dfdccba-b761-416b-8964-20df74ecefee"), "A.03.21", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Marine aquaculture" },
                    { new Guid("7031b970-6925-4edf-b1fd-83ff1ad467cc"), "A.03.22", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Freshwater aquaculture" },
                    { new Guid("f0eb6af5-083b-48c0-93b0-2d24f9e5220e"), "B.05", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of coal and lignite" },
                    { new Guid("620b69f6-9cb9-431a-b5e0-fb7da0bd0519"), "B.05.1", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of hard coal" },
                    { new Guid("d7e50b9c-33d1-4a58-bb67-2182034b59a9"), "B.05.10", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of hard coal" },
                    { new Guid("4ac11b76-13fa-4965-8710-9ad89b7d59de"), "A.02.30", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Gathering of wild growing non-wood products" },
                    { new Guid("2b032630-eb6b-41cf-8fca-44e962e0f566"), "A.01.5", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Mixed farming" },
                    { new Guid("6437db98-3815-4360-b08a-46e704f134fe"), "A.01.49", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of other animals" },
                    { new Guid("2fa29d15-8282-4f2b-a35a-311c87bbd383"), "A.01.47", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of poultry" },
                    { new Guid("fc116f29-fb3b-4399-b94f-787ea4a4519c"), "A.01.1", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of non-perennial crops" },
                    { new Guid("e9a03f96-60bf-4fa8-8a1f-8a60af165b91"), "A.01.11", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("8e7ac096-f90a-4864-bf94-88c3792f2ffd"), "A.01.12", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of rice" },
                    { new Guid("55d52a25-22d5-4a23-a485-88efeb02f5d8"), "A.01.13", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("9f1815af-61e1-4749-9181-77960cc73757"), "A.01.14", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of sugar cane" },
                    { new Guid("0e0bf319-ce2a-4926-8728-569c00ece40b"), "A.01.15", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of tobacco" },
                    { new Guid("fa9f7535-5fdd-4318-93fb-0a8cb7f2ddf5"), "A.01.16", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of fibre crops" },
                    { new Guid("03571dfc-ff8b-4842-8000-89290325819b"), "A.01.19", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of other non-perennial crops" },
                    { new Guid("880d7fd4-022b-4184-baa0-50265b3ccb5d"), "A.01.2", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of perennial crops" },
                    { new Guid("6cf5e78d-6484-49ee-a3b3-dba0f3b88072"), "A.01.21", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of grapes" },
                    { new Guid("b6edf850-dbb3-4913-809b-f18e6a97e4c7"), "A.01.22", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of tropical and subtropical fruits" },
                    { new Guid("55876e80-b4dd-487b-99a9-027f01fbb647"), "A.01.23", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of citrus fruits" },
                    { new Guid("6cb9d429-9f13-4a97-a073-2494f7b57def"), "A.01.24", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of pome fruits and stone fruits" },
                    { new Guid("5f2e56cb-ac01-4f7a-8647-b052bea2ea6c"), "A.01.25", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("ab1b2be2-a82c-45da-a4aa-dae6eff6e107"), "A.01.26", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of oleaginous fruits" },
                    { new Guid("ccef56ba-de70-4ca3-90d4-4bcb253f59e6"), "A.01.27", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of beverage crops" },
                    { new Guid("5626bc4f-bffd-4976-8cd8-5126694c5e53"), "A.01.28", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("d4e1f9e2-9cd3-4d27-875a-fad2fa098008"), "A.01.29", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Growing of other perennial crops" },
                    { new Guid("722c16b0-6405-4a96-a77c-6dbfa7f1f3f8"), "A.01.3", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Plant propagation" },
                    { new Guid("b2a1254c-6232-4c37-a169-0e935edc407c"), "A.01.30", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Plant propagation" },
                    { new Guid("474ccf5b-158c-444c-846e-143123e42887"), "A.01.4", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Animal production" },
                    { new Guid("b6c8b18d-1486-48c6-8c0f-bb0c1e601e20"), "A.01.41", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of dairy cattle" },
                    { new Guid("18d845d7-fb2f-4a17-bc37-cf0cd188d8f3"), "A.01.42", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of other cattle and buffaloes" },
                    { new Guid("e0bd2367-3ad3-4a82-a4b6-96260b8c5ad5"), "A.01.43", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of horses and other equines" },
                    { new Guid("31b1e0b7-320a-40a5-9f85-a1d9f57de761"), "A.01.44", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of camels and camelids" },
                    { new Guid("d5d1967c-6b2f-4f46-96e3-1dde185f2db3"), "A.01.45", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of sheep and goats" },
                    { new Guid("8672d0d5-1d27-42bd-8378-adc6f8972014"), "A.01.46", new Guid("2218847c-43cd-4647-8086-f9eb53aacb87"), "Raising of swine/pigs" },
                    { new Guid("45abeea7-27c6-4891-8ca4-a9cdfc6fdbfe"), "B.05.2", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of lignite" },
                    { new Guid("34af7774-b20c-4b2b-8a58-fa31f137e44f"), "C.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of beverages" },
                    { new Guid("930027a3-13f6-44aa-8907-1ac3ff1ba1f6"), "B.05.20", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of lignite" },
                    { new Guid("7cdd3d84-ba9f-4ab6-80cc-9fe6a6abc029"), "B.06.1", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7bc55e86-dd4c-40c7-83e6-49a8e93fe315"), "C.10.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of potatoes" },
                    { new Guid("e3e15454-7882-413b-8f41-096b38468c21"), "C.10.32", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("eb29a58c-1227-487d-8d1b-16899063605c"), "C.10.39", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("14ccd8e6-3870-488f-9e64-0e2fa9bbd88d"), "C.10.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("6bc0c8b2-ca61-4d24-b025-99acdb3ace43"), "C.10.41", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of oils and fats" },
                    { new Guid("b8b258a1-f9c9-4c01-a5cd-d82cfc2d6ed0"), "C.10.42", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("d0f237e5-9c99-48d9-aa7c-1509b36b6728"), "C.10.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of dairy products" },
                    { new Guid("182097e1-5753-4547-9ce7-0bc272d60aac"), "C.10.51", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Operation of dairies and cheese making" },
                    { new Guid("df3a3032-c378-4f3a-8763-fa4ef9ce1972"), "C.10.52", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ice cream" },
                    { new Guid("c5c463a3-c1aa-4db5-8d73-af55279382fa"), "C.10.6", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("85ffd635-6232-4160-acdb-0a81c171b1d0"), "C.10.61", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of grain mill products" },
                    { new Guid("8250dd44-0247-4b3b-9042-b18e154d6957"), "C.10.62", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of starches and starch products" },
                    { new Guid("bf0818f9-4ef9-408b-9fa5-316ad11078ce"), "C.10.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("35fd8eb7-b27c-41cd-8aa4-fd939281f7a4"), "C.10.7", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("5a2ac2d4-463d-47c8-92ae-29e31391216f"), "C.10.72", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("bec1c6f2-4cc4-45b3-a98e-a251251bd626"), "C.10.73", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("18f3039b-b1a4-4dcd-84e5-58b9574b6c3b"), "C.10.8", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other food products" },
                    { new Guid("c558db0c-adcb-462e-ae56-08097848c6ae"), "C.10.81", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of sugar" },
                    { new Guid("d19d8454-6b7c-4cf0-85e2-01dbd48beab4"), "C.10.82", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("722f41cc-d5b7-4734-9f93-3ac201b28a4f"), "C.10.83", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing of tea and coffee" },
                    { new Guid("d5dcd933-3382-4ef4-b1f9-2528fe38c649"), "C.10.84", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of condiments and seasonings" },
                    { new Guid("5b7bbc3b-b9ab-4e32-9ce5-77671180ccc4"), "C.10.85", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of prepared meals and dishes" },
                    { new Guid("c3470858-5ddf-48c6-855c-ee24549c3545"), "C.10.86", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("071636be-b0fb-491e-8dd2-8c36bf9e0e3e"), "C.10.89", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other food products n.e.c." },
                    { new Guid("c7adbe1e-3e2d-4689-9148-ba746de3eb60"), "C.10.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of prepared animal feeds" },
                    { new Guid("07c23d4f-90c6-404b-ac56-20fbc450323f"), "C.10.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("2b2b6bf1-b25f-4366-bb16-de81e3bba799"), "C.10.71", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("c3d9eb69-aebb-4ee5-bb9e-189cc3cf5f87"), "C.10.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("5c0eb409-fb83-484c-9a05-7c3b39c447a8"), "C.10.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("17d866e8-4de6-4134-ac79-55b15faec3bc"), "C.10.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Production of meat and poultry meat products" },
                    { new Guid("3e1600d4-5f33-48d6-bf71-be95bee6315b"), "B.06.10", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of crude petroleum" },
                    { new Guid("a1ff8b11-29f1-455f-99f5-6906439f5289"), "B.06.2", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of natural gas" },
                    { new Guid("90cfeb2f-a23c-40d6-bd74-11d25ab1261d"), "B.06.20", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of natural gas" },
                    { new Guid("fc389b91-034e-4b3c-9895-6dfbe008069b"), "B.07", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of metal ores" },
                    { new Guid("d35fe975-ddb5-4b23-9321-e6b20df7a24c"), "B.07.1", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of iron ores" },
                    { new Guid("7c990d12-f6d2-464b-860b-3b314a318719"), "B.07.10", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of iron ores" },
                    { new Guid("fc029681-6c38-4087-82bd-8590cf8d0385"), "B.07.2", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of non-ferrous metal ores" },
                    { new Guid("f0de2ded-59fd-4114-9d90-855aac5a0d1d"), "B.07.21", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of uranium and thorium ores" },
                    { new Guid("c35e6237-36a0-41ca-b355-db0770005c0d"), "B.07.29", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of other non-ferrous metal ores" },
                    { new Guid("adff4ec3-1213-44a8-aada-f668ac651a4a"), "B.08", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Other mining and quarrying" },
                    { new Guid("62fee790-d5d9-4595-baf3-712e0e4c3279"), "B.08.1", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Quarrying of stone, sand and clay" },
                    { new Guid("3bbbc353-9aaf-4aa3-a050-fdd57e3142d2"), "B.08.11", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("bfc48bed-6dbd-4910-b698-4ba926dacf7f"), "B.08.12", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("8fcd08c1-fd9c-44bd-b4ab-6b4853743feb"), "B.08.9", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining and quarrying n.e.c." },
                    { new Guid("922b44d9-7968-4b16-9de7-f47cbaa0827c"), "B.08.91", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("e52740bc-859d-492e-b4e4-14d84d47839b"), "B.08.92", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of peat" },
                    { new Guid("bf169f38-a3ab-4aca-b949-14e7d6aecc51"), "B.08.93", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of salt" },
                    { new Guid("068bf6de-7391-4bf7-99d0-a176c98bb6eb"), "B.08.99", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Other mining and quarrying n.e.c." },
                    { new Guid("263a10c5-2348-422c-a04c-bd60c418f6bd"), "B.09", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Mining support service activities" },
                    { new Guid("4406d523-5255-420b-b5a1-bd061dba1a79"), "B.09.1", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("6c158385-5b3a-49cd-ac23-e6ba7ee7cb91"), "B.09.10", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("35fb104b-fe61-44e0-be93-f5a81550b366"), "B.09.9", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Support activities for other mining and quarrying" },
                    { new Guid("94028441-7b8e-4c8b-bf2f-7c3a26b471bb"), "B.09.90", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Support activities for other mining and quarrying" },
                    { new Guid("3aac7c5f-02dd-4d45-8428-9518c11d5dc1"), "C.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of food products" },
                    { new Guid("d4b7d8b2-e9d7-4ed8-b6fc-1ff609cf6ce9"), "C.10.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("e831ee1d-41b4-48bf-8c62-486c3288c8a2"), "C.10.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of meat" },
                    { new Guid("4f1611b7-75a1-4150-a6f9-2af1e4d526e4"), "C.10.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing and preserving of poultry meat" },
                    { new Guid("04e87c4f-7333-4bff-b485-5bd7d50fc2c1"), "B.06", new Guid("c3386b6d-0371-4105-8177-e1194f8e1dfb"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("dd47bd97-321d-42bd-b02f-e61e033bc84d"), "F.43.2", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("20b21a25-0a0e-4a64-939e-39c617db1f19"), "C.23.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of refractory products" },
                    { new Guid("072e793b-8db5-410d-a202-4ef4e15410aa"), "C.23.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("08622eeb-e350-4d63-b044-0a20a604cecc"), "C.30.92", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("880260fb-25db-4b30-8f16-15c578ea90c4"), "C.30.99", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("bde64ffc-6394-4f99-9c55-fc653cda1866"), "C.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of furniture" },
                    { new Guid("2c4845ee-3ead-4aa9-b45c-234c8c65f90a"), "C.31.0", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of furniture" },
                    { new Guid("c48db3e2-2c6c-4006-b7a4-532ec42faef1"), "C.31.01", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of office and shop furniture" },
                    { new Guid("15933def-8a6e-40f4-a8f3-53a970e6cc76"), "C.31.02", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of kitchen furniture" },
                    { new Guid("601dc578-0e0e-49fd-af2a-96de889e9c48"), "C.31.03", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of mattresses" },
                    { new Guid("981dc8dc-bc0a-4931-a01c-154d4d23a331"), "C.31.09", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other furniture" },
                    { new Guid("d95db67e-38bf-4744-9f31-e255c86ad4b4"), "C.32", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Other manufacturing" },
                    { new Guid("85dd9061-ab4e-4ef6-b35a-f3164bd2fb7d"), "C.32.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("32aaca7e-6b02-40e1-8ca0-0fccef114600"), "C.32.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Striking of coins" },
                    { new Guid("dd8aea51-ae86-4db9-b04a-c6371aee8e04"), "C.32.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of jewellery and related articles" },
                    { new Guid("f35d5387-b6da-4361-aedc-52c188a861e7"), "C.30.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of motorcycles" },
                    { new Guid("554fa269-0bd4-42af-b94d-a0e2dcb66136"), "C.32.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("c09414b5-c2aa-4011-adb3-9397389ab153"), "C.32.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of musical instruments" },
                    { new Guid("c75649ce-f0df-4277-a383-e4734e23a6e9"), "C.32.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of sports goods" },
                    { new Guid("56686643-c795-45c9-84f2-5c6fb719cf62"), "C.32.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of sports goods" },
                    { new Guid("8c478a4e-d412-49fa-b3f2-8fe444b5e95c"), "C.32.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of games and toys" },
                    { new Guid("77f76c0b-363d-42cd-b0a4-c56652924c08"), "C.32.40", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of games and toys" },
                    { new Guid("ece2accb-6a8c-422d-b4e8-eea3980c9126"), "C.32.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("231891d8-e4d2-487e-b235-17273a0b705a"), "C.32.50", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("7d6ffca6-cc2e-4426-a24a-015668bc7ef5"), "C.32.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacturing n.e.c." },
                    { new Guid("024ef68d-851c-40b5-9db3-9562ebd02224"), "C.32.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d8e3bb49-688f-4b8d-9ac2-a7ddd095d59d"), "C.32.99", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Other manufacturing n.e.c." },
                    { new Guid("75b3dcc9-38fd-4906-9d25-7bcc19f37363"), "C.33", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair and installation of machinery and equipment" },
                    { new Guid("fd211212-7cb0-472a-bcbf-7a6cfc71df42"), "C.33.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("ca2be234-8f00-4720-a0cc-ed20ee148c70"), "C.32.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of musical instruments" },
                    { new Guid("931d31a3-ee77-4922-93d8-3bb45a2c7e29"), "C.30.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("b2a3234a-ca1c-4766-8009-bd42139c2ef6"), "C.30.40", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of military fighting vehicles" },
                    { new Guid("1955c973-64b7-4fe0-aa57-a9fbccf10c69"), "C.30.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of military fighting vehicles" },
                    { new Guid("0a723582-ad16-4a14-82c3-f53d1faeafca"), "C.28.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("90798874-9c80-4998-b28b-37d29fc454a7"), "C.28.41", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of metal forming machinery" },
                    { new Guid("f15ffa3b-3211-4b50-bbe2-2a1dfd186cf4"), "C.28.49", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other machine tools" },
                    { new Guid("b0dfd85b-9b83-449f-9b06-ac5c8a637a4c"), "C.28.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other special-purpose machinery" },
                    { new Guid("f402f5c8-9c45-4575-b96c-29bae158a11b"), "C.28.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of machinery for metallurgy" },
                    { new Guid("74844862-6003-44b1-8f8c-195dc3343a29"), "C.28.92", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("c89e4797-071d-418b-85a8-d42bb27ca426"), "C.28.93", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("b2592c9a-b37a-45b6-92c9-fb33ba4f2f66"), "C.28.94", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("b8ac4cf8-3a9d-46cd-ba92-309adaca015b"), "C.28.95", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("f76e518e-e17a-40b1-8bf8-cfc7fd2c00a5"), "C.28.96", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("94845421-0e5e-44c4-92ad-a75c6659902e"), "C.28.99", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("bd68620e-7fe1-4c93-b523-dbb2ec4db553"), "C.29", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("2d6095e4-7cee-4d80-a6f9-63fd9a6e1c55"), "C.29.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of motor vehicles" },
                    { new Guid("0f17555a-797a-4d83-b8fa-eea2a3139de4"), "C.29.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of motor vehicles" },
                    { new Guid("dfcdf996-cd75-456a-be02-0f3cd4e19d84"), "C.29.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("f5789c9e-8396-4eac-aad1-19cd5c1dac57"), "C.29.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("6ccdf450-2e01-4d4b-bc54-b93462467a0f"), "C.29.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("77a0721e-afd8-4d88-b448-d7f3973b4ae7"), "C.29.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("1b89d855-3b99-4389-a6f4-fbe200f9ea29"), "C.29.32", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("a0619a6c-f01b-4484-92e1-ca8837031aa6"), "C.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other transport equipment" },
                    { new Guid("8c12de60-4de5-46f6-835c-c27bc5735e97"), "C.30.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Building of ships and boats" },
                    { new Guid("1a7dd7ba-8b46-483c-9c96-8b261b8e2353"), "C.30.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Building of ships and floating structures" },
                    { new Guid("7404750a-c94c-464e-af89-7c6bb453ee0e"), "C.30.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Building of pleasure and sporting boats" },
                    { new Guid("9d67e185-3f71-4fa7-bfe7-ca3b2b0db16a"), "C.30.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("b3d265e3-4829-4d40-b57d-9d9a82fd71d9"), "C.30.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("fd61467a-9634-4274-833a-9b2230788930"), "C.30.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("36a30818-21e4-4d78-95ee-0b26b44f85fc"), "C.30.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("116deddc-c973-4c92-ae2f-90af23e74371"), "C.33.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair of fabricated metal products" },
                    { new Guid("7a5e08de-c4f8-47be-b9fc-13db2103e211"), "C.28.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("9391d7b7-af0c-47a6-a37f-277bba19db38"), "C.33.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair of machinery" },
                    { new Guid("3028fdca-5636-47b5-bf70-b79522345e68"), "C.33.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair of electrical equipment" },
                    { new Guid("e6519e14-ebf7-4ac3-90b3-a9b1c71542c9"), "E.38.3", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Materials recovery" },
                    { new Guid("f5549aab-0958-4f3f-ae73-c84b428184d0"), "E.38.31", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Dismantling of wrecks" },
                    { new Guid("e7a46c2f-fa34-4251-b26c-d6e1df3c1733"), "E.38.32", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Recovery of sorted materials" },
                    { new Guid("117d88b5-4fa3-440a-b25b-d9cdbc0fdf56"), "E.39", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e1be6b1d-c5f3-4c08-b81c-4c9cad02cbb6"), "E.39.0", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Remediation activities and other waste management services" },
                    { new Guid("c77ceaa0-1ab1-4848-90c3-339c9d6e278f"), "E.39.00", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Remediation activities and other waste management services" },
                    { new Guid("8b181259-5a04-4d76-83e8-48c90a3425af"), "F.41", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of buildings" },
                    { new Guid("e9e3dfdc-331c-4c44-870a-ab0a573ab001"), "F.41.1", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Development of building projects" },
                    { new Guid("26f8f0cd-1982-461c-bc40-c44b302c4abf"), "F.41.10", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Development of building projects" },
                    { new Guid("34f5f834-09c2-490c-99e7-ead08198127a"), "F.41.2", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of residential and non-residential buildings" },
                    { new Guid("7257ab4f-6580-48c7-95e4-1180a79bb8c4"), "F.41.20", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of residential and non-residential buildings" },
                    { new Guid("2f327777-4b49-470b-a9da-90a09a1789ff"), "F.42", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Civil engineering" },
                    { new Guid("a220b9f4-803b-4e10-b472-475981a3c2a4"), "E.38.22", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Treatment and disposal of hazardous waste" },
                    { new Guid("127cc829-1ab3-4f21-87ed-6d4fa4e223f2"), "F.42.1", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of roads and railways" },
                    { new Guid("2c857759-0ce8-4a12-968a-9c6aeffc1093"), "F.42.12", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of railways and underground railways" },
                    { new Guid("1f3e596f-c805-4ece-9dd7-493a4e061567"), "F.42.13", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of bridges and tunnels" },
                    { new Guid("293daabe-81cf-47f6-a0b6-0b6e8f699366"), "F.42.2", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of utility projects" },
                    { new Guid("e1737034-05a0-4ed6-b429-62c371b46688"), "F.42.21", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of utility projects for fluids" },
                    { new Guid("b90e5e55-0bec-4080-af6c-91cf85e905fb"), "F.42.22", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("447d1189-f2ba-4220-be68-e66b92469eab"), "F.42.9", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of other civil engineering projects" },
                    { new Guid("fecb3781-18ea-4d7a-9f31-0b6a044013c1"), "F.42.91", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of water projects" },
                    { new Guid("7a2889e7-5fc2-4759-ac7e-1b362463aacf"), "F.42.99", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("424d069e-e6c3-4aa4-a7f4-d8a24e7698fa"), "F.43", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Specialised construction activities" },
                    { new Guid("f55f3075-275b-41f0-afb4-9e8a6ba0acd0"), "F.43.1", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Demolition and site preparation" },
                    { new Guid("f9ca3317-3616-448d-a2f9-7986782ca91e"), "F.43.11", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Demolition" },
                    { new Guid("8589f529-4cc6-489d-89a9-3854b846a7b8"), "F.43.12", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Site preparation" },
                    { new Guid("cd438018-b0ed-4d2a-b45d-083e8ef2d8e2"), "F.42.11", new Guid("d88a4515-c842-41a6-b31c-0b80032b8be9"), "Construction of roads and motorways" },
                    { new Guid("a29cfa10-38e6-4f98-9a6b-9494c6f37639"), "E.38.21", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("80b561e6-b147-411c-b6cf-b8d95fb4ca28"), "E.38.2", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Waste treatment and disposal" },
                    { new Guid("7842909e-6ef4-4c72-bfff-754aa0bf6161"), "E.38.12", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Collection of hazardous waste" },
                    { new Guid("9800f79a-b0d3-416d-b44d-771774f9ebca"), "C.33.15", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair and maintenance of ships and boats" },
                    { new Guid("7abb8340-a8ae-4820-86ba-fc152799267c"), "C.33.16", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("dec30320-60e3-43e6-a3aa-9970abed3bca"), "C.33.17", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair and maintenance of other transport equipment" },
                    { new Guid("8a96c76f-1d9f-4557-9b6f-df9e78daa7f1"), "C.33.19", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair of other equipment" },
                    { new Guid("4b83f4f0-74d3-4409-a784-42121bef0510"), "C.33.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Installation of industrial machinery and equipment" },
                    { new Guid("41b7ca8e-e307-444c-aa5c-dc692e94e6a0"), "C.33.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Installation of industrial machinery and equipment" },
                    { new Guid("6f4d241c-83d8-4045-bae4-5618824d88bd"), "D.35", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("18dd6308-de46-43c6-9e72-f4bdafd3a125"), "D.35.1", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Electric power generation, transmission and distribution" },
                    { new Guid("db840237-5bbe-4509-a4c7-c250ac8f22a2"), "D.35.11", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Production of electricity" },
                    { new Guid("2c6d0610-8726-42d2-89b1-ada8498a9719"), "D.35.12", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Transmission of electricity" },
                    { new Guid("80d023b5-26b4-4258-aba0-9c9e361c4fc0"), "D.35.13", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Distribution of electricity" },
                    { new Guid("7e47f7f7-8fa5-4c0a-a55d-d4c83c8bc151"), "D.35.14", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Trade of electricity" },
                    { new Guid("32e1f33a-5575-46a9-8e81-952044e61055"), "D.35.2", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("f819d066-1d19-4a21-bee6-54736887eb3f"), "D.35.21", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Manufacture of gas" },
                    { new Guid("8818496d-aebf-45f7-a0d2-d74d666baa5e"), "D.35.22", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Distribution of gaseous fuels through mains" },
                    { new Guid("b17c5616-fb74-418b-a63b-65723285ce2a"), "D.35.23", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d266e605-b401-454e-90de-4d581f7dfdca"), "D.35.3", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Steam and air conditioning supply" },
                    { new Guid("1c52af59-1c5d-4d4c-9785-91e0f5106724"), "D.35.30", new Guid("7985c4f2-e7b2-4218-b0b9-ca2e67836f6d"), "Steam and air conditioning supply" },
                    { new Guid("aada5359-2937-4673-a251-17b7325a8a42"), "E.36", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Water collection, treatment and supply" },
                    { new Guid("ba9bd48a-8026-4bac-b27d-09f21009e16e"), "E.36.0", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Water collection, treatment and supply" },
                    { new Guid("36acbbc7-a4d3-4aca-a690-c54cfed5be1f"), "E.36.00", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Water collection, treatment and supply" },
                    { new Guid("f2e3b7f0-d2d1-4932-ae57-828426ae6cd8"), "E.37", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Sewerage" },
                    { new Guid("1b7b3398-ddfc-429b-add3-6f6a110d21d6"), "E.37.0", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Sewerage" },
                    { new Guid("e1469f3b-1e54-4b63-99ed-7f77f7621a0a"), "E.37.00", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Sewerage" },
                    { new Guid("c97acb44-41c7-4b6a-a2b3-03fa6a95722e"), "E.38", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("80fda8f9-29b5-43ea-914f-b65bd3a3a333"), "E.38.1", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Waste collection" },
                    { new Guid("c605b074-f910-4f11-810e-9c47ba28e7d7"), "E.38.11", new Guid("f232e599-f751-4c59-8bf2-614362d22393"), "Collection of non-hazardous waste" },
                    { new Guid("eac2da4e-7b7d-4a8e-8034-154ad2e8ee5a"), "C.33.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Repair of electronic and optical equipment" },
                    { new Guid("a82c06a1-bf81-4a44-9e9c-d04f9996ff92"), "C.23.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of clay building materials" },
                    { new Guid("6283829b-4f98-4eba-96dd-c44bc2f17114"), "C.28.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("d0e1ea05-a5fd-4091-9d3f-85ae2fdb587c"), "C.28.25", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("c212625e-e513-40d6-a276-794952c3d080"), "C.24.34", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Cold drawing of wire" },
                    { new Guid("c118371f-b7ef-4550-a6c1-2b7bd08aa0b0"), "C.24.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("32c4b5ab-9494-4257-9876-65841368b895"), "C.24.41", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Precious metals production" },
                    { new Guid("b4fd25c0-cef9-4add-aa05-714cd1e39ec4"), "C.24.42", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Aluminium production" },
                    { new Guid("16289a3f-abf0-40d1-816c-859b9af6e18f"), "C.24.43", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Lead, zinc and tin production" },
                    { new Guid("88a8e1da-4f33-4ad8-aea5-9ee06a64c8fb"), "C.24.44", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Copper production" },
                    { new Guid("3db8e144-8616-42a1-b74b-1ccbf0f361c5"), "C.24.45", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Other non-ferrous metal production" },
                    { new Guid("bd8be91e-bab4-4118-9010-899e78474f39"), "C.24.46", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Processing of nuclear fuel" },
                    { new Guid("8b69fc3c-6ea9-4b8b-9a2e-e3f55722d85d"), "C.24.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Casting of metals" },
                    { new Guid("e32a26d0-a920-42a9-b9d5-2a1068802016"), "C.24.51", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Casting of iron" },
                    { new Guid("8a0fe18b-2922-4ebb-a3e1-e8d8d6638fcc"), "C.24.52", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Casting of steel" },
                    { new Guid("73b5af97-da11-4934-a219-8d3b61a93677"), "C.24.53", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Casting of light metals" },
                    { new Guid("97e72100-991a-445a-94c9-da7b079f0790"), "C.24.33", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Cold forming or folding" },
                    { new Guid("07b4e8dd-058b-4219-9ee5-b55e559671dd"), "C.24.54", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Casting of other non-ferrous metals" },
                    { new Guid("5bd695a5-5445-4c88-a9ea-61740988f8fd"), "C.25.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of structural metal products" },
                    { new Guid("fd777411-9440-49d7-abaf-7a0f406f30d7"), "C.25.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("54b9e443-6d9c-47c6-8097-aac3d6235b0d"), "C.25.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of doors and windows of metal" },
                    { new Guid("dc5d8377-160c-4eab-9227-3440112ea007"), "C.25.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("ce33eacb-3e10-48aa-a7ad-12c30bc19828"), "C.25.21", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("c355e663-474a-4c2c-9335-6a398379bec0"), "C.25.29", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("4f495114-8bdc-428a-a04f-cdbb5ecab0cd"), "C.25.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("af6f6198-75f7-4dd4-a77e-7a2ba750f12d"), "C.25.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("18905526-dea5-40c1-a11e-a721f01aa762"), "C.25.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of weapons and ammunition" },
                    { new Guid("71b731f7-99d0-483f-918e-2da330f6906e"), "C.25.40", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of weapons and ammunition" },
                    { new Guid("c138c135-96c5-4920-b342-f17605519e4e"), "C.25.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("520ce5f7-e6ad-4d63-8177-2bb46ef62e6c"), "C.25.50", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("0ff794ad-5ac4-41a2-97b3-5856bb0539e2"), "C.25", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("48c9d8ee-047b-441c-856b-b3ed48094979"), "C.24.32", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Cold rolling of narrow strip" },
                    { new Guid("0c28cd35-eda9-4e25-b4b1-ab5010a06d5b"), "C.24.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Cold drawing of bars" },
                    { new Guid("f7555988-b1f1-47f7-8953-1dd359c8a7d8"), "C.24.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other products of first processing of steel" },
                    { new Guid("75fc6107-db26-425c-a7da-ede9bd189ab2"), "C.23.32", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("0311b2dd-b2f0-4824-96b3-4c902651a56f"), "C.23.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("bed9b07d-0578-41a6-b869-00d40eb6bb1a"), "C.23.41", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("8970a7e8-d73a-4dab-95bb-e93b0f719380"), "C.23.42", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("3bdb7ed1-f654-4385-9bed-bca01229da2e"), "C.23.43", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("eaa8619c-7da7-4974-82fd-24377d5f35ab"), "C.23.44", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other technical ceramic products" },
                    { new Guid("5630ebae-210d-4884-9f1e-d9f958196c30"), "C.23.49", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other ceramic products" },
                    { new Guid("f798be1a-fe75-4a15-83a3-85411af10b1b"), "C.23.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cement, lime and plaster" },
                    { new Guid("635deb6f-9a3a-4a28-bfe3-085ebc102a82"), "C.23.51", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cement" },
                    { new Guid("375ba5c9-aa86-4bd8-bd0c-90c63cab5ae7"), "C.23.52", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of lime and plaster" },
                    { new Guid("5068a7c5-bac2-4c99-90db-f977d3292dd4"), "C.23.6", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("b1e67f14-c7e2-4092-b9b2-8f1d0e344326"), "C.23.61", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("5f510a07-74e3-4b99-a5ef-2dd576727f49"), "C.23.62", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("41e91486-5cf8-455d-b32e-3f18cd07e2ae"), "C.23.63", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ready-mixed concrete" },
                    { new Guid("e6d5af28-2c82-4412-8bb2-4e800e8c7474"), "C.23.64", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of mortars" },
                    { new Guid("e191a447-dfe1-4b9f-b1ad-50b0dcfa8e5b"), "C.23.65", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fibre cement" },
                    { new Guid("b68501fb-c830-4d37-93ba-c816e5570ef9"), "C.23.69", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("596604a8-0835-43cb-8a32-a7d57a6bebd6"), "C.23.7", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Cutting, shaping and finishing of stone" },
                    { new Guid("e15e0d55-4d6c-4136-8779-9b4a5039b368"), "C.23.70", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Cutting, shaping and finishing of stone" },
                    { new Guid("ab24654c-c0aa-47c0-a75d-c23b03128012"), "C.23.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("0c29a15d-dacc-4bfb-98b2-b13a98dceda6"), "C.23.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Production of abrasive products" },
                    { new Guid("7cf84201-fd28-4cf5-9593-5887205e5711"), "C.23.99", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("246ac2b8-7027-4a8d-b4fb-f40a59e5ef4d"), "C.24", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic metals" },
                    { new Guid("edee1888-f67a-47c5-b17e-d62476f9273c"), "C.24.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("a047b00d-e31f-404c-b299-70d04ef7b968"), "C.24.10", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("09f3ca42-3292-46d8-b0b1-3a69de8a0d5d"), "C.24.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("6dd3bfb3-91d3-429c-ab27-9904a17a8ca7"), "C.24.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("ce03cc33-eea4-4b9e-a417-db4ed1d0626a"), "C.25.6", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Treatment and coating of metals; machining" },
                    { new Guid("a549be03-b1ae-4c24-9488-f192af7a09f7"), "C.28.29", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("e0698f1e-586d-434f-b4e0-0c828966bbf7"), "C.25.61", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Treatment and coating of metals" },
                    { new Guid("12746551-2225-429e-9bee-e386cf207391"), "C.25.7", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("12eac419-f5e0-4ff9-a915-345dc6d28af0"), "C.27.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("d2e5bdaa-b416-4408-9048-b3640d9e62e2"), "C.27.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of batteries and accumulators" },
                    { new Guid("4f8abe89-a908-4938-994a-c2fb8691ec1a"), "C.27.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of batteries and accumulators" },
                    { new Guid("286f5e23-06fb-4e06-89aa-3bdc452db74e"), "C.27.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wiring and wiring devices" },
                    { new Guid("77c56663-2e5e-40b7-8605-268ea4e15964"), "C.27.31", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fibre optic cables" },
                    { new Guid("30bc1472-90a9-4f37-9f51-d044e6f48d1f"), "C.27.32", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("1ab42bc7-dc4a-46c1-86fa-ecb1c698593b"), "C.27.33", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wiring devices" },
                    { new Guid("af8d9363-f362-40a9-ba88-cf4b82ae133d"), "C.27.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1ac73919-11d7-4841-ae99-3019091323f1"), "C.27.40", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electric lighting equipment" },
                    { new Guid("ccd333bc-ebd0-4385-aec8-4e6a70e7a55d"), "C.27.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of domestic appliances" },
                    { new Guid("7b174cd2-1816-4ae6-b4f7-52eb8ab918ae"), "C.27.51", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electric domestic appliances" },
                    { new Guid("1c05df48-6afa-41cb-ad1e-8fdc5397a4e8"), "C.27.52", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("1d9f7e8a-a5f6-4016-9646-b2c86dfcac7e"), "C.27.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("2a30821f-1a28-4556-b1a7-89005f3b8c71"), "C.27.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other electrical equipment" },
                    { new Guid("e468078f-bd7a-40b9-8d74-60e7ba907f68"), "C.28", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("781558cc-74ed-431a-80e6-5626a5d6ce40"), "C.28.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of general-purpose machinery" },
                    { new Guid("374ed13e-9402-489d-a084-15de81ca75a0"), "C.28.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("5ebdaf17-20e4-4251-8fcd-07a31460607c"), "C.28.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fluid power equipment" },
                    { new Guid("69fa2480-5cd3-4891-aeff-357be69cc88f"), "C.28.13", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other pumps and compressors" },
                    { new Guid("5227f9c3-462f-4f61-aee4-05c366e657fd"), "C.28.14", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other taps and valves" },
                    { new Guid("14ec3561-1bc2-4d8f-aee6-814b33646834"), "C.28.15", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("5174b546-6efd-4c64-8400-3ac67e4fc8c8"), "C.28.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other general-purpose machinery" },
                    { new Guid("a650e8cc-55b9-44cc-a280-69260f07908b"), "C.28.21", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("c6a3891c-16af-435a-8c25-7d959e4a231a"), "C.28.22", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of lifting and handling equipment" },
                    { new Guid("f9e6e646-df89-4d25-b37d-fd7ad05b9357"), "C.28.23", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("e2b560c3-75d4-4fbc-81f4-754b0104574a"), "C.28.24", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of power-driven hand tools" },
                    { new Guid("84c8c4d1-b312-4b79-b00d-3bbcf699eda1"), "C.27.90", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other electrical equipment" },
                    { new Guid("62c073bd-4e4c-4808-aff4-e1d5af0fec44"), "C.27.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("e1088968-57fe-4c71-99ae-60f197957245"), "C.27", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electrical equipment" },
                    { new Guid("588738ea-e318-4626-914e-d5cac8590b4e"), "C.26.80", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of magnetic and optical media" },
                    { new Guid("9b70c005-d62e-4aec-b56d-9d296dd7aad3"), "C.25.71", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of cutlery" },
                    { new Guid("c55b9f18-fa49-4b8d-80dd-f46cfa14692a"), "C.25.72", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of locks and hinges" },
                    { new Guid("f9aa117f-d746-475b-941a-ca5ffe5fb21e"), "C.25.73", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of tools" },
                    { new Guid("61946e77-10bc-437a-be46-3cac99c65e75"), "C.25.9", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other fabricated metal products" },
                    { new Guid("af1deda7-2c4b-4887-972d-b92e57868e7f"), "C.25.91", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of steel drums and similar containers" },
                    { new Guid("0c394d6c-cfe8-475d-bb00-3c7c386b76bd"), "C.25.92", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of light metal packaging" },
                    { new Guid("8739358b-595d-43a7-8abd-c0fa040bdd9a"), "C.25.93", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of wire products, chain and springs" },
                    { new Guid("68a4ceb2-222a-4934-b73c-b9c7754e6db1"), "C.25.94", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("db8932ca-8eac-4d08-b6c6-bc53298d9179"), "C.25.99", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("523549b0-84a1-49a7-a7a1-195514c3c872"), "C.26", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("f213ccf4-ad0b-4b9b-ab25-51b219783c84"), "C.26.1", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electronic components and boards" },
                    { new Guid("fbd6b144-9c1e-4de2-afca-2d9c493ed61f"), "C.26.11", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of electronic components" },
                    { new Guid("c7cc3cd8-7b8e-4d06-8900-9da3ad40b115"), "C.26.12", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of loaded electronic boards" },
                    { new Guid("ac138b62-d805-4424-b24f-fcb0573c111c"), "C.26.2", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("94b0476f-52e3-4595-8682-2936b42ad802"), "C.26.20", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("df3fae50-1452-4961-8c5a-f39d7d525244"), "C.26.3", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of communication equipment" },
                    { new Guid("d338e92a-c662-4184-b09d-a28d04eed074"), "C.26.30", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of communication equipment" },
                    { new Guid("0df79392-55d5-485f-9064-1e8fcbcf700a"), "C.26.4", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of consumer electronics" },
                    { new Guid("e046a1c5-62b1-4eee-bb61-01dbc50371ed"), "C.26.40", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of consumer electronics" },
                    { new Guid("409a7495-e675-4da1-a4ce-260f84b46bae"), "C.26.5", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3789c7c3-440f-4bb2-b22f-fba03b06ca96"), "C.26.51", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("b7824bd6-2d21-49f1-b600-0a54094ec80b"), "C.26.52", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of watches and clocks" },
                    { new Guid("26614973-3bd8-41b7-a640-fb9763d71879"), "C.26.6", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("9caa0fa4-b50a-41ae-b24a-1915fbf67461"), "C.26.60", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("750a0957-d479-4c00-98d8-82048b1c9377"), "C.26.7", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("32d3d3c1-946e-4b06-953f-ecc3d543bd80"), "C.26.70", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("f33e93f9-da5f-44fc-875e-3b052c082e14"), "C.26.8", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Manufacture of magnetic and optical media" },
                    { new Guid("a8fcd01b-e42d-4bb0-9935-86de5ae4fe89"), "C.25.62", new Guid("39768f73-31bd-4d9d-a7ea-7881e18c446b"), "Machining" },
                    { new Guid("b45e5c49-a08a-42db-b3b5-cb8bdaaaad16"), "U.99.00", new Guid("e3d2ecf6-4460-4227-980d-a244cff02f80"), "Activities of extraterritorial organisations and bodies" }
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
