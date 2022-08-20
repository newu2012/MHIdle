using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Item");

            migrationBuilder.RenameColumn(
                name: "ResourceValue",
                table: "Item",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ResourceType",
                table: "Item",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ResourceRarity",
                table: "Item",
                newName: "Rarity");

            migrationBuilder.RenameColumn(
                name: "ResourceName",
                table: "Item",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ResourceMaximumInStorage",
                table: "Item",
                newName: "MaximumInStorage");

            migrationBuilder.RenameColumn(
                name: "ResourceMaximumInInventory",
                table: "Item",
                newName: "MaximumInInventory");

            migrationBuilder.RenameColumn(
                name: "ResourceImagePath",
                table: "Item",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ResourceDescription",
                table: "Item",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Resource");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Resource",
                newName: "ResourceValue");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Resource",
                newName: "ResourceType");

            migrationBuilder.RenameColumn(
                name: "Rarity",
                table: "Resource",
                newName: "ResourceRarity");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Resource",
                newName: "ResourceName");

            migrationBuilder.RenameColumn(
                name: "MaximumInStorage",
                table: "Resource",
                newName: "ResourceMaximumInStorage");

            migrationBuilder.RenameColumn(
                name: "MaximumInInventory",
                table: "Resource",
                newName: "ResourceMaximumInInventory");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Resource",
                newName: "ResourceImagePath");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Resource",
                newName: "ResourceDescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "id");
        }
    }
}
