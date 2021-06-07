using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class AlterPlanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("057a00ca-8fe6-4b77-a636-e09fb7f77579"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0f1b232b-4376-4a02-8fe3-808b93620590"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("182f9634-30b4-4a93-925b-7c6919d92fa8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ab8e95d-7b05-45cb-a4a4-d7740b0eee2d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1b02ce43-60df-404e-8134-6485f167b8a9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ff5d156-8026-40a6-8140-7df3802cc18b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("23b99526-eb89-4903-80f4-e56883f7e589"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("27b8d6dd-88e1-4303-8f5f-64d4e10be9c6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("30598965-b650-4f3e-8ba7-eec35f9ef2ca"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("41c37136-fcd2-4c8d-95ec-b4cda99c0a31"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("463e1fa2-b448-4447-804d-3294b11d39a6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4728302d-71be-4f9c-9560-7c21b5b6a43d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("47cfac7a-8c0f-4078-a94e-743b6c31fa33"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d01763a-40e4-495c-890b-a6a7d97adbcc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("54ac6e7a-0cf4-44c6-9628-f0423f4c8558"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c6e26db-30f1-421a-9ef0-07121fb9db46"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6791cccb-2153-405a-82b9-c657ee07df10"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("68aab8f6-6937-48d3-bd0e-ebe4545e0e19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a9958be-d5f0-4a7e-b715-f442a1e0302a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("85e91c8f-7604-48e7-9d55-a814adc461c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9218324b-2393-4824-9510-458c37f866cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9229334f-005f-4c99-ae43-41b61498742f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aa00367d-2bc7-4216-880f-07c4d09d579a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ad313d10-3ceb-4c48-ab6d-2cc7aedc5a13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ae9e778e-887a-41d6-8463-43a7e6b9c3d2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bff695ea-d8bc-4b50-9ccb-4eab1a265979"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c4a59021-4eb8-4443-bbd7-5e6d06ae6e83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c4cc31de-04a5-4da5-99dc-abb8c3631624"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cfe41dca-4d4a-4575-bc19-3dd8cb67b1fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d0b3ca0a-441d-496c-ba3b-22e365f4dde3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d3c7d9f9-0d1b-45c1-86fe-6b2adf0337ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("df1d8335-2163-48ad-9a92-34995f348db0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e5614cb5-95cf-4626-898b-af0909acb96d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0d6491f-0fbb-4e78-ada2-e8ded5729843"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f3c2a880-8281-4e98-ae91-a4469c5e69a9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f49762e9-72c3-4c35-a6a9-7f9f88f65c80"));

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "SharedPlans",
                newName: "BusinessPlanId");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("c096f401-de5e-4e9c-8a8d-8deac0e147ea"), "AT", "Austria" },
                    { new Guid("1e5902d8-e310-4e90-8b9b-03c561db0124"), "LU", "Luxembourg" },
                    { new Guid("05bba7c6-742d-4f1d-8ed4-c2cc2c156eaf"), "MT", "Malta" },
                    { new Guid("dd99a756-0632-480d-937e-eb5d39e16423"), "NL", "Netherlands" },
                    { new Guid("f17a8b5e-3063-4070-a12c-b929c79cd721"), "MK", "North Macedonia" },
                    { new Guid("62524e7f-12fc-409b-ac26-c3c4fd887177"), "NO", "Norway" },
                    { new Guid("a305e39f-5a3a-4fda-81cb-82a4ac48aca8"), "PL", "Poland" },
                    { new Guid("5c3340c2-7a58-4c1d-855b-9f87649626e6"), "LT", "Lithuania" },
                    { new Guid("b9bb510a-c96f-40d4-8f14-d6c3bcfac947"), "PT", "Portugal" },
                    { new Guid("8356c33c-8904-4991-bf74-5e7c6128946c"), "RS", "Serbia" },
                    { new Guid("14d87cb9-01e8-412e-8ebb-283d956633ce"), "SK", "Slovakia" },
                    { new Guid("37ac6e38-8c8e-46ee-b018-c7d442afb451"), "SI", "Slovenia" },
                    { new Guid("e469fc99-01cb-417e-b2c2-ed62ab880263"), "ES", "Spain" },
                    { new Guid("b7a2a4bf-b038-42ad-9ab9-28360701a471"), "SE", "Sweden" },
                    { new Guid("1260aa58-e2f7-456d-b101-07f13363bf77"), "CH", "Switzerland" },
                    { new Guid("a7af6f04-5f33-42e6-940f-dab8d5a87d8a"), "RO", "Romania" },
                    { new Guid("385d9a3b-a5b6-4c24-aeaf-f5fd30dba44d"), "LI", "Liechtenstein" },
                    { new Guid("6281bf95-7315-41f5-ac4e-fb1537963668"), "LV", "Latvia" },
                    { new Guid("1f70afd3-bff3-4066-b4cb-3ca9bb750f58"), "IT", "Italy" },
                    { new Guid("7498d010-db21-4762-9283-facdadac74f8"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("dd740d99-f863-4014-8b4d-232473ce56d4"), "BE", "Belgium" },
                    { new Guid("8e0c8d9e-1ced-4e58-95a4-c64c86c6267a"), "BG", "Bulgaria" },
                    { new Guid("944fd834-b723-4dec-9fe6-9394d54da53c"), "HR", "Croatia" },
                    { new Guid("ed1d2957-e95a-4c57-a2c3-8f9ca771bb7c"), "CY", "Cyprus" },
                    { new Guid("befc51b7-2c89-4db4-a80c-c60113df6ad4"), "CZ", "Czechia" },
                    { new Guid("14e981be-bac8-46bc-82e5-32ead6cb58f1"), "DK", "Denmark" },
                    { new Guid("23fd694c-8c5d-49ac-a32c-1cf1946661fb"), "EE", "Estonia" },
                    { new Guid("791fd1be-fc27-44e1-9c56-b2fba273d86c"), "FI", "Finland" },
                    { new Guid("13e2582d-5095-426d-91ba-b01fefb82d9b"), "FR", "France" },
                    { new Guid("6780de5e-48e5-412f-92c1-9ee5ffc2179f"), "DE", "Germany" },
                    { new Guid("51a92ecc-c481-407b-81e6-feb7067cdf96"), "EL", "Greece" },
                    { new Guid("da2485b5-5201-49a1-9e2e-20f6a8f67771"), "HU", "Hungary" },
                    { new Guid("82d56c8a-8169-4bcf-b0ae-6e678bfd54fe"), "IS", "Iceland" },
                    { new Guid("892a8ad4-1a91-4f38-908c-a182ecba5722"), "IE", "Ireland" },
                    { new Guid("1fd6107c-0861-4da6-b532-84af2ab6b461"), "TR", "Turkey" },
                    { new Guid("51bacae2-3bac-4771-a9c2-d552668fb2df"), "UK", "United Kingdom" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SharedPlans_BusinessPlanId",
                table: "SharedPlans",
                column: "BusinessPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_SharedPlans_BusinessPlans_BusinessPlanId",
                table: "SharedPlans",
                column: "BusinessPlanId",
                principalTable: "BusinessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharedPlans_BusinessPlans_BusinessPlanId",
                table: "SharedPlans");

            migrationBuilder.DropIndex(
                name: "IX_SharedPlans_BusinessPlanId",
                table: "SharedPlans");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("05bba7c6-742d-4f1d-8ed4-c2cc2c156eaf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1260aa58-e2f7-456d-b101-07f13363bf77"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("13e2582d-5095-426d-91ba-b01fefb82d9b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("14d87cb9-01e8-412e-8ebb-283d956633ce"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("14e981be-bac8-46bc-82e5-32ead6cb58f1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1e5902d8-e310-4e90-8b9b-03c561db0124"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1f70afd3-bff3-4066-b4cb-3ca9bb750f58"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1fd6107c-0861-4da6-b532-84af2ab6b461"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("23fd694c-8c5d-49ac-a32c-1cf1946661fb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("37ac6e38-8c8e-46ee-b018-c7d442afb451"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("385d9a3b-a5b6-4c24-aeaf-f5fd30dba44d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51a92ecc-c481-407b-81e6-feb7067cdf96"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51bacae2-3bac-4771-a9c2-d552668fb2df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c3340c2-7a58-4c1d-855b-9f87649626e6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("62524e7f-12fc-409b-ac26-c3c4fd887177"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6281bf95-7315-41f5-ac4e-fb1537963668"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6780de5e-48e5-412f-92c1-9ee5ffc2179f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7498d010-db21-4762-9283-facdadac74f8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("791fd1be-fc27-44e1-9c56-b2fba273d86c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("82d56c8a-8169-4bcf-b0ae-6e678bfd54fe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8356c33c-8904-4991-bf74-5e7c6128946c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("892a8ad4-1a91-4f38-908c-a182ecba5722"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8e0c8d9e-1ced-4e58-95a4-c64c86c6267a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("944fd834-b723-4dec-9fe6-9394d54da53c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a305e39f-5a3a-4fda-81cb-82a4ac48aca8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a7af6f04-5f33-42e6-940f-dab8d5a87d8a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b7a2a4bf-b038-42ad-9ab9-28360701a471"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b9bb510a-c96f-40d4-8f14-d6c3bcfac947"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("befc51b7-2c89-4db4-a80c-c60113df6ad4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c096f401-de5e-4e9c-8a8d-8deac0e147ea"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("da2485b5-5201-49a1-9e2e-20f6a8f67771"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dd740d99-f863-4014-8b4d-232473ce56d4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dd99a756-0632-480d-937e-eb5d39e16423"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e469fc99-01cb-417e-b2c2-ed62ab880263"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed1d2957-e95a-4c57-a2c3-8f9ca771bb7c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f17a8b5e-3063-4070-a12c-b929c79cd721"));

            migrationBuilder.RenameColumn(
                name: "BusinessPlanId",
                table: "SharedPlans",
                newName: "PlanId");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("d3c7d9f9-0d1b-45c1-86fe-6b2adf0337ea"), "AT", "Austria" },
                    { new Guid("cfe41dca-4d4a-4575-bc19-3dd8cb67b1fd"), "LU", "Luxembourg" },
                    { new Guid("1b02ce43-60df-404e-8134-6485f167b8a9"), "MT", "Malta" },
                    { new Guid("5c6e26db-30f1-421a-9ef0-07121fb9db46"), "NL", "Netherlands" },
                    { new Guid("68aab8f6-6937-48d3-bd0e-ebe4545e0e19"), "MK", "North Macedonia" },
                    { new Guid("0f1b232b-4376-4a02-8fe3-808b93620590"), "NO", "Norway" },
                    { new Guid("463e1fa2-b448-4447-804d-3294b11d39a6"), "PL", "Poland" },
                    { new Guid("d0b3ca0a-441d-496c-ba3b-22e365f4dde3"), "LT", "Lithuania" },
                    { new Guid("aa00367d-2bc7-4216-880f-07c4d09d579a"), "PT", "Portugal" },
                    { new Guid("9229334f-005f-4c99-ae43-41b61498742f"), "RS", "Serbia" },
                    { new Guid("f3c2a880-8281-4e98-ae91-a4469c5e69a9"), "SK", "Slovakia" },
                    { new Guid("47cfac7a-8c0f-4078-a94e-743b6c31fa33"), "SI", "Slovenia" },
                    { new Guid("23b99526-eb89-4903-80f4-e56883f7e589"), "ES", "Spain" },
                    { new Guid("f0d6491f-0fbb-4e78-ada2-e8ded5729843"), "SE", "Sweden" },
                    { new Guid("30598965-b650-4f3e-8ba7-eec35f9ef2ca"), "CH", "Switzerland" },
                    { new Guid("54ac6e7a-0cf4-44c6-9628-f0423f4c8558"), "RO", "Romania" },
                    { new Guid("ad313d10-3ceb-4c48-ab6d-2cc7aedc5a13"), "LI", "Liechtenstein" },
                    { new Guid("1ab8e95d-7b05-45cb-a4a4-d7740b0eee2d"), "LV", "Latvia" },
                    { new Guid("9218324b-2393-4824-9510-458c37f866cd"), "IT", "Italy" },
                    { new Guid("bff695ea-d8bc-4b50-9ccb-4eab1a265979"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("ae9e778e-887a-41d6-8463-43a7e6b9c3d2"), "BE", "Belgium" },
                    { new Guid("1ff5d156-8026-40a6-8140-7df3802cc18b"), "BG", "Bulgaria" },
                    { new Guid("e5614cb5-95cf-4626-898b-af0909acb96d"), "HR", "Croatia" },
                    { new Guid("4728302d-71be-4f9c-9560-7c21b5b6a43d"), "CY", "Cyprus" },
                    { new Guid("df1d8335-2163-48ad-9a92-34995f348db0"), "CZ", "Czechia" },
                    { new Guid("f49762e9-72c3-4c35-a6a9-7f9f88f65c80"), "DK", "Denmark" },
                    { new Guid("27b8d6dd-88e1-4303-8f5f-64d4e10be9c6"), "EE", "Estonia" },
                    { new Guid("182f9634-30b4-4a93-925b-7c6919d92fa8"), "FI", "Finland" },
                    { new Guid("6791cccb-2153-405a-82b9-c657ee07df10"), "FR", "France" },
                    { new Guid("c4a59021-4eb8-4443-bbd7-5e6d06ae6e83"), "DE", "Germany" },
                    { new Guid("057a00ca-8fe6-4b77-a636-e09fb7f77579"), "EL", "Greece" },
                    { new Guid("c4cc31de-04a5-4da5-99dc-abb8c3631624"), "HU", "Hungary" },
                    { new Guid("85e91c8f-7604-48e7-9d55-a814adc461c5"), "IS", "Iceland" },
                    { new Guid("41c37136-fcd2-4c8d-95ec-b4cda99c0a31"), "IE", "Ireland" },
                    { new Guid("4d01763a-40e4-495c-890b-a6a7d97adbcc"), "TR", "Turkey" },
                    { new Guid("6a9958be-d5f0-4a7e-b715-f442a1e0302a"), "UK", "United Kingdom" }
                });
        }
    }
}
