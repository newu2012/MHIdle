using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    public partial class ChangeTerritoryEventToResourceNodeEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerritoryEvent");

            migrationBuilder.CreateTable(
                name: "ResourceNodeEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TerritoryId = table.Column<int>(type: "integer", nullable: true),
                    ResourceNodeItemsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceNodeEventProportion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TerritoryId = table.Column<int>(type: "integer", nullable: false),
                    ResourceNodeItemsId = table.Column<int>(type: "integer", nullable: false),
                    ProportionValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEventProportion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventProportion_ResourceNodeEvent_ResourceNodeI~",
                        column: x => x.ResourceNodeItemsId,
                        principalTable: "ResourceNodeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ResourceNodeEventProportion_ResourceNodeItemsId",
                table: "ResourceNodeEventProportion",
                column: "ResourceNodeItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventTerritory_TerritoryId",
                table: "ResourceNodeEventTerritory",
                column: "TerritoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeEventProportion");

            migrationBuilder.DropTable(
                name: "ResourceNodeEventTerritory");

            migrationBuilder.DropTable(
                name: "ResourceNodeEvent");

            migrationBuilder.CreateTable(
                name: "TerritoryEvent",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProportionValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryEvent", x => x.id);
                });
        }
    }
}
