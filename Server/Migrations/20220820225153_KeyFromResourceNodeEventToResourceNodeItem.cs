using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    public partial class KeyFromResourceNodeEventToResourceNodeItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MaximumInInventory = table.Column<int>(type: "integer", nullable: false),
                    MaximumInStorage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceNodeEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Territory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territory", x => x.id);
                    table.ForeignKey(
                        name: "FK_Territory_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ResourceNodeItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProportionValue = table.Column<double>(type: "double precision", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    ResourceNodeEventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceNodeItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeItem_ResourceNodeEvent_ResourceNodeEventId",
                        column: x => x.ResourceNodeEventId,
                        principalTable: "ResourceNodeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceNodeProportion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProportionValue = table.Column<double>(type: "double precision", nullable: false),
                    TerritoryId = table.Column<int>(type: "integer", nullable: false),
                    ResourceNodeEventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeProportion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceNodeProportion_ResourceNodeEvent_ResourceNodeEventId",
                        column: x => x.ResourceNodeEventId,
                        principalTable: "ResourceNodeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeProportion_Territory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Territory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ItemId",
                table: "ResourceNodeItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeItem_ResourceNodeEventId",
                table: "ResourceNodeItem",
                column: "ResourceNodeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_ResourceNodeEventId",
                table: "ResourceNodeProportion",
                column: "ResourceNodeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_TerritoryId",
                table: "ResourceNodeProportion",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Territory_RegionId",
                table: "Territory",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeItem");

            migrationBuilder.DropTable(
                name: "ResourceNodeProportion");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ResourceNodeEvent");

            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
