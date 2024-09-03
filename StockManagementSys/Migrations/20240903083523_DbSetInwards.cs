using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class DbSetInwards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InwardId",
                table: "PoDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inwards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InwardNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    InwardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inwards_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoDetails_InwardId",
                table: "PoDetails",
                column: "InwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwards_SupplierId",
                table: "Inwards",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoDetails_Inwards_InwardId",
                table: "PoDetails",
                column: "InwardId",
                principalTable: "Inwards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoDetails_Inwards_InwardId",
                table: "PoDetails");

            migrationBuilder.DropTable(
                name: "Inwards");

            migrationBuilder.DropIndex(
                name: "IX_PoDetails_InwardId",
                table: "PoDetails");

            migrationBuilder.DropColumn(
                name: "InwardId",
                table: "PoDetails");
        }
    }
}
