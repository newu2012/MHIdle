using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddResourceNodePropertiesToMonster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TerritoryEventItem_TerritoryEvent_MonsterName",
                table: "TerritoryEventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TerritoryEventItem_TerritoryEvent_ResourceNodeName",
                table: "TerritoryEventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TerritoryEventProportion_TerritoryEvent_MonsterName",
                table: "TerritoryEventProportion");

            migrationBuilder.DropForeignKey(
                name: "FK_TerritoryEventProportion_TerritoryEvent_ResourceNodeName",
                table: "TerritoryEventProportion");

            migrationBuilder.DropIndex(
                name: "IX_TerritoryEventProportion_MonsterName",
                table: "TerritoryEventProportion");

            migrationBuilder.DropIndex(
                name: "IX_TerritoryEventProportion_ResourceNodeName",
                table: "TerritoryEventProportion");

            migrationBuilder.DropIndex(
                name: "IX_TerritoryEventItem_MonsterName",
                table: "TerritoryEventItem");

            migrationBuilder.DropIndex(
                name: "IX_TerritoryEventItem_ResourceNodeName",
                table: "TerritoryEventItem");

            migrationBuilder.DropColumn(
                name: "MonsterName",
                table: "TerritoryEventProportion");

            migrationBuilder.DropColumn(
                name: "ResourceNodeName",
                table: "TerritoryEventProportion");

            migrationBuilder.DropColumn(
                name: "MonsterName",
                table: "TerritoryEventItem");

            migrationBuilder.DropColumn(
                name: "ResourceNodeName",
                table: "TerritoryEventItem");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TerritoryEvent",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentType",
                table: "TerritoryEvent",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentRequiredLevel",
                table: "TerritoryEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentExpectedLevel",
                table: "TerritoryEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DurationSeconds",
                table: "TerritoryEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "TerritoryEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MonsterName",
                table: "TerritoryEventProportion",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResourceNodeName",
                table: "TerritoryEventProportion",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonsterName",
                table: "TerritoryEventItem",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResourceNodeName",
                table: "TerritoryEventItem",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TerritoryEvent",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentType",
                table: "TerritoryEvent",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentRequiredLevel",
                table: "TerritoryEvent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentExpectedLevel",
                table: "TerritoryEvent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DurationSeconds",
                table: "TerritoryEvent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "TerritoryEvent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventProportion_MonsterName",
                table: "TerritoryEventProportion",
                column: "MonsterName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventProportion_ResourceNodeName",
                table: "TerritoryEventProportion",
                column: "ResourceNodeName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventItem_MonsterName",
                table: "TerritoryEventItem",
                column: "MonsterName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventItem_ResourceNodeName",
                table: "TerritoryEventItem",
                column: "ResourceNodeName");

            migrationBuilder.AddForeignKey(
                name: "FK_TerritoryEventItem_TerritoryEvent_MonsterName",
                table: "TerritoryEventItem",
                column: "MonsterName",
                principalTable: "TerritoryEvent",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TerritoryEventItem_TerritoryEvent_ResourceNodeName",
                table: "TerritoryEventItem",
                column: "ResourceNodeName",
                principalTable: "TerritoryEvent",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TerritoryEventProportion_TerritoryEvent_MonsterName",
                table: "TerritoryEventProportion",
                column: "MonsterName",
                principalTable: "TerritoryEvent",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TerritoryEventProportion_TerritoryEvent_ResourceNodeName",
                table: "TerritoryEventProportion",
                column: "ResourceNodeName",
                principalTable: "TerritoryEvent",
                principalColumn: "Name");
        }
    }
}
