using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infinterest.Migrations
{
    public partial class ichangedsomethings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_brokers_BrokerId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_EventVendors_EventVendorsId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_users_VendorUserId1",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_listings_brokers_BrokerId",
                table: "listings");

            migrationBuilder.DropForeignKey(
                name: "FK_users_EventVendors_EventVendorsId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_EventVendors_EventVendorsId1",
                table: "users");

            migrationBuilder.DropTable(
                name: "brokers");

            migrationBuilder.DropTable(
                name: "EventVendors");

            migrationBuilder.DropIndex(
                name: "IX_users_EventVendorsId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_EventVendorsId1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_events_BrokerId",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_EventVendorsId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "EventVendorsId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "EventVendorsId1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "MLSNumber",
                table: "listings");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "EventVendorsId",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "VendorUserId1",
                table: "events",
                newName: "BrokerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_events_VendorUserId1",
                table: "events",
                newName: "IX_events_BrokerUserId");

            migrationBuilder.AddColumn<bool>(
                name: "Confimed",
                table: "events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_BrokerUserId",
                table: "events",
                column: "BrokerUserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_listings_users_BrokerId",
                table: "listings",
                column: "BrokerId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_users_BrokerUserId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_listings_users_BrokerId",
                table: "listings");

            migrationBuilder.DropColumn(
                name: "Confimed",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "BrokerUserId",
                table: "events",
                newName: "VendorUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_events_BrokerUserId",
                table: "events",
                newName: "IX_events_VendorUserId1");

            migrationBuilder.AddColumn<int>(
                name: "EventVendorsId",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventVendorsId1",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MLSNumber",
                table: "listings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrokerId",
                table: "events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventVendorsId",
                table: "events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "brokers",
                columns: table => new
                {
                    BrokerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brokers", x => x.BrokerId);
                });

            migrationBuilder.CreateTable(
                name: "EventVendors",
                columns: table => new
                {
                    EventVendorsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendors", x => x.EventVendorsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_EventVendorsId",
                table: "users",
                column: "EventVendorsId");

            migrationBuilder.CreateIndex(
                name: "IX_users_EventVendorsId1",
                table: "users",
                column: "EventVendorsId1");

            migrationBuilder.CreateIndex(
                name: "IX_events_BrokerId",
                table: "events",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_events_EventVendorsId",
                table: "events",
                column: "EventVendorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_events_brokers_BrokerId",
                table: "events",
                column: "BrokerId",
                principalTable: "brokers",
                principalColumn: "BrokerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_events_EventVendors_EventVendorsId",
                table: "events",
                column: "EventVendorsId",
                principalTable: "EventVendors",
                principalColumn: "EventVendorsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_VendorUserId1",
                table: "events",
                column: "VendorUserId1",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_listings_brokers_BrokerId",
                table: "listings",
                column: "BrokerId",
                principalTable: "brokers",
                principalColumn: "BrokerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_EventVendors_EventVendorsId",
                table: "users",
                column: "EventVendorsId",
                principalTable: "EventVendors",
                principalColumn: "EventVendorsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_EventVendors_EventVendorsId1",
                table: "users",
                column: "EventVendorsId1",
                principalTable: "EventVendors",
                principalColumn: "EventVendorsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
