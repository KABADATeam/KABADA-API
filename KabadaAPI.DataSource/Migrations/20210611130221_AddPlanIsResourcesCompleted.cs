using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class AddPlanIsResourcesCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<bool>(
                name: "IsResourcesCompleted",
                table: "BusinessPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.DropColumn(
                name: "IsResourcesCompleted",
                table: "BusinessPlans");            
        }
    }
}
