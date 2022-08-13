using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ChangeIdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TerritoryID",
                table: "Territory",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ResourceID",
                table: "Resource",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegionID",
                table: "Region",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Territory",
                newName: "TerritoryID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Resource",
                newName: "ResourceID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Region",
                newName: "RegionID");
        }
    }
}
