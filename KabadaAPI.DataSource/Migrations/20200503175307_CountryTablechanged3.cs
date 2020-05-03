using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class CountryTablechanged3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Countries",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Countries",
                newName: "Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Countries",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Countries",
                newName: "latitude");
        }
    }
}
