using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddDurationAndInstrumentTypeForTerritory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationSecondsExploreInTerritory",
                table: "Territory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationSecondsExploreOnEnter",
                table: "Territory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentExpectedLevel",
                table: "Territory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentRequiredLevel",
                table: "Territory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentType",
                table: "Territory",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationSecondsExploreInTerritory",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "DurationSecondsExploreOnEnter",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "InstrumentExpectedLevel",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "InstrumentRequiredLevel",
                table: "Territory");

            migrationBuilder.DropColumn(
                name: "InstrumentType",
                table: "Territory");
        }
    }
}
