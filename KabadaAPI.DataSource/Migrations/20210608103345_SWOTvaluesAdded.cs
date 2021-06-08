using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class SWOTvaluesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
    table: "Texters",
    keyColumn: "Id",
    keyValue: new Guid("00397e14-79dc-4f9f-be31-f30aacaef60f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("07e48285-c84c-4143-b295-949f06587241"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("1ac5124e-a5f9-4184-a830-6740843e1d2e"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("1e31de01-f51b-4cfd-8d73-fe42f94429e5"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("2e92794a-1b4f-4e37-aee0-591e5646148f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("3eabf66f-aa13-4a9e-8bfa-63f3b68032c1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("45b5d2ac-1ff9-494c-b62f-5cc91bd956c1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("4819c005-1228-4a3d-aafa-aee626300e0b"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("53936dfb-bbfe-4281-9fff-ce5f8e6661b1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("542d2486-3b15-43c8-8b28-8872e805d0fb"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("5fcc9f4d-dbaf-4ba7-9187-b548e799788c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("62abf64e-3d2d-4e43-b795-55579955bd7b"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("62f7e9c9-5819-4f3a-b9ef-c1b853df917d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("72be0b41-fbf4-452c-88ad-a51bdf578cb1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("7f299c46-93bc-4788-bd46-094823544175"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("7f60413b-c732-4a3f-8812-3b9f860b7d14"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("889a6bbb-4f36-4b9e-b5db-a6500976502e"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("8d12ead0-c6f8-48b9-8f60-2f527f7684ab"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("9f399477-a374-48ef-8574-4522c313734d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a68d476b-8a22-405f-9852-5ab85a95ffac"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("cc93e7e7-35c2-4521-8fdb-5de537cba47c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("dabc4363-e459-4bf1-862b-1b2b5038b42c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("de2a50f0-32a3-4f99-b6d1-99c79395aeb1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("de71b7cf-a051-4fbb-a600-cde79db82dd9"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("e241f707-9094-4a43-893a-de5388f507fb"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("e349a7d6-8e31-4f10-9e47-6908821ec484"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("ee2cfd00-0c7e-48c5-9e15-f4368f0194ea"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("f2dee628-d359-473e-8286-5e95bad3c655"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("fc4783c0-a4cd-419c-b54a-233270a3deb6"));

            

            migrationBuilder.InsertData(
                table: "Texters",
                columns: new[] { "Id", "Kind", "LongValue", "MasterId", "Value" },
                values: new object[,]
                {
                    { new Guid("542d2486-3b15-43c8-8b28-8872e805d0fb"), (short)1, "a", null, "Land" },
                    { new Guid("1ac5124e-a5f9-4184-a830-6740843e1d2e"), (short)1, "a", null, "Facilities and equipment" },
                    { new Guid("2e92794a-1b4f-4e37-aee0-591e5646148f"), (short)1, "a", null, "Vehicles" },
                    { new Guid("fc4783c0-a4cd-419c-b54a-233270a3deb6"), (short)1, "a", null, "Inventory" },
                    { new Guid("8d12ead0-c6f8-48b9-8f60-2f527f7684ab"), (short)1, "a", null, "Skills and experience of employees" },
                    { new Guid("9f399477-a374-48ef-8574-4522c313734d"), (short)1, "a", null, "Corporate image" },
                    { new Guid("62abf64e-3d2d-4e43-b795-55579955bd7b"), (short)1, "a", null, "Patents" },
                    { new Guid("cc93e7e7-35c2-4521-8fdb-5de537cba47c"), (short)1, "a", null, "Trademarks" },
                    { new Guid("889a6bbb-4f36-4b9e-b5db-a6500976502e"), (short)1, "a", null, "Copyrights" },
                    { new Guid("45b5d2ac-1ff9-494c-b62f-5cc91bd956c1"), (short)1, "a", null, "Operational processes" },
                    { new Guid("1e31de01-f51b-4cfd-8d73-fe42f94429e5"), (short)1, "a", null, "Management processes" },
                    { new Guid("53936dfb-bbfe-4281-9fff-ce5f8e6661b1"), (short)1, "a", null, "Supporting processes" },
                    { new Guid("de2a50f0-32a3-4f99-b6d1-99c79395aeb1"), (short)1, "a", null, "Product design" },
                    { new Guid("7f60413b-c732-4a3f-8812-3b9f860b7d14"), (short)1, "a", null, "Product assortment" },
                    { new Guid("3eabf66f-aa13-4a9e-8bfa-63f3b68032c1"), (short)1, "a", null, "Packaging and labeling" },
                    { new Guid("07e48285-c84c-4143-b295-949f06587241"), (short)1, "a", null, "Complementary and after-sales service" },
                    { new Guid("f2dee628-d359-473e-8286-5e95bad3c655"), (short)1, "a", null, "Guarantees and warranties" },
                    { new Guid("00397e14-79dc-4f9f-be31-f30aacaef60f"), (short)1, "a", null, "Return of goods" },
                    { new Guid("5fcc9f4d-dbaf-4ba7-9187-b548e799788c"), (short)1, "a", null, "Price" },
                    { new Guid("ee2cfd00-0c7e-48c5-9e15-f4368f0194ea"), (short)1, "a", null, "Discounts" },
                    { new Guid("62f7e9c9-5819-4f3a-b9ef-c1b853df917d"), (short)1, "a", null, "Payment terms" },
                    { new Guid("4819c005-1228-4a3d-aafa-aee626300e0b"), (short)1, "a", null, "Advertising, PR and sales promotion" },
                    { new Guid("72be0b41-fbf4-452c-88ad-a51bdf578cb1"), (short)1, "a", null, "Customer convenient access to products" },
                    { new Guid("dabc4363-e459-4bf1-862b-1b2b5038b42c"), (short)3, "a", null, "Trend changes" },
                    { new Guid("a68d476b-8a22-405f-9852-5ab85a95ffac"), (short)3, "a", null, "New substitute products" },
                    { new Guid("e241f707-9094-4a43-893a-de5388f507fb"), (short)3, "a", null, "Arrival of new technology" },
                    { new Guid("7f299c46-93bc-4788-bd46-094823544175"), (short)3, "a", null, "New regulations" },
                    { new Guid("e349a7d6-8e31-4f10-9e47-6908821ec484"), (short)3, "a", null, "Unfulfilled customer need" },
                    { new Guid("de71b7cf-a051-4fbb-a600-cde79db82dd9"), (short)3, "a", null, "Taking business courses (training)" },

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {              
            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("00397e14-79dc-4f9f-be31-f30aacaef60f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("07e48285-c84c-4143-b295-949f06587241"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("1ac5124e-a5f9-4184-a830-6740843e1d2e"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("1e31de01-f51b-4cfd-8d73-fe42f94429e5"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("2e92794a-1b4f-4e37-aee0-591e5646148f"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("3eabf66f-aa13-4a9e-8bfa-63f3b68032c1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("45b5d2ac-1ff9-494c-b62f-5cc91bd956c1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("4819c005-1228-4a3d-aafa-aee626300e0b"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("53936dfb-bbfe-4281-9fff-ce5f8e6661b1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("542d2486-3b15-43c8-8b28-8872e805d0fb"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("5fcc9f4d-dbaf-4ba7-9187-b548e799788c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("62abf64e-3d2d-4e43-b795-55579955bd7b"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("62f7e9c9-5819-4f3a-b9ef-c1b853df917d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("72be0b41-fbf4-452c-88ad-a51bdf578cb1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("7f299c46-93bc-4788-bd46-094823544175"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("7f60413b-c732-4a3f-8812-3b9f860b7d14"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("889a6bbb-4f36-4b9e-b5db-a6500976502e"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("8d12ead0-c6f8-48b9-8f60-2f527f7684ab"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("9f399477-a374-48ef-8574-4522c313734d"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("a68d476b-8a22-405f-9852-5ab85a95ffac"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("cc93e7e7-35c2-4521-8fdb-5de537cba47c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("dabc4363-e459-4bf1-862b-1b2b5038b42c"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("de2a50f0-32a3-4f99-b6d1-99c79395aeb1"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("de71b7cf-a051-4fbb-a600-cde79db82dd9"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("e241f707-9094-4a43-893a-de5388f507fb"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("e349a7d6-8e31-4f10-9e47-6908821ec484"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("ee2cfd00-0c7e-48c5-9e15-f4368f0194ea"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("f2dee628-d359-473e-8286-5e95bad3c655"));

            migrationBuilder.DeleteData(
                table: "Texters",
                keyColumn: "Id",
                keyValue: new Guid("fc4783c0-a4cd-419c-b54a-233270a3deb6"));

            
        }
    }
}
