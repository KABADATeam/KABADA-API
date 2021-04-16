using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class AddedUserFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlans_Activities_ActivityId",
                table: "BusinessPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlans_Countries_CountryId",
                table: "BusinessPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_TypeId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("01c11456-a25d-464c-82f7-affdbf8b61aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("03e387ca-6901-44f9-b668-8947179339db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04156915-3b6a-426c-afa3-c919be1dde80"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b085bc4-87ba-4b4d-9712-94fdc5c5e249"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("14c7449d-1d4e-44be-a121-39d2fbbcb927"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("19938bf5-d608-4479-9d33-0263152aae04"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("19c9a496-113e-432f-818b-0cac6826c1bd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1c0cf7ba-e377-4579-b827-331ce81f6396"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1deb28f9-ce83-401e-a44f-5fbc621227a8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2404514c-e872-43ca-a3a1-34f5c2d44877"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42c96344-1a64-4d51-9bef-fea0eb399df2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("48d107ee-ee37-4d16-bb55-022e5c7d79cb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51ec6742-3f0a-4194-8c34-d1a602af273b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5543dca5-56d2-4d20-805e-a85d363e3bef"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5b3dfc90-8a00-4a39-a028-9ef977f5230e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5fc9ac01-cf9b-4cbe-bfec-1ce3c3c878db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6869a7ca-514a-4305-9694-25a5ecaacd3c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e8b8007-19fe-4540-abbd-d4f25d139cf0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("80e01a3d-aef4-4686-9f39-a0bd5cd53ae5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("82a03045-edbe-4689-9e8c-4a0357539ce8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("837632d0-aeb2-4383-8eed-4883327e672c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("86b69af7-7092-4d3e-b0d2-d061e9f4faa2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8897a384-f454-451c-afb9-4b4704cc65e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9566004f-1bf0-4d79-a9cc-758e596bf253"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("99e6e658-76f7-4cdd-af7c-007df834df9d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9aa4620d-cac4-4866-81d4-ccac9ceec330"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c050dff-56c1-4498-a0cd-d8ae6d9a6852"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a2581b15-5bfd-42fe-92b8-88122a74eecb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a96eacf7-1b7a-4ae6-9330-abad1e4d6b35"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c33f3bef-ca43-4faa-8b7f-3fd843b5011a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d5b7b411-79ec-47a0-a35b-2d8eed5000b4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4d2bfc0-afba-42ae-b679-0a6ea9117d96"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7a381cc-9597-4d92-83c0-08d82ea0cc03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8fd9ca2-465d-4e20-8422-8324706ba33f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9df115d-7475-47ce-8a4f-e12c07cd248f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed572569-ddea-4c67-8802-cc3292e538ed"));

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "BusinessPlans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityId",
                table: "BusinessPlans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Completed",
                table: "BusinessPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BusinessPlans",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<Guid>(
                name: "Img",
                table: "BusinessPlans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "BusinessPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ShortCode", "Title" },
                values: new object[,]
                {
                    { new Guid("f5ab89ba-5b03-4093-ad51-183ca4a7274c"), "AT", "Austria" },
                    { new Guid("921a6b99-1793-45a0-abca-471bbeb1eca8"), "LU", "Luxembourg" },
                    { new Guid("acee1875-6f0f-40e4-bddb-eb06d3c48533"), "MT", "Malta" },
                    { new Guid("a49e4976-bc70-40b0-a268-311fba1d5d79"), "NL", "Netherlands" },
                    { new Guid("d2752d29-dd87-4465-9585-8f56e7adac19"), "MK", "North Macedonia" },
                    { new Guid("9f952f5d-7a4c-4662-b617-51ab6efded02"), "NO", "Norway" },
                    { new Guid("ef5aa574-0186-47e1-90d1-9456079972ab"), "PL", "Poland" },
                    { new Guid("834f0556-611b-4d16-8acd-6e457cd73ccc"), "LT", "Lithuania" },
                    { new Guid("f8a7cc37-15be-4c7f-bc37-f8032bbd5faf"), "PT", "Portugal" },
                    { new Guid("063c428f-0911-431d-80a8-d769fed8fab4"), "RS", "Serbia" },
                    { new Guid("da36d956-ea45-4b43-ba0a-8315b65d0dbf"), "SK", "Slovakia" },
                    { new Guid("6f817dc3-b303-4858-982f-0d87d75011e9"), "SI", "Slovenia" },
                    { new Guid("099c2339-f0ba-416a-8678-bfeaebcf1d4a"), "ES", "Spain" },
                    { new Guid("346338d5-f6d2-4b6e-8feb-756df000d3ff"), "SE", "Sweden" },
                    { new Guid("27910a25-ce3d-436b-a192-7daac0200eaa"), "CH", "Switzerland" },
                    { new Guid("93d20ae7-fcb4-43b4-9bea-8cd4280713d1"), "RO", "Romania" },
                    { new Guid("a6cd036e-53c8-4a36-818c-117d66207143"), "LI", "Liechtenstein" },
                    { new Guid("634a1f18-7a15-4c07-af60-ff9646c4e878"), "LV", "Latvia" },
                    { new Guid("01ecafe2-a57a-471f-93cc-76a5ad6f00b8"), "IT", "Italy" },
                    { new Guid("e74b3be9-6234-4d11-9aec-0e8d53aabc13"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("aae07170-0dd1-4f18-96b2-62def28e2dfc"), "BE", "Belgium" },
                    { new Guid("09b8e6f3-47ad-46b1-a5a4-2b4b3db350ac"), "BG", "Bulgaria" },
                    { new Guid("fabfc024-d751-44ca-82be-cc9c7c6da9d1"), "HR", "Croatia" },
                    { new Guid("70c29370-b044-4fe0-b5fb-53553d86fc55"), "CY", "Cyprus" },
                    { new Guid("2c9c79a5-12b1-4aa4-b125-f69b86960323"), "CZ", "Czechia" },
                    { new Guid("dd3ea3c1-7667-4710-a67a-6303156a43b5"), "DK", "Denmark" },
                    { new Guid("34a99288-d33c-4ffb-8f54-1d3e2a365c97"), "EE", "Estonia" },
                    { new Guid("cef95951-cf02-44d7-b7c0-ed45580aeda4"), "FI", "Finland" },
                    { new Guid("38ccd330-416a-4317-b9d4-bc7c5c590ba5"), "FR", "France" },
                    { new Guid("9a3567e1-2096-4ab0-b0d8-3f021169d23c"), "DE", "Germany" },
                    { new Guid("4d043dd5-4e0e-4294-bbea-94dc578cbd18"), "EL", "Greece" },
                    { new Guid("268f286a-4679-4389-bcfa-b09b9dc14793"), "HU", "Hungary" },
                    { new Guid("fcf39f76-7425-4a7e-9087-6d9f186737cd"), "IS", "Iceland" },
                    { new Guid("2ee12e10-0780-49a6-8469-12e5f0b3329e"), "IE", "Ireland" },
                    { new Guid("757c1a3f-74ce-41d2-b975-a8ce28d5e25a"), "TR", "Turkey" },
                    { new Guid("ac63f5a4-6c6d-4ddc-965e-57a033fc3ad0"), "UK", "United Kingdom" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlans_Activities_ActivityId",
                table: "BusinessPlans",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlans_Countries_CountryId",
                table: "BusinessPlans",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_TypeId",
                table: "Users",
                column: "TypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlans_Activities_ActivityId",
                table: "BusinessPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlans_Countries_CountryId",
                table: "BusinessPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_TypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("01ecafe2-a57a-471f-93cc-76a5ad6f00b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("063c428f-0911-431d-80a8-d769fed8fab4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("099c2339-f0ba-416a-8678-bfeaebcf1d4a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("09b8e6f3-47ad-46b1-a5a4-2b4b3db350ac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("268f286a-4679-4389-bcfa-b09b9dc14793"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("27910a25-ce3d-436b-a192-7daac0200eaa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2c9c79a5-12b1-4aa4-b125-f69b86960323"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2ee12e10-0780-49a6-8469-12e5f0b3329e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("346338d5-f6d2-4b6e-8feb-756df000d3ff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("34a99288-d33c-4ffb-8f54-1d3e2a365c97"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("38ccd330-416a-4317-b9d4-bc7c5c590ba5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d043dd5-4e0e-4294-bbea-94dc578cbd18"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("634a1f18-7a15-4c07-af60-ff9646c4e878"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f817dc3-b303-4858-982f-0d87d75011e9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70c29370-b044-4fe0-b5fb-53553d86fc55"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("757c1a3f-74ce-41d2-b975-a8ce28d5e25a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("834f0556-611b-4d16-8acd-6e457cd73ccc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("921a6b99-1793-45a0-abca-471bbeb1eca8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("93d20ae7-fcb4-43b4-9bea-8cd4280713d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9a3567e1-2096-4ab0-b0d8-3f021169d23c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f952f5d-7a4c-4662-b617-51ab6efded02"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a49e4976-bc70-40b0-a268-311fba1d5d79"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a6cd036e-53c8-4a36-818c-117d66207143"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aae07170-0dd1-4f18-96b2-62def28e2dfc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac63f5a4-6c6d-4ddc-965e-57a033fc3ad0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acee1875-6f0f-40e4-bddb-eb06d3c48533"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cef95951-cf02-44d7-b7c0-ed45580aeda4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d2752d29-dd87-4465-9585-8f56e7adac19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("da36d956-ea45-4b43-ba0a-8315b65d0dbf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dd3ea3c1-7667-4710-a67a-6303156a43b5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e74b3be9-6234-4d11-9aec-0e8d53aabc13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ef5aa574-0186-47e1-90d1-9456079972ab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f5ab89ba-5b03-4093-ad51-183ca4a7274c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f8a7cc37-15be-4c7f-bc37-f8032bbd5faf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fabfc024-d751-44ca-82be-cc9c7c6da9d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fcf39f76-7425-4a7e-9087-6d9f186737cd"));

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "BusinessPlans");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "BusinessPlans");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "BusinessPlans");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "BusinessPlans");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "BusinessPlans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityId",
                table: "BusinessPlans",
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
                    { new Guid("19c9a496-113e-432f-818b-0cac6826c1bd"), "AT", "Austria" },
                    { new Guid("80e01a3d-aef4-4686-9f39-a0bd5cd53ae5"), "LU", "Luxembourg" },
                    { new Guid("1c0cf7ba-e377-4579-b827-331ce81f6396"), "MT", "Malta" },
                    { new Guid("c33f3bef-ca43-4faa-8b7f-3fd843b5011a"), "NL", "Netherlands" },
                    { new Guid("82a03045-edbe-4689-9e8c-4a0357539ce8"), "MK", "North Macedonia" },
                    { new Guid("d5b7b411-79ec-47a0-a35b-2d8eed5000b4"), "NO", "Norway" },
                    { new Guid("5b3dfc90-8a00-4a39-a028-9ef977f5230e"), "PL", "Poland" },
                    { new Guid("6869a7ca-514a-4305-9694-25a5ecaacd3c"), "LT", "Lithuania" },
                    { new Guid("42c96344-1a64-4d51-9bef-fea0eb399df2"), "PT", "Portugal" },
                    { new Guid("1deb28f9-ce83-401e-a44f-5fbc621227a8"), "RS", "Serbia" },
                    { new Guid("2404514c-e872-43ca-a3a1-34f5c2d44877"), "SK", "Slovakia" },
                    { new Guid("a2581b15-5bfd-42fe-92b8-88122a74eecb"), "SI", "Slovenia" },
                    { new Guid("0b085bc4-87ba-4b4d-9712-94fdc5c5e249"), "ES", "Spain" },
                    { new Guid("14c7449d-1d4e-44be-a121-39d2fbbcb927"), "SE", "Sweden" },
                    { new Guid("837632d0-aeb2-4383-8eed-4883327e672c"), "CH", "Switzerland" },
                    { new Guid("01c11456-a25d-464c-82f7-affdbf8b61aa"), "RO", "Romania" },
                    { new Guid("8897a384-f454-451c-afb9-4b4704cc65e2"), "LI", "Liechtenstein" },
                    { new Guid("5543dca5-56d2-4d20-805e-a85d363e3bef"), "LV", "Latvia" },
                    { new Guid("e8fd9ca2-465d-4e20-8422-8324706ba33f"), "IT", "Italy" },
                    { new Guid("9c050dff-56c1-4498-a0cd-d8ae6d9a6852"), "BA", "Bosnia and Herzegovina" },
                    { new Guid("7e8b8007-19fe-4540-abbd-d4f25d139cf0"), "BE", "Belgium" },
                    { new Guid("ed572569-ddea-4c67-8802-cc3292e538ed"), "BG", "Bulgaria" },
                    { new Guid("04156915-3b6a-426c-afa3-c919be1dde80"), "HR", "Croatia" },
                    { new Guid("a96eacf7-1b7a-4ae6-9330-abad1e4d6b35"), "CY", "Cyprus" },
                    { new Guid("e4d2bfc0-afba-42ae-b679-0a6ea9117d96"), "CZ", "Czechia" },
                    { new Guid("9566004f-1bf0-4d79-a9cc-758e596bf253"), "DK", "Denmark" },
                    { new Guid("86b69af7-7092-4d3e-b0d2-d061e9f4faa2"), "EE", "Estonia" },
                    { new Guid("99e6e658-76f7-4cdd-af7c-007df834df9d"), "FI", "Finland" },
                    { new Guid("9aa4620d-cac4-4866-81d4-ccac9ceec330"), "FR", "France" },
                    { new Guid("51ec6742-3f0a-4194-8c34-d1a602af273b"), "DE", "Germany" },
                    { new Guid("19938bf5-d608-4479-9d33-0263152aae04"), "EL", "Greece" },
                    { new Guid("48d107ee-ee37-4d16-bb55-022e5c7d79cb"), "HU", "Hungary" },
                    { new Guid("5fc9ac01-cf9b-4cbe-bfec-1ce3c3c878db"), "IS", "Iceland" },
                    { new Guid("e9df115d-7475-47ce-8a4f-e12c07cd248f"), "IE", "Ireland" },
                    { new Guid("03e387ca-6901-44f9-b668-8947179339db"), "TR", "Turkey" },
                    { new Guid("e7a381cc-9597-4d92-83c0-08d82ea0cc03"), "UK", "United Kingdom" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlans_Activities_ActivityId",
                table: "BusinessPlans",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlans_Countries_CountryId",
                table: "BusinessPlans",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_TypeId",
                table: "Users",
                column: "TypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
