using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookShop.DataAccess.Migrations
{
    public partial class ColumTypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Launuage",
                table: "BookShopAssets",
                newName: "Language");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "BookShopAssets",
                newName: "Launuage");
        }
    }
}
