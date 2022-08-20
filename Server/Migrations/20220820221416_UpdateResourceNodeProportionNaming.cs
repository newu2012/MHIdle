using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    public partial class UpdateResourceNodeProportionNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeEventProportion");

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
                name: "IX_ResourceNodeProportion_ResourceNodeEventId",
                table: "ResourceNodeProportion",
                column: "ResourceNodeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeProportion_TerritoryId",
                table: "ResourceNodeProportion",
                column: "TerritoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceNodeProportion");

            migrationBuilder.CreateTable(
                name: "ResourceNodeEventProportion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceNodeEventId = table.Column<int>(type: "integer", nullable: false),
                    TerritoryId = table.Column<int>(type: "integer", nullable: false),
                    ProportionValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceNodeEventProportion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventProportion_ResourceNodeEvent_ResourceNodeE~",
                        column: x => x.ResourceNodeEventId,
                        principalTable: "ResourceNodeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceNodeEventProportion_Territory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Territory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventProportion_ResourceNodeEventId",
                table: "ResourceNodeEventProportion",
                column: "ResourceNodeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceNodeEventProportion_TerritoryId",
                table: "ResourceNodeEventProportion",
                column: "TerritoryId");
        }
    }
}
