using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddDurationAndInstrumentTypeForResourceNodeEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationSeconds",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentExpectedLevel",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentRequiredLevel",
                table: "ResourceNodeEvent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentType",
                table: "ResourceNodeEvent",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationSeconds",
                table: "ResourceNodeEvent");

            migrationBuilder.DropColumn(
                name: "InstrumentExpectedLevel",
                table: "ResourceNodeEvent");

            migrationBuilder.DropColumn(
                name: "InstrumentRequiredLevel",
                table: "ResourceNodeEvent");

            migrationBuilder.DropColumn(
                name: "InstrumentType",
                table: "ResourceNodeEvent");
        }
    }
}
