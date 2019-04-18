using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class manytomanydbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_confirmedVendors_users_EventId",
                table: "confirmedVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_confirmedVendors_events_VendorId",
                table: "confirmedVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_pendingVendors_users_EventId",
                table: "pendingVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_pendingVendors_events_VendorId",
                table: "pendingVendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pendingVendors",
                table: "pendingVendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_confirmedVendors",
                table: "confirmedVendors");

            migrationBuilder.RenameTable(
                name: "pendingVendors",
                newName: "pendingvendors");

            migrationBuilder.RenameTable(
                name: "confirmedVendors",
                newName: "confirmedvendors");

            migrationBuilder.RenameIndex(
                name: "IX_pendingVendors_EventId",
                table: "pendingvendors",
                newName: "IX_pendingvendors_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_confirmedVendors_EventId",
                table: "confirmedvendors",
                newName: "IX_confirmedvendors_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pendingvendors",
                table: "pendingvendors",
                columns: new[] { "VendorId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_confirmedvendors",
                table: "confirmedvendors",
                columns: new[] { "VendorId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_confirmedvendors_users_EventId",
                table: "confirmedvendors",
                column: "EventId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_confirmedvendors_events_VendorId",
                table: "confirmedvendors",
                column: "VendorId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pendingvendors_users_EventId",
                table: "pendingvendors",
                column: "EventId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pendingvendors_events_VendorId",
                table: "pendingvendors",
                column: "VendorId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_confirmedvendors_users_EventId",
                table: "confirmedvendors");

            migrationBuilder.DropForeignKey(
                name: "FK_confirmedvendors_events_VendorId",
                table: "confirmedvendors");

            migrationBuilder.DropForeignKey(
                name: "FK_pendingvendors_users_EventId",
                table: "pendingvendors");

            migrationBuilder.DropForeignKey(
                name: "FK_pendingvendors_events_VendorId",
                table: "pendingvendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pendingvendors",
                table: "pendingvendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_confirmedvendors",
                table: "confirmedvendors");

            migrationBuilder.RenameTable(
                name: "pendingvendors",
                newName: "pendingVendors");

            migrationBuilder.RenameTable(
                name: "confirmedvendors",
                newName: "confirmedVendors");

            migrationBuilder.RenameIndex(
                name: "IX_pendingvendors_EventId",
                table: "pendingVendors",
                newName: "IX_pendingVendors_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_confirmedvendors_EventId",
                table: "confirmedVendors",
                newName: "IX_confirmedVendors_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pendingVendors",
                table: "pendingVendors",
                columns: new[] { "VendorId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_confirmedVendors",
                table: "confirmedVendors",
                columns: new[] { "VendorId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_confirmedVendors_users_EventId",
                table: "confirmedVendors",
                column: "EventId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_confirmedVendors_events_VendorId",
                table: "confirmedVendors",
                column: "VendorId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pendingVendors_users_EventId",
                table: "pendingVendors",
                column: "EventId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pendingVendors_events_VendorId",
                table: "pendingVendors",
                column: "VendorId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
