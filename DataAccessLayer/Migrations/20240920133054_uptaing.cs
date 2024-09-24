using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class uptaing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PoDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "smallmoney");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "InwardDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "smallmoney");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "PoDetails",
                type: "smallmoney",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InwardDetail",
                type: "smallmoney",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
