using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class Countries_and_UserBusinessPlan_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryNr",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                table: "Countries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Countries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserBusinessPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusinessPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBusinessPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: true),
                    ActivityId = table.Column<Guid>(nullable: true),
                    TitleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPlan_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessPlan_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessPlan_UserBusinessPlans_TitleId",
                        column: x => x.TitleId,
                        principalTable: "UserBusinessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("915c3b87-0ca3-4403-b1ad-c79fc0082f3b"), "BE", "Belgium" },
                    { new Guid("6b419cb1-2f7b-4a81-95e4-ab738ddb53ed"), "AT", "Austria" },
                    { new Guid("561e567e-3fe7-49a0-b1bf-023628be559b"), "NL", "Netherlands" },
                    { new Guid("1dbd9296-25fb-41ff-943d-93e5e6daf835"), "MT", "Malta" },
                    { new Guid("eff0ccb0-3ec6-422b-9978-291b28801dab"), "HU", "Hungary" },
                    { new Guid("4438596a-7f16-4c0f-901a-2965fdf78a62"), "LU", "Luxembourg" },
                    { new Guid("c8dc2bc1-7617-4e95-b237-61f8f233db2d"), "LT", "Lithuania" },
                    { new Guid("b41cd2a9-b84a-4feb-a720-59e717410132"), "LV", "Latvia" },
                    { new Guid("1ef36684-a8f4-4617-82bd-a510d1689f12"), "CY", "Cyprus" },
                    { new Guid("c2bae133-4318-499a-a85d-69b74b15bcb0"), "IT", "Italy" },
                    { new Guid("0e997fa7-ea44-441a-a5f8-b7b493db284f"), "HR", "Croatia" },
                    { new Guid("c3339870-5e3a-40a3-a8d3-41b7e2fb0e14"), "FR", "France" },
                    { new Guid("9319ed0b-778d-443b-8206-3a184d82bd28"), "ES", "Spain" },
                    { new Guid("fe976a88-c434-4fbc-80c4-028d8a26a7bf"), "EL", "Greece" },
                    { new Guid("0dedbb53-5e1b-4d52-92a2-08fe48dcd92c"), "IE", "Ireland" },
                    { new Guid("b310ddf7-1c0a-45a3-bbf3-e3849de4940a"), "EE", "Estonia" },
                    { new Guid("25f7aa3f-86bc-49a2-987b-27fc10337ecf"), "DE", "Germany" },
                    { new Guid("0ac17433-3a96-4b41-920c-d9ed69f82b2e"), "DK", "Denmark" },
                    { new Guid("77feeaad-8fb5-4c3c-a406-ab02dd6bd4a0"), "CZ", "Czechia" },
                    { new Guid("e6d62294-d062-40c6-bb69-f25309f28374"), "BG", "Bulgaria" },
                    { new Guid("e98b3a0e-7dbf-4025-8894-13ec5fe8b5aa"), "PL", "Poland" },
                    { new Guid("29ead83e-5e1e-4c2d-a317-5eddf4d23925"), "PT", "Portugal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlan_ActivityId",
                table: "BusinessPlan",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlan_CountryId",
                table: "BusinessPlan",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlan_TitleId",
                table: "BusinessPlan",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinessPlans_UserId",
                table: "UserBusinessPlans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPlan");

            migrationBuilder.DropTable(
                name: "UserBusinessPlans");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0ac17433-3a96-4b41-920c-d9ed69f82b2e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0dedbb53-5e1b-4d52-92a2-08fe48dcd92c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e997fa7-ea44-441a-a5f8-b7b493db284f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1dbd9296-25fb-41ff-943d-93e5e6daf835"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ef36684-a8f4-4617-82bd-a510d1689f12"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("25f7aa3f-86bc-49a2-987b-27fc10337ecf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("29ead83e-5e1e-4c2d-a317-5eddf4d23925"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4438596a-7f16-4c0f-901a-2965fdf78a62"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("561e567e-3fe7-49a0-b1bf-023628be559b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6b419cb1-2f7b-4a81-95e4-ab738ddb53ed"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("77feeaad-8fb5-4c3c-a406-ab02dd6bd4a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("915c3b87-0ca3-4403-b1ad-c79fc0082f3b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9319ed0b-778d-443b-8206-3a184d82bd28"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b310ddf7-1c0a-45a3-bbf3-e3849de4940a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b41cd2a9-b84a-4feb-a720-59e717410132"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c2bae133-4318-499a-a85d-69b74b15bcb0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3339870-5e3a-40a3-a8d3-41b7e2fb0e14"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c8dc2bc1-7617-4e95-b237-61f8f233db2d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e6d62294-d062-40c6-bb69-f25309f28374"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e98b3a0e-7dbf-4025-8894-13ec5fe8b5aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eff0ccb0-3ec6-422b-9978-291b28801dab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fe976a88-c434-4fbc-80c4-028d8a26a7bf"));

            migrationBuilder.DropColumn(
                name: "ShortCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryNr",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
