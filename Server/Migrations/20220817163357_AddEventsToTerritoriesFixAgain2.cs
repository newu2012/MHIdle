using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddEventsToTerritoriesFixAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionEventName",
                table: "TerritoryEvent",
                newName: "Name");
            
            migrationBuilder.RenameColumn(
                name: "RegionEventDescription",
                table: "TerritoryEvent",
                newName: "Description");
            
            migrationBuilder.RenameColumn(
                name: "RegionEventProportionValue",
                table: "TerritoryEvent",
                newName: "ProportionValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TerritoryEvent",
                newName: "RegionEventName");
            
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TerritoryEvent",
                newName: "RegionEventDescription");
            
            migrationBuilder.RenameColumn(
                name: "ProportionValue",
                table: "TerritoryEvent",
                newName: "RegionEventProportionValue");
        }
    }
}
