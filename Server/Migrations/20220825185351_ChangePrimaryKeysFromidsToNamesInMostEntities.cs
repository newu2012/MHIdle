using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ChangePrimaryKeysFromidsToNamesInMostEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMaterial_Recipe_RecipeId",
                table: "RecipeMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeProportion");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeProportion_Territory_TerritoryId",
                table: "ResourceNodeProportion");

            migrationBuilder.DropForeignKey(
                name: "FK_Territory_Region_RegionId",
                table: "Territory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Territory",
                table: "Territory");

            migrationBuilder.DropIndex(
                name: "IX_Territory_RegionId",
                table: "Territory");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeEventId",
                table: "ResourceNodeProportion");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeProportion_TerritoryId",
                table: "ResourceNodeProportion");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceNodeEvent",
                table: "ResourceNodeEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_RecipeMaterial_RecipeId",
                table: "RecipeMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventId",
                table: "ResourceNodeProportion");

            migrationBuilder.DropColumn(
                name: "TerritoryId",
                table: "ResourceNodeProportion");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ResourceNodeEvent");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeMaterial");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Territory",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Territory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResourceNodeEventName",
                table: "ResourceNodeProportion",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TerritoryName",
                table: "ResourceNodeProportion",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "ResourceNodeItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");

            migrationBuilder.AddColumn<string>(
                name: "ResourceNodeEventName",
                table: "ResourceNodeItem",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ResourceNodeEvent",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Region",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "RecipeMaterial",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");

            migrationBuilder.AddColumn<string>(
                name: "RecipeName",
                table: "RecipeMaterial",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Recipe",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipe",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Item",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Territory",
                table: "Territory",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceNodeEvent",
                table: "ResourceNodeEvent",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Territory_RegionName",
                table: "Territory",
                column: "RegionName");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeEventName",
                table: "ResourceNodeProportion",
                column: "ResourceNodeEventName");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_TerritoryName",
                table: "ResourceNodeProportion",
                column: "TerritoryName");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventName",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventName");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMaterial_RecipeName",
                table: "RecipeMaterial",
                column: "RecipeName");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMaterial_Recipe_RecipeName",
                table: "RecipeMaterial",
                column: "RecipeName",
                principalTable: "Recipe",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventName",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventName",
                principalTable: "ResourceNodeEvent",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNodeEvent_ResourceNodeEventN~",
                table: "ResourceNodeProportion",
                column: "ResourceNodeEventName",
                principalTable: "ResourceNodeEvent",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeProportion_Territory_TerritoryName",
                table: "ResourceNodeProportion",
                column: "TerritoryName",
                principalTable: "Territory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Territory_Region_RegionName",
                table: "Territory",
                column: "RegionName",
                principalTable: "Region",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMaterial_Recipe_RecipeName",
                table: "RecipeMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventName",
                table: "ResourceNodeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNodeEvent_ResourceNodeEventN~",
                table: "ResourceNodeProportion");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeProportion_Territory_TerritoryName",
                table: "ResourceNodeProportion");

            migrationBuilder.DropForeignKey(
                name: "FK_Territory_Region_RegionName",
                table: "Territory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Territory",
                table: "Territory");

            migrationBuilder.DropIndex(
                name: "IX_Territory_RegionName",
                table: "Territory");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeEventName",
                table: "ResourceNodeProportion");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeProportion_TerritoryName",
                table: "ResourceNodeProportion");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventName",
                table: "ResourceNodeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceNodeEvent",
                table: "ResourceNodeEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_RecipeMaterial_RecipeName",
                table: "RecipeMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventName",
                table: "ResourceNodeProportion");

            migrationBuilder.DropColumn(
                name: "TerritoryName",
                table: "ResourceNodeProportion");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventName",
                table: "ResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "RecipeName",
                table: "RecipeMaterial");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Territory",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Territory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Territory",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventId",
                table: "ResourceNodeProportion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TerritoryId",
                table: "ResourceNodeProportion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "ResourceNodeItem",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventId",
                table: "ResourceNodeItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ResourceNodeEvent",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Region",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Region",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "RecipeMaterial",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeMaterial",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Recipe",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Territory",
                table: "Territory",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceNodeEvent",
                table: "ResourceNodeEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Territory_RegionId",
                table: "Territory",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeEventId",
                table: "ResourceNodeProportion",
                column: "ResourceNodeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_TerritoryId",
                table: "ResourceNodeProportion",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventId",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMaterial_RecipeId",
                table: "RecipeMaterial",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMaterial_Recipe_RecipeId",
                table: "RecipeMaterial",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventId",
                principalTable: "ResourceNodeEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeProportion",
                column: "ResourceNodeEventId",
                principalTable: "ResourceNodeEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeProportion_Territory_TerritoryId",
                table: "ResourceNodeProportion",
                column: "TerritoryId",
                principalTable: "Territory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Territory_Region_RegionId",
                table: "Territory",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "id");
        }
    }
}
