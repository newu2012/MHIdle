using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class RenameProportionValueToValueInResourceNodeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProportionValue",
                table: "ResourceNodeProportion",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ProportionValue",
                table: "ResourceNodeItem",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ResourceNodeProportion",
                newName: "ProportionValue");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ResourceNodeItem",
                newName: "ProportionValue");
        }
    }
}
