using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class SplitItemToResourceAndInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ChanceToBreak",
                table: "Item",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Item",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InstrumentLevel",
                table: "Item",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentType",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChanceToBreak",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "InstrumentLevel",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "InstrumentType",
                table: "Item");
        }
    }
}
