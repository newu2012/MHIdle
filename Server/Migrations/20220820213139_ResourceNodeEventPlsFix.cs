using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ResourceNodeEventPlsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceNodeEventResourceNodeItem",
                table: "ResourceNodeEventResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeEventsId",
                table: "ResourceNodeEventResourceNodeItem");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventId",
                table: "ResourceNodeItem");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeEventId",
                table: "ResourceNodeEventResourceNodeItem",
                newName: "ResourceNodeItemsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceNodeEventResourceNodeItem",
                table: "ResourceNodeEventResourceNodeItem",
                columns: new[] { "ResourceNodeEventsId", "ResourceNodeItemsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeItemsId",
                table: "ResourceNodeEventResourceNodeItem",
                column: "ResourceNodeItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceNodeEventResourceNodeItem",
                table: "ResourceNodeEventResourceNodeItem");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeItemsId",
                table: "ResourceNodeEventResourceNodeItem");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeItemsId",
                table: "ResourceNodeEventResourceNodeItem",
                newName: "ResourceNodeEventId");

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventId",
                table: "ResourceNodeItem",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceNodeEventResourceNodeItem",
                table: "ResourceNodeEventResourceNodeItem",
                columns: new[] { "ResourceNodeEventId", "ResourceNodeEventsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeEventsId",
                table: "ResourceNodeEventResourceNodeItem",
                column: "ResourceNodeEventsId");
        }
    }
}
