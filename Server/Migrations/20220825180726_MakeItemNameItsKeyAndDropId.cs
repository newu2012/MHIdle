using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class MakeItemNameItsKeyAndDropId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Item_ItemId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMaterial_Item_ItemId",
                table: "RecipeMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_Item_ItemId",
                table: "ResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeItem_ItemId",
                table: "ResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_RecipeMaterial_ItemId",
                table: "RecipeMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ItemId",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "RecipeMaterial");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ResourceNodeItem",
                type: "character varying(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "RecipeMaterial",
                type: "character varying(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Recipe",
                type: "character varying(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ItemName",
                table: "ResourceNodeItem",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMaterial_ItemName",
                table: "RecipeMaterial",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ItemName",
                table: "Recipe",
                column: "ItemName");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Item_ItemName",
                table: "Recipe",
                column: "ItemName",
                principalTable: "Item",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMaterial_Item_ItemName",
                table: "RecipeMaterial",
                column: "ItemName",
                principalTable: "Item",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeItem_Item_ItemName",
                table: "ResourceNodeItem",
                column: "ItemName",
                principalTable: "Item",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Item_ItemName",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMaterial_Item_ItemName",
                table: "RecipeMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_Item_ItemName",
                table: "ResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeItem_ItemName",
                table: "ResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_RecipeMaterial_ItemName",
                table: "RecipeMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ItemName",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "RecipeMaterial");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ResourceNodeItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "RecipeMaterial",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ItemId",
                table: "ResourceNodeItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMaterial_ItemId",
                table: "RecipeMaterial",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ItemId",
                table: "Recipe",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Item_ItemId",
                table: "Recipe",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMaterial_Item_ItemId",
                table: "RecipeMaterial",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeItem_Item_ItemId",
                table: "ResourceNodeItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
