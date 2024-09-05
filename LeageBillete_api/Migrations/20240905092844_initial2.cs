using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeageBillete_api.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prix_eleve",
                table: "Price_Tickets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Prix_eleve",
                table: "Event_Days",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prix_eleve",
                table: "Price_Tickets");

            migrationBuilder.DropColumn(
                name: "Prix_eleve",
                table: "Event_Days");
        }
    }
}
