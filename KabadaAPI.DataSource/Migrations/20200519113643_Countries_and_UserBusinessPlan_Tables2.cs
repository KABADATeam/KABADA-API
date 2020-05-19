using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class Countries_and_UserBusinessPlan_Tables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlan_UserBusinessPlans_TitleId",
                table: "BusinessPlan");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPlan_TitleId",
                table: "BusinessPlan");

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
                name: "TitleId",
                table: "BusinessPlan");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BusinessPlan",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserBusinessPlanId",
                table: "BusinessPlan",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("42f8ae56-377e-4f98-a7fb-825e059304fb"), "BE", "Belgium" },
                    { new Guid("59f14e5a-dd91-4db1-b902-b89e12a77fe0"), "AT", "Austria" },
                    { new Guid("47c37222-1e70-47eb-8789-010f50c1aed5"), "NL", "Netherlands" },
                    { new Guid("89c8ec1c-ff5a-4d97-a245-e8214f106644"), "MT", "Malta" },
                    { new Guid("3f1ae0bd-01d7-4b55-9c9c-c0c63d59ff97"), "HU", "Hungary" },
                    { new Guid("9206cdc0-0fe7-4ed9-8ba9-1f8c1c15105d"), "LU", "Luxembourg" },
                    { new Guid("e4082eb6-b027-4d9e-8d37-f88bcd7cd30f"), "LT", "Lithuania" },
                    { new Guid("ec1bdfb2-6a45-48da-9511-bbc29463e779"), "LV", "Latvia" },
                    { new Guid("54183507-d544-4a51-adf9-f5d3f0569fa8"), "CY", "Cyprus" },
                    { new Guid("a5430d3b-55fb-4af8-8115-9c046b27d683"), "IT", "Italy" },
                    { new Guid("7b7daea2-9dfa-4087-9c5e-4dbfdf1111e8"), "HR", "Croatia" },
                    { new Guid("8aa7b82d-e1e0-444e-9039-6f2770b33e79"), "FR", "France" },
                    { new Guid("f3fb16a8-82c8-405f-b200-7801e66ca9c6"), "ES", "Spain" },
                    { new Guid("9d052193-94b0-4650-ba95-edb2ecf3e8db"), "EL", "Greece" },
                    { new Guid("92a96c9e-5468-4370-ae7b-034aaede9910"), "IE", "Ireland" },
                    { new Guid("78a3fb8c-f2cb-4b80-8734-486a9495d4f9"), "EE", "Estonia" },
                    { new Guid("4df57557-e9aa-4675-b635-7b41b588dd72"), "DE", "Germany" },
                    { new Guid("7b1ff062-92ca-4937-9d88-93f3c31a9a89"), "DK", "Denmark" },
                    { new Guid("9b4a4576-0789-4ede-8613-499ce0e496ba"), "CZ", "Czechia" },
                    { new Guid("ca1fe07b-9573-4912-bea2-ca06118caa8d"), "BG", "Bulgaria" },
                    { new Guid("86ed97fd-3a7a-43b9-8ff2-9bd615cd3992"), "PL", "Poland" },
                    { new Guid("5caf0d71-49c5-4bb5-821a-00776f12e951"), "PT", "Portugal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlan_UserBusinessPlanId",
                table: "BusinessPlan",
                column: "UserBusinessPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlan_UserBusinessPlans_UserBusinessPlanId",
                table: "BusinessPlan",
                column: "UserBusinessPlanId",
                principalTable: "UserBusinessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlan_UserBusinessPlans_UserBusinessPlanId",
                table: "BusinessPlan");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPlan_UserBusinessPlanId",
                table: "BusinessPlan");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3f1ae0bd-01d7-4b55-9c9c-c0c63d59ff97"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42f8ae56-377e-4f98-a7fb-825e059304fb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("47c37222-1e70-47eb-8789-010f50c1aed5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4df57557-e9aa-4675-b635-7b41b588dd72"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("54183507-d544-4a51-adf9-f5d3f0569fa8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59f14e5a-dd91-4db1-b902-b89e12a77fe0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5caf0d71-49c5-4bb5-821a-00776f12e951"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78a3fb8c-f2cb-4b80-8734-486a9495d4f9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7b1ff062-92ca-4937-9d88-93f3c31a9a89"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7b7daea2-9dfa-4087-9c5e-4dbfdf1111e8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("86ed97fd-3a7a-43b9-8ff2-9bd615cd3992"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("89c8ec1c-ff5a-4d97-a245-e8214f106644"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8aa7b82d-e1e0-444e-9039-6f2770b33e79"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9206cdc0-0fe7-4ed9-8ba9-1f8c1c15105d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("92a96c9e-5468-4370-ae7b-034aaede9910"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9b4a4576-0789-4ede-8613-499ce0e496ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9d052193-94b0-4650-ba95-edb2ecf3e8db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a5430d3b-55fb-4af8-8115-9c046b27d683"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ca1fe07b-9573-4912-bea2-ca06118caa8d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4082eb6-b027-4d9e-8d37-f88bcd7cd30f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec1bdfb2-6a45-48da-9511-bbc29463e779"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f3fb16a8-82c8-405f-b200-7801e66ca9c6"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BusinessPlan");

            migrationBuilder.DropColumn(
                name: "UserBusinessPlanId",
                table: "BusinessPlan");

            migrationBuilder.AddColumn<Guid>(
                name: "TitleId",
                table: "BusinessPlan",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "IX_BusinessPlan_TitleId",
                table: "BusinessPlan",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlan_UserBusinessPlans_TitleId",
                table: "BusinessPlan",
                column: "TitleId",
                principalTable: "UserBusinessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
