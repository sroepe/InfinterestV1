using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class fixingmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaOfHouseToFeature",
                table: "events");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "listings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    addressLine1 = table.Column<string>(nullable: true),
                    addressLine2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    postalCode = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    area = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    VendorUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_areas_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_areas_users_VendorUserId",
                        column: x => x.VendorUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    business = table.Column<string>(nullable: true),
                    VendorUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_business_users_VendorUserId",
                        column: x => x.VendorUserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "areas",
                columns: new[] { "AreaId", "EventId", "VendorUserId", "area" },
                values: new object[,]
                {
                    { 1, null, null, "Basement" },
                    { 12, null, null, "Other" },
                    { 11, null, null, "Yard" },
                    { 9, null, null, "Office" },
                    { 8, null, null, "Living Room" },
                    { 7, null, null, "Kitchen" },
                    { 10, null, null, "Patio" },
                    { 5, null, null, "Family / Media Room" },
                    { 4, null, null, "Dining Room" },
                    { 3, null, null, "Bedroom" },
                    { 2, null, null, "Bathroom" },
                    { 6, null, null, "Garage" }
                });

            migrationBuilder.InsertData(
                table: "business",
                columns: new[] { "BusinessId", "VendorUserId", "business" },
                values: new object[,]
                {
                    { 9, null, "Interior Design" },
                    { 14, null, "Technology and Security" },
                    { 13, null, "Photographers" },
                    { 12, null, "Pets and Animals" },
                    { 11, null, "Landscapers and Contractors" },
                    { 10, null, "Jewelery" },
                    { 8, null, "Home Based Business" },
                    { 2, null, "Baby and Kids" },
                    { 6, null, "Furnishings" },
                    { 5, null, "Food/Nutrition and Beverage" },
                    { 4, null, "Fashion and Apparel" },
                    { 3, null, "Entertainment and Music" },
                    { 15, null, "Wedding" },
                    { 1, null, "Art" },
                    { 7, null, "Health and Wellness" },
                    { 16, null, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_listings_AddressId",
                table: "listings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_areas_EventId",
                table: "areas",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_areas_VendorUserId",
                table: "areas",
                column: "VendorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_business_VendorUserId",
                table: "business",
                column: "VendorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_listings_address_AddressId",
                table: "listings",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listings_address_AddressId",
                table: "listings");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "business");

            migrationBuilder.DropIndex(
                name: "IX_listings_AddressId",
                table: "listings");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "listings");

            migrationBuilder.AddColumn<string>(
                name: "AreaOfHouseToFeature",
                table: "events",
                nullable: true);
        }
    }
}
