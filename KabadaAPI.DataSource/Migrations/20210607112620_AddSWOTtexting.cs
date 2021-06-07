using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class AddSWOTtexting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Texters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    Master = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LongValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan_SWOTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TexterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Kind = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_SWOTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_SWOTs_BusinessPlans_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_SWOTs_Texters_TexterId",
                        column: x => x.TexterId,
                        principalTable: "Texters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("cc06d497-ee3d-4c9a-964e-f37c11c422d8"), "AT", "Austria" },
                    { new Guid("2e863ded-3eab-4c9f-a508-bfd0420dfac4"), "LU", "Luxembourg" },
                    { new Guid("2c9f8e5f-d1c6-49b6-a7a2-fa33b58ebbc7"), "MT", "Malta" },
                    { new Guid("9c95b36f-7783-431e-adbb-79c20b413215"), "NL", "Netherlands" },
                    { new Guid("36fc2c30-3c81-40a0-98f7-c2160ff52638"), "MK", "North Macedonia" },
                    { new Guid("a3bbfac0-f902-426a-8058-063cde504d3a"), "NO", "Norway" },
                    { new Guid("b8c7f6f1-1514-44a0-8d8c-de1e54676351"), "PL", "Poland" },
                    { new Guid("feb042e8-df72-4477-a88f-46e5d1b9aa61"), "LT", "Lithuania" },
                    { new Guid("313268fc-39d9-44c2-b152-671939a1af0e"), "PT", "Portugal" },
                    { new Guid("d7cc2ff3-8d41-4e97-8090-80d048c549b0"), "RS", "Serbia" },
                    { new Guid("528b366c-f1fe-492e-8291-b2ed16b34939"), "SK", "Slovakia" },
                    { new Guid("b7fcd747-e039-4ee6-96d8-0220cdcf43dd"), "SI", "Slovenia" },
                    { new Guid("1ded9fa0-38e7-4026-a5cb-5f41541464be"), "ES", "Spain" },
                    { new Guid("fef80347-6362-47ad-b464-195e0fe3adc0"), "SE", "Sweden" },
                    { new Guid("ac8cf5c0-31b4-4e4e-bd20-ed8da119c16b"), "CH", "Switzerland" },
                    { new Guid("44f245b2-c030-46ed-a35e-d25eb4e5c1fd"), "RO", "Romania" },
                    { new Guid("0894dbfc-6109-4d61-afb2-4d65ef99ef53"), "LI", "Liechtenstein" },
                    { new Guid("e7f67045-bbcd-4d06-b56b-01eba8e5968c"), "LV", "Latvia" },
                    { new Guid("df1b2589-cc0a-4917-867c-b25b224d55d3"), "IT", "Italy" },
                    { new Guid("8b1e1c40-183a-47c2-a7f3-91c226986974"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("c02ccc01-986d-4415-8a11-62a80339f27a"), "BE", "Belgium" },
                    { new Guid("302c39ee-c5dc-4e02-8ff0-794b037dc94d"), "BG", "Bulgaria" },
                    { new Guid("087dc5f7-4745-4cb5-bb8f-9e7cdbda4571"), "HR", "Croatia" },
                    { new Guid("5a42bb75-281d-46cb-a712-0ad4e86b8506"), "CY", "Cyprus" },
                    { new Guid("99a3b177-6c80-45ae-a154-70c0dff8e257"), "CZ", "Czechia" },
                    { new Guid("5f20c99a-9f2c-48a9-9dae-1fa9d9220805"), "DK", "Denmark" },
                    { new Guid("20b81ab4-5eaf-47af-a28d-51639baabc07"), "EE", "Estonia" },
                    { new Guid("eebf54af-f6bd-4a62-a939-b68466a2d702"), "FI", "Finland" },
                    { new Guid("f094e529-040e-40e2-9d3b-78bb87e64d08"), "FR", "France" },
                    { new Guid("abfe2a6a-9d5c-4486-999c-2fb7e38e5cc8"), "DE", "Germany" },
                    { new Guid("34037c06-29fd-4d0c-a9c7-5525b3f53fb8"), "EL", "Greece" },
                    { new Guid("312468ff-2a2e-4eb7-a362-c94376c03319"), "HU", "Hungary" },
                    { new Guid("2b64eadb-7e5d-4b04-8132-5db64f750508"), "IS", "Iceland" },
                    { new Guid("52e9e003-05e6-41d5-abfa-d1f3bcf52b17"), "IE", "Ireland" },
                    { new Guid("ab3a5016-86d1-4434-937b-fcee627c5aef"), "TR", "Turkey" },
                    { new Guid("4168798a-4dc1-4b53-821b-5dccf202c588"), "UK", "United Kingdom" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan_SWOTs");

            migrationBuilder.DropTable(
                name: "Texters");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("087dc5f7-4745-4cb5-bb8f-9e7cdbda4571"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0894dbfc-6109-4d61-afb2-4d65ef99ef53"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ded9fa0-38e7-4026-a5cb-5f41541464be"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("20b81ab4-5eaf-47af-a28d-51639baabc07"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b64eadb-7e5d-4b04-8132-5db64f750508"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c9f8e5f-d1c6-49b6-a7a2-fa33b58ebbc7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e863ded-3eab-4c9f-a508-bfd0420dfac4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("302c39ee-c5dc-4e02-8ff0-794b037dc94d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("312468ff-2a2e-4eb7-a362-c94376c03319"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("313268fc-39d9-44c2-b152-671939a1af0e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("34037c06-29fd-4d0c-a9c7-5525b3f53fb8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("36fc2c30-3c81-40a0-98f7-c2160ff52638"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4168798a-4dc1-4b53-821b-5dccf202c588"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("44f245b2-c030-46ed-a35e-d25eb4e5c1fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("528b366c-f1fe-492e-8291-b2ed16b34939"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("52e9e003-05e6-41d5-abfa-d1f3bcf52b17"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5a42bb75-281d-46cb-a712-0ad4e86b8506"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5f20c99a-9f2c-48a9-9dae-1fa9d9220805"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8b1e1c40-183a-47c2-a7f3-91c226986974"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("99a3b177-6c80-45ae-a154-70c0dff8e257"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c95b36f-7783-431e-adbb-79c20b413215"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a3bbfac0-f902-426a-8058-063cde504d3a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab3a5016-86d1-4434-937b-fcee627c5aef"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("abfe2a6a-9d5c-4486-999c-2fb7e38e5cc8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac8cf5c0-31b4-4e4e-bd20-ed8da119c16b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b7fcd747-e039-4ee6-96d8-0220cdcf43dd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b8c7f6f1-1514-44a0-8d8c-de1e54676351"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c02ccc01-986d-4415-8a11-62a80339f27a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cc06d497-ee3d-4c9a-964e-f37c11c422d8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d7cc2ff3-8d41-4e97-8090-80d048c549b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("df1b2589-cc0a-4917-867c-b25b224d55d3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7f67045-bbcd-4d06-b56b-01eba8e5968c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eebf54af-f6bd-4a62-a939-b68466a2d702"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f094e529-040e-40e2-9d3b-78bb87e64d08"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("feb042e8-df72-4477-a88f-46e5d1b9aa61"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fef80347-6362-47ad-b464-195e0fe3adc0"));

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
    }
}
