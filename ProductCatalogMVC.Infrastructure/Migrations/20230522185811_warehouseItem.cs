using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalogMVC.Infrastructure.Migrations
{
    public partial class warehouseItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WarehouseItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WarehouseItems");
        }
    }
}
