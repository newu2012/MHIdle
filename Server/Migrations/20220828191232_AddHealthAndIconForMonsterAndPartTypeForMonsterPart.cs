using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddHealthAndIconForMonsterAndPartTypeForMonsterPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentHealth",
                table: "TerritoryEvent",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "TerritoryEvent",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximumHealth",
                table: "TerritoryEvent",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartType",
                table: "MonsterPart",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHealth",
                table: "TerritoryEvent");

            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "TerritoryEvent");

            migrationBuilder.DropColumn(
                name: "MaximumHealth",
                table: "TerritoryEvent");

            migrationBuilder.DropColumn(
                name: "PartType",
                table: "MonsterPart");
        }
    }
}
