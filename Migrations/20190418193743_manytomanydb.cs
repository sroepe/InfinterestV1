using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class manytomanydb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmedVendors_users_EventId",
                table: "ConfirmedVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmedVendors_events_VendorId",
                table: "ConfirmedVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_PendingVendors_users_EventId",
                table: "PendingVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_PendingVendors_events_VendorId",
                table: "PendingVendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PendingVendors",
                table: "PendingVendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmedVendors",
                table: "ConfirmedVendors");

            migrationBuilder.RenameTable(
                name: "PendingVendors",
                newName: "pendingVendors");

            migrationBuilder.RenameTable(
                name: "ConfirmedVendors",
                newName: "confirmedVendors");

            migrationBuilder.RenameIndex(
                name: "IX_PendingVendors_EventId",
                table: "pendingVendors",
                newName: "IX_pendingVendors_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmedVendors_EventId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "PendingVendors");

            migrationBuilder.RenameTable(
                name: "confirmedVendors",
                newName: "ConfirmedVendors");

            migrationBuilder.RenameIndex(
                name: "IX_pendingVendors_EventId",
                table: "PendingVendors",
                newName: "IX_PendingVendors_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_confirmedVendors_EventId",
                table: "ConfirmedVendors",
                newName: "IX_ConfirmedVendors_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PendingVendors",
                table: "PendingVendors",
                columns: new[] { "VendorId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmedVendors",
                table: "ConfirmedVendors",
                columns: new[] { "VendorId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmedVendors_users_EventId",
                table: "ConfirmedVendors",
                column: "EventId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmedVendors_events_VendorId",
                table: "ConfirmedVendors",
                column: "VendorId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PendingVendors_users_EventId",
                table: "PendingVendors",
                column: "EventId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PendingVendors_events_VendorId",
                table: "PendingVendors",
                column: "VendorId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
