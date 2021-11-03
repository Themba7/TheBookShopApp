using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookShop.DataAccess.Migrations
{
    public partial class DbCleanUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_Subscriptions_SubscriptionId",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_SubscriptionId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "Fees",
                table: "Subscriptions",
                newName: "Fee");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookShopAssetId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatronId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ApplicationUserId",
                table: "Subscriptions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BookShopAssetId",
                table: "Subscriptions",
                column: "BookShopAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PatronId",
                table: "Subscriptions",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_ApplicationUserId",
                table: "Subscriptions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_BookShopAssets_BookShopAssetId",
                table: "Subscriptions",
                column: "BookShopAssetId",
                principalTable: "BookShopAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Patrons_PatronId",
                table: "Subscriptions",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_ApplicationUserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_BookShopAssets_BookShopAssetId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Patrons_PatronId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ApplicationUserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_BookShopAssetId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_PatronId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "BookShopAssetId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "Fee",
                table: "Subscriptions",
                newName: "Fees");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Patrons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookShopAssetId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subscribed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true),
                    Unsubscribed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_BookShopAssets_BookShopAssetId",
                        column: x => x.BookShopAssetId,
                        principalTable: "BookShopAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookShopAssetId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Since = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true),
                    Until = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_BookShopAssets_BookShopAssetId",
                        column: x => x.BookShopAssetId,
                        principalTable: "BookShopAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_SubscriptionId",
                table: "Patrons",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_BookShopAssetId",
                table: "CheckoutHistories",
                column: "BookShopAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_SubscriptionId",
                table: "CheckoutHistories",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookShopAssetId",
                table: "Checkouts",
                column: "BookShopAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_SubscriptionId",
                table: "Checkouts",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_Subscriptions_SubscriptionId",
                table: "Patrons",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
