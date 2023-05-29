using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalogMVC.Infrastructure.Migrations
{
    public partial class itemsXML01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuppCategoryId",
                table: "WarehouseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Producent",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuppCategoryId",
                table: "WarehouseItems");

            migrationBuilder.DropColumn(
                name: "Producent",
                table: "Items");
        }
    }
}
