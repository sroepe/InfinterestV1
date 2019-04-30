using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class bigmodelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "users",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserType = table.Column<string>(nullable: true),
                    AffiliateCode = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
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

            migrationBuilder.CreateTable(
                name: "listings",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    ListingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MLSLink = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    BrokerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listings", x => x.ListingId);
                    table.ForeignKey(
                        name: "FK_listings_address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_listings_users_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Confirmed = table.Column<bool>(nullable: false),
                    ListingId = table.Column<int>(nullable: false),
                    BrokerId = table.Column<int>(nullable: false),
                    OpenHouseDate = table.Column<DateTime>(nullable: false),
                    OpenHouseTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_events_users_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_events_listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "eventvendors",
                columns: table => new
                {
                    Confirmed = table.Column<bool>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventvendors", x => new { x.VendorId, x.EventId });
                    table.ForeignKey(
                        name: "FK_eventvendors_users_EventId",
                        column: x => x.EventId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventvendors_events_VendorId",
                        column: x => x.VendorId,
                        principalTable: "events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_events_BrokerId",
                table: "events",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_events_ListingId",
                table: "events",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_eventvendors_EventId",
                table: "eventvendors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_listings_AddressId",
                table: "listings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_listings_BrokerId",
                table: "listings",
                column: "BrokerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "business");

            migrationBuilder.DropTable(
                name: "eventvendors");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "listings");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
