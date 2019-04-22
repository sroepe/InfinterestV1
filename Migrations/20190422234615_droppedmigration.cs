using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class droppedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ImgUrl = table.Column<string>(nullable: true),
                    BrokerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listings", x => x.ListingId);
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
                    AreaOfHouseToFeature = table.Column<string>(nullable: true),
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
                name: "confirmedvendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirmedvendors", x => new { x.VendorId, x.EventId });
                    table.ForeignKey(
                        name: "FK_confirmedvendors_users_EventId",
                        column: x => x.EventId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_confirmedvendors_events_VendorId",
                        column: x => x.VendorId,
                        principalTable: "events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pendingvendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pendingvendors", x => new { x.VendorId, x.EventId });
                    table.ForeignKey(
                        name: "FK_pendingvendors_users_EventId",
                        column: x => x.EventId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pendingvendors_events_VendorId",
                        column: x => x.VendorId,
                        principalTable: "events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_confirmedvendors_EventId",
                table: "confirmedvendors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_events_BrokerId",
                table: "events",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_events_ListingId",
                table: "events",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_listings_BrokerId",
                table: "listings",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_pendingvendors_EventId",
                table: "pendingvendors",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "confirmedvendors");

            migrationBuilder.DropTable(
                name: "pendingvendors");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "listings");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
