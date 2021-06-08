using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KabadaAPI.DataSource.Migrations
{
    public partial class AddPlanIsSWOTCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<bool>(
                name: "IsSwotCompleted",
                table: "BusinessPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.DropColumn(
                name: "IsSwotCompleted",
                table: "BusinessPlans");            
        }
    }
}
