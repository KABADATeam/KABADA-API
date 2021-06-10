using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class RemovePlan_SWOT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan_SWOTs");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("012a91a2-140d-490f-85bd-baa423a6f83e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("03c942c5-1bf7-43f4-a85c-b98ef312abd9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0594222c-dfd9-40ab-b018-efbe1824e114"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("32bb7058-0e5f-44a0-9e3a-4b8aed85f80a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("33e38074-7dd9-4a8e-a243-d771f0f6fde7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("364695d6-694d-4e97-81ae-c07d881a3baf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a876a12-4516-4965-b9c4-de0586c8cefb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3e35159f-ae17-43cc-8edc-49aabc46be88"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("47d6d7b1-2731-4e18-bab8-312ec98660f8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("50eef082-a07c-4e65-9908-4f1f9d9e9dbf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("57c653c9-f2a7-4fbd-ace9-3c6f6ab63356"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("57d7d142-1fa4-4f13-a05b-8c9a127d39f7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c8a3566-c218-4e82-9c42-25df6f557f6b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d8b1eaa-ec93-4204-a695-6a02a9010eaa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5ef21ca4-ea3f-4911-a00e-436e1b0e76bc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5fdb2a71-6560-4a55-a09b-8101ff5c7419"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("61192ff9-50d5-45ea-9880-9827f7f517c1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63bd34b2-1c7d-4ba5-8100-c6a1242e71a7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7f7e445f-f7ea-4d38-b186-5e79af1f962b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7fd8e70a-1160-4528-9c20-4009edbf41fe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("867f149f-2a98-4ebf-8d0b-be14edde0727"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("929dc2d8-5d2b-4082-9284-68f5ca7ae473"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("98669425-bcb1-47e2-bfc4-c8278b2bcf1a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9beb4a41-95ed-4dc9-99a1-443bc6ac71ac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c78ce27-18e5-4c69-94c1-e361cf4d3ea4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acfa6a69-e72d-42b7-ace2-320ca82ec178"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ade0e7e3-fe9f-481e-a0d3-97b410ed5f85"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b58a736d-640d-4071-ad4d-6303e657809e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ba59391f-a329-479b-a0ff-850721c1553b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cc3aaba6-22f9-4a46-95ab-fbab4bab6a75"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cd628a80-4b13-4aa4-9a2f-bf49c3777153"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cf877b85-2019-49e7-8f38-cf53c0d1db52"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("deda09d2-10c1-4732-ac46-56eb6859636f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8efdbb8-80aa-4929-907d-b1a0c978c4bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9871d7c-0cdb-446e-b4b8-645028367cac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ecb2ba44-fc73-41de-8417-b8e5a064e3a9"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("09946175-ee3d-4685-9bd3-981d2fc39929"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("0e1a5d71-fcc3-4284-b2a3-f862c462b024"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("1cf45dc6-7fdb-49f0-9538-4157e8a553bf"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("2046c247-6ad2-4e5b-bdab-97b47dfed1aa"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("21314cff-9e72-4edd-8aee-e27fb624c758"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("22e6e3d5-c43a-475a-90a9-e85a49e4a9f8"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("30ac62d0-8895-4554-8fa0-24560407c6cc"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("42e631d5-c97d-41d3-86cd-bbdbc98858c6"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("49821c20-9b01-4536-b872-b0cac44eaf62"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("4abcd74b-5da6-408b-b024-8cc951bebedb"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("55371934-76ae-4342-bd57-3586f38770b1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("6c1dbfb4-ead4-4ab9-b33e-8c24ad5d9c54"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("6e8056bb-ce8f-4cf6-8b10-ba9731017708"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("8aa2f16b-0901-4bd9-b7f8-a985e69b9f0f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("927025a1-d9bd-46f7-a9e0-46a72e3ab03b"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a17d6b33-cf13-4c33-8c62-4857fb78d14d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a2bdcb8e-4d0d-4529-9eed-5157aacbaab1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a5f21ef9-5cdc-4140-80c2-6d0afcc785c9"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("bb14cbcb-4541-452f-b90e-8f2b80ca0264"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("bfa3fc95-c6d9-46f2-9dbb-c204ee46c323"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("c6268942-76c0-4b98-8191-a10a4b7f7358"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("cd5a30b1-889b-4516-bc72-278c0cd6d6c6"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("d0a32a06-8781-49be-8510-ca43b8eab93c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("df8ac6bf-c951-4805-847f-743afbcff8b3"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("e9866a4f-2040-493d-880f-2cb15dbd7092"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("ecb3571f-be75-4cad-b186-dace77165576"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("f0a9cedc-d2db-444b-8ac8-38d12c7ed50d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("f55e9ca7-133b-4e69-bdd0-55f89e22ae97"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("ffa33650-899f-445e-8086-6204bf1b564c"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("7132a836-82da-41cf-83d5-55786ec40bcf"), "AT", "Austria" },
                    { new Guid("16f71a14-2504-48f0-b61b-92f67bbbf824"), "LU", "Luxembourg" },
                    { new Guid("ec253754-d5e6-454e-a62c-d5a072e5ed3b"), "MT", "Malta" },
                    { new Guid("6af8f9cf-cef9-4879-a9e7-f8feac0a3e2b"), "NL", "Netherlands" },
                    { new Guid("ddb9e2fb-2ddb-4746-92ba-9435c4165786"), "MK", "North Macedonia" },
                    { new Guid("b9447354-7c08-4372-afd6-baec707b372d"), "NO", "Norway" },
                    { new Guid("0c0cbed6-32a4-4f67-b28e-23784a0f8c22"), "PL", "Poland" },
                    { new Guid("59a4c0bc-091b-4986-afff-048aa0fbaeec"), "PT", "Portugal" },
                    { new Guid("e893d866-998f-4bcd-8301-d3862bc6098f"), "RO", "Romania" },
                    { new Guid("663675ba-53c6-4f62-9e17-d54cd7fcfade"), "RS", "Serbia" },
                    { new Guid("3518711a-8787-4e47-9e17-7d10277af68f"), "SK", "Slovakia" },
                    { new Guid("aa5ea2c4-8852-48c8-972b-3834bc7f16ce"), "SI", "Slovenia" },
                    { new Guid("22e99421-3223-4442-a73d-fe8cbd7ae977"), "ES", "Spain" },
                    { new Guid("223a9acc-3101-4c47-ab0e-77a94d98b85f"), "CH", "Switzerland" },
                    { new Guid("45058a36-d5e9-4777-81b8-f5ced1ddfa87"), "TR", "Turkey" },
                    { new Guid("170f503e-ee1b-412a-8900-20d2ab2af3ac"), "UK", "United Kingdom" },
                    { new Guid("202ec202-c4ff-4bc7-b3b2-0ca85d2bbb2b"), "LT", "Lithuania" },
                    { new Guid("8f9c0610-1dfd-4fab-a660-b1b60081659a"), "LI", "Liechtenstein" },
                    { new Guid("fece1725-f0b8-4973-92cf-a006d753aae3"), "SE", "Sweden" },
                    { new Guid("0e73b881-ab36-4520-ae27-a904656b8420"), "IT", "Italy" },
                    { new Guid("ab9a6fd7-4b7a-44c6-a972-29fe1f298eaf"), "LV", "Latvia" },
                    { new Guid("85126313-305e-44f1-9ec9-d713742f857c"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("ac23b20d-6e1e-49a1-b2d6-5c8a5a663ea3"), "BE", "Belgium" },
                    { new Guid("5228e6dd-2761-429f-9c10-929d940c0880"), "HR", "Croatia" },
                    { new Guid("8be2e91d-bf6a-42e3-868c-58f8ea9164a5"), "CY", "Cyprus" },
                    { new Guid("89630086-c599-42cf-9ef4-ac1aeae1a480"), "CZ", "Czechia" },
                    { new Guid("78214696-3927-4597-9f39-2cb9ddbf5758"), "DK", "Denmark" },
                    { new Guid("8fb768c3-c511-44af-8dee-c93d14237516"), "BG", "Bulgaria" },
                    { new Guid("4d976243-bdd7-4bda-b537-85335c970ab0"), "FI", "Finland" },
                    { new Guid("61f16112-1ae1-47ea-aa45-93414d9f73f3"), "FR", "France" },
                    { new Guid("1edc7ea3-1b77-43de-85f2-d96c63658145"), "DE", "Germany" },
                    { new Guid("08454657-8bc3-49cf-8465-7f1e53df8f96"), "EL", "Greece" },
                    { new Guid("60396446-3a8f-4b64-9fbf-24fbfd92a19f"), "HU", "Hungary" },
                    { new Guid("69cd61cb-4073-4892-a810-f072d330b778"), "IS", "Iceland" },
                    { new Guid("63b1e8fc-d1ab-4e1f-8ad4-36e0662dc683"), "EE", "Estonia" },
                    { new Guid("0fbee029-d1df-4b26-aa21-c104aea9b426"), "IE", "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "Value" },
                values: new object[,]
                {
                    { new Guid("641df355-53d0-4e89-baa9-1c82c84ee1aa"), (short)1, "a", null, "Guarantees and warranties" },
                    { new Guid("cc2ecbc2-99d7-415a-b2be-011e46636144"), (short)1, "a", null, "Return of goods" },
                    { new Guid("1205d8ae-14d5-4d70-806d-13c85632f6bb"), (short)1, "a", null, "Price" },
                    { new Guid("873fd20e-9a9f-4a16-a130-2c83de5bd256"), (short)1, "a", null, "Discounts" },
                    { new Guid("d027391d-4d5c-41e7-9edd-eed6e136910d"), (short)1, "a", null, "Payment terms" },
                    { new Guid("a4f78afd-5116-48d4-a202-7e7f5d2114e9"), (short)3, "a", null, "Arrival of new technology" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "Value" },
                values: new object[,]
                {
                    { new Guid("24e85fad-562d-4e50-bc06-7fae24f1d977"), (short)1, "a", null, "Advertising, PR and sales promotion" },
                    { new Guid("bccc433f-e3bb-4c2e-963e-e6a5982b1554"), (short)3, "a", null, "New regulations" },
                    { new Guid("42c0fa95-677b-4526-98de-94dca1a6504f"), (short)3, "a", null, "Unfulfilled customer need" },
                    { new Guid("45296413-b1e6-47a2-a2bb-8b1271b41a1c"), (short)1, "a", null, "Complementary and after-sales service" },
                    { new Guid("3d9d33fe-2c10-4bc5-8dc5-dcae99e3979f"), (short)3, "a", null, "Taking business courses (training)" },
                    { new Guid("4a1710e9-2d54-4c94-aea6-61039ca8ad45"), (short)1, "a", null, "Customer convenient access to products" },
                    { new Guid("f294bc47-4bf2-417b-81aa-3dc6ab29fb14"), (short)1, "a", null, "Packaging and labeling" },
                    { new Guid("2bac2601-4e37-4206-a404-2e32ca08ba0a"), (short)1, "a", null, "Corporate image" },
                    { new Guid("54b6e699-af73-44d6-ae43-0859c2ed9206"), (short)1, "a", null, "Product design" },
                    { new Guid("cccb90b3-8812-4198-9b56-fe7e0b9eb981"), (short)1, "a", null, "Supporting processes" },
                    { new Guid("436d5d5b-de7d-4194-92c2-cfaa1eff06d4"), (short)1, "a", null, "Management processes" },
                    { new Guid("b602b90a-6f04-4691-89f1-531ab2ecc273"), (short)1, "a", null, "Operational processes" },
                    { new Guid("fc1dc8e1-66c8-48e3-a756-6c9da8a7e899"), (short)1, "a", null, "Copyrights" },
                    { new Guid("5eab0230-d4f1-449a-9e62-17e4255b29fe"), (short)1, "a", null, "Trademarks" },
                    { new Guid("3de70d58-429d-48aa-8a0e-2a969fa12073"), (short)1, "a", null, "Patents" },
                    { new Guid("f7eddaa6-d248-470f-9214-a0290ce0ed21"), (short)1, "a", null, "Skills and experience of employees" },
                    { new Guid("415e5989-8913-44b2-8926-2b8caae034e2"), (short)1, "a", null, "Inventory" },
                    { new Guid("b9ed86a8-116c-470d-87ef-4779d21e27f1"), (short)1, "a", null, "Vehicles" },
                    { new Guid("b8d1b11c-369c-41de-9152-21487f1e7885"), (short)1, "a", null, "Facilities and equipment" },
                    { new Guid("c123ae32-8e22-429b-9518-91d74c522b74"), (short)1, "a", null, "Land" },
                    { new Guid("64938d2e-1e76-4f1d-84da-705288a2da14"), (short)3, "a", null, "Trend changes" },
                    { new Guid("a2ef4f58-8d87-4ddf-9a30-cebe6337349c"), (short)1, "a", null, "Product assortment" },
                    { new Guid("d0910018-dd99-43aa-9e30-be9eb5386533"), (short)3, "a", null, "New substitute products" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("08454657-8bc3-49cf-8465-7f1e53df8f96"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0c0cbed6-32a4-4f67-b28e-23784a0f8c22"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e73b881-ab36-4520-ae27-a904656b8420"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0fbee029-d1df-4b26-aa21-c104aea9b426"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("16f71a14-2504-48f0-b61b-92f67bbbf824"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("170f503e-ee1b-412a-8900-20d2ab2af3ac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1edc7ea3-1b77-43de-85f2-d96c63658145"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("202ec202-c4ff-4bc7-b3b2-0ca85d2bbb2b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("223a9acc-3101-4c47-ab0e-77a94d98b85f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("22e99421-3223-4442-a73d-fe8cbd7ae977"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3518711a-8787-4e47-9e17-7d10277af68f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("45058a36-d5e9-4777-81b8-f5ced1ddfa87"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d976243-bdd7-4bda-b537-85335c970ab0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5228e6dd-2761-429f-9c10-929d940c0880"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59a4c0bc-091b-4986-afff-048aa0fbaeec"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60396446-3a8f-4b64-9fbf-24fbfd92a19f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("61f16112-1ae1-47ea-aa45-93414d9f73f3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63b1e8fc-d1ab-4e1f-8ad4-36e0662dc683"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("663675ba-53c6-4f62-9e17-d54cd7fcfade"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69cd61cb-4073-4892-a810-f072d330b778"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6af8f9cf-cef9-4879-a9e7-f8feac0a3e2b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7132a836-82da-41cf-83d5-55786ec40bcf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78214696-3927-4597-9f39-2cb9ddbf5758"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("85126313-305e-44f1-9ec9-d713742f857c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("89630086-c599-42cf-9ef4-ac1aeae1a480"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8be2e91d-bf6a-42e3-868c-58f8ea9164a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8f9c0610-1dfd-4fab-a660-b1b60081659a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8fb768c3-c511-44af-8dee-c93d14237516"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aa5ea2c4-8852-48c8-972b-3834bc7f16ce"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab9a6fd7-4b7a-44c6-a972-29fe1f298eaf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac23b20d-6e1e-49a1-b2d6-5c8a5a663ea3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b9447354-7c08-4372-afd6-baec707b372d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ddb9e2fb-2ddb-4746-92ba-9435c4165786"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e893d866-998f-4bcd-8301-d3862bc6098f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec253754-d5e6-454e-a62c-d5a072e5ed3b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fece1725-f0b8-4973-92cf-a006d753aae3"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("1205d8ae-14d5-4d70-806d-13c85632f6bb"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("24e85fad-562d-4e50-bc06-7fae24f1d977"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("2bac2601-4e37-4206-a404-2e32ca08ba0a"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("3d9d33fe-2c10-4bc5-8dc5-dcae99e3979f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("3de70d58-429d-48aa-8a0e-2a969fa12073"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("415e5989-8913-44b2-8926-2b8caae034e2"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("42c0fa95-677b-4526-98de-94dca1a6504f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("436d5d5b-de7d-4194-92c2-cfaa1eff06d4"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("45296413-b1e6-47a2-a2bb-8b1271b41a1c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("4a1710e9-2d54-4c94-aea6-61039ca8ad45"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("54b6e699-af73-44d6-ae43-0859c2ed9206"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("5eab0230-d4f1-449a-9e62-17e4255b29fe"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("641df355-53d0-4e89-baa9-1c82c84ee1aa"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("64938d2e-1e76-4f1d-84da-705288a2da14"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("873fd20e-9a9f-4a16-a130-2c83de5bd256"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a2ef4f58-8d87-4ddf-9a30-cebe6337349c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a4f78afd-5116-48d4-a202-7e7f5d2114e9"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("b602b90a-6f04-4691-89f1-531ab2ecc273"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("b8d1b11c-369c-41de-9152-21487f1e7885"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("b9ed86a8-116c-470d-87ef-4779d21e27f1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("bccc433f-e3bb-4c2e-963e-e6a5982b1554"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("c123ae32-8e22-429b-9518-91d74c522b74"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("cc2ecbc2-99d7-415a-b2be-011e46636144"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("cccb90b3-8812-4198-9b56-fe7e0b9eb981"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("d027391d-4d5c-41e7-9edd-eed6e136910d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("d0910018-dd99-43aa-9e30-be9eb5386533"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("f294bc47-4bf2-417b-81aa-3dc6ab29fb14"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("f7eddaa6-d248-470f-9214-a0290ce0ed21"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("fc1dc8e1-66c8-48e3-a756-6c9da8a7e899"));

            migrationBuilder.CreateTable(
                name: "Plan_SWOTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    TexterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_SWOTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_SWOTs_BusinessPlans_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plan_SWOTs_Texters_TexterId",
                        column: x => x.TexterId,
                        principalTable: "Texters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("867f149f-2a98-4ebf-8d0b-be14edde0727"), "AT", "Austria" },
                    { new Guid("57d7d142-1fa4-4f13-a05b-8c9a127d39f7"), "LU", "Luxembourg" },
                    { new Guid("cd628a80-4b13-4aa4-9a2f-bf49c3777153"), "MT", "Malta" },
                    { new Guid("e8efdbb8-80aa-4929-907d-b1a0c978c4bb"), "NL", "Netherlands" },
                    { new Guid("5c8a3566-c218-4e82-9c42-25df6f557f6b"), "MK", "North Macedonia" },
                    { new Guid("63bd34b2-1c7d-4ba5-8100-c6a1242e71a7"), "NO", "Norway" },
                    { new Guid("364695d6-694d-4e97-81ae-c07d881a3baf"), "PL", "Poland" },
                    { new Guid("9c78ce27-18e5-4c69-94c1-e361cf4d3ea4"), "PT", "Portugal" },
                    { new Guid("5ef21ca4-ea3f-4911-a00e-436e1b0e76bc"), "RO", "Romania" },
                    { new Guid("ade0e7e3-fe9f-481e-a0d3-97b410ed5f85"), "RS", "Serbia" },
                    { new Guid("32bb7058-0e5f-44a0-9e3a-4b8aed85f80a"), "SK", "Slovakia" },
                    { new Guid("5fdb2a71-6560-4a55-a09b-8101ff5c7419"), "SI", "Slovenia" },
                    { new Guid("012a91a2-140d-490f-85bd-baa423a6f83e"), "ES", "Spain" },
                    { new Guid("98669425-bcb1-47e2-bfc4-c8278b2bcf1a"), "CH", "Switzerland" },
                    { new Guid("57c653c9-f2a7-4fbd-ace9-3c6f6ab63356"), "TR", "Turkey" },
                    { new Guid("acfa6a69-e72d-42b7-ace2-320ca82ec178"), "UK", "United Kingdom" },
                    { new Guid("33e38074-7dd9-4a8e-a243-d771f0f6fde7"), "LT", "Lithuania" },
                    { new Guid("b58a736d-640d-4071-ad4d-6303e657809e"), "LI", "Liechtenstein" },
                    { new Guid("ba59391f-a329-479b-a0ff-850721c1553b"), "SE", "Sweden" },
                    { new Guid("50eef082-a07c-4e65-9908-4f1f9d9e9dbf"), "IT", "Italy" },
                    { new Guid("61192ff9-50d5-45ea-9880-9827f7f517c1"), "LV", "Latvia" },
                    { new Guid("0594222c-dfd9-40ab-b018-efbe1824e114"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("ecb2ba44-fc73-41de-8417-b8e5a064e3a9"), "BE", "Belgium" },
                    { new Guid("cf877b85-2019-49e7-8f38-cf53c0d1db52"), "HR", "Croatia" },
                    { new Guid("9beb4a41-95ed-4dc9-99a1-443bc6ac71ac"), "CY", "Cyprus" },
                    { new Guid("929dc2d8-5d2b-4082-9284-68f5ca7ae473"), "CZ", "Czechia" },
                    { new Guid("e9871d7c-0cdb-446e-b4b8-645028367cac"), "DK", "Denmark" },
                    { new Guid("7fd8e70a-1160-4528-9c20-4009edbf41fe"), "BG", "Bulgaria" },
                    { new Guid("47d6d7b1-2731-4e18-bab8-312ec98660f8"), "FI", "Finland" },
                    { new Guid("3a876a12-4516-4965-b9c4-de0586c8cefb"), "FR", "France" },
                    { new Guid("03c942c5-1bf7-43f4-a85c-b98ef312abd9"), "DE", "Germany" },
                    { new Guid("deda09d2-10c1-4732-ac46-56eb6859636f"), "EL", "Greece" },
                    { new Guid("cc3aaba6-22f9-4a46-95ab-fbab4bab6a75"), "HU", "Hungary" },
                    { new Guid("5d8b1eaa-ec93-4204-a695-6a02a9010eaa"), "IS", "Iceland" },
                    { new Guid("7f7e445f-f7ea-4d38-b186-5e79af1f962b"), "EE", "Estonia" },
                    { new Guid("3e35159f-ae17-43cc-8edc-49aabc46be88"), "IE", "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "Value" },
                values: new object[,]
                {
                    { new Guid("f55e9ca7-133b-4e69-bdd0-55f89e22ae97"), (short)1, "a", null, "Guarantees and warranties" },
                    { new Guid("cd5a30b1-889b-4516-bc72-278c0cd6d6c6"), (short)1, "a", null, "Return of goods" },
                    { new Guid("f0a9cedc-d2db-444b-8ac8-38d12c7ed50d"), (short)1, "a", null, "Price" },
                    { new Guid("927025a1-d9bd-46f7-a9e0-46a72e3ab03b"), (short)1, "a", null, "Discounts" },
                    { new Guid("bb14cbcb-4541-452f-b90e-8f2b80ca0264"), (short)1, "a", null, "Payment terms" },
                    { new Guid("c6268942-76c0-4b98-8191-a10a4b7f7358"), (short)3, "a", null, "Arrival of new technology" }
                });

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "Value" },
                values: new object[,]
                {
                    { new Guid("ecb3571f-be75-4cad-b186-dace77165576"), (short)1, "a", null, "Advertising, PR and sales promotion" },
                    { new Guid("21314cff-9e72-4edd-8aee-e27fb624c758"), (short)3, "a", null, "New regulations" },
                    { new Guid("1cf45dc6-7fdb-49f0-9538-4157e8a553bf"), (short)3, "a", null, "Unfulfilled customer need" },
                    { new Guid("8aa2f16b-0901-4bd9-b7f8-a985e69b9f0f"), (short)1, "a", null, "Complementary and after-sales service" },
                    { new Guid("a17d6b33-cf13-4c33-8c62-4857fb78d14d"), (short)3, "a", null, "Taking business courses (training)" },
                    { new Guid("30ac62d0-8895-4554-8fa0-24560407c6cc"), (short)1, "a", null, "Customer convenient access to products" },
                    { new Guid("a2bdcb8e-4d0d-4529-9eed-5157aacbaab1"), (short)1, "a", null, "Packaging and labeling" },
                    { new Guid("09946175-ee3d-4685-9bd3-981d2fc39929"), (short)1, "a", null, "Corporate image" },
                    { new Guid("6c1dbfb4-ead4-4ab9-b33e-8c24ad5d9c54"), (short)1, "a", null, "Product design" },
                    { new Guid("4abcd74b-5da6-408b-b024-8cc951bebedb"), (short)1, "a", null, "Supporting processes" },
                    { new Guid("2046c247-6ad2-4e5b-bdab-97b47dfed1aa"), (short)1, "a", null, "Management processes" },
                    { new Guid("6e8056bb-ce8f-4cf6-8b10-ba9731017708"), (short)1, "a", null, "Operational processes" },
                    { new Guid("e9866a4f-2040-493d-880f-2cb15dbd7092"), (short)1, "a", null, "Copyrights" },
                    { new Guid("0e1a5d71-fcc3-4284-b2a3-f862c462b024"), (short)1, "a", null, "Trademarks" },
                    { new Guid("a5f21ef9-5cdc-4140-80c2-6d0afcc785c9"), (short)1, "a", null, "Patents" },
                    { new Guid("49821c20-9b01-4536-b872-b0cac44eaf62"), (short)1, "a", null, "Skills and experience of employees" },
                    { new Guid("42e631d5-c97d-41d3-86cd-bbdbc98858c6"), (short)1, "a", null, "Inventory" },
                    { new Guid("d0a32a06-8781-49be-8510-ca43b8eab93c"), (short)1, "a", null, "Vehicles" },
                    { new Guid("df8ac6bf-c951-4805-847f-743afbcff8b3"), (short)1, "a", null, "Facilities and equipment" },
                    { new Guid("22e6e3d5-c43a-475a-90a9-e85a49e4a9f8"), (short)1, "a", null, "Land" },
                    { new Guid("55371934-76ae-4342-bd57-3586f38770b1"), (short)3, "a", null, "Trend changes" },
                    { new Guid("bfa3fc95-c6d9-46f2-9dbb-c204ee46c323"), (short)1, "a", null, "Product assortment" },
                    { new Guid("ffa33650-899f-445e-8086-6204bf1b564c"), (short)3, "a", null, "New substitute products" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_SWOTs_BusinessPlanId",
                table: "Plan_SWOTs",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_SWOTs_TexterId",
                table: "Plan_SWOTs",
                column: "TexterId");
        }
    }
}
