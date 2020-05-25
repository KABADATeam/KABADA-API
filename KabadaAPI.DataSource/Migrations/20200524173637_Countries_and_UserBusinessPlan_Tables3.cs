using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class Countries_and_UserBusinessPlan_Tables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("e8fe5612-4084-465d-905c-2cd25d1dd479"), "BE", "Belgium" },
                    { new Guid("557857b4-e501-45e7-8a31-954bd72a9273"), "AT", "Austria" },
                    { new Guid("b5437b36-ee90-47bc-8256-699ec442dfb7"), "NL", "Netherlands" },
                    { new Guid("5e69d3fb-3c8a-4cad-a6f5-7da2d73ca497"), "MT", "Malta" },
                    { new Guid("4da8c4bb-ae3f-4c80-924c-510ae574ce0f"), "HU", "Hungary" },
                    { new Guid("e4c1f7ef-4814-4ca3-b21a-e090b38d11f2"), "LU", "Luxembourg" },
                    { new Guid("6446fa56-d5f3-45a6-bc22-e17b89c66e8f"), "LT", "Lithuania" },
                    { new Guid("b196b741-7a48-41c5-9eea-00d6d9de1aa3"), "LV", "Latvia" },
                    { new Guid("5b141737-4550-4b4a-bf7b-4373bd926217"), "CY", "Cyprus" },
                    { new Guid("faded6c1-5724-4a32-b2de-18d05ca5a7bc"), "IT", "Italy" },
                    { new Guid("093ca9f8-cc72-4a04-a06d-f7a68e93d097"), "HR", "Croatia" },
                    { new Guid("fc2933ef-dd36-44e0-8c53-e53db118c3e7"), "FR", "France" },
                    { new Guid("010c8e7a-e2a1-4daf-a244-478dbda60eb3"), "ES", "Spain" },
                    { new Guid("ef0100ee-6591-4ecc-ad32-d268c371d203"), "EL", "Greece" },
                    { new Guid("26ed4352-7a63-4fd4-a55e-e3e813eb5ad4"), "IE", "Ireland" },
                    { new Guid("c1148480-2c3f-4716-9ca1-e2f8a55afc7e"), "EE", "Estonia" },
                    { new Guid("8ae7d4a9-5f37-48df-8eca-f9ae02a43e01"), "DE", "Germany" },
                    { new Guid("1f8b2a9c-3f1c-42b1-9ad5-2ef5290b69b6"), "DK", "Denmark" },
                    { new Guid("69a8432a-1cb4-41d6-9843-ca4abf52943e"), "CZ", "Czechia" },
                    { new Guid("6fa068ec-f4a8-4a66-b746-be3727d06d06"), "BG", "Bulgaria" },
                    { new Guid("d05ea0fb-886b-4995-96c3-984bcc87472f"), "PL", "Poland" },
                    { new Guid("558dc3a5-2706-4cc2-afce-bfa012a590fe"), "PT", "Portugal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("010c8e7a-e2a1-4daf-a244-478dbda60eb3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("093ca9f8-cc72-4a04-a06d-f7a68e93d097"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1f8b2a9c-3f1c-42b1-9ad5-2ef5290b69b6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("26ed4352-7a63-4fd4-a55e-e3e813eb5ad4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4da8c4bb-ae3f-4c80-924c-510ae574ce0f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("557857b4-e501-45e7-8a31-954bd72a9273"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("558dc3a5-2706-4cc2-afce-bfa012a590fe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5b141737-4550-4b4a-bf7b-4373bd926217"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5e69d3fb-3c8a-4cad-a6f5-7da2d73ca497"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6446fa56-d5f3-45a6-bc22-e17b89c66e8f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69a8432a-1cb4-41d6-9843-ca4abf52943e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6fa068ec-f4a8-4a66-b746-be3727d06d06"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8ae7d4a9-5f37-48df-8eca-f9ae02a43e01"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b196b741-7a48-41c5-9eea-00d6d9de1aa3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b5437b36-ee90-47bc-8256-699ec442dfb7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1148480-2c3f-4716-9ca1-e2f8a55afc7e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d05ea0fb-886b-4995-96c3-984bcc87472f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4c1f7ef-4814-4ca3-b21a-e090b38d11f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8fe5612-4084-465d-905c-2cd25d1dd479"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ef0100ee-6591-4ecc-ad32-d268c371d203"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("faded6c1-5724-4a32-b2de-18d05ca5a7bc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fc2933ef-dd36-44e0-8c53-e53db118c3e7"));

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
        }
    }
}
