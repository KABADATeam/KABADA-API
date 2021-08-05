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
                    { new Guid("a33b1801-bf2e-4f08-bfa3-d21803652729"), "AT", "Austria" },
                    { new Guid("6ac714fc-4cbb-467c-8484-3b0d5e2d499a"), "LU", "Luxembourg" },
                    { new Guid("a6fa3801-72f0-4fe3-8e5d-b637a0d779c7"), "MT", "Malta" },
                    { new Guid("a6cd6f95-4a90-4b52-9be5-5e671d82c0bf"), "MK", "North Macedonia" },
                    { new Guid("fa400f5f-398a-4c67-b0c6-4d491e35383e"), "NO", "Norway" },
                    { new Guid("9387de2a-178a-46b6-8f6f-e2af440806fa"), "PL", "Poland" },
                    { new Guid("c187f7b1-373c-48d6-80c4-b331cc7bfa98"), "PT", "Portugal" },
                    { new Guid("73a80db1-1472-40b2-9c43-93d82dc22d65"), "RO", "Romania" },
                    { new Guid("dc029962-e979-44d9-b883-864d975e092d"), "RS", "Serbia" },
                    { new Guid("0917200e-8913-42b6-9447-c7ee6c0f8a40"), "SK", "Slovakia" },
                    { new Guid("7e1d4c97-8fdf-4143-ae87-cb286bc566ff"), "SI", "Slovenia" },
                    { new Guid("a45a0889-e512-4555-8362-547d850a3af1"), "ES", "Spain" },
                    { new Guid("daaa76d1-648c-4c82-af77-630cbc53fdd3"), "SE", "Sweden" },
                    { new Guid("db7dae1c-0ba5-4694-b579-b741ea97324f"), "CH", "Switzerland" },
                    { new Guid("d1341e2d-4258-4574-b49d-a30a176809ef"), "TR", "Turkey" },
                    { new Guid("e73568ea-67ea-4bad-b674-8cf2b265f91b"), "UK", "United Kingdom" },
                    { new Guid("c65a6e3e-3777-434a-bf5d-160fcdddfdc5"), "LT", "Lithuania" },
                    { new Guid("395570cb-2f53-4c21-bc79-a97aab16938f"), "LI", "Liechtenstein" },
                    { new Guid("f1f9f537-80e5-4000-8b89-9a92a5f4ddae"), "NL", "Netherlands" },
                    { new Guid("ab043529-0e4d-410e-9137-739b38ccb714"), "IT", "Italy" },
                    { new Guid("e51c7c15-d6ba-41d3-a8be-247e6eb1876f"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("4f7c773e-e97a-4417-ac9d-2ec28d0bc588"), "BE", "Belgium" },
                    { new Guid("040e1aac-5f60-44ce-854b-764def9596af"), "BG", "Bulgaria" },
                    { new Guid("6542d326-e922-40fa-b93d-9d43c2867416"), "LV", "Latvia" },
                    { new Guid("7160daaf-743e-4cfe-bc6e-1e9fd31c8cff"), "CY", "Cyprus" },
                    { new Guid("783d6579-7e95-495d-8630-c0da10bcf17c"), "CZ", "Czechia" },
                    { new Guid("21a6656a-08c9-4837-847c-d5b4dba154c8"), "DK", "Denmark" },
                    { new Guid("e29d7a2f-c80a-4393-8bcc-bc2fb5dd1b09"), "EE", "Estonia" },
                    { new Guid("ef855cb1-884d-4f99-95ac-ab299699af54"), "HR", "Croatia" },
                    { new Guid("d146989a-1e20-433a-91db-2156302856b8"), "FR", "France" },
                    { new Guid("7763a453-b88e-40d4-bd40-c61b50f70ea5"), "DE", "Germany" },
                    { new Guid("2d5e5281-4a8c-4f15-807f-203122e5c60c"), "EL", "Greece" },
                    { new Guid("2b585a32-e138-442b-a762-87c3709964ab"), "HU", "Hungary" },
                    { new Guid("c96bb7ed-78c0-4625-af22-bf52ece75913"), "IS", "Iceland" },
                    { new Guid("6c153327-395d-4510-817b-a22ad608d4d1"), "IE", "Ireland" },
                    { new Guid("e9702f74-5db1-40aa-87f1-35c60a758669"), "FI", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "N", "EN", "Administrative and support service activities" },
                    { new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "O", "EN", "Public administration and defence; compulsory social security" },
                    { new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "P", "EN", "Education" },
                    { new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Q", "EN", "Human health and social work activities" },
                    { new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "T", "EN", "Activities of households as employers; undifferentiated goods-and services-producing activities of households for own use" },
                    { new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "S", "EN", "Other services activities" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "Language", "Title" },
                values: new object[,]
                {
                    { new Guid("18bcd142-95cf-4e86-bdb7-99696e6f027f"), "U", "EN", "Activities of extraterritorial organisations and bodies" },
                    { new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "M", "EN", "Professional, scientific and technical activities" },
                    { new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "R", "EN", "Arts, entertainment and recreation" },
                    { new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "L", "EN", "Real estate activities" },
                    { new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "J", "EN", "Information and communication" },
                    { new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "B", "EN", "Mining and quarrying" },
                    { new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "I", "EN", "Accommodation and food service activities" },
                    { new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "H", "EN", "Transporting and storage" },
                    { new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "G", "EN", "Wholesale and retail trade; repair of motor vehicles and motorcycles" },
                    { new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "F", "EN", "Construction" },
                    { new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "E", "EN", "Water supply; sewerage; waste managment and remediation activities" },
                    { new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "D", "EN", "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "C", "EN", "Manufacturing" },
                    { new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "A", "EN", "Agriculture, forestry and fishing" },
                    { new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "K", "EN", "Financial and insurance activities" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { new Guid("d715d682-421b-4066-ae0f-fed3b18f0798"), "EN", "English" });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("eed82f80-4e74-435d-9371-fba9683b33ad"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)3, "Equipment" },
                    { new Guid("90a35599-3c47-4389-b571-c9d3c7957daf"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)4, "Other" },
                    { new Guid("aa2e4a07-25cf-454b-9505-118ee9077477"), (short)23, null, new Guid("4bf467d0-1c9d-469d-9dad-45b6bf4b7f47"), (short)1, "Other" },
                    { new Guid("aa02701e-c0d0-4c27-a09d-7a4987629640"), (short)23, null, new Guid("0bff5c28-137c-4890-90df-ba7e0746431c"), (short)1, "Other" },
                    { new Guid("5087771d-cce4-4521-a3cb-a14b1891abba"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)2, "Office" },
                    { new Guid("0bff5c28-137c-4890-90df-ba7e0746431c"), (short)22, null, null, (short)3, "Packaging" },
                    { new Guid("a560bf73-2db4-46de-a121-17756a2cd4ad"), (short)23, null, new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)1, "Manufacturing building" },
                    { new Guid("5a7a66cb-25f4-462b-b1f7-47b97735d7da"), (short)21, null, null, (short)9, "Other" },
                    { new Guid("e77f9a30-6e69-432d-9c8e-88380ba63de2"), (short)23, null, new Guid("09b845a4-df9c-4f53-b833-1f69ae6d1835"), (short)1, "Other" },
                    { new Guid("09b845a4-df9c-4f53-b833-1f69ae6d1835"), (short)22, null, null, (short)1, "Resources" },
                    { new Guid("3253125f-cc5c-4269-a6e2-d9e95f0d4c3a"), (short)23, null, new Guid("5a7a66cb-25f4-462b-b1f7-47b97735d7da"), (short)1, "Other" },
                    { new Guid("c7b32094-6538-4e72-ad49-6ea1fda21562"), (short)22, null, null, (short)4, "Salaries" },
                    { new Guid("e1371329-8c9e-4ab3-95fe-654e7f64dfc4"), (short)23, null, new Guid("f61f60ab-7991-4dac-b40e-c742dcef878b"), (short)1, "Other" },
                    { new Guid("f61f60ab-7991-4dac-b40e-c742dcef878b"), (short)21, null, null, (short)8, "Marketing" },
                    { new Guid("fb2a304a-f8fb-4fc2-ae29-eb95cd44bf6c"), (short)22, null, null, (short)2, "Rent (short term)" },
                    { new Guid("08871a1a-331b-44af-8395-9bdf2287ed8c"), (short)23, null, new Guid("c7b32094-6538-4e72-ad49-6ea1fda21562"), (short)1, "Employees directly involved in production / service" },
                    { new Guid("7ac334c8-cafd-4f64-8414-00c61aa80cb7"), (short)22, null, null, (short)7, "Marketing" },
                    { new Guid("67dc4bec-4276-44df-a573-e95b64864a7e"), (short)22, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("54afad44-3157-4521-90df-543d4686355a"), (short)23, null, new Guid("67dc4bec-4276-44df-a573-e95b64864a7e"), (short)1, "Other" },
                    { new Guid("ef60cdef-d5b1-421a-aa36-10463faf9f6e"), (short)22, null, null, (short)6, "Permits & licenses" },
                    { new Guid("03af662c-036c-43d8-95c7-e07b9388495c"), (short)23, null, new Guid("ef60cdef-d5b1-421a-aa36-10463faf9f6e"), (short)1, "Other" },
                    { new Guid("a4b8b286-4fc6-4021-ab42-3952154ffeba"), (short)23, null, new Guid("7ac334c8-cafd-4f64-8414-00c61aa80cb7"), (short)1, "Other" },
                    { new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)22, null, null, (short)8, "Distribution" },
                    { new Guid("e31f5678-6604-47a6-ac67-724b8d0d54e8"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)1, "Transport" },
                    { new Guid("bbe1a5d6-d7d1-4d70-a5cf-00589419ce8d"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)2, "Cost of warehouse" },
                    { new Guid("c267cba0-ef66-48d5-96bd-74d4efd1b52b"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)3, "Fees to distributors" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("de834ef4-a990-4a17-9385-e6a6c226189c"), (short)23, null, new Guid("e50d6201-cd2e-46bb-b9b0-3a723ab72a79"), (short)4, "Other" },
                    { new Guid("4a3658fb-71ac-4feb-9104-7761fdd5cc9b"), (short)22, null, null, (short)9, "Other" },
                    { new Guid("7c36e454-f5df-4cbf-9507-01a389bcb923"), (short)23, null, new Guid("4a3658fb-71ac-4feb-9104-7761fdd5cc9b"), (short)1, "Other" },
                    { new Guid("a5a126b8-fb9a-413c-a5fa-53870b90df77"), (short)24, null, null, (short)1, "Asset sale" },
                    { new Guid("d050dc8f-aa16-47f8-ab35-ae6fc8d7a3ae"), (short)24, null, null, (short)2, "Usage fee" },
                    { new Guid("69646d5e-0e73-4056-9dac-70ff0d0a9ebe"), (short)23, null, new Guid("c7b32094-6538-4e72-ad49-6ea1fda21562"), (short)2, "Other" },
                    { new Guid("4bf467d0-1c9d-469d-9dad-45b6bf4b7f47"), (short)21, null, null, (short)7, "Permits & Licenses" },
                    { new Guid("2d9ebc0f-7a82-4891-8dc6-1fa64b5fa22d"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)1, "Manufacturing buildings" },
                    { new Guid("ac1f0f22-1958-45fd-851b-130a155e86c3"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)4, "Marketing" },
                    { new Guid("a571bc0b-8f30-4070-b16b-cd873a2deab7"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)4, "Other" },
                    { new Guid("1b776dfa-533e-4511-8185-5c576db8dcec"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)3, "Transport" },
                    { new Guid("db69b609-d71a-417a-9142-f8b5dbeb7cb3"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)2, "Production equipment and machinery" },
                    { new Guid("e673e497-be75-4692-952c-8cdf3d5a9714"), (short)23, null, new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)1, "IT (office) equipment" },
                    { new Guid("e4c57d7e-a1c6-462a-8f83-35aa7e989ddb"), (short)21, null, null, (short)3, "Rent of equipment" },
                    { new Guid("373f6176-6eef-4866-96ff-2c4efe5c4a76"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)4, "Other" },
                    { new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)21, null, null, (short)4, "Utilities" },
                    { new Guid("c7250794-8be0-4cdb-99e7-37337b2e8fc1"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)3, "Sales buildings (shops)" },
                    { new Guid("bf7c1d8a-7240-4c81-84e2-b96709e3c3ba"), (short)24, null, null, (short)3, "Subscription fee" },
                    { new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)21, null, null, (short)2, "Rent of buildings" },
                    { new Guid("e221190c-00bc-404f-a540-708d0e673454"), (short)23, null, new Guid("df741ccc-d2ef-4797-8c96-8b5be0344f88"), (short)1, "Other" },
                    { new Guid("df741ccc-d2ef-4797-8c96-8b5be0344f88"), (short)21, null, null, (short)1, "Rent of office" },
                    { new Guid("41655b64-362b-4402-af8d-a777ed912c97"), (short)20, null, null, (short)3, "Highly" },
                    { new Guid("0367b12d-3444-4c35-8045-d8ecc607cc00"), (short)20, null, null, (short)2, "Medium" },
                    { new Guid("c5acf766-38a0-4cf2-8649-6074f10a6b9f"), (short)23, null, new Guid("da2dac96-650b-4d54-a984-9c6bae0653c7"), (short)2, "Inventory buildings" },
                    { new Guid("fe7ff7a5-af48-4eb2-b60e-0d76c808a43f"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)5, "Other" },
                    { new Guid("e6aaacaf-9550-4937-bf13-0d1ff0b69874"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)1, "Electricity" },
                    { new Guid("36c027b7-849b-4466-bafa-8e3441a53fb9"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)3, "Gas" },
                    { new Guid("fb4a4c08-a17d-444c-9776-92c54acd6940"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)3, "Finance management" },
                    { new Guid("860adbf1-baf5-4cf2-8b55-a5baca045e60"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)2, "Factory workers / service" },
                    { new Guid("c804bad3-0387-44fb-9817-93085d14ccf9"), (short)23, null, new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)1, "Management" },
                    { new Guid("f5d95c3b-4894-41b1-98b8-b1eb44ef436a"), (short)21, null, null, (short)6, "Salaries" },
                    { new Guid("5cb61693-d73a-40fd-9664-01921eeba8cc"), (short)23, null, new Guid("abdbd71b-4c23-4cc1-aacb-2dac249540f3"), (short)1, "Other" },
                    { new Guid("abdbd71b-4c23-4cc1-aacb-2dac249540f3"), (short)21, null, null, (short)5, "Outsourcing of specified services" },
                    { new Guid("a4e19cfd-e63d-4eaf-b45e-8a298a3be406"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)2, "Water" },
                    { new Guid("31ca9e3a-ff44-41db-8833-2661abddb353"), (short)23, null, new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)3, "Other" },
                    { new Guid("eaee254e-e4c3-4ebd-86eb-ed38a54c238b"), (short)23, null, new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)1, "Accountant" },
                    { new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)21, null, null, (short)4, "Outsourcing of services" },
                    { new Guid("cf1657e0-d4eb-430c-8185-fc80c20aa25c"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)7, "Other" },
                    { new Guid("d54aefa4-bd1c-4c73-b0f1-8e3c58eb29bc"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)6, "Communication" },
                    { new Guid("7d87bb63-1cd8-4ec0-a46d-487c77da365f"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)5, "Maintenance" },
                    { new Guid("2bb3f65a-5c77-4482-9fa3-8b7c2ce555bd"), (short)23, null, new Guid("25532174-0c07-4293-99c2-10c954ad6367"), (short)4, "Heat" },
                    { new Guid("fc510839-c0c3-4883-a917-e35a2b9ea22e"), (short)23, null, new Guid("507b8ec3-8687-4c2c-a6e2-80833c1da93e"), (short)2, "IT support" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("6d62227c-94dc-4ad8-a89c-240fe74f26d6"), (short)24, null, null, (short)4, "Lending, renting, leasing" },
                    { new Guid("c6a66809-c479-4563-95df-cb9396c37e35"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)4, "" },
                    { new Guid("ab606dbd-08d6-49be-8bc6-844812d8b214"), (short)24, null, null, (short)6, "Brokerage fees" },
                    { new Guid("88579996-53e2-4699-a6f0-b97df2421276"), (short)32, null, null, (short)6, "65 - 74" },
                    { new Guid("97f2428a-982b-44a6-8b54-9b7f81c8958b"), (short)32, null, null, (short)7, "75 years or older" },
                    { new Guid("6d1b4bb9-7de0-443d-a9f4-9880cb99fab0"), (short)32, null, null, (short)8, "All age groups" },
                    { new Guid("b30ffa71-9656-4f10-be64-cd92bad378c0"), (short)33, null, null, (short)1, "Low" },
                    { new Guid("d2a35000-6520-47fb-921a-1968a38f6eb8"), (short)33, null, null, (short)2, "Medium" },
                    { new Guid("bdb6d057-80b7-411a-a6b6-12aae71581c3"), (short)33, null, null, (short)3, "High" },
                    { new Guid("bc6e314f-5d86-40dc-a791-d63be99c22bd"), (short)34, null, null, (short)1, "Primary" },
                    { new Guid("bbab5ef4-bbd3-44aa-a879-1a792a5feada"), (short)34, null, null, (short)2, "Secondary" },
                    { new Guid("4718bb8b-3018-4408-9ff1-68ab9c4f2b87"), (short)34, null, null, (short)3, "Higher education" },
                    { new Guid("c055ffa9-c8e4-4f77-859d-cae9785736f6"), (short)35, null, null, (short)1, "Domestic" },
                    { new Guid("dd32e3d1-de98-436a-be89-79206cf5204b"), (short)35, null, null, (short)2, "Domestic Urban" },
                    { new Guid("2d5348f7-f619-4de2-a186-ee0ad4fff927"), (short)35, null, null, (short)3, "Domestic Rural" },
                    { new Guid("197debde-3d72-4bae-89e5-e5d9010c8562"), (short)35, null, null, (short)4, "Foreign" },
                    { new Guid("5bf44939-b777-454a-86c2-280eea5fc6dd"), (short)35, null, null, (short)5, "Foreign Urban" },
                    { new Guid("e59e3f4e-077f-4d34-9214-f5b93134cf44"), (short)35, null, null, (short)6, "Foreign Rural" },
                    { new Guid("825d07dd-581b-4473-841c-9ec037746ae2"), (short)35, null, null, (short)7, "Transnational" },
                    { new Guid("a2254a01-9908-42e0-af0d-8a0b04875197"), (short)36, null, null, (short)1, "Small" },
                    { new Guid("bf6b3a07-2578-4ab2-8ca8-21209388c38e"), (short)40, null, null, (short)4, "Other" },
                    { new Guid("fd203ec9-9519-4adb-8c98-314cab2b4689"), (short)40, null, null, (short)3, "Printed Promotional/informative materials" },
                    { new Guid("ce619ee3-d636-497f-8238-2ac9c9e79b49"), (short)40, null, null, (short)2, "Ads and Commercials" },
                    { new Guid("2fc70a56-27b6-442b-938c-9c13fb36e316"), (short)40, null, null, (short)1, "Word of Mouth" },
                    { new Guid("a9677a24-bc3c-40aa-8265-4be52545113b"), (short)39, null, null, (short)2, "female" },
                    { new Guid("c7cb2b43-fc30-40ec-b06b-2bdeadc6000f"), (short)39, null, null, (short)1, "male" },
                    { new Guid("c31ebd92-79bc-417c-bab4-0c3960778ef7"), (short)32, null, null, (short)5, "35 - 64" },
                    { new Guid("da790cb3-6e70-4f32-8e18-fab771727c07"), (short)38, null, null, (short)4, "Non-Government organisations" },
                    { new Guid("9454b766-1241-44ca-ae12-63e101fbae55"), (short)38, null, null, (short)2, "National Government" },
                    { new Guid("7851aaea-93c4-48e8-8817-563ef55cf61a"), (short)38, null, null, (short)1, "International Organisations" },
                    { new Guid("593cfcc0-bc1d-4189-b0af-bdd5f51b0b8d"), (short)37, null, null, (short)2, "Services" },
                    { new Guid("3a0ffc1e-bede-4f74-9cff-5735a0b600f9"), (short)37, null, null, (short)1, "Goods" },
                    { new Guid("bbc364e1-2394-48c7-8aaf-774ba76942b6"), (short)36, null, null, (short)3, "Large" },
                    { new Guid("37634235-3b04-4aad-a647-6d79a2c88655"), (short)36, null, null, (short)2, "Medium" },
                    { new Guid("a3a74886-85d0-4861-baa3-7d09bea0e583"), (short)38, null, null, (short)3, "Muncipality" },
                    { new Guid("22d688a4-1dae-42c2-98af-4e076de1ca73"), (short)32, null, null, (short)4, "25 - 34" },
                    { new Guid("109af523-c8ae-409f-a5ab-c15d02ce5858"), (short)32, null, null, (short)3, "18 - 24" },
                    { new Guid("6e0f7f5e-1780-4218-a5c5-f6be04b49a12"), (short)32, null, null, (short)2, "12 - 17" },
                    { new Guid("2e4ee3fe-7f1b-4105-b37e-c1ee4d8d4d40"), (short)30, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)1, "Fixed location" },
                    { new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)29, null, new Guid("91d5edff-f361-47aa-8d3c-b420681dcd5e"), (short)1, "Physical" },
                    { new Guid("91d5edff-f361-47aa-8d3c-b420681dcd5e"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)1, "Own shop" },
                    { new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)27, null, null, (short)1, "Direct sales" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("925f1189-56f9-4cc3-ae1e-50ddbab2a29d"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)4, "Auctions" },
                    { new Guid("e1d977e9-0c83-4f69-8bfe-3f2689b6cec2"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)3, "Real time market" },
                    { new Guid("a82e9156-c03c-4815-80ca-35508e2371ad"), (short)30, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)2, "Mobile" },
                    { new Guid("be31e251-6784-4472-a771-86c159b3f9fb"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)2, "Yield management" },
                    { new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)25, null, null, (short)2, "Dynamic pricing" },
                    { new Guid("fef1c6f8-493c-4641-9f0c-1141cb762605"), (short)26, null, new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)3, "Volume dependent" },
                    { new Guid("2483ee5b-da92-4400-aa64-88eb8a1ea152"), (short)26, null, new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)2, "Product feature dependent" },
                    { new Guid("75c81e8e-aa76-4f81-895e-0465da7b6d7a"), (short)26, null, new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)1, "List price" },
                    { new Guid("266f43d7-8b45-4880-bd3c-88dcbd017fb4"), (short)25, null, null, (short)1, "Fixed pricing" },
                    { new Guid("80b218db-fd97-43a7-9945-dbe555990934"), (short)24, null, null, (short)7, "Advertising" },
                    { new Guid("2897fd3b-afad-47e5-8407-3582fb0cdf07"), (short)26, null, new Guid("363f16df-3f11-4643-9c93-cd64242c0bf5"), (short)1, "Negotiation" },
                    { new Guid("5393af35-4b9f-49f4-a366-e1430860ee49"), (short)24, null, null, (short)5, "Licensing" },
                    { new Guid("f90efa9d-ff68-4fe7-b6b3-bf55850f7437"), (short)31, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)1, "Self pickup" },
                    { new Guid("ee238326-5d11-4531-92b0-6565f42ae874"), (short)31, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)3, "Courier service" },
                    { new Guid("ef193985-9b48-495e-a40c-3f53f2b0b30a"), (short)32, null, null, (short)1, "Under 12" },
                    { new Guid("d57d1d34-e721-4d46-a5f4-a3f9e7d3a198"), (short)27, null, null, (short)5, "Other" },
                    { new Guid("b0cb1000-5a92-47a0-a45b-499c5f580524"), (short)27, null, null, (short)4, "Agents" },
                    { new Guid("e1915d59-a5a4-43bd-a5db-7c8ab320371a"), (short)27, null, null, (short)3, "Wholesalers" },
                    { new Guid("97070765-ae68-4bb1-9b50-d99761807ef4"), (short)27, null, null, (short)2, "Retailers" },
                    { new Guid("169b2610-f5eb-47c1-88d8-95831dae4a59"), (short)20, null, null, (short)1, "Not" },
                    { new Guid("7ace64a6-77c6-44de-a675-78ff13ca0859"), (short)31, null, new Guid("4152d046-a8a2-4adc-a6b3-b2de8c3cafbf"), (short)2, "Delivery to home" },
                    { new Guid("df0fa10f-05df-485a-9f90-aaae6cc11ebc"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)3, "Direct visit" },
                    { new Guid("e8f6e9d6-0e37-4182-9c47-33c9d119ac73"), (short)31, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)3, "To the email" },
                    { new Guid("b2706a04-d62f-4103-ae40-6b5868029c73"), (short)31, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)2, "Courier service" },
                    { new Guid("6dad8d59-0786-43e5-98a6-dd6d4fdc7688"), (short)31, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)1, "Own delivery" },
                    { new Guid("3fe4a8e4-daa1-4edb-a209-2d9f6f9ced35"), (short)30, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)2, "Platform" },
                    { new Guid("404d16aa-f0f7-452a-88ce-13109e57724a"), (short)30, null, new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)1, "Own website" },
                    { new Guid("65c4d434-7f22-44ce-b9a3-c9681ff199a8"), (short)29, null, new Guid("91d5edff-f361-47aa-8d3c-b420681dcd5e"), (short)2, "Online" },
                    { new Guid("c06464ec-0248-4964-b09a-dd6fd7c6cc17"), (short)28, null, new Guid("3c81ac65-960e-44aa-b752-17808fa31c1f"), (short)2, "Market/Fairs" },
                    { new Guid("6a09985e-01b1-4034-9a82-05945dce19a5"), (short)19, null, null, (short)3, "Premium" },
                    { new Guid("07d5452f-6ea6-4ae6-9395-89fd1d0eeab0"), (short)15, null, null, (short)13, "Uncertainty" },
                    { new Guid("0fe097a6-bd15-4272-885e-de82c1d08677"), (short)19, null, null, (short)1, "Basic" },
                    { new Guid("f5e69507-6f10-49bd-a3aa-edd3b0845e67"), (short)3, null, null, (short)14, "Demographic trends" },
                    { new Guid("7a4a57fd-79e7-4141-88b5-e57a22d7ef9a"), (short)3, null, null, (short)15, "Cultural norms and values" },
                    { new Guid("6a08ddad-1878-46da-a843-a1856a93dd91"), (short)3, null, null, (short)16, "Lifestyle trends" },
                    { new Guid("90e3590d-b9d4-4e07-87cf-e45659e486f0"), (short)3, null, null, (short)17, "Technological change" },
                    { new Guid("70fad897-dcb6-4818-a9b1-39b2b08dd93c"), (short)3, null, null, (short)18, "Cybersecurity" },
                    { new Guid("ed7c4844-5ab2-431f-b765-ea94db35952d"), (short)3, null, null, (short)19, "Climate and its change" },
                    { new Guid("457f681a-f052-408d-a7f6-8979f6c47063"), (short)3, null, null, (short)20, "Natural disasters" },
                    { new Guid("adb303c0-23af-4eca-948c-9f09142bf015"), (short)3, null, null, (short)21, "Competition" },
                    { new Guid("e436274e-cbea-42e0-be23-8dcf0804daf0"), (short)3, null, null, (short)22, "Bargaining power of suppliers" },
                    { new Guid("75ccb567-91f3-4966-91f6-30565cb59ba0"), (short)3, null, null, (short)23, "Bargaining power of buyers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("5a78cb95-3eb4-432a-a0cc-68886ae692da"), (short)3, null, null, (short)24, "Potential/future competition" },
                    { new Guid("e3773f81-fa98-4ad4-b235-2bab8369e22b"), (short)3, null, null, (short)25, "Substitution possibilities" },
                    { new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)5, "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function.", null, (short)1, "Physical resources" },
                    { new Guid("22656f17-0f99-438f-a934-b71d64a7fbd6"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)1, "Buildings" },
                    { new Guid("d8aaf777-bd2b-40e6-9eab-ea5e06f34c55"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("22656f17-0f99-438f-a934-b71d64a7fbd6"), (short)1, "Ownership type" },
                    { new Guid("be005f23-8f91-4776-835c-f4e231bdb1e5"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("22656f17-0f99-438f-a934-b71d64a7fbd6"), (short)2, "Frequency" },
                    { new Guid("ca5124ab-0c2f-4224-88b1-f579a01d2522"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)2, "Equipment" },
                    { new Guid("7682545b-fbee-475e-ab30-5a1f694c81c6"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)3, "Software" },
                    { new Guid("aa351db4-3b28-4cab-ad95-722bfcba23dc"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)2, "Licenses" },
                    { new Guid("25feae02-736b-44c7-b6e7-06fa502f4c63"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)1, "Brands" },
                    { new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)5, "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company.", null, (short)2, "Intellectual resources" },
                    { new Guid("5d465e51-2608-4a01-af4f-566fcc5e7519"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3c36a2c7-4cd3-43b1-98f5-270c8c98edd7"), (short)2, "Frequency" },
                    { new Guid("229ee29a-cac8-488c-9a75-37fbdbff4a42"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3c36a2c7-4cd3-43b1-98f5-270c8c98edd7"), (short)1, "Ownership type" },
                    { new Guid("f71ce8b4-dbd8-4280-a216-66677e115f74"), (short)3, null, null, (short)13, "Infrastructure" },
                    { new Guid("3c36a2c7-4cd3-43b1-98f5-270c8c98edd7"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)5, "Other" },
                    { new Guid("fc87ba60-6c43-4420-bdb0-eacc00ffbca5"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)4, "Raw materials" },
                    { new Guid("b362e97b-b47d-4183-82b2-ecc6dbd9bc6f"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3943c265-621b-4738-93c8-4470986c3af3"), (short)2, "Frequency" },
                    { new Guid("4a427807-de66-429c-8ae0-2185f71d2543"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("3943c265-621b-4738-93c8-4470986c3af3"), (short)1, "Ownership type" },
                    { new Guid("3943c265-621b-4738-93c8-4470986c3af3"), (short)6, null, new Guid("b3ef13cf-c5f0-46d9-ba7b-79ab2147effb"), (short)3, "Transport" },
                    { new Guid("335fcecd-5a78-4b23-a065-be7eaeae4f20"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("ca5124ab-0c2f-4224-88b1-f579a01d2522"), (short)2, "Frequency" },
                    { new Guid("df75df99-8916-4eba-8ef1-636c8cc2478b"), (short)8, "[{\"title\":\"Rent\",\"selected\":false},{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("ca5124ab-0c2f-4224-88b1-f579a01d2522"), (short)1, "Ownership type" },
                    { new Guid("8f4213e4-50ce-42f9-aee1-73e2d6efeaff"), (short)8, "[{\"title\":\"Buy\",\"selected\":false},{\"title\":\"Own\",\"selected\":false}]", new Guid("fc87ba60-6c43-4420-bdb0-eacc00ffbca5"), (short)1, "Ownership type" },
                    { new Guid("a3935a3c-ad19-4395-8020-c7c73a9587f3"), (short)3, null, null, (short)12, "New markets" },
                    { new Guid("eea606be-c02d-41a6-a35e-e8701086869c"), (short)3, null, null, (short)11, "Market size" },
                    { new Guid("f611bf2d-3089-4e53-b362-cf740f1f102a"), (short)3, null, null, (short)10, "Accessibility of financial resources" },
                    { new Guid("a80edb58-5f37-4410-891f-9c0446982131"), (short)1, "a", null, (short)14, "Product assortment" },
                    { new Guid("e0c84bf6-dbc3-450e-95ac-fe42299e05df"), (short)1, "a", null, (short)13, "Product design" },
                    { new Guid("acb3829b-c7e2-45eb-810d-80cd3d4f5f39"), (short)1, "a", null, (short)12, "Supporting processes" },
                    { new Guid("e8daf129-e055-4683-b4aa-c1ebd5934e25"), (short)1, "a", null, (short)11, "Management processes" },
                    { new Guid("7d1df83e-9bdd-47eb-8fad-ad7f7b1a8329"), (short)1, "a", null, (short)10, "Operational processes" },
                    { new Guid("7cb479d5-c8e5-40c3-909c-fbde2188b593"), (short)1, "a", null, (short)9, "Copyrights" },
                    { new Guid("651a1fcd-0ad6-4311-9bb0-61cb8b210146"), (short)1, "a", null, (short)15, "Packaging and labeling" },
                    { new Guid("17063605-ce9b-4e92-9d41-52ea1cee6632"), (short)1, "a", null, (short)8, "Trademarks" },
                    { new Guid("2f2f8c7f-ac0c-4115-a3b8-714e0d6529d9"), (short)1, "a", null, (short)6, "Corporate image" },
                    { new Guid("4820dc72-7756-4510-9d6a-9a062e2fc22e"), (short)1, "a", null, (short)5, "Skills and experience of employees" },
                    { new Guid("f782da7f-d1e2-4cf8-9267-ea403651f58d"), (short)1, "a", null, (short)4, "Inventory" },
                    { new Guid("7322bf24-fee2-4a31-bcda-c4e7a762c162"), (short)1, "a", null, (short)3, "Vehicles" },
                    { new Guid("92455eb0-dd6b-4c56-a883-8a39f2dafbae"), (short)1, "a", null, (short)2, "Facilities and equipment" },
                    { new Guid("9d608883-4f26-4303-9903-d8de46433f04"), (short)1, "a", null, (short)1, "Land" },
                    { new Guid("8e07b533-f25e-4227-8fd8-1b2f19a7b4f3"), (short)1, "a", null, (short)7, "Patents" },
                    { new Guid("d4ede701-8037-488b-9794-9b8632c1c3c0"), (short)6, null, new Guid("d938dd78-01a5-4d06-9757-149402db6e7d"), (short)4, "Other" },
                    { new Guid("d89128ed-072e-4f22-aea3-7f058c855888"), (short)1, "a", null, (short)16, "Complementary and after-sales service" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("fee1bca2-317f-4b5d-9c8b-9414a16a4d0f"), (short)1, "a", null, (short)18, "Return of goods" },
                    { new Guid("316e0636-3ce5-4ba0-b72f-7223698fb8fb"), (short)3, null, null, (short)9, "Accessibility of tangible resources" },
                    { new Guid("636b2c40-cfd3-4eb3-9003-dac709ff860b"), (short)3, null, null, (short)8, "Accessibility of human resources" },
                    { new Guid("3861b60b-1598-4b1e-be5a-8d815e6674a7"), (short)3, null, null, (short)7, "Interest rate" },
                    { new Guid("ab5ffc0e-da10-4ed8-a7fb-369785911381"), (short)3, null, null, (short)6, "Exchange rate" },
                    { new Guid("62d8c572-b4b2-45e7-be6d-607de423b903"), (short)3, null, null, (short)5, "Inflation" },
                    { new Guid("9ee57d37-6425-409e-b7fd-aa97f3010e9f"), (short)3, null, null, (short)4, "Income and wealth" },
                    { new Guid("42c22ecb-1f79-467a-8b1f-2e709de5a5e2"), (short)1, "a", null, (short)17, "Guarantees and warranties" },
                    { new Guid("cdc1a197-fb79-42b9-a7cb-9ff8fd0e1622"), (short)3, null, null, (short)3, "Economic growth" },
                    { new Guid("e04a476c-a409-472a-beb4-819b104d9731"), (short)3, null, null, (short)1, "Political stability" },
                    { new Guid("e93d16a1-fc41-4443-b88b-023d051103bf"), (short)1, "a", null, (short)23, "Advertising, PR and sales promotion" },
                    { new Guid("0ea957e0-d54e-4729-b7a7-1a4ac6b0b9fc"), (short)1, "a", null, (short)22, "Customer convenient access to products" },
                    { new Guid("9f62a58d-00b7-43ee-8374-ae679f5d68af"), (short)1, "a", null, (short)21, "Payment terms" },
                    { new Guid("c6e60be8-eef9-41fe-948b-133375a3c43b"), (short)1, "a", null, (short)20, "Discounts" },
                    { new Guid("1afacd96-1b6b-4958-bffd-af953759ee25"), (short)1, "a", null, (short)19, "Price" },
                    { new Guid("c48b255a-2451-42e2-a889-0a76e5b850e0"), (short)3, null, null, (short)2, "Government regulation" },
                    { new Guid("7146d46e-a7b5-429b-85ee-74f24e9b8894"), (short)19, null, null, (short)2, "Medium" },
                    { new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)5, "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal.", null, (short)3, "Human resources" },
                    { new Guid("f5311b29-88a0-4500-8173-b2e16a3137ed"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false},{\"title\":\"Myself\",\"selected\":false}]", new Guid("e2d723ce-1ea6-4d1e-a35e-5b47907d2d2a"), (short)1, "Ownership type" },
                    { new Guid("adcdc439-8170-4fab-a70d-457c1b98bc92"), (short)15, null, null, (short)8, "Result of R&D" },
                    { new Guid("7baa945c-4bcb-46b9-8e95-c72fe5b49778"), (short)15, null, null, (short)9, "Driven by market pull" },
                    { new Guid("f9862c29-9a20-4cbe-8fa2-5e1660f6b8da"), (short)15, null, null, (short)10, "Discontinuous" },
                    { new Guid("dfe881a2-cd69-4295-a16a-edfb2c8fc0bf"), (short)15, null, null, (short)11, "Based on new technologies" },
                    { new Guid("121f0a92-8b35-4890-8384-b66f48db9ac5"), (short)15, null, null, (short)12, "Leads to a new design" },
                    { new Guid("5365d22f-9372-4471-baab-f1175d25ae0f"), (short)15, null, null, (short)14, "New set of features" },
                    { new Guid("d39c0155-1419-4a48-962f-2e42d5aca11b"), (short)15, null, null, (short)15, "Driven by technology" },
                    { new Guid("4cb290b2-7fbc-4846-be7b-79f9e3efbb46"), (short)15, null, null, (short)16, "Expertise of manufacturer" },
                    { new Guid("49ac2e9c-ecbb-4a14-aa35-a35efb4ff919"), (short)15, null, null, (short)17, "Manufacturing complexity" },
                    { new Guid("b00a4df7-4b4e-41b6-a2ac-cabf1e75ce5d"), (short)15, null, null, (short)18, "Special materials and components" },
                    { new Guid("cf6361ec-886e-4b0a-b53b-af9a477f334b"), (short)15, null, null, (short)19, "Workmanship" },
                    { new Guid("187d8314-5350-4f30-a68c-fde38021a178"), (short)15, null, null, (short)20, "Rarity" },
                    { new Guid("8f79391b-d687-4515-9292-5b4958ef0589"), (short)15, null, null, (short)21, "Durability" },
                    { new Guid("7da1cdc9-d7e4-4234-b31b-9e0570e5e9c6"), (short)15, null, null, (short)22, "Comfortability & Usability" },
                    { new Guid("58b41b4d-da41-4f9b-9cec-5da895a0b502"), (short)15, null, null, (short)23, "Safety" },
                    { new Guid("2ad13e8d-672f-4eb7-87eb-ca33891eeffb"), (short)15, null, null, (short)24, "Aesthetics" },
                    { new Guid("f2424d76-d25a-430a-ab55-3c0480a1f56c"), (short)15, null, null, (short)25, "Extraordinariness" },
                    { new Guid("c109d793-c4af-4ade-b0c1-17157bc927de"), (short)18, null, null, (short)3, "Highly" },
                    { new Guid("44468654-bf65-4e70-ab92-c4bf5c399d03"), (short)18, null, null, (short)2, "Medium" },
                    { new Guid("329ecdc4-faeb-43fa-b53e-9efad8c7b4d3"), (short)18, null, null, (short)1, "Not" },
                    { new Guid("4261a424-6b58-467c-a5da-1844827950b5"), (short)17, null, null, (short)4, "High-end" },
                    { new Guid("10f4eb49-006c-4f56-89d4-fb1743313707"), (short)17, null, null, (short)3, "Market" },
                    { new Guid("1245994e-b52c-4c9a-9060-8c4856742197"), (short)17, null, null, (short)2, "Economy" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("ae7c712d-f780-429f-aed6-87509c0bc43c"), (short)15, null, null, (short)7, "Improvement of existing characteristics" },
                    { new Guid("3325759e-8add-4b30-a00c-10ce7fbbd330"), (short)17, null, null, (short)1, "Free" },
                    { new Guid("085df303-2e4d-4dd0-9e9f-204085352597"), (short)16, null, null, (short)6, "Fees come from another product" },
                    { new Guid("fe928bb7-8ef0-4f01-b40b-f7da62c1c084"), (short)16, null, null, (short)5, "Different price for individuals" },
                    { new Guid("87ffbf10-1f99-4d0b-ae5a-202736ed5a4e"), (short)16, null, null, (short)4, "Different price for business" },
                    { new Guid("67cdf9e6-acc0-404a-a189-78325e83f547"), (short)16, null, null, (short)3, "Paid plans" },
                    { new Guid("93916775-80bd-4355-bfda-907e8a737cbe"), (short)16, null, null, (short)2, "Additional functions" },
                    { new Guid("75bcee28-686d-47e6-82b2-5c2a32168377"), (short)16, null, null, (short)1, "Non time limited usage" },
                    { new Guid("95f441a5-2f4e-4c6e-93e7-5e18cbe26749"), (short)16, null, null, (short)7, "Other" },
                    { new Guid("e2d723ce-1ea6-4d1e-a35e-5b47907d2d2a"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)1, "Specialists & Know-how" },
                    { new Guid("96f638ad-c41f-492f-982a-7f4018bcb3a6"), (short)15, null, null, (short)6, "Dominant design unchanged" },
                    { new Guid("bdf69fe7-c3e3-44e1-a984-41041ea08e96"), (short)15, null, null, (short)4, "Continuous" },
                    { new Guid("cc3cddf7-c4fa-4679-8feb-58935864f5b2"), (short)11, null, null, (short)4, "Wholesalers" },
                    { new Guid("9c1015a6-00a0-4d86-a723-c56bb7da4df5"), (short)11, null, null, (short)3, "Retailers" },
                    { new Guid("e83d8ad7-c709-41b3-b1cd-15e1871fb374"), (short)11, "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance", null, (short)2, "Highly diversified distributors" },
                    { new Guid("4ae078f2-21a9-4f01-b11d-92eace60e38e"), (short)11, "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors", null, (short)1, "Self distribution" },
                    { new Guid("f4056ba5-de88-45b6-92a9-6f9707e4f494"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("3066446c-5e9b-4321-bdf6-a47f367f61c5"), (short)2, "Frequency" },
                    { new Guid("0f3080b7-034f-4891-9d66-e1d6f0d8cd8c"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("3066446c-5e9b-4321-bdf6-a47f367f61c5"), (short)1, "Ownership type" },
                    { new Guid("88fa173b-e9a8-44a7-be1a-43fab1989a02"), (short)11, null, null, (short)5, "Agents" },
                    { new Guid("3066446c-5e9b-4321-bdf6-a47f367f61c5"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)4, "Other" },
                    { new Guid("d4c9d2ba-44e3-4eff-98a5-f968bdc25952"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("4b0ba05e-88c6-4c54-a313-880e3aee9905"), (short)1, "Ownership type" },
                    { new Guid("4b0ba05e-88c6-4c54-a313-880e3aee9905"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)3, "Employees directly involved in production or service" },
                    { new Guid("73fcb86d-53b1-4063-87b8-3aa42702c820"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("b4517dc0-8202-4cff-be3e-c11a1f78037c"), (short)2, "Frequency" },
                    { new Guid("ab3c7d47-062b-437e-a164-4172444e276f"), (short)8, "[{\"title\":\"Employ\",\"selected\":false},{\"title\":\"Outsource\",\"selected\":false}]", new Guid("b4517dc0-8202-4cff-be3e-c11a1f78037c"), (short)1, "Ownership type" },
                    { new Guid("b4517dc0-8202-4cff-be3e-c11a1f78037c"), (short)6, null, new Guid("63cee727-8378-4603-8b0b-839751dfeed1"), (short)2, "Administrative" },
                    { new Guid("941b8d92-ecb7-4885-b95c-e57408d66213"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("e2d723ce-1ea6-4d1e-a35e-5b47907d2d2a"), (short)2, "Frequency" },
                    { new Guid("58eac7eb-b165-4056-8df3-27e3ab23d1e9"), (short)8, "[{\"title\":\"Permanently\",\"selected\":false},{\"title\":\"Time to time\",\"selected\":false}]", new Guid("4b0ba05e-88c6-4c54-a313-880e3aee9905"), (short)2, "Frequency" },
                    { new Guid("2984418a-638e-4da9-be1d-12ba94d8ffaf"), (short)15, null, null, (short)5, "Based on old technology" },
                    { new Guid("4c53b804-2392-4744-a1ce-c11d424d7aab"), (short)11, null, null, (short)6, "Others" },
                    { new Guid("50477479-4b86-4ce1-bcea-c3e7b075f5c8"), (short)12, null, null, (short)2, "Equipment and real estate" },
                    { new Guid("5eb6013b-0cca-4f89-b39d-e711477a972f"), (short)15, null, null, (short)3, "No improvements or innovations" },
                    { new Guid("0ff6b626-a1ff-4184-b1bb-5bf2992091bd"), (short)15, null, null, (short)2, "Product or service already exists in the market" },
                    { new Guid("aae57ccf-f33c-4a0e-925a-7a65d8ca171e"), (short)15, null, null, (short)1, "Not different from competitors" },
                    { new Guid("c64ed84d-db99-4a25-95f1-79bb99fa6936"), (short)14, null, null, (short)2, "Service" },
                    { new Guid("3f2faea5-f8f6-43b4-80f2-db55874a5c4b"), (short)14, null, null, (short)1, "Physical good" },
                    { new Guid("578b2d6c-608f-4bd7-9e38-1f888650e6b0"), (short)12, null, null, (short)1, "Raw materials, finished or semi-finished goods" },
                    { new Guid("fbaa6538-cedd-43f9-b739-bffcf4f00e96"), (short)13, null, null, (short)1, "Other" },
                    { new Guid("da250714-2420-4d57-8015-44fe1e1ff294"), (short)13, null, null, (short)1, "Non-governmental institutions" },
                    { new Guid("1947e5da-01ea-4d22-8e37-72264d47d9b8"), (short)13, null, null, (short)1, "Government institutions" },
                    { new Guid("37c1161f-aac3-4e5e-81df-3cce00e3b25c"), (short)13, null, null, (short)1, "Associations" },
                    { new Guid("22ab4468-869c-4f8a-94c9-e2f5c3974718"), (short)12, null, null, (short)5, "Human resources" },
                    { new Guid("3bb18f50-91bf-4c73-ad1f-9cdd924127fb"), (short)12, null, null, (short)4, "Financiers" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "OrderValue", "Value" },
                values: new object[,]
                {
                    { new Guid("57edccf6-bc5a-4679-8a9a-99f8c2f97a4e"), (short)12, null, null, (short)3, "Outsourced services" },
                    { new Guid("7a82656a-a993-4a54-b8e6-c69224642dd1"), (short)13, null, null, (short)1, "Consultants" }
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
                    { new Guid("bdd618a9-8314-4db3-a83b-d705c1ab77d1"), "A.01", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Crop and animal production, hunting and related service activities" },
                    { new Guid("43e154b2-376f-4360-b8f7-93702ab10562"), "H.51.22", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Space transport" },
                    { new Guid("564c0075-910d-40d6-af17-9e5c0e56ce8b"), "H.52", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Warehousing and support activities for transportation" },
                    { new Guid("456fec40-6da4-4326-86be-8616698373fb"), "H.52.1", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Warehousing and storage" },
                    { new Guid("688fe54d-ebd0-4401-9cd1-23e425f06d9c"), "H.52.10", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Warehousing and storage" },
                    { new Guid("ab04acf6-9725-479f-91b3-cd4c7e300cc6"), "H.52.2", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Support activities for transportation" },
                    { new Guid("79291abb-b8af-4952-a839-1099e697d83e"), "H.52.21", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Service activities incidental to land transportation" },
                    { new Guid("027601e5-f420-4c04-aff4-de1a95eec373"), "H.52.22", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Service activities incidental to water transportation" },
                    { new Guid("0d6c2b87-826b-43ea-827d-b0de9a3b6099"), "H.52.23", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Service activities incidental to air transportation" },
                    { new Guid("32e9ede0-121e-46eb-a4a2-41886826e6e0"), "H.52.24", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Cargo handling" },
                    { new Guid("5735c0d5-ee2e-4ba2-b1b1-32a5ce9d5ac6"), "H.52.29", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Other transportation support activities" },
                    { new Guid("976d7455-40cc-4bfc-b6ac-9519dbcd0fab"), "H.53", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Postal and courier activities" },
                    { new Guid("52486190-c36c-4f15-8077-23225daf75fc"), "H.53.1", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Postal activities under universal service obligation" },
                    { new Guid("42376332-cdfb-484e-abfa-ca769e56c3af"), "H.51.21", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Freight air transport" },
                    { new Guid("86bc9593-8e60-4be0-9662-88578ed3c3a5"), "H.53.10", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Postal activities under universal service obligation" },
                    { new Guid("c707bc56-1263-4880-8250-0193d22f2bbc"), "H.53.20", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Other postal and courier activities" },
                    { new Guid("9d2c49a6-f551-4a63-abec-884ac43d697e"), "I.55", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Accommodation" },
                    { new Guid("8fc35d2a-b909-4eb9-bbfa-14aa4a5ea0ae"), "I.55.1", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Hotels and similar accommodation" },
                    { new Guid("67484535-7821-46c6-817c-9a634fe1fb13"), "I.55.10", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Hotels and similar accommodation" },
                    { new Guid("2c5a6106-4531-4a34-9a0e-0ff634e8e6dc"), "I.55.2", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Holiday and other short-stay accommodation" },
                    { new Guid("5cccaef5-492a-4364-b41c-a1a660e18d49"), "I.55.20", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Holiday and other short-stay accommodation" },
                    { new Guid("92cbc61b-ef5b-4b11-864b-85f535a93f4b"), "I.55.3", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("9ab2449c-9f37-4ef0-a133-c7df3e244390"), "I.55.30", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Camping grounds, recreational vehicle parks and trailer parks" },
                    { new Guid("ca0f4fc5-e202-4276-b06e-f0a66c9d6590"), "I.55.9", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Other accommodation" },
                    { new Guid("513c211a-bc76-45f7-89c9-faae3dda6909"), "I.55.90", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Other accommodation" },
                    { new Guid("bd4e10f9-a52c-4e3e-91a1-8498cd503df3"), "I.56", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Food and beverage service activities" },
                    { new Guid("6ce92e6f-df12-4631-a20f-6f77decbe4a3"), "I.56.1", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Restaurants and mobile food service activities" },
                    { new Guid("7fcf1c27-720a-4e29-a7b7-78b7e5aca638"), "H.53.2", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Other postal and courier activities" },
                    { new Guid("f1a3031d-6a27-43dc-a4c2-fc1e378f8e14"), "H.51.2", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Freight air transport and space transport" },
                    { new Guid("ed0c94a4-8ae3-418e-a807-c13ec6e77144"), "H.51.10", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Passenger air transport" },
                    { new Guid("6121a6da-d576-4fd0-ad39-870c8f731ee8"), "H.51.1", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Passenger air transport" },
                    { new Guid("0582524b-d413-4cd8-8487-eb6b46186ff5"), "G.47.9", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail trade not in stores, stalls or markets" },
                    { new Guid("d214db5e-c911-4f87-93b6-1b8e976feba7"), "G.47.91", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale via mail order houses or via Internet" },
                    { new Guid("22f98b85-290b-4217-afed-40af0de52cdc"), "G.47.99", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Other retail sale not in stores, stalls or markets" },
                    { new Guid("196683ca-2f44-42cd-8ec3-78462d34cc74"), "H.49", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Land transport and transport via pipelines" },
                    { new Guid("2619911f-5030-4dca-992f-28b25fe66ee7"), "H.49.1", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Passenger rail transport, interurban" },
                    { new Guid("84a49426-2664-4c18-b801-491d4e2b3049"), "H.49.10", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Passenger rail transport, interurban" },
                    { new Guid("6cd67592-abda-4521-8fa9-b8b21cf54f46"), "H.49.2", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Freight rail transport" },
                    { new Guid("079211a3-e957-4a8a-be33-b5db60d2c46b"), "H.49.20", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Freight rail transport" },
                    { new Guid("44dd6f4f-12ac-4798-83de-a1bc8b79d636"), "H.49.3", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Other passenger land transport" },
                    { new Guid("a3de1599-4a61-4cfc-a908-e9ef6c83f712"), "H.49.31", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Urban and suburban passenger land transport" },
                    { new Guid("93643b76-8559-4ba1-b129-abf8efd3b44f"), "H.49.32", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Taxi operation" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("3987d89a-4a20-40d7-86d8-83421065c29b"), "H.49.39", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Other passenger land transport n.e.c." },
                    { new Guid("83b30329-be76-49c4-9a41-2435590d015a"), "H.49.4", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Freight transport by road and removal services" },
                    { new Guid("0aa9095c-6876-4fdd-9bed-f5ae452888e7"), "H.49.41", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Freight transport by road" },
                    { new Guid("103e445b-58ba-4ad1-b627-7b7bd3e79cbb"), "H.49.42", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Removal services" },
                    { new Guid("a6d646ef-7325-4722-9c7c-2333c61a13b1"), "H.49.5", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Transport via pipeline" },
                    { new Guid("fd9a2ba2-7806-48e5-9ab1-a693dd142f33"), "H.49.50", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Transport via pipeline" },
                    { new Guid("1b8d1613-f309-4da9-a571-b814142da011"), "H.50", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Water transport" },
                    { new Guid("f23f6783-1c12-440f-9a8a-d0294dcc8596"), "H.50.1", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Sea and coastal passenger water transport" },
                    { new Guid("93996218-a8ea-41ae-8c29-1bf051f3fe95"), "H.50.10", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Sea and coastal passenger water transport" },
                    { new Guid("330b01cb-f12a-4798-b766-7577f8529aa0"), "H.50.2", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Sea and coastal freight water transport" },
                    { new Guid("00b8bbfe-56b1-4cb8-8522-8e605b4db005"), "H.50.20", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Sea and coastal freight water transport" },
                    { new Guid("d9283b92-6092-490e-bd05-7cab304a89bb"), "H.50.3", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Inland passenger water transport" },
                    { new Guid("b6823bfa-f538-43e8-9808-d835620a521c"), "H.50.30", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Inland passenger water transport" },
                    { new Guid("7ba0e9f6-441a-4ef6-803c-38091f30526e"), "H.50.4", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Inland freight water transport" },
                    { new Guid("94533e9b-1c41-465a-a3e8-d7a51d25cefe"), "H.50.40", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Inland freight water transport" },
                    { new Guid("704a4dfe-9de8-4906-8941-aaf896f83a71"), "H.51", new Guid("5050b28d-7659-4a8e-a333-beed05c4dd06"), "Air transport" },
                    { new Guid("1a6acebd-4b6e-45e7-8752-301140dd0cc8"), "I.56.10", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Restaurants and mobile food service activities" },
                    { new Guid("ea0995a3-2c46-4097-8bde-9e79d6cce3df"), "G.47.89", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale via stalls and markets of other goods" },
                    { new Guid("1b6bf1cb-96d1-4965-9dfe-ee005758feb6"), "I.56.2", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Event catering and other food service activities" },
                    { new Guid("1229ce24-7dc9-4251-b945-85b4282f86e2"), "I.56.29", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Other food service activities" },
                    { new Guid("2b60fa5d-105c-40d4-9251-014fef791f51"), "J.61.30", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Satellite telecommunications activities" },
                    { new Guid("4c75f49e-b8a7-4c29-ae3f-5330dacbf027"), "J.61.9", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other telecommunications activities" },
                    { new Guid("0e80c812-9592-4e83-8bc6-b23060b48ee6"), "J.61.90", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other telecommunications activities" },
                    { new Guid("cde90489-48b0-4d6f-8ec8-4419e7e06d14"), "J.62", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Computer programming, consultancy and related activities" },
                    { new Guid("46c3d00e-e858-4b77-b069-8d16617c1b2d"), "J.62.0", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Computer programming, consultancy and related activities" },
                    { new Guid("1f187e84-a83c-473a-aa03-658633954da4"), "J.62.01", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Computer programming activities" },
                    { new Guid("950038c4-09d6-441f-9095-1d4b6c7489a2"), "J.62.02", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Computer consultancy activities" },
                    { new Guid("ce32c267-7aaa-47a9-aa62-af50f6b045ff"), "J.62.03", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Computer facilities management activities" },
                    { new Guid("3960dbda-c1bd-4985-a472-75011c51a57e"), "J.62.09", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other information technology and computer service activities" },
                    { new Guid("063bc693-81d2-430a-8e58-d6f4ad1d96d4"), "J.63", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Information service activities" },
                    { new Guid("29e22003-caa6-4835-be4b-db66ad261740"), "J.63.1", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Data processing, hosting and related activities; web portals" },
                    { new Guid("d73a0f82-d258-4bf5-b0db-ddaee392c30e"), "J.63.11", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Data processing, hosting and related activities" },
                    { new Guid("b2124199-98cf-40f8-b9e3-dbdfb5db15c7"), "J.61.3", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Satellite telecommunications activities" },
                    { new Guid("d2cfabe1-a1aa-4707-865d-afa0b56f48e1"), "J.63.12", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Web portals" },
                    { new Guid("dbf2fffa-f05e-4156-a5b0-f7e3f72f1ac1"), "J.63.91", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "News agency activities" },
                    { new Guid("2931f3b6-ca60-46b3-a7f0-cd12e27517d9"), "J.63.99", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other information service activities n.e.c." },
                    { new Guid("2aba9270-209b-41fd-a345-d96c50692531"), "K.64", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Financial service activities, except insurance and pension funding" },
                    { new Guid("33c6d01a-d028-423f-b919-3e7488506c8c"), "K.64.1", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Monetary intermediation" },
                    { new Guid("4ba66101-180d-446a-b970-c7fe8f37b245"), "K.64.11", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Central banking" },
                    { new Guid("c3aed7eb-e213-4194-b606-504fe80f9440"), "K.64.19", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Other monetary intermediation" },
                    { new Guid("18c5e9d6-55c9-45e0-ae70-94fca970f9b0"), "K.64.2", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Activities of holding companies" },
                    { new Guid("d542d62d-a90d-434e-a29f-bddd577f17f9"), "K.64.20", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Activities of holding companies" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a9abfcf7-2e18-468e-b332-45a58aa90761"), "K.64.3", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Trusts, funds and similar financial entities" },
                    { new Guid("f242279b-f3b3-42a8-bb45-b714b5dc423f"), "K.64.30", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Trusts, funds and similar financial entities" },
                    { new Guid("f117f5f1-151f-4b78-a884-12b1c560d55a"), "K.64.9", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Other financial service activities, except insurance and pension funding" },
                    { new Guid("e46c33cb-d8d2-4aa0-9948-5ef2a4f7d570"), "K.64.91", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Financial leasing" },
                    { new Guid("d2ebeda2-95f5-4c60-843f-ae83a2665443"), "J.63.9", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other information service activities" },
                    { new Guid("f864b1c1-1f0c-4623-9a34-533d65341d24"), "J.61.20", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Wireless telecommunications activities" },
                    { new Guid("e4195775-7fe7-4c1a-b8ec-0894d56732e5"), "J.61.2", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Wireless telecommunications activities" },
                    { new Guid("c68cce5e-a1bd-40ed-b953-4f1d69de2265"), "J.61.10", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Wired telecommunications activities" },
                    { new Guid("e4b6926a-4d93-4d9e-a523-8ab02b534313"), "I.56.3", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Beverage serving activities" },
                    { new Guid("45262d32-ed15-4780-9478-b2b2527d8bf5"), "I.56.30", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Beverage serving activities" },
                    { new Guid("6bac12d9-3551-4b7e-a4be-852622a25361"), "J.58", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Publishing activities" },
                    { new Guid("2e7a3a08-3cd5-48ed-9d94-26e84e39e839"), "J.58.1", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Publishing of books, periodicals and other publishing activities" },
                    { new Guid("b89fee8b-c4d0-4ca2-af54-202a4594211c"), "J.58.11", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Book publishing" },
                    { new Guid("df752ad3-3e8a-4f6d-87ce-6af79bdfb1ee"), "J.58.12", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Publishing of directories and mailing lists" },
                    { new Guid("ded7ee6f-71c2-4f02-892d-4333f9ce8ced"), "J.58.13", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Publishing of newspapers" },
                    { new Guid("1608c349-add0-4989-bba7-3a5076bf3584"), "J.58.14", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Publishing of journals and periodicals" },
                    { new Guid("021e7e9d-bbce-434d-ad96-affcbe8acd13"), "J.58.19", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other publishing activities" },
                    { new Guid("29dc2be2-c657-4c0f-9c39-d381a210bb44"), "J.58.2", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Software publishing" },
                    { new Guid("5d5625f7-9da3-495d-a8e7-7cad2168248e"), "J.58.21", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Publishing of computer games" },
                    { new Guid("0082d938-ae45-41b8-9600-52072ba72fc8"), "J.58.29", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Other software publishing" },
                    { new Guid("383cc13f-2715-412f-8137-f38bfc61cffd"), "J.59", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Motion picture, video and television programme production, sound recording and music publishing activities" },
                    { new Guid("f3b8ee88-9fda-46a2-9fef-f48ba2046619"), "J.59.1", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Motion picture, video and television programme activities" },
                    { new Guid("d97dcf3e-3720-4b72-b557-1452d42d01d6"), "J.59.11", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Motion picture, video and television programme production activities" },
                    { new Guid("d8b506ac-5c9c-4e6e-ae66-213fb364436c"), "J.59.12", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Motion picture, video and television programme post-production activities" },
                    { new Guid("58492012-8edf-4e8f-8a91-8b84bdf8a621"), "J.59.13", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Motion picture, video and television programme distribution activities" },
                    { new Guid("8f6aae4e-4d03-4f74-bf37-ddf49b0f864c"), "J.59.14", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Motion picture projection activities" },
                    { new Guid("9139cc9d-e228-4be1-a25c-5e72bdabe897"), "J.59.2", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Sound recording and music publishing activities" },
                    { new Guid("bc438304-6823-4b51-9273-d1b72823af04"), "J.59.20", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Sound recording and music publishing activities" },
                    { new Guid("b27dc63d-65f9-4a72-8420-f25741148690"), "J.60", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Programming and broadcasting activities" },
                    { new Guid("a3d493b6-725d-4a31-85f0-6ae7c870bba2"), "J.60.1", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Radio broadcasting" },
                    { new Guid("2801d924-19c2-47d5-912b-5706db7cd3dc"), "J.60.10", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Radio broadcasting" },
                    { new Guid("88f80ed4-2759-4098-a53a-a77614f8ce92"), "J.60.2", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Television programming and broadcasting activities" },
                    { new Guid("69ce9d45-4be4-40b3-848b-995554fcb77b"), "J.60.20", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Television programming and broadcasting activities" },
                    { new Guid("a0c8ead7-547c-4c61-b85e-8892bba99f34"), "J.61", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Telecommunications" },
                    { new Guid("b1e5385e-22c4-48e7-92d8-821d57860a2b"), "J.61.1", new Guid("e16601ee-0fce-4a5a-8dfb-538c4a84e727"), "Wired telecommunications activities" },
                    { new Guid("7da98623-50dd-4d76-9b9c-a5d579368420"), "I.56.21", new Guid("32d8d770-d3d5-4947-be99-26527997d92c"), "Event catering activities" },
                    { new Guid("0c6329f0-e0be-43c5-b15e-8029fa624413"), "K.64.92", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Other credit granting" },
                    { new Guid("14a649f7-5be6-443b-a6dc-f8649ef96e6e"), "G.47.82", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale via stalls and markets of textiles, clothing and footwear" },
                    { new Guid("9b009662-ff15-4e61-9cb5-a77a29d6babf"), "G.47.8", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale via stalls and markets" },
                    { new Guid("76b51140-3670-4306-a2fb-0907ba759652"), "G.46.19", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of a variety of goods" },
                    { new Guid("a85eb4d9-889d-4f08-a6bd-26362e60f922"), "G.46.2", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of agricultural raw materials and live animals" },
                    { new Guid("baa4e85a-6b24-4896-8309-30ad37c251c1"), "G.46.21", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of grain, unmanufactured tobacco, seeds and animal feeds" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7a43b4c6-de91-4c62-8a86-81f43d26c24f"), "G.46.22", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of flowers and plants" },
                    { new Guid("589fca75-ddca-4a94-a9a7-4d4022e84b01"), "G.46.23", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of live animals" },
                    { new Guid("4818f649-598a-4970-83b0-ff4d787b1411"), "G.46.24", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of hides, skins and leather" },
                    { new Guid("4fe44e8d-1ad6-4181-a9a0-8f58548df790"), "G.46.3", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of food, beverages and tobacco" },
                    { new Guid("670d11e5-34f9-469e-a941-75ff2d62e071"), "G.46.31", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of fruit and vegetables" },
                    { new Guid("a61196e6-3b41-44de-b555-04d5ee0436ef"), "G.46.32", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of meat and meat products" },
                    { new Guid("f63e274a-35e6-4b34-9730-078234348ab2"), "G.46.33", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of dairy products, eggs and edible oils and fats" },
                    { new Guid("cb6b6504-30bc-4207-ad86-0335bd8f6173"), "G.46.34", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of beverages" },
                    { new Guid("be48d782-5167-49ec-ab92-3e5fadbb25e5"), "G.46.35", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of tobacco products" },
                    { new Guid("6c493f72-9e1d-4340-8597-c1f5ee21f072"), "G.46.18", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents specialised in the sale of other particular products" },
                    { new Guid("8c7ba704-085a-43fd-afbe-09a05ea1aac5"), "G.46.36", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of sugar and chocolate and sugar confectionery" },
                    { new Guid("d7cc6fc8-0eec-44a0-a549-fdfef14c9df0"), "G.46.38", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of other food, including fish, crustaceans and molluscs" },
                    { new Guid("a1d2aec8-d131-44b8-86a5-8dadef6e6b20"), "G.46.39", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Non-specialised wholesale of food, beverages and tobacco" },
                    { new Guid("19320891-8323-480d-9dd3-13d9f1145689"), "G.46.4", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of household goods" },
                    { new Guid("cccf1499-e3e1-4b3a-b7e2-f88e9b7a1086"), "G.46.41", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of textiles" },
                    { new Guid("e375db7e-c594-401b-8884-187525c7fc2f"), "G.46.42", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of clothing and footwear" },
                    { new Guid("e6b063f8-de36-4a2d-87eb-bf5b21baccda"), "G.46.43", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of electrical household appliances" },
                    { new Guid("1b520763-df71-4f04-bddb-e98ca3bf0089"), "G.46.44", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of china and glassware and cleaning materials" },
                    { new Guid("c5a1d76b-0474-4be2-a23a-ef0b0596291e"), "G.46.45", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of perfume and cosmetics" },
                    { new Guid("91c4f6e9-4868-49b6-86d2-55f573e22a44"), "G.46.46", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of pharmaceutical goods" },
                    { new Guid("62a947dc-3dfa-4097-a625-056ef89c577e"), "G.46.47", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of furniture, carpets and lighting equipment" },
                    { new Guid("c5c25a8f-2948-4280-b0df-b778060d7a06"), "G.46.48", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of watches and jewellery" },
                    { new Guid("88fd43c1-4e9f-4181-aa64-3da205f34366"), "G.46.49", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of other household goods" },
                    { new Guid("fa7cdd30-373b-4eb4-a769-0bfb568f43a2"), "G.46.37", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of coffee, tea, cocoa and spices" },
                    { new Guid("ffef5f2a-37ef-4a4e-8fa5-fc959f3ee2e1"), "G.46.17", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of food, beverages and tobacco" },
                    { new Guid("da0a19da-37d2-4c14-a89a-6aa7db3483a5"), "G.46.16", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of textiles, clothing, fur, footwear and leather goods" },
                    { new Guid("f254284e-ca74-46c4-bb42-01c4c8f7f045"), "G.46.15", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of furniture, household goods, hardware and ironmongery" },
                    { new Guid("5e66636b-701c-4a8d-8201-d5187cc3fef7"), "F.43.29", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Other construction installation" },
                    { new Guid("adc0f490-967d-42f9-8e43-bea8313aa200"), "F.43.3", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Building completion and finishing" },
                    { new Guid("5a6e6367-2d2f-4fe9-a3eb-78e3db374912"), "F.43.31", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Plastering" },
                    { new Guid("61ab6646-8bad-4e8e-b1aa-3305b9c4b0cb"), "F.43.32", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Joinery installation" },
                    { new Guid("67c56f17-ab13-4413-8183-4f0cb00fe979"), "F.43.33", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Floor and wall covering" },
                    { new Guid("46332292-0310-4a2d-9429-bc16edd7db96"), "F.43.34", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Painting and glazing" },
                    { new Guid("5f19341c-7ca6-4c4f-aec9-a81609ad7474"), "F.43.39", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Other building completion and finishing" },
                    { new Guid("85fb6b96-d83e-4c46-9583-26ac645f57db"), "F.43.9", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Other specialised construction activities" },
                    { new Guid("da8a8b45-8fe8-480b-ae67-e354e45a6f8a"), "F.43.91", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Roofing activities" },
                    { new Guid("5b78ccf8-774a-4b63-9455-897d11555343"), "F.43.99", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Other specialised construction activities n.e.c." },
                    { new Guid("01c944a8-f22d-4abd-8936-76c50ff93717"), "G.45", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale and retail trade and repair of motor vehicles and motorcycles" },
                    { new Guid("6239f212-dcf6-43d7-94a2-8aa6afe8022e"), "G.45.1", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Sale of motor vehicles" },
                    { new Guid("dcabf877-3596-4ec6-98ef-c9a28b02b397"), "G.45.11", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Sale of cars and light motor vehicles" },
                    { new Guid("6876214b-88ed-48a3-95d6-70d86e3c916b"), "G.45.19", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Sale of other motor vehicles" },
                    { new Guid("cbcfa13b-4f24-4be8-8b98-570254cd931c"), "G.45.2", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Maintenance and repair of motor vehicles" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("7b1c6992-a2d5-4114-ab92-19794137d665"), "G.45.20", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Maintenance and repair of motor vehicles" },
                    { new Guid("8d707fcb-e423-4c4a-bbb2-235c11bce136"), "G.45.3", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Sale of motor vehicle parts and accessories" },
                    { new Guid("f6ea8315-6025-4466-adf6-d45091ca0c37"), "G.45.31", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale trade of motor vehicle parts and accessories" },
                    { new Guid("7875d101-e21f-4e19-8d5d-08049e89f221"), "G.45.32", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail trade of motor vehicle parts and accessories" },
                    { new Guid("a6cd372e-8308-4c26-ac86-d7aa605e7c7b"), "G.45.4", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("1344bef4-1cc8-465f-ac0d-d2acfe6be089"), "G.45.40", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Sale, maintenance and repair of motorcycles and related parts and accessories" },
                    { new Guid("c0913543-9577-4262-8e67-b44756ea0cc0"), "G.46", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale trade, except of motor vehicles and motorcycles" },
                    { new Guid("a3bbbbe3-86df-4f0d-ae5b-149ce4b59fec"), "G.46.1", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale on a fee or contract basis" },
                    { new Guid("46c376d1-f9b1-418a-b5a6-726ab80c02e2"), "G.46.11", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of agricultural raw materials, live animals, textile raw materials and semi-finished goods" },
                    { new Guid("facaf4a9-05ae-4590-a6d3-c395c0bb2723"), "G.46.12", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of fuels, ores, metals and industrial chemicals" },
                    { new Guid("a0e34032-3103-43c2-8171-d89162f4d4d8"), "G.46.13", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of timber and building materials" },
                    { new Guid("1aeb4363-ebff-4d2b-be02-1cff47aab865"), "G.46.14", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Agents involved in the sale of machinery, industrial equipment, ships and aircraft" },
                    { new Guid("05753ecf-d25d-409a-88d6-a4cc55f4819d"), "G.46.5", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of information and communication equipment" },
                    { new Guid("5a06e635-9251-4f93-a7c0-6d04c0f26b7c"), "G.47.81", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale via stalls and markets of food, beverages and tobacco products" },
                    { new Guid("76b3b97a-038d-47e3-80d3-430e2373b521"), "G.46.51", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of computers, computer peripheral equipment and software" },
                    { new Guid("938e4d81-5e59-4f1e-b44d-dfc57a96aa2b"), "G.46.6", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of other machinery, equipment and supplies" },
                    { new Guid("4986c996-2e2f-4de5-bca4-2cb5680acced"), "G.47.4", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of information and communication equipment in specialised stores" },
                    { new Guid("dfa4bf57-3ea7-4bee-b97a-645563fd1df3"), "G.47.41", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of computers, peripheral units and software in specialised stores" },
                    { new Guid("7e3f630a-e10c-4cc2-94ff-0c14afd6e91d"), "G.47.42", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of telecommunications equipment in specialised stores" },
                    { new Guid("f92486e8-2a25-492a-9be4-c095df7247d5"), "G.47.43", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of audio and video equipment in specialised stores" },
                    { new Guid("b9ae86cf-2f72-4687-98af-5f9beb78310f"), "G.47.5", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of other household equipment in specialised stores" },
                    { new Guid("d0ccd1e6-cf2a-47b3-92b7-dcfdb6d2e060"), "G.47.51", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of textiles in specialised stores" },
                    { new Guid("4499bc28-e401-4fc7-a917-245e4bec0480"), "G.47.52", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of hardware, paints and glass in specialised stores" },
                    { new Guid("9b51a5da-6e42-43a8-b8f1-c6f3caf46ce8"), "G.47.53", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of carpets, rugs, wall and floor coverings in specialised stores" },
                    { new Guid("fa6c9553-339d-47e7-a71d-a98b93cd1795"), "G.47.54", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of electrical household appliances in specialised stores" },
                    { new Guid("443966a7-3c92-421d-bd0c-3153d5c86dbb"), "G.47.59", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of furniture, lighting equipment and other household articles in specialised stores" },
                    { new Guid("c6cfa437-61e0-4907-b829-1259926b3191"), "G.47.6", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of cultural and recreation goods in specialised stores" },
                    { new Guid("1e9bec0e-c9d3-4bb5-8813-7de7921cf7d9"), "G.47.61", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of books in specialised stores" },
                    { new Guid("55fcc2ab-219a-41fd-b100-9580c7462cc9"), "G.47.30", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("a395a401-b63f-4e4a-87ed-0dfdf1fb03ad"), "G.47.62", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of newspapers and stationery in specialised stores" },
                    { new Guid("7379b9ca-bb65-4a07-99d4-6424dcd0fe02"), "G.47.64", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of sporting equipment in specialised stores" },
                    { new Guid("0dff4f7e-6777-496b-8af5-e4bb23338232"), "G.47.65", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of games and toys in specialised stores" },
                    { new Guid("1e81dfb6-ce89-436e-afb2-69de7dd83c81"), "G.47.7", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of other goods in specialised stores" },
                    { new Guid("ecc2812e-45f7-418e-bed9-06774f7678cd"), "G.47.71", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of clothing in specialised stores" },
                    { new Guid("baa9e0b1-4679-425f-a0d2-55b33880efb7"), "G.47.72", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of footwear and leather goods in specialised stores" },
                    { new Guid("2369d1d9-ab08-4e45-b1fc-f21a2479a307"), "G.47.73", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Dispensing chemist in specialised stores" },
                    { new Guid("83fd066f-3bb4-4f3b-89d7-80f9d2e2e812"), "G.47.74", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of medical and orthopaedic goods in specialised stores" },
                    { new Guid("e3de536b-5b7c-47e2-bbf6-ccde46f80156"), "G.47.75", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of cosmetic and toilet articles in specialised stores" },
                    { new Guid("63362ee3-df62-40c5-ab8f-8b78c0049714"), "G.47.76", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of flowers, plants, seeds, fertilisers, pet animals and pet food in specialised stores" },
                    { new Guid("2b2ecd93-ce55-4e6f-9aba-f7d73940890d"), "G.47.77", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of watches and jewellery in specialised stores" },
                    { new Guid("eb487849-bb39-4492-ad46-b6d3f15963a4"), "G.47.78", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Other retail sale of new goods in specialised stores" },
                    { new Guid("06f89355-e285-4cbb-9c94-a6bf86dee88d"), "G.47.79", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of second-hand goods in stores" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("dd5a236e-765f-475c-96e7-dcd35fc66fc4"), "G.47.63", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of music and video recordings in specialised stores" },
                    { new Guid("8b8b82e8-79a9-4e95-a1bb-adae7e37a207"), "G.47.3", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of automotive fuel in specialised stores" },
                    { new Guid("31cbb56f-0f74-47ed-9af3-0cdbfe8cac88"), "G.47.29", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Other retail sale of food in specialised stores" },
                    { new Guid("3186968d-ee7c-480b-b939-4dcd05626103"), "G.47.26", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of tobacco products in specialised stores" },
                    { new Guid("a66bd74e-997e-45b9-98c2-90b7de73cd54"), "G.46.61", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of agricultural machinery, equipment and supplies" },
                    { new Guid("843c0b56-c371-428b-ba81-c746a89a7151"), "G.46.62", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of machine tools" },
                    { new Guid("dfa8558b-bdc5-4bba-8afa-65038d2078ce"), "G.46.63", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of mining, construction and civil engineering machinery" },
                    { new Guid("334b44f7-b863-4e70-8ad4-9595219ef33f"), "G.46.64", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of machinery for the textile industry and of sewing and knitting machines" },
                    { new Guid("15738f8c-d34f-46bf-99f0-8dc03a7f8d2e"), "G.46.65", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of office furniture" },
                    { new Guid("9cbe7215-fae3-4091-a274-5f9b8b28aedb"), "G.46.66", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of other office machinery and equipment" },
                    { new Guid("d8ddc786-248b-4136-a44b-9aaa9807f9d8"), "G.46.69", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of other machinery and equipment" },
                    { new Guid("a88f434e-640e-4aaf-84a0-be03241730e0"), "G.46.7", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Other specialised wholesale" },
                    { new Guid("83456504-70ee-4489-8fe7-5f64ba828934"), "G.46.71", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of solid, liquid and gaseous fuels and related products" },
                    { new Guid("8060887f-88ad-4990-b80e-cce7575ec279"), "G.46.72", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of metals and metal ores" },
                    { new Guid("64d32f60-1982-4b55-9b0e-6b2dee1222c1"), "G.46.73", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of wood, construction materials and sanitary equipment" },
                    { new Guid("235d8b6f-81ff-40d7-a897-9a5332435520"), "G.46.74", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of hardware, plumbing and heating equipment and supplies" },
                    { new Guid("b8a0dd3d-ebf5-43ed-b111-6454d8ee13e5"), "G.46.75", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of chemical products" },
                    { new Guid("cdcf2fdd-34e9-419b-895b-6412180ce1c2"), "G.46.76", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of other intermediate products" },
                    { new Guid("3b412d78-8c80-4ef2-b399-3a127d278e28"), "G.46.77", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of waste and scrap" },
                    { new Guid("f4ad2b69-d04b-4755-a4b6-3b105dfaeb6d"), "G.46.9", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Non-specialised wholesale trade" },
                    { new Guid("eb619693-8f89-4f9a-8404-eac0e1645535"), "G.46.90", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Non-specialised wholesale trade" },
                    { new Guid("94787737-0eb8-4fd5-b5ef-efbff7b41e41"), "G.47", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail trade, except of motor vehicles and motorcycles" },
                    { new Guid("0a3f4324-cf65-4737-a02a-54947a68f6b4"), "G.47.1", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale in non-specialised stores" },
                    { new Guid("3e2b884b-e488-4954-a219-4135c576647e"), "G.47.11", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale in non-specialised stores with food, beverages or tobacco predominating" },
                    { new Guid("3a9b2d41-512c-43ed-b201-e11675b9f032"), "G.47.19", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Other retail sale in non-specialised stores" },
                    { new Guid("743558e9-421a-43e0-986d-98ee6376a29c"), "G.47.2", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of food, beverages and tobacco in specialised stores" },
                    { new Guid("0ab7d279-a7e7-4d2f-96c5-f70d01efe6e5"), "G.47.21", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of fruit and vegetables in specialised stores" },
                    { new Guid("b3a355e3-ac6a-421a-9b91-16f84124b379"), "G.47.22", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of meat and meat products in specialised stores" },
                    { new Guid("56b1f8b9-aa7c-4028-8c08-cdc103efc1d8"), "G.47.23", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of fish, crustaceans and molluscs in specialised stores" },
                    { new Guid("8e78ffbe-aba4-455b-80d8-c5801b82f52b"), "G.47.24", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of bread, cakes, flour confectionery and sugar confectionery in specialised stores" },
                    { new Guid("8227bf32-9bc3-4b71-bef0-3551499b3127"), "G.47.25", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Retail sale of beverages in specialised stores" },
                    { new Guid("0948baaf-5453-4476-a8f7-64f424f88c69"), "G.46.52", new Guid("e89708b7-c7cc-433c-824e-fae0f8321920"), "Wholesale of electronic and telecommunications equipment and parts" },
                    { new Guid("de3e58ac-5810-4b9a-89f6-45565f02ba58"), "F.43.22", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Plumbing, heat and air-conditioning installation" },
                    { new Guid("3f1cc0d4-e22b-46b4-8ae2-a379d34d3189"), "K.64.99", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Other financial service activities, except insurance and pension funding n.e.c." },
                    { new Guid("d72e2acd-4692-427f-b472-d863fc45e35c"), "K.65.1", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Insurance" },
                    { new Guid("0766f38f-3f69-465a-85fb-56a3247d4369"), "P.85.6", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Educational support activities" },
                    { new Guid("abffbec7-6a76-4b05-b421-ddf19359cc48"), "P.85.60", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Educational support activities" },
                    { new Guid("4632672c-b151-4bd3-87e4-4d1bb578cfd3"), "Q.86", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Human health activities" },
                    { new Guid("a4bee865-f83d-4ca9-acff-6050270bac34"), "Q.86.1", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Hospital activities" },
                    { new Guid("72c6e155-2483-4866-9cb4-ec11f5b99560"), "Q.86.10", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Hospital activities" },
                    { new Guid("1f75e660-8a67-4dc1-b9ea-546f01ec659e"), "Q.86.2", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Medical and dental practice activities" },
                    { new Guid("be9dde2c-07e0-4dbd-abf2-8187d81a9ab0"), "Q.86.21", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "General medical practice activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("6c10a2de-2a0d-4dbe-b3ad-35e077a7898f"), "Q.86.22", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Specialist medical practice activities" },
                    { new Guid("6de6d4e4-5a76-4e97-a1a1-fa6dab37dbd6"), "Q.86.23", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Dental practice activities" },
                    { new Guid("f20f4484-291b-4ac6-8562-2614be42fda0"), "Q.86.9", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Other human health activities" },
                    { new Guid("a8e1cbfd-8b16-4b6e-8366-1a69b7292abf"), "Q.86.90", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Other human health activities" },
                    { new Guid("e92b68e3-5118-471a-8326-f944d7efa8cd"), "Q.87", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential care activities" },
                    { new Guid("8f8ef53c-c80e-420d-aea0-d4e3798e3e49"), "P.85.59", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Other education n.e.c." },
                    { new Guid("92d8644b-b0e9-4789-8401-d400a3290742"), "Q.87.1", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential nursing care activities" },
                    { new Guid("19d03414-e139-463e-b9ba-db523788f439"), "Q.87.2", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("8733540b-5405-4cc6-b545-fbf1cf73d581"), "Q.87.20", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential care activities for mental retardation, mental health and substance abuse" },
                    { new Guid("a9306c46-154a-44f7-b0b3-3cbfd5f45177"), "Q.87.3", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential care activities for the elderly and disabled" },
                    { new Guid("3911e8e5-05f9-4fdd-ad36-1305e8b862d6"), "Q.87.30", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential care activities for the elderly and disabled" },
                    { new Guid("75e5fb5d-2bb6-4d80-9ee8-cdfd5dcb1c13"), "Q.87.9", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Other residential care activities" },
                    { new Guid("c95e48c1-c0b7-4eec-bf34-08fd8859e2c2"), "Q.87.90", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Other residential care activities" },
                    { new Guid("34226671-e3d8-4214-8f43-115fabb52b31"), "Q.88", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Social work activities without accommodation" },
                    { new Guid("9c8b7183-45e2-4871-912c-551096ff079a"), "Q.88.1", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("30a66106-06a2-4bd5-a3ab-90fa284b8d30"), "Q.88.10", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Social work activities without accommodation for the elderly and disabled" },
                    { new Guid("d0913751-d76d-4f93-bf6a-4fc6347ecc58"), "Q.88.9", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Other social work activities without accommodation" },
                    { new Guid("0621818b-b239-41d1-9ddc-32575d83819a"), "Q.88.91", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Child day-care activities" },
                    { new Guid("b678dbd7-83a8-4db4-9514-042226ffd660"), "Q.88.99", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Other social work activities without accommodation n.e.c." },
                    { new Guid("93c87971-9248-4542-9995-710025a5ac4a"), "Q.87.10", new Guid("42fb442c-a5ff-49aa-a613-fd97caf74d2a"), "Residential nursing care activities" },
                    { new Guid("c84d781e-e59f-4e08-a221-cab24838087f"), "P.85.53", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Driving school activities" },
                    { new Guid("24e2ac55-2666-4ae7-9e96-75c3b1f0d868"), "P.85.52", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Cultural education" },
                    { new Guid("7cfa37be-bb2a-4a52-bd4b-d23bb7c66c00"), "P.85.51", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Sports and recreation education" },
                    { new Guid("79cb5e26-0fa0-4aa5-8bd6-82877de8807e"), "N.82.91", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Packaging activities" },
                    { new Guid("37583154-5896-4099-8bfc-8a6b40702424"), "N.82.99", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other business support service activities n.e.c." },
                    { new Guid("bf5288e9-a04c-440d-a7cc-39073d22b4bd"), "O.84", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Public administration and defence; compulsory social security" },
                    { new Guid("b0826140-a90a-4b85-bd02-b4bbb5b03ebf"), "O.84.1", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Administration of the State and the economic and social policy of the community" },
                    { new Guid("4a9df371-569e-4dd3-a2ff-5c7608cb9a7c"), "O.84.11", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "General public administration activities" },
                    { new Guid("bb7acc34-29c0-418d-ba4e-c79a162ceb17"), "O.84.12", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Regulation of the activities of providing health care, education, cultural services and other social services, excluding social security" },
                    { new Guid("1b9531ff-0a4d-4a22-aa05-5661005b39ab"), "O.84.13", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Regulation of and contribution to more efficient operation of businesses" },
                    { new Guid("11e927e8-3170-4d9b-8acd-c6b5d13abfcc"), "O.84.2", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Provision of services to the community as a whole" },
                    { new Guid("a02af392-85f8-4f00-a74b-679b0e18d3ba"), "O.84.21", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Foreign affairs" },
                    { new Guid("b79259f2-315a-4645-85f4-6a96f36bf23f"), "O.84.22", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Defence activities" },
                    { new Guid("2cc6c4ca-7f47-42cd-99f9-b1d312cc588b"), "O.84.23", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Justice and judicial activities" },
                    { new Guid("420e05f1-a237-4937-8d56-b52689c1fcd7"), "O.84.24", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Public order and safety activities" },
                    { new Guid("c04b1b90-c42f-4222-be09-5fd50062ffe5"), "O.84.25", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Fire service activities" },
                    { new Guid("f9e8cf98-2c7d-47f9-b161-fe36afd5f327"), "O.84.3", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Compulsory social security activities" },
                    { new Guid("2fcf0c62-fc91-4d49-b98a-9f94bb9e034d"), "O.84.30", new Guid("23fcdfc9-a9d4-43e8-a4f5-a1de71e19768"), "Compulsory social security activities" },
                    { new Guid("0eaf7145-1e5a-4bc5-871d-b06b5bf5ddff"), "P.85", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Education" },
                    { new Guid("7932c04a-46c4-45bc-ba62-e008391f71f8"), "P.85.1", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Pre-primary education" },
                    { new Guid("6ed0a5b6-4329-4a1c-987c-a95117b18af2"), "P.85.10", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Pre-primary education" },
                    { new Guid("e58658cb-a1a7-4e0a-856f-1129e9a613ed"), "P.85.2", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Primary education" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("f16a8319-4ba6-4edd-8cc7-2a13a29a44bf"), "P.85.20", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Primary education" },
                    { new Guid("65090dd8-d775-4673-8e51-3e7b483e65b2"), "P.85.3", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Secondary education" },
                    { new Guid("1c628d03-040a-4a2a-9083-8bde25418c93"), "P.85.31", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "General secondary education" },
                    { new Guid("c5c44a05-4871-4dbc-aed4-b1e6b9e25d1f"), "P.85.32", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Technical and vocational secondary education" },
                    { new Guid("552617bd-b9c7-4ee1-848a-d3e6d5a8b157"), "P.85.4", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Higher education" },
                    { new Guid("18874921-2cff-4325-95ea-f5df02880e97"), "P.85.41", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Post-secondary non-tertiary education" },
                    { new Guid("7d43061f-1c0b-42ea-a431-c81ecd6877d6"), "P.85.42", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Tertiary education" },
                    { new Guid("999d9d27-4f5d-4cb4-ba03-cc0783d1caee"), "P.85.5", new Guid("7f83af21-5241-43d4-93d5-0b838cea099d"), "Other education" },
                    { new Guid("f3de6193-153b-422e-bd90-8da33e676f04"), "R.90", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Creative, arts and entertainment activities" },
                    { new Guid("95641569-1cae-4a0d-a387-07d607363d9b"), "N.82.92", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Activities of collection agencies and credit bureaus" },
                    { new Guid("f9ad4d9d-776e-4bb9-aab4-93c0c3ed8d88"), "R.90.0", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Creative, arts and entertainment activities" },
                    { new Guid("a994165e-6b17-4914-9422-2b444ac9c2e5"), "R.90.02", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Support activities to performing arts" },
                    { new Guid("da656787-f80f-4723-abc7-04f455b4f9d0"), "S.95.1", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of computers and communication equipment" },
                    { new Guid("e7dd9fad-6ec0-4a10-bc20-bbc9c8352850"), "S.95.11", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of computers and peripheral equipment" },
                    { new Guid("de988329-f5c3-46eb-ad3d-3b31e435c4f3"), "S.95.12", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of communication equipment" },
                    { new Guid("982e5961-746b-4a9f-bf16-7f7be08a1f6b"), "S.95.2", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of personal and household goods" },
                    { new Guid("370cf575-439d-4ecc-bdf4-cffcf71d31c9"), "S.95.21", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of consumer electronics" },
                    { new Guid("13db921d-f2ed-4af8-912f-b8572e68a594"), "S.95.22", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of household appliances and home and garden equipment" },
                    { new Guid("f882ac64-37a7-48bb-926a-2554ba696da8"), "S.95.23", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of footwear and leather goods" },
                    { new Guid("c890bf5c-1476-4292-b9e1-756bca7bee87"), "S.95.24", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of furniture and home furnishings" },
                    { new Guid("d0ef52a3-281a-440b-815d-77069a47ebec"), "S.95.25", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of watches, clocks and jewellery" },
                    { new Guid("b2bf79b6-10f3-44a9-bfb8-888524aa8ac7"), "S.95.29", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of other personal and household goods" },
                    { new Guid("e0ca6ee1-657e-44f1-b582-a75fe5372140"), "S.96", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Other personal service activities" },
                    { new Guid("2abe85f8-4035-4080-9c72-4fbe2d721c2c"), "S.96.0", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Other personal service activities" },
                    { new Guid("6f6a7d6f-4599-4e38-8100-151be3e7a1b6"), "S.95", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Repair of computers and personal and household goods" },
                    { new Guid("1cbbde72-1117-4bdc-ba0a-24f5fcc16c83"), "S.96.01", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Washing and (dry-)cleaning of textile and fur products" },
                    { new Guid("7d3a5f5b-aa89-4a4b-91ef-9409a10089af"), "S.96.03", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Funeral and related activities" },
                    { new Guid("ddd2bbca-45ba-4f41-8095-015ee62fcf29"), "S.96.04", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Physical well-being activities" },
                    { new Guid("9783cbae-b41b-4722-8404-d4c302e1c072"), "S.96.09", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Other personal service activities n.e.c." },
                    { new Guid("7ca3e0c7-778a-4d0f-9ff3-1120497d5433"), "T.97", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Activities of households as employers of domestic personnel" },
                    { new Guid("9ea6c5f5-f14b-4253-9810-ec324ce01524"), "T.97.0", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Activities of households as employers of domestic personnel" },
                    { new Guid("60eee1dd-f2a2-4ae3-b4e9-308a7b292641"), "T.97.00", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Activities of households as employers of domestic personnel" },
                    { new Guid("fcccaeca-9660-4f8c-9d7b-0c4963eb5863"), "T.98", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Undifferentiated goods- and services-producing activities of private households for own use" },
                    { new Guid("63b51a8d-59d1-4d7b-8d41-5937428d7fcc"), "T.98.1", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("fe54c70e-af8f-4cbd-a369-df6ef7f09eb7"), "T.98.10", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Undifferentiated goods-producing activities of private households for own use" },
                    { new Guid("348a3cec-8b08-46af-aa80-3fb9299f3324"), "T.98.2", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("a98e0479-9bc5-4efc-8ebc-9a1e7639f59c"), "T.98.20", new Guid("23b1da76-0ba1-4ca0-ab89-e9b6671c920c"), "Undifferentiated service-producing activities of private households for own use" },
                    { new Guid("a7412981-90ca-450a-8189-69bd1884d2a0"), "U.99", new Guid("18bcd142-95cf-4e86-bdb7-99696e6f027f"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("83fcfb40-6842-4a81-93d9-193183303325"), "S.96.02", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Hairdressing and other beauty treatment" },
                    { new Guid("f2ad3e74-05fc-4913-8a11-f38d7bc16b63"), "S.94.99", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of other membership organisations n.e.c." },
                    { new Guid("41c234e3-a170-4b9a-a0ca-8ac0043fc828"), "S.94.92", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of political organisations" },
                    { new Guid("5a330103-61f5-44c4-8e04-c5a96f640ad7"), "S.94.91", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of religious organisations" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fbefe4ff-4a25-4aea-b0ca-e46805bdb783"), "R.90.03", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Artistic creation" },
                    { new Guid("92dcdd46-cc2e-4ff9-9661-02c77943b935"), "R.90.04", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Operation of arts facilities" },
                    { new Guid("5ae167df-1a44-4d8d-893e-edbb49ed1ed5"), "R.91", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("a579d7ac-f157-41c1-90be-4901b736b843"), "R.91.0", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Libraries, archives, museums and other cultural activities" },
                    { new Guid("62ebecde-9738-47d9-9bac-0265394a9aa9"), "R.91.01", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Library and archives activities" },
                    { new Guid("39e046fa-684d-4b4f-80c8-53ab097e069a"), "R.91.02", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Museums activities" },
                    { new Guid("f063cc7d-6f8b-4023-9fc0-3dde3d16b10b"), "R.91.03", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Operation of historical sites and buildings and similar visitor attractions" },
                    { new Guid("5bb083a7-9e22-4589-9162-61c83bac207f"), "R.91.04", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Botanical and zoological gardens and nature reserves activities" },
                    { new Guid("e7df0667-8958-41f8-9c9d-363bbfb5b3af"), "R.92", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Gambling and betting activities" },
                    { new Guid("93520b53-1794-4376-a772-8fd0c08f0666"), "R.92.0", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Gambling and betting activities" },
                    { new Guid("65771bd7-58d8-401e-b7ae-646dde1f7bb7"), "R.92.00", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Gambling and betting activities" },
                    { new Guid("dd25fe6c-e443-4e31-ad0e-26515d6327ec"), "R.93", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Sports activities and amusement and recreation activities" },
                    { new Guid("72781f1f-84da-48b7-944a-102dd3d8642f"), "R.93.1", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Sports activities" },
                    { new Guid("2cf8fbf0-1fda-4a7f-81d8-70b581e32e43"), "R.93.11", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Operation of sports facilities" },
                    { new Guid("bd317a1b-2e50-495e-865c-80f7420cf2c8"), "R.93.12", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Activities of sport clubs" },
                    { new Guid("cca3282f-2701-409c-8422-da03357251c8"), "R.93.13", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Fitness facilities" },
                    { new Guid("49c32be1-89f5-4564-85f7-6f07769bbece"), "R.93.19", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Other sports activities" },
                    { new Guid("a4c4cf0d-576e-446a-908a-2f2a9a2f3f14"), "R.93.2", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Amusement and recreation activities" },
                    { new Guid("db28f318-8320-424c-81b7-083fc4fd33ad"), "R.93.21", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Activities of amusement parks and theme parks" },
                    { new Guid("2e7ce213-08b6-42a3-8953-9c116d63bde9"), "R.93.29", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Other amusement and recreation activities" },
                    { new Guid("37285105-3004-49a4-a48a-5b577048aa2b"), "S.94", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of membership organisations" },
                    { new Guid("3fb82925-a381-41e5-bcb9-60008839b387"), "S.94.1", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of business, employers and professional membership organisations" },
                    { new Guid("02559fb7-a3fd-4098-b0e8-1479e84c6f87"), "S.94.11", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of business and employers membership organisations" },
                    { new Guid("fc3a0c04-3976-44e2-adf0-72b9ff77e6a0"), "S.94.12", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of professional membership organisations" },
                    { new Guid("ef8d9b81-c434-4f30-a3ae-e1e4fa987db3"), "S.94.2", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of trade unions" },
                    { new Guid("681f2cbc-597a-4e70-b0ad-2cecf31b38d3"), "S.94.20", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of trade unions" },
                    { new Guid("023a79cc-c018-4787-adf7-ee54ed000bcd"), "S.94.9", new Guid("ffb9f808-f730-4ba6-8bc8-3a7b49891837"), "Activities of other membership organisations" },
                    { new Guid("0da00410-81cc-4045-b04f-b5de67f58363"), "R.90.01", new Guid("0530f9c1-4b9b-4a49-b093-1482a6a72818"), "Performing arts" },
                    { new Guid("2fbf9332-b757-47ad-8f8e-8e92736194e2"), "K.65", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Insurance, reinsurance and pension funding, except compulsory social security" },
                    { new Guid("2fe1c07a-18dd-42a7-9785-c541c7bbafbc"), "N.82.9", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Business support service activities n.e.c." },
                    { new Guid("dcf4dd09-4071-4c1a-ad28-b8955a18345a"), "N.82.3", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Organisation of conventions and trade shows" },
                    { new Guid("ee715226-e6bc-4bf5-ae61-0746f456dbfe"), "M.70.1", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Activities of head offices" },
                    { new Guid("10b12d78-29d2-4e06-8d46-fc70f622a695"), "M.70.10", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Activities of head offices" },
                    { new Guid("687b26c5-df80-4a34-ac35-06e93b4bfa3a"), "M.70.2", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Management consultancy activities" },
                    { new Guid("f80324b4-7a79-4289-8d84-241083a1b031"), "M.70.21", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Public relations and communication activities" },
                    { new Guid("86abe368-efc9-42b7-975c-96ae6396d6de"), "M.70.22", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Business and other management consultancy activities" },
                    { new Guid("d25efd7a-f5bf-4010-bd55-5370969a4c6f"), "M.71", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Architectural and engineering activities; technical testing and analysis" },
                    { new Guid("ea1362a8-f4f1-44ec-9d1e-06df4647ef9d"), "M.71.1", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Architectural and engineering activities and related technical consultancy" },
                    { new Guid("57a20dc9-bf15-4637-86f5-f7e2de7ba196"), "M.71.11", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Architectural activities" },
                    { new Guid("a4640576-1622-4712-9964-edded1d6b605"), "M.71.12", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Engineering activities and related technical consultancy" },
                    { new Guid("1d245362-f057-4b25-8245-9cf8d73f7d63"), "M.71.2", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Technical testing and analysis" },
                    { new Guid("f3335ef3-9f69-44e4-8ead-271dc0ea304b"), "M.71.20", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Technical testing and analysis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1883fba1-31a6-4af7-8d66-ba614cdc0ba8"), "M.72", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Scientific research and development" },
                    { new Guid("dabeaa89-456c-493a-b72d-ec3fbc030951"), "M.70", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Activities of head offices; management consultancy activities" },
                    { new Guid("f6dc960a-d2c9-44b1-8e4a-07bc0b202034"), "M.72.1", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Research and experimental development on natural sciences and engineering" },
                    { new Guid("69e48a21-f918-49c4-8859-7554a858313f"), "M.72.19", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Other research and experimental development on natural sciences and engineering" },
                    { new Guid("43af4d9f-c02f-43b8-ba38-e54936af91d1"), "M.72.2", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("5e26ec04-c6e1-4804-b201-4df79bf7edc4"), "M.72.20", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Research and experimental development on social sciences and humanities" },
                    { new Guid("4a15be90-c21b-43c8-b3bb-2223f73e76c7"), "M.73", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Advertising and market research" },
                    { new Guid("07690009-c494-4b09-b0e7-5074d80c6b5a"), "M.73.1", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Advertising" },
                    { new Guid("7a50c7f3-bb82-497c-bcac-0d128767cbe5"), "M.73.11", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Advertising agencies" },
                    { new Guid("eb02e879-80b7-4aa3-bd02-98c21f49254e"), "M.73.12", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Media representation" },
                    { new Guid("9c0ec91a-8e34-4e94-81f5-b8ac08f54efe"), "M.73.2", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Market research and public opinion polling" },
                    { new Guid("3f34659f-39c6-4bd4-9e83-311f559d712f"), "M.73.20", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Market research and public opinion polling" },
                    { new Guid("94b7e08d-1d6a-4985-9be3-18c136156c4e"), "M.74", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Other professional, scientific and technical activities" },
                    { new Guid("9447c1c0-9c81-4476-ac26-b164b2fe1e6f"), "M.74.1", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Specialised design activities" },
                    { new Guid("cf4abc97-25b8-4007-9460-39ace5ec2551"), "M.74.10", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Specialised design activities" },
                    { new Guid("5d553c82-6016-41ed-bb61-6c4735b0fc66"), "M.72.11", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Research and experimental development on biotechnology" },
                    { new Guid("613ed107-853e-4c87-b1c2-5d5a9a80240a"), "M.69.20", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("987d60e2-7822-4ec0-a1ae-0a265f14cb85"), "M.69.2", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Accounting, bookkeeping and auditing activities; tax consultancy" },
                    { new Guid("32551250-2858-414e-bde6-a659bce354b1"), "M.69.10", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Legal activities" },
                    { new Guid("86a2da8e-c4fd-4c8f-a22b-abddd1c6a50c"), "K.65.11", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Life insurance" },
                    { new Guid("bcd27d41-748c-4aa8-8751-fb45f22bb4d2"), "K.65.12", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Non-life insurance" },
                    { new Guid("410b4f24-03a6-4f12-97b8-c7993a79abec"), "K.65.2", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Reinsurance" },
                    { new Guid("8a437a89-9fb6-4848-9733-0d46a5dfc690"), "K.65.20", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Reinsurance" },
                    { new Guid("d547b66c-0477-4f51-af18-83db4f6fe093"), "K.65.3", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Pension funding" },
                    { new Guid("330fa165-bda1-4ebf-b0f4-9f8d5ec8f2f4"), "K.65.30", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Pension funding" },
                    { new Guid("54b02242-abeb-433b-af57-931ef7d0df2c"), "K.66", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Activities auxiliary to financial services and insurance activities" },
                    { new Guid("0bed58e6-1ea2-48fc-b10b-3bd69f6986ad"), "K.66.1", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("d8de5fbf-a778-4ce4-9d4c-d4f5ce764afa"), "K.66.11", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Administration of financial markets" },
                    { new Guid("6d1a0601-0af1-42a5-bd40-84446e44d66c"), "K.66.12", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Security and commodity contracts brokerage" },
                    { new Guid("bb51ba89-086d-4474-bd75-1694a77d60a0"), "K.66.19", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Other activities auxiliary to financial services, except insurance and pension funding" },
                    { new Guid("424ba605-21c2-478f-888e-154690af9bc5"), "K.66.2", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Activities auxiliary to insurance and pension funding" },
                    { new Guid("0226c99c-387a-4cf7-9335-cfffb3a44ed2"), "K.66.21", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Risk and damage evaluation" },
                    { new Guid("a7fde98a-3e3a-400f-a3e4-514a15d8883b"), "K.66.22", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Activities of insurance agents and brokers" },
                    { new Guid("912c2e76-1317-43b1-9d50-d4df01f35aba"), "K.66.29", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Other activities auxiliary to insurance and pension funding" },
                    { new Guid("7607cd6e-0171-48c5-86da-7fd14103ea54"), "K.66.3", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Fund management activities" },
                    { new Guid("69b34b12-410c-4f7e-8aed-8c603b88b65f"), "K.66.30", new Guid("41461a4b-b21e-4a91-a2b7-e2489ceca62b"), "Fund management activities" },
                    { new Guid("4c666c06-b2f9-49c0-a19e-24ba9ed794e3"), "L.68", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Real estate activities" },
                    { new Guid("09bb2bbc-20a7-4bdc-92d2-8ef6f975457e"), "L.68.1", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Buying and selling of own real estate" },
                    { new Guid("68d03746-bc08-43d9-8fae-13b660569439"), "L.68.10", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Buying and selling of own real estate" },
                    { new Guid("ffc1f9d7-c692-40f2-be5a-ca7062da2ad3"), "L.68.2", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Renting and operating of own or leased real estate" },
                    { new Guid("fd588796-e627-4de0-b918-da5a7a4a6812"), "L.68.20", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Renting and operating of own or leased real estate" },
                    { new Guid("f87bab33-0ba0-4b43-8026-675a91963db3"), "L.68.3", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Real estate activities on a fee or contract basis" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e5daab3f-1e75-4c83-a96d-8ee11a2a80a9"), "L.68.31", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Real estate agencies" },
                    { new Guid("4ac33671-7ed3-4600-a3d5-4e61b180ccf2"), "L.68.32", new Guid("387e9e31-0883-4c88-81bb-95c06e0d3c38"), "Management of real estate on a fee or contract basis" },
                    { new Guid("365fe6d6-e837-4bce-813f-63c36033ec97"), "M.69", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Legal and accounting activities" },
                    { new Guid("2b81fed0-6316-466b-b711-f7b6fce80667"), "M.69.1", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Legal activities" },
                    { new Guid("e13e1cd6-4d50-4010-a1b9-b562b52145f4"), "M.74.2", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Photographic activities" },
                    { new Guid("41792f29-8bfc-483a-acd9-a922b256a50b"), "N.82.30", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Organisation of conventions and trade shows" },
                    { new Guid("0a17bec0-50be-431f-b94e-c5798e13ad8a"), "M.74.20", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Photographic activities" },
                    { new Guid("07e3b6fb-67ee-4784-8588-f7694e36a2b5"), "M.74.30", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Translation and interpretation activities" },
                    { new Guid("56b833d7-be82-4f00-b7fe-9972f517bbf9"), "N.79.11", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Travel agency activities" },
                    { new Guid("f989bee5-3369-4b10-84f4-e08a970241d5"), "N.79.12", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Tour operator activities" },
                    { new Guid("0a5d6efb-d522-44ef-9226-3fa9c18751be"), "N.79.9", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other reservation service and related activities" },
                    { new Guid("e1016c71-2046-484e-8805-cff353ccbd1c"), "N.79.90", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other reservation service and related activities" },
                    { new Guid("a838a9a3-1142-43c5-9ac6-96f13d681f6e"), "N.80", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Security and investigation activities" },
                    { new Guid("1645b27b-eb6f-4a0f-b99e-53be6e9fca88"), "N.80.1", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Private security activities" },
                    { new Guid("edf5762f-c22a-44be-90ce-5dff6440ae53"), "N.80.10", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Private security activities" },
                    { new Guid("41256d2f-2b93-497e-bc35-f26123b604fa"), "N.80.2", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Security systems service activities" },
                    { new Guid("b207cdc1-7330-4b95-aa03-54ab1eebe43c"), "N.80.20", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Security systems service activities" },
                    { new Guid("7260b755-9c33-474b-8ddf-9f5412c16131"), "N.80.3", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Investigation activities" },
                    { new Guid("b0088cf5-a366-41b3-8777-ca33f7d3843d"), "N.80.30", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Investigation activities" },
                    { new Guid("3cfb6ebe-1c81-40b8-af74-09e823356583"), "N.81", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Services to buildings and landscape activities" },
                    { new Guid("2a369a1e-255b-49f1-a18a-210a94314a04"), "N.79.1", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Travel agency and tour operator activities" },
                    { new Guid("c88ee20f-7d36-4143-aa20-97875e9d381b"), "N.81.1", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Combined facilities support activities" },
                    { new Guid("3f72877a-8f5a-4c87-97db-e7b824d4454c"), "N.81.2", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Cleaning activities" },
                    { new Guid("b42918e3-06fc-4ffd-aef0-7d194aa80ba6"), "N.81.21", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "General cleaning of buildings" },
                    { new Guid("2cbad643-1824-4b03-9020-8513a876d551"), "N.81.22", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other building and industrial cleaning activities" },
                    { new Guid("32370a5b-d40f-4d85-b4fd-816e5c0b13be"), "N.81.29", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other cleaning activities" },
                    { new Guid("14a4ee19-336a-494a-88e5-d61786c3a212"), "N.81.3", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Landscape service activities" },
                    { new Guid("08cf90c5-54b5-47ff-8e9e-b7e28fe3431b"), "N.81.30", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Landscape service activities" },
                    { new Guid("77765911-8de8-46aa-b6fc-689244e51125"), "N.82", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Office administrative, office support and other business support activities" },
                    { new Guid("961aba0a-fd10-4bac-b308-c94de21bc6b3"), "N.82.1", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Office administrative and support activities" },
                    { new Guid("aeaf0a8b-3545-4bc2-988d-d36502af83ca"), "N.82.11", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Combined office administrative service activities" },
                    { new Guid("7df14108-cc7a-4fd7-aef1-6434dbad87d5"), "N.82.19", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Photocopying, document preparation and other specialised office support activities" },
                    { new Guid("bf5cc0b3-5ce9-47b7-97e8-6ad5645e7bc1"), "N.82.2", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Activities of call centres" },
                    { new Guid("1986f878-6f93-42e8-ba5c-14c7bed4d547"), "N.82.20", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Activities of call centres" },
                    { new Guid("6ba2b08d-81c5-40f7-87c0-33da07cbdcab"), "N.81.10", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Combined facilities support activities" },
                    { new Guid("8fc07bb2-220e-49bf-8b89-2fe41901fcb0"), "N.79", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Travel agency, tour operator and other reservation service and related activities" },
                    { new Guid("62987d23-c6f2-4238-976e-3bba9f9b675b"), "N.78.30", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other human resources provision" },
                    { new Guid("7eccfe50-a97a-4c48-8fe5-04d4b8a6eddd"), "N.78.3", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Other human resources provision" },
                    { new Guid("11588405-4c50-41cd-adc6-4a62217132ec"), "M.74.9", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("ceabc117-7cfc-48fd-b269-a5ef8153c400"), "M.74.90", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Other professional, scientific and technical activities n.e.c." },
                    { new Guid("ad259e80-199d-4bdd-b4cb-9b3594a8c054"), "M.75", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Veterinary activities" },
                    { new Guid("30bca52c-b793-49bc-9456-8a2923cca474"), "M.75.0", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Veterinary activities" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("b141e6e4-47d1-4069-b646-a2e98d27b9d0"), "M.75.00", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Veterinary activities" },
                    { new Guid("79b43c66-b4e6-49bb-b783-b996d3f78a6f"), "N.77", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Rental and leasing activities" },
                    { new Guid("6152c8ec-23a0-419b-b760-4e48b622c447"), "N.77.1", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of motor vehicles" },
                    { new Guid("79d35779-7fd9-4a10-a9fe-40bd959def31"), "N.77.11", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of cars and light motor vehicles" },
                    { new Guid("2c053205-a18c-4a60-a559-042903e524c9"), "N.77.12", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of trucks" },
                    { new Guid("5ec4d0bd-3bc4-45d1-be6c-ed77014c957c"), "N.77.2", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of personal and household goods" },
                    { new Guid("12f3f5c4-114b-4ce7-bf86-e06c944fbfbd"), "N.77.21", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of recreational and sports goods" },
                    { new Guid("049858cf-5470-4605-b134-244b84505f00"), "N.77.22", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting of video tapes and disks" },
                    { new Guid("48649e64-fa39-4f02-a0f4-f96d45b9f285"), "N.77.29", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of other personal and household goods" },
                    { new Guid("92096803-3878-4683-8d12-e0aa94aefc2d"), "N.77.3", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of other machinery, equipment and tangible goods" },
                    { new Guid("2b890ab3-1053-4cf0-bf8e-4af5f28a295b"), "N.77.31", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of agricultural machinery and equipment" },
                    { new Guid("30edbf92-abbc-44be-a74f-eceb4c91346d"), "N.77.32", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of construction and civil engineering machinery and equipment" },
                    { new Guid("cbc64ade-132f-4450-ac46-2149f1a0eef7"), "N.77.33", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of office machinery and equipment (including computers)" },
                    { new Guid("ecf066e3-2ca0-48f9-94b5-71f0a5ca8528"), "N.77.34", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of water transport equipment" },
                    { new Guid("2c5f29d1-0b5a-4997-99ca-16ca3a3ecf4f"), "N.77.35", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of air transport equipment" },
                    { new Guid("027c293a-06b8-4187-940e-c0915c084b1f"), "N.77.39", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Renting and leasing of other machinery, equipment and tangible goods n.e.c." },
                    { new Guid("bf5a9603-a504-4d8a-8dfb-ffcbe85f934a"), "N.77.4", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("29975ae1-aca4-4853-b9cb-b8c5042b8f30"), "N.77.40", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Leasing of intellectual property and similar products, except copyrighted works" },
                    { new Guid("937c2c33-eba9-4e1c-9909-8aa921b3b173"), "N.78", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Employment activities" },
                    { new Guid("db4f2677-e1a3-4683-81ef-3da0c41e980b"), "N.78.1", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Activities of employment placement agencies" },
                    { new Guid("263e162b-c83c-4dfc-bd23-d809574c746f"), "N.78.10", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Activities of employment placement agencies" },
                    { new Guid("5aeb6c35-32be-4330-92ad-98f68f785e4d"), "N.78.2", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Temporary employment agency activities" },
                    { new Guid("67515afe-a068-4460-852e-085f7fdeaba8"), "N.78.20", new Guid("14a5f9f8-e87b-4a14-9886-8ae26334e49c"), "Temporary employment agency activities" },
                    { new Guid("a53a14af-a77e-4f0c-96b5-fee33aacb49c"), "M.74.3", new Guid("c1f3f351-8924-4a10-8325-3dfa3a6966d1"), "Translation and interpretation activities" },
                    { new Guid("65b3a63d-5a0e-453c-93fc-2501bfbf7df3"), "U.99.0", new Guid("18bcd142-95cf-4e86-bdb7-99696e6f027f"), "Activities of extraterritorial organisations and bodies" },
                    { new Guid("ec19836e-6521-464a-a6cb-f07da9667585"), "F.43.21", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Electrical installation" },
                    { new Guid("a07dcf96-7c40-427c-83db-64ef21db529f"), "F.43.13", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Test drilling and boring" },
                    { new Guid("e4f2cb5e-949e-47d4-9f76-baceda9f07d8"), "C.14.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of articles of fur" },
                    { new Guid("0c5fc7c9-1f3e-4e6c-8fdb-360bf1cb949e"), "C.14.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of articles of fur" },
                    { new Guid("7998cb0e-6852-4052-b69b-02d06e949c96"), "C.14.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of knitted and crocheted apparel" },
                    { new Guid("b9c69f47-3af4-4e76-8370-ed44fc606b81"), "C.14.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of knitted and crocheted hosiery" },
                    { new Guid("bda9749e-90d6-427d-9321-4685bc27ac6e"), "C.14.39", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other knitted and crocheted apparel" },
                    { new Guid("97876795-88de-41d4-97af-2d3d3f63d42c"), "C.15", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of leather and related products" },
                    { new Guid("00bd64c9-bb53-497a-bbfd-3569b36e8703"), "C.15.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur" },
                    { new Guid("65fa300c-7d14-4d39-aaf0-5744b518fc2e"), "C.15.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Tanning and dressing of leather; dressing and dyeing of fur" },
                    { new Guid("4df51e10-cbd1-4afc-80f7-c964daabb467"), "C.15.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of luggage, handbags and the like, saddlery and harness" },
                    { new Guid("18cbf794-ab06-4adf-b508-b2102e3afb4f"), "C.15.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of footwear" },
                    { new Guid("ef9c47b9-b9da-4bfb-a39e-b0f1e54262a7"), "C.15.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of footwear" },
                    { new Guid("4e25a642-11f8-46a0-8e5c-d12900b24123"), "C.16", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials" },
                    { new Guid("ddf4df69-ce6c-45c0-bcfc-597958297be6"), "C.14.19", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other wearing apparel and accessories" },
                    { new Guid("9bb5e068-9fe0-47fc-895d-59800bddeab1"), "C.16.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Sawmilling and planing of wood" },
                    { new Guid("69a9085e-248a-4b32-b7f5-0fc57d8cb348"), "C.16.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of products of wood, cork, straw and plaiting materials" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("553b9e5a-3fd7-4b70-9290-6f85dc0f0e92"), "C.16.21", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of veneer sheets and wood-based panels" },
                    { new Guid("6ceb50f0-8424-4643-95ac-d48d2fbcc45c"), "C.16.22", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of assembled parquet floors" },
                    { new Guid("d99c0f1a-c02c-4387-a720-e52d744451cc"), "C.16.23", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other builders' carpentry and joinery" },
                    { new Guid("ba616d14-236e-47d3-b3b9-5f6d908cb61e"), "C.16.24", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wooden containers" },
                    { new Guid("e352701a-d760-4fb7-906f-c1c89e159875"), "C.16.29", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials" },
                    { new Guid("ca49487c-72d3-43c1-b9ef-7318ec647013"), "C.17", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of paper and paper products" },
                    { new Guid("6a3cc857-852c-4307-865f-eda4d99d93c2"), "C.17.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of pulp, paper and paperboard" },
                    { new Guid("d7165605-2f6b-4076-b5c8-37ebe9be1214"), "C.17.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of pulp" },
                    { new Guid("993ff02a-4dc9-4a53-aaf6-a512b8876c1f"), "C.17.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of paper and paperboard" },
                    { new Guid("6e3a3101-e40b-4508-aac3-8b4ef390646b"), "C.17.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of articles of paper and paperboard" },
                    { new Guid("4daa2ed3-0cae-4c35-86ba-7361d1d8dfcc"), "C.17.21", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of corrugated paper and paperboard and of containers of paper and paperboard" },
                    { new Guid("4e158766-f2a8-420b-9bcb-b9ca638600c8"), "C.16.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Sawmilling and planing of wood" },
                    { new Guid("6db6ed01-f74d-4f6c-b904-bfecc0908d37"), "C.14.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of underwear" },
                    { new Guid("51ac7e21-9882-4c6f-9ab5-1ccb98cf4474"), "C.14.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other outerwear" },
                    { new Guid("3fcbe4a5-ab70-4b68-937d-75a09d318039"), "C.14.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of workwear" },
                    { new Guid("3a2453f4-f5b3-48f9-a7be-a2ac69b2f7ec"), "C.11.02", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wine from grape" },
                    { new Guid("65f15485-e543-426e-92db-b26a6f257f10"), "C.11.03", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cider and other fruit wines" },
                    { new Guid("fee035e3-4b34-4177-bf5a-ce0b8ae2c5b3"), "C.11.04", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other non-distilled fermented beverages" },
                    { new Guid("0eea6a9c-272e-4e94-96f8-3a23ee3c6d92"), "C.11.05", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of beer" },
                    { new Guid("ef5291c3-e918-4a0a-8a85-a9044df66df1"), "C.11.06", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of malt" },
                    { new Guid("340d1278-ed07-44a5-b4f2-d69990a9bc3f"), "C.11.07", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of soft drinks; production of mineral waters and other bottled waters" },
                    { new Guid("19a27b62-29e2-4211-b345-0747e17c72ef"), "C.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tobacco products" },
                    { new Guid("be8da747-0b39-4c18-8908-e52a4989cf98"), "C.12.0", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tobacco products" },
                    { new Guid("61d29676-3de3-4f2b-a003-2bf278d7c4ee"), "C.12.00", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tobacco products" },
                    { new Guid("bdf8a585-f0a1-49a4-8486-177bdbb67b83"), "C.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of textiles" },
                    { new Guid("bd94b961-44e8-4571-828f-fdd321b896ed"), "C.13.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Preparation and spinning of textile fibres" },
                    { new Guid("d3c23a9f-6707-4220-a006-7af34e108edf"), "C.13.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Preparation and spinning of textile fibres" },
                    { new Guid("403949ba-434d-4198-b84d-52131a30e39d"), "C.13.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Weaving of textiles" },
                    { new Guid("268c665a-a072-42a8-ad83-32a0afd4444e"), "C.13.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Weaving of textiles" },
                    { new Guid("a801180e-66b7-4f9e-8fe9-343b652fde29"), "C.13.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Finishing of textiles" },
                    { new Guid("87620109-25e6-4470-a9ae-bc717560f233"), "C.13.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Finishing of textiles" },
                    { new Guid("3d9234e2-da17-4edf-bc12-c80a27dbe40e"), "C.13.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other textiles" },
                    { new Guid("efc25604-b884-42e2-9548-5631b7b5ec47"), "C.13.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of knitted and crocheted fabrics" },
                    { new Guid("14fc7762-7ef9-4da2-8b88-995e2df1719f"), "C.13.92", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of made-up textile articles, except apparel" },
                    { new Guid("9d4ea1d9-629c-41c4-bd9c-41d817e35eba"), "C.13.93", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of carpets and rugs" },
                    { new Guid("d52d66d7-7f84-4e20-8282-c1f3654b906a"), "C.13.94", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cordage, rope, twine and netting" },
                    { new Guid("f1008b93-e822-4779-991e-b09c0b1456d1"), "C.13.95", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of non-wovens and articles made from non-wovens, except apparel" },
                    { new Guid("e76e610b-bf6f-4053-b1a6-426f67df49df"), "C.13.96", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other technical and industrial textiles" },
                    { new Guid("e3ddf118-6c56-4ca3-bf07-546bbdb0534a"), "C.13.99", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other textiles n.e.c." },
                    { new Guid("a0845313-d486-4634-bbc1-74ec3da9214c"), "C.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wearing apparel" },
                    { new Guid("838b2df4-9cf8-4600-8d3b-c1ba17cae282"), "C.14.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wearing apparel, except fur apparel" },
                    { new Guid("f3354569-b2a8-44fb-811b-d7dc5ba47d27"), "C.14.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of leather clothes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("dc6411d6-595f-48da-9bd7-f049535523f1"), "C.17.22", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of household and sanitary goods and of toilet requisites" },
                    { new Guid("e4bb0534-8a09-444a-bd1c-f749ae3442bb"), "C.11.01", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Distilling, rectifying and blending of spirits" },
                    { new Guid("8787f917-2675-401a-9dfe-7f4fdbef877c"), "C.17.23", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of paper stationery" },
                    { new Guid("a8609ed2-7687-4b95-a6bf-f0519f044977"), "C.17.29", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other articles of paper and paperboard" },
                    { new Guid("5016e8d3-f000-44b5-8160-136dba1bc4b8"), "C.20.52", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of glues" },
                    { new Guid("42d24543-dd32-496f-a4a6-7a6f0ecf0e2b"), "C.20.53", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of essential oils" },
                    { new Guid("52040513-b4b9-4629-835f-d8c9290fe4d1"), "C.20.59", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other chemical products n.e.c." },
                    { new Guid("71ba65f6-1c73-4528-b01c-2e2ba1fced37"), "C.20.6", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of man-made fibres" },
                    { new Guid("4db77737-4c9f-4002-905d-4dff772cb04d"), "C.20.60", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of man-made fibres" },
                    { new Guid("1428958c-fe6d-4343-9ac0-9567e8772ee2"), "C.21", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic pharmaceutical products and pharmaceutical preparations" },
                    { new Guid("cbd246e4-3761-4a0c-aed1-0264d3bafeac"), "C.21.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("0c0fb62d-ecc7-4cfd-bb02-13f903488c5e"), "C.21.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic pharmaceutical products" },
                    { new Guid("2a1e8664-fc18-452c-8266-fe90cf8a08d2"), "C.21.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("63eaeb53-e929-4b48-89ac-9482c69a07a3"), "C.21.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of pharmaceutical preparations" },
                    { new Guid("c6a80414-84c0-49de-bf4a-6b7582d8d1c7"), "C.22", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of rubber and plastic products" },
                    { new Guid("c2e30abd-78cb-4aba-8ffe-72dcdf032c5a"), "C.22.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of rubber products" },
                    { new Guid("45fcc11d-6ecf-4b05-a042-7425dab184de"), "C.20.51", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of explosives" },
                    { new Guid("d952288b-cd55-4123-b7b7-e648773ace45"), "C.22.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres" },
                    { new Guid("98850298-1699-47d3-b688-de03bb9f42c6"), "C.22.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of plastics products" },
                    { new Guid("5cf47d6b-357d-4d66-b233-168fb275bf14"), "C.22.21", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of plastic plates, sheets, tubes and profiles" },
                    { new Guid("1788ffd8-0be8-4242-b6a8-3c545ffe1824"), "C.22.22", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of plastic packing goods" },
                    { new Guid("3ef15f76-fc10-4142-bdf3-47f42946e45d"), "C.22.23", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of builders’ ware of plastic" },
                    { new Guid("9bd204a2-5d3e-444d-84b6-f2cf9356d1a1"), "C.22.29", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other plastic products" },
                    { new Guid("8da4bb20-0dd3-458d-a27b-5d42b7ddc1f2"), "C.23", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other non-metallic mineral products" },
                    { new Guid("bff928db-e353-4265-bc78-2d27fe2c4b3d"), "C.23.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of glass and glass products" },
                    { new Guid("55245703-0c08-4b82-a60d-180dbf150287"), "C.23.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of flat glass" },
                    { new Guid("be64808a-5683-422a-96e7-ddadc8f1b4b0"), "C.23.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Shaping and processing of flat glass" },
                    { new Guid("f7263fec-9a45-4086-bfd9-7c84006bcb0a"), "C.23.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of hollow glass" },
                    { new Guid("ebe53842-a0ea-4193-9be6-ee23cb420a0f"), "C.23.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of glass fibres" },
                    { new Guid("61483755-8a65-4a84-af8f-ebdb52a896a3"), "C.23.19", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture and processing of other glass, including technical glassware" },
                    { new Guid("0b1a8643-0968-4083-adad-f8072ea93252"), "C.22.19", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other rubber products" },
                    { new Guid("992de77c-3faa-4833-a6df-237230fd458f"), "C.20.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other chemical products" },
                    { new Guid("204f4ffe-d936-4ad9-acd8-0c91a473333e"), "C.20.42", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of perfumes and toilet preparations" },
                    { new Guid("edbde43b-6862-4568-9cda-adc9b09a833b"), "C.20.41", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of soap and detergents, cleaning and polishing preparations" },
                    { new Guid("eb97d827-792c-45e7-83d8-38b966758830"), "C.18", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Printing and reproduction of recorded media" },
                    { new Guid("a509fd64-ca9c-427e-962e-a404d1335da2"), "C.18.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Printing and service activities related to printing" },
                    { new Guid("9110cbe3-5942-4b1a-917e-de19eb83b3fa"), "C.18.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Printing of newspapers" },
                    { new Guid("66781348-cbcc-494f-811d-841863dccbbb"), "C.18.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Other printing" },
                    { new Guid("d7ef6e29-8997-4ca4-b640-b8a1671718ef"), "C.18.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Pre-press and pre-media services" },
                    { new Guid("806f4bbc-c55c-472e-b0e3-f4408e5bf1b9"), "C.18.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Binding and related services" },
                    { new Guid("06e3c458-5e01-4017-8115-8f0b07c88409"), "C.18.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Reproduction of recorded media" },
                    { new Guid("129eb6f9-87e2-4d55-abf8-b59151c57638"), "C.18.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Reproduction of recorded media" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1b788287-216b-43fc-99e5-a7f3777960b1"), "C.19", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of coke and refined petroleum products" },
                    { new Guid("91394641-0081-485d-9c47-5f9352e109ec"), "C.19.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of coke oven products" },
                    { new Guid("13d6ef85-756b-4bd7-8fbc-362dc8d59909"), "C.19.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of coke oven products" },
                    { new Guid("6a0f6a08-3b5e-40d9-b3ba-593169717dd8"), "C.19.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of refined petroleum products" },
                    { new Guid("e5a4e170-2453-4e2c-b12e-68185f1dbe3b"), "C.19.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of refined petroleum products" },
                    { new Guid("87800c11-0823-4ddc-80ad-6fef0258091e"), "C.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of chemicals and chemical products" },
                    { new Guid("b1f73d10-17cf-40ff-a5d4-f511cdcf9b7b"), "C.20.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic chemicals, fertilisers and nitrogen compounds, plastics and synthetic rubber in primary forms" },
                    { new Guid("9a8bfce8-c697-48ce-aa71-500d5aac9cab"), "C.20.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of industrial gases" },
                    { new Guid("bf0aafce-118c-47ca-abf5-060616e89f5d"), "C.20.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of dyes and pigments" },
                    { new Guid("085f391d-6ca4-42ef-8982-bf9f97187cf6"), "C.20.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other inorganic basic chemicals" },
                    { new Guid("b85684e6-ec18-4d8d-a074-0681e328ba35"), "C.20.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other organic basic chemicals" },
                    { new Guid("7bcbcb95-3bbc-4c42-9b6d-60dfa76abe3e"), "C.20.15", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fertilisers and nitrogen compounds" },
                    { new Guid("1ba2b189-0d3d-48bb-a47c-48af3f8ff298"), "C.20.16", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of plastics in primary forms" },
                    { new Guid("8f3dd057-cfa0-49ea-a05f-a8a4af9d7211"), "C.20.17", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of synthetic rubber in primary forms" },
                    { new Guid("7ed35e2c-6461-4ef8-ba45-5aa7aa6b58eb"), "C.20.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("4f03ebe0-85fe-4a21-bb85-4548a4d2606c"), "C.20.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of pesticides and other agrochemical products" },
                    { new Guid("397c03ff-14d5-4ab1-987e-125b9cb171aa"), "C.20.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("550ad145-57b3-405c-b697-35d8c4bcce51"), "C.20.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of paints, varnishes and similar coatings, printing ink and mastics" },
                    { new Guid("94db7fe9-82c2-4f63-8c4b-9b098f3519d3"), "C.20.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations" },
                    { new Guid("d0ab2138-2be3-41ac-8247-907513f8c5a8"), "C.17.24", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wallpaper" },
                    { new Guid("af537eeb-8de0-412b-9b7a-f1ded07efbd1"), "C.23.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of refractory products" },
                    { new Guid("1623d1f3-8654-47fb-ad56-42a085b00c56"), "C.11.0", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of beverages" },
                    { new Guid("f3dba2e3-4233-4ac8-b33d-635a41dc956e"), "C.10.92", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of prepared pet foods" },
                    { new Guid("9709003d-cf6f-4520-aa6e-144c4db10da9"), "A.01.6", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Support activities to agriculture and post-harvest crop activities" },
                    { new Guid("3ab0bd89-924b-4215-896b-d0850b5fe418"), "A.01.61", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Support activities for crop production" },
                    { new Guid("ec5779bc-c831-459c-9efb-662c347bdb79"), "A.01.62", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Support activities for animal production" },
                    { new Guid("15033388-447d-4997-a3a0-9263e7b63343"), "A.01.63", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Post-harvest crop activities" },
                    { new Guid("59c355ce-f898-405b-abd7-68f007d03dd3"), "A.01.64", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Seed processing for propagation" },
                    { new Guid("f43514fb-cef5-4d9c-b935-059dffbe7052"), "A.01.7", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Hunting, trapping and related service activities" },
                    { new Guid("15ebe735-3950-4d60-917c-3b67de2d048e"), "A.01.70", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Hunting, trapping and related service activities" },
                    { new Guid("708c0256-1ab7-46ea-a7fa-b309d5a14980"), "A.02", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Forestry and logging" },
                    { new Guid("9956724e-ce19-499b-80c2-89a60fee1fe2"), "A.02.1", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Silviculture and other forestry activities" },
                    { new Guid("df024d56-a186-483f-8271-bdcd875f4ac7"), "A.02.10", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Silviculture and other forestry activities" },
                    { new Guid("195c5ba8-8a14-421f-8004-7980f71decfd"), "A.02.2", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Logging" },
                    { new Guid("eb32a519-066b-4538-a145-ccd2e69a8727"), "A.02.20", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Logging" },
                    { new Guid("7a49613c-a9a0-4c0c-b021-6bf9bd8b958a"), "A.01.50", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Mixed farming" },
                    { new Guid("cea28656-7dac-44da-ae1b-eefb8180034b"), "A.02.3", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Gathering of wild growing non-wood products" },
                    { new Guid("f581d913-c5b9-4b60-ba55-b632b6f0ec0e"), "A.02.4", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Support services to forestry" },
                    { new Guid("3dc7c043-cac7-4f85-bf7a-3c0c079cdc81"), "A.02.40", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Support services to forestry" },
                    { new Guid("2eb5766f-e55c-48c4-bb7d-5ede0c7816fb"), "A.03", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Fishing and aquaculture" },
                    { new Guid("415890ab-ddd4-445e-81a0-276f656d43b6"), "A.03.1", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Fishing" },
                    { new Guid("6e776ade-23eb-4d47-bacc-8a12ad662d3b"), "A.03.11", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Marine fishing" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("d1296321-fad3-4b2b-940d-866a978aae26"), "A.03.12", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Freshwater fishing" },
                    { new Guid("15b9ccaf-ee3d-45e0-a208-a3dcf783100f"), "A.03.2", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Aquaculture" },
                    { new Guid("a2e8deec-3c6a-4f62-81c3-e98ffeeae2f7"), "A.03.21", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Marine aquaculture" },
                    { new Guid("df4613d2-cecc-4a63-82d3-d1a5691c3a5d"), "A.03.22", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Freshwater aquaculture" },
                    { new Guid("a1dca675-d7d9-45d8-862e-a9dd4545d52c"), "B.05", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of coal and lignite" },
                    { new Guid("03fd5558-0b7e-491c-92a2-264cd746d3a5"), "B.05.1", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of hard coal" },
                    { new Guid("35023700-0b82-430a-93b8-3fc44c7ca0ef"), "B.05.10", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of hard coal" },
                    { new Guid("883ee970-48bd-4f4a-979e-78c51451aa37"), "A.02.30", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Gathering of wild growing non-wood products" },
                    { new Guid("aa6cc04d-f89a-4ed5-b151-c03ac68accce"), "A.01.5", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Mixed farming" },
                    { new Guid("31028d15-8b05-4836-91ef-ab7c66cb8ec4"), "A.01.49", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of other animals" },
                    { new Guid("076764e8-b3e3-4bb4-a943-01c70aea3c74"), "A.01.47", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of poultry" },
                    { new Guid("4b6e3200-ef3f-4d79-b400-346c0cf249e6"), "A.01.1", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of non-perennial crops" },
                    { new Guid("5706e20e-cc1e-46de-9064-d92ddf7afdc4"), "A.01.11", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of cereals (except rice), leguminous crops and oil seeds" },
                    { new Guid("8f963bea-01b2-4480-86d1-118df90ccbc1"), "A.01.12", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of rice" },
                    { new Guid("50ca142e-06d6-4cb7-92b5-65d274cfc07b"), "A.01.13", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of vegetables and melons, roots and tubers" },
                    { new Guid("2bc4fdef-0bf1-496a-8952-cb3745abdad4"), "A.01.14", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of sugar cane" },
                    { new Guid("ff89db7c-d645-41ee-baf1-c9a9b88329a7"), "A.01.15", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of tobacco" },
                    { new Guid("cd9a78d9-4048-4d85-bcb5-f600dfb560de"), "A.01.16", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of fibre crops" },
                    { new Guid("297cef91-7745-47f6-9146-2544021312f8"), "A.01.19", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of other non-perennial crops" },
                    { new Guid("b4d2678f-22f2-4863-933b-9a2d6d0d4876"), "A.01.2", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of perennial crops" },
                    { new Guid("513c7d5e-8c02-4941-b79d-e3ef1811b686"), "A.01.21", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of grapes" },
                    { new Guid("12b6a9d2-6132-4bd2-a4be-07e5d6c3399b"), "A.01.22", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of tropical and subtropical fruits" },
                    { new Guid("1a28e56f-4a46-490a-a2b3-7bd75426b682"), "A.01.23", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of citrus fruits" },
                    { new Guid("3a7a39ac-8257-471b-8899-3d778d93f6a2"), "A.01.24", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of pome fruits and stone fruits" },
                    { new Guid("f9bb46a4-4d82-4b25-8e96-e0078d81f8ab"), "A.01.25", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of other tree and bush fruits and nuts" },
                    { new Guid("6cc401f7-c08d-45bd-98e7-3baefc8d3696"), "A.01.26", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of oleaginous fruits" },
                    { new Guid("8f724172-a045-4e48-9eb9-351e1d79f462"), "A.01.27", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of beverage crops" },
                    { new Guid("7f29aa89-3cfa-4478-a1ae-6af96403b825"), "A.01.28", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of spices, aromatic, drug and pharmaceutical crops" },
                    { new Guid("2c3173a4-f047-449a-98ea-237662584fdc"), "A.01.29", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Growing of other perennial crops" },
                    { new Guid("4c481190-2afd-48a4-b1b9-841fad52cf47"), "A.01.3", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Plant propagation" },
                    { new Guid("9442d8e8-1bd9-4e1a-81ae-f12057e5a234"), "A.01.30", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Plant propagation" },
                    { new Guid("f7ae1d91-acd0-4db7-90ec-6ec7f889b86c"), "A.01.4", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Animal production" },
                    { new Guid("ae19474b-9c23-44f2-996a-ccfd8ca02b26"), "A.01.41", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of dairy cattle" },
                    { new Guid("e8b95569-3a42-4a77-8e30-934f1a61ae12"), "A.01.42", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of other cattle and buffaloes" },
                    { new Guid("6a5cef48-8917-42c8-a7ed-b470b6619c6e"), "A.01.43", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of horses and other equines" },
                    { new Guid("261bb59d-dfc9-4446-886b-a88533f3277d"), "A.01.44", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of camels and camelids" },
                    { new Guid("8bf5a35d-3f9a-4391-a2dd-716fa02a6a07"), "A.01.45", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of sheep and goats" },
                    { new Guid("854565be-a892-4727-a5b2-f7cdc70dacca"), "A.01.46", new Guid("d8e7037f-fff0-4148-bf5b-711ecacec2a5"), "Raising of swine/pigs" },
                    { new Guid("4620d08d-1248-45ca-baee-be818848b36e"), "B.05.2", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of lignite" },
                    { new Guid("8106c11c-3cc8-4124-9cc5-84bec23219a2"), "C.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of beverages" },
                    { new Guid("1217cacb-83b8-449c-9bd4-708ccd93b035"), "B.05.20", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of lignite" },
                    { new Guid("7b56d231-abab-46c9-a272-0d7e2a1be99a"), "B.06.1", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of crude petroleum" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("5f08b66e-582f-4c0f-9a0e-6900fec6313a"), "C.10.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of potatoes" },
                    { new Guid("9514bbc4-f254-4278-a7f9-dc0ddc02ebbb"), "C.10.32", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fruit and vegetable juice" },
                    { new Guid("7f81bb26-8315-474f-b97b-38d9d7ca8e9d"), "C.10.39", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Other processing and preserving of fruit and vegetables" },
                    { new Guid("f110b332-4c2f-4c9a-ab08-8e32d166af59"), "C.10.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of vegetable and animal oils and fats" },
                    { new Guid("acd82b32-808b-4b44-8f24-f203eb7fb6a6"), "C.10.41", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of oils and fats" },
                    { new Guid("99dda20c-a6fa-4e55-9245-736e6a2c4309"), "C.10.42", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of margarine and similar edible fats" },
                    { new Guid("1d26207f-538c-4b5b-8960-c8956d338b10"), "C.10.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of dairy products" },
                    { new Guid("72b13095-11e3-41cb-8b44-7b4321311125"), "C.10.51", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Operation of dairies and cheese making" },
                    { new Guid("1e1a342d-e3a8-4856-a0cc-c137a8e943ce"), "C.10.52", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ice cream" },
                    { new Guid("07657860-21c2-4410-bca2-114fd188f668"), "C.10.6", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of grain mill products, starches and starch products" },
                    { new Guid("148e84d3-eec7-4ca9-a7b0-3c401d602c96"), "C.10.61", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of grain mill products" },
                    { new Guid("618abf43-3c06-4e2a-899a-62df53414705"), "C.10.62", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of starches and starch products" },
                    { new Guid("c5e55406-8228-4881-81fa-26b076725205"), "C.10.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of fruit and vegetables" },
                    { new Guid("2f7ca9c1-64f1-40bc-9249-fe4389369a84"), "C.10.7", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bakery and farinaceous products" },
                    { new Guid("68111c95-53b5-4b54-ba83-53d527aabcf7"), "C.10.72", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes" },
                    { new Guid("dbf368ec-3590-4232-8a19-b01102bc33ef"), "C.10.73", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of macaroni, noodles, couscous and similar farinaceous products" },
                    { new Guid("1b8de3d1-9568-40b1-a4bc-bfd6752db269"), "C.10.8", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other food products" },
                    { new Guid("bbd12044-83c4-4b62-8d0c-4bab15b7e810"), "C.10.81", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of sugar" },
                    { new Guid("de58917a-f2c0-4300-92e1-f418cf414652"), "C.10.82", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cocoa, chocolate and sugar confectionery" },
                    { new Guid("58d1abce-3e30-4a64-a41a-74b772ac8823"), "C.10.83", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing of tea and coffee" },
                    { new Guid("c02a88dd-787c-4058-972c-85e23aea2ab0"), "C.10.84", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of condiments and seasonings" },
                    { new Guid("6ab4bcd3-30c6-4aac-8176-9ecc9f3b5e80"), "C.10.85", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of prepared meals and dishes" },
                    { new Guid("59d9675c-e11e-492d-825f-05547a4fe174"), "C.10.86", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of homogenised food preparations and dietetic food" },
                    { new Guid("58d5e909-8716-46b7-83c5-abdf48894416"), "C.10.89", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other food products n.e.c." },
                    { new Guid("5ae389fb-6e86-4675-8d06-35493df4e936"), "C.10.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of prepared animal feeds" },
                    { new Guid("6d9ffe91-142d-4e3b-9afb-abd78aa81a69"), "C.10.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of prepared feeds for farm animals" },
                    { new Guid("422613ac-aea7-4a33-a0e1-45cd36008e72"), "C.10.71", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bread; manufacture of fresh pastry goods and cakes" },
                    { new Guid("6f2e3b39-a6b0-4b0d-922c-36e49261732d"), "C.10.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("89a6c32c-6f85-40b1-8487-d8781b8f405b"), "C.10.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of fish, crustaceans and molluscs" },
                    { new Guid("8c724856-d05a-4546-b7ec-e5131e303580"), "C.10.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Production of meat and poultry meat products" },
                    { new Guid("ecdc2ba4-4599-41b0-bb43-c47c24e79efd"), "B.06.10", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of crude petroleum" },
                    { new Guid("592f6f54-942d-4d29-903b-ecf30b9a5838"), "B.06.2", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of natural gas" },
                    { new Guid("38a19ca5-58e1-425a-b3d9-caee5021dfe2"), "B.06.20", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of natural gas" },
                    { new Guid("db83fc71-06e5-4fcb-abd1-d7a05c3799d4"), "B.07", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of metal ores" },
                    { new Guid("778633a7-6f8c-4df7-8003-c04f730a67aa"), "B.07.1", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of iron ores" },
                    { new Guid("d2865c70-3b3c-426d-ab8c-4a68d86daaf0"), "B.07.10", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of iron ores" },
                    { new Guid("a6a6f83d-d5bb-484d-ba8c-7d4c3787f845"), "B.07.2", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of non-ferrous metal ores" },
                    { new Guid("5ae06294-b468-4ab1-baff-6c243f09ca28"), "B.07.21", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of uranium and thorium ores" },
                    { new Guid("9d58fede-2372-4d5b-9ce2-0287132c4aa4"), "B.07.29", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of other non-ferrous metal ores" },
                    { new Guid("ea84a7e5-1b35-4cd2-87e3-6427c70ea31d"), "B.08", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Other mining and quarrying" },
                    { new Guid("e7b709b7-ede6-4b39-b212-6f011b5690be"), "B.08.1", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Quarrying of stone, sand and clay" },
                    { new Guid("fdc6eca7-0402-4c45-8bd3-f7ee1398e8a6"), "B.08.11", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("fb4de44a-4377-4596-8e10-0850995582df"), "B.08.12", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Operation of gravel and sand pits; mining of clays and kaolin" },
                    { new Guid("4ff27f3a-f534-4559-9a8e-6fcfa71478c2"), "B.08.9", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining and quarrying n.e.c." },
                    { new Guid("d2c281b7-b6d5-4e8b-9778-ce49996030f8"), "B.08.91", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining of chemical and fertiliser minerals" },
                    { new Guid("f6e2e3c3-d6b1-4658-9b0b-9a68df318206"), "B.08.92", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of peat" },
                    { new Guid("568e90eb-141c-43ab-b05c-7b0b6aecf121"), "B.08.93", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of salt" },
                    { new Guid("bff63eea-104e-4ec0-adbd-67ec1e314f45"), "B.08.99", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Other mining and quarrying n.e.c." },
                    { new Guid("bf8a1ef6-d9ef-4b4e-8604-3aa4be31c755"), "B.09", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Mining support service activities" },
                    { new Guid("930fcea2-ba1f-4ecd-9f04-50858793a5c5"), "B.09.1", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("155fddb0-028e-4898-ab3c-578febaacde7"), "B.09.10", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Support activities for petroleum and natural gas extraction" },
                    { new Guid("91b5222f-5ce3-4571-8de8-e606b3f0daff"), "B.09.9", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Support activities for other mining and quarrying" },
                    { new Guid("97adde8a-c783-4069-9e1e-d8f9ba6cab68"), "B.09.90", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Support activities for other mining and quarrying" },
                    { new Guid("46be64f0-fd54-47da-b3d0-ebd80c782195"), "C.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of food products" },
                    { new Guid("c449b6e7-d4d2-42f9-a7b7-5c62aee1cb25"), "C.10.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of meat and production of meat products" },
                    { new Guid("70949cc6-b8e3-4866-9c29-dcc983bc144a"), "C.10.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of meat" },
                    { new Guid("7c6db166-333e-442e-8ce5-441cbe7ef5ef"), "C.10.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing and preserving of poultry meat" },
                    { new Guid("e6ee12cd-df6c-40e2-99d4-b47d8b77dfb3"), "B.06", new Guid("60798474-efa5-4721-b33a-031e4f8b3a30"), "Extraction of crude petroleum and natural gas" },
                    { new Guid("72a21d4b-ea08-4f47-9fb1-e5e331309d5a"), "F.43.2", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Electrical, plumbing and other construction installation activities" },
                    { new Guid("c186fc5f-5ed2-4cfb-9a59-0eb4364e0e0e"), "C.23.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of refractory products" },
                    { new Guid("2eb27bb0-6354-46c7-bcb7-cd3c80582922"), "C.23.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ceramic tiles and flags" },
                    { new Guid("407080cc-8d1a-4d69-9f36-ac9b3b3dec45"), "C.30.92", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bicycles and invalid carriages" },
                    { new Guid("441a1670-b260-41c0-8bf4-6334608b538e"), "C.30.99", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other transport equipment n.e.c." },
                    { new Guid("d282ca3a-73e4-4aa1-98b5-b7c936b67d55"), "C.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of furniture" },
                    { new Guid("adcbfe64-e8c6-4b55-894c-fbac31cb5b6e"), "C.31.0", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of furniture" },
                    { new Guid("a99dbd1b-a171-47b2-bd3b-2929635d36d5"), "C.31.01", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of office and shop furniture" },
                    { new Guid("00c659f2-d2eb-47b0-afc7-912766be8b59"), "C.31.02", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of kitchen furniture" },
                    { new Guid("6b4e7e36-e2e5-4586-bc3a-f49528dcf0e4"), "C.31.03", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of mattresses" },
                    { new Guid("16dc8d0b-1a3a-44f5-a65e-99032a3f8972"), "C.31.09", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other furniture" },
                    { new Guid("87eee788-82cf-4d0f-9843-186293657c15"), "C.32", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Other manufacturing" },
                    { new Guid("f33dd38b-2afa-47ef-a950-e4b6f85a00ff"), "C.32.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of jewellery, bijouterie and related articles" },
                    { new Guid("7250bdaa-3206-404b-b142-a173a0177a66"), "C.32.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Striking of coins" },
                    { new Guid("40fd76cf-90d5-4df1-98e3-6c1985318bdd"), "C.32.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of jewellery and related articles" },
                    { new Guid("61b13d65-61d9-42f6-a3e8-6e0923f3e236"), "C.30.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of motorcycles" },
                    { new Guid("85dcd6a8-65d6-4247-8524-b98e039e86d1"), "C.32.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of imitation jewellery and related articles" },
                    { new Guid("eb2b1940-d30d-4c32-b13a-84bcfcd4ed1c"), "C.32.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of musical instruments" },
                    { new Guid("528942b5-61d8-4f70-9c4b-d072a351a39f"), "C.32.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of sports goods" },
                    { new Guid("4fda00e1-682d-40ff-a9a4-5507d8f0a986"), "C.32.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of sports goods" },
                    { new Guid("8ad799f6-8a82-441f-93a0-b2f7164c93a5"), "C.32.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of games and toys" },
                    { new Guid("45f65778-67aa-4337-9aaa-36dd9ab59ced"), "C.32.40", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of games and toys" },
                    { new Guid("66d28e87-99cd-40c2-8344-dcefaa7b6247"), "C.32.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("abb2def1-ce7b-46d6-bd9b-6f43b154c4e9"), "C.32.50", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of medical and dental instruments and supplies" },
                    { new Guid("a6e32a05-e19d-4eba-b56a-50ca4272c8aa"), "C.32.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacturing n.e.c." },
                    { new Guid("20ee3413-a171-4319-875e-ae38b29336a1"), "C.32.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of brooms and brushes" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("384310fc-0c98-4727-868a-4464b237ad8d"), "C.32.99", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Other manufacturing n.e.c." },
                    { new Guid("9d01c46a-f1d0-4879-85c0-b1d754ca6e0b"), "C.33", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair and installation of machinery and equipment" },
                    { new Guid("172f3a99-ee40-49a8-ac29-ae2e91c183f4"), "C.33.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair of fabricated metal products, machinery and equipment" },
                    { new Guid("02009589-d981-4282-8902-30e88c9625bd"), "C.32.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of musical instruments" },
                    { new Guid("2e9e89d5-ff26-4ad1-b385-91e821693750"), "C.30.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of transport equipment n.e.c." },
                    { new Guid("04f8f6a6-4046-4231-8601-9884f6f2de20"), "C.30.40", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of military fighting vehicles" },
                    { new Guid("d97fbecd-408d-4923-9093-42a601a885ca"), "C.30.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of military fighting vehicles" },
                    { new Guid("68c39356-3530-49c2-9b66-b53dd7f9e00b"), "C.28.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of metal forming machinery and machine tools" },
                    { new Guid("ea0667cf-6dda-4bbe-ad3d-0b4df6a426f2"), "C.28.41", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of metal forming machinery" },
                    { new Guid("c5ef5237-05e6-4a8b-b9b5-e4b18fe63381"), "C.28.49", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other machine tools" },
                    { new Guid("158759d2-cf3a-47e6-9105-5506dcfd0e5e"), "C.28.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other special-purpose machinery" },
                    { new Guid("85af23f0-7472-4ff2-a68c-5b29e5d0dfaf"), "C.28.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of machinery for metallurgy" },
                    { new Guid("ce3ce21c-921c-443b-bfd1-46f069602082"), "C.28.92", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of machinery for mining, quarrying and construction" },
                    { new Guid("997018e9-9445-482d-8ced-a087a22863c4"), "C.28.93", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of machinery for food, beverage and tobacco processing" },
                    { new Guid("700f16a2-c00f-4e87-a01b-57ebd8bf2b56"), "C.28.94", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of machinery for textile, apparel and leather production" },
                    { new Guid("060ddc94-f840-4266-b8d0-337a555e4f61"), "C.28.95", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of machinery for paper and paperboard production" },
                    { new Guid("b5fe8897-3bcd-4f51-b1bc-f17375f28d5f"), "C.28.96", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of plastics and rubber machinery" },
                    { new Guid("df779413-d199-49d2-8fe9-d6f27c3be077"), "C.28.99", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other special-purpose machinery n.e.c." },
                    { new Guid("09a01f3b-e39b-48b5-84c6-2a6b04f1f8eb"), "C.29", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of motor vehicles, trailers and semi-trailers" },
                    { new Guid("641517df-95eb-474b-aac7-2aaaf5698203"), "C.29.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of motor vehicles" },
                    { new Guid("d1faf335-215d-4ab0-8755-8baaf0d3f59e"), "C.29.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of motor vehicles" },
                    { new Guid("1884ed17-2136-4693-acca-885a71e9fbf8"), "C.29.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("9793ec1a-120a-4d84-ba94-3ff416ab12ec"), "C.29.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers" },
                    { new Guid("a70628e7-1dfc-4e67-a95e-06f003ddfe14"), "C.29.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of parts and accessories for motor vehicles" },
                    { new Guid("b7eaeb3f-51a4-4096-a8a1-539508eda3c1"), "C.29.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electrical and electronic equipment for motor vehicles" },
                    { new Guid("72084a41-4470-4f0f-94ae-3a304c0855df"), "C.29.32", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other parts and accessories for motor vehicles" },
                    { new Guid("ad498f3e-dff6-4be8-bf89-becf2cf1f31b"), "C.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other transport equipment" },
                    { new Guid("a5447f45-c8b4-46b6-ac0d-928323534b26"), "C.30.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Building of ships and boats" },
                    { new Guid("e2d8a3c1-a53a-4fe0-a9db-c60d6c60fb8c"), "C.30.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Building of ships and floating structures" },
                    { new Guid("230c412f-31f8-481d-9f02-77e651368611"), "C.30.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Building of pleasure and sporting boats" },
                    { new Guid("2188fbbc-0bb5-4e0b-914a-e164071bfcb4"), "C.30.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("a654292d-0884-4c6c-949d-ffc349472f16"), "C.30.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of railway locomotives and rolling stock" },
                    { new Guid("20514188-18e0-4575-b010-e5765979fbee"), "C.30.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("d270e770-e2eb-4baa-bbcb-0723a83ce186"), "C.30.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of air and spacecraft and related machinery" },
                    { new Guid("dec59e89-66d8-4379-a97a-300e76642cd0"), "C.33.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair of fabricated metal products" },
                    { new Guid("90a0c08d-2c07-4e4b-8d28-c67f5d68fcaf"), "C.28.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("f315d31a-9f50-4f90-ae51-7aed76cc8331"), "C.33.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair of machinery" },
                    { new Guid("6f286ce9-4bfc-4020-861a-7a044b6ffcd4"), "C.33.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair of electrical equipment" },
                    { new Guid("48aadba0-1dc7-4208-a52d-75ee5de68a0a"), "E.38.3", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Materials recovery" },
                    { new Guid("9764602d-7f06-4cbe-8a75-adc220f35c19"), "E.38.31", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Dismantling of wrecks" },
                    { new Guid("7e83a109-1463-454f-920f-a8d7f0b81db9"), "E.38.32", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Recovery of sorted materials" },
                    { new Guid("4c9a5ccb-22e9-4758-a28f-3b340f648caf"), "E.39", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Remediation activities and other waste management services" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("341d2c67-bf02-4ac5-90ab-00a6905722f5"), "E.39.0", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Remediation activities and other waste management services" },
                    { new Guid("baeed7c2-b794-434e-8616-425d2fefd455"), "E.39.00", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Remediation activities and other waste management services" },
                    { new Guid("77fef277-7147-4368-9a59-1063b52254cc"), "F.41", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of buildings" },
                    { new Guid("46b86806-7cc6-497a-8983-70bbace74e8c"), "F.41.1", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Development of building projects" },
                    { new Guid("9297ae48-b459-43c0-9634-6ddd5ffc4951"), "F.41.10", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Development of building projects" },
                    { new Guid("e1fe86b4-b721-43fe-8d0c-9414bc9ae035"), "F.41.2", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of residential and non-residential buildings" },
                    { new Guid("9e71e2a5-1bfc-475d-b8f7-19ff51c3f8d8"), "F.41.20", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of residential and non-residential buildings" },
                    { new Guid("1b730bc1-bc6d-47da-b860-a83787e47d79"), "F.42", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Civil engineering" },
                    { new Guid("0276bafc-5b42-4d28-8d33-5cb981744045"), "E.38.22", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Treatment and disposal of hazardous waste" },
                    { new Guid("cd809a00-32ba-4ea6-95a5-ea6a2b709b57"), "F.42.1", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of roads and railways" },
                    { new Guid("1faea384-5c96-4749-bb44-d8cf88b12583"), "F.42.12", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of railways and underground railways" },
                    { new Guid("6536b289-0c2d-48ae-8061-325ff7f7918d"), "F.42.13", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of bridges and tunnels" },
                    { new Guid("f0cd0cc9-0719-4056-8e34-5467a6d7012b"), "F.42.2", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of utility projects" },
                    { new Guid("39e6ded0-0fa6-417d-ae16-049623177183"), "F.42.21", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of utility projects for fluids" },
                    { new Guid("6a4655a4-da29-45ed-8382-f212803ed244"), "F.42.22", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of utility projects for electricity and telecommunications" },
                    { new Guid("9cdbbed9-6654-4fde-b7b8-c7ca7e080b6d"), "F.42.9", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of other civil engineering projects" },
                    { new Guid("154c0c6b-244e-414c-9aad-e26ebed96c30"), "F.42.91", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of water projects" },
                    { new Guid("62bed47e-119d-4812-84ea-14760cc1862f"), "F.42.99", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of other civil engineering projects n.e.c." },
                    { new Guid("599b453e-4bf0-4354-aa8d-976eca3b8868"), "F.43", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Specialised construction activities" },
                    { new Guid("2863dcdc-d21b-4778-b34c-a20ed73a5737"), "F.43.1", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Demolition and site preparation" },
                    { new Guid("19cf0a5a-2ce9-4719-9bcc-fae0f4c94204"), "F.43.11", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Demolition" },
                    { new Guid("5bda4c26-71cd-42b2-8d83-4fc544a5197a"), "F.43.12", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Site preparation" },
                    { new Guid("bf611187-fa9c-47db-9c86-8159c21bbdc6"), "F.42.11", new Guid("43198bed-bd01-4d3b-8100-772ec6e39f4e"), "Construction of roads and motorways" },
                    { new Guid("bc3b2ce2-d1fa-4355-b5ab-d68409d9c61c"), "E.38.21", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Treatment and disposal of non-hazardous waste" },
                    { new Guid("3894a1f4-8252-40f0-b39b-4ba2e2173eee"), "E.38.2", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Waste treatment and disposal" },
                    { new Guid("f90a6486-82c1-428f-8752-2cf269ab26d1"), "E.38.12", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Collection of hazardous waste" },
                    { new Guid("38b1f2a6-ab63-4a28-a93c-853e7f9f4c96"), "C.33.15", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair and maintenance of ships and boats" },
                    { new Guid("17b6380d-6a94-4db6-b01f-59797c3af39d"), "C.33.16", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair and maintenance of aircraft and spacecraft" },
                    { new Guid("88c34645-a8d0-423f-ba43-31c448e4c3aa"), "C.33.17", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair and maintenance of other transport equipment" },
                    { new Guid("0f7de9c0-81b9-4ec6-b8d0-4a62fcd92e36"), "C.33.19", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair of other equipment" },
                    { new Guid("2d9f99ca-ecb8-4f81-94ce-c6d5d8656d86"), "C.33.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Installation of industrial machinery and equipment" },
                    { new Guid("f71b2654-1341-4cdf-babd-2edd5a04ead4"), "C.33.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Installation of industrial machinery and equipment" },
                    { new Guid("abd268b0-45d2-4c6e-9dee-21966f014522"), "D.35", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Electricity, gas, steam and air conditioning supply" },
                    { new Guid("7d70aba5-aa8c-4d93-b7cb-f1d795407715"), "D.35.1", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Electric power generation, transmission and distribution" },
                    { new Guid("0c40a8ec-4719-460a-896e-8f0335973ff0"), "D.35.11", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Production of electricity" },
                    { new Guid("2742cee9-518b-481a-8a62-39ec6fe8a577"), "D.35.12", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Transmission of electricity" },
                    { new Guid("e3f36d64-9cd4-4b2e-98d0-fdfa31497877"), "D.35.13", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Distribution of electricity" },
                    { new Guid("735065fb-d633-4447-9395-2c3e735b0e52"), "D.35.14", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Trade of electricity" },
                    { new Guid("27cd1407-6fc9-41e3-9d51-76c801621eb8"), "D.35.2", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Manufacture of gas; distribution of gaseous fuels through mains" },
                    { new Guid("9dc32b84-31f4-4639-8680-59bc82fa7285"), "D.35.21", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Manufacture of gas" },
                    { new Guid("ede8d91e-8e44-4597-bd03-141dec583e91"), "D.35.22", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Distribution of gaseous fuels through mains" },
                    { new Guid("a4f8e1d5-64d0-4a15-a341-cd56cc9d7fce"), "D.35.23", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Trade of gas through mains" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("e5ca58ce-e9a8-4aed-9ba8-e11794a1bde5"), "D.35.3", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Steam and air conditioning supply" },
                    { new Guid("e0e27a8f-3502-4868-bafe-68e326da2042"), "D.35.30", new Guid("bbb886fa-e144-4524-8c8e-de500cf36c74"), "Steam and air conditioning supply" },
                    { new Guid("a62d1316-2321-4b82-b710-0178551c7f02"), "E.36", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Water collection, treatment and supply" },
                    { new Guid("d35c0595-8fcf-4d55-919c-7b2f79f8fabd"), "E.36.0", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Water collection, treatment and supply" },
                    { new Guid("965c3692-98c4-46f6-81bd-abb7c2e42bde"), "E.36.00", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Water collection, treatment and supply" },
                    { new Guid("57755990-f2f1-432d-ac75-a8c2b2f70391"), "E.37", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Sewerage" },
                    { new Guid("6c3106f1-6a9e-4e76-ae86-bf976066ce95"), "E.37.0", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Sewerage" },
                    { new Guid("8fae6c9c-540e-4912-b68f-f6126da9c20e"), "E.37.00", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Sewerage" },
                    { new Guid("de7dae19-1edd-4745-8ce0-24b2a87bf130"), "E.38", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Waste collection, treatment and disposal activities; materials recovery" },
                    { new Guid("bd642ba8-1e57-4e23-b2cf-802d75ee2bd9"), "E.38.1", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Waste collection" },
                    { new Guid("47391d53-aba1-408b-afce-8277e6bae0ad"), "E.38.11", new Guid("f3557dcf-bda8-4b0a-ab9b-c78905e3940e"), "Collection of non-hazardous waste" },
                    { new Guid("00867721-a170-40e7-bd8a-ed9340112d00"), "C.33.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Repair of electronic and optical equipment" },
                    { new Guid("7c6101d5-d7cb-4ae0-a75e-1a9535f9491d"), "C.23.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of clay building materials" },
                    { new Guid("0b49a83f-d0aa-4b72-862d-30c2682f08c5"), "C.28.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of agricultural and forestry machinery" },
                    { new Guid("3d41e23c-8f30-44ea-b25a-c73f362d41c9"), "C.28.25", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of non-domestic cooling and ventilation equipment" },
                    { new Guid("761edf42-cacc-439c-b45e-45f94282725e"), "C.24.34", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Cold drawing of wire" },
                    { new Guid("fcff2d70-a5b1-4736-9244-c77bc3f728a7"), "C.24.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic precious and other non-ferrous metals" },
                    { new Guid("642b099e-658f-4971-aabd-6b5220940470"), "C.24.41", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Precious metals production" },
                    { new Guid("d344bff2-eaf0-4b2c-b079-c7a6c3c574d9"), "C.24.42", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Aluminium production" },
                    { new Guid("0186f048-b9a5-4f44-974c-04e79dd38f8b"), "C.24.43", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Lead, zinc and tin production" },
                    { new Guid("cc5456af-a821-4346-a6be-a5b619b9c909"), "C.24.44", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Copper production" },
                    { new Guid("520adff3-852c-4bf4-ac46-a7a6d224c6d6"), "C.24.45", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Other non-ferrous metal production" },
                    { new Guid("42afd9da-c3be-4f24-876f-5ef2528183ee"), "C.24.46", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Processing of nuclear fuel" },
                    { new Guid("bafcd5d7-ce44-4901-aa30-87d61f489392"), "C.24.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Casting of metals" },
                    { new Guid("2aa99bb9-8e6c-4973-ba87-2fd684c4eb3d"), "C.24.51", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Casting of iron" },
                    { new Guid("82764332-9914-4517-b2de-f42f9ad6010b"), "C.24.52", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Casting of steel" },
                    { new Guid("92d2284d-1bd4-4cdc-96e4-202cac0d5907"), "C.24.53", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Casting of light metals" },
                    { new Guid("8b8841b8-e69d-4eb0-8c28-48d943ac1485"), "C.24.33", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Cold forming or folding" },
                    { new Guid("2ef3d0bf-7a30-497c-aa5e-2eb665dcb874"), "C.24.54", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Casting of other non-ferrous metals" },
                    { new Guid("da0fc6be-1c58-4e9e-9acd-5097d8999074"), "C.25.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of structural metal products" },
                    { new Guid("62c5a3c5-0173-4429-93e9-fbb3e02a4ba6"), "C.25.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of metal structures and parts of structures" },
                    { new Guid("880b06b0-130e-467e-bec7-aebc56f1c190"), "C.25.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of doors and windows of metal" },
                    { new Guid("b7195128-5fdd-4db3-841b-826cea101b8f"), "C.25.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tanks, reservoirs and containers of metal" },
                    { new Guid("b9ca2d6c-5954-48b0-95d7-d5faf2d6a3ad"), "C.25.21", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of central heating radiators and boilers" },
                    { new Guid("43d93ca4-b26d-4883-8694-df45fcc8cd59"), "C.25.29", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other tanks, reservoirs and containers of metal" },
                    { new Guid("7cbe062f-1a95-4f2d-a08e-33d3cbce9cb1"), "C.25.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("7dc0532c-fe57-4ea5-9c03-c5e8bf3244b4"), "C.25.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of steam generators, except central heating hot water boilers" },
                    { new Guid("0441887e-6c3a-4850-89cf-2af491704add"), "C.25.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of weapons and ammunition" },
                    { new Guid("18541281-a721-4125-934c-6faae4f5436a"), "C.25.40", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of weapons and ammunition" },
                    { new Guid("75263151-a349-44d5-b65b-091fb72eaa1e"), "C.25.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("f9f3fe7f-91b3-4614-b8d5-eca7f59b8ce2"), "C.25.50", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Forging, pressing, stamping and roll-forming of metal; powder metallurgy" },
                    { new Guid("4511ff71-7a71-41d3-a668-33c2af4f380a"), "C.25", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fabricated metal products, except machinery and equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("475b4767-b94d-41dc-b7f0-ca7161158203"), "C.24.32", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Cold rolling of narrow strip" },
                    { new Guid("04ea54e0-7c7c-47b0-b491-e31895b11631"), "C.24.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Cold drawing of bars" },
                    { new Guid("f744df86-4079-4584-b860-d51d064aca63"), "C.24.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other products of first processing of steel" },
                    { new Guid("0c2419e9-1d73-4720-8b55-f55f0c1d8a92"), "C.23.32", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bricks, tiles and construction products, in baked clay" },
                    { new Guid("33be84ec-241a-4ab9-82d6-c1b898e3e59a"), "C.23.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other porcelain and ceramic products" },
                    { new Guid("c3889a01-9f1c-453f-ad2b-0afb3780e8ec"), "C.23.41", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ceramic household and ornamental articles" },
                    { new Guid("9a5af711-92b5-4bb4-a0d1-086c9e0b1d70"), "C.23.42", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ceramic sanitary fixtures" },
                    { new Guid("1e564311-c011-4cfb-9a24-18b7750f721e"), "C.23.43", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ceramic insulators and insulating fittings" },
                    { new Guid("e85f4131-7ac5-4278-a6b4-b2cc243c8a15"), "C.23.44", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other technical ceramic products" },
                    { new Guid("02d889e0-547d-4b93-abf7-ffb3dbb542dc"), "C.23.49", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other ceramic products" },
                    { new Guid("de12c01f-cb83-4cd6-9659-34f9644e4ec8"), "C.23.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cement, lime and plaster" },
                    { new Guid("0cb0720b-4780-419f-95f8-12ed19409bae"), "C.23.51", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cement" },
                    { new Guid("6199c8ab-dd66-4d06-b481-963ee1f6200b"), "C.23.52", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of lime and plaster" },
                    { new Guid("629b3056-d2fe-42e9-b480-740c0f09d125"), "C.23.6", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of articles of concrete, cement and plaster" },
                    { new Guid("47741955-9813-4e67-8892-9e2827d6dbae"), "C.23.61", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of concrete products for construction purposes" },
                    { new Guid("5b367691-55e5-4932-9a9c-27440cc8f9ab"), "C.23.62", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of plaster products for construction purposes" },
                    { new Guid("1ee8b55e-b153-4a4d-92fc-ad59803a0334"), "C.23.63", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ready-mixed concrete" },
                    { new Guid("49f0f965-03f8-448b-bab8-0754bf486f0c"), "C.23.64", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of mortars" },
                    { new Guid("7f703e66-887e-4301-aa17-bef5f9aa435c"), "C.23.65", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fibre cement" },
                    { new Guid("3f01f094-625b-4055-a22f-c393e90d2cbb"), "C.23.69", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other articles of concrete, plaster and cement" },
                    { new Guid("aeeee077-9b44-4f1c-8d22-cb3f2a24a993"), "C.23.7", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Cutting, shaping and finishing of stone" },
                    { new Guid("3cf1fe9c-4046-4af1-bdef-5dfd08ed6ca2"), "C.23.70", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Cutting, shaping and finishing of stone" },
                    { new Guid("84e405b3-b696-4e94-869d-b40379330385"), "C.23.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of abrasive products and non-metallic mineral products n.e.c." },
                    { new Guid("8cbe0928-e0f9-43b3-9bf8-19e46b3886ea"), "C.23.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Production of abrasive products" },
                    { new Guid("f4069fa1-1c1a-4e7f-9cc1-ec83941c177f"), "C.23.99", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other non-metallic mineral products n.e.c." },
                    { new Guid("e54558b4-0c66-4575-baee-58a341a6bb5c"), "C.24", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic metals" },
                    { new Guid("7f9d8a8c-d56e-4759-87ae-8f73d277cf8e"), "C.24.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("51c0317e-f7e5-477f-9788-0021eadabc05"), "C.24.10", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of basic iron and steel and of ferro-alloys" },
                    { new Guid("f67772c3-f518-4af0-888a-d60ce7ff0d15"), "C.24.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("2dda27ec-65ec-464f-a0b8-9dc062a15ee6"), "C.24.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tubes, pipes, hollow profiles and related fittings, of steel" },
                    { new Guid("6e1dc6b2-620c-4ac4-b626-b6af82049132"), "C.25.6", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Treatment and coating of metals; machining" },
                    { new Guid("bc0d7116-33de-4e1f-827a-9b2f13a8e48c"), "C.28.29", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other general-purpose machinery n.e.c." },
                    { new Guid("6bf2cc60-dffa-4bb0-8afc-0f39741ac9e9"), "C.25.61", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Treatment and coating of metals" },
                    { new Guid("e12617e7-e76e-4ac3-85ea-0209109ebf2f"), "C.25.7", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cutlery, tools and general hardware" },
                    { new Guid("5592fb06-b7e2-4320-b9b1-96ea5dcd8033"), "C.27.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electricity distribution and control apparatus" },
                    { new Guid("3a31e729-a630-42d0-88d3-8e7ccf00e85d"), "C.27.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of batteries and accumulators" },
                    { new Guid("b45d05db-06c2-4961-b847-2e5d1562e744"), "C.27.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of batteries and accumulators" },
                    { new Guid("a45c7cab-0e0c-4561-9c31-1034390ba3e8"), "C.27.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wiring and wiring devices" },
                    { new Guid("e691d667-d860-4232-b3c5-a43c1cf71048"), "C.27.31", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fibre optic cables" },
                    { new Guid("7b6cfeb9-1cf8-428e-9469-1afc6b107fc9"), "C.27.32", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other electronic and electric wires and cables" },
                    { new Guid("86572812-80ed-47e5-82ad-4e35850a23cb"), "C.27.33", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wiring devices" },
                    { new Guid("a55e9343-f352-43e2-86c5-f497048f5785"), "C.27.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electric lighting equipment" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("1c66fb7e-084f-4333-974c-47b5e552248a"), "C.27.40", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electric lighting equipment" },
                    { new Guid("764d4342-8305-4c67-9f8c-bc27ba556caf"), "C.27.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of domestic appliances" },
                    { new Guid("393e4b7e-a4cc-41ce-99df-18879f0a1d90"), "C.27.51", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electric domestic appliances" },
                    { new Guid("fec8cb9c-34d7-491f-a0d3-1362464da1b9"), "C.27.52", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of non-electric domestic appliances" },
                    { new Guid("bed2d71f-c689-4832-893a-a414a598c663"), "C.27.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electric motors, generators and transformers" },
                    { new Guid("382d8f76-25e9-4dd2-b194-296abb8ab3bf"), "C.27.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other electrical equipment" },
                    { new Guid("a5dfddcf-88d1-457a-9800-90b1b3b7c18f"), "C.28", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of machinery and equipment n.e.c." },
                    { new Guid("af654855-8e78-4916-b69f-75a3b869500f"), "C.28.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of general-purpose machinery" },
                    { new Guid("0b9f7db2-f983-488a-b59e-32f92e27bb96"), "C.28.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of engines and turbines, except aircraft, vehicle and cycle engines" },
                    { new Guid("b11b398e-ff6d-459f-84b3-b72d15e3456e"), "C.28.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fluid power equipment" },
                    { new Guid("07f2b23e-2fa3-4511-9216-d769f0c89d9d"), "C.28.13", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other pumps and compressors" },
                    { new Guid("cebc0667-d200-4cdf-8fd7-309f27de94b3"), "C.28.14", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other taps and valves" },
                    { new Guid("de40adc4-22bc-491d-abd9-7d791fcb5af3"), "C.28.15", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of bearings, gears, gearing and driving elements" },
                    { new Guid("6951d224-1b86-47e5-9f22-74b05678dccd"), "C.28.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other general-purpose machinery" },
                    { new Guid("afa9e17e-a9c5-4b9e-9cdf-d5dd6487000a"), "C.28.21", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of ovens, furnaces and furnace burners" },
                    { new Guid("56be5598-1186-40ec-b0b1-3e76e967420f"), "C.28.22", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of lifting and handling equipment" },
                    { new Guid("48cdef1f-d99b-4c84-a87f-605564fab73e"), "C.28.23", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of office machinery and equipment (except computers and peripheral equipment)" },
                    { new Guid("43b0d5e0-0005-4400-8582-60fb3004c672"), "C.28.24", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of power-driven hand tools" },
                    { new Guid("8ebfcc18-6c54-4bf3-855f-c501fa4d68cd"), "C.27.90", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other electrical equipment" },
                    { new Guid("04cd5747-141e-48f4-a6bf-3cf592061b17"), "C.27.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electric motors, generators, transformers and electricity distribution and control apparatus" },
                    { new Guid("2ddf5a9f-8447-4f79-8d62-9710e17fd52b"), "C.27", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electrical equipment" },
                    { new Guid("767c0343-01c6-4b8a-bd3b-88037fd32528"), "C.26.80", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of magnetic and optical media" },
                    { new Guid("e7045668-a49a-4a9c-bb94-92dc2a07559f"), "C.25.71", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of cutlery" },
                    { new Guid("1ed1f12f-a735-4b8a-85c4-3e5f8d0570fe"), "C.25.72", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of locks and hinges" },
                    { new Guid("90f91a60-ef5b-4bd5-96f0-a0e70e6d8f4a"), "C.25.73", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of tools" },
                    { new Guid("e770d0b8-b54e-4635-ac9b-090b0d78c171"), "C.25.9", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other fabricated metal products" },
                    { new Guid("9d7448ad-9229-4076-b96d-0fee94503864"), "C.25.91", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of steel drums and similar containers" },
                    { new Guid("ade03e34-f107-4a75-a075-fbde07831dc8"), "C.25.92", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of light metal packaging" },
                    { new Guid("7c439f03-d5bd-4161-92e1-fe3865c38bfb"), "C.25.93", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of wire products, chain and springs" },
                    { new Guid("51bcc324-40ab-4e41-861a-4ef173c67eaf"), "C.25.94", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of fasteners and screw machine products" },
                    { new Guid("158d65d8-7028-4091-bb1f-fe21a2c9d6ab"), "C.25.99", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of other fabricated metal products n.e.c." },
                    { new Guid("37cbcc26-b17d-4b4f-a418-b58c6db9501e"), "C.26", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of computer, electronic and optical products" },
                    { new Guid("24d8990f-91c6-43dc-b8b9-4ad622ed6437"), "C.26.1", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electronic components and boards" },
                    { new Guid("ff3940d5-f449-4a91-a10d-f654abbc03a6"), "C.26.11", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of electronic components" },
                    { new Guid("6ee0142f-05b2-4040-8d77-85785e3be5f7"), "C.26.12", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of loaded electronic boards" },
                    { new Guid("d7a42ec7-7723-4a34-baa8-a10b71c316e0"), "C.26.2", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("469f0f84-377e-46db-873e-3ad969ed7ad9"), "C.26.20", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of computers and peripheral equipment" },
                    { new Guid("23f44e0a-32d3-4413-95a0-bbfa28b76495"), "C.26.3", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of communication equipment" },
                    { new Guid("f48a2839-f73f-46d3-86ba-4d4abac19f8c"), "C.26.30", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of communication equipment" },
                    { new Guid("97a5ff0b-d39a-44b1-b4fc-0aadcda06359"), "C.26.4", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of consumer electronics" },
                    { new Guid("fed43f2a-e79e-418d-aa51-5045feb6b80b"), "C.26.40", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of consumer electronics" },
                    { new Guid("fc8818ee-3888-4f4f-a53e-1279ea81e925"), "C.26.5", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of instruments and appliances for measuring, testing and navigation; watches and clocks" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Code", "IndustryId", "Title" },
                values: new object[,]
                {
                    { new Guid("113e93a6-a0b4-4d76-96d0-e0b034734633"), "C.26.51", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of instruments and appliances for measuring, testing and navigation" },
                    { new Guid("856c0f21-3953-4a97-8ad9-34a7892a03e6"), "C.26.52", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of watches and clocks" },
                    { new Guid("8732e65e-15ee-4000-b077-eeb562c0acc2"), "C.26.6", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("654829a7-51b3-47ec-a424-4aabfada1979"), "C.26.60", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of irradiation, electromedical and electrotherapeutic equipment" },
                    { new Guid("a650d2f0-44e1-4ca8-bced-e179f5330355"), "C.26.7", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("e9564d4c-4f5a-478c-884b-5ff3b50a329c"), "C.26.70", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of optical instruments and photographic equipment" },
                    { new Guid("471dbb35-8903-4637-94bf-c90b1b08e855"), "C.26.8", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Manufacture of magnetic and optical media" },
                    { new Guid("06c59b10-ec2e-4ea8-880b-0f8fb0c93f2a"), "C.25.62", new Guid("cad84cd0-284d-4989-af9f-36b451e07d64"), "Machining" },
                    { new Guid("630acfac-e1af-482b-9136-191ceb9d0780"), "U.99.00", new Guid("18bcd142-95cf-4e86-bdb7-99696e6f027f"), "Activities of extraterritorial organisations and bodies" }
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
