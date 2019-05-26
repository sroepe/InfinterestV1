using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class requeststatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "eventvendors");

            migrationBuilder.DropColumn(
                name: "Denied",
                table: "eventvendors");

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                table: "eventvendors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "eventvendors");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "eventvendors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Denied",
                table: "eventvendors",
                nullable: false,
                defaultValue: false);
        }
    }
}
