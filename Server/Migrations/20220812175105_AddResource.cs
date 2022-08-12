using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    public partial class AddResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ResourceName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ResourceDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ResourceRarity = table.Column<int>(type: "integer", nullable: false),
                    ResourceValue = table.Column<int>(type: "integer", nullable: false),
                    ResourceImagePath = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ResourceMaximumInInventory = table.Column<int>(type: "integer", nullable: false),
                    ResourceMaximumInStorage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
