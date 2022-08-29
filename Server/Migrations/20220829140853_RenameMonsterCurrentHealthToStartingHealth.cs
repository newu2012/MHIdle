using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class RenameMonsterCurrentHealthToStartingHealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentHealth",
                table: "TerritoryEvent",
                newName: "StartingHealth");

            migrationBuilder.RenameColumn(
                name: "CurrentHealth",
                table: "MonsterPart",
                newName: "StartingHealth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartingHealth",
                table: "TerritoryEvent",
                newName: "CurrentHealth");

            migrationBuilder.RenameColumn(
                name: "StartingHealth",
                table: "MonsterPart",
                newName: "CurrentHealth");
        }
    }
}
