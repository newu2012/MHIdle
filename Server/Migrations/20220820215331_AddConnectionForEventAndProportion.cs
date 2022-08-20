using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddConnectionForEventAndProportion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ResourceNodeEventProportion_ResourceNodeEvent_ResourceNodeEventId",
                table: "ResourceNodeEventProportion",
                column: "ResourceNodeEventId",
                principalTable: "ResourceNodeEvent",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
