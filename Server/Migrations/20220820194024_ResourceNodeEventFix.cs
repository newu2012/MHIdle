using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class ResourceNodeEventFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeEventTerritory");

            migrationBuilder.DropColumn(
                name: "TerritoryId",
                table: "ResourceNodeEvent");

            migrationBuilder.AddColumn<int>(
                name: "ResourceNodeEventId",
                table: "ResourceNodeEventProportion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventProportion_TerritoryId",
                table: "ResourceNodeEventProportion",
                column: "TerritoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeEventProportion_Territory_TerritoryId",
                table: "ResourceNodeEventProportion",
                column: "TerritoryId",
                principalTable: "Territory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceNodeEventProportion_Territory_TerritoryId",
                table: "ResourceNodeEventProportion");

            migrationBuilder.DropIndex(
                name: "IX_ResourceNodeEventProportion_TerritoryId",
                table: "ResourceNodeEventProportion");

            migrationBuilder.DropColumn(
                name: "ResourceNodeEventId",
                table: "ResourceNodeEventProportion");

            migrationBuilder.AddColumn<int>(
                name: "TerritoryId",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResourceNodeEventTerritory",
                columns: table => new
                {
                    TerritoriesId = table.Column<int>(type: "integer", nullable: false),
                    TerritoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEventTerritory", x => new { x.TerritoriesId, x.TerritoryId });
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventTerritory_ResourceNodeEvent_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "ResourceNodeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventTerritory_Territory_TerritoriesId",
                        column: x => x.TerritoriesId,
                        principalTable: "Territory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventTerritory_TerritoryId",
                table: "ResourceNodeEventTerritory",
                column: "TerritoryId");
        }
    }
}
