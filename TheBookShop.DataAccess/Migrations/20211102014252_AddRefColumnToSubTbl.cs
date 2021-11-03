using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookShop.DataAccess.Migrations
{
    public partial class AddRefColumnToSubTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionRefId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionRefId",
                table: "Subscriptions");
        }
    }
}
