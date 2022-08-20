using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ResourceNodeEventMaybeThisIsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeEventResourceNodeItem");

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventId",
                table: "ResourceNodeItem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventId",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventId",
                principalTable: "ResourceNodeEvent",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.CreateTable(
                name: "ResourceNodeEventResourceNodeItem",
                columns: table => new
                {
                    ResourceNodeEventsId = table.Column<int>(type: "integer", nullable: false),
                    ResourceNodeItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEventResourceNodeItem", x => new { x.ResourceNodeEventsId, x.ResourceNodeItemsId });
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventResourceNodeItem_ResourceNodeEvent_Resourc~",
                        column: x => x.ResourceNodeEventsId,
                        principalTable: "ResourceNodeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventResourceNodeItem_ResourceNodeItem_Resource~",
                        column: x => x.ResourceNodeItemsId,
                        principalTable: "ResourceNodeItem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeItemsId",
                table: "ResourceNodeEventResourceNodeItem",
                column: "ResourceNodeItemsId");
        }
    }
}
