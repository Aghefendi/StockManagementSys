using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class udpating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WareHouseStockQuantity",
                table: "ControlChecks",
                newName: "OutwardId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlChecks_OutwardId",
                table: "ControlChecks",
                column: "OutwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlChecks_Outwards_OutwardId",
                table: "ControlChecks",
                column: "OutwardId",
                principalTable: "Outwards",
                principalColumn: "OutwardId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlChecks_Outwards_OutwardId",
                table: "ControlChecks");

            migrationBuilder.DropIndex(
                name: "IX_ControlChecks_OutwardId",
                table: "ControlChecks");

            migrationBuilder.RenameColumn(
                name: "OutwardId",
                table: "ControlChecks",
                newName: "WareHouseStockQuantity");
        }
    }
}
