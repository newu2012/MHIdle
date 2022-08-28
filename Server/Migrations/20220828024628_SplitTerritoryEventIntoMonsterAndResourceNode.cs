using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class SplitTerritoryEventIntoMonsterAndResourceNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeItem");

            migrationBuilder.DropTable(
                name: "ResourceNodeProportion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceNode",
                table: "ResourceNode");

            migrationBuilder.RenameTable(
                name: "ResourceNode",
                newName: "TerritoryEvent");

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TerritoryEvent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TerritoryEvent",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TerritoryEvent",
                table: "TerritoryEvent",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "MonsterPart",
                columns: table => new
                {
                    PartName = table.Column<string>(type: "text", nullable: false),
                    MaximumHealth = table.Column<double>(type: "double precision", nullable: false),
                    CurrentHealth = table.Column<double>(type: "double precision", nullable: false),
                    MonsterName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterPart", x => x.PartName);
                    table.ForeignKey(
                        name: "FK_MonsterPart_TerritoryEvent_MonsterName",
                        column: x => x.MonsterName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryEventItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    MinimumQuantity = table.Column<int>(type: "integer", nullable: false),
                    MaximumQuantity = table.Column<int>(type: "integer", nullable: false),
                    TerritoryEventName = table.Column<string>(type: "text", nullable: false),
                    MonsterName = table.Column<string>(type: "text", nullable: true),
                    ResourceNodeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryEventItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_TerritoryEventItem_Item_ItemName",
                        column: x => x.ItemName,
                        principalTable: "Item",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerritoryEventItem_TerritoryEvent_MonsterName",
                        column: x => x.MonsterName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_TerritoryEventItem_TerritoryEvent_ResourceNodeName",
                        column: x => x.ResourceNodeName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_TerritoryEventItem_TerritoryEvent_TerritoryEventName",
                        column: x => x.TerritoryEventName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryEventProportion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    TerritoryName = table.Column<string>(type: "text", nullable: false),
                    TerritoryEventName = table.Column<string>(type: "text", nullable: false),
                    MonsterName = table.Column<string>(type: "text", nullable: true),
                    ResourceNodeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryEventProportion", x => x.id);
                    table.ForeignKey(
                        name: "FK_TerritoryEventProportion_Territory_TerritoryName",
                        column: x => x.TerritoryName,
                        principalTable: "Territory",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerritoryEventProportion_TerritoryEvent_MonsterName",
                        column: x => x.MonsterName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_TerritoryEventProportion_TerritoryEvent_ResourceNodeName",
                        column: x => x.ResourceNodeName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_TerritoryEventProportion_TerritoryEvent_TerritoryEventName",
                        column: x => x.TerritoryEventName,
                        principalTable: "TerritoryEvent",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterPart_MonsterName",
                table: "MonsterPart",
                column: "MonsterName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventItem_ItemName",
                table: "TerritoryEventItem",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventItem_MonsterName",
                table: "TerritoryEventItem",
                column: "MonsterName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventItem_ResourceNodeName",
                table: "TerritoryEventItem",
                column: "ResourceNodeName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventItem_TerritoryEventName",
                table: "TerritoryEventItem",
                column: "TerritoryEventName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventProportion_MonsterName",
                table: "TerritoryEventProportion",
                column: "MonsterName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventProportion_ResourceNodeName",
                table: "TerritoryEventProportion",
                column: "ResourceNodeName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventProportion_TerritoryEventName",
                table: "TerritoryEventProportion",
                column: "TerritoryEventName");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryEventProportion_TerritoryName",
                table: "TerritoryEventProportion",
                column: "TerritoryName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterPart");

            migrationBuilder.DropTable(
                name: "TerritoryEventItem");

            migrationBuilder.DropTable(
                name: "TerritoryEventProportion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TerritoryEvent",
                table: "TerritoryEvent");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TerritoryEvent");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TerritoryEvent");

            migrationBuilder.RenameTable(
                name: "TerritoryEvent",
                newName: "ResourceNode");

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentType",
                table: "ResourceNode",
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
                table: "ResourceNode",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentExpectedLevel",
                table: "ResourceNode",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DurationSeconds",
                table: "ResourceNode",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "ResourceNode",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceNode",
                table: "ResourceNode",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "ResourceNodeItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    ResourceNodeName = table.Column<string>(type: "text", nullable: false),
                    MaximumQuantity = table.Column<int>(type: "integer", nullable: false),
                    MinimumQuantity = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceNodeItem_Item_ItemName",
                        column: x => x.ItemName,
                        principalTable: "Item",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeItem_ResourceNode_ResourceNodeName",
                        column: x => x.ResourceNodeName,
                        principalTable: "ResourceNode",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceNodeProportion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ResourceNodeName = table.Column<string>(type: "text", nullable: false),
                    TerritoryName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeProportion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceNodeProportion_ResourceNode_ResourceNodeName",
                        column: x => x.ResourceNodeName,
                        principalTable: "ResourceNode",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeProportion_Territory_TerritoryName",
                        column: x => x.TerritoryName,
                        principalTable: "Territory",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ItemName",
                table: "ResourceNodeItem",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ResourceNodeName",
                table: "ResourceNodeItem",
                column: "ResourceNodeName");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeName",
                table: "ResourceNodeProportion",
                column: "ResourceNodeName");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_TerritoryName",
                table: "ResourceNodeProportion",
                column: "TerritoryName");
        }
    }
}
