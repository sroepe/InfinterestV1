using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class rediddatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenHouseDate",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "OpenHouseTime",
                table: "events",
                newName: "OpenHouseDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenHouseDateTime",
                table: "events",
                newName: "OpenHouseTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHouseDate",
                table: "events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
