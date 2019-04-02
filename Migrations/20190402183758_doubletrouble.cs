using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class doubletrouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_users_VendorUserId",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_VendorUserId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "CustomID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AreaOfHouse",
                table: "users");

            migrationBuilder.DropColumn(
                name: "BusinessCategory",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AreaOfHouseToFeature",
                table: "listings");

            migrationBuilder.DropColumn(
                name: "VendorUserId",
                table: "events");

            migrationBuilder.AddColumn<string>(
                name: "AreaOfHouseToFeature",
                table: "events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConfimedVendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfimedVendors", x => new { x.VendorId, x.EventId });
                    table.ForeignKey(
                        name: "FK_ConfimedVendors_users_EventId",
                        column: x => x.EventId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfimedVendors_events_VendorId",
                        column: x => x.VendorId,
                        principalTable: "events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PendingVendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingVendors", x => new { x.VendorId, x.EventId });
                    table.ForeignKey(
                        name: "FK_PendingVendors_users_EventId",
                        column: x => x.EventId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PendingVendors_events_VendorId",
                        column: x => x.VendorId,
                        principalTable: "events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfimedVendors_EventId",
                table: "ConfimedVendors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingVendors_EventId",
                table: "PendingVendors",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfimedVendors");

            migrationBuilder.DropTable(
                name: "PendingVendors");

            migrationBuilder.DropColumn(
                name: "AreaOfHouseToFeature",
                table: "events");

            migrationBuilder.AddColumn<string>(
                name: "CustomID",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaOfHouse",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessCategory",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaOfHouseToFeature",
                table: "listings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorUserId",
                table: "events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_events_VendorUserId",
                table: "events",
                column: "VendorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_VendorUserId",
                table: "events",
                column: "VendorUserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
