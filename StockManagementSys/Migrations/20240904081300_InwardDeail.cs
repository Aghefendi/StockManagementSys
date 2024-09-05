using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class InwardDeail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoDetails_Inwards_InwardId",
                table: "PoDetails");

            migrationBuilder.DropIndex(
                name: "IX_PoDetails_InwardId",
                table: "PoDetails");

            migrationBuilder.DropColumn(
                name: "InwardId",
                table: "PoDetails");

            migrationBuilder.CreateTable(
                name: "InwardDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InwardId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Quantity = table.Column<decimal>(type: "smallmoney", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InwardDetail_Inwards_InwardId",
                        column: x => x.InwardId,
                        principalTable: "Inwards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InwardDetail_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InwardDetail_InwardId",
                table: "InwardDetail",
                column: "InwardId");

            migrationBuilder.CreateIndex(
                name: "IX_InwardDetail_ProductCode",
                table: "InwardDetail",
                column: "ProductCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InwardDetail");

            migrationBuilder.AddColumn<int>(
                name: "InwardId",
                table: "PoDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoDetails_InwardId",
                table: "PoDetails",
                column: "InwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoDetails_Inwards_InwardId",
                table: "PoDetails",
                column: "InwardId",
                principalTable: "Inwards",
                principalColumn: "Id");
        }
    }
}
