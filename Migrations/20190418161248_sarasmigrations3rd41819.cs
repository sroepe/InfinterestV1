using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class sarasmigrations3rd41819 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Confimed",
                table: "events",
                newName: "Confirmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Confirmed",
                table: "events",
                newName: "Confimed");
        }
    }
}
