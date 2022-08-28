using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class RenameResourceNodeEventToResourceNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventName",
                table: "ResourceNodeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNodeEvent_ResourceNodeEventN~",
                table: "ResourceNodeProportion");

            migrationBuilder.DropTable(
                name: "ResourceNodeEvent");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeEventName",
                table: "ResourceNodeProportion",
                newName: "ResourceNodeName");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeEventName",
                table: "ResourceNodeProportion",
                newName: "IX_ResourceNodeProportion_ResourceNodeName");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeEventName",
                table: "ResourceNodeItem",
                newName: "ResourceNodeName");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventName",
                table: "ResourceNodeItem",
                newName: "IX_ResourceNodeItem_ResourceNodeName");

            migrationBuilder.CreateTable(
                name: "ResourceNode",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    DurationSeconds = table.Column<int>(type: "integer", nullable: false),
                    InstrumentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    InstrumentRequiredLevel = table.Column<int>(type: "integer", nullable: false),
                    InstrumentExpectedLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNode", x => x.Name);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeItem_ResourceNode_ResourceNodeName",
                table: "ResourceNodeItem",
                column: "ResourceNodeName",
                principalTable: "ResourceNode",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNode_ResourceNodeName",
                table: "ResourceNodeProportion",
                column: "ResourceNodeName",
                principalTable: "ResourceNode",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_ResourceNode_ResourceNodeName",
                table: "ResourceNodeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeProportion_ResourceNode_ResourceNodeName",
                table: "ResourceNodeProportion");

            migrationBuilder.DropTable(
                name: "ResourceNode");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeName",
                table: "ResourceNodeProportion",
                newName: "ResourceNodeEventName");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeName",
                table: "ResourceNodeProportion",
                newName: "IX_ResourceNodeProportion_ResourceNodeEventName");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeName",
                table: "ResourceNodeItem",
                newName: "ResourceNodeEventName");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceNodeItem_ResourceNodeName",
                table: "ResourceNodeItem",
                newName: "IX_ResourceNodeItem_ResourceNodeEventName");

            migrationBuilder.CreateTable(
                name: "ResourceNodeEvent",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DurationSeconds = table.Column<int>(type: "integer", nullable: false),
                    InstrumentExpectedLevel = table.Column<int>(type: "integer", nullable: false),
                    InstrumentRequiredLevel = table.Column<int>(type: "integer", nullable: false),
                    InstrumentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEvent", x => x.Name);
                });

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
        }
    }
}
