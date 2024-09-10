using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Products",
                type: "smallmoney",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
