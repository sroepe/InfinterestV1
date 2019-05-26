using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class addressmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listings_address_AddressId",
                table: "listings");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "listings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_listings_address_AddressId",
                table: "listings",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listings_address_AddressId",
                table: "listings");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "listings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_listings_address_AddressId",
                table: "listings",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
