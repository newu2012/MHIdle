using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ResourceNodeEventFixOnceAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeEventProportion_ResourceNodeEventProportionId",
                table: "ResourceNodeEventProportion");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventProportionId",
                table: "ResourceNodeEventProportion");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventProportionId",
                table: "ResourceNodeEvent");

            migrationBuilder.DropColumn(
                name: "ResourceNodeItemId",
                table: "ResourceNodeEvent");

            migrationBuilder.RenameColumn(
                name: "ResourceNodeItemId",
                table: "ResourceNodeEventResourceNodeItem",
                newName: "ResourceNodeEventsId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeItemId",
                table: "ResourceNodeEventResourceNodeItem",
                newName: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeEventsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResourceNodeEventsId",
                table: "ResourceNodeEventResourceNodeItem",
                newName: "ResourceNodeItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeEventsId",
                table: "ResourceNodeEventResourceNodeItem",
                newName: "IX_ResourceNodeEventResourceNodeItem_ResourceNodeItemId");

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventProportionId",
                table: "ResourceNodeEventProportion",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventProportionId",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeItemId",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventProportion_ResourceNodeEventProportionId",
                table: "ResourceNodeEventProportion",
                column: "ResourceNodeEventProportionId");
        }
    }
}
