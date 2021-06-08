using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class SWAOTchangeMandatories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_SWOTs_BusinessPlans_BusinessPlanId",
                table: "Plan_SWOTs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_SWOTs_Texters_TexterId",
                table: "Plan_SWOTs");

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

            migrationBuilder.DropColumn(
                name: "Master",
                table: "Texters");

            migrationBuilder.AddColumn<Guid>(
                name: "MasterId",
                table: "Texters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TexterId",
                table: "Plan_SWOTs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessPlanId",
                table: "Plan_SWOTs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("2b6d28d3-9022-42e5-99bc-21eeee4c297b"), "AT", "Austria" },
                    { new Guid("b2e16db6-e262-4d82-a3d3-e45a07600427"), "LU", "Luxembourg" },
                    { new Guid("87bbdcfd-3fd5-473a-bf94-ae98738ad84e"), "MT", "Malta" },
                    { new Guid("f7dc0685-bc52-42e4-9323-f0b08087505f"), "NL", "Netherlands" },
                    { new Guid("480c0624-70ba-43f8-8073-b31db9a5e331"), "MK", "North Macedonia" },
                    { new Guid("bd42a561-9d2b-417e-9914-1e611315f7a5"), "NO", "Norway" },
                    { new Guid("a94e2b2b-f123-40f1-8602-586b4f5b922a"), "PL", "Poland" },
                    { new Guid("099a2509-89d1-4d84-b1f8-3a01c737c33f"), "LT", "Lithuania" },
                    { new Guid("e1b95dc5-9193-49ad-bef5-173e5a539ae5"), "PT", "Portugal" },
                    { new Guid("948f4fdd-c460-4009-965d-92a61f326227"), "RS", "Serbia" },
                    { new Guid("cb0da9e6-e4d2-4b76-bb82-c85b2cd2b4e5"), "SK", "Slovakia" },
                    { new Guid("6f5d27b0-c848-4d93-a8ce-81667943dbf3"), "SI", "Slovenia" },
                    { new Guid("30a1b2fc-722e-4284-9ecb-86fae1e72e00"), "ES", "Spain" },
                    { new Guid("1234fd13-beb5-46ee-b86b-f4948e0e2c47"), "SE", "Sweden" },
                    { new Guid("a82f9d8b-0cb4-4f27-bdfa-6cee0b58022f"), "CH", "Switzerland" },
                    { new Guid("5d6e9061-b1cd-4b62-8bbf-fcd49692b9e8"), "RO", "Romania" },
                    { new Guid("3d276db7-6c51-4c30-92da-9fa3478cf6e9"), "LI", "Liechtenstein" },
                    { new Guid("993e29b8-6f1e-4c5d-900f-61ec597c92bb"), "LV", "Latvia" },
                    { new Guid("ffd89cc1-45ad-47df-b17d-2d3caacc6cd8"), "IT", "Italy" },
                    { new Guid("9c8a2ddb-c9d9-4e23-835a-e214f24b2431"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("75734d67-f0dc-4ec7-96fe-2a2e70d7b0e2"), "BE", "Belgium" },
                    { new Guid("3e7af893-f1bb-462d-bcd2-3028af19dce8"), "BG", "Bulgaria" },
                    { new Guid("f27e19e4-80a5-4833-891f-a318b6e550ab"), "HR", "Croatia" },
                    { new Guid("ed080507-97ed-4bcb-9e01-21f143a873ad"), "CY", "Cyprus" },
                    { new Guid("00e29bcb-dcf4-42f2-a1c2-89e2f0cb8fa6"), "CZ", "Czechia" },
                    { new Guid("f6a2a115-867b-494c-a2eb-14200a4472fa"), "DK", "Denmark" },
                    { new Guid("3011e993-82ba-4b3b-b39d-63697087c502"), "EE", "Estonia" },
                    { new Guid("19616d6b-4f12-4943-8087-3a84f8ef7c9e"), "FI", "Finland" },
                    { new Guid("a0b1da2c-c6e2-4360-ae39-f97ebf492bb5"), "FR", "France" },
                    { new Guid("e3394948-bb17-4e1d-854c-1e9491a05b25"), "DE", "Germany" },
                    { new Guid("72bed04b-7915-45e3-980b-1d0474e5a86f"), "EL", "Greece" },
                    { new Guid("065328d2-450f-4b15-8283-761f2a9f188b"), "HU", "Hungary" },
                    { new Guid("2b62b868-4ef2-4c4b-a180-8562da252d24"), "IS", "Iceland" },
                    { new Guid("c4e3466c-1230-4eb4-ab09-0a3ce5e9e8fd"), "IE", "Ireland" },
                    { new Guid("75e0ca55-edc8-4bc8-afb4-29fbabe44a93"), "TR", "Turkey" },
                    { new Guid("0850a3ef-6301-426d-b1b3-5726b84ba4ff"), "UK", "United Kingdom" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_SWOTs_BusinessPlans_BusinessPlanId",
                table: "Plan_SWOTs",
                column: "BusinessPlanId",
                principalTable: "BusinessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_SWOTs_Texters_TexterId",
                table: "Plan_SWOTs",
                column: "TexterId",
                principalTable: "Texters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_SWOTs_BusinessPlans_BusinessPlanId",
                table: "Plan_SWOTs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_SWOTs_Texters_TexterId",
                table: "Plan_SWOTs");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00e29bcb-dcf4-42f2-a1c2-89e2f0cb8fa6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("065328d2-450f-4b15-8283-761f2a9f188b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0850a3ef-6301-426d-b1b3-5726b84ba4ff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("099a2509-89d1-4d84-b1f8-3a01c737c33f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1234fd13-beb5-46ee-b86b-f4948e0e2c47"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("19616d6b-4f12-4943-8087-3a84f8ef7c9e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b62b868-4ef2-4c4b-a180-8562da252d24"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b6d28d3-9022-42e5-99bc-21eeee4c297b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3011e993-82ba-4b3b-b39d-63697087c502"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("30a1b2fc-722e-4284-9ecb-86fae1e72e00"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3d276db7-6c51-4c30-92da-9fa3478cf6e9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3e7af893-f1bb-462d-bcd2-3028af19dce8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("480c0624-70ba-43f8-8073-b31db9a5e331"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d6e9061-b1cd-4b62-8bbf-fcd49692b9e8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f5d27b0-c848-4d93-a8ce-81667943dbf3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("72bed04b-7915-45e3-980b-1d0474e5a86f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("75734d67-f0dc-4ec7-96fe-2a2e70d7b0e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("75e0ca55-edc8-4bc8-afb4-29fbabe44a93"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("87bbdcfd-3fd5-473a-bf94-ae98738ad84e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("948f4fdd-c460-4009-965d-92a61f326227"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("993e29b8-6f1e-4c5d-900f-61ec597c92bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c8a2ddb-c9d9-4e23-835a-e214f24b2431"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a0b1da2c-c6e2-4360-ae39-f97ebf492bb5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a82f9d8b-0cb4-4f27-bdfa-6cee0b58022f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a94e2b2b-f123-40f1-8602-586b4f5b922a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b2e16db6-e262-4d82-a3d3-e45a07600427"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bd42a561-9d2b-417e-9914-1e611315f7a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c4e3466c-1230-4eb4-ab09-0a3ce5e9e8fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb0da9e6-e4d2-4b76-bb82-c85b2cd2b4e5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e1b95dc5-9193-49ad-bef5-173e5a539ae5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e3394948-bb17-4e1d-854c-1e9491a05b25"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed080507-97ed-4bcb-9e01-21f143a873ad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f27e19e4-80a5-4833-891f-a318b6e550ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f6a2a115-867b-494c-a2eb-14200a4472fa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f7dc0685-bc52-42e4-9323-f0b08087505f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ffd89cc1-45ad-47df-b17d-2d3caacc6cd8"));

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "Texters");

            migrationBuilder.AddColumn<Guid>(
                name: "Master",
                table: "Texters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TexterId",
                table: "Plan_SWOTs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessPlanId",
                table: "Plan_SWOTs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_SWOTs_BusinessPlans_BusinessPlanId",
                table: "Plan_SWOTs",
                column: "BusinessPlanId",
                principalTable: "BusinessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_SWOTs_Texters_TexterId",
                table: "Plan_SWOTs",
                column: "TexterId",
                principalTable: "Texters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
