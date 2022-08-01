using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "integer", nullable: false),
                    RegionDescription = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Territory",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TerritoryDescription = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: false),
                    RegionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territory", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK_Territories_Region",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Territory_RegionID",
                table: "Territory",
                column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
