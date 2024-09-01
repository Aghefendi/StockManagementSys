using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class PoHeaderAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    QuotationNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoHeaders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoHeaders_SupplierId",
                table: "PoHeaders",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoHeaders");
        }
    }
}
