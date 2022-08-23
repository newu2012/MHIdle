using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddMinimumAndMaximumQuantityForResourceNodeItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaximumQuantity",
                table: "ResourceNodeItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumQuantity",
                table: "ResourceNodeItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumQuantity",
                table: "ResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "MinimumQuantity",
                table: "ResourceNodeItem");
        }
    }
}
